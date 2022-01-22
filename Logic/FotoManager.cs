using FotoDB.Contexts;
using FotoDB.ILogic;
using FotoDB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Logic
{
    public class FotoManager : IFotoManager
    {
        private readonly FotoDBContext _fotoDBContext;

        public FotoManager(FotoDBContext fotoDBContext)
        {
            _fotoDBContext = fotoDBContext;
        }
        public FotoManager AddFoto(FotoModel fotoModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Add(fotoModel);
            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch (Exception)
            //    {

            //        fotoModel.FotoModelID = 0;
            //        context.Add(fotoModel);
            //        context.SaveChanges();
            //    }
            //}
            _fotoDBContext.Add(fotoModel);
            try
            {
                _fotoDBContext.SaveChanges();
            }
            catch (Exception)
            {

                fotoModel.FotoModelID = 0;
                _fotoDBContext.Add(fotoModel);
                _fotoDBContext.SaveChanges();
            }
            return this;
        }
        public async Task<FotoManager> AddFotoAsync(FotoModel fotoModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Add(fotoModel);
            //    try
            //    {
            //        await context.SaveChangesAsync();
            //    }
            //    catch (Exception)
            //    {

            //        fotoModel.FotoModelID = 0;
            //        context.Add(fotoModel);
            //        await context.SaveChangesAsync();
            //    }
            //}
            _fotoDBContext.Add(fotoModel);
            try
            {
                await _fotoDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                fotoModel.FotoModelID = 0;
                _fotoDBContext.Add(fotoModel);
                await _fotoDBContext.SaveChangesAsync();
            }
            return this;
        }

        public FotoManager RemoveFoto(int id)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    context.Remove(foto);
            //    context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            _fotoDBContext.Remove(foto);
            _fotoDBContext.SaveChanges();
            return this;
        }

        public FotoManager UpdateFoto(FotoModel fotoModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Update(fotoModel);
            //    context.SaveChanges();
            //}
            _fotoDBContext.Update(fotoModel);
            _fotoDBContext.SaveChanges();
            return this;
        }

        public async Task<FotoManager> UpdateFotoAsync(FotoModel fotoModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Update(fotoModel);
            //    try
            //    {
            //        await context.SaveChangesAsync();
            //    }
            //    catch (Exception)
            //    {

            //        fotoModel.FotoModelID = 0;
            //        context.Update(fotoModel);
            //        await context.SaveChangesAsync();
            //    }
            //}
            _fotoDBContext.Update(fotoModel);
            try
            {
                await _fotoDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                fotoModel.FotoModelID = 0;
                _fotoDBContext.Update(fotoModel);
                await _fotoDBContext.SaveChangesAsync();
            }
            return this;
        }

        public FotoManager ChangeOpis(int id, string newOpis)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    if (newOpis == null)
            //    {
            //        foto.Opis = "";
            //    }
            //    else
            //    {
            //        foto.Opis = newOpis;
            //    }
            //    this.UpdateFoto(foto);
            //    //lub
            //    //context.Update(foto);
            //    //context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            if (newOpis == null)
            {
                foto.Opis = "";
            }
            else
            {
                foto.Opis = newOpis;
            }
            this.UpdateFoto(foto);
            return this;
        }

        public FotoManager ChangeDataWykonania(int id, DateTime newData)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    if (newData == null)
            //    {
            //        foto.DataWykonania = DateTime.Now;
            //    }
            //    else
            //    {
            //        foto.DataWykonania = newData;
            //    }
            //    this.UpdateFoto(foto);
            //    //lub
            //    //context.Update(foto);
            //    //context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            if (newData > DateTime.Now)
            {
                foto.DataWykonania = DateTime.Now;
            }
            else
            {
                foto.DataWykonania = newData;
            }
            this.UpdateFoto(foto);
            return this;
        }

        public FotoManager ChangeFotoTytul(int id, string newFotoTytul)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    if (newFotoTytul == null)
            //    {
            //        foto.FotoTytul = "";
            //    }
            //    else
            //    {
            //        foto.FotoTytul = newFotoTytul;
            //    }
            //    this.UpdateFoto(foto);
            //    //lub
            //    //context.Update(foto);
            //    //context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            if (newFotoTytul == null)
            {
                foto.FotoTytul = "";
            }
            else
            {
                foto.FotoTytul = newFotoTytul;
            }
            this.UpdateFoto(foto);
            return this;
        }

        public FotoManager ChangeFotoData(int id, byte[] newFotoData)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    if (newFotoData == null)
            //    {
            //        foto.FotoData = null;
            //    }
            //    else
            //    {
            //        foto.FotoData = newFotoData;
            //    }
            //    this.UpdateFoto(foto);
            //    //lub
            //    //context.Update(foto);
            //    //context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            if (newFotoData == null)
            {
                foto.FotoData = null;
            }
            else
            {
                foto.FotoData = newFotoData;
            }
            this.UpdateFoto(foto);
            return this;
        }

        public FotoManager ChangeRozszerzenie(int id, string newRozszerzenie)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    if (newRozszerzenie == null)
            //    {
            //        foto.FotoRozszerzenie = "";
            //    }
            //    else
            //    {
            //        foto.FotoRozszerzenie = newRozszerzenie;
            //    }
            //    this.UpdateFoto(foto);
            //    //lub
            //    //context.Update(foto);
            //    //context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            if (newRozszerzenie == null)
            {
                foto.FotoRozszerzenie = "";
            }
            else
            {
                foto.FotoRozszerzenie = newRozszerzenie;
            }
            this.UpdateFoto(foto);
            return this;
        }

        public FotoManager ChangeAutor(int id, int id_autor)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    if (id_autor <= 0)
            //    {
            //        foto.AutorModelID = 0;
            //    }
            //    else
            //    {
            //        foto.AutorModelID = id_autor;
            //    }
            //    this.UpdateFoto(foto);
            //    //lub
            //    //context.Update(foto);
            //    //context.SaveChanges();
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            if (id_autor <= 0)
            {
                foto.AutorModelID = 0;
            }
            else
            {
                foto.AutorModelID = id_autor;
            }
            this.UpdateFoto(foto);
            return this;
        }

        public FotoModel GetFoto(int id)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            //    return foto;
            //}
            var foto = _fotoDBContext.Fotos.SingleOrDefault(f => f.FotoModelID == id);
            return foto;
        }

        public List<FotoModel> GetFotos()
        {
            //using (var context = new FotoDBContext())
            //{
            //    List<FotoModel> fotos = context.Fotos.ToList<FotoModel>();
            //    return fotos;
            //}
            List<FotoModel> fotos = _fotoDBContext.Fotos.ToList<FotoModel>();
            return fotos;
        }
        

        public IEnumerable<SelectListItem> GetListAutors()
        {
            IEnumerable<SelectListItem> listAutors = from autor in _fotoDBContext.Autors
                                                    select new SelectListItem
                                                    {
                                                        Text = autor.Nazwisko + " " + autor.Imie,
                                                        Value = autor.AutorModelID.ToString()
                                                    };
            return listAutors;
        }

    }
}
