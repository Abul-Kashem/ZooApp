using System;
using System.Collections.Generic;
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
        public List<ViewAnimal> GetAnimals()
        {
           
            

            //fetch db.animal data, and pull all rows table into RAM
            List<Animal> animals = db.Animals.ToList();

            //convert this data into view data
            List<ViewAnimal> viewAnimals = new List<ViewAnimal>();
            foreach (Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Name = animal.Name,
                    Origin = animal.Origin

                };
                viewAnimals.Add(viewAnimal);
            }
            //return
            return viewAnimals;
             
        }

        public ViewAnimal GetAnimal(int id)
        {
          Animal animal =  db.Animals.Find(id);
            return new ViewAnimal()
            {
                Origin = animal.Origin
            }; 
        }
    }
}
