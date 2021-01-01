using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.ViewModels
{
    public class OfferedProducts : Products
    {
        [Display(Name = "Offered Price")]
        public decimal OfferedPrice { get; set; }
    }
}
