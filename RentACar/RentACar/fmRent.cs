using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using SqlLibrary;
using System.Drawing.Printing;
using System.Data.SqlTypes;
using System.Globalization;

namespace RentACar
{
    public partial class fmRent : Form
    {
        private Rent rent;
        private string textForPrint = "";
        private bool rentFinded = false;
        public fmRent()
        {
            InitializeComponent();
        }

        private void tbNumber_Validating(object sender, CancelEventArgs e)
        {
            if(tbNumber.Text==String.Empty || !int.TryParse(tbNumber.Text, out int result))
            {
                errorProvider.SetError(tbNumber, "Неверное значение поля");
                e.Cancel = true;
            }
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            if (RentSql.FindRent(int.Parse(tbNumber.Text)).Count>0)
            {
                rent = RentSql.FindRent(int.Parse(tbNumber.Text))[0];
                lbNumber.Text = "Аренда №: " + rent.N.ToString();
                lbClient.Text = "Права клиента: " + rent.Client.ToString();
                lbCar.Text = "Машина: " + rent.Car;
                lbPrice.Text = "Стоимость за 1 час: " + rent.Price.ToString() + " руб.";
                lbDate1.Text = "Начало аренды: " + rent.StartDate.ToShortDateString();
                lbDate2.Text = "Конец аренды: " + rent.EndDate.ToShortDateString();
                TimeSpan interval = rent.EndDate - rent.StartDate;
                int allprice = rent.Price * interval.Days * 24;
                lbResult.Text = $"Итого: {allprice.ToString("N", CultureInfo.CurrentCulture)} руб.";
                rentFinded = true;
            }
            else
            {
                lbNumber.Text = "Аренда №:-";
                lbClient.Text = "Права клиента:-";
                lbCar.Text = "Машина:-";
                lbPrice.Text = "Стоимость за 1 час:-";
                lbDate1.Text = "Начало аренды:-";
                lbDate2.Text = "Конец аренды:-";
                lbResult.Text = "Итого:-";
                rentFinded = false;
            }
            btPrint.Enabled = rentFinded;
        }

        private void fmRent_Load(object sender, EventArgs e)
        {
            btPrint.Enabled = false;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            List<string> alltext = GetTextForPrint();
            textForPrint = "";
            foreach(var i in alltext)
            {
                textForPrint += $"{i}\n";
            }
            PrintDocument document = new PrintDocument();
            document.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = document;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }

        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textForPrint, new Font("Calibri", 14), Brushes.Black, 0, 0);
        }
        private List<string> GetTextForPrint()
        {
            List<string> text = new List<string>();
            text.Add("Информация об аренде");
            text.Add(lbNumber.Text);
            text.Add(lbCar.Text);
            text.Add(lbClient.Text);
            text.Add(lbPrice.Text);
            text.Add(lbDate1.Text);
            text.Add(lbDate2.Text);
            text.Add(lbResult.Text);
            return text;
        }
    }
}
