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
using System.IO;

namespace StoreProcedure
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        string imgPath = "";
        byte[] imgData = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            con = new SqlConnection(conStr);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (btnInsert.Text == "New")
            {
                btnClear.PerformClick();
                btnInsert.Text = "Insert";
            }
            else
            {
                try
                {
                    cmd.CommandText = "Emp_Insert";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Ename", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Job", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Salary", textBox4.Text);

                    if (imgPath.Trim().Length > 0)
                    {
                        imgData = File.ReadAllBytes(imgPath);
                        cmd.Parameters.AddWithValue("@Photo", imgData);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Photo", DBNull.Value);
                        cmd.Parameters["@Photo"].SqlDbType = SqlDbType.VarBinary;
                    }
                    cmd.Parameters.Add("@Eno", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    textBox1.Text = cmd.Parameters["@Eno"].Value.ToString();
                    imgData = null; 
                    imgPath = "";
                    btnInsert.Text = "New";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            imgPath = "";
            imgData = null;
            pictureBox1.Image = null;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox2.Focus();
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Jpeg Images|*.jpg|Bitmap Images|*.bmp|All Files|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                imgPath = openFileDialog1.FileName;
                pictureBox1.ImageLocation = imgPath;
            }
        }
        private void btnImgCancel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
