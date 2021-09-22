using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project_C_Sharp___UNYT
{
    public partial class CourseForm : Form
    {
        CourseClass course = new CourseClass(); // I have called the course class
        public CourseForm()
        {
            InitializeComponent();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            DataGridView_course.ReadOnly = true;
            //to show course list on datagridview
            DataGridView_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            // this contition check if the course name and course hours are empty
            if (textBox_Cname.Text == "" || textBox_Chour.Text == "")
            { 
                //the app show an error message if the data are empty
                MessageBox.Show("Need Course data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //this condition check if the data is not empty
            {

                string cName = textBox_Cname.Text;
                int chr = Convert.ToInt32(textBox_Chour.Text);
                string desc = textBox_description.Text;

                //this condition enters the data (name, hours, description)
                if (course.insetCourse(cName, chr, desc))
                {
                    showData();
                    button_clear.PerformClick();//The application automatically deletes the previously entered data
                    //show a message that a new course has been inserted
                    MessageBox.Show("New course inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {   //shows an error message
                    MessageBox.Show("Course not insert", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // delete the above fields (course name, course hour, course description)
        private void button_clear_Click_1(object sender, EventArgs e)
        {
            textBox_Cname.Clear();
            textBox_Chour.Clear();
            textBox_description.Clear();
        }
    }
}
