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
        public BaseResponse<T> GetServiceResponse<T>(string serviceUrl, Method method = Method.GET) where T : new()
        {
            BaseResponse<T> responseModel = null;
            var client = new RestClient(serviceUrl);

            var request = new RestRequest(resource, method);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response;
                response = client.Execute(request);

            responseModel.StatusCode = response.StatusCode.ToString();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseModel.Data = JsonConvert.DeserializeObject<T>(response.Content);
            }
            else
            {
                responseModel.Errors.Add(response.ErrorException);
            }
            return responseModel;
        }
    }
}
