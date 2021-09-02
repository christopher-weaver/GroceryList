using GroceryList.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Models
{
   public class ShoppingListEdit
    {
        public int Id { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public string StoreName { get; set; }

        public DateTime DateOfTrip { get; set; }
    }
}
