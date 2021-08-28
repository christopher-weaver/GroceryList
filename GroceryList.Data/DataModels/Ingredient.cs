using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data.DataModels
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal GramsRemaining { get; set; }

        public decimal Cost { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
