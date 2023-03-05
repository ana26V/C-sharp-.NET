using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_si_Zero_eu
{
    public partial class Form1 : Form
    {
        const int BSIZE = 3;
        const string Player1 = "X";
        const string Player2 = "O";

        string[,] tablaMatrice = new string[BSIZE, BSIZE];
        string currentPlayer = Player1;
        public Form1()
        {
            InitializeComponent();
            resetTabla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control cnt in tableLayoutPanel1.Controls)
            {
                Button btn = (Button)cnt;
                btn.Click += Btn_Click;
            }
            resetTabla();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            /*sender este de tipul object deoarece poate fi orice obiect care a
             * declanșat evenimentul (în cazul nostru, un buton). 
             * Însă, pentru a putea accesa proprietățile și metodele specifice 
             * unui buton, trebuie să facem cast la tipul Button.*/
            Button button = (Button)sender;
            int linie = tableLayoutPanel1.GetRow(button);
            int coloana = tableLayoutPanel1.GetColumn(button);

            if (tablaMatrice[linie, coloana] == null)//nu merge ==0 pt ca e de tip string
            {
                tablaMatrice[linie, coloana] = currentPlayer;
                button.Text = currentPlayer;
               
                if (isWinner(currentPlayer))
                {
                    MessageBox.Show("Winner: " + currentPlayer);
                    resetTabla();
                }
                else if(isFull())
                {
                    MessageBox.Show("of");
                    resetTabla();
                }
                else
                {
                    currentPlayer = (currentPlayer == Player1) ? Player2 : Player1;
                }
            }

        }

        private void resetTabla()
        {
            tablaMatrice = new string[BSIZE, BSIZE];
            foreach (Control cont in tableLayoutPanel1.Controls)
            {
                Button bt = (Button)cont;
                bt.Text = "";
            }
            currentPlayer = Player1;
        }

        private bool isWinner(string player)
        {
            for (int i = 0; i < BSIZE; i++)
            {
                if (tablaMatrice[i, 0] == player && tablaMatrice[i, 1] == player
                    && tablaMatrice[i, 2] == player)
                    return true;
            }
            for (int j = 0; j < BSIZE; j++)
            {
                if (tablaMatrice[0, j] == player && tablaMatrice[1, j] == player
                    && tablaMatrice[2, j] == player)
                    return true;
            }
            if (tablaMatrice[0, 0] == player && tablaMatrice[1, 1] == player && tablaMatrice[2, 2] == player)
            {
                return true;
            }
            else if (tablaMatrice[0, 2] == player && tablaMatrice[1, 1] == player && tablaMatrice[2, 0] == player)
            {
                return true;
            }
            return false;
        }

        private bool isFull()
        {
            foreach (string cell in tablaMatrice)
            {
                if (cell == null)
                    return false;
            }
            return true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

}