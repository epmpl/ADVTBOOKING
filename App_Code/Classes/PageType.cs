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
//------------------------
/// <summary>
/// Summary description for PageType
/// </summary>
namespace NewAdbooking.Classes
{
    public class PageType : connection
    {
        public PageType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet pagedes(string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drppub", ref con);
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
         // public DataSet chkcode(string drppub,string pagetypecode,string pagename, string height, string width, string nocolumns, string compcode)
        public DataSet chkcode(string pagetypecode, string compcode)      
          {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("pgchkcode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                
                cmd.Parameters.Add("@pagetypecode", SqlDbType.VarChar);
                cmd.Parameters["@pagetypecode"].Value = pagetypecode;

                //cmd.Parameters.Add("@drppub", SqlDbType.VarChar);
                //cmd.Parameters["@drppub"].Value = drppub;

                //cmd.Parameters.Add("@pagename", SqlDbType.VarChar);
                //cmd.Parameters["@pagename"].Value = pagename;

                //cmd.Parameters.Add("@height", SqlDbType.VarChar);
                //cmd.Parameters["@height"].Value = height;

                //cmd.Parameters.Add("@width", SqlDbType.VarChar);
                //cmd.Parameters["@width"].Value = width;

                //cmd.Parameters.Add("@nocolumns", SqlDbType.VarChar);
                //cmd.Parameters["@nocolumns"].Value = nocolumns;

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
        public DataSet autocode(string str,string pubname)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("ptautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;


                cmd.Parameters.Add("@pubname", SqlDbType.VarChar);
                cmd.Parameters["@pubname"].Value = pubname;

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

        public DataSet insertedvalue(string drppub, string pagetypecode, string pagename, string height, string width, string nocolumns, string compcode, string userid)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("ptinsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@drppub", SqlDbType.VarChar);
               cmd.Parameters["@drppub"].Value = drppub;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@pagetypecode", SqlDbType.VarChar);
                cmd.Parameters["@pagetypecode"].Value = pagetypecode;

                cmd.Parameters.Add("@pagename", SqlDbType.VarChar);
                cmd.Parameters["@pagename"].Value = pagename;

                cmd.Parameters.Add("@height", SqlDbType.VarChar);
                cmd.Parameters["@height"].Value = height;

                cmd.Parameters.Add("@width", SqlDbType.VarChar);
                cmd.Parameters["@width"].Value = width;

                cmd.Parameters.Add("@nocolumns", SqlDbType.VarChar);
                cmd.Parameters["@nocolumns"].Value = nocolumns;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

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
        
        
        
        
        //e(exepublication, exepagetypecode, exepagename,                            exeheight, exewidth, execolumns, 


        public DataSet ptexecute(string drppub, string pagetypecode, string pagename, string height, string width, string nocolumns, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("ptexe", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@drppublication", SqlDbType.VarChar);
                cmd.Parameters["@drppublication"].Value = drppub;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@pagetypecode", SqlDbType.VarChar);
                cmd.Parameters["@pagetypecode"].Value = pagetypecode;

                cmd.Parameters.Add("@pagename", SqlDbType.VarChar);
                cmd.Parameters["@pagename"].Value = pagename;

                cmd.Parameters.Add("@height", SqlDbType.VarChar);
                cmd.Parameters["@height"].Value = height;

                cmd.Parameters.Add("@width", SqlDbType.VarChar);
                cmd.Parameters["@width"].Value = width;

                cmd.Parameters.Add("@nocolumns", SqlDbType.VarChar);
                cmd.Parameters["@nocolumns"].Value = nocolumns;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

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
        public DataSet ptdelete(string pagetypecode, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();
            try
            {
                con.Open();
                cmd = GetCommand("ptdel", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pagetypecode", SqlDbType.VarChar);
                cmd.Parameters["@pagetypecode"].Value = pagetypecode;

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
        public DataSet ptupdate(string drppub, string pagetypecode, string pagename, string height, string width, string nocolumns, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("ptmodify", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@drppublication", SqlDbType.VarChar);
                cmd.Parameters["@drppublication"].Value = drppub;

                cmd.Parameters.Add("@pagetypecode", SqlDbType.VarChar);
                cmd.Parameters["@pagetypecode"].Value = pagetypecode;

                cmd.Parameters.Add("@pagename", SqlDbType.VarChar);
                cmd.Parameters["@pagename"].Value = pagename;

                cmd.Parameters.Add("@height", SqlDbType.VarChar);
                cmd.Parameters["@height"].Value = height;

                cmd.Parameters.Add("@width", SqlDbType.VarChar);
                cmd.Parameters["@width"].Value = width;

                cmd.Parameters.Add("@nocolumns", SqlDbType.VarChar);
                cmd.Parameters["@nocolumns"].Value = nocolumns;


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
