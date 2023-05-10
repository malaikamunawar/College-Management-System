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
    public partial class TeacherAttendence : Form
    {
        public TeacherAttendence()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StaffAttendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StaffAttendance values (@StaffID, @Date ,@Status )", con);
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            cmd.Parameters.AddWithValue("StaffID", id.Text);
            cmd.Parameters.AddWithValue("Date", theDate);
            cmd.Parameters.AddWithValue("Status", status.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update  StaffAttendance set StaffID=@StaffID,Date=@Date,Status=@Status", con);
            cmd.Parameters.AddWithValue("@StaffID", id.Text);
            cmd.Parameters.AddWithValue("Date", theDate);
            cmd.Parameters.AddWithValue("Status", status.Text);

        }
    }
}
