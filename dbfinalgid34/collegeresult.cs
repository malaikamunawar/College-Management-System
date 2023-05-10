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
    public partial class collegeresult : Form
    {
        public collegeresult()
        {
            InitializeComponent();
        }
        public void Seccombo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select SectionName from Section";
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

        //public void Descriptioncombo()
        //{
        //    SqlConnection con = Configuration.getInstance().getConnection();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select Description from CourseEvaluation ";
        //    //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    foreach (DataRow ROW in dt.Rows)
        //    {
        //        desc.Items.Add(ROW["Description"]).ToString();
        //        //Reg.Text=ROW["Id"].ToString();
        //    }
        //}
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void show()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select  Student.RegNo, course.courseTitle, CourseEvaluation.Description , CourseEvaluation.TotalMarks,CourseEvaluation.ObtainedMarks, CourseEvaluation.obtainedPercentage, CourseEvaluation.ExamDate  from Student join CourseEvaluation on student.StudentId = CourseEvaluation.StudentId join Course on Course.CourseID=CourseEvaluation.CourseID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void collegeresult_Load(object sender, EventArgs e)
        {
           
            Seccombo();
            regcombo();
            classcombo();
            coursecombo();
            //Descriptioncombo();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
            //MessageBox.Show(studentid.ToString());

            int total = Int32.Parse(tmarks.Text);
            int obt = Int32.Parse(omarks.Text);
            float product = obt * 100;
            float percentage = product / total;

            SqlCommand cmd = new SqlCommand("UPDATE CourseEvaluation set TotalMarks=@TotalMarks, ObtainedMarks=@ObtainedMarks, obtainedPercentage=@obtainedPercentage where StudentId= '" + studentid.ToString() + "'", con);

            cmd.Parameters.AddWithValue("@ObtainedMarks", Int32.Parse(omarks.Text));
            cmd.Parameters.AddWithValue("@TotalMarks", Int32.Parse(tmarks.Text));
            cmd.Parameters.AddWithValue("@obtainedPercentage", percentage);
            cmd.ExecuteNonQuery();
            show();
            MessageBox.Show("Successfully Updated");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                regc.Text = row.Cells[0].Value.ToString();
                course.Text = row.Cells[1].Value.ToString();
                dest.Text = row.Cells[2].Value.ToString();
                tmarks.Text = row.Cells[3].Value.ToString();
                omarks.Text = row.Cells[4].Value.ToString(); 
           
            }
            var con = Configuration.getInstance().getConnection();
            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();
           // MessageBox.Show("reg");

            SqlCommand cmd3 = new SqlCommand("Select Section.SectionName from Section join Student on Student.SectionId= Section.SectionId where Student.StudentId='" + studentid.ToString() + "'", con);
            String sectionname = (String)cmd3.ExecuteScalar();
            //MessageBox.Show("sec");

            SqlCommand cmd4 = new SqlCommand("Select [Class].ClassName from [Class] join Student on Student.ClassID = [Class].ClassId where Student.StudentId = '" + studentid.ToString() + "'", con);
            int classno = (int)cmd4.ExecuteScalar();
            //MessageBox.Show("cls");
            classname.Text = classno.ToString();
            section.Text = sectionname;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String regvalue = regc.Text;
            SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
            int studentid = (int)cmd2.ExecuteScalar();

            String coursevalue = course.Text;
            SqlCommand cmd1 = new SqlCommand("Select CourseID from Course where CourseTitle='" + coursevalue + "'", con);
            int courseid = (int)cmd1.ExecuteScalar();

            SqlCommand cmd = new SqlCommand("delete from CourseEvaluation where StudentId= '" + studentid.ToString() + "' and CourseId = '" + courseid.ToString() + "' and Description = '" + dest.Text + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
            show();
        }



        private void button12_Click(object sender, EventArgs e)
        {
            if (section.SelectedItem != null && classname.SelectedItem != null && course.SelectedItem != null && dest.Text != null)
            {
                if (regc.SelectedItem == null)
                {
                    //int DisID = new int();

                    //MessageBox.Show(result.ToString());
                    var con = Configuration.getInstance().getConnection();
                    String coursevalue = course.Text;
                    SqlCommand cmd1 = new SqlCommand("Select CourseID from Course where CourseTitle='" + coursevalue + "'", con);
                    int courseid = (int)cmd1.ExecuteScalar();

                    //String regvalue = regc.Text;
                    //SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
                    //int studentid = (int)cmd2.ExecuteScalar();
                    // MessageBox.Show(studentid.ToString());

                    String secvalue = section.Text;
                    SqlCommand cmd3 = new SqlCommand("Select SectionId from Section where SectionName='" + secvalue + "'", con);
                    int sectionid = (int)cmd3.ExecuteScalar();

                    String classvalue = classname.Text;
                    SqlCommand cmd4 = new SqlCommand("Select classID from [Class] where [ClassName]='" + classvalue + "'", con);
                    int classid = (int)cmd4.ExecuteScalar();

                    string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                    SqlCommand cmd5 = new SqlCommand("select  Student.RegNo, Course.CourseTitle, CourseEvaluation.Description , CourseEvaluation.TotalMarks, CourseEvaluation.ObtainedMarks, CourseEvaluation.obtainedPercentage, CourseEvaluation.ExamDate  from Student join CourseEvaluation on student.StudentId = CourseEvaluation.StudentId join Course on Course.CourseID=CourseEvaluation.CourseID where CourseEvaluation.CourseID = '" + courseid.ToString() + "' and CourseEvaluation.Description= '" + dest.Text + "' and Student.SectionId = '" + sectionid.ToString() + "' and Student.ClassID = '" + classid.ToString() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd5);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    cmd5.ExecuteNonQuery();
                    MessageBox.Show("Successfully searched");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    String coursevalue = course.Text;
                    SqlCommand cmd1 = new SqlCommand("Select CourseID from Course where CourseTitle='" + coursevalue + "'", con);
                    int courseid = (int)cmd1.ExecuteScalar();

                    String regvalue = regc.Text;
                    SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
                    int studentid = (int)cmd2.ExecuteScalar();
                    // MessageBox.Show(studentid.ToString());

                    String secvalue = section.Text;
                    SqlCommand cmd3 = new SqlCommand("Select SectionId from Section where SectionName='" + secvalue + "'", con);
                    int sectionid = (int)cmd3.ExecuteScalar();

                    String classvalue = classname.Text;
                    SqlCommand cmd4 = new SqlCommand("Select classID from [Class] where [ClassName]='" + classvalue + "'", con);
                    int classid = (int)cmd4.ExecuteScalar();

                    string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                    SqlCommand cmd5 = new SqlCommand("select  Student.RegNo, Course.CourseTitle, CourseEvaluation.Description , CourseEvaluation.TotalMarks, CourseEvaluation.ObtainedMarks, CourseEvaluation.obtainedPercentage, CourseEvaluation.ExamDate from Student join CourseEvaluation on student.StudentId = CourseEvaluation.StudentId join Course on Course.CourseID = CourseEvaluation.CourseID where Student.RegNo= '" + regc.Text + "' and CourseEvaluation.CourseID = '" + courseid.ToString() + "' and CourseEvaluation.Description= '" + dest.Text + "' and Student.SectionId = '" + sectionid.ToString() + "' and Student.ClassID = '" + classid.ToString() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd5);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    cmd5.ExecuteNonQuery();
                    MessageBox.Show("Successfully searched");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentattendance sa = new studentattendance();
            sa.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (regc.SelectedItem != null && course.SelectedItem != null && classname.SelectedItem != null && section.SelectedItem != null && dest.Text != null && tmarks.Text != null && omarks != null)
            {


                var con = Configuration.getInstance().getConnection();

                String coursevalue = course.Text;
                SqlCommand cmd1 = new SqlCommand("Select CourseID from Course where CourseTitle='" + coursevalue + "'", con);
                int courseid = (int)cmd1.ExecuteScalar();

                String regvalue = regc.Text;
                SqlCommand cmd2 = new SqlCommand("Select StudentId from Student where RegNo='" + regvalue + "'", con);
                int studentid = (int)cmd2.ExecuteScalar();
                // MessageBox.Show(studentid.ToString());

                String secvalue = section.Text;
                SqlCommand cmd3 = new SqlCommand("Select SectionId from Section where SectionName='" + secvalue + "'", con);
                int sectionid = (int)cmd3.ExecuteScalar();

                String classvalue = classname.Text;
                SqlCommand cmd4 = new SqlCommand("Select classID from [Class] where [ClassName]='" + classvalue + "'", con);
                int classid = (int)cmd4.ExecuteScalar();

                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                int total = Int32.Parse(tmarks.Text);
                int obt = Int32.Parse(omarks.Text);
                float product = obt * 100;
                float percentage = product / total;
                //String percentage = (obt / total).ToString("0.00%");
                //MessageBox.Show(percentage.ToString());
                SqlCommand cmd = new SqlCommand("Insert into CourseEvaluation values (@CourseID, @StudentId ,@Description , @TotalMarks , @ObtainedMarks , @obtainedPercentage, @ExamDate)", con);
                cmd.Parameters.AddWithValue("CourseID", courseid.ToString());
                cmd.Parameters.AddWithValue("@StudentId", studentid.ToString());
                cmd.Parameters.AddWithValue("@Description", dest.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", float.Parse(tmarks.Text));
                cmd.Parameters.AddWithValue("@ObtainedMarks", float.Parse(omarks.Text));
                cmd.Parameters.AddWithValue("@obtainedPercentage", percentage);
                cmd.Parameters.AddWithValue("@ExamDate", theDate);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                show();
            }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            feestatus fs = new feestatus();
            fs.Show();
        }
    }
}
