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
    /// Summary description for AdCat4
    /// </summary>
    public class AdCat4:connection
    {
        public AdCat4()
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
                objmysqlcommand = GetCommand("AD_CAT4_AD_CAT4_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
                objmysqlcommand = GetCommand("CAT4_SAVE_CAT4_SAVE_P", ref objmysqlconnection);
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
                objmysqlcommand = GetCommand("CAT4_MODIFY", ref objmysqlconnection);
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
        public DataSet catfpnl()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Cat_FPNL", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
                objmysqlcommand = GetCommand("CAT4_DELETE", ref objmysqlconnection);
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
//================================
        public DataSet catdauto(string str, string cat3code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT4_AUTO", ref objmysqlconnection);
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

                objmysqlcommand.Parameters.Add("Sub_Cat_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Sub_Cat_Name"].Value = cat3code;

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
                objmysqlcommand = GetCommand("CAT4_CHK", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("PCAT_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCAT_CODE"].Value = catcode;

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


        public DataSet catexecute1(string compcode, string subcatname, string catname, string catcode, string catalias, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CAT4_EXE1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("PCOMP_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCOMP_CODE"].Value = compcode;

                objmysqlcommand.Parameters.Add("PSUB_CAT_NAME", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PSUB_CAT_NAME"].Value = subcatname;


                objmysqlcommand.Parameters.Add("Cat_Name1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCAT_NAME"].Value = catname;

                objmysqlcommand.Parameters.Add("PCAT_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCAT_CODE"].Value = catcode;

                objmysqlcommand.Parameters.Add("PCAT_ALIAS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCAT_ALIAS"].Value = catalias;

                objmysqlcommand.Parameters.Add("PUSERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PUSERID"].Value = userid;


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

        public DataSet addcategoryname1(string adtype,string comp_code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcategory_adcategory_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("company_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["company_code"].Value = comp_code;

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
//====================new change
         public DataSet addcategorynameALL(string adtype, string cat3)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADCATEGORYALL_ADCATEGORYALL_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("cat3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat3"].Value = cat3;

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

        public DataSet addcategoryname3(string adsubcategory)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVSUBSUBCATEGORY_ADVSUBSUBCATEGORY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

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

        public DataSet addcategoryname2(string adcat, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("advsubcategory1_advsubcategory_p1", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcat;

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

        //======================================================


    }
}
