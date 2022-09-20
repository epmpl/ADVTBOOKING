using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
/// <summary>
/// Summary description for audit_comman
/// </summary>
    public class audit_comman : connection
    {
        public audit_comman()
        {
            //
            // TODO: Add constructor logic here
            //
        }

       // txtvalidityfrom.Text, txttilldate.Text, Session["dateformat"].ToString(), revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, hdnagency1.Value, hdnclient1.Value, branch, hdnretainer.Value, hdnexecode.Value, hiddensupplement.Value, drpstatus.SelectedValue, drpuom.SelectedValue, Session["userid"].ToString(), txtBookingId.Text

        public DataSet websp_bindgrid(string fromdate, string todate, string dateformat, string revcenter, string adtype, string publcode, string pubcenter  , string edition, string hdnagency, string hdnclient, string branch, string retainer, string hdnexecode, string hdnsupplement , string drpstatus, string uommast, string userid, string booking_id )
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                // string openreferExtra = ConfigurationSettings.AppSettings["openreferExtra"];
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_bindaudit_websp_bindaudit_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("Pfromdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pfromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("Ptodate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Ptodate"].Value = todate;

                objSqlCommand.Parameters.Add("Pdate1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pdate1"].Value = dateformat;

                objSqlCommand.Parameters.Add("Pbranch", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pbranch"].Value = revcenter;

                objSqlCommand.Parameters.Add("Padtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Padtype"].Value = adtype;

                objSqlCommand.Parameters.Add("Ppublication", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Ppublication"].Value = publcode;

                objSqlCommand.Parameters.Add("Ppub_cent", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Ppub_cent"].Value = pubcenter;

                objSqlCommand.Parameters.Add("Pedition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pedition"].Value = edition;

                objSqlCommand.Parameters.Add("Pagency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pagency"].Value = hdnagency;

                objSqlCommand.Parameters.Add("Pclient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pclient"].Value = hdnclient;

                objSqlCommand.Parameters.Add("Pbranchnew", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Pbranchnew"].Value = branch;

                objSqlCommand.Parameters.Add("v_retainer", MySqlDbType.VarChar);
                objSqlCommand.Parameters["v_retainer"].Value = retainer;

                objSqlCommand.Parameters.Add("v_executive", MySqlDbType.VarChar);
                objSqlCommand.Parameters["v_executive"].Value = hdnexecode;

                objSqlCommand.Parameters.Add("v_supplement", MySqlDbType.VarChar);
                objSqlCommand.Parameters["v_supplement"].Value = hdnsupplement;

                objSqlCommand.Parameters.Add("v_insert_status", MySqlDbType.VarChar);
                objSqlCommand.Parameters["v_insert_status"].Value = drpstatus;

                objSqlCommand.Parameters.Add("puom_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["puom_code"].Value = uommast;

                objSqlCommand.Parameters.Add("v_userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["v_userid"].Value = userid;

                objSqlCommand.Parameters.Add("PBOOKING_ID", MySqlDbType.VarChar);
                objSqlCommand.Parameters["PBOOKING_ID"].Value = booking_id;

                objSqlDataAdapter = new MySqlDataAdapter();
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
