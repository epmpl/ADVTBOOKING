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
    /// Summary description for publish_status
    /// </summary>
    public class publish_status : orclconnection
    {
        public publish_status()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet websp_updatestatus(string dateformat, string tilldate, string fromdate, string Adtype, string rev)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();


                com = GetCommand("Websp_updatestatus_sambad", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm31 = new OracleParameter("Adtype", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (Adtype != "0")
                {
                    prm31.Value = Adtype;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);
                OracleParameter prm131 = new OracleParameter("rev", OracleType.VarChar);
                prm131.Direction = ParameterDirection.Input;
                if (rev != "0")
                {
                    prm131.Value = rev;
                }
                else
                {
                    prm131.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm131);


                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;



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
        public DataSet bindrevenuecenter(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindrevenuecenter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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

        public DataSet updatestatusnew(string bookingid, string insertion, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatestausnew_sambad.updatestausnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookingid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = insertion;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = edition;
                objOraclecommand.Parameters.Add(prm6);



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