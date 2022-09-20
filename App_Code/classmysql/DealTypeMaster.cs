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
    /// Summary description for DealTypeMaster
    /// </summary>
    public class DealTypeMaster:connection
    {
        public DealTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet savedeal(string companycode, string userid, string dealcode, string dealname, string dealalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DealType_SAVE", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("dealalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealalias"].Value = dealalias;

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

        //Modify//
        public DataSet dealupdate(string companycode, string userid, string dealcode, string dealname, string dealalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DealType_MODIFY", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("dealalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealalias"].Value = dealalias;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

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
        //Delete//
        public DataSet deletedeal(string companycode, string dealcode, string userid)//, string dealname, string dealalias, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DealType_DELETE", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

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

        //Execute//
        public DataSet execute(string companycode, string dealcode, string dealname, string dealalias)//, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DealExecute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("dealalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealalias"].Value = dealalias;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

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
        //AutoGeneratedCode//
        public DataSet countdealcode(string str /*,string cod*/)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdealcodename", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str.Substring(0,2).ToString();


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

        //public DataSet dealfpnl()
        //{
        //    SqlConnection objmysqlconnection;
        //    SqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("dealfpnl", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objmysqlconnection);
        //    }
        //}



        public DataSet chkdealcode(string companycode, string userid, string dealcode,string dealname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("dealchk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

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
