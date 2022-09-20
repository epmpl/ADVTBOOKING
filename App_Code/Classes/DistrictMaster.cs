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
/// Summary description for DistrictMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class DistrictMaster:connection
{
	public DistrictMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet bindstate(string code,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("bindstate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@countrycode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@countrycode"].Value=code;

				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
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


		public DataSet statesel(string compcode,string userid,string statcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("statesel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@statcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@statcode"].Value=statcode;

				objSqlCommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value=compcode;
 
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
		
			
		public DataSet ModifyValue(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMstModify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@DistCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistCode"].Value =DistCode;
			
				objSqlCommand.Parameters.Add("@DistName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistName"].Value =DistName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias ;

				objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@StateName"].Value =StateName;

				objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CountryName"].Value =CountryName;
								
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


		public DataSet InsertValue(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMstInsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@DistCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistCode"].Value =DistCode;
			
				objSqlCommand.Parameters.Add("@DistName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistName"].Value =DistName;

				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias "].Value =Alias ;

				objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@StateName"].Value =StateName;

				objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CountryName"].Value =CountryName;

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

		public DataSet SelectValue(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMstSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;
					
				objSqlCommand.Parameters.Add("@DistCode", SqlDbType.VarChar);
//				if(DistCode=="" ||DistCode==null || DistCode=="0")
//				{
//					objSqlCommand.Parameters["@DistCode"].Value ="%%";		
//					//objSqlCommand.Parameters["@DistCode"].Value=
//				}
				//else
				//{
					objSqlCommand.Parameters["@DistCode"].Value =DistCode;
				//}
								
				objSqlCommand.Parameters.Add("@DistName", SqlDbType.VarChar);
//				if(DistName=="" ||DistName==null||DistName=="0")
//				{
//					objSqlCommand.Parameters["@DistName"].Value ="%%";
//				}
//				else
//				{
					objSqlCommand.Parameters["@DistName"].Value =DistName;
				//}

				
				objSqlCommand.Parameters.Add("@Alias ", SqlDbType.VarChar);
//				if(@Alias=="" ||@Alias==null||@Alias=="0")
//				{
//					objSqlCommand.Parameters["@Alias "].Value ="%%";
//				}
//				else
//				{
					objSqlCommand.Parameters["@Alias "].Value =Alias;
				//}

				objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
//				if(StateName=="" ||StateName==null||StateName=="0")
//				{
//					objSqlCommand.Parameters["@StateName"].Value ="%%";
//				}
//				else
//				{
					objSqlCommand.Parameters["@StateName"].Value =StateName;
				//}

				objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
//				if(CountryName=="" ||CountryName==null||CountryName=="0")
//				{
//					objSqlCommand.Parameters["@CountryName"].Value ="%%";
//				}
//				else
//				{
					objSqlCommand.Parameters["@CountryName"].Value =CountryName;

				//}



				objSqlDataAdapter =new SqlDataAdapter(objSqlCommand);
				//objSqlDataAdapter.SelectCommand =objSqlCommand;
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

		public DataSet Selectfnpl(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMstfnpl", ref objSqlConnection);
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

		public DataSet state(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMst_State", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

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

		public DataSet DeleteValue(string DistCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMstDelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@DistCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistCode"].Value =DistCode;
				
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

		public DataSet country(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("DistrictMst_Country", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

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

    public DataSet checkdistrict(string DistCode, string DistName, string compcode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkdiscode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@DistCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistCode"].Value =DistCode;

                objSqlCommand.Parameters.Add("@DistName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DistName"].Value = DistName;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                //objSqlCommand.Parameters.Add("@countrycode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@countrycode"].Value = countrycode;
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

    public DataSet countdistrictcode(string str, string countrycode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkdistrictcodename", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;

            objSqlCommand.Parameters.Add("@countrycode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@countrycode"].Value = countrycode;

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

    public DataSet countdistrictcodename(string str, string strname, string compcode, string countrycode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkdistrictcodenamemodify", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@strname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@strname"].Value = strname;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = compcode;

            objSqlCommand.Parameters.Add("@countrycode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@countrycode"].Value = countrycode;

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
