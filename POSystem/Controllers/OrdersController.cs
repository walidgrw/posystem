using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSystem.Models;
using System.Linq;
using System.Text;

namespace POSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const decimal VATRate = 0.20m;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.MenuItems = _context.MenuItems.Where(m => m.IsAvailable).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Review(List<int> itemIds, List<int> quantities)
        {
            if (itemIds == null || itemIds.Count == 0)
                return RedirectToAction("Create");

            var model = new OrderViewModel
            {
                ItemIds = itemIds,
                Quantities = quantities,
                SelectedItems = new List<MenuItemSelection>()
            };

            decimal subtotal = 0;

            for (int i = 0; i < itemIds.Count; i++)
            {
                var item = _context.MenuItems.FirstOrDefault(m => m.Id == itemIds[i]);
                var qty = quantities[i];

                if (item == null || qty <= 0) continue;

                model.SelectedItems.Add(new MenuItemSelection
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = qty
                });

                subtotal += item.Price * qty;
            }

            model.Total = subtotal;
            model.VAT = subtotal * VATRate / (1 + VATRate);
            model.Subtotal = model.Total - model.VAT;

            return View("Review", model);
        }

        [HttpPost]
        public IActionResult Complete(OrderViewModel model)
        {
            Console.WriteLine("✅ POST to Complete() triggered");

            if (model == null || model.ItemIds == null || model.Quantities == null)
            {
                Console.WriteLine("❌ Model is null or missing ItemIds/Quantities");
                return RedirectToAction("Create");
            }

            Console.WriteLine($"🧾 Items: {model.ItemIds.Count} | Quantities: {model.Quantities.Count}");
            Console.WriteLine($"💳 Payments: {model.PaymentMethods?.Count ?? 0} methods");

            var order = new Order
            {
                CreatedBy = HttpContext.Session.GetString("UserName"),
                CreatedAt = DateTime.Now,
                Status = "Completed",
                Payments = new List<Payment>(),
                OrderItems = new List<OrderItem>()
            };

            for (int i = 0; i < model.ItemIds.Count; i++)
            {
                var item = _context.MenuItems.Find(model.ItemIds[i]);
                var qty = model.Quantities[i];

                if (item == null || qty <= 0) continue;

                order.OrderItems.Add(new OrderItem
                {
                    MenuItemId = item.Id,
                    Quantity = qty,
                    Price = item.Price
                });
            }

            decimal subtotal = 0;
            foreach (var itemId in model.ItemIds.Select((id, index) => new { id, qty = model.Quantities[index] }))
            {
                var item = _context.MenuItems.Find(itemId.id);
                if (item == null || itemId.qty <= 0) continue;

                subtotal += item.Price * itemId.qty;
            }

            order.Total = subtotal;
            order.VAT = subtotal * VATRate / (1 + VATRate);
            order.Subtotal = order.Total - order.VAT;


            decimal paymentSum = 0;

            if (model.PaymentMethods != null && model.PaymentAmounts != null)
            {
                for (int i = 0; i < model.PaymentMethods.Count; i++)
                {
                    var method = model.PaymentMethods[i];
                    var amount = model.PaymentAmounts[i];

                    if (string.IsNullOrEmpty(method) || amount <= 0) continue;

                    order.Payments.Add(new Payment
                    {
                        Method = method,
                        Amount = amount
                    });

                    paymentSum += amount;
                }
            }

            if (Math.Round(paymentSum, 2) != Math.Round(order.Total, 2))
            {
                Console.WriteLine("❌ Payment mismatch. Not saving order.");
                ModelState.AddModelError("", "Payment total must match order total.");
                return View("Review", model);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
            Console.WriteLine("✅ Order saved successfully");

            return RedirectToAction("Details", new { id = order.Id });
        }

        public IActionResult Details(int id, string category)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Payments)
                .FirstOrDefault(o => o.Id == id);

            var categories = _context.MenuItems.Select(m => m.Category).Distinct().ToList();
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;

            return View(order);
        }

        public IActionResult Dashboard()
        {
            var today = DateTime.Today;

            var todayOrders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.CreatedAt.Date == today)
                .ToList();

            ViewBag.TotalOrders = todayOrders.Count;
            ViewBag.TotalSales = todayOrders.Sum(o => o.Total);
            ViewBag.TotalVAT = todayOrders.Sum(o => o.VAT);

            var orderItems = todayOrders.SelectMany(o => o.OrderItems).ToList();

            var bestSellers = orderItems
                .GroupBy(oi => oi.MenuItem?.Name)
                .Select(group => new
                {
                    ItemName = group.Key ?? "Unknown",
                    Quantity = group.Sum(g => g.Quantity)
                })
                .OrderByDescending(g => g.Quantity)
                .Take(5)
                .ToList();

            ViewBag.BestSellers = bestSellers;

            return View();
        }

        public IActionResult History(DateTime? date)
        {
            var query = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(o => o.CreatedAt.Date == date.Value.Date);
            }

            var orders = query.OrderByDescending(o => o.CreatedAt).ToList();
            ViewBag.SelectedDate = date?.ToString("yyyy-MM-dd");

            return View(orders);
        }

        public IActionResult ExportToCsv()
        {
            var orders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToList();

            var csv = new StringBuilder();
            csv.AppendLine("Order ID,Date,Total,Status,Created By");

            foreach (var order in orders)
            {
                csv.AppendLine($"{order.Id},{order.CreatedAt:yyyy-MM-dd HH:mm},{order.Total:F2},{order.Status},{order.CreatedBy}");
            }

            var fileName = "orders_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            var fileBytes = Encoding.UTF8.GetBytes(csv.ToString());

            return File(fileBytes, "text/csv", fileName);
        }

        public IActionResult CloseShift(DateTime? from, DateTime? to)
        {
            var start = from ?? DateTime.Today;
            var end = to?.Date.AddDays(1).AddTicks(-1) ?? DateTime.Now;

            var orders = _context.Orders
                .Include(o => o.Payments)
                .Where(o => o.CreatedAt >= start && o.CreatedAt <= end)
                .ToList();

            var report = new ShiftReportViewModel
            {
                From = start,
                To = end,
                TotalOrders = orders.Count,
                TotalSales = orders.Sum(o => o.Total),
                TotalVAT = orders.Sum(o => o.VAT),
                TotalSubtotal = orders.Sum(o => o.Subtotal),
                PaymentSummary = orders
                    .SelectMany(o => o.Payments)
                    .GroupBy(p => p.Method)
                    .ToDictionary(g => g.Key, g => g.Sum(p => p.Amount)),
                Staff = orders
                    .Select(o => o.CreatedBy)
                    .Distinct()
                    .ToList()
            };

            return View(report);
        }
    }
}