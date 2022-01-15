using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Controllers
{
    public class KrajController : Controller
    {
        public IActionResult Index()
        {
            var manager = new KrajManager();

            ////ręczne dodawanie danych do modelu i do bazy
            //var kraj = new KrajModel();
            //kraj.KrajModelID = 1;
            //kraj.Nazwa = "Polska";
            //manager.AddKraj(kraj);

            ////ręczne usuwanie danych z modelu i z bazy
            //manager.RemoveKraj(5);

            ////ręczne update danych w modelu i w bazie
            //var kraj = new KrajModel();
            //kraj.KrajModelID = 2;
            //kraj.Nazwa = "Niemcy";
            //manager.UpdateKraj(kraj);

            ////ręczna zmiana danych w modelu i w bazie
            //manager.ChangeNazwa(3, "Szkocja");

            var krajs = manager.GetKrajs();

            return View(krajs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(KrajModel kraj)
        {
            var manager = new KrajManager();
            manager.AddKraj(kraj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var manager = new KrajManager();
            var kraj = manager.GetKraj(id);
            return View(kraj);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var manager = new KrajManager();
            try
            {
                manager.RemoveKraj(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorTitle = "Delete";
                ViewBag.ErrorMessage = "You cannot delete this record because it does not exist in the database.";
                return View("Error");
            }   
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manager = new KrajManager();
            var kraj = manager.GetKraj(id);
            return View(kraj);
        }
        
        [HttpPost]
        public IActionResult Edit(KrajModel kraj)
        {
            var manager = new KrajManager();
            manager.UpdateKraj(kraj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var manager = new KrajManager();
            var kraj = manager.GetKraj(id);
            return View(kraj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
