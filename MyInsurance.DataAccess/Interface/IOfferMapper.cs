using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.DataAccess.Interface
{
   public interface IOfferMapper
    {
        Model.Offer ToModel(Data.Offer offer);
        List<Model.Offer> ToModelList(List<Data.Offer> offerList);
        Data.Offer ToData(Model.Offer offer);
        List<Data.Offer> ToDataList(List<Model.Offer> offerList);
    }
}
