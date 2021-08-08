using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookADO;
namespace TestAddressBookADO
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo repo;
        AddressBookDetails details;
       [TestInitialize]
        public void Setup()
        {
            repo = new AddressBookRepo();
            details = new AddressBookDetails();
        }
        [TestMethod]
        public void TestMethodInsertTable()
        {
            int expected = 1;
            var actual = repo.InsertTable(details);
            Assert.AreEqual(expected, actual);
        
        }
        [TestMethod]
        public void TestEditDetails()
        {
            int expected = 1;
            int actual = repo.EditDetails(details);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDeleteRecord()
        {
            int expected = 1;
            int actual = repo.DeleteRecord();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRetrieveDataCityAndState()
        {
            int expected = 2;
            var actual = repo.RetrieveData(details);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountGroupByCityAndState()
        {
            var expected = "2 NewYork Adol 1 Canada Boredom 2 Mexico Cargo 1 London Gago 1 NewJersy Kindle ";
            
            var actual = repo.CountByStateAndCity(details);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSortByNameAndCity()
        {
            int expected = 2;
            var actual = repo.SortByNameAndCity(details);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFindAddressBookByTypeAndName()
        {
            var expected = "Chandler";
            var actual = repo.FindAddressBookByTypeAndName(details);
            Assert.AreEqual(expected, actual);
        }
    }
}
