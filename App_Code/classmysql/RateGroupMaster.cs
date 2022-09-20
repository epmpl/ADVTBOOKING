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
    /// Summary description for RateGroupMaster
    /// </summary>
    public class RateGroupMaster:connection
    {
        public RateGroupMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet ModifyValue(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RateGroupMastModify_RateGroupMastModify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;


                objmysqlcommand.Parameters.Add("RtGroupCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["RtGroupCode"].Value = RtGroupCode;

                objmysqlcommand.Parameters.Add("RtGroupName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["RtGroupName"].Value = RtGroupName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;



                objmysqlDataAdapter = new MySqlDataAdapter();
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet InsertValue(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RateGroupMasterInsert_RateGroupMasterInsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rtgroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rtgroupcode"].Value = userid;


                objmysqlcommand.Parameters.Add("rtgroupname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rtgroupname"].Value = RtGroupCode;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = RtGroupName;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = Alias;



                objmysqlDataAdapter = new MySqlDataAdapter();
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet SelectValue(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RateGroupMasterSelect_RateGroupMasterSelect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;


                objmysqlcommand.Parameters.Add("RtGroupCode", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["RtGroupCode"].Value = RtGroupCode;





                objmysqlcommand.Parameters.Add("RtGroupName", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["RtGroupName"].Value = RtGroupName;



                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;


                objmysqlDataAdapter = new MySqlDataAdapter();
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet Selectfnpl(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RateGroupMasterSelect_RateGroupMasterSelect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;



                objmysqlDataAdapter = new MySqlDataAdapter();
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet chkvalue(string RtGroupCode, string RtGroupName,string compcode,string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkrategroup_chkrategroup_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("rtgroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rtgroupcode"].Value = RtGroupCode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("rtgroupname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rtgroupname"].Value = RtGroupName;



                objmysqlDataAdapter = new MySqlDataAdapter();
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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
        public DataSet DeleteValue(string RtGroupCode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RateGroupMastDelete_RateGroupMastDelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("RtGroupCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["RtGroupCode"].Value = RtGroupCode;

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









        public DataSet chkrgroupcode1(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkrgname_chkrgname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2).ToString();


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