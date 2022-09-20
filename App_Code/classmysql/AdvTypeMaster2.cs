using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data ;
using MySql.Data .MySqlClient ;
namespace NewAdbooking.classmysql
{

    /// <summary>
    /// Summary description for AdvTypeMaster2
    /// </summary>
    public class AdvTypeMaster2:connection 
    {
        public AdvTypeMaster2()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet Advsave(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advertisement_Save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Adv_Type_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Code"].Value = adtypecode;

                objmysqlcommand.Parameters.Add("Adv_Type_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Name"].Value = adtypename;

                objmysqlcommand.Parameters.Add("Adv_Type_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Alias"].Value = alias;

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

        public DataSet Advmodify(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advertisement_Modify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Adv_Type_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Code"].Value = adtypecode;

                objmysqlcommand.Parameters.Add("Adv_Type_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Name"].Value = adtypename;

                objmysqlcommand.Parameters.Add("Adv_Type_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Alias"].Value = alias;

                //objmysqlcommand.Parameters.Add("UserId",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["UserId"].Value=UserId;

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

        public DataSet Advmodifychk1(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("CHKADVTYPNAME", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("companycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["companycode"].Value = companycode;

                objmysqlcommand.Parameters.Add("adtypecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtypecode"].Value = adtypecode;


                objmysqlcommand.Parameters.Add("adtypename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtypename"].Value = adtypename;

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

        public DataSet Advdelete(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advertisement_Delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Adv_Type_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Code"].Value = adtypecode;

                //objmysqlcommand.Parameters.Add("Adv_Type_Name", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["Adv_Type_Name"].Value=adtypename;

                //objmysqlcommand.Parameters.Add("Adv_Type_Alias", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["Adv_Type_Alias"].Value=alias;

                //objmysqlcommand.Parameters.Add("UserId",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["UserId"].Value=UserId;

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

        public DataSet Advexecute(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advertisement_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Adv_Type_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Code"].Value = adtypecode;


                objmysqlcommand.Parameters.Add("Adv_Type_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adv_Type_Name"].Value = adtypename;


                objmysqlcommand.Parameters.Add("Adv_Type_Alias", MySqlDbType.VarChar);
                //if(alias!="" && alias!=null )
                //{
                objmysqlcommand.Parameters["Adv_Type_Alias"].Value = alias;
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["Adv_Type_Alias"].Value ="%%";
                //}
                //objmysqlcommand.Parameters.Add("UserId",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["UserId"].Value=UserId;

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


        public DataSet Advexecute1(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advertisement_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

               objmysqlcommand.Parameters.Add("vAdv_Type_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vAdv_Type_Code"].Value = adtypecode;

                 objmysqlcommand.Parameters.Add("vAdv_Type_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vAdv_Type_Name"].Value = adtypename;

                 objmysqlcommand.Parameters.Add("vAdv_Type_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vAdv_Type_Alias"].Value = alias;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet; ;

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


        public DataSet Advfpnl()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advtypefpnl", ref objmysqlconnection);
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


        public DataSet advcheck(string adtypecode, string companycode, string UserId, string adtypename)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
             objmysqlconnection.Open();
             objmysqlcommand = GetCommand("Advertisement_check", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = adtypecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("adtypename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtypename"].Value = adtypename;
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


        public DataSet countzonecode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADVERTISEMENT_CODENAME_ADVERTISEMENT_CODENAME_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;
                

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }


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