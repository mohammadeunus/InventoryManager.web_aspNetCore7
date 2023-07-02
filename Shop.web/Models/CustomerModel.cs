using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{
    [Table("Customers")]
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Address { get; set; } 
        public SalesSummaryModel SalesSummary { get; set; }

    }
}
