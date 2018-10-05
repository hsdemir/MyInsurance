using MyInsurance.Model.ResponseModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Business.Helpers
{
    public class ServiceHelper
    {
        public BaseResponse<T> ServiceCall<T>(string serviceUrl, string resource, Method method = Method.GET, string postData = null, List<HttpHeader> headers = null, List<Parameter> parameters = null) where T : new()
        {
            BaseResponse<T> responseModel = new BaseResponse<T>();
            var client = new RestClient(serviceUrl + resource);

            var request = new RestRequest(method);
            request.RequestFormat = DataFormat.Json;

            //request model ile gönderilecek headerları ekle
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Name, header.Value);
                }
            }

            //request model ile gönderilecek parametreleri ekle GET/POST
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Name, (parameter.Value ?? string.Empty), parameter.ContentType, parameter.Type);
                }
            }

            if (postData != null)
            {
                request.AddJsonBody(postData);
            }

            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            responseModel.StatusCode = response.StatusCode;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseModel.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }
            else if (response.ErrorException != null)
            {
                responseModel.Error = response.ErrorException;
            }
            return responseModel;
        }
    }
}
