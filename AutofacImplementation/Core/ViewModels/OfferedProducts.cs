using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class OfferedProducts : Products
    {
        [Display(Name = "Offered Price")]
        public decimal OfferedPrice { get; set; }
    }
}
