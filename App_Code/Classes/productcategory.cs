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
/// Summary description for productcategory
/// </summary>

namespace NewAdbooking.Classes
{
    public class productcategory:connection
    {
        public productcategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet chkcode(string code,string desc,string incode,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkproductcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@desc"].Value = desc;


                objSqlCommand.Parameters.Add("@incode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@incode"].Value = incode;



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

        public DataSet insertedvalue(string productcode,string productdescription,string alias, string compcode,string userid,string industry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertproductcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@productcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productcode"].Value = productcode;

                objSqlCommand.Parameters.Add("@productdescription", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productdescription"].Value = productdescription;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@industry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@industry"].Value = industry;

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

        public DataSet updatepro(string productcode, string productdescription, string alias, string compcode, string userid,string industry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateproductcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@productcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productcode"].Value = productcode;

                objSqlCommand.Parameters.Add("@productdescription", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productdescription"].Value = productdescription;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlCommand.Parameters.Add("@industry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@industry"].Value = industry;


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

        public DataSet executequery(string productcode, string alias, string productdescription, string compcode,string industry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executeprocat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@productcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productcode"].Value = productcode;

                objSqlCommand.Parameters.Add("@productdescription", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productdescription"].Value = productdescription;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@industry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@industry"].Value = industry;

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


        public DataSet deleteproduct(string code,  string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("deleteproduct", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@productcode", SqlDbType.VarChar);
                cmd.Parameters["@productcode"].Value = code;

                //cmd.Parameters.Add("@productdescription", SqlDbType.VarChar);
                //cmd.Parameters["@productdescription"].Value = name;

                //cmd.Parameters.Add("@alias", SqlDbType.VarChar);
                //cmd.Parameters["@alias"].Value = alias;

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
        public DataSet bind_industry(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_Ind_Name", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet autocode(string str,string indus)
        { 
               SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("productautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

                cmd.Parameters.Add("@indus", SqlDbType.VarChar);
                cmd.Parameters["@indus"].Value = indus;

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
