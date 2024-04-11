using AgileWorks.Models;
using AgileWorks.Helpers;

namespace TicketHelperTests {
    [TestClass]
    public class TicketHelperTests {


        [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void MarkAsUrgentBasedOnTargetTimeTests (int dueDateHoursFromNow, int targetTimeHoursFromNow, bool expectedResult) {
            Ticket ticket = new Ticket {
                DueDate = DateTime.Now.AddHours(dueDateHoursFromNow),
            };
            DateTime targetTime = DateTime.Now.AddHours(targetTimeHoursFromNow);
            ticket = TicketHelper.MarkAsUrgentBasedOnTargetTime(ticket, targetTime);
            Assert.AreEqual(ticket.MarkedAsUrgent, expectedResult);
        }

        public static IEnumerable<object[]> TestData() {
            return new List<object[]>
            {
            new object[] { 20, 10, false },
            new object[] { 15, 10, false },
            new object[] { -10, -20, false },
            new object[] { 5, 10, true },
            new object[] { 3, 10, true },
            new object[] { -5, 50, true },
            };
       }
    }
}