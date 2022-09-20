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
/// Summary description for BillStatus
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class BillStatus : connection
    {
        public BillStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public DataSet billsave1(string companycode, string billid, string billstatus, string billalias, string UserId)
        public DataSet billsave1(string billid, string billstatus, string billalias)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILL_SAVE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@compcode", SqlDbType.VarChar);
                //com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@billid", SqlDbType.VarChar);
                com.Parameters["@billid"].Value = billid;

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                com.Parameters["@billstatus"].Value = billstatus;

                com.Parameters.Add("@billalias", SqlDbType.VarChar);
                com.Parameters["@billalias"].Value = billalias;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = UserId;

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
         //public DataSet billmodify(string companycode, string billid, string billstatus, string billalias, string UserId)

        public DataSet billmodify(string billid, string billstatus, string billalias)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILL_MODIFY", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@compcode", SqlDbType.VarChar);
                //com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@billid", SqlDbType.VarChar);
                com.Parameters["@billid"].Value = billid;

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                com.Parameters["@billstatus"].Value = billstatus;

                com.Parameters.Add("@billalias", SqlDbType.VarChar);
                com.Parameters["@billalias"].Value = billalias;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = UserId;

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

        //public DataSet chkbillid(string companycode, string UserId, string billid)
        public DataSet chkbillid(string billid,string billstatus, string mod)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILLCHK", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@compcode", SqlDbType.VarChar);
                //com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@billid", SqlDbType.VarChar);
                com.Parameters["@billid"].Value = billid;

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                com.Parameters["@billstatus"].Value = billstatus;

                com.Parameters.Add("@mod", SqlDbType.VarChar);
                com.Parameters["@mod"].Value = mod;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = UserId;

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

       // public DataSet billexecute1(string companycode, string zonecode, string zonename, string alias, string UserId)
       public DataSet billexecute1(string billid, string billstatus, string billalias)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILL_EXE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                //com.Parameters["@Comp_Code"].Value = companycode;

                com.Parameters.Add("@bill_id", SqlDbType.VarChar);

                com.Parameters["@bill_id"].Value = billid;


                com.Parameters.Add("@billstatus", SqlDbType.VarChar);

                com.Parameters["@billstatus"].Value = billstatus;


                com.Parameters.Add("@billalias", SqlDbType.VarChar);

                com.Parameters["@billalias"].Value = billalias;
                

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


        public DataSet billfpnl()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILLFPNL", ref con);
                com.CommandType = CommandType.StoredProcedure;

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


        public DataSet billdelete(string billid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILL_DELETE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                //com.Parameters["@Comp_Code"].Value = companycode;

                com.Parameters.Add("@billid", SqlDbType.VarChar);
                com.Parameters["@billid"].Value = billid;

                //com.Parameters.Add("@Zone_Name", SqlDbType.VarChar);
                //com.Parameters["@Zone_Name"].Value = zonename;

                //com.Parameters.Add("@Zone_Alias", SqlDbType.VarChar);
                //com.Parameters["@Zone_Alias"].Value = alias;

                //com.Parameters.Add("@UserId", SqlDbType.VarChar);
                //com.Parameters["@UserId"].Value = UserId;

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


        public DataSet billexecute2(string billid, string billstatus, string billalias)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BILL_EXE", ref con);
                com.CommandType = CommandType.StoredProcedure;

               

                com.Parameters.Add("@billid", SqlDbType.VarChar);

                com.Parameters["@billid"].Value = billid;

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);

                com.Parameters["@billstatus"].Value = billstatus;


                com.Parameters.Add("@billalias", SqlDbType.VarChar);

                com.Parameters["@billalias"].Value = billalias;
               
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


        public DataSet billidauto(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BILL_AUTO", ref objSqlConnection);
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









    }
}
