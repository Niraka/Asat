using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsatUnitTests
{
    [TestClass]
    public class Event
    {
        [TestMethod]
        public void DefaultConstruct()
        {
            Asat.Framework.Event.Event<int> e = new Asat.Framework.Event.Event<int>();
            Assert.AreEqual(e.GetEventId(), -1);
            Assert.AreEqual(e.GetEventTypeId(), -1);
            Assert.AreEqual(e.GetData(), default(int));
        }

        [TestMethod]
        public void SpecifiedConstructEvent()
        {
            Asat.Framework.Event.Event<int> e = new Asat.Framework.Event.Event<int>(1, 2, 3);
            Assert.AreEqual(e.GetEventId(), 1);
            Assert.AreEqual(e.GetEventTypeId(), 2);
            Assert.AreEqual(e.GetData(), 3);
        }

        [TestMethod]
        public void DefaultConstructEventTypeDetails()
        {
            Asat.Framework.Event.EventTypeDetails details = new Asat.Framework.Event.EventTypeDetails();
            Assert.AreEqual(details.iUid, -1);
            Assert.AreEqual(details.sName, string.Empty);
            Assert.AreEqual(details.EventListeners == null, false);
            Assert.AreEqual(details.EventListeners.Count, 0);
        }

        [TestMethod]
        public void SpecifiedConstructEventTypeDetails()
        {
            Asat.Framework.Event.EventTypeDetails details = new Asat.Framework.Event.EventTypeDetails(1, "test");
            Assert.AreEqual(details.iUid, 1);
            Assert.AreEqual(details.sName, "test");
            Assert.AreEqual(details.EventListeners == null, false);
            Assert.AreEqual(details.EventListeners.Count, 0);
        }
    }
}
