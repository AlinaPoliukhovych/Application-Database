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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection;

        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DbConnection().GetData($"SELECT * FROM Affiliate");
        }
    }
}
