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
/// Summary description for taluka_mast
/// </summary>
namespace NewAdbooking.Classes
{

    public class taluka_mast:connection
    {
        public taluka_mast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bind_all_talukas_ds(string compcode, string compval, string unitcode, string unitval, string tablname, string col_name, string orderby, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Cir_Dynamic_DML_variable_order", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcomp_val", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_val"].Value = compval;

                objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit_code"].Value = unitcode;

                objSqlCommand.Parameters.Add("@punit_val", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit_val"].Value = unitval;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tablname;


                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = col_name;

                objSqlCommand.Parameters.Add("@porder", SqlDbType.VarChar);
                objSqlCommand.Parameters["@porder"].Value = orderby;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tablname;
                
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
        public DataSet taluka_Code(string code, string date, string extra1, string extra2)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Cir_Genrate_Code.taluka_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = code;

               
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

        public DataSet duplicacy_chk(string compval, string userid, string dist, string t_code, string t_name, string t_alias, string t_othername)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savetaluka", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compval"].Value = compval;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;


                objSqlCommand.Parameters.Add("@t_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_code"].Value = t_code;

                objSqlCommand.Parameters.Add("@t_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_name"].Value = t_name;


                objSqlCommand.Parameters.Add("@t_alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_alias"].Value = t_alias;

                objSqlCommand.Parameters.Add("@t_othername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_othername"].Value = t_othername;


                objSqlCommand.ExecuteNonQuery();
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

        //================================== check duplicacy=========================================///

        public DataSet duplicacy_chktalucode(string compval, string userid, string dist, string t_code, string t_name)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chktalukacode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compval"].Value = compval;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;


                objSqlCommand.Parameters.Add("@t_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_code"].Value = t_code;

                objSqlCommand.Parameters.Add("@t_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_name"].Value = t_name;


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

        //-===========================================================================================///

        public DataSet modify5(string compval, string userid, string dist, string t_code, string t_name, string t_alias, string t_othername)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifytaluka", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compval"].Value = compval;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;


                objSqlCommand.Parameters.Add("@t_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_code"].Value = t_code;

                objSqlCommand.Parameters.Add("@t_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_name"].Value = t_name;


                objSqlCommand.Parameters.Add("@t_alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_alias"].Value = t_alias;

                objSqlCommand.Parameters.Add("@t_othername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@t_othername"].Value = t_othername;

                objSqlCommand.ExecuteNonQuery();
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

        public DataSet binddist(string code) /*, string dateformat, string extra1, string extra2)*/
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_Dist1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = code;

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

        public DataSet Save_tal(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_dml.variable_insert_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = code;

                objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;


                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;


                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.ExecuteNonQuery();
                return objDataSet;

                //da.SelectCommand = cmd;
                //da.Fill(objDataSet);
                //return "true";

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

        public DataSet execute_tal(string compcode, string distcodeexe, string talcodeexe, string talnameexe, string talaliasexe, string talonameexe)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("talukaexe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@distcodeexe", SqlDbType.VarChar);
                objSqlCommand.Parameters["@distcodeexe"].Value = distcodeexe;


                objSqlCommand.Parameters.Add("@talcodeexe", SqlDbType.VarChar);
                objSqlCommand.Parameters["@talcodeexe"].Value = talcodeexe;


                objSqlCommand.Parameters.Add("@talnameexe", SqlDbType.VarChar);
                objSqlCommand.Parameters["@talnameexe"].Value = talnameexe;

                objSqlCommand.Parameters.Add("@talaliasexe", SqlDbType.VarChar);
                objSqlCommand.Parameters["@talaliasexe"].Value = talaliasexe;

                objSqlCommand.Parameters.Add("@talonameexe", SqlDbType.VarChar);
                objSqlCommand.Parameters["@talonameexe"].Value = talonameexe;


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


        public DataSet delete_tal(string talcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("talukadel", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@talcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@talcode"].Value = talcode;



                objSqlCommand.ExecuteNonQuery();
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

        //public DataSet bind_all_talukas_ds(string compcode, string compval, string unitcode, string unitval, string tablname, string col_name, string orderby, string date, string extra1, string extra2)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Cir_Dynamic_DML.variable_order", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@pcomp_val", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pcomp_val"].Value = compval;


        //        objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@punit_code"].Value = unitcode;


        //        objSqlCommand.Parameters.Add("@punit_val", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@punit_val"].Value = unitval;

        //        objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@ptable_name"].Value = tablname;

        //        objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pcolname"].Value = col_name;


        //        objSqlCommand.Parameters.Add("@porder", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@porder"].Value = orderby;

        //        objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pextra1"].Value = extra1;

        //        objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pextra2"].Value = extra2;



        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }

        //}

        public DataSet autocode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("talukamastautocode", ref objSqlConnection);
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

        //=================================================================//

        public DataSet talunamechk(string str)//, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkbranchname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

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