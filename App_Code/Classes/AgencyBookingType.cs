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
    public class AgencyBookingType : connection
    {
        public AgencyBookingType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet savebkdata(string booktyp, string agency, string frmdate, string tdate, string dateformat, string usrid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savebktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@booktyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktyp"].Value = booktyp;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@frmdate", SqlDbType.VarChar);
                if (frmdate == "" || frmdate == null)
                {
                    objSqlCommand.Parameters["@frmdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@frmdate"].Value = frmdate;
                }

                objSqlCommand.Parameters.Add("@tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@tdate"].Value = tdate;
                }

                objSqlCommand.Parameters.Add("@usrid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@usrid"].Value = usrid;

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
  public DataSet delbkdata(string compcode, string code11)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("delbktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code11"].Value = code11;
                                
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
    public DataSet updbkdata(string booktyp, string agency, string frmdate, string tdate, string dateformat, string usrid, string compcode,string code11)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updbktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@booktyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktyp"].Value = booktyp;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@frmdate", SqlDbType.VarChar);
                if (frmdate == "" || frmdate == null)
                {
                    objSqlCommand.Parameters["@frmdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@frmdate"].Value = frmdate;
                }

                objSqlCommand.Parameters.Add("@tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@tdate"].Value = tdate;
                }

                objSqlCommand.Parameters.Add("@usrid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@usrid"].Value = compcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code11"].Value = code11;

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
    public DataSet chkdup(string booktyp, string agency, string frmdate, string tdate, string dateformat, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdupbktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@booktyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktyp"].Value = booktyp;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@frmdate", SqlDbType.VarChar);
                if (frmdate == "" || frmdate == null)
                {
                    objSqlCommand.Parameters["@frmdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@frmdate"].Value = frmdate;
                }

                objSqlCommand.Parameters.Add("@tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@tdate"].Value = tdate;
                }

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
    public DataSet chkdupdate(string booktyp, string agency, string frmdate, string tdate, string dateformat, string compcode,string code11)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdupdatebktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@booktyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktyp"].Value = booktyp;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@frmdate", SqlDbType.VarChar);
                if (frmdate == "" || frmdate == null)
                {
                    objSqlCommand.Parameters["@frmdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@frmdate"].Value = frmdate;
                }

                objSqlCommand.Parameters.Add("@tdate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@tdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@tdate"].Value = tdate;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code11"].Value = code11;

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
    public DataSet bindcktyp(string compcode, string code11)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindbktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code11"].Value = code11;

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
    public DataSet findrec(string booktyp, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("findrecbktype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@booktyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktyp"].Value = booktyp;

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
    }
}
