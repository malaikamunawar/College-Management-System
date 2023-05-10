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
    public partial class feestatus : Form
    {
        public feestatus()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void regcombo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select RegNo from Student ";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                regc.Items.Add(ROW["RegNo"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }
        }
        private void view_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");


            SqlCommand cmd = new SqlCommand("select Student.RegNo , Student.StudentName , StudentFee.VoucherDate,  StudentFee.FeeStatus from Student join StudentFee on student.StudentId = StudentFee.StudentId where student.studentid = '" +studentid + "'  and VoucherDate = '" + theDate + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }

        private void regc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Seccombo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select SectionName from Section   ";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                section.Items.Add(ROW["SectionName"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }

        }
        public void classcombo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ClassName from Class ";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                classname.Items.Add(ROW["ClassName"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }

        }
        private void feestatus_Load(object sender, EventArgs e)
        {
            regcombo();
            Seccombo();
            classcombo();

        }

        public void show()
        {
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd1 = new SqlCommand("select Student.RegNo , Student.StudentName , StudentFee.VoucherDate,  StudentFee.FeeStatus from Student join StudentFee on student.StudentId = StudentFee.StudentId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd1.ExecuteNonQuery();
           // MessageBox.Show("Successfully Loaded");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection(); String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");


            SqlCommand cmd = new SqlCommand("delete from StudentFee where StudentID= '" + studentid.ToString() + "' and Voucherdate = '" +theDate + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
            show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
            //MessageBox.Show(studentid.ToString());

            SqlCommand cmd = new SqlCommand("UPDATE StudentFee set FeeStatus=@FeeStatus where StudentID= '" + studentid.ToString() + "'", con);

            cmd.Parameters.AddWithValue("@FeeStatus", status.Text);

            cmd.ExecuteNonQuery();
 
            MessageBox.Show("Successfully Updated");
            show();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (section.SelectedItem != null && classname.SelectedItem != null)
            {

                var con = Configuration.getInstance().getConnection();

            String secvalue = section.Text;
            //int SecID = new int();
            SqlCommand cmd2 = new SqlCommand("Select SectionId from Section where SectionName='" + secvalue + "'", con);
            int sectionid = (int)cmd2.ExecuteScalar();

            String classvalue = classname.Text;
            SqlCommand cmd = new SqlCommand("Select classid from class where classname='" + classvalue + "'", con);
            int classid = (int)cmd.ExecuteScalar();

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");


            
                SqlCommand cmd1 = new SqlCommand("select Student.RegNo , Student.StudentName , StudentFee.VoucherDate,  StudentFee.FeeStatus from Student join StudentFee on student.StudentId = StudentFee.StudentId where student.classid = '" + classid.ToString() + "' and student.sectionid= '" +sectionid.ToString()+ "' and VoucherDate = '"+theDate+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Loaded");
            }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }




        }

        private void button13_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
            // MessageBox.Show(studentid.ToString());

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            SqlCommand cmd = new SqlCommand("Insert into StudentFee values (@StudentId ,@FeeStatus,@VoucherDate)", con);
            cmd.Parameters.AddWithValue("StudentId", studentid.ToString());
            cmd.Parameters.AddWithValue("@FeeStatus", status.Text);
            cmd.Parameters.AddWithValue("@VoucherDate", theDate);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                regc.Text = row.Cells[0].Value.ToString();
                status.Text = row.Cells[3].Value.ToString();

            }
        }
    }
}
