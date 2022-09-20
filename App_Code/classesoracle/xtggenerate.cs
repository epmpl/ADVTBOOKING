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
    /// Summary description for xtggenerate
    /// </summary>
    public class xtggenerate : orclconnection
    {
        public xtggenerate()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void updatextgmatter(string cioid, string filename, string xtgmatternew, string oldfilename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
         
            objOracleConnection = GetConnection();
         
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatextgmatter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioidnew", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("filename", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = filename;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("xtgmatternew", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = xtgmatternew;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("oldfilename", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = oldfilename;
                objOraclecommand.Parameters.Add(prm4);


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
        public DataSet xtggeneratefile(string compcode, string pubdate, string cioid, string dateformat,string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getXTGMatter_prev", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                
                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if(pubdate=="")
                    prm2.Value =System.DBNull.Value;
                else
                {
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;

                    }

                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    pubdate = mm + "/" + dd + "/" + yy;
                }
                    prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }
                
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cioid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("logincenter", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_getref", OracleType.Cursor);
                objOraclecommand.Parameters["p_getref"].Direction = ParameterDirection.Output;

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