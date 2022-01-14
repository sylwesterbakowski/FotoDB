﻿using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}
