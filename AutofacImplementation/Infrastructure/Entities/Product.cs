using Core;
using System.ComponentModel.DataAnnotations;

//Just a basic implementation for maintaining structure
namespace Infrastructure.Entities
{
    /*
     * Notes:
     * ------
     * 1. Just a basic implementation for maintaining  DevSkill structure.
     * **/
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
