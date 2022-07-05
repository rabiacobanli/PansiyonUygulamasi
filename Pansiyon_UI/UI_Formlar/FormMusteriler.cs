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
    public partial class FormMusteriler : Form
    {
        public FormMusteriler()
        {
            InitializeComponent();
        }

        MusteriManager _musteriManager = new MusteriManager();

        private void Musteriler_Load(object sender, EventArgs e)
        {
            MusteriListele();

        }

        public void MusteriListele()
        {
            dataGridView1.DataSource = _musteriManager.Listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxTC .Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxIsim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxSoyisim.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            mtbxTelefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxEmail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbxCinsiyet.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteriler musteri = new Musteriler()
            {
                Ad = tbxIsim.Text,
                Soyad = tbxSoyisim.Text,
                TcNo = tbxTC.Text,
                Telefon = mtbxTelefon.Text,
                Cinsiyet = cbxCinsiyet.Text,
                Email = tbxEmail.Text
            };
            _musteriManager.Ekle(musteri);
            MusteriListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            Musteriler musteri = new Musteriler()
            {
                Id = int.Parse(tbxId.Text),
                Ad = tbxIsim.Text,
                Soyad = tbxSoyisim.Text,
                TcNo = tbxTC.Text,
                Telefon = mtbxTelefon.Text,
                Cinsiyet = cbxCinsiyet.Text,
                Email = tbxEmail.Text
            };
            _musteriManager.Guncelle(musteri);
            MusteriListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Musteriler musteri = new Musteriler()
            {
                Id = int.Parse(tbxId.Text),
                Ad = tbxIsim.Text,
                Soyad = tbxSoyisim.Text,
                TcNo = tbxTC.Text,
                Telefon = mtbxTelefon.Text,
                Cinsiyet = cbxCinsiyet.Text,
                Email = tbxEmail.Text
            };
            _musteriManager.Sil(musteri);
            MusteriListele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            tbxId.Clear();
            tbxTC.Clear();
            tbxIsim.Clear();
            tbxSoyisim.Clear();
            mtbxTelefon.Clear();
            tbxEmail.Clear(); 
            cbxCinsiyet.SelectedItem=null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxId.Text !="" && tbxIsim.Text  !="" && tbxSoyisim.Text !="")
            {       
            FormKonaklamalar formKonaklamalar = new FormKonaklamalar();
            formKonaklamalar.MusteriId = Convert.ToInt32(tbxId.Text);
            formKonaklamalar.MusteriAdiSoyadi = tbxIsim.Text + " " + tbxSoyisim.Text;
            formKonaklamalar.ShowDialog(); // ShowDialog: Açık olan ekranı kapatmadan diğer form ekranına geçemez
            }
        }
    }
}
