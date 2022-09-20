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
    /// Summary description for bankmaster
    /// </summary>
    public class bankmaster:orclconnection
    {
        public bankmaster()
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


        public DataSet countcity(string txtcountry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillcity.fillcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("txtcountry", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = txtcountry;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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


        public DataSet bankbind(string agencode, string agencysubcode, string comp, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindbankdata.bindbankdata_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("comp", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = comp;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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

        public DataSet insertdata(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bankinsert.bankinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("bankname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bankname;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("branch", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branch;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3= new OracleParameter("country", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = country;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("city", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = city;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bankno", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bankno;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6= new OracleParameter("accountno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = accountno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8= new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agencode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("subagncode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = subagncode;
                objOraclecommand.Parameters.Add(prm10);

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


        public DataSet bankdata(string compcode, string userid, string agencode, string subagncode, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bankdataselect.bankdataselect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agencode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("subagncode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = subagncode;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm6 = new OracleParameter("code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = code10;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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


        public DataSet updatedata(string bankname, string branch, string country, string city, string bankno, string accountno, string compcode, string userid, string agencode, string subagncode, string codebk)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bankdataupdate.bankdataupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("bankname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bankname;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("branch", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branch;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("country", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = country;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("city", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = city;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("bankno", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bankno;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("accountno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = accountno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agencode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("subagncode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = subagncode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("codebk", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = codebk;
                objOraclecommand.Parameters.Add(prm11);

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


        public DataSet deletedata(string compcode, string userid, string codebk)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bankdatadelete.bankdatadelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm11 = new OracleParameter("codebk", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = codebk;
                objOraclecommand.Parameters.Add(prm11);


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