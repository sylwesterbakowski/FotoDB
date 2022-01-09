using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Controllers
{
    public class FotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
