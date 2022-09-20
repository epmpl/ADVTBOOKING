using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

namespace NewAdbooking.classesoracle
{
    /// <summary>
    /// Summary description for reportmisbookingid
    /// </summary>
    public class reportmisbookingid : orclconnection
    {
        public reportmisbookingid()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindbookingid(string fromDate, string toDate)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getMissingId.getMissingId_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.DateTime);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Convert.ToDateTime(fromDate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("todate", OracleType.DateTime);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Convert.ToDateTime(toDate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }
    }
}