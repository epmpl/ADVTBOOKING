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
namespace NewAdbooking.Report.classesoracle
{

    public class qbc_alleditions_rpt : orclconnection
    {
        public qbc_alleditions_rpt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindunit(string extra1)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("websp_pubcenter.websp_pubcenter_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
                cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }

        }
        public DataSet getBranch_weekbill(string userid, string pubcenter, string extra1)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_branch_bind.cir_branch_bind_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("puserid", OracleType.VarChar, 1000);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = userid;
                //cmd.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("pubcenter", OracleType.VarChar, 1000);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = pubcenter;
                //cmd.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("puserid", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcenter", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcenter;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm5);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
    }
}