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
    /// Summary description for BillStatus
    /// </summary>
    public class BillStatus : orclconnection 
    {
        public BillStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet billsave1(string billid, string billstatus, string billalias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILL_SAVE.BILL_SAVE_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("billid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billid;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = billstatus;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("billalias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = billalias;
                objOraclecommand.Parameters.Add(prm3);




                



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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
        //public DataSet billmodify(string companycode, string billid, string billstatus, string billalias, string UserId)

        public DataSet billmodify(string billid, string billstatus, string billalias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILL_MODIFY.BILL_MODIFY_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("billid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billid;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = billstatus;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("billalias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = billalias;
                objOraclecommand.Parameters.Add(prm3);




              

      

              



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        //public DataSet chkbillid(string companycode, string UserId, string billid)
        public DataSet chkbillid(string billid, string billstatus, string mod)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILLCHK.BILLCHK_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("billid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = billstatus;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("mod1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = mod;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

              



                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        // public DataSet billexecute1(string companycode, string zonecode, string zonename, string alias, string UserId)
        public DataSet billexecute1(string billid, string billstatus, string billalias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILL_EXE.BILL_EXE_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("vbill_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billid;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("vbillstatus", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = billstatus;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("vbillalias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = billalias;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

          


                


               

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet billfpnl()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILLFPNL.BILLFPNL_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet billdelete(string billid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILL_DELETE.BILL_DELETE_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("billid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billid;
                objOraclecommand.Parameters.Add(prm1);

            


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet billexecute2(string billid, string billstatus, string billalias)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILL_EXE.BILL_EXE_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm1 = new OracleParameter("billid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billid;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = billstatus;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("billalias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = billalias;
                objOraclecommand.Parameters.Add(prm3);




               

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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


        public DataSet billidauto(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BILL_AUTO.BILL_AUTO_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length >2)
                {
                     prm2.Value = str.Substring (0,2);
                }
                else
                {
                     prm2.Value = str;
                }
               
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                


                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

    }
}
