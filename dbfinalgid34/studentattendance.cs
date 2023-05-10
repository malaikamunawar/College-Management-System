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
    public partial class studentattendance : Form
    {
        public studentattendance()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentattendance sa = new studentattendance();
            sa.Show();
        }
        //public void Discombo()
        //    {
        //        SqlConnection con = Configuration.getInstance().getConnection();
        //        SqlCommand cmd = con.CreateCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select DisciplineName from Discipline ";
        //        //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
        //        cmd.ExecuteNonQuery();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        foreach (DataRow ROW in dt.Rows)
        //        {
        //            dis.Items.Add(ROW["DisciplineName"]).ToString();
        //            //Reg.Text=ROW["Id"].ToString();
        //        }

        //    }
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

        public void coursecombo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select CourseTitle from Course ";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                course.Items.Add(ROW["CourseTitle"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }
        }
        //var con = Configuration.getInstance().getConnection();
        //SqlDataReader dr;
        ////SqlCommand cmd = con.CreateCommand();
        ////cmd.CommandType = CommandType.Text;
        ////cmd.CommandText = "select DisciplineName from Discipline ";
        //SqlCommand cmd = new SqlCommand("select DisciplineName from Discipline ", con);
        //cmd.ExecuteNonQuery();
        //DataTable dt = new DataTable();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(dt);
        //dr = null;
        ////SqlCommand cmd = new SqlCommand("select DisciplineName from Discipline ", con);

        //while (dr.Read())
        //{
        //    dis.Text = dr["DisciplineName"].ToString();
        //}

        //foreach (DataRow ROW in dt.Rows)
        //{
        //    dis.Text = ROW["DisciplineName"].ToString();
        //}


        private void button7_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            String coursevalue = course.Text;
            SqlCommand cmd1 = new SqlCommand("Select CourseID from Course where CourseTitle='" + coursevalue + "'", con);
            int courseid = (int)cmd1.ExecuteScalar();

            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
           // MessageBox.Show(studentid.ToString());

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            SqlCommand cmd = new SqlCommand("Insert into StudentAttendance values (@StuId ,@CourseId,@Date , @Status)", con);
            cmd.Parameters.AddWithValue("StuId", studentid.ToString());
            cmd.Parameters.AddWithValue("@CourseId", courseid.ToString());
            cmd.Parameters.AddWithValue("@Date", theDate);
            cmd.Parameters.AddWithValue("@Status", status.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            show();
            //var con = Configuration.getInstance().getConnection();
            //String disvalue = dis.Text;
            //MessageBox.Show(disvalue);
            //SqlCommand cmd = new SqlCommand("Select DisciplineID from Discipline where DisciplineName = '" + dis.Text + "'", con);
            //int disciplineid = (int)cmd.ExecuteScalar();
            //MessageBox.Show(disciplineid.ToString());
            //if (section.Text != null && classname.Text != null && dis.Text != null)
            //{
            //    //var con = Configuration.getInstance().getConnection();

            //    SqlCommand cmd = new SqlCommand("select Student.StudentName, Student.RegNo ,  StudentAttendance.Status, StudentAttendance.Date , StudentAttendance.CourseID from Student join StudentAttendance on Student.StudentId = StudentAttendance.StuID where Student.SectionID= '" + SecID.ToString() + "' and Student.DisciplineID = '" + DisID.ToString() + "' and StudentAttendance.Date = '" + theDate + '"', con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    dataGridView1.DataSource = dt;

            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Successfully searched");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (section.SelectedItem != null && classname.SelectedItem != null && course.SelectedItem != null)
            {
                //int DisID = new int();

                //MessageBox.Show(result.ToString());
                var con = Configuration.getInstance().getConnection();

            
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String secvalue = section.Text;
            //int SecID = new int();
            SqlCommand cmd2 = new SqlCommand("Select SectionId from Section where SectionName='" + secvalue + "'", con);
            int sectionid = (int)cmd2.ExecuteScalar();

            String coursevalue = course.Text;
            SqlCommand cmd3 = new SqlCommand("Select CourseID from Course where CourseTitle='" + coursevalue + "'", con);
            int courseid = (int)cmd3.ExecuteScalar();
            // MessageBox.Show(sectionid.ToString());

            //if (dis.SelectedIndex == 0)
            //{
            //    DisID = 1;
            //}
            //if (dis.SelectedIndex==1)
            //{
            //    DisID = 2;
            //}
            //if (dis.SelectedIndex==2)
            //{
            //    DisID = 3;
            //}
            //if (dis.SelectedIndex==3)
            //{
            //    DisID = 4;
            //}
            //if (dis.SelectedIndex==4)
            //{
            //    DisID = 5;
            //}


            //int SID = new int();
            //if (section.SelectedIndex == 0)
            //{
            //     SID = 1;
            //}
            //else if (section.SelectedIndex==1)
            //{
            //     SID = 2;
            //}
            //else if (section.SelectedIndex==2)
            //{
            //     SID = 3;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Section");
            //}
            // String SecID = SID.ToS
           
                //var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("select Student.StudentName, Student.RegNo ,  StudentAttendance.Status, StudentAttendance.Date , StudentAttendance.CourseID from Student join StudentAttendance on Student.StudentId = StudentAttendance.StuID where Student.SectionID= '" + sectionid.ToString() +"' and StudentAttendance.Date = '" + theDate + "' and StudentAttendance.CourseID = '" + courseid+ "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully searched");
                }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }
        }
        private void show()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Student.RegNo , StudentAttendance.Date ,  Course.CourseTitle,  StudentAttendance.Status from Student join StudentAttendance on student.StudentId = StudentAttendance.StuID join Course on Course.CourseID=StudentAttendance.CourseID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentattendance_Load(object sender, EventArgs e)
        {
            //Discombo();
            Seccombo();
            classcombo();
            regcombo();
            coursecombo();
            
        }

            private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                regc.Text = row.Cells[0].Value.ToString();
         
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection(); String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
            
            SqlCommand cmd = new SqlCommand("delete from StudentAttendance where StuID= '" +  studentid.ToString() + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
            show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
            //MessageBox.Show(studentid.ToString());

            SqlCommand cmd = new SqlCommand("UPDATE StudentAttendance set Status=@Status where StuID= '" + studentid.ToString() + "'", con);
          
            cmd.Parameters.AddWithValue("@Status", status.Text);

            cmd.ExecuteNonQuery();
            show();
            MessageBox.Show("Successfully Updated");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}
