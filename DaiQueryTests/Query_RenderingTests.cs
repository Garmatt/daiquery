using DaiQuery;
using NUnit.Framework;
using DaiQuery.Shortcuts;

namespace DaiQueryTests
{
    [TestFixture]
    public class Query_RenderingTests
    {
        Query query;
        Table testTable;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            testTable = new Table("TestTable");
        }

        [SetUp]
        public void SetUp()
        {
            query = new Query();
        }
        
        [TearDown]
        public void TearDown()
        {
            query = null;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            testTable = null;
        }

        [Test]
        public void SelectEmpty()
        {
            Assert.AreEqual(string.Empty, query.Render());
        }

        [Test]
        public void SelectConstantUnicodeString()
        {
            query.Select(new ConstantUnicodeString("test", true));
            Assert.AreEqual("SELECT N'test';", query.Render());
        }

        [Test]
        public void SelectConstantUnicodeStringWithAlias()
        {
            query.SelectClause.Add(new ConstantUnicodeString("test", true), "TestAlias");
            Assert.AreEqual("SELECT N'test' AS TestAlias;", query.Render());
        }

        [Test]
        public void SelectColumn()
        {
            query.Select("TestColumn").From(testTable);
            Assert.AreEqual("SELECT [TestColumn] FROM [TestTable];", query.Render());
        }

        [Test]
        public void SelectTableColumn()
        {
            query.Select(new Column("TestColumn", testTable)).From(testTable);
            Assert.AreEqual("SELECT [TestTable].[TestColumn] FROM [TestTable];", query.Render());
        }

        [Test]
        public void SelectColumnWithAlias()
        {
            query.From(testTable).SelectClause.Add(new Column("TestColumn", testTable), "Test");
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable];", query.Render());
        }

        [Test]
        public void SelectColumnWithAlias_WithFilter()
        {
            query.From(testTable)
                .Where(new ComparisonPredicate( new Column("FilterColumn", testTable), ComparisonOperator.Equal, new ConstantString("TEST_VALUE", false)))
                .SelectClause.Add(new Column("TestColumn", testTable), "Test");
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable] WHERE [TestTable].[FilterColumn] = 'TEST_VALUE';", query.Render());
        }

        [Test]
        public void SelectColumn_WithFilter()
        {
            query.From(testTable).Where("FilterColumn", false, "TEST_VALUE").Select("TestColumn");
            Assert.AreEqual("SELECT [TestColumn] FROM [TestTable] WHERE [FilterColumn] <> 'TEST_VALUE';", query.Render());
        }

        [Test]
        public void SelectColumnWithNullAlias()
        {
            Assert.That(() => query.SelectClause.Add(new Column("TestColumn", new Table("TestTable")), (string)null), Throws.ArgumentException);
        }
    }
}
