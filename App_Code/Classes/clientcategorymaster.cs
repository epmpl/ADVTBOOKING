using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for clientcategorymaster
/// </summary>
namespace NewAdbooking.Classes
{
    public class clientcategorymaster : connection
    {

        public clientcategorymaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
/********************************************************************************************************/

        public DataSet checkccmcode(string code, string compcode, string userid,string name)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkclientcatmaster", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;



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
/**********************************************************************************************************/


        public DataSet countccmcode(string str)
        {
                SqlConnection objSqlConnection;
                SqlCommand objSqlCommand;
                objSqlConnection = GetConnection();
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
                DataSet objDataSet = new DataSet();
                try
                {
                    objSqlConnection.Open();
                    objSqlCommand = GetCommand("chkclientcatmastcodename", ref objSqlConnection);
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
/********************************************************************************************************/
        public DataSet insertclientcatmast(string ccmcode, string ccmname, string ccmalias, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertccm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@clientcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatcode"].Value = ccmcode;

                objSqlCommand.Parameters.Add("@clientcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatname"].Value = ccmname;


                objSqlCommand.Parameters.Add("@clientcatalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatalias"].Value =ccmalias;

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
/******************************************************************************************************/
        public DataSet updaetccmcode(string ccmcode, string ccmname, string ccmalias, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateccm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@clientcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatcode"].Value = ccmcode;

                objSqlCommand.Parameters.Add("@clientcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatname"].Value = ccmname;


                objSqlCommand.Parameters.Add("@clientcatalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatalias"].Value = ccmalias;




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

/******************************************************************************************************/
        public DataSet executeccm(string ccmcode, string ccmname, string ccmalias, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executeccm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@clientcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatcode"].Value = ccmcode;

                objSqlCommand.Parameters.Add("@clientcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatname"].Value = ccmname;


                objSqlCommand.Parameters.Add("@clientcatalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatalias"].Value = ccmalias;

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

/*****************************************************************************************************/
        public DataSet firstquery()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("firstccm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


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
/*******************************************************************************************************/
        public DataSet deleteit(string ccmcode, string ccmcompcode, string ccmuserid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteccm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = ccmcompcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = ccmuserid;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = ccmcode;

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


        public DataSet chknameforduplicate(string ccmcode, string name, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkduplicatename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ccmcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ccmcode"].Value = ccmcode;


                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;

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
/****************************************************************************************************/
   }
}
