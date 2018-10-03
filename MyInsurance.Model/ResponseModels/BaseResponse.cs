using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Model.ResponseModels
{
   public class BaseResponse<T> where T : new()
    {
        public T Data { get; set; }
        public List<Exception> Errors { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
    }
}
