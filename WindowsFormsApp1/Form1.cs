using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, this.textBox1.Size.Height); 
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String password = textBox2.Text;

            if (login == "admin" & password == "1234")
            {
                Form2 form2 = new Form2();
                textBox1.Text = "";
                textBox2.Text = "";

                form2.Show();
            }
            else
            {
                MessageBox.Show("Неправильні облікові дані\n(логін і пароль зліва під зображеннями)", "Невірно!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}
