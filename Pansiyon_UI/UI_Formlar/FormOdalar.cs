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
    public partial class FormOdalar : Form
    {
        public FormOdalar()
        {
            InitializeComponent();
        }

        OdalarManager _odalarManager = new OdalarManager();

        private void FormOdalar_Load(object sender, EventArgs e)
        {
            OdalarListele();
        }

        public void OdalarListele()
        {
            dataGridView1.DataSource = _odalarManager.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Odalar oda = new Odalar()
            {
                OdaNo = tbxOdaNo.Text,
                Fiyat = Convert.ToDecimal(tbxFiyat.Text),
                MüsaitMi = Convert.ToBoolean(cbxMusaitMi.Text)
               
            };
            _odalarManager.Ekle(oda);
            OdalarListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Odalar oda = new Odalar()
            {
                Id= int.Parse(tbxOdaId.Text),
                OdaNo = tbxOdaNo.Text,
                Fiyat = Convert.ToDecimal(tbxFiyat.Text),
                MüsaitMi = Convert.ToBoolean(cbxMusaitMi.Text)

            };
            _odalarManager.Guncelle(oda);
            OdalarListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Odalar oda = new Odalar()
            {
                Id = int.Parse(tbxOdaId.Text),
                OdaNo = tbxOdaNo.Text,
                Fiyat = Convert.ToDecimal(tbxFiyat.Text),
                MüsaitMi = Convert.ToBoolean(cbxMusaitMi.Text)

            };
            _odalarManager.Sil(oda);
            OdalarListele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbxOdaId.Clear();
            tbxOdaNo.Clear();
            cbxMusaitMi.SelectedItem = null;
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxOdaId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxOdaNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxFiyat.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbxMusaitMi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

    }
}
