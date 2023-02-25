using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            

            string words = "";

            string[] units = { "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua", "zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "saisprezece", "saptesprezece", "optsprezece", "nouasprezece" };
            string[] tens = { "douazeci", "treizeci", "patruzeci", "cincizeci", "saizeci", "saptezeci", "optzeci", "nouazeci" };

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " mii ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " sute ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "si ";

                if (number < 20)
                    words += units[number - 1];
                else
                {
                    words += tens[number / 10 - 2];
                    if ((number % 10) > 0)
                        words += "-" + units[number % 10 - 1];
                }
            }

            return words;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            double sbrut = double.Parse(textBox1.Text);
            double CFS_angajat = (sbrut / 1000) * 5;
            label1.Text= CFS_angajat.ToString();
           
           
            string words = NumberToWords((int)sbrut);
            string aux = textBox1.Text;
            MessageBox.Show("Ati introdus " + words);
           
        }
    }
}
