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
    public partial class Category : Form
    {
        public Category()
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
                da.SelectCommand.CommandText = "SP_displayCate";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Connection = Con;
                da.Fill(dt);
                CateDGV.DataSource = dt;
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Fail to load DataGridView");
            }
        }
        private void Reset()
        {
            CateTb.Clear();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CateTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_addCate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Kind", SqlDbType.NVarChar).Value = CateTb.Text;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Category Saved Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void CateDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CateTb.Text = CateDGV.SelectedRows[0].Cells[1].Value.ToString();
            if (CateTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CateDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                Con.Open();
                da.SelectCommand = new SqlCommand();
                // goi thủ tục từ SQl
                da.SelectCommand.CommandText = "SP_fillBookDGV2";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Kind", SqlDbType.NVarChar).Value = CateTb.Text;
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

                    cmd.CommandText = "SP_deleteCate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = key;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Category Deleted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (CateTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_editCate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = key;
                    cmd.Parameters.Add("@Kind", SqlDbType.NVarChar).Value = CateTb.Text;
                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Category Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Author obj = new Author();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DashBoard o = new DashBoard();
            o.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
