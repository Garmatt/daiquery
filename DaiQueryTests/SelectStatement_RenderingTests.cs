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
            Assert.AreEqual(string.Empty, selectStatement.Render());
        }

        [Test]
        public void SelectConstantUnicodeString()
        {
            selectStatement.Select(new ConstantUnicodeString("test", true));
            Assert.AreEqual("SELECT N'test';", selectStatement.Render());
        }

        [Test]
        public void SelectConstantUnicodeStringWithAlias()
        {
            selectStatement.SelectClause.Add(new ConstantUnicodeString("test", true), "TestAlias");
            Assert.AreEqual("SELECT N'test' AS TestAlias;", selectStatement.Render());
        }

        [Test]
        public void SelectColumn()
        {
            selectStatement.Select("TestColumn").From(testTable);
            Assert.AreEqual("SELECT [TestColumn] FROM [TestTable];", selectStatement.Render());
        }

        [Test]
        public void SelectTableColumn()
        {
            selectStatement.Select(new Column("TestColumn", testTable)).From(testTable);
            Assert.AreEqual("SELECT [TestTable].[TestColumn] FROM [TestTable];", selectStatement.Render());
        }

        [Test]
        public void SelectColumnWithAlias()
        {
            selectStatement.From(testTable).SelectClause.Add(new Column("TestColumn", testTable), "Test");
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable];", selectStatement.Render());
        }

        [Test]
        public void SelectColumnWithAlias_WithFilter()
        {
            selectStatement.From(testTable)
                .Where(new ComparisonPredicate( new Column("FilterColumn", testTable), ComparisonOperator.Equal, new ConstantString("TEST_VALUE", false)))
                .SelectClause.Add(new Column("TestColumn", testTable), "Test");
            Assert.AreEqual("SELECT [TestTable].[TestColumn] AS Test FROM [TestTable] WHERE [TestTable].[FilterColumn] = 'TEST_VALUE';", selectStatement.Render());
        }

        [Test]
        public void SelectColumn_WithFilter()
        {
            selectStatement.From(testTable).Where("FilterColumn", false, "TEST_VALUE").Select("TestColumn");
            Assert.AreEqual("SELECT [TestColumn] FROM [TestTable] WHERE [FilterColumn] <> 'TEST_VALUE';", selectStatement.Render());
        }

        [Test]
        public void SelectColumnWithNullAlias()
        {
            Assert.That(() => selectStatement.SelectClause.Add(new Column("TestColumn", new Table("TestTable")), (string)null), Throws.ArgumentException);
        }
    }
}
