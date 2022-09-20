using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for userformwiserights
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class userformwiserights : connection
    {
        public userformwiserights()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet binduserid(string logincode, string dateformat, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_login_bind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();


                objSqlCommand.Parameters.Add("@plogin_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plogin_code"].Value = logincode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet bindcompname(string usercode, string dateformat, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_change_company_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@puser_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puser_code"].Value = usercode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }


        }
        //public DataSet bindunit()
        //{
        //    OracleConnection con;
        //    OracleCommand cmd;
        //    con = GetConnection();
        //    DataSet ds = new DataSet();
        //    OracleDataAdapter da = new OracleDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        cmd = GetCommand("websp_pubcenter.websp_pubcenter_p", ref con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("p_accounts", OracleType.Cursor);
        //        cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //        cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
        //        cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }

        //}
        //public DataSet bindmodule(string modulecode, string dateformat, string extra1, string extra2)
        //{
        //    OracleConnection con;
        //    OracleCommand cmd;
        //    con = GetConnection();
        //    DataSet ds = new DataSet();
        //    OracleDataAdapter da = new OracleDataAdapter();
        //    try
        //    {
        //        con.Open();
        //        cmd = GetCommand("user_privileges.module_bind_p", ref con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("pmodule_code", OracleType.VarChar, 1000);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = modulecode;
        //        cmd.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = dateformat;
        //        cmd.Parameters.Add(prm2);

        //        OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = extra1;
        //        cmd.Parameters.Add(prm3);

        //        OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = extra2;
        //        cmd.Parameters.Add(prm4);

        //        cmd.Parameters.Add("p_accounts", OracleType.Cursor);
        //        cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }
        //}
        //public DataSet reportdata(string compcode, string unitcode, string usercode, string modulecode, string dateformat, string extra1, string extra2)
        //{
        //    OracleConnection con;
        //    OracleCommand cmd;
        //    con = GetConnection();
        //    DataSet ds = new DataSet();
        //    OracleDataAdapter da = new OracleDataAdapter();
        //    try
        //    {
        //        con.Open();
        //        cmd = GetCommand("cir_rep_user_form_rights.cir_rep_user_form_rights_p", ref con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 1000);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        cmd.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("punit_code", OracleType.VarChar, 1000);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = unitcode;
        //        cmd.Parameters.Add(prm2);

        //        OracleParameter prm3 = new OracleParameter("puser_code", OracleType.VarChar, 1000);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = usercode;
        //        cmd.Parameters.Add(prm3);

        //        OracleParameter prm4 = new OracleParameter("pmodule_code", OracleType.VarChar, 1000);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = modulecode;
        //        cmd.Parameters.Add(prm4);

        //        OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
        //        prm5.Direction = ParameterDirection.Input;
        //        prm5.Value = dateformat;
        //        cmd.Parameters.Add(prm5);

        //        OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
        //        prm6.Direction = ParameterDirection.Input;
        //        prm6.Value = extra1;
        //        cmd.Parameters.Add(prm6);

        //        OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = extra2;
        //        cmd.Parameters.Add(prm7);

        //        cmd.Parameters.Add("p_accounts", OracleType.Cursor);
        //        cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //        cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
        //        cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }

        //}


        public DataSet bindunit()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }


        public DataSet bindmodule(string modulecode, string dateformat, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("user_privileges_module_bind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@pmodule_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmodule_code"].Value = modulecode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        public DataSet reportdata(string compcode, string unitcode, string usercode, string modulecode, string dateformat, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_rep_user_form_rights", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit_code"].Value = unitcode;

                objSqlCommand.Parameters.Add("@puser_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puser_code"].Value = usercode;

                objSqlCommand.Parameters.Add("@pmodule_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmodule_code"].Value = modulecode;


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }
    }
}