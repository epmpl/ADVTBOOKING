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
namespace NewAdbooking.Report.Classes
{
    /// <summary>
    /// Summary description for RO_Agency_Wise
    /// </summary>
    public class RO_Agency_Wise : connection
    {
        public RO_Agency_Wise()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindpaymode(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("an_payment", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

               
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
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
        public DataSet getQBC(string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
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

        public DataSet ro_report(string compcode, string dateformat, string userid, string chk_access, string from_date, string to_date, string print_cent, string agency, string branch, string district, string taluka, string ro_doc, string pay_mode, string executive, string retainer, string det_sum, string age_exeret, string type, string ad_type, string adcat, string dtbased)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Ro_Report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pad_type", SqlDbType.VarChar);
                if (ad_type == "0" || ad_type=="")
                    objSqlCommand.Parameters["@pad_type"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@pad_type"].Value = ad_type;

                objSqlCommand.Parameters.Add("@pad_cat", SqlDbType.VarChar);
                if (adcat == "0" || adcat=="")
                    objSqlCommand.Parameters["@pad_cat"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@pad_cat"].Value = adcat;

                objSqlCommand.Parameters.Add("@ptype", SqlDbType.VarChar);
                if (type == "0" || type == "")
                    objSqlCommand.Parameters["@ptype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ptype"].Value = type;



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_access;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfromdate"].Value = from_date;

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateto"].Value = to_date;

                objSqlCommand.Parameters.Add("@pprint_cent", SqlDbType.VarChar);
                if (print_cent == "0" || print_cent=="")
                    objSqlCommand.Parameters["@pprint_cent"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@pprint_cent"].Value = print_cent;

            objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
            if (agency == "0" || agency == "")
                objSqlCommand.Parameters["@pagency"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@pagency"].Value = agency;

            objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
            if (branch == "0" || branch == "Select Branch" || branch=="")
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pbranch"].Value = branch;


                objSqlCommand.Parameters.Add("@pdistrict", SqlDbType.VarChar);
                if (district == "0" || district == "Select District" || district=="")
                    objSqlCommand.Parameters["@pdistrict"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pdistrict"].Value = district;

                objSqlCommand.Parameters.Add("@ptaluka", SqlDbType.VarChar);
                if (taluka == "0" || taluka == "")
                    objSqlCommand.Parameters["@ptaluka"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ptaluka"].Value = taluka;

                objSqlCommand.Parameters.Add("@pro_doc_status", SqlDbType.VarChar);
                if (ro_doc == "0" || ro_doc == "")
                    objSqlCommand.Parameters["@pro_doc_status"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pro_doc_status"].Value = ro_doc;

                objSqlCommand.Parameters.Add("@ppay_mode", SqlDbType.VarChar);
                if (pay_mode == "0" || pay_mode=="")
                    objSqlCommand.Parameters["@ppay_mode"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ppay_mode"].Value = pay_mode;
               
                objSqlCommand.Parameters.Add("@pexecutive", SqlDbType.VarChar);
                if (executive == "0" || executive == "")
                    objSqlCommand.Parameters["@pexecutive"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pexecutive"].Value = executive;

                objSqlCommand.Parameters.Add("@pretainer", SqlDbType.VarChar);
                if (retainer == "0" || retainer == "")
                    objSqlCommand.Parameters["@pretainer"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pretainer"].Value = retainer;
                ///////////////////////////////////////////
                objSqlCommand.Parameters.Add("@det_summry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@det_summry"].Value = det_sum;

                objSqlCommand.Parameters.Add("@age_exeret", SqlDbType.VarChar);
                objSqlCommand.Parameters["@age_exeret"].Value = age_exeret;

                objSqlCommand.Parameters.Add("@P_datebased", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_datebased"].Value = dtbased;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
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
        public DataSet run_offline(string agency, string from_date, string to_date, string compcode, string status, string dateformat, string user_id, string chk_access)
        {
SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("offline_report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency == "0" || agency == "")
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@agname"].Value = agency;

            objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
            if (from_date == "")
                objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@fromdate"].Value = from_date;

            objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
            if (to_date == "")
                objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@dateto"].Value = to_date;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            if (compcode == "")
                objSqlCommand.Parameters["@compcode"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@compcode"].Value = compcode;


            objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
            if (status == "" || status == "0")
                objSqlCommand.Parameters["@status"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@status"].Value = status;

            objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@dateformat"].Value = dateformat;

            objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@puserid"].Value = user_id;

            objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
            objSqlCommand.Parameters["@chk_access"].Value = chk_access;

           


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
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
