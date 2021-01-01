using Core;
using System.ComponentModel.DataAnnotations;

//Just a basic implementation for maintaining structure
namespace Infrastructure.Entities
{
    public class Products : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
