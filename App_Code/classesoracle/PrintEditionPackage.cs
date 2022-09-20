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
/// Summary description for PrintEditionPackage
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class PrintEditionPackage : orclconnection
    {
        public PrintEditionPackage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet adtypbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


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
                objOracleConnection.Close();
            }
        }

        public DataSet selpackageForPrintEdition(string compcode, string pack_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("select_addType_with_plus", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pack_code;
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

        public DataSet selectEditionComboCode(string pack, string combincode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("select_edition_combin_code", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("packdes", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pack;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcombin_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = combincode;
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

        public DataSet executePrintEditionComboCode(string comp_code, string pack_des, string combin)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execute_packbill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //objOraclecommand.Parameters.Add("@code", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@code"].Value = crgcode;
                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comp_code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pack_des;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("ppackagecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = combin;
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

        public DataSet insertEditionComboCode(string pack_name, string flag, string pack_des, string combin, string adtype, string comp_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("SP_combinPrintEdition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm = new OracleParameter("prctype", OracleType.VarChar, 50);
                prm.Direction = ParameterDirection.Input;
                prm.Value = "MOD_INSERT";
                objOraclecommand.Parameters.Add(prm);

                OracleParameter prm1 = new OracleParameter("pack_name", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pack_name;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = flag;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("combin_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pack_des;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("package_name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = combin;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtye", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = comp_code;
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

        public DataSet updateEditionComboCode(string flag, string id)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("SP_combinPrintEdition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm = new OracleParameter("prctype", OracleType.VarChar, 50);
                prm.Direction = ParameterDirection.Input;
                prm.Value = "MOD_UPDATE";
                objOraclecommand.Parameters.Add(prm);

                OracleParameter prm1 = new OracleParameter("pack_name", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = flag;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = id;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("combin_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("package_name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtye", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
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

        public DataSet selectPrintEditionComboCode(string comp_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("SP_combinPrintEdition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm = new OracleParameter("prctype", OracleType.VarChar, 50);
                prm.Direction = ParameterDirection.Input;
                prm.Value = "MOD_SELECT";
                objOraclecommand.Parameters.Add(prm);

                OracleParameter prm1 = new OracleParameter("pack_name", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = "";
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = "";
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("combin_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "";
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("package_name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "";
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtye", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = "";
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = comp_code;
                objOraclecommand.Parameters.Add(prm6);

                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
