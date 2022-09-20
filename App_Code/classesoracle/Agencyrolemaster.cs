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
    /// Summary description for Agencyrolemaster
    /// </summary>
    public class Agencyrolemaster:orclconnection
    {
    
        public Agencyrolemaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet bindagencycode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencycode.bindagencycode_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
               objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


          






                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet insertrole(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertintorole.insertintorole_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);
               OracleParameter prm3 = new OracleParameter("code1", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = code;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("nameofrole", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = nameofrole;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = agencycode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("subcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = subcode;
               objOraclecommand.Parameters.Add(prm6);





               










                
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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

        public DataSet modifyrole(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("modifyintorole.modifyintorole_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               
           
             
               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);
               OracleParameter prm3 = new OracleParameter("code1", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = code;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("nameofrole", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = nameofrole;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = agencycode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("subcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = subcode;
               objOraclecommand.Parameters.Add(prm6);


               OracleParameter prm61 = new OracleParameter("level", OracleType.VarChar, 50);
               prm61.Direction = ParameterDirection.Input;
               prm61.Value = System.DBNull.Value;
               objOraclecommand.Parameters.Add(prm61);



               
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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

        public DataSet execute(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executerole.executerole_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);
               OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = code;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("nameofrole", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = nameofrole;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = agencycode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("subcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = subcode;
               objOraclecommand.Parameters.Add(prm6);
               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;








                
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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

        public DataSet firstdata(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstrole.firstrole_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

     

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);
               objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
               objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


               
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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

        public DataSet chkroleage(string code, string compcode, string userid, string nameofrole)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkrole.checkrole_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

              

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm3 = new OracleParameter("code1", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = code;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm4 = new OracleParameter("nameofrole", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = nameofrole;
               objOraclecommand.Parameters.Add(prm4);

               objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
               objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


               objOraclecommand.Parameters.Add("p_account1", OracleType.Cursor);
               objOraclecommand.Parameters["p_account1"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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


        public DataSet deldata(string compcode, string userid, string doccode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("agroledel.agroledel_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

              

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm3 = new OracleParameter("doccode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = doccode;
               objOraclecommand.Parameters.Add(prm3);
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);
               objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
               objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;



             
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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








        public DataSet chksrolecode1(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkrolename.chkrolename_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = str;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               if (str.Length > 2)
               {
                   prm3.Value = str.Substring(0, 2);
               }
               else
               {
                   prm3.Value = str;
               }
               objOraclecommand.Parameters.Add(prm3);
               objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
               objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;
               objOraclecommand.Parameters.Add("p_account1", OracleType.Cursor);
               objOraclecommand.Parameters["p_account1"].Direction = ParameterDirection.Output;




               objorclDataAdapter.SelectCommand =objOraclecommand;
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