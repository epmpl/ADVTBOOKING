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
    /// Summary description for StateMaster
    /// </summary>
    public class StateMaster:connection 
    {
        public StateMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adcountryname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcountryname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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


        public DataSet Advsave1(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {



                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Statemaster_Save", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;
                objmysqlcommand.Parameters.Add("State_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Code"].Value = statecode;
                objmysqlcommand.Parameters.Add("State_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Name"].Value = statename;
                objmysqlcommand.Parameters.Add("State_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Alias"].Value = alias;
                objmysqlcommand.Parameters.Add("Country_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code"].Value = countryname;
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

        public DataSet Advmodify1(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Statemaster_Modify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code1"].Value = companycode;

                objmysqlcommand.Parameters.Add("State_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Code1"].Value = statecode;

                objmysqlcommand.Parameters.Add("State_Name1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Name1"].Value = statename;             

                objmysqlcommand.Parameters.Add("State_Alias1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Alias1"].Value = alias;


                objmysqlcommand.Parameters.Add("Country_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code1"].Value = countryname;

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

        public DataSet Advdelete(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Statemaster_Delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code1"].Value = companycode;
                objmysqlcommand.Parameters.Add("State_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Code1"].Value = statecode;
                objmysqlcommand.Parameters.Add("State_Name1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Name1"].Value = statename;
                objmysqlcommand.Parameters.Add("State_Alias1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Alias1"].Value = statename;
                objmysqlcommand.Parameters.Add("Country_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code1"].Value = countryname;
              

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

        public DataSet Advexecute1(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {



                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Statemaster_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;
                objmysqlcommand.Parameters.Add("State_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Code"].Value = statecode;
                objmysqlcommand.Parameters.Add("State_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Name"].Value = statename;
                objmysqlcommand.Parameters.Add("State_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Alias"].Value = alias;
                objmysqlcommand.Parameters.Add("Country_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code"].Value = countryname;
              

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

        public DataSet Advexecute2(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Statemaster_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;
                objmysqlcommand.Parameters.Add("State_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Code"].Value = statecode;
                objmysqlcommand.Parameters.Add("State_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Name"].Value = statename;
                objmysqlcommand.Parameters.Add("State_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["State_Alias"].Value = statename;
                objmysqlcommand.Parameters.Add("Country_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Country_Code"].Value = countryname;


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


        public DataSet Statefirst()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Statefpnl", ref objmysqlconnection);
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

        public DataSet chkstatecode(string companycode, string UserId, string statecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkstate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;
                objmysqlcommand.Parameters.Add("statecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statecode"].Value = statecode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet chkstatename(string statecode, string statename, string companycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkstatename", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("statecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statecode"].Value = statecode;
                objmysqlcommand.Parameters.Add("statename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statename"].Value = statename;
                objmysqlcommand.Parameters.Add("companycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["companycode"].Value = companycode;
               
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

        public DataSet countstatecode(string str, string ssss, string statecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKSTATECODENAME_CHKSTATECODENAME_P", ref objmysqlconnection);
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
                objmysqlcommand.Parameters.Add("ssss", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ssss"].Value = ssss;
                objmysqlcommand.Parameters.Add("statecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statecode"].Value = statecode;
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
