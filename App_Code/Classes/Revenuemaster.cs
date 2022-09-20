using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Revenuemaster:connection
	{
		public Revenuemaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet checkrevcode(string comcode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkrevcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comcode"].Value =comcode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

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


		public DataSet revinsert(string sharecode,string sharedescription,string validatedate,string validatetill,string remarks,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertintorev", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@sharecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharecode"].Value =sharecode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;


				objSqlCommand.Parameters.Add("@sharedescription", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharedescription"].Value =sharedescription;

				objSqlCommand.Parameters.Add("@validatedate",SqlDbType.DateTime);
				objSqlCommand.Parameters["@validatedate"].Value=Convert.ToDateTime(validatedate);


				objSqlCommand.Parameters.Add("@validatetill",SqlDbType.DateTime);
				objSqlCommand.Parameters["@validatetill"].Value=Convert.ToDateTime(validatetill);

				objSqlCommand.Parameters.Add("@remarks",SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value=remarks;

				
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


		public DataSet executerev(string sharecode,string sharedescription,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executerev", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@sharecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharecode"].Value =sharecode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;


				objSqlCommand.Parameters.Add("@sharedescription", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharedescription"].Value =sharedescription;

				

				
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

		public DataSet firstrev()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstrev", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				

				
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

		public DataSet revupdate(string sharecode,string sharedescription,string validatedate,string validatetill,string remarks,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updaterev", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@sharecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharecode"].Value =sharecode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;


				objSqlCommand.Parameters.Add("@sharedescription", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharedescription"].Value =sharedescription;

				objSqlCommand.Parameters.Add("@validatedate",SqlDbType.DateTime);
				objSqlCommand.Parameters["@validatedate"].Value=Convert.ToDateTime(validatedate);


				objSqlCommand.Parameters.Add("@validatetill",SqlDbType.DateTime);
				objSqlCommand.Parameters["@validatetill"].Value=Convert.ToDateTime(validatetill);

				objSqlCommand.Parameters.Add("@remarks",SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value=remarks;

				
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
		public DataSet revdelete(string sharecode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deleterev", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@sharecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sharecode"].Value =sharecode;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

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

	}
}
