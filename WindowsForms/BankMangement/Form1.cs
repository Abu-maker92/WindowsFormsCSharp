using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankMangement
{
    public partial class Form1 : Form
    {
        int accId;
        int accTyId;
        string imgLocation;
        string constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        private string AccountType;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadcmbAccountType();
            LoaddgvCustomerInfo();
            //LoadcmbGender();
        }

        private void ClearAll()
        {
            txtCName.Text = "";
            txtFName.Text = "";
            txtAccountTypeId.Text = "";
            cmbGender.Text = "";
            txtAccountType.Text = "";            
            dateTimePicker.Text = "";
            txtOccupation.Text = "";
            txtPhnNumber.Text = "";
            txtDepositAmount.Text = "";
        }

        private void LoaddgvCustomerInfo()
        {
            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT AccountNo, CustomerName, FathersName, Customer.AccountTypeId,Gender, AccountType, DateOfBirth,Ocupation,PhoneNo,DepositAmount, ImageName, ImageData FROM Customer join AccountType_tbl on AccountType_tbl.AccountTypeId=Customer.AccountTypeId";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr, LoadOption.Upsert);
                con.Close();
                dgvCustomerInfo.DataSource = dt;
                dgvCustomerInfo.RowTemplate.Height = 80;
                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dgvCustomerInfo.Columns[11];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;

            }
        }

        private void LoadcmbGender()
        {
            
        }

        private void LoadcmbAccountType()
        {
            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM AccountType_tbl";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr, LoadOption.Upsert);
                con.Close();
                cmbTypeOfAcc.ValueMember = "AccountTypeId";
                cmbTypeOfAcc.DisplayMember = "AccountType";
                cmbTypeOfAcc.DataSource = dt;
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int count;
            Customer obj = new Customer();
            obj.CustomerName = txtCName.Text;
            obj.FathersName = txtFName.Text;
            obj.AccountTypeId = Convert.ToInt32(cmbTypeOfAcc.SelectedValue.ToString());
            obj.Gender = cmbGender.Text;
            obj.DateOfBirth = Convert.ToDateTime(dateTimePicker.Text);
            obj.Ocupation = txtOccupation.Text;
            obj.PhoneNo = txtPhnNumber.Text;
            obj.DepositAmount = Convert.ToDecimal(txtDepositAmount.Text);
            obj.ImageName = imgLocation;

            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brdr = new BinaryReader(stream);
            images = brdr.ReadBytes((int)stream.Length);
            obj.ImageData = images;

            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Customer SET CustomerName='" + obj.CustomerName + "', FathersName='" + obj.FathersName + "', AccountTypeId='" + obj.AccountTypeId + "'," +
                    " " + " DateOfBirth='" + obj.DateOfBirth + "',Ocupation='" + obj.Ocupation + "',PhoneNo='" + obj.PhoneNo + "',DepositAmount='" + obj.DepositAmount + "', ImageName='" + obj.ImageName + "', ImageData=@img Where AccountNo='" + accId + "'";
                cmd.Parameters.Add(new SqlParameter("@img", obj.ImageData));                
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("Data Insert Successfully");
                }
            }
            ClearAll();
            LoaddgvCustomerInfo();
        }

        private void btnUpdate_Acc_Click(object sender, EventArgs e)
        {
            int count;
            //Course objc = new Course();

            AccountType = txtAccountType.Text;

            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE AccountType_tbl SET AccountType='" + AccountType + "' Where AccountTypeId='" + accTyId + "'";
                //cmd.CommandText = "INSERT INTO Course(CourseName) VALUES" + " ('" + CourseName + "')";
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("Data Update Successfully");
                }
            }
            ClearAll();
            LoaddgvCustomerInfo();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                imgLocation = d.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count;
            Customer obj = new Customer();
            obj.CustomerName = txtCName.Text;
            obj.FathersName = txtFName.Text;
            obj.AccountTypeId = Convert.ToInt32(cmbTypeOfAcc.SelectedValue.ToString());
            obj.Gender = cmbGender.Text;
            obj.DateOfBirth = Convert.ToDateTime(dateTimePicker.Text);
            obj.Ocupation = txtOccupation.Text;
            obj.PhoneNo = txtPhnNumber.Text;
            obj.DepositAmount = Convert.ToDecimal(txtDepositAmount.Text);            
            obj.ImageName = imgLocation;

            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brdr = new BinaryReader(stream);
            images = brdr.ReadBytes((int)stream.Length);
            obj.ImageData = images;

            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Customer(CustomerName, FathersName, Customer.AccountTypeId,Gender, DateOfBirth,Ocupation,PhoneNo,DepositAmount, ImageName, ImageData) VALUES" +
                    " ('" + obj.CustomerName + "', '" + obj.FathersName + "','" + obj.AccountTypeId + "','" + obj.Gender + "','" + obj.DateOfBirth + "','" + obj.Ocupation + "','" + obj.PhoneNo + "','" + obj.DepositAmount + "','" + obj.ImageName + "',@img)";
                cmd.Parameters.Add(new SqlParameter("@img", obj.ImageData));
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("Data Insert Successfully");
                }
            }
            ClearAll();
            LoaddgvCustomerInfo();
        }

        private void dgvCustomerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cellId = e.RowIndex;
            DataGridViewRow row = dgvCustomerInfo.Rows[cellId];
           
            try
            {
                accId = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                accId = 0;
            }
            try
            {
                accTyId = Convert.ToInt32(row.Cells[3].Value.ToString());
            }
            catch (Exception)
            {

                accTyId = 0;
            }
            txtCName.Text = row.Cells[1].Value.ToString();
            txtFName.Text = row.Cells[2].Value.ToString();
            txtAccountTypeId.Text = row.Cells[3].Value.ToString();
            cmbGender.Text = row.Cells[4].Value.ToString();
            txtAccountType.Text = row.Cells[5].Value.ToString();
            cmbTypeOfAcc.SelectedValue = accTyId;
            dateTimePicker.Text = row.Cells[6].Value.ToString();
            txtOccupation.Text = row.Cells[7].Value.ToString();
            txtPhnNumber.Text = row.Cells[8].Value.ToString();
            txtDepositAmount.Text = row.Cells[9].Value.ToString();
            byte[] data = (byte[])row.Cells[11].Value;
            MemoryStream stream = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(stream);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(constr))
            {
                int count = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Customer WHERE AccountNo='" + accId + "'";
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Data deleted Successfully");
                }
            }
            ClearAll();
            LoaddgvCustomerInfo();
        }

        private void btnSave_Acc_Click(object sender, EventArgs e)
        {
            int count;
            AccountType = txtAccountType.Text;

            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO AccountType_tbl(AccountType) VALUES" + " ('" + AccountType + "')";
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("Data Insert Successfully");
                }
            }
            ClearAll();
            LoaddgvCustomerInfo();
        }

        private void btnTypeDelete_Click(object sender, EventArgs e)
        {
            int count;

            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from AccountType_tbl WHERE AccountTypeId='" + accTyId + "'";                
                con.Open();
                count = cmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("Data Delete Successfully");
                }
            }
            ClearAll();
            LoaddgvCustomerInfo();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            List<ViewReport> list = new List<ViewReport>();
            using (var con = new SqlConnection(constr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT AccountNo, CustomerName, AccountType, Gender, DateOfBirth, DepositAmount FROM Customer join AccountType_tbl on Customer.AccountTypeId=AccountType_tbl.AccountTypeId";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr, LoadOption.Upsert);

                ViewReport obj;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj = new ViewReport();
                    obj.AccountNo = Convert.ToInt32(dt.Rows[i]["AccountNo"].ToString());
                    obj.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                    obj.AccountType = dt.Rows[i]["AccountType"].ToString();
                    obj.Gender = dt.Rows[i]["Gender"].ToString();
                    obj.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"].ToString());
                    obj.DepositAmount = Convert.ToDecimal(dt.Rows[i]["DepositAmount"].ToString());
                    list.Add(obj);
                }

            }

            using (Report frm = new Report(list))
            {
                frm.ShowDialog();
            }
            LoaddgvCustomerInfo();
        }
    }
}
