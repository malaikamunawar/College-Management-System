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

namespace dbfinalgid34
{
    public partial class ManageTeacher : Form
    {
        public ManageTeacher()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ManageTeacher_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Staff", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string doj = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Staff values (@Id, @name ,@Gender , @Email , @dateOfBirth , @age, @Designation, @DateOfJoining)", con);
            cmd.Parameters.AddWithValue("Id", id.Text);
            cmd.Parameters.AddWithValue("name", name.Text);
            cmd.Parameters.AddWithValue("Gender", gen.Text);
            cmd.Parameters.AddWithValue("Email", email.Text);
            cmd.Parameters.AddWithValue("dateOfBirth", dob );
            cmd.Parameters.AddWithValue("age", age.Text);
            cmd.Parameters.AddWithValue("Designation", "Teacher");
            cmd.Parameters.AddWithValue("DateOfJoining", doj);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");






        }

        private void button11_Click(object sender, EventArgs e)
        {
            string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string doj = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update  Staff set Id=@Id,name=@name,Gender=@Gender,Email=@Email,dateOfBirth=@dateOfBirth,age=@age,Designation=@Designation,Gender=@Gender,DateOfJoining=@DateOfJoining where name=@name", con);
            cmd.Parameters.AddWithValue("@studentName", name.Text);
            cmd.Parameters.AddWithValue("Gender", gen.Text);
            cmd.Parameters.AddWithValue("Email", email.Text);
            cmd.Parameters.AddWithValue("dateOfBirth", dob);
            cmd.Parameters.AddWithValue("age", age.Text);
            cmd.Parameters.AddWithValue("Designation", "Teacher");
            cmd.Parameters.AddWithValue("DateOfJoining", doj);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Staff where id= '" + id.Text  +"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void gen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void age_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
