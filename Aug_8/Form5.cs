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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void Display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Product.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ClassA";
            cmd.ExecuteNonQuery();

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            dgv1.DataSource = dt;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            Display(); 
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgv1.Rows[e.RowIndex];
                txtId.Text = index.Cells[0].Value.ToString();
                txtName.Text = index.Cells[1].Value.ToString();
                dtpDob.Value = DateTime.Parse(index.Cells[2].Value.ToString());
                String gender = index.Cells[3].Value.ToString().Trim();
              
                if (gender.Equals("Male")){
                    rdbMale.Checked=true;         
                }
                else
                {                   
                    rdbFemale.Checked = true;
                }
                txtPhone.Text = index.Cells[4].Value.ToString();
                cbCity.Text = index.Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String gender = "";
            if (rdbMale.Checked) gender = "Male";
            else gender = "Female";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Product.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"update ClassA set Id='{txtId.Text}',Name='{txtName.Text}'" +
                $",DOB='{dtpDob.Value}',Gender='{gender}',Phone='{txtPhone.Text}',City='{cbCity.Text}' where Id='{txtId.Text}'";
           
            cmd.ExecuteNonQuery();
            con.Close();
            
            MessageBox.Show("Updated Success");
            Display();
            Clear();

        }

        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            dtpDob.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            cbCity.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();
        }
    }
}
