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
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AD_CAT5_AD_CAT5_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;

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
        public DataSet savecat4(string compcode, string subcatname, string catname, string catcode, string catalias, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT5_SAVE_CAT5_SAVE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = compcode;

                objmysqlcommand.Parameters.Add("Sub_Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Sub_Cat_Name"].Value = subcatname;

                objmysqlcommand.Parameters.Add("Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Name"].Value = catname;

                objmysqlcommand.Parameters.Add("Cat_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Code"].Value = catcode;

                objmysqlcommand.Parameters.Add("Cat_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Alias"].Value = catalias;

                objmysqlcommand.Parameters.Add("userId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userId"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
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

        public DataSet catmodify(string compcode, string subcatname, string catname, string catcode, string catalias, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT5_MODIFY_CAT5_MODIFY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = compcode;


                objmysqlcommand.Parameters.Add("Sub_Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Sub_Cat_Name"].Value = subcatname;

                objmysqlcommand.Parameters.Add("Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Name"].Value = catname;

                objmysqlcommand.Parameters.Add("Cat_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Code"].Value = catcode;

                objmysqlcommand.Parameters.Add("Cat_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Alias"].Value = catalias;

                objmysqlcommand.Parameters.Add("userId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userId"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
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
        //        objmysqlcommand = GetCommand("Cat5_FPNL", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
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
        public DataSet catdelete(string catcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT5_DELETE_CAT5_DELETE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Cat_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Code"].Value = catcode;


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
                objmysqlcommand = GetCommand("CAT5_AUTO_CAT5_AUTO_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }
                objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subcatname"].Value = subcatname;
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


        public DataSet chkcatcod(string catcode, string subcatname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT5_CHK_CAT5_CHK_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["catname"].Value = catcode;

                objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subcatname"].Value = subcatname;

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


        public DataSet catexecute1(string compcode, string subcatname, string catcode, string catname, string catalias, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT5_EXE1_CAT5_EXE1_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = compcode;

                objmysqlcommand.Parameters.Add("Sub_Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Sub_Cat_Name"].Value = subcatname;


                objmysqlcommand.Parameters.Add("Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Name"].Value = catname;

                objmysqlcommand.Parameters.Add("Cat_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Code"].Value = catcode;

                objmysqlcommand.Parameters.Add("Cat_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cat_Alias"].Value = catalias;

                objmysqlcommand.Parameters.Add("userId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userId"].Value = userid;


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