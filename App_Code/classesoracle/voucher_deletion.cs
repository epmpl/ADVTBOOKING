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
    /// Summary description for voucher_deletion
    /// </summary>
    public class voucher_deletion : orclconnection
    {
        public voucher_deletion()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet getbranch()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_branch.bind_branch_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



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
        public DataSet bind_voucherdelete(string compcode, string doctype, string unit, string rcptdt, string dateformat, string voucherno, string rcptno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();                
                objOraclecommand = GetCommand("ad_vch_delete_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctyp", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pvoucherno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = voucherno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("precptdt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = rcptdt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("precptno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = rcptno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet bind_voucherdetail(string compcode, string doctype, string unit, string rcptdt, string dateformat, string voucherno, string rcptno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();              
                objOraclecommand = GetCommand("ad_vch_detail_List_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;

                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctyp", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pvoucherno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = voucherno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("precptdt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = rcptdt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("precptno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = rcptno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet bind_voucherno(string compcode, string doctype, string unit, string rcptdt, string dateformat, string voucherno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_voucherno_List_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
              
                    prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctyp", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("precptdt", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rcptdt;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                //OracleParameter prm6 = new OracleParameter("pvoucherno", OracleType.VarChar, 50);
                //prm6.Direction = ParameterDirection.Input;
                //prm6.Value = voucherno;
                //objOraclecommand.Parameters.Add(prm6);

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


        ///////////////////////////////////////////////For Bill No.////////////////////////////////////////////////

        public DataSet bind_billno(string compcode, string doctype, string unit, string billdt, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_bills_List_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;

                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctyp", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbildt", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = billdt;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                

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

        //====================================For bill Detail============================================

        public DataSet bind_billdetail(string compcode, string doctype, string unit, string billdt, string dateformat,string billno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_bills_detail_List_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;

                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctyp", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbillno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = billno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pbildt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = billdt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

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


        /////////////////////////////////////For Bill Delete////////////////////////////

        public DataSet bind_billdelete(string compcode, string doctype, string unit, string billdt, string dateformat, string billno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_bills_delete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctyp", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);              

                OracleParameter prm5 = new OracleParameter("pbilldt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = billdt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pbillno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = billno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformat;
                objOraclecommand.Parameters.Add(prm7);

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


        ////////////////////////////////////For Bill Adjust//////////////////////////////////////////

         public DataSet bill_adjust(string compcode, string billdt,string billno,string userid, string dateformat, string extra1, string extra2)
         {

             OracleConnection objOracleConnection;
             OracleCommand objOraclecommand;
             DataSet objDataSet = new DataSet();
             objOracleConnection = GetConnection();
             OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

             try
             {
                 objOracleConnection.Open();
                 objOraclecommand = GetCommand("ad_bill_unadjusted", ref objOracleConnection);
                 objOraclecommand.CommandType = CommandType.StoredProcedure;

                 OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                 prm1.Direction = ParameterDirection.Input;
                 prm1.Value = compcode;
                 objOraclecommand.Parameters.Add(prm1);

                 OracleParameter prm2 = new OracleParameter("pbilldate", OracleType.VarChar, 50);
                 prm2.Direction = ParameterDirection.Input;
                 prm2.Value = billdt;
                 objOraclecommand.Parameters.Add(prm2);

                 OracleParameter prm3 = new OracleParameter("pbillno", OracleType.VarChar, 50);
                 prm3.Direction = ParameterDirection.Input;
                 prm3.Value = billno;
                 objOraclecommand.Parameters.Add(prm3);

                 OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar, 50);
                 prm5.Direction = ParameterDirection.Input;
                 prm5.Value = userid;
                 objOraclecommand.Parameters.Add(prm5);               

                 OracleParameter prm7 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                 prm7.Direction = ParameterDirection.Input;
                 prm7.Value = dateformat;
                 objOraclecommand.Parameters.Add(prm7);

                 OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                 prm6.Direction = ParameterDirection.Input;
                 prm6.Value = extra1;
                 objOraclecommand.Parameters.Add(prm6);

                 OracleParameter prm61 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                 prm61.Direction = ParameterDirection.Input;
                 prm61.Value = extra2;
                 objOraclecommand.Parameters.Add(prm61);

                 //objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                 //objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet check_drcr(string compcode, string doctype, string dateformat, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_doctype_bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (compcode == "0")
                    prm1.Value = System.DBNull.Value;
                else
                    prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdoctype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = doctype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                objOraclecommand.Parameters.Add(prm5);




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
