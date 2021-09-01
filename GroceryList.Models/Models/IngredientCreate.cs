using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services.Services
{
    public class IngredientCreate
    {
        [Required]
        public string Name { get; set; }

        // Amount required for recipe or remaining in pantry
        public decimal Grams { get; set; }

        public decimal Cost { get; set; }

        // public DateTime DateOfPurchase { get; set; }

        // public DateTime ExpirationDate { get; set; }
    }
}
