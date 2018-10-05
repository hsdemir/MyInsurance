using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.DataAccess.Interface
{
    public interface ICompanyDataAccess
    {
        Company GetCompany(int Id);
        List<Company> GetCompanies();
    }
}
