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
/// <summary>
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.classesoracle
{

    public class couponmaster : orclconnection
    {
       
		public DataSet getPubCenter()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_pubcenter.websp_pubcenter_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = compcode;
                //objOraclecommand.Parameters.Add(prm2);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public string couponsave(string code, string unitcode, string tblname, string action, string dateformat, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_insert_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcolname", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcolvalue", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                cmd.Parameters.Add(prm3);

                OracleParameter prm7 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = "$~$";
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                cmd.Parameters.Add(prm10);


                cmd.ExecuteNonQuery();

                // da.SelectCommand = cmd;
                //da.Fill(ds);
                return "true";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                CloseConnection(ref con);
            }

        }
        public DataSet get_coupon()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_gen_coupon", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet get_execute(string tblname, string colname, string colvalue, string delimeter, string dateformat, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_execute_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;

                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);
                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);

                OracleParameter prm12 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                cmd.Parameters.Add(prm12);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                cmd.Parameters.Add(prm10);

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
        public DataSet get_unit_name(string comp_code, string unit)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                string codes = "";

                codes = "select cir_get_pubcenter('" + comp_code + "', '" + unit + "','','','','') from dual";
                cmd.CommandText = codes;
                cmd.Connection = con;
                con.Open();
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
        public DataSet Modify_coup(string code, string unitcode, string tblname, string action, string wheresecond, string dateformat, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_update_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcolname", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("pcolvalue", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = unitcode;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wheresecond;
                cmd.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);


                OracleParameter prm12 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                cmd.Parameters.Add(prm12);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                cmd.Parameters.Add(prm10);

                //da.SelectCommand = cmd;
                //da.Fill(ds);
                cmd.ExecuteNonQuery();
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

        public DataSet Delete_coup(string code, string unitcode, string tblname, string action, string wheresecond, string dateformat)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_delete_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);



                OracleParameter prm5 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = unitcode;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wheresecond;
                cmd.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);



                OracleParameter prm10 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = dateformat;
                cmd.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = "";
                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "";
                cmd.Parameters.Add(prm12);

                //da.SelectCommand = cmd;
                //da.Fill(ds);
                cmd.ExecuteNonQuery();
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

        public DataSet duplicacy_chk(string compcol, string compval, string unitcol, string unitval, string tablename, string desc_col, string desc_val, string alias_col, string alias_val, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {



                con.Open();
                cmd = GetCommand("cir_check_duplicacy.cir_check_duplicacy_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_col", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcol;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pcomp_val", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compval;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("punit_col", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unitcol;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("punit_val", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "''";
                cmd.Parameters.Add(prm8);

                OracleParameter prm7 = new OracleParameter("ptbl_name", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = tablename;
                cmd.Parameters.Add(prm7);

                OracleParameter prm3 = new OracleParameter("pdesc_col", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = desc_col;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdesc_val", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = desc_val;
                cmd.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("palias_col", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = alias_col;
                cmd.Parameters.Add(prm12);

                OracleParameter prm11 = new OracleParameter("palias_val", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = alias_val;
                cmd.Parameters.Add(prm11);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = date;
                cmd.Parameters.Add(prm5);


                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                cmd.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                cmd.Parameters.Add(prm10);

                cmd.Parameters.Add("p_circul", OracleType.Cursor);
                cmd.Parameters["p_circul"].Direction = ParameterDirection.Output;


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
