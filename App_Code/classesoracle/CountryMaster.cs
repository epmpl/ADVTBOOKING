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
    /// Summary description for CountryMaster
    /// </summary>
    public class CountryMaster : orclconnection 
    {
        public CountryMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet Advsave(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Countrymaster_Save.Countrymaster_Save_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Country_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("Country_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm3 = new OracleParameter("UserId", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
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

        public DataSet Advmodify(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Countrymaster_Modify.Countrymaster_Modify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Country_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("Country_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);






               


               
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

        public DataSet Advdelete(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Countrymaster_Delete.Countrymaster_Delete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("Country_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Country_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
               

                 objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet Advexecute(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Countrymaster_Execute.Countrymaster_Execute_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Country_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("Country_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);

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


        public DataSet Advexecute1(string companycode, string code, string name, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Countrymaster_Execute.Countrymaster_Execute_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("Country_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("Country_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
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

        public DataSet Advfirst()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Countryfpnl.Countryfpnl_p", ref objOracleConnection);
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



        public DataSet chkcountrycode(string companycode, string UserId, string code,string name)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkcountry.checkcountry_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = companycode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("countrycode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = name;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


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

        public DataSet countcode(string str, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcountrycodename.chkcountrycodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0,2);
                }
                else
                {
                    prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
    }
}
