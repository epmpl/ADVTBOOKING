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
/// Summary description for Master
/// </summary>
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for Master.
    /// </summary>
    public class Master : connection
    {
        public Master()
        {
            //
            // TODO: Add constructor logic here
            //
        }




        public DataSet checkagencycode(string comp, string type, string agencycode, string agencysubcode, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("CheckSavedAgencyCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pCompCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCompCode"].Value = comp;

                objSqlCommand.Parameters.Add("@pType", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pType"].Value = type;

                objSqlCommand.Parameters.Add("@pAgencyCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pAgencyCode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@pAgencySubCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pAgencySubCode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("@pExtra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pExtra1"].Value = extra1;


                objSqlCommand.Parameters.Add("@pExtra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pExtra2"].Value = extra2;

              

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


        public DataSet fillmrv1(string compcode, string dateformat, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("agency_mrv_region_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;


                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;


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





        public DataSet editioncodecenterwise(string compcode, string userid, string center, string pub, string chk_value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addedition_center_B", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = chk_value;


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
        public DataSet chkdupagencycode(string agname, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdupagencycode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = agname;



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
        public DataSet chkdupagency(string agname, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdupagname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = agname;



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

        public DataSet Pripubcode_new(string compcode, string userid, string chk_value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_addpubcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = chk_value;
                

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

        public DataSet Pripubcode(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_addpubcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = "";



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
        public DataSet centercodenew(string compcode, string userid, string chk_value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = chk_value;


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
        public DataSet centercode(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_value"].Value = "";


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
        //public DataSet Insertcompanymaster(string Empcodeincharge,string Empcode,string Storycode,string duedate,string Comment)
        public DataSet editioncode(string compcode, string userid)/*, string pubcode)*/
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



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
        public DataSet secpubcode(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addsecpub_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



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
        public DataSet Insertcompanymaster(string compcode, string compname, string add, string street, string district, string country, string state, string pin, string mail, string phne, string fax, string pan, string tan, string regno, string date, string boxadd, string remarks, string allias)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_companymaster", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@compname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compname"].Value = compname;
                objSqlCommand.Parameters.Add("@add", SqlDbType.VarChar);
                objSqlCommand.Parameters["@add"].Value = add;
                objSqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
                objSqlCommand.Parameters["@date"].Value = Convert.ToDateTime(date);
                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                //if (Comment =="" || Comment==null)
                objSqlCommand.Parameters["@street"].Value = street;
                //else

                objSqlCommand.Parameters.Add("@district", SqlDbType.VarChar);
                objSqlCommand.Parameters["@district"].Value = district;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@pin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pin"].Value = pin;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;

                objSqlCommand.Parameters.Add("@phne", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phne"].Value = phne;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@pan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pan"].Value = pan;

                objSqlCommand.Parameters.Add("@tan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tan"].Value = tan;

                objSqlCommand.Parameters.Add("@regno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@regno"].Value = regno;

                objSqlCommand.Parameters.Add("@boxadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxadd"].Value = boxadd;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@allias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allias"].Value = allias;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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

        public DataSet selectfirst()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_selectfirst", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet addcity()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_addcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet addregion1(string values)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addregion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@values", SqlDbType.VarChar);
                objSqlCommand.Parameters["@values"].Value = values;

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



        public DataSet addagent_typ(string userid,string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_agent", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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


        public DataSet adzone(string userid,string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindzone", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet addagenttyp(string agent)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addagent", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agent"].Value = agent;
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

        public DataSet addstate(string statecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addstate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@statecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statecode"].Value = statecode;
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

        public DataSet adddist(string dist)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_adddist", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dist"].Value = dist;
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



        public DataSet subcategory(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addagencysubcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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


        public DataSet representative(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_representative", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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

        public DataSet saveagent(string compcode, string agencytype, string agentcategory, string agentcategory2, string agentcode, string agentname, string alias, string agencyho, string address, string street, string city, string district, string state, string country, string phone, string fax, string mail, string url, string bussinessstartdate, string enrolldate, string mrerefferenceno, string novts, string credit, string pan, string tan, string stacno, string status, string remarks, string userid, string subagencyho, string agencycode, string billto, string alert, string creditlimit, string code, string representative, string pin, string region, string type, string zone, string address1, string address2, string curtype, string acagen, string fax2, string rategrp, string paymode, string qbcuserid, string dateformat, string taluka, string zip, string branchcode, string hdstatecode, string hddistcode, string billf, string oldagency, string booktype, string vat, string raterevise, string editionwise, string executive, string email, string age_desig, string creditdays, string creditlimitdays, string recoverylimit, string emailidcc, string kyc_attach, string intrestcalculation, string bilflag, string subsubcd1, string sapcode, string security, string gstus, string gstdt, string gstin, string retainersa, string blcheque, string scuritybond, string kycapp, string addproof, string gstatus, string gstclty, string gstarno, string gstprovid, string gsteftdt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_saveagent", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@acagen", SqlDbType.VarChar);
                objSqlCommand.Parameters["@acagen"].Value = acagen;

                objSqlCommand.Parameters.Add("@txtfax1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfax1"].Value = fax2;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@curtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curtype"].Value = curtype;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agentcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcategory"].Value = agentcategory;

                objSqlCommand.Parameters.Add("@rategrp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategrp"].Value = rategrp;

                objSqlCommand.Parameters.Add("@agentcategory2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcategory2"].Value = agentcategory2;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agentcode;

                objSqlCommand.Parameters.Add("@agentname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentname"].Value = agentname;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;


                objSqlCommand.Parameters.Add("@mrerefferenceno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mrerefferenceno"].Value = mrerefferenceno;

                objSqlCommand.Parameters.Add("@agencyho", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyho"].Value = agencyho;

                objSqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address"].Value = address;
                //*************************Pankaj************
                objSqlCommand.Parameters.Add("@address1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address1"].Value = address1;

                objSqlCommand.Parameters.Add("@address2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address2"].Value = address2;
                //*****************************************************************
                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@street"].Value = street;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@zip", SqlDbType.VarChar);
                if (zip != null && zip != "")
                    objSqlCommand.Parameters["@zip"].Value = zip;
                else
                    objSqlCommand.Parameters["@zip"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@district", SqlDbType.VarChar);
                objSqlCommand.Parameters["@district"].Value = district;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;

                objSqlCommand.Parameters.Add("@url", SqlDbType.VarChar);
                if (url != null && url != "")
                    objSqlCommand.Parameters["@url"].Value = url;
                else
                    objSqlCommand.Parameters["@url"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@bussinessstartdate", SqlDbType.VarChar);
                if (bussinessstartdate != "" && bussinessstartdate != null)
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bussinessstartdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bussinessstartdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = bussinessstartdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        bussinessstartdate = mm + "/" + dd + "/" + yy;
                    }
                }
                if (bussinessstartdate != "" && bussinessstartdate != null)
                {
                    objSqlCommand.Parameters["@bussinessstartdate"].Value = Convert.ToDateTime(bussinessstartdate);
                }
                else
                {
                    objSqlCommand.Parameters["@bussinessstartdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@enrolldate", SqlDbType.VarChar);
                if (enrolldate != "" && enrolldate != null)
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = enrolldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        enrolldate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = enrolldate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        enrolldate = mm + "/" + dd + "/" + yy;
                    }
                }
                if (enrolldate != "" && enrolldate != null)
                {
                    objSqlCommand.Parameters["@enrolldate"].Value = Convert.ToDateTime(enrolldate);
                }
                else
                {
                    objSqlCommand.Parameters["@enrolldate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@novts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@novts"].Value = novts;

                objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@credit"].Value = credit;

                objSqlCommand.Parameters.Add("@pan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pan"].Value = pan;

                objSqlCommand.Parameters.Add("@tan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tan"].Value = tan;

                objSqlCommand.Parameters.Add("@stacno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stacno"].Value = stacno;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@subagencyho", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencyho"].Value = subagencyho;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;


                objSqlCommand.Parameters.Add("@alert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alert"].Value = alert;

                objSqlCommand.Parameters.Add("@creditlimit", SqlDbType.VarChar);
                if (creditlimit == "")
                {
                    objSqlCommand.Parameters["@creditlimit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@creditlimit"].Value = creditlimit;
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@representative", SqlDbType.VarChar);
                objSqlCommand.Parameters["@representative"].Value = representative;

                objSqlCommand.Parameters.Add("@pin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pin"].Value = pin;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@qbcuserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@qbcuserid"].Value = qbcuserid;

                objSqlCommand.Parameters.Add("@taluka", SqlDbType.VarChar);
                objSqlCommand.Parameters["@taluka"].Value = taluka;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@hdstatecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hdstatecode"].Value = hdstatecode;

                objSqlCommand.Parameters.Add("@hddistcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hddistcode"].Value = hddistcode;

                objSqlCommand.Parameters.Add("@billf", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billf"].Value = billf;

                objSqlCommand.Parameters.Add("@oldagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@oldagency"].Value = oldagency;

                objSqlCommand.Parameters.Add("@booktype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktype"].Value = booktype;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;

                objSqlCommand.Parameters.Add("@p_raterevise", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_raterevise"].Value = vat;

                objSqlCommand.Parameters.Add("@p_editionwisebilling", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_editionwisebilling"].Value = editionwise;

                objSqlCommand.Parameters.Add("@p_executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_executive"].Value = executive;

                objSqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                objSqlCommand.Parameters["@email"].Value = email;

                objSqlCommand.Parameters.Add("@age_desig", SqlDbType.VarChar);
                objSqlCommand.Parameters["@age_desig"].Value = age_desig;

                objSqlCommand.Parameters.Add("@creditdays", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditdays"].Value = creditdays;

                objSqlCommand.Parameters.Add("@creditlimitdays", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditlimitdays"].Value = creditlimitdays;

                objSqlCommand.Parameters.Add("@recoverylimit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@recoverylimit"].Value = recoverylimit;

                objSqlCommand.Parameters.Add("@emailid_cc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@emailid_cc"].Value = emailidcc;

                objSqlCommand.Parameters.Add("@kyc_attach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@kyc_attach"].Value = kyc_attach;

                objSqlCommand.Parameters.Add("@intrestcalculation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@intrestcalculation"].Value = intrestcalculation;

                objSqlCommand.Parameters.Add("@sapcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sapcode"].Value = sapcode;

                objSqlCommand.Parameters.Add("@Billflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Billflag"].Value = bilflag;

                objSqlCommand.Parameters.Add("@vatno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vatno"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@subsubagcode", SqlDbType.VarChar);
                if (subsubcd1 == "")
                {
                    objSqlCommand.Parameters["@subsubagcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@subsubagcode"].Value = subsubcd1;
                }

                objSqlCommand.Parameters.Add("@psecurity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psecurity"].Value = security;

                objSqlCommand.Parameters.Add("@pgstaus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstaus"].Value = gstus;


                objSqlCommand.Parameters.Add("@pgstdate", SqlDbType.VarChar);                               
                if (gstdt == "")
                {
                    objSqlCommand.Parameters["@pgstdate"].Value = System.DBNull.Value;                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = gstdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        gstdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = gstdt.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        gstdt = mm + "/" + dd + "/" + yy;
                    }
                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = gstdt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            gstdt = mm + "/" + dd + "/" + yy;
                        }
                    objSqlCommand.Parameters["@pgstdate"].Value = Convert.ToDateTime(gstdt);
                }

                objSqlCommand.Parameters.Add("@pgstin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstin"].Value = gstin;

                objSqlCommand.Parameters.Add("@retain", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retain"].Value = retainersa;

                objSqlCommand.Parameters.Add("@blankcheque", SqlDbType.VarChar);
                objSqlCommand.Parameters["@blankcheque"].Value = blcheque;

                objSqlCommand.Parameters.Add("@secrtybond", SqlDbType.VarChar);
                objSqlCommand.Parameters["@secrtybond"].Value = scuritybond;

                objSqlCommand.Parameters.Add("@kycappli", SqlDbType.VarChar);
                objSqlCommand.Parameters["@kycappli"].Value = kycapp;

                objSqlCommand.Parameters.Add("@addproof", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addproof"].Value = addproof;

                objSqlCommand.Parameters.Add("@pgstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstatus"].Value = gstatus;

                objSqlCommand.Parameters.Add("@pgstclty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstclty"].Value = gstclty;

                objSqlCommand.Parameters.Add("@pgstarno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstarno"].Value = gstarno;

                objSqlCommand.Parameters.Add("@pgstprovid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstprovid"].Value = gstprovid;

                objSqlCommand.Parameters.Add("@pgsteftdt", SqlDbType.VarChar);
                if (gsteftdt == "")
                {
                    objSqlCommand.Parameters["@pgsteftdt"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = gsteftdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        gsteftdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = gsteftdt.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        gsteftdt = mm + "/" + dd + "/" + yy;
                    }
                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = gsteftdt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            gsteftdt = mm + "/" + dd + "/" + yy;
                        }
                    objSqlCommand.Parameters["@pgsteftdt"].Value = Convert.ToDateTime(gsteftdt);
                }
                
                objSqlDataAdapter = new SqlDataAdapter();
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

        //
        public DataSet addagency(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_addagency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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


        public DataSet filcur(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("filcur", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet firstquery(string compcode, string userid, string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_agencyfirst", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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

        public DataSet executeagency(string compcode, string userid, string agentcode, string subagencycode, string agencyname1, string alias, string agenttype, string agentcategory, string agentsubcategory, string city, string count, string branchcode,string billfreq)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_executeagency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);

                if (agentcode != null && agentcode != "")
                    objSqlCommand.Parameters["@agentcode"].Value = agentcode;
                else
                    objSqlCommand.Parameters["@agentcode"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                if (subagencycode != null && subagencycode != "")
                    objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;
                else
                    objSqlCommand.Parameters["@subagencycode"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@agencyname1", SqlDbType.VarChar);
                if (agencyname1 != null && agencyname1 != "")
                    objSqlCommand.Parameters["@agencyname1"].Value = agencyname1;
                else
                    objSqlCommand.Parameters["@agencyname1"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                if (alias != null && alias != "")
                    objSqlCommand.Parameters["@alias"].Value = alias;
                else
                    objSqlCommand.Parameters["@alias"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@agenttype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agenttype"].Value = agenttype;

                objSqlCommand.Parameters.Add("@agentcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcategory"].Value = agentcategory;

                objSqlCommand.Parameters.Add("@agentsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentsubcategory"].Value = agentsubcategory;
                
                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@count", SqlDbType.VarChar);
                objSqlCommand.Parameters["@count"].Value = count;

                objSqlCommand.Parameters.Add("@billf", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billf"].Value = billfreq;

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

        public DataSet agentdelete(string compcode, string userid, string agentcode, string subagency, string codesubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_deleteagent", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agentcode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@subagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("@codesubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codesubcode"].Value = codesubcode;

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

        public DataSet chkagent(string compcode, string userid, string agencycode, string subagencycode, string agencyname, string alias, string agenttype, string agentcategory, string agentsubcategory, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_chkagent", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                if (@agencycode != null && @agencycode != "")
                    objSqlCommand.Parameters["@agencycode"].Value = agencycode;
                else
                    objSqlCommand.Parameters["@agencycode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                if (@subagencycode != null && @subagencycode != "")
                    objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;
                else
                    objSqlCommand.Parameters["@subagencycode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@agencyname", SqlDbType.VarChar);
                if (@agencyname != null && @agencyname != "")
                    objSqlCommand.Parameters["@agencyname"].Value = agencyname;
                else
                    objSqlCommand.Parameters["@agencyname"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                if (@alias != null && @alias != "")
                    objSqlCommand.Parameters["@alias"].Value = alias;
                else
                    objSqlCommand.Parameters["@alias"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@agenttype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agenttype"].Value = agenttype;


                objSqlCommand.Parameters.Add("@agentcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcategory"].Value = agentcategory;


                objSqlCommand.Parameters.Add("@agentsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentsubcategory"].Value = agentsubcategory;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;


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

        public DataSet agencymodify(string compcode, string agencytype, string agentcategory, string agentcategory2, string agentcode, string agentname, string alias, string agencyho, string address, string street, string city, string zip, string district, string state, string country, string phone, string mail, string fax, string url, string bussinessstartdate, string enrolldate, string mrerefferenceno, string novts, string credit, string pan, string tan, string stacno, string paymode, string status, string remarks, string userid, string statusdate, string subagencyho, string agencycode, string billto, string alert, string creditlimit, string code, string region, string representative, string pincode, string stacno1, string type, string zone, string address1, string address2, string curtype, string acagen, string fax2, string rategrp, string qbcuserid, string dateformat, string depocode, string taluka, string branchcode, string hdstatecode, string hddistcode, string billfreq, string oldagen, string booktype, string vat, string raterevise, string insertremark, string editionwisebilling, string executive, string email, string age_desig, string creditdays, string creditlimitdays, string recoverylimit, string emailidcc, string kyc_attach, string intrestcalculation, string bilflag, string sapcode, string secure, string gstattus, string gstdt, string gstin, string retainer, string blankcheque, string Securitybond, string kycapp, string addproof, string gstatus, string gstcltya, string gstarno, string gstprovid, string gsteftdt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_agencymodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@acagen", SqlDbType.VarChar);
                objSqlCommand.Parameters["@acagen"].Value = acagen;
                
                objSqlCommand.Parameters.Add("@agentcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcategory"].Value = agentcategory;

                objSqlCommand.Parameters.Add("@txtfax2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtfax2"].Value = fax2;

                objSqlCommand.Parameters.Add("@curtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@curtype"].Value = curtype;

                objSqlCommand.Parameters.Add("@rategrp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategrp"].Value = rategrp;

                objSqlCommand.Parameters.Add("@agentcategory2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcategory2"].Value = agentcategory2;

                objSqlCommand.Parameters.Add("@agentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentcode"].Value = agentcode;

                objSqlCommand.Parameters.Add("@agentname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agentname"].Value = agentname;

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

                objSqlCommand.Parameters.Add("@mrerefferenceno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mrerefferenceno"].Value = mrerefferenceno;

                objSqlCommand.Parameters.Add("@agencyho", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyho"].Value = agencyho;

                objSqlCommand.Parameters.Add("@address", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address"].Value = address;

                objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
                objSqlCommand.Parameters["@street"].Value = street;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@zip", SqlDbType.VarChar);
                if (zip != null && zip != "")
                    objSqlCommand.Parameters["@zip"].Value = zip;
                else
                    objSqlCommand.Parameters["@zip"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@district", SqlDbType.VarChar);
                objSqlCommand.Parameters["@district"].Value = district;

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                objSqlCommand.Parameters["@state"].Value = state;

                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
                objSqlCommand.Parameters["@country"].Value = country;

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mail"].Value = mail;

                objSqlCommand.Parameters.Add("@url", SqlDbType.VarChar);
                if (url != null && url != "")
                    objSqlCommand.Parameters["@url"].Value = url;
                else
                    objSqlCommand.Parameters["@url"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@bussinessstartdate", SqlDbType.DateTime);
                if (bussinessstartdate != "" && bussinessstartdate != null)
                {
                    objSqlCommand.Parameters["@bussinessstartdate"].Value = Convert.ToDateTime(bussinessstartdate);
                }
                else
                {
                    objSqlCommand.Parameters["@bussinessstartdate"].Value = System.DBNull.Value;
                    
                }

                objSqlCommand.Parameters.Add("@enrolldate", SqlDbType.DateTime);
                if (enrolldate != "" && enrolldate != null)
                {
                    objSqlCommand.Parameters["@enrolldate"].Value = Convert.ToDateTime(enrolldate);
                }
                else
                {
                    objSqlCommand.Parameters["@enrolldate"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters.Add("@novts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@novts"].Value = novts;

                objSqlCommand.Parameters.Add("@credit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@credit"].Value = credit;

                objSqlCommand.Parameters.Add("@pan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pan"].Value = pan;

                objSqlCommand.Parameters.Add("@tan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tan"].Value = tan;

                objSqlCommand.Parameters.Add("@stacno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stacno"].Value = stacno1;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@subagencyho", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencyho"].Value = subagencyho;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@alert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alert"].Value = alert;

                objSqlCommand.Parameters.Add("@creditlimit", SqlDbType.VarChar);
                if (creditlimit == "")
                {
                    objSqlCommand.Parameters["@creditlimit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@creditlimit"].Value = creditlimit;
                }

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@representative", SqlDbType.VarChar);
                objSqlCommand.Parameters["@representative"].Value = representative;

                objSqlCommand.Parameters.Add("@pincode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pincode"].Value = pincode;

                objSqlCommand.Parameters.Add("@stacno1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@stacno1"].Value = stacno1;

                objSqlCommand.Parameters.Add("@address1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address1"].Value = address1;

                objSqlCommand.Parameters.Add("@address2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@address2"].Value = address2;

                objSqlCommand.Parameters.Add("@qbcuserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@qbcuserid"].Value = qbcuserid;

                objSqlCommand.Parameters.Add("@depocode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@depocode"].Value = depocode;

                objSqlCommand.Parameters.Add("@taluka", SqlDbType.VarChar);
                objSqlCommand.Parameters["@taluka"].Value = taluka;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@hdstatecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hdstatecode"].Value = hdstatecode;

                objSqlCommand.Parameters.Add("@hddistcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hddistcode"].Value = hddistcode;

                objSqlCommand.Parameters.Add("@billf", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billf"].Value = billfreq;

                objSqlCommand.Parameters.Add("@oldagen", SqlDbType.VarChar);
                objSqlCommand.Parameters["@oldagen"].Value = oldagen;

                objSqlCommand.Parameters.Add("@booktype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktype"].Value = booktype;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;

                objSqlCommand.Parameters.Add("@p_raterevise", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_raterevise"].Value = raterevise;

                objSqlCommand.Parameters.Add("@p_insertremarkdet", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_insertremarkdet"].Value = insertremark;

                objSqlCommand.Parameters.Add("@p_editionwisebilling", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_editionwisebilling"].Value = editionwisebilling;

                objSqlCommand.Parameters.Add("@p_executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_executive"].Value = executive;

                objSqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
                objSqlCommand.Parameters["@email"].Value = email;


                objSqlCommand.Parameters.Add("@age_desig", SqlDbType.VarChar);
                objSqlCommand.Parameters["@age_desig"].Value = age_desig;


                objSqlCommand.Parameters.Add("@emailidcc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@emailidcc"].Value = emailidcc;



                objSqlCommand.Parameters.Add("@kyc_attach", SqlDbType.VarChar);
                objSqlCommand.Parameters["@kyc_attach"].Value = kyc_attach;

                objSqlCommand.Parameters.Add("@intrestcalculation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@intrestcalculation"].Value = intrestcalculation;


                objSqlCommand.Parameters.Add("@sapcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sapcode"].Value = sapcode;


                objSqlCommand.Parameters.Add("@Billflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Billflag"].Value = bilflag;

                objSqlCommand.Parameters.Add("@psecurity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psecurity"].Value = secure;

                objSqlCommand.Parameters.Add("@pgstaus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstaus"].Value = gstattus;


                objSqlCommand.Parameters.Add("@pgstdate", SqlDbType.VarChar);
                if (gstdt == "")
                {
                    objSqlCommand.Parameters["@pgstdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = gstdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        gstdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = gstdt.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        gstdt = mm + "/" + dd + "/" + yy;
                    }
                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = gstdt.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            gstdt = mm + "/" + dd + "/" + yy;
                        }
                    objSqlCommand.Parameters["@pgstdate"].Value = Convert.ToDateTime(gstdt);
                }

                objSqlCommand.Parameters.Add("@pgstin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstin"].Value = gstin;

                objSqlCommand.Parameters.Add("@creditdays", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditdays"].Value = creditdays;

                objSqlCommand.Parameters.Add("@creditlimitdays", SqlDbType.VarChar);
                objSqlCommand.Parameters["@creditlimitdays"].Value = creditlimitdays;

                objSqlCommand.Parameters.Add("@recoverylimit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@recoverylimit"].Value = recoverylimit;

                objSqlCommand.Parameters.Add("@vatno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vatno"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@retain", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retain"].Value = retainer;

                objSqlCommand.Parameters.Add("@blankcheque", SqlDbType.VarChar);
                objSqlCommand.Parameters["@blankcheque"].Value =blankcheque;

                objSqlCommand.Parameters.Add("@secrtybond", SqlDbType.VarChar);
                objSqlCommand.Parameters["@secrtybond"].Value = Securitybond;

                objSqlCommand.Parameters.Add("@kycappli", SqlDbType.VarChar);
                objSqlCommand.Parameters["@kycappli"].Value =kycapp;

                objSqlCommand.Parameters.Add("@addproof", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addproof"].Value = addproof;

                objSqlCommand.Parameters.Add("@pgstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstatus"].Value = gstatus;

                objSqlCommand.Parameters.Add("@pgstclty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgstclty"].Value = gstcltya;

                 objSqlCommand.Parameters.Add("@pgstarno", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pgstarno"].Value = gstarno;

                 objSqlCommand.Parameters.Add("@pgstprovid", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pgstprovid"].Value = gstprovid;

                 objSqlCommand.Parameters.Add("@pgsteftdt", SqlDbType.VarChar);
                 if (gsteftdt == "")
                 {
                     objSqlCommand.Parameters["@pgsteftdt"].Value = System.DBNull.Value;
                 }
                 else
                 {
                     if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = gsteftdt.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         gsteftdt = mm + "/" + dd + "/" + yy;
                     }
                     else if (dateformat == "mm/dd/yyyy")
                     {
                         string[] arr = gsteftdt.Split('/');
                         string dd = arr[1];
                         string mm = arr[0];
                         string yy = arr[2];
                         gsteftdt = mm + "/" + dd + "/" + yy;
                     }
                     else
                         if (dateformat == "yyyy/mm/dd")
                         {
                             string[] arr = gsteftdt.Split('/');
                             string dd = arr[2];
                             string mm = arr[1];
                             string yy = arr[0];
                             gsteftdt = mm + "/" + dd + "/" + yy;
                         }
                     objSqlCommand.Parameters["@pgsteftdt"].Value = Convert.ToDateTime(gsteftdt);
                 }

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet agencycode(string code, string compcode, string userid, string type,string subcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_agencycode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

                objSqlCommand.Parameters.Add("@subcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcode"].Value = subcode;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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

        //public DataSet addregion(string regioncode)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("addregion", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        //				objSqlCommand.Parameters["@compcode"].Value =compcode;
        //        //
        //        //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        //				objSqlCommand.Parameters["@userid"].Value =userid;

        //        objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@regioncode"].Value = regioncode;


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


        public DataSet addregion(string regioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pcmaddregion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@compcode"].Value =compcode;
                //
                //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@regioncode"].Value = regioncode;


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

        public DataSet addregionexe(string regioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("addregionpop", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@compcode"].Value =compcode;
                //
                //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@regioncode"].Value = regioncode;


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


        public DataSet addstate1(string regioncode, string userid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_state", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@regioncode"].Value = regioncode;


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


        public DataSet add()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("region", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@dist"].Value =dist;
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

        public DataSet agentcheck(string agencycode, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_agentcheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


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


        public DataSet formpermission(string compcode, string userid, string formname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_showpermission", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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


        public DataSet formpermissionall(string compcode, string userid, string formname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_showpermission", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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

        public DataSet adcountryname(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adcountryname", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;
                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet filrategroup(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bindrateforpreferrence", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }




        public DataSet countcity(string txtcountry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@txtcountry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtcountry"].Value = txtcountry;

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


        public DataSet countcode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcodeagen", ref objSqlConnection);
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

        public DataSet bindbill(string agencyname, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindbillto", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agencyname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyname"].Value = agencyname;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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




        public DataSet fillsubho(string subagencode, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillsubho", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@subagencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencode"].Value = subagencode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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

        public DataSet chkshow(string hiddencomcode, string hiddenuserid, string hiddenagevcode, string hiddenagensubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkagentshow", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = hiddenuserid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = hiddencomcode;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = hiddenagevcode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = hiddenagensubcode;


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



        public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("payfill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = hiddenuserid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = hiddencomcode;

                

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



        public DataSet countcode(string str, string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcodename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@sub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sub"].Value = str;


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


        public DataSet countsubcode(string str, string agencode, string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkcodeagen", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;


                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

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


        public DataSet chk(string agencode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkagencode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;


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


        public DataSet bindagency(string compcode, string userid, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencynameonkey", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

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

        public DataSet SubAgencyBind(string agency, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("SubAgencyBind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;




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

        public DataSet GetAgencyNameAdd(string client, string compcode, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GetAgencyName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlDataAdapter = new SqlDataAdapter();
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

        public void agentpayinsert(string compcode, string agecode, string agencysubcode, string userid, int i, string strMode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcomm;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcomm = GetCommand("agentpayinsert", ref sqlcon);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                sqlcomm.Parameters.Add("@Cash", SqlDbType.VarChar);
                sqlcomm.Parameters["@Cash"].Value = strMode;
                //sqlcomm.Parameters.Add("@Credit", SqlDbType.VarChar);
                //sqlcomm.Parameters["@Credit"].Value = strMode[1];
                //sqlcomm.Parameters.Add("@Bank", SqlDbType.VarChar);
                //sqlcomm.Parameters["@Bank"].Value = strMode[2];
                sqlcomm.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcomm.Parameters["@Comp_Code"].Value = compcode;

                sqlcomm.Parameters.Add("@agencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@agencycode"].Value = agecode;

                sqlcomm.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                sqlcomm.Parameters["@subagencycode"].Value = agencysubcode;

                sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcomm.Parameters["@userid"].Value = userid;
                sqlcomm.Parameters.Add("@Flag", SqlDbType.VarChar);
                sqlcomm.Parameters["@Flag"].Value = i;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref sqlcon); }
        }

        // from this we get the agency code and will bind to list box

        public DataSet bindagencycode(string agencyname,string compcode,string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencycodeinlistbox", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agencyname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyname"].Value = agencyname;


                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = System.DBNull.Value;



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

        public DataSet usercode(string agencode, string subagencode, string compcode, string userid, string agenname,string qbcuserid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkusercode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agenname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agenname"].Value = agenname;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencode;

                objSqlCommand.Parameters.Add("@subagencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencode"].Value = subagencode;



                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@qbcuserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@qbcuserid"].Value = qbcuserid;

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


        public DataSet filcat(string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("agecatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;



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



        public DataSet filsubcat(string subcat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("agesubcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = subcat;



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


        //public DataSet parent()
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("fillparent", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;


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


        //public DataSet filchild(string child)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("fillchild", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@child", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@child"].Value = child;

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



        public DataSet credfil(string agtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillcred", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;

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

        public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GetAgencyName_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet binduserid(string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getuserid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        //public DataSet chkdupCode(string code)
        //{

        //}


        //==================== for taluka===================///

        public DataSet bindtalu(string talukabind)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_talu", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@talukabind", SqlDbType.VarChar);
                objSqlCommand.Parameters["@talukabind"].Value = talukabind;

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

        public void saveaduser(string agencycode, string depocode, string genno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("aduserinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@depocode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@depocode"].Value = depocode;

                objSqlCommand.Parameters.Add("@genno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@genno"].Value = genno;
 
                objSqlCommand.ExecuteNonQuery();
               
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
    public DataSet getClientNameadd(string client, string compcode, string value, string datecheck)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforagency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@datecheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datecheck"].Value = datecheck;

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

//==============************To show Agency Client Remark History**********************============//
    public DataSet getagencyclientremark(string agency_code, string subagency_code, string cust_code, string type, string compcode, string dateformat)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("ADB_GETAGENCY_REMARKDETAIL", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@p_agency_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_agency_code"].Value = agency_code;

            objSqlCommand.Parameters.Add("@p_subagency_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_subagency_code"].Value = subagency_code;

            objSqlCommand.Parameters.Add("@p_cust_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_cust_code"].Value = cust_code;

            objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@p_type", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_type"].Value = type;

            objSqlCommand.Parameters.Add("@p_dateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_dateformat"].Value = dateformat;

            objSqlCommand.Parameters.Add("@extra", SqlDbType.VarChar);
            objSqlCommand.Parameters["@extra"].Value = System.DBNull.Value;

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


    public DataSet agencybind(string custCode, string agencyname, string userid, string datformat)
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        con = GetConnection();

        try
        {
            con.Open();
            cmd = GetCommand("ad_agency_bind_p", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            cmd.Parameters["@pcompcode"].Value = custCode;

            cmd.Parameters.Add("@pag_name", SqlDbType.VarChar);
            cmd.Parameters["@pag_name"].Value = agencyname;

            cmd.Parameters.Add("@puserid", SqlDbType.VarChar);
            cmd.Parameters["@puserid"].Value = userid;

            cmd.Parameters.Add("@pdateformat", SqlDbType.VarChar);
            cmd.Parameters["@pdateformat"].Value = datformat;

            cmd.Parameters.Add("@pextra1", SqlDbType.VarChar);
            cmd.Parameters["@pextra1"].Value = System.DBNull.Value;

            cmd.Parameters.Add("@pextra2", SqlDbType.VarChar);
            cmd.Parameters["@pextra2"].Value = System.DBNull.Value;

            cmd.Parameters.Add("@pextra3", SqlDbType.VarChar);
            cmd.Parameters["@pextra3"].Value = System.DBNull.Value;

            cmd.Parameters.Add("@pextra4", SqlDbType.VarChar);
            cmd.Parameters["@pextra4"].Value = System.DBNull.Value;

            cmd.Parameters.Add("@pextra5", SqlDbType.VarChar);
            cmd.Parameters["@pextra5"].Value = System.DBNull.Value;

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;

        }

        catch (Exception ex)
        {
            throw (ex);


        }

        finally
        {
            CloseConnection(ref con);

        }
    }



    public DataSet Checkduplicay2(string custCode, string branchcode, string Agencyname, string panno)
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        con = GetConnection();

        try
        {
            con.Open();
            cmd = GetCommand("chkpanclientagency", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            cmd.Parameters["@pcompcode"].Value = custCode;

            cmd.Parameters.Add("@pbranch", SqlDbType.VarChar);
            cmd.Parameters["@pbranch"].Value = branchcode;

            cmd.Parameters.Add("@pagency", SqlDbType.VarChar);
            cmd.Parameters["@pagency"].Value = Agencyname;

            cmd.Parameters.Add("@ppanno", SqlDbType.VarChar);
            cmd.Parameters["@ppanno"].Value = panno;


            cmd.Parameters.Add("@pextera", SqlDbType.VarChar);
            cmd.Parameters["@pextera"].Value = System.DBNull.Value;

            cmd.Parameters.Add("@pextera2", SqlDbType.VarChar);
            cmd.Parameters["@pextera2"].Value = System.DBNull.Value;

            cmd.Parameters.Add("@pextera3", SqlDbType.VarChar);
            cmd.Parameters["@pextera3"].Value = System.DBNull.Value;

           

            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;

        }

        catch (Exception ex)
        {
            throw (ex);


        }

        finally
        {
            CloseConnection(ref con);

        }
    }


    public DataSet addcategorybind(string agtypcod)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bindagencytype", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agencytype"].Value = agtypcod;

            //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            //objSqlCommand.Parameters["@compcode"].Value = compcode;

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

    public DataSet fetchdata(string compcode, string booking)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("fetchdatapayment_gateway", ref con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            com.Parameters["@pcompcode"].Value = compcode;

            com.Parameters.Add("@pbookingid", SqlDbType.VarChar);
            com.Parameters["@pbookingid"].Value = booking;
            da.SelectCommand = com;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref con);
        }
    }

    }

    

}
