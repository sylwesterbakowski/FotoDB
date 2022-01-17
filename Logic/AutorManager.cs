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
    public class AutorManager : IAutorManager
    {
        private readonly FotoDBContext _fotoDBContext;

        public AutorManager(FotoDBContext fotoDBContext)
        {
            _fotoDBContext = fotoDBContext;
        }
        public AutorManager AddAutor(AutorModel autorModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Add(autorModel);
            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch (Exception)
            //    {

            //        autorModel.AutorModelID = 0;
            //        context.Add(autorModel);
            //        context.SaveChanges();
            //    }
            //}
            _fotoDBContext.Add(autorModel);
            try
            {
                _fotoDBContext.SaveChanges();
            }
            catch (Exception)
            {

                autorModel.AutorModelID = 0;
                _fotoDBContext.Add(autorModel);
                _fotoDBContext.SaveChanges();
            }
            return this;
        }

        public AutorManager RemoveAutor(int id)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var autor = context.Autors.SingleOrDefault(a => a.AutorModelID == id);
            //    context.Remove(autor);
            //    context.SaveChanges();
            //}
            var autor = _fotoDBContext.Autors.SingleOrDefault(a => a.AutorModelID == id);
            _fotoDBContext.Remove(autor);
            _fotoDBContext.SaveChanges();
            return this;
        }

        public AutorManager UpdateAutor(AutorModel autorModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Update(autorModel);
            //    context.SaveChanges();

            //}
            _fotoDBContext.Update(autorModel);
            _fotoDBContext.SaveChanges();
            return this;
        }

        public AutorManager ChangeNazwisko(int id, string newNazwisko)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var autor = context.Autors.SingleOrDefault(a => a.AutorModelID == id);
            //    if (newNazwisko == null)
            //    {
            //        autor.Nazwisko = "Brak Nazwiska";
            //    }
            //    else
            //    {
            //        autor.Nazwisko = newNazwisko;
            //    }
            //    this.UpdateAutor(autor);
            //    //lub
            //    //context.Update(autor);
            //    //context.SaveChanges();
            //}
            var autor = _fotoDBContext.Autors.SingleOrDefault(a => a.AutorModelID == id);
            if (newNazwisko == null)
            {
                autor.Nazwisko = "Brak Nazwiska";
            }
            else
            {
                autor.Nazwisko = newNazwisko;
            }
            this.UpdateAutor(autor);
            return this;
        }

        public AutorManager ChangeImie(int id, string newImie)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var autor = context.Autors.SingleOrDefault(a => a.AutorModelID == id);
            //    if (newImie == null)
            //    {
            //        autor.Imie = "Brak Imienia";
            //    }
            //    else
            //    {
            //        autor.Imie = newImie;
            //    }
            //    this.UpdateAutor(autor);
            //    //lub
            //    //context.Update(autor);
            //    //context.SaveChanges();
            //}
            var autor = _fotoDBContext.Autors.SingleOrDefault(a => a.AutorModelID == id);
            if (newImie == null)
            {
                autor.Imie = "Brak Imienia";
            }
            else
            {
                autor.Imie = newImie;
            }
            this.UpdateAutor(autor);
            return this;
        }

        public AutorManager ChangeKraj(int id, int id_kraj)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var autor = context.Autors.SingleOrDefault(a => a.AutorModelID == id);
            //    if (id_kraj <= 0)
            //    {
            //        autor.KrajModelID = 0;
            //    }
            //    else
            //    {
            //        autor.KrajModelID = id_kraj;
            //    }
            //    this.UpdateAutor(autor);
            //    //lub
            //    //context.Update(autor);
            //    //context.SaveChanges();
            //}
            var autor = _fotoDBContext.Autors.SingleOrDefault(a => a.AutorModelID == id);
            if (id_kraj <= 0)
            {
                autor.KrajModelID = 0;
            }
            else
            {
                autor.KrajModelID = id_kraj;
            }
            this.UpdateAutor(autor);
            return this;
        }

        public IEnumerable<SelectListItem> GetListKrajs()
        {
            IEnumerable<SelectListItem> listKrajs = from kraj in _fotoDBContext.Krajs
                                                    select new SelectListItem
                                                    {
                                                        Text = kraj.Nazwa,
                                                        Value = kraj.KrajModelID.ToString()
                                                    };
            return listKrajs;
        }

        public AutorModel GetAutor(int id)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var autor = context.Autors.SingleOrDefault(a => a.AutorModelID == id);
            //    return autor;
            //}
            var autor = _fotoDBContext.Autors.SingleOrDefault(a => a.AutorModelID == id);
            return autor;
        }

        public List<AutorModel> GetAutors()
        {
            //using (var context = new FotoDBContext())
            //{
            //    List<AutorModel> autors = context.Autors.ToList<AutorModel>();
            //    return autors;
            //}
            List<AutorModel> autors = _fotoDBContext.Autors.ToList<AutorModel>();
            return autors;
        }
    }
}
