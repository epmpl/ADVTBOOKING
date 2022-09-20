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
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{
    /// <summary>
    /// Summary description for RateGroupMaster
    /// </summary>
    public class RateGroupMaster:orclconnection
    {
        public RateGroupMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet ModifyValue(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RateGroupMastModify.RateGroupMastModify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("RtGroupCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = RtGroupCode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("RtGroupName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = RtGroupName;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
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


        public DataSet InsertValue(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RateGroupMasterInsert.RateGroupMasterInsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("RtGroupCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = RtGroupCode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("RtGroupName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = RtGroupName;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
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

        public DataSet SelectValue(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RateGroupMasterSelect.RateGroupMasterSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



               
                //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["userid"].Value =userid;
                OracleParameter prm2 = new OracleParameter("RtGroupCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = RtGroupCode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("RtGroupName", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = RtGroupName;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Alias;
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

        public DataSet Selectfnpl(string RtGroupCode, string RtGroupName, string Alias, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RateGroupSelectfnpl.RateGroupSelectfnpl_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                objOraclecommand.Parameters["compcode"].Value = compcode;

                //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["userid"].Value =userid;

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

        public DataSet chkvalue(string RtGroupCode, string RtGroupName,string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkrategroup.chkrategroup_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("RtGroupCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = RtGroupCode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm4 = new OracleParameter("RtGroupName", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = RtGroupName;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (OracleException  objException)
            {
                throw (objException);
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
        public DataSet DeleteValue(string RtGroupCode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RateGroupMastDelete.RateGroupMastDelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                

                //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["userid"].Value =userid;

                OracleParameter prm2 = new OracleParameter("RtGroupCode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = RtGroupCode;
                objOraclecommand.Parameters.Add(prm2);
                
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









        public DataSet chkrgroupcode1(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkrgname.chkrgname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                
                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2).ToString();
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

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