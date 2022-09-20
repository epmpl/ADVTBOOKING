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
/// Summary description for ClientMasterpopup
/// </summary>
namespace NewAdbooking.Classes
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
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("payfill", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = hiddenuserid;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = hiddencomcode;



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

    public DataSet getData(string clientcode, string userid, string compcode)
    {
        SqlConnection sqlcon;
        SqlCommand sqlcomm;
        sqlcon = GetConnection();
        DataSet ds = new DataSet();
        try
        {
            sqlcon.Open();
            sqlcomm = GetCommand("Clientpayselect", ref sqlcon);
            sqlcomm.CommandType = CommandType.StoredProcedure;



            sqlcomm.Parameters.Add("@custcode", SqlDbType.VarChar);
            sqlcomm.Parameters["@custcode"].Value = clientcode;
            sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
            sqlcomm.Parameters["@userid"].Value = userid;
            sqlcomm.Parameters.Add("@compcode", SqlDbType.VarChar);
            sqlcomm.Parameters["@compcode"].Value = compcode;
            SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref sqlcon);
        }
        return ds;
    }

    public void insertData(string compcode, string custcode, string userid, int i, string strMode)
    {
        SqlConnection sqlcon;
        SqlCommand sqlcomm;
        sqlcon = GetConnection();
        try
        {
            sqlcon.Open();
            sqlcomm = GetCommand("updateClientPay", ref sqlcon);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            sqlcomm.Parameters.Add("@Cash", SqlDbType.VarChar);
            sqlcomm.Parameters["@Cash"].Value = strMode;
            //sqlcomm.Parameters.Add("@Credit", SqlDbType.VarChar);
            //sqlcomm.Parameters["@Credit"].Value = strMode[1];
            //sqlcomm.Parameters.Add("@Bank", SqlDbType.VarChar);
            //sqlcomm.Parameters["@Bank"].Value = strMode[2];
            sqlcomm.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
            sqlcomm.Parameters["@Comp_Code"].Value = compcode;
            sqlcomm.Parameters.Add("@Client_Code", SqlDbType.VarChar);
            sqlcomm.Parameters["@Client_Code"].Value = custcode;
            sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
            sqlcomm.Parameters["@userid"].Value = userid;
            sqlcomm.Parameters.Add("@Flag", SqlDbType.VarChar);
            sqlcomm.Parameters["@Flag"].Value = i;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcomm;
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref sqlcon); }
    }

    public DataSet clientcontactbind(string custcode,string userid,string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientcontactbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		}



    public DataSet contactupdate(string contactperson, string dob, string phone, string ext, string fax, string mail, string compcode, string userid, string custcode, string contcode, string anniversary, string mobile)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientcontactupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contactperson"].Value =contactperson;

				objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
				if(dob=="" || dob==null || dob=="undefined")
				{
					objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
				}
				objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
				objSqlCommand.Parameters["@phone"].Value =phone;

				objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ext"].Value =ext;

				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fax"].Value =fax;

				objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mail"].Value =mail;

				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				objSqlCommand.Parameters.Add("@contcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contcode"].Value =contcode;



                objSqlCommand.Parameters.Add("@anniversary1", SqlDbType.DateTime);
                if (anniversary == "" || anniversary == null || anniversary == "undefined")
                {
                    objSqlCommand.Parameters["@anniversary1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@anniversary1"].Value = Convert.ToDateTime(anniversary);
                }
                objSqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobile"].Value = mobile;



				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}

		public DataSet clientcontactbind12(string custcode,string userid,string compcode,string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientcontactbind12", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		}




        public DataSet insertcontact(string contact, string dob, string phone, string ext, string fax, string mail, string userid, string custcode, string compcode, string anniversary, string mobile)
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientcontactdetails", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@contact", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contact"].Value =contact;

				
				objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
				if(dob=="" || dob==null || dob=="undefined")
				{
					objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
				}

				objSqlCommand.Parameters.Add("@phone",SqlDbType.VarChar);
				//if (Comment =="" || Comment==null)
				objSqlCommand.Parameters["@phone"].Value=phone;
				//else

				objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ext"].Value =ext;

				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fax"].Value =fax;

				objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mail"].Value =mail;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


                objSqlCommand.Parameters.Add("@anniversary1", SqlDbType.DateTime);
                if (anniversary == "" || anniversary == null || anniversary == "undefined")
                {
                    objSqlCommand.Parameters["@anniversary1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@anniversary1"].Value = Convert.ToDateTime(anniversary);
                }
                
                
                objSqlCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobile"].Value = mobile;


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}

    public DataSet addstatusname(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bind_status", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (SqlException objException)
        {
            throw (objException);
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

		public DataSet statusupdate (string status,string fromdate1,string todate1,string compcode,string userid,string custcode,string update,string dateformat,string circular)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientststuscheck11", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				//objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@status"].Value =status;

				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;

				objSqlCommand.Parameters.Add("@formdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@formdate"].Value = Convert.ToDateTime(fromdate1);

				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate1);

				
				
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =update;


				//objSqlCommand.Parameters.Add("@crcular", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@crcular"].Value =circular;


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}



		public DataSet statusupdate11 (string status,string fromdate,string todate,string compcode,string userid,string custcode,string update,string circular,string attach, string remark)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientstatusupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;

				objSqlCommand.Parameters.Add("@formdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@formdate"].Value = fromdate;

				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@todate"].Value = todate;

				
				
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
				objSqlCommand.Parameters["@update"].Value =update;

				objSqlCommand.Parameters.Add("@crcular", SqlDbType.VarChar);
				objSqlCommand.Parameters["@crcular"].Value =circular;

                objSqlCommand.Parameters.Add("@attach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach"].Value = attach;


                objSqlCommand.Parameters.Add("@remark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remark"].Value = remark;

					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}



		/*public DataSet statusupdate1 (string status,string fromdate1,string todate1,string compcode,string userid,string custcode,string update)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientstatusupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;

				objSqlCommand.Parameters.Add("@formdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@formdate"].Value = Convert.ToDateTime(fromdate1);

				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate1);

				
				
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
				objSqlCommand.Parameters["@update"].Value =update;


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}*/







        public DataSet insertstatus11(string status, string fromdate, string todate, string custcode, string compcode, string userid, string circular, string attach, string remark)
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_insertclientstatus", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;

				
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromdate"].Value =fromdate;

				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@todate"].Value =todate;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
				objSqlCommand.Parameters["@circular"].Value =circular;

                objSqlCommand.Parameters.Add("@attach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach"].Value = attach;

                objSqlCommand.Parameters.Add("@remark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remark"].Value = remark;



				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}
    public DataSet chkcontact(string contactperson, string custcode, string compcode, string hiddenccode)
    {
        	SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("clientcontcheck", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;
                
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
                
                objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contactperson"].Value =contactperson;

                objSqlCommand.Parameters.Add("@ccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ccode"].Value = hiddenccode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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


		public DataSet insertstatus(string status,string fromdate,string todate,string custcode,string compcode,string userid,string dateformat,string circular)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientststuscheck12", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				//objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@status"].Value =status;

				
				objSqlCommand.Parameters.Add("@formdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@formdate"].Value =fromdate;

				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@todate"].Value =todate;

				
				
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;

				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}




		


		public DataSet clientstatusbind12(string custcode,string compcode,string userid,string datagrid,string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientststuscheck", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =datagrid;

				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;




				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		}


		public DataSet clientstatusdelete(string custcode,string compcode,string userid,string delete1)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientstatusdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

			

				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

										

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;




				objSqlCommand.Parameters.Add("@delete", SqlDbType.VarChar);
				objSqlCommand.Parameters["@delete"].Value =delete1;

				


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}




		public DataSet contactbind(string custcode,string userid,string compcode)
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientcontactbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

								objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
								objSqlCommand.Parameters["@compcode"].Value =compcode;

				


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}




		public DataSet contactdelete(string custcode,string compcode,string userid,string update)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientcontactdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 

			

				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

										

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;




						objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
						objSqlCommand.Parameters["@update"].Value =update;

				


				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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
				CloseConnection(ref objSqlConnection);
			}
		
		}

    public DataSet status_name_call(string status,string compcode)
    {
        	SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("status_name_call", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;


				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
    }

		public DataSet clientstatusbind(string custcode,string userid,string compcode,string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_clientstatusbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@custcode"].Value =custcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;


				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		}

	



		

	}
}
