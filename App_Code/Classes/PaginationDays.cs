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
/// Summary description for PaginationDays
/// </summary>

namespace NewAdbooking.Classes
{
    public class PaginationDays : connection
    {
        public PaginationDays()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet clsCheckExistingRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string daycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_CheckRecord", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno"].Value = pageno;

                objSqlCommand.Parameters.Add("@daycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@daycode"].Value = daycode;


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

        //save new record
        public DataSet clsSaveDaysRecord(string compcode, string userid, string ddlpubcode, string ddlcentercode, string ddleditioncode, string ddlsuppcode, string ddlpgno, string ddldaycode, string txtvalidfromdate, string txtvalidtodate, string dateformat)  //,string ddlpubname,string ddlcentername,string ddleditionname,string ddlsuppname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_SavenewPaginationdays", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ddlpubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpubcode"].Value = ddlpubcode;

                objSqlCommand.Parameters.Add("@ddlcentercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlcentercode"].Value = ddlcentercode;

                objSqlCommand.Parameters.Add("@ddleditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddleditioncode"].Value = ddleditioncode;

                objSqlCommand.Parameters.Add("@ddlsuppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlsuppcode"].Value = ddlsuppcode;

                objSqlCommand.Parameters.Add("@ddlpgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgno"].Value = ddlpgno;

                objSqlCommand.Parameters.Add("@ddldaycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddldaycode"].Value = ddldaycode;

                objSqlCommand.Parameters.Add("@txtvalidfromdate", SqlDbType.VarChar);
                if (txtvalidfromdate == "" || txtvalidfromdate == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = txtvalidfromdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@txtvalidfromdate"].Value = txtvalidfromdate;
                }

                objSqlCommand.Parameters.Add("@txtvalidtodate", SqlDbType.VarChar);
                if (txtvalidtodate == "" || txtvalidtodate == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidtodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidtodate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = txtvalidtodate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        txtvalidtodate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@txtvalidtodate"].Value = txtvalidtodate;
                }

                //objSqlCommand.Parameters.Add("@ddlpubname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ddlpubname"].Value = ddlpubname;

                //objSqlCommand.Parameters.Add("@ddlcentername", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ddlcentername"].Value = ddlcentername;

                //objSqlCommand.Parameters.Add("@ddleditionname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ddleditionname"].Value = ddleditionname;

                //objSqlCommand.Parameters.Add("@ddlsuppname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ddlsuppname"].Value = ddlsuppname;


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

        public DataSet clsUpdateDaysRecord(string compcode, string ddlpubcode, string ddlcentercode, string ddleditioncode, string ddlsuppcode, string ddlpgno, string ddldaycode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_Modifypagination_Master", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = ddlpubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = ddlcentercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = ddleditioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = ddlsuppcode;

                objSqlCommand.Parameters.Add("@txtno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtno"].Value = ddlpgno;

                objSqlCommand.Parameters.Add("@pubday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubday"].Value = ddldaycode;



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



        public DataSet clsExecuteDaysRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string ddldaycode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_ExecuteDaysRecord", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno"].Value = pageno;

                objSqlCommand.Parameters.Add("@ddldaycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddldaycode"].Value = ddldaycode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

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


        // Delete Page configuration's record
        public DataSet clsDeleteDaysRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string dday, string pgnumber) //, string rec_id)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_DeleteDaysRecord", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@dday", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dday"].Value = dday;

                objSqlCommand.Parameters.Add("@pgnumber", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgnumber"].Value = pgnumber;

                //objSqlCommand.Parameters.Add("@rec_id", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@rec_id"].Value = rec_id;


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

        public DataSet editioncodes(string compcode, string userid, string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_addeditions", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

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

        public DataSet clsCategory(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Category", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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

        public DataSet centercode(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_addcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = 1;

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

        public DataSet Pripubcode(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addpub_forbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = 1;

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

        public DataSet secpubcodes(string compcode, string userid, string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_addsecpub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

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