using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data.DataModels
{
    public class Pantry : IIngredientList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Ingredients))]
        public List<int> IngredientIds { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
