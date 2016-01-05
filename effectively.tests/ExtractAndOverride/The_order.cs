namespace effectively.tests.ExtractAndOverride {
    using effectively.ExtractAndOverride;
    using NUnit.Framework;

    [TestFixture]
    public class The_order {

        [TestFixture]
        class when_adding_an_order {

            [TestFixture]
            class given_an_invalid_user {

                [Test]
                public void returns_false() {
                    var order = new Order();
                    var result = order.Add();
                    Assert.IsFalse(result);
                }
            }

            [TestFixture]
            class given_a_valid_user {

                [Test]
                public void returns_true() {
                    // how can we arrange this??
                    var order = new Order();
                    var result = order.Add();
                    Assert.IsTrue(result);
                }
            }
        }
    }
}
