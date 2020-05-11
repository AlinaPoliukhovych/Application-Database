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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }       

        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";
        private async void button1_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int sum = 0;
                    sqlConnection.Open();
                    SqlDataReader sqlReader = null;
                    SqlCommand command;

                    command = new SqlCommand("SELECT Sum(CheckProduct.Countt) AS CountProduct FROM CheckProduct JOIN PriceList ON PriceList.Id = CheckProduct.PriceListID WHERE CheckProduct.PriceListID in (SELECT PriceList.Id FROM PriceList JOIN TypeProduct ON TypeProduct.Id = PriceList.TypeProductID WHERE TypeProduct.Namee = @typeProduct)", sqlConnection);
                    command.Parameters.AddWithValue("typeProduct", SqlDbType.VarChar).Value = textBox1.Text;
                    try
                    {

                        sqlReader = await command.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            sum = Convert.ToInt32(sqlReader["CountProduct"]);
                        }
                        MessageBox.Show($"Кількість проданих одиниць товарів типу \"{textBox1.Text}\" = " + sum, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Такого типу молочної продукції в базі не існує.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введіть тип продукції, наприклад \"молоко\"(без лапок)", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int sum = 0;
                    sqlConnection.Open();
                    SqlDataReader sqlReader = null;
                    SqlCommand command;

                    command = new SqlCommand("SELECT SUM(PriceList.Price*CheckProduct.Countt) AS SumProduct FROM CheckProduct JOIN PriceList ON PriceList.Id = CheckProduct.PriceListID WHERE CheckProduct.PriceListID in (SELECT PriceList.Id FROM PriceList JOIN TypeProduct ON TypeProduct.Id = PriceList.TypeProductID WHERE TypeProduct.Namee = @typeProduct)", sqlConnection);
                    command.Parameters.AddWithValue("typeProduct", SqlDbType.VarChar).Value = textBox1.Text;
                    try
                    {

                        sqlReader = await command.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            sum = Convert.ToInt32(sqlReader["SumProduct"]);
                        }
                        MessageBox.Show($"Сума проданих одиниць товарів типу \"{textBox1.Text}\" = " + sum, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Такого типу молочної продукції в базі не існує.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введіть тип продукції, наприклад \"молоко\"(без лапок)", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int sum = 0;
                    sqlConnection.Open();
                    SqlDataReader sqlReader = null;
                    SqlCommand command;

                    command = new SqlCommand("SELECT Sum(CheckProduct.Countt) AS CountProduct FROM CheckProduct JOIN PriceList ON PriceList.Id = CheckProduct.PriceListID WHERE CheckProduct.PriceListID in (SELECT PriceList.Id FROM PriceList JOIN Maker ON Maker.Id = PriceList.MakerID  WHERE Maker.Namee like '%' + @maker + '%')", sqlConnection);
                    command.Parameters.AddWithValue("maker", SqlDbType.VarChar).Value = textBox2.Text;
                    try
                    {

                        sqlReader = await command.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            sum = Convert.ToInt32(sqlReader["CountProduct"]);
                        }
                        MessageBox.Show($"Кількість проданих одиниць товарів виробника з ключовим словом \"{textBox2.Text}\" = " + sum, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Такого виробника в базі не існує.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введіть виробника, наприклад \"Простоквашино\"(без лапок)", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int sum = 0;
                    sqlConnection.Open();
                    SqlDataReader sqlReader = null;
                    SqlCommand command;

                    command = new SqlCommand("SELECT SUM(PriceList.Price*CheckProduct.Countt) AS SumProduct FROM CheckProduct JOIN PriceList ON PriceList.Id = CheckProduct.PriceListID WHERE CheckProduct.PriceListID in (SELECT PriceList.Id FROM PriceList JOIN Maker ON Maker.Id = PriceList.MakerID  WHERE Maker.Namee like '%' + @maker + '%')", sqlConnection);
                    command.Parameters.AddWithValue("maker", SqlDbType.VarChar).Value = textBox2.Text;
                    try
                    {

                        sqlReader = await command.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            sum = Convert.ToInt32(sqlReader["SumProduct"]);
                        }
                        MessageBox.Show($"Сума проданих одиниць товарів виробника з ключовим словом \"{textBox2.Text}\" = " + sum, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Такого виробника в базі не існує.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введіть виробника, наприклад \"Простоквашино\"(без лапок)", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
