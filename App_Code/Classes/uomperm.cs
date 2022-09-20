using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
/// Summary description for uomperm
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class uomperm : connection
    {
        public uomperm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet uombind(string agencode, string agencysubcode, string comp, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binduomdata", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@comp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp"].Value = comp;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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
        public DataSet insertdata(string compcode, string userid, string uom, string category, string adtype, string agencode, string subagncode, string seq)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("uominsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = category;

                objSqlCommand.Parameters.Add("@seqno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno"].Value = seq;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@subagncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagncode"].Value = subagncode;


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
        public DataSet bankdata(string compcode, string userid, string agencode, string subagncode, string code10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("uomdataselect", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@subagncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagncode"].Value = subagncode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code10;


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

        public DataSet updatedata(string compcode, string userid, string uom, string category, string adtype, string agencode, string subagncode, string seq)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("uomdataupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@uomname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomname"].Value = uom;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = category;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@subagncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagncode"].Value = subagncode;

                objSqlCommand.Parameters.Add("@codebk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codebk"].Value = seq;


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


        public DataSet deletedata(string compcode, string userid, string codebk)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("uomdatadelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@codebk", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codebk"].Value = codebk;


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