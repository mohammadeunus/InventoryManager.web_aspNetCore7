using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{
    [Table("Admins")]
    public class AdminModel
    {
        [Key] 
        public int UserName { get; set; }
        [MaxLength(40)]
        public string? Name { get; set; }
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        [StringLength(100),MinLength(8)]
        public string? Password { get; set; }
        public bool IsDelete { get; set; }
 
    }
}
