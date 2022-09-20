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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.Classes
{

    public class Disc_master : connection
    {
        public Disc_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }
///****************************************START PROCEDURE***************************************************///
        public DataSet countcode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("discchkcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                if (str.Length > 2)
                {

                    objSqlCommand.Parameters["@cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objSqlCommand.Parameters["@cod"].Value = str;
                }
                //objSqlCommand.Parameters["@cod"].Value = userid;


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
        public DataSet chkduplicate(string compcode, string disccode, string discdes, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("discchk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@disccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disccode"].Value = disccode;

                objSqlCommand.Parameters.Add("@discdes", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discdes"].Value = discdes;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;

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
public DataSet savedata(string compcode, string disccode, string discdes, string adtype1, string status1, string disctyp, string discprm, string userid1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("discsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@disccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disccode"].Value = disccode;

                objSqlCommand.Parameters.Add("@discdes", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discdes"].Value = discdes;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status1;

                objSqlCommand.Parameters.Add("@disctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disctyp"].Value = disctyp;

                objSqlCommand.Parameters.Add("@discprm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discprm"].Value = discprm;

                objSqlCommand.Parameters.Add("@userid1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid1"].Value = userid1;

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
public DataSet updatedata(string compcode, string disccode, string adtype1, string status1, string disctyp, string discprm)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("discupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@disccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disccode"].Value = disccode;

                //objSqlCommand.Parameters.Add("@discdes", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@discdes"].Value = discdes;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

                objSqlCommand.Parameters.Add("@status1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status1"].Value = status1;

                objSqlCommand.Parameters.Add("@disctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disctyp"].Value = disctyp;

                objSqlCommand.Parameters.Add("@discprm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discprm"].Value = discprm;

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
public DataSet exec(string compcode, string disccode, string disdes, string adtyp, string stat, string disctyp, string disprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("discexec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@disccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disccode"].Value = disccode;

                objSqlCommand.Parameters.Add("@disdes", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disdes"].Value = disdes;

                objSqlCommand.Parameters.Add("@adtyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtyp"].Value = adtyp;

                objSqlCommand.Parameters.Add("@stat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stat"].Value = stat;

                objSqlCommand.Parameters.Add("@disctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disctyp"].Value = disctyp;

                objSqlCommand.Parameters.Add("@disprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disprem"].Value = disprem;

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
public DataSet del(string compcode, string disccode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("discdel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@disccode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disccode"].Value = disccode;

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
