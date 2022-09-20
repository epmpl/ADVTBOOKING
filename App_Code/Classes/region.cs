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
/// Summary description for region
/// </summary>
namespace NewAdbooking.Classes
{
public class region:connection
{
    public DataSet regionmaster_save(string Comp_Code, string Region_Code, string Region_Name, string Region_alias, string UserId, string zone)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	


			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("dbo.region_save", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Comp_Code"].Value =Comp_Code;

				
				objSqlCommand.Parameters.Add("@Region_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region_Code"].Value =Region_Code;
				
				
				objSqlCommand.Parameters.Add("@Region_Name", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region_Name"].Value =Region_Name;
				
				
				objSqlCommand.Parameters.Add("@Region_alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region_alias"].Value =Region_alias;



				objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
				objSqlCommand.Parameters["@UserId"].Value =UserId;

                objSqlCommand.Parameters.Add("@zone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone1"].Value = zone;

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





    public DataSet regionmaster_modify(string Comp_Code, string Region_Code, string Region_Name, string Region_alias, string UserId, string zone)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	


			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_modifyregion", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Comp_Code"].Value =Comp_Code;

				
				objSqlCommand.Parameters.Add("@Region_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region_Code"].Value =Region_Code;
				
				
				objSqlCommand.Parameters.Add("@Region_Name", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region_Name"].Value =Region_Name;
				
				
				objSqlCommand.Parameters.Add("@Region_alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Region_alias"].Value =Region_alias;



                objSqlCommand.Parameters.Add("@zone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone1"].Value = zone;


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



    public DataSet chkregion(string compcode, string regioncode, string regionname, string alias, string username, string zone)

		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("sp_chkregion", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				

				objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Comp_Code"].Value =compcode;

				
				objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
			//	if(regioncode != null && regioncode != ""  && regioncode != "undefined")
					objSqlCommand.Parameters["@regioncode"].Value =regioncode;
                //else
                //    objSqlCommand.Parameters["@regioncode"].Value ="%%";
				
				
				objSqlCommand.Parameters.Add("@regionname", SqlDbType.VarChar);
				//if(regionname != null && regionname != "" && regionname!= "undefined")
					objSqlCommand.Parameters["@regionname"].Value =regionname;
                //else
                //    objSqlCommand.Parameters["@regionname"].Value ="%%";
				
				
				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				//if(alias != null && alias != "" && alias!= "undefined")
					objSqlCommand.Parameters["@alias"].Value =alias;
                //else
                //    objSqlCommand.Parameters["@alias"].Value ="%%";



                objSqlCommand.Parameters.Add("@zone1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone1"].Value = zone;
				//string str=objDataSet.Tables["region_mst"].Rows[0].ToString ();

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

	
//********************************************************************************************************	
    
//*******************************************************************************************************


		public DataSet btndelete(string compcode,string regioncode,string userid)

		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("regiondel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;
				

				objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@regioncode"].Value =regioncode;
				
 
				
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


    public DataSet chkregion123(string compcode, string regionname, string regioncode,string userid)

		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkregion", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@regionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@regionname"].Value = regionname;
		
				objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@regioncode"].Value =regioncode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
				
				
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
    public DataSet countregioncode(string str,string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkregioncodename", ref objSqlConnection);
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
//******************************************************************************************************
    public DataSet chknameforduplicate(string regioncode, string regionname, string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkduplicateregion", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@regioncode"].Value = regioncode;

            objSqlCommand.Parameters.Add("@regionname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@regionname"].Value = regionname;


            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (SqlException objException)
        {
            throw (objException);
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
 //******************************************************************************************************
        public DataSet getzone(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindzone", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
               
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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
