using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.web.Models
{
    [Table("Admins")]
    public class AdminModel
    {
        [Key]
        public int userName { get; set; }
        [MaxLength(40)]
        public string? name { get; set; }
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public string? email { get; set; }
        [Required]
        [StringLength(100),MinLength(8)]
        public string? password { get; set; }
        public bool isDelete { get; set; }
    }
}
