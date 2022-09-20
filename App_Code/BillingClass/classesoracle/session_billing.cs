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
namespace NewAdbooking.BillingClass.classesoracle
{

    /// <summary>
    /// Summary description for session_billing
    /// </summary>
    public class session_billing: orclconnection
    {
    
        public session_billing()
        {
            //
            // TODO: Add constructor logic here
            //
        }




        public DataSet bindbranch_userwise(string userid_v)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_branch_branchwise.bind_branch_branchwise_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                if (userid_v == "")
                {
                    prm3.Value = System.DBNull.Value;

                }
                else
                {
                    prm3.Value = userid_v;

                }
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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


        public DataSet ad_get_backdays_validate(string pcomp_code, string pformname, string puserid, string pentry_date, string pdateformat, string pextra1, string pextra2)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            {
                try
                {





                    con.Open();
                    string query = "select  ad_get_backdays_validate('" + pcomp_code + "','" + pformname + "','" + puserid + "','" + pentry_date + "','" + pdateformat + "','" + pextra1 + "','" + pextra2 + "') AS CHKDATE from dual";
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    //cmd.ExecuteNonQuery();

                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;


                
                }
                catch (Exception objException)
                {
                    throw (objException);
                }
                finally
                {
                    CloseConnection(ref con);
                }
            }

        }




        public DataSet fetch_agency(string   booking_id,string comp_code,string type_bill)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            {
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("bill_fetch_agencymail", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;
                    OracleParameter prm1 = new OracleParameter("v_booking", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = booking_id;
                    objOraclecommand.Parameters.Add(prm1);



                    OracleParameter prm3 = new OracleParameter("vcomp_code", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;

                    if (comp_code == "")
                    {
                        prm3.Value = System.DBNull.Value;

                    }
                    else
                    {
                        prm3.Value = comp_code;

                    }
                    objOraclecommand.Parameters.Add(prm3);


                    OracleParameter prm4 = new OracleParameter("v_type_bill", OracleType.VarChar, 50);
                    prm4.Direction = ParameterDirection.Input;
                    prm4.Value = type_bill;
                    objOraclecommand.Parameters.Add(prm4);


                    objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                    objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                    objorclDataAdapter.SelectCommand = objOraclecommand;
                    objorclDataAdapter.Fill(objDataSet);
                    return objDataSet;
                }
                catch (Exception objException)
                {
                    throw (objException);
                }
                finally
                {
                    objOracleConnection.Close();
                }
            }

        }

        public DataSet chklogin_billing(string user_id, string comp_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("billing_session.billing_session_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("vusername", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = user_id;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("vcomp_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                if (comp_code == "")
                {
                    prm3.Value = System.DBNull.Value;

                }
                else
                {
                    prm3.Value = comp_code;

                }
                objOraclecommand.Parameters.Add(prm3);
             
                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;
               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

    }
}