using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsatUnitTests
{
    [TestClass]
    class DatabaseAddress
    {
        [TestMethod]
        public void DefaultConstructDatabaseAddress()
        {
            Asat.Tools.DatabaseAddress dba = new Asat.Tools.DatabaseAddress();
            Assert.AreEqual(dba.GetServerName(), string.Empty);
            Assert.AreEqual(dba.GetDatabaseName(), string.Empty);
        }

        [TestMethod]
        public void SpecifiedConstructDatabaseAddress()
        {
            Asat.Tools.DatabaseAddress dba = new Asat.Tools.DatabaseAddress("a", "b");
            Assert.AreEqual(dba.GetServerName(), "a");
            Assert.AreEqual(dba.GetDatabaseName(), "b");
        }
    }
}
