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
    /// Summary description for adsubcat3
    /// </summary>
    public class adsubcat3:connection
    {
        public adsubcat3()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet getCat1(string cat1)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getCat1_getCat1_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("cat2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat2"].Value = cat1;

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




        public DataSet addcategory3name(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adsubcat_adsubcat_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
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
        public DataSet savecat3(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string xml, string priority)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cat3save_cat3save_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["subcatname"].Value = subcatname;

               objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catname"].Value = catname;

               objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catcode"].Value = catcode;

               objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catalias"].Value = catalias;

               objmysqlcommand.Parameters.Add("xml", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["xml"].Value = xml;

               objmysqlcommand.Parameters.Add("prior", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["prior"].Value = priority;

                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
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

        public DataSet catmodify(string compcode, string subcatname, string catname, string catcode, string catalias, string userid, string xml, string priority)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cat3_modify_cat3_modify_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["subcatname"].Value = subcatname;

               objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catname"].Value = catname;

               objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catcode"].Value = catcode;

               objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catalias"].Value = catalias;

               objmysqlcommand.Parameters.Add("xml", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["xml"].Value = xml;

               objmysqlcommand.Parameters.Add("prior", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["prior"].Value = priority;

                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return (objDataSet);
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
        //public DataSet catfpnl()
        //{
        //    MySqlConnection objmysqlconnection;
        //    MySqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //       objmysqlcommand = GetCommand("CATFPNL", ref objmysqlconnection);
        //       objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlDataAdapter.SelectCommand =objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objmysqlconnection);
        //    }
        //}
        public DataSet catdelete(string compcode, string catcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT_DELETE_CAT_DELETE_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catcode"].Value = catcode;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
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
        public DataSet catdauto(string str, string subcatname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cat_namechk_cat_namechk_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["str"].Value = str;

               objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length>2)
                {
               objmysqlcommand.Parameters["cod"].Value = str.Substring(0,2);
                }
                else
                {
                  objmysqlcommand.Parameters["cod"].Value = str;
                }

                objmysqlcommand.Parameters.Add("subcatname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subcatname1"].Value = subcatname;

                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
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


        public DataSet chkcatcod(string catcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CATCHK_CATCHK_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catcode"].Value = catcode;

                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
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


        public DataSet catexecute1(string compcode, string subcatname, string catname, string catcode, string catalias, string xml)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT_EXE1_CAT_EXE1_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["subcatname"].Value = subcatname;


               objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catname"].Value = catname;

               objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catcode"].Value = catcode;

               objmysqlcommand.Parameters.Add("catalias", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["catalias"].Value = catalias;

                //com.Parameters.Add("userid", MySqlDbType.VarChar);
                //com.Parameters["userid"].Value = userid;


               objmysqlcommand.Parameters.Add("xml", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["xml"].Value = xml;

                objmysqlDataAdapter.SelectCommand =objmysqlcommand;
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