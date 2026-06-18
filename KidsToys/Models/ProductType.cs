using System.ComponentModel.DataAnnotations;

namespace KidsToys.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        [Required]
  
        public string Name { get; set; }
    }
}
