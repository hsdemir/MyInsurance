using MyInsurance.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Model;
using MyInsurance.DataAccess.Mappers;

namespace MyInsurance.DataAccess.DataAccess
{
    public class CompanyDataAccess : ICompanyDataAccess
    {
        CompanyMapper _companyMapper;
        public CompanyDataAccess()
        {
            _companyMapper = new CompanyMapper();
        }
        public Company GetCompany(int Id)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var companyData = db.Companies.FirstOrDefault(c => c.Id == Id);
                return _companyMapper.ToModel(companyData);
            }
        }
        public List<Company> GetCompanies()
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var companyData = db.Companies.ToList();
                return _companyMapper.ToModelList(companyData);
            }
        }
    }
}
