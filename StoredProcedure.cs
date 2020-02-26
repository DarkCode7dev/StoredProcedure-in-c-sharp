using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado
{
    class StoredProceduresDb
    {
        static void Main(string[] args)
        {
            //Create Stored Procedures
            //Insert Procedure 
            const string connect = @"Data Source=DESKTOP-452QJS5\PROGRAMMER;Initial Catalog=Ado;Integrated Security=True";

            //Insert Procedure
            // InsertProcedure(connect);

            //Update Procedure
            // UpdateProcedure(connect);

            //Delete Procedure
            // DeleteProcedure(connect);

            //select
            ReadAllRecord(connect);

        }

        private static void ReadAllRecord(string connect)
        {
            //Creating connection between SQL and VS
            IDbConnection dbConnection = new SqlConnection(connect);
            IDbCommand command = new SqlCommand("EmpShow", (SqlConnection)dbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // ExecuteReader used for getting the query results as a DataReader object. It is readonly forward only retrieval of records and it uses select command to read through the table from the first to the last.
            try
            {
                dbConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine(reader["EmpName"] + "lives in " + reader["EmpAddress"]);
            }
            catch (SqlException)
            {

                Console.WriteLine("Sorry Something went wrong.....");
            }

            finally
            {
                dbConnection.Close();
            }
        }
        private static void DeleteProcedure(string connect)
        {
            int id = MyConsole.GetNumber("Enter the Id:");
            
            SqlConnection dbConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand("EmpDelete", dbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@param1", id);
            

            try
            {
                //open Connection

                dbConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                Console.WriteLine("Someting went wrong");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private static void UpdateProcedure(string connect)
        {
            int id = MyConsole.GetNumber("Enter the Id:");
            string name = MyConsole.GetString("Enter the Name: ");
            string address = MyConsole.GetString("Enter the Address:");

            SqlConnection dbConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand("EmpUpdate", dbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@param1", id);
            command.Parameters.AddWithValue("@param2", name);
            command.Parameters.AddWithValue("@param3", address);

            try
            {
                //open Connection

                dbConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                Console.WriteLine("Someting went wrong");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private static void InsertProcedure(string connect)
        {
            int id = MyConsole.GetNumber("Enter the Id:");
            string name = MyConsole.GetString("Enter the Name: ");
            string address = MyConsole.GetString("Enter the Address:");

            SqlConnection dbConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand("EmpInsert", dbConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@param1", id);
            command.Parameters.AddWithValue("@param2", name);
            command.Parameters.AddWithValue("@param3", address);

            try
            {
                //open Connection

                dbConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                Console.WriteLine("Someting went wrong");
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
