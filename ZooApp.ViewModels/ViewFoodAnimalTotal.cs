using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewFoodAnimalTotal
    {
        public ViewFoodAnimalTotal()
        {

        }
        public ViewFoodAnimalTotal(AnimalFood animalFood)
        {
            Id = animalFood.Id;
            AnimalName = animalFood.Animal.Name;
            TotalQty = animalFood.Quantity * animalFood.Animal.Quantity;
            TotalPrice = TotalQty * animalFood.Food.Price;
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double TotalQty { get; set; }
        public string AnimalName { get; set; }

       
    }
}
