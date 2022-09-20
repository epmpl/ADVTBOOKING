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
/// Summary description for StateMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class StateMaster:connection
{
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

		
		public DataSet Advsave1(string companycode,string statecode,string statename,string alias,string countryname,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Statemaster_Save",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@State_Code",SqlDbType.VarChar);
				com.Parameters["@State_Code"].Value=statecode;
				
				com.Parameters.Add("@State_Name", SqlDbType.VarChar);
				com.Parameters["@State_Name"].Value=statename;

				com.Parameters.Add("@State_Alias", SqlDbType.VarChar);
				com.Parameters["@State_Alias"].Value=alias;

				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
				com.Parameters["@Country_Code"].Value=countryname;

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

		public DataSet Advmodify1(string companycode,string statecode,string statename,string alias,string countryname,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Statemaster_Modify",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@State_Code",SqlDbType.VarChar);
				com.Parameters["@State_Code"].Value=statecode;
				
				com.Parameters.Add("@State_Name", SqlDbType.VarChar);
				com.Parameters["@State_Name"].Value=statename;

				com.Parameters.Add("@State_Alias", SqlDbType.VarChar);
				com.Parameters["@State_Alias"].Value=alias;

				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
				com.Parameters["@Country_Code"].Value=countryname;

                com.Parameters.Add("@UserId", SqlDbType.VarChar);
                com.Parameters["@UserId"].Value = UserId;

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

		public DataSet Advdelete(string companycode,string statecode,string statename,string alias,string countryname,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Statemaster_Delete",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@State_Code",SqlDbType.VarChar);
				com.Parameters["@State_Code"].Value=statecode;
				
				com.Parameters.Add("@State_Name", SqlDbType.VarChar);
				com.Parameters["@State_Name"].Value=statename;

				com.Parameters.Add("@State_Alias", SqlDbType.VarChar);
				com.Parameters["@State_Alias"].Value=alias;

				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
				com.Parameters["@Country_Code"].Value=countryname;

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

		public DataSet Advexecute1(string companycode,string statecode,string statename,string alias,string countryname,string UserId)
		{
			SqlConnection con = new SqlConnection();
			SqlCommand com = new SqlCommand();
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Statemaster_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@State_Code", SqlDbType.VarChar);
                //if(statecode!="" && statecode!=null)
                //{
					com.Parameters["@State_Code"].Value=statecode;
                //}
                //else
                //{
                //    com.Parameters["@State_Code"].Value="%%";
                //}
				
				com.Parameters.Add("@State_Name", SqlDbType.VarChar);
                //if(statename!="" && statename!=null )
                //{
					com.Parameters["@State_Name"].Value=statename;
                //}
                //else
                //{
                //    com.Parameters["@State_Name"].Value ="%%";
                //}

				com.Parameters.Add("@State_Alias", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@State_Alias"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@State_Alias"].Value ="%%";
                //}
				
				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
                //if(countryname == "0")
                //{
					//com.Parameters["@Country_Code"].Value="%%";
                //}
                //else
                //{
                 com.Parameters["@Country_Code"].Value=countryname;
				
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

		public DataSet Advexecute2(string companycode,string statecode,string statename,string alias,string countryname,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Statemaster_Execute",ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;
				
				com.Parameters.Add("@State_Code", SqlDbType.VarChar);
                //if(statecode!="" && statecode!=null)
                //{
					com.Parameters["@State_Code"].Value=statecode;
                //}
                //else
                //{
                //    com.Parameters["@State_Code"].Value="%%";
                //}
				
				com.Parameters.Add("@State_Name", SqlDbType.VarChar);
                //if(statename!="" && statename!=null )
                //{
					com.Parameters["@State_Name"].Value=statename;
                //}
                //else
                //{
                //    com.Parameters["@State_Name"].Value ="%%";
                //}

				com.Parameters.Add("@State_Alias", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@State_Alias"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@State_Alias"].Value ="%%";
                //}
											
				com.Parameters.Add("@Country_Code", SqlDbType.VarChar);
                //if(countryname!="" && countryname!=null)
                //{
					com.Parameters["@Country_Code"].Value=countryname;
                //}
                //else
                //{
                //    com.Parameters["@Country_Code"].Value="%%";
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


		public DataSet Statefirst()
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Statefpnl", ref con);
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

		public DataSet chkstatecode(string companycode,string UserId,string statecode)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("chkstate", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;
					
				com.Parameters.Add("@statecode", SqlDbType.VarChar);
				com.Parameters["@statecode"].Value=statecode;				
				
				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value=UserId;

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

    public DataSet chkstatename(string statename, string countryname, string companycode)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("chkstatename", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@countryname", SqlDbType.VarChar);
            com.Parameters["@countryname"].Value = countryname;

            com.Parameters.Add("@statename", SqlDbType.VarChar);
            com.Parameters["@statename"].Value = statename;
                                  
            com.Parameters.Add("@companycode", SqlDbType.VarChar);
            com.Parameters["@companycode"].Value = companycode;

            da.SelectCommand = com;
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

    public DataSet countstatecode(string str, string ssss, string statecode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkstatecodename", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;

            objSqlCommand.Parameters.Add("@ssss", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ssss"].Value = ssss;

            objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@statecode"].Value = statecode;

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
