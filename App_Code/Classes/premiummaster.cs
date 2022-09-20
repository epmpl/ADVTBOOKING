using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for premiummaster.
	/// </summary>
	public class premiummaster:connection
	{
		public premiummaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet rategrpbind(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("rategroupbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

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

		public DataSet pactypbind(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("packagetypebind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

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
		public DataSet combinbind(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("packagetypebind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

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

		public DataSet packagebind(string comb,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bindpkgname", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@comb",SqlDbType.VarChar);
				objSqlCommand.Parameters["@comb"].Value=comb;

				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

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

		public DataSet checkprem(string txtpremiumcode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkpremmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				
 
				objSqlCommand.Parameters.Add("@txtpremiumcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpremiumcode"].Value=txtpremiumcode;
 

				
 
				
 

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

		public DataSet insertpremmast(string drpcombin,string drpadvtype,string drpcategory,string txtpremiumcode,string drpprerate,string txtrate,string drppremiumtype,string txtremarks,string validatedate,string validatetill,string compcode,string userid,string drppackagename,string drprategroup)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertpremmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@drprategroup",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drprategroup"].Value=drprategroup;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				objSqlCommand.Parameters.Add("@drpcombin",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcombin"].Value=drpcombin;
 
				objSqlCommand.Parameters.Add("@drpadvtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvtype"].Value=drpadvtype;
 

				objSqlCommand.Parameters.Add("@drpcategory",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcategory"].Value=drpcategory;
 
				objSqlCommand.Parameters.Add("@txtpremiumcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpremiumcode"].Value=txtpremiumcode;
 

				objSqlCommand.Parameters.Add("@drpprerate",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpprerate"].Value=drpprerate;
 
				

				objSqlCommand.Parameters.Add("@txtrate",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtrate"].Value=txtrate;
 
				objSqlCommand.Parameters.Add("@drppremiumtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drppremiumtype"].Value=drppremiumtype;

				
 
				
 
 
				objSqlCommand.Parameters.Add("@txtremarks",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtremarks"].Value=txtremarks;
 
				objSqlCommand.Parameters.Add("@validatedate",SqlDbType.DateTime);
				objSqlCommand.Parameters["@validatedate"].Value=Convert.ToDateTime(validatedate);
 
 
				objSqlCommand.Parameters.Add("@validatetill",SqlDbType.DateTime);

				if(validatetill!=null && validatetill!="")
				{
					objSqlCommand.Parameters["@validatetill"].Value=Convert.ToDateTime(validatetill);
				}
				else
				{
					objSqlCommand.Parameters["@validatetill"].Value=System.DBNull.Value;
				}

				objSqlCommand.Parameters.Add("@drppackagename",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drppackagename"].Value=drppackagename;
 
 
				
 

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
		public DataSet bindpretyp(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("premiumtypbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

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



		public DataSet executeprmma(string drpadvtype,string drpcategory,string txtpremiumcode,string drpprerate,string validatedate,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executepremmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				
				objSqlCommand.Parameters.Add("@drpadvtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvtype"].Value=drpadvtype;
 

				objSqlCommand.Parameters.Add("@drpcategory",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcategory"].Value=drpcategory;
 
				objSqlCommand.Parameters.Add("@txtpremiumcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpremiumcode"].Value=txtpremiumcode;
 

				objSqlCommand.Parameters.Add("@drpprerate",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpprerate"].Value=drpprerate;
 
				

				
 
				
 
 
				
 
//				objSqlCommand.Parameters.Add("@validatedate",SqlDbType.DateTime);
//				objSqlCommand.Parameters["@validatedate"].Value=Convert.ToDateTime(validatedate);
// 
 
				
 

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

		public DataSet premfirst()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstpremmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				
				// 
 
				
 

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

		public DataSet updatepremmast(string drpcombin,string drpadvtype,string drpcategory,string txtpremiumcode,string drpprerate,string txtrate,string drppremiumtype,string txtremarks,string validatedate,string validatetill,string compcode,string userid,string drppackagename,string drprategroup)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatepremmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@drprategroup",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drprategroup"].Value=drprategroup;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				objSqlCommand.Parameters.Add("@drpcombin",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcombin"].Value=drpcombin;
 
				objSqlCommand.Parameters.Add("@drpadvtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpadvtype"].Value=drpadvtype;
 

				objSqlCommand.Parameters.Add("@drpcategory",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpcategory"].Value=drpcategory;
 
				objSqlCommand.Parameters.Add("@txtpremiumcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpremiumcode"].Value=txtpremiumcode;
 

				objSqlCommand.Parameters.Add("@drpprerate",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drpprerate"].Value=drpprerate;
 
				

				objSqlCommand.Parameters.Add("@txtrate",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtrate"].Value=txtrate;
 
				objSqlCommand.Parameters.Add("@drppremiumtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drppremiumtype"].Value=drppremiumtype;

				
 
				
 
 
				objSqlCommand.Parameters.Add("@txtremarks",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtremarks"].Value=txtremarks;
 
				objSqlCommand.Parameters.Add("@validatedate",SqlDbType.DateTime);
				objSqlCommand.Parameters["@validatedate"].Value=Convert.ToDateTime(validatedate);
 
 
				objSqlCommand.Parameters.Add("@validatetill",SqlDbType.DateTime);
				
				if(validatetill!=null && validatetill!="")
				{
					objSqlCommand.Parameters["@validatetill"].Value=Convert.ToDateTime(validatetill);
				}
				else
				{
					objSqlCommand.Parameters["@validatetill"].Value=System.DBNull.Value;
				}

				objSqlCommand.Parameters.Add("@drppackagename",SqlDbType.VarChar);
				objSqlCommand.Parameters["@drppackagename"].Value=drppackagename;
 
 
				
 

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

		public DataSet deletepremmast(string txtpremiumcode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletepremmast", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				
 
				objSqlCommand.Parameters.Add("@txtpremiumcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtpremiumcode"].Value=txtpremiumcode;
 

				
 
				
 

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
