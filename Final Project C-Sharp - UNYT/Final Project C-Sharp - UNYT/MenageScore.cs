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
    public partial class MenageScore : Form
    {
        CourseClass course = new CourseClass();
        ScoreClass score = new ScoreClass();
        public MenageScore()
        {
            InitializeComponent();
        }
        private void ManageScore_Load(object sender, EventArgs e)
        {
            //populate the combobox with courses name
            comboBox_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_course.DisplayMember = "CourseName";
            comboBox_course.ValueMember = "CourseName";
            // to show score data on datagridview
            showScore();
        }

        //create a function to show data on datagridview score
        public void showScore()
        {
            DataGridView_score.ReadOnly = true;
            // the data is taken from the database
            DataGridView_score.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId,student.StdFirstName,student.StdLastName,score.CourseName,score.Grade,score.LetterGrade FROM student INNER JOIN score ON score.StudentId=student.StdId"));
        }

        //Display student data from course to textbox
        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            // the application display all curse information in DataGridView
            //information- student ID, course, grade, letter grade
            textBox_stdId.Text = DataGridView_score.CurrentRow.Cells[0].Value.ToString();
            comboBox_course.Text = DataGridView_score.CurrentRow.Cells[3].Value.ToString();
            textBox_Grade.Text = DataGridView_score.CurrentRow.Cells[4].Value.ToString();
            textBox_LetterGrade.Text = DataGridView_score.CurrentRow.Cells[5].Value.ToString();
        }

        //this button checks for the student, with the course name, student name, and surname
        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_score.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId, student.StdFirstName, student.StdLastName, score.CourseName, score.Grade, score.LetterGrade FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE CONCAT(student.StdFirstName, student.StdLastName, score.CourseName)LIKE '%" + textBox_search.Text + "%'"));

        }
        // delete the above fields (student ID, grade, course, Letter Grade, search button)
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_Grade.Clear();
            textBox_LetterGrade.Clear();
            textBox_search.Clear();
        }

        private void button_Update_Click_1(object sender, EventArgs e)
        {
            // this contition check if the student ID and course Grade are empty
            if (textBox_stdId.Text == "" || textBox_Grade.Text == "")
            {
                // the app show an error message if the data are empty
                MessageBox.Show("Need grade data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //this condition check if the data is not empty
            {
                int stdId = Convert.ToInt32(textBox_stdId.Text);
                string cName = comboBox_course.Text;
                double grade = Convert.ToInt32(textBox_Grade.Text);
                string LeGrade = textBox_LetterGrade.Text;

                //this condition enters the data (ID, Name, Grade, Letter Grade)
                if (score.updateScore(stdId, cName, grade, LeGrade))
                {
                    showScore();  //show score list on datagridview 
                    button_clear.PerformClick(); //The application automatically deletes the previously entered data
                    //show a message that a new course has been edited
                    MessageBox.Show("Grade Edited Complete", "Update Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //shows an error message if the data are not edited
                    MessageBox.Show("Grade not edit", "Update Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //deletes the score from the ID
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_stdId.Text == "")
            { // the condition checks if the Id field is empty and shows an error message, if is empty 
                MessageBox.Show("Field Error- we need student id", "Delete Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //if it is not empty
            {
                int id = Convert.ToInt32(textBox_stdId.Text); // input ID
                //the application displays a warning message if the user wants to delete the data
                if (MessageBox.Show("Are you sure you want to remove this grade", "Delete Grade", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (score.deleteScore(id)) // if the id is deleted 
                    {
                        showScore(); //show score list on datagridview 
                        //show a message that a new course has been deleted
                        MessageBox.Show("Grade Removed", "Delete Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_clear.PerformClick();//The application automatically deletes the previously entered data
                    }
                }

            }
        }
    }
}
