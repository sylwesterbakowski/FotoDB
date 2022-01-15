using FotoDB.Contexts;
using FotoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB.Logic
{
    public class FotoManager
    {
        public FotoManager AddFoto(FotoModel fotoModel)
        {
            using (var context = new FotoDBContext())
            {
                context.Add(fotoModel);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    fotoModel.FotoModelID = 0;
                    context.Add(fotoModel);
                    context.SaveChanges();
                }
            }
            return this;
        }
        public async Task<FotoManager> AddFotoAsync(FotoModel fotoModel)
        {
            using (var context = new FotoDBContext())
            {
                context.Add(fotoModel);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    fotoModel.FotoModelID = 0;
                    context.Add(fotoModel);
                    await context.SaveChangesAsync();
                }
            }
            return this;
        }

        public FotoManager RemoveFoto(int id)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                context.Remove(foto);
                context.SaveChanges();
            }
            return this;
        }

        public FotoManager UpdateFoto(FotoModel fotoModel)
        {
            using (var context = new FotoDBContext())
            {
                context.Update(fotoModel);
                context.SaveChanges();

            }
            return this;
        }

        public FotoManager ChangeOpis(int id, string newOpis)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                if (newOpis == null)
                {
                    foto.Opis = "";
                }
                else
                {
                    foto.Opis = newOpis;
                }
                this.UpdateFoto(foto);
                //lub
                //context.Update(foto);
                //context.SaveChanges();
            }
            return this;
        }

        public FotoManager ChangeDataWykonania(int id, DateTime newData)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                if (newData == null)
                {
                    foto.DataWykonania = DateTime.Now;
                }
                else
                {
                    foto.DataWykonania = newData;
                }
                this.UpdateFoto(foto);
                //lub
                //context.Update(foto);
                //context.SaveChanges();
            }
            return this;
        }

        public FotoManager ChangeFotoTytul(int id, string newFotoTytul)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                if (newFotoTytul == null)
                {
                    foto.FotoTytul = "";
                }
                else
                {
                    foto.FotoTytul = newFotoTytul;
                }
                this.UpdateFoto(foto);
                //lub
                //context.Update(foto);
                //context.SaveChanges();
            }
            return this;
        }

        public FotoManager ChangeFotoData(int id, byte[] newFotoData)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                if (newFotoData == null)
                {
                    foto.FotoData = null;
                }
                else
                {
                    foto.FotoData = newFotoData;
                }
                this.UpdateFoto(foto);
                //lub
                //context.Update(foto);
                //context.SaveChanges();
            }
            return this;
        }

        public FotoManager ChangeRozszerzenie(int id, string newRozszerzenie)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                if (newRozszerzenie == null)
                {
                    foto.FotoRozszerzenie = "";
                }
                else
                {
                    foto.FotoRozszerzenie = newRozszerzenie;
                }
                this.UpdateFoto(foto);
                //lub
                //context.Update(foto);
                //context.SaveChanges();
            }
            return this;
        }

        public FotoManager ChangeAutor(int id, int id_autor)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                if (id_autor <= 0)
                {
                    foto.AutorModelID = 0;
                }
                else
                {
                    foto.AutorModelID = id_autor;
                }
                this.UpdateFoto(foto);
                //lub
                //context.Update(foto);
                //context.SaveChanges();
            }
            return this;
        }

        public FotoModel GetFoto(int id)
        {
            using (var context = new FotoDBContext())
            {
                var foto = context.Fotos.SingleOrDefault(f => f.FotoModelID == id);
                return foto;
            }
        }

        public List<FotoModel> GetFotos()
        {
            using (var context = new FotoDBContext())
            {
                List<FotoModel> fotos = context.Fotos.ToList<FotoModel>();
                return fotos;
            }
        }
    }
}
