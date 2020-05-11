using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER01;
                                        Initial Catalog=Dairy;Integrated Security=True";
        private void Form9_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DbConnection().GetData($"SELECT Packaging.Id, TypePackaging.Namee, VolumePackaging.Valuee " +
                " FROM Packaging JOIN TypePackaging ON TypePackaging.ID = Packaging.TypePackagingID " +
                "JOIN VolumePackaging ON VolumePackaging.ID = Packaging.VolumePackagingID ");

        }
    }
}
