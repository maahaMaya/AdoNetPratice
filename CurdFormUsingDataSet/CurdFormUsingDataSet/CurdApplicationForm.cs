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
using Microsoft.VisualBasic;

namespace CurdFormUsingDataSet
{
    public partial class CurdApplicationForm : Form
    {
        SqlDataAdapter da;
        DataSet ds;

        int RowIndex = 0;
        public CurdApplicationForm()
        {
            InitializeComponent();
        }

        private void CurdApplicationForm_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno", "Data Source=(localdb)\\MSSQLLocalDB; Database=CSDB;");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ds = new DataSet();

            da.Fill(ds, "Employee");

            ShowData();
        }
        public void ShowData() 
        {
            if(ds.Tables[0].Rows[RowIndex].RowState != DataRowState.Deleted)
            {
                textBox1.Text = ds.Tables[0].Rows[RowIndex]["Eno"].ToString();
                textBox2.Text = ds.Tables[0].Rows[RowIndex]["Ename"].ToString();
                textBox3.Text = ds.Tables[0].Rows[RowIndex]["Job"].ToString();
                textBox4.Text = ds.Tables[0].Rows[RowIndex]["Salary"].ToString();
            }
            else
            {
                MessageBox.Show("This data is deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (RowIndex >= 1)
            {
                RowIndex--;
                ShowData();
            }
            else
            {
                RowIndex++;
                MessageBox.Show("You are first record of the table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(RowIndex >= (ds.Tables[0].Rows.Count - 1))
            {
                MessageBox.Show("You are last record of the table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RowIndex++;
                ShowData();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            RowIndex = 0;
            ShowData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            RowIndex = ds.Tables[0].Rows.Count - 1;
            ShowData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            int lastRowIndex = ds.Tables[0].Rows.Count  - 1;
            int newEmpNo = Convert.ToInt16(ds.Tables[0].Rows[lastRowIndex]["Eno"]) + 1;
            textBox1.Text = newEmpNo.ToString();
            btnInsert.Enabled = true;
            textBox2.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables["Employee"].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;
            dr[4] = true;
            ds.Tables["Employee"].Rows.Add(dr);
            btnInsert.Enabled = false;
            MessageBox.Show("Record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds.Tables["Employee"].Rows[RowIndex]["Eno"] = textBox1.Text;
            ds.Tables["Employee"].Rows[RowIndex]["Ename"] = textBox2.Text;
            ds.Tables["Employee"].Rows[RowIndex]["Job"] = textBox3.Text;
            ds.Tables["Employee"].Rows[RowIndex]["Salary"] = textBox4.Text;
            MessageBox.Show("Updated successfully .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ds.Tables["Employee"].Rows[RowIndex].Delete();
            btnFirst.PerformClick();
            MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            da.Update(ds, "Employee");
            MessageBox.Show("Updated DataBase successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = Interaction.InputBox("Enter Emp no to search : ", "Input box");
            bool Status = int.TryParse(value, out int Eno);
            if (Status)
            {
                DataRow dr = ds.Tables[0].Rows.Find(Eno);
                if (dr != null)
                {
                    RowIndex = ds.Tables[0].Rows.IndexOf(dr);
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                }
                else
                {
                    MessageBox.Show("Emp no is not exist in the table", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Employee values must be integer.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
