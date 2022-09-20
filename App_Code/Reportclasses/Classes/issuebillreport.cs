using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
namespace NewAdbooking.Report.Classes
{

/// <summary>
/// Summary description for issuebillreport
/// </summary>
    public class issuebillreport : connection
{
	public issuebillreport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet pub_cent_NEW(string compcode, string chk_access, string useid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("Bind_PubCentName_r", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@puserid"].Value = useid;
            objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
            objSqlCommand.Parameters["@chk_access"].Value = chk_access;
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

    public DataSet district(string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("CityMst_District", ref objSqlConnection);
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

    public DataSet adbranch(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("branchbind_adv", ref objSqlConnection);
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

    public DataSet pub_Edtn(string compcode, string publ_code, string dateformat, string extra1, string extra2)
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
            objSqlCommand.Parameters["@pubcode "].Value = publ_code;
            objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@centercode"].Value = extra1;
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

        public DataSet getissuebillrep(string compcode, string pubcent, string edition, string fromdate, string todate, string dateformat, string userid, string access, string ratio_type, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_Issue_Billwise_report_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppubcent", SqlDbType.VarChar);
                if (pubcent=="")
                objSqlCommand.Parameters["@ppubcent"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ppubcent"].Value = pubcent;

                objSqlCommand.Parameters.Add("@pedtncode", SqlDbType.VarChar);
                if (edition=="")
                objSqlCommand.Parameters["@pedtncode"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pedtncode"].Value = edition;

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (fromdate=="")
                {
                    objSqlCommand.Parameters["@pfrom_date"].Value = System.DBNull.Value;
                }
                else
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
                    objSqlCommand.Parameters["@pfrom_date"].Value = fromdate;
                }
                

                objSqlCommand.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@ptill_date"].Value = System.DBNull.Value;
                }
                else
                {
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
                    objSqlCommand.Parameters["@ptill_date"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                if (userid=="")
                objSqlCommand.Parameters["@puserid"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                if (access=="")
                objSqlCommand.Parameters["@chk_access"].Value = access;
                else
                    objSqlCommand.Parameters["@chk_access"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pratio_type", SqlDbType.VarChar);
                if (ratio_type=="")
                objSqlCommand.Parameters["@pratio_type"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pratio_type"].Value = ratio_type;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

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

