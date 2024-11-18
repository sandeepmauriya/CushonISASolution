using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentsCoreApi.Models
{
    public class Investments
    {
        [Key]
        public int InvestmentID { get; set; }

        [ForeignKey("Customers")]
        public int CustomerID { get; set; }

        [ForeignKey("Funds")]
        public int FundID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal InvestmentAmount { get; set; }

        [Required]
        public DateTime InvestmentDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Customers Customers { get; set; }
        public virtual Funds Funds { get; set; }
    }


}
