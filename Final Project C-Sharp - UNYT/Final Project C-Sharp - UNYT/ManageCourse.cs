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
    public partial class ManageCourse : Form
    {
        CourseClass course = new CourseClass(); // I have called the course class
        public ManageCourse()
        {
            InitializeComponent();
        }

        private void ManageCourse_Load(object sender, EventArgs e)
        {
            showData();

        }
        // Show data of the course 
        private void showData()
        {
            DataGridView_course.ReadOnly = true;
            //to show course list on datagridview
            DataGridView_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
        }
        //Display course data from course to textbox
        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            // the application display all course information in DataGridView
            //information- course ID, course name, course hour, course descrption
            textBox_id.Text = DataGridView_course.CurrentRow.Cells[0].Value.ToString();
            textBox_Cname.Text = DataGridView_course.CurrentRow.Cells[1].Value.ToString();
            textBox_Chour.Text = DataGridView_course.CurrentRow.Cells[2].Value.ToString();
            textBox_description.Text = DataGridView_course.CurrentRow.Cells[3].Value.ToString();
        }
        // delete the above fields (course name, course hour, course description)
        private void button_clear_Click_1(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_Cname.Clear();
            textBox_Chour.Clear();
            textBox_description.Clear();
            textBox_search.Clear();
        }

        private void button_Update_Click_1(object sender, EventArgs e)
        {
            // this contition check if the course name and course hours and course ID are empty
            if (textBox_Cname.Text == "" || textBox_Chour.Text == "" || textBox_id.Text.Equals(""))
            {
                // the app show an error message if the data are empty
                MessageBox.Show("Need Course data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //this condition check if the data is not empty
            {
                int id = Convert.ToInt32(textBox_id.Text);
                string cName = textBox_Cname.Text;
                int chr = Convert.ToInt32(textBox_Chour.Text);
                string desc = textBox_description.Text;

                //this condition enters the data (ID, name, hours, description)
                if (course.updateCourse(id, cName, chr, desc))
                {
                    showData(); //show course list on datagridview 
                    button_clear.PerformClick();//The application automatically deletes the previously entered data
                    //show a message that a new course has been inserted
                    MessageBox.Show("course update successfuly", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {   //shows an error message if the data are not edited
                    MessageBox.Show("Error-Course not Edit", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //deletes the course from the ID
        private void button_delete_Click_1(object sender, EventArgs e)
        {
            if (textBox_id.Text.Equals(""))
            { // the condition checks if the Id field is empty and shows an error message, if is empty 
                MessageBox.Show("Need Course Id", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //if it is not empty
            {
                try
                {
                    int id = Convert.ToInt32(textBox_id.Text); // input ID
                    if (course.deletCourse(id)) // if ID is deleted the application shows a confiramtion message 
                    {
                        showData();  //show course list on datagridview 
                        button_clear.PerformClick(); //The application automatically deletes the previously entered data
                    //show a message that a new course has been deleted
                        MessageBox.Show("course Deleted", "Removed Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)

                {   //shows an error message
                    MessageBox.Show(ex.Message, "Removed Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_search_Click_1(object sender, EventArgs e)
        {
           //To Search course and show on datagridview
            DataGridView_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }
    }
}
