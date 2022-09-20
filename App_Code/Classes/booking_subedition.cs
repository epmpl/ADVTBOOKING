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
/// <summary>
/// Summary description for booking_subedition
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class booking_subedition:connection
    {
        public booking_subedition()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void updateData(string srno, string insertid, string height, string width, string totarea, string dateI, string edition, string receiptno, string dateformat, string insstatus, string pageno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            // DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateDataEditionDetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@srno_p", SqlDbType.Int);
                objSqlCommand.Parameters["@srno_p"].Value = srno;

                objSqlCommand.Parameters.Add("@insertid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertid_p"].Value = insertid;

                objSqlCommand.Parameters.Add("@height_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@height_p"].Value = height;

                objSqlCommand.Parameters.Add("@width_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@width_p"].Value = width;

                objSqlCommand.Parameters.Add("@totarea_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@totarea_p"].Value = totarea;

                objSqlCommand.Parameters.Add("@dateI_p", SqlDbType.VarChar);
                if (dateI == "" || dateI == null)
                {
                    objSqlCommand.Parameters["@dateI_p"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateI.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateI = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                         string[] arr = dateI.Split('/');
                        string yy = arr[0];
                        string mm = arr[1];
                        string dd = arr[2];
                        dateI = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@dateI_p"].Value = dateI;
                  
                }

                objSqlCommand.Parameters.Add("@edition_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_p"].Value = edition;

                objSqlCommand.Parameters.Add("@receiptno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno_p"].Value = receiptno;

                objSqlCommand.Parameters.Add("@insstatus_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insstatus_p"].Value = insstatus;

                objSqlCommand.Parameters.Add("@pageno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno_p"].Value = pageno;
               
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlCommand.ExecuteNonQuery();
                //  return objDataSet;
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
        public DataSet fetchSubEdition(string edition, string compcode, string insertid, string dateformat,string pkgcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("FetchSubEditionDetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertid"].Value = insertid;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

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