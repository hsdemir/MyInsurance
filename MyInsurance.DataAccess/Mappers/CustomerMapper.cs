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
    public class CustomerMapper
    {
        private static MapperConfiguration _mapperConfiguration { get; set; }
        public static IMapper _mapper { get; set; }
        public CustomerMapper()
        {
            if (_mapperConfiguration == null)
            {
                var _mapperConfiguration = new MapperConfiguration(config =>
                {
                    config = new MapperConfigurationExpression();
                    config.CreateMap<Model.Customer, Data.Customer>();
                    config.CreateMap<List<Model.Customer>, List<Data.Customer>>();
                    config.CreateMap<Data.Customer, Model.Customer>();
                    config.CreateMap<List<Data.Customer>, List<Model.Customer>>();
                });
                _mapper = _mapperConfiguration.CreateMapper();
            }
        }
        public Data.Customer ToData(Model.Customer customer)
        {
            return _mapper.Map<Data.Customer>(customer);
        }

        public List<Data.Customer> ToDataList(List<Model.Customer> customerList)
        {
            return _mapper.Map<List<Data.Customer>>(customerList);
        }

        public Model.Customer ToModel(Data.Customer customer)
        {
            return _mapper.Map<Model.Customer>(customer);
        }

        public List<Model.Customer> ToModelList(List<Data.Customer> customerList)
        {
            return _mapper.Map<List<Model.Customer>>(customerList);
        }
    }
}
