using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book ADO!");
            AddressBookRepo repo = new AddressBookRepo();
            AddressBookDetails details = new AddressBookDetails();
            repo.GetAllData();
            repo.InsertTable(details);
            repo.ReadData(details);
        }
    }
}
