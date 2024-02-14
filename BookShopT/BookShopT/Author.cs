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

namespace BookShopT
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NJTFF52\SQLEXPRESS;Initial Catalog=BookShopDb;Integrated Security=True");
        private void populate()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                Con.Open();
                da.SelectCommand = new SqlCommand();
                // goi thủ tục từ SQl
                da.SelectCommand.CommandText = "SP_displayAuthor";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Connection = Con;
                da.Fill(dt);
                AuthorDGV.DataSource = dt;
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Fail to load DataGridView");
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AuthTb.Text == "" || BirthTb.Text == "" || HomeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_addAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Auth", SqlDbType.NVarChar).Value = AuthTb.Text;
                    cmd.Parameters.Add("@Birth", SqlDbType.NVarChar).Value = BirthTb.Text;
                    cmd.Parameters.Add("@Home", SqlDbType.NVarChar).Value = HomeTb.Text;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Author Saved Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int key = 0;
        private void AuthorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AuthTb.Text = AuthorDGV.SelectedRows[0].Cells[1].Value.ToString();
            BirthTb.Text = AuthorDGV.SelectedRows[0].Cells[2].Value.ToString();
            HomeTb.Text = AuthorDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (AuthTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AuthorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                Con.Open();
                da.SelectCommand = new SqlCommand();
                // goi thủ tục từ SQl
                da.SelectCommand.CommandText = "SP_fillBookDGV";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Auth", SqlDbType.NVarChar).Value = AuthTb.Text;
                da.SelectCommand.Connection = Con;
                da.Fill(dt);
                BookDGV.DataSource = dt;
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Fail to load DataGridView");
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_deleteAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = key;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Author Deleted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (AuthTb.Text == "" || BirthTb.Text == "" || HomeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_editAuthor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = key;
                    cmd.Parameters.Add("@Auth", SqlDbType.NVarChar).Value = AuthTb.Text;
                    cmd.Parameters.Add("@Birth", SqlDbType.NVarChar).Value = BirthTb.Text;
                    cmd.Parameters.Add("@Home", SqlDbType.NVarChar).Value = HomeTb.Text;
                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Author Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            AuthTb.Text = "";
            BirthTb.Text = "";
            HomeTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Books ob = new Books();
            ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Category ob = new Category();
            ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users ob = new Users();
            ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DashBoard ob = new DashBoard();
            ob.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }
    }
}
