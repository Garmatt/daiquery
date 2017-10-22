using DaiQuery;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DaiQueryTests
{
    [TestFixture]
    public class SimpleExpressions_RenderingTests
    {
        private Table table = new Table("WorkOrder");

        public static IEnumerable<string> ColumnNames
        {
            get
            {
                return new List<string> { "WorkOrderID", "ProductID", "OrderQty", "StartDate", "EndDate" };
            }
        }

        [Test, TestCaseSource("ColumnNames")]
        public void RenderColumn(string columnName)
        {
            Assert.AreEqual("[" + columnName + "]", new Column(columnName).Render());
        }

        [Test, TestCaseSource("ColumnNames")]
        public void RenderColumnWithTable(string columnName)
        {
            Assert.AreEqual("[WorkOrder].[" + columnName + "]", new Column(columnName, table).Render());
        }
    }
}
