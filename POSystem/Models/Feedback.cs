using System;
using System.ComponentModel.DataAnnotations;

namespace POSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Display(Name = "Service Quality")]
        [Range(1, 5)]
        public int Service { get; set; }

        [Display(Name = "Food Quality")]
        [Range(1, 5)]
        public int Food { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
