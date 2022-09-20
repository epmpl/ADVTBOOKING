using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for DiscountMaster.
	/// </summary>
	public class DiscountMaster:connection
	{
		public DiscountMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public DataSet advdata(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				
				objSqlConnection.Open();
				objSqlCommand = GetCommand("getadvtyp", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				 
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



		public DataSet advdata1(string comb,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bindpkgname", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@comb", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comb"].Value =comb;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				 
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




		public DataSet chksave(string discode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkdissave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				 
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



		public DataSet disinsert(string discode,string comb,string compcode,string userid,string advcode,string catcode,string pkgname,string  distyp,string disval,string fromdate,string todate,string remarks)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("disinsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				objSqlCommand.Parameters.Add("@comb", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comb"].Value =comb;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@advcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@advcode"].Value =advcode;

				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@catcode"].Value =catcode;

				objSqlCommand.Parameters.Add("@pkgname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pkgname"].Value =pkgname;

				objSqlCommand.Parameters.Add("@distyp", SqlDbType.VarChar);
				objSqlCommand.Parameters["@distyp"].Value =distyp;

				objSqlCommand.Parameters.Add("@disval", SqlDbType.VarChar);
				objSqlCommand.Parameters["@disval"].Value =disval;

				
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromdate"].Value =fromdate;

				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				if(todate=="" || todate==null || todate=="undefined/undefined/")
				{
					objSqlCommand.Parameters["@todate"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@todate"].Value =Convert.ToDateTime(todate);
				}


				objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value =remarks;
				 
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


		public DataSet disexe(string discode,string comb,string compcode,string userid,string advcode,string catcode,string  distyp,string fromdate)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("disexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				if(discode=="" || discode== null || discode=="undefined")
				{
					objSqlCommand.Parameters["@discode"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@discode"].Value =discode;
				}
				objSqlCommand.Parameters.Add("@comb", SqlDbType.VarChar);
				if(comb=="0")
				{
				objSqlCommand.Parameters["@comb"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@comb"].Value =comb;
				}
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@advcode", SqlDbType.VarChar);
				if(advcode=="0")
				{
					objSqlCommand.Parameters["@advcode"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@advcode"].Value =advcode;
				}

				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				if(catcode=="0")
				{
					objSqlCommand.Parameters["@catcode"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@catcode"].Value =catcode;
				}
				
				objSqlCommand.Parameters.Add("@distyp", SqlDbType.VarChar);
				if(distyp=="0")
				{
					objSqlCommand.Parameters["@distyp"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@distyp"].Value =distyp;
				}
		
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				if(fromdate=="" || fromdate== null || fromdate=="undefined")
				{
					objSqlCommand.Parameters["@fromdate"].Value ="%%";
				}
				else
				{
					objSqlCommand.Parameters["@fromdate"].Value =fromdate;
				}
								 
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





		public DataSet disupdate(string discode,string comb,string compcode,string userid,string advcode,string catcode,string pkgname,string  distyp,string disval,string fromdate,string todate,string remarks)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("disupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				objSqlCommand.Parameters.Add("@comb", SqlDbType.VarChar);
				objSqlCommand.Parameters["@comb"].Value =comb;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@advcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@advcode"].Value =advcode;

				objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@catcode"].Value =catcode;

				objSqlCommand.Parameters.Add("@pkgname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pkgname"].Value =pkgname;

				objSqlCommand.Parameters.Add("@distyp", SqlDbType.VarChar);
				objSqlCommand.Parameters["@distyp"].Value =distyp;

				objSqlCommand.Parameters.Add("@disval", SqlDbType.VarChar);
				objSqlCommand.Parameters["@disval"].Value =disval;

				
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromdate"].Value =fromdate;

				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				if(todate=="" || todate==null || todate=="undefined/undefined/")
				{
					objSqlCommand.Parameters["@todate"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@todate"].Value =Convert.ToDateTime(todate);
				}


				objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value =remarks;
				 
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


		public DataSet listboxdis(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adsizeadvcategory", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				
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



		public DataSet checkmulti(string compcode,string userid,string discode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("dismultiselect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				
				
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


		public DataSet listboxmultibind(string compcode,string userid,string discode,string abc)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertmultidis", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				objSqlCommand.Parameters.Add("@abc",SqlDbType.VarChar);
				objSqlCommand.Parameters["@abc"].Value=abc;
				
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



		public DataSet listboxmultiupdate(string compcode,string userid,string discode,string abc)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatemultidis", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				objSqlCommand.Parameters.Add("@abc",SqlDbType.VarChar);
				objSqlCommand.Parameters["@abc"].Value=abc;
				
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




		public DataSet chkfnpl(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("disfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				
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



		public DataSet delete(string discode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("disdelete ", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@discode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discode"].Value =discode;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				 
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
		
	
	
	
	
	
	
	
	
	
	
	}






	

	}

