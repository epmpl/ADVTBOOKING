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
using MySql.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// Summary description for ClientMasterpopup
/// </summary>

namespace NewAdbooking.classmysql
{
public class ClientMasterpopup:connection
{
	public ClientMasterpopup()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("payfill", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = hiddenuserid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = hiddencomcode;



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

    public DataSet getData(string clientcode, string userid, string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("Clientpayselect", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;



            objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["custcode"].Value = clientcode;
            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;
            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            //return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }
        return objDataSet;
    }

    public void insertData(string compcode, string custcode, string userid, int i, string strMode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("updateClientPay", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("Cash", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Cash"].Value = strMode;
            //sqlcomm.Parameters.Add("Credit", MySqlDbType.VarChar);
            //sqlcomm.Parameters["Credit"].Value = strMode[1];
            //sqlcomm.Parameters.Add("Bank", MySqlDbType.VarChar);
            //sqlcomm.Parameters["Bank"].Value = strMode[2];
            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("Client_Code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Client_Code"].Value = custcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("Flag", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Flag"].Value = i;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            //return objDataSet;
        }
        catch (Exception ex) 
        { 
            throw (ex); 
        }
        finally
        { CloseConnection(ref objmysqlconnection); }
    }

    public DataSet clientcontactbind(string custcode,string userid,string compcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientcontactbind", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;


				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;



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



		public DataSet contactupdate (string contactperson,string dob,string phone,string ext,string fax,string mail,string compcode,string userid,string custcode,string contcode)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientcontactupdate", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["contactperson"].Value =contactperson;

				objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
				if(dob=="" || dob==null || dob=="undefined")
				{
					objmysqlcommand.Parameters["dob"].Value = System.DBNull.Value;
				}
				else
				{
					objmysqlcommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
				}
				objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone"].Value =phone;

				objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["ext"].Value =ext;

				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["mail"].Value =mail;

				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				

				objmysqlcommand.Parameters.Add("contcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["contcode"].Value =contcode;




              





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

		public DataSet clientcontactbind12(string custcode,string userid,string compcode,string dateformat)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientcontactbind12", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["date1"].Value =dateformat;


				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;



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




        public DataSet insertcontact(string contact, string dob, string phone, string ext, string fax, string mail, string userid, string custcode, string compcode)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientcontactdetails", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("contact", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["contact"].Value =contact;

				
				objmysqlcommand.Parameters.Add("dob", MySqlDbType.DateTime);
				if(dob=="" || dob==null || dob=="undefined")
				{
					objmysqlcommand.Parameters["dob"].Value = System.DBNull.Value;
				}
				else
				{
					objmysqlcommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
				}

				objmysqlcommand.Parameters.Add("phone",MySqlDbType.VarChar);
				//if (Comment =="" || Comment==null)
				objmysqlcommand.Parameters["phone"].Value=phone;
				//else

				objmysqlcommand.Parameters.Add("ext", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["ext"].Value =ext;

				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["mail"].Value =mail;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;


				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

                objmysqlcommand.Parameters.Add("mobile", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mobile"].Value = "";

                objmysqlcommand.Parameters.Add("anniversary1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["anniversary1"].Value = System.DBNull.Value;



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

    public DataSet addstatusname(string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bind_status_bind_status_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

		public DataSet statusupdate (string status,string fromdate1,string todate1,string compcode,string userid,string custcode,string update,string dateformat,string circular)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientststuscheck11", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				//objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
				//objmysqlcommand.Parameters["status"].Value =status;

				objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["date1"].Value =dateformat;

                objmysqlcommand.Parameters.Add("formdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["formdate"].Value = Convert.ToDateTime(fromdate1).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate1).ToString("yyyy-MM-dd");

				
				
				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				

				objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["code1"].Value =update;


				//objmysqlcommand.Parameters.Add("crcular", MySqlDbType.VarChar);
				//objmysqlcommand.Parameters["crcular"].Value =circular;




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



		public DataSet statusupdate11 (string status,string fromdate,string todate,string compcode,string userid,string custcode,string update,string circular)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientstatusupdate", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["status1"].Value =status;


                objmysqlcommand.Parameters.Add("formdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["formdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");
				
				
				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				

				objmysqlcommand.Parameters.Add("update1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["update1"].Value =update;

				objmysqlcommand.Parameters.Add("crcular", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["crcular"].Value =circular;


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



		/*public DataSet statusupdate1 (string status,string fromdate1,string todate1,string compcode,string userid,string custcode,string update)
		{
		
			SqlConnection objmysqlconnection;
			SqlCommand objmysqlcommand;
			objmysqlconnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("sp_clientstatusupdate", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["status"].Value =status;

				objmysqlcommand.Parameters.Add("formdate", MySqlDbType.DateTime);
				objmysqlcommand.Parameters["formdate"].Value = Convert.ToDateTime(fromdate1);

				objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
				objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate1);

				
				
				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				

				objmysqlcommand.Parameters.Add("update", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["update"].Value =update;


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objmysqlcommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
		
		}*/







		public DataSet insertstatus11(string status,string fromdate,string todate,string custcode,string compcode,string userid,string circular)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();	
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_insertclientstatus", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("pstatus", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pstatus"].Value =status;


                objmysqlcommand.Parameters.Add("formdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["formdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["circular"].Value =circular;

                objmysqlcommand.Parameters.Add("attach", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["attach"].Value = "";

                objmysqlcommand.Parameters.Add("remark", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remark"].Value = "";

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
    public DataSet chkcontact(string contactperson, string custcode, string compcode, string hiddenccode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("clientcontcheck", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;
                
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
                
                objmysqlcommand.Parameters.Add("contactperson", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["contactperson"].Value =contactperson;

                objmysqlcommand.Parameters.Add("ccode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ccode"].Value = hiddenccode;

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


		public DataSet insertstatus(string status,string fromdate1,string todate1,string custcode,string compcode,string userid,string dateformat,string circular)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_clientststuscheck12", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				//objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
				//objmysqlcommand.Parameters["status"].Value =status;

				
				//objmysqlcommand.Parameters.Add("formdate", MySqlDbType.VarChar);
				//objmysqlcommand.Parameters["formdate"].Value =fromdate;

				//objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
				//objmysqlcommand.Parameters["todate"].Value =todate;

                objmysqlcommand.Parameters.Add("formdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["formdate"].Value = Convert.ToDateTime(fromdate1).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate1).ToString("yyyy-MM-dd");
				
				
				
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;


				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["date1"].Value =dateformat;



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




		


		public DataSet clientstatusbind12(string custcode,string compcode,string userid,string datagrid,string dateformat)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); ;	
			try
			{
                objmysqlconnection.Open();
				objmysqlcommand = GetCommand("sp_clientststuscheck", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;


				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["code1"].Value =datagrid;

				objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["date1"].Value =dateformat;


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


		public DataSet clientstatusdelete(string custcode,string compcode,string userid,string delete1)
			
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
				objmysqlcommand = GetCommand("sp_clientstatusdelete", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 

			

				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

										

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;




				objmysqlcommand.Parameters.Add("delete1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["delete1"].Value =delete1;


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




		public DataSet contactbind(string custcode,string userid,string compcode)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();	
			try
			{
                objmysqlconnection.Open();
				objmysqlcommand = GetCommand("sp_clientcontactbind", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 
				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
                
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




		public DataSet contactdelete(string custcode,string compcode,string userid,string update)
			
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
				objmysqlcommand = GetCommand("sp_clientcontactdelete", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 

			

				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

										

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;




						objmysqlcommand.Parameters.Add("update1", MySqlDbType.VarChar);
						objmysqlcommand.Parameters["update1"].Value =update;






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

    public DataSet status_name_call(string status,string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
				objmysqlcommand = GetCommand("status_name_call", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["status1"].Value =status;



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

		public DataSet clientstatusbind(string custcode,string userid,string compcode,string dateformat)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
                objmysqlconnection.Open();
				objmysqlcommand = GetCommand("sp_clientstatusbind", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


				objmysqlcommand.Parameters.Add("custcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["custcode"].Value =custcode;


				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["date1"].Value =dateformat;



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

	}
}
