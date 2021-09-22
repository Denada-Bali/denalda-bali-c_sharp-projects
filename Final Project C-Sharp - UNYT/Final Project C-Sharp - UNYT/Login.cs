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
    public partial class Login : Form
    {
        StudentClass student = new StudentClass();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        { 
            //Sets the transparency of Panel
            MyPanel.BackColor = Color.FromArgb(100, Color.MidnightBlue);
            panel1.BackColor = Color.FromArgb(100, Color.MidnightBlue);
            panel2.BackColor = Color.FromArgb(100, Color.MidnightBlue);
        }
        private void textBox_usrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void MyPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button_login_Click_1(object sender, EventArgs e)
        {
            // this contition check if the username and password are empty
            if (textBox_usrname.Text == "" || textBox_password.Text == "")
            {
                //the app show an error message if the data are empty
                MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  //if the data is not empty 
            {     //the program checks if the account exists 
                
                string uname = textBox_usrname.Text;
                string pass = textBox_password.Text;                //by retrieving the data in the database. 
                DataTable table = student.getList(new MySqlCommand("SELECT * FROM `user` WHERE `username`= '" + uname + "' AND `password`='" + pass + "'"));
                //if the data table has more than 0 rows I will execute the following code
                if (table.Rows.Count > 0)
                {
                    // the application will send us to the MainForm/Dashboard
                    MainForm main = new MainForm();
                    this.Hide();
                    main.Show();

                }
                else
                { // else will print an error message
                    MessageBox.Show("Your username and password are not exists", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // delete the above fields (username / password)
        private void clearLabel_Click(object sender, EventArgs e)
        {
            textBox_usrname.Clear();
            textBox_password.Clear();
        }

        //end program
        private void Exitlabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
