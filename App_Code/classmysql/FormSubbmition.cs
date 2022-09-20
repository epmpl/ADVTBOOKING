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
    /// Summary description for FormSubbmition
    /// </summary>
    public class FormSubbmition : connection
    {
        public FormSubbmition()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet autocode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("forminsertautocode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }

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
        public DataSet formcheck(string code, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("forminsertchk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("formcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formcode"].Value = code;

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
        public DataSet forminsert(string compcode, string code, string name, string alias, string userid, string formtype, string modulecod)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("forminsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("formcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formcode"].Value = code;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = name;

                objmysqlcommand.Parameters.Add("formalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formalias"].Value = alias;

                objmysqlcommand.Parameters.Add("formtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formtype1"].Value = formtype;

                objmysqlcommand.Parameters.Add("modulecod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["modulecod"].Value = modulecod;

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
//======================================New
        public DataSet execform(string compcode, string formtyp, string modulecode, string frmcode, string frmname, string frmalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("formexec", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("formcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formcode"].Value = frmcode;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = frmname;

                objmysqlcommand.Parameters.Add("formalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formalias"].Value = frmalias;

                objmysqlcommand.Parameters.Add("formtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formtype1"].Value = formtyp;

                objmysqlcommand.Parameters.Add("modulecod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["modulecod"].Value = modulecode;

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
        public DataSet delform(string compcode, string frmcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("formdel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("formcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formcode"].Value = frmcode;

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
        public DataSet modifydata(string compcode, string formtyp, string modulecode, string frmcode, string frmname, string frmalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("formupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("formcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formcode"].Value = frmcode;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = frmname;

                objmysqlcommand.Parameters.Add("formalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formalias"].Value = frmalias;

                objmysqlcommand.Parameters.Add("formtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formtype1"].Value = formtyp;

                objmysqlcommand.Parameters.Add("modulecod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["modulecod"].Value = modulecode;

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
