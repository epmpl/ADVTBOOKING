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
/// Summary description for variable
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class variable : connection
    {
        public variable()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet variable_save(string Comp_Code, string variable_Code, string variable_Name, string variable_alias, string UserId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("variable_save", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = Comp_Code;


                objSqlCommand.Parameters.Add("@variable_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variable_Code"].Value = variable_Code;


                objSqlCommand.Parameters.Add("@variable_Name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variable_Name"].Value = variable_Name;


                objSqlCommand.Parameters.Add("@variable_alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variable_alias"].Value = variable_alias;



                objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                objSqlCommand.Parameters["@UserId"].Value = UserId;


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





        public DataSet variablemaster_modify(string Comp_Code, string variable_Code, string variable_Name, string variable_alias, string UserId)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_modifyvariable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = Comp_Code;


                objSqlCommand.Parameters.Add("@variable_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variable_Code"].Value = variable_Code;


                objSqlCommand.Parameters.Add("@variable_Name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variable_Name"].Value = variable_Name;


                objSqlCommand.Parameters.Add("@variable_alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variable_alias"].Value = variable_alias;



                //objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@UserId"].Value =UserId;


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



        public DataSet chkvariable(string compcode, string variablecode, string variablename, string alias, string username)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_executevariable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = compcode;


                objSqlCommand.Parameters.Add("@variablecode", SqlDbType.VarChar);
                //	if(regioncode != null && regioncode != ""  && regioncode != "undefined")
                objSqlCommand.Parameters["@variablecode"].Value = variablecode;
                //else
                //    objSqlCommand.Parameters["@regioncode"].Value ="%%";


                objSqlCommand.Parameters.Add("@variablename", SqlDbType.VarChar);
                //if(regionname != null && regionname != "" && regionname!= "undefined")
                objSqlCommand.Parameters["@variablename"].Value = variablename;
                //else
                //    objSqlCommand.Parameters["@regionname"].Value ="%%";


                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                //if(alias != null && alias != "" && alias!= "undefined")
                objSqlCommand.Parameters["@alias"].Value = alias;
                //else
                //    objSqlCommand.Parameters["@alias"].Value ="%%";



                //objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@UserId"].Value =username;
                //string str=objDataSet.Tables["region_mst"].Rows[0].ToString ();

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


        //********************************************************************************************************	

        //*******************************************************************************************************


        public DataSet btndelete(string compcode, string variablecode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("variabledelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;


                objSqlCommand.Parameters.Add("@variablecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variablecode"].Value = variablecode;



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


        public DataSet chkvariable_(string compcode, string variablename, string variablecode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkvariable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@variablename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variablename"].Value = variablename;

                objSqlCommand.Parameters.Add("@variablecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variablecode"].Value = variablecode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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
        public DataSet countvariablecode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkvariablecodename", ref objSqlConnection);
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
        //******************************************************************************************************
        public DataSet chknameforduplicate(string variablecode, string variablename, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkduplicatevariable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@variablecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variablecode"].Value = variablecode;

                objSqlCommand.Parameters.Add("@variablename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@variablename"].Value = variablename;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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
