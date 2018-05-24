using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsatUnitTests
{
    [TestClass]
    public class ColumnAddress
    {
        [TestMethod]
        public void ToolsColumnAddressDefaultConstruct()
        {
            Asat.Tools.ColumnAddress ca = new Asat.Tools.ColumnAddress();
            Assert.AreEqual(ca.GetServerName(), string.Empty);
            Assert.AreEqual(ca.GetDatabaseName(), string.Empty);
            Assert.AreEqual(ca.GetTableName(), string.Empty);
            Assert.AreEqual(ca.GetColumnName(), string.Empty);
        }

        [TestMethod]
        public void ToolsColumnAddressSpecifiedConstruct()
        {
            Asat.Tools.ColumnAddress ca = new Asat.Tools.ColumnAddress("A", "B", "C", "D");
            Assert.AreEqual(ca.GetServerName(), "A");
            Assert.AreEqual(ca.GetDatabaseName(), "B");
            Assert.AreEqual(ca.GetTableName(), "C");
            Assert.AreEqual(ca.GetColumnName(), "D");
        }

        [TestMethod]
        public void ToolsColumnAddressNullReplacedByEmptyString()
        {
            Asat.Tools.ColumnAddress ca = new Asat.Tools.ColumnAddress(
                "a",
                "b",
                null,
                null);
            Assert.AreEqual(ca.GetServerName(), "A");
            Assert.AreEqual(ca.GetDatabaseName(), "B");
            Assert.AreEqual(ca.GetTableName(), string.Empty);
            Assert.AreEqual(ca.GetColumnName(), string.Empty);
        }

        [TestMethod]
        public void ToolsColumnAddressForcedUppercase()
        {
            Asat.Tools.ColumnAddress ca = new Asat.Tools.ColumnAddress(
                "lowercase",
                "test",
                "OTHER",
                "anothER.more");
            Assert.AreEqual(ca.GetServerName(), "LOWERCASE");
            Assert.AreEqual(ca.GetDatabaseName(), "TEST");
            Assert.AreEqual(ca.GetTableName(), "OTHER");
            Assert.AreEqual(ca.GetColumnName(), "ANOTHER.MORE");
        }
    }
}
