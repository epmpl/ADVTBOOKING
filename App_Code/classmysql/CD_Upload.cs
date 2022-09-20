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
    /// Summary description for CD_Upload
    /// </summary>
    public class CD_Upload : connection
    {
        public CD_Upload()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet Pripubcode(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_addpubcode1_Websp_addpubcode1_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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


        public DataSet centercode(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_Addcenter", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet editioncode(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_addedition_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet secpubcode(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_addsecpub_p_Websp_addsecpub", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet UpdateFilename_CD(string compcode, string fname, string idnum, string insnum, string insertid, string editioncode, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_updatefilename_cd", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("fname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fname"].Value = fname;

                objmysqlcommand.Parameters.Add("idnum", MySqlDbType.Int32);
                objmysqlcommand.Parameters["idnum"].Value = idnum;

                objmysqlcommand.Parameters.Add("insnum", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insnum"].Value = insnum;

                objmysqlcommand.Parameters.Add("insertid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertid"].Value = insertid;

                objmysqlcommand.Parameters.Add("peditioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["peditioncode"].Value = editioncode;

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


        public DataSet formpermission(string compcode, string userid, string formname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_Show_Permission", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = formname;

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


        public DataSet editioncodes(string centercode, string userid, string pubcode)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("websp_addeditions", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["centercode"].Value = centercode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pubcode"].Value = pubcode;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }

        public DataSet secpubcodes(string compcode, string userid, string editioncode)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("Websp_Addsecpubs", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["editioncode"].Value = editioncode;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }


    }
}