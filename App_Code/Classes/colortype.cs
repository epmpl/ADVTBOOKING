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
/// Summary description for colortype
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class colortype:connection
    {
        public colortype()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /*new change ankur 15 feb*/
        public DataSet colortype_save(string Comp_Code, string colortypecode, string colortypename, string colortypealias, string UserId,string cat,string edit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("colortype_save", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = Comp_Code;


                objSqlCommand.Parameters.Add("@colortypecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypecode"].Value = colortypecode;


                objSqlCommand.Parameters.Add("@colortypename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypename"].Value = colortypename;


                objSqlCommand.Parameters.Add("@colortypealias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypealias"].Value = colortypealias;



                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;


                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = edit;



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




        /*new change ankur 15 feb*/
        public DataSet colortype_modify(string Comp_Code, string colortypecode, string colortypename, string colortypealias, string UserId,string cat,string edit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_modifycolortype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = Comp_Code;


                objSqlCommand.Parameters.Add("@colortypecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypecode"].Value = colortypecode;


                objSqlCommand.Parameters.Add("@colortypename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypename"].Value = colortypename;


                objSqlCommand.Parameters.Add("@colortypealias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypealias"].Value = colortypealias;



                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;



                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = edit;


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



        public DataSet chkcolortypeexecute(string compcode, string colortypecode, string colortypename, string alias, string username)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_executecolortype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Comp_Code"].Value = compcode;


                objSqlCommand.Parameters.Add("@colortypecode", SqlDbType.VarChar);
                //	if(regioncode != null && regioncode != ""  && regioncode != "undefined")
                objSqlCommand.Parameters["@colortypecode"].Value = colortypecode;
                //else
                //    objSqlCommand.Parameters["@regioncode"].Value ="%%";


                objSqlCommand.Parameters.Add("@colortypename", SqlDbType.VarChar);
                //if(regionname != null && regionname != "" && regionname!= "undefined")
                objSqlCommand.Parameters["@colortypename"].Value = colortypename;
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


        public DataSet btndelete(string compcode, string colortypecode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("colortypedelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;


                objSqlCommand.Parameters.Add("@colortypecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypecode"].Value = colortypecode;



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

        /*new change ankur 15 feb*/
        public DataSet chkcolortype(string compcode, string colortypename, string colortypecode, string userid,string cat,string edit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcolortype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@colortypename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypename"].Value = colortypename;

                objSqlCommand.Parameters.Add("@colortypecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypecode"].Value = colortypecode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;

                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = edit;


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
        public DataSet countcolortypecode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcolortypename", ref objSqlConnection);
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
        public DataSet chknameforduplicate(string colortypecode, string colortypename, string compcode,string cat,string edit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkduplicatecolortype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@colortypecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypecode"].Value = colortypecode;

                objSqlCommand.Parameters.Add("@colortypename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colortypename"].Value = colortypename;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;


                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = edit;

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
