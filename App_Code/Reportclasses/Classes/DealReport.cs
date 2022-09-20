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
/// Summary description for DealReport
/// </summary>
    public class DealReport : connection
{
	public DealReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet bindratecode(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("adb_bindratecode", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

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
    public DataSet getdealdata(string pcompcode, string padtype, string padcat, string pdeal_type, string pag_maincode, string pag_subcode, string pclient, string papproved, string ppackage, string pratecode, string pfromdt, string ptilldt, string pdate_flag, string puserid, string pdateformat)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("rpt_deal_detail", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

            objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
            if (padtype == "0" || padtype == "")
                objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@padtype"].Value = padtype;

            objSqlCommand.Parameters.Add("@padcat", SqlDbType.VarChar);
            if (padcat == "0" || padcat == "")
                objSqlCommand.Parameters["@padcat"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@padcat"].Value = padcat;

            objSqlCommand.Parameters.Add("@pdeal_type", SqlDbType.VarChar);
            if (pdeal_type == "0" || pdeal_type == "")
                objSqlCommand.Parameters["@pdeal_type"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@pdeal_type"].Value = pdeal_type;


            objSqlCommand.Parameters.Add("@pag_maincode", SqlDbType.VarChar);

            if (pag_maincode != "0" && pag_maincode != "")
                objSqlCommand.Parameters["@pag_maincode"].Value = System.DBNull.Value;
            else
                objSqlCommand.Parameters["@pag_maincode"].Value = pag_maincode;


            objSqlCommand.Parameters.Add("@pag_subcode", SqlDbType.VarChar);
            if (pag_subcode == "0" || pag_subcode == "")
            {
                objSqlCommand.Parameters["@pag_subcode"].Value = System.DBNull.Value;
            }
            else
            {

                objSqlCommand.Parameters["@pag_subcode"].Value = pag_subcode;
            }

            objSqlCommand.Parameters.Add("@pclient", SqlDbType.VarChar);
            if (pclient == "")
            {
                objSqlCommand.Parameters["@pclient"].Value = System.DBNull.Value;
            }
            else
            {

                objSqlCommand.Parameters["@pclient"].Value = pclient;
            }

            objSqlCommand.Parameters.Add("@papproved", SqlDbType.VarChar);
            if (papproved == "0" || papproved == "")
            {
                objSqlCommand.Parameters["@papproved"].Value = System.DBNull.Value;
            }
            else
            {

                objSqlCommand.Parameters["@papproved"].Value = papproved;
            }


            objSqlCommand.Parameters.Add("@pfromdt", SqlDbType.VarChar);
            if (pfromdt != "0" && pfromdt != "")
            {
                if (pdateformat == "dd/mm/yyyy")
                {
                    string[] arr = pfromdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pfromdt = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pfromdt"].Value = pfromdt;
            }
            else
            {
                objSqlCommand.Parameters["@pfromdt"].Value = System.DBNull.Value;
            }


            objSqlCommand.Parameters.Add("@ptilldt", SqlDbType.VarChar);
            if (ptilldt != "0" && ptilldt != "")
            {
                if (pdateformat == "dd/mm/yyyy")
                {
                    string[] arr = ptilldt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    ptilldt = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@ptilldt"].Value = ptilldt;
            }
            else
            {
               objSqlCommand.Parameters["@ptilldt"].Value = System.DBNull.Value;
            }


            objSqlCommand.Parameters.Add("@ppackage", SqlDbType.VarChar);
            if (ppackage == "0" || ppackage == "")
            {
                objSqlCommand.Parameters["@ppackage"].Value = System.DBNull.Value;
            }
            else
            {

                objSqlCommand.Parameters["@ppackage"].Value = ppackage;
            }

            objSqlCommand.Parameters.Add("@pratecode", SqlDbType.VarChar);
            if (pratecode == "0" || pratecode == "")
            {
                objSqlCommand.Parameters["@pratecode"].Value = System.DBNull.Value;
            }
            else
            {

                objSqlCommand.Parameters["@pratecode"].Value = pratecode;
            }


            objSqlCommand.Parameters.Add("@pdate_flag", SqlDbType.VarChar);
            if(pdate_flag == "")
            {
                objSqlCommand.Parameters["@pdate_flag"].Value = System.DBNull.Value;
            }
            else
            {

                objSqlCommand.Parameters["@pdate_flag"].Value = pdate_flag;
            }

            objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@puserid"].Value = puserid;

            objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pdateformat"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra6", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra6"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra7", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra7"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra8"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra9"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra10"].Value = System.DBNull.Value; 

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
