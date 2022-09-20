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
    /// Summary description for premiumtype_master
    /// </summary>
    public class premiumtype_master : orclconnection
    {
        public premiumtype_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkpremcode(string premcode, string compcode, string userid, string premname, string advtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkprem.checkprem_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                

                OracleParameter prm1 = new OracleParameter("comcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("V_PREMNANE", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = premname;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("V_ADVTYPE", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = advtype;
                objOraclecommand.Parameters.Add(prm5);  
                
                
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

        public DataSet insertintoprem(string advtype, string premcode, string alias, string premdesc, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertpremtype.insertpremtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = advtype;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = alias;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("premdesc", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premdesc;
                objOraclecommand.Parameters.Add(prm6);

                

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

        public DataSet executeintoprem(string advtype, string premcode, string alias, string premdesc, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executepremtype.executepremtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                

                //objOraclecommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value=userid;

                OracleParameter prm3 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (advtype=="0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                prm3.Value = advtype;
                }
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("premdesc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premdesc;
                objOraclecommand.Parameters.Add(prm5);
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                

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
        public DataSet firstfromprem()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstpremtype.firstpremtype_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


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

        public DataSet updateintoprem(string advtype, string premcode, string alias, string premdesc, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatepremtype.updatepremtype_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                

                //objOraclecommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value=userid;

                OracleParameter prm3 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = advtype;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("alias1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("premdesc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premdesc;
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

        public DataSet deleteintoprem(string premcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletepremtype.deletepremtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("premcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = premcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                

                //objOraclecommand.Parameters.Add("@userid",SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value=userid;

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








        public DataSet chkptcode1(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkptname.chkptname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;

                if(str.Length >2)
                {
                    prm2.Value =str.Substring (0,2);
                }
                else
                {
                prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);
                 
                    
                
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

    }
}
