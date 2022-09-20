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
/// Summary description for AgencySubCategoryMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class AgencySubCategoryMaster:connection
{
	public AgencySubCategoryMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet addagencytype()
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("adagencytype", ref con);
				com.CommandType=CommandType.StoredProcedure;

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


  /*  public DataSet agencycategory(string agencytype)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fillcategory", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencytype"].Value = agencytype;

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
    }*/
		
	
		
		public DataSet ascmsave(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Ascm_Save",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@atc", SqlDbType.VarChar);
				com.Parameters["@atc"].Value=agency;

				com.Parameters.Add("@acc", SqlDbType.VarChar);
				com.Parameters["@acc"].Value=category;

				com.Parameters.Add("@ascc",SqlDbType.VarChar);
				com.Parameters["@ascc"].Value=code;
				
				com.Parameters.Add("@ascn", SqlDbType.VarChar);
				com.Parameters["@ascn"].Value=name;

				com.Parameters.Add("@asca", SqlDbType.VarChar);
				com.Parameters["@asca"].Value=alias;

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
	

		public DataSet ascmmodify(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Ascm_Modify",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@atc", SqlDbType.VarChar);
				com.Parameters["@atc"].Value=agency;

				com.Parameters.Add("@acc", SqlDbType.VarChar);
				com.Parameters["@acc"].Value=category;

				com.Parameters.Add("@ascc",SqlDbType.VarChar);
				com.Parameters["@ascc"].Value=code;
				
				com.Parameters.Add("@ascn", SqlDbType.VarChar);
				com.Parameters["@ascn"].Value=name;

				com.Parameters.Add("@asca", SqlDbType.VarChar);
				com.Parameters["@asca"].Value=alias;

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

		public DataSet ascmdelete(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Ascm_Delete",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@atc", SqlDbType.VarChar);
				com.Parameters["@atc"].Value=agency;

				com.Parameters.Add("@acc", SqlDbType.VarChar);
				com.Parameters["@acc"].Value=category;

				com.Parameters.Add("@ascc",SqlDbType.VarChar);
				com.Parameters["@ascc"].Value=code;
				
				com.Parameters.Add("@ascn", SqlDbType.VarChar);
				com.Parameters["@ascn"].Value=name;

				com.Parameters.Add("@asca", SqlDbType.VarChar);
				com.Parameters["@asca"].Value=alias;

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

		public DataSet ascmexecute(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Ascm_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@atc", SqlDbType.VarChar);
                //if(agency == "0")
                //{
                //    com.Parameters["@atc"].Value="%%";
                //}
                //else
                //{
					com.Parameters["@atc"].Value=agency;
				//}
				
				com.Parameters.Add("@acc", SqlDbType.VarChar);
                //if(category == "0")
                //{	
                //    com.Parameters["@acc"].Value="%%";
                //}
                //else
                //{
					com.Parameters["@acc"].Value=category;
				//}

				com.Parameters.Add("@ascc", SqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
					com.Parameters["@ascc"].Value=code;
                //}
                //else
                //{
                //    com.Parameters["@ascc"].Value="%%";
                //}

				com.Parameters.Add("@ascn", SqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
					com.Parameters["@ascn"].Value=name;
                //}
                //else
                //{
                //    com.Parameters["@ascn"].Value ="%%";
                //}

				com.Parameters.Add("@asca", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@asca"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@asca"].Value ="%%";
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


		public DataSet ascmexecute1(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Ascm_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

				com.Parameters.Add("@atc", SqlDbType.VarChar);
                //if(agency == "0")
                //{
                //    com.Parameters["@atc"].Value="%%";
                //}
                //else
                //{
					com.Parameters["@atc"].Value=agency;
				//}
				
				com.Parameters.Add("@acc", SqlDbType.VarChar);
                //if(category == "0")
                //{	
                //    com.Parameters["@acc"].Value="%%";
                //}
                //else
                //{
					com.Parameters["@acc"].Value=category;
				//}

				com.Parameters.Add("@ascc", SqlDbType.VarChar);
                //if(code!="" && code!=null)
                //{
					com.Parameters["@ascc"].Value=code;
                //}
                //else
                //{
                //    com.Parameters["@ascc"].Value="%%";
                //}

				com.Parameters.Add("@ascn", SqlDbType.VarChar);
                //if(name!="" && name!=null )
                //{
					com.Parameters["@ascn"].Value=name;
                //}
                //else
                //{
                //    com.Parameters["@ascn"].Value ="%%";
                //}

				com.Parameters.Add("@asca", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@asca"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@asca"].Value ="%%";
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

		public DataSet ascmfirst(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Ascmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value =UserId;

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

		public DataSet ascmlast(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Ascmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value =UserId;

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

		public DataSet ascmprevious(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Ascmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value =UserId;

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

		public DataSet ascmnext(string companycode,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Ascmfpnl", ref con);
				com.CommandType = CommandType.StoredProcedure;
 
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =companycode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value =UserId;

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
	
		public DataSet chkascmcode(string companycode,string UserId,string code)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Ascmcheck", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;
				
				com.Parameters.Add("@ascc", SqlDbType.VarChar);
				com.Parameters["@ascc"].Value=code;				
				
                //com.Parameters.Add("@userid", SqlDbType.VarChar);
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
    public DataSet addagencycat(string agencytype)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bindagencytype", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencytype"].Value = agencytype;

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

    public DataSet countascmcode(string str)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkascmodename", ref objSqlConnection);
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
