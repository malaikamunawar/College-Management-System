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
//using System.IO.FileStream;
using System.Windows.Forms;

namespace dbfinalgid34
{
    public partial class managestudent : Form
    {
        public managestudent()
        {
            InitializeComponent();
        }

        private void Contact_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void Category_Load(object sender, EventArgs e)
        {
            
           // Seccombo();
           // Discombo();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select StudentName,Gender,RegNo,Email,Age,DateOfBirth,FatherName,CNIC from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentattendance sa = new studentattendance();
            sa.Show();
        }
       
       
       /* public void Discombo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DisciplineName from Discipline ";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                dis.Items.Add(ROW["DisciplineName"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }

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

        }*/
        private void Reg_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //real
          //  for name
           if (name.Text == " " && !System.Text.RegularExpressions.Regex.IsMatch(name.Text, "^[a-zA-Z]") )
            {
                MessageBox.Show("Name's textbox accepts only alphabetical characters");
                name.Text.Remove(name.Text.Length - 1);
            }
            
          //  for father
            if
          ( fname.Text == " " && !System.Text.RegularExpressions.Regex.IsMatch(fname.Text, "^[a-zA-Z]") )
            {
                MessageBox.Show("Father Name's textbox accepts only alphabetical characters");
                fname.Text.Remove(fname.Text.Length - 1);
            }
           // for reg No.
            if ( fname.Text == " " && !System.Text.RegularExpressions.Regex.IsMatch(fname.Text, "^[a-zA-Z]") && !System.Text.RegularExpressions.Regex.IsMatch(fname.Text, "^[a-zA-Z]") )
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                fname.Text.Remove(fname.Text.Length - 1);
            }
         //    for contact
            if (
                    !contact.Text.All(char.IsDigit) && contact.MaxLength == 11 )
           {
                MessageBox.Show("Contact No can contain only numeric values");
            }


          //  email validation
            if (
                    !this.email.Text.Contains('@') || !this.email.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email");
               // (MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

            else
            {
                try
                {
                     int classNo = 0;
                    int session = 0;
                    String Gender;
                    int discip = 0;
                    int section = 0;
                    var con = Configuration.getInstance().getConnection();

                    string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    SqlCommand cm = new SqlCommand("Insert into Student values (@StudentId,@StudentName,@Gender,@RegNo,@Email,@ContactNo,@Age,@DateOfBirth,@sessionID,@sectionID,@DiscID,@ClassID,@FatherName,@CNIC)", con);                        
                     cm.Parameters.AddWithValue("@StudentId" , int.Parse(ID.Text));
                    cm.Parameters.AddWithValue("@studentName", name.Text);
                    if (gen.Text == "male")
                    {
                        Gender = "Male";
                    }
                    else
                    {
                        Gender = "Female";
                    }
                    cm.Parameters.AddWithValue("@Gender", Gender);
                    cm.Parameters.AddWithValue("@RegNo", regc.Text);
                    cm.Parameters.AddWithValue("@email", email.Text);                    
                    cm.Parameters.AddWithValue("@ContactNo", contact.Text);
                    cm.Parameters.AddWithValue("@Age", int.Parse(Age.Text));
                    cm.Parameters.AddWithValue("@DateOfBirth", theDate);
                    if (comboBox1.Text == "2018")
                    {
                        session = 1;
                    }
                    else if (comboBox1.Text == "2019")
                    {
                        session = 2;
                    }
                    else if (comboBox1.Text == "2020")
                    {
                        session = 3;
                    }
                    cm.Parameters.AddWithValue("@SessionID", session);
                    if (this.section.Text == "A")
                    {
                        section = 1;
                    }
                    else if (this.section.Text == "B")
                    {
                        section = 2;
                    }
                    cm.Parameters.AddWithValue("@SectionID", section);
                  
                    if (this.dis.Text == "Pre-Medical")
                    {
                        discip = 1;
                    }
                    else if (this.dis.Text == "Pre-Engineering")
                    {
                        discip = 2;
                    }
                    else if (this.dis.Text == "ICS")
                    {
                        discip = 3;
                    }
                    else if (this.dis.Text == "Commerce")
                    {
                       discip = 5;
                    }
                    else if (this.dis.Text == "Art")
                    {
                       discip = 4;
                    }
                    cm.Parameters.AddWithValue("@DiscID", discip);
                    if (this.classname.Text == "11")
                    {
                        classNo = 1;
                    }
                    else if (this.classname.Text == "12")
                    {
                        classNo = 2;
                    }
                    cm.Parameters.AddWithValue("@ClassID", classNo);
                    cm.Parameters.AddWithValue("@FatherName", fname.Text);
                    cm.Parameters.AddWithValue("@CNIC", cnic.Text);
                   // cm.Parameters.AddWithValue("@ClassID", classid); 
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {



        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
               // int classNo = 0;
                int Gender;
                int disc = 0;
                int section = 0;
                var con = Configuration.getInstance().getConnection();
                SqlCommand cm = new SqlCommand("Update  Student set StudentName=@StudentName,Email=@Email,ContactNo=@ContactNo,Age=@Age,DateOfBirth=@DateOfBirth,sectionID=@sectionID,discID=@discID,Gender=@Gender,FatherName=@FatherName,CNIC=@CNIC where RegNo=@RegNo", con);
                cm.Parameters.AddWithValue("@studentName", name.Text);
                cm.Parameters.AddWithValue("@RegNo", regc.Text);
                cm.Parameters.AddWithValue("@email", email.Text);
                cm.Parameters.AddWithValue("@ContactNo", int.Parse(contact.Text));
                cm.Parameters.AddWithValue("@age", int.Parse(Age.Text));
                cm.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value.Date);
                if (this.section.Text == "A")
                {
                    section = 1;
                }
                else if (this.section.Text == " B")
                {
                    section = 2;
                }
                else if (this.section.Text == " C")
                {
                    section = 3;
                }
                cm.Parameters.AddWithValue("@SectionId", section);
                if (this.dis.Text == "Pre-Medical")
                {
                    disc = 1;
                }
                else if (this.dis.Text == "Pre-Engineering")
                {
                    disc = 2;
                }
                else if (this.dis.Text == "ICS")
                {
                    disc = 3;
                }
                else if (this.dis.Text == "Commerce")
                {
                    disc = 4;
                }
                else if (this.dis.Text == "Art")
                {
                    disc = 5;
                }
                cm.Parameters.AddWithValue("@DiscID", disc);
                if (gen.Text == "Male")
                {
                    Gender = 1;
                }
                else if(gen.Text=="Female")
                {
                    Gender = 2;
                }
                else
                {
                    Gender = 1;
                }
                cm.Parameters.AddWithValue("@Gender", Gender);
                cm.Parameters.AddWithValue("@FatherName", fname.Text);
                cm.Parameters.AddWithValue("@CNIC", cnic.Text);

                /* if (comboBox1.Text == "Inter Part-I")
                 {
                     classNo = 1;
                 }
                 else if (comboBox1.Text == "Inter Part-II")
                 {
                     classNo = 2;
                 }
                 cm.Parameters.AddWithValue("@ClassID", classNo);*/
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
               // int classNo = 0;
                int Gender;
                int disc = 0;
                int section = 0;
                var con = Configuration.getInstance().getConnection();
            SqlCommand cm = new SqlCommand("Delete  Student where RegNo=@regNo", con);
            cm.Parameters.AddWithValue("@studentName", name.Text);
            cm.Parameters.AddWithValue("@FatherName", fname.Text);
            cm.Parameters.AddWithValue("@RegNo", regc.Text);
            cm.Parameters.AddWithValue("@Contact", int.Parse(contact.Text));
            cm.Parameters.AddWithValue("@email", email.Text);
            cm.Parameters.AddWithValue("@age", int.Parse(Age.Text));
            cm.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value.Date);
            /* if (comboBox1.Text == "Inter Part-I")
             {
                 classNo = 1;
             }
             else if (comboBox1.Text == "Inter Part-II")
             {
                 classNo = 2;
             }
             cm.Parameters.AddWithValue("@ClassID", classNo);*/
            if (this.section.Text == "A")
            {
                section = 1;
            }
            else if (this.section.Text == " B")
            {
                section = 2;
            }
            cm.Parameters.AddWithValue("@sectionId", section);
            if (gen.Text == "male")
            {
                Gender = 1;
            }
            else
            {
                Gender = 2;
            }
            cm.Parameters.AddWithValue("@Gender", Gender);
            if (this.dis.Text == "Pre-Medical")
            {
                disc = 1;
            }
            else if (this.dis.Text == "Pre-Engineering")
            {
                disc = 2;
            }
            else if (this.dis.Text == "ICS")
            {
                disc = 3;
            }
            else if (this.dis.Text == "Commerce")
            {
                disc = 4;
            }
            else if (this.dis.Text == "Art")
            {
                disc = 5;
            }
            cm.Parameters.AddWithValue("@DiscID", disc);
            cm.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                regc.Text = row.Cells[0].Value.ToString();

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            String ConnectionString = @"Data Source=DESKTOP-33ICO7R;Initial Catalog=College;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "Select * from Student";
            String search = richTextBox1.Text;

            if (comboBox2.SelectedIndex == 0)
            {
                query += "where StudentName like '%" + search + "or RegNo like '%" + search + "or Email like '%";
                if (int.TryParse(search, out _))
                {
                    query += "OR StudentId" + search;
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                query += "where StudentId" + search;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                query += "where StudentName like '%" + search;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                query += "where RegNo like '%" + search;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                query += "where email like '%" + search;
            }
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["StudentId"], reader["StudentName"], reader["RegNo"], reader["Email"], reader["ContactNo"], reader["Age"], reader["DateOfBirth"], reader["SessionID"], reader["SectionID"], reader["DiscID"], reader["ClassID"]);
            }
            con.Close();
        }

        private void classname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
