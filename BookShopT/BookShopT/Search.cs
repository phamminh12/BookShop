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
    public partial class Search : Form
    {
        public Search()
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
                da.SelectCommand.CommandText = "SP_displayBook";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        private void Reset()
        {
            SearchTb.Clear();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            populate();
            Reset();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (SearchTb.Text == "")
            {
                MessageBox.Show("Please enter your request in the text box!!", "Not enough infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                try
                {
                    Con.Open();
                    da.SelectCommand = new SqlCommand();
                    da.SelectCommand.CommandText = "SP_searchBook";
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Text", SqlDbType.VarChar).Value = SearchTb.Text;
                    da.SelectCommand.Connection = Con;
                    da.Fill(dt);
                    BookDGV.DataSource = dt;
                    Con.Close();
                }
                catch
                {
                    MessageBox.Show("Fail to search book", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
