using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Var10
{
    public partial class Form1 : Form
    {
        private SqlConnection con = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        DataTable tabel;

        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e) // список
        {

            //tabel.Clear();
            string connstr = @"Data Source=DESKTOP-QVHC0LO\SQLEXPRESS;Initial Catalog = predpriyatie; Integrated Security = True";
            con = new SqlConnection(connstr);
            con.Open();
            sqlDataAdapter = new SqlDataAdapter("SELECT fam, namee, otche FROM sotrudnik LEFT JOIN MedKarta ON sotrudnik.Id = IdSotr LEFT JOIN DataOsmotra ON MedKarta.Id = Idkart where Result = 'нет';", con);
            tabel = new DataTable();
            sqlDataAdapter.Fill(tabel);

            dataGridView1.DataSource = tabel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string connstr = @"Data Source=DESKTOP-QVHC0LO\SQLEXPRESS;Initial Catalog = predpriyatie; Integrated Security = True";
            //SqlConnection con = new SqlConnection(connstr);
        }

        private void button2_Click(object sender, EventArgs e) //колво
        {
            string connstr = @"Data Source=DESKTOP-QVHC0LO\SQLEXPRESS;Initial Catalog = predpriyatie; Integrated Security = True";
            con = new SqlConnection(connstr);
            con.Open();
            string datatime = textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text;
            label1.Text = datatime;
            sqlDataAdapter = new SqlDataAdapter("SELECT COUNT(*) FROM DataOsmotra where Result != 'нет' AND Dat = '" + datatime + "';", con);
            tabel = new DataTable();
            sqlDataAdapter.Fill(tabel);

            dataGridView1.DataSource = tabel;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
