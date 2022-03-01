using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotoGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length>14)
            {

                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
                checkBox2.Text = $"Nem megfelelő a karakterek száma ({14 - textBox1.Text.Length})";

            }
            string wtf = "";
            foreach (var item in textBox1.Text)
            {
                if (item=='0' || item=='1' || item=='2')
                {

                }
                else
                {
                    wtf += item + ";";
                }
                if (wtf.Length>0)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked= false;
                }
                checkBox1.Text = $"Helytelen karakter az eredményben ({wtf})";
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
