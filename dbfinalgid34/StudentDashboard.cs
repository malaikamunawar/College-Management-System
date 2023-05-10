using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbfinalgid34
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            managestudent sm = new managestudent();
            sm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Category c = new Category();
            //c.Show();
            collegeresult cr = new collegeresult();
            cr.Show();
                }

        private void button3_Click(object sender, EventArgs e)
        {
            studentattendance sa = new studentattendance();
            sa.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            managestudent sm = new managestudent();
            sm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            studentattendance sat = new studentattendance();
            sat.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            collegeresult cr = new collegeresult();
            cr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            feestatus fs = new feestatus();
            fs.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fee f = new fee();
            f.Show()
;        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
