namespace effectively.tests.BreakoutClass {
    using effectively.BreakoutClass;
    using NUnit.Framework;

    [TestFixture]
    public class The_person {
        [Test]
        public void is_testable() {
            var person = new Person("bob");
            // kaboom
        }

        // has a sortable display name property
    }
}
