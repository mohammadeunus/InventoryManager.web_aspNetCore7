using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace Shop.web.Models
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

         
        [MaxLength(50)]
        public string? CreatedBy { get; set; } 
        [MaxLength(50)]
        public string? UpdatedBy { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public DateTime UpdatedDate { get; set; }
        public ICollection<ProductModel>? Product { get; set; }

    }
}
