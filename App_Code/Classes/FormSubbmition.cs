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
/// Summary description for FormSubbmition
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class FormSubbmition:connection 
    {
        public FormSubbmition()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet formcheck(string code, string compcode)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("forminsertchk", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@formcode", SqlDbType.VarChar);
                cmd.Parameters["@formcode"].Value = code;


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

        public DataSet forminsert(string compcode, string code, string name, string alias, string userid, string formtype, string modulecod)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("forminsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@formcode", SqlDbType.VarChar);
                cmd.Parameters["@formcode"].Value = code;

                cmd.Parameters.Add("@formname", SqlDbType.VarChar);
                cmd.Parameters["@formname"].Value = name;

                cmd.Parameters.Add("@formalias", SqlDbType.VarChar);
                cmd.Parameters["@formalias"].Value = alias;

                cmd.Parameters.Add("@formtype1", SqlDbType.VarChar);
                cmd.Parameters["@formtype1"].Value = formtype;

                cmd.Parameters.Add("@modulecod", SqlDbType.VarChar);
                cmd.Parameters["@modulecod"].Value = modulecod;

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
        /*  public DataSet forminsert(string compcode, string code, string name, string alias, string userid, string formtype, string modulecod)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("forminsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@formcode", SqlDbType.VarChar);
                cmd.Parameters["@formcode"].Value = code;

                cmd.Parameters.Add("@formname", SqlDbType.VarChar);
                cmd.Parameters["@formname"].Value = name;

                cmd.Parameters.Add("@formalias", SqlDbType.VarChar);
                cmd.Parameters["@formalias"].Value = alias;

                cmd.Parameters.Add("@formtype1", SqlDbType.VarChar);
                cmd.Parameters["@formtype1"].Value = formtype;

                cmd.Parameters.Add("@modulecod", SqlDbType.VarChar);
                 cmd.Parameters["@modulecod"].Value = forminsert;

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
        */
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
                cmd = GetCommand("forminsertautocode", ref con);
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

//=====================================================NEw================
        public DataSet execform(string compcode, string formtyp, string modulecode, string frmcode, string frmname, string frmalias)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("formexec", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@formcode", SqlDbType.VarChar);
                cmd.Parameters["@formcode"].Value = frmcode;

                cmd.Parameters.Add("@formname", SqlDbType.VarChar);
                cmd.Parameters["@formname"].Value = frmname;

                cmd.Parameters.Add("@formalias", SqlDbType.VarChar);
                cmd.Parameters["@formalias"].Value = frmalias;

                cmd.Parameters.Add("@formtype1", SqlDbType.VarChar);
                cmd.Parameters["@formtype1"].Value = formtyp;

                cmd.Parameters.Add("@modulecod", SqlDbType.VarChar);
                cmd.Parameters["@modulecod"].Value = modulecode;

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
        public DataSet delform(string compcode, string frmcode)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("formdel", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@formcode", SqlDbType.VarChar);
                cmd.Parameters["@formcode"].Value = frmcode;

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
        public DataSet modifydata(string compcode, string formtyp, string modulecode, string frmcode, string frmname, string frmalias)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("formupdate", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@formcode", SqlDbType.VarChar);
                cmd.Parameters["@formcode"].Value = frmcode;

                cmd.Parameters.Add("@formname", SqlDbType.VarChar);
                cmd.Parameters["@formname"].Value = frmname;

                cmd.Parameters.Add("@formalias", SqlDbType.VarChar);
                cmd.Parameters["@formalias"].Value = frmalias;

                cmd.Parameters.Add("@formtype1", SqlDbType.VarChar);
                cmd.Parameters["@formtype1"].Value = formtyp;

                cmd.Parameters.Add("@modulecod", SqlDbType.VarChar);
                cmd.Parameters["@modulecod"].Value = modulecode;

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
