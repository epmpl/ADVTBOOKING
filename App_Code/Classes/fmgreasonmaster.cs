using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OracleClient;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Roav_qbc
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for fmgreasonmaster
    /// </summary>
    public class fmgreasonmaster : connection
    {
        public fmgreasonmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string Save_main(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Cir_Dynamic_DML_variable_insert_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = code;

                objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = datefrm;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;





                objSqlCommand.ExecuteNonQuery();

                return "true";

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

        public DataSet cli_execute(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_execute_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


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

        public DataSet Modify_tal(string code, string unitcode, string tblname, string action, string wheresecond, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_update_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = code;

                objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = wheresecond;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;



                objSqlCommand.ExecuteNonQuery();

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


        public string delete_tal(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_dml_variable_delete_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;


                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = date;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return "true";

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

        public DataSet gencodfmg(string compcod, string desc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Ad_Gen_Code_fmg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcod;

                objSqlCommand.Parameters.Add("@descp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descp"].Value = desc;

              

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



    }
}