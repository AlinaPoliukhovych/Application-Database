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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";
        public async void ToFiltr()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                int count = 0;
                int sum = 0;
                sqlConnection.Open();
                SqlDataReader sqlReader = null;
                SqlCommand command;
                command = new SqlCommand("OrdersProc", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("TypeProduct", SqlDbType.NVarChar).Value = textBox3.Text.Trim();
                command.Parameters.AddWithValue("Maker", SqlDbType.NVarChar).Value = textBox4.Text.Trim();
                command.Parameters.AddWithValue("TypePackaging", SqlDbType.NVarChar).Value = comboBox1.Text.Trim();
                command.Parameters.AddWithValue("VolumePackaging", SqlDbType.NVarChar).Value = comboBox2.Text.Trim();
                command.Parameters.AddWithValue("Greasiness", SqlDbType.NVarChar).Value = comboBox3.Text.Trim();
                
                try
                {

                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        count = Convert.ToInt32(sqlReader["CountProduct"]);
                        sum = Convert.ToInt32(sqlReader["SumProduct"]);

                    }
                    textBox1.Text = Convert.ToString(count);
                    textBox2.Text = Convert.ToString(sum);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не знайдено, оберіть іншу характеристику.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ToFiltr();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToFiltr();

        }
    }
}
