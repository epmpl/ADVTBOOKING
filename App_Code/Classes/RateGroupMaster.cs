    using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for RateGroupMaster.
	/// </summary>
	public class RateGroupMaster:connection
	{
		public RateGroupMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ModifyValue(string RtGroupCode,string RtGroupName,string Alias,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("RateGroupMastModify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@RtGroupCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@RtGroupCode"].Value =RtGroupCode;
			
				objSqlCommand.Parameters.Add("@RtGroupName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@RtGroupName"].Value =RtGroupName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias ;

						
							
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


		public DataSet InsertValue(string RtGroupCode,string RtGroupName,string Alias,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("RateGroupMasterInsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@RtGroupCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@RtGroupCode"].Value =RtGroupCode;
			
				objSqlCommand.Parameters.Add("@RtGroupName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@RtGroupName"].Value =RtGroupName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias ;

						
							
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

		public DataSet SelectValue(string RtGroupCode,string RtGroupName,string Alias,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("RateGroupMasterSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				
				objSqlCommand.Parameters.Add("@RtGroupCode", SqlDbType.VarChar);
				
					objSqlCommand.Parameters["@RtGroupCode"].Value =RtGroupCode;
				
				
				
				
			
				objSqlCommand.Parameters.Add("@RtGroupName", SqlDbType.VarChar);
				
					objSqlCommand.Parameters["@RtGroupName"].Value =RtGroupName;
				

				
				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				
				
				
					objSqlCommand.Parameters["@Alias "].Value =Alias;
				

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

		public DataSet Selectfnpl(string RtGroupCode,string RtGroupName,string Alias,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("RateGroupSelectfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

											
							
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

		public DataSet chkvalue(string RtGroupCode,string RtGroupName,string compcode,string userid)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkrategroup", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@RtGroupCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@RtGroupCode"].Value =RtGroupCode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@RtGroupName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@RtGroupName"].Value = RtGroupName;							
							
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
		public DataSet DeleteValue(string RtGroupCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("RateGroupMastDelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@RtGroupCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@RtGroupCode"].Value =RtGroupCode;
				
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









        public DataSet chkrgroupcode1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkrgname", ref objSqlConnection);
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
