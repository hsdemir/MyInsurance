using MyInsurance.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Model;
using MyInsurance.DataAccess.DataAccess;

namespace MyInsurance.Business.Business
{
    public class CompanyBusiness : ICompanyBusiness
    {
        CompanyDataAccess _companyDataAccess;
        public CompanyBusiness()
        {
            _companyDataAccess = new CompanyDataAccess();
        }

        public Company GetCompany(int Id)
        {
            return _companyDataAccess.GetCompany(Id);
        }

        public List<Company> GetCompanies()
        {
            return _companyDataAccess.GetCompanies();
        }
    }
}
