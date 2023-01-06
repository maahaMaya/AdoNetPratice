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

namespace CurdFormApp
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
            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            //cmd.CommandText = "SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno";
            //dr = cmd.ExecuteReader();
            //ShowData();
            Load_Data();
        }
        private void ShowData() 
        { 
            if (dr.Read())
            {
                textBox1.Text = dr["Eno"].ToString();
                textBox2.Text = dr["Ename"].ToString();
                textBox3.Text = dr["Job"].ToString();
                textBox4.Text = dr["Salary"].ToString();
                checkBox1.Checked = (bool)dr["Status"];
            }
            else
            {
                MessageBox.Show("You are last record of the table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Load_Data()
        {
            cmd.CommandText = "SELECT Eno, Ename, Job, Salary, Status FROM Employee WHERE Status = 1 ORDER BY Eno";
            dr = cmd.ExecuteReader();
            ShowData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            //textBox1.Clear();
            //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox tb = ctrl as TextBox;
                    tb.Clear();
                }
            }
            dr.Close();
            cmd.CommandText = "SELECT ISNULL(MAX(Eno), 1000) + 1 FROM Employee";
            textBox1.Text = cmd.ExecuteScalar().ToString();
            checkBox1.Enabled = true;
            btnInsert.Enabled = true;
            textBox2.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cmd.CommandText = $"INSERT INTO Employee (Eno, Ename, Job, Salary, Status) VALUES ({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}', {textBox4.Text}, {Convert.ToInt32(checkBox1.Checked)})";
            //MessageBox.Show(cmd.CommandText);
            if(cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox1.Enabled = false;
                btnInsert.Enabled = false;
                Load_Data();

            }
            else
            {
                MessageBox.Show("Not Saved..try again", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dr.Close();
            cmd.CommandText = $"UPDATE Employee SET Ename = '{textBox2.Text}', Job = '{textBox3.Text}', Salary = {textBox4.Text}, Status =  {Convert.ToInt32(checkBox1.Checked)} WHERE Eno = {textBox1.Text}";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox1.Enabled = false;
                btnInsert.Enabled = false;
                Load_Data();
            }
            else
            {
                MessageBox.Show("Not Saved..try again", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dr.Close();
            //cmd.CommandText = $"DELETE FROM Employee WHERE Eno = {textBox1.Text}";
            cmd.CommandText = $" UPDATE Employee SET Status = 0 WHERE Eno = {textBox1.Text}";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox1.Enabled = false;
                btnInsert.Enabled = false;
                Load_Data();
            }
            else
            {
                MessageBox.Show("Not Deleted..try again", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
