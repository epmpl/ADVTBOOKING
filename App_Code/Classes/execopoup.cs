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

/// <summary>
/// Summary description for coupon_booklate
/// </summary>
/// \
/// 

namespace NewAdbooking.Classes
{
    public class execopoup : connection
    {
        public execopoup()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet fill_reoprt(string compcode, string pag, string id, string dateformate, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("Websp_agent", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                //sqlcom.Parameters.Add("@pag_name", SqlDbType.VarChar);
                //sqlcom.Parameters["@pag_name"].Value = pag;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = id;

                //sqlcom.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                //sqlcom.Parameters["@pdateformat"].Value = dateformate;

                //sqlcom.Parameters.Add("@pextra1", SqlDbType.VarChar);
                //sqlcom.Parameters["@pextra1"].Value = extra1;

                //sqlcom.Parameters.Add("@pextra2", SqlDbType.VarChar);
                //sqlcom.Parameters["@pextra2"].Value = System.DBNull.Value;

                //sqlcom.Parameters.Add("@pextra3", SqlDbType.VarChar);
                //sqlcom.Parameters["@pextra3"].Value = extra3;

                //sqlcom.Parameters.Add("@pextra4", SqlDbType.VarChar);
                //sqlcom.Parameters["@pextra4"].Value = extra4;

                //sqlcom.Parameters.Add("@pextra5", SqlDbType.VarChar);
                //sqlcom.Parameters["@pextra5"].Value = extra5;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }



        public DataSet duplicasy_ckeck(string compcode, string execcode, string agencycode, string fromdate, string todate, string dateformat)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AD_EXEC_DUP", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                sqlcom.Parameters["@pcompcode"].Value = compcode;

                sqlcom.Parameters.Add("@pexec_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pexec_code"].Value = execcode;

                sqlcom.Parameters.Add("@pag_type_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pag_type_code"].Value = agencycode;


                sqlcom.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    sqlcom.Parameters["@pfrom_date"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = todate.Split('/');
                        fromdate = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = todate.Split('/');
                        fromdate = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pfrom_date"].Value = fromdate;
                }


                sqlcom.Parameters.Add("@pto_date", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    sqlcom.Parameters["@pto_date"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = todate.Split('/');
                        todate = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = todate.Split('/');
                        todate = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pto_date"].Value = todate;
                }

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }





        public DataSet savedata_table(string compcode, string agencycode, string days, string limit, string recovery, string fromdate, string todate, string execcode, string createdby, string createddt, string updatedby, string updateddt, string dateformat)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AD_EXEC_insert", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@pcomcode", SqlDbType.VarChar);
                sqlcom.Parameters["@pcomcode"].Value = compcode;

                sqlcom.Parameters.Add("@pag_type_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pag_type_code"].Value = agencycode;

                sqlcom.Parameters.Add("@pcredit_days", SqlDbType.VarChar);
                sqlcom.Parameters["@pcredit_days"].Value = days;

                sqlcom.Parameters.Add("@pcredit_limit", SqlDbType.VarChar);
                sqlcom.Parameters["@pcredit_limit"].Value = limit;

                sqlcom.Parameters.Add("@precovery_limit", SqlDbType.VarChar);
                sqlcom.Parameters["@precovery_limit"].Value = recovery;

                sqlcom.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    sqlcom.Parameters["@pfrom_date"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = todate.Split('/');
                        fromdate = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = todate.Split('/');
                        fromdate = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pfrom_date"].Value = fromdate;
                }


                sqlcom.Parameters.Add("@pto_date", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    sqlcom.Parameters["@pto_date"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = todate.Split('/');
                        todate = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = todate.Split('/');
                        todate = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pto_date"].Value = todate;
                }


                sqlcom.Parameters.Add("@pexec_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pexec_code"].Value = execcode;

                sqlcom.Parameters.Add("@pcreadit_by", SqlDbType.VarChar);
                sqlcom.Parameters["@pcreadit_by"].Value = createdby;

                sqlcom.Parameters.Add("@pcreadet_dt", SqlDbType.VarChar);
                if (createddt == "" || createddt == null)
                {
                    sqlcom.Parameters["@pcreadet_dt"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = createddt.Split('/');
                        createddt = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = createddt.Split('/');
                        createddt = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pcreadet_dt"].Value = createddt;
                }

                sqlcom.Parameters.Add("@pupdated_by", SqlDbType.VarChar);
                sqlcom.Parameters["@pupdated_by"].Value = updatedby;

                sqlcom.Parameters.Add("@pupdated_dt", SqlDbType.VarChar);
                if (updateddt == "" || updateddt == null)
                {
                    sqlcom.Parameters["@pupdated_dt"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = updateddt.Split('/');
                        updateddt = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = updateddt.Split('/');
                        updateddt = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pupdated_dt"].Value = updateddt;
                }



                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
        public DataSet binddata_grid(string compcode, string agencycode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AD_EXEC_CREDIT_BIND", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@execode", SqlDbType.VarChar);
                sqlcom.Parameters["@execode"].Value = agencycode;

              

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }

        public DataSet bind_agency(string compcode, string reportto)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {

                con.Open();
                string query = "select dbo.ad_agencytype_name('" + compcode + "','" + reportto + "') as 'AGENCY_NAME'";

                da = new SqlDataAdapter();
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
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
        public DataSet mdy_table(string compcode, string agencycode, string days, string limit, string recovery, string fromdate, string todate, string execcode, string createdby, string createddt, string updatedby, string updateddt, string dateformat, string slab_no)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AD_EXEC_update", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@pcomcode", SqlDbType.VarChar);
                sqlcom.Parameters["@pcomcode"].Value = compcode;

                sqlcom.Parameters.Add("@pag_type_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pag_type_code"].Value = agencycode;

                sqlcom.Parameters.Add("@pcredit_days", SqlDbType.VarChar);
                sqlcom.Parameters["@pcredit_days"].Value = days;

                sqlcom.Parameters.Add("@pcredit_limit", SqlDbType.VarChar);
                sqlcom.Parameters["@pcredit_limit"].Value = limit;

                sqlcom.Parameters.Add("@precovery_limit", SqlDbType.VarChar);
                sqlcom.Parameters["@precovery_limit"].Value = recovery;

                sqlcom.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    sqlcom.Parameters["@pfrom_date"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = todate.Split('/');
                        fromdate = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = todate.Split('/');
                        fromdate = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pfrom_date"].Value = fromdate;
                }


                sqlcom.Parameters.Add("@pto_date", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    sqlcom.Parameters["@pto_date"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = todate.Split('/');
                        todate = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = todate.Split('/');
                        todate = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pto_date"].Value = todate;
                }


                sqlcom.Parameters.Add("@pexec_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pexec_code"].Value = execcode;

                sqlcom.Parameters.Add("@pcreadit_by", SqlDbType.VarChar);
                sqlcom.Parameters["@pcreadit_by"].Value = createdby;

                sqlcom.Parameters.Add("@pcreadet_dt", SqlDbType.VarChar);
                if (createddt == "" || createddt == null)
                {
                    sqlcom.Parameters["@pcreadet_dt"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = createddt.Split('/');
                        createddt = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = createddt.Split('/');
                        createddt = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pcreadet_dt"].Value = createddt;
                }

                sqlcom.Parameters.Add("@pupdated_by", SqlDbType.VarChar);
                sqlcom.Parameters["@pupdated_by"].Value = updatedby;

                sqlcom.Parameters.Add("@pupdated_dt", SqlDbType.VarChar);
                if (updateddt == "" || updateddt == null)
                {
                    sqlcom.Parameters["@pupdated_dt"].Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arrfdt = updateddt.Split('/');
                        updateddt = arrfdt[1] + "/" + arrfdt[2] + "/" + arrfdt[0];
                    }
                    else if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arrfdt = updateddt.Split('/');
                        updateddt = arrfdt[1] + "/" + arrfdt[0] + "/" + arrfdt[2];
                    }

                    sqlcom.Parameters["@pupdated_dt"].Value = updateddt;
                }

                sqlcom.Parameters.Add("@pexec_slab_sno", SqlDbType.VarChar);
                sqlcom.Parameters["@pexec_slab_sno"].Value = slab_no;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }

        public DataSet delete_data(string compcode, string execcode, string slab_no)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AD_EXEC_del", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@pcomcode", SqlDbType.VarChar);
                sqlcom.Parameters["@pcomcode"].Value = compcode;



                sqlcom.Parameters.Add("@pexec_code", SqlDbType.VarChar);
                sqlcom.Parameters["@pexec_code"].Value = execcode;



                sqlcom.Parameters.Add("@pexec_slab_sno", SqlDbType.VarChar);
                sqlcom.Parameters["@pexec_slab_sno"].Value = slab_no;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
    }
}
