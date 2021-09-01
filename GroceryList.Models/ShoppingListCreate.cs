using GroceryList.Data.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Models
{
   public class ShoppingListCreate
    {
        [Required]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string StoreName { get; set; }
        public DateTime DateOfTrip { get; set; }
    }
}
