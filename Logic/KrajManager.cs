using FotoDB.Contexts;
using FotoDB.ILogic;
using FotoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Logic
{
    public class KrajManager : IKrajManager
    {
        private readonly FotoDBContext _fotoDBContext;

        public KrajManager(FotoDBContext fotoDBContext)
        {
            _fotoDBContext = fotoDBContext;
        }
        public KrajManager AddKraj(KrajModel krajModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Add(krajModel);
            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch (Exception)
            //    {
            //        krajModel.KrajModelID = 0;
            //        context.Add(krajModel);
            //        context.SaveChanges();
            //    }
            //}

            _fotoDBContext.Add(krajModel);
            try
            {
                _fotoDBContext.SaveChanges();
            }
            catch (Exception)
            {
                krajModel.KrajModelID = 0;
                _fotoDBContext.Add(krajModel);
                _fotoDBContext.SaveChanges();
            }
            return this;
        }

        public KrajManager RemoveKraj(int id)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var kraj = context.Krajs.SingleOrDefault(k => k.KrajModelID == id);
            //    context.Remove(kraj);
            //    context.SaveChanges();
            //}
            var kraj = _fotoDBContext.Krajs.SingleOrDefault(k => k.KrajModelID == id);
            _fotoDBContext.Remove(kraj);
            _fotoDBContext.SaveChanges();
            return this;
        }

        public KrajManager UpdateKraj(KrajModel krajModel)
        {
            //using (var context = new FotoDBContext())
            //{
            //    context.Update(krajModel);
            //    context.SaveChanges();
            //}
            _fotoDBContext.Update(krajModel);
            _fotoDBContext.SaveChanges();
            return this;
        }

        public KrajManager ChangeNazwa(int id, string newNazwa)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var kraj = context.Krajs.SingleOrDefault(k => k.KrajModelID == id);
            //    if (newNazwa == null)
            //    {
            //        kraj.Nazwa = "Brak Nazwy";
            //    }
            //    else
            //    {
            //        kraj.Nazwa = newNazwa;
            //    }
            //    this.UpdateKraj(kraj);
            //    //lub
            //    //context.Update(kraj);
            //    //context.SaveChanges();
            //}
            var kraj = _fotoDBContext.Krajs.SingleOrDefault(k => k.KrajModelID == id);
            if (newNazwa == null)
            {
                kraj.Nazwa = "Brak Nazwy";
            }
            else
            {
                kraj.Nazwa = newNazwa;
            }
            this.UpdateKraj(kraj);
            return this;
        }

        public KrajModel GetKraj(int id)
        {
            //using (var context = new FotoDBContext())
            //{
            //    var kraj = context.Krajs.SingleOrDefault(k => k.KrajModelID == id);
            //    return kraj;
            //}
            var kraj = _fotoDBContext.Krajs.SingleOrDefault(k => k.KrajModelID == id);
            return kraj;
        }

        public List<KrajModel> GetKrajs()
        {
            //using (var context = new FotoDBContext())
            //{
            //    List<KrajModel> krajs = context.Krajs.ToList<KrajModel>();
            //    return krajs;
            //}
            List<KrajModel> krajs = _fotoDBContext.Krajs.ToList<KrajModel>();
            return krajs;
        }
    }
}
