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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NJTFF52\SQLEXPRESS;Initial Catalog=BookShopDb;Integrated Security=True");
        public static string UserName = "";
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NJTFF52\SQLEXPRESS;Initial Catalog=BookShopDb;Integrated Security=True");
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='"+UnameTb.Text+"' and UPass='"+UPassTb.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);   
            if (dt.Rows[0][0].ToString() == "1")
            {
                UserName = UnameTb.Text;
                Billing obj = new Billing();
                obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin ();
            obj.Show();
            this.Hide();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (UPassTb.PasswordChar == '*')
            {
                UPassTb.PasswordChar = '\0';
                guna2ImageButton1.Image = BookShopT.Properties.Resources.eye_off_icon;
            }
            else
            {
                UPassTb.PasswordChar = '*';
                guna2ImageButton1.Image = BookShopT.Properties.Resources.eye_icon;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Search ob = new Search();
            ob.Show();
            this.Hide();
        }
    }
}
