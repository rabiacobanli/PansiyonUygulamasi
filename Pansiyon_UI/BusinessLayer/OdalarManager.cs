using Pansiyon_UI.Dal;
using Pansiyon_UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_UI.BusinessLayer
{
    class OdalarManager
    {
        OdalarDal _odalarDal = new OdalarDal();

        public Odalar OdaGetir(int id)
        {
            return _odalarDal.OdaGetir(id);
        }

        public void OdaGuncelleKonaklamaGiris(Odalar oda)
        {
            oda.MüsaitMi = false;
            Guncelle(oda);
        }

        public void OdaGuncelleKonaklamaCikis(Odalar oda)
        {
            oda.MüsaitMi = true;
            Guncelle(oda);
        }

        public void Ekle(Odalar oda)
        {
            _odalarDal.Ekle(oda);
        }

        public void Sil(Odalar oda)
        {
            _odalarDal.Sil(oda);
        }

        public void Guncelle(Odalar oda)
        {
            _odalarDal.Guncelle(oda);
        }

        public List<Odalar> Listele()
        {
            return _odalarDal.Listele();
        }
    }
}
