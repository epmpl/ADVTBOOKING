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
    /// Summary description for bankmaster
    /// </summary>
    public class bankmaster:connection
    {
        public bankmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adcountryname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcountryname_adcountryname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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


        public DataSet countcity(string txtcountry)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtcountry", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcountry"].Value = txtcountry;

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


        public DataSet bankbind(string agencode, string agencysubcode, string comp, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindbankdata", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("comp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp"].Value = comp;

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

        public DataSet insertdata(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bankinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bankname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bankname1"].Value = bankname;

                objmysqlcommand.Parameters.Add("branch1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branch1"].Value = branch;

                objmysqlcommand.Parameters.Add("country1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country1"].Value = country;

                objmysqlcommand.Parameters.Add("city1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city1"].Value = city;

                objmysqlcommand.Parameters.Add("bankno1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bankno1"].Value = bankno;

                objmysqlcommand.Parameters.Add("accountno1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["accountno1"].Value = accountno;

                objmysqlcommand.Parameters.Add("compcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode1"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode1"].Value = agencode;

                objmysqlcommand.Parameters.Add("subagncode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagncode1"].Value = subagncode;


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


        public DataSet bankdata(string compcode, string userid, string agencode, string subagncode, string code10)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bankdataselect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("subagncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagncode"].Value = subagncode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code10;


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


        public DataSet updatedata(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode, string codebk)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bankdataupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bankname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bankname1"].Value = bankname;

                objmysqlcommand.Parameters.Add("branch1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branch1"].Value = branch;

                objmysqlcommand.Parameters.Add("country1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country1"].Value = country;

                objmysqlcommand.Parameters.Add("city1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city1"].Value = city;

                objmysqlcommand.Parameters.Add("bankno1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bankno1"].Value = bankno;

                objmysqlcommand.Parameters.Add("accountno1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["accountno1"].Value = accountno;

                objmysqlcommand.Parameters.Add("compcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode1"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode1"].Value = agencode;

                objmysqlcommand.Parameters.Add("subagncode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagncode1"].Value = subagncode;

                objmysqlcommand.Parameters.Add("codebk1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["codebk1"].Value = codebk;


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


        public DataSet deletedata(string compcode, string userid, string codebk)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bankdatadelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("codebk", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["codebk"].Value = codebk;


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
