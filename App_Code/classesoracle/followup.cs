using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{


    /// <summary>
    /// Summary description for followup
    /// </summary>
    public class followup : orclconnection
    {
        public followup()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet execute_maingrp(string compcode, string maingrcode, string dateformat, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = extra1;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



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
        public DataSet findrecord(string compcode, string agency, string client, string fdate, string tdate, string dateformat, string extra1, string extra2, string extra3)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("followup", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pclient", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = client;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdatefrom", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fdate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateto", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tdate;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pdateformate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra1;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = extra2;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra3;
                objOraclecommand.Parameters.Add(prm9);





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
        public DataSet clientxls(string compcode, string client)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindclientforxls.bindclientforxls_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm1 = new OracleParameter("client", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = client;
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
        public DataSet fetchMailId(string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("followupfetchMailId_ro", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("bkid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

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
    }
}
