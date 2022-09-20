using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for Master
    /// </summary>
    public class Master : orclconnection
    {
        public Master()
        {
            //
            // TODO: Add constructor logic here
            //
        }


       
        
        public DataSet checkagencycode(string comp, string type, string agencycode, string agencysubcode, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CheckSavedAgencyCode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pCompCode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comp;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pType", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = type;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pAgencyCode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pAgencySubCode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("pExtra1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra1;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pExtra2", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra2;
                objOraclecommand.Parameters.Add(prm6);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet fillmrv1(string compcode, string dateformat, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("agency_mrv_region_bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                objOraclecommand.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pextra3", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra3;
                objOraclecommand.Parameters.Add(prm6);




                OracleParameter prm7 = new OracleParameter("pextra4", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra4;
                objOraclecommand.Parameters.Add(prm7);




                OracleParameter prm8 = new OracleParameter("pextra5", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = extra5;
                objOraclecommand.Parameters.Add(prm8);










                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }




        public DataSet chkdupagencycode(string agname, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdupagencycode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agname;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet chkdupagency(string agname, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdupagname", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agname;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet givepermission(string userid, string compcode, string formname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletepermition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("formname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = formname;
                objOraclecommand.Parameters.Add(prm1);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet formpermissionall(string compcode, string userid, string formname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_showpermission.websp_showpermission_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("Formname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = formname;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("vuserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet formpermission(string compcode, string userid, string formname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_showpermission.websp_showpermission_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("vuserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("formname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = formname;
                objOraclecommand.Parameters.Add(prm1);
                //objOraclecommand.Parameters.Add("formname", SqlDbType.VarChar);
                //objOraclecommand.Parameters["formname"].Value = formname;

                //objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                //objOraclecommand.Parameters["compcode"].Value = compcode;

                //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["userid"].Value = userid;


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }


        public DataSet adcountryname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcountryname.adcountryname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet addcity()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_addcity.Websp_addcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet countcity(string txtcountry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcity.fillcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("txtcountry", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = txtcountry;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
//=============================================================================================================

        public DataSet Insertcompanymaster(string compcode, string compname, string add, string street, string district, string country, string state, string pin, string mail, string phne, string fax, string pan, string tan, string regno, string date, string boxadd, string remarks, string allias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_companymaster.websp_companymaster_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("add", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = add;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("date", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToDateTime(date);
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("street", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = street;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("district", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = district;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("country", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = country;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("state", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = state;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9= new OracleParameter("pin", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pin;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("mail", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = mail;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("phne", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = phne;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fax;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm13 = new OracleParameter("pan", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pan;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("tan", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = tan;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15= new OracleParameter("regno", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = regno;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("boxadd", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = boxadd;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("remarks", OracleType.VarChar, 500);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = remarks;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("allias", OracleType.VarChar, 500);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = allias;
                objOraclecommand.Parameters.Add(prm18);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet selectfirst()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_selectfirst.Websp_selectfirst_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet addregion1(string values)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_addregion.websp_addregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm18 = new OracleParameter("values", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = values;
                objOraclecommand.Parameters.Add(prm18);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }



        public DataSet addagent_typ(string userid, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_agent.Websp_agent_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet adzone(string userid, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindzone.bindzone_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet addagenttyp(string agent)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_addagent.websp_addagent_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("agent", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agent;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet addstate(string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_addstate.websp_addstate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("statecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet adddist(string dist)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_adddist.websp_adddist_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("dist", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dist;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }



        public DataSet subcategory(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_addagencysubcat.websp_addagencysubcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet representative(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_representative.websp_representative_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet saveagent(string compcode, string agencytype, string agentcategory, string agentcategory2, string agentcode, string agentname, string alias, string agencyho, string address, string street, string city, string district, string state, string country, string phone, string fax, string mail, string url, string bussinessstartdate, string enrolldate, string mrerefferenceno, string novts, string credit, string pan, string tan, string stacno, string status, string remarks, string userid, string subagencyho, string agencycode, string billto, string alert, string creditlimit, string code, string representative, string pin, string region, string type, string zone, string address1, string address2, string curtype, string acagen, string fax2, string rategrp, string paymode, string qbcuserid, string dateformat, string taluka, string branchcode, string hdstatecode, string hddistcode, string billf, string oldagency, string booktype, string vat, string raterevise, string editionwise, string executive, string bill, string age_desig, string mrv, string creditdays, string creditlimitdays, string recoverylimit, string emailidcc, string kyc, string intrestcalculation, string bilflag, string subsubcd1, string sapcode, string security, string gstus, string gstdt, string gstin, string retainer, string blcheque, string scuritybond, string kycapp, string addproof, string gstatus, string gstclty, string gstarno, string gstprovid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_saveagent.websp_saveagent_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("agencytype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencytype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("agentcategory", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agentcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("agentcategory2", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agentcategory2;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("agentcode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = agentcode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("agentname", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = agentname;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = alias;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm14 = new OracleParameter("agencyho", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = agencyho;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm3 = new OracleParameter("txtfax1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fax2;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm15 = new OracleParameter("address", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = address;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm18 = new OracleParameter("street", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = street;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("city", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = city;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("district1", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = district;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("state1", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = state;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("country", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = country;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = phone;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = fax;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm27 = new OracleParameter("mail", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = mail;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("url1", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = url;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("bussinessstartdate", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                if (bussinessstartdate == "")
                {
                    prm29.Value = bussinessstartdate;
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
                    else if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = bussinessstartdate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            bussinessstartdate = mm + "/" + dd + "/" + yy;

                        }
                        else 
                            {
                                string[] arr = bussinessstartdate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                bussinessstartdate = mm + "/" + dd + "/" + yy;
                            }
                    prm29.Value = Convert.ToDateTime(bussinessstartdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("enrolldate", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                if (enrolldate == "")
                {
                    prm30.Value = enrolldate;
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
                    else if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = enrolldate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
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
                    prm30.Value = Convert.ToDateTime(enrolldate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("novts", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = novts;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("credit", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = credit;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("pan", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = pan;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("TAN", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = tan;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("stacno", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = stacno;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm6 = new OracleParameter("paymode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = paymode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm36 = new OracleParameter("status", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = status;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("remarks", OracleType.VarChar, 500);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = remarks;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = userid;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm13 = new OracleParameter("mrerefferenceno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = mrerefferenceno;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm39 = new OracleParameter("subagencyho", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = subagencyho;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = agencycode;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("billto", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = billto;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("alert", OracleType.VarChar, 500);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = alert;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("creditlimit", OracleType.VarChar, 50);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = creditlimit;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("code", OracleType.VarChar, 50);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = code;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("representative", OracleType.VarChar, 50);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = representative;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pin", OracleType.VarChar, 50);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pin;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("region1", OracleType.VarChar, 50);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = region;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("TYPE1", OracleType.VarChar, 50);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = type;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm25 = new OracleParameter("ZONE1", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = zone;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm16 = new OracleParameter("address1", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = address1;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("address2", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = address2;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm5 = new OracleParameter("curtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = curtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm2 = new OracleParameter("acagen", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = acagen;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("rategrp", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rategrp;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm49 = new OracleParameter("qbcuserid", OracleType.VarChar, 50);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = qbcuserid;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm491 = new OracleParameter("taluka1", OracleType.VarChar, 50);
                prm491.Direction = ParameterDirection.Input;
                prm491.Value = taluka;
                objOraclecommand.Parameters.Add(prm491);

                OracleParameter prm50 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = branchcode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm4911 = new OracleParameter("hddistcode", OracleType.VarChar, 50);
                prm4911.Direction = ParameterDirection.Input;
                prm4911.Value = hddistcode;
                objOraclecommand.Parameters.Add(prm4911);

                OracleParameter prm501 = new OracleParameter("hdstatecode", OracleType.VarChar, 50);
                prm501.Direction = ParameterDirection.Input;
                prm501.Value = hdstatecode;
                objOraclecommand.Parameters.Add(prm501);

                OracleParameter prm502 = new OracleParameter("billf", OracleType.VarChar, 50);
                prm502.Direction = ParameterDirection.Input;
                prm502.Value = billf;
                objOraclecommand.Parameters.Add(prm502);

                OracleParameter prm503 = new OracleParameter("oldagency", OracleType.VarChar, 50);
                prm503.Direction = ParameterDirection.Input;
                prm503.Value = oldagency;
                objOraclecommand.Parameters.Add(prm503);

                OracleParameter prm504 = new OracleParameter("booktype1", OracleType.VarChar, 50);
                prm504.Direction = ParameterDirection.Input;
                prm504.Value = booktype;
                objOraclecommand.Parameters.Add(prm504);

                OracleParameter prm505 = new OracleParameter("vat1", OracleType.VarChar, 50);
                prm505.Direction = ParameterDirection.Input;
                prm505.Value = vat;
                objOraclecommand.Parameters.Add(prm505);

                OracleParameter prm506 = new OracleParameter("p_raterevise", OracleType.VarChar, 50);
                prm506.Direction = ParameterDirection.Input;
                prm506.Value = raterevise;
                objOraclecommand.Parameters.Add(prm506);

                OracleParameter prm508 = new OracleParameter("p_editionwisebilling", OracleType.VarChar, 50);
                prm508.Direction = ParameterDirection.Input;
                prm508.Value = editionwise;
                objOraclecommand.Parameters.Add(prm508);

                OracleParameter prm509 = new OracleParameter("pexecutive", OracleType.VarChar, 50);
                prm509.Direction = ParameterDirection.Input;
                prm509.Value = executive;
                objOraclecommand.Parameters.Add(prm509);

                OracleParameter prm510 = new OracleParameter("pemail", OracleType.VarChar, 50);
                prm510.Direction = ParameterDirection.Input;
                prm510.Value = bill;
                objOraclecommand.Parameters.Add(prm510);

                OracleParameter prm511 = new OracleParameter("page_desig", OracleType.VarChar, 50);
                prm511.Direction = ParameterDirection.Input;
                prm511.Value = age_desig;
                objOraclecommand.Parameters.Add(prm511);
                
                OracleParameter prm512 = new OracleParameter("pzip", OracleType.VarChar, 50);
                prm512.Direction = ParameterDirection.Input;
                prm512.Value = mrv;
                objOraclecommand.Parameters.Add(prm512);

                OracleParameter prm5066 = new OracleParameter("creditdays", OracleType.VarChar, 50);
                prm5066.Direction = ParameterDirection.Input;
                prm5066.Value = creditdays;
                objOraclecommand.Parameters.Add(prm5066);

                OracleParameter prm5077 = new OracleParameter("creditlimitdays", OracleType.VarChar, 50);
                prm5077.Direction = ParameterDirection.Input;
                if (creditlimitdays == "")
                {
                    prm5077.Value = creditlimitdays;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = enrolldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                          creditlimitdays = dd + "/" + mm + "/" + yy;
                    }
                    else if (dateformat == "mm/dd/yyyy")
                        {
                            string[] arr = enrolldate.Split('/');
                            string dd = arr[1];
                            string mm = arr[0];
                            string yy = arr[2];
                            creditlimitdays = mm + "/" + dd + "/" + yy;
                        }
                        else
                            if (dateformat == "yyyy/mm/dd")
                            {
                                string[] arr = enrolldate.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                creditlimitdays = mm + "/" + dd + "/" + yy;
                            }
                    prm5077.Value = Convert.ToDateTime(creditlimitdays).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5077);

                OracleParameter prm5088 = new OracleParameter("recoverylimit", OracleType.VarChar, 50);
                prm5088.Direction = ParameterDirection.Input;
                prm5088.Value = recoverylimit;
                objOraclecommand.Parameters.Add(prm5088);

                OracleParameter prm50661 = new OracleParameter("pemailidcc", OracleType.VarChar, 50);
                prm50661.Direction = ParameterDirection.Input;
                prm50661.Value = emailidcc;
                objOraclecommand.Parameters.Add(prm50661);

                OracleParameter prm506623 = new OracleParameter("pkyc_attach", OracleType.VarChar, 50);
                prm506623.Direction = ParameterDirection.Input;
                prm506623.Value = kyc;
                objOraclecommand.Parameters.Add(prm506623);

                OracleParameter prm506624 = new OracleParameter("intrestcalculation", OracleType.VarChar, 50);
                prm506624.Direction = ParameterDirection.Input;
                prm506624.Value = intrestcalculation;
                objOraclecommand.Parameters.Add(prm506624);

                OracleParameter prm506625 = new OracleParameter("PBillflag", OracleType.VarChar, 50);
                prm506625.Direction = ParameterDirection.Input;
                prm506625.Value = bilflag;
                objOraclecommand.Parameters.Add(prm506625);

                OracleParameter prm506626 = new OracleParameter("Pvatno", OracleType.VarChar, 50);
                prm506626.Direction = ParameterDirection.Input;
                prm506626.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm506626); 

                OracleParameter prm506660 = new OracleParameter("psubsubagcode", OracleType.VarChar, 50);
                prm506660.Direction = ParameterDirection.Input;
                prm506660.Value = subsubcd1;
                objOraclecommand.Parameters.Add(prm506660);

                    OracleParameter prm221 = new OracleParameter("sapcode", OracleType.VarChar, 50);
                  prm221.Direction = ParameterDirection.Input;
                  prm221.Value = sapcode;
                  objOraclecommand.Parameters.Add(prm221);

                  OracleParameter prm222 = new OracleParameter("psecurity", OracleType.VarChar, 50);
                  prm222.Direction = ParameterDirection.Input;
                  prm222.Value = security;
                  objOraclecommand.Parameters.Add(prm222);

                  OracleParameter prm223 = new OracleParameter("pgstaus", OracleType.VarChar, 50);
                  prm223.Direction = ParameterDirection.Input;
                  prm223.Value = gstus;
                  objOraclecommand.Parameters.Add(prm223);

                  OracleParameter prm224 = new OracleParameter("pgstdate", OracleType.VarChar, 50);
                  prm224.Direction = ParameterDirection.Input;
                  if (gstdt == "")
                  {
                      prm224.Value = System.DBNull.Value;
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
                      prm224.Value = Convert.ToDateTime(gstdt).ToString("dd-MMMM-yyyy");
                  }                 
                  objOraclecommand.Parameters.Add(prm224);

                  OracleParameter prm225 = new OracleParameter("pgstin", OracleType.VarChar, 50);
                  prm225.Direction = ParameterDirection.Input;
                  prm225.Value = gstin;
                  objOraclecommand.Parameters.Add(prm225);

                  OracleParameter prm2125 = new OracleParameter("pretain", OracleType.VarChar, 50);
                  prm2125.Direction = ParameterDirection.Input;
                  prm2125.Value = retainer;
                  objOraclecommand.Parameters.Add(prm2125);

                  OracleParameter prm2225 = new OracleParameter("pblankcheque", OracleType.VarChar, 50);
                  prm2225.Direction = ParameterDirection.Input;
                  prm2225.Value = blcheque;
                  objOraclecommand.Parameters.Add(prm2225);

                  OracleParameter prm2e25 = new OracleParameter("psecrtybond", OracleType.VarChar, 50);
                  prm2e25.Direction = ParameterDirection.Input;
                  prm2e25.Value = scuritybond;
                  objOraclecommand.Parameters.Add(prm2e25);

                  OracleParameter prm2r25 = new OracleParameter("pkycappli", OracleType.VarChar, 50);
                  prm2r25.Direction = ParameterDirection.Input;
                  prm2r25.Value = kycapp;
                  objOraclecommand.Parameters.Add(prm2r25);

                  OracleParameter prm225t = new OracleParameter("paddproof", OracleType.VarChar, 50);
                  prm225t.Direction = ParameterDirection.Input;
                  prm225t.Value = addproof;
                  objOraclecommand.Parameters.Add(prm225t);

                  OracleParameter prm225tt = new OracleParameter("pgstatus", OracleType.VarChar, 50);
                  prm225tt.Direction = ParameterDirection.Input;
                  prm225tt.Value = gstatus;
                  objOraclecommand.Parameters.Add(prm225tt);

                  OracleParameter prm225ttt = new OracleParameter("pgstclty", OracleType.VarChar, 50);
                  prm225ttt.Direction = ParameterDirection.Input;
                  prm225ttt.Value = gstclty;
                  objOraclecommand.Parameters.Add(prm225ttt);

                  OracleParameter prm225tttt = new OracleParameter("pgstarno", OracleType.VarChar);
                  prm225tttt.Direction = ParameterDirection.Input;
                  prm225tttt.Value = gstarno;
                  objOraclecommand.Parameters.Add(prm225tttt);

                  OracleParameter prm225ttttt = new OracleParameter("pgstprovid", OracleType.VarChar);
                  prm225ttttt.Direction = ParameterDirection.Input;
                  prm225ttttt.Value = gstprovid;
                  objOraclecommand.Parameters.Add(prm225ttttt);
         
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        //
        public DataSet addagency(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_addagency.websp_addagency_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }


        public DataSet filcur(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("filcur.filcur_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet firstquery(string compcode, string userid, string agencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_agencyfirst.websp_agencyfirst_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet executeagency(string compcode, string userid, string agentcode, string subagencycode, string agencyname1, string alias, string agenttype, string agentcategory, string agentsubcategory, string city, string count, string branchcode, string billfreq)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_executeagency.websp_executeagency_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agentcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agentcode;
                objOraclecommand.Parameters.Add(prm3);

          

                OracleParameter prm4 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm4);

           

                OracleParameter prm5 = new OracleParameter("agencyname1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencyname1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = alias;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7= new OracleParameter("agenttype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (agenttype == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = agenttype;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("agentcategory", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (agentcategory == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = agentcategory;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("agentsubcategory", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (agentsubcategory == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {

                    prm9.Value = agentsubcategory;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("city", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (city == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = city;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("COUNT1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (count == "0")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = count;
                }
                objOraclecommand.Parameters.Add(prm11);
                
                OracleParameter prm12 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (branchcode == "0")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = branchcode;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("billf", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (billfreq == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = billfreq;
                }
                objOraclecommand.Parameters.Add(prm13);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet agentdelete(string compcode, string userid, string agentcode, string subagency, string codesubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_deleteagent.websp_deleteagent_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("agentcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agentcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("subagency", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subagency;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("codesubcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = codesubcode;
                objOraclecommand.Parameters.Add(prm5);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet chkagent(string compcode, string userid, string agencycode, string subagencycode, string agencyname, string alias, string agenttype, string agentcategory, string agentsubcategory, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_chkagent.websp_chkagent_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("agentcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("agencyname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencyname;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = alias;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("agenttype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agenttype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("agentcategory", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = agentcategory;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("agentsubcategory", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agentsubcategory;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("city", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = city;
                objOraclecommand.Parameters.Add(prm10);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet agencymodify(string compcode, string agencytype, string agentcategory, string agentcategory2, string agentcode, string agentname, string alias, string agencyho, string address, string street, string city, string zip, string district, string state, string country, string phone, string mail, string fax, string url, string bussinessstartdate, string enrolldate, string mrerefferenceno, string novts, string credit, string pan, string tan, string stacno, string paymode, string status, string remarks, string userid, string statusdate, string subagencyho, string agencycode, string billto, string alert, string creditlimit, string code, string region, string representative, string pincode, string stacno1, string type, string zone, string address1, string address2, string curtype, string acagen, string fax2, string rategrp, string qbcuserid, string dateformat, string depocode, string taluka, string branchcode, string hdstatecode, string hddistcode, string billfreq, string oldagen, string booktype, string vat, string raterevise, string insertremark, string editionwisebilling, string executive, string email, string age_desig, string creditdays, string creditlimitdays, string recoverylimit, string emailcc, string kyc_attach, string intrestcalculation, string bilflag, string sapcode, string secure, string gstattus, string gstdt, string gstin, string retainer, string blankcheque, string Securitybond, string kycapp, string addproof, string gstatus, string gstcltya, string gstarno, string gstprovid, string gstefectivedt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_agencymodify.websp_agencymodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("agencytype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencytype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("agentcategory", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agentcategory;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("agentcategory2", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agentcategory2;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("agentcode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = agentcode;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("agentname", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = agentname;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = alias;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm14 = new OracleParameter("agencyho", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = agencyho;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm48 = new OracleParameter("TYPE1", OracleType.VarChar, 50);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = type;
                objOraclecommand.Parameters.Add(prm48);


                OracleParameter prm15 = new OracleParameter("address", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = address;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm18 = new OracleParameter("street", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = street;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("city", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = city;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm51 = new OracleParameter("zip", OracleType.VarChar, 50);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = zip;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm20 = new OracleParameter("district1", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = district;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("state1", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = state;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("country", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = country;
                objOraclecommand.Parameters.Add(prm22);



                OracleParameter prm23 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = phone;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm3 = new OracleParameter("txtfax2", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fax2;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm24 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = fax;
                objOraclecommand.Parameters.Add(prm24);



                OracleParameter prm27 = new OracleParameter("mail", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = mail;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("url1", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = url;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("bussinessstartdate", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                if (bussinessstartdate == "")
                    prm29.Value = System.DBNull.Value;
                else
                    prm29.Value = Convert.ToDateTime(bussinessstartdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("enrolldate", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                if (enrolldate == "")
                    prm30.Value = System.DBNull.Value;
                else
                    prm30.Value = Convert.ToDateTime(enrolldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("novts", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = novts;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("credit", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = credit;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("pan", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = pan;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("TAN", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = tan;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("stacno", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = stacno1;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter prm6 = new OracleParameter("paymode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = paymode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm36 = new OracleParameter("status", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = status;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("remarks", OracleType.VarChar, 500);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = remarks;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = userid;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm13 = new OracleParameter("mrerefferenceno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = mrerefferenceno;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm39 = new OracleParameter("subagencyho", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = subagencyho;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = agencycode;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("billto", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = billto;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("alert1", OracleType.VarChar, 500);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = alert;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("creditlimit", OracleType.VarChar, 50);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = creditlimit;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("code", OracleType.VarChar, 50);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = code;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm47 = new OracleParameter("region1", OracleType.VarChar, 50);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = region;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm45 = new OracleParameter("representative", OracleType.VarChar, 50);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = representative;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("pincode", OracleType.VarChar, 50);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = pincode;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm53 = new OracleParameter("stacno1", OracleType.VarChar, 50);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = stacno1;
                objOraclecommand.Parameters.Add(prm53);

                OracleParameter prm25 = new OracleParameter("zone1", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = zone;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm16 = new OracleParameter("address1", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = address1;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("address2", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = address2;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm5 = new OracleParameter("curtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = curtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm2 = new OracleParameter("acagen", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = acagen;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("rategrp", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rategrp;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm49 = new OracleParameter("qbcuserid", OracleType.VarChar, 50);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = qbcuserid;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("depocode", OracleType.VarChar, 50);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = depocode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm511 = new OracleParameter("taluka1", OracleType.VarChar, 50);
                prm511.Direction = ParameterDirection.Input;
                prm511.Value = taluka;
                objOraclecommand.Parameters.Add(prm511);

                OracleParameter prm52 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = branchcode;
                objOraclecommand.Parameters.Add(prm52);

                OracleParameter prm4911 = new OracleParameter("hddistcode", OracleType.VarChar, 50);
                prm4911.Direction = ParameterDirection.Input;
                prm4911.Value = hddistcode;
                objOraclecommand.Parameters.Add(prm4911);

                OracleParameter prm501 = new OracleParameter("hdstatecode", OracleType.VarChar, 50);
                prm501.Direction = ParameterDirection.Input;
                prm501.Value = hdstatecode;
                objOraclecommand.Parameters.Add(prm501);

                OracleParameter prm502 = new OracleParameter("billf", OracleType.VarChar, 50);
                prm502.Direction = ParameterDirection.Input;
                prm502.Value = billfreq;
                objOraclecommand.Parameters.Add(prm502);

                OracleParameter prm503 = new OracleParameter("oldagen", OracleType.VarChar, 50);
                prm503.Direction = ParameterDirection.Input;
                prm503.Value = oldagen;
                objOraclecommand.Parameters.Add(prm503);

                OracleParameter prm504 = new OracleParameter("booktype1", OracleType.VarChar, 50);
                prm504.Direction = ParameterDirection.Input;
                prm504.Value = booktype;
                objOraclecommand.Parameters.Add(prm504);

                OracleParameter prm505 = new OracleParameter("vat1", OracleType.VarChar, 50);
                prm505.Direction = ParameterDirection.Input;
                prm505.Value = vat;
                objOraclecommand.Parameters.Add(prm505);

                OracleParameter prm506 = new OracleParameter("p_raterevise", OracleType.VarChar, 50);
                prm506.Direction = ParameterDirection.Input;
                prm506.Value = raterevise;
                objOraclecommand.Parameters.Add(prm506);

                OracleParameter prm507 = new OracleParameter("p_insertremarkdet", OracleType.VarChar, 50);
                prm507.Direction = ParameterDirection.Input;
                prm507.Value = insertremark;
                objOraclecommand.Parameters.Add(prm507);

                OracleParameter prm508 = new OracleParameter("p_editionwisebilling", OracleType.VarChar, 50);
                prm508.Direction = ParameterDirection.Input;
                prm508.Value = editionwisebilling;
                objOraclecommand.Parameters.Add(prm508);

                OracleParameter prm509 = new OracleParameter("pexecutive", OracleType.VarChar, 50);
                prm509.Direction = ParameterDirection.Input;
                prm509.Value = executive;
                objOraclecommand.Parameters.Add(prm509);


                OracleParameter prm510 = new OracleParameter("pemail", OracleType.VarChar, 50);
                prm510.Direction = ParameterDirection.Input;
                prm510.Value = email;
                objOraclecommand.Parameters.Add(prm510);

                OracleParameter prm513 = new OracleParameter("page_desig", OracleType.VarChar, 50);
                prm513.Direction = ParameterDirection.Input;
                prm513.Value = age_desig;
                objOraclecommand.Parameters.Add(prm513);


                OracleParameter prm5066 = new OracleParameter("creditdays", OracleType.VarChar, 50);
                prm5066.Direction = ParameterDirection.Input;
                prm5066.Value = creditdays;
                objOraclecommand.Parameters.Add(prm5066);


                OracleParameter prm5077 = new OracleParameter("creditlimitdays", OracleType.VarChar, 50);
                prm5077.Direction = ParameterDirection.Input;
                if (creditlimitdays == "")
                    prm5077.Value = System.DBNull.Value;
                else
                    prm507.Value = Convert.ToDateTime(creditlimitdays).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5077);




                OracleParameter prm5088 = new OracleParameter("recoverylimit", OracleType.VarChar, 50);
                prm5088.Direction = ParameterDirection.Input;
                prm5088.Value = recoverylimit;
                objOraclecommand.Parameters.Add(prm5088);

                OracleParameter prm50881 = new OracleParameter("pemailidcc", OracleType.VarChar, 50);
                prm50881.Direction = ParameterDirection.Input;
                prm50881.Value = emailcc;
                objOraclecommand.Parameters.Add(prm50881);


                OracleParameter prm508812 = new OracleParameter("pkyc_attach", OracleType.VarChar, 50);
                prm508812.Direction = ParameterDirection.Input;
                prm508812.Value = kyc_attach;
                objOraclecommand.Parameters.Add(prm508812);


                OracleParameter prm508813 = new OracleParameter("pintrestcalculation", OracleType.VarChar, 50);
                prm508813.Direction = ParameterDirection.Input;
                prm508813.Value = intrestcalculation;
                objOraclecommand.Parameters.Add(prm508813);



                OracleParameter prm508819 = new OracleParameter("PBillflag", OracleType.VarChar, 50);
                prm508819.Direction = ParameterDirection.Input;
                prm508819.Value = bilflag;
                objOraclecommand.Parameters.Add(prm508819);

                OracleParameter prm111 = new OracleParameter("sapcode", OracleType.VarChar, 50);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = sapcode;
                objOraclecommand.Parameters.Add(prm111);


                OracleParameter prm112 = new OracleParameter("Pvatno", OracleType.VarChar, 50);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm112);

                OracleParameter prm113 = new OracleParameter("psecurity", OracleType.VarChar, 50);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = secure;
                objOraclecommand.Parameters.Add(prm113);

                OracleParameter prm223 = new OracleParameter("pgstaus", OracleType.VarChar, 50);
                prm223.Direction = ParameterDirection.Input;
                prm223.Value = gstattus;
                objOraclecommand.Parameters.Add(prm223);

                OracleParameter prm224 = new OracleParameter("pgstdate", OracleType.VarChar, 50);
                prm224.Direction = ParameterDirection.Input;
                if (gstdt == "")
                {
                    prm224.Value = System.DBNull.Value;
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
                    prm224.Value = Convert.ToDateTime(gstdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm224);

                OracleParameter prm225 = new OracleParameter("pgstin", OracleType.VarChar, 50);
                prm225.Direction = ParameterDirection.Input;
                prm225.Value = gstin;
                objOraclecommand.Parameters.Add(prm225);
                OracleParameter prm2125 = new OracleParameter("pretain", OracleType.VarChar, 50);
                prm2125.Direction = ParameterDirection.Input;
                prm2125.Value = retainer;
                objOraclecommand.Parameters.Add(prm2125);

                OracleParameter prm2225 = new OracleParameter("pblankcheque", OracleType.VarChar, 50);
                prm2225.Direction = ParameterDirection.Input;
                prm2225.Value = blankcheque;
                objOraclecommand.Parameters.Add(prm2225);

                OracleParameter prm2e25 = new OracleParameter("psecrtybond", OracleType.VarChar, 50);
                prm2e25.Direction = ParameterDirection.Input;
                prm2e25.Value = Securitybond;
                objOraclecommand.Parameters.Add(prm2e25);

                OracleParameter prm2r25 = new OracleParameter("pkycappli", OracleType.VarChar, 50);
                prm2r25.Direction = ParameterDirection.Input;
                prm2r25.Value = kycapp;
                objOraclecommand.Parameters.Add(prm2r25);

                OracleParameter prm225t = new OracleParameter("paddproof", OracleType.VarChar, 50);
                prm225t.Direction = ParameterDirection.Input;
                prm225t.Value = addproof;
                objOraclecommand.Parameters.Add(prm225t);

                OracleParameter prm225tt = new OracleParameter("pgstatus", OracleType.VarChar, 50);
                prm225tt.Direction = ParameterDirection.Input;
                prm225tt.Value = gstatus;
                objOraclecommand.Parameters.Add(prm225tt);

                OracleParameter prm225ttt = new OracleParameter("pgstclty", OracleType.VarChar, 50);
                prm225ttt.Direction = ParameterDirection.Input;
                prm225ttt.Value = gstcltya;
                objOraclecommand.Parameters.Add(prm225ttt);

                OracleParameter prm225tttt = new OracleParameter("pgstarno", OracleType.VarChar);
                prm225tttt.Direction = ParameterDirection.Input;
                prm225tttt.Value = gstarno;
                objOraclecommand.Parameters.Add(prm225tttt);

                OracleParameter prm225ttttt = new OracleParameter("pgstprovid", OracleType.VarChar);
                prm225ttttt.Direction = ParameterDirection.Input;
                prm225ttttt.Value = gstprovid;
                objOraclecommand.Parameters.Add(prm225ttttt);

                OracleParameter prm226ttttt = new OracleParameter("pgstefectivedt", OracleType.VarChar);
                prm226ttttt.Direction = ParameterDirection.Input;
                prm226ttttt.Value = gstefectivedt;
                objOraclecommand.Parameters.Add(prm226ttttt);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet agencycode(string code, string compcode, string userid, string type, string subcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_agencycode.websp_agencycode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = code;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm1 = new OracleParameter("subcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = subcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("type", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = type;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }


        public DataSet addregion(string regioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmaddregion.pcmaddregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = regioncode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet addregionexe(string regioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("addregionpop.addregionpop_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = regioncode;
                objOraclecommand.Parameters.Add(prm1);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet addstate1(string regioncode, string userid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_state.websp_state_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = regioncode;
                objOraclecommand.Parameters.Add(prm1);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet add()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("region.region_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet agentcheck(string agencycode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_agentcheck.websp_agentcheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agencycode;
                objOraclecommand.Parameters.Add(prm1);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }


      

        public DataSet filrategroup(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindrateforpreferrence.bindrateforpreferrence_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }




      


        public DataSet countcode(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcodeagen.chkcodeagen_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("str", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = str;
                objOraclecommand.Parameters.Add(prm3);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet bindbill(string agencyname, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindbillto.bindbillto_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("agencyname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agencyname;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }




        public DataSet fillsubho(string subagencode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillsubho.fillsubho_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("subagencode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = subagencode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet chkshow(string hiddencomcode, string hiddenuserid, string hiddenagevcode, string hiddenagensubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkagentshow.chkagentshow_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = hiddencomcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = hiddenuserid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = hiddenagevcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2= new OracleParameter("agencysubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = hiddenagensubcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }



        }



        public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("payfill.payfill_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = hiddencomcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = hiddenuserid;
                objOraclecommand.Parameters.Add(prm4);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }



        }



        public DataSet countcode(string str, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcodename.chkcodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("str", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = str;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm5.Value = str.Substring(0,2);
                }
                else
                {
                    prm5.Value = str;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("TYPE1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = type;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("sub", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (str.Length > 3)
                {
                    prm7.Value = str.Substring(0,3);
                    objOraclecommand.Parameters.Add(prm7);
                }
                else
                {
                    prm7.Value = str;
                    objOraclecommand.Parameters.Add(prm7);
                }
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet countsubcode(string str, string agencode, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcodeagen.chkcodeagen_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("str", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = str;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm5.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm5);
                }
                else
                {

                    prm5.Value = str;
                    objOraclecommand.Parameters.Add(prm5);
                }
                OracleParameter prm6 = new OracleParameter("type1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = type;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agencode;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet chk(string agencode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkagencode.chkagencode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm7 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agencode;
                objOraclecommand.Parameters.Add(prm7);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet bindagency(string compcode, string userid, string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencynameonkey.bindagencynameonkey_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agency;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet SubAgencyBind(string agency, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("SubAgencyBind.SubAgencyBind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agency;
                objOraclecommand.Parameters.Add(prm7);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet GetAgencyNameAdd(string client, string compcode, string value)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("GetAgencyName.GetAgencyName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("client", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("value", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = value;
                objOraclecommand.Parameters.Add(prm7);

                   objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public void agentpayinsert(string compcode, string agecode, string agencysubcode, string userid, int i, string strMode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("agentpayinsert.agentpayinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("Cash", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = strMode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5= new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agecode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("Flag", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = i;
                objOraclecommand.Parameters.Add(prm8);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
               
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }
        }

        // from this we get the agency code and will bind to list box

        public DataSet bindagencycode(string agencyname, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencycodeinlistbox.bindagencycodeinlistbox_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("agencyname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencyname;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet usercode(string agencode, string subagencode, string compcode, string userid, string agenname, string qbcuserid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkusercode.chkusercode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4= new OracleParameter("agenname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agenname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("subagencode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = subagencode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("qbcuserid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = qbcuserid;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet filcat(string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("agecatcode.agecatcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet filsubcat(string subcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("agesubcatcode.agesubcatcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = subcat;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


      

        public DataSet credfil(string agtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcred.fillcred_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agtype", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agtype;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("GetAgencyName_agency.GetAgencyName_agency_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("value1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet binduserid(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getuserid.websp_getuserid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public void saveaduser(string agencycode, string depocode, string genno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("aduserinsert.aduserinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agencycode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agencycode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("depocode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = depocode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("genno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = genno;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.ExecuteNonQuery();
                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        // ad function in oracle class --->>. Master.cs

        public DataSet Pripubcode(string compcode, string userid, string chk_value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();

            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addpubcode_b.Websp_addpubcode1_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("chk_value", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = chk_value;
                objOracleCommand.Parameters.Add(prm3);


                

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet centercode(string compcode, string userid, string chk_value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addcenter_B.Websp_addcenter", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("chk_value", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = chk_value;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_center", OracleType.Cursor);
                objOracleCommand.Parameters["p_center"].Direction = ParameterDirection.Output;


                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet editioncode(string compcode, string userid)/*, string pubcode)*/
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_addedition.websp_addedition_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);



               


                

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet editioncodecenterwise(string compcode, string userid, string center, string pub, string chk_value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_addedition_center_B.websp_addedition_center_B", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pub", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pub;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("chk_value", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = chk_value;
                objOracleCommand.Parameters.Add(prm5);


                

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet secpubcode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addsecpub_p.Websp_addsecpub", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);



                objOracleCommand.Parameters.Add("p_secpub", OracleType.Cursor);
                objOracleCommand.Parameters["p_secpub"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        // generate reference file
        public DataSet clsReferenceFile(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_getReferencefile1", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centercode;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = suppcode;
                objOracleCommand.Parameters.Add(prm6);

                objOracleCommand.Parameters.Add("p_getref", OracleType.Cursor);
                objOracleCommand.Parameters["p_getref"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        //updateclassified(updatestatus);
        public DataSet updateclassified(string cioid, string insertion)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_getReferenceupdate", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cioid;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("insertion_no", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = insertion;
                objOracleCommand.Parameters.Add(prm4);


                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet bindtalu(string talukabind)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("bind_talu.bind_talu_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("talukabind", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = talukabind;
                objOracleCommand.Parameters.Add(prm1);


                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet getClientNameadd(string client, string compcode, string value, string datecheck)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforagency", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("datecheck", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = datecheck;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        //==============************To show Agency Client Remark History**********************============//
        public DataSet getagencyclientremark(string agency_code, string subagency_code, string cust_code, string type, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("ADB_GETAGENCY_REMARKDETAIL", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_agency_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agency_code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_subagency_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = subagency_code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("p_cust_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cust_code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_type", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = type;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("extra", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_dateformat", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }




        public DataSet agencybind(string custCode, string agencyname, string userid, string datformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_AGENCY_BIND_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = custCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pag_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencyname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = datformat;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }

            catch (Exception ex)
            {
                throw (ex);


            }

            finally
            {
                CloseConnection(ref objOracleConnection);

            }
        }


        public DataSet Checkduplicay2(string custCode, string branchcode, string Agencyname, string panno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpanclientagency", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = custCode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Agencyname;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("ppanno", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = panno;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pextera", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pextera2", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextera3", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);




                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }

            catch (Exception ex)
            {
                throw (ex);


            }

            finally
            {
                CloseConnection(ref objOracleConnection);

            }
        }


        public DataSet bindagencat(string agntyp)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencytype.bindagencytype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agencytype", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agntyp;
                objOraclecommand.Parameters.Add(prm1);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet fetchdata(string compcode, string booking)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FETCHDATAPAYMENT_GATEWAY", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm21 = new OracleParameter("pbookingid", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = booking;
                objOraclecommand.Parameters.Add(prm21);

                objOraclecommand.Parameters.Add("p_newsprint", OracleType.Cursor);
                objOraclecommand.Parameters["p_newsprint"].Direction = ParameterDirection.Output;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
    }
}