using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace POSystem.Models
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.MenuItems.Any()) return;

                context.MenuItems.AddRange(
                // 🥘 Main Dishes
                new MenuItem { Name = "Chicken Tagine with Lemon", Price = 75, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Kefta Tagine with Eggs", Price = 70, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Lamb Tagine with Prunes", Price = 85, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Vegetable Tagine", Price = 65, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Royal Couscous", Price = 90, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Beef Couscous", Price = 80, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Vegetarian Couscous", Price = 70, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Meat Skewers", Price = 60, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Chicken Skewers", Price = 55, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Roast Chicken", Price = 65, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Chicken Pastilla", Price = 75, Category = "Main Dishes", IsAvailable = true },
                new MenuItem { Name = "Seafood Pastilla", Price = 85, Category = "Main Dishes", IsAvailable = true },

                // 🍕 Pizzas
                new MenuItem { Name = "Margherita", Price = 50, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Pepperoni", Price = 60, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Four Cheese", Price = 65, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Vegetarian", Price = 55, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "BBQ Chicken", Price = 60, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Hawaiian", Price = 58, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Seafood", Price = 70, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Tunisian", Price = 62, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Neapolitan", Price = 55, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Calzone", Price = 60, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Merguez Pizza", Price = 65, Category = "Pizzas", IsAvailable = true },
                new MenuItem { Name = "Chef’s Special Pizza", Price = 70, Category = "Pizzas", IsAvailable = true },

                // 🍔 Burgers
                new MenuItem { Name = "Classic Beef Burger", Price = 55, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Cheeseburger", Price = 60, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Chicken Burger", Price = 50, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Spicy Chicken Burger", Price = 52, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Double Beef Burger", Price = 70, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "BBQ Bacon Burger", Price = 65, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Veggie Burger", Price = 48, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Fish Burger", Price = 53, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Mushroom Swiss Burger", Price = 62, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Blue Cheese Burger", Price = 64, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Crispy Chicken Burger", Price = 55, Category = "Burgers", IsAvailable = true },
                new MenuItem { Name = "Chef’s Special Burger", Price = 68, Category = "Burgers", IsAvailable = true },

                // Shawarmas and wraps
                new MenuItem { Name = "Chicken Shawarma Wrap", Price = 45, Category = "Wraps & Sandwiches", IsAvailable = true },
                new MenuItem { Name = "Grilled Veggie Wrap", Price = 38, Category = "Wraps & Sandwiches", IsAvailable = true },
                new MenuItem { Name = "Club Sandwich", Price = 50, Category = "Wraps & Sandwiches", IsAvailable = true },

                // Kids Menu
                new MenuItem { Name = "Mini Burger & Fries", Price = 35, Category = "Kids Menu", IsAvailable = true },
                new MenuItem { Name = "Chicken Nuggets & Fries", Price = 30, Category = "Kids Menu", IsAvailable = true },
                new MenuItem { Name = "Mini Pizza (Cheese)", Price = 32, Category = "Kids Menu", IsAvailable = true },

                // 🥗 Starters & Salads
                new MenuItem { Name = "Moroccan Harira Soup", Price = 35, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Lentil Soup", Price = 30, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Zaalouk (Eggplant Salad)", Price = 28, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Taktouka (Pepper & Tomato Salad)", Price = 28, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Mixed Moroccan Salads", Price = 40, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Green Salad", Price = 25, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Greek Salad", Price = 38, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Caesar Salad", Price = 42, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Chicken Caesar Salad", Price = 48, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Shrimp Avocado Salad", Price = 55, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Cheese & Olive Plate", Price = 32, Category = "Starters & Salads", IsAvailable = true },
                new MenuItem { Name = "Mini Briouats (Cheese/Meat)", Price = 36, Category = "Starters & Salads", IsAvailable = true },

                // ☕ Hot Drinks
                new MenuItem { Name = "Moroccan Mint Tea", Price = 18, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Black Tea", Price = 15, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Green Tea", Price = 15, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Coffee", Price = 20, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Espresso", Price = 22, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Double Espresso", Price = 28, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Cappuccino", Price = 30, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Café Latte", Price = 30, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Hot Chocolate", Price = 28, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Spiced Chai Latte", Price = 32, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Herbal Infusion (Chamomile)", Price = 25, Category = "Hot Drinks", IsAvailable = true },
                new MenuItem { Name = "Ginger & Honey Tea", Price = 26, Category = "Hot Drinks", IsAvailable = true },

                // 🥤 Cold Drinks
                new MenuItem { Name = "Mineral Water (Small)", Price = 10, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Mineral Water (Large)", Price = 18, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Sparkling Water", Price = 20, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Soda (Coca-Cola)", Price = 15, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Soda (Fanta)", Price = 15, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Soda (Sprite)", Price = 15, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Iced Tea (Lemon)", Price = 20, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Iced Tea (Peach)", Price = 20, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Fresh Orange Juice", Price = 25, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Fresh Lemon Juice", Price = 22, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Fruit Cocktail Juice", Price = 30, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Milkshake (Vanilla)", Price = 28, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Milkshake (Chocolate)", Price = 28, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Milkshake (Strawberry)", Price = 28, Category = "Cold Drinks", IsAvailable = true },
                new MenuItem { Name = "Iced Coffee", Price = 26, Category = "Cold Drinks", IsAvailable = true },

                // Sides
                new MenuItem { Name = "French Fries", Price = 18, Category = "Sides", IsAvailable = true },
                new MenuItem { Name = "Sweet Potato Fries", Price = 22, Category = "Sides", IsAvailable = true },
                new MenuItem { Name = "Onion Rings", Price = 20, Category = "Sides", IsAvailable = true },
                new MenuItem { Name = "Garlic Bread", Price = 15, Category = "Sides", IsAvailable = true },

                // 🍰 Desserts
                new MenuItem { Name = "Chocolate Cake", Price = 35, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Vanilla Crème Brûlée", Price = 38, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Moroccan Pastries (Assorted)", Price = 30, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Fruit Salad", Price = 28, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Cheesecake (Strawberry)", Price = 40, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Tiramisu", Price = 42, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Carrot Cake", Price = 35, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Ice Cream (2 scoops)", Price = 25, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Flan Caramel", Price = 30, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Chocolate Mousse", Price = 32, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Apple Tart", Price = 34, Category = "Desserts", IsAvailable = true },
                new MenuItem { Name = "Dates & Almonds", Price = 28, Category = "Desserts", IsAvailable = true }
                );


            context.SaveChanges();
        }
    }
}
