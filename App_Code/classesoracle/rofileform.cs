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

/// <summary>
/// Summary description for rofileform
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class rofileform: orclconnection
    {
        public rofileform()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet payment(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("paymentmode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
               
                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
                objOracleConnection.Close();
            }

        }

        public DataSet gbind(string comecode1, string paymode, string todate, string fromdate, string client, string taluka, string agency, string publication, string exename, string district, string retainer, string branch, string dateformate, string rostatus, string rono, string bookingid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_ro_filing", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = comecode1;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("ppaymode", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                if (paymode == "0" || paymode == "")
                    prm21.Value = System.DBNull.Value;
                else
                    prm21.Value = paymode;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("ptodate", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];

                    todate = mm + "/" + dd + "/" + yy;


                }
                prm22.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pfromdate", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];

                    fromdate = mm + "/" + dd + "/" + yy;


                }
                prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pclient", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = client;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("ptaluka", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                if (taluka == "0" || taluka == "")
                    prm25.Value = System.DBNull.Value;
                else
                    prm25.Value = taluka;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = agency;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("ppcenter", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                if (publication == "All" || publication == "")
                    prm27.Value = System.DBNull.Value;
                else
                    prm27.Value = publication;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("pexename", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = exename;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pdistrict", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                if (district == "0" || district == "" || district == "--Select District--")
                    prm29.Value = System.DBNull.Value;
                else
                    prm29.Value = district;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm20 = new OracleParameter("pretainer", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = retainer;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm1 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                    prm1.Value = System.DBNull.Value;
                else
                    prm1.Value = branch;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("pdateformate", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = dateformate;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("prodocstatus", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (rostatus == "0" || rostatus == "")
                    prm12.Value = System.DBNull.Value;
                else
                    prm12.Value = rostatus;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pbookingid", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (bookingid == "0" || bookingid == "")
                    prm13.Value = System.DBNull.Value;
                else
                    prm13.Value = bookingid;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("prono", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (rono == "0" || rono == "")
                    prm14.Value = System.DBNull.Value;
                else
                    prm14.Value = rono;
                objOraclecommand.Parameters.Add(prm14);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
                objOracleConnection.Close();
            }

        }

        public DataSet executeauditmast2(string cioid,string compcode ,string tick)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updaterofile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("tick", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (tick == "0" || tick == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = tick;
                }
                objOraclecommand.Parameters.Add(prm3);


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
                objOracleConnection.Close();
            }

        }
        public DataSet fetchamt(string bookingid ,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetch_reciptamt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pbkid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bookingid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
                objOracleConnection.Close();
            }

        }
        public DataSet savecomment(string cioid, string compcode, string comment)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updaterofile_comment", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("comment1", OracleType.VarChar, 500);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = comment;
                objOraclecommand.Parameters.Add(prm3);


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
                objOracleConnection.Close();
            }

        }
//======================It will get all Exec active and Inactive===================================//
        public DataSet getExec(string compcode, string execname, string value, string center)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getExec_rofile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execname", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = execname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;



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
        //======================It will get all Retainer active and Inactive===================================//
        public DataSet getretainer(string compcode, string center, string centermain)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("GETRETAINER_ROFILE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PUBCENTER", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = center;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centermain;
                objOraclecommand.Parameters.Add(prm3);


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
        //======================It will get all AGency active and Inactive===================================//
        public DataSet bindagency(string compcode, string userid, string agency, string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforbooking_rofile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objOraclecommand.Parameters.Add(prm4);

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
