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
            int expected = 1;
            var actual = repo.RetrieveData(details);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountGroupByCityAndState()
        {
            var expected = "Adol NewYork 1 Kindle NewJersy 1 Gago London 1 Boredom Mexico 1 Vietnam Paris 1 ";
            
            var actual = repo.CountByStateAndCity(details);
            Assert.AreEqual(expected, actual);
        }
    }
}
