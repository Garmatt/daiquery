using DaiQuery;
using NUnit.Framework;

namespace DaiQueryTests
{
    [TestFixture]
    public class SelectStatement_RenderingTests
    {
        SelectStatement selectStatement;
        Table testTable;

        [SetUp]
        public void Initialize()
        {
            selectStatement = new SelectStatement();
            testTable = new Table("TestTable");
        }

        [TearDown]
        public void Cleanup()
        {
            testTable = null;
            selectStatement = null;
        }

        [Test]
        public void SelectEmpty()
        {
            Assert.AreEqual(";", selectStatement.Render(false));
        }

        [Test]
        public void SelectConstantUnicodeStringWithAlias()
        {
            selectStatement.SelectClause.Add(new ConstantUnicodeString("test", true), "TestAlias");
            Assert.AreEqual("SELECT N'test' AS TestAlias;", selectStatement.Render(false));
        }

        [Test]
        public void SelectColumnWithAlias()
        {
            selectStatement.FromClause.Source = testTable;
            selectStatement.SelectClause.Add(new Column("TestColumn", testTable), "Test");
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable];", selectStatement.Render(false));
        }

        [Test]
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

        [Test]
        public void SelectColumnWithNullAlias()
        {
            Assert.That(() => selectStatement.SelectClause.Add(new Column("TestColumn", new Table("TestTable")), (string)null), Throws.ArgumentException);
        }
    }
}
