using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Models
{
    public class KrajModel
    {
        public int KrajModelID { get; set; }

        [Required]
        public string Nazwa { get; set; }
        
        public ICollection<AutorModel> Autors { get; set; }

       // public List<AutorModel> ListaAutorow { get; set; }
    }
}
