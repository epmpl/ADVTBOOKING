using System;
using System.Data;
using System.Data.SqlClient;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for MaterialMaster.
	/// </summary>
	public class MaterialMaster:connection
	{
		public MaterialMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet chksave(string compcode,string matcode,string matname,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("matchk", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@matcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matcode"].Value =matcode;


				objSqlCommand.Parameters.Add("@matname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matname"].Value =matname;


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



		public DataSet matinsert(string compcode,string matcode,string matname,string userid,string matalias)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("matinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@matcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matcode"].Value =matcode;


				objSqlCommand.Parameters.Add("@matname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matname"].Value =matname;
				

				objSqlCommand.Parameters.Add("@matalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matalias"].Value =matalias;

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


		public DataSet deletemat(string compcode,string matcode,string matname,string matalias,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("matdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@matcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matcode"].Value =matcode;

				objSqlCommand.Parameters.Add("@matname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matname"].Value =matname;
				
				objSqlCommand.Parameters.Add("@matalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matalias"].Value =matalias;

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


		public DataSet matupdate(string compcode,string matcode,string matname,string userid,string matalias)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("matupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@matcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matcode"].Value =matcode;


				objSqlCommand.Parameters.Add("@matname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matname"].Value =matname;
				

				objSqlCommand.Parameters.Add("@matalias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@matalias"].Value =matalias;

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


		public DataSet matexe(string compcode,string matcode,string matname,string userid,string matalias)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("matexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@matcode", SqlDbType.VarChar);
				if(matcode=="" || matcode== null || matcode == "undefined")
				{
					objSqlCommand.Parameters["@matcode"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@matcode"].Value =matcode;
				}

				
				objSqlCommand.Parameters.Add("@matname", SqlDbType.VarChar);
				if(matname=="" || matname==null || matname=="undefined")
				{
						objSqlCommand.Parameters["@matname"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@matname"].Value =matname;
				}


				objSqlCommand.Parameters.Add("@matalias", SqlDbType.VarChar);
				if(matalias=="" || matalias==null || matalias=="undefined")
				{
					objSqlCommand.Parameters["@matalias"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@matalias"].Value =matalias;
				}


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

		public DataSet matfnpl(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("matfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
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





		}
	}

