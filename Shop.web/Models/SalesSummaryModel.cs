using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.web.Models
{
    public class SalesSummaryModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string InvoiceNo { get; set; }
        public int TotalQty { get; set; } 

        [Column(TypeName = "decimal(5,2)")]
        public Decimal TotalVat { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public Decimal TotalDiscount { get; set; } 
        [MaxLength(50)]
        public string? CreatedBy { get; set; }

        [MaxLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerModel Customers { get; set; }
    }
}
