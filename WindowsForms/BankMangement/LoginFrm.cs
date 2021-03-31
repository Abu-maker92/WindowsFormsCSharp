using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankMangement
{
    public partial class LoginFrm : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnCLogin_Click(object sender, EventArgs e)
        {
            string query = "Select * from Log_tbl where UserName='" + txtEnterUserName.Text.Trim() + "' and Password='" + txtEnterPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, constr);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                this.Hide();
                Form1 frm1 = new Form1();                
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
        }

        private void btnRWindow_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterFrm rgf = new RegisterFrm();
            rgf.Show();
        }
    }
}
