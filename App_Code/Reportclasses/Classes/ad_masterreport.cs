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
    public class ad_masterreport : connection
{
	public ad_masterreport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet masterreport(string compcode, string unitcode, string channel, string seqno, string tablename, string tablecol, string tablefilter, string order, string ext2, string ext3, string ext4, string ext5, string ext6, string ext7, string ext8, string ext9, string ext10)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet ds = new DataSet();

        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("tv_get_table_report", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
            objSqlCommand.Parameters["@punit"].Value = unitcode;

            objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pchannel"].Value = channel;

            objSqlCommand.Parameters.Add("@ptseq_no", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ptseq_no"].Value = seqno;

            objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ptable_name"].Value = tablename;

            objSqlCommand.Parameters.Add("@ptable_col", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ptable_col"].Value = tablecol;

            objSqlCommand.Parameters.Add("@ptable_filter", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ptable_filter"].Value = tablefilter;

            objSqlCommand.Parameters.Add("@porder", SqlDbType.VarChar);
            objSqlCommand.Parameters["@porder"].Value = order;

            objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra2"].Value = ext2;

            objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra3"].Value = ext3;

            objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra4"].Value = ext4;

            objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra5"].Value = ext5;

            objSqlCommand.Parameters.Add("@pextra6", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra6"].Value = ext6;

            objSqlCommand.Parameters.Add("@pextra7", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra7"].Value = ext7;

            objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra8"].Value = ext8;

            objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra9"].Value = ext9;

            objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra10"].Value = ext10;

            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(ds);
            return ds;

        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }


    }

}
}