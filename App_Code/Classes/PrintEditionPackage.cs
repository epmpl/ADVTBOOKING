using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PrintEditionPackage
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class PrintEditionPackage : connection
    {
        public PrintEditionPackage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adtypbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advtypbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet selpackageForPrintEdition(string compcode, string pack_code)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("select_addType_with_plus", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@adtype", SqlDbType.VarChar);
                cmd.Parameters["@adtype"].Value = pack_code;

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

        public DataSet selectEditionComboCode(string pack_des, string combin)
        {

            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("select_edition_combin_code", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@packdes", SqlDbType.VarChar);
                cmd.Parameters["@packdes"].Value = pack_des;

                cmd.Parameters.Add("@combin_code", SqlDbType.VarChar);
                cmd.Parameters["@combin_code"].Value = combin;

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

        public DataSet executePrintEditionComboCode(string comp_code, string pack_des, string combin)
        {

            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("execute_packbill", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@prctype", SqlDbType.VarChar);
                //cmd.Parameters["@prctype"].Value = "MOD_SELECT";

                cmd.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                cmd.Parameters["@pcompcode"].Value = comp_code;

                cmd.Parameters.Add("@padtype", SqlDbType.VarChar);
                cmd.Parameters["@padtype"].Value = pack_des;

                cmd.Parameters.Add("@ppackagecode", SqlDbType.VarChar);
                cmd.Parameters["@ppackagecode"].Value = combin;

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

        public DataSet insertEditionComboCode(string pack_name, string flag, string pack_des, string combin, string adtype, string comp_code)
        {

            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("SP_combinPrintEdition", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@prctype", SqlDbType.VarChar);
                cmd.Parameters["@prctype"].Value = "MOD_INSERT";

                cmd.Parameters.Add("@pack_name", SqlDbType.VarChar);
                cmd.Parameters["@pack_name"].Value = pack_name;

                cmd.Parameters.Add("@flag", SqlDbType.VarChar);
                cmd.Parameters["@flag"].Value = flag;

                cmd.Parameters.Add("@combin_code", SqlDbType.VarChar);
                cmd.Parameters["@combin_code"].Value = pack_des;

                cmd.Parameters.Add("@package_name", SqlDbType.VarChar);
                cmd.Parameters["@package_name"].Value = combin;

                cmd.Parameters.Add("@adtye", SqlDbType.VarChar);
                cmd.Parameters["@adtye"].Value = adtype;

                cmd.Parameters.Add("@comp_code", SqlDbType.VarChar);
                cmd.Parameters["@comp_code"].Value = comp_code;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
                //CloseConnection(ref con);
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

        public DataSet updateEditionComboCode(string flag, string id)
        {

            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("SP_combinPrintEdition", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@prctype", SqlDbType.VarChar);
                cmd.Parameters["@prctype"].Value = "MOD_UPDATE";

                cmd.Parameters.Add("@pack_name", SqlDbType.VarChar);
                cmd.Parameters["@pack_name"].Value = flag;

                cmd.Parameters.Add("@flag", SqlDbType.VarChar);
                cmd.Parameters["@flag"].Value = id;

                //cmd.Parameters.Add("@combin_code", SqlDbType.VarChar);
                //cmd.Parameters["@combin_code"].Value = id;

                //cmd.Parameters.Add("@package_name", SqlDbType.VarChar);
                //cmd.Parameters["@package_name"].Value = combin;

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

        public DataSet selectPrintEditionComboCode(string comp_code)
        {

            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("SP_combinPrintEdition", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@prctype", SqlDbType.VarChar);
                cmd.Parameters["@prctype"].Value = "MOD_SELECT";

                cmd.Parameters.Add("@pack_name", SqlDbType.VarChar);
                cmd.Parameters["@pack_name"].Value = comp_code;

                //cmd.Parameters.Add("@flag", SqlDbType.VarChar);
                //cmd.Parameters["@flag"].Value = combin;

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
