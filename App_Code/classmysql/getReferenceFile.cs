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
    /// Summary description for getReferenceFile
    /// </summary>
    public class getReferenceFile : connection
    {
        public getReferenceFile()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet clsEditionFileName(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string iidnum, string insnum, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_geteditionfilename", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubdate"].Value = pubdate;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centercode"].Value = centercode;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("iidnum", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["iidnum"].Value = iidnum;

                objmysqlcommand.Parameters.Add("iinsnum", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["iinsnum"].Value = insnum;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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


        public DataSet clsPublishClassifiedAd(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string iidnum, string insnum, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_PublishClassifiedAd", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubdate"].Value = pubdate;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["centercode"].Value = centercode;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;

                objmysqlcommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppcode"].Value = suppcode;

                objmysqlcommand.Parameters.Add("iidnum", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["iidnum"].Value = iidnum;

                objmysqlcommand.Parameters.Add("insnum", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insnum"].Value = insnum;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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