using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Final_Project_C_Sharp___UNYT
{
    class CourseClass
    {
        DBconnect connect = new DBconnect();

        //create a function to insert course to the database
        public bool insetCourse(string cName, int hr, string desc)
        {
            //mysql connection represent an open connection to my database
            //connection string is a string that specifies information about data source           //The VALUES command specifies the values of an INSERT INTO statement.
            MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@cn,@ch,@desc)", connect.getconnection);
            // add dates in my database server
            //@cn,@ch,@desc
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.openConnect();  // open the connection
            //returns the number of rows affected by the query we are executing.
            if (command.ExecuteNonQuery() == 1) 
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        //create a function to get course list
        public DataTable getCourse(MySqlCommand command)
        { //sets some of its properties, retrieves data from a table, and displays it. And open the connection
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //create a update function for course edit
        public bool updateCourse(int id, string cName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET`CourseName`=@cn,`CourseHour`=@ch,`Description`=@desc WHERE  `CourseId`=@id", connect.getconnection);
            // add dates in my database server to update
            //@id,@cn,@ch,@desc
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        //Create a function to delete a course
        //we only need course id
        public bool deletCourse(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseId`=@id", connect.getconnection);
            // add course ID  in my database server to delete 
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
    }
}
