using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
/// <summary>
/// Summary description for ClientMaster
/// </summary>
public class ClientMaster:connection
{
	public ClientMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet addcity()
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("clientfillcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
                CloseConnection(ref objmysqlconnection);
			}

		}
    public DataSet bind_rate(string userid,string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("rategroupbind_rategroupbind_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }
    }

    public DataSet getClientNamelist(string client, string compcode, string value)
    {
        string zonename = "";
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("getclientnameadd", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;
            objmysqlcommand.Parameters.Add("client", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["client"].Value = client;

            objmysqlcommand.Parameters.Add("value", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["value"].Value = value;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;

            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }

    }

		

		public DataSet addpickdistname(string citycode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillstaedistcountry_fillstaedistcountry_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["citycode"].Value =citycode;
                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}

		}


    public DataSet addclientsave(string compcode, string custcode, string custname, string custalias, string add1, string street, string citycode, string zip, string dist, string state, string country, string phone1, string phone2, string fax, string email, string url, string vats, string servicetax, string pan, string creditdays, string paymodecode, string custstatus, string statusreason, string alert, string userid, string zone, string region, string crdlimit, int i, string rategroup, string clientcat, string taluka, string agency_sav)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("clientsave_clientsave_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

			
				objmysqlcommand.Parameters.Add("flag1", MySqlDbType.Int24);
				objmysqlcommand.Parameters["flag1"].Value =i;
			
				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["zone"].Value =zone;
				
                objmysqlcommand.Parameters.Add("region1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["region1"].Value =region;
				
                objmysqlcommand.Parameters.Add("crdlimit", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["crdlimit"].Value =crdlimit;
				
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;


				objmysqlcommand.Parameters.Add("custname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custname"].Value =custname;

				objmysqlcommand.Parameters.Add("custalias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custalias"].Value =custalias;

				objmysqlcommand.Parameters.Add("add1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["add1"].Value =add1;
              				
				objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["street"].Value =street;

				objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["citycode"].Value =citycode;

				objmysqlcommand.Parameters.Add("zip", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["zip"].Value =zip;

				objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["dist"].Value =dist;

				objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["state"].Value =state;

				objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["country"].Value =country;

				objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone1"].Value =phone1;

				objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone2"].Value =phone2;

				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["emailid"].Value =email;

				objmysqlcommand.Parameters.Add("url", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["url"].Value =url;

				objmysqlcommand.Parameters.Add("vats", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["vats"].Value =vats;

				objmysqlcommand.Parameters.Add("servicetax1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["servicetax1"].Value =servicetax;

				objmysqlcommand.Parameters.Add("pan1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pan1"].Value =pan;

				objmysqlcommand.Parameters.Add("creditdays", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["creditdays"].Value =creditdays;

				objmysqlcommand.Parameters.Add("paymodecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["paymodecode"].Value =paymodecode;

				objmysqlcommand.Parameters.Add("custstatus", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custstatus"].Value =custstatus;

				objmysqlcommand.Parameters.Add("statusreason", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["statusreason"].Value =statusreason;

				objmysqlcommand.Parameters.Add("alert", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alert"].Value =alert;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("rategroup", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroup"].Value = rategroup;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka;

                objmysqlcommand.Parameters.Add("agency_sav", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency_sav"].Value = agency_sav;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}

		}
    //==========================================================================================//
    public DataSet addclientmodify(string compcode, string custcode, string custname, string custalias, string add1, string street, string citycode, string zip, string dist, string state, string country, string phone1, string phone2, string fax, string email, string url, string vats, string servicetax, string pan, string creditdays, string paymodecode, string custstatus, string statusreason, string alert, string userid, string zone, string region, string crdlimit, int i, string rategroup, string clientcat)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("clientsave1", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("flag", MySqlDbType.Int24);
            objmysqlcommand.Parameters["flag"].Value = i;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;


            objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["zone"].Value = zone;

            objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["region"].Value = region;

            objmysqlcommand.Parameters.Add("crdlimit", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["crdlimit"].Value = crdlimit;

            objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["custcode"].Value = custcode;


            objmysqlcommand.Parameters.Add("custname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["custname"].Value = custname;

            objmysqlcommand.Parameters.Add("custalias", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["custalias"].Value = custalias;

            objmysqlcommand.Parameters.Add("add1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["add1"].Value = add1;

            objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["street"].Value = street;

            objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["citycode"].Value = citycode;

            objmysqlcommand.Parameters.Add("zip", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["zip"].Value = zip;

            objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["dist"].Value = dist;

            objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["state"].Value = state;

            objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["country"].Value = country;

            objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["phone1"].Value = phone1;

            objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["phone2"].Value = phone2;

            objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fax"].Value = fax;

            objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["emailid"].Value = email;

            objmysqlcommand.Parameters.Add("url", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["url"].Value = url;

            objmysqlcommand.Parameters.Add("vats", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["vats"].Value = vats;

            objmysqlcommand.Parameters.Add("servicetax", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["servicetax"].Value = servicetax;

            objmysqlcommand.Parameters.Add("pan", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pan"].Value = pan;

            objmysqlcommand.Parameters.Add("creditdays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["creditdays"].Value = creditdays;

            objmysqlcommand.Parameters.Add("paymodecode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["paymodecode"].Value = paymodecode;

            objmysqlcommand.Parameters.Add("custstatus", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["custstatus"].Value = custstatus;

            objmysqlcommand.Parameters.Add("statusreason", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["statusreason"].Value = statusreason;

            objmysqlcommand.Parameters.Add("alert", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["alert"].Value = alert;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("rategroup", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["rategroup"].Value = rategroup;

            objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["clientcat"].Value = clientcat;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }

    }
    //*******************************************************************************************//
    

		public  DataSet ClientDelete(string compcode,string custcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ClientDelete_ClientDelete_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

			
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}

		}




		public void addclientmodify(string compcode,string custcode,string custname,string custalias,string add1,string street,string citycode,string zip,string dist,string state,string country,string phone1,string phone2,string fax,string email,string url,string vats,string servicetax,string pan,string creditdays,string paymodecode,string custstatus,string statusreason,string alert,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("clientmodify", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;


				objmysqlcommand.Parameters.Add("custname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custname"].Value =custname;

				objmysqlcommand.Parameters.Add("custalias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custalias"].Value =custalias;

				objmysqlcommand.Parameters.Add("add1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["add1"].Value =add1;
              				
				objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["street"].Value =street;

				objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["citycode"].Value =citycode;

				objmysqlcommand.Parameters.Add("zip", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["zip"].Value =zip;

				objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["dist"].Value =dist;

				objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["state"].Value =state;

				objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["country"].Value =country;

				objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone1"].Value =phone1;

				objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone2"].Value =phone2;

				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["emailid"].Value =email;

				objmysqlcommand.Parameters.Add("url", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["url"].Value =url;

				objmysqlcommand.Parameters.Add("vats", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["vats"].Value =vats;

				objmysqlcommand.Parameters.Add("servicetax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["servicetax"].Value =servicetax;

				objmysqlcommand.Parameters.Add("pan", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pan"].Value =pan;

				objmysqlcommand.Parameters.Add("creditdays", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["creditdays"].Value =creditdays;

				objmysqlcommand.Parameters.Add("paymodecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["paymodecode"].Value =paymodecode;

				objmysqlcommand.Parameters.Add("custstatus", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custstatus"].Value =custstatus;

				objmysqlcommand.Parameters.Add("statusreason", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["statusreason"].Value =statusreason;

				objmysqlcommand.Parameters.Add("alert", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alert"].Value =alert;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                //return objDataSet;
				
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}

		}

		public DataSet addclientexecute(string compcode,string custcode,string custname,string custalias,string citycode,string custstatus,string userid,string rategroup,string country)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();	
			try
			{
				objmysqlconnection.Open();

                objmysqlcommand = GetCommand("clientexecute_clientexecute_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

                objmysqlcommand.Parameters.Add("rategroup", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroup"].Value = rategroup;
				
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;


				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
                //if(custcode== null || custcode=="")
                //{
                //    objmysqlcommand.Parameters["custcode"].Value ="%%";
                //}
                //else
                //{
					objmysqlcommand.Parameters["custcode"].Value =custcode;
                //}



				objmysqlcommand.Parameters.Add("custname", MySqlDbType.VarChar);
                //if(custname== null || custname=="" )
                //{
                //    objmysqlcommand.Parameters["custname"].Value ="%%";
                //}
                //else
                //{
					objmysqlcommand.Parameters["custname"].Value =custname;
                //}



				objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                //if(custalias== null || custalias=="")
                //{
                //    objmysqlcommand.Parameters["alias"].Value ="%%";
                //}
                //else
                //{
					objmysqlcommand.Parameters["alias"].Value =custalias;
                //}


			
				objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);


                if(citycode== null || citycode=="" || citycode=="undefined" || citycode=="0")
                {
                    objmysqlcommand.Parameters["citycode"].Value ="";
                }
			
                else
                {
					objmysqlcommand.Parameters["citycode"].Value =citycode;
                }




				objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                //if(custstatus!= null&& custstatus!="" && custstatus!="undefined")
                //{
                //    objmysqlcommand.Parameters["status"].Value =custstatus;
                //}
                //else
                //{
					objmysqlcommand.Parameters["status1"].Value =custstatus;
                //}

                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objDataSet);
                    return objDataSet;
				
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}

		}
        public DataSet ClientDeleteclear(string compcode, string custcode, string userid)
        {
           
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Clientclearnew_Clientclearnew_p", ref objSqlConnection);
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

    public DataSet getClientName(string compcode, string client)
    {
        string zonename = "";
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("websp_getclientNameclient_websp_getclientNameclient_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;
            objmysqlcommand.Parameters.Add("client", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["client"].Value = client;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }

    }





	/*******************auto code generation****************************/
    public DataSet autocode(string str)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("clientautocode_clientautocode_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["str"].Value = str;

            objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
            if (str.Length > 2)
            {
                objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
            }
            else
            {
                objmysqlcommand.Parameters["cod"].Value = str;

            }
            

            //objmysqlcommand.Parameters.Add("indus", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["indus"].Value = indus;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;

        }

        catch (Exception ex)
        {
            throw (ex);


        }

        finally
        {
            CloseConnection(ref objmysqlconnection);

        }



    }

    ///////////////////////////////////////////////////////////////////


		// First ,Next,Previous,Last Records Fetching Function

		public DataSet ClientQuery(string Comp_Code,string userid,string Client_Code)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ClientQuery_ClientQuery_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Comp_Code"].Value =Comp_Code;

				objmysqlcommand.Parameters.Add("Client_Code", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Client_Code"].Value =Client_Code;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}


		}


		public DataSet chkshow(string compcode,string userid,string custcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("chkclientshow", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}


		}
    //*******************************************************************************************************
    //****************By Manish Verma************************************************************************
    //*********This Function Check Duplicate Record ********************************************************
    public DataSet chkDupUDefine(string custCode,string custName)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("clientuserdefine_clientuserdefine_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("Cust_Code1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Cust_Code1"].Value = custCode;

            objmysqlcommand.Parameters.Add("Cust_Name1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Cust_Name1"].Value = custName;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

        catch (Exception ex)
        {
            throw (ex);


        }

        finally
        {
            CloseConnection(ref objmysqlconnection);

        }
    }
    //*******************************************************************************************************

	}
}
		
