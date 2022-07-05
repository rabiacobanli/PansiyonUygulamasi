using Pansiyon_UI.Dal;
using Pansiyon_UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_UI.BusinessLayer
{
    public class MusteriManager
    {
        MusterilerDal _musterilerDal = new MusterilerDal();

        public void Ekle(Musteriler musteri)
        {
            _musterilerDal.Ekle(musteri);
        }

        public void Sil(Musteriler musteri)
        {
            _musterilerDal.Sil(musteri);
        }

        public void Guncelle(Musteriler musteri)
        {
            _musterilerDal.Guncelle(musteri);
        }

        public List<Musteriler> Listele()
        {
            return _musterilerDal.Listele();
        }
    }
}
