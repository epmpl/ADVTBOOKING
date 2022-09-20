using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClientMaster
/// </summary>
namespace NewAdbooking.Classes
{
    public class ClientMaster : connection
    {
        public ClientMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet addcity()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("clientfillcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet bind_rate(string userid, string compcode)
        {
            SqlConnection con;
            SqlCommand objSqlCommand;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                objSqlCommand = GetCommand("rategroupbind", ref con);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = objSqlCommand;
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

        public DataSet getClientNamelist(string client, string compcode, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getclientnameadd", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }



        public DataSet addpickdistname(string citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillstaedistcountry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet addclientsave(string compcode, string custcode, string custname, string custalias, string add1, string street, string citycode, string zip, string dist, string state, string country, string phone1, string phone2, string fax, string email, string url, string vats, string servicetax, string pan, string creditdays, string paymodecode, string custstatus, string statusreason, string alert, string userid, string zone, string region, string crdlimit, int i, string rategroup, string clientcat, string taluka, string agency_sav, string clinttype, string agencycode, string type, string parent, string oldclient, string clntdesigntion, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt, string branch, string gstaus, string gstdate, string gstin,string gstapp,string gstcltyp,string gstarno,string gstprovid,string gsteftdt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("clientsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@flag", SqlDbType.Int);
                objSqlCommand.Parameters["@flag"].Value = i;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@crdlimit", SqlDbType.VarChar);
                if (crdlimit == "")
                {
                    objSqlCommand.Parameters["@crdlimit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@crdlimit"].Value = crdlimit;
                }

                objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custcode"].Value = custcode;


                objSqlCommand.Parameters.Add("@custname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custname"].Value = custname;

                objSqlCommand.Parameters.Add("@custalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custalias"].Value = custalias;

                objSqlCommand.Parameters.Add("@add1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@add1"].Value = add1;

                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@street"].Value = street;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;

                objSqlCommand.Parameters.Add("@zip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zip"].Value = zip;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@phone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone1"].Value = phone1;

                objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone2"].Value = phone2;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@emailid"].Value = email;

                objSqlCommand.Parameters.Add("@url", SqlDbType.VarChar);
                objSqlCommand.Parameters["@url"].Value = url;

                objSqlCommand.Parameters.Add("@vats", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vats"].Value = vats;

                objSqlCommand.Parameters.Add("@servicetax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@servicetax"].Value = servicetax;

                objSqlCommand.Parameters.Add("@pan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pan"].Value = pan;

                objSqlCommand.Parameters.Add("@creditdays", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditdays"].Value = creditdays;

                objSqlCommand.Parameters.Add("@paymodecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymodecode"].Value = paymodecode;

                objSqlCommand.Parameters.Add("@custstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custstatus"].Value = custstatus;

                objSqlCommand.Parameters.Add("@statusreason", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusreason"].Value = statusreason;

                objSqlCommand.Parameters.Add("@alert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alert"].Value = alert;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@rategroup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroup"].Value = rategroup;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@taluka", SqlDbType.VarChar);
                objSqlCommand.Parameters["@taluka"].Value = taluka;

                objSqlCommand.Parameters.Add("@agency_sav", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_sav"].Value = agency_sav;

                objSqlCommand.Parameters.Add("@p_CLIENT_TYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_CLIENT_TYPE"].Value = clinttype;

                objSqlCommand.Parameters.Add("@p_QBC_AGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_QBC_AGENCY"].Value = agencycode;

                objSqlCommand.Parameters.Add("@p_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_type"].Value = type;

                objSqlCommand.Parameters.Add("@p_parent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_parent"].Value = parent;

                objSqlCommand.Parameters.Add("@poldclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@poldclient"].Value = oldclient;

                objSqlCommand.Parameters.Add("@cldesignation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cldesignation"].Value = clntdesigntion;

                objSqlCommand.Parameters.Add("@pdiscount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscount"].Value = discount;

                objSqlCommand.Parameters.Add("@pdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscamt"].Value = discamt;

                objSqlCommand.Parameters.Add("@pffdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdisctype"].Value = ffdiscount;

                objSqlCommand.Parameters.Add("@pffdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdiscamt"].Value = ffdiscamt;

                objSqlCommand.Parameters.Add("@pcashdisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashdisc"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@pcashamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashamt"].Value = cashamt;

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);  //30sep15
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@pgstaus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstaus"].Value = gstaus;


                objSqlCommand.Parameters.Add("@pgstdate", SqlDbType.VarChar);
                if (gstdate == "")
                {
                    objSqlCommand.Parameters["@pgstdate"].Value = System.DBNull.Value;
                }
                else
                {

                    string[] arr = gstdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        gstdate = mm + "/" + dd + "/" + yy;
                   
                    objSqlCommand.Parameters["@pgstdate"].Value = Convert.ToDateTime(gstdate);
                }

                objSqlCommand.Parameters.Add("@pgstin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstin"].Value = gstin;

                objSqlCommand.Parameters.Add("@pgstapp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstapp"].Value = gstapp;

                objSqlCommand.Parameters.Add("@pgstcltyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstcltyp"].Value = gstcltyp;

                objSqlCommand.Parameters.Add("@pgstarno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstarno"].Value = gstarno;

                objSqlCommand.Parameters.Add("@pgstprovid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstprovid"].Value = gstprovid;

                objSqlCommand.Parameters.Add("@pgsteftdt", SqlDbType.VarChar);
                if (gsteftdt == "")
                {
                    objSqlCommand.Parameters["@pgsteftdt"].Value = System.DBNull.Value;
                }
                else
                {

                    string[] arr = gsteftdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    gsteftdt = mm + "/" + dd + "/" + yy;

                    objSqlCommand.Parameters["@pgsteftdt"].Value = Convert.ToDateTime(gsteftdt);
                }

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet ClientDelete(string compcode, string custcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ClientDelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custcode"].Value = custcode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }




        public DataSet ClientDeleteclear(string compcode, string custcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ClientDeleteclear", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custcode"].Value = custcode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public void addclientmodify(string compcode, string custcode, string custname, string custalias, string add1, string street, string citycode, string zip, string dist, string state, string country, string phone1, string phone2, string fax, string email, string url, string vats, string servicetax, string pan, string creditdays, string paymodecode, string custstatus, string statusreason, string alert, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("clientmodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custcode"].Value = custcode;


                objSqlCommand.Parameters.Add("@custname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custname"].Value = custname;

                objSqlCommand.Parameters.Add("@custalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custalias"].Value = custalias;

                objSqlCommand.Parameters.Add("@add1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@add1"].Value = add1;

                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@street"].Value = street;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;

                objSqlCommand.Parameters.Add("@zip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zip"].Value = zip;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@phone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone1"].Value = phone1;

                objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone2"].Value = phone2;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@emailid"].Value = email;

                objSqlCommand.Parameters.Add("@url", SqlDbType.VarChar);
                objSqlCommand.Parameters["@url"].Value = url;

                objSqlCommand.Parameters.Add("@vats", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vats"].Value = vats;

                objSqlCommand.Parameters.Add("@servicetax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@servicetax"].Value = servicetax;

                objSqlCommand.Parameters.Add("@pan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pan"].Value = pan;

                objSqlCommand.Parameters.Add("@creditdays", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditdays"].Value = creditdays;

                objSqlCommand.Parameters.Add("@paymodecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymodecode"].Value = paymodecode;

                objSqlCommand.Parameters.Add("@custstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custstatus"].Value = custstatus;

                objSqlCommand.Parameters.Add("@statusreason", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusreason"].Value = statusreason;

                objSqlCommand.Parameters.Add("@alert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alert"].Value = alert;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet addclientexecute(string compcode, string custcode, string custname, string custalias, string citycode, string custstatus, string userid, string rategroup, string country, string agency_sav, string parent, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                objSqlCommand = GetCommand("clientexecute", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rategroup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroup"].Value = rategroup;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;


                objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
                //if(custcode== null || custcode=="")
                //{
                //    objSqlCommand.Parameters["@custcode"].Value ="%%";
                //}
                //else
                //{
                objSqlCommand.Parameters["@custcode"].Value = custcode;
                //}



                objSqlCommand.Parameters.Add("@custname", SqlDbType.VarChar);
                //if(custname== null || custname=="" )
                //{
                //    objSqlCommand.Parameters["@custname"].Value ="%%";
                //}
                //else
                //{
                objSqlCommand.Parameters["@custname"].Value = custname;
                //}



                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                //if(custalias== null || custalias=="")
                //{
                //    objSqlCommand.Parameters["@alias"].Value ="%%";
                //}
                //else
                //{
                objSqlCommand.Parameters["@alias"].Value = custalias;
                //}



                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);


                //if(citycode== null || citycode=="" || citycode=="undefined" || citycode=="0")
                //{
                //    objSqlCommand.Parameters["@citycode"].Value ="%%";
                //    //objSqlCommand.Parameters["@citycode"].Value ="0";
                //}

                //else
                //{
                objSqlCommand.Parameters["@citycode"].Value = citycode;
                //}




                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                //if(custstatus!= null&& custstatus!="" && custstatus!="undefined")
                //{
                //    objSqlCommand.Parameters["@status"].Value =custstatus;
                //}
                //else
                //{
                objSqlCommand.Parameters["@status"].Value = custstatus;
                //}

                objSqlCommand.Parameters.Add("@agency_sav", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_sav"].Value = agency_sav;

                objSqlCommand.Parameters.Add("@p_parent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_parent"].Value = parent;

                objSqlCommand.Parameters.Add("@pdiscount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscount"].Value = discount;

                objSqlCommand.Parameters.Add("@pdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiscamt"].Value = discamt;

                objSqlCommand.Parameters.Add("@pffdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdisctype"].Value = ffdiscount;

                objSqlCommand.Parameters.Add("@pffdiscamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pffdiscamt"].Value = ffdiscamt;

                objSqlCommand.Parameters.Add("@pcashdisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashdisc"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@pcashamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcashamt"].Value = cashamt;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet getClientName(string compcode, string client)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }





        /*******************auto code generation****************************/
        public DataSet autocode(string str)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("clientautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

                //cmd.Parameters.Add("@indus", SqlDbType.VarChar);
                //cmd.Parameters["@indus"].Value = indus;

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

        ///////////////////////////////////////////////////////////////////


        // First ,Next,Previous,Last Records Fetching Function

        public DataSet ClientQuery(string Comp_Code, string userid, string Client_Code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ClientQuery", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = Comp_Code;

                objSqlCommand.Parameters.Add("@Client_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Client_Code"].Value = Client_Code;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }


        public DataSet chkshow(string compcode, string userid, string custcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkclientshow", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@custcode"].Value = custcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }


        }
        //*******************************************************************************************************
        //****************By Manish Verma************************************************************************
        //*********This Function Check Duplicate Record ********************************************************
        public DataSet chkDupUDefine(string custCode, string custName)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("clientuserdefine", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Cust_Code", SqlDbType.VarChar);
                cmd.Parameters["@Cust_Code"].Value = custCode;

                cmd.Parameters.Add("@Cust_Name", SqlDbType.VarChar);
                cmd.Parameters["@Cust_Name"].Value = custName;

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
        //*******************************************************************************************************
        public DataSet bind_clintname(string comp_code, string catcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "select  dbo.ADD_GET_CLIENT_NAME('" + comp_code + "','" + catcode + "')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objSqlConnection.Close();
            }
        }


        public DataSet getClientNa(string compcode, string client)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Add_bindParentclient", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet cilntnamebind(string custCode, string clintName)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("bindclient11new", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = custCode;

                cmd.Parameters.Add("@client", SqlDbType.VarChar);
                cmd.Parameters["@client"].Value = clintName;

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

    }
}
