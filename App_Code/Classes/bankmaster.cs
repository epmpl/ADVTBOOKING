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
/// Summary description for bankmaster
/// </summary>
namespace NewAdbooking.Classes
{
public class bankmaster:connection
{
	public bankmaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet adcountryname(string compcode)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("adcountryname", ref con);
				com.CommandType=CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = com;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}


		public DataSet countcity(string txtcountry)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("fillcity", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@txtcountry", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtcountry"].Value =txtcountry;

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


		public DataSet bankbind(string agencode,string agencysubcode,string comp,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bindbankdata", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@agencode"].Value =agencode;

				objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@agencysubcode"].Value =agencysubcode;

				objSqlCommand.Parameters.Add("@comp", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comp"].Value =comp;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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

		public DataSet insertdata(string bankname,string branch,string country,string city,string bankno,string accountno,string compcode,string userid,string agencode,string subagncode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bankinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@bankname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bankname"].Value =bankname;

				objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
				objSqlCommand.Parameters["@branch"].Value =branch;

				objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
				objSqlCommand.Parameters["@country"].Value =country;

				objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
				objSqlCommand.Parameters["@city"].Value =city;

				objSqlCommand.Parameters.Add("@bankno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bankno"].Value =bankno;

				objSqlCommand.Parameters.Add("@accountno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@accountno"].Value =accountno;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@agencode"].Value =agencode;

				objSqlCommand.Parameters.Add("@subagncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subagncode"].Value =subagncode;


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


		public DataSet bankdata(string compcode,string userid,string agencode,string subagncode,string code10)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bankdataselect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@agencode"].Value =agencode;

				objSqlCommand.Parameters.Add("@subagncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subagncode"].Value =subagncode;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code10;


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


		public DataSet updatedata(string bankname,string branch,string country,string city,string bankno,string accountno,string compcode,string userid,string agencode,string subagncode,string codebk)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bankdataupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@bankname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bankname"].Value =bankname;

				objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
				objSqlCommand.Parameters["@branch"].Value =branch;

				objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
				objSqlCommand.Parameters["@country"].Value =country;

				objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
				objSqlCommand.Parameters["@city"].Value =city;

				objSqlCommand.Parameters.Add("@bankno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@bankno"].Value =bankno;

				objSqlCommand.Parameters.Add("@accountno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@accountno"].Value =accountno;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@agencode"].Value =agencode;

				objSqlCommand.Parameters.Add("@subagncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@subagncode"].Value =subagncode;

				objSqlCommand.Parameters.Add("@codebk", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codebk"].Value =codebk;


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


		public DataSet deletedata(string compcode,string userid,string codebk)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bankdatadelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@codebk", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codebk"].Value =codebk;


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