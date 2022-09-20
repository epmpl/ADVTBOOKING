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
/// Summary description for RateMaster
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class RateMaster : orclconnection
    {
        public RateMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet fetch_priority_rate(string rateid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetchPriorityRate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rateidm", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = rateid;
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
        public string insert_priority_rate(string rateuniqueid, string data, string status)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insert_priorityrate_details", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("rateidm", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_str", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = data;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("STATUS", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = status;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_error_text", OracleType.VarChar, 200);
                objOraclecommand.Parameters["p_error_text"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                string output = objOraclecommand.Parameters["p_error_text"].Value.ToString();


                return output;

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
        public DataSet getEditionDetail(string pkgdesc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getEditionDetail_pri", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pkgdesc", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pkgdesc;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

             

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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
        public DataSet autogenrated(string compcode, string auto)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getautocoderate.getautocoderate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("auto", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = auto;
                objOraclecommand.Parameters.Add(prm2);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet bindscheme(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("schemebind.schemebind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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


        public DataSet getpremiumval(string compcode, string premium)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("gatvalpremium.gatvalpremium_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("premium", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = premium;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet ratecodecheck(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string agencycode, string dateformat, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkratecode.chkratecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("uom", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = uom;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = fromdate.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            fromdate = mm + "/" + dd + "/" + yy;
                        }

                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = todate.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            todate = mm + "/" + dd + "/" + yy;
                        }
                prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adtype1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adtype;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("color", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = color;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("package1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = package;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("currency", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = currency;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("adscat6", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = adscat6;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("adscat5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = adscat5;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("adscat4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = adscat4;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premium", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = premium;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizeto", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sizeto;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("frominsert", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = frominsert;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("toinsert", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = toinsert;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("clientcat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = clientcat;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("minadarea", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm21.Value = "0";
                }
                else
                {
                    prm21.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = "";
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("agencycode", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = agencycode;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm24);


                //objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                //objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet soloratechk(string compcode, string ratecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chksolocode.chksolocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet soloratebind(string compcode, string ratecode, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindsolorate.bindsolorate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet chkpkgrate(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chksolopackage.chksolopackage_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("todate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = todate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = color;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("package", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = package;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("uom", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = uom;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("adscat6", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = adscat6;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("adscat5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = adscat5;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("adscat4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = adscat4;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premium", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = premium;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizeto", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sizeto;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("frominsert", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = frominsert;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("toinsert", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = toinsert;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("clientcat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = clientcat;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("minadarea", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm21.Value = "0";
                }
                else
                {
                    prm21.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("type", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm24 = new OracleParameter("agencycode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = agencycode;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm23 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm23);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet insertratecode(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertratecode.insertratecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("datefrom", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = datefrom;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateto;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ratecode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ratecode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adtype", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("rategroupcode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rategroupcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adcategory", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adcategory;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("package", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = package;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("premium", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = premium;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("premiumval", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = premiumval;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("packagedesc", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = packagedesc;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("uom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = uom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (sizefrom == "" || sizefrom == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = sizefrom;
                }
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("sizeto", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (sizeto == "" || sizeto == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = sizeto;
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("consumption", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (consumption == "" || consumption == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = consumption;
                }
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("color", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = color;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("flramount", OracleType.Double);
                prm21.Direction = ParameterDirection.Input;
                if (flramount == "" || flramount == null)
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    prm21.Value = Convert.ToDouble(flramount);
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("remarks", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = remarks;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("colorchrty", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = colorchrty;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("weekdrate", OracleType.Double);
                prm24.Direction = ParameterDirection.Input;
                if (weekdrate == "" || weekdrate == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDecimal(weekdrate);
                }
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("weeminrate", OracleType.Double);
                prm25.Direction = ParameterDirection.Input;
                if (weeminrate == "" || weeminrate == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(weeminrate);
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("extweerate", OracleType.Double);
                prm26.Direction = ParameterDirection.Input;
                if (extweerate == "" || extweerate == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToDouble(extweerate);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("focusdarate", OracleType.Double);
                prm27.Direction = ParameterDirection.Input;
                if (focusdarate == "" || focusdarate == null)
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    prm27.Value = Convert.ToDouble(focusdarate);
                }
                objOraclecommand.Parameters.Add(prm27);


                OracleParameter prm28 = new OracleParameter("focminrate", OracleType.Double);
                prm28.Direction = ParameterDirection.Input;
                if (focminrate == "" || focminrate == null)
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDouble(focminrate);
                }
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("focexrate", OracleType.Double);
                prm29.Direction = ParameterDirection.Input;
                if (focexrate == "" || focexrate == null)
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDouble(focexrate);
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validfromdate", OracleType.DateTime);
                prm30.Direction = ParameterDirection.Input;
                if (validfromdate == "" || validfromdate == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate = mm + "/" + dd + "/" + yy;
                            }

                    prm30.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("validtill", OracleType.DateTime);
                prm31.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null)
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill = mm + "/" + dd + "/" + yy;
                            }

                    prm31.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm31);

                //Convert.ToDateTime();
                OracleParameter prm32 = new OracleParameter("weekendrate", OracleType.Double);
                prm32.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm32.Value = System.DBNull.Value;
                }
                else
                {
                    prm32.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm32);


                OracleParameter prm33 = new OracleParameter("weekendmin", OracleType.Double);
                prm33.Direction = ParameterDirection.Input;
                if (weekendmin == "" || weekendmin == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDouble(weekendmin);
                }
                objOraclecommand.Parameters.Add(prm33);


                OracleParameter prm34 = new OracleParameter("weekendextra", OracleType.Double);
                prm34.Direction = ParameterDirection.Input;
                if (weekendextra == "" || weekendextra == null)
                {
                    prm34.Value = System.DBNull.Value;
                }
                else
                {
                    prm34.Value = Convert.ToDouble(weekendextra);
                }
                objOraclecommand.Parameters.Add(prm34);


                OracleParameter prm35 = new OracleParameter("combination", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = combination;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("insertsolo", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = insertsolo;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("minadarea", OracleType.Double);
                prm37.Direction = ParameterDirection.Input;
                if (minadarea == "" || minadarea == null)
                {
                    prm37.Value = Convert.ToDouble("0");
                }
                else
                {
                    prm37.Value = Convert.ToDouble(minadarea);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("editionfrom", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                if (editionfrom == "" || editionfrom == null)
                {
                    prm38.Value = System.DBNull.Value;
                }
                else
                {
                    prm38.Value = Convert.ToInt32(editionfrom);
                }
                objOraclecommand.Parameters.Add(prm38);


                OracleParameter prm39 = new OracleParameter("editionto", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                if (editionfrom == "" || editionfrom == null)
                {
                    prm39.Value = System.DBNull.Value;
                }
                else
                {
                    prm39.Value = Convert.ToInt32(editionto);
                }
                objOraclecommand.Parameters.Add(prm39);


                OracleParameter prm40 = new OracleParameter("scheme", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = scheme;
                objOraclecommand.Parameters.Add(prm40);



                OracleParameter prm41 = new OracleParameter("adscat6", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = adscat6;
                objOraclecommand.Parameters.Add(prm41);



                OracleParameter prm42 = new OracleParameter("adscat5", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = adscat5;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("adscat4", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adscat4;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("frominsert", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                if (frominsert == "" || frominsert == null)
                {
                    prm44.Value = System.DBNull.Value;
                }
                else
                {
                    prm44.Value = frominsert;
                }
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("toinsert", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                if (toinsert == "" || toinsert == null)
                {
                    prm45.Value = System.DBNull.Value;
                }
                else
                {
                    prm45.Value = toinsert;
                }
                objOraclecommand.Parameters.Add(prm45);


                OracleParameter prm46 = new OracleParameter("agtype", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = agtype;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("clientcat", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = clientcat;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("max_area", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = max_area;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("type", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = type;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("agencycode", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = agencycode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm51 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("rate_sun", OracleType.Number);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = Convert.ToDouble(rate_sun);
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("rate_mon", OracleType.Number);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = Convert.ToDouble(rate_mon);
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("rate_tue", OracleType.Number);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = Convert.ToDouble(rate_tue);
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("rate_wed", OracleType.Number);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = Convert.ToDouble(rate_wed);
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm56 = new OracleParameter("rate_thu", OracleType.Number);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = Convert.ToDouble(rate_thu);
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("rate_fri", OracleType.Number);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = Convert.ToDouble(rate_fri);
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("rate_sat", OracleType.Number);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = Convert.ToDouble(rate_sat);
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("rate_sun_extra", OracleType.Number);
                prm59.Direction = ParameterDirection.Input;
                if (rate_sun_extra == "")
                {
                    prm59.Value = 0;
                }
                else
                {
                    prm59.Value = Convert.ToDouble(rate_sun_extra);
                }
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("rate_mon_extra", OracleType.Number);
                prm60.Direction = ParameterDirection.Input;
                if (rate_mon_extra == "")
                {
                    prm60.Value = 0;
                }
                else
                {
                    prm60.Value = Convert.ToDouble(rate_mon_extra);
                }
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("rate_tue_extra", OracleType.Number);
                prm61.Direction = ParameterDirection.Input;
                if (rate_tue_extra == "")
                {
                    prm61.Value = 0;
                }
                else
                {
                    prm61.Value = Convert.ToDouble(rate_tue_extra);
                }
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm62 = new OracleParameter("rate_wed_extra", OracleType.Number);
                prm62.Direction = ParameterDirection.Input;
                if (rate_wed_extra == "")
                {
                    prm62.Value = 0;
                }
                else
                {
                    prm62.Value = Convert.ToDouble(rate_wed_extra);
                }
                objOraclecommand.Parameters.Add(prm62);

                OracleParameter prm63 = new OracleParameter("rate_thu_extra", OracleType.Number);
                prm63.Direction = ParameterDirection.Input;
                if (rate_thu_extra == "")
                {
                    prm63.Value = 0;
                }
                else
                {
                    prm63.Value = Convert.ToDouble(rate_thu_extra);
                }
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm64 = new OracleParameter("rate_fri_extra", OracleType.Number);
                prm64.Direction = ParameterDirection.Input;
                if (rate_fri_extra == "")
                {
                    prm64.Value = 0;
                }
                else
                {
                    prm64.Value = Convert.ToDouble(rate_fri_extra);
                }
                objOraclecommand.Parameters.Add(prm64);

                OracleParameter prm65 = new OracleParameter("rate_sat_extra", OracleType.Number);
                prm65.Direction = ParameterDirection.Input;
                if (rate_sat_extra == "")
                {
                    prm65.Value = 0;
                }
                else
                {
                    prm65.Value = Convert.ToDouble(rate_sat_extra);
                }
                objOraclecommand.Parameters.Add(prm65);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet soloinsert(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string flag, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertsolorate.insertsolorate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("datefrom", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (datefrom == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datefrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datefrom = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = datefrom.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            datefrom = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = datefrom.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                datefrom = mm + "/" + dd + "/" + yy;
                            }

                    prm4.Value = Convert.ToDateTime(datefrom).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = dateto.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            dateto = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = dateto.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                dateto = mm + "/" + dd + "/" + yy;
                            }

                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ratecode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adtype1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("rategroupcode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rategroupcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adcategory", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adcategory;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("package1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = package;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("premium", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = premium;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("premiumval", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = premiumval;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("packagedesc", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = packagedesc;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("uom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = uom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (sizefrom == "" || sizefrom == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = Convert.ToDouble(sizefrom);
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("sizeto", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (sizeto == "" || sizeto == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = Convert.ToDouble(sizeto);
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("consumption", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (consumption == "" || consumption == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = Convert.ToDouble(consumption);
                }
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("color", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = color;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("remarks", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = remarks;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("colorchrty", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = colorchrty;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("weekdrate", OracleType.Double);
                prm23.Direction = ParameterDirection.Input;
                if (weekdrate == "" || weekdrate == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDouble(weekdrate);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("weeminrate", OracleType.Double);
                prm24.Direction = ParameterDirection.Input;
                if (weeminrate == "" || weeminrate == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDouble(weeminrate);
                }
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("extweerate", OracleType.Double);
                prm25.Direction = ParameterDirection.Input;
                if (extweerate == "" || extweerate == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(extweerate);
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("focusdarate", OracleType.Double);
                prm26.Direction = ParameterDirection.Input;
                if (focusdarate == "" || focusdarate == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToDouble(focusdarate);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("focminrate", OracleType.Double);
                prm27.Direction = ParameterDirection.Input;
                if (focminrate == "" || focminrate == null)
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    prm27.Value = Convert.ToDouble(focminrate);
                }
                objOraclecommand.Parameters.Add(prm27);



                OracleParameter prm28 = new OracleParameter("focexrate", OracleType.Double);
                prm28.Direction = ParameterDirection.Input;
                if (focexrate == "" || focexrate == null)
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDouble(focexrate);
                }
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("validfromdate", OracleType.DateTime);
                prm29.Direction = ParameterDirection.Input;
                if (validfromdate == "" || validfromdate == null)
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate = mm + "/" + dd + "/" + yy;
                            }

                    prm29.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validtill", OracleType.DateTime);
                prm30.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill = mm + "/" + dd + "/" + yy;
                            }

                    prm30.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm30);

                //Convert.ToDateTime();
                OracleParameter prm31 = new OracleParameter("weekendrate", OracleType.Double);
                prm31.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    prm31.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("weekendmin", OracleType.Double);
                prm32.Direction = ParameterDirection.Input;
                if (weekendmin == "" || weekendmin == null)
                {
                    prm32.Value = System.DBNull.Value;
                }
                else
                {
                    prm32.Value = Convert.ToDouble(weekendmin);
                }
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("weekendextra", OracleType.Double);
                prm33.Direction = ParameterDirection.Input;
                if (weekendextra == "" || weekendextra == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDouble(weekendextra);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("combination", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = combination;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("insertsolo", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = insertsolo;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("flag", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = flag;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("adscat6", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = adscat6;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("adscat5", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = adscat5;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("adscat4", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = adscat4;
                objOraclecommand.Parameters.Add(prm39);


                OracleParameter prm40 = new OracleParameter("frominsert", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                if (frominsert == "" || frominsert == null)
                {
                    prm40.Value = System.DBNull.Value;
                }
                else
                {
                    prm40.Value = Convert.ToDouble(frominsert);
                }
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("toinsert", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                if (toinsert == "" || toinsert == null)
                {
                    prm41.Value = System.DBNull.Value;
                }
                else
                {
                    prm41.Value = Convert.ToDouble(toinsert);
                }
                objOraclecommand.Parameters.Add(prm41);


                OracleParameter prm42 = new OracleParameter("agtype", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = agtype;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("clientcat", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = clientcat;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("minadarea", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm44.Value = "0";
                }
                else
                {
                    prm44.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("type1", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = type;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("agencycode", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = agencycode;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm47);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet solorateget(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getsolorate.getsolorate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm6 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ratecode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adtype1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("rategroupcode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rategroupcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adcategory", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adcategory;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("package1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = package;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm15 = new OracleParameter("packagedesc", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = packagedesc;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("uom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = uom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (sizefrom == "" || sizefrom == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = sizefrom;
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("sizeto", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (sizeto == "" || sizeto == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = sizeto;
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("consumption", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (consumption == "" || consumption == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = consumption;
                }
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("color", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = color;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm23 = new OracleParameter("weekdrate", OracleType.Double);
                prm23.Direction = ParameterDirection.Input;
                if (weekdrate == "" || weekdrate == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDouble(weekdrate);
                }
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("weeminrate", OracleType.Double);
                prm24.Direction = ParameterDirection.Input;
                if (weeminrate == "" || weeminrate == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDouble(weeminrate);
                }
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("extweerate", OracleType.Double);
                prm25.Direction = ParameterDirection.Input;
                if (extweerate == "" || extweerate == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(extweerate);
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("focusdarate", OracleType.Double);
                prm26.Direction = ParameterDirection.Input;
                if (focusdarate == "" || focusdarate == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToDouble(focusdarate);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("focminrate", OracleType.Double);
                prm27.Direction = ParameterDirection.Input;
                if (focminrate == "" || focminrate == null)
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    prm27.Value = Convert.ToDouble(focminrate);
                }
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("focexrate", OracleType.Double);
                prm28.Direction = ParameterDirection.Input;
                if (focexrate == "" || focexrate == null)
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDouble(focexrate);
                }
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("validfromdate", OracleType.DateTime);
                prm29.Direction = ParameterDirection.Input;
                if (validfromdate == "" || validfromdate == null)
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate = mm + "/" + dd + "/" + yy;
                            }

                    prm29.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validtill", OracleType.DateTime);
                prm30.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill = mm + "/" + dd + "/" + yy;
                            }

                    prm30.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm21 = new OracleParameter("remarks", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = remarks;
                objOraclecommand.Parameters.Add(prm21);


                OracleParameter prm14 = new OracleParameter("premiumval", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = premiumval;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm13 = new OracleParameter("premium", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = premium;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm31 = new OracleParameter("weekendrate", OracleType.Double);
                prm31.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    prm31.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("weekendmin", OracleType.Double);
                prm32.Direction = ParameterDirection.Input;
                if (weekendmin == "" || weekendmin == null)
                {
                    prm32.Value = System.DBNull.Value;
                }
                else
                {
                    prm32.Value = Convert.ToDouble(weekendmin);
                }
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("weekendextra", OracleType.Double);
                prm33.Direction = ParameterDirection.Input;
                if (weekendextra == "" || weekendextra == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDouble(weekendextra);
                }
                objOraclecommand.Parameters.Add(prm33);


                OracleParameter prm34 = new OracleParameter("combination", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = combination;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("insertsolo", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = insertsolo;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter prm4 = new OracleParameter("datefrom", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (datefrom == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datefrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datefrom = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = datefrom.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            datefrom = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = datefrom.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                datefrom = mm + "/" + dd + "/" + yy;
                            }

                    prm4.Value = Convert.ToDateTime(datefrom).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = dateto.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            dateto = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = dateto.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                dateto = mm + "/" + dd + "/" + yy;
                            }

                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm37 = new OracleParameter("clientcat", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm37.Value = "0";
                }
                else
                {
                    prm37.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("minadarea", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = minadarea;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm22 = new OracleParameter("colorchrty", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = colorchrty;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm40 = new OracleParameter("type1", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = type;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm39 = new OracleParameter("agencycode", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = agencycode;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm41 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm41);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet insertintorate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max, string priority, string vat, string Adon, string refrence, string cancellation, string positionprem)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                //string datefrom = validfromdate;
                //string dateto = validtill;
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertratemast.insertratemast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ratecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rategroupcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = rategroupcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("currency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = currency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("package1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = package;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("premium", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = premium;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("premiumval", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = premiumval;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("packagedesc", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = packagedesc;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("uom", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = uom;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (sizefrom == "" || sizefrom == null)
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = sizefrom;
                }
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("sizeto", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (sizeto == "" || sizeto == null)
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = sizeto;
                }
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("consumption", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (consumption == "" || consumption == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = consumption;
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("color", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = color;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("remarks", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = remarks;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("colorchrty", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = colorchrty;
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm21 = new OracleParameter("weekdrate", OracleType.Double);
                prm21.Direction = ParameterDirection.Input;
                if (weekdrate == "" || weekdrate == null)
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    prm21.Value = Convert.ToDouble(weekdrate);
                }
                objOraclecommand.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("weeminrate", OracleType.Double);
                prm22.Direction = ParameterDirection.Input;
                if (weeminrate == "" || weeminrate == null)
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDouble(weeminrate);
                }
                objOraclecommand.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("extweerate", OracleType.Double);
                prm23.Direction = ParameterDirection.Input;
                if (extweerate == "" || extweerate == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDouble(extweerate);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("focusdarate", OracleType.Double);
                prm24.Direction = ParameterDirection.Input;
                if (focusdarate == "" || focusdarate == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDouble(focusdarate);
                }
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("focminrate", OracleType.Double);
                prm25.Direction = ParameterDirection.Input;
                if (focminrate == "" || focminrate == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(focminrate);
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("focexrate", OracleType.Double);
                prm26.Direction = ParameterDirection.Input;
                if (focexrate == "" || focexrate == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToDouble(focexrate);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("validfromdate", OracleType.DateTime);
                prm27.Direction = ParameterDirection.Input;
                if (validfromdate == "" || validfromdate == null)
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate = mm + "/" + dd + "/" + yy;
                            }

                    prm27.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm27);


                OracleParameter prm28 = new OracleParameter("validtill", OracleType.DateTime);
                prm28.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null)
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill = mm + "/" + dd + "/" + yy;
                            }

                    prm28.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm28);


                //Convert.ToDateTime();
                OracleParameter prm29 = new OracleParameter("weekendrate", OracleType.Double);
                prm29.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("weekendmin", OracleType.Double);
                prm30.Direction = ParameterDirection.Input;
                if (weekendmin == "" || weekendmin == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDouble(weekendmin);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("weekendextra", OracleType.Double);
                prm31.Direction = ParameterDirection.Input;
                if (weekendextra == "" || weekendextra == null)
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    prm31.Value = Convert.ToDouble(weekendextra);
                }
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("minadarea", OracleType.Double);
                prm32.Direction = ParameterDirection.Input;
                if (minadarea == "" || minadarea == null)
                {
                    prm32.Value = Convert.ToDouble("0");
                }
                else
                {
                    prm32.Value = Convert.ToDouble(minadarea);
                }
                objOraclecommand.Parameters.Add(prm32);


                OracleParameter prm33 = new OracleParameter("editionfrom", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (editionfrom == "" || editionfrom == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToInt32(editionfrom);
                }
                objOraclecommand.Parameters.Add(prm33);


                OracleParameter prm34 = new OracleParameter("editionto", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                if (editionto == "" || editionto == null)
                {
                    prm34.Value = System.DBNull.Value;
                }
                else
                {
                    prm34.Value = Convert.ToInt32(editionto);
                }
                objOraclecommand.Parameters.Add(prm34);


                OracleParameter prm35 = new OracleParameter("flramount", OracleType.Double);
                prm35.Direction = ParameterDirection.Input;
                if (flramount == "" || flramount == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDouble(flramount);
                }
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter prm36 = new OracleParameter("flrdiscount", OracleType.Double);
                prm36.Direction = ParameterDirection.Input;
                if (flrdiscount == "" || flrdiscount == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDouble(flrdiscount);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("scheme1", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = scheme;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("adscat6", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = adscat6;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("adscat5", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = adscat5;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("adscat4", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = adscat4;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("frominsert", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                if (frominsert == "" || frominsert == null)
                {
                    prm41.Value = System.DBNull.Value;
                }
                else
                {
                    prm41.Value = frominsert;
                }
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("toinsert", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                if (toinsert == "" || toinsert == null)
                {
                    prm42.Value = System.DBNull.Value;
                }
                else
                {
                    prm42.Value = toinsert;
                }
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("agtype", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = agtype;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("clientcat", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = clientcat;
                objOraclecommand.Parameters.Add(prm44);


                OracleParameter prm48 = new OracleParameter("maxadarea", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = max_area;
                objOraclecommand.Parameters.Add(prm48);


                OracleParameter prm49 = new OracleParameter("type1", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = type;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("agencycode", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = agencycode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm51 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("rate_sun", OracleType.Number);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = Convert.ToDouble(rate_sun);
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("rate_mon", OracleType.Number);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = Convert.ToDouble(rate_mon);
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("rate_tue", OracleType.Number);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = Convert.ToDouble(rate_tue);
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("rate_wed", OracleType.Number);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = Convert.ToDouble(rate_wed);
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm56 = new OracleParameter("rate_thu", OracleType.Number);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = Convert.ToDouble(rate_thu);
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("rate_fri", OracleType.Number);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = Convert.ToDouble(rate_fri);
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("rate_sat", OracleType.Number);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = Convert.ToDouble(rate_sat);
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("rate_sun_extra", OracleType.Number);
                prm59.Direction = ParameterDirection.Input;
                if (rate_sun_extra == "")
                {
                    prm59.Value = 0;
                }
                else
                {
                    prm59.Value = Convert.ToDouble(rate_sun_extra);
                }
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("rate_mon_extra", OracleType.Number);
                prm60.Direction = ParameterDirection.Input;
                if (rate_mon_extra == "")
                {
                    prm60.Value = 0;
                }
                else
                {
                    prm60.Value = Convert.ToDouble(rate_mon_extra);
                }
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("rate_tue_extra", OracleType.Number);
                prm61.Direction = ParameterDirection.Input;
                if (rate_tue_extra == "")
                {
                    prm61.Value = 0;
                }
                else
                {
                    prm61.Value = Convert.ToDouble(rate_tue_extra);
                }
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm62 = new OracleParameter("rate_wed_extra", OracleType.Number);
                prm62.Direction = ParameterDirection.Input;
                if (rate_wed_extra == "")
                {
                    prm62.Value = 0;
                }
                else
                {
                    prm62.Value = Convert.ToDouble(rate_wed_extra);
                }
                objOraclecommand.Parameters.Add(prm62);

                OracleParameter prm63 = new OracleParameter("rate_thu_extra", OracleType.Number);
                prm63.Direction = ParameterDirection.Input;
                if (rate_thu_extra == "")
                {
                    prm63.Value = 0;
                }
                else
                {
                    prm63.Value = Convert.ToDouble(rate_thu_extra);
                }
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm64 = new OracleParameter("rate_fri_extra", OracleType.Number);
                prm64.Direction = ParameterDirection.Input;
                if (rate_fri_extra == "")
                {
                    prm64.Value = 0;
                }
                else
                {
                    prm64.Value = Convert.ToDouble(rate_fri_extra);
                }
                objOraclecommand.Parameters.Add(prm64);

                OracleParameter prm65 = new OracleParameter("rate_sat_extra", OracleType.Number);
                prm65.Direction = ParameterDirection.Input;
                if (rate_sat_extra == "")
                {
                    prm65.Value = 0;
                }
                else
                {
                    prm65.Value = Convert.ToDouble(rate_sat_extra);
                }
                objOraclecommand.Parameters.Add(prm65);

                OracleParameter prm66 = new OracleParameter("width_max", OracleType.Number);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = Convert.ToDouble(width_max);
                objOraclecommand.Parameters.Add(prm66);


                OracleParameter prm67 = new OracleParameter("priority_m", OracleType.Number);
                prm67.Direction = ParameterDirection.Input;
                if (priority == "")
                    prm67.Value = System.DBNull.Value;
                else
                    prm67.Value = Convert.ToInt32(priority);
                objOraclecommand.Parameters.Add(prm67);

                OracleParameter prm68 = new OracleParameter("vat", OracleType.VarChar);
                prm68.Direction = ParameterDirection.Input;
                prm68.Value = vat;
                objOraclecommand.Parameters.Add(prm68);

                OracleParameter prm69 = new OracleParameter("Adon1", OracleType.VarChar);
                prm69.Direction = ParameterDirection.Input;
                prm69.Value = Adon;
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("refrence", OracleType.VarChar);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = refrence;
                objOraclecommand.Parameters.Add(prm70);

                OracleParameter prm71 = new OracleParameter("p_cancellation", OracleType.VarChar);
                prm71.Direction=ParameterDirection.Input;
                prm71.Value=cancellation;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("p_Positionprem", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                //if (positionprem=="0")
                //prm72.Value = System.DBNull.Value;
               // else
                prm72.Value = positionprem;
                objOraclecommand.Parameters.Add(prm72);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet executedate(string compcode, string ratecode, string adtype, string currency, string rategroup, string colorcode, string uomcode, string packagecode, string pubcenter, string adcat, string positionprem,string validfrom,string dateformat, string subcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executeratecode.executeratecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                //objOraclecommand.Parameters.Add("@uom", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@uom"].Value = uom;

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adtype;
                }

                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("currency", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (currency == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = currency;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("rategroup", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (rategroup == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = rategroup;
                }

                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("colorcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (colorcode == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = colorcode;
                }

                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("uomcode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (uomcode == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = uomcode;
                }

                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("packagecode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (packagecode == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = packagecode;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm23 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (pubcenter == "0")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = pubcenter;
                }
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm11 = new OracleParameter("adcate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (adcat == "0" || adcat=="")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = adcat;
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("p_Positionprem", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (positionprem == "0")
                    prm12.Value = System.DBNull.Value;
                else
                prm12.Value = positionprem;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm51 = new OracleParameter("pvalid_fromdt", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;

                if (validfrom == "" || validfrom == null)
                {
                    prm51.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfrom.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfrom = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfrom.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfrom = mm + "/" + dd + "/" + yy;
                            }

                    prm51.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm51);



                OracleParameter prm13 = new OracleParameter("p_adsubcat", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (subcat == "0")
                    prm13.Value = System.DBNull.Value;
                else
                    prm13.Value = subcat;
                objOraclecommand.Parameters.Add(prm13);

                
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet premiumbind(string compcode,string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpremiumforrate.bindpremiumforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);


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

        public DataSet paccolochk(string package, string color, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpackagecolor.chkpackagecolor_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("package", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = package;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("color", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = color;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet modifyrate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type, string agencycode, string dateformat, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max, string priority, string vat, string Adon, string refrence, string cancellation, string positionprem)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifyratecode.modifyratecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ratecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rategroupcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = rategroupcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("currency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = currency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("package1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = package;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm13 = new OracleParameter("packagedesc", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = packagedesc;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("uom", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = uom;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (sizefrom == "" || sizefrom == null)
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = Convert.ToInt32(sizefrom);
                }
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("sizeto", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (sizeto == "" || sizeto == null)
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = Convert.ToInt32(sizeto);
                }
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("consumption", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (consumption == "" || consumption == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = Convert.ToInt32(consumption);
                }
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("color", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = color;
                objOraclecommand.Parameters.Add(prm18);


                OracleParameter prm20 = new OracleParameter("colorchrty", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = colorchrty;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("weekdrate", OracleType.Double);
                prm21.Direction = ParameterDirection.Input;
                if (weekdrate == "" || weekdrate == null)
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    prm21.Value = Convert.ToDouble(weekdrate);
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("weeminrate", OracleType.Double);
                prm22.Direction = ParameterDirection.Input;
                if (weeminrate == "" || weeminrate == null)
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    prm22.Value = Convert.ToDouble(weeminrate);
                }
                objOraclecommand.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("extweerate", OracleType.Double);
                prm23.Direction = ParameterDirection.Input;
                if (extweerate == "" || extweerate == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDouble(extweerate);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("focusdarate", OracleType.Double);
                prm24.Direction = ParameterDirection.Input;
                if (focusdarate == "" || focusdarate == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDouble(focusdarate);
                }
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("focminrate", OracleType.Double);
                prm25.Direction = ParameterDirection.Input;
                if (focminrate == "" || focminrate == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(focminrate);
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("focexrate", OracleType.Double);
                prm26.Direction = ParameterDirection.Input;
                if (focexrate == "" || focexrate == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToDouble(focexrate);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("validfromdate", OracleType.DateTime);
                prm27.Direction = ParameterDirection.Input;
                if (validfromdate == "" || validfromdate == null)
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate = mm + "/" + dd + "/" + yy;
                            }
                    prm27.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm27);


                OracleParameter prm28 = new OracleParameter("validtill", OracleType.DateTime);
                prm28.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null)
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill = mm + "/" + dd + "/" + yy;
                            }
                    prm28.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm19 = new OracleParameter("remarks", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = remarks;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm12 = new OracleParameter("premiumval", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = premiumval;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm11 = new OracleParameter("premium", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = premium;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm29 = new OracleParameter("weekendrate", OracleType.Double);
                prm29.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("weekendmin", OracleType.Double);
                prm30.Direction = ParameterDirection.Input;
                if (weekendmin == "" || weekendmin == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToDouble(weekendmin);
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("weekendextra", OracleType.Double);
                prm31.Direction = ParameterDirection.Input;
                if (weekendextra == "" || weekendextra == null)
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    prm31.Value = Convert.ToDouble(weekendextra);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm33 = new OracleParameter("editionto", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (editionto == "" || editionto == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToInt32(editionto);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm32 = new OracleParameter("minadarea", OracleType.Double);
                prm32.Direction = ParameterDirection.Input;
                if (minadarea == "" || minadarea == null)
                {
                    prm32.Value = Convert.ToDouble("0");
                }
                else
                {
                    prm32.Value = Convert.ToDouble(minadarea);
                }
                objOraclecommand.Parameters.Add(prm32);




                OracleParameter prm34 = new OracleParameter("editionfrom", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                if (editionfrom == "" || editionfrom == null)
                {
                    prm34.Value = System.DBNull.Value;
                }
                else
                {
                    prm34.Value = Convert.ToInt32(editionfrom);
                }
                objOraclecommand.Parameters.Add(prm34);




                OracleParameter prm35 = new OracleParameter("flramount", OracleType.Double);
                prm35.Direction = ParameterDirection.Input;
                if (flramount == "" || flramount == null)
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                {
                    prm35.Value = Convert.ToDouble(flramount);
                }
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter prm36 = new OracleParameter("flrdiscount", OracleType.Double);
                prm36.Direction = ParameterDirection.Input;
                if (flrdiscount == "" || flrdiscount == null)
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                {
                    prm36.Value = Convert.ToDouble(flrdiscount);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("scheme1", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = scheme;
                objOraclecommand.Parameters.Add(prm37);



                OracleParameter prm38 = new OracleParameter("adscat6", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = adscat6;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("adscat5", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = adscat5;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("adscat4", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = adscat4;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("frominsert", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                if (frominsert == "" || frominsert == null)
                {
                    prm41.Value = System.DBNull.Value;
                }
                else
                {
                    prm41.Value = Convert.ToInt32(frominsert);
                }
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("toinsert", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                if (toinsert == "" || toinsert == null)
                {
                    prm42.Value = System.DBNull.Value;
                }
                else
                {
                    prm42.Value = Convert.ToInt32(toinsert);
                }
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("agtype", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = agtype;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("clientcat", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = clientcat;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm48 = new OracleParameter("max_area", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = max_area;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("type1", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = type;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("agencycode", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = agencycode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm51 = new OracleParameter("rate_sun", OracleType.Number);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = Convert.ToDouble(rate_sun);
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("rate_mon", OracleType.Number);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = Convert.ToDouble(rate_mon);
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm53 = new OracleParameter("rate_tue", OracleType.Number);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = Convert.ToDouble(rate_tue);
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm54 = new OracleParameter("rate_wed", OracleType.Number);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = Convert.ToDouble(rate_wed);
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("rate_thu", OracleType.Number);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = Convert.ToDouble(rate_thu);
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm56 = new OracleParameter("rate_fri", OracleType.Number);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = Convert.ToDouble(rate_fri);
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("rate_sat", OracleType.Number);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = Convert.ToDouble(rate_sat);
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("rate_sun_extra", OracleType.Number);
                prm58.Direction = ParameterDirection.Input;
                if (rate_sun_extra == "")
                {
                    prm58.Value = 0;
                }
                else
                {
                    prm58.Value = Convert.ToDouble(rate_sun_extra);
                }
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("rate_mon_extra", OracleType.Number);
                prm59.Direction = ParameterDirection.Input;
                if (rate_mon_extra == "")
                {
                    prm59.Value = 0;
                }
                else
                {
                    prm59.Value = Convert.ToDouble(rate_mon_extra);
                }
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("rate_tue_extra", OracleType.Number);
                prm60.Direction = ParameterDirection.Input;
                if (rate_tue_extra == "")
                {
                    prm60.Value = 0;
                }
                else
                {
                    prm60.Value = Convert.ToDouble(rate_tue_extra);
                }
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("rate_wed_extra", OracleType.Number);
                prm61.Direction = ParameterDirection.Input;
                if (rate_wed_extra == "")
                {
                    prm61.Value = 0;
                }
                else
                {
                    prm61.Value = Convert.ToDouble(rate_wed_extra);
                }
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm62 = new OracleParameter("rate_thu_extra", OracleType.Number);
                prm62.Direction = ParameterDirection.Input;
                if (rate_thu_extra == "")
                {
                    prm62.Value = 0;
                }
                else
                {
                    prm62.Value = Convert.ToDouble(rate_thu_extra);
                }
                objOraclecommand.Parameters.Add(prm62);

                OracleParameter prm63 = new OracleParameter("rate_fri_extra", OracleType.Number);
                prm63.Direction = ParameterDirection.Input;
                if (rate_fri_extra == "")
                {
                    prm63.Value = 0;
                }
                else
                {
                    prm63.Value = Convert.ToDouble(rate_fri_extra);
                }
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm64 = new OracleParameter("rate_sat_extra", OracleType.Number);
                prm64.Direction = ParameterDirection.Input;
                if (rate_sat_extra == "")
                {
                    prm64.Value = 0;
                }
                else
                {
                    prm64.Value = Convert.ToDouble(rate_sat_extra);
                }
                objOraclecommand.Parameters.Add(prm64);

                OracleParameter prm65 = new OracleParameter("width_max", OracleType.Number);
                prm65.Direction = ParameterDirection.Input;
                prm65.Value = Convert.ToInt32(width_max);
                objOraclecommand.Parameters.Add(prm65);

                OracleParameter prm66 = new OracleParameter("priority_m", OracleType.Number);
                prm66.Direction = ParameterDirection.Input;
                if (priority == "")
                    prm66.Value = System.DBNull.Value;
                else
                    prm66.Value = Convert.ToInt32(priority);
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("vat", OracleType.VarChar);
                prm67.Direction = ParameterDirection.Input;
                prm67.Value = vat;
                objOraclecommand.Parameters.Add(prm67);

                OracleParameter prm69 = new OracleParameter("Adon1", OracleType.VarChar);
                prm69.Direction = ParameterDirection.Input;
                prm69.Value = Adon;
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("refrence", OracleType.VarChar);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = refrence;
                objOraclecommand.Parameters.Add(prm70);


                OracleParameter prm71 = new OracleParameter("p_cancellation", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = cancellation;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("p_Positionprem", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
             //   if (positionprem == "0")
           //         prm72.Value = System.DBNull.Value;
            //    else
                    prm72.Value = positionprem;
                objOraclecommand.Parameters.Add(prm72);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet description(string packagecode, string compcode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string decimalvalue, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddescription.binddescription_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (validfromdate1 == "")
                {
                    prm9.Value = validfromdate1;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate1 = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate1.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate1 = mm + "/" + dd + "/" + yy;
                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate1.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate1 = mm + "/" + dd + "/" + yy;
                            }

                    prm9.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validtill1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (validtill1 == "")
                {
                    prm10.Value = validtill1;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill1 = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill1.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill1 = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill1.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill1 = mm + "/" + dd + "/" + yy;
                            }



                    prm10.Value = Convert.ToDateTime(validtill1).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("uom", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = uom;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("adscat4", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = adscat4;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("adscat5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = adscat5;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("adscat6", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = adscat6;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premium", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = premium;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizeto", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sizeto;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("frominsert", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = frominsert;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("toinsert", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = toinsert;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("decimalvalue", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = decimalvalue;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("clientcat", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = clientcat;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("minadarea", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm22.Value = "0";
                }
                else
                {
                    prm22.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("type1", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = type;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("agencycode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = agencycode;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm25);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet descriptionforchange(string packagecode, string compcode, string pubcenter, string adtype)//,string type,string agencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Binddescriptionforchange1.Binddescriptionforchange1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype;
                objOraclecommand.Parameters.Add(prm4);

                //OracleParameter prm3 = new OracleParameter("type1", OracleType.VarChar);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = type;
                //objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("agencycode", OracleType.VarChar);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = agencycode;
                //objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


                //objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;


                objorclDataAdapter.ReturnProviderSpecificTypes = true;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public OracleDataReader descriptionforchange_Reader(string packagecode, string compcode)//,string type,string agencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            OracleDataReader dr;
            // DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Binddescriptionforchange1.Binddescriptionforchange1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                //OracleParameter prm3 = new OracleParameter("type1", OracleType.VarChar);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = type;
                //objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("agencycode", OracleType.VarChar);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = agencycode;
                //objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


                //objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;

                dr = objOraclecommand.ExecuteReader();

                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //objorclDataAdapter.Fill(objDataSet);
                return (dr);
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
        public DataSet getdescription(string packagecode, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddescription12.binddescription12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet deleterate(string ratecode, string compcode, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deleterate.deleterate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet chkcolor(string colorcode, string compcode, string value, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string bwcode, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkopenorreff.chkopenorreff_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("colorcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colorcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("packagecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = packagecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (validfromdate1 == "")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate1 = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        validfromdate1 = mm + "/" + dd + "/" + yy;

                    }

                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfromdate1 = mm + "/" + dd + "/" + yy;
                    }
                    prm11.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("validtill1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (validtill1 == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill1 = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        validtill1 = mm + "/" + dd + "/" + yy;

                    }

                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validtill1 = mm + "/" + dd + "/" + yy;
                    }
                    prm12.Value = Convert.ToDateTime(validtill1).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("bwcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = bwcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("uom", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = uom;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adscat6", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adscat6;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("adscat5", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adscat5;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adscat4", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adscat4;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("premium", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = premium;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("sizeto", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = sizeto;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("frominsert", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = frominsert;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("toinsert", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = toinsert;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("clientcat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = clientcat;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("minadarea", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm24.Value = "0";
                }
                else
                {
                    prm24.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("type1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = type;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("agencycode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = agencycode;
                objOraclecommand.Parameters.Add(prm26);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet getpremiumbaserate(string colorcode, string compcode, string value, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string bwcode, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getpremiumbaserate.getpremiumbaserate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("colorcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colorcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("packagecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = packagecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = validfromdate1;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("validtill1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = validtill1;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("bwcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = bwcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("uom", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = uom;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adscat6", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adscat6;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("adscat5", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adscat5;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adscat4", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adscat4;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("premium", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = premium;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("sizeto", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = sizeto;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("frominsert", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = frominsert;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("toinsert", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = toinsert;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("clientcat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = clientcat;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("minadarea", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm24.Value = "0";
                }
                else
                {
                    prm24.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("type1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = type;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("agencycode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = agencycode;
                objOraclecommand.Parameters.Add(prm26);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet checkpackage(string packagecode, string compcode, string value, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode,string dateformat, string pubcenter)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpackagecode.chkpackagecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy" && validfromdate1 != "" && validfromdate1 != null)
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validfromdate1 = mm + "/" + dd + "/" + yy;
                }

                prm10.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("validtill1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy" && validtill1 != "" && validtill1 != null)
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validtill1 = mm + "/" + dd + "/" + yy;

                }

                prm11.Value = Convert.ToDateTime(validtill1).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm11);

                //prm9.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");

                OracleParameter prm12 = new OracleParameter("uom", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = uom;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("adscat6", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = adscat6;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("adscat5", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = adscat5;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("adscat4", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = adscat4;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("premium", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = premium;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("sizeto", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = sizeto;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("frominsert", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = frominsert;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("toinsert", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = toinsert;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("clientcat", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = clientcat;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("minadarea", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm22.Value = "0";
                }
                else
                {
                    prm22.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm25 = new OracleParameter("type1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = type;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm23 = new OracleParameter("agencycode", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = agencycode;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm24);


                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        // not used anywhere

        public DataSet editionforrate(string packagecode, string compcode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkeditionforrate.chkeditionforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = validfromdate1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validtill1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = validtill1;
                objOraclecommand.Parameters.Add(prm10);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet chkratecode(string compcode, string ratecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkratedetail.chkratedetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet chkratecodemast(string compcode, string ratecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkratedetailmast.chkratedetailmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet ratedetailsinsert(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string uniquerate, string weekrate, string solofocusrate, string weekendrate, string soloweekrate, string type, string weekextra, string focusextra, string weekendextra, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string adtype1, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertratedetail.insertratedetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("uniquerate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = uniquerate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ratecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ratecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("edition", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("rate", OracleType.Double);
                prm6.Direction = ParameterDirection.Input;
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = Convert.ToDouble(rate);
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("weekrate", OracleType.Double);
                prm7.Direction = ParameterDirection.Input;
                if (weekrate.Trim() == "" || weekrate == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = Convert.ToDouble(weekrate);
                }
                objOraclecommand.Parameters.Add(prm7);
                ////////////if (weekdrate == "" || weekdrate == null)
                ////////////{
                ////////////    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                ////////////}
                ////////////else
                ////////////{
                ////////////    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                ////////////}

                OracleParameter prm8 = new OracleParameter("solofocusrate", OracleType.Double);
                prm8.Direction = ParameterDirection.Input;
                if (solofocusrate.Trim() == "" || solofocusrate.Trim() == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = Convert.ToDouble(solofocusrate);
                }
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("focusrate", OracleType.Double);
                prm9.Direction = ParameterDirection.Input;
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = Convert.ToDouble(focusrate);
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("weekendrate", OracleType.Double);
                prm10.Direction = ParameterDirection.Input;
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("soloweekrate", OracleType.Double);
                prm11.Direction = ParameterDirection.Input;
                if (soloweekrate.Trim() == "" || soloweekrate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = Convert.ToDouble(soloweekrate);
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm25 = new OracleParameter("weekextra", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = weekextra;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm23 = new OracleParameter("focusextra", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = focusextra;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("weekendextra", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = weekendrate;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm26 = new OracleParameter("rate_sun", OracleType.Float);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = Convert.ToDouble(rate_sun);
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("rate_mon", OracleType.Float);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = Convert.ToDouble(rate_mon);
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("rate_tue", OracleType.Float);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = Convert.ToDouble(rate_tue);
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("rate_wed", OracleType.Float);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = Convert.ToDouble(rate_wed);
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("rate_thu", OracleType.Float);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = Convert.ToDouble(rate_thu);
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("rate_fri", OracleType.Float);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = Convert.ToDouble(rate_fri);
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("rate_sat", OracleType.Float);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = Convert.ToDouble(rate_sat);
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("rate_sun_extra", OracleType.Float);
                prm33.Direction = ParameterDirection.Input;
                if (rate_sun_extra == "")
                {
                    prm33.Value = 0;
                }
                else
                {
                    prm33.Value = Convert.ToDouble(rate_sun_extra);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("rate_mon_extra", OracleType.Float);
                prm34.Direction = ParameterDirection.Input;
                if (rate_mon_extra == "")
                {
                    prm34.Value = 0;
                }
                else
                {
                    prm34.Value = Convert.ToDouble(rate_mon_extra);
                }
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rate_tue_extra", OracleType.Float);
                prm35.Direction = ParameterDirection.Input;
                if (rate_tue_extra == "")
                {
                    prm35.Value = 0;
                }
                else
                {
                    prm35.Value = Convert.ToDouble(rate_tue_extra);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("rate_wed_extra", OracleType.Float);
                prm36.Direction = ParameterDirection.Input;
                if (rate_wed_extra == "")
                {
                    prm36.Value = 0;
                }
                else
                {
                    prm36.Value = Convert.ToDouble(rate_wed_extra);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("rate_thu_extra", OracleType.Float);
                prm37.Direction = ParameterDirection.Input;
                if (rate_thu_extra == "")
                {
                    prm37.Value = 0;
                }
                else
                {
                    prm37.Value = Convert.ToDouble(rate_thu_extra);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("rate_fri_extra", OracleType.Float);
                prm38.Direction = ParameterDirection.Input;
                if (rate_fri_extra == "")
                {
                    prm38.Value = 0;
                }
                else
                {
                    prm38.Value = Convert.ToDouble(rate_fri_extra);
                }
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("rate_sat_extra", OracleType.Float);
                prm39.Direction = ParameterDirection.Input;
                if (rate_sat_extra == "")
                {
                    prm39.Value = 0;
                }
                else
                {
                    prm39.Value = Convert.ToDouble(rate_sat_extra);
                }
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("adtype1", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = adtype1;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm41);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet rateget(string packagecode, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddescription12.binddescription12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet ratedetailsupdate(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string rateuniqueid, string weekendrate, string type, string weekextra, string focusextra, string weekendextra, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string adtype1, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateratedetail.updateratedetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ratecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ratecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("edition", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rate", OracleType.Double);
                prm6.Direction = ParameterDirection.Input;
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = Convert.ToDouble(rate);
                }
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("focusrate", OracleType.Double);
                prm7.Direction = ParameterDirection.Input;
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = Convert.ToDouble(focusrate);
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("weekendrate", OracleType.Double);
                prm8.Direction = ParameterDirection.Input;
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm25 = new OracleParameter("weekextra", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (weekextra.Trim() == "" || weekextra.Trim() == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(weekextra);
                }
                
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm23 = new OracleParameter("focusextra", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (focusextra.Trim() == "" || focusextra.Trim() == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDouble(focusextra);
                }
                
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("weekendextra", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (weekendrate.Trim() == "" || weekendrate.Trim() == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDouble(weekendrate);
                }
                
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm26 = new OracleParameter("rate_sun", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = Convert.ToDouble(rate_sun);
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("rate_mon", OracleType.Number);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = Convert.ToDouble(rate_mon);
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("rate_tue", OracleType.Number);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = Convert.ToDouble(rate_tue);
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("rate_wed", OracleType.Number);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = Convert.ToDouble(rate_wed);
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("rate_thu", OracleType.Number);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = Convert.ToDouble(rate_thu);
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("rate_fri", OracleType.Number);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = Convert.ToDouble(rate_fri);
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("rate_sat", OracleType.Number);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = Convert.ToDouble(rate_sat);
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("rate_sun_extra", OracleType.Number);
                prm33.Direction = ParameterDirection.Input;
                if (rate_sun_extra == "")
                {
                    prm33.Value = 0;
                }
                else
                {
                    prm33.Value = Convert.ToDouble(rate_sun_extra);
                }
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("rate_mon_extra", OracleType.Number);
                prm34.Direction = ParameterDirection.Input;
                if (rate_mon_extra == "")
                {
                    prm34.Value = 0;
                }
                else
                {
                    prm34.Value = Convert.ToDouble(rate_mon_extra);
                }
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rate_tue_extra", OracleType.Number);
                prm35.Direction = ParameterDirection.Input;
                if (rate_tue_extra == "")
                {
                    prm35.Value = 0;
                }
                else
                {
                    prm35.Value = Convert.ToDouble(rate_tue_extra);
                }
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("rate_wed_extra", OracleType.Number);
                prm36.Direction = ParameterDirection.Input;
                if (rate_wed_extra == "")
                {
                    prm36.Value = 0;
                }
                else
                {
                    prm36.Value = Convert.ToDouble(rate_wed_extra);
                }
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("rate_thu_extra", OracleType.Number);
                prm37.Direction = ParameterDirection.Input;
                if (rate_thu_extra == "")
                {
                    prm37.Value = 0;
                }
                else
                {
                    prm37.Value = Convert.ToDouble(rate_thu_extra);
                }
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("rate_fri_extra", OracleType.Number);
                prm38.Direction = ParameterDirection.Input;
                if (rate_fri_extra == "")
                {
                    prm38.Value = 0;
                }
                else
                {
                    prm38.Value = Convert.ToDouble(rate_fri_extra);
                }
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("rate_sat_extra", OracleType.Number);
                prm39.Direction = ParameterDirection.Input;
                if (rate_sat_extra == "")
                {
                    prm39.Value = 0;
                }
                else
                {
                    prm39.Value = Convert.ToDouble(rate_sat_extra);
                }
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("adtype1", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = adtype1;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm41);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet soloratedetailsupdate(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string rateuniqueid, string weekendrate, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatesoloratedetail.updatesoloratedetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ratecode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ratecode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("edition", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rate", OracleType.Double);
                prm6.Direction = ParameterDirection.Input;
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = Convert.ToDouble(rate);
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("focusrate", OracleType.Double);
                prm7.Direction = ParameterDirection.Input;
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = Convert.ToDouble(focusrate);
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("weekendrate", OracleType.Double);
                prm8.Direction = ParameterDirection.Input;
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet bindgridfromdetail(string ratecode, string compcode, string type)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindratedetails.bindratedetails_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet modifygrid(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra,string extrarate)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ratemodifygrid.ratemodifygrid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("weekrate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (weekrate == "" || weekrate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = weekrate;
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("focusrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                //if (focusrate == "" || focusrate == null)
                //{
                //    prm12.Value = System.DBNull.Value;
                //}
                //else
                //{
                    prm12.Value =focusrate;
              //  }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validfromdate1 = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        validfromdate1 = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = validfromdate1.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            validfromdate1 = mm + "/" + dd + "/" + yy;
                        }

                prm9.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validtill1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validtill1 = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        validtill1 = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = validtill1.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            validtill1 = mm + "/" + dd + "/" + yy;
                        }

                prm10.Value = Convert.ToDateTime(validtill1).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm13 = new OracleParameter("weekendrate", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                //if (weekendrate == "" || weekendrate == null)
                //{
                //    prm13.Value = System.DBNull.Value;
                //}
                //else
                //{
                    prm13.Value = weekendrate;
               // }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("decimalvalue", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                //if (decimalvalue == "" || decimalvalue == null)
                //{
                //    prm14.Value = System.DBNull.Value;
                //}
                //else
                //{
                    prm14.Value = decimalvalue;
               // }
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("uom", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = uom;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("adscat6", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adscat6;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adscat5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adscat5;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adscat4", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = adscat4;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("premium", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = premium;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("sizeto", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = sizeto;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("frominsert", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = frominsert;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("toinsert", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = toinsert;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("clientcat", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = clientcat;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("minadarea", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm25.Value = "0";
                }
                else
                {
                    prm25.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("type1", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = type;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm28 = new OracleParameter("agencycode", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = agencycode;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("pkg_sun_rate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = rate_sun;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pkg_mon_rate", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = rate_mon;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pkg_tue_rate", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = rate_tue;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("pkg_wed_rate", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = rate_wed;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("pkg_thu_rate", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = rate_thu;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("pkg_fri_rate", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = rate_fri;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pkg_sat_rate", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = rate_sat;
                objOraclecommand.Parameters.Add(prm36);

                /////////////////////////////////////////////////////////

                OracleParameter prm37 = new OracleParameter("pkg_sun_rate_ex", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = rate_sun_extra;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("pkg_mon_rate_ex", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = rate_mon_extra;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("pkg_tue_rate_ex", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = rate_tue_extra;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("pkg_wed_rate_ex", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = rate_wed_extra;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pkg_thu_rate_ex", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = rate_thu_extra;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("pkg_fri_rate_ex", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = rate_fri_extra;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("pkg_sat_rate_ex", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = rate_sat_extra;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("extrarate", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = extrarate;
                objOraclecommand.Parameters.Add(prm44);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet sizecheck(string sizefrom, string sizeto, string adtype, string adcategory, string adsubcategory, string compcode, string uom)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checksizeforrate.checksizeforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("uom", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = uom;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("sizeto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sizeto;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet showgrid(string compcode, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindgridforexe.bindgridforexe_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (validfromdate1 == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate1 = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validfromdate1.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validfromdate1 = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validfromdate1.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validfromdate1 = mm + "/" + dd + "/" + yy;
                            }

                    prm9.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validtill1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (validtill1 == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill1 = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = validtill1.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            validtill1 = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = validtill1.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                validtill1 = mm + "/" + dd + "/" + yy;
                            }

                    prm10.Value = Convert.ToDateTime(validtill1).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("uom", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = uom;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("adscat6", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = adscat6;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("adscat5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = adscat5;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("adscat4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = adscat4;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premium", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = premium;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizeto", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sizeto;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("frominsert", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = frominsert;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("toinsert", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = toinsert;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("clientcat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = clientcat;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("minadarea", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm21.Value = "0";
                }
                else
                {
                    prm21.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("agencycode", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = agencycode;
                objOraclecommand.Parameters.Add(prm23);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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



        public DataSet updatesizechk(string sizefrom, string sizeto, string adtype, string adcategory, string adsubcategory, string compcode, string ratecode, string uom, string adscat4, string adscat5, string adscat6)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatechecksizeforrate.updatechecksizeforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("uom", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = uom;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("sizeto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sizeto;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ratecode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ratecode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adscat6", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adscat6;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("adscat5", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = adscat5;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("adscat4", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adscat4;
                objOraclecommand.Parameters.Add(prm11);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        // not used anywhere

        public DataSet modsolpack(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checksolopackage.checksolopackage_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("todate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = todate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = color;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("package", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = package;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet soloratemodify(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string rateuniqueid, string pkgdesc, string weekrate, string focusrate, string weekendrate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("soloratemodify.soloratemodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecodes", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
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
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = fromdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            fromdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = fromdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                fromdate = mm + "/" + dd + "/" + yy;
                            }
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("todate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (todate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = todate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            todate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = todate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                todate = mm + "/" + dd + "/" + yy;
                            }
                    prm4.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = color;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("package1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = package;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pkgdesc", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pkgdesc;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("weekrate", OracleType.Double);
                prm13.Direction = ParameterDirection.Input;
                if (weekrate == "" || weekrate == null)
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = Convert.ToDouble(weekrate);
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("focusrate", OracleType.Double);
                prm14.Direction = ParameterDirection.Input;
                if (focusrate == "" || focusrate == null)
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = Convert.ToDouble(focusrate);
                }
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("weekendrate", OracleType.Double);
                prm15.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("uom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = uom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adscat6", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adscat6;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adscat5", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = adscat5;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("adscat4", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = adscat4;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("premium", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = premium;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("sizeto", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = sizeto;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("frominsert", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;



                prm23.Value = frominsert;

                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("toinsert", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;


                prm24.Value = toinsert;

                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("clientcat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = clientcat;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("minadarea", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = minadarea;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm28 = new OracleParameter("type1", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = type;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("agencycode", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = agencycode;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("rate_sun", OracleType.Number);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = Convert.ToInt32(rate_sun);
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("rate_mon", OracleType.Number);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = Convert.ToInt32(rate_mon);
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("rate_tue", OracleType.Number);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = Convert.ToInt32(rate_tue);
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("rate_wed", OracleType.Number);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = Convert.ToInt32(rate_wed);
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rate_thu", OracleType.Number);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = Convert.ToInt32(rate_thu);
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("rate_fri", OracleType.Number);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = Convert.ToInt32(rate_fri);
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("rate_sat", OracleType.Number);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = Convert.ToInt32(rate_sat);
                objOraclecommand.Parameters.Add(prm37);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet editionmodify(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string rateuniqueid, string pkgdesc, string weekrate, string focusrate, string weekendrate, string uom, string type, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionmodifyrate.editionmodifyrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ratecode3", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("adtype1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("color", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = color;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("PACKAGE1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = package;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
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
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;

                    }

                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("todate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (todate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;

                    }

                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm11 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pkgdesc", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pkgdesc;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("weekrate", OracleType.Double);
                prm13.Direction = ParameterDirection.Input;
                if (weekrate == "" || weekrate == null)
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = Convert.ToDouble(weekrate);
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("focusrate", OracleType.Double);
                prm14.Direction = ParameterDirection.Input;
                if (focusrate == "" || focusrate == null)
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = Convert.ToDouble(focusrate);
                }
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("weekendrate", OracleType.Double);
                prm15.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("uom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = uom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm22 = new OracleParameter("type1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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





        public DataSet modifycirculation(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string flag, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agetype, string clientcat, string max_area, string type, string agencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifycirculation.modifycirculation_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("datefrom", OracleType.VarChar);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = datefrom;
                //objOraclecommand.Parameters.Add(prm4);

                //OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                //prm5.Direction = ParameterDirection.Input;
                //prm5.Value = dateto;
                //objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ratecode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ratecode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adtype", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("rategroupcode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rategroupcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adcategory", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adcategory;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("currency", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = currency;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("package", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = package;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("premium", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = premium;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("premiumval", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = premiumval;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("packagedesc", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = packagedesc;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("uom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = uom;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (sizefrom == "" || sizefrom == null)
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = sizefrom;
                }
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("sizeto", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (sizeto == "" || sizeto == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    prm18.Value = sizeto;
                }
                objOraclecommand.Parameters.Add(prm18);


                OracleParameter prm19 = new OracleParameter("consumption", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (consumption == "" || consumption == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = consumption;
                }
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("color", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = color;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("remarks", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = remarks;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("colorchrty", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = colorchrty;
                objOraclecommand.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("weekdrate", OracleType.Double);
                prm23.Direction = ParameterDirection.Input;
                if (weekdrate == "" || weekdrate == null)
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToDouble(weekdrate);
                }
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("weeminrate", OracleType.Double);
                prm24.Direction = ParameterDirection.Input;
                if (weeminrate == "" || weeminrate == null)
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToDouble(weeminrate);
                }
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("extweerate", OracleType.Double);
                prm25.Direction = ParameterDirection.Input;
                if (extweerate == "" || extweerate == null)
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToDouble(extweerate);
                }
                objOraclecommand.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("focusdarate", OracleType.Double);
                prm26.Direction = ParameterDirection.Input;
                if (focusdarate == "" || focusdarate == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = Convert.ToDouble(focusdarate);
                }
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("focminrate", OracleType.Double);
                prm27.Direction = ParameterDirection.Input;
                if (focminrate == "" || focminrate == null)
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    prm27.Value = Convert.ToDouble(focminrate);
                }
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("focexrate", OracleType.Double);
                prm28.Direction = ParameterDirection.Input;
                if (focexrate == "" || focexrate == null)
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToDouble(focexrate);
                }
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("validfromdate", OracleType.DateTime);
                prm29.Direction = ParameterDirection.Input;
                if (validfromdate == "" || validfromdate == null)
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = validfromdate;
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validtill", OracleType.DateTime);
                prm30.Direction = ParameterDirection.Input;
                if (validtill == "" || validtill == null)
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = validtill;
                }
                objOraclecommand.Parameters.Add(prm30);

                //Convert.ToDateTime();
                OracleParameter prm31 = new OracleParameter("weekendrate", OracleType.Double);
                prm31.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    prm31.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("weekendmin", OracleType.Double);
                prm32.Direction = ParameterDirection.Input;
                if (weekendmin == "" || weekendmin == null)
                {
                    prm32.Value = System.DBNull.Value;
                }
                else
                {
                    prm32.Value = Convert.ToDouble(weekendmin);
                }
                objOraclecommand.Parameters.Add(prm32);


                OracleParameter prm33 = new OracleParameter("weekendextra", OracleType.Double);
                prm33.Direction = ParameterDirection.Input;
                if (weekendextra == "" || weekendextra == null)
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                {
                    prm33.Value = Convert.ToDouble(weekendextra);
                }
                objOraclecommand.Parameters.Add(prm33);


                OracleParameter prm34 = new OracleParameter("combination", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = combination;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("insertsolo", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = insertsolo;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("flag", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = flag;
                objOraclecommand.Parameters.Add(prm36);


                OracleParameter prm37 = new OracleParameter("minadarea", OracleType.Double);
                prm37.Direction = ParameterDirection.Input;
                if (minadarea == "" || minadarea == null)
                {
                    prm37.Value = Convert.ToDecimal("0");
                }
                else
                {
                    prm37.Value = Convert.ToDouble(minadarea);
                }
                objOraclecommand.Parameters.Add(prm37);


                OracleParameter prm38 = new OracleParameter("editionfrom", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                if (editionfrom == "" || editionfrom == null)
                {
                    prm38.Value = System.DBNull.Value;
                }
                else
                {
                    prm38.Value = Convert.ToInt32(editionfrom);
                }
                objOraclecommand.Parameters.Add(prm38);


                OracleParameter prm39 = new OracleParameter("editionto", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                if (editionto == "" || editionto == null)
                {
                    prm39.Value = System.DBNull.Value;
                }
                else
                {
                    prm39.Value = Convert.ToInt32(editionto);
                }
                objOraclecommand.Parameters.Add(prm39);


                OracleParameter prm40 = new OracleParameter("flramount", OracleType.Double);
                prm40.Direction = ParameterDirection.Input;
                if (flramount == "" || flramount == null)
                {
                    prm40.Value = System.DBNull.Value;
                }
                else
                {
                    prm40.Value = Convert.ToDouble(flramount);
                }
                objOraclecommand.Parameters.Add(prm40);


                OracleParameter prm41 = new OracleParameter("flrdiscount", OracleType.Double);
                prm41.Direction = ParameterDirection.Input;
                if (flrdiscount == "" || flrdiscount == null)
                {
                    prm41.Value = System.DBNull.Value;
                }
                else
                {
                    prm41.Value = Convert.ToDouble(flrdiscount);
                }
                objOraclecommand.Parameters.Add(prm41);


                OracleParameter prm42 = new OracleParameter("scheme", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = scheme;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("adscat6", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = adscat6;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("adscat5", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = adscat5;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("adscat4", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = adscat4;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("frominsert", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                if (frominsert == "" || frominsert == null)
                {
                    prm46.Value = System.DBNull.Value;
                }
                else
                {
                    prm46.Value = frominsert;
                }
                objOraclecommand.Parameters.Add(prm46);


                OracleParameter prm47 = new OracleParameter("toinsert", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                if (toinsert == "" || toinsert == null)
                {
                    prm47.Value = System.DBNull.Value;
                }
                else
                {
                    prm47.Value = toinsert;
                }
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("agetype", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = agetype;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("clientcat", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = clientcat;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm56 = new OracleParameter("max_area", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = max_area;
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("type1", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = type;
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("agencycode", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = agencycode;
                objOraclecommand.Parameters.Add(prm58);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet uombind(string compcode, string userid, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binduomforrate.binduomforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet descriptioncirculation(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string decimalvalue11, string clientcat, string minadarea, string type, string agencycode, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddescriptionforcirculation.bdcirculation_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = validfromdate1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validtill1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = validtill1;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("weekrate", OracleType.Double);
                prm11.Direction = ParameterDirection.Input;
                if (weekrate == "" || weekrate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = Convert.ToDouble(weekrate);
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("focusrate", OracleType.Double);
                prm12.Direction = ParameterDirection.Input;
                if (focusrate == "" || focusrate == null)
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDouble(focusrate);
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("weekendrate", OracleType.Double);
                prm13.Direction = ParameterDirection.Input;
                if (weekendrate == "" || weekendrate == null)
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = Convert.ToDouble(weekendrate);
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("decimalvalue", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (decimalvalue == "" || decimalvalue == null)
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = Convert.ToInt32(decimalvalue);
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("uom", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = uom;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("adscat6", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adscat6;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adscat5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adscat5;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adscat4", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = adscat4;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("premium", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = premium;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("sizeto", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = sizeto;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("frominsert", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = frominsert;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("toinsert", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = toinsert;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("decimalvalue11", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = decimalvalue11;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("clientcat", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = clientcat;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("minadarea", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm26.Value = "0";
                }
                else
                {
                    prm26.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("type1", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = type;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("agencycode", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = agencycode;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm28.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm29);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet bindscategory4(string compcode, string adscat4, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Rate_bindadcat4.Rate_bindadcat4_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adscat4", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adscat4;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet bindclientcat(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Rate_bindclientcat.Rate_bindclientcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet bindpckforadtype(string typecode, string compcode, string adcat, string adscat, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_bindpkg.rate_bindpkg_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("typecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = typecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adcat1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adcat == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adcat;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("adscat", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (adscat == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = adscat;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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

        public DataSet getuom_desc(string compcode, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getuomdesc.getuomdesc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("value", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = value;
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

        public DataSet bindrateforgrid(string packagecode, string compcode, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_bindgrid.rate_bindgrid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("dateformat", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet chkinsanddate(string compcode, string rateuniqueid, string type, string sizefrom, string sizeto, string fromins, string toins, string datefrom, string dateto, string tosave, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string uom, string adscat4, string adscat5, string adscat6, string premium, string clientcat, string minadarea, string agencycode, string dateformat, string pubcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_chkdateins.rate_chkdateins_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm100 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm100.Direction = ParameterDirection.Input;
                prm100.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm100);


                OracleParameter prm16 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sizeto", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sizeto;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("fromins", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = fromins;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("toins", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = toins;
                objOraclecommand.Parameters.Add(prm19);

                

                OracleParameter prm4 = new OracleParameter("datefrom", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = datefrom.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datefrom = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = datefrom.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        datefrom = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = datefrom.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            datefrom = mm + "/" + dd + "/" + yy;
                        }

                prm4.Value = Convert.ToDateTime(datefrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;


                }
              
                prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm3 = new OracleParameter("ratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm37 = new OracleParameter("tosave", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = tosave;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm6 = new OracleParameter("adtype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adtype;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("adcategory", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcategory;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("adsubcategory", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adsubcategory;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("color", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = color;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("package1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = package;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("currency", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = currency;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm2 = new OracleParameter("uom", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = uom;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm12 = new OracleParameter("adscat6", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = adscat6;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("adscat5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = adscat5;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("adscat4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = adscat4;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premium", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = premium;
                objOraclecommand.Parameters.Add(prm15);



                OracleParameter prm20 = new OracleParameter("clientcat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = clientcat;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("minadarea", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm21.Value = "0";
                }
                else
                {
                    prm21.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("TYPE", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = type;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("agencycode", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = agencycode;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm24);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet premiumbindcatwise(string compcode, string advcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpremiumcatwise.bindpremiumcatwise_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("advcatcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = advcatcode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);


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

        public DataSet packagebind(string compcode, string adtype, string pubcenter,int no)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpackage_rate.bindpackage_rate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcenter", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("no", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = no;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;





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

        public DataSet advdatacategory(string compcode, string booking, string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                
                objOraclecommand = GetCommand("book_advcategory.book_advcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("booking", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = booking;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;
               


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

        public DataSet description_go(string compcode, string rateuniqueid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddescription.binddescription_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("rateuniqueid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = rateuniqueid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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
//=======*****************To get Password of User*********************************//
        public DataSet fetchPassword(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetchPassword", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode_p", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid_p", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
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
        
        
        public DataSet bindPagePosition(string compcode, string bookingdate, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("WEBSP_GETPAGEPOSITION_DATEWISE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("bookingdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (bookingdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(bookingdate).ToString("dd-MMMM-yyyy");
                }
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


        public DataSet bindratecode(string compcode, string ratecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("binndratecode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_ratecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ratecode;
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
