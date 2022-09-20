using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;

/// <summary>
/// Summary description for Ad_Translation_charge
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class Ad_Translation_charge:orclconnection
    {
        public Ad_Translation_charge()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet adtypbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }


        public DataSet agtypecode(string str, string adcattype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autoagtypecode.autoagtypecode_p11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2);
                }
                else
                {
                    prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcattype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcattype;
                objOraclecommand.Parameters.Add(prm3);



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





        public DataSet checkdp(string compname, string compname1, string userid, string userid1, string tabname, string modename, string modename1, string alias, string alias1, string date, string extra1, string extra2)
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
                prm1.Value = compname;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pcomp_val", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compname1;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("punit_col", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = "''";
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("punit_val", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "''";
                cmd.Parameters.Add(prm8);

                OracleParameter prm11 = new OracleParameter("ptbl_name", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = tabname;
                cmd.Parameters.Add(prm11);


                OracleParameter prm61 = new OracleParameter("pdesc_col", OracleType.VarChar, 2000);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = modename;
                cmd.Parameters.Add(prm61);

                OracleParameter prm21 = new OracleParameter("pdesc_val", OracleType.VarChar, 2000);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = modename1;
                cmd.Parameters.Add(prm21);

                OracleParameter prm81 = new OracleParameter("palias_col", OracleType.VarChar, 2000);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = alias;
                cmd.Parameters.Add(prm81);


                OracleParameter prm31 = new OracleParameter("palias_val", OracleType.VarChar, 2000);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = alias1;
                cmd.Parameters.Add(prm31);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

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



        public string Save_ModeCode(string code, string unitcode, string tblname, string action, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();

            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Cir_Dynamic_DML.variable_insert_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcolname", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcolvalue", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                cmd.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm7 = new OracleParameter("pdelimiter", OracleType.VarChar, 1000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = "$~$";
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = date;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = "";
                cmd.Parameters.Add(prm9);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = "";
                cmd.Parameters.Add(prm5);
                cmd.ExecuteNonQuery();
                return "True";

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


        public DataSet execute_area(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
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
                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);


                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
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


        public DataSet delete_area(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
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

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);


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


        public string Modify_area(string code, string unitcode, string tblname, string action, string wheresecond, string date, string extra1, string extra2)
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

                OracleParameter prm9 = new OracleParameter("pcolvalue", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = unitcode;
                cmd.Parameters.Add(prm9);

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wheresecond;
                cmd.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

                cmd.ExecuteNonQuery();
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

        public DataSet execute_area1(string comcode, string AD_TYPE, string CHARGE_CODE, string CHARGE_NAME, string CHARGE_ALIAS, string CHARGE_TYPE, string CHARGE_ON)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("mode_execute", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("pcomcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pAD_TYPE", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = AD_TYPE;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("PCHARGE_CODE", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = CHARGE_CODE;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("PCHARGE_NAME", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = CHARGE_NAME;
                cmd.Parameters.Add(prm8);


                OracleParameter prm3 = new OracleParameter("PCHARGE_ALIAS", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = CHARGE_ALIAS;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("PCHARGES_TYPE", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = CHARGE_TYPE;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("PCHARGE_ON", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = CHARGE_ON;
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



    }
}