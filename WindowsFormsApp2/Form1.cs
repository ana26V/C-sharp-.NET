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


        private void button1_Click(object sender, EventArgs e)
        {
           
            double sbrut = double.Parse(textBox1.Text);
            double CFS_angajat = (sbrut / 1000) * 5;
            label1.Text= CFS_angajat.ToString();
            string aux = textBox1.Text;
            MessageBox.Show("Ati introdus" + aux);
        }
    }
}
