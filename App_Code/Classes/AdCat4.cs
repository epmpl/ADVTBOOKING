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
    /// Summary description for AdCat4
    /// </summary>
    public class AdCat4:connection
    {
        public AdCat4()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet addcategorynameALL(string adtype, string cat3)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adcategoryAll", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;

                com.Parameters.Add("@cat3", SqlDbType.VarChar);
                com.Parameters["@cat3"].Value = cat3;

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
        public DataSet addcategoryname3(string adsubcategory)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("advsubsubcategory", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                com.Parameters["@adsubcategory"].Value = adsubcategory;

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

        public DataSet addcategoryname1(string adtype,string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adcategory", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;

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
        public DataSet addcategoryname2(string adcat, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("advsubcategory", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adcategory", SqlDbType.VarChar);
                com.Parameters["@adcategory"].Value = adcat;

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

        public DataSet addcategoryname(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Ad_Cat4", ref con);
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
        public DataSet savecat4(string compcode, string subcatname, string catname, string catcode, string catalias, string userid,string pubcenter,string sapcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat4_Save", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;

                com.Parameters.Add("@Sub_Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Sub_Cat_Name"].Value = subcatname;

                com.Parameters.Add("@Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Cat_Name"].Value = catname;

                com.Parameters.Add("@Cat_Code", SqlDbType.VarChar);
                com.Parameters["@Cat_Code"].Value = catcode;

                com.Parameters.Add("@Cat_Alias", SqlDbType.VarChar);
                com.Parameters["@Cat_Alias"].Value = catalias;

                com.Parameters.Add("@userId", SqlDbType.VarChar);
                com.Parameters["@userId"].Value = userid;

                com.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                com.Parameters["@pubcenter"].Value = pubcenter;

                com.Parameters.Add("@sapcode", SqlDbType.VarChar);
                com.Parameters["@sapcode"].Value = sapcode;
                com.Parameters.Add("@pubcode", SqlDbType.VarChar);
                com.Parameters["@pubcode"].Value = System.DBNull.Value;

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

        public DataSet catmodify(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string ppubcenter,string sapcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat4_Modify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;


                com.Parameters.Add("@Sub_Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Sub_Cat_Name"].Value = subcatname;

                com.Parameters.Add("@Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Cat_Name"].Value = catname;

                com.Parameters.Add("@Cat_Code", SqlDbType.VarChar);
                com.Parameters["@Cat_Code"].Value = catcode;

                com.Parameters.Add("@Cat_Alias", SqlDbType.VarChar);
                com.Parameters["@Cat_Alias"].Value = catalias;

                com.Parameters.Add("@userId", SqlDbType.VarChar);
                com.Parameters["@userId"].Value = userid;

                com.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                com.Parameters["@ppubcenter"].Value = ppubcenter;

                com.Parameters.Add("@sapcode", SqlDbType.VarChar);
                com.Parameters["@sapcode"].Value = sapcode;
                com.Parameters.Add("@pubcode", SqlDbType.VarChar);
                com.Parameters["@pubcode"].Value = System.DBNull.Value;

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
                com = GetCommand("Cat_FPNL", ref con);
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
        public DataSet catdelete(string catcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat4_Delete", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Cat_Code", SqlDbType.VarChar);
                com.Parameters["@Cat_Code"].Value = catcode;


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
        public DataSet catdauto(string str, string cat3code)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat4_Auto", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("@cod", SqlDbType.VarChar);
                com.Parameters["@cod"].Value = str;

                com.Parameters.Add("@Sub_Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Sub_Cat_Name"].Value = cat3code;


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


        public DataSet chkcatcod(string catcode,string catname, string subcatname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat4_Chk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Cat_Code", SqlDbType.VarChar);
                com.Parameters["@Cat_Code"].Value = catcode;

                com.Parameters.Add("@catname", SqlDbType.VarChar);
                com.Parameters["@catname"].Value = catname;

                com.Parameters.Add("@subcatname", SqlDbType.VarChar);
                com.Parameters["@subcatname"].Value = subcatname;

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


        public DataSet catexecute1(string compcode, string subcatname, string catname, string catcode, string catalias, string userid)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat4_Exe1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;

                com.Parameters.Add("@Sub_Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Sub_Cat_Name"].Value = subcatname;


                com.Parameters.Add("@Cat_Name", SqlDbType.VarChar);
                com.Parameters["@Cat_Name"].Value = catname;

                com.Parameters.Add("@Cat_Code", SqlDbType.VarChar);
                com.Parameters["@Cat_Code"].Value = catcode;

                com.Parameters.Add("@Cat_Alias", SqlDbType.VarChar);
                com.Parameters["@Cat_Alias"].Value = catalias;

                com.Parameters.Add("@userId", SqlDbType.VarChar);
                com.Parameters["@userId"].Value = userid;


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
