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

namespace FormApplications
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Database=CSDB;");
            cmd = new SqlCommand("SELECT Deptno, Dname, Location FROM Dept ORDER BY Deptno", con);
            con.Open();
            dr = cmd.ExecuteReader();

            label1.Text = dr.GetName(0) + ":";
            label2.Text = dr.GetName(1) + ":";
            label3.Text = dr.GetName(2) + ":";

            ShowData();
        }

        private void ShowData()
        {
            if (dr.Read())
            {
                textBox1.Text = dr.GetValue(0).ToString();
                textBox2.Text = dr.GetValue(1).ToString();
                textBox3.Text = dr.GetValue(2).ToString();
            }
            else
            {
                MessageBox.Show("You are last record of the table", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(con.State != ConnectionState.Closed)
            {
                con.Close();
            }  
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
