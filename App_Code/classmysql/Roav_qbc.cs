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
    /// Summary description for Roav_qbc
    /// </summary>
    public class Roav_qbc:connection
    {
        public Roav_qbc()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        

        public DataSet rate_ecode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AUTOAGTYPECODE_autoratecode", ref objmysqlconnection);
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


        public DataSet cli_execute(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cir_dynamic_dml_variable_execute_stmt", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("ptable_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptable_name"].Value = tblname;

                objmysqlcommand.Parameters.Add("pcond_colname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcond_colname"].Value = colname;

                objmysqlcommand.Parameters.Add("pcond_colval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcond_colval"].Value = colvalue;

                objmysqlcommand.Parameters.Add("pdelimiter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pdelimiter"].Value = "$~$" ;//delimeter;

                objmysqlcommand.Parameters.Add("pdateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pdateformat"].Value = date;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;
              
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