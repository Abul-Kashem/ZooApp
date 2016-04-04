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
    public class AnimalServices
    {
        //create a db obj
        ZooContext db = new ZooContext();
        public List<ViewAnimal> GetAll()
        {
            //fetch db.animal data, and pull all rows table into RAM
            var animals = db.Animals.ToList();

            //convert this data into view data
            var viewAnimals = new List<ViewAnimal>();
            foreach (var animal in animals)
            {
                //var viewAnimal = new ViewAnimal()
                //{
                //    Name = animal.Name,
                //    Id = animal.Id,
                //    Quantity = animal.Quantity,
                //    Origin = animal.Origin

                //};
                var viewAnimal = new ViewAnimal(animal);
                viewAnimals.Add(viewAnimal);
            }
            //return
            return viewAnimals;
        }

        public ViewAnimal Get(int id)
        {
            var animal = db.Animals.Find(id);
            return new ViewAnimal(animal);
            //return new ViewAnimal()
            //{
            //    Name = animal.Name,
            //    Id = animal.Id,
            //    Quantity = animal.Quantity,
            //    Origin = animal.Origin
            //};
        }
        public bool Save(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }
        public bool Update(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Animal animal)
        {
            Animal entity = db.Animals.Find(animal.Id);
            db.Animals.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Animal GetDbModel(int id)
        {
            return db.Animals.Find(id);
        }
    }
}
