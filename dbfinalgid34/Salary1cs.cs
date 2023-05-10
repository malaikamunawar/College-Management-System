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

namespace dbfinalgid34
{
    public partial class Salary1cs : Form
    {
        public Salary1cs()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select StaffName,DesignationID,Amount,Status,DateOfGrant from StaffSalary", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void Salary1cs_Load(object sender, EventArgs e)
        {


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // int classNo = 0;
                int status=0;
                //int desig = 0;
                //int amount = 0;
                var con = Configuration.getInstance().getConnection();
                SqlCommand cm = new SqlCommand("Insert into StaffSalary values (@StaffID,@StaffName,@DesignationID,@Amount,@Status,@DateOfGrant)", con);
                 cm.Parameters.AddWithValue("@StaffID", int.Parse(ID.Text));
                cm.Parameters.AddWithValue("@StaffName", name.Text);
                //if (comboBox1.Text == "Professor")
                //{
                //    desig = 1;
                //}
                //else if (comboBox3.Text == " Coordinator")
                //{
                //    desig = 2;
                //}
                //else if (comboBox3.Text == " Student Advisor")
                //{
                //    desig = 3;
                //}
                cm.Parameters.AddWithValue("@DesignationID", "Teacher");
                //if (comboBox1.Text == "65,000")
                //{
                //    amount = 65000;
                //}
                //else if (comboBox1.Text == "50,000 ")
                //{
                //    amount = 50000;
                //}
                //else if (comboBox1.Text == " 25,000")
                //{
                //    amount = 25000;
                //}
                //else if (comboBox1.Text == " 15,000")
                //{
                //    amount = 15000;
                //}
                cm.Parameters.AddWithValue("@Amount", 50000.ToString());
                if (this.status.Text == "Paid")
                {
                    status = 1;
                }
                else if (this.status.Text == "Unpaid")
                {
                    status = 0;
                }
                cm.Parameters.AddWithValue("@Status", status);
                cm.Parameters.AddWithValue("@DateOfGrant", dateTimePicker1.Value.Date);
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE StaffSalary set Status=@Status where StaffID= '" + ID.Text + "'", con);
            cmd.Parameters.AddWithValue("Status", status);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection(); 
           

            SqlCommand cmd = new SqlCommand("delete from StaffSalary where StaffId= '" + ID.Text + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }
    }
}
