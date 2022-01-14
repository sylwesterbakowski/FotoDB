using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Controllers
{
    public class AutorController : Controller
    {
        public IActionResult Index()
        {
            var manager = new AutorManager();

            ////ręczne dodawanie danych do modelu i do bazy
            //var autor = new AutorModel();
            //autor.AutorModelID = 1;
            //autor.Nazwisko = "Kowalski";
            //autor.Imie = "Jan";
            //autor.KrajModelID = 1;
            //manager.AddAutor(autor);

            ////ręczne usuwanie danych z modelu i z bazy
            //manager.RemoveAutor(4);

            ////ręczne update danych w modelu i w bazie
            //var autor = new AutorModel();
            //autor.AutorModelID = 3;
            //autor.Nazwisko = "Nowak";
            //autor.Imie = "Karolina";
            //autor.KrajModelID = 2;
            //manager.UpdateAutor(autor);

            ////ręczna zmiana danych w modelu i w bazie
            //manager.ChangeNazwisko(5, "Nowaczek");
            //manager.ChangeImie(6, "Grzegorz");
            //manager.ChangeKraj(3, 3);

            var autors = manager.GetAutors();

            return View(autors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AutorModel autor)
        {
            var manager = new AutorManager();
            manager.AddAutor(autor);
            return RedirectToAction("Index");
        }
    }
}
