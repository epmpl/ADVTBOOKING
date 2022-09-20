using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AgencyTypeMaster
/// </summary>
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for AgencyTypeMaster.
    /// </summary>
    public class AgencyTypeMaster : connection
    {
        public AgencyTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet atmsave(string companycode, string code, string name, string alias, string UserId, string txtefffrom, string txtefftill, string commrate, string commapply, string creditdays, string adcat, string uniqueid, string mrvno, string PAM_TARGET_TABLENAME, string monthdate,string comm_req)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atm_Save", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@atc", SqlDbType.VarChar);
                com.Parameters["@atc"].Value = code;

                com.Parameters.Add("@atn", SqlDbType.VarChar);
                com.Parameters["@atn"].Value = name;

                com.Parameters.Add("@ata", SqlDbType.VarChar);
                com.Parameters["@ata"].Value = alias;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@effectivefrom", SqlDbType.DateTime);
               
                if (txtefffrom == null || txtefffrom == "" || txtefffrom =="undefined/undefined/")
                {
                    com.Parameters["@effectivefrom"].Value = System.DBNull.Value;
                    
                }
                else
                {
                    com.Parameters["@effectivefrom"].Value = Convert.ToDateTime(txtefffrom);
                }

                com.Parameters.Add("@effectivetill", SqlDbType.DateTime);
                if (txtefftill == null || txtefftill == "" || txtefftill == "undefined/undefined/")
                {
                    com.Parameters["@effectivetill"].Value = System.DBNull.Value;  
                }
                else
                {
                    com.Parameters["@effectivetill"].Value = Convert.ToDateTime(txtefftill);
                    
                }
               

                com.Parameters.Add("@commrate", SqlDbType.VarChar);
                com.Parameters["@commrate"].Value = commrate;

                com.Parameters.Add("@commapply", SqlDbType.VarChar);
                com.Parameters["@commapply"].Value = commapply;

                com.Parameters.Add("@creditdays", SqlDbType.VarChar);
                com.Parameters["@creditdays"].Value = creditdays;

                com.Parameters.Add("@adcat", SqlDbType.VarChar);
                com.Parameters["@adcat"].Value = adcat;

                com.Parameters.Add("@uniqueid", SqlDbType.VarChar);
                com.Parameters["@uniqueid"].Value = uniqueid;

                com.Parameters.Add("@mrvno", SqlDbType.VarChar);
                com.Parameters["@mrvno"].Value = mrvno;

                com.Parameters.Add("@pamtargettablename", SqlDbType.VarChar);
                com.Parameters["@pamtargettablename"].Value = PAM_TARGET_TABLENAME;

                com.Parameters.Add("@pmonthbill", SqlDbType.VarChar);
                com.Parameters["@pmonthbill"].Value = monthdate;


                com.Parameters.Add("@commreq", SqlDbType.VarChar);
                com.Parameters["@commreq"].Value = comm_req;
                
                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet atmmodify(string companycode, string code, string name, string alias, string UserId, string txtefffrom, string txtefftill, string commrate, string commdetail, string creditdays, string adcat, string uniqueid, string mrvno, string PAM_TARGET_TABLENAME, string monthdate,string comm_req)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atm_Modify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@atc", SqlDbType.VarChar);
                com.Parameters["@atc"].Value = code;

                com.Parameters.Add("@atn", SqlDbType.VarChar);
                com.Parameters["@atn"].Value = name;

                com.Parameters.Add("@ata", SqlDbType.VarChar);
                com.Parameters["@ata"].Value = alias;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@effectivefrom", SqlDbType.DateTime);

                if (txtefffrom == null || txtefffrom == "" || txtefffrom == "undefined/undefined/")
                {
                    com.Parameters["@effectivefrom"].Value = System.DBNull.Value;

                }
                else
                {
                    com.Parameters["@effectivefrom"].Value = Convert.ToDateTime(txtefffrom);
                }

                com.Parameters.Add("@effectivetill", SqlDbType.DateTime);
                if (txtefftill == null || txtefftill == "" || txtefftill == "undefined/undefined/")
                {
                    com.Parameters["@effectivetill"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@effectivetill"].Value = Convert.ToDateTime(txtefftill);

                }

                com.Parameters.Add("@commrate", SqlDbType.VarChar);
                com.Parameters["@commrate"].Value = commrate;

                com.Parameters.Add("@commapply", SqlDbType.VarChar);
                com.Parameters["@commapply"].Value = commdetail;

                com.Parameters.Add("@creditdays", SqlDbType.VarChar);
                com.Parameters["@creditdays"].Value = creditdays;

                com.Parameters.Add("@adcat", SqlDbType.VarChar);
                com.Parameters["@adcat"].Value = adcat;

                com.Parameters.Add("@uniqueid", SqlDbType.VarChar);
                com.Parameters["@uniqueid"].Value = uniqueid;


                com.Parameters.Add("@mrvno", SqlDbType.VarChar);
                com.Parameters["@mrvno"].Value = mrvno;

                com.Parameters.Add("@pamtargettablename", SqlDbType.VarChar);
                com.Parameters["@pamtargettablename"].Value = PAM_TARGET_TABLENAME;


                com.Parameters.Add("@pmonthbill", SqlDbType.VarChar);
                 com.Parameters["@pmonthbill"].Value = monthdate;



                 com.Parameters.Add("@comm_req", SqlDbType.VarChar);
                 com.Parameters["@comm_req"].Value = comm_req;
                
                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet atmdelete(string companycode, string code, string name, string alias, string UserId,string id)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atm_Delete", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@atc", SqlDbType.VarChar);
                com.Parameters["@atc"].Value = code;

                com.Parameters.Add("@atn", SqlDbType.VarChar);
                com.Parameters["@atn"].Value = name;

                com.Parameters.Add("@ata", SqlDbType.VarChar);
                com.Parameters["@ata"].Value = alias;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = UserId;


                com.Parameters.Add("@id", SqlDbType.VarChar);
                com.Parameters["@id"].Value = id;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet atmexecute(string companycode, string code, string name, string alias, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atm_Execute", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@atc", SqlDbType.VarChar);
                if (code != "" && code != null)
                {
                    com.Parameters["@atc"].Value = code;
                }
                else
                {
                    com.Parameters["@atc"].Value = "%%";
                }

                com.Parameters.Add("@atn", SqlDbType.VarChar);
                if (name != "" && name != null)
                {
                    com.Parameters["@atn"].Value = name;
                }
                else
                {
                    com.Parameters["@atn"].Value = "%%";
                }

                com.Parameters.Add("@ata", SqlDbType.VarChar);
                if (alias != "" && alias != null)
                {
                    com.Parameters["@ata"].Value = alias;
                }
                else
                {
                    com.Parameters["@ata"].Value = "%%";
                }
                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet atmexecute1(string companycode, string code, string name, string alias, string UserId)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atm_Execute", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@atc", SqlDbType.VarChar);
                if (code != "" && code != null)
                {
                    com.Parameters["@atc"].Value = code;
                }
                else
                {
                    com.Parameters["@atc"].Value = "%%";
                }

                com.Parameters.Add("@atn", SqlDbType.VarChar);
                if (name != "" && name != null)
                {
                    com.Parameters["@atn"].Value = name;
                }
                else
                {
                    com.Parameters["@atn"].Value = "%%";
                }

                com.Parameters.Add("@ata", SqlDbType.VarChar);
                if (alias != "" && alias != null)
                {
                    com.Parameters["@ata"].Value = alias;
                }
                else
                {
                    com.Parameters["@ata"].Value = "%%";
                }
                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet atmfpnl()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atmfpnl", ref con);
                com.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet chkatmcode(string companycode, string UserId, string code,string adname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atmcheck", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = companycode;

                com.Parameters.Add("@atc", SqlDbType.VarChar);
                com.Parameters["@atc"].Value = code;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = UserId;

                com.Parameters.Add("@adname", SqlDbType.VarChar);
                com.Parameters["@adname"].Value = adname;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }



        public DataSet agtypecode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autoagtypecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet chkslab(string compcode,string agtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_agency_type_chkslab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }



    }
}
