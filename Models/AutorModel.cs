using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Models
{
    public class AutorModel
    {
        public int AutorModelID { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string Imie { get; set; }


        public int KrajModelID { get; set; }
        public KrajModel KrajModel { get; set; }
        public ICollection<FotoModel> Fotos { get; set; }
    }
}
