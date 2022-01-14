using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Controllers
{
    public class FotoController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FotoController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var manager = new FotoManager();

            ////ręczne dodawanie danych do modelu i do bazy
            //var foto = new FotoModel();
            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //string fileName = "wwsi";
            //string extention = ".jpg";
            //string path = Path.Combine(wwwRootPath + "/Image/", fileName + extention);
            //byte[] data = System.IO.File.ReadAllBytes(path);

            //foto.FotoModelID = 1;
            //foto.DataWykonania = DateTime.Now;
            //foto.FotoTytul = fileName;
            //foto.FotoRozszerzenie = extention;
            //foto.FotoData = data;
            //foto.Opis = "Logo WSSI";
            //foto.AutorModelID = 1;
            //manager.AddFoto(foto);

            ////ręczne usuwanie danych z modelu i z bazy
            //manager.RemoveFoto(2);

            ////ręczne update danych w modelu i w bazie
            //var foto = new FotoModel();
            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //string fileName = "wwsi_lock";
            //string extention = ".png";
            //string path = Path.Combine(wwwRootPath + "/Image/", fileName + extention);
            //byte[] data = System.IO.File.ReadAllBytes(path);

            //foto.FotoModelID = 5;
            //foto.DataWykonania = DateTime.Now;
            //foto.FotoTytul = fileName;
            //foto.FotoRozszerzenie = extention;
            //foto.FotoData = data;
            //foto.Opis = "NetSec WWSI";
            //foto.AutorModelID = 3;
            //manager.UpdateFoto(foto);

            ////ręczna zmiana danych w modelu i w bazie
            //manager.ChangeDataWykonania(6, DateTime.Now);
            //manager.ChangeFotoTytul(7, "wwsi_lock");

            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //string fileName = "wwsi_lock";
            //string extention = ".png";
            //string path = Path.Combine(wwwRootPath + "/Image/", fileName + extention);
            //byte[] data = System.IO.File.ReadAllBytes(path);
            //manager.ChangeFotoData(7, data);
            //manager.ChangeRozszerzenie(7, "png");
            //manager.ChangeOpis(7, "NetSec WWSI");
            //manager.ChangeAutor(7, 3);

            var fotos = manager.GetFotos();

            return View(fotos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FotoModel foto)
        {
            var manager = new FotoManager();
            manager.AddFoto(foto);
            return RedirectToAction("Index");
        }
    }
}
