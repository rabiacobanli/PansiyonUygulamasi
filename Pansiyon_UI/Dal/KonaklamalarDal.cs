using Pansiyon_UI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_UI.Dal
{
    public class KonaklamalarDal
    {
        public void Ekle(Konaklamalar konaklama)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(konaklama);
                result.State = EntityState.Added;
                context.SaveChanges();
            }

        }


        public void Guncelle(Konaklamalar konaklama)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(konaklama);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }

        }


        public void Sil(Konaklamalar konaklama)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(konaklama);
                result.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


        public List<Konaklamalar> Listele()
        {
            using (MyContext context = new MyContext())
            {
                return context.Konaklamalar.ToList();
            }
        }


    }
}
