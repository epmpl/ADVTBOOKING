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
    /// Summary description for StateMaster
    /// </summary>
    public class StateMaster : orclconnection
    {
        public StateMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet adcountryname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcountryname.adcountryname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

		  OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2); 
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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


        public DataSet Advsave1(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Statemaster_Save.Statemaster_Save_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;            

           

            

                


                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = companycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("State_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm4 = new OracleParameter("State_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statename;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("State_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = countryname;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm3 = new OracleParameter("UserId", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
                objOraclecommand.Parameters.Add(prm3);

              


                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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

        public DataSet Advmodify1(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Statemaster_Modify.Statemaster_Modify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = companycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("State_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm4 = new OracleParameter("State_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statename;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("State_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = countryname;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm3 = new OracleParameter("UserId", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
                objOraclecommand.Parameters.Add(prm3);             

                

             

                

              

                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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

        public DataSet Advdelete(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Statemaster_Delete.Statemaster_Delete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = companycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("State_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm4 = new OracleParameter("State_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statename;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("State_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = countryname;
                objOraclecommand.Parameters.Add(prm6);        

              

             

                

               

               

                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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

        public DataSet Advexecute1(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Statemaster_Execute.Statemaster_Execute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = companycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("State_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm4 = new OracleParameter("State_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statename;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("State_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (countryname == "0")
                {
                    prm6.Value = DBNull.Value;
                }
                else
                {

                    prm6.Value = countryname;
                }
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


               

               

                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;

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

        public DataSet Advexecute2(string companycode, string statecode, string statename, string alias, string countryname, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Statemaster_Execute.Statemaster_Execute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;                  


                OracleParameter prm2 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = companycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("State_Code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm4 = new OracleParameter("State_Name", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = statename;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("State_Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);
                OracleParameter prm6 = new OracleParameter("Country_Code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = countryname;
                objOraclecommand.Parameters.Add(prm6);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


               
                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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


        public DataSet Statefirst()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Statefpnl.Statefpnl_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;

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

        public DataSet chkstatecode(string companycode, string UserId, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkstate.chkstate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = companycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("statecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = statecode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = UserId;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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

        public DataSet chkstatename( string statename,string countryname, string companycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkstatename.chkstatename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("countryname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = countryname;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("statename", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = statename;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("companycode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = companycode;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
               
             

                

                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(ds);
                return ds;
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

        public DataSet countstatecode(string str, string ssss, string statecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkstatecodename.chkstatecodename_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;            

             

              OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = str;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              if (str.Length > 2)
              {
                  prm2.Value = str.Substring(0, 2);
              }
              else
              {
                  prm2.Value = str;
              }
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm3 = new OracleParameter("ssss", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = ssss;
              objOraclecommand.Parameters.Add(prm3);


              OracleParameter prm4 = new OracleParameter("statecode", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = statecode;
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
    }
}