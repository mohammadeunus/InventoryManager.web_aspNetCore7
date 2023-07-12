using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{ 
    public class SalesDetailsModel
    {
        [Required]
        public int Id { get; set;}
        [MaxLength(50)]
        public string? InvoiceNo { get; set; }
        public int SaleQty { get; set; }
        public Decimal Price { get; set;}

        [Column(TypeName = "decimal(5,2)")]
        public decimal VatPercent { get; set; }
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
         
        [MaxLength(50)]
        public string? UpdatedBy { get; set; }
         
        public DateTime CreatedDate { get; set; }
          
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel? Product { get; set; }
    }
    public class SalesViewModel
    {
        public SalesDetailsModel? SalesDetailsViewModel { get; set; }
        public IEnumerable<SalesDetailsModel>? saleDetailsListViewModel { get; set; }
        public StockModel? stockModel { get; set; }
    }
}
