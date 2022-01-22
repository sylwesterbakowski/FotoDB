using FotoDB.ILogic;
using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FotoDB.Controllers
{
    public class KrajController : Controller
    {
        private readonly IKrajManager _krajManager;

        public KrajController(IKrajManager krajManager)
        {
            _krajManager = krajManager;
        }
        //public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        //public async Task<IActionResult> Index(string sortOrder, string searchString)
        //public IActionResult Index(string sortOrder, string searchString)
        //public IActionResult Index(
        //                            string sortOrder,
        //                            string currentFilter,
        //                            string searchString,
        //                            int? pageNumber)
        public IActionResult Index(
                                    string sortOrder,
                                    string searchString)
        {
            //var manager = new KrajManager();

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

            //var krajs = manager.GetKrajs();

            //var krajs = _krajManager.GetKrajs();
            //return View(krajs);

            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.IDSortParm = sortOrder == "ID" ? "id_desc" : "ID";

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
            ViewData["NazwaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nazwa_desc" : "";
            ViewData["IDSortParm"] = sortOrder == "id" ? "id_desc" : "id";

            //if (searchString != null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            ViewData["CurrentFilter"] = searchString;


            var krajs = from k in _krajManager.GetKrajs()
                        select k;


            if (!String.IsNullOrEmpty(searchString))
            {
                krajs = krajs.Where(k => k.Nazwa.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "nazwa_desc":
                    krajs = krajs.OrderByDescending(k => k.Nazwa);
                    break;
                case "id":
                    krajs = krajs.OrderBy(k => k.KrajModelID);
                    break;
                case "id_desc":
                    krajs = krajs.OrderByDescending(k => k.KrajModelID);
                    break;
                default:
                    krajs = krajs.OrderBy(k => k.Nazwa);
                    break;
            }
            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //return View(krajs.ToPagedList(pageNumber, pageSize));
            //return View(await krajs.AsNoTracking().ToListAsync());
            //return View(krajs);
            //int pageSize = 3;
            //return View(PaginatedList<KrajModel>.CreateAsync(krajs.AsQueryable(), pageNumber ?? 1, pageSize));
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
            //var manager = new KrajManager();
            //manager.AddKraj(kraj);
            _krajManager.AddKraj(kraj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var manager = new KrajManager();
            //var kraj = manager.GetKraj(id);
            var kraj = _krajManager.GetKraj(id);
            return View(kraj);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            //var manager = new KrajManager();
            try
            {
                //manager.RemoveKraj(id);
                _krajManager.RemoveKraj(id);
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
            //var manager = new KrajManager();
            //var kraj = manager.GetKraj(id);
            var kraj = _krajManager.GetKraj(id);
            return View(kraj);
        }
        
        [HttpPost]
        public IActionResult Edit(KrajModel kraj)
        {
            //var manager = new KrajManager();
            //manager.UpdateKraj(kraj);
            _krajManager.UpdateKraj(kraj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //var manager = new KrajManager();
            //var kraj = manager.GetKraj(id);
            var kraj = _krajManager.GetKraj(id);
            return View(kraj);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
