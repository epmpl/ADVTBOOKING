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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.classesoracle
{

    public class Disc_master : orclconnection
    {
        public Disc_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }
//*******************************Start Calling Procedure***********************************//
        public DataSet chkduplicate(string compcode, string disccode, string discdes, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("discchk", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("disccode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = disccode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("discdes", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = discdes;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet exec(string compcode, string disccode, string disdes, string adtyp, string stat, string disctyp, string disprem)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("discexec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("disccode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = disccode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("disdes", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = disdes;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("adtyp", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtyp;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("stat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = stat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("disctyp", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = disctyp;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("disprem", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = disprem;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet del(string compcode, string disccode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("discdel", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("disccode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = disccode;
                objOraclecommand.Parameters.Add(prm2);

                //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet savedata(string compcode, string disccode, string discdes, string adtype1, string status1, string disctyp, string discprm, string userid1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("discsave", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("disccode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = disccode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("discdes", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = discdes;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("status1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = status1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("disctyp", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = disctyp;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("discprm", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = discprm;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("userid1", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid1;
                objOraclecommand.Parameters.Add(prm8);

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
        public DataSet updatedata(string compcode, string disccode, string adtype1, string status1, string disctyp, string discprm)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("discupdate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("disccode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = disccode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm4 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = adtype1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("status1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = status1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("disctyp", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = disctyp;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("discprm", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = discprm;
                objOraclecommand.Parameters.Add(prm7);

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
        public DataSet countcode(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("discchkcodename", ref objOracleConnection);
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
                CloseConnection(ref objOracleConnection);
            }
        }
    }
}
