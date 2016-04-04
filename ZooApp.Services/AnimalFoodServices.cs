using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalFoodServices
    {
        ZooContext db = new ZooContext();
        public List<ViewFoodTotal> GetViewFoodTotals()
        {
            /* Old Pattern Coding
            var animalFoods = db.AnimalFoods.ToList();
            List<ViewFoodTotal> totals = new List<ViewFoodTotal>();
            foreach (AnimalFood animalFood in animalFoods)
            {
                ViewFoodTotal foodTotal = new ViewFoodTotal(animalFood);
                totals.Add(foodTotal);
            }


            List<ViewFoodTotal> result = new List<ViewFoodTotal>();
            var groupBy = totals.GroupBy(x => x.FoodName);
            foreach (IGrouping<string, ViewFoodTotal> foodToatals in groupBy)
            {
                double totalPrice = foodToatals.Sum(x => x.TotalPrice);
                double quantity = foodToatals.Sum(x => x.TotalQty);
                ViewFoodTotal foodTotal = new ViewFoodTotal()
                {
                    FoodName = foodToatals.Key,
                    FoodPrice = foodToatals.First().FoodPrice,
                    TotalPrice = totalPrice,
                    TotalQty = quantity

                };
                result.Add(foodTotal);
            }

            return result;
            */
            //This is smart coding
            IQueryable<IGrouping<int, AnimalFood>> animalFoodGroups = db.AnimalFoods.GroupBy(x => x.FoodId);
            IQueryable<ViewFoodTotal> foodTotals = from foodGroup in animalFoodGroups
                                                   let food = foodGroup.FirstOrDefault()
                                                   let totalQuantity = foodGroup.Sum(x => x.Animal.Quantity * x.Quantity)
                                                   select new ViewFoodTotal()
                                                   {
                                                       FoodPrice = food.Food.Price,
                                                       FoodName = food.Food.Name,
                                                       TotalQty = totalQuantity,
                                                       TotalPrice = totalQuantity * food.Food.Price,
                                                       Id =food.Id,
                                                       FoodId =food.FoodId
                                                   };
            return foodTotals.ToList();


        }
        public List<ViewFoodAnimalTotal> GetViewFoodTotalsByFood(int foodId)
        {
            IQueryable<AnimalFood> animalFoods = db.AnimalFoods.Where(x => x.FoodId == foodId);
            var totals = animalFoods.Select(animalFood => new ViewFoodAnimalTotal()
            {
                Id = animalFood.Id,
                AnimalName = animalFood.Animal.Name,
                TotalQty = animalFood.Quantity * animalFood.Animal.Quantity,
                TotalPrice = animalFood.Quantity * animalFood.Animal.Quantity * animalFood.Food.Price
            }).ToList();

            return totals;
        }
    }
}
