﻿using System;
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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NJTFF52\SQLEXPRESS;Initial Catalog=BookShopDb;Integrated Security=True");
        private void DashBoard_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(BQty) from BookTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BookStockLbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Amount) from BillTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            AmountLbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select Count(*) from UserTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserTotalLbl.Text = dt2.Rows[0][0].ToString();
            Con.Close();
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
