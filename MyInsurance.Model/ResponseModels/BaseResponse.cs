using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Model.ResponseModels
{
   public class BaseResponse<T> where T : new()
    {
        public T Data { get; set; }
        public Exception Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
