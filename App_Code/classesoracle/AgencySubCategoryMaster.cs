using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for AgencySubCategoryMaster
/// </summary>
    public class AgencySubCategoryMaster : orclconnection
{
	public AgencySubCategoryMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  public DataSet addagencytype()
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("adagencytype.adagencytype_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}


  /*  public DataSet agencycategory(string agencytype)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fillcategory", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencytype"].Value = agencytype;

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
    }*/
		
	
		
		public DataSet ascmsave(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascm_Save.Ascm_Save_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = category;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ascc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = UserId;
                cmd.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("ascn", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = name;
                cmd.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("asca", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = alias;
                cmd.Parameters.Add(prm7);

                da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{	
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}
	

		public DataSet ascmmodify(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascm_Modify.Ascm_Modify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
				
				

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = category;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ascc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code;
                cmd.Parameters.Add(prm4);
          
                OracleParameter prm6 = new OracleParameter("ascn", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = name;
                cmd.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("asca", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = alias;
                cmd.Parameters.Add(prm7);

                da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}

		public DataSet ascmdelete(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascm_Delete.Ascm_Delete_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = category;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ascc", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code;
                cmd.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("ascn", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = name;
                cmd.Parameters.Add(prm6);
                OracleParameter prm7 = new OracleParameter("asca", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = alias;
                cmd.Parameters.Add(prm7);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}

		public DataSet ascmexecute(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascm_Execute.Ascm_Execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;               


                    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = companycode;
                    cmd.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    if (agency=="0")
                {
                    prm2.Value = System.DBNull .Value ;
                }
                else
                {
                    prm2.Value = agency;
                }
                    cmd.Parameters.Add(prm2);
                    OracleParameter prm3 = new OracleParameter("acc", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    if (category=="0")
                {
                    prm3.Value = System .DBNull .Value ;
                }
                else
                {
                    prm3.Value = category;
                }
                    cmd.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("ascc", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = code;
                    cmd.Parameters.Add(prm4);
                    OracleParameter prm7 = new OracleParameter("asca", OracleType.VarChar, 50);
                    prm7.Direction = ParameterDirection.Input;
                    prm7.Value = alias;
                    cmd.Parameters.Add(prm7);
                    OracleParameter prm8 = new OracleParameter("ascn", OracleType.VarChar, 50);
                    prm8.Direction = ParameterDirection.Input;
                    prm8.Value = name;
                    cmd.Parameters.Add(prm8);

                    cmd.Parameters.Add("P_Accounts", OracleType.Cursor);
                    cmd.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                    da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}			
		}


		public DataSet ascmexecute1(string companycode,string agency,string category,string code,string name,string alias,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascm_Execute.Ascm_Execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;  
				 
				

                    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = companycode;
                    cmd.Parameters.Add(prm1);

                    OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    if (agency=="0")
                    {
                    prm2.Value = System.DBNull.Value;
                    }
                    else
                    {
                    prm2.Value = agency;
                    }
                    cmd.Parameters.Add(prm2);

                    OracleParameter prm3 = new OracleParameter("acc", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    if (category == "0")
                    {
                        prm3.Value = System.DBNull.Value;
                    }
                    else
                    {
                        prm3.Value = category;
                    }

                    cmd.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("ascc", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = code;
                    cmd.Parameters.Add(prm4);
                    OracleParameter prm7 = new OracleParameter("asca", OracleType.VarChar, 50);
                    prm7.Direction = ParameterDirection.Input;
                    prm7.Value = alias;
                    cmd.Parameters.Add(prm7);
                    OracleParameter prm8 = new OracleParameter("ascn", OracleType.VarChar, 50);
                    prm8.Direction = ParameterDirection.Input;
                    prm8.Value = name;
                    cmd.Parameters.Add(prm8);

                    cmd.Parameters.Add("P_Accounts", OracleType.Cursor);
                    cmd.Parameters["P_Accounts"].Direction = ParameterDirection.Output;








                    da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref con);
			}
		}

		public DataSet ascmfirst(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascmfpnl.Ascmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

             


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                da.SelectCommand = cmd;				
				da.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref con);
			}
		}

		public DataSet ascmlast(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();	
			try
			{
				con.Open();
                cmd = GetCommand("Ascmfpnl.Ascmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
 
				

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;				
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref con);
			}
		}

		public DataSet ascmprevious(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascmfpnl.Ascmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;				
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref con);
			}
		
		}

		public DataSet ascmnext(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();	
			try
			{
				con.Open();
                cmd = GetCommand("Ascmfpnl.Ascmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;				
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref con);
			}
		
		}
	
		public DataSet chkascmcode(string companycode,string UserId,string code)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("Ascmcheck.Ascmcheck_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

				

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ascc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                da.SelectCommand = cmd;
				da.Fill(ds);
				return ds;
	
			}
		
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref con);
			}

		}
    public DataSet addagencycat(string agencytype)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("bindagencytype.bindagencytype_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            
            OracleParameter prm1 = new OracleParameter("agencytype", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = agencytype;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }

    public DataSet countascmcode(string str)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkascmodename.chkascmodename_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = str;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (str.Length>2)
            {
                prm2.Value = str.Substring(0, 2);
            }
            else
            {
            prm2.Value = str;
            }
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
            objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }
	}
}

