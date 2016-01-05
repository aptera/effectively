namespace effectively.ExtractInterface {
    using System.Net;
    using System.Web;

    public class InvoiceService {

        public InvoiceDto GetInvoice(int id) {

            // arg! how can I test that this happened?
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.OK;

            return new InvoiceDto { Id = id };
        }

    }
}
