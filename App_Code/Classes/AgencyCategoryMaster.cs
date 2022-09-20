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
/// Summary description for AgencyCategoryMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class AgencyCategoryMaster:connection
{
	public AgencyCategoryMaster()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public DataSet addagencytype()
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("adagencytype", ref con);
            com.CommandType = CommandType.StoredProcedure;

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
    public DataSet acmsave(string companycode, string code, string name, string alias, string agencytype, string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("acm_Save",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@acc",SqlDbType.VarChar);
				com.Parameters["@acc"].Value=code;
				
				com.Parameters.Add("@acn", SqlDbType.VarChar);
				com.Parameters["@acn"].Value=name;

				com.Parameters.Add("@aca", SqlDbType.VarChar);
				com.Parameters["@aca"].Value=alias;

              

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                com.Parameters["@agencytype"].Value = agencytype;

				com.Parameters.Add("@userid",SqlDbType.VarChar);
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

    public DataSet acmmodify(string companycode, string code, string name, string alias,string agencytype, string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("acm_Modify",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@acc",SqlDbType.VarChar);
				com.Parameters["@acc"].Value=code;
				
				com.Parameters.Add("@acn", SqlDbType.VarChar);
				com.Parameters["@acn"].Value=name;

				com.Parameters.Add("@aca", SqlDbType.VarChar);
				com.Parameters["@aca"].Value=alias;

               
                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                com.Parameters["@agencytype"].Value = agencytype;
				
                //com.Parameters.Add("@userid",SqlDbType.VarChar);
                //com.Parameters["@userid"].Value=UserId;
				
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

    public DataSet acmdelete(string companycode, string code, string name, string alias, string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("acm_Delete",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@acc",SqlDbType.VarChar);
				com.Parameters["@acc"].Value=code;
				
				com.Parameters.Add("@acn", SqlDbType.VarChar);
				com.Parameters["@acn"].Value=name;

				com.Parameters.Add("@aca", SqlDbType.VarChar);
				com.Parameters["@aca"].Value=alias;

                //com.Parameters.Add("@userid",SqlDbType.VarChar);
                //com.Parameters["@userid"].Value=UserId;

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

		public DataSet acmexecute(string companycode,string code,string name,string alias,string agencytype,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("acm_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@acc", SqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
					com.Parameters["@acc"].Value=code;
                //}
                //else
                //{
                //    com.Parameters["@acc"].Value="%%";
                //}
				
				com.Parameters.Add("@acn", SqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
					com.Parameters["@acn"].Value=name;
                //}
                //else
                //{
                //    com.Parameters["@acn"].Value ="%%";
                //}

				com.Parameters.Add("@aca", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@aca"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@aca"].Value ="%%";
                //}

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                //if (agencytype != "0" && agencytype != null )
                //{
                    com.Parameters["@agencytype"].Value = agencytype;
                //}
                //else
                //{
                //    com.Parameters["@agencytype"].Value = "%%";
                //}
                //com.Parameters.Add("@userid",SqlDbType.VarChar);
                //com.Parameters["@userid"].Value=UserId;
				
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


		public DataSet acmexecute1(string companycode,string code,string name,string alias,string agencytype,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("acm_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@acc", SqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
					com.Parameters["@acc"].Value=code;
                //}
                //else
                //{
                //    com.Parameters["@acc"].Value="%%";
                //}
				
				com.Parameters.Add("@acn", SqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
					com.Parameters["@acn"].Value=name;
                //}
                //else
                //{
                //    com.Parameters["@acn"].Value ="%%";
                //}

				com.Parameters.Add("@aca", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@aca"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@aca"].Value ="%%";
                //}
                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                //if (agencytype != "0" && agencytype != null)
                //{
                    com.Parameters["@agencytype"].Value = agencytype;
                //}
                //else
                //{
                //    com.Parameters["@agencytype"].Value = "%%";
                //}
                //com.Parameters.Add("@userid",SqlDbType.VarChar);
                //com.Parameters["@userid"].Value=UserId;
				
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

		public DataSet acmfirst(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("acmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =UserId;

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

		public DataSet acmlast(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("acmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =UserId;

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

		public DataSet acmprevious(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("acmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =UserId;

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

		public DataSet acmnext(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("acmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =UserId;

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
	
		public DataSet chkacmcode(string companycode,string UserId,string code)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("acmcheck", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;
				
				com.Parameters.Add("@acc", SqlDbType.VarChar);
				com.Parameters["@acc"].Value=code;				
				
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
    public DataSet countacmcodename(string str)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkacmcodename", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;


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
