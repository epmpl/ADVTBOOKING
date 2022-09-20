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
    /// Summary description for fill_auditgrid
    /// </summary>
    public class fill_auditgrid : orclconnection
    {
        public fill_auditgrid()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string branch1, string adtype, string audittype, string branch2, string abc_cat, string userid, string comp_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bindaudit_grid.Bindaudit_grid_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pdate1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                objOraclecommand.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //if (dateformat == "dd/mm/yyyy")
                //{
                //    string[] tilldatearr = tilldate.Split('/');
                //    string dd1 = tilldatearr[0].ToString();
                //    string mm1 = tilldatearr[1].ToString();
                //    string yy1 = tilldatearr[2].ToString();
                //    tilldate = mm1 + "/" + dd1 + "/" + yy1;
                //}
                //prm2.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                //objOraclecommand.Parameters.Add(prm2);

                //OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                //prm3.Direction = ParameterDirection.Input;
                //if (dateformat == "dd/mm/yyyy")
                //{
                //    string[] fromdatearr = fromdate.Split('/');
                //    string dd1 = fromdatearr[0].ToString();
                //    string mm1 = fromdatearr[1].ToString();
                //    string yy1 = fromdatearr[2].ToString();
                //    fromdate = mm1 + "/" + dd1 + "/" + yy1;
                //}
                //prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); ;
                //objOraclecommand.Parameters.Add(prm3);


                /*OracleParameter prm4 = new OracleParameter("branch1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                String BRANCHNAME = branch2;
                if (branch1.IndexOf("(") >= 0)
                {
                    BRANCHNAME = branch2.Substring(0, branch2.IndexOf("("));
                }
                prm4.Value = BRANCHNAME;
                objOraclecommand.Parameters.Add(prm4);
                 * */

                OracleParameter prm5 = new OracleParameter("pAdtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                //OracleParameter prm7 = new OracleParameter("v_Cat", OracleType.VarChar);
                //prm7.Direction = ParameterDirection.Input;
                //if (abc_cat == "0")
                //{
                //    prm7.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm7.Value = abc_cat;
                //}
                //objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("pbranch2", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (branch2 != "0" && branch2 != "--Select Branch--" && branch2 != "")
                {
                    prm9.Value = branch2;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);
                /*
                 OracleParameter prm6 = new OracleParameter("audittype", OracleType.VarChar);
                 prm6.Direction = ParameterDirection.Input;
                 prm6.Value = audittype;
                 objOraclecommand.Parameters.Add(prm6);
                 */

                OracleParameter prm16 = new OracleParameter("v_userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("v_comp_code", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = comp_code;
                objOraclecommand.Parameters.Add(prm17);






                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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