using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace ConfigureFilesForm
{
    public partial class DataGridForm : Form
    {
        DataSet ds;
        SqlDataAdapter da;

        public DataGridForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridForm_Load(object sender, EventArgs e)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            da = new SqlDataAdapter("SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno", ConStr);
            ds = new DataSet();
            da.Fill(ds, "Employee");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            da.Update(ds, "Employee");
            MessageBox.Show("Data saved to Database Server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
