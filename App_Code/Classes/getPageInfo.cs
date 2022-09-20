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
/// Summary description for getPageInfo
/// </summary>
namespace NewAdbooking.Classes
{
    public class getPageInfo : connection
    {
        public getPageInfo()
        {
        }
        //ShowAllPage : get number of issue pages
        public DataSet clsGetIssuePages(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode,string dateformat)
        {

            SqlConnection objSqlConnection;

            SqlCommand objSqlCommand;

            objSqlConnection = GetConnection();

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            DataSet objDataSet = new DataSet();

            try
            {

                objSqlConnection.Open();

                objSqlCommand = GetCommand("websp_getIssuePages", ref objSqlConnection);

                objSqlCommand.CommandType =CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);

                ////objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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

                CloseConnection(
                ref objSqlConnection);

            }

        }

        public DataSet clspageHeading(string pubdate, string pubcode, string centercode, string editioncode, string suppcode,string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pageHeading", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

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

        //ShowAllPage : Update Ad's Position and Page
        public DataSet clsUpdateAd(string pubdate, string pubcode, string centercode, string editioncode, string suppcode,string pageno,double xstcol,double ystrow,string iidnum,string pgid,string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_UpdateAd", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pubdate"].Value = pubdate;

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

                objSqlCommand.Parameters.Add("@xstcol", SqlDbType.VarChar);
                objSqlCommand.Parameters["@xstcol"].Value = xstcol;

                objSqlCommand.Parameters.Add("@ystrow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ystrow"].Value = ystrow;     

                objSqlCommand.Parameters.Add("@iidnum", SqlDbType.VarChar);
                objSqlCommand.Parameters["@iidnum"].Value = iidnum;

                objSqlCommand.Parameters.Add("@pgid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgid"].Value = pgid;                

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





        public DataSet clsPagination(string pubdate, string centercode, string pubcode, string suppcode, string editioncode, int pageno,string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {   
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Create_Dummy_Pagebestfit", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

                ////objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                ////objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@P_DATE", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@P_DATE"].Value = pubdate;

                objSqlCommand.Parameters.Add("@P_CNT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_CNT"].Value = centercode;

                objSqlCommand.Parameters.Add("@P_PPUB", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_PPUB"].Value = pubcode;

                objSqlCommand.Parameters.Add("@P_SECPUB", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_SECPUB"].Value = suppcode;

                objSqlCommand.Parameters.Add("@P_ED", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ED"].Value = editioncode;

                objSqlCommand.Parameters.Add("@P_PAGE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_PAGE"].Value = pageno;

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
        public void clsSubmitIssuePages(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode,string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            // DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_SubmitIssuePages", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy" && pubdate != "" && pubdate != null)
                {
                    string[] arr = pubdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pubdate = mm + "/" + dd + "/" + yy;

                }
                objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlCommand.ExecuteNonQuery();
                // objSqlDataAdapter.Fill(objDataSet);

                // return objDataSet;

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