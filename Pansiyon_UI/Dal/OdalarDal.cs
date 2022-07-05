using Pansiyon_UI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_UI.Dal
{
    public class OdalarDal
    {

        public void Ekle(Odalar oda)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(oda);
                result.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public Odalar OdaGetir(int id)
        {
           using (MyContext context = new MyContext())
            {
                return context.Odalar.Find(id);
            }
        }
           

        public void Guncelle(Odalar oda)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(oda);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }

        }


        public void Sil(Odalar oda)
        {
            using (MyContext context = new MyContext())
            {
                var result = context.Entry(oda);
                result.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


        public List<Odalar> Listele()
        {
            MyContext context = new MyContext();
            return context.Odalar.ToList();
            
        }



    }
}
