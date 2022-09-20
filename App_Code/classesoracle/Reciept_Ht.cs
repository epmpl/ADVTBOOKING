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
    /// Summary description for Reciept_Ht
    /// </summary>
    public class Reciept_Ht : orclconnection
    {
        public Reciept_Ht()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindrodetail(string compcode, string receiptno,string sapid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection_search();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("rodetail_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("receipt_no", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (receiptno == "")
                    prm2.Value = System.DBNull.Value;
                else
                    prm2.Value = receiptno;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sap_id", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (sapid == "")
                    prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = sapid;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOracleCommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_insert", OracleType.Cursor);
                objOracleCommand.Parameters["ht_insert"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_matter", OracleType.Cursor);
                objOracleCommand.Parameters["ht_matter"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_box", OracleType.Cursor);
                objOracleCommand.Parameters["ht_box"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_comm", OracleType.Cursor);
                objOracleCommand.Parameters["ht_comm"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_recdate", OracleType.Cursor);
                objOracleCommand.Parameters["ht_recdate"].Direction = ParameterDirection.Output;

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
        public DataSet bindreceiptdata(string compcode, string booking_id)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("ht_receipt_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("receipt_no", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = booking_id;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOracleCommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_insert", OracleType.Cursor);
                objOracleCommand.Parameters["ht_insert"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_matter", OracleType.Cursor);
                objOracleCommand.Parameters["ht_matter"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_box", OracleType.Cursor);
                objOracleCommand.Parameters["ht_box"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_comm", OracleType.Cursor);
                objOracleCommand.Parameters["ht_comm"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_recdate", OracleType.Cursor);
                objOracleCommand.Parameters["ht_recdate"].Direction = ParameterDirection.Output;

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

        public DataSet bindreceiptdata_bill(string compcode, string booking_id)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("ht_receipt_p_b", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("receipt_no", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = booking_id;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOracleCommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_insert", OracleType.Cursor);
                objOracleCommand.Parameters["ht_insert"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_matter", OracleType.Cursor);
                objOracleCommand.Parameters["ht_matter"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_box", OracleType.Cursor);
                objOracleCommand.Parameters["ht_box"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_comm", OracleType.Cursor);
                objOracleCommand.Parameters["ht_comm"].Direction = ParameterDirection.Output;

                objOracleCommand.Parameters.Add("ht_recdate", OracleType.Cursor);
                objOracleCommand.Parameters["ht_recdate"].Direction = ParameterDirection.Output;

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
    }
}
