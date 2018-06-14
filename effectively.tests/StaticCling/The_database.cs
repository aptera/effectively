namespace effectively.tests.StaticCling {
	using System.Collections.Generic;
	using effectively.StaticCling;
	using FakeItEasy;
	using NUnit.Framework;

	[TestFixture]
	public class The_database {

		[TestFixture]
		public class when_querying {

			[Test]
			public void logs_the_sql() {
				var logger = A.Fake<Logger>();
				A.CallTo(() => logger.LogInstance(A<string>.Ignored)).DoesNothing();
				var database = new Testabledatabase(logger);

				var searcher = new PeopleSearcher(database);
				searcher.Search("Wayne");
				A.CallTo(() => logger.LogInstance("select * from Person where Name like '%Wayne%'")).MustHaveHappened();

			}
		}

		public class Testabledatabase : Database
		{

			public Testabledatabase(Logger logger) : base(logger)
			{
				
			}

			protected override IEnumerable<T> HitTheDatabase<T>()
			{
				return null;
			}
		}
    }
}
