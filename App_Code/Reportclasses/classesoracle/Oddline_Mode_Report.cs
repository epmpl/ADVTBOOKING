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
namespace NewAdbooking.Report.classesoracle
{
    /// <summary>
    /// Summary description for Oddline_Mode_Report
    /// </summary>
    public class Oddline_Mode_Report : orclconnection
    {
        public Oddline_Mode_Report()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet run_offline(string agency,string from_date,string to_date,string compcode,string status,string dateformat,string user_id,string chk_access )
        {
            
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("offline_report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (agency == "0" || agency == "")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = agency;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("fromdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (from_date == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = from_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        from_date = mm + "/" + dd + "/" + yy;


                    }

                    prm2.Value = Convert.ToDateTime(from_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("dateto", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (to_date == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = to_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        to_date = mm + "/" + dd + "/" + yy;


                    }

                    prm3.Value = Convert.ToDateTime(to_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (compcode == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = compcode;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("status", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (status == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = status;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("puserid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = user_id;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("chk_access", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = chk_access;
                objOraclecommand.Parameters.Add(prm8);



                objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
                objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;



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