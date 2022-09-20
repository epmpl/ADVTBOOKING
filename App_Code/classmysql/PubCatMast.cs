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
/// Summary description for PubCatMast
/// </summary>
public class PubCatMast:connection 
{
	public PubCatMast()
	{
		//
		// TODO: Add constructor logic here
		//
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
                objmysqlcommand = GetCommand("BODYFILLSTAEDISTCOUNTRY_fillstaedistcountry_p", ref objmysqlconnection);
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
    public DataSet insertpcm(string compcode, string centercode, string centername, string alias, string add1, string street, string city, string dist, string country, string phone1, string phone2, string pin, string state, string fax, string email, string remarks, string userid, string region, string zone, string fax1, string boxaddress, string printval)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("pcminsert", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlcommand.Parameters.Add("centercode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["centercode"].Value =centercode;

					objmysqlcommand.Parameters.Add("centername", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["centername"].Value =centername;

					objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alias"].Value =alias;

					objmysqlcommand.Parameters.Add("add1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["add1"].Value =add1;

					objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["street"].Value =street;

					objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["city"].Value =city;

					objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["dist"].Value =dist;

					
				objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["country"].Value =country;

				objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone1"].Value =phone1;

				objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone2"].Value =phone2;

					

				objmysqlcommand.Parameters.Add("pin", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pin"].Value =pin;

				objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["state"].Value =state;

				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("email", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["email"].Value =email;


				objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["remarks"].Value =remarks;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("fax1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax1"].Value = fax1;

                objmysqlcommand.Parameters.Add("boxaddress", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxaddress"].Value = boxaddress;

                objmysqlcommand.Parameters.Add("printval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["printval"].Value = printval;

                				
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


        public DataSet updatepcm(string compcode, string centercode, string centername, string alias, string add1, string street, string city, string dist, string country, string phone1, string phone2, string pin, string state, string fax, string email, string remarks, string userid, string region, string zone, string fax1,string boxadd11,string printval)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("pcmupdate", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlcommand.Parameters.Add("centercode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["centercode"].Value =centercode;

				objmysqlcommand.Parameters.Add("centername", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["centername"].Value =centername;

				objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alias"].Value =alias;

				objmysqlcommand.Parameters.Add("add1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["add1"].Value =add1;

				objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["street"].Value =street;

				objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["city"].Value =city;

				objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["dist"].Value =dist;

					
				objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["country"].Value =country;

				objmysqlcommand.Parameters.Add("phone1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone1"].Value =phone1;

				objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone2"].Value =phone2;

				objmysqlcommand.Parameters.Add("pin", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pin"].Value =pin;

				objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["state"].Value =state;

				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("email", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["email"].Value =email;


				objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["remarks"].Value =remarks;


                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("fax1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax1"].Value = fax1;

                objmysqlcommand.Parameters.Add("boxadd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["boxadd"].Value = boxadd11;

                objmysqlcommand.Parameters.Add("printval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["printval"].Value = printval;
				
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



        public DataSet pcmexe(string compcode, string centcode, string centname, string alias, string country, string city, string companyname, string state, string MRV, string agcode, string dpcode)
		{
			 MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmexe_pcmexe_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value =centcode;
                
				objmysqlcommand.Parameters.Add("centname", MySqlDbType.VarChar);
               	objmysqlcommand.Parameters["centname"].Value =centname;
              
				objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alias"].Value =alias;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

				objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["city"].Value =city;

                objmysqlcommand.Parameters.Add("pcompname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcompname"].Value = companyname;

                objmysqlcommand.Parameters.Add("pstate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pstate"].Value =state ;

                objmysqlcommand.Parameters.Add("pmrv", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pmrv"].Value = MRV;

                objmysqlcommand.Parameters.Add("pcir_agcdpo_upd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcir_agcdpo_upd"].Value = agcode;

                objmysqlcommand.Parameters.Add("pcir_dpcdpo_upd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcir_dpcdpo_upd"].Value = dpcode;

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


        public DataSet addregion(string regioncode)
        {
             MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmaddregion_pcmaddregion_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("regioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["regioncode"].Value = regioncode;


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




        public DataSet checkpubcode(string compcode, string centcode, string userid)
        {
             MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpubcatcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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


      


        public DataSet getbind(string centcode, string compcode, string userid, string dateformat)
		{
			 MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 	
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("pcmbinddata", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = dateformat;


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

		public DataSet pcmfnpl(string compcode, string userid)
		{
			 MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("pcmfnpl", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

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

        public DataSet pcmdel(string compcode, string centercode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmdel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

             

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centercode;


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





        public DataSet chkpcm(string compcode, string userid, string centcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkpcm", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;


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

        //pankaj//

        public DataSet chkcity(string compcode, string userid, string centername, string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("centername", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centername"].Value = centername;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;



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

        // for modify saurabh agarwal

        public DataSet chkcitymodify(string compcode, string userid, string centername, string city, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkcitymodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centername", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centername"].Value = centername;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;


                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;

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


        public DataSet pcmstatuscheck(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmstatuschk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status"].Value = status;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);
                    // com.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
                }


                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);
                }
                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = dateformat;

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

        //Code for the insert the status by clicking on link Button//
        public DataSet insertpcmstatus(string compcode, string userid, string centcode, string status, string fromdate, string todate, string circular)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmstatusin1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = status;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);
                    // com.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
                }

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);
                }

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



        public DataSet pcmstatuscheck12(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string dateformat, string codepass)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmstatuschk12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = status;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["todate"].Value = todate;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = dateformat;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = codepass;

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





        //Code for the Update the status by clicking on link Button//
        public DataSet updatepcmstatus(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string codepass)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmstatusupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = status;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);
                }
                //objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["todate"].Value = todate;
                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);
                }

                //objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = codepass;

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




        //Code for the Delete the status by clicking on link Button//
        public DataSet deletepcmstatus(string centcode, string compcode, string userid, string codepass)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmstatdel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = codepass;

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





        public DataSet selectpcmstatus(string centcode, string compcode, string userid, string code11, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmselect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;


                objmysqlcommand.Parameters.Add("code11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code11"].Value = code11;


                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;


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


        //Code for the Update the Contact of person  by clicking on link Button//
        public DataSet contactupdate(string contactperson, string dob, string desi, string phone, string ext, string fax, string mail, string compcode, string userid, string centcode, string update)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmcontactupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactperson"].Value = contactperson;

                objmysqlcommand.Parameters.Add("desi", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["desi"].Value = desi;


                objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["dob"].Value = Convert.ToDateTime(dob);

                objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone"].Value = phone;

                objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ext"].Value = ext;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlcommand.Parameters.Add("update1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["update1"].Value = update;




                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        //Code for the Insert the Contact of person  by clicking on link Button//
    public DataSet insertcontact(string contact, string dob, string desi, string phone, string ext, string fax, string mail, string userid, string centcode, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmcontactdetails", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("contact", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contact"].Value = contact;

                objmysqlcommand.Parameters.Add("desi", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["desi"].Value = desi;


                objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
                if (dob == "" || dob == null || dob == "Undefined")
                {
                    objmysqlcommand.Parameters["dob"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
                }

                objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
                //if (Comment =="" || Comment==null)
                objmysqlcommand.Parameters["phone"].Value = phone;
                //else

                objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ext"].Value = ext;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

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




        public DataSet pcmcontbind(string centcode, string compcode, string userid, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmcontbind1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = dateformat;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (MySqlException objException)
            {
                throw (objException);
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



        //Code for the Select the Contact of person  by clicking on Check boxes//
        public DataSet selpcmbind(string centcode, string userid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmselcont", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("contcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contcode"].Value = centcode;


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
        //Code for the Delete the Contact of person  by clicking on Delete Button//
        public DataSet pcmcontdelete(string centcode, string compcode, string userid, string update)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmcontdelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("update1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["update1"].Value = update;

              
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet pubcatcode(/*string cod, */string str)//, string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autopubcatcode_autopubcatcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;
                


                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length >2)
                {
                objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }

                //objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("company_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["company_code"].Value = "";

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
        public DataSet bindcontact(string compcode, string userid, string centcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pcmbinddata", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;


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

        public DataSet chkcolor(string contactperson1, string centcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pub_chkname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("contactper", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactper"].Value = contactperson1;

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

        //txtphoneno,txtext,txtfaxno,mail,desi,txtdob

        public DataSet chkcolormod(string contactperson1, string centcode, string compcode, string txtphoneno, string txtext, string txtfaxno, string mail, string desi, string txtdob)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();    

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pub_chkname_mod", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

               
                objmysqlcommand.Parameters.Add("centcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centcode"].Value = centcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("contactper", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["contactper"].Value = contactperson1;


                objmysqlcommand.Parameters.Add("txtphoneno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtphoneno"].Value = txtphoneno;

                objmysqlcommand.Parameters.Add("txtext", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtext"].Value = txtext;

                objmysqlcommand.Parameters.Add("txtfaxno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtfaxno"].Value = txtfaxno;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

                objmysqlcommand.Parameters.Add("desi", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["desi"].Value = desi;

                objmysqlcommand.Parameters.Add("txtdob", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtdob"].Value = txtdob;

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

    public DataSet pubcodechk(string str,string comp)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkpubcatcode", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["str"].Value = str;
            objmysqlcommand.Parameters.Add("company_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["company_code"].Value = comp;
            
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


    public DataSet chkusercode(string compcode, string code)
    {

        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("pcmusercodechk", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code1"].Value = code;

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

    public DataSet pubnamechk(string str)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkbranchname", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["str"].Value = str;

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


    }
}
