using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace OpenBox.BLL
{
    public class Customer
    {

        public string email { get; set; }

        public string name { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string zip { get; set; }

        public string locState { get; set; }

        public string locCountry { get; set; }

        public string phone { get; set; }

        public string shippingname { get; set; }

        public string shippingLastName { get; set; }

        public string shippingAddress { get; set; }

        public string ahippingAddress2 { get; set; }

        public string shippingCity { get; set; }

        public string shippingZip { get; set; }

        public string shippingLocState { get; set; }

        public string shippingLocCountry { get; set; }

        public string shippingPhone { get; set; }
     
        public List<SqlDataRecord> GetRecord()
        {
            SqlDataRecord result = new SqlDataRecord(new SqlMetaData[] {
                new SqlMetaData("email", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("name", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("lastName", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("address", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("Address2", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("city", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("zip", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("locState", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("locCountry", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("phone", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingname", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingLastName", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingAddress", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("ShippingAddress2", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingCity", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingZip", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingLocState", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingLocCountry", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("shippingPhone", System.Data.SqlDbType.VarChar, 100) });

            result.SetString(0, this.email ?? "");
            result.SetString(1, this.name ?? "");
            result.SetString(2, this.lastName ?? "");
            result.SetString(3, this.address ?? "");
            result.SetString(4, this.address2 ?? "");
            result.SetString(5, this.city ?? "");
            result.SetString(6, this.zip ?? "");
            result.SetString(7, this.locState ?? "");
            result.SetString(8, this.locCountry ?? "");
            result.SetString(9, this.phone ?? "");
            result.SetString(10, this.shippingname ?? "");
            result.SetString(11, this.shippingLastName ?? "");
            result.SetString(12, this.shippingAddress ?? "");
            result.SetString(13, this.ahippingAddress2 ?? "");
            result.SetString(14, this.shippingCity ?? "");
            result.SetString(15, this.shippingZip ?? "");
            result.SetString(16, this.shippingLocState ?? "");
            result.SetString(17, this.shippingLocCountry ?? "");
            result.SetString(18, this.shippingPhone ?? "");

            return new List<SqlDataRecord>() { result };
        }
           
    }
}
