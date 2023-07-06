using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Shop.web.Models
{
    [Table("Stocks")]
    public class StockModel
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        public int Qty { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
         
        [MaxLength(50)]
        public string? UpdatedBy { get; set; }
         
        public DateTime CreatedDate { get; set; }
         
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel Products { get; set; }
    }
}
