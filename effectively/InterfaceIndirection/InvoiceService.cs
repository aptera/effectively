namespace effectively.ExtractInterface {
    using InterfaceIndirection;
    using System.Net;
    using System.Web;

    public class InvoiceService {
        private IContext myContext = new Context();

        public InvoiceService(IContext context) {
            this.myContext = context;
        }

        public InvoiceDto GetInvoice(int id) {

            // arg! how can I test that this happened?
            myContext.setStatusCode((int)HttpStatusCode.OK);

            return new InvoiceDto { Id = id.ToString() };
        }

    }
}
