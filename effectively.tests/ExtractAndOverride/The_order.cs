namespace effectively.tests.ExtractAndOverride {
    using effectively.ExtractAndOverride;
    using NUnit.Framework;

    [TestFixture]
    public class The_order {
        private TestableOrderService service;
        private Order order;
        [SetUp]
        public void setup() {
            ArrangeDefaultValues();
        }

        private void ArrangeDefaultValues() {
            service = new TestableOrderService();
            service.isValidUser = true;

            order = new Order();
            order.Amount = 0;
        }

        [Test]
        public void GivenCurrentUserIsNotValid_OrderCantSave() {
            service.isValidUser = false;
            bool result = service.Add(order);
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenCurrentUserValid_OrderAmountIsNegative_OrderCannotBeSaved() {
            order.Amount = -1;

            bool result = service.Add(order);
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenTheOrderAmountZeroTheOrderCanBeSaved() {
            bool result = service.Add(order);
            Assert.IsTrue(result);

        }

        [Test]
        public void TheOrderSavesToTheDatabase() {
            bool result = service.Add(order);
            Assert.AreEqual(0, service.savedOrder.Amount);
        }

        private class TestableOrderService : OrderService {
            public Order savedOrder { get; private set; }
            public bool isValidUser { get; set; }

            protected override bool GetIsValidUser() {
                return isValidUser;
            }
            protected override void SaveToDatabase(Order order) {
                savedOrder = order;
            }
        }
    }
}
