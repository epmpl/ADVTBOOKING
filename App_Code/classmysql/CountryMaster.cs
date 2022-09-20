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
    /// Summary description for CountryMaster
    /// </summary>
    public class CountryMaster:connection 
    {
        public CountryMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet Advsave(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
             
            try
            {
                objmysqlconnection.Open();

               

                objmysqlcommand = GetCommand("Countrymaster_Save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Country_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code"].Value = code;

                objmysqlcommand.Parameters.Add("Country_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Name"].Value = name;

                objmysqlcommand.Parameters.Add("Country_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Alias"].Value = alias;

                objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["UserId"].Value = UserId;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet Advmodify(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Countrymaster_Modify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Country_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code"].Value = code;

                objmysqlcommand.Parameters.Add("Country_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Name"].Value = name;

                objmysqlcommand.Parameters.Add("Country_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Alias"].Value = alias;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet Advdelete(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
             
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Countrymaster_Delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Country_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code"].Value = code;

                objmysqlcommand.Parameters.Add("Country_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Name"].Value = name;

                objmysqlcommand.Parameters.Add("Country_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Alias"].Value = alias;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet Advexecute(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            
            try
            {
                objmysqlconnection.Open();


                objmysqlcommand = GetCommand("Countrymaster_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code1"].Value = companycode;

                objmysqlcommand.Parameters.Add("Country_Code1", MySqlDbType.VarChar);
                
                objmysqlcommand.Parameters["Country_Code1"].Value = code;
              

                objmysqlcommand.Parameters.Add("Country_Name1", MySqlDbType.VarChar);
                
                objmysqlcommand.Parameters["Country_Name1"].Value = name;
             

                objmysqlcommand.Parameters.Add("Country_Alias1", MySqlDbType.VarChar);
                
                objmysqlcommand.Parameters["Country_Alias1"].Value = alias;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet Advexecute1(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
            
            try
            {
                objmysqlconnection.Open();

                objmysqlcommand = GetCommand("Countrymaster_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Comp_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code1"].Value = companycode;

                objmysqlcommand.Parameters.Add("Country_Code1", MySqlDbType.VarChar);
                
                objmysqlcommand.Parameters["Country_Code1"].Value = code;
              

                objmysqlcommand.Parameters.Add("Country_Name1", MySqlDbType.VarChar);
               
                objmysqlcommand.Parameters["Country_Name1"].Value = name;
               

                objmysqlcommand.Parameters.Add("Country_Alias1", MySqlDbType.VarChar);
               
                objmysqlcommand.Parameters["Country_Alias1"].Value = alias;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet Advfirst()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
             
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Countryfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }



        public DataSet chkcountrycode(string companycode, string UserId, string code,string name)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
              
            try
            {
                objmysqlconnection.Open();

                objmysqlcommand = GetCommand("checkcountry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;
                objmysqlcommand.Parameters.Add("countrycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["countrycode"].Value = code;
                objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["UserId"].Value = UserId;
                objmysqlcommand.Parameters.Add("name1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["name1"].Value = name;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }

        }

        public DataSet countcode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcountrycodename", ref objmysqlconnection);
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
                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
    }
}
