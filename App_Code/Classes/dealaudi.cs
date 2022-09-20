using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
    public class dealaudi : connection
    {
        public dealaudi()
        {


        }

        public DataSet sub(string compcode, string adtype, string vf, string vt, string agencycode, string clintname, string de, string at, string dateforma, string rate_type, string user)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_dealAudit", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype_p", SqlDbType.VarChar);
                if (adtype == "sel")
                {
                    adtype = "";
                }
                objSqlCommand.Parameters["@adtype_p"].Value = adtype;







                objSqlCommand.Parameters.Add("@validfrom_p", SqlDbType.VarChar);
                if (vf == "" || vf == null)
                {
                    objSqlCommand.Parameters["@validfrom_p"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateforma == "dd/mm/yyyy")
                    {
                        string[] arr = vf.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        vf = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@validfrom_p"].Value = vf;
                }






                objSqlCommand.Parameters.Add("@validto_p", SqlDbType.VarChar);
                if (vt == "" || vt == null)
                {
                    objSqlCommand.Parameters["@validto_p"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateforma == "dd/mm/yyyy")
                    {
                        string[] arr = vt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        vt = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@validto_p"].Value = vt;
                }







                objSqlCommand.Parameters.Add("@agency_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_p"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client_p"].Value = clintname;

                objSqlCommand.Parameters.Add("@dealno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno_p"].Value = de;

                objSqlCommand.Parameters.Add("@audittype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audittype_p"].Value = at;

                objSqlCommand.Parameters.Add("@dateformat_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat_p"].Value = dateforma;

                objSqlCommand.Parameters.Add("@prate_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prate_type"].Value = rate_type;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = user;

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
        /*
                public DataSet updatedealstatus(string compcode, string dealno, string userid, string remark)
                {
                    SqlConnection objSqlConnection;
                    SqlCommand objSqlCommand;
                    objSqlConnection = GetConnection();
                    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
                    DataSet objDataSet = new DataSet();
                    try
                    {
                        objSqlConnection.Open();
                        objSqlCommand = GetCommand("tv_dealauditupdate", ref objSqlConnection);
                        objSqlCommand.CommandType = CommandType.StoredProcedure;

                        objSqlCommand.Parameters.Add("@pdealno", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@pdealno"].Value = dealno;

                        objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@puserid"].Value = userid;

                        objSqlCommand.Parameters.Add("@premark", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@premark"].Value = remark;

                        objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@pcompcode"].Value = compcode;


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

                */
        public DataSet updatedealstatus(string compcode, string dealno, string userid, string remark, string unit, string seq, string percentage, string lvl, string dealpass, string disamt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_dealauditupdate_new", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = dealno;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@remark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remark"].Value = remark;

                objSqlCommand.Parameters.Add("@unit_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unit_code"].Value = unit;

                objSqlCommand.Parameters.Add("@seq_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seq_no"].Value = seq;

                objSqlCommand.Parameters.Add("@assing_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@assing_flag"].Value = dealpass;

                objSqlCommand.Parameters.Add("@assing_level", SqlDbType.VarChar);
                objSqlCommand.Parameters["@assing_level"].Value = lvl;

                objSqlCommand.Parameters.Add("@dicamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dicamt"].Value = Convert.ToDecimal(disamt);

                objSqlCommand.Parameters.Add("@percentage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@percentage"].Value = percentage;


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
        public DataSet levelper(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deallevel_ad_fetch_amount12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@passed_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@passed_by"].Value = userid;



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

        public DataSet updatedealstatusunapp(string compcode, string dealno, string userid, string remark)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_dealauditupdateunapp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pdealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdealno"].Value = dealno;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@premark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premark"].Value = remark;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

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



