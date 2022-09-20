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

/// <summary>
/// Summary description for clientbrandmast
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class clientbrandmast : orclconnection
    {
        public clientbrandmast()
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



        public DataSet adproduct(string compcode, string userid , string custcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindclientprodbrand.bindclientprodbrand_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pcustcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = custcode;
                objOraclecommand.Parameters.Add(prm4);

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
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet adbrand1(string compcode, string productcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientproductbrandbind.clientproductbrandbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                //OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = userid;
                //objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("productcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = productcode;
                objOraclecommand.Parameters.Add(prm4);

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
                objOraclecommand = GetCommand("websp_clientbindbrand.websp_clientbindbrand_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("pcustcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = custcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
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


        public DataSet insertclientcode(string client_code, string client_name, string exec_code, string compcode, string userid,string prod_code,string brand_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertclientbrand.insertclientbrand_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pclient", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client_name;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = exec_code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pbrand_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = brand_code;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pproduct_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = prod_code;
                objOraclecommand.Parameters.Add(prm8);

                //OracleParameter prm7 = new OracleParameter("exec_code", OracleType.VarChar, 50);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = exec_code;
                //objOraclecommand.Parameters.Add(prm7);

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
                objOraclecommand = GetCommand("delclientbrand.delclientbrand_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pclient_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pclient_name", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client_name;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pbrand_name", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = product_name;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pclient_brand_code", OracleType.VarChar, 50);
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
                objOraclecommand = GetCommand("websp_clientbrandbind12.websp_clientbrandbind12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("pclient_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7 = new OracleParameter("pclient_brand_code", OracleType.VarChar, 50);
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


        //public DataSet chk(string client_code, string product_code, string compcode, string userid, string exec_code)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("chkclientprod.chkclientprod_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm4 = new OracleParameter("client_code", OracleType.VarChar, 50);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = client_code;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm2);

        //        OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = userid;
        //        objOraclecommand.Parameters.Add(prm3);

        //        OracleParameter prm7 = new OracleParameter("product_code", OracleType.VarChar, 50);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = product_code;
        //        objOraclecommand.Parameters.Add(prm7);

        //        OracleParameter prm8 = new OracleParameter("exec_code", OracleType.VarChar, 50);
        //        prm8.Direction = ParameterDirection.Input;
        //        prm8.Value = exec_code;
        //        objOraclecommand.Parameters.Add(prm8);

        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //        objmysqlDataAdapter.SelectCommand = objOraclecommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }
        //}


        public DataSet chk(string client_code, string exec_code, string compcode, string userid, string product_code, string brand_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkclientbrand.chkclientbrand_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("pclient_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                //OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //prm3.Value = userid;
                //objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm7 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = exec_code;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pproduct_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = product_code;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pbrand_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = brand_code;
                objOraclecommand.Parameters.Add(prm9);


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
        public DataSet updateclientcode(string client_code, string client_name, string brand_code, string compcode, string userid, string client_prod_code, string product_code, string exec_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateclientbrand.updateclientbrand_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client_code;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pclient", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client_name;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("pclient_brand_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client_prod_code;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pproduct_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = product_code;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbrand_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = brand_code;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm91 = new OracleParameter("pexec_code", OracleType.VarChar, 50);
                prm91.Direction = ParameterDirection.Input;
                prm91.Value = exec_code;
                objOraclecommand.Parameters.Add(prm91);

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
