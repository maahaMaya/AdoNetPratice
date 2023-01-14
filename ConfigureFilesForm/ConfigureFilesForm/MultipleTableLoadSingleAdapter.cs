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
    public partial class MultipleTableLoadSingleAdapter : Form
    {
        DataSet ds;
        SqlDataAdapter da;

        bool flag = false;
        public MultipleTableLoadSingleAdapter()
        {
            InitializeComponent();
        }

        private void MultipleTableLoadApporachOne_Load(object sender, EventArgs e)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            ds = new DataSet();
            da = new SqlDataAdapter("Select * From Dept", ConStr);
            da.Fill(ds, "Dept");
            da.SelectCommand.CommandText = "Select * From Emp";
            da.Fill(ds, "Emp");
            //MessageBox.Show("total table :" + ds.Tables.Count);
            dataGridView1.DataSource = ds.Tables["Emp"];

            comboBox1.DataSource = ds.Tables["Dept"];
            //comboBox1.DisplayMember = "Deptno";
            comboBox1.DisplayMember = "Dname";
            comboBox1.ValueMember = "Deptno";
            comboBox1.Text = "-- Select department --";
            flag = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                DataView dv = ds.Tables["Emp"].DefaultView;
                //dv.RowFilter = "Deptno = " + comboBox1.Text;
                dv.RowFilter = "Deptno = " + comboBox1.SelectedValue;
                //MessageBox.Show("Text :" + comboBox1.Text);
                //MessageBox.Show("Value : " + comboBox1.SelectedValue);
                //dv.Sort = "Ename";
                dv.Sort = "Ename Desc";
            }
        }
    }
}
