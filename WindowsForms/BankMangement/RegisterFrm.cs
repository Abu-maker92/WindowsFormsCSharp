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
    public partial class RegisterFrm : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //string Password;
            int count = 0;
            Log_tbl obj = new Log_tbl();
            obj.UserName = txtCUserName.Text;
            obj.Password = txtCPassword.Text;

            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Log_tbl(UserName, Password) VALUES" +
                    " ('" + obj.UserName + "', '" + obj.Password + "')";
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (txtCUserName.Text == "" || txtCPassword.Text == "")
                {
                    MessageBox.Show("Fill Up Both UserName and Password");
                }
                else if (count > 0)
                {
                    MessageBox.Show("Register UserName and Password  Successfully");
                }
                else
                {
                    MessageBox.Show("Click Again Register Button");
                }
                AllClear();
            }
        }

        private void AllClear()
        {
            txtCUserName.Text = "";
            txtCPassword.Text = "";
        }

        private void btnLoginwindow_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginFrm lgf = new LoginFrm();
            lgf.Show();
        }
    }
}
