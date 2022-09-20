using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for Materiallog
    /// </summary>
    public class Materiallog:connection
    {
        public Materiallog()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet MastPrevDisp(string compcode, string userid, string userhome, string admin, string retainer)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_ModultPrevDisp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@userhome", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userhome"].Value = userhome;

                objSqlCommand.Parameters.Add("@admin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@admin"].Value = admin;

                objSqlCommand.Parameters.Add("@retainer_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer_code"].Value = retainer;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet pub_centbind(string compcode, string useid, string chk_acc)
        {
            //SqlConnection objSqlConnection;
            //SqlCommand objSqlCommand;
            //objSqlConnection = GetConnection();
            //SqlDataAdapter objSqlDataAdapter;
            //DataSet objDataSet = new DataSet();
            //try
            //{
            //    objSqlConnection.Open();
            //    objSqlCommand = GetCommand("pubcent_proc", ref objSqlConnection);
            //    objSqlCommand.CommandType = CommandType.StoredProcedure;


            //    objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
            //    objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

            //    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            //    objSqlCommand.Parameters["@compcode"].Value = compcode;

            //    objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
            //    objSqlCommand.Parameters["@puserid"].Value = useid;

            //    objSqlDataAdapter = new SqlDataAdapter();
            //    objSqlDataAdapter.SelectCommand = objSqlCommand;
            //    objSqlDataAdapter.Fill(objDataSet);
            //    return objDataSet;


            //}
            //catch (SqlException objException)
            //{
            //    throw (objException);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            //finally
            //{
            //    CloseConnection(ref objSqlConnection);
            //}

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }


        public DataSet getdata(string pubdate, string pubcenter, string user, string extra1, string extra2, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_rep_material_log", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pinsdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pinsdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@pcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@pusername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pusername"].Value = user;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }



    }
}