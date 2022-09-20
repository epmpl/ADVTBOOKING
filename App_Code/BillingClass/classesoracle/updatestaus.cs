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
    /// Summary description for updatestaus
    /// </summary>
    public class updatestaus : orclconnection
    {
        public updatestaus()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet paymode_bind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("an_payment.an_payment_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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

        public DataSet publication_center(string compcode)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("PubCentName1.PubCentName1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;





                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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



        public DataSet websp_bindgridorderwise(string dateformat, string tilldate, string fromdate, string branch, string adtype, string publication, string pub_cent, string edition, string agency, string client, string branchnew, string retainer, string executive, string supplement, string insert_status, string userid, string payment_mode)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_bindorderwise.websp_bindorderwise_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("fromdate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;



                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];

                    fromdate = mm + "/" + dd + "/" + yy;


                }

                prm5.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("todate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = tilldate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    tilldate = mm + "/" + dd + "/" + yy;


                }

                prm6.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("branch", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adtype", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adtype;
                objOraclecommand.Parameters.Add(prm8);

                /////

                OracleParameter prm9 = new OracleParameter("publication", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (publication == "0")
                {
                    prm9.Value = System.DBNull.Value;

                }
                else
                {
                    prm9.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (pub_cent == "0")
                {
                    prm10.Value = System.DBNull.Value;

                }
                else
                {
                    prm10.Value = pub_cent;
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm18 = new OracleParameter("edition", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm18.Value = System.DBNull.Value;

                }
                else
                {
                    prm18.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm28 = new OracleParameter("agency", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (agency == "0" || agency == "")
                {
                    prm28.Value = System.DBNull.Value;

                }
                else
                {
                    prm28.Value = agency;
                }
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm38 = new OracleParameter("client", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                if (client == "0" || client == "")
                {
                    prm38.Value = System.DBNull.Value;

                }
                else
                {

                    prm38.Value = client;
                }
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm48 = new OracleParameter("branchnew", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                if ((branchnew == "") || (branchnew == "0"))
                {
                    prm48.Value = System.DBNull.Value;

                }
                else
                {
                    prm48.Value = branchnew;
                }
                objOraclecommand.Parameters.Add(prm48);


                ////

                OracleParameter prm51 = new OracleParameter("v_retainer", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                if (retainer == "0" || retainer == "")
                {
                    prm51.Value = System.DBNull.Value;

                }
                else
                {
                    prm51.Value = retainer;
                }
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm49 = new OracleParameter("v_executive", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                if (executive == "0" || executive == "")
                {
                    prm49.Value = System.DBNull.Value;

                }
                else
                {
                    prm49.Value = executive;
                }
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("v_supplement", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (supplement == "")
                {
                    prm50.Value = System.DBNull.Value;

                }
                else
                {
                    prm50.Value = supplement;
                }
                objOraclecommand.Parameters.Add(prm50);



                OracleParameter prm150 = new OracleParameter("v_insert_status", OracleType.VarChar);
                prm150.Direction = ParameterDirection.Input;
                if (insert_status == "0")
                {
                    prm150.Value = System.DBNull.Value;

                }
                else
                {
                    prm150.Value = insert_status;
                }
                objOraclecommand.Parameters.Add(prm150);



                OracleParameter prm16 = new OracleParameter("v_userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm151 = new OracleParameter("v_payment_mode", OracleType.VarChar);
                prm151.Direction = ParameterDirection.Input;
                if (payment_mode == "0")
                {
                    prm151.Value = System.DBNull.Value;

                }
                else
                {
                    prm151.Value = payment_mode;
                }
                objOraclecommand.Parameters.Add(prm151);




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
                objOracleConnection.Close();
            }
        }


        public DataSet updatestatus_order(string bookingid, string insertion, string edition,string from_date,string date_format)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatestaus_orderwise.updatestaus_orderwise_p", ref objOracleConnection);
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

                OracleParameter prm17 = new OracleParameter("v_from_date", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;

                if (date_format == "dd/mm/yyyy")
                {
                    string[] arr = from_date.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    from_date = mm + "/" + dd + "/" + yy;


                }

                prm17.Value = Convert.ToDateTime(from_date).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm17);




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