using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSystem.Controllers;
using POSystem.Models;

namespace POSystem.Controllers
{
    [AllowAnonymous] // 👈 Optional: allows all actions in this controller without login
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Feedback/Create?orderId=7
        public IActionResult Create(int? orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

        // POST: /Feedback/Create
        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                ViewBag.Message = "✅ Thank you for your feedback!";
                return View();
            }

            return View(feedback);
        }
        public IActionResult Index()
        {
            var feedbackList = _context.Feedbacks
                .OrderByDescending(f => f.SubmittedAt)
                .ToList();

            ViewBag.AverageRating = feedbackList.Any() ? feedbackList.Average(f => f.Rating) : 0;
            ViewBag.AverageService = feedbackList.Any() ? feedbackList.Average(f => f.Service) : 0;
            ViewBag.AverageFood = feedbackList.Any() ? feedbackList.Average(f => f.Food) : 0;

            return View(feedbackList);
        }

    }
}