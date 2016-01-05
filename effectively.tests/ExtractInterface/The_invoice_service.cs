namespace effectively.tests.ExtractInterface {
    using effectively.ExtractInterface;
    using NUnit.Framework;

    [TestFixture]
    public class The_invoice_service {

        [TestFixture]
        public class when_getting_an_invoice {
            private InvoiceService _service;

            [SetUp]
            public void SetUp() {
                _service = new InvoiceService();
            }

            [Test]
            public void returns_an_invoice_with_a_matching_id() {
                var invoice = _service.GetInvoice(1);
                Assert.AreEqual(1, invoice.Id);
            }

            [Test]
            public void sets_the_http_status_to_ok() {
                var invoice = _service.GetInvoice(1);
                // ???
            }

        }
    }
}
