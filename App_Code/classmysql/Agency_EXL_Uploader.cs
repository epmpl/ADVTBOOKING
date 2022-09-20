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
    public class Agency_EXL_Uploader : connection
    {
        public Agency_EXL_Uploader()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet Agency_EXL_Upload(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();

            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AGENCY_DATA_UPLOAD", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcompcode"].Value = compcode;
                
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