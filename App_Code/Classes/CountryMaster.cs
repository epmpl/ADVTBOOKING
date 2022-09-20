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
/// Summary description for CountryMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class CountryMaster:connection
{
	public CountryMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet Advsave(string companycode,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Countrymaster_Save",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Country_Code",SqlDbType.VarChar);
				com.Parameters["@Country_Code"].Value=code;
				
				com.Parameters.Add("@Country_Name", SqlDbType.VarChar);
				com.Parameters["@Country_Name"].Value=name;

				com.Parameters.Add("@Country_Alias", SqlDbType.VarChar);
				com.Parameters["@Country_Alias"].Value=alias;

				com.Parameters.Add("@UserId",SqlDbType.VarChar);
				com.Parameters["@UserId"].Value=UserId;

				da.SelectCommand=com;
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
	
		public DataSet Advmodify(string companycode,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Countrymaster_Modify",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Country_Code",SqlDbType.VarChar);
				com.Parameters["@Country_Code"].Value=code;
				
				com.Parameters.Add("@Country_Name", SqlDbType.VarChar);
				com.Parameters["@Country_Name"].Value=name;

				com.Parameters.Add("@Country_Alias", SqlDbType.VarChar);
				com.Parameters["@Country_Alias"].Value=alias;

                //com.Parameters.Add("@UserId",SqlDbType.VarChar);
                //com.Parameters["@UserId"].Value=UserId;
				da.SelectCommand=com;
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

		public DataSet Advdelete(string companycode,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Countrymaster_Delete",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Country_Code",SqlDbType.VarChar);
				com.Parameters["@Country_Code"].Value=code;
				
				com.Parameters.Add("@Country_Name", SqlDbType.VarChar);
				com.Parameters["@Country_Name"].Value=name;

				com.Parameters.Add("@Country_Alias", SqlDbType.VarChar);
				com.Parameters["@Country_Alias"].Value=alias;

                //com.Parameters.Add("@UserId",SqlDbType.VarChar);
                //com.Parameters["@UserId"].Value=UserId;

				da.SelectCommand=com;
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

		public DataSet Advexecute(string companycode,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Countrymaster_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
					com.Parameters["@Country_Code"].Value=code;
                //}
                //else
                //{
                //    com.Parameters["@Country_Code"].Value="%%";
                //}
				
				com.Parameters.Add("@Country_Name", SqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
					com.Parameters["@Country_Name"].Value=name;
                //}
                //else
                //{
                //    com.Parameters["@Country_Name"].Value ="%%";
                //}

				com.Parameters.Add("@Country_Alias", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@Country_Alias"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@Country_Alias"].Value ="%%";
                //}
                //com.Parameters.Add("@UserId",SqlDbType.VarChar);
                //com.Parameters["@UserId"].Value=UserId;
				
				da.SelectCommand=com;
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


		public DataSet Advexecute1(string companycode,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Countrymaster_Execute",ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;
				
				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
					com.Parameters["@Country_Code"].Value=code;
                //}
                //else
                //{
                //    com.Parameters["@Country_Code"].Value="%%";
                //}
				
				com.Parameters.Add("@Country_Name", SqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
					com.Parameters["@Country_Name"].Value=name;
                //}
                //else
                //{
                //    com.Parameters["@Country_Name"].Value ="%%";
                //}

				com.Parameters.Add("@Country_Alias", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@Country_Alias"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@Country_Alias"].Value ="%%";
                //}
											
                //com.Parameters.Add("@UserId", SqlDbType.VarChar);
                //com.Parameters["@UserId"].Value =UserId;
				
				da.SelectCommand=com;
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

		public DataSet Advfirst()
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Countryfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				da.SelectCommand=com;				
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

		
	
		public DataSet chkcountrycode(string companycode,string UserId,string code, string name)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("checkcountry", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;
				
				com.Parameters.Add("@countrycode", SqlDbType.VarChar);
				com.Parameters["@countrycode"].Value=code;				
				
				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value=UserId;

                com.Parameters.Add("@name", SqlDbType.VarChar);
                com.Parameters["@name"].Value = name;

				da.SelectCommand=com;
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

    public DataSet countcode(string str,string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkcountrycodename", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

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
}
}
