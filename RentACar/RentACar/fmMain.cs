using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void btAdmin_Click(object sender, EventArgs e)
        {
            fmAdmin fmAdmin = new fmAdmin();
            fmAdmin.Owner = this;
            fmAdmin.ShowDialog();
            this.Close();
        }
    }
}
