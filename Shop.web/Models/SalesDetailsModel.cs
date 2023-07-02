using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{
    [Table("SalesDetails")]
    public class SalesDetailsModel
    {
        [Required]
        public int Id { get; set;}
        [MaxLength(50)]
        public string InvoiceNo { get; set; }
        public int SaleQty { get; set; }
        public Decimal Price { get; set;}
        public decimal VatPercent { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }


    }
}
