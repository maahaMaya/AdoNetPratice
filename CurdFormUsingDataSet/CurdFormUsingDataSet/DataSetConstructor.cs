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

namespace CurdFormUsingDataSet
{
    public partial class DataSetConstructor : Form
    {
        //SqlConnection con;
        //SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataSetConstructor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Default Constructor
            //con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Database=CSDB;");
            //cmd = new SqlCommand("SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno", con);
            //da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //ds = new DataSet();

            //MessageBox.Show("Table Count Before Fill: " + ds.Tables.Count);
            //MessageBox.Show("Connection State Before  Fill: " + con.State);
            //da.Fill(ds, "Employee");
            //MessageBox.Show("Connection State After  Fill: " + con.State);
            //MessageBox.Show("Table Count After Fill: " + ds.Tables.Count);


            //One Parameter
            //con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Database=CSDB;");
            //cmd = new SqlCommand("SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno", con);
            //da = new SqlDataAdapter(cmd);

            //ds = new DataSet();

            //MessageBox.Show("Table Count Before Fill: " + ds.Tables.Count);
            //MessageBox.Show("Connection State Before  Fill: " + con.State);
            //da.Fill(ds, "Employee");
            //MessageBox.Show("Connection State After  Fill: " + con.State);
            //MessageBox.Show("Table Count After Fill: " + ds.Tables.Count);

            ////Two Parameter without connection string
            //con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Database=CSDB;");
            //da = new SqlDataAdapter("SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno", con);

            //ds = new DataSet();

            //MessageBox.Show("Table Count Before Fill: " + ds.Tables.Count);
            //MessageBox.Show("Connection State Before  Fill: " + con.State);
            //da.Fill(ds, "Employee");
            //MessageBox.Show("Connection State After  Fill: " + con.State);
            //MessageBox.Show("Table Count After Fill: " + ds.Tables.Count);


            //Two Parameter with connection string
            da = new SqlDataAdapter("SELECT Eno, Ename, Job, Salary, Status FROM Employee ORDER BY Eno", "Data Source=(localdb)\\MSSQLLocalDB; Database=CSDB;");

            ds = new DataSet();

            MessageBox.Show("Table Count Before Fill: " + ds.Tables.Count);
            da.Fill(ds, "Employee");
            MessageBox.Show("Table Count After Fill: " + ds.Tables.Count);
        }
    }
}
