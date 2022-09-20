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
/// Summary description for product_subsub_category
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class product_subsub_category:connection 
    {
        public product_subsub_category()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Bind The Drop down
        public DataSet productdes( string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpproductselect", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;


                da.SelectCommand = cmd;
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

        public DataSet productsubdes( string compcode,string prosubsubcode )
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpsubproductselect", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = prosubsubcode;

                da.SelectCommand = cmd;
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
        //     Check code
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
                cmd = GetCommand("productsubcatcode", ref con);
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
     
        public DataSet insertedvalue(string drpprosub, string drpprosubsub, string prosubsubcode, string prosubsubname, string proalias, string compcode, string userid)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("productsubsubinsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

                cmd.Parameters.Add("@procatcode", SqlDbType.VarChar);
                cmd.Parameters["@procatcode"].Value = drpprosub;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = drpprosubsub;

                cmd.Parameters.Add("@prosubsubname", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubname"].Value = prosubsubname;

                cmd.Parameters.Add("@alias", SqlDbType.VarChar);
                cmd.Parameters["@alias"].Value = proalias;

                cmd.Parameters.Add("@prosubsubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubcode"].Value = prosubsubcode;

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
                cmd = GetCommand("productsubsubautocode", ref con);
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

        public DataSet prosubexecute(string drpprosub, string drpsubprodu, string prosubsubcode, string prosubsubname, string proalias, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();

            try
            {


                con.Open();
                cmd = GetCommand("productsubsubexe", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@procatcode", SqlDbType.VarChar);
                cmd.Parameters["@procatcode"].Value = drpprosub;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = drpsubprodu;

                cmd.Parameters.Add("@prosubsubname", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubname"].Value = prosubsubname;

                cmd.Parameters.Add("@alias", SqlDbType.VarChar);
                cmd.Parameters["@alias"].Value = proalias;

                cmd.Parameters.Add("@prosubsubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubcode"].Value = prosubsubcode;

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
        public DataSet deleteproduct(string prosubsubcode, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();
            try
            {


                con.Open();
                cmd = GetCommand("productsubsubdel", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@prosubsubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubcode"].Value = prosubsubcode;

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
        public DataSet updatepro(string drpprosub,string drpprosubsub, string prosubsubcode, string prosubsubname, string proalias, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("productsubsubmodify", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@procatcode", SqlDbType.VarChar);
                cmd.Parameters["@procatcode"].Value = drpprosub;

                cmd.Parameters.Add("@prosubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubcode"].Value = drpprosubsub;

                cmd.Parameters.Add("@prosubsubname", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubname"].Value = prosubsubname;

                cmd.Parameters.Add("@alias", SqlDbType.VarChar);
                cmd.Parameters["@alias"].Value = proalias;

                cmd.Parameters.Add("@prosubsubcode", SqlDbType.VarChar);
                cmd.Parameters["@prosubsubcode"].Value = prosubsubcode;

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