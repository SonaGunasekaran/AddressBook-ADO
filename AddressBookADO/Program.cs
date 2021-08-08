using System;
using System.Data.SqlClient;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book ADO!");
            Console.WriteLine("1.Retrive all data\n2.Insert into Table\n3.Edit Details\n4.Delete Records using name\n5.Retrieve data based on city or state\n6.Count data based on city or state ");
            Console.Write("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            AddressBookRepo repo = new AddressBookRepo();
            AddressBookDetails details = new AddressBookDetails();
            
            switch (choice)
            {
                case 1:
                    repo.GetAllData();
                    break;
                case 2:
                    repo.InsertTable(details);
                    repo.ReadData(details);
                    break;
                case 3:
                    repo.EditDetails(details);
                    break;
                case 4:
                    repo.DeleteRecord();
                    break;
                case 5:
                    repo.RetrieveData(details);
                    break;
                case 6:
                    repo.CountByStateAndCity(details);
                    break;
                default:
                    break;
            }
        }
    }
}
