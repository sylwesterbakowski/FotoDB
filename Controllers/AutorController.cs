using FotoDB.ILogic;
using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorManager _autorManager;

        public AutorController(IAutorManager autorManager)
        {
            _autorManager = autorManager;
        }
        public IActionResult Index()
        {
            //var manager = new AutorManager();

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

            //var autors = manager.GetAutors();
            var autors = _autorManager.GetAutors();
            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            ViewBag.ListKrajs = listKrajs;

            return View(autors);
        }

        [HttpGet]
        public IActionResult Create()
        {

            //List<FotoDB.Models.KrajModel> listKrajs = _autorManager..Krajs.ToList();
            //listKrajs.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            ViewBag.ListKrajs = listKrajs;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AutorModel autor)
        {
            //var manager = new AutorManager();
            //manager.AddAutor(autor);


            _autorManager.AddAutor(autor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create_dwa()
        {
            //ViewBag.KrajModel_ID = new SelectList(_autorManager.GetKrajs(), "Nazwa", "KrajModelID");
            //IEnumerable<SelectListItem>  lista_krajow =_autorManager.GetKrajs();




            //List<FotoDB.Models.KrajModel> listKrajs = _autorManager..Krajs.ToList();
            //listKrajs.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            ViewBag.ListKrajs = listKrajs;
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var manager = new AutorManager();
            //var autor = manager.GetAutor(id);
            var autor = _autorManager.GetAutor(id);

            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            foreach (var item in listKrajs)
            {
                if (item.Value == autor.KrajModelID.ToString())
                {
                    ViewBag.Kraj = item.Text;
                }
            }

            return View(autor);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            //var manager = new AutorManager();
            try
            {
                //manager.RemoveAutor(id);
                _autorManager.RemoveAutor(id);
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
            //var manager = new AutorManager();
            //var autor = manager.GetAutor(id);
            var autor = _autorManager.GetAutor(id);

            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            ViewBag.ListKrajs = listKrajs;


            return View(autor);
        }

        [HttpPost]
        public IActionResult Edit(AutorModel autor)
        {
            //var manager = new AutorManager();
            //manager.UpdateAutor(autor);
            _autorManager.UpdateAutor(autor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //var manager = new AutorManager();
            //var autor = manager.GetAutor(id);
            var autor = _autorManager.GetAutor(id);
            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            foreach (var item in listKrajs)
            {
                if (item.Value == autor.KrajModelID.ToString())
                {
                    ViewBag.Kraj = item.Text;
                }
            }
            return View(autor);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
