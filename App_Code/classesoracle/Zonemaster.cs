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
    /// Summary description for Zonemaster
    /// </summary>
    public class Zonemaster : orclconnection 
    {
        public Zonemaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet Advsave1(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ZONE_SAVE.ZONE_SAVE_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              

            

           

           



              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = companycode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("zonecode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = zonecode;
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm4 = new OracleParameter("zonename", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = zonename;
              objOraclecommand.Parameters.Add(prm4);

              OracleParameter prm5 = new OracleParameter("zonealias", OracleType.VarChar, 50);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = alias;
              objOraclecommand.Parameters.Add(prm5);

              OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = UserId;
              objOraclecommand.Parameters.Add(prm3);


            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
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

        public DataSet Advmodify1(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ZONE_MODIFY.ZONE_MODIFY_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;



              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = companycode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("zonecode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = zonecode;
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm5 = new OracleParameter("zonename", OracleType.VarChar, 50);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = zonename;
              objOraclecommand.Parameters.Add(prm5);

              OracleParameter prm6= new OracleParameter("zonealias", OracleType.VarChar, 50);
              prm6.Direction = ParameterDirection.Input;
              prm6.Value = alias;
              objOraclecommand.Parameters.Add(prm6);



               

            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
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

        public DataSet Advdelete(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Zone_Delete.Zone_Delete_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;


              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = companycode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("zonecode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = zonecode;
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm3 = new OracleParameter("zonename", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = zonename;
              objOraclecommand.Parameters.Add(prm3);


              OracleParameter prm4 = new OracleParameter("zonealias", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = alias;
              objOraclecommand.Parameters.Add(prm4);


               

            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
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

        public DataSet Advexecute1(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Zone_Execute.Zone_Execute_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;




              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = companycode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("zonecode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = zonecode;
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm3 = new OracleParameter("zonename", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = zonename;
              objOraclecommand.Parameters.Add(prm3);


              OracleParameter prm4 = new OracleParameter("zonealias", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = alias;
              objOraclecommand.Parameters.Add(prm4);
              objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                

             
                

            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
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

        public DataSet Advexecute2(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Zone_Execute.Zone_Execute_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;


              OracleParameter prm1 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = companycode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("Zone_Code", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              if (zonecode != "" && zonecode != null)
              {
                  prm2.Value = zonecode;
              }
              else
              {
                  prm2.Value = "%%";
              }
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm3 = new OracleParameter("Zone_Name", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              if (zonename != "" && zonename != null)
              {
                  prm3.Value = zonename;
              }
              else
              {
                  prm3.Value = "%%";
              
              }
              objOraclecommand.Parameters.Add(prm3);


              OracleParameter prm4 = new OracleParameter("Zone_Alias", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              if (alias != "" && alias != null)
              {
                  prm4.Value = alias;
              }
              else
              {
                  prm4.Value = "%%";
              }
              objOraclecommand.Parameters.Add(prm4);

              OracleParameter prm5 = new OracleParameter("UserId", OracleType.VarChar, 50);
              prm5.Direction = ParameterDirection.Input;
              prm5.Value = UserId;
              objOraclecommand.Parameters.Add(prm5);

              objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            

             

           

            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
            objmysqlDataAdapter.Fill(ds);
                return ds;
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


        public DataSet Zonefpnl()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Zonefpnl.Zonefpnl_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;

              objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
            objmysqlDataAdapter.Fill(ds);
                return ds;

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

        public DataSet chkzonecode(string companycode, string UserId, string zonecode, string zonename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet ds = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("zonechk.zonechk_p", ref objOracleConnection);
              objOraclecommand.CommandType = CommandType.StoredProcedure;


              OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
              prm1.Direction = ParameterDirection.Input;
              prm1.Value = companycode;
              objOraclecommand.Parameters.Add(prm1);


              OracleParameter prm2 = new OracleParameter("zonecode", OracleType.VarChar, 50);
              prm2.Direction = ParameterDirection.Input;
              prm2.Value = zonecode;
              objOraclecommand.Parameters.Add(prm2);

              OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
              prm3.Direction = ParameterDirection.Input;
              prm3.Value = UserId;
              objOraclecommand.Parameters.Add(prm3);

              OracleParameter prm4 = new OracleParameter("zonename", OracleType.VarChar, 50);
              prm4.Direction = ParameterDirection.Input;
              prm4.Value = zonename;
              objOraclecommand.Parameters.Add(prm4);

              objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

              objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
              objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

            objmysqlDataAdapter.SelectCommand =  objOraclecommand;
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

        public DataSet countzonecode(string str,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkzonecodename.chkzonecodename_p", ref objOracleConnection);
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