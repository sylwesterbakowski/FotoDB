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
        //public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        public IActionResult Index(
                                    string sortOrder,
                                    string searchString)
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
            //var autors = _autorManager.GetAutors();
            //IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            //ViewBag.ListKrajs = listKrajs;

            //return View(autors);

            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NazwiskoSortParm = String.IsNullOrEmpty(sortOrder) ? "nazwisko_desc" : "";
            //ViewBag.ImieSortParm = sortOrder == "imie" ? "imie_desc" : "imie";
            //ViewBag.IDSortParm = sortOrder == "id" ? "id_desc" : "id";
            //ViewBag.IDKrajSortParm = sortOrder == "idkraj" ? "idkraj_desc" : "idkraj";

            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //ViewBag.CurrentFilter = searchString;

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NazwiskoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nazwisko_desc" : "";
            ViewData["ImieSortParm"] = sortOrder == "imie" ? "imie_desc" : "imie";
            ViewData["IDSortParm"] = sortOrder == "id" ? "id_desc" : "id";
            ViewData["IDKrajSortParm"] = sortOrder == "idkraj" ? "idkraj_desc" : "idkraj";

            ViewData["CurrentFilter"] = searchString;

            var autors = from a in _autorManager.GetAutors()
                        select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                autors = autors.Where(a => a.Nazwisko.ToLower().Contains(searchString.ToLower())
                                        || a.Imie.ToLower().Contains(searchString.ToLower()));
            }

            IEnumerable<SelectListItem> listKrajs = _autorManager.GetListKrajs();
            ViewBag.ListKrajs = listKrajs;
            //ViewBag.KrajSortParm = String.IsNullOrEmpty(sortOrder) ? "kraj_desc" : "kraj";
            //ViewBag.KrajSortParm = sortOrder == "kraj" ? "kraj_desc" : "kraj";

            switch (sortOrder)
            {
                case "nazwisko_desc":
                    autors = autors.OrderByDescending(a => a.Nazwisko);
                    break;
                case "imie":
                    autors = autors.OrderBy(a => a.Imie);
                    break;
                case "imie_desc":
                    autors = autors.OrderByDescending(a => a.Imie);
                    break;
                case "id":
                    autors = autors.OrderBy(a => a.AutorModelID);
                    break;
                case "id_desc":
                    autors = autors.OrderByDescending(a => a.AutorModelID);
                    break;
                case "idkraj":
                    autors = autors.OrderBy(a => a.KrajModelID);
                    break;
                case "idkraj_desc":
                    autors = autors.OrderByDescending(a => a.KrajModelID);
                    break;
                //case "kraj":
                //    ViewBag.ListKrajs = listKrajs.OrderBy(a => a.Text);
                //    break;
                //case "kraj_desc":
                //    ViewBag.ListKrajs = listKrajs.OrderByDescending(a => a.Text);
                //    break;
                default:
                    autors = autors.OrderBy(a => a.Nazwisko);
                    break;
            }


            //int pageSize = 4;
            //int pageNumber = (page ?? 1);
            //return View(autors.ToPagedList(pageNumber, pageSize));
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
