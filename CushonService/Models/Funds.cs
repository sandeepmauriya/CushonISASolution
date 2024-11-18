using System.ComponentModel.DataAnnotations;

namespace InvestmentsCoreApi.Models
{
    public class Funds
    {
        [Key]
        public int FundID { get; set; }
        public string FundName { get; set; }
        public string Description { get; set; }
        public int RiskLevel { get; set; }
    }
}
