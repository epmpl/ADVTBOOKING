using System;
using System.Data;
using System.Configuration;//
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
    /// Summary description for ClientProdMastr
    /// </summary>
    public class ClientProdMastr:orclconnection
    {
        public ClientProdMastr()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adproduct(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adproduct.adproduct_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet adexecutive(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adexecutive.adexecutive_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet clientbind(string userid, string compcode, string custcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_clientbind.websp_clientbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = custcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
        
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
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet insertclientcode(string client_code, string client_name, string product_code, string compcode, string userid, string exec_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertclientprod1.insertclientprod1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client_name;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("product_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = product_code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("exec_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = exec_code;
                objOraclecommand.Parameters.Add(prm7);

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
                CloseConnection(ref objOracleConnection);
            }

        }




        public DataSet deleteclientprod(string client_code, string client_name, string product_name, string compcode, string userid, string client_prod_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("delclientprod.delclientprod_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("client_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client_name", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client_name;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("product_name", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = product_name;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client_prod_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client_prod_code;
                objOraclecommand.Parameters.Add(prm7);

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
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet contactbind12(string client_code, string userid, string compcode, string client_prod_code)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_clientbind12.websp_clientbind12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("client_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7 = new OracleParameter("client_prod_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client_prod_code;
                objOraclecommand.Parameters.Add(prm7);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet chk(string client_code, string product_code, string compcode, string userid, string exec_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkclientprod.chkclientprod_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("client_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7 = new OracleParameter("product_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = product_code;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("exec_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = exec_code;
                objOraclecommand.Parameters.Add(prm8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet chk1(string client_code, string product_code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkclientprod1.chkclientprod1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("client_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7 = new OracleParameter("product_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = product_code;
                objOraclecommand.Parameters.Add(prm7);

              

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet updateclientcode(string client_code, string client_name, string product_code, string compcode, string userid, string client_prod_code, string exec_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateclientprod.updateclientprod_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client_name;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("client_prod_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client_prod_code;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("product_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = product_code;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("exec_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = exec_code;
                objOraclecommand.Parameters.Add(prm9);

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
                CloseConnection(ref objOracleConnection);
            }

        }


    }
}