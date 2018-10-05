
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.DataAccess.Mappers
{
    //Todo : Mapper için daha base bir yapı kurulabilir.
    public class CompanyMapper
    {
        private static MapperConfiguration _mapperConfiguration { get; set; }
        public static IMapper _mapper { get; set; }
        public CompanyMapper()
        {
            if (_mapperConfiguration == null)
            {
                var _mapperConfiguration = new MapperConfiguration(config =>
                {
                    config = new MapperConfigurationExpression();
                    config.CreateMap<Model.Company, Data.Company>();
                    config.CreateMap<List<Model.Company>, List<Data.Company>>();
                    config.CreateMap<Data.Company, Model.Company>();
                    config.CreateMap<List<Data.Company>, List<Model.Company>>();
                });
                _mapper = _mapperConfiguration.CreateMapper();
            }
        }
        public Data.Company ToData(Model.Company company)
        {
            return _mapper.Map<Data.Company>(company);
        }

        public List<Data.Company> ToDataList(List<Model.Company> companyList)
        {
            return _mapper.Map<List<Data.Company>>(companyList);
        }

        public Model.Company ToModel(Data.Company company)
        {
            return _mapper.Map<Model.Company>(company);
        }

        public List<Model.Company> ToModelList(List<Data.Company> companyList)
        {
            return _mapper.Map<List<Model.Company>>(companyList);
        }
    }
}
