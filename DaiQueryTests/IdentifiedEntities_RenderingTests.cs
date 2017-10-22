using DaiQuery;
using NUnit.Framework;

namespace DaiQueryTests
{
    [TestFixture]
    public class IdentifiedEntities_RenderingTests
    {
        private Server server;
        private Database database;
        private Schema schema;

        [SetUp]
        public void SetUp()
        {
            server = new Server("TEST_SQL_SERVER");
            database = new Database("AdventureWorks");
            schema = new Schema("Production");
        }

        [TearDown]
        public void TearDown()
        {
            server = null;
            database = null;
            schema = null;
        }

        [Test]
        public void RenderServer()
        {
            Assert.AreEqual("[TEST_SQL_SERVER]", server.Render());
        }

        [Test]
        public void RenderDatabase()
        {
            Assert.AreEqual("[AdventureWorks]", database.Render());
        }

        [Test]
        public void RenderDatabaseWithServer()
        {
            database.Server = server;
            Assert.AreEqual("[TEST_SQL_SERVER].[AdventureWorks]", database.Render());
        }

        [Test]
        public void RenderSchema()
        {
            Assert.AreEqual("[Production]", schema.Render());
        }

        [Test]
        public void RenderSchemaWithDatabase()
        {
            schema.Database = database;
            Assert.AreEqual("[AdventureWorks].[Production]", schema.Render());
        }

        [Test]
        public void RenderSchemaWithDatabaseWithServer()
        {
            database.Server = server;
            schema.Database = database;
            Assert.AreEqual("[TEST_SQL_SERVER].[AdventureWorks].[Production]", schema.Render());
        }
    }
}
