using GroceryList.Data.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    public class RecipeCreate
    {
        [Required]
        public string RecipeName { get; set; }

        [Required]
        public virtual List<Ingredient> Ingredients { get; set; }

    }
}
