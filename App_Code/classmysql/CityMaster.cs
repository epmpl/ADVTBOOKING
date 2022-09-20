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
    /// Summary description for CityMaster
    /// </summary>
    public class CityMaster:connection 
    {
        public CityMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet distselect(string compcode, string userid, string statcode, string distcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("distsel_distsel_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("statcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statcode"].Value = statcode;
                objmysqlcommand.Parameters.Add("distcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["distcode"].Value = distcode;
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

        public DataSet binddistrict(string kan, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDDISTRICT_BINDDISTRICT_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("statecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["statecode"].Value = kan;

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


        public DataSet ModifyValue(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMstModify_CityMstModify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("CityCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityCode"].Value = CityCode;


                objmysqlcommand.Parameters.Add("CityName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityName"].Value = CityName;
                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;


                objmysqlcommand.Parameters.Add("DistrictName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistrictName"].Value = DistrictName;

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;


                objmysqlcommand.Parameters.Add("ZoneName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ZoneName"].Value = ZoneName;

                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;
                objmysqlcommand.Parameters.Add("CitySTD", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CitySTD"].Value = CitySTD;
                objmysqlcommand.Parameters.Add("Region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region"].Value = Region;



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


        public DataSet InsertValue(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMstInsert_CityMstInsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("CityCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityCode"].Value = CityCode;

                objmysqlcommand.Parameters.Add("CityName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityName"].Value = CityName;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

                objmysqlcommand.Parameters.Add("DistrictName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistrictName"].Value = DistrictName;

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;

                objmysqlcommand.Parameters.Add("ZoneName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ZoneName"].Value = ZoneName;

                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;

                objmysqlcommand.Parameters.Add("CitySTD", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CitySTD"].Value = CitySTD;

                objmysqlcommand.Parameters.Add("Region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region"].Value = Region;

               
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

        public DataSet SelectValue(string compcode, string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMstSelect_CityMstSelect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("CityCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityCode"].Value = CityCode;
                if (CityCode == "0")
                {
                    objmysqlcommand.Parameters["CityCode"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["CityCode"].Value = CityCode;
                }
                objmysqlcommand.Parameters.Add("CityName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityName"].Value = CityName;
                if (CityName == "0")
                {
                    objmysqlcommand.Parameters["CityName"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["CityName"].Value = CityName;
                }
                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;
                if (Alias == "0")
                {
                    objmysqlcommand.Parameters["Alias"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["Alias"].Value = Alias;
                }
                objmysqlcommand.Parameters.Add("DistrictName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistrictName"].Value = DistrictName;
                if (DistrictName == "0")
                {
                    objmysqlcommand.Parameters["DistrictName"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["DistrictName"].Value = DistrictName;
                }

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;
                if (StateName == "0")
                {
                    objmysqlcommand.Parameters["StateName"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["StateName"].Value = StateName;
                }

                objmysqlcommand.Parameters.Add("ZoneName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ZoneName"].Value = ZoneName;
                if (ZoneName == "0")
                {
                    objmysqlcommand.Parameters["ZoneName"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["ZoneName"].Value = ZoneName;
                }

                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;

                if (CountryName == "0")
                {
                    objmysqlcommand.Parameters["CountryName"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["CountryName"].Value = CountryName;
                }

                objmysqlcommand.Parameters.Add("CitySTD", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CitySTD"].Value = "";

                objmysqlcommand.Parameters.Add("Region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Region"].Value = Region;
                if (Region == "0")
                {
                    objmysqlcommand.Parameters["Region"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["Region"].Value = Region;
                }
                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = "";

              
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

        public DataSet Selectfnpl(string CityCode, string CityName, string Alias, string DistrictName, string StateName, string ZoneName, string CountryName, string CitySTD, string Region, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMstfnpl_CityMstfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

              

              //  objmysqlDataAdapter = new SqlDataAdapter();
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

        public DataSet district(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMst_District_CityMst_District_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
                objmysqlcommand = GetCommand("CityMst_State_CityMst_State_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet zone(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMst_Zone_CityMst_Zone_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
                objmysqlcommand = GetCommand("CityMst_Country_CityMst_Country_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet region(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMst_Region_CityMst_Region_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet DeleteValue(string CityCode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CityMastDelete_CityMastDelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("CityCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityCode"].Value = CityCode;

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


        public DataSet citycheck(string CityCode, string compcode, string name, string CountryName, string StateName, string DistrictName, string mode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("citychkcode_citychkcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("CityCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CityCode"].Value = CityCode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("name1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["name1"].Value = name;


                objmysqlcommand.Parameters.Add("CountryName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CountryName"].Value = CountryName;

                objmysqlcommand.Parameters.Add("StateName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["StateName"].Value = StateName;

                objmysqlcommand.Parameters.Add("DistrictName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DistrictName"].Value = DistrictName;

                objmysqlcommand.Parameters.Add("mode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mode1"].Value = mode;

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
                objmysqlcommand = GetCommand("chkcitycodename_chkcitycodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;
               

               objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                 if(str.Length>2)
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
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet retainer()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("login_getbranchname_login_getbranchname_p", ref objmysqlconnection);
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
        public DataSet userupdatebranch(string username, string branchcode, string compcode, string citycode, string userflag)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CITYUPDATEBRANCH", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;
                objmysqlcommand.Parameters.Add("branchcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode1"].Value = branchcode;


                objmysqlcommand.Parameters.Add("userflag1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userflag1"].Value = userflag;
                objmysqlcommand.Parameters.Add("compcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode1"].Value = compcode;


                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = citycode;

                


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

        public DataSet usersavebranch(string username, string branchcode, string compcode, string CityCode, string userflag)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CITYSAVEBRANCH", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;
                objmysqlcommand.Parameters.Add("branchcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode1"].Value = branchcode;


                objmysqlcommand.Parameters.Add("userflag1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userflag1"].Value = userflag;
                objmysqlcommand.Parameters.Add("compcode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode1"].Value = compcode;


                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = CityCode;




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

        public DataSet executebranch(string compcode, string citycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("citybranchexe", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = citycode;

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
//==================Bind Region=====================
        public DataSet bindregion(string code, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDREGION", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("zonecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonecode"].Value = code;

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
    }
}
