using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for colortype
    /// </summary>
    public class colortype:connection
    {
        public colortype()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet colortype_save(string Comp_Code, string colortypecode, string colortypename, string colortypealias, string UserId, string cat, string edit)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("colortype_save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = Comp_Code;


                objmysqlcommand.Parameters.Add("colortypecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypecode"].Value = colortypecode;


                objmysqlcommand.Parameters.Add("colortypename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypename"].Value = colortypename;


                objmysqlcommand.Parameters.Add("colortypealias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypealias"].Value = colortypealias;



                objmysqlcommand.Parameters.Add("cat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat1"].Value = cat;


                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;



                objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["UserId"].Value = UserId;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }




        /*new change ankur 15 feb*/
        public DataSet colortype_modify(string Comp_Code, string colortypecode, string colortypename, string colortypealias, string UserId, string cat, string edit)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_modifycolortype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = Comp_Code;


                objmysqlcommand.Parameters.Add("colortypecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypecode"].Value = colortypecode;


                objmysqlcommand.Parameters.Add("colortypename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypename"].Value = colortypename;


                objmysqlcommand.Parameters.Add("colortypealias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypealias"].Value = colortypealias;



                objmysqlcommand.Parameters.Add("cat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat"].Value = cat;



                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }



        public DataSet chkcolortypeexecute(string compcode, string colortypecode, string colortypename, string alias, string username)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_executecolortype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("colortypecode", MySqlDbType.VarChar);
                //	if(regioncode != null && regioncode != ""  && regioncode != "undefined")
                objmysqlcommand.Parameters["colortypecode"].Value = colortypecode;
                //else
                //    objmysqlcommand.Parameters["regioncode"].Value ="%%";


                objmysqlcommand.Parameters.Add("colortypename", MySqlDbType.VarChar);
                //if(regionname != null && regionname != "" && regionname!= "undefined")
                objmysqlcommand.Parameters["colortypename"].Value = colortypename;
                //else
                //    objmysqlcommand.Parameters["regionname"].Value ="%%";


                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                //if(alias != null && alias != "" && alias!= "undefined")
                objmysqlcommand.Parameters["alias"].Value = alias;
                //else
                //    objmysqlcommand.Parameters["alias"].Value ="%%";



                //objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["UserId"].Value =username;
                //string str=objDataSet.Tables["region_mst"].Rows[0].ToString ();

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }


        //********************************************************************************************************	

        //*******************************************************************************************************


        public DataSet btndelete(string compcode, string colortypecode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("colortypedelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;


                objmysqlcommand.Parameters.Add("colortypecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypecode"].Value = colortypecode;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }

        /*new change ankur 15 feb*/
        public DataSet chkcolortype(string compcode, string colortypename, string colortypecode, string userid, string cat, string edit)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcolortype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("colortypename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypename"].Value = colortypename;

                objmysqlcommand.Parameters.Add("colortypecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypecode"].Value = colortypecode;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("cat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat1"].Value = cat;

                objmysqlcommand.Parameters.Add("edit1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit1"].Value = edit;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }
        public DataSet countcolortypecode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcolortypename", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
        //******************************************************************************************************
        public DataSet chknameforduplicate(string colortypecode, string colortypename, string compcode, string cat, string edit)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkduplicatecolortype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("colortypecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypecode"].Value = colortypecode;

                objmysqlcommand.Parameters.Add("colortypename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colortypename"].Value = colortypename;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("cat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat"].Value = cat;


                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;

             
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
           
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }
    }
}
