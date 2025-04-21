using System.ComponentModel.DataAnnotations;

namespace POSystem.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 9999)]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
