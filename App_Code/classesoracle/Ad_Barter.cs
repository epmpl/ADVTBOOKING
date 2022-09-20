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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.classesoracle
{

    public class Ad_Barter : orclconnection
    {
        public Ad_Barter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet uombind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("uomadsize.uomadsize_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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

        public DataSet getPubCenter(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("publication_proc.publication_proc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet getQBC(string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_QBC.websp_QBC_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }

        public DataSet bindagency(string compcode,string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

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
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet savebarter(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt,  string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks,string dateformat,string productdesc,string barteruom,string barterkilldate,string strbook,string client)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Adbarter_save", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("unitcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("branchcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("agencode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencycode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("subagencode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("bartercode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = bartercode;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("barterdesc", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = barterdesc;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("barterstdt", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (barterstdt == "" || barterstdt==null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = barterstdt.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         barterstdt = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(barterstdt).ToString("dd-MMMM-yyyy");
                }
              
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("barterendt", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (barterstdt =="" || barterstdt == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterendt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterendt = mm + "/" + dd + "/" + yy;
                    }
                    prm10.Value = Convert.ToDateTime(barterendt).ToString("dd-MMMM-yyyy");
                }
               
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("prodamt", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ProdAmt;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("barteramt", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = barterAmt;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("barterarea", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = barterArea;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm15 = new OracleParameter("remarks", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = Remarks;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("productdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = productdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("barteruom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = barteruom;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("barterkilldate", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (barterkilldate == "" || barterkilldate == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterkilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterkilldate = mm + "/" + dd + "/" + yy;
                    }
                    prm18.Value = Convert.ToDateTime(barterkilldate).ToString("dd-MMMM-yyyy");
                }
            
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("strbook", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = strbook;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("client", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = client;
                objOraclecommand.Parameters.Add(prm20);

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

        public DataSet updatebarter(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate,string strbook,string client)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Adbarter_modify", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("unitcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("branchcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("agencode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencycode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("subagencode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("bartercode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = bartercode;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("barterdesc", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = barterdesc;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("barterstdt", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (barterstdt == "" || barterstdt == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterstdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterstdt = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(barterstdt).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("barterendt", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (barterstdt == "" || barterstdt == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterendt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterendt = mm + "/" + dd + "/" + yy;
                    }
                    prm10.Value = Convert.ToDateTime(barterendt).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("prodamt", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ProdAmt;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("barteramt", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = barterAmt;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("barterarea", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = barterArea;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm15 = new OracleParameter("remarks", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = Remarks;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("productdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = productdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("barteruom", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = barteruom;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("barterkilldate", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (barterkilldate == "" || barterkilldate == null)
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterkilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterkilldate = mm + "/" + dd + "/" + yy;
                    }
                    prm18.Value = Convert.ToDateTime(barterkilldate).ToString("dd-MMMM-yyyy");
                }

                OracleParameter prm19 = new OracleParameter("strbook", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = strbook;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("client", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = client;
                objOraclecommand.Parameters.Add(prm20);

                objOraclecommand.Parameters.Add(prm18);

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


        public DataSet checkdupbarter(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string agencycode, string subagencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Adbarter_checkduplicacy", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("bartercode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bartercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("unitcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("branchcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("barterdesc", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = barterdesc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("agencycode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = agencycode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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

        //barterexecute(compcode,unitcode, branchcode, bartercode, barterdesc,barterstdt,barterendt,barterkilldate,productdesc);

        public DataSet barterexecute(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string barterstdt, string barterendt, string barterkilldate, string productdesc, string agencycode, string subagencycode, string strbook, string client)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdBarter_Exe", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("bartercode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bartercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("unitcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("branchcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branchcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("barterdesc", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = barterdesc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("productdesc", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = productdesc;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("barterstdt", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = barterstdt;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("barterendt", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = barterendt;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("barterkilldate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value =barterkilldate;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("agencycode", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = agencycode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("subagencycode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("strbook", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = strbook;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("client", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = client;
                objOraclecommand.Parameters.Add(prm13);

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
                CloseConnection(ref objOracleConnection);
            }

        }


        public void barterdelete(string bartercode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Adbarter_delete", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("bartercode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bartercode;
                objOraclecommand.Parameters.Add(prm2);


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

        //--------------autogenerate-------------------//
        public DataSet barterautocode(string str, string compcode, string unitcode, string branchcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autoabartercode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2);
                }
                else
                {
                    prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("unitcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("branchcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = branchcode;
                objOraclecommand.Parameters.Add(prm5);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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