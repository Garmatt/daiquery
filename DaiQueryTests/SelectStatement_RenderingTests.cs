using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaiQuery;

namespace DaiQueryTests
{
    [TestClass]
    public class SelectStatement_RenderingTests
    {
        SelectStatement selectStatement;
        Table testTable;

        [TestInitialize]
        public void Initialize()
        {
            selectStatement = new SelectStatement();
            testTable = new Table("TestTable");
        }

        [TestCleanup]
        public void Cleanup()
        {
            testTable = null;
            selectStatement = null;
        }

        [TestMethod]
        public void SelectEmpty()
        {
            Assert.AreEqual(";", selectStatement.Render(false));
        }

        [TestMethod]
        public void SelectConstantUnicodeStringWithAlias()
        {
            selectStatement.SelectClause.Add(new ConstantUnicodeString("test", true), "TestAlias");
            Assert.AreEqual("SELECT N'test' AS TestAlias;", selectStatement.Render(false));
        }

        [TestMethod]
        public void SelectColumnWithAlias()
        {
            selectStatement.FromClause.Source = testTable;
            selectStatement.SelectClause.Add(new Column("TestColumn", testTable), "Test");
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable];", selectStatement.Render(false));
        }

        [TestMethod]
        public void SelectColumnWithAlias_WithFilter()
        {
            selectStatement.FromClause.Source = testTable;
            selectStatement.SelectClause.Add(new Column("TestColumn", testTable), "Test");
            selectStatement.WhereClause.Predicate = new ComparisonPredicate(
                eComparisonOperator.EQUAL, 
                new Column("FilterColumn", testTable), 
                new ConstantString("TEST_VALUE", false));
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable] WHERE [TestTable].[FilterColumn] = 'TEST_VALUE';", selectStatement.Render(false));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectColumnWithNullAlias()
        {
            selectStatement.SelectClause.Add(new Column("TestColumn", new Table("TestTable")), null);
        }
    }
}
