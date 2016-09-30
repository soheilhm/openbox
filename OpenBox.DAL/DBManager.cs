using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBox.DAL
{
    /// <summary>
    /// Manages access to database.
    /// </summary>
    public static class DBManager
    {

        #region Access Methods (public)

        /// <summary>
        /// Creates a new OpenBox offer from a return request detail.
        /// </summary>
        /// <param name="returnDetailId">Row id (idCancelDetail) from CancelOrderDetail</param>
        /// <seealso cref="ExecuteSPNonQuery(string, IEnumerable{SqlParameter})"/>
        static public void Offers_Insert(int returnDetailId)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@returnDetailId", returnDetailId));

            ExecuteSPNonQuery(nameof(Offers_Insert), p);
        }

        /// <summary>
        /// Gets a list of OpenBox offers from search criteria.
        /// </summary>
        /// <param name="location">2-letter state code</param>
        /// <param name="tags">comma-separated list of search keywords</param>
        /// <param name="priceMin">minimum price (can be null for "no minimum" search)</param>
        /// <param name="priceMax">maximum price (can be null for "no maximum" search)</param>
        /// <returns>List of Offers matching the conditions</returns>
        /// <seealso cref="ExecuteSP(string, IEnumerable{SqlParameter})"/>
        static public List<dynamic> Offers_Search(string location, string tags, decimal? priceMin, decimal? priceMax)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@location", location));
            p.Add(new SqlParameter("@tags", tags));
            if (priceMin.HasValue)
            {
                p.Add(new SqlParameter("@priceMin", priceMin.Value));
            }
            if (priceMax.HasValue)
            {
                p.Add(new SqlParameter("@priceMax", priceMax.Value));
            }
            
            DataSet ds = ExecuteSP(nameof(Offers_Search), p);

            List<object> result = new List<object>();

            foreach(DataRow r in ds.Tables[0].Rows)
            {
                result.Add(new { returnDetailId = r["returnDetailId"], productId = r["productId"], quantity = r["quantity"], price = r["price"], title = r["title"], brandId = r["brandId"] });
            }

            return result;

        }

        /// <summary>
        /// Gets an OpenBox offer from the return request detail id.
        /// </summary>
        /// <param name="returnDetailId">Row id (idCancelDetail) from CancelOrderDetail</param>
        /// <returns></returns>
        /// <seealso cref="ExecuteSP(string, IEnumerable{SqlParameter})"/>
        static public dynamic Offers_Select(int returnDetailId)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@returnDetailId", returnDetailId));

            DataSet ds = ExecuteSP(nameof(Offers_Select), p);

            if (ds.Tables.Count < 2)
            {
                return null;
            }

            DataRow drOffer = ds.Tables[ds.Tables.Count - 2].Rows[0];

            return new {
                product = ds,
                offer = new {
                    returnDetailId = drOffer["returnDetailId"],
                    productId = drOffer["productId"],
                    brandId = drOffer["brandId"],
                    quantity = drOffer["quantity"],
                    price = drOffer["price"],
                    location = drOffer["location"],
                    title = drOffer["title"],
                    notes = drOffer["notes"],
                    bookedBy = drOffer["bookedBy"],
                    sold = drOffer["sold"]
                },
                options = (from dr in ds.Tables[ds.Tables.Count - 1].Select() select dr["idoption"]).ToList()
            };
        }

        /// <summary>
        /// Resets all booking on OpenBox offers that have expired.
        /// </summary>
        static public void Offers_Reset()
        {
            ExecuteSPNonQuery(nameof(Offers_Reset), null);
        }

        /// <summary>
        /// Books an OpenBox offer so that it cannot be bought by several customers simultaneously.
        /// </summary>
        /// <param name="returnDetailId"></param>
        /// <returns>A Guid that identifies the user as having booked the offer or null if booking failed</returns>
        /// <seealso cref="ExecuteSPScalar(string, IEnumerable{SqlParameter})"/>
        public static Guid Offers_Book(int returnDetailId)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@returnDetailId", returnDetailId));

            Guid result = (Guid)ExecuteSPScalar(nameof(Offers_Book), p);

            return result;
        }

        /// <summary>
        /// Extends a booking on an OpenBox offer so that it cannot be bought by several customers simultaneously.
        /// </summary>
        /// <param name="returnDetailId"></param>
        /// <param name="guid"></param>
        /// <returns>The <paramref name="guid"/> if booking was successfully updated or null if it failed</returns>
        /// <seealso cref="ExecuteSPScalar(string, IEnumerable{SqlParameter})"/>
        public static Guid Offers_Book(int returnDetailId, Guid guid)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@returnDetailId", returnDetailId));
            p.Add(new SqlParameter("@guid", guid));

            Guid result = (Guid)ExecuteSPScalar(nameof(Offers_Book), p);

            return result;
        }

        /// <summary>
        /// Places an order on an OpenBox offer.
        /// </summary>
        /// <param name="returnDetailId">offer id (also return request detail id, see <see cref="Offers_Insert(int)"/>)</param>
        /// <param name="guid">booking id (order will not be placed if guid is invalid)</param>
        /// <param name="customer">customer details (email, name, address...)</param>
        /// <param name="transaction">transaction details (amount, method...)</param>
        /// <returns>Order id, if successfully placed</returns>
        /// <remarks>
        /// Several cases may happen in regards to the <paramref name="guid"/>.
        /// <para>
        /// The offer has the same booking guid: the offer is currently booked by the customer and the order can be placed.
        /// </para>
        /// <para>
        /// The offer has no booking guid: the booking has expired. It will be restarted so that the order can be placed.
        /// </para>
        /// <para>
        /// The offer has a different booking guid: the booking has expired and someone else has booked it instead. The order cannot be placed anymore.
        /// </para>
        /// </remarks>
        static public int? Orders_Insert(int returnDetailId, Guid guid, Object customer, object transaction)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@returnDetailId", returnDetailId));
            p.Add(new SqlParameter("@guid", guid));
            p.Add(new SqlParameter("@customer", customer) { SqlDbType = SqlDbType.Structured });
            p.Add(new SqlParameter("@transaction", transaction) { SqlDbType = SqlDbType.Structured });

            int? result = null;
            object spResult = ExecuteSPScalar(nameof(Orders_Insert), p);
            if(spResult != DBNull.Value) { result = (int)spResult; }

            return result;
        }

        #endregion

        #region Direct Access (private)

        /// <summary>
        /// Gets connection string from configuration file
        /// </summary>
        static private string DBConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["OpenBox"].ConnectionString;
            }
        }

        /// <summary>
        /// Executes an SP that's expected to return values. Uses <see cref="DBConnection"/> as connection.
        /// </summary>
        /// <param name="spName">Stored Procedure name (method returns null if this is empty)</param>
        /// <param name="parameters">Enumeration of parameters (can be empty or null)</param>
        /// <returns>DataSet with all tables returned by the stored procedure</returns>
        static private DataSet ExecuteSP(string spName, IEnumerable<SqlParameter> parameters)
        {
            if (string.IsNullOrEmpty(spName))
            {
                return null;
            }

            DataSet result = new DataSet();

            using(SqlConnection cnx = new SqlConnection(DBManager.DBConnection))
            {
                using(SqlCommand cmd = new SqlCommand(spName, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                }
            }

            return result;
        }

        /// <summary>
        /// Executes an SP that's expected to return a single value. Uses <see cref="DBConnection"/> as connection.
        /// </summary>
        /// <param name="spName">Stored Procedure name (method returns null if this is empty)</param>
        /// <param name="parameters">Enumeration of parameters (can be empty or null)</param>
        /// <returns>Object with the first value in the first field of the first table returned by the stored procedure</returns>
        static private object ExecuteSPScalar(string spName, IEnumerable<SqlParameter> parameters)
        {
            if (string.IsNullOrEmpty(spName))
            {
                return null;
            }

            object result = null;

            using(SqlConnection cnx = new SqlConnection(DBManager.DBConnection))
            {
                using(SqlCommand cmd = new SqlCommand(spName, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    cnx.Open();
                    result = cmd.ExecuteScalar();
                    cnx.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// Executes an SP that's expected to not return values. Uses <see cref="DBConnection"/> as connection.
        /// </summary>
        /// <param name="spName">Stored Procedure name (method returns null if this is empty)</param>
        /// <param name="parameters">Enumeration of parameters (can be empty or null)</param>
        static private void ExecuteSPNonQuery(string spName, IEnumerable<SqlParameter> parameters)
        {
            if (string.IsNullOrEmpty(spName))
            {
                return;
            }

            using (SqlConnection cnx = new SqlConnection(DBManager.DBConnection))
            {
                using (SqlCommand cmd = new SqlCommand(spName, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }

            return;
        }

        #endregion

    }
}
