using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Models
{
    public class FotoModel
    {
        public int FotoModelID { get; set; }

        public DateTime DataWykonania { get; set; }

        public string FotoTytul { get; set; }

        public byte[] FotoData { get; set; }

        [Required]
        public string FotoRozszerzenie { get; set; }

        public string Opis { get; set; }

        public int AutorModelID { get; set; }
        public AutorModel AutorModel { get; set; }

    }
}
