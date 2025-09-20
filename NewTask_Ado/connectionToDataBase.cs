using System;
using System.Data.SqlClient;

namespace NewTask_Ado
{
    internal class ConnectionToDatabase
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public ConnectionToDatabase()
        {

            sqlConnection = new SqlConnection("Data Source=Youssef-Waeel;Initial Catalog=ADOTASK;Integrated Security=True");
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

        }

        // character a
        public void DisplayDepartments()
        {

            sqlCommand.CommandText = "SELECT * FROM Departments";
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["DepName"]);
            }

            reader.Close();
            sqlConnection.Close();
        }

        public void AddDepartment(int Id, string Name)
        {
            sqlConnection.Open();
            sqlCommand.CommandText = "INSERT INTO Departments (DepId,DepName) VALUES (@Id, @Name)";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@Name", Name);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteDepartment(string deptName)
        {
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM Departments\nWHERE DepName=@deptName;";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@deptName", deptName);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void Exsit()
        {
            sqlConnection.Close();
        }
    }
}
