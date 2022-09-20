using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{
    /// <summary>
    /// Summary description for fmg_transaction
    /// </summary>
    public class fmg_transaction : orclconnection
    {
        public fmg_transaction()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet gbind(string comecode, string todate, string fromdate, string bookingid, string client, string date, string agency, string insertid, string padtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fmgdatabid", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comecode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "")
                {
                    if (date == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (date == "mm/dd/yyyy")
                        {
                            string[] arr = todate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            todate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (date == "yyyy/mm/dd")
                            {
                                string[] arr = todate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                todate = mm + "/" + dd + "/" + yy;
                            }

                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                //prm2.Value = todate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate != "")
                {
                    if (date == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (date == "mm/dd/yyyy")
                        {
                            string[] arr = fromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            fromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (date == "yyyy/mm/dd")
                            {
                                string[] arr = fromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                fromdate = mm + "/" + dd + "/" + yy;
                            }

                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                //prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("bookingid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookingid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = agency;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("insertid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = insertid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_adtye", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = padtype;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("extra", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




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
                objOracleConnection.Close();
            }
        }
    }
}
