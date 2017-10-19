using DaiQuery;
using NUnit.Framework;

namespace DaiQueryTests
{
    [TestFixture]
    public class SelectStatement_RenderingTests
    {
        SelectStatement selectStatement;
        Table testTable;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            testTable = new Table("TestTable");
        }

        [SetUp]
        public void SetUp()
        {
            selectStatement = new SelectStatement();
        }
        
        [TearDown]
        public void TearDown()
        {
            selectStatement = null;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            testTable = null;
        }

        [Test]
        public void SelectEmpty()
        {
            Assert.AreEqual(string.Empty, selectStatement.Render(false));
        }

        [Test]
        public void SelectConstantUnicodeString()
        {
            selectStatement.Select(new ConstantUnicodeString("test", true));
            Assert.AreEqual("SELECT N'test';", selectStatement.Render(false));
        }

        [Test]
        public void SelectConstantUnicodeStringWithAlias()
        {
            selectStatement.SelectClause.Add(new ConstantUnicodeString("test", true), "TestAlias");
            Assert.AreEqual("SELECT N'test' AS TestAlias;", selectStatement.Render(false));
        }

        [Test]
        public void SelectColumn()
        {
            selectStatement.Select(new Column("TestColumn", testTable)).From(testTable);
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable];", selectStatement.Render(false));
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
                new Column("FilterColumn", testTable),
                ComparisonOperator.Equal,
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
