using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for NoIssueDayMaster.
	/// </summary>
	public class NoIssueDayMaster:connection
	{
		public NoIssueDayMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public DataSet checknoisscode(string noisscode,string noissuedayname, string compcode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checknoissuedaycode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Comp_Code"].Value =compcode;

				objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
				objSqlCommand.Parameters["@UserId"].Value =userid;

				objSqlCommand.Parameters.Add("@No_Iss_Day_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@No_Iss_Day_Code"].Value = noisscode;

                objSqlCommand.Parameters.Add("@No_Iss_Day_Name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@No_Iss_Day_Name"].Value = noissuedayname;
			
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

		public DataSet insertnoiss(string noisscode,string noissname,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("issuedayinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@uid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@uid"].Value =userid;

				objSqlCommand.Parameters.Add("@noissuedaycode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@noissuedaycode"].Value =noisscode;

				objSqlCommand.Parameters.Add("@noissday", SqlDbType.VarChar);
				objSqlCommand.Parameters["@noissday"].Value =noissname;

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

        public DataSet executenoiss(string compcode, string noisscode, string noissname, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("NoIssueDayMaster_Execute", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = compcode;

                objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                objSqlCommand.Parameters["@UserId"].Value = userid;

 
				objSqlCommand.Parameters.Add("@No_Iss_Day_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@No_Iss_Day_Code"].Value =noisscode;

				objSqlCommand.Parameters.Add("@No_Iss_Day", SqlDbType.VarChar);
				objSqlCommand.Parameters["@No_Iss_Day"].Value =noissname;

                
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

		public DataSet firstquery()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("NoIssueDayMaster_pnl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
			
                //objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@Comp_Code"].Value =compcode;

                //objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@UserId"].Value =userid;

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
		
		public DataSet updaetcode(string noisscode,string noissname,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("NoIssueDayMaster_Modify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 		
				objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Comp_Code"].Value =compcode;

				objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
				objSqlCommand.Parameters["@UserId"].Value =userid;

				objSqlCommand.Parameters.Add("@No_Iss_Day_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@No_Iss_Day_Code"].Value =noisscode;

				objSqlCommand.Parameters.Add("@No_Iss_Day", SqlDbType.VarChar);
				objSqlCommand.Parameters["@No_Iss_Day"].Value =noissname;
				
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

		public DataSet deletenoiss(string noisscode,string noissname,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("NoIssueDayMaster_Delete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Comp_Code"].Value =compcode;

				objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
				objSqlCommand.Parameters["@UserId"].Value =userid;

				objSqlCommand.Parameters.Add("@No_Iss_Day_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@No_Iss_Day_Code"].Value =noisscode;
				
				objSqlCommand.Parameters.Add("@No_Iss_Day", SqlDbType.VarChar);
				objSqlCommand.Parameters["@No_Iss_Day"].Value =noissname;

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

        public DataSet dauto(string str)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("NoIssueDayMaster_Auto", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("@cod", SqlDbType.VarChar);
                com.Parameters["@cod"].Value = str;


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
	}

}