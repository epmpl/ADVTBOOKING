using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for SchemeTypeMaster.
	/// </summary>
	public class SchemeTypeMaster:connection
	{
		public SchemeTypeMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ModifyValue(string SchemTypeCode,string SchemeTypeName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("SchemeTypeMstModify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;
				
				objSqlCommand.Parameters.Add("@SchemTypeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemTypeCode"].Value =SchemTypeCode;
			
				objSqlCommand.Parameters.Add("@SchemeTypeName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeTypeName"].Value =SchemeTypeName;

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


		public DataSet InsertValue(string SchemTypeCode,string SchemeTypeName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("SchemeTypeMstInsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				
				objSqlCommand.Parameters.Add("@SchemTypeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemTypeCode"].Value =SchemTypeCode;
			
				objSqlCommand.Parameters.Add("@SchemeTypeName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeTypeName"].Value =SchemeTypeName;

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

		public DataSet SelectValue(string SchemTypeCode,string SchemeTypeName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("SchemeTypeSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;
					
				objSqlCommand.Parameters.Add("@SchemTypeCode", SqlDbType.VarChar);
                //if(SchemTypeCode=="" ||SchemTypeCode==null || SchemTypeCode=="0")
                //{
                //    objSqlCommand.Parameters["@SchemTypeCode"].Value ="%%";		
                //}
                //else
                //{
					objSqlCommand.Parameters["@SchemTypeCode"].Value =SchemTypeCode;
                //}
				
				objSqlCommand.Parameters.Add("@SchemeTypeName", SqlDbType.VarChar);
                //if(SchemeTypeName=="" ||SchemeTypeName==null||SchemeTypeName=="0")
                //{
                //    objSqlCommand.Parameters["@SchemeTypeName"].Value ="%%";
                //}
                //else
                //{
					objSqlCommand.Parameters["@SchemeTypeName"].Value =SchemeTypeName;
                //}

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

		public DataSet Selectfnpl(string SchemTypeCode,string SchemeTypeName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("SchemeTypefnpl", ref objSqlConnection);
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

		public DataSet DeleteValue(string SchemTypeCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("SchemeTypeMstdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@SchemTypeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemTypeCode"].Value =SchemTypeCode;
							
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


		public DataSet checkscheme(string SchemTypeCode,string compcode,string userid)	 	
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkscheme", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@SchemTypeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemTypeCode"].Value =SchemTypeCode;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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


        public DataSet chkschemecode1(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("schemenamechk", ref objSqlConnection);
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
