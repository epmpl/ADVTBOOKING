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
/// Summary description for BranchMaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class BrandMaster:connection
    {
        public BrandMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet productdes(string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpbrandproduct", ref con);
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
                cmd = GetCommand("chkbrandcode", ref con);
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
        public DataSet insertedvalue(string drpprosub, string brandcode, string brandname, string brandalias, string compcode, string userid,string productcat,string  productsubcat)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("brandinsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@brandcode", SqlDbType.VarChar);
                cmd.Parameters["@brandcode"].Value = brandcode;

                cmd.Parameters.Add("@brandname", SqlDbType.VarChar);
                cmd.Parameters["@brandname"].Value = brandname;

                cmd.Parameters.Add("@brandalias", SqlDbType.VarChar);
                cmd.Parameters["@brandalias"].Value = brandalias;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

                cmd.Parameters.Add("@drppro", SqlDbType.VarChar);
                cmd.Parameters["@drppro"].Value = drpprosub;

                cmd.Parameters.Add("@prodcategory", SqlDbType.VarChar);
                cmd.Parameters["@prodcategory"].Value = productcat;

                cmd.Parameters.Add("@prodsubcategory", SqlDbType.VarChar);
                cmd.Parameters["@prodsubcategory"].Value = productsubcat;


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
        public DataSet autocode(string str, string productcategory)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("brandautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

                cmd.Parameters.Add("@cat", SqlDbType.VarChar);
                cmd.Parameters["@cat"].Value = productcategory;

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
        public DataSet prosubexecute(string drpprodes, string brandcode, string brandname, string brandalias, string compcode,string productcat,string productsubcat)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("brandexe", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@drppro", SqlDbType.VarChar);
                cmd.Parameters["@drppro"].Value = drpprodes;

                cmd.Parameters.Add("@brandcode", SqlDbType.VarChar);
                cmd.Parameters["@brandcode"].Value = brandcode;

                cmd.Parameters.Add("@brandname", SqlDbType.VarChar);
                cmd.Parameters["@brandname"].Value = brandname;

                cmd.Parameters.Add("@brandalias", SqlDbType.VarChar);
                cmd.Parameters["@brandalias"].Value = brandalias;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@prodcategory", SqlDbType.VarChar);
                cmd.Parameters["@prodcategory"].Value = productcat;

                cmd.Parameters.Add("@prodsubcategory", SqlDbType.VarChar);
                cmd.Parameters["@prodsubcategory"].Value = productsubcat;

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
        public DataSet deleteproduct(string brandcode, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();
            try
            {
                con.Open();
                cmd = GetCommand("branddel", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@brandcode", SqlDbType.VarChar);
                cmd.Parameters["@brandcode"].Value = brandcode;

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
        public DataSet updatepro(string drpprodes, string brandcode, string brandname, string brandalias, string compcode,string productcat,string productsubcat)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("brandmodify", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@drppro", SqlDbType.VarChar);
                cmd.Parameters["@drppro"].Value = drpprodes;

                cmd.Parameters.Add("@brandcode", SqlDbType.VarChar);
                cmd.Parameters["@brandcode"].Value = brandcode;

                cmd.Parameters.Add("@brandname", SqlDbType.VarChar);
                cmd.Parameters["@brandname"].Value = brandname;

                cmd.Parameters.Add("@brandalias", SqlDbType.VarChar);
                cmd.Parameters["@brandalias"].Value = brandalias;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@prodcategory", SqlDbType.VarChar);
                cmd.Parameters["@prodcategory"].Value = productcat;

                cmd.Parameters.Add("@prodsubcategory", SqlDbType.VarChar);
                cmd.Parameters["@prodsubcategory"].Value = productsubcat;


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


        public DataSet prodcategory(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_PRODCATEGORY", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("Compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["Compcode"].Value = compcode;

                //  objSqlCommand.Parameters.Add("suppcode", SqlDbType.VarChar);
                // objSqlCommand.Parameters["suppcode"].Value = suppcode;



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


        public DataSet prodsubcategory( string prodcatcode,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_PRODSUBCATEGORY", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("Compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["Compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pro_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["pro_cat_code"].Value = prodcatcode;



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

        public DataSet product(string compcode, string prodcatcode, string prodsubcatcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_PRODUCT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("Compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["Compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pro_cat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["pro_cat_code"].Value = prodcatcode;

                objSqlCommand.Parameters.Add("pro_subcat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["pro_subcat_code"].Value = prodsubcatcode;



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
