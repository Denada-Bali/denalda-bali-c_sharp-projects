using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Final_Project_C_Sharp___UNYT
{
    class ScoreClass
    {
        DBconnect connect = new DBconnect();
        //create a function add grade to the database
        public bool insertScore(int stdid, string courName, double gra, string lgr)
    {
        //mysql connection represent an open connection to my database
        //connection string is a string that specifies information about data source     //The VALUES command specifies the values of an INSERT INTO statement.
        MySqlCommand command = new MySqlCommand("INSERT INTO `score`(`StudentId`, `CourseName`, `Grade`, `LetterGrade`) VALUES (@stid,@cn,@gra,@lgr)", connect.getconnection);
        
        // add dates in my database server
        //@stid,@cn,@gra,@lgr
        command.Parameters.Add("@stid", MySqlDbType.Int32).Value = stdid;
        command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = courName;
        command.Parameters.Add("@gra", MySqlDbType.Double).Value = gra;
        command.Parameters.Add("@lgr", MySqlDbType.VarChar).Value = lgr;
        connect.openConnect();// open the connection
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
    //create a functon to get list
    public DataTable getList(MySqlCommand command)
    {
      //sets some of its properties, retrieves data from a table, and displays it. 
      //And open the connection
        command.Connection = connect.getconnection;
        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    // create a function to check already course grade
    public bool checkScore(int stdId, string cName)
    {
        DataTable table = getList(new MySqlCommand("SELECT * FROM `score` WHERE `StudentId`= '" + stdId + "' AND `CourseName`= '" + cName + "'"));
        if (table.Rows.Count > 0)
        { return true; }
        else
        { return false; }
    }
    // Create A function to edit grade data
    public bool updateScore(int stdid, string scn, double grade, string LeGrade)
    {
        MySqlCommand command = new MySqlCommand("UPDATE `score` SET `Grade`=@gra,`LetterGrade`=@lgr WHERE `StudentId`=@stid AND `CourseName`=@scn", connect.getconnection);
        //@stid,@sco,@desc
        command.Parameters.Add("@scn", MySqlDbType.VarChar).Value = scn;
        command.Parameters.Add("@stid", MySqlDbType.Int32).Value = stdid;
        command.Parameters.Add("@gra", MySqlDbType.Double).Value = grade;
        command.Parameters.Add("@lgr", MySqlDbType.VarChar).Value = LeGrade;
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
    //Create a function to delete a grade data
    public bool deleteScore(int id)
    {
        MySqlCommand command = new MySqlCommand("DELETE FROM `score` WHERE `StudentId`=@id", connect.getconnection);

        //@id
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
