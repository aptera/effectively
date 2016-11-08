namespace effectively.tests.StaticCling {
    using effectively.StaticCling;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class The_database {

        [TestFixture]
        public class when_querying {

            [Test]
            public void logs_the_sql() {
                TestableLogger testLogger = new TestableLogger();
                new TestableDatabase(testLogger).QueryInstance<string>("");

                Assert.AreEqual("", testLogger._message);
            }


        }

        private class TestableDatabase : Database {

            public TestableDatabase(TestableLogger testLogger) : base(testLogger) { }

            protected override IEnumerable<T> AccessDatabase<T>(string sql) {
                return null;
            }
        }

        private class TestableLogger : Logger {
            public string _message { get; private set; }

            public override void LogInstance(string message) {
                _message = message;
            }
        }
    }
}
