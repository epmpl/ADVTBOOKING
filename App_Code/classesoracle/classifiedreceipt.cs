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
    /// Summary description for receipt
    /// </summary>
    public class classifiedreceipt : orclconnection
    {
        public classifiedreceipt()
        {

        }

        public DataSet selectreceipt(string cio_booking_id, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_receiptnew2", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_booking_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS2", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS2"].Direction = ParameterDirection.Output;



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






        public DataSet selectreceiptno(string cio_booking_id, string receiptno, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_receipt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_booking_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("receiptno", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = receiptno;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                //objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
        //for receipt matter
        public DataSet clsreceiptmatter(string booking_id)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_clsmatter.websp_clsmatter_P", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("booking_id", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = booking_id;
                objOracleCommand.Parameters.Add(prm1);

                objOracleCommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOracleCommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOracleCommand;
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
        public DataSet getamount(string amt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("getamount_word", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("amt", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = amt;
                objOracleCommand.Parameters.Add(prm1);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOracleCommand;
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
        //===================*** TO GET RECEIPT DATA FOR RP RECEIPT*******========//
        public DataSet selectreceipt_rp(string compcode, string cio_booking_id, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Receipt_Print", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_booking_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS2", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS2"].Direction = ParameterDirection.Output;



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

        public DataSet bindaddress(string compcode, string unit, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("adgetbindaddress", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
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
        public DataSet selectreceipt_nb(string cio_booking_id, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_receiptnew2_nb", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_booking_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS2", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS2"].Direction = ParameterDirection.Output;



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
