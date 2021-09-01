using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data.DataModels
{
    public interface IIngredientList
    {
        int Id { get; set; }
        List<Ingredient> Ingredients { get; set; }
        Guid UserId { get; set; }
    }
}
