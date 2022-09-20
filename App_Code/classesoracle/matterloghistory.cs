using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.OracleClient;

/// <summary>
/// Summary description for RateMaster
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class matterloghistory : orclconnection
    {
        public matterloghistory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet updatedealstatus(string tabl, string userid, string frmdt, string todt, string dateformat, string bukid, string branch)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getmatterlog", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tabl;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pfrmdt", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] fromdatearr = frmdt.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    frmdt = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm3.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy"); ;


             //   prm3.Value = frmdt;
                objOraclecommand.Parameters.Add(prm3);

                 OracleParameter prm4 = new OracleParameter("ptdat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] fromdatearr = todt.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    todt = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm4.Value = Convert.ToDateTime(todt).ToString("dd-MMMM-yyyy"); ;


              //  prm4.Value = todt;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pbukid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bukid;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = branch;
                }
                //prm6.Value = branch;
                objOraclecommand.Parameters.Add(prm6);



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

        public DataSet MastPrevDisp_user(string compcode, string userid, string userhome, string admin, string retainer, string username)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_Modultuser.wesp_wesp_Modultuser_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userhome", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userhome;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("ADMIN1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = admin;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Retainer", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = retainer;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("username1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = username;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_extra1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_extra2", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);


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