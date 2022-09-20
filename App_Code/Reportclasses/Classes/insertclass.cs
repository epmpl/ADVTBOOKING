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
/// Summary description for insertclass
/// </summary>
public class insertclass:connection
{
	public insertclass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    
    public DataSet insertionwisebilling(string compcode, string pcentcode, string unitcode, string publcode, string edtncode, string dist_code, string from_date, string till_date, string dateformat, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        SqlConnection objSqlConnection=new SqlConnection();
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("rpt_edtionwise_summary_rpt_edtionwise_billing", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            if (compcode == "0" || compcode == "")
            {
                objSqlCommand.Parameters["@pcompcode"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;
            }
            

            objSqlCommand.Parameters.Add("@ppcentcode", SqlDbType.VarChar);
            if (pcentcode == "0" || pcentcode == "")
            {
                objSqlCommand.Parameters["@ppcentcode"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@ppcentcode"].Value = pcentcode;

            }
            
            objSqlCommand.Parameters.Add("@punitcode", SqlDbType.VarChar);
            if (unitcode == "0" || unitcode == "")
            {
                objSqlCommand.Parameters["@punitcode"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@punitcode"].Value = unitcode;

            }
           

            objSqlCommand.Parameters.Add("@ppublcode", SqlDbType.VarChar);
            if (publcode == "0" || publcode == "")
            {
                objSqlCommand.Parameters["@ppublcode"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@ppublcode"].Value = publcode;

            }
            
            objSqlCommand.Parameters.Add("@pedtncode", SqlDbType.VarChar);
            if (edtncode == "0" || edtncode == "" || edtncode == "--Select Edition Name--")
            {
                objSqlCommand.Parameters["@pedtncode"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@pedtncode"].Value = edtncode;

            }
            
            objSqlCommand.Parameters.Add("@pdist_code", SqlDbType.VarChar);
            if (dist_code == "0" || dist_code == "")
            {
                objSqlCommand.Parameters["@pdist_code"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@pdist_code"].Value = dist_code;

            }
            
            objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);

            if (from_date == "0" || from_date == "")
            {
                objSqlCommand.Parameters["@pfrom_date"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@pfrom_date"].Value = from_date;
            }


            objSqlCommand.Parameters.Add("@ptill_date", SqlDbType.VarChar);
            if (till_date == "" || till_date == "")
            {
                objSqlCommand.Parameters["@ptill_date"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@ptill_date"].Value = till_date;
            }
            
            objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

            objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@puserid"].Value = userid;

            objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra1"].Value = extra1;

            objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra2"].Value = extra2;

            objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra3"].Value = extra3;

            objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra4"].Value = extra4;

            objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra5"].Value = extra5;



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