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
    /// Summary description for RORemarks
    /// </summary>
    public class RORemarks : orclconnection
    {
        public RORemarks()
        {
            //
            // TODO: Add constructor logic here
            //
        }
//=============================================
        public void insertRemarks(string remarks, string userid, string appstatus, string cioid, string insertid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertRemarks_mobile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm2 = new OracleParameter("remarks", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = remarks;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("appstatus", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = appstatus;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cioid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cioid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("insertid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (insertid == "" || insertid == "0")
                    prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = insertid;
                objOraclecommand.Parameters.Add(prm6);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objOraclecommand.ExecuteNonQuery();

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
////////////////////////=============================================================to bind remark=====================////////////////////////////
        public DataSet findrem(string cioid, string insertid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("RoApproval_selectremark", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("cioid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cioid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("insertid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (insertid == "" || insertid == "0")
                    prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = insertid;
                objOraclecommand.Parameters.Add(prm6);

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
    }
}