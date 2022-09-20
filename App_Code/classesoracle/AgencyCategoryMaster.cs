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
/// Summary description for AgencyCategoryMaster
/// </summary>
    public class AgencyCategoryMaster : orclconnection
{
	public AgencyCategoryMaster()
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
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref con);
        }
    }
    public DataSet acmsave(string companycode, string code, string name, string alias, string agencytype, string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acm_Save.acm_Save_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("acn", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("aca", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("agencytype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencytype;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                cmd.Parameters.Add(prm6);



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

    public DataSet acmmodify(string companycode, string code, string name, string alias,string agencytype, string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acm_Modify.acm_Modify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;			
				


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("acn", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("aca", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("agencytype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencytype;
                cmd.Parameters.Add(prm5);



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

    public DataSet acmdelete(string companycode, string code, string name, string alias, string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acm_Delete.acm_Delete_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
				

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("acn", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("aca", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                cmd.Parameters.Add(prm4);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;




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

		public DataSet acmexecute(string companycode,string code,string name,string alias,string agencytype,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acm_Execute.acm_Execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure; 		 
				


                    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = companycode;
                    cmd.Parameters.Add(prm1);
                    OracleParameter prm2 = new OracleParameter("acc", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = code;
                    cmd.Parameters.Add(prm2);
                    OracleParameter prm3 = new OracleParameter("acn", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = name;
                    cmd.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("aca", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = alias;
                    cmd.Parameters.Add(prm4);
                    OracleParameter prm5 = new OracleParameter("agencytype", OracleType.VarChar, 50);
                    prm5.Direction = ParameterDirection.Input;
                    if (agencytype=="0")
                {
                    prm5.Value =System .DBNull .Value ;
                }
                else
                {
                       prm5.Value = agencytype;
                }
                 
                    cmd.Parameters.Add(prm5);

                    cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                    cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;






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


		public DataSet acmexecute1(string companycode,string code,string name,string alias,string agencytype,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acm_Execute.acm_Execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;  
				 
		            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = companycode;
                    cmd.Parameters.Add(prm1);
                    OracleParameter prm2 = new OracleParameter("acc", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = code;
                    cmd.Parameters.Add(prm2);
                    OracleParameter prm3 = new OracleParameter("acn", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = name;
                    cmd.Parameters.Add(prm3);

                    OracleParameter prm4 = new OracleParameter("aca", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = alias;
                    cmd.Parameters.Add(prm4);
                    OracleParameter prm5 = new OracleParameter("agencytype", OracleType.VarChar, 50);
                    prm5.Direction = ParameterDirection.Input;
                    if (agencytype=="0")
                {
                    prm5.Value = System .DBNull .Value;
                }
                else
                {

                    prm5.Value = agencytype;
                }
                    cmd.Parameters.Add(prm5);
                    cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                    cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;





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

		public DataSet acmfirst(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();	
			try
			{
				con.Open();
                cmd = GetCommand("acmfpnl.acmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
 
				
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                cmd.Parameters.Add(prm6);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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

		public DataSet acmlast(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();	
			try
			{
				con.Open();
                cmd = GetCommand("acmfpnl.acmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
 
				
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                cmd.Parameters.Add(prm6);


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

		public DataSet acmprevious(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();	
			try
			{
				con.Open();
                cmd = GetCommand("acmfpnl.acmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                cmd.Parameters.Add(prm6);

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

		public DataSet acmnext(string companycode,string UserId)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acmfpnl.acmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                cmd.Parameters.Add(prm6);
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
	
		public DataSet chkacmcode(string companycode,string UserId,string code)
		{
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
			try
			{
				con.Open();
                cmd = GetCommand("acmcheck.acmcheck_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

				
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("acc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = UserId;
                cmd.Parameters.Add(prm6);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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
        public DataSet countacmcodename(string str, string agencytype)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkacmcodename.chkacmcodename_p", ref objOracleConnection);
           objOraclecommand.CommandType = CommandType.StoredProcedure;
           OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
           prm1.Direction = ParameterDirection.Input;
           prm1.Value = str;
           objOraclecommand.Parameters.Add(prm1);
           
            OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
           prm2.Direction = ParameterDirection.Input;
           if (str.Length > 2)
           {
               prm2.Value = str.Substring (0,2);
           }
           else
           {
               prm2.Value = str;
           }
           objOraclecommand.Parameters.Add(prm2);

           OracleParameter prm3 = new OracleParameter("drpagencytype", OracleType.VarChar, 50);
           prm3.Direction = ParameterDirection.Input;
           prm3.Value = agencytype;
           objOraclecommand.Parameters.Add(prm3);


           objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
           objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

           objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
           objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;






           objorclDataAdapter.SelectCommand = objOraclecommand;
           objorclDataAdapter.Fill (objDataSet);

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

