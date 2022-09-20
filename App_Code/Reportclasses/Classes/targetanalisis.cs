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
using System.Data.SqlClient;
namespace NewAdbooking.Report.Classes
{

    /// <summary>
    /// Summary description for targetanalisis
    /// </summary>
    public class targetanalisis : connection
    {
        public targetanalisis()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet advpub(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubName", ref objSqlConnection);
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

        public DataSet edition(string pubcode, string centercode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("edition_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pubcode ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode "].Value = pubcode;
                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;
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

        public DataSet adname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RA_adbindcategory_r", ref objSqlConnection);
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

        public DataSet uombind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binduomfortarget", ref objSqlConnection);
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

        public DataSet getbussinessreport(string compcode, string pub_center, string branch, string publication, string edition, string agencycode, string client_code, string exec_code, string adtype, string uom, string agency_pay, string datefrom, string todate, string dateformat, string userid, string chkaccess, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_rep_bussiness_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppub_center", SqlDbType.VarChar);
                if (pub_center == "" || pub_center == "0")
                {
                    objSqlCommand.Parameters["@ppub_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppub_center"].Value = pub_center;
                }

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@ppublication", SqlDbType.VarChar);
                if (publication == "" || publication == "0")
                {
                    objSqlCommand.Parameters["@ppublication"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublication"].Value = publication;
                }
                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                if (edition == "" || edition == "0")
                {
                    objSqlCommand.Parameters["@pedition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pedition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@pagency_code", SqlDbType.VarChar);
                if (agencycode == "")
                {
                    objSqlCommand.Parameters["@pagency_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagency_code"].Value = agencycode;
                }

                objSqlCommand.Parameters.Add("@pclient_code", SqlDbType.VarChar);
                if (client_code == "")
                {
                    objSqlCommand.Parameters["@pclient_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pclient_code"].Value = client_code;
                }

                objSqlCommand.Parameters.Add("@pexecutive_code", SqlDbType.VarChar);
                if (exec_code == "")
                {
                    objSqlCommand.Parameters["@pexecutive_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pexecutive_code"].Value = exec_code;
                }

                objSqlCommand.Parameters.Add("@pad_typecode", SqlDbType.VarChar);
                if (adtype == "")
                {
                    objSqlCommand.Parameters["@pad_typecode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pad_typecode"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@pumo_code", SqlDbType.VarChar);
                if (uom == "")
                {
                    objSqlCommand.Parameters["@pumo_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pumo_code"].Value = uom;
                }

                objSqlCommand.Parameters.Add("@pagency_pay", SqlDbType.VarChar);
                if (agency_pay == "")
                {
                    objSqlCommand.Parameters["@pagency_pay"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagency_pay"].Value = agency_pay;
                }

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = datefrom.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datefrom = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = datefrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    datefrom = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pfrom_date"].Value = datefrom;

               

                objSqlCommand.Parameters.Add("@pto_date", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pto_date"].Value = todate;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pchk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchk_access"].Value = chkaccess;

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


        public DataSet getbussinessamtreport(string compcode, string pub_center, string branch, string publication, string edition, string agencycode, string client_code, string exec_code, string adtype, string uom, string agency_pay, string datefrom, string todate, string dateformat, string userid, string chkaccess, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_rep_bussiness_amt_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppub_center", SqlDbType.VarChar);
                if (pub_center == "" || pub_center == "0")
                {
                    objSqlCommand.Parameters["@ppub_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppub_center"].Value = pub_center;
                }

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@ppublication", SqlDbType.VarChar);
                if (publication == "" || publication == "0")
                {
                    objSqlCommand.Parameters["@ppublication"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublication"].Value = publication;
                }
                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                if (edition == "" || edition == "0")
                {
                    objSqlCommand.Parameters["@pedition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pedition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@pagency_code", SqlDbType.VarChar);
                if (agencycode == "")
                {
                    objSqlCommand.Parameters["@pagency_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagency_code"].Value = agencycode;
                }

                objSqlCommand.Parameters.Add("@pclient_code", SqlDbType.VarChar);
                if (client_code == "")
                {
                    objSqlCommand.Parameters["@pclient_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pclient_code"].Value = client_code;
                }

                objSqlCommand.Parameters.Add("@pexecutive_code", SqlDbType.VarChar);
                if (exec_code == "")
                {
                    objSqlCommand.Parameters["@pexecutive_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pexecutive_code"].Value = exec_code;
                }

                objSqlCommand.Parameters.Add("@pad_typecode", SqlDbType.VarChar);
                if (adtype == "")
                {
                    objSqlCommand.Parameters["@pad_typecode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pad_typecode"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@pumo_code", SqlDbType.VarChar);
                if (uom == "")
                {
                    objSqlCommand.Parameters["@pumo_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pumo_code"].Value = uom;
                }

                objSqlCommand.Parameters.Add("@pagency_pay", SqlDbType.VarChar);
                if (agency_pay == "")
                {
                    objSqlCommand.Parameters["@pagency_pay"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagency_pay"].Value = agency_pay;
                }

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = datefrom.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datefrom = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = datefrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    datefrom = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pfrom_date"].Value = datefrom;



                objSqlCommand.Parameters.Add("@pto_date", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pto_date"].Value = todate;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pchk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchk_access"].Value = chkaccess;

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

        public DataSet paymode(string compcode,string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("payfill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



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


        public DataSet getlastday(string frmdate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getlastday", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pfrmdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = frmdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = frmdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    frmdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pfrmdate"].Value = frmdate;
                              

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
