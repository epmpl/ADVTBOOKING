using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{

    public class Executive_team_transfer : connection
    {
        public Executive_team_transfer()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet executivetransferdataexec(string compcode, string executive)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executive_team_transfer_executive_team_transfer_ex", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("execod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["execod"].Value = executive;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet executivetransferdatateam(string compcode, string team)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executive_team_transfer_executive_team_transfer_tm", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("teamcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["teamcode"].Value = team;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet executivetransferdataupdate(string compcode, string teamCode, string executiveCode, string userid, string extra1, string extra)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executive_team_transfer_executive_team_transfer_update", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("tmcod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["tmcod"].Value = teamCode;

                objmysqlcommand.Parameters.Add("executive", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["executive"].Value = executiveCode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;
                
                objmysqlcommand.Parameters.Add("pextra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra"].Value = extra;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
    }
}
