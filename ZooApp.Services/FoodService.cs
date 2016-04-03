using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        //create a db obj
        ZooContext db = new ZooContext();
        public List<ViewFood> GetAll() 
        {

            //fetch db.food data, and pull all rows table into RAM
            var foods = db.Foods.ToList();

            //convert this data into view data
            var viewFoods = new List<ViewFood>();
            foreach (var food in foods)
            {
                var viewFood = new ViewFood(food);
                viewFoods.Add(viewFood);
            }
            //return
            return viewFoods;

        }

        public ViewFood Get(int id)
        {
            var food = db.Foods.Find(id);
            return new ViewFood(food);
            //return new ViewFood(food)//This is same for above line
            //{
            //    Name = food.Name,
            //    Id = food.Id
            //};
        }
        public bool Save(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
            return true;
        }
        public bool Update(Food food)
        {
            try
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(Food food)
        {
            Food entity = db.Foods.Find(food.Id);
            db.Foods.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Food GetDbModel(int id)
        {
            return db.Foods.Find(id);
        }
    }
}
