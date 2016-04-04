using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal()
        {

        }
        public ViewFoodTotal(AnimalFood animalFood)
        {
            FoodName = animalFood.Food.Name;
            FoodPrice = animalFood.Food.Price;
            TotalQty = animalFood.Animal.Quantity * animalFood.Quantity;
            TotalPrice = animalFood.Food.Price * TotalQty;
            Id = animalFood.Id;
            FoodId = animalFood.FoodId;

        }
        public int Id { get; set; }
        public int FoodId { get; set; }

        public string FoodName { get; set; }
        public double FoodPrice { get; set; }

        public double TotalPrice { get; set; }
        public double TotalQty { get; set; }
    }
} 
