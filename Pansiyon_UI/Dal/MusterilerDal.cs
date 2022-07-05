using Pansiyon_UI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_UI.Dal
{
    public class MusterilerDal
    {
       public void Ekle(Musteriler musteri)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(musteri);
                result.State = EntityState.Added;
                context.SaveChanges();
            }

        }


        public void Guncelle(Musteriler musteri)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(musteri);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }

        }


        public void Sil(Musteriler musteri)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(musteri);
                result.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


        public List<Musteriler> Listele()
        {
            using (MyContext context = new MyContext())
            {
                return context.Musteriler.ToList();
            }
        }
    }
}
