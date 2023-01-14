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
using System.Data.OracleClient;

namespace ConfigureFilesForm
{
    public partial class MultiTableFromDiffrerntDS : Form
    {
        DataSet ds;
        SqlDataAdapter sda;
        SqlDataAdapter oda;
        //OracleDataAdapter oda;
        public MultiTableFromDiffrerntDS()
        {
            InitializeComponent();
        }

        private void MultipleTableLoadMultiAdapter_Load(object sender, EventArgs e)
        {
            string SqlConStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            string OracleConStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;

            sda = new SqlDataAdapter("Select Eno, Ename, Job, Salary, Status From Employee", SqlConStr);
            oda = new SqlDataAdapter("Select Grade, LoSal, HiSal From Salgrade", OracleConStr);


            ds = new DataSet();
            sda.Fill(ds, "Employee");
            oda.Fill(ds, "Salgrade");
            dataGridView1.DataSource = ds.Tables["Salgrade"];
            dataGridView2.DataSource = ds.Tables["Employee"];
        }
    }
}
