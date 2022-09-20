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
/// Summary description for Reciept_Ht
/// </summary>
namespace NewAdbooking.Classes
{

    public class Reciept_Ht:connection
    {
        public Reciept_Ht()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindreceiptdata(string compcode, string booking_id)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            SqlDataAdapter sqladpt = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("ht_receipt_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@comp_code", SqlDbType.VarChar);
                cmd.Parameters["@comp_code"].Value = compcode;

                cmd.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                cmd.Parameters["@receipt_no"].Value = booking_id;

                sqladpt.SelectCommand = cmd;
                sqladpt.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
public DataSet bindrodetail(string compcode, string receiptno,string sapid)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            SqlDataAdapter sqladpt = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("rodetail_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@comp_code", SqlDbType.VarChar);
                cmd.Parameters["@comp_code"].Value = compcode;

                cmd.Parameters.Add("@receipt_no", SqlDbType.VarChar);
                if (receiptno == "")
                    cmd.Parameters["@receipt_no"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@receipt_no"].Value = receiptno;

                cmd.Parameters.Add("@sap_id", SqlDbType.VarChar);
                if (sapid == "")
                    cmd.Parameters["@sap_id"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@sap_id"].Value = sapid;


                sqladpt.SelectCommand = cmd;
                sqladpt.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
    }
}
