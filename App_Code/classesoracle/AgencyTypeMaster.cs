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
/// Summary description for AgencyTypeMaster
/// </summary>
    public class AgencyTypeMaster : orclconnection
{
	public AgencyTypeMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet atmsave(string companycode, string code, string name, string alias, string UserId, string txtefffrom, string txtefftill, string commrate, string commapply, string creditdays, string adcat, string uniqueid, string mrvno, string PAM_TARGET_TABLENAME, string monthdate,string comm_req)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atm_Save.atm_Save_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("ata", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("atn", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("userid1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = UserId;
                cmd.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("commrate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = commrate;
                cmd.Parameters.Add(prm6);


                OracleParameter prm11 = new OracleParameter("effectivefrom", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (txtefffrom == null || txtefffrom == "" || txtefffrom == "undefined/undefined/")
                {
                    prm11.Value = System.DBNull.Value; 
                }
                else
                {
                  
                    prm11.Value = Convert.ToDateTime(txtefffrom).ToString ("dd-MMMM-yyyy");
                }

                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("effectivetill", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (txtefftill == null || txtefftill == "" || txtefftill == "undefined/undefined/")
                {
                    prm12.Value = System.DBNull.Value; 
                }
                else
                {
                   
                    prm12.Value = Convert.ToDateTime(txtefftill).ToString("dd-MMMM-yyyy");
                
                }
                cmd.Parameters.Add(prm12);          

              

          
                OracleParameter prm7 = new OracleParameter("commapply", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = commapply;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("creditdays", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = creditdays;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adcat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adcat;

                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("uniqueid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = uniqueid;
                cmd.Parameters.Add(prm10);


                OracleParameter prm13 = new OracleParameter("mrvno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = mrvno;
                cmd.Parameters.Add(prm13);

                  OracleParameter prm14 = new OracleParameter("pamtargettable", OracleType.VarChar, 50);
                  prm14.Direction = ParameterDirection.Input;
                  prm14.Value = PAM_TARGET_TABLENAME;
                  cmd.Parameters.Add(prm14);

                  OracleParameter prm15 = new OracleParameter("pmonthbill", OracleType.VarChar, 50);
                  prm15.Direction = ParameterDirection.Input;
                  prm15.Value = monthdate;
                  cmd.Parameters.Add(prm15);

                  OracleParameter prm16 = new OracleParameter("pcomm_req", OracleType.VarChar, 50);
                  prm16.Direction = ParameterDirection.Input;
                  prm16.Value = comm_req;
                  cmd.Parameters.Add(prm16);
                
                
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

    public DataSet atmmodify(string companycode, string code, string name, string alias, string UserId, string txtefffrom, string txtefftill, string commrate, string commdetail, string creditdays, string adcat, string uniqueid, string mrvno, string PAM_TARGET_TABLENAME,string  monthdate,string comm_req)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atm_Modify.atm_Modify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("ata", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("atn", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = UserId;
                cmd.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("commrate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = commrate;
                cmd.Parameters.Add(prm6);


                OracleParameter prm11 = new OracleParameter("effectivefrom", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (txtefffrom == null || txtefffrom == "" || txtefffrom == "undefined/undefined/")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {

                    prm11.Value = Convert.ToDateTime(txtefffrom).ToString("dd-MMMM-yyyy");
                }

                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("effectivetill", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (txtefftill == null || txtefftill == "" || txtefftill == "undefined/undefined/")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = Convert.ToDateTime(txtefftill).ToString ("dd-MMMM-yyyy");

                }
                cmd.Parameters.Add(prm12);




                OracleParameter prm7 = new OracleParameter("commapply", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = commdetail;
                cmd.Parameters.Add(prm7);
                OracleParameter prm8 = new OracleParameter("creditdays", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = creditdays;
                cmd.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("adcat1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adcat;

                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("uniqueid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = uniqueid;
                cmd.Parameters.Add(prm10);


                OracleParameter prm13 = new OracleParameter("mrvno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = mrvno;
                cmd.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pamtargettable", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = PAM_TARGET_TABLENAME;
                cmd.Parameters.Add(prm14);

                
                 OracleParameter prm15 = new OracleParameter("pmonthbill", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = monthdate;
                cmd.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pcomm_req", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = comm_req;
                cmd.Parameters.Add(prm16);

                

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

        public DataSet atmdelete(string companycode, string code, string name, string alias, string UserId,string id)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atm_Delete.atm_Delete_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("ata", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("atn", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                cmd.Parameters.Add(prm4);
                //OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm5.Direction = ParameterDirection.Input;
                //prm5.Value = UserId;
                //cmd.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("id", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = id;
                cmd.Parameters.Add(prm6);
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

        public DataSet atmexecute(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atm_Execute.atm_Execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (code != "" && code != null)
                {
                    prm2.Value = code;
                }
                else
                {
                    prm2.Value = code;
                }
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("atn", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (name != "" && name != null)
                {
                    prm3.Value = name;
                }
                else
                {
                    prm3.Value = name;
                }
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ata", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (alias != "" && alias != null)
                {
                    prm4.Value = alias;
                }
                else
                {
                    prm4.Value = "%%";
                }
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = UserId;
                cmd.Parameters.Add(prm5);
                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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

        public DataSet atmexecute1(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atm_Execute.atm_Execute_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (code != "" && code != null)
                {
                    prm2.Value = code;
                }
                else
                {
                    prm2.Value = code;
                }
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("atn", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (name != "" && name != null)
                {
                    prm3.Value = name;
                }
                else
                {
                    prm3.Value = name;
                }
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ata", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (alias != "" && alias != null)
                {
                    prm4.Value = alias;
                }
                else
                {
                    prm4.Value = "%%";
                }
                cmd.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = UserId;
                cmd.Parameters.Add(prm5);
                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;









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

        public DataSet atmfpnl()
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atmfpnl.atmfpnl_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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

        public DataSet chkatmcode(string companycode, string UserId, string code,string adname)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("atmcheck.atmcheck_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("atc", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("adname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adname;
                cmd.Parameters.Add(prm4);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_Accounts1", OracleType.Cursor);
                cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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



        public DataSet agtypecode(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autoagtypecode.autoagtypecode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length >2)
                {
                    prm2.Value = str.Substring (0,2);
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

        public DataSet chkslab(string compcode, string agtype)
        {
           
            
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("websp_agency_type_chkslab", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               
                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pagtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agtype;
                cmd.Parameters.Add(prm2);

               

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


    }
}

