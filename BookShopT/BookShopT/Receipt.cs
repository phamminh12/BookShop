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
    public partial class Receipt : Form
    {
        public Receipt()
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
            string query = "Select KName from KindTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                BCatCb.Items.Add(dr["KName"].ToString());
            }
        }
        private void populate()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                Con.Open();
                da.SelectCommand = new SqlCommand();
                // goi thủ tục từ SQl
                da.SelectCommand.CommandText = "SP_displayReceipt";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Connection = Con;
                da.Fill(dt);
                ReceiptDGV.DataSource = dt;
                loadCbb();
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Fail to load DataGridView");
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "" || BautTb.Text == "" || QtyTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SP_addReceipt";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = Login.UserName;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = BTitleTb.Text;
                    cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd.Parameters.Add("@Cate", SqlDbType.NVarChar).Value = BCatCb.Text;
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTb.Text;
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = PriceTb.Text;
                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "SP_addAuthorIf";
                    cmd1.Parameters.Add("@Auth", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd1.Connection = Con;
                    Con.Open();
                    cmd1.ExecuteNonQuery();
                    Con.Close();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "SP_addBook";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@Title", SqlDbType.NVarChar).Value = BTitleTb.Text;
                    cmd2.Parameters.Add("@Author", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd2.Parameters.Add("@Cat", SqlDbType.NVarChar).Value = BCatCb.Text;
                    cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTb.Text;
                    cmd2.Parameters.Add("@Price", SqlDbType.Int).Value = PriceTb.Text;

                    cmd2.Connection = Con;
                    Con.Open();
                    cmd2.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Receipt Saved Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void ReceiptDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = ReceiptDGV.SelectedRows[0].Cells[2].Value.ToString();
            BautTb.Text = ReceiptDGV.SelectedRows[0].Cells[3].Value.ToString();
            BCatCb.SelectedItem = ReceiptDGV.SelectedRows[0].Cells[4].Value.ToString();
            QtyTb.Text = ReceiptDGV.SelectedRows[0].Cells[5].Value.ToString();
            PriceTb.Text = ReceiptDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (BTitleTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ReceiptDGV.SelectedRows[0].Cells[0].Value.ToString());
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

                    cmd.CommandText = "SP_deleteReceipt";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = key;

                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Receipt Deleted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            UserNameLbl.Text = Login.UserName;
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
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_editReceipt";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = key;
                    cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = Login.UserName;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = BTitleTb.Text;
                    cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = BautTb.Text;
                    cmd.Parameters.Add("@Cate", SqlDbType.NVarChar).Value = BCatCb.Text;
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTb.Text;
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = PriceTb.Text;
                    cmd.Connection = Con;
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Receipt Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Billing ob = new Billing();
            ob.Show();
            this.Hide();
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
