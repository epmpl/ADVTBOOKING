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
    /// Summary description for copyrate1
    /// </summary>
    public class copyrate1 : orclconnection
    {
        public copyrate1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void ratecopy(string srcRCode, string destRCode, string srcRGrCode, string destRGrCode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("copyrate.copyrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("SOURCE_RATE_CODE", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = srcRCode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("DEST_RATE_CODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = destRCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("SOURCE_RATE_GR_CODE", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = srcRGrCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("DEST_RATE_GR_CODE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = destRGrCode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("DATEFORMAT", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.ExecuteNonQuery();
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
