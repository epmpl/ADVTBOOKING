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
    /// Summary description for DistrictMaster
    /// </summary>
    public class DistrictMaster:connection 
    {
        public DistrictMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindstate(string code, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDSTATE_BBINDSTATE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("countrycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["countrycode"].Value = code;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
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


        public DataSet statesel(string compcode, string userid, string statcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("STATESEL_STATESEL_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("statcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statcode"].Value = statcode;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
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


        public DataSet ModifyValue(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMSTMODIFY_DISTRICTMSTMODIFY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("DistCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistCode"].Value = DistCode;

                objmysqlcommand.Parameters.Add("DistName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistName"].Value = DistName;

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;






                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;           

             
               

                

              
            }

            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet InsertValue(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMSTINSERT_DISTRICTMSTINSERT_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("DistCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistCode"].Value = DistCode;

                objmysqlcommand.Parameters.Add("DistName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistName"].Value = DistName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;






             

                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;     
            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet SelectValue(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMSTSELECT_DISTRICTMSTSELECT_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


            
                objmysqlcommand.Parameters.Add("DistCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistCode"].Value = DistCode;

                objmysqlcommand.Parameters.Add("DistName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistName"].Value = DistName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;


                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;     
              

            


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet Selectfnpl(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMSTFNPL_DISTRICTMSTFNPL_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet; 
            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet state(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMST_STATE_DISTRICTMST_STATE_P", ref objmysqlconnection);
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

        public DataSet DeleteValue(string DistCode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMSTDELETE_DISTRICTMSTDELETE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("DistCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistCode"].Value = DistCode;

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

        public DataSet country(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DISTRICTMST_COUNTRY_DISTRICTMST_COUNTRY_P", ref objmysqlconnection);
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

        public DataSet checkdistrict(string DistCode, string DistName, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKDISCODE_CHKDISCODE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("DistCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistCode"].Value = DistCode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("DistName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistName"].Value = DistName;

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

        public DataSet countdistrictcode (string str,string countrycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKDISTRICTCODENAME_CHKDISTRICTCODENAME_P", ref objmysqlconnection);
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
                objmysqlcommand.Parameters.Add("countrycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["countrycode"].Value = countrycode;

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

        public DataSet countdistrictcodename(string str, string strname, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKDISTRICTCODENAMEMODIFY_CHKDISTRICTCODENAMEMODIFY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("strname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["strname"].Value = strname;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = compcode;



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
