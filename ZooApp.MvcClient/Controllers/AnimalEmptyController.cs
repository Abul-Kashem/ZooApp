using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class AnimalEmptyController : Controller
    {
        AnimalServices services = new AnimalServices();
        // GET: AnimalEmpty
        public ActionResult Index()
        {
            var viewAnimals = services.GetAnimals(); 
            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
            ViewAnimal animal = services.GetAnimal(id);
            return View(animal);
        }
    }
}