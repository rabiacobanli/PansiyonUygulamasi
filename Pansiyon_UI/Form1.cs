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
using Pansiyon_UI.UI_Formlar;
using FormMusteriler = Pansiyon_UI.UI_Formlar.FormMusteriler;

namespace Pansiyon_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMusteriler musterilerForm = new FormMusteriler();
            musterilerForm.Show();
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            FormOdalar odalarForm = new FormOdalar();
            odalarForm.Show();
        }
    }
}
