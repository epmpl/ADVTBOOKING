using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.Classes
{
    public class Ag_merging : connection
    {
        public Ag_merging()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindagency(string compcode, string userid, string agency, string agtype, string ag_main_code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adb_bindagencyformerge", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@ag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ag_main_code"].Value = ag_main_code;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = System.DBNull.Value;

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




        public string process_call(string compcode, string Agency_main_code, string Agency_sub_code, string from_agency_code, string to_agency_main_code, string to_agency_sub_code, string to_agency_code, string on_date, string dateformat, string remarks, string user, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_merge_agency_proc", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pfrom_agency_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfrom_agency_main_code"].Value = Agency_main_code;

                objSqlCommand.Parameters.Add("@pfrom_agency_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfrom_agency_sub_code"].Value = Agency_sub_code;

                objSqlCommand.Parameters.Add("@pfrom_agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfrom_agency_code"].Value = from_agency_code;

                objSqlCommand.Parameters.Add("@pto_agency_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pto_agency_main_code"].Value = to_agency_main_code;

                objSqlCommand.Parameters.Add("@pto_agency_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pto_agency_sub_code"].Value = to_agency_sub_code;

                objSqlCommand.Parameters.Add("@pto_agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pto_agency_code"].Value = to_agency_code;

                objSqlCommand.Parameters.Add("@pon_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pon_date"].Value = on_date;

                objSqlCommand.Parameters.Add("@premarks",SqlDbType.VarChar);
                objSqlCommand.Parameters["@premarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@puser",SqlDbType.VarChar);
                objSqlCommand.Parameters["@puser"].Value = user;

                objSqlCommand.Parameters.Add("@pdateformat",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value =pextra1;

                objSqlCommand.Parameters.Add("@pextra2",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value =pextra2;

                objSqlCommand.Parameters.Add("@pextra3",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value =pextra3;

                objSqlCommand.Parameters.Add("@pextra4",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value =pextra4;

                objSqlCommand.Parameters.Add("@pextra5",SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value =pextra5;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return "True";
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
