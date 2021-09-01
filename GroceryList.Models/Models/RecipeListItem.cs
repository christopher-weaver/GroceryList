using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    public class RecipeListItem
    {
        public int Id { get; set; }

        public string RecipeName { get; set; }
    }
}
