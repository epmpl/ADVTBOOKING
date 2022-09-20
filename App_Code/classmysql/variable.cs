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
    /// Summary description for variable
    /// </summary>
    public class variable:connection
    {
        public variable()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet variable_save(string Comp_Code, string variable_Code, string variable_Name, string variable_alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("variable_save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = Comp_Code;


                objmysqlcommand.Parameters.Add("variable_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variable_Code"].Value = variable_Code;


                objmysqlcommand.Parameters.Add("variable_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variable_Name"].Value = variable_Name;


                objmysqlcommand.Parameters.Add("variable_alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variable_alias"].Value = variable_alias;



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





        public DataSet variablemaster_modify(string Comp_Code, string variable_Code, string variable_Name, string variable_alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_modifyvariable", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = Comp_Code;


                objmysqlcommand.Parameters.Add("variable_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variable_Code"].Value = variable_Code;


                objmysqlcommand.Parameters.Add("variable_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variable_Name"].Value = variable_Name;


                objmysqlcommand.Parameters.Add("variable_alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variable_alias"].Value = variable_alias;



                //objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["UserId"].Value =UserId;


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



        public DataSet chkvariable(string compcode, string variablecode, string variablename, string alias, string username)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("sp_executevariable", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = compcode;


                objmysqlcommand.Parameters.Add("variablecode", MySqlDbType.VarChar);
                //	if(regioncode != null && regioncode != ""  && regioncode != "undefined")
                objmysqlcommand.Parameters["variablecode"].Value = variablecode;
                //else
                //    objmysqlcommand.Parameters["regioncode"].Value ="%%";


                objmysqlcommand.Parameters.Add("variablename", MySqlDbType.VarChar);
                //if(regionname != null && regionname != "" && regionname!= "undefined")
                objmysqlcommand.Parameters["variablename"].Value = variablename;
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


        public DataSet btndelete(string compcode, string variablecode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("variabledelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;


                objmysqlcommand.Parameters.Add("variablecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variablecode"].Value = variablecode;



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


        public DataSet chkvariable_(string compcode, string variablename, string variablecode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkvariable", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("variablename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variablename"].Value = variablename;

                objmysqlcommand.Parameters.Add("variablecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variablecode"].Value = variablecode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


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
        public DataSet countvariablecode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkvariablecodename", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["str"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["str"].Value = str;
                }
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
        public DataSet chknameforduplicate(string variablecode, string variablename, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkduplicatevariable", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("variablecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variablecode"].Value = variablecode;

                objmysqlcommand.Parameters.Add("variablename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["variablename"].Value = variablename;


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
    }
}