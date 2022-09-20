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
    /// Summary description for weekly_monthly_reports
    /// </summary>
    public class weekly_monthly_reports : connection
    {
        public weekly_monthly_reports()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet branchbindWithPrintCenter(string compcode, string printbindbranch)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("BRANCHWITHPRINTCEN", ref  objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@printcen", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printcen"].Value = printbindbranch;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);
                return ds;

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

        public DataSet weekwise_billing(string compcode, string printcenter, string branchcode, string publication, string fromdate, string dateto, string useid, string dateformat,string basedon, string ext1, string ext2, string ext3, string ext4, string ext5, string ext6, string ext7, string ext8, string ext9, string ext10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_weekwise_billing_summ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcenter", SqlDbType.VarChar);
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    objSqlCommand.Parameters["@pcenter"].Value = printcenter;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = branchcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@ppublcode", SqlDbType.VarChar);
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = publication;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = System.DBNull.Value;
                }
                                
                objSqlCommand.Parameters.Add("@pdatefrom", SqlDbType.DateTime);
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
                objSqlCommand.Parameters["@pdatefrom"].Value = fromdate;

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.DateTime);
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
                objSqlCommand.Parameters["@pdateto"].Value = dateto;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pdate_basedon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_basedon"].Value = basedon;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = ext1;

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