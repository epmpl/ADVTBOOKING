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
    /// Summary description for industrymaster
    /// </summary>
    public class industrymaster : connection
    {
        public industrymaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet chkcode(string code, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkindustrycode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;
                objmysqlcommand.Parameters.Add("CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CODE"].Value = code;

                objmysqlcommand.Parameters.Add("NAME", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["NAME"].Value = code;

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

        public DataSet insertvalue(string code, string name, string alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertindustry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["name"].Value = name;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


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

        public DataSet updatevalue(string code, string name, string alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateindustry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["name"].Value = name;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

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

        public DataSet executequery(string code, string alias, string name, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executeindustry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;
                objmysqlcommand.Parameters.Add("name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["name"].Value = name;
                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;
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


        public DataSet deletevalue(string code, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  

            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deleteindustry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;
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
                objmysqlcommand = GetCommand("industryautocode_industryautocode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("STR", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["STR"].Value = str;

                objmysqlcommand.Parameters.Add("COD", MySqlDbType.VarChar);
                if(str.Length >2)
                {
                    objmysqlcommand.Parameters["COD"].Value = str.Substring(0, 2);
            }
                
                    else
                {
                    objmysqlcommand.Parameters["COD"].Value = str;
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