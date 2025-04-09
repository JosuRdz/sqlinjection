using System.ComponentModel.DataAnnotations;

namespace Spark_Project.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Beneficiary { get; set; } = string.Empty;
    }
}
