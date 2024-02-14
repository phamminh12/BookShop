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

namespace BookShopT
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NJTFF52\SQLEXPRESS;Initial Catalog=BookShopDb;Integrated Security=True");
        private void loadCbb()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NJTFF52\SQLEXPRESS;Initial Catalog=BookShopDb;Integrated Security=True");
            Con.Open();
            BCatCb.Items.Clear();
            CatCbSearchCb.Items.Clear();
            string query = "Select KName from KindTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BCatCb.Items.Add(dr["KName"].ToString());
                CatCbSearchCb.Items.Add(dr["KName"].ToString());
            }
        }
        private void populate()
        {
            /*Con.Open();
            string query = "select * from BookTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            loadCbb();
            Con.Close();*/

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
                loadCbb();
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Fail to load DataGridView");
            }
        }
        
        private void Filter()
        {
            Con.Open();
            string query = "select * from BookTbl where BCat='"+CatCbSearchCb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(BTitleTb.Text == "" || BautTb.Text=="" || QtyTb.Text == "" || PriceTb.Text=="" || BCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    /*Con.Open();
                    string query = "insert into BookTbl values ('" + BTitleTb.Text + "','" + BautTb.Text + "','" + BCatCb.SelectedItem.ToString() + "','" + QtyTb.Text + "','" + PriceTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Saved Successfully");
                    Con.Close();
                    populate();
                    Reset();*/

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SP_addBook";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = BTitleTb.Text;
                    cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd.Parameters.Add("@Cat", SqlDbType.NVarChar).Value = BCatCb.Text;
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTb.Text;
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = PriceTb.Text;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Book Saved Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "SP_addAuthorIf";
                    cmd1.Parameters.Add("@Auth", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd1.Connection = Con;
                    Con.Open();
                    cmd1.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    Reset();
                } 
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void CatCbSearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            populate();
            CatCbSearchCb.SelectedIndex = -1;
        }
        private void Reset()
        {
            BTitleTb.Text = "";
            BautTb.Text = "";
            BCatCb.SelectedIndex = -1;
            PriceTb.Text = "";
            QtyTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        int key = 0;
        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            BautTb.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
            BCatCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (BTitleTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
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
                    /*Con.Open();
                    string query = "delete from BookTbl where BId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();*/

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_deleteBook";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = key;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Book Deleted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (BTitleTb.Text == "" || BautTb.Text == "" || QtyTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    /*Con.Open();
                    string query = "update BookTbl set BTitle='"+BTitleTb.Text+"',BAuthor='"+BautTb.Text+"',BCat='"+BCatCb.SelectedItem.ToString()+"',BQty="+QtyTb.Text+",BPrice="+PriceTb.Text+" where BId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();*/

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_editBook";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = key;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = BTitleTb.Text;
                    cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd.Parameters.Add("@Cat", SqlDbType.NVarChar).Value = BCatCb.Text;
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTb.Text;
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = PriceTb.Text;
                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Book Update Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DashBoard obj = new DashBoard();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Author ob = new Author();
            ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Category ob = new Category();
            ob.Show();
            this.Hide();
        }
    }
}
