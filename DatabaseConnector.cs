using System;
using MySql.Data.MySqlClient;

public class DatabaseConnector
{
    private MySqlConnection myConnection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=password_manager;" + "UID=application;PASSWORD=pwdManager2020;");

    public DatabaseConnector()
	{
        try
        {
            openConnection();
            Console.WriteLine("successfully connected to database");
        }
        catch
        {
            throw new Exception("connection to database failed");
        }
        closeConnection();
    }

    public MySqlConnection getMySqlConnection()
    {
        //get connection
        return myConnection;
    }

    public void loginUser(String username, String password)
    {
        if (password1.Equals(password2))
        {
            openConnection();
            //INSERT query to save new user
            string userInsertQuery = string.Format("SELECT EXISTS INTO user (username, mail) Values('{0}', '{1}')", username, mail);
            MySqlCommand userInsertCommand = new MySqlCommand(userInsertQuery);

            //set connection to command
            userInsertCommand.Connection = myConnection;

            //run command
            userInsertCommand.ExecuteNonQuery();
            closeConnection();
        }
        else
        {
            throw new Exception("passwords are not the same");
        }
    }

    public void createNewUser(String username, String password1, String password2, String mail)
    {
        if (password1.Equals(password2))
        {
            openConnection();
            //INSERT query to save new user
            string userInsertQuery = string.Format("INSERT INTO user (username, mail) Values('{0}', '{1}')", username, mail);
            MySqlCommand userInsertCommand = new MySqlCommand(userInsertQuery);

            //set connection to command
            userInsertCommand.Connection = myConnection;

            //run command
            userInsertCommand.ExecuteNonQuery();
            closeConnection();
        } else
        {
            throw new Exception("passwords are not the same");
        }
    }

    private void openConnection()
    {
        //start connection to database
        myConnection.open();
    }

    private void closeConnection()
    {
        //end connection to database
        myConnection.Close();
    }
}
