using MyInsurance.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Data;
using MyInsurance.Model;
using AutoMapper;
using AutoMapper.Configuration;

namespace MyInsurance.DataAccess.Mappers
{
    //Todo : Mapper için daha base bir yapı kurulabilir.
    public class OfferMapper : IOfferMapper
    {
        private static MapperConfiguration _mapperConfiguration { get; set; }
        public static IMapper _mapper { get; set; }
        public OfferMapper()
        {
            if (_mapperConfiguration == null)
            {
                var _mapperConfiguration = new MapperConfiguration(config =>
                {
                    config = new MapperConfigurationExpression();
                    config.CreateMap<Model.Offer, Data.Offer>();
                    config.CreateMap<List<Model.Offer>, List<Data.Offer>>();
                    config.CreateMap<Data.Offer, Model.Offer>();
                    config.CreateMap<List<Data.Offer>, List<Model.Offer>>();
                });
                _mapper = _mapperConfiguration.CreateMapper();
            }
        }
        public Data.Offer ToData(Model.Offer offer)
        {
            return _mapper.Map<Data.Offer>(offer);
        }

        public List<Data.Offer> ToDataList(List<Model.Offer> offerList)
        {
            return _mapper.Map<List<Data.Offer>>(offerList);
        }

        public Model.Offer ToModel(Data.Offer offer)
        {
            return _mapper.Map<Model.Offer>(offer);
        }

        public List<Model.Offer> ToModelList(List<Data.Offer> offerList)
        {
            return _mapper.Map<List<Model.Offer>>(offerList);
        }
    }
}
