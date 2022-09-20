using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using java.sql;
using System.Data.SqlClient;
namespace NewAdbooking.Report.Classes
{
    public class rpt_audit_trail : connection
    {
        public rpt_audit_trail()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindr(string compcode, string unit, string cha, string repo, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet ds = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_get_report_table_col_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = cha;

                objSqlCommand.Parameters.Add("@ptseq_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptseq_no"].Value = repo;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;

                objSqlCommand.Parameters.Add("@pextra6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra6"].Value = extra6;

                objSqlCommand.Parameters.Add("@pextra7", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra7"].Value = extra7;

                objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra8"].Value = extra8;

                objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra9"].Value = extra9;

                objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra10"].Value = extra10;

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


        public DataSet masrep(string compcode, string unit, string cha, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet ds = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_get_report_table_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pchannel"].Value = cha;

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

                objSqlCommand.Parameters.Add("@pextra6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra6"].Value = extra6;

                objSqlCommand.Parameters.Add("@pextra7", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra7"].Value = extra7;

                objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra8"].Value = extra8;

                objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra9"].Value = extra9;

                objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra10"].Value = extra10;

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

        public DataSet bindgrid(string compcode, string unit, string cha, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet ds = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_data_from_tbl", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid"].Value = unit;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfromdate"].Value = cha;

                objSqlCommand.Parameters.Add("@ptodate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptodate"].Value = extra1;

                objSqlCommand.Parameters.Add("@pval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pval"].Value = extra2;

               

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
