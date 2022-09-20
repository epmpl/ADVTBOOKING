using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for AdvTypeMaster2.
	/// </summary>
	public class AdvTypeMaster2:connection
	{
		public AdvTypeMaster2()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet Advsave(string companycode,string adtypecode,string adtypename,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Advertisement_Save",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Adv_Type_Code",SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Code"].Value=adtypecode;
				
				com.Parameters.Add("@Adv_Type_Name", SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Name"].Value=adtypename;

				com.Parameters.Add("@Adv_Type_Alias", SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Alias"].Value=alias;

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

		public DataSet Advmodify(string companycode,string adtypecode,string adtypename,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Advertisement_Modify",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Adv_Type_Code",SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Code"].Value=adtypecode;
				
				com.Parameters.Add("@Adv_Type_Name", SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Name"].Value=adtypename;

				com.Parameters.Add("@Adv_Type_Alias", SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Alias"].Value=alias;

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

        public DataSet Advmodifychk1(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("chkadvtypname", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@companycode", SqlDbType.VarChar);
                com.Parameters["@companycode"].Value = companycode;

                com.Parameters.Add("@adtypecode", SqlDbType.VarChar);
                com.Parameters["@adtypecode"].Value = adtypecode;


                com.Parameters.Add("@adtypename", SqlDbType.VarChar);
                com.Parameters["@adtypename"].Value = adtypename;

                com.Parameters.Add("@UserId", SqlDbType.VarChar);
                com.Parameters["@UserId"].Value = UserId;

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

		public DataSet Advdelete(string companycode,string adtypecode,string adtypename,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Advertisement_Delete",ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Adv_Type_Code",SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Code"].Value=adtypecode;
				
                //com.Parameters.Add("@Adv_Type_Name", SqlDbType.VarChar);
                //com.Parameters["@Adv_Type_Name"].Value=adtypename;

                //com.Parameters.Add("@Adv_Type_Alias", SqlDbType.VarChar);
                //com.Parameters["@Adv_Type_Alias"].Value=alias;

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

		public DataSet Advexecute(string companycode,string adtypecode,string adtypename,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Advertisement_Execute",ref con); 
				com.CommandType=CommandType.StoredProcedure;  
				 
				com.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;

				com.Parameters.Add("@Adv_Type_Code", SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Code"].Value=adtypecode;
			
				
				com.Parameters.Add("@Adv_Type_Name", SqlDbType.VarChar);
				com.Parameters["@Adv_Type_Name"].Value=adtypename;
				

				com.Parameters.Add("@Adv_Type_Alias", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@Adv_Type_Alias"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@Adv_Type_Alias"].Value ="%%";
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


		public DataSet Advexecute1(string companycode,string adtypecode,string adtypename,string alias,string UserId)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
				com=GetCommand("Advertisement_Execute",ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				com.Parameters["@Comp_Code"].Value=companycode;
				
				com.Parameters.Add("@Adv_Type_Code", SqlDbType.VarChar);
                //if(adtypecode!="" && adtypecode!=null)
                //{
					com.Parameters["@Adv_Type_Code"].Value=adtypecode;
                //}
                //else
                //{
                //    com.Parameters["@Adv_Type_Code"].Value="%%";
                //}
				
				com.Parameters.Add("@Adv_Type_Name", SqlDbType.VarChar);
                //if(adtypename!="" && adtypename!=null )
                //{
					com.Parameters["@Adv_Type_Name"].Value=adtypename;
                //}
                //else
                //{
                //    com.Parameters["@Adv_Type_Name"].Value ="%%";
                //}

				com.Parameters.Add("@Adv_Type_Alias", SqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
					com.Parameters["@Adv_Type_Alias"].Value =alias;
                //}
                //else
                //{
                //    com.Parameters["@Adv_Type_Alias"].Value ="%%";
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


		public DataSet Advfpnl()
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Advtypefpnl", ref con);
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


        public DataSet advcheck(string companycode, string adtypecode, string UserId, string adtypename)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();	
			try
			{
				con.Open();
				com=GetCommand("Advertisement_check", ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@atc", SqlDbType.VarChar);
				com.Parameters["@atc"].Value=adtypecode;  
				
				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=companycode;

                com.Parameters.Add("@adtypename", SqlDbType.VarChar);
                com.Parameters["@adtypename"].Value = adtypename;
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


        public DataSet countzonecode(string str,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Advertisement_codename", ref objSqlConnection);
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
