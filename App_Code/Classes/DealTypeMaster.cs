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
/// Summary description for DealTypeMaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class DealTypeMaster:connection 
     {
        public DealTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Save//
        public DataSet savedeal(string companycode, string userid, string dealcode, string dealname, string dealalias)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("DealType_SAVE", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode",SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = companycode;

                cmd.Parameters.Add("@userid",SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

                cmd.Parameters.Add("@dealcode",SqlDbType.VarChar);
                cmd.Parameters["@dealcode"].Value = dealcode;

                cmd.Parameters.Add("@dealname", SqlDbType.VarChar);
                cmd.Parameters["@dealname"].Value = dealname;

                cmd.Parameters.Add("@dealalias",SqlDbType.VarChar);
                cmd.Parameters["@dealalias"].Value = dealalias;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;


            }

            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref con);
            
            }
                    
        
        }

        //Modify//
        public DataSet dealupdate(string companycode, string userid, string dealcode, string dealname, string dealalias)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("DealType_MODIFY", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@dealcode", SqlDbType.VarChar);
                com.Parameters["@dealcode"].Value = dealcode;

                com.Parameters.Add("@dealname", SqlDbType.VarChar);
                com.Parameters["@dealname"].Value = dealname;

                com.Parameters.Add("@dealalias", SqlDbType.VarChar);
                com.Parameters["@dealalias"].Value = dealalias;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        //Delete//
        public DataSet deletedeal(string companycode, string dealcode, string userid)//, string dealname, string dealalias, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("DealType_DELETE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Compcode", SqlDbType.VarChar);
                com.Parameters["@Compcode"].Value = companycode;

                com.Parameters.Add("@dealcode", SqlDbType.VarChar);
                com.Parameters["@dealcode"].Value = dealcode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        //Execute//
        public DataSet execute(string companycode, string dealcode, string dealname, string dealalias)//, string userid)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("DealExecute", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@dealcode", SqlDbType.VarChar);
                com.Parameters["@dealcode"].Value = dealcode;

                com.Parameters.Add("@dealname", SqlDbType.VarChar);
                com.Parameters["@dealname"].Value = dealname;
                
                com.Parameters.Add("@dealalias", SqlDbType.VarChar);
                com.Parameters["@dealalias"].Value = dealalias;
                
                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        //AutoGeneratedCode//
        public DataSet countdealcode(string str /*,string cod*/)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdealcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;


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

        //public DataSet dealfpnl()
        //{
        //    SqlConnection con;
        //    SqlCommand com;
        //    con = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con.Open();
        //        com = GetCommand("dealfpnl", ref con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        da.SelectCommand = com;
        //        da.Fill(ds);
        //        return ds;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }
        //}



        public DataSet chkdealcode(string companycode, string userid, string dealcode, string dealname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("dealchk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@dealcode", SqlDbType.VarChar);
                com.Parameters["@dealcode"].Value = dealcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@dealname", SqlDbType.VarChar);
                com.Parameters["@dealname"].Value = dealname;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        
     }
}
