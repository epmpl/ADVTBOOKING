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
/// Summary description for productmaster
/// </summary>
namespace NewAdbooking.Classes
{
public class productmaster:connection
{
	public productmaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet checkcode(string txtproductcode,string txtprodsubcode,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkproductcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@txtproductcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtproductcode"].Value =txtproductcode;
			
				objSqlCommand.Parameters.Add("@txtprodsubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodsubcode"].Value =txtprodsubcode;

				
						
							
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

		public DataSet saveproduct(string txtproductcode,string txtprodsubcode,string txtprodname,string clientname,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertproduct", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@txtproductcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtproductcode"].Value =txtproductcode;
			
				objSqlCommand.Parameters.Add("@txtprodsubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodsubcode"].Value =txtprodsubcode;

				objSqlCommand.Parameters.Add("@txtprodname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodname"].Value =txtprodname;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;


				
						
							
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

		public DataSet executeproduct(string txtproductcode,string txtprodsubcode,string txtprodname,string clientname,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("executeproduct", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@txtproductcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtproductcode"].Value =txtproductcode;
			
				objSqlCommand.Parameters.Add("@txtprodsubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodsubcode"].Value =txtprodsubcode;

				objSqlCommand.Parameters.Add("@txtprodname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodname"].Value =txtprodname;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;
		
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

		public DataSet firstprodctcode()
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("firstproduct", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 			
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

		public DataSet deleteproduct(string txtproductcode,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deleteprducycode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@txtproductcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtproductcode"].Value =txtproductcode;
			
			
				
						
							
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

		public DataSet updateproduct(string txtproductcode,string txtprodsubcode,string txtprodname,string clientname,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updateproduct", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@txtproductcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtproductcode"].Value =txtproductcode;
			
				objSqlCommand.Parameters.Add("@txtprodsubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodsubcode"].Value =txtprodsubcode;

				objSqlCommand.Parameters.Add("@txtprodname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@txtprodname"].Value =txtprodname;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

				
						
							
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

    public DataSet bindclientname(string compcode, string userid)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bindproductclientname", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;



            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;


            





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


	}
}
