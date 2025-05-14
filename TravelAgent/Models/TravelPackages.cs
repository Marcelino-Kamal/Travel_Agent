using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelAgent.Models
{
    public class TravelPackages
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string  ImgUrl { get; set; }

        [Required]
        [Precision(18,2)]
        public decimal price { get; set; }
            
        [Required]
        public DateTime DateTime { get; set; }




    }
}
