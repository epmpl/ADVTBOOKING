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
/// Summary description for emailprocessmaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class emailprocessmaster : connection
    {
        public emailprocessmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindagencyname22(string compcode, string client, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GetAgency_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;


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
        public string Save_main1(string COMP_CODE, string AG_MAIN_CODE, string AG_SUB_CODE, string SEC_RATE_TYPE, string SEC_RATE, string SEC_LIMIT_AMT, string CREATED_BY, string CREATED_DATE, string flag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("agency_secinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@COMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMP_CODE"].Value = COMP_CODE;

                objSqlCommand.Parameters.Add("@AG_MAIN_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@AG_MAIN_CODE"].Value = AG_MAIN_CODE;

                objSqlCommand.Parameters.Add("@AG_SUB_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@AG_SUB_CODE"].Value = AG_SUB_CODE;

                objSqlCommand.Parameters.Add("@SEC_RATE_TYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SEC_RATE_TYPE"].Value = SEC_RATE_TYPE;

                objSqlCommand.Parameters.Add("@SEC_RATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SEC_RATE"].Value = SEC_RATE;

                objSqlCommand.Parameters.Add("@SEC_LIMIT_AMT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SEC_LIMIT_AMT"].Value = SEC_LIMIT_AMT;

                objSqlCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CREATED_BY"].Value = CREATED_BY;

                objSqlCommand.Parameters.Add("@CREATED_DATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CREATED_DATE"].Value = CREATED_DATE;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;




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




    }
}