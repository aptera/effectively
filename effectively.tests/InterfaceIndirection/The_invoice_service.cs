namespace effectively.tests.ExtractInterface {
    using effectively.ExtractInterface;
    using InterfaceIndirection;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class The_invoice_service {

        [TestFixture]
        public class when_getting_an_invoice {

            [Test]
            public void TheInvoice_idisa_string() {
                var mockContext = new Mock<IContext>();
                InvoiceService myService = new InvoiceService(mockContext.Object);
                var invoice = myService.GetInvoice(0);
                Assert.IsInstanceOf(typeof(string), invoice.Id);
            }


            //the invoice number is the invoice Id as a string


            //Given an invoice prefix (cookie)
            //the invoice number is the prefix + invoice Id

        }
    }
}
