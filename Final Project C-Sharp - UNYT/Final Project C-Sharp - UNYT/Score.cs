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
    public partial class Score : Form
    {
        CourseClass course = new CourseClass(); // I have called the course class
        StudentClass student = new StudentClass(); // I have called the student class
        ScoreClass score = new ScoreClass(); // I have called the score class
        public Score()
        {
            InitializeComponent();
        }

        private void Score_Load(object sender, EventArgs e)
        {
            //populate the combobox with courses name
            comboBox_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_course.DisplayMember = "CourseName";
            comboBox_course.ValueMember = "CourseName";
            // to show data on score datagridview

            //To Display the student list on Datagridview
            DataGridView_student.DataSource = student.getList(new MySqlCommand("SELECT `StdId`,`StdFirstName`,`StdLastName` FROM `student`"));
            DataGridView_student.ReadOnly = true;
        }

        //create a function to show data on datagridview score
        private void showScoe()
        {
            // the data is taken from the database
            DataGridView_student.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFirstName,student.StdLastName,score.CourseName,score.Grade,score.LetterGrade FROM student INNER JOIN score ON score.StudentId=student.StdId"));
        }

        //Display student data from student to textbox
        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            textBox_stdId.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
        }

        //add score
        private void button_add_Click(object sender, EventArgs e)
        { 
            // this contition check if the student Id and student grade are empty
            if (textBox_stdId.Text == "" || textBox_Grade.Text == "")
            {
                //the app show an error message if the data are empty
                MessageBox.Show("Need grade data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int studentId = Convert.ToInt32(textBox_stdId.Text);
                string cName = comboBox_course.Text;
                double Grade = Convert.ToInt32(textBox_Grade.Text);
                string LeGradec = textBox_LetterGrade.Text;

                //this condition checks if the grade has not been previously introduced to this student
                //by checking the student by ID and name
                if (!score.checkScore(studentId, cName))
                {
                    //this condition check if the data is not empty
                    if (score.insertScore(studentId, cName, Grade, LeGradec))
                    {
                        showScoe();
                        button_clear.PerformClick();// The application automatically deletes the previously entered data
                    //show a message that a new course has been inserted
                        MessageBox.Show("New grade added", "Add Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {   //shows an error message
                        MessageBox.Show("Grade not added", "Add Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //if the score exists the program indicates an error message
                {
                    MessageBox.Show("The grade for this course are alerady exists", "Add Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //this button shows in DataGridView the student data (ID, first name, and last name)
        //which are taken from the student database
        private void button_sStudent_Click_1(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = student.getList(new MySqlCommand("SELECT `StdId`,`StdFirstName`,`StdLastName` FROM `student`"));
        }

        //this button displays in the datagridview the student data (ID, first and last name, course name, grade, and grade in letters).
        //which are taken from the score database 
        private void button_sScore_Click_1(object sender, EventArgs e)
        {
            showScoe();
        }

        // delete the above fields (student ID, grade, course, Letter Grade)
        private void button_clear_Click_1(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_Grade.Clear();
            comboBox_course.SelectedIndex = 0;
            textBox_LetterGrade.Clear();
        }
    }
}