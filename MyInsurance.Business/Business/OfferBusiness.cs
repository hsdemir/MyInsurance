using MyInsurance.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.DataAccess;
using MyInsurance.Model;
using MyInsurance.DataAccess.DataAccess;
using MyInsurance.Business.Helpers;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace MyInsurance.Business.Business
{
    public class OfferBusiness : IOfferBusiness
    {
        OfferDataAccess _offerDataAccess;
        CompanyBusiness _companyBusiness;
        ServiceHelper _serviceHelper;
        public OfferBusiness()
        {
            _offerDataAccess = new OfferDataAccess();
            _companyBusiness = new CompanyBusiness();
            _serviceHelper = new ServiceHelper();
        }
        public Offer Create(Offer offer)
        {
            return _offerDataAccess.Create(offer);
        }

        public List<Offer> GetAllCompanyOffers(Customer customer)
        {
            var offerList = new List<Offer>();
            var companyList = _companyBusiness.GetCompanies();
            if (companyList != null && companyList.Any())
            {
                foreach (var company in companyList)
                {
                    //Todo : Farklı thread'ler ile servis çağrısı yapılmalı, servisler birbirini beklememeli.
                    //Todo : Tümü response verdiğinde return edilmeli.
                    var postDataJSON = JsonConvert.SerializeObject(customer);
                    var headers = new List<HttpHeader> { new HttpHeader { Name = "content-type", Value = "application/json" } };
                    var parameters = new List<Parameter> { new Parameter { Name = "application/json", Value = postDataJSON, Type = ParameterType.RequestBody } };
                    var serviceResponse = _serviceHelper.ServiceCall<Offer>(company.ServiceDomain, company.ServicePath, Method.POST, headers: headers, parameters: parameters);
                    if (serviceResponse.StatusCode == HttpStatusCode.OK && serviceResponse.Data != null)
                    {
                        var offerModel = Create(serviceResponse.Data);
                        offerList.Add(offerModel);
                    }
                }
            }

            return offerList;
        }

        public List<Offer> GetCustomerOffers(string TcNumber)
        {
            return _offerDataAccess.GetCustomerOffers(TcNumber);
        }
    }
}
