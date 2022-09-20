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
/// Summary description for productsubcategory
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class productsubcategory : connection
    {
        public productsubcategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Bind The Drop down
        public DataSet productdes(string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds= new DataSet();
            SqlDataAdapter da= new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpsubproduct", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;


                da.SelectCommand=cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        //Check code
        public DataSet chkcode(string code, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("productsubcode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@code", SqlDbType.VarChar);
                cmd.Parameters["@code"].Value = code;


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
        //Insert the value
        public DataSet insertedvalue(string drpprosub, string prosubcode, string prosubname, string proalias, string compcode, string userid)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("productsubinsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = prosubcode;

                cmd.Parameters.Add("@prosubname", SqlDbType.VarChar);
                cmd.Parameters["@prosubname"].Value = prosubname;

                cmd.Parameters.Add("@alias", SqlDbType.VarChar);
                cmd.Parameters["@alias"].Value = proalias;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

                cmd.Parameters.Add("@drppro", SqlDbType.VarChar);
                cmd.Parameters["@drppro"].Value = drpprosub;


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

        //Auto generated code
        public DataSet autocode(string str)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("productsubautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

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

        //Execute Value
        public DataSet prosubexecute(string drpprodes, string prosubcode, string prosubname, string prosubalias, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("productsubexe", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@drpproduct", SqlDbType.VarChar);
                cmd.Parameters["@drpproduct"].Value = drpprodes;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = prosubcode;

                cmd.Parameters.Add("@prosubname", SqlDbType.VarChar);
                cmd.Parameters["@prosubname"].Value = prosubname;

                cmd.Parameters.Add("@prosubalias", SqlDbType.VarChar);
                cmd.Parameters["@prosubalias"].Value = prosubalias;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

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

        //Delete The Value
        public DataSet deleteproduct(string prosubcode, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();
            try
            {
                con.Open();
                cmd = GetCommand("productsubdel", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = prosubcode;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

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

        //Modify The Value
        public DataSet updatepro(string drpprodes, string prosubcode, string prosubname, string prosubalias, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("productsubmodify", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@drpproduct", SqlDbType.VarChar);
                cmd.Parameters["@drpproduct"].Value = drpprodes;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = prosubcode;

                cmd.Parameters.Add("@prosubname", SqlDbType.VarChar);
                cmd.Parameters["@prosubname"].Value = prosubname;

                cmd.Parameters.Add("@prosubalias", SqlDbType.VarChar);
                cmd.Parameters["@prosubalias"].Value = prosubalias;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;


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
        

    }
}