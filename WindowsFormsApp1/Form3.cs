using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";
        
        public void Refresh()
        {
           
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {             
                
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SearchProductsBy", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("TypeProduct", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                command.Parameters.AddWithValue("Maker", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
                command.Parameters.AddWithValue("TypePackaging", SqlDbType.NVarChar).Value = comboBox1.Text.Trim();
                command.Parameters.AddWithValue("VolumePackaging", SqlDbType.NVarChar).Value = comboBox2.Text.Trim();
                command.Parameters.AddWithValue("Greasiness", SqlDbType.NVarChar).Value = comboBox3.Text.Trim();
                command.Parameters.AddWithValue("Price", SqlDbType.NVarChar).Value = textBox3.Text.Trim();
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView1.DataSource = dt;
                sqlConnection.Close();
               
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (button2.Text=="На весь екран")
            {
                button2.Text = "Зменшити вікно";
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                TopMost = true;
                dataGridView1.Size = new Size(800, 800);
                dataGridView1.Location = new Point(394, 26);

                //Location of button Close
                button3.Location = new Point(1477, 10);
                button2.Location = new Point(12, 430);


            }
            else
            {
                WindowState = FormWindowState.Normal;
                button2.Text = "На весь екран";
                TopMost = false;
                this.Size= new Size(818, 497);
                dataGridView1.Location = new Point(320, 26);

                dataGridView1.Size = new Size(425, 348);
                button3.Location = new Point(758, 3);
                button2.Location = new Point(605, 380);
            }
        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Refresh();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Refresh();

        }
    }
}
