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
using System.Configuration;

namespace ConfigureFilesForm
{
    public partial class MultipleTableLoadMultiAdapter : Form
    {
        DataSet ds;
        DataRelation dr;
        SqlConnection con;
        SqlDataAdapter da1, da2;
        public MultipleTableLoadMultiAdapter()
        {
            InitializeComponent();
        }

        private void MultipleTableLoadMultiAdapter_Load(object sender, EventArgs e)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            con = new SqlConnection(ConStr);
            da1 = new SqlDataAdapter("Select * From Dept", con);
           // da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da2 = new SqlDataAdapter("Select * From Emp", con);
            //da2.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ds = new DataSet();
            da1.Fill(ds, "Dept");
            da2.Fill(ds, "Emp");

            dr = new DataRelation("ParentChild", ds.Tables["Dept"].Columns["Deptno"], ds.Tables["Emp"].Columns["Deptno"]);
            ds.Relations.Add(dr);

            dataGridView1.DataSource = ds.Tables["Dept"];
            dataGridView2.DataSource = ds.Tables["Emp"];


        }
    }
}
