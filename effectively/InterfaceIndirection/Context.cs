using System.Web;

namespace effectively.InterfaceIndirection {
    public class Context : IContext {
        public void setStatusCode(int code) {
            HttpContext.Current.Response.StatusCode = code;
        }
    }
}
