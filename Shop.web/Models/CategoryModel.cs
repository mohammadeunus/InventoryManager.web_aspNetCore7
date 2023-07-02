using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [Required]
        [MaxLength(50)]
        public string createdBy { get; set; }
        [Required]
        [MaxLength(50)]
        public string updatedBy { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        [Required]
        public DateTime updatedDate { get; set; }

        [Required] 
        public ICollection<ProductModel> product { get; set; }
    }
}
