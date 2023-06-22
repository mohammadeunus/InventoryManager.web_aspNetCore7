using System.ComponentModel.DataAnnotations;

namespace Shop.web.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
