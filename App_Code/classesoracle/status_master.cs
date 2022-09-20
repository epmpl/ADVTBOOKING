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
/// Summary description for status_master
/// </summary>
    public class status_master : orclconnection
{
	public status_master()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet chkcode(string statuscode, string compcode, string statusname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("check_status_code.check_status_code_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("statuscode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = statuscode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("statusname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = statusname;
                objOraclecommand.Parameters.Add(prm3);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

               


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
        public DataSet executequery(string statuscode, string statusname, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execute_status_master.execute_status_master_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("statuscode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = statuscode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("statusname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = statusname;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



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

        public DataSet autocode(string str,string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            con = GetConnection();
           
            try
            {
                con.Open();
                cmd = GetCommand("status_autocode.status_autocode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                cmd.Parameters.Add(prm2);
                OracleParameter prm6 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (str.Length >2)
                {
                    prm6.Value = str.Substring(0, 2);
                }
                else
                {
                    prm6.Value = str;
                }
                cmd.Parameters.Add(prm6);

                OracleParameter prm3 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                cmd.Parameters.Add(prm3);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
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

        public DataSet insert_status_master(string statuscode, string statusname, string statusalias, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insert_status_master.insert_status_master_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

               

              

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("statuscode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = statuscode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("statusname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = statusname;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("statusalias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statusalias;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);



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

        public DataSet update_status_master(string statuscode, string statusname, string statusalias, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("update_status_master.update_status_master_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

               
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("statuscode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = statuscode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("statusname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = statusname;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("statusalias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statusalias;
                objOraclecommand.Parameters.Add(prm4);

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
        public DataSet delete_status_master(string statuscode, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("delete_status_master.delete_status_master_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("statuscode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = statuscode;
                cmd.Parameters.Add(prm2);

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

