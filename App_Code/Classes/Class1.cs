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
/// Summary description for Class1
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class Class1 : connection
    {
        public Class1()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet griddisplay(string fromdate, string todate, string cid, string ascdesc, string dateformat, string agencyname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("report_booking_confirm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "0" || fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (todate == "0" || todate == "")
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@todate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = "0";


                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = "1";

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = "0";

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = cid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@filter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filter"].Value = "0";

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agencyname == "0" || agencyname == "")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = agencyname;
                }


                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindGridUser(string fromDate, string toDate, string userid, string cid, string ascdesc, string dateformat, string agencyname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("report_booking_confirm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromDate == "0" || fromDate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromDate;
                }

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (toDate == "0" || toDate == "")
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@todate"].Value = toDate;
                }

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = "0";


                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = "2";

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = cid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@filter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filter"].Value = "0";

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agencyname == "0" || agencyname == "")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = agencyname;
                }


                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindGrid(string fromDate, string toDate, string status, string cid, string ascdesc, string dateformat, string filter, string agencyname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("report_booking_confirm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromDate == "0" || fromDate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromDate;
                }

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (toDate == "0" || toDate == "")
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@todate"].Value = toDate;
                }

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@status1"].Value = status;
               

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = "0";

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = "0";

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = cid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@filter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@filter"].Value = filter;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agencyname == "0" || agencyname == "")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = agencyname;
                }


                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindSapAdReport(string fromdate, string todate, string edition, string agencycode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindSapAdReport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "0" || fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (todate == "0" || todate=="")
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@todate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@sedition", SqlDbType.VarChar);
                if (edition == "0" || edition=="")
                {
                    objSqlCommand.Parameters["@sedition"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@sedition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                if (agencycode == "0" || agencycode == "")
                {
                    objSqlCommand.Parameters["@agencycode"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@agencycode"].Value = agencycode;
                }
               
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindSapEdition(string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindSapReportEdition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindgrid(string publication, string publicationcenter, string edition,string fromdate,string dateto, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_ciobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication=="0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;

                }
                else
                {
                objSqlCommand.Parameters["@pub_name"].Value = publication;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (publicationcenter=="0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                objSqlCommand.Parameters["@pub_cent"].Value = publicationcenter;
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition=="0")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;

                }
                else
                {
                objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet billing(string cioid,string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_invoice", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;






                objSqlCommand.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobooking"].Value = cioid;             

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
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
       
        public DataSet getClientName(string compcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
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
                objSqlCommand = GetCommand("RA_adbindcategory", ref objSqlConnection);
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


        public DataSet advtype(string adtype, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RA_bindadcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advtype"].Value = adtype;

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

        public DataSet page(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpremiumforrate", ref objSqlConnection);
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
        public DataSet position(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getPagePosition", ref objSqlConnection);
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

        public DataSet pub_cent(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("publication_proc", ref objSqlConnection);
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

        public DataSet spfun(string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


               
               
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {

                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {

                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
               
                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

               

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid != "")
                {
                    objsqlcom.Parameters["@descid"].Value = descid;
                }
                else
                {
                    objsqlcom.Parameters["@descid"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc != "")
                {
                    objsqlcom.Parameters["@ascdesc"].Value = ascdesc;
                }
                else
                {
                    objsqlcom.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (clientname != "")
                {
                    objsqlcom.Parameters["@clientname"].Value = clientname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }
                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);




                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }
        //-------------------------gaurav------------------------------------

        public DataSet spAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (clientname != "")
                {
                    objsqlcom.Parameters["@clientname"].Value = clientname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid != "")
                {
                    objsqlcom.Parameters["@descid"].Value = descid;
                }
                else
                {
                    objsqlcom.Parameters["@descid"].Value = System.DBNull.Value;
                }
               
                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc != "")
                {
                    objsqlcom.Parameters["@ascdesc"].Value = ascdesc;
                }
                else
                {
                    objsqlcom.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }
               // objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


             
                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }

        //-----------------Excel------------------------------------

        public SqlDataReader spfunexcel(string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }
                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------               
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }
        public DataSet adagencycli(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindclientforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;


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

        public DataSet agency(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;


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
        public SqlDataReader spAgencyexcel(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }




        public DataSet spStatus(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }


                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }


                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "0")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }




        }
        public SqlDataReader spStatusexcel(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }



                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "0")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }



        public SqlDataReader spclientexcel(string clientname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (clientname != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = clientname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }


        public DataSet spclient(string cliname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc,string agname, string status, string hold)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (cliname != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = cliname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid != "")
                {
                    objsqlcom.Parameters["@descid"].Value = descid;
                }
                else
                {
                    objsqlcom.Parameters["@descid"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc != "")
                {
                    objsqlcom.Parameters["@ascdesc"].Value = ascdesc;
                }
                else
                {
                    objsqlcom.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname != "")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }



        public DataSet spDeviation(string cliname, string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (cliname != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = cliname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }


                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);


                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }


                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "0")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }




        }





        public SqlDataReader spDeviationexcel(string cliname, string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (cliname != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = cliname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }


                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcategory != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                //-----------------------------------------------------------------------------------------------------------
                if (edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }
                //---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }


        public DataSet spPagepremium(string page, string position, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string hold, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@page", SqlDbType.VarChar);

                if (page != "0")
                {
                    objsqlcom.Parameters["@page"].Value = page;
                }
                else
                {
                    objsqlcom.Parameters["@page"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@position", SqlDbType.VarChar);

                if (position != "0")
                {
                    objsqlcom.Parameters["@position"].Value = position;
                }
                else
                {
                    objsqlcom.Parameters["@position"].Value = System.DBNull.Value;
                }

                //if (agname != "0")
                //{
                //    objsqlcom.Parameters["@agname"].Value = agname;
                //}


                //else
                //{
                //    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                //}
                //objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                //if (adtype != "0")
                //{
                //    objsqlcom.Parameters["@adtype"].Value = adtype;
                //}

                //else
                //{
                //    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                //}
                //objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                //if (adcategory != "")
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }


                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                //objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                //if (status != "0")
                //{
                //    objsqlcom.Parameters["@status"].Value = status;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                //}
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "0")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;



                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }




        }
        public SqlDataReader spPagepremiumexcel(string page, string position, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string hold)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@page", SqlDbType.VarChar);

                if (page != "0")
                {
                    objsqlcom.Parameters["@page"].Value = page;
                }
                else
                {
                    objsqlcom.Parameters["@page"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@position", SqlDbType.VarChar);

                if (position != "0")
                {
                    objsqlcom.Parameters["@position"].Value = position;
                }
                else
                {
                    objsqlcom.Parameters["@position"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                //if (clientname != "0")
                //{
                //    objsqlcom.Parameters["@clientname"].Value = clientname;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                //}
                //objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                //if (agname != "0")
                //{
                //    objsqlcom.Parameters["@agname"].Value = agname;
                //}


                //else
                //{
                //    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                //}
                //objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                //if (adtype != "0")
                //{
                //    objsqlcom.Parameters["@adtype"].Value = adtype;
                //}

                //else
                //{
                //    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                //}
                //objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                //if (adcategory != "")
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold != "0")
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                }



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }
        public DataSet bindregion(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_region", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@regioncode"].Value = regioncode;




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

        public DataSet bindlanguage(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("PubAddLanguage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@regioncode"].Value = regioncode;




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
        public DataSet spregionreport(string fromdate, string dateto, string compcode, string region, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
            // spregionexcel

        }


        //public SqlDataReader spregionexcel(string fromdate, string dateto, string compcode, string region, string dateformat)
        //{
        //    SqlConnection objsqlcon = new SqlConnection();
        //    SqlCommand objsqlcom;
        //    objsqlcon = GetConnection();
        //    SqlDataAdapter objsqldap = new SqlDataAdapter();
        //    DataSet objdataset = new DataSet();

        //    try
        //    {

        //        objsqlcon.Open();
        //        objsqlcom = GetCommand("MisReport", ref objsqlcon);
        //        objsqlcom.CommandType = CommandType.StoredProcedure;

        //        objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
        //        if (fromdate != "")
        //        {
        //            objsqlcom.Parameters["@fromdate"].Value = fromdate;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
        //        }
        //        objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
        //        if (dateto != "")
        //        {
        //            objsqlcom.Parameters["@dateto"].Value = dateto;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
        //        }
        //        objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
        //        if (region != "0")
        //        {
        //            objsqlcom.Parameters["@region"].Value = region;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
        //        }




        //        objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@compcode"].Value = compcode;






        //        objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@dateformat"].Value = dateformat;

        //        objsqldap.SelectCommand = objsqlcom;
        //        SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

        //        return objdatareadre;
        //        //objsqldap.Fill(objdataset);

        //        //return objdataset;



        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        //CloseConnection(ref objsqlcon);
        //    }


        //}


        public DataSet spregionpdf(string fromdate, string dateto, string compcode, string region, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }


        public DataSet sppublication(string fromdate, string dateto, string pubname, string compcode, string dateformat, string published, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;



                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;
                objsqlcom.Parameters.Add("@published", SqlDbType.VarChar);
                if (published != "0")
                {
                    objsqlcom.Parameters["@published"].Value = published;
                }
                else
                {
                    objsqlcom.Parameters["@published"].Value = System.DBNull.Value;
                }

                //  objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }




        }
        public SqlDataReader sppublicationexcel(string fromdate, string dateto, string pubname, string compcode, string dateformat,string published)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@published", SqlDbType.VarChar);
                if (published != "0")
                {
                    objsqlcom.Parameters["@published"].Value = published;
                }
                else
                {
                    objsqlcom.Parameters["@published"].Value = System.DBNull.Value;
                }


                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }

        }





        public DataSet sppublicationpdf(string fromdate, string dateto, string pubname, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                //objsqlcon.Open();
                //objsqlcom = GetCommand("report", ref objsqlcon);
                //objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }


        public DataSet spupcountry(string fromdate, string dateto, string pubname, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;



                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                //  objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);




                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }




        }

        public SqlDataReader speupcountryxcel(string fromdate, string dateto, string pubname, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }

        }




        public SqlDataReader spupcountryexcel(string fromdate, string dateto, string pubname, string compcode,  string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }
        }
   

   public SqlDataReader spregionexcel(string fromdate, string dateto, string compcode, string region, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

// Neha
// for publication

public DataSet publication(string compcode)
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

// for region
 public DataSet region(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_region", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@regioncode"].Value = region;


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

// for agency

public DataSet bindagency(string compcode, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforbookingreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

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

// for client

public DataSet getClientName(string compcode, string client)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlDataAdapter = new SqlDataAdapter();
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

// for product

public DataSet bindProduct(string compcode, string product, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getProduct", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;
                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindProductcategory(string compcode)//, string product, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_Product1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                //objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@product"].Value = product;
                //objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@value"].Value = value;
                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet bindProductcategory(string compcode, string product, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_Product", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;
                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;
                objSqlDataAdapter = new SqlDataAdapter();
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

// for brand

public DataSet bindBrand(string compcode, string procat)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getBrandreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@procat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@procat"].Value = procat;
                objSqlDataAdapter = new SqlDataAdapter();
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

// for subcategory

public DataSet prosubcat(string compcode, string prosubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("drpsubproductselect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prosubcode"].Value = prosubcode;


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

// for subsubcategory

 public DataSet prosubsubcat( string procatcode, string prosubcatcode,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_PRODUCT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pro_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pro_cat_code"].Value = procatcode;

                objSqlCommand.Parameters.Add("@pro_subcat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pro_subcat_code"].Value = prosubcatcode;


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

// for varient
 public DataSet proforvarient(string compcode, string brand)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_BRANDVARIENT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                //objSqlCommand.Parameters.Add("@pro_subcat_code", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pro_subcat_code"].Value = prosubcatcode;


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
        public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
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

                objSqlDataAdapter = new SqlDataAdapter();
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



        // for onscreen(fromdt, dateto, agency, client, publication, product, subcat, subsubcat, brand, varient, region, Session["compcode"].ToString(), Session["dateformat"].ToString());

        public DataSet onscreenreportforclient(string fromdate, string dateto, string agency, string client, string publication, string product, string subcat, string subsubcat, string brand, string varient, string region, string compcode, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();


            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("clientreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@subcat", SqlDbType.VarChar);
                if (subcat != "")
                {
                    objsqlcom.Parameters["@subcat"].Value = subcat;
                }

                else
                {
                    objsqlcom.Parameters["@subcat"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@subsubcat", SqlDbType.VarChar);
                if (subsubcat != "")
                {
                    objsqlcom.Parameters["@subsubcat"].Value = subsubcat;
                }
                else
                {
                    objsqlcom.Parameters["@subsubcat"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@brand", SqlDbType.VarChar);
                if (brand != "")
                {
                    objsqlcom.Parameters["@brand"].Value = brand;
                }
                else
                {
                    objsqlcom.Parameters["@brand"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@varient", SqlDbType.VarChar);
                if (varient != "")
                {
                    objsqlcom.Parameters["@varient"].Value = varient;
                }
                else
                {
                    objsqlcom.Parameters["@varient"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }


        // for excel
        public SqlDataReader excelfileforclient(string fromdate, string dateto, string agency, string client, string publication, string product, string subcat, string subsubcat, string brand, string varient, string region, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("clientreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@subcat", SqlDbType.VarChar);
                if (subcat != "")
                {
                    objsqlcom.Parameters["@subcat"].Value = subcat;
                }

                else
                {
                    objsqlcom.Parameters["@subcat"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@subsubcat", SqlDbType.VarChar);
                if (subsubcat != "")
                {
                    objsqlcom.Parameters["@subsubcat"].Value = subsubcat;
                }
                else
                {
                    objsqlcom.Parameters["@subsubcat"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@brand", SqlDbType.VarChar);
                if (brand != "")
                {
                    objsqlcom.Parameters["@brand"].Value = brand;
                }
                else
                {
                    objsqlcom.Parameters["@brand"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@varient", SqlDbType.VarChar);
                if (varient != "")
                {
                    objsqlcom.Parameters["@varient"].Value = varient;
                }
                else
                {
                    objsqlcom.Parameters["@varient"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }
// for pdf

        //public DataSet pdffile(string agency, string client, string fromdate, string dateto, string compcode, string publication, string dateformat, string region, string subcat, string subsubcat, string product, string brand, string varient)
        //{
        //    SqlConnection objsqlcon = new SqlConnection();
        //    SqlCommand objsqlcom;
        //    objsqlcon = GetConnection();
        //    SqlDataAdapter objsqldap = new SqlDataAdapter();
        //    DataSet objdataset = new DataSet();

        //    try
        //    {

        //        objsqlcon.Open();
        //        objsqlcom = GetCommand("ScheduleReport", ref objsqlcon);
        //        objsqlcom.CommandType = CommandType.StoredProcedure;

        //        objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
        //        if (agency != "0")
        //        {
        //            objsqlcom.Parameters["@agname"].Value = agency;
        //        }

        //        else
        //        {
        //            objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
        //        }
        //        objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

        //        if (client != "")
        //        {
        //            objsqlcom.Parameters["@clientname"].Value = client;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
        //        if (fromdate != "")
        //        {
        //            objsqlcom.Parameters["@fromdate"].Value = fromdate;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
        //        }
        //        objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
        //        if (dateto != "")
        //        {
        //            objsqlcom.Parameters["@dateto"].Value = dateto;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@compcode"].Value = compcode;

        //        objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
        //        if (publication != "0")
        //        {
        //            objsqlcom.Parameters["@pub_name"].Value = publication;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
        //        }
        //        objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
        //        if (region != "0")
        //        {
        //            objsqlcom.Parameters["@region"].Value = region;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@subcat", SqlDbType.VarChar);
        //        if (subcat != "0")
        //        {
        //            objsqlcom.Parameters["@subcat"].Value = subcat;
        //        }

        //        else
        //        {
        //            objsqlcom.Parameters["@subcat"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@subsubcat", SqlDbType.VarChar);
        //        if (subsubcat != "0")
        //        {
        //            objsqlcom.Parameters["@subsubcat"].Value = subsubcat;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@subsubcat"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
        //        if (product != "0")
        //        {
        //            objsqlcom.Parameters["@product"].Value = product;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@brand", SqlDbType.VarChar);
        //        if (brand != "0")
        //        {
        //            objsqlcom.Parameters["@brand"].Value = brand;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@brand"].Value = System.DBNull.Value;
        //        }

        //        objsqlcom.Parameters.Add("@varient", SqlDbType.VarChar);
        //        if (varient != "0")
        //        {
        //            objsqlcom.Parameters["@varient"].Value = varient;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@varient"].Value = System.DBNull.Value;
        //        }
        //        objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@dateformat"].Value = dateformat;


        //        objsqldap.SelectCommand = objsqlcom;
        //        objsqldap.Fill(objdataset);

        //        return objdataset;



        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objsqlcon);
        //    }


        //}
        public DataSet spproductreport(string fromdate, string dateto, string compcode, string region, string dateformat, string product, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
            // spregionexcel

        }
        public SqlDataReader spproductexcel(string fromdate, string dateto, string compcode, string region, string dateformat, string product)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("ScheduleReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
        }


        public SqlDataReader displayexcelfile(string frmdt, string todate, string compcode, string publication, string dateformate)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("ScheduleReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }

        }


        public DataSet spbinduom(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_uom", ref objSqlConnection);
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

        public DataSet spcontractreport(string fromdate, string dateto, string compcode, string dateformat, string product, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}
                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@pub_name"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
            // spregionexcel


        }
        public SqlDataReader spcontractexcel(string fromdate, string dateto, string compcode, string region, string dateformat, string product)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet spschemereport(string fromdate, string dateto, string compcode, string pubname, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}
                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
            // spregionexcel


        }
        public SqlDataReader spschemeexcel(string fromdate, string dateto, string compcode, string pubname, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet spcontractreport(string fromdate, string dateto, string compcode, string dateformat, string product)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
               //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}
                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@pub_name"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
            // spregionexcel


        }
        public SqlDataReader spcontractexcel(string fromdate, string dateto, string compcode, string dateformat, string product)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "0")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@pub_name"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;






                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }








        public DataSet adagencycli1(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("packagereport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@regioncode"].Value = regioncode;




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

        public DataSet bindadtype(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("report_bindadcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@advtype"].Value = adtype;

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

        public DataSet packagedesc(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("packagereport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@adcatcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@adcatcode"].Value = adcatcode;


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
        //wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww


        public DataSet schedule_drillout(string frmdt, string todate, string client, string compcode, string dateformate, string package, string agency, string publication, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("ScheduleReport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@publication"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@publication"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



               objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
               objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
        }


        public SqlDataReader scheduleexcel_drillout(string frmdt, string todate, string client, string compcode, string dateformate, string package, string agency, string publication)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("ScheduleReport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@publication"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@publication"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }

        }

        
       public DataSet drillout(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                
                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }


        public DataSet drilloutpage(string page, string position, string client, string agency, string adtyp, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string status, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@page", SqlDbType.VarChar);
                if (page != "0")
                {
                    objsqlcom.Parameters["@page"].Value = page;
                }
                else
                {
                    objsqlcom.Parameters["@page"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@position", SqlDbType.VarChar);

                if (position != "0")
                {
                    objsqlcom.Parameters["@position"].Value = position;
                }
                else
                {
                    objsqlcom.Parameters["@position"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                //objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                //if (adcat != "")
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = adcat;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }
        public DataSet drilloutdev(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string status, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }

       // public DataSet productdrillout(string fromdt, string dateto, string region, string prod, string compcode, string dateformate, string agency, string client, string package, string adcategory, string descid, string ascdesc)
        public DataSet productdrillout(string fromdt, string dateto, string region, string prod, string compcode, string dateformate, string agency, string client, string package, string adcategory, string descid, string ascdesc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("MisReport_drillout", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory != "0")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (prod != "0")
                {
                    objSqlCommand.Parameters["@product"].Value = prod;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objSqlCommand.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objSqlCommand.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objSqlCommand.Parameters["@package"].Value = package;
                }
                else
                {
                    objSqlCommand.Parameters["@package"].Value = System.DBNull.Value;
                }

                //objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);

                objSqlCommand.Parameters["@descid"].Value = descid;



                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;
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

        
        public DataSet regiondrillout(string fromdt, string dateto, string region, string language, string agency, string client, string compcode, string dateformat, string descid, string ascdesc)//, string lang
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("MisReport_drillout", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@language", SqlDbType.VarChar);
                if (language != "0")
                {
                    objSqlCommand.Parameters["@language"].Value = language;
                }
                else
                {
                    objSqlCommand.Parameters["@language"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agency != "0")
                {
                    objSqlCommand.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objSqlCommand.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;



                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

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

        public SqlDataReader region_drillout(string fromdt, string dateto, string region, string language, string agency, string client, string compcode, string dateformat)//, string lang
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@language", SqlDbType.VarChar);
                if (language != "0")
                {
                    objsqlcom.Parameters["@language"].Value = language;
                }
                else
                {
                    objsqlcom.Parameters["@language"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        
        public DataSet publicationdrillout(string fromdt, string dateto, string publ, string agname, string clientname, string published1, string region, string compcode, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("MisReport_drillout", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objSqlCommand.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (clientname != "0")
                {
                    objSqlCommand.Parameters["@clientname"].Value = clientname;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@published", SqlDbType.VarChar);
                if (published1 != "0")
                {
                    objSqlCommand.Parameters["@published"].Value = published1;
                }
                else
                {
                    objSqlCommand.Parameters["@published"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;



                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

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

        
      public DataSet contractdrillout(string fromdt, string dateto, string prod, string agency, string client, string package, string adtyp, string adcat, string region, string compcode, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("MisReport_drillout", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (prod != "0")
                {
                    objSqlCommand.Parameters["@product"].Value = prod;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }



                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agency != "0")
                {
                    objSqlCommand.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objSqlCommand.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtyp != "0")
                {
                    objSqlCommand.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objSqlCommand.Parameters["@package"].Value = package;
                }
                else
                {
                    objSqlCommand.Parameters["@package"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;
                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;



                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

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

        
           public DataSet clientdrillout(string fromdt, string dateto, string agency, string client, string publicationcode, string product, string subcat, string subsubcat, string brand, string varient, string region, string package, string compcode, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("clientreport_drillout", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agency != "")
                {
                    objSqlCommand.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "")
                {
                    objSqlCommand.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publicationcode != "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = publicationcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }



                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objSqlCommand.Parameters["@product"].Value = product;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@subcat", SqlDbType.VarChar);
                if (subcat != "")
                {
                    objSqlCommand.Parameters["@subcat"].Value = subcat;
                }
                else
                {
                    objSqlCommand.Parameters["@subcat"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@subsubcat", SqlDbType.VarChar);
                if (subsubcat != "")
                {
                    objSqlCommand.Parameters["@subsubcat"].Value = subsubcat;
                }
                else
                {
                    objSqlCommand.Parameters["@subsubcat"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                if (brand != "")
                {
                    objSqlCommand.Parameters["@brand"].Value = brand;
                }
                else
                {
                    objSqlCommand.Parameters["@brand"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                if (varient != "")
                {
                    objSqlCommand.Parameters["@varient"].Value = varient;
                }
                else
                {
                    objSqlCommand.Parameters["@varient"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objSqlCommand.Parameters["@package"].Value = package;
                }
                else
                {
                    objSqlCommand.Parameters["@package"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;



                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;


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

        public DataSet drilloutstatus(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string status, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }

        // client, agency, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, package);
        public DataSet drilloutagency(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }
        public DataSet drilloutclient(string client, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }
        public SqlDataReader product_drillout(string fromdt, string dateto, string region, string prod, string compcode, string dateformate, string agency, string client, string package, string adcategory)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;




                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory != "0")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (prod != "0")
                {
                    objsqlcom.Parameters["@product"].Value = prod;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }

        }


        public SqlDataReader publication_drillout(string fromdt, string dateto, string publ, string agname, string clientname, string published1, string region, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agname != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (clientname != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = clientname;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@published", SqlDbType.VarChar);
                if (published1 != "0")
                {
                    objsqlcom.Parameters["@published"].Value = published1;
                }
                else
                {
                    objsqlcom.Parameters["@published"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public SqlDataReader contract_drillout(string fromdt, string dateto, string prod, string agency, string client, string package, string adtyp, string adcat, string region, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("MisReport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (prod != "0")
                {
                    objsqlcom.Parameters["@product"].Value = prod;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }

        }

        public SqlDataReader client_drillout(string fromdt, string dateto, string agency, string client, string publicationcode, string product, string subcat, string subsubcat, string brand, string varient, string region, string package, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("clientreport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);

                if (agency != "")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publicationcode != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publicationcode;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@subcat", SqlDbType.VarChar);
                if (subcat != "")
                {
                    objsqlcom.Parameters["@subcat"].Value = subcat;
                }
                else
                {
                    objsqlcom.Parameters["@subcat"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@subsubcat", SqlDbType.VarChar);
                if (subsubcat != "")
                {
                    objsqlcom.Parameters["@subsubcat"].Value = subsubcat;
                }
                else
                {
                    objsqlcom.Parameters["@subsubcat"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@brand", SqlDbType.VarChar);
                if (brand != "")
                {
                    objsqlcom.Parameters["@brand"].Value = brand;
                }
                else
                {
                    objsqlcom.Parameters["@brand"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@varient", SqlDbType.VarChar);
                if (varient != "")
                {
                    objsqlcom.Parameters["@varient"].Value = varient;
                }
                else
                {
                    objsqlcom.Parameters["@varient"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet addaydrilloutpdf(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;




                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }




  public DataSet addaydrilloutexcel(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;




              


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);
                return objdataset;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

               // return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;





            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }

        public SqlDataReader drillout_clientexcel(string client, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet statusdrilloutexcel(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string status, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;




                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);
                return objdataset;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                // return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;





            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }

        public DataSet statusdrilloutpdf(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string dateformat, string status, string descid,string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {



                objsqlcon.Open();
                objsqlcom = GetCommand("report_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }

        public SqlDataReader drillout_dev(string client, string agency, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string status, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                if (adcat != "")
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcat;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public SqlDataReader drillout_page(string page, string position, string client, string agency, string adtyp, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string package, string status, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@page", SqlDbType.VarChar);
                if (page != "0")
                {
                    objsqlcom.Parameters["@page"].Value = page;
                }
                else
                {
                    objsqlcom.Parameters["@page"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@position", SqlDbType.VarChar);

                if (position != "0")
                {
                    objsqlcom.Parameters["@position"].Value = position;
                }
                else
                {
                    objsqlcom.Parameters["@position"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);

                if (client != "0")
                {
                    objsqlcom.Parameters["@clientname"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agname"].Value = agency;
                }

                else
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtyp != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtyp;
                }

                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                //objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);

                //if (adcat != "")
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = adcat;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publ != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publ;
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcen != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcen;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }

                ////-----------------------------------------------------------------------------------------------------------
                //if (edition == "")
                //{
                //    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                //}
                ////---------------------------------------------------------------------------------------------------------
                else
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "0")
                {
                    objsqlcom.Parameters["@package"].Value = package;
                }
                else
                {
                    objsqlcom.Parameters["@package"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                if (status != "0")
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }





       
    
    }



}
    