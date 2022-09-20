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
    /// Summary description for LanguageMaster
    /// </summary>
    public class LanguageMaster : connection
    {
        public LanguageMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet ModifyValue(string LangCode, string LangName, string Alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("languagemastmodify_languagemastmodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
               
                objmysqlcommand.Parameters.Add("LangCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangCode"].Value = LangCode;
                objmysqlcommand.Parameters.Add("LangName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangName"].Value = LangName;
                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            
             

             
            }
            catch (MySqlException objException)
            {
                throw (objException);
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet InsertValue(string LangCode, string LangName, string Alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("languagemstinsert_languagemstinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("LangCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangCode"].Value = LangCode;
                objmysqlcommand.Parameters.Add("LangName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangName"].Value = LangName;
                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
               

             
            }
            catch (MySqlException objException)
            {
                throw (objException);
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet SelectValue(string LangCode, string LangName, string Alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            try
            {



                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("languagemstselect_languagemstselect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("LangCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangCode"].Value = LangCode;
                objmysqlcommand.Parameters.Add("LangName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangName"].Value = LangName;
                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
             
            }
            catch (MySqlException objException)
            {
                throw (objException);
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet Selectfnpl(string LangCode, string LangName, string Alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("languagemstfnpl_languagemstfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
               

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
             
            }
            catch (MySqlException objException)
            {
                throw (objException);
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet DeleteValue(string LangCode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("languagemastdelete_languagemastdelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("LangCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["LangCode"].Value = LangCode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
               
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet checklangcode(string LangCode, string LangName, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("langchkcode_langchkcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("langcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["langcode"].Value = LangCode;
                objmysqlcommand.Parameters.Add("langname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["langname"].Value = LangName;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
               

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }



        public DataSet countlanguagecode(string str,string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chklanguagecodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;
                objmysqlcommand.Parameters.Add("company_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["company_code"].Value = compcode;
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
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }










    }
}
