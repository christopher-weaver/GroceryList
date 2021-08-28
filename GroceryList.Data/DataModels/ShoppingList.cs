using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data.DataModels
{
    public class ShoppingList : IIngredientList
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey(nameof(Ingredients))]
        public List<int> IngredientIds { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
