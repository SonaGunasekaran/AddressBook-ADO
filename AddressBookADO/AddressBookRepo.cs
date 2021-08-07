using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBookADO
{
    public class AddressBookRepo
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
        public int InsertTable(AddressBookDetails details)
        {
            int count = 0;
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertAddressBook", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    ReadData(details);
                    sqlCommand.Parameters.AddWithValue("@FirstName", details.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", details.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", details.Address);
                    sqlCommand.Parameters.AddWithValue("@City", details.City);
                    sqlCommand.Parameters.AddWithValue("@State", details.State);
                    sqlCommand.Parameters.AddWithValue("@ZipCode", details.ZipCode);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", details.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", details.Email);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Inserted Successfully");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
                return count;
            }
        }

        public AddressBookDetails ReadData(AddressBookDetails details)
        {
            details.FirstName = "Stefan";
            details.LastName = "Salvatore";
            details.Address = "Seattle";
            details.City = "Cargo";
            details.State = "Mexico";
            details.ZipCode = "1234560";
            details.PhoneNumber = 987654312;
            details.Email = "stef@gmail.com";
            return details;
        }
    }
}


