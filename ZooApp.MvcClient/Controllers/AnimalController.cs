using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class AnimalController : Controller
    {
        AnimalServices service = new AnimalServices();
        // GET: Animal
        public ActionResult Index()
        {
            var viewAnimals = service.GetAll();
            return View(viewAnimals);
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            ViewAnimal viewAnimal = service.Get(id);
            return View(viewAnimal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            try
            {
                // TODO: Add insert logic here
                bool saved = service.Save(animal);
                if (saved)
                {
                    return RedirectToAction("Index");
                }

                return View(animal);
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            Animal animal = service.GetDbModel(id);
            return View(animal);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            try
            {
                // TODO: Add update logic here
                bool update = service.Update(animal);
                if (update)
                {
                    return RedirectToAction("Index");
                }
                return View(animal);
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            Animal  animal = service.GetDbModel(id);
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            try
            {
                // TODO: Add delete logic here
                
                bool deleted = service.Delete(animal);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }

                return View(animal);
            }
            catch
            {
                return View();
            }
        }
    }
}
