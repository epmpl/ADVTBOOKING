using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for SchemeMaster.
	/// </summary>
	public class SchemeMaster:connection
	{
		public SchemeMaster()
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


		public DataSet colscheme(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schemetypsel", ref objSqlConnection);
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


		public DataSet schinsert(string AdvType,string AdvCat,string SchemeCode,string SchemeType,string CombName,string PackName,string Color,string Remarks,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schsave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@AdvType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@AdvType"].Value =AdvType;

				objSqlCommand.Parameters.Add("@SchemeType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeType"].Value =SchemeType;

				objSqlCommand.Parameters.Add("@CombName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CombName"].Value =CombName;

				objSqlCommand.Parameters.Add("@PackName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PackName"].Value =PackName;

				objSqlCommand.Parameters.Add("@Color", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Color"].Value =Color;


				objSqlCommand.Parameters.Add("@AdvCat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@AdvCat"].Value =AdvCat;

				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;
				

				objSqlCommand.Parameters.Add("@Remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Remarks"].Value =Remarks;
				
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


		public DataSet chkinsert(string SchemeCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkschemesave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;
				
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




		public DataSet schmodify(string AdvType,string AdvCat,string SchemeCode,string SchemeType,string CombName,string PackName,string Color,string Remarks,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@AdvType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@AdvType"].Value =AdvType;

				objSqlCommand.Parameters.Add("@SchemeType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeType"].Value =SchemeType;

				objSqlCommand.Parameters.Add("@CombName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CombName"].Value =CombName;

				objSqlCommand.Parameters.Add("@PackName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@PackName"].Value =PackName;

				objSqlCommand.Parameters.Add("@Color", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Color"].Value =Color;


				objSqlCommand.Parameters.Add("@AdvCat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@AdvCat"].Value =AdvCat;

				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;
				

				objSqlCommand.Parameters.Add("@Remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Remarks"].Value =Remarks;
				
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


		public DataSet 	checkcode(string compcode,string SchemeCode,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkschemecode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

												
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




		public DataSet 	selectpubdaymodify(string compcode,string SchemeCode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("secdaymodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

				objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sun"].Value =sun;
				
				objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mon"].Value =mon;


				objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
				objSqlCommand.Parameters["@tue"].Value =tue;

				objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
				objSqlCommand.Parameters["@wed"].Value =wed;
				
				objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
				objSqlCommand.Parameters["@thu"].Value =thu;


				objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fri"].Value =fri;

				objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sat"].Value =sat;
				
				objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
				objSqlCommand.Parameters["@all"].Value =all;
								
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




		public DataSet 	selectpubdaysave(string compcode,string SchemeCode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("secdaysave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

				objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sun"].Value =sun;
				
				objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mon"].Value =mon;


				objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
				objSqlCommand.Parameters["@tue"].Value =tue;

				objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
				objSqlCommand.Parameters["@wed"].Value =wed;
				
				objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
				objSqlCommand.Parameters["@thu"].Value =thu;


				objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fri"].Value =fri;

				objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sat"].Value =sat;
				
				objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
				objSqlCommand.Parameters["@all"].Value =all;
								
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


		public DataSet schexe(string AdvType,string AdvCat,string SchemeCode,string SchemeType,string CombName,string PackName,string Color,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@AdvType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@AdvType"].Value =AdvType;

				objSqlCommand.Parameters.Add("@SchemeType", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeType"].Value =SchemeType;

				objSqlCommand.Parameters.Add("@CombName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CombName"].Value =CombName;

				

				objSqlCommand.Parameters.Add("@Color", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Color"].Value =Color;


				objSqlCommand.Parameters.Add("@AdvCat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@AdvCat"].Value =AdvCat;

				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;
				

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
			

		public DataSet 	checkpubcode(string compcode,string SchemeCode,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schdayexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

												
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


		public DataSet 	secfnpl(string compcode,string SchemeCode,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("secfnpl", ref objSqlConnection);
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


		public DataSet 	secdel(string compcode,string SchemeCode,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;
				
																
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




		public DataSet 	schbind(string compcode,string userid,string SchemeCode)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("secbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

												
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



		public DataSet 	detailinsert(string compcode,string userid,string SchemeCode,string paid,string free,string disno ,string distype,string discount,string freins,string fromdate,string todate,string period,string periodtyp)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("secsubmit", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

												
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

				objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
				if(paid=="" || paid==null)
				{
					objSqlCommand.Parameters["@paid"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@paid"].Value =paid;
				}

				objSqlCommand.Parameters.Add("@free", SqlDbType.VarChar);
				if(free==""  || free==null)
				{
					objSqlCommand.Parameters["@free"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@free"].Value =free;
				}

				objSqlCommand.Parameters.Add("@disno", SqlDbType.VarChar);
				if(disno==""  || disno==null)
				{
					objSqlCommand.Parameters["@disno"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@disno"].Value =disno;
				}
				objSqlCommand.Parameters.Add("@distype", SqlDbType.VarChar);
				if(distype=="0")
				{
					objSqlCommand.Parameters["@distype"].Value ="";
				}
				else
				{
					objSqlCommand.Parameters["@distype"].Value =distype;
				}

				objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
				if(discount=="" || discount==null)
				{
					objSqlCommand.Parameters["@discount"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@discount"].Value =discount;
				}

				objSqlCommand.Parameters.Add("@freins", SqlDbType.VarChar);
				if(freins=="" || freins==null)
				{
					objSqlCommand.Parameters["@freins"].Value =System.DBNull.Value;				
				}
				else
				{
					objSqlCommand.Parameters["@freins"].Value =freins;
				}

				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.DateTime);
				if(fromdate=="" || fromdate==null)
				{
					objSqlCommand.Parameters["@fromdate"].Value=System.DBNull.Value;
				}
				else
				{
						objSqlCommand.Parameters["@fromdate"].Value =fromdate;
				}
				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);

				if(todate=="" || todate==null)
				{
					objSqlCommand.Parameters["@todate"].Value=System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@todate"].Value =todate;
				}
				objSqlCommand.Parameters.Add("@period", SqlDbType.VarChar);
				if(period=="")
				{
						objSqlCommand.Parameters["@period"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@period"].Value =period;
				}

				objSqlCommand.Parameters.Add("@periodtyp", SqlDbType.VarChar);
				if(periodtyp=="0" )
				{
					objSqlCommand.Parameters["@periodtyp"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@periodtyp"].Value =periodtyp;
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



		
		public DataSet 	detailupdate(string Code, string compcode,string userid,string SchemeCode,string paid,string free,string disno ,string distype,string discount,string freins,string fromdate,string todate,string period,string periodtyp)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("secupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Code"].Value =Code;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

												
				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;

				objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@paid"].Value =paid;

				objSqlCommand.Parameters.Add("@free", SqlDbType.VarChar);
				objSqlCommand.Parameters["@free"].Value =free;

				objSqlCommand.Parameters.Add("@disno", SqlDbType.VarChar);
				objSqlCommand.Parameters["@disno"].Value =disno;

				objSqlCommand.Parameters.Add("@distype", SqlDbType.VarChar);
				if(distype=="0")
				{
					objSqlCommand.Parameters["@distype"].Value ="";
				}
				else
				{
					objSqlCommand.Parameters["@distype"].Value =distype;
				}

				objSqlCommand.Parameters.Add("@discount", SqlDbType.VarChar);
				objSqlCommand.Parameters["@discount"].Value =discount;

				objSqlCommand.Parameters.Add("@freins", SqlDbType.VarChar);
				objSqlCommand.Parameters["@freins"].Value =freins;

				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				if(fromdate=="" || fromdate==null)
				{
					objSqlCommand.Parameters["@fromdate"].Value=System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@fromdate"].Value =fromdate;
				}
				
				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);

				if(todate=="" || todate==null)
				{
					objSqlCommand.Parameters["@todate"].Value=System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@todate"].Value =todate;
				}
				
				objSqlCommand.Parameters.Add("@period", SqlDbType.VarChar);
				if(period=="0")
				{
					objSqlCommand.Parameters["@period"].Value ="";
				}
				else
				{
					objSqlCommand.Parameters["@period"].Value =period;
				}

				objSqlCommand.Parameters.Add("@periodtyp", SqlDbType.VarChar);
				objSqlCommand.Parameters["@periodtyp"].Value =periodtyp;
				
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



		public DataSet clientcontactbind(string SchemeCode,string userid,string compcode,string code10)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schdetsel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;


				objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code10"].Value =code10;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				 
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


		public DataSet detaildelete(string SchemeCode,string compcode,string userid,string code)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("schdeldetail", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@SchemeCode"].Value =SchemeCode;


				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =code;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				 
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
