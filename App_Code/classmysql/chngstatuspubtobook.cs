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
/// Summary description for chngstatuspubtobook
/// </summary>
    public class chngstatuspubtobook : connection
    {
        public chngstatuspubtobook()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        // FOR changestatuspublish_to_book 

        public DataSet changestatuspublish_to_book(string fromdate, string todate, string agencycode, string bookingid, string adtype, string branch)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDGRID_CHANGESTATUSPTOB", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("validfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfrom"].Value = fromdate;

                objmysqlcommand.Parameters.Add("validto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validto"].Value = todate;

                objmysqlcommand.Parameters.Add("pagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pagencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("pcioid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcioid"].Value = bookingid;

                objmysqlcommand.Parameters.Add("pbranch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbranch"].Value = branch;

                objmysqlcommand.Parameters.Add("padtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["padtype"].Value = adtype;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        // FOR UPDATE 

        public DataSet update(string insertid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatepublishtobooked", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("insertid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertid"].Value = insertid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }




    }
}