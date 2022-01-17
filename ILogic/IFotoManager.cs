using FotoDB.Logic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FotoDB.ILogic
{
    public interface IFotoManager
    {
        FotoManager AddFoto(FotoModel fotoModel);
        Task<FotoManager> AddFotoAsync(FotoModel fotoModel);
        FotoManager ChangeAutor(int id, int id_autor);
        FotoManager ChangeDataWykonania(int id, DateTime newData);
        FotoManager ChangeFotoData(int id, byte[] newFotoData);
        FotoManager ChangeFotoTytul(int id, string newFotoTytul);
        FotoManager ChangeOpis(int id, string newOpis);
        FotoManager ChangeRozszerzenie(int id, string newRozszerzenie);
        IEnumerable<SelectListItem> GetListAutors();
        FotoModel GetFoto(int id);
        List<FotoModel> GetFotos();
        FotoManager RemoveFoto(int id);
        FotoManager UpdateFoto(FotoModel fotoModel);
        Task<FotoManager> UpdateFotoAsync(FotoModel fotoModel);
    }
}