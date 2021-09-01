using GroceryList.Data.DataModels;
using GroceryList.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Models
{
   public class ShoppingListItem
    {
        public int Id { get; set; }
        public DateTime DateOfTrip { get; set; }
        public string StoreName { get; set; }
        public List<IngredientDisplay> Ingredients { get; set; }
    }
}
