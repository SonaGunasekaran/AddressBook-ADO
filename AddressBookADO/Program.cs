using System;
using System.Data.SqlClient;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book ADO!");
            Console.WriteLine("1.Retrive all data\n2.Update salary\n3.Retirieve Date using Name\n4.Aggregate Functions");
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
                    repo.GetAllData();
                    repo.DeleteRecord();
                    break;
                case 5:
                    repo.GetAllData();
                    repo.RetrieveData(details);
                    break;

                default:
                    break;

            }
        }
    }
}
