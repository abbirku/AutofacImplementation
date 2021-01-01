using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Products : Entity
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
