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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageTeacher mt = new ManageTeacher();
            mt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Salary1cs s = new Salary1cs();
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignCourse ac = new AssignCourse()
                ;
            ac.Show();
        }
    }
}