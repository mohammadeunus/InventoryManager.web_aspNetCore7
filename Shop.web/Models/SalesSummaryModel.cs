using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{
    [Table("SalesSummaries")]
    public class SalesSummaryModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string InvoiceNo { get; set; }
        public int TotalQty { get; set; }
        public Decimal TotalVat { get; set; }
        public Decimal TotalDiscount { get; set; }
        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
        public int CustomerId { get; set;}
        [ForeignKey("CustomerId")]
        public CustomerModel customers { get; set; } 
    }
}
