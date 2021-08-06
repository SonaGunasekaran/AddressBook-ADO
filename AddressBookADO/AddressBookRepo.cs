using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBookADO
{
    class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book;Integrated Security=True;";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void GetAllData()
        {
            //open connection
            this.sqlConnection.Open();
            //retrieve the query
            AddressBookDetails details = new AddressBookDetails();
            string query = @"select * from dbo.Address_Book_Table";
            try
            {
                SqlCommand command = new SqlCommand(query, this.sqlConnection);
                //returns data as rows
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        details.Id = Convert.ToInt32(reader["id"]);
                        details.FirstName = Convert.ToString(reader["FirstName"]);
                        details.LastName = Convert.ToString(reader["LastName"]);
                        details.Address = Convert.ToString(reader["Address"]);
                        details.City = Convert.ToString(reader["City"]);
                        details.State = Convert.ToString(reader["State"]);
                        details.ZipCode = Convert.ToString(reader["ZipCode"]);
                        details.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                        details.Email = Convert.ToString(reader["Email"]);
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", details.FirstName, details.LastName, details.Address, details.City, details.State, details.ZipCode, details.PhoneNumber, details.Email);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data vailable");
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //connection close
                this.sqlConnection.Close();
            }
        }
    }
}
