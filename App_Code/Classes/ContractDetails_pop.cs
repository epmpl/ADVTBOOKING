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

/// <summary>
/// Summary description for ContractDetails_pop
/// </summary>
namespace NewAdbooking.Classes
{
    public class ContractDetails_pop : connection 
    {
        public ContractDetails_pop()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet contactseq()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cntct_info_SEQ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet saveinfo(string seq, string comcode, string pucode, string cntctname, string cntctno, string desc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("save_cntct_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pucode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pucode"].Value = pucode;

                objSqlCommand.Parameters.Add("@cntctnm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cntctnm"].Value = cntctname;

                objSqlCommand.Parameters.Add("@cntctno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cntctno"].Value = cntctno;

                objSqlCommand.Parameters.Add("@descrptn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descrptn"].Value = desc;

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

        public DataSet saveinfomain(string seq, string comcode, string pucode, string cntctname, string cntctno, string desc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("save_cntct_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pucode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pucode"].Value = pucode;

                objSqlCommand.Parameters.Add("@cntctnm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cntctnm"].Value = cntctname;

                objSqlCommand.Parameters.Add("@cntctno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cntctno"].Value = cntctno;

                objSqlCommand.Parameters.Add("@descrptn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descrptn"].Value = desc;

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

        public DataSet qryinfo(string comcode, string pucode, string text)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("query_cntct_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcode"].Value = pucode;

                objSqlCommand.Parameters.Add("@ptxt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptxt"].Value = text;


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

        public DataSet updateinfo(string seq, string comcode, string pucode, string cntctname, string cntctno, string desc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("update_cntct_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@pucode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pucode"].Value = pucode;

                objSqlCommand.Parameters.Add("@cntctnm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cntctnm"].Value = cntctname;

                objSqlCommand.Parameters.Add("@cntctno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cntctno"].Value = cntctno;

                objSqlCommand.Parameters.Add("@descrptn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descrptn"].Value = desc;

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

        public DataSet deleteinfo(string seq, string comcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("delete_cntct_main", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

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

        public DataSet gridtxt(string comcode, string seq)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fill_grid_txt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cmcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@seq", SqlDbType.Int);
                objSqlCommand.Parameters["@seq"].Value = seq;                

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
