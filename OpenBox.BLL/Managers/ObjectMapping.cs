using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenBox.BLL
{
    static class ObjectMapping
    {

        static internal Offer ConvertToOffer(object dal)
        {
            Offer result = ConvertFromDAL<Offer>(dal);

            return result;
        }

        static internal Product ConvertToProduct(object dal)
        {
            Product result = new Product();

            if (dal == null || dal.GetType() != typeof(System.Data.DataSet)) { return null; }
            System.Data.DataSet ds = (System.Data.DataSet)dal;

            result.productId = (int)ds.Tables[0].Rows[0]["ProductId"];
            result.brandId = Convert.ToInt32(ds.Tables[0].Rows[0]["MfgId"]);
            result.details = (string)ds.Tables[0].Rows[0]["Details"];
            result.sku = (string)ds.Tables[0].Rows[0]["SKU"];

            return result;
        }

        static internal List<Offer> ConvertToOffers(List<object> dal)
        {
            List<Offer> result = new List<Offer>();
            foreach (object o in dal) { result.Add(ConvertToOffer(o)); }
            return result;
        }

        static internal T ConvertFromDAL<T>(object dal) where T : class, new()
        {
            T result = new T();

            if (dal == null) { return null; }

            foreach (FieldInfo p in dal.GetType().GetFields())
            {
                if (result.GetType().GetProperty(p.Name) != null)
                {
                    object value = p.GetValue(dal);
                    if (value == DBNull.Value) { value = null; }
                    result.GetType().GetProperty(p.Name).SetValue(result, value);
                }
            }

            foreach (PropertyInfo p in dal.GetType().GetProperties())
            {
                if (result.GetType().GetProperty(p.Name) != null)
                {
                    object value = p.GetValue(dal, null);
                    if(value == DBNull.Value) { value = null; }
                    result.GetType().GetProperty(p.Name).SetValue(result, value);
                }
            }

            return result;
        }

    }
}
