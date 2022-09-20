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
    /// Summary description for Master
    /// </summary>
    public class Master:connection  
    {
        public Master()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet formpermission(string compcode, string userid, string formname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_SHOWPERMISSION_websp_showpermission_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Formname"].Value = formname;

                objmysqlcommand.Parameters.Add("Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("Vuserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Vuserid"].Value = userid;

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


        public DataSet formpermissionall(string compcode, string userid, string formname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_showpermission_websp_showpermission_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = formname;

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



        public DataSet addcity()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_addcity", ref objmysqlconnection);
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


        public DataSet countcity(string txtcountry)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillcity_fillcity_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("txtcountry", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcountry"].Value = txtcountry;

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
                objmysqlcommand = GetCommand("adcountryname_adcountryname_p", ref objmysqlconnection);
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
        public DataSet givepermission(string userid, string compcode, string formname)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletepermition", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formname"].Value = formname;

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

        public DataSet addregion(string regioncode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pcmaddregion_pcmaddregion_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("regioncode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["regioncode"].Value = regioncode;


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

        
//****************************Change by bhanu sharma**************//////////


        public DataSet binduserid(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_getuserid_websp_getuserid_p", ref objmysqlconnection);
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

        public DataSet filrategroup(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindrateforpreferrence_bindrateforpreferrence_p", ref objmysqlconnection);
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

        public DataSet adzone(string userid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindzone_bindzone_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet add()

        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("region_region_p", ref objmysqlconnection);
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

        public DataSet subcategory(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_addagencysubcat", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet representative(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_representative_websp_representative_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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
        public DataSet addagency(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_addagency", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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
        public DataSet filcur(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("filcur_filcur_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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


        public DataSet bindagencyforxls(string compcode, string agency)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindagencyforxls_bindagencyforxls_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("AGENCY", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["AGENCY"].Value = agency;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;



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
        public DataSet addagent_typ(string userid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_agent_Websp_agent_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet addstate(string statecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_addstate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
        public DataSet adddist(string dist)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_adddist", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;





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
        public DataSet filcat(string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("agecatcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("p_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_code"].Value = code;





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
         public DataSet bindagency(string compcode, string userid, string agency)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();

             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("bindagencynameonkey", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["compcode"].Value = compcode;

                 objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["userid"].Value = userid;

                 objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["agency"].Value = agency;



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

        public DataSet filsubcat(string subcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("agesubcatcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = subcat;





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

        public DataSet agencycode(string code, string compcode, string userid, string type, string subcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_AGENCYCODE_websp_agencycode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("subcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subcode"].Value = subcode;

                objmysqlcommand.Parameters.Add("type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type"].Value = type;

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

        public DataSet agencymodify(string compcode, string agencytype, string agentcategory, string agentcategory2, string agentcode, string agentname, string alias, string agencyho, string address, string street, string city, string zip, string district, string state, string country, string phone, string mail, string fax, string url, string bussinessstartdate, string enrolldate, string mrerefferenceno, string novts, string credit, string pan, string tan, string stacno, string paymode, string status, string remarks, string userid, string statusdate, string subagencyho, string agencycode, string billto, string alert, string creditlimit, string code, string region, string representative, string pincode, string stacno1, string type, string zone, string address1, string address2, string curtype, string acagen, string fax2, string rategrp, string qbcuserid, string dateformat, string depocode, string taluka, string branchcode, string hdstatecode, string hddistcode, string billfreq)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_agencymodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;

                objmysqlcommand.Parameters.Add("agentcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcategory"].Value = agentcategory;

                objmysqlcommand.Parameters.Add("agentcategory2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcategory2"].Value = agentcategory2;

                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agentcode;

                objmysqlcommand.Parameters.Add("agentname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentname"].Value = agentname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("agencyho", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyho"].Value = agencyho;

                objmysqlcommand.Parameters.Add("TYPE1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["TYPE1"].Value = type;

                objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address"].Value = address;

                objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["street"].Value = street;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("zip", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zip"].Value = zip;

                objmysqlcommand.Parameters.Add("district", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["district"].Value = district;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone"].Value = phone;

                objmysqlcommand.Parameters.Add("txtfax2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtfax2"].Value = fax2;

                objmysqlcommand.Parameters.Add("fax1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax1"].Value = fax;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

                objmysqlcommand.Parameters.Add("url1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["url1"].Value = url;

                objmysqlcommand.Parameters.Add("bussinessstartdate", MySqlDbType.DateTime);
                if (bussinessstartdate == "")
                {
                    objmysqlcommand.Parameters["bussinessstartdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["bussinessstartdate"].Value = Convert.ToDateTime(bussinessstartdate);
                }


                objmysqlcommand.Parameters.Add("enrolldate", MySqlDbType.DateTime);
                if (enrolldate == "")
                {
                    objmysqlcommand.Parameters["enrolldate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["enrolldate"].Value = Convert.ToDateTime(enrolldate);
                }
                
                objmysqlcommand.Parameters.Add("novts", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["novts"].Value = novts;

                objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["credit"].Value = credit;

                objmysqlcommand.Parameters.Add("pan", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pan"].Value = pan;

                objmysqlcommand.Parameters.Add("tan1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tan1"].Value = tan;

                objmysqlcommand.Parameters.Add("type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type"].Value = type;

                objmysqlcommand.Parameters.Add("stacno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["stacno"].Value = stacno1;

                objmysqlcommand.Parameters.Add("paymode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["paymode"].Value = paymode;

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = status;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("mrerefferenceno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mrerefferenceno"].Value = mrerefferenceno;

                objmysqlcommand.Parameters.Add("subagencyho", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencyho"].Value = subagencyho;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("billto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billto"].Value = billto;

                objmysqlcommand.Parameters.Add("alert1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alert1"].Value = alert;

                objmysqlcommand.Parameters.Add("creditlimit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditlimit"].Value = creditlimit;

                
                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("representative", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["representative"].Value = representative;

                objmysqlcommand.Parameters.Add("pincode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pincode"].Value = pincode;

                //objmysqlcommand.Parameters.Add("stacno1", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["stacno1"].Value = stacno1;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("address1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address1"].Value = address1;

                objmysqlcommand.Parameters.Add("address2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address2"].Value = address2;

                objmysqlcommand.Parameters.Add("curtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["curtype"].Value = curtype;

                objmysqlcommand.Parameters.Add("acagen", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acagen"].Value = acagen;

                objmysqlcommand.Parameters.Add("rategrp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategrp"].Value = rategrp;

                objmysqlcommand.Parameters.Add("qbcuserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["qbcuserid"].Value = qbcuserid;

                objmysqlcommand.Parameters.Add("depocode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["depocode"].Value = depocode;

                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("hddistcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hddistcode"].Value = hddistcode;


                objmysqlcommand.Parameters.Add("billf", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billf"].Value = billfreq;

                objmysqlcommand.Parameters.Add("hdstatecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hdstatecode"].Value = hdstatecode;

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

        public DataSet chkagent(string compcode, string userid, string agencycode, string subagencycode, string agencyname, string alias, string agenttype, string agentcategory, string agentsubcategory, string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_chkagent", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("agencyname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyname"].Value = agencyname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("agenttype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agenttype"].Value = agenttype;

                objmysqlcommand.Parameters.Add("agentcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcategory"].Value = agentcategory;

                objmysqlcommand.Parameters.Add("agentsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentsubcategory"].Value = agentsubcategory;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                
                

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

        public DataSet executeagency(string compcode, string userid, string agentcode, string subagencycode, string agencyname1, string alias, string agenttype, string agentcategory, string agentsubcategory, string city, string count, string branchcode, string billfreq)
        {
            //call  websp_executeagency_websp_executeagency_p('TNIE','bh02','','','TEST','','','','','','','','')
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_executeagency_websp_executeagency_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agentcode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("agencyname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyname1"].Value = agencyname1;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("agenttype", MySqlDbType.VarChar);
                if (agenttype == "0")
                {
                    objmysqlcommand.Parameters["agenttype"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["agenttype"].Value = agenttype;
                }
                //objmysqlcommand.Parameters["agenttype"].Value = agenttype;

                objmysqlcommand.Parameters.Add("agentcategory", MySqlDbType.VarChar);
                if (agentcategory == "0")
                {
                    objmysqlcommand.Parameters["agentcategory"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["agentcategory"].Value = agentcategory;
                }
                
                //objmysqlcommand.Parameters["agentcategory"].Value = agentcategory;

                objmysqlcommand.Parameters.Add("agentsubcategory", MySqlDbType.VarChar);
                if (agentsubcategory == "0")
                {
                    objmysqlcommand.Parameters["agentsubcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objmysqlcommand.Parameters["agentsubcategory"].Value = agentsubcategory;
                }
                //objmysqlcommand.Parameters["agentsubcategory"].Value = agentsubcategory;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                if (city == "0")
                {
                    objmysqlcommand.Parameters["city"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["city"].Value = city;
                }
                //objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("count1", MySqlDbType.VarChar);
                if (count == "0")
                {
                    objmysqlcommand.Parameters["count1"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["count1"].Value = count;
                }
                //objmysqlcommand.Parameters["COUNT1"].Value = count;
                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                if (branchcode == "0")
                {
                    objmysqlcommand.Parameters["branchcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["branchcode"].Value = branchcode;
                }

                objmysqlcommand.Parameters.Add("billf", MySqlDbType.VarChar);
                if (billfreq == "0")
                {
                    objmysqlcommand.Parameters["billf"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["billf"].Value = billfreq;
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

        public DataSet firstquery(string compcode, string userid, string agencycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_agencyfirst", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

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
        public DataSet agentdelete(string compcode, string userid, string agentcode, string subagency, string codesubcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_deleteagent", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agentcode;

                objmysqlcommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagency"].Value = subagency;

                objmysqlcommand.Parameters.Add("codesubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["codesubcode"].Value = codesubcode;



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

        public DataSet SubAgencyBind(string agency, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("SubAgencyBind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = agency;

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

        public DataSet usercode(string agencode, string subagencode, string compcode, string userid, string agenname, string qbcuserid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkusercode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

                objmysqlcommand.Parameters.Add("subagencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencode"].Value = subagencode;

                objmysqlcommand.Parameters.Add("agenname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agenname"].Value = agenname;

                objmysqlcommand.Parameters.Add("qbcuserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["qbcuserid"].Value = qbcuserid;

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

        public DataSet credfil(string agtype)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillcred", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = agtype;

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

        public DataSet countcode(string str, string type)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcodename_chkcodename_p", ref objmysqlconnection);
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
                //objmysqlcommand.Parameters["cod"].Value = str;

                objmysqlcommand.Parameters.Add("type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type1"].Value = type;

                objmysqlcommand.Parameters.Add("sub", MySqlDbType.VarChar);

                if (str.Length > 3)
                {
                    objmysqlcommand.Parameters["sub"].Value = str.Substring(0, 3);
                   // objmysqlcommand.Parameters.Add(objmysqlcommand.Parameters["sub"]);
                }
                else
                {
                    objmysqlcommand.Parameters["sub"].Value = str;
                   // objmysqlcommand.Parameters.Add(objmysqlcommand.Parameters["sub"]);
                }
                //objmysqlcommand.Parameters["sub"].Value = str;

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

        public DataSet countsubcode(string str, string agencode, string type)

            {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcodeagen_chkcodeagen_p", ref objmysqlconnection);
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
                //objmysqlcommand.Parameters["cod"].Value = str;

                objmysqlcommand.Parameters.Add("type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type1"].Value = type;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;

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

        public DataSet chk(string agencode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkagencode_chkagencode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencode"].Value = agencode;



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

        public DataSet bindbill(string agencyname, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindbillto_bindbillto_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencyname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyname"].Value = agencyname;



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

        public DataSet fillsubho(string subagencode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillsubho_fillsubho_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("subagencode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencode"].Value = subagencode;



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

        public DataSet bindagencycode(string agencyname, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindagencycodeinlistbox_bindagencycodeinlistbox_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agencyname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyname"].Value = agencyname;



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

        public DataSet saveagent(string compcode, string agencytype, string agentcategory, string agentcategory2, string agentcode, string agentname, string alias, string agencyho, string address, string street, string city, string district, string state, string country, string phone, string fax, string mail, string url, string bussinessstartdate, string enrolldate, string mrerefferenceno, string novts, string credit, string pan, string tan, string stacno, string status, string remarks, string userid, string subagencyho, string agencycode, string billto, string alert, string creditlimit, string code, string representative, string pin, string region, string type, string zone, string address1, string address2, string curtype, string acagen, string fax2, string rategrp, string paymode, string qbcuserid, string dateformat, string taluka, string branchcode, string hdstatecode, string hddistcode, string billf)//, string zip)
        
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_saveagent", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("acagen", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["acagen"].Value = acagen;

                objmysqlcommand.Parameters.Add("txtfax1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtfax1"].Value = fax2;

                objmysqlcommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencytype"].Value = agencytype;

                objmysqlcommand.Parameters.Add("curtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["curtype"].Value = curtype;

                objmysqlcommand.Parameters.Add("paymode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["paymode"].Value = paymode;

                objmysqlcommand.Parameters.Add("agentcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcategory"].Value = agentcategory;

                objmysqlcommand.Parameters.Add("rategrp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategrp"].Value = rategrp;

                objmysqlcommand.Parameters.Add("agentcategory2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcategory2"].Value = agentcategory2;

                objmysqlcommand.Parameters.Add("agentcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentcode"].Value = agentcode;

                objmysqlcommand.Parameters.Add("agentname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agentname"].Value = agentname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("mrerefferenceno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mrerefferenceno"].Value = mrerefferenceno;

                objmysqlcommand.Parameters.Add("agencyho", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencyho"].Value = agencyho;

                objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address"].Value = address;

                objmysqlcommand.Parameters.Add("address1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address1"].Value = address1;

                objmysqlcommand.Parameters.Add("address2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address2"].Value = address2;

                objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["street"].Value = street;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;



                objmysqlcommand.Parameters.Add("district", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["district"].Value = district;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("bussinessstartdate", MySqlDbType.DateTime);
                if (bussinessstartdate == "")
                {
                    objmysqlcommand.Parameters["bussinessstartdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["bussinessstartdate"].Value = Convert.ToDateTime(bussinessstartdate);
                }
                /*objmysqlcommand.Parameters.Add("bussinessstartdate", MySqlDbType.VarChar);

                if (bussinessstartdate == "")
                {
                    objmysqlcommand.Parameters["bussinessstartdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bussinessstartdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bussinessstartdate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = bussinessstartdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            bussinessstartdate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = bussinessstartdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                bussinessstartdate = mm + "/" + dd + "/" + yy;
                            }

                    objmysqlcommand.Parameters["bussinessstartdate"].Value = Convert.ToDateTime(bussinessstartdate).ToString("dd-MMMM-yyyy");
                }
                    //objmysqlcommand.Parameters["bussinessstartdate"].Value = bussinessstartdate;*/

                objmysqlcommand.Parameters.Add("enrolldate", MySqlDbType.DateTime);
                if (enrolldate == "")
                {
                    objmysqlcommand.Parameters["enrolldate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["enrolldate"].Value = Convert.ToDateTime(enrolldate);
                }
                /*objmysqlcommand.Parameters.Add("enrolldate", MySqlDbType.VarChar);
                if (enrolldate == "")
                {
                    objmysqlcommand.Parameters["enrolldate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = enrolldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        enrolldate = mm + "/" + dd + "/" + yy;


                    }
                    else
                        if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = enrolldate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            enrolldate = mm + "/" + dd + "/" + yy;

                        }

                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = enrolldate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                enrolldate = mm + "/" + dd + "/" + yy;
                            }

                    objmysqlcommand.Parameters["enrolldate"].Value = Convert.ToDateTime(enrolldate).ToString("dd-MMMM-yyyy");
                }
                //objmysqlcommand.Parameters["enrolldate"].Value = enrolldate;*/


                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone"].Value = phone;

                objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax"].Value = fax;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("mail", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mail"].Value = mail;

                objmysqlcommand.Parameters.Add("url", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["url"].Value = url;

                objmysqlcommand.Parameters.Add("novts", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["novts"].Value = novts;

                objmysqlcommand.Parameters.Add("credit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["credit"].Value = credit;

                objmysqlcommand.Parameters.Add("pan", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pan"].Value = pan;

                objmysqlcommand.Parameters.Add("tan", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tan"].Value = tan;

                objmysqlcommand.Parameters.Add("stacno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["stacno"].Value = stacno;

                objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status"].Value = status;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("subagencyho", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencyho"].Value = subagencyho;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;


                objmysqlcommand.Parameters.Add("billto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billto"].Value = billto;

                objmysqlcommand.Parameters.Add("alert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alert"].Value = alert;

                objmysqlcommand.Parameters.Add("creditlimit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditlimit"].Value = creditlimit;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;

                objmysqlcommand.Parameters.Add("representative", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["representative"].Value = representative;

                objmysqlcommand.Parameters.Add("pin", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pin"].Value = pin;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type"].Value = type;

                objmysqlcommand.Parameters.Add("qbcuserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["qbcuserid"].Value = qbcuserid;

                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka;


                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = taluka;

                objmysqlcommand.Parameters.Add("hddistcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hddistcode"].Value = hddistcode;


                objmysqlcommand.Parameters.Add("hdstatecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hdstatecode"].Value = hdstatecode;

                objmysqlcommand.Parameters.Add("billf", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billf"].Value = billf;

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

        public DataSet chkshow(string hiddencomcode, string hiddenuserid, string hiddenagevcode, string hiddenagensubcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkagentshow", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = hiddencomcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = hiddenuserid;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = hiddenagevcode;

                objmysqlcommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencysubcode"].Value = hiddenagensubcode;


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

        public void saveaduser(string agencycode, string depocode, string genno)

            {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("aduserinsert_aduserinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("depocode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["depocode"].Value = depocode;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("genno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["genno"].Value = genno;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                //return objDataSet;
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

        public DataSet chkdupagency(string agname, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdupagname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = agname;

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

        public DataSet bindtalu(string talukabind)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bind_talu_bind_talu_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("talukabind", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["talukabind"].Value = talukabind;

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

        public DataSet chkdupagencycode(string agname, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdupagencycode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = agname;

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

        public void agentpayinsert(string compcode, string agecode, string agencysubcode, string userid, int i, string strMode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("agentpayinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Cash", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Cash"].Value = strMode;

                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = compcode;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agecode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = agencysubcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("Flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Flag"].Value = i;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                //return objDataSet;
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

        public DataSet bindbranch()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bind_branch_bind_branch_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("@compcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["@compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            finally
            {
                objmysqlconnection.Close();
            }
        }
        public DataSet centercode(string comp_code, string user_id, string chk_value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_ADDCENTER_B", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = comp_code;

                objmysqlcommand.Parameters.Add("USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID"].Value = user_id;

                objmysqlcommand.Parameters.Add("CHK_VALUE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["CHK_VALUE"].Value = chk_value;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            finally
            {
                objmysqlconnection.Close();
            }
        }

        public DataSet secpubcode(string comp_code, string user_id)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_ADDSECPUB_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = comp_code;

                objmysqlcommand.Parameters.Add("USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID"].Value = user_id;

                

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            finally
            {
                objmysqlconnection.Close();
            }
        }
        public DataSet formpermission1(string comp_code, string user_id, string formname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_Showpermission", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Compcode"].Value = comp_code;

                objmysqlcommand.Parameters.Add("Vuserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Vuserid"].Value = user_id;

                objmysqlcommand.Parameters.Add("Formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Formname"].Value = formname;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            finally
            {
                objmysqlconnection.Close();
            }
        }

        public string delete_tal(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_dml_variable_delete_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("ptable_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("pcond_colname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("pcond_colval", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcond_colval"].Value = colvalue;

                objSqlCommand.Parameters.Add("pdelimiter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("pdateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pdateformat"].Value = date;


                objSqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pextra2"].Value = extra2;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return "true";

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
        public DataSet editioncodecenterwise(string compcode, string userid,string center, string pub, string chk_value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_ADDEDITION_CENTER_B", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["center"].Value = center;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("chk_value", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_value"].Value = chk_value;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
            finally
            {
                objmysqlconnection.Close();
            }
        }
        ////////common function to bind functions
        //shubham namdev 14/04/2017
        public DataSet BindCommanFunction(string procedureName, string[] parameterValueArray)
        {

            MySqlConnection con1 = null;
            MySqlCommand cmd1 = null;
            con1 = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                con1 = null;
                cmd1 = null;
                string query1 = "";
                objDataSet = new DataSet();
                con1 = GetConnection();

                con1.Open();
                for (int i = 0; i < parameterValueArray.Length; i++)
                {
                    if (i == 0)
                    {
                        query1 = parameterValueArray[i];
                    }
                    else
                    {
                        query1 = query1 + "','" + parameterValueArray[i];
                    }
                }
                string query = "select  " + procedureName + "('" + query1 + "') AS ID from dual";

                MySqlDataAdapter da1 = new MySqlDataAdapter(query, con1);
                da1.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con1);
            }

        }
        public DataSet BindCommanFunctionagency(string procedureName, string[] parameterValueArray)
        {

            MySqlConnection con1 = null;
            MySqlCommand cmd1 = null;
            con1 = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                con1 = null;
                cmd1 = null;
                string query1 = "";
                objDataSet = new DataSet();
                con1 = GetConnection();

                con1.Open();
                for (int i = 0; i < parameterValueArray.Length; i++)
                {
                    if (i == 0)
                    {
                        query1 = parameterValueArray[i];
                    }
                    else
                    {
                        query1 = query1 + "','" + parameterValueArray[i];
                    }
                }
                string query = "select  " + procedureName + "('" + query1 + "') AS Agency_Name from dual";

                MySqlDataAdapter da1 = new MySqlDataAdapter(query, con1);
                da1.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con1);
            }

        }


        public DataSet GetAgencyNameAdd_agency(string agencyname, string compcode, string value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("GetAgencyName_agency_GetAgencyName_agency_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("client", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["client"].Value = agencyname;

                objmysqlcommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["value1"].Value = value;


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

        // gst checking code

        public DataSet chkgstno(string comp_code, string unit_code, string gstin, string state_code, string pan_no, string type, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("gstinvalidate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcomp_code"].Value = comp_code;

                objmysqlcommand.Parameters.Add("punit_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["punit_code"].Value = unit_code;

                objmysqlcommand.Parameters.Add("pgstin", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pgstin"].Value = gstin;

                objmysqlcommand.Parameters.Add("pstate_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pstate_code"].Value = state_code;

                objmysqlcommand.Parameters.Add("ppan_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppan_no"].Value = pan_no;

                objmysqlcommand.Parameters.Add("ptype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptype"].Value = type;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlcommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra5"].Value = extra5;

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