using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

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
            using (this.sqlConnection)
            {
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
        public int InsertTable(AddressBookDetails details)
        {
            int count = 0;
            using (sqlConnection)
            {
                try
                {

                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertAddressBook", this.sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    this.sqlConnection.Open();
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
                    this.sqlConnection.Close();
                }
                return count;
            }
        }
        public int EditDetails(AddressBookDetails details)
        {
            int count = 0;


            try
            {
                using (this.sqlConnection)
                {
                    GetAllData();
                    this.sqlConnection.Open();
                    string query = @"update Address_Book_Table set Address='MysticFalls'where FirstName='Damon'";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Updated SuccessFully");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return count;
        }
        public int DeleteRecord()
        {
            AddressBookDetails details = new AddressBookDetails();
            int count = 0;
            try
            {
                using (sqlConnection)
                {

                    string query = @"delete from Address_Book_Table where FirstName = 'Rachel' and LastName = 'Green'";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Deleted SuccessFully");

                    }
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
        public int RetrieveData(AddressBookDetails details)
        {
            int count = 0;
            try
            {
                using (this.sqlConnection)
                {

                    string query = @"Select FirstName from Address_Book_Table where City = 'Adol' or State = 'NewYork'";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count++;
                            details.FirstName = Convert.ToString(reader["FirstName"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return count;

        }
        public string CountByStateAndCity(AddressBookDetails details)
        {
            string result = null;
            try
            {
                using (this.sqlConnection)
                {

                    string query = @"Select Count(*) As TotalCount, State, City from Address_Book_Table group by State,City";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    int res = sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            result += reader[0] + " " + reader[1] + " " + reader[2] + " ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return result;
        }
        public int SortByNameAndCity(AddressBookDetails details)
        {
            int count = 0;
            try
            {
                using (this.sqlConnection)
                {

                    string query = @"Select FirstName from Address_Book_Table where City='NewYork' order by FirstName";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count++;
                            details.FirstName = Convert.ToString(reader["FirstName"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                this.sqlConnection.Close();
            }
            return count;
        }
        public int FindAddressBookByTypeAndName(AddressBookDetails details)
        {
            int count = 0;
            try
            {
                using (this.sqlConnection)
                {

                    string query = @"Select FirstName from Address_Book_Table where AddressBookType='Friends'";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count++;
                            details.FirstName = Convert.ToString(reader["FirstName"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                this.sqlConnection.Close();
            }
            return count;
        }
        public string CountAddressBookType(AddressBookDetails details)
        {
            string result = null;
            try
            {
                using (sqlConnection)
                {

                    string query = @"Select count(*) as Type, AddressBookType from Address_Book_Table group by AddressBookType";
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    sqlConnection.Open();
                    int res = sqlCommand.ExecuteNonQuery();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result += reader[0] + " " + reader[1] + " ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                sqlConnection.Close();
            }
            return result;
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




