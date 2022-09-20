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
/// Summary description for CityMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class CityMaster:connection
{
	public CityMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet distselect(string compcode,string userid,string statcode,string distcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("distsel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@statcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@statcode"].Value=statcode;

				objSqlCommand.Parameters.Add("@distcode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@distcode"].Value=distcode;
				
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
		
		public DataSet binddistrict(string code1,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("binddistrict", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@statecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@statecode"].Value=code1;

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
		

		public DataSet ModifyValue(string CityCode,string CityName,string Alias,string DistrictName,string StateName,string ZoneName,string CountryName,string CitySTD,string Region,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMstModify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;
				
				objSqlCommand.Parameters.Add("@CityCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityCode"].Value =CityCode;
			
				objSqlCommand.Parameters.Add("@CityName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityName"].Value =CityName;

				objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias"].Value =Alias ;

				objSqlCommand.Parameters.Add("@DistrictName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistrictName"].Value =DistrictName ;

				objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@StateName"].Value =StateName ;

				objSqlCommand.Parameters.Add("@ZoneName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ZoneName"].Value =ZoneName ;

				objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CountryName"].Value =CountryName ;

				objSqlCommand.Parameters.Add("@CitySTD", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CitySTD"].Value =CitySTD ;

				objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region"].Value =Region ;

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


		public DataSet InsertValue(string CityCode,string CityName,string Alias,string DistrictName,string StateName,string ZoneName,string CountryName,string CitySTD,string Region,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMstInsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@CityCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityCode"].Value =CityCode;
			
				objSqlCommand.Parameters.Add("@CityName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityName"].Value =CityName;

				objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias"].Value =Alias ;

				objSqlCommand.Parameters.Add("@DistrictName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistrictName"].Value =DistrictName ;

				objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@StateName"].Value =StateName ;

				objSqlCommand.Parameters.Add("@ZoneName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ZoneName"].Value =ZoneName ;

				objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CountryName"].Value =CountryName ;

				objSqlCommand.Parameters.Add("@CitySTD", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CitySTD"].Value =CitySTD ;

				objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region"].Value =Region ;

                objSqlCommand.Parameters.Add("@int_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@int_id"].Value = "";

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

		public DataSet SelectValue(string CityCode,string CityName,string Alias,string DistrictName,string StateName,string ZoneName,string CountryName,string CitySTD,string Region,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMstSelect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@CityCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityCode"].Value =CityCode;
			
				objSqlCommand.Parameters.Add("@CityName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityName"].Value =CityName;

				objSqlCommand.Parameters.Add("@Alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Alias"].Value =Alias ;

				objSqlCommand.Parameters.Add("@DistrictName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@DistrictName"].Value =DistrictName ;

				objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@StateName"].Value =StateName ;

				objSqlCommand.Parameters.Add("@ZoneName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ZoneName"].Value =ZoneName ;

				objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CountryName"].Value =CountryName ;

				objSqlCommand.Parameters.Add("@CitySTD", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CitySTD"].Value =CitySTD ;

				objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region"].Value =Region ;

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

		public DataSet Selectfnpl(string CityCode,string CityName,string Alias,string DistrictName,string StateName,string ZoneName,string CountryName,string CitySTD,string Region,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMstfnpl", ref objSqlConnection);
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

		public DataSet district(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMst_District", ref objSqlConnection);
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
				objSqlCommand = GetCommand("CityMst_State", ref objSqlConnection);
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

		public DataSet zone(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMst_Zone", ref objSqlConnection);
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
				objSqlCommand = GetCommand("CityMst_Country", ref objSqlConnection);
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

		public DataSet region(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMst_Region", ref objSqlConnection);
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

		public DataSet DeleteValue(string CityCode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("CityMastDelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;	
		
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@CityCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityCode"].Value =CityCode;
				
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


    public DataSet citycheck(string CityCode, string compcode, string name, string CountryName, string StateName, string DistrictName,string mode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("citychkcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@CityCode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@CityCode"].Value =CityCode;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;


                objSqlCommand.Parameters.Add("@CountryName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CountryName"].Value = CountryName;

                objSqlCommand.Parameters.Add("@StateName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@StateName"].Value = StateName;

                objSqlCommand.Parameters.Add("@DistrictName", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DistrictName"].Value = DistrictName;

                objSqlCommand.Parameters.Add("@mode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mode"].Value = mode;

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
    public DataSet countcode(string str, string countrycode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkcitycodename", ref objSqlConnection);
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
    //=========================bind branch name==============================
    public DataSet retainer()
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("login_getbranchname", ref con);
            com.CommandType = CommandType.StoredProcedure;

            //com.Parameters.Add("@Curr_Name", SqlDbType.VarChar);
            //com.Parameters["@Curr_Name"].Value = currencyname;

            //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
            //com.Parameters["@Curr_Code"].Value = currencycode;

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


    public DataSet usersavebranch(string username, string branchcode, string compcode, string CityCode, string userflag)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("CitySaveBranch", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@username", SqlDbType.VarChar);
            com.Parameters["@username"].Value = username;

            com.Parameters.Add("@branchcode", SqlDbType.VarChar);
            com.Parameters["@branchcode"].Value = branchcode;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = compcode;

            com.Parameters.Add("@CityCode", SqlDbType.VarChar);
            com.Parameters["@CityCode"].Value = CityCode;

            com.Parameters.Add("@userflag1", SqlDbType.VarChar);
            com.Parameters["@userflag1"].Value = userflag;

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

    public DataSet userupdatebranch(string username, string branchcode, string compcode, string citycode, string userflag)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("CityUpdateBranch", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@username", SqlDbType.VarChar);
            com.Parameters["@username"].Value = username;

            com.Parameters.Add("@branchcode1", SqlDbType.VarChar);
            com.Parameters["@branchcode1"].Value = branchcode;

            com.Parameters.Add("@userflag1", SqlDbType.VarChar);
            com.Parameters["@userflag1"].Value = userflag;

            com.Parameters.Add("@compcode1", SqlDbType.VarChar);
            com.Parameters["@compcode1"].Value = compcode;

            com.Parameters.Add("@citycode1", SqlDbType.VarChar);
            com.Parameters["@citycode1"].Value = citycode;

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
    public DataSet executebranch(string compcode, string citycode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("citybranchexe", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@citycode", SqlDbType.VarChar);
                com.Parameters["@citycode"].Value = citycode;

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
//=======Bind region=========
    public DataSet bindregion(string code, string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bindregion", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@zonecode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@zonecode"].Value = code;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

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
