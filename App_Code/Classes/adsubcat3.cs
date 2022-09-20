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

namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for adsubcat3
    /// </summary>
    public class adsubcat3 : connection
    {
        public adsubcat3()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getCat1(string cat1, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("getCat1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@cat2", SqlDbType.VarChar);
                com.Parameters["@cat2"].Value = cat1;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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
        public DataSet addcategory3name(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adsubcat", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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
        public DataSet savecat3(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string xml, string priority, string statusai, string ppubcenter, string sapcode, string statecode,string pub)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("cat3save", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;

                com.Parameters.Add("@catname", SqlDbType.VarChar);
                com.Parameters["@catname"].Value = catname;

                com.Parameters.Add("@catcode", SqlDbType.VarChar);
                com.Parameters["@catcode"].Value = catcode;

                com.Parameters.Add("@catalias", SqlDbType.VarChar);
                com.Parameters["@catalias"].Value = catalias;

                com.Parameters.Add("@xml", SqlDbType.VarChar);
                com.Parameters["@xml"].Value = xml;

                com.Parameters.Add("@prior", SqlDbType.VarChar);
                com.Parameters["@prior"].Value = priority;

                com.Parameters.Add("@status1", SqlDbType.VarChar);
                com.Parameters["@status1"].Value = statusai;

                com.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                com.Parameters["@ppubcenter"].Value = ppubcenter;

                com.Parameters.Add("@sapcode", SqlDbType.VarChar);
                com.Parameters["@sapcode"].Value = sapcode;

                com.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                com.Parameters["@pstatecode"].Value = statecode;

                com.Parameters.Add("@ppubname", SqlDbType.VarChar);
                com.Parameters["@ppubname"].Value = pub;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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

        public DataSet catmodify(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string xml, string ip, string priority, string statusai, string ppubcenter, string sapcode, string statecode,string pub)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("cat3_modify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;

                com.Parameters.Add("@catname", SqlDbType.VarChar);
                com.Parameters["@catname"].Value = catname;

                com.Parameters.Add("@catcode", SqlDbType.VarChar);
                com.Parameters["@catcode"].Value = catcode;

                com.Parameters.Add("@catalias", SqlDbType.VarChar);
                com.Parameters["@catalias"].Value = catalias;

                com.Parameters.Add("@xml", SqlDbType.VarChar);
                com.Parameters["@xml"].Value = xml;

                

                com.Parameters.Add("@prior", SqlDbType.VarChar);
                com.Parameters["@prior"].Value = priority;

                com.Parameters.Add("@status1", SqlDbType.VarChar);
                com.Parameters["@status1"].Value = statusai;

                com.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                com.Parameters["@ppubcenter"].Value = ppubcenter;


                com.Parameters.Add("@sapcode", SqlDbType.VarChar);
                com.Parameters["@sapcode"].Value = sapcode;

                com.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                com.Parameters["@pstatecode"].Value = statecode;

                com.Parameters.Add("@ppubname", SqlDbType.VarChar);
                com.Parameters["@ppubname"].Value = pub;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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
        public DataSet catfpnl()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("CATFPNL", ref con);
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
        public DataSet catdelete(string compcode, string catcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("CAT_DELETE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@catcode", SqlDbType.VarChar);
                com.Parameters["@catcode"].Value = catcode;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;


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
        public DataSet catdauto(string str, string subcatname, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("CAT_AUTO", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("@cod", SqlDbType.VarChar);
                if (str.Length > 2)
                {
                    com.Parameters["@cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    com.Parameters["@cod"].Value = str;
                }


                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;

                com.Parameters.Add("@compcode1", SqlDbType.VarChar);
                com.Parameters["@compcode1"].Value = compcode;

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


        public DataSet chkcatcod(string catcode, string subcatname, string catname, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("CATCHK", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@catcode", SqlDbType.VarChar);
                com.Parameters["@catcode"].Value = catcode;

                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;

                com.Parameters.Add("@catname", SqlDbType.VarChar);
                com.Parameters["@catname"].Value = catname;


                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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


        public DataSet catexecute1(string compcode, string subcatname, string catname, string catcode, string catalias, string xml, string ppubcenter, string statecode)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("CAT_EXE1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;


                com.Parameters.Add("@catname", SqlDbType.VarChar);
                com.Parameters["@catname"].Value = catname;

                com.Parameters.Add("@catcode", SqlDbType.VarChar);
                com.Parameters["@catcode"].Value = catcode;

                com.Parameters.Add("@catalias", SqlDbType.VarChar);
                com.Parameters["@catalias"].Value = catalias;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;


                com.Parameters.Add("@xml", SqlDbType.VarChar);
                com.Parameters["@xml"].Value = xml;

                com.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                com.Parameters["@pstatecode"].Value = statecode;


                //com.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                //com.Parameters["@ppubcenter"].Value = ppubcenter;


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
        public DataSet catnamechk(string str, string subcatname, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("cat_namechk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;

                com.Parameters.Add("@compcode1", SqlDbType.VarChar);
                com.Parameters["@compcode1"].Value = compcode;

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
        public DataSet pub_centbind(string compcode, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pubcent_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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