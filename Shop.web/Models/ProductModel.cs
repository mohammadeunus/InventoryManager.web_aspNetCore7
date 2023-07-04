using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; } 

        [Column(TypeName = "decimal(5,2)")]
        public decimal VatPercent { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercent { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
         
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
         
        [MaxLength(50)]
        public string? UpdatedBy { get; set; }
         
        public DateTime CreatedDate { get; set; }
         
        public DateTime UpdatedDate { get; set; }
          
        public SalesDetailsModel? SalesDetails { get; set; }
        public StockModel? Stocks { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; }

    }
}
