using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            //Location of button Close
            button11.Location = new Point(1477, 10);
            dataGridView5.Size = new Size(800, 859);

            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
            ShowMaker();
            ShowCheckProduct();
            ShowCheckUnique();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))//Show PriceList
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowPrice", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView5.DataSource = dt;
                sqlConnection.Close();
            }
        }
      
        private void label22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowMaker()
        {
            Thread.Sleep(1000);
            dataGridView1.DataSource = new DbConnection().GetData($"SELECT * FROM Maker");
        }
      
        private void button4_Click(object sender, EventArgs e)//INSERT Maker
        {
            Task task = new Task(InsertMaker);
            task.Start();
            task.Wait();

            textBox9.Text = "";
            ShowMaker();
        }
        public void InsertMaker()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox9.Text, "Maker");
        }

        private  void button8_Click(object sender, EventArgs e)//UPDATE Maker
        {
            Task task = new Task(UpdateMaker);
            task.Start();
            task.Wait();

            textBox10.Text = "";
            textBox11.Text = "";

            ShowMaker();
        }
        public void UpdateMaker()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Update("Namee", textBox10.Text, "Maker", textBox11.Text);
        }

        private void button10_Click(object sender, EventArgs e)//DELETE Maker
        {           
            Task task = new Task(DeleteMaker);
            task.Start();
            task.Wait();

            textBox12.Text = "";
            ShowMaker();
        }

        public void DeleteMaker()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox12.Text, "Maker");
        }        
       
        private void button12_Click(object sender, EventArgs e)//INSERT TypeProduct
        {
            Task task = new Task(InsertTypeProduct);
            task.Start();
            task.Wait();

            textBox7.Text = "";
            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
        }
        public void InsertTypeProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox7.Text, "TypeProduct");
        }

        private void button9_Click(object sender, EventArgs e)//UPDATE TypeProduct
        {
            Task task = new Task(UpdateTypeProduct);
            task.Start();
            task.Wait();

            textBox2.Text = "";
            textBox4.Text = "";

            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
        }
        public void UpdateTypeProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Update("Namee", textBox2.Text, "TypeProduct", textBox4.Text);
        }

        private void button6_Click(object sender, EventArgs e)//DELETE TypeProduct
        {
            Task task = new Task(DeleteTypeProduct);
            task.Start();
            task.Wait();

            textBox1.Text = "";
            dataGridView2.DataSource = new DbConnection().GetData($"SELECT * FROM TypeProduct");
        }

        public void DeleteTypeProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox1.Text, "TypeProduct");
        }

        public void ShowCheckProduct()
        {
            Thread.Sleep(1000);
            dataGridView3.DataSource = new DbConnection().GetData($"SELECT * FROM CheckProduct ORDER BY CheckUniqueID");
        }

        private void button16_Click(object sender, EventArgs e)//INSERT CheckProduct
        {
            Task task = new Task(InsertCheckProduct);
            task.Start();
            task.Wait();

            textBox16.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            ShowCheckProduct();
        }
        public void InsertCheckProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox16.Text, textBox25.Text, textBox26.Text, "CheckProduct");
        }
        private void button15_Click(object sender, EventArgs e)//UPDATE CheckProduct
        {          
            Task task = new Task(UpdateCheckProduct);
            task.Start();
            task.Wait();
            textBox29.Text = "";
            textBox28.Text = "";
            textBox27.Text = "";
            textBox15.Text = "";
            ShowCheckProduct();
        }

        public void UpdateCheckProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Update("CheckUniqueID", textBox29.Text, "PriceListID", textBox28.Text, "Countt", textBox27.Text,  "CheckProduct", textBox15.Text);
        }

        private void button14_Click(object sender, EventArgs e)//DELETE CheckProduct
        {
            Task task = new Task(DeleteCheckProduct);
            task.Start();
            task.Wait();

            textBox41.Text = "";
            ShowCheckProduct();
        }

        public void DeleteCheckProduct()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox41.Text, "CheckProduct");
        }
        
        public void ShowCheckUnique()
        {
            Thread.Sleep(1000);
            dataGridView4.DataSource = new DbConnection().GetData($"SELECT * FROM CheckUnique");
        }
        private void button20_Click(object sender, EventArgs e)//INSERT CheckUnique
        {
            Task task = new Task(InsertCheckUnique);
            task.Start();
            task.Wait();

            textBox20.Text = "";
            ShowCheckUnique();
        }
        public void InsertCheckUnique()
        {
            DbConnection dbConnection = new DbConnection();
            string date1 = Convert.ToString(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm.ss"));
            string date2 = Convert.ToString(dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm.ss"));
            dbConnection.Insert(textBox20.Text, date1, date2, "CheckUnique");
            MessageBox.Show(""+ date1 + "  "+ date2);
        }
        private void button19_Click(object sender, EventArgs e)//UPDATE CheckUnique
        {
            Task task = new Task(UpdateCheckUnique);
            task.Start();
            task.Wait();
            textBox18.Text = "";
            textBox19.Text = "";
            ShowCheckUnique();
        }

        public void UpdateCheckUnique()
        {
            string date1 = Convert.ToString(dateTimePicker4.Value);
            string date2 = Convert.ToString(dateTimePicker3.Value);
            
            DbConnection dbConnection = new DbConnection();
            dbConnection.Update("AffiliateID", textBox18.Text, "DateSold", date1, "DatePayment", date2, "CheckUnique", textBox19.Text);
        }

        private void button18_Click(object sender, EventArgs e)//DELETE CheckUnique
        {
            Task task = new Task(DeleteCheckUnique);
            task.Start();
            task.Wait();

            textBox17.Text = "";
            ShowCheckUnique();
        }

        public void DeleteCheckUnique()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox17.Text, "CheckUnique");
        }
                
        private void button5_Click(object sender, EventArgs e)//Refresh PriceList
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("ShowPrice", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView5.DataSource = dt;
                sqlConnection.Close();
            }
        }
        private async void button24_Click(object sender, EventArgs e)//INSERT PriceList
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(InsertPriceList);
            task.Start();
            task.Wait();

            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox39.Text = "";

            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }
        public void InsertPriceList()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Insert(textBox34.Text, textBox35.Text, textBox36.Text, textBox37.Text, textBox39.Text, "PriceList");
        }
        private async void button23_Click(object sender, EventArgs e)//UPDATE PriceList
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(UpdatePriceList);
            task.Start();
            task.Wait();

            textBox23.Text = "";
            textBox32.Text = "";
            textBox31.Text = "";
            textBox30.Text = "";
            textBox22.Text = "";
            textBox33.Text = "";

            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }
        public void UpdatePriceList()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                ["ID"] = textBox23.Text,
                ["TypeProductID"] = textBox32.Text,
                ["MakerID"] = textBox31.Text,
                ["Price"] = textBox30.Text,
                ["PackagingID"] = textBox22.Text,
                ["GreasinessID"] = textBox33.Text,
            };

            DbConnection dbConnection = new DbConnection();
            dbConnection.Update(keyValuePairs, "PriceList");
        }
        private async void button22_Click(object sender, EventArgs e)//DELETE PriceList
        {
            if (label55.Visible)
                label55.Visible = false;
            Task task = new Task(DeletePriceList);
            task.Start();
            task.Wait();

            textBox21.Text = "";
            label55.Visible = true;
            label55.Text = "Натисніть клавішу \"Оновити\", щоб дані в таблиці оновилися.";
            await Task.Delay(4000);
            label55.Text = "";
        }

        public void DeletePriceList()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Delete(textBox21.Text, "PriceList");
            
        }

        private void пошукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        private void знайтиКількістьПроданихОдиницьПевногоТоваруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void аналітикаПродажівфільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void пісочницяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }        
    }
}
