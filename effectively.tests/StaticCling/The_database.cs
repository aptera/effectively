namespace effectively.tests.StaticCling {
	using effectively.StaticCling;
	using NUnit.Framework;

    [TestFixture]
    public class The_database {

        [TestFixture]
        public class when_querying {

            [Test]
            [Ignore("This needs to be implemented!")]

            public void logs_the_sql() {
				var searcher = new PeopleSearcher();
				searcher.Search("Wayne");
                Assert.Fail("Not implemented!");
            }
        }
    }
}
