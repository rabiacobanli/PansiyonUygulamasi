using Pansiyon_UI.BusinessLayer;
using Pansiyon_UI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_UI.UI_Formlar
{
    public partial class FormKonaklamalar : Form
    {
        public int MusteriId { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        public decimal OdaFiyat { get; set; }


        public FormKonaklamalar()
        {
            InitializeComponent();
        }

        KonaklamaManager _konaklama = new KonaklamaManager();

        private void FormKonaklamalar_Load(object sender, EventArgs e)
        {
            tbxMusteriAdiSoyadi.Text = MusteriAdiSoyadi;
            GunSayisiHesapla();
            OdaSec();
            KonaklamaListele();

        }


        private void GunSayisiHesapla()
        {
            TimeSpan gunSayisi;
            gunSayisi = DateTime.Parse(dtpCikis.Text) - DateTime.Parse(dtpGiris.Text);
            tbxGünSayisi.Text = gunSayisi.TotalDays.ToString();
        }


        private void KonaklamaListele()
        {
            dgwKonaklamalar.DataSource = _konaklama.Listele().Where(k => k.AktifMi = true&& k.MusteriId==MusteriId).ToList();
        }



        private void dtpGiris_ValueChanged(object sender, EventArgs e)
        {
            GunSayisiHesapla();
            ToplamFiyatHesapla();
        }



        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            GunSayisiHesapla();
            ToplamFiyatHesapla();
        }

        private void OdaSec()
        {
            OdalarManager odalarManager = new OdalarManager();
            int pozisyonX = 50;
            int pozisyonY = 50;
            int sutun = 1;

            for (int i = 0; i < odalarManager.Listele().Count; i++)
            {
                Button button = new Button();
                button.Location = new Point(pozisyonX , pozisyonY);
                button.Height = 50;
                button.Width = 60;
                button.Text = odalarManager.Listele()[i].OdaNo.ToString();
                button.Name = odalarManager.Listele()[i].Id.ToString();
                button.Click += new EventHandler(SeciliButon);
                grpbOdalar.Controls.Add(button);


                if (!odalarManager.Listele()[i].MüsaitMi)
                {
                    button.BackColor = Color.Red;
                    button.Enabled = false;
                }
                else
                {
                    button.BackColor = Color.Green;
                }



                if (sutun<5)
                {
                    pozisyonX += 80;
                    sutun++;
                }
                else
                {
                    sutun = 1;
                    pozisyonX = 50;
                    pozisyonY += 80;

                }
            }                             
         
        }

        private void SeciliButon(object sender , EventArgs eventArgs)
        {
            Button dinamikButon = (sender as Button);
            tbxOdaNo.Text = dinamikButon.Text;
            tbxOdaId.Text = dinamikButon.Name;
            OdalarManager odalarManager = new OdalarManager();
            int id = Convert.ToInt32(tbxOdaId.Text);
            Odalar oda = odalarManager.OdaGetir(id);
            tbxOdaFiyat.Text = oda.Fiyat.ToString();
            ToplamFiyatHesapla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxOdaId.Text !="" &&tbxFiyat.Text !="" && cbxAktifMi.Checked)
            {
                Konaklamalar konaklama = new Konaklamalar()
                {
                    MusteriId = MusteriId,
                    OdaId = Convert.ToInt32(tbxOdaId.Text),
                    GirisTarihi= dtpGiris.Value,
                    CikisTarihi=dtpCikis.Value,
                    AktifMi=cbxAktifMi.Checked,
                    ToplamFiyat=Convert.ToDecimal(tbxFiyat.Text)

                };

                _konaklama.Ekle(konaklama);
                OdalarManager odalarManager = new OdalarManager();
                Odalar oda = new Odalar();
                oda = odalarManager.Listele().Where(o => o.OdaNo == tbxOdaNo.Text).FirstOrDefault();
                odalarManager.OdaGuncelleKonaklamaGiris(oda);               
                KonaklamaListele();
                grpbOdalar.Controls.Clear();
                OdaSec();
            }

            else
            {
                MessageBox.Show("Lütfen önce bir oda seçin ve boş alanları doldurun(Tarih , Fiyat ve Konaklama Durumu)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbxOdaId.Text != "" && tbxFiyat.Text != "" && tbxKonaklamaId.Text !="")
            {
                Konaklamalar konaklama = new Konaklamalar()
                {
                    Id = Convert.ToInt32(tbxKonaklamaId.Text),
                    MusteriId = MusteriId,
                    OdaId = Convert.ToInt32(tbxOdaId.Text),
                    GirisTarihi = dtpGiris.Value,
                    CikisTarihi = dtpCikis.Value,
                    AktifMi = cbxAktifMi.Checked,
                    ToplamFiyat = Convert.ToDecimal(tbxFiyat.Text)

                };
                _konaklama.Guncelle(konaklama);

                if (!konaklama.AktifMi)
                {
                    OdalarManager odalarManager = new OdalarManager();
                    Odalar oda = new Odalar();
                    oda = odalarManager.Listele().Where(o => o.Id == Convert.ToInt32(tbxOdaId.Text)).FirstOrDefault();
                    odalarManager.OdaGuncelleKonaklamaCikis(oda);

                }
                KonaklamaListele();
                grpbOdalar.Controls.Clear();
                OdaSec();
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçin");
            }
        }


        private void dgwKonaklamalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxKonaklamaId.Text = dgwKonaklamalar.CurrentRow.Cells[0].Value.ToString();
            tbxOdaId.Text = dgwKonaklamalar.CurrentRow.Cells[2].Value.ToString();
            dtpGiris.Value = Convert.ToDateTime(dgwKonaklamalar.CurrentRow.Cells[3].Value.ToString());
            dtpCikis.Value = Convert.ToDateTime(dgwKonaklamalar.CurrentRow.Cells[4].Value.ToString());
            tbxFiyat.Text = dgwKonaklamalar.CurrentRow.Cells[5].Value.ToString();
            cbxAktifMi.Checked = Convert.ToBoolean(dgwKonaklamalar.CurrentRow.Cells[6].Value);
        }

        private void ToplamFiyatHesapla()
        {
            tbxFiyat.Text = (Convert.ToDecimal(tbxOdaFiyat.Text) * Convert.ToInt32(tbxGünSayisi.Text)).ToString();
        }
    }
}
