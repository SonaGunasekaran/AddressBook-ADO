using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBookADO
{
    class AddressBookDetails
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book;Integrated Security=True;";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}
