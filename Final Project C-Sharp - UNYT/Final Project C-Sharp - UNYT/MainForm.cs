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
    public partial class MainForm : Form
    {
       // I have called the student class and the course class
        StudentClass student = new StudentClass();
        CourseClass course = new CourseClass();

        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            studentCount();
            // populate the combobox with courses name which the application get from the database.
            comboBox_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_course.DisplayMember = "CourseName";
            comboBox_course.ValueMember = "CourseName";
        }

        //create a function to display student count
        private void studentCount()
        {
            //Display the values
            label_totalStd.Text = "Total Students : " + student.totalStudent();
            label_maleStd.Text = "Male : " + student.maleStudent();
            label_femaleStd.Text = "Female : " + student.femaleStudent();

        }

        private void customizeDesign()
        {
            //makes student, course and score button options,invisible
            panel_stdsubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;

        }

        //hide submenu
        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;
            if (panel_courseSubmenu.Visible == true)
                panel_courseSubmenu.Visible = false;
            if (panel_scoreSubmenu.Visible == true)
                panel_scoreSubmenu.Visible = false;
        }
        //show submenu
        private void showSubmenu(Panel submenu)
        {    // if the submenu is invisible the application will execute the following code
            if (submenu.Visible == false)
            {
                //which makes the submenu visible and invisible when the user clicks
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        // when we press the student button the program shows the submenu related to the student's actions
        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }

        //#region and #endregion, organizes the code into blocks that can be expanded or collapsed visually.
        #region StdSubmenu
        private void button_registration_Click(object sender, EventArgs e)// Open the RegistrationForm
        {
            openChildForm(new RegistrationForm());

            hideSubmenu();  // and hide submenu
        }

        private void button_manageStd_Click(object sender, EventArgs e)// Open the ManageStudent Form
        {
            openChildForm(new ManageStudent());
            hideSubmenu(); // and hide submenu
        }

        private void button_stdPrint_Click(object sender, EventArgs e)// Open the Print Form
        {
            openChildForm(new Print());
            hideSubmenu(); // and hide submenu
        }
        #endregion StdSubmenu 


        // when we press the course button the program shows the submenu related to the course's actions
        private void button_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);
        }

        //#region and #endregion, organizes the code into blocks that can be expanded or collapsed visually.
        #region CourseSubmenu
        private void button_newCourse_Click(object sender, EventArgs e)// Open the CourseForm
        {
            openChildForm(new CourseForm());
            hideSubmenu();  // and hide submenu
        }

        private void button_manageCourse_Click(object sender, EventArgs e)// Open the ManageCourse Form
        {
            openChildForm(new ManageCourse());
            hideSubmenu();  // and hide submenu
        }

        private void button_coursePrint_Click(object sender, EventArgs e)// Open the PrintCourse Form
        {
            openChildForm(new PrintCourse());
            hideSubmenu(); // and hide submenu
        }
        #endregion CourseSubmenu

        // when we press the score button the program shows the submenu related to the score's actions
        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoreSubmenu);
        }

        //#region and #endregion, organizes the code into blocks that can be expanded or collapsed visually.

        #region ScoreSubmenu
        private void button_newScore_Click(object sender, EventArgs e)// Open the Score Form
        {
            openChildForm(new Score());
            hideSubmenu();  // and hide submenu
        }

        private void button_manageScore_Click(object sender, EventArgs e)// Open the MenageScore Form
        {
            openChildForm(new MenageScore());
            hideSubmenu();  // and hide submenu
        }

        private void button_scorePrint_Click(object sender, EventArgs e)// Open the PrintScore Form
        {
            openChildForm(new PrintScore());
            hideSubmenu();  // and hide submenu
        }
        #endregion ScoreSubmenu

        //to show register form in mainform which means it can open a form within a form
        //I have create a child form 
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false; //set its TopLevel to false
            childForm.FormBorderStyle = FormBorderStyle.None;

            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);//Adds the child form as a control.
            panel_main.Tag = childForm;
            childForm.BringToFront(); // I used this to give the newly created form over controls
            childForm.Show(); //finally display it
        }

        //Returns the application to the login
        private void button_exit_Click_2(object sender, EventArgs e)
        { 
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        //Returns the application to the main menu (dashboard)
        private void button_dashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
            studentCount();
        }

        //Enumerates female or male students in enrolled classes
        private void comboBox_course_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label_cmale.Text = "Male : " + student.exeCount("SELECT COUNT(*) FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE score.CourseName = '" + comboBox_course.Text + "' AND student.Gender = 'Male'");
            label_cfemale.Text = "Female : " + student.exeCount("SELECT COUNT(*) FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE score.CourseName = '" + comboBox_course.Text + "' AND student.Gender = 'Female'");
        }
    }
}