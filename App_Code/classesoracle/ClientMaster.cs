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
    /// Summary description for ClientMaster
    /// </summary>
    public class ClientMaster : orclconnection
    {
        public ClientMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet addcity()
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientfillcity.clientfillcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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
        public DataSet bind_rate(string userid, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rategroupbind.rategroupbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
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

        public DataSet getClientNamelist(string client, string compcode, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getclientnameadd.getclientnameadd_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("datecheck", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("client", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = client;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("value", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = value;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


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




        public DataSet addpickdistname(string citycode)//
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillstaedistcountry.fillstaedistcountry_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = citycode;
                objOraclecommand.Parameters.Add(prm2);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;



                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

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


        public DataSet addclientsave(string compcode, string custcode, string custname, string custalias, string add1, string street, string citycode, string zip, string dist, string state, string country, string phone1, string phone2, string fax, string email, string url, string vats, string servicetax, string pan, string creditdays, string paymodecode, string custstatus, string statusreason, string alert, string userid, string zone, string region, string crdlimit, int i, string rategroup, string clientcat, string taluka, string agency_sav, string clinttype, string agencycode, string type, string parent, string oldclient, string designation, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt, string branch, string gstaus, string gstdate, string gstin, string gstapp, string gstcltyp,string gstarno,string gstprovid)
        {
           
////////
            /////




            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientsave.clientsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("flag1", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = i;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("zone", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = zone;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("region1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = region;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("crdlimit", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = crdlimit;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = custcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("custname", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = custname;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("custalias", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = custalias;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("add1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = add1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("street", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = street;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = citycode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("zip", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = zip;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("dist", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = dist;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("state", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = state;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("country", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = country;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("phone1", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = phone1;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("phone2", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = phone2;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = fax;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("emailid", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = email;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("url1", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = url;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("vats", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = vats;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("servicetax1", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = servicetax;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pan1", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = pan;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("creditdays", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = creditdays;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("paymodecode", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = paymodecode;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("custstatus", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = custstatus;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("statusreason", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = statusreason;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("alert", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = alert;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = userid;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("rategroup", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = rategroup;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("clientcat", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = clientcat;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("taluka1", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = taluka;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("agency_sav", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = agency_sav;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("p_CLIENT_TYPE", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = clinttype;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("p_QBC_AGENCY", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = agencycode;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("p_type", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = type;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("p_parent", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = parent;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("poldclient", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = oldclient;
                objOraclecommand.Parameters.Add(prm38);


                OracleParameter prm39 = new OracleParameter("pdesignantion", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = designation;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("pdiscount", OracleType.VarChar, 500);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = discount;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pdiscamt", OracleType.VarChar, 500);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = discamt;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("pffdisctype", OracleType.VarChar, 500);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = ffdiscount;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("pffdiscamt", OracleType.VarChar, 500);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = ffdiscamt;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("pcashdisc", OracleType.VarChar, 500);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("pcashamt", OracleType.VarChar, 500);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = cashamt;
                objOraclecommand.Parameters.Add(prm45);

		OracleParameter prm46 = new OracleParameter("pbranch", OracleType.VarChar, 500);  //30sep15
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = branch;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm223 = new OracleParameter("pgstaus", OracleType.VarChar, 50);
                prm223.Direction = ParameterDirection.Input;
                prm223.Value = gstaus;
                objOraclecommand.Parameters.Add(prm223);

                OracleParameter prm224 = new OracleParameter("pgstdate", OracleType.VarChar, 50);
                prm224.Direction = ParameterDirection.Input;
                if (gstdate == "")
                {
                    prm224.Value = System.DBNull.Value;
                }
                else
                {

                    string[] arr = gstdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        gstdate = mm + "/" + dd + "/" + yy;

                        prm224.Value = Convert.ToDateTime(gstdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm224);

                OracleParameter prm225 = new OracleParameter("pgstin", OracleType.VarChar, 50);
                prm225.Direction = ParameterDirection.Input;
                prm225.Value = gstin;
                objOraclecommand.Parameters.Add(prm225);

                OracleParameter prm226 = new OracleParameter("pgstapp", OracleType.VarChar, 50);
                prm226.Direction = ParameterDirection.Input;
                prm226.Value = gstapp;
                objOraclecommand.Parameters.Add(prm226);

                OracleParameter prm227 = new OracleParameter("pgstcltyp", OracleType.VarChar, 50);
                prm227.Direction = ParameterDirection.Input;
                prm227.Value = gstcltyp;
                objOraclecommand.Parameters.Add(prm227);

                OracleParameter prm227ttt = new OracleParameter("pgstprovid", OracleType.VarChar, 50);
                prm227ttt.Direction = ParameterDirection.Input;
                prm227ttt.Value = gstprovid;
                objOraclecommand.Parameters.Add(prm227ttt);

                OracleParameter prm227tttt = new OracleParameter("pgstarno", OracleType.VarChar, 50);
                prm227tttt.Direction = ParameterDirection.Input;
                prm227tttt.Value = gstarno;
                objOraclecommand.Parameters.Add(prm227tttt);

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

        public DataSet ClientDelete(string compcode, string custcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ClientDelete.ClientDelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm6 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = custcode;
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
                CloseConnection(ref objOracleConnection);
            }

        }



        public DataSet ClientDeleteclear(string compcode, string custcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Clientclearnew.Clientclearnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pCompCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm6 = new OracleParameter("pcustcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = custcode;
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
                CloseConnection(ref objOracleConnection);
            }

        }



        public void addclientmodify(string compcode, string custcode, string custname, string custalias, string add1, string street, string citycode, string zip, string dist, string state, string country, string phone1, string phone2, string fax, string email, string url, string vats, string servicetax, string pan, string creditdays, string paymodecode, string custstatus, string statusreason, string alert, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientmodify.clientmodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = custcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("custname", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = custname;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("custalias", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = custalias;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("add1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = add1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("street", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = street;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = citycode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("zip", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = zip;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("dist", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = dist;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("state", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = state;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("country", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = country;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("phone1", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = phone1;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("phone2", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = phone2;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = fax;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("emailid", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = email;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("url", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = url;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("vats", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = vats;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("servicetax", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = servicetax;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pan", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = pan;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("creditdays", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = creditdays;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("paymodecode", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = paymodecode;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("custstatus", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = custstatus;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("statusreason", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = statusreason;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("alert", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = alert;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = userid;
                objOraclecommand.Parameters.Add(prm29);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);


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

        public DataSet addclientexecute(string compcode, string custcode, string custname, string custalias, string citycode, string custstatus, string userid, string rategroup, string country, string agency_sav, string parent, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("clientexecute.clientexecute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm30 = new OracleParameter("rategroup", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                if (rategroup == "0")
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = rategroup;
                }
                objOraclecommand.Parameters.Add(prm30);


                OracleParameter prm29 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = userid;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm15 = new OracleParameter("country", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (country == "0")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = country;
                }
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm6 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = custcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("custname", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = custname;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = custalias;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm11 = new OracleParameter("citycode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (citycode == "0")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = citycode;
                }
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm26 = new OracleParameter("status", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                if (custstatus == "0" || custstatus == null)
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                {
                    prm26.Value = custstatus;
                }

                //prm26.Value = custstatus;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agency_sav", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = agency_sav;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("p_parent", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = parent;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm40 = new OracleParameter("pdiscount", OracleType.VarChar, 500);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = discount;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pdiscamt", OracleType.VarChar, 500);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = discamt;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("pffdisctype", OracleType.VarChar, 500);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = ffdiscount;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("pffdiscamt", OracleType.VarChar, 500);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = ffdiscamt;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("pcashdisc", OracleType.VarChar, 500);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("pcashamt", OracleType.VarChar, 500);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = cashamt;
                objOraclecommand.Parameters.Add(prm45);

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


        public DataSet getClientName(string compcode, string client)
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
                objOraclecommand = GetCommand("websp_getclientNameclient.websp_getclientNameclient_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("client", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = client;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
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






        /*******************auto code generation****************************/
        public DataSet autocode(string str)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientautocode.clientautocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm3.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm3);
                }
                else
                {
                    prm3.Value = str;
                    objOraclecommand.Parameters.Add(prm3);

                }



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

        ///////////////////////////////////////////////////////////////////


        // First ,Next,Previous,Last Records Fetching Function

        public DataSet ClientQuery(string Comp_Code, string userid, string Client_Code)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ClientQuery.ClientQuery_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Comp_Code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Client_Code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Client_Code;
                objOraclecommand.Parameters.Add(prm4);


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


        public DataSet chkshow(string compcode, string userid, string custcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkclientshow.chkclientshow_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = custcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;

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
        //*******************************************************************************************************
        //****************By Manish Verma************************************************************************
        //*********This Function Check Duplicate Record ********************************************************
        public DataSet chkDupUDefine(string custCode, string custName)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientuserdefine.clientuserdefine_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("cust_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = custCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cust_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = custName;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


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
        //*******************************************************************************************************


        //public DataSet addclientsave(string custname, string custcode)
        //{

        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("clientusercode.clientusercode_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = custname;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = custcode;
        //        objOraclecommand.Parameters.Add(prm2);


        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }

        //}



        public DataSet bind_clintname(string comp_code, string catcode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                //string query = "select  Get_unit_type('" + comp_code + "','" + unit_code + "') from dual";
                string query = "select  ADD_GET_CLIENT_NAME('" + comp_code + "','" + catcode + "') from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

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

        public DataSet getClientNa(string compcode, string client, string center)
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
                objOraclecommand = GetCommand("Add_bindParentclient", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objOraclecommand.Parameters.Add(prm3);

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


        public DataSet cilntnamebind(string custCode, string clintName)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindclient11new.bindclient11new_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = custCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("client", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = clintName;
                objOraclecommand.Parameters.Add(prm3);

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


    }
}

