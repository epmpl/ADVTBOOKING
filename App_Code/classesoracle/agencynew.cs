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
/// Summary description for agencynew
/// </summary>
/// n
namespace NewAdbooking.classesoracle
{
    public class agencynew:orclconnection
    {
        public agencynew()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindagency(string compcode, string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

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


        public string Save_main(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
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
                //  return ds;

                //da.SelectCommand = cmd;
                //da.Fill(ds);
                return "true";

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


        public DataSet cli_execute(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
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


        public DataSet Agency_get(string pcode, string subcode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            string ank = "";
            try
            {
                ank = "Select ad_get_fieldname('Comp_Code','" + pcode + "','code_subcode','" + subcode + "','Agency_Name','agency_mast','','') AS Agency_Name from dual";
                cmd.CommandText = ank;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);

                //ad_get_fieldname ('Comp_Code','HT001','code_subcode',
                //                   'TC0TCP0',
                //                   'Agency_Name',
                //                   'agency_mast',
                //                   '',
                //                   ''
                //                  ) AS agencyname
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

            return ds;
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


        public string delete_tal(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
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
                return "true";

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