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
/// Summary description for cir_taluka_mast
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class taluka_mast : orclconnection
    {
        public taluka_mast()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet col_width(string tablename, string columname)
        {
            OracleConnection con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand orclcmd;
            try
            {
                con.Open();
                orclcmd = GetCommand("Table_Column_Detail.Table_Column_Detail_p", ref con);
                orclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tablename;
                orclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcolumn_name", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = columname;
                orclcmd.Parameters.Add(prm2);

                orclcmd.Parameters.Add("p_circul", OracleType.Cursor);
                orclcmd.Parameters["p_circul"].Direction = ParameterDirection.Output;

                da.SelectCommand = orclcmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public DataSet taluka_Code(string code, string date, string extra1, string extra2)
        {
           
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Cir_Genrate_Code.taluka_P", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                

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

                cmd.Parameters.Add("ptype_code", OracleType.Cursor);
                cmd.Parameters["ptype_code"].Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("ptal_code", OracleType.Cursor);
                //cmd.Parameters["ptal_code"].Direction = ParameterDirection.Output;


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


        public DataSet binddist(string code) /*, string dateformat, string extra1, string extra2)*/
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Bind_Dist1", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("P_accounts", OracleType.Cursor);
                cmd.Parameters["P_accounts"].Direction = ParameterDirection.Output;


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


        public DataSet Save_tal(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
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

                OracleParameter prm4 = new OracleParameter("pdelimiter", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "$~$";
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = datefrm;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra1;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra2;
                cmd.Parameters.Add(prm7);



                cmd.ExecuteNonQuery();
                return ds;

                //da.SelectCommand = cmd;
                //da.Fill(ds);
                //return "true";

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


        public DataSet execute_tal(string compcode, string distcodeexe, string talcodeexe, string talnameexe, string talaliasexe, string talonameexe)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("talukaexe.talukaexe_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("distcodeexe", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = distcodeexe;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("talcodeexe", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = talcodeexe;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("talnameexe", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = talnameexe;
                cmd.Parameters.Add(prm8);


                OracleParameter prm3 = new OracleParameter("talaliasexe", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = talaliasexe;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("talonameexe", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = talonameexe;
                cmd.Parameters.Add(prm4);


                

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


        public DataSet Modify_tal(string code, string unitcode, string tblname, string action, string wheresecond, string date, string extra1, string extra2)
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

        public DataSet delete_tal(string talcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("talukadel.talukadel_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("talcode", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = talcode;
                cmd.Parameters.Add(prm1);

                //OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                //prm6.Direction = ParameterDirection.Input;
                //prm6.Value = colname;
                //cmd.Parameters.Add(prm6);

                //OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = colvalue;
                //cmd.Parameters.Add(prm2);

                //OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                //prm8.Direction = ParameterDirection.Input;
                //prm8.Value = "$~$";
                //cmd.Parameters.Add(prm8);

                //OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = date;
                //cmd.Parameters.Add(prm3);


                //OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = extra1;
                //cmd.Parameters.Add(prm4);


                //OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                //prm5.Direction = ParameterDirection.Input;
                //prm5.Value = extra2;
                //cmd.Parameters.Add(prm5);


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


        public DataSet bind_all_taluka(string compcode, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Cir_Taluka_Bind.Cir_Taluka_Bind_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

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


        public DataSet bind_all_talukas_ds(string compcode, string compval, string unitcode, string unitval, string tablname, string col_name, string orderby, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("Cir_Dynamic_DML.variable_order", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcomp_val", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compval;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punit_code", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("punit_val", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = unitval;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tablname;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pcolname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = col_name;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("porder", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = orderby;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = date;
                cmd.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                cmd.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
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


        public DataSet duplicacy_chk(string compval, string userid, string dist, string t_code, string t_name, string t_alias, string t_othername)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {



                con.Open();
                cmd = GetCommand("savetaluka.savetaluka_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compval", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compval;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 20);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = userid;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("dist", OracleType.VarChar, 20);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dist;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("t_code", OracleType.VarChar, 20);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = t_code;
                cmd.Parameters.Add(prm8);

                OracleParameter prm7 = new OracleParameter("t_name", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = t_name;
                cmd.Parameters.Add(prm7);

                OracleParameter prm3 = new OracleParameter("t_alias", OracleType.VarChar, 20);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = t_alias;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("t_othername", OracleType.VarChar, 20);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = t_othername;
                cmd.Parameters.Add(prm4);

               


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


        public DataSet autocode(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("talukamastautocode.talukamastautocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str.Substring(0,2);
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
                objOracleConnection.Close();

            }
        }



        public DataSet modify5(string compval, string userid, string dist, string t_code, string t_name, string t_alias, string t_othername)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {



                con.Open();
                cmd = GetCommand("modifytaluka.modifytaluka_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compval", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compval;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 20);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = userid;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("dist", OracleType.VarChar, 20);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dist;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("t_code", OracleType.VarChar, 20);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = t_code;
                cmd.Parameters.Add(prm8);

                OracleParameter prm7 = new OracleParameter("t_name", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = t_name;
                cmd.Parameters.Add(prm7);

                OracleParameter prm3 = new OracleParameter("t_alias", OracleType.VarChar, 20);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = t_alias;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("t_othername", OracleType.VarChar, 20);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = t_othername;
                cmd.Parameters.Add(prm4);

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
                con.Close();

            }
        }

        public DataSet duplicacy_chktalucode(string compval, string userid, string dist, string t_code, string t_name)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("chktalukacode", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compval", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compval;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 20);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = userid;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("dist", OracleType.VarChar, 20);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dist;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("t_code", OracleType.VarChar, 20);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = t_code;
                cmd.Parameters.Add(prm8);

                OracleParameter prm7 = new OracleParameter("t_name", OracleType.VarChar, 20);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = t_name;
                cmd.Parameters.Add(prm7);

                cmd.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

              
                objorclDataAdapter.SelectCommand = cmd;
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

        //=================================================================//

        public DataSet talunamechk(string str)//, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("chkbranchname", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT2", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = cmd;
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
