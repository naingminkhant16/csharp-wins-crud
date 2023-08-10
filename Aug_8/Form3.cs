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

namespace Aug_8
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String gender=rdbMale.Checked?"Male":"Female";
            String query = $"insert into ClassA(Id,Name,DOB,Gender,Phone,City)" +
                $" values ('{ txtId.Text}','{ txtName.Text}','{ dtpDOB.Value}','{ gender}','{ txtPh.Text}','{ cbCity.Text}')";
         
            /* string query = "insert into ClassA(Id,Name,DOB,Gender,Phone,City) values ('"
                + txtId.Text + "','" + txtName.Text + "','" + dtpDOB.Value + "','"
                + gender + "','" + txtPh.Text + "','" + cbCity.Text + "')";*/
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Product.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =query; 
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Successfully");
            Clear();
        }
        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPh.Text = "";
            dtpDOB.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            cbCity.SelectedIndex = 0;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();
        }
    }
}
