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

/// <summary>
/// Summary description for tv_booking_transaction
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class tv_booking_transaction : orclconnection
    {
        public tv_booking_transaction()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet get10ClientName(string compcode, string client, string center,string userid)
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
                objOraclecommand = GetCommand("websp_get10clientName", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

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
        public DataSet getchannelfromdeal(string compcode, string modetype, string deal, string fromdate, string todate)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("getchannelfromdeal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pmodetype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = modetype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("deal", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = deal;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fromdate;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = todate;
                objOraclecommand.Parameters.Add(prm5);

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
        public DataSet binddeal(string compcode, string deal, string client, string agency, string adtype, string modetype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddeal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("client", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("agency", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agency;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("modetype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = modetype;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;


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
        public DataSet bind10deal(string compcode, string deal, string client, string agency, string adtype, string modetype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind10deal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("client", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("agency", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agency;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("modetype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = modetype;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;


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
        public DataSet getagencyfromdeal(string compcode, string deal)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("getagencyfromdeal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;


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
        public DataSet getclientfromdeal(string compcode, string deal)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("getclientfromdeal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;


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
        public DataSet bindallinfo(string compcode, string deal, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindallinfo", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;


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
        public DataSet bindtpid(string compcode, string tpid, string channel, string location, string client, string agency, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_clipbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("tpid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = tpid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pUNIT", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pCHANNEL", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pLOCATION", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = location;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pAGENCY", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = agency;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pCLIENTCD", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet bind10tpid(string compcode, string tpid, string channel, string location, string client, string agency, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_clip10bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("tpid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = tpid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pUNIT", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pCHANNEL", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pLOCATION", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = location;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pAGENCY", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = agency;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pCLIENTCD", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet bindbtb(string compcode, string deal, string btbval, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_btbbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("btbval", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = btbval;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pchannel", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
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
        public DataSet bind10btb(string compcode, string deal, string btbval, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_btb10bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("btbval", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = btbval;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pchannel", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
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
        public DataSet bindfromto10band(string compcode, string deal, string fromband, string btbcode, string uom, string ros, string channel, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_get_time_band", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_btb", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = btbcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punit", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_btb_code", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ros;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_ros_rod", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = uom;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("p_channel", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = channel;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_deal", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = deal;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet bindfromtoband(string compcode, string deal, string fromband, string btbcode, string uom, string ros, string channel, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_get_time_band", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_btb", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = btbcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punit", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_btb_code", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ros;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_ros_rod", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = uom;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("p_channel", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = channel;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_deal", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = deal;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet getdatefromdeal(string compcode, string deal)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_BINDDATEFROMDEAL", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;


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
        public DataSet binduom(string compcode, string deal, string uom)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_uombind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("uom", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = uom;
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
        public DataSet bind10uom(string compcode, string deal, string uom)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_uom10bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("uom", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = uom;
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
        public DataSet bindadtype(string compcode, string deal, string adtype, string channel, string location, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_adtypebind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pchannel", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("plocation_code", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = location;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("punit", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = unit;
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet bind10adtype(string compcode, string deal, string adtype, string channel, string location, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_adtype10bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pchannel", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("plocation_code", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = location;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("punit", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = unit;
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet bindprogram(string compcode, string deal, string program, string channel, string location, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_programbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("program1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = program;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pchannel", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ploc_id", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = location;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("punit", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = unit;
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet bind10program(string compcode, string deal, string program, string channel, string location, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_program10bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("program1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = program;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pchannel", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ploc_id", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = location;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("punit", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = unit;
                objOraclecommand.Parameters.Add(prm6);

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

        public DataSet bindbookgrid(string compcode, string unit, string channel, string location, string adtype, string airdate, string deal, string btbcode, string frbtbcode, string tobtbcode, string paidbonus, string dur, string tapid, string prgid, string noofspot, string ratetype, string returndata, string insertid, string status, string fromdate, string todate, string dateformat, string category, string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_fetch_booking_data", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pchannel", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = channel;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("plocation_code", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = location;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pad_type", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pair_date", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (airdate == "")
                    prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = Convert.ToDateTime(airdate).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdealno", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = deal;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pbtb_code", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = btbcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pfr_btb_code", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = frbtbcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pto_btb_code", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = tobtbcode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ppaid_bonus", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = paidbonus;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pdur", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dur;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("ptap_id", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = tapid;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pprg_id", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = prgid;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pno_of_spot", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = noofspot;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("prate_type", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ratetype;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("p_return_data", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = returndata;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("p_pref_sec", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = "10";
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pinsert_id", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = insertid;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pbook_status", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = status;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                    prm21.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pto_date", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (todate == "" || todate == null)
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                    prm22.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = dateformat;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pcatg", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = category;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("p_agency", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = agency;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("pextra8", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("pextra9", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("pextra10", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm28);

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
        public DataSet get10Exec(string compcode, string execname, string value, string center)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_get10Exec.websp_get10Exec_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execname", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = execname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objOraclecommand.Parameters.Add(prm4);

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
        public DataSet get10retainer(string compcode, string center, string centermain)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("GET10RETAINER.GET10RETAINER_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PUBCENTER", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = center;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centermain;
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
        public DataSet bind10Product(string compcode, string product, string value)
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
                objOraclecommand = GetCommand("websp_get10Product.websp_get10Product_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("product", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = product;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
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
        public DataSet insertintoelectronicbooking(string compcode, string adtype1, string bookingdate, string branch, string bookedby, string bookingid, string prebookingid, string client, string agency, string deal, string clientadd, string agencyadd, string subagency, string agencytype, string mobileno, string status1, string agencypaymode, string creditperiod, string rono, string rodate, string rostatus, string dockitno, string keyno, string execode, string execzone, string agencyoutstand, string retainer, string booktype, string color, string adcategory, string appby, string audit, string product, string brand, string varient, string campain, string caption, string materialstatus, string bartertype, string ratecode, string cardrate, string cardamt, string contractrate, string deviation, string discount, string discountpre, string premiumamt, string premiumper, string specialdisc, string specialdiscper, string spacialcharges, string addagencycommrate, string addagencycommrateper, string grossamt, string Retainercomm, string Retainercommper, string billcycle, string revenue, string paymenttype, string billstatus, string cashdiscount, string cashrecieved, string cardname, string cardtype, string expirydate, string drpmonth, string drpyear, string cardno, string chqno, string chqamt, string chqdate, string bankname, string ourbank, string billto, string receipt, string tradedisc, string chktrade, string billamt, string billremark, string userid, string flag, string hidattach1, string hidattach2, string fmg, string fromdealdate, string todaeldate, string modetype, string representative)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertupdateintoelecbooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype1;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("bookingdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (bookingdate == "" || bookingdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = bookingdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    bookingdate = mm + "/" + dd + "/" + yy;
                    prm3.Value = Convert.ToDateTime(bookingdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("branch", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = branch;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bookedby", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bookedby;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("bookingid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = bookingid;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("prebookingid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = prebookingid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("client", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = client;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("agency", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agency;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("deal", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = deal;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("clientadd", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = clientadd;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("agencyadd", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = agencyadd;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("subagency", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = subagency;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm70 = new OracleParameter("agencytype", OracleType.VarChar);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = agencytype;
                objOraclecommand.Parameters.Add(prm70);

                OracleParameter prm14 = new OracleParameter("mobileno", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = mobileno;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("status1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = status1;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("agencypaymode", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = agencypaymode;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("creditperiod", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = creditperiod;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("rono", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = rono;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("rodate", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (rodate == "" || rodate == null)
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr1 = rodate.Split('/');
                    string dd1 = arr1[0];
                    string mm1 = arr1[1];
                    string yy1 = arr1[2];
                    rodate = mm1 + "/" + dd1 + "/" + yy1;
                    prm19.Value = Convert.ToDateTime(rodate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("rostatus", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rostatus;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("dockitno", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dockitno;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("keyno", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = keyno;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("execode", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = execode;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("execzone", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = execzone;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("agencyoutstand", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = agencyoutstand;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("retainer", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = retainer;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("booktype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = booktype;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("color1", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = color;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adcategory", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = adcategory;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("appby", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = appby;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("audit1", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = audit;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("product", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = product;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("brand1", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = brand;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("varient1", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = varient;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("campain1", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = campain;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("caption1", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = caption;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("materialstatus", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = materialstatus;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("bartertype", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = bartertype;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("ratecode11", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = ratecode;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("cardrate", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = cardrate;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("cardamt", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = cardamt;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("contractrate", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = contractrate;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("deviation1", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = deviation;
                objOraclecommand.Parameters.Add(prm43);

                //OracleParameter prm44 = new OracleParameter("agreedrate", OracleType.VarChar);
                //prm44.Direction = ParameterDirection.Input;
                //prm44.Value = agreedrate;
                //objOraclecommand.Parameters.Add(prm44);

                //OracleParameter prm45 = new OracleParameter("agreedamt", OracleType.VarChar);
                //prm45.Direction = ParameterDirection.Input;
                //prm45.Value = agreedamt;
                //objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("discount", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = discount;
                objOraclecommand.Parameters.Add(prm46);

                OracleParameter prm47 = new OracleParameter("discountpre", OracleType.VarChar);
                prm47.Direction = ParameterDirection.Input;
                prm47.Value = discountpre;
                objOraclecommand.Parameters.Add(prm47);

                OracleParameter prm48 = new OracleParameter("premiumamt", OracleType.VarChar);
                prm48.Direction = ParameterDirection.Input;
                prm48.Value = premiumamt;
                objOraclecommand.Parameters.Add(prm48);

                OracleParameter prm49 = new OracleParameter("premiumper", OracleType.VarChar);
                prm49.Direction = ParameterDirection.Input;
                prm49.Value = premiumper;
                objOraclecommand.Parameters.Add(prm49);

                OracleParameter prm50 = new OracleParameter("specialdisc", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = specialdisc;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm51 = new OracleParameter("specialdiscper", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = specialdiscper;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm54 = new OracleParameter("spacialcharges", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = spacialcharges;
                objOraclecommand.Parameters.Add(prm54);

                OracleParameter prm55 = new OracleParameter("addagencycommrate", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = addagencycommrate;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm56 = new OracleParameter("addagencycommrateper", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = addagencycommrateper;
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("grossamt", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = grossamt;
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm58 = new OracleParameter("Retainercomm", OracleType.VarChar);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = Retainercomm;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("Retainercommper", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = Retainercommper;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("billcycle", OracleType.VarChar);
                prm60.Direction = ParameterDirection.Input;
                prm60.Value = billcycle;
                objOraclecommand.Parameters.Add(prm60);

                OracleParameter prm61 = new OracleParameter("revenue", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = revenue;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm62 = new OracleParameter("paymenttype", OracleType.VarChar);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = paymenttype;
                objOraclecommand.Parameters.Add(prm62);

                OracleParameter prm63 = new OracleParameter("billstatus", OracleType.VarChar);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = billstatus;
                objOraclecommand.Parameters.Add(prm63);

                OracleParameter prm64 = new OracleParameter("cashdiscount", OracleType.VarChar);
                prm64.Direction = ParameterDirection.Input;
                prm64.Value = cashdiscount;
                objOraclecommand.Parameters.Add(prm64);

                OracleParameter prm65 = new OracleParameter("cashrecieved", OracleType.VarChar);
                prm65.Direction = ParameterDirection.Input;
                prm65.Value = cashrecieved;
                objOraclecommand.Parameters.Add(prm65);

                OracleParameter prm66 = new OracleParameter("cardname", OracleType.VarChar);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = cardname;
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("cardtype", OracleType.VarChar);
                prm67.Direction = ParameterDirection.Input;
                prm67.Value = cardtype;
                objOraclecommand.Parameters.Add(prm67);

                OracleParameter prm68 = new OracleParameter("expirydate", OracleType.VarChar);
                prm68.Direction = ParameterDirection.Input;
                prm68.Value = "";
                objOraclecommand.Parameters.Add(prm68);

                OracleParameter prm69 = new OracleParameter("drpmonth1", OracleType.VarChar);
                prm69.Direction = ParameterDirection.Input;
                prm69.Value = drpmonth;
                objOraclecommand.Parameters.Add(prm69);



                OracleParameter prm71 = new OracleParameter("drpyear1", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = drpyear;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("cardno", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                prm72.Value = cardno;
                objOraclecommand.Parameters.Add(prm72);

                OracleParameter prm73 = new OracleParameter("chqno", OracleType.VarChar);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = chqno;
                objOraclecommand.Parameters.Add(prm73);

                OracleParameter prm74 = new OracleParameter("chqamt", OracleType.VarChar);
                prm74.Direction = ParameterDirection.Input;
                prm74.Value = chqamt;
                objOraclecommand.Parameters.Add(prm74);

                OracleParameter prm75 = new OracleParameter("chqdate", OracleType.VarChar);
                prm75.Direction = ParameterDirection.Input;
                if (chqdate == "" || chqdate == null)
                {
                    prm75.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr2 = chqdate.Split('/');
                    string dd2 = arr2[0];
                    string mm2 = arr2[1];
                    string yy2 = arr2[2];
                    chqdate = mm2 + "/" + dd2 + "/" + yy2;
                    prm75.Value = Convert.ToDateTime(chqdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm75);

                OracleParameter prm76 = new OracleParameter("bankname", OracleType.VarChar);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = bankname;
                objOraclecommand.Parameters.Add(prm76);

                OracleParameter prm77 = new OracleParameter("ourbank", OracleType.VarChar);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = ourbank;
                objOraclecommand.Parameters.Add(prm77);

                OracleParameter prm78 = new OracleParameter("billto", OracleType.VarChar);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = billto;
                objOraclecommand.Parameters.Add(prm78);

                OracleParameter prm79 = new OracleParameter("receipt", OracleType.VarChar);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = receipt;
                objOraclecommand.Parameters.Add(prm79);

                OracleParameter prm80 = new OracleParameter("tradedisc", OracleType.VarChar);
                prm80.Direction = ParameterDirection.Input;
                prm80.Value = tradedisc;
                objOraclecommand.Parameters.Add(prm80);

                OracleParameter prm81 = new OracleParameter("chktrade", OracleType.VarChar);
                prm81.Direction = ParameterDirection.Input;
                prm81.Value = chktrade;
                objOraclecommand.Parameters.Add(prm81);

                OracleParameter prm82 = new OracleParameter("billamt", OracleType.VarChar);
                prm82.Direction = ParameterDirection.Input;
                prm82.Value = billamt;
                objOraclecommand.Parameters.Add(prm82);

                OracleParameter prm83 = new OracleParameter("billremark", OracleType.VarChar);
                prm83.Direction = ParameterDirection.Input;
                prm83.Value = billremark;
                objOraclecommand.Parameters.Add(prm83);

                OracleParameter prm84 = new OracleParameter("userid1", OracleType.VarChar);
                prm84.Direction = ParameterDirection.Input;
                prm84.Value = userid;
                objOraclecommand.Parameters.Add(prm84);

                OracleParameter prm85 = new OracleParameter("flag1", OracleType.VarChar);
                prm85.Direction = ParameterDirection.Input;
                prm85.Value = flag;
                objOraclecommand.Parameters.Add(prm85);

                OracleParameter prm86 = new OracleParameter("attach1", OracleType.VarChar);
                prm86.Direction = ParameterDirection.Input;
                prm86.Value = hidattach1;
                objOraclecommand.Parameters.Add(prm86);

                OracleParameter prm87 = new OracleParameter("attach2", OracleType.VarChar);
                prm87.Direction = ParameterDirection.Input;
                prm87.Value = hidattach2;
                objOraclecommand.Parameters.Add(prm87);

                OracleParameter prm88 = new OracleParameter("fmginsert", OracleType.VarChar);
                prm88.Direction = ParameterDirection.Input;
                prm88.Value = fmg;
                objOraclecommand.Parameters.Add(prm88);

                OracleParameter prm89 = new OracleParameter("fromdealdate", OracleType.VarChar);
                prm89.Direction = ParameterDirection.Input;
                if (fromdealdate == "" || fromdealdate == null)
                {
                    prm89.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr2 = fromdealdate.Split('/');
                    string dd2 = arr2[0];
                    string mm2 = arr2[1];
                    string yy2 = arr2[2];
                    fromdealdate = mm2 + "/" + dd2 + "/" + yy2;
                    prm89.Value = Convert.ToDateTime(fromdealdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm89);

                OracleParameter prm90 = new OracleParameter("todaeldate", OracleType.VarChar);
                prm90.Direction = ParameterDirection.Input;
                if (todaeldate == "" || todaeldate == null)
                {
                    prm90.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr2 = todaeldate.Split('/');
                    string dd2 = arr2[0];
                    string mm2 = arr2[1];
                    string yy2 = arr2[2];
                    todaeldate = mm2 + "/" + dd2 + "/" + yy2;
                    prm90.Value = Convert.ToDateTime(todaeldate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm90);

                OracleParameter prm91 = new OracleParameter("modetype", OracleType.VarChar);
                prm91.Direction = ParameterDirection.Input;
                prm91.Value = modetype;
                objOraclecommand.Parameters.Add(prm91);

                OracleParameter prm92 = new OracleParameter("prepresentative", OracleType.VarChar);
                prm92.Direction = ParameterDirection.Input;
                prm92.Value = representative;
                objOraclecommand.Parameters.Add(prm92);

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
        public DataSet insertintoelectronicchild(string compcode, string userid, string bookingid, string revenue, string channel, string location, string advtype, string ratetype, string scheduledate, string btbcode, string fromband, string toband, string break1, string position, string progname, string padebonus, string noofspote, string tapeid, string duration, string rate, string gross, string flag, string insertid, string status, string seqno, string category, string clientcode, string productcd, string brandcd)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertupdateintoelechild", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("bookingid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = bookingid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("revenue", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = revenue;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("channel1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = channel;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("location1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = location;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("advtype1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = advtype;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ratetype", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ratetype;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("scheduledate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (scheduledate == "" || scheduledate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    string[] arr = scheduledate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    scheduledate = mm + "/" + dd + "/" + yy;
                    prm10.Value = Convert.ToDateTime(scheduledate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("btbcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = btbcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("fromband", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = fromband;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("toband", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = toband;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("break1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = break1;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("position1", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = position;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("progname1", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = progname;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("padebonus1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = padebonus;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("noofspote", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = noofspote;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("tapeid", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = tapeid;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("duration1", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = duration;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("rate11", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = rate;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("gross11", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = gross;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("flag1", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = flag;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm5 = new OracleParameter("insertid1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = insertid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm24 = new OracleParameter("status1", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = status;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("seqno", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = seqno;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("category1", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = category;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("clientcode", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = clientcode;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("productcd", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = productcd;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("brandcd", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = brandcd;
                objOraclecommand.Parameters.Add(prm29);

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
        public DataSet insertupdatehtml(string compcode, string bookingid, string html, string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_insertbookhtml", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("bookingid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bookingid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("html", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = html;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = flag;
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
        public DataSet prevbooking(string compcode, string userid, string formname)
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
                objOraclecommand = GetCommand("gettheprevbooking1.gettheprevbooking1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("vuserid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("formname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = formname;
                objOraclecommand.Parameters.Add(prm3);

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
                objOraclecommand.Parameters.Add("P_Accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts5"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts6"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts7"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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
        public DataSet tvbookingexecute(string compcode, string deal, string agencycode, string client, string bookingid, string dockitno, string keyno, string rono, string booking)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_bookingexecute", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencycode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("client", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bookingid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bookingid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dockitno", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dockitno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("keyno", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = keyno;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("rono1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = rono;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("booking", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = booking;
                objOraclecommand.Parameters.Add(prm9);

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
        public DataSet tvbookingexecutedet(string compcode, string bookingid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_bookingexecutedet", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("bookingid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bookingid;
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
        public DataSet tvbookinghtml(string compcode, string bookingid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_bookinghtml", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("bookingid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bookingid;
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
        public DataSet bindbindadcat(string compcode, string deal, string adcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_adcatbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adcat1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcat;
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
        public DataSet bind10bindadcat(string compcode, string deal, string adcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_adcat10bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adcat1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcat;
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
        public DataSet chkvalidateintable(string tablename, string columnname, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_value_validate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tablename;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcolumn_name", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = columnname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pvalue", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_temp", OracleType.Cursor);
                objOraclecommand.Parameters["p_temp"].Direction = ParameterDirection.Output;


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
        public DataSet chkvalidate(string channel, string deal, string btbcode, string padebonus, string tapid, string totalnoofspote)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_check_deal_value", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pchannel", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = channel;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdealno", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbtb_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = btbcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ppaid_bonus", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = padebonus;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pclipid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tapid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("p_tot_sec", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = totalnoofspote;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra2", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra3", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra4", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra5", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm12);

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
        public DataSet bind10representative(string compcode, string resentative)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("rep10bind.rep10bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("pextra1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = resentative;
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
        public DataSet bindrepresentative(string compcode, string resentative)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("repbind.repbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("pextra1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = resentative;
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

        /////new bind bhanu 

        public DataSet bindagency_DJ(string compcode, string userid, string agency, string pubcenter, string branch, string center, string loginth, string publication)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforbooking_DJ", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm31 = new OracleParameter("branch", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = branch;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm41 = new OracleParameter("center", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = center;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm5 = new OracleParameter("loginth", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = loginth;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("publication", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = publication;
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet bind10agency_n(string compcode, string userid, string agency, string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind10agencyforbooking_N", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
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
        public DataSet bindagency_n(string compcode, string userid, string agency, string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforbooking_N.bindagencyforbooking_N_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
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
        public DataSet getClientName_n(string compcode, string client, string center, string userid)
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
                objOraclecommand = GetCommand("websp_getclientName.websp_getclientName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

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
        public DataSet get10ClientName_n(string compcode, string client, string center, string userid)
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
                objOraclecommand = GetCommand("websp_get10clientName", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

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
        public DataSet getExecbooking_n(string compcode, string execname, string value, string center, string adtype, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getExecbooking_N.websp_getExecbooking_N_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("execname", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = execname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("value", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("center", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = center;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("padtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;



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
        public DataSet getretainer_n(string compcode, string center, string centermain,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("GETRETAINER_N.GETRETAINER_N_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PUBCENTER", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = center;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centermain;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar);
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

        public DataSet getteamname(string compcode, string teamname, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BIND_BOOKING_TEAM", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("TEAMNAME", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = teamname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("EXTRA1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("EXTRA2", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("EXTRA3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra3;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("EXTRA4", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra4;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("EXTRA5", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra5;
                objOraclecommand.Parameters.Add(prm7);


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
    }
}
