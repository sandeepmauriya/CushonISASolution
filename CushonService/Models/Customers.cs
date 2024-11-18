using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsCoreApi.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string NiNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Navigation property
        public virtual ICollection<Investments> Investments { get; set; }
    }
}
