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
    /// Summary description for AdSubCat5
    /// </summary>
    public class AdSubCat5:connection
    {
        public AdSubCat5()
        {
            //
            // TODO: Add constructor logic here
            //
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
                com = GetCommand("Ad_Cat5", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;

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
        public DataSet savecat4(string compcode, string subcatname, string catname, string catcode, string catalias, string userid,string sales_org)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat5_Save", ref con);
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


                com.Parameters.Add("@salesorg", SqlDbType.VarChar);
                com.Parameters["@salesorg"].Value = sales_org;
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

        public DataSet catmodify(string compcode, string subcatname, string catname, string catcode, string catalias, string userid,string salesorg)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat5_Modify", ref con);
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



                com.Parameters.Add("@sales_org", SqlDbType.VarChar);
                com.Parameters["@sales_org"].Value = salesorg;

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
                com = GetCommand("Cat5_FPNL", ref con);
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
                com = GetCommand("Cat5_Delete", ref con);
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
        public DataSet catdauto(string str, string subcatname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat5_Auto", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("@cod", SqlDbType.VarChar);
                com.Parameters["@cod"].Value = str;

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


        public DataSet chkcatcod(string catcode, string subcatname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat5_Chk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Cat_Code", SqlDbType.VarChar);
                com.Parameters["@Cat_Code"].Value = catcode;

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


        public DataSet catexecute1(string compcode, string subcatname, string catcode, string catname, string catalias, string userid)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Cat5_Exe1", ref con);
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
