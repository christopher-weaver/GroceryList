using GroceryList.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Models.Models
{
    public class RecipeEdit
    {
        public int Id { get; set; }

        public string RecipeName { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }
}
