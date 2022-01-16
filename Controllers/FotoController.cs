using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<IActionResult> CreateAsync(FotoModel foto)
        {
            //string fileName = "wwsi_lock";
            //string extention = ".png";
            //var path = foto.ImageFile.FileName;
            //foto.FotoData = System.IO.File.ReadAllBytes(foto.ImageFile.FileName);

            //foto.FotoData = System.IO.File.ReadAllBytes(foto.ImageFile.FileName);

            using (var memoryStream = new MemoryStream())
            {
                var manager = new FotoManager();
                if (foto.ImageFile != null)
                    await foto.ImageFile.CopyToAsync(memoryStream);
                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    foto.FotoData = memoryStream.ToArray();
                    await manager.AddFotoAsync(foto);
                }
                else
                {

                    ViewBag.ErrorTitle = "File";
                    ViewBag.ErrorMessage = "The file is too large. We can accept an image up to 2MB.";
                    return View("Error");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var manager = new FotoManager();
            var foto = manager.GetFoto(id);
            return View(foto);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var manager = new FotoManager();
            try
            {
                manager.RemoveFoto(id);
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
            var manager = new FotoManager();
            var foto = manager.GetFoto(id);
            //try
            //{
            //    using (MemoryStream stream = new MemoryStream(foto.FotoData))
            //    {
            //        foto.ImageFile = new FormFile(stream, 0, stream.Length, foto.FotoTytul, foto.FotoTytul + foto.FotoRozszerzenie);
            //        return View(foto);
            //    }
            //    //using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            //    //{
            //    //    fs.Write(byteArray, 0, byteArray.Length);
            //    //    return View(foto);
            //    //}

            //}
            //catch (Exception)
            //{

            //    ViewBag.ErrorTitle = "File";
            //    ViewBag.ErrorMessage = "There is now file in database";
            //    return View("Error");
            //}
            return View(foto);
        }

        //[HttpPost]
        //public IActionResult Edit(FotoModel foto)
        //{
        //    var manager = new FotoManager();
        //    manager.UpdateFoto(foto);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public async Task<IActionResult> EditAsync(FotoModel foto)
        {
            //string fileName = "wwsi_lock";
            //string extention = ".png";
            //var path = foto.ImageFile.FileName;
            //foto.FotoData = System.IO.File.ReadAllBytes(foto.ImageFile.FileName);

            //foto.FotoData = System.IO.File.ReadAllBytes(foto.ImageFile.FileName);
            
            using (var memoryStream = new MemoryStream())
            {
                var manager = new FotoManager();
                if (foto.ImageFile != null)
                {
                    await foto.ImageFile.CopyToAsync(memoryStream);
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        foto.FotoData = memoryStream.ToArray();
                        await manager.UpdateFotoAsync(foto);
                    }
                    else
                    {

                        ViewBag.ErrorTitle = "File";
                        ViewBag.ErrorMessage = "The file is too large. We can accept an image up to 2MB.";
                        return View("Error");
                    }
                }
                else
                {
                   // await manager.UpdateFotoAsync(foto);
                }
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var manager = new FotoManager();
            var foto = manager.GetFoto(id);
            return View(foto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
