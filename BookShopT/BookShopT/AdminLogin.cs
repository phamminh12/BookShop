using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopT
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (UPassTb.Text == "0000")
            {
                Books Obj = new Books();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password.Contact The Admin");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
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

        
    }
}
