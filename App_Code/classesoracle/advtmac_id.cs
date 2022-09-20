using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for advtmac_id
    /// </summary>
    public class advtmac_id : orclconnection 
    {
        public advtmac_id()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet getUser(string extra1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cir_login_bind.cir_login_bind_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("plogin_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = "";
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = "";
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "";
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }


        public DataSet getfirstlastname(string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstlastname", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("puserid", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = extra2;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcom_code", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = extra1;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }


        public DataSet savedata(string compcode, string usercode, string machinename, string machineip, string macip, string remark, string location, string username)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FA_MACHINE_SECURITY.FA_MACHINE_SECURITY_SAVE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("puser_id", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pmachine_name", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = machinename;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pmachine_ip", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = machineip;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pmachine_mac_addr", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = macip;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("premarks", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = remark;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("plocation", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = location;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = "";
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = username;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = usercode;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "";
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra4", OracleType.VarChar, 2000);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = "";
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra5", OracleType.VarChar, 2000);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = "";
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra6", OracleType.VarChar, 2000);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = "";
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pextra7", OracleType.VarChar, 2000);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "";
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra8", OracleType.VarChar, 2000);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = "";
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pextra9", OracleType.VarChar, 2000);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = "";
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm6 = new OracleParameter("pextra10", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = "";
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }



        public DataSet datadelete(string compcode, string username, string userid, string machinename, string machineip, string macip, string remark, string location)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FA_MACHINE_SECURITY.FA_MACHINE_SECURITY_DELETE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("puser_id", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pmachine_name", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = machinename;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pmachine_ip", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = machineip;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pmachine_mac_addr", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = macip;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = "";
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = username;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = remark;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = location;
                objOraclecommand.Parameters.Add(prm12);

               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }





        public DataSet executedata(string compcode, string usercode, string machinename, string machineip, string macip, string remark, string location)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FA_MACHINE_SECURITY.FA_MACHINE_SECURITY_EXECUTE", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("puser_id", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pmachine_name", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = machinename;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pmachine_ip", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = machineip;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pmachine_mac_addr", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = macip;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = "";
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = "";
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = "";
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = "";
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra4", OracleType.VarChar, 2000);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = "";
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra5", OracleType.VarChar, 2000);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = "";
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra6", OracleType.VarChar, 2000);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = "";
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pextra7", OracleType.VarChar, 2000);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = "";
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra8", OracleType.VarChar, 2000);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = "";
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pextra9", OracleType.VarChar, 2000);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = "";
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm6 = new OracleParameter("pextra10", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = "";
                objOraclecommand.Parameters.Add(prm6);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }



    }
}