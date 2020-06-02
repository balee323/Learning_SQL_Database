using Notes_CRUD_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Notes_CRUD_App
{
    class DatabaseAccessManager
    {

        private string _dBConnectionString = "Data Source=devmachine\\sqldev;Integrated Security=True;Initial Catalog=LearningSQL";
        private SqlConnection _connection;


        private bool ConnectToDB()
        {
            bool connectionSuccessful = false;
            try
            {
                _connection = new SqlConnection(_dBConnectionString);
                _connection.Open();
                connectionSuccessful = true;
            }
            catch (Exception e)
            {
                //error has occurred while trying to connect to DB.
                MessageBox.Show(e.Message);
            }

            return connectionSuccessful;

        }


        public List<Note> GetNotes(Int64 userId)
        {
            List<Note> notes = new List<Note>();

            var connectionSuccessful = ConnectToDB();

            if (connectionSuccessful == true)
            {
                SqlCommand sqlCmd = new SqlCommand($"Select * from Notes where USER_ID = {userId}", _connection);
                sqlCmd.CommandType = CommandType.Text; //for using in-code sql

                try
                {
                    SqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Note note = new Note();
                        note.NoteBody = (string)reader["NOTE_BODY"];
                        note.NoteDate = (DateTime)reader["DATE"];
                        note.NoteId = (Int64)reader["NOTE_ID"];

                        notes.Add(note);
                    }

                }
                catch (Exception e)
                {
                    //error has occurred while trying to read User's notes.
                    MessageBox.Show(e.Message);
                }
            }

            return notes;
        }


        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            var connectionSuccessful = ConnectToDB();

            if (connectionSuccessful == true)
            {
                SqlCommand sqlCmd = new SqlCommand("Select * from Users", _connection);
                sqlCmd.CommandType = CommandType.Text; //for using in-code sql

                try
                {
                    SqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        User user = new User();
                        user.FirstName = (string)reader["FNAME"];
                        user.LastName = (string)reader["LNAME"];
                        user.DOB = (DateTime)reader["DOB"];
                        user.UserID = (Int64)reader["USER_ID"];

                        users.Add(user);
                    }

                }
                catch (Exception e)
                {
                    //error has occurred while trying to get Users.
                    MessageBox.Show(e.Message);
                }
            }

            return users;
        }


    }
}
