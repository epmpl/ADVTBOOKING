using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for ColorMaster.
	/// </summary>
	public class ColorMaster:connection
	{
		public ColorMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ModifyValue(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("ColorMastModify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@ColorCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorCode"].Value =ColorCode;
			
				objSqlCommand.Parameters.Add("@ColorName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorName"].Value =ColorName;

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

		public DataSet InsertValue(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("ColorMastInsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@ColorCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorCode"].Value =ColorCode;
			
				objSqlCommand.Parameters.Add("@ColorName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorName"].Value =ColorName;

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

		public DataSet SelectValue(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("ColorMastSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@ColorCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorCode"].Value =ColorCode;
				
				objSqlCommand.Parameters.Add("@ColorName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorName"].Value =ColorName;
				
				objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias"].Value =Alias;

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

		public DataSet Selectfnpl(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("ColorSelectfnpl", ref objSqlConnection);
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

        public DataSet checkcolor(string ColorCode, string ColorName, string compcode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkcolorcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@ColorCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorCode"].Value =ColorCode;

                objSqlCommand.Parameters.Add("@ColorName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ColorName"].Value = ColorName;

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

		public DataSet DeleteValue(string ColorCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("ColorMastDelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@ColorCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ColorCode"].Value =ColorCode;
				
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

        public DataSet countcolorcode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcolorcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                //objSqlCommand.Parameters.Add("@ColorName", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ColorName"].Value = ColorName;

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
