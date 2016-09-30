using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace OpenBox.BLL
{
    public class Payment
    {
        public string id { get; set; }

        public decimal amount { get; set; }

        public string currency { get; set; }

        public string method { get; set; }

        public string processor { get; set; }

        public string response { get; set; }

        public string msg { get; set; }


        public List<SqlDataRecord> GetRecord()
        {
            SqlDataRecord result = new SqlDataRecord(new SqlMetaData[] {
                new SqlMetaData("id", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("amount", System.Data.SqlDbType.Decimal, 9, 2),
                new SqlMetaData("currency", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("method", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("processor", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("response", System.Data.SqlDbType.VarChar, 100),
                new SqlMetaData("msg", System.Data.SqlDbType.VarChar, 100) });

            result.SetString(0, this.id ?? "");
            result.SetDecimal(1, this.amount);
            result.SetString(2, this.currency ?? "USD");
            result.SetString(3, this.method ?? "");
            result.SetString(4, this.processor ?? "");
            result.SetString(5, this.response ?? "");
            result.SetString(6, this.msg ?? "");

            return new List<SqlDataRecord>() { result };
        }
    }
}
