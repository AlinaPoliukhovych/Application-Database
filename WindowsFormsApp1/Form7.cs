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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = new DbConnection().GetData(richTextBox1.Text);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Помилка в коді, перевірте правильність написання команд.\nДетально:\n" + ex.Message, "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TopMost == false)
            {
                button2.Text = "Зменшити вікно";
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                TopMost = true;
                dataGridView1.Size = new Size(800, 800);
                dataGridView1.Location = new Point(594, 26);

                //Location of button Close
                button3.Location = new Point(1477, 10);
                button2.Location = new Point(90, 750);
                button1.Location = new Point(160, 750);
                richTextBox1.Size = new Size(400, 700);

            }
            else
            {
                WindowState = FormWindowState.Normal;
                button2.Text = "На весь екран";
                TopMost = false;
                this.Size = new Size(818, 497);
                dataGridView1.Location = new Point(320, 26);
                dataGridView1.Size = new Size(425, 348);
                button3.Location = new Point(758, 3);
                button1.Location = new Point(340, 380);
                button2.Location = new Point(600, 380);
                richTextBox1.Size = new Size(299, 426);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
