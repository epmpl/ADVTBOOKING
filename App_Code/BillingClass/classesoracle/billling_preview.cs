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
namespace NewAdbooking.BillingClass.classesoracle
{


    /// <summary>
    /// Summary description for billling_preview
    /// </summary>
    public class billling_preview : orclconnection
    {
        public billling_preview()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet selectlastnew_preview(string bookingid, string dateformat, string fromdate, string dateto, string v_invoice, string compcode, string centername)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_Orderlastnew_pre", ref con);
                com.CommandType = CommandType.StoredProcedure;





                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);




                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);










         
                OracleParameter prm26 = new OracleParameter("v_compcode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = compcode;
                com.Parameters.Add(prm26);



                OracleParameter prm141 = new OracleParameter("v_centername", OracleType.VarChar);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = centername;
                com.Parameters.Add(prm141);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_accounts1", OracleType.Cursor);
                com.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


           

                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
    }
}