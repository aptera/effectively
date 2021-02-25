namespace effectively.tests.StaticCling
{
	using effectively.StaticCling;
	using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class The_people_searcher
	{

		[TestFixture]
		public class when_querying
		{

			[Test]
			public void logs_the_sql()
			{
				LastMessageLogger logger = new LastMessageLogger();
				TestableDatabase database = new TestableDatabase(logger);
				PeopleSearcher peopleSearcher = new PeopleSearcher(database);
				peopleSearcher.Search("Luke");
				Assert.AreEqual("select * from Person where Name like '%Luke%'", logger.LastMessage);

			}
		}
	}

	[TestFixture]
	public class The_database
    {
		[TestFixture]
		public class WhenStaticQuerying
		{
			[Test]
			public void ThenThrowException()
			{
				Assert.Throws<Exception>(() => Database.Query<Person>(""));
			}
		}

		[TestFixture]
		public class WhenInstanceQuerying
		{
			[Test]
			public void ThenThrowException()
			{
				Database database = new Database();
				Assert.Throws<Exception>(() => database.QuerySQL<Person>(""));
			}

			[Test]
			public void ThenTheSqlQueryIsLogged()
			{
				LastMessageLogger logger = new LastMessageLogger();
				var database = new TestableDatabase(logger);
				database.QuerySQL<Person>("The Query");
				Assert.AreEqual("The Query", logger.LastMessage);
			}
		}

	}

	[TestFixture]
	public class The_logger
	{
		[TestFixture]
		public class WhenStaticLogging
		{
			[Test]
			public void ThenThrowException()
			{
				Assert.Throws<Exception>(() => Logger.Log(""));

			}
		}

		[TestFixture]
		public class WhenInstanceLogging
		{
			[Test]
			public void ThenThrowException()
			{
				Logger logger = new Logger();
				Assert.Throws<Exception>(() => logger.LogMessage(""));
			}
		}

		[TestFixture]
		public class WhenOverridingInstanceLogging
		{
			[Test]
			public void ThenLogMessageToLastMessage()
			{
				LastMessageLogger logger = new LastMessageLogger();
				logger.LogMessage("Message");
				Assert.AreEqual("Message", logger.LastMessage);
			}

		}
	}

	class LastMessageLogger : Logger
    {
		public string LastMessage { get; set; }

		public override void LogMessage(string message)
        {
			LastMessage = message;
        }

    }


	class TestableDatabase : Database
    {
        public TestableDatabase(Logger logger) : base(logger)
        {

        }

        protected override IEnumerable<T> OnQuerySQL<T>(string sql)
        {
			return null;
        }
    }
}