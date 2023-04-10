using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace appDate
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void diatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        string[] meses = new string[12] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
        bool bisiesto = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (mestxt.Text == "" || diatxt.Text == "" || añotxt.Text == "") { MessageBox.Show("llene TODOS los campos"); }
            else
            {

                if (Convert.ToInt32(diatxt.Text) > 31) { MessageBox.Show("ningun mes tiene mas de 31 dias"); }
                else
                {
                    int año = Convert.ToInt32(añotxt.Text);
                    int messel = Convert.ToInt32(mestxt.Text) - 1;
                    int dia = Convert.ToInt32(diatxt.Text);
                    bool corto = false;
                    bool cambioMes = false;
                    if (messel + 1 == 4 || messel + 1 == 6 || messel == 9 || messel + 1 == 11) { corto = true; }

                    if (messel + 1 <= 0 || messel + 1 >= 13) { MessageBox.Show("los meses del año deben insertarse con un numero del 1 al 12"); }
                    else
                    {
                        if (año % 400 == 0 || (año % 4 == 0 && año % 100 != 0)) { bisiesto = true; }
                        else { bisiesto = false; }
                        if (corto && messel != 1 && dia == 30) { messel += 1; dia = 1; cambioMes = true; }
                        else
                        {
                            if (dia == 31 && messel != 1)
                            {
                                if (messel == 11) { año += 1; messel = 0; dia = 1; cambioMes = true; }
                                else { messel += 1; dia = 1; cambioMes = true; }
                            }
                            if (dia == 29 && messel == 1 && bisiesto) { messel += 1; dia = 1; cambioMes = true; }
                            else { if (dia == 28 && messel == 1 && !bisiesto) { messel += 1; dia = 1; cambioMes = true; } }
                            if (!cambioMes) { dia += 1; }

                            MessageBox.Show("mañana sera: " + dia + " del mes: " + meses[messel] + " del año: " + año);

                        }
                    }
                }
            }
        }
    }
}