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
using System.Data.OracleClient;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Roav_qbc
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class Roav_qbc : connection
    {
        public Roav_qbc()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindagency(string compcode, string userid, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforxls", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

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




        public string Save_main(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Cir_Dynamic_DML_variable_insert_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = code;

                objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = datefrm;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;





                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlDataAdapter.Fill(objDataSet);
                objSqlCommand.ExecuteNonQuery();

                return "true";

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

        public DataSet Modify_tal(string code, string unitcode, string tblname, string action, string wheresecond, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_update_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcolname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolname"].Value = code;

                objSqlCommand.Parameters.Add("@pcolvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolvalue"].Value = unitcode;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = wheresecond;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlDataAdapter.Fill(objDataSet);

                objSqlCommand.ExecuteNonQuery();

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


        public DataSet cli_execute(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_execute_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


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


        public string delete_tal(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_dynamic_dml_variable_delete_stmt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@ptable_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable_name"].Value = tblname;

                objSqlCommand.Parameters.Add("@pcond_colname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colname"].Value = colname;

                objSqlCommand.Parameters.Add("@pcond_colval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcond_colval"].Value = colvalue;

                objSqlCommand.Parameters.Add("@pdelimiter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdelimiter"].Value = "$~$";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = date;


                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = date;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return "true";

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


        //public DataSet Atognrte_Code( string pcode)
        //{
        //    OracleConnection con;
        //    OracleCommand cmd = new OracleCommand();
        //    con = GetConnection();
        //    DataSet ds = new DataSet();
        //    OracleDataAdapter da = new OracleDataAdapter();
        //    string ank = "";
        //    try
        //    {
        //        ank = "Select ro_book_allotmentno(" + pcode +") AS ISSUE_NO from dual";
        //        cmd.CommandText = ank;
        //        cmd.Connection = con;
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }

        //    return ds;
        //}

        public DataSet Agency_get(string pcode, string subcode, string codesubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_adagenc_bysubcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = pcode;

                objSqlCommand.Parameters.Add("@pagsubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagsubcode"].Value = subcode;

                objSqlCommand.Parameters.Add("@pcodsubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcodsubcode"].Value = codesubcode;

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

        public DataSet ro_modify(string compcode, string typ, string agncod, string issdt, string dateformat, string csisno, string ronofrm, string ronotll, string sts, string userid, string currentdate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateroqbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@typ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@typ"].Value = typ;

                objSqlCommand.Parameters.Add("@codesubcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@codesubcod"].Value = agncod;

                objSqlCommand.Parameters.Add("@issudt", SqlDbType.VarChar);

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = issdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    issdt = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = issdt.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    issdt = mm + "/" + dd + "/" + yy;
                }


                objSqlCommand.Parameters["@issudt"].Value = issdt;

                objSqlCommand.Parameters.Add("@issno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@issno"].Value = Convert.ToInt32(csisno);

                objSqlCommand.Parameters.Add("@ronofrm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ronofrm"].Value = Convert.ToInt32(ronofrm);

                objSqlCommand.Parameters.Add("@ronotll", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ronotll"].Value = Convert.ToInt32(ronotll);

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = sts;

                objSqlCommand.Parameters.Add("@crntdate", SqlDbType.VarChar);

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = currentdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    currentdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = currentdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    currentdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@crntdate"].Value = currentdate;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                //  objSqlCommand.ExecuteNonQuery();

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

        public DataSet duplicacy_chk(string ptbl_name, string pcol1, string pcol1_val, string pcol2, string pcol2_val, string pcol3, string pcol3_val, string pcol4, string pcol4_val, string pcol5, string pcol5_val, string pcol6, string pcol6_val, string pcol7, string pcol7_val, string pcol8, string pcol8_val, string pcol9, string pcol9_val, string pcol10, string pcol10_val, string date, string extra1, string extra2)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                //cmd = GetCommand("fa_check_duplicacy_fa_check_duplicacy_p", ref con);
                cmd = GetCommand("tv_duplicacy", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ptbl_name", SqlDbType.VarChar);
                cmd.Parameters["@ptbl_name"].Value = ptbl_name;

                cmd.Parameters.Add("@pcol1", SqlDbType.VarChar);
                cmd.Parameters["@pcol1"].Value = pcol1;

                cmd.Parameters.Add("@pcol1_val", SqlDbType.VarChar);
                if (pcol1_val == "")
                {
                    cmd.Parameters["@pcol1_val"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pcol1_val"].Value = pcol1_val;
                }

                cmd.Parameters.Add("@pcol2", SqlDbType.VarChar);
                cmd.Parameters["@pcol2"].Value = pcol2;

                cmd.Parameters.Add("@pcol2_val", SqlDbType.DateTime);
                if (pcol2_val == "" || pcol2_val == "0")
                    cmd.Parameters["@pcol2_val"].Value = System.DBNull.Value;
                else
                {
                    if (date == "dd/mm/yyyy")
                    {
                        string[] arr = pcol2_val.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pcol2_val = mm + "/" + dd + "/" + yy;
                    }
                    else if (date == "yyyy/mm/dd")
                    {
                        string[] arr = pcol2_val.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        pcol2_val = mm + "/" + dd + "/" + yy;
                    }
                    cmd.Parameters["@pcol2_val"].Value = Convert.ToDateTime(pcol2_val);
                }

                cmd.Parameters.Add("@pcol3", SqlDbType.VarChar);
                if (pcol3 == "" || pcol3 == "0")
                    cmd.Parameters["@pcol3"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol3"].Value = pcol3;

                cmd.Parameters.Add("@pcol3_val", SqlDbType.VarChar);
                if (pcol3_val == "" || pcol3_val == "0")
                    cmd.Parameters["@pcol3_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol3_val"].Value = pcol3_val;

                cmd.Parameters.Add("@pcol4", SqlDbType.VarChar);
                if (pcol4 == "" || pcol4 == "0")
                    cmd.Parameters["@pcol4"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol4"].Value = pcol4;

                cmd.Parameters.Add("@pcol4_val", SqlDbType.VarChar);
                if (pcol4_val == "" || pcol4_val == "0")
                    cmd.Parameters["@pcol4_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol4_val"].Value = pcol4_val;

                cmd.Parameters.Add("@pcol5", SqlDbType.VarChar);
                if (pcol5 == "" || pcol5 == "0")
                    cmd.Parameters["@pcol5"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol5"].Value = pcol5;

                cmd.Parameters.Add("@pcol5_val", SqlDbType.VarChar);
                if (pcol5_val == "" || pcol5_val == "0")
                    cmd.Parameters["@pcol5_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol5_val"].Value = pcol5_val;

                cmd.Parameters.Add("@pcol6", SqlDbType.VarChar);
                if (pcol6 == "" || pcol6 == "0")
                    cmd.Parameters["@pcol6"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol6"].Value = pcol6;

                cmd.Parameters.Add("@pcol6_val", SqlDbType.VarChar);
                if (pcol6_val == "" || pcol6_val == "0")
                    cmd.Parameters["@pcol6_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol6_val"].Value = pcol6_val;

                cmd.Parameters.Add("@pcol7", SqlDbType.VarChar);
                if (pcol7 == "" || pcol7 == "0")
                    cmd.Parameters["@pcol7"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol7"].Value = pcol7;

                cmd.Parameters.Add("@pcol7_val", SqlDbType.VarChar);
                if (pcol7_val == "" || pcol7_val == "0")
                    cmd.Parameters["@pcol7_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol7_val"].Value = pcol7_val;

                cmd.Parameters.Add("@pcol8", SqlDbType.VarChar);
                if (pcol8 == "" || pcol8 == "0")
                    cmd.Parameters["@pcol8"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol8"].Value = pcol8;

                cmd.Parameters.Add("@pcol8_val", SqlDbType.VarChar);
                if (pcol8_val == "" || pcol8_val == "0")
                    cmd.Parameters["@pcol8_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol8_val"].Value = pcol8_val;

                cmd.Parameters.Add("@pcol9", SqlDbType.VarChar);
                if (pcol9 == "" || pcol9 == "0")
                    cmd.Parameters["@pcol9"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol9"].Value = pcol9;

                cmd.Parameters.Add("@pcol9_val", SqlDbType.VarChar);
                if (pcol9_val == "" || pcol9_val == "0")
                    cmd.Parameters["@pcol9_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol9_val"].Value = pcol9_val;

                cmd.Parameters.Add("@pcol10", SqlDbType.VarChar);
                if (pcol10 == "" || pcol10 == "0")
                    cmd.Parameters["@pcol10"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol10"].Value = pcol10;

                cmd.Parameters.Add("@pcol10_val", SqlDbType.VarChar);
                if (pcol10_val == "" || pcol10_val == "0")
                    cmd.Parameters["@pcol10_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol10_val"].Value = pcol10_val;

                cmd.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                cmd.Parameters["@pdateformat"].Value = date;

                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (extra1 == "" || extra1 == "0")
                    cmd.Parameters["@pextra1"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pextra1"].Value = extra1;

                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (extra2 == "" || extra2 == "0")
                    cmd.Parameters["@pextra2"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pextra2"].Value = extra2;

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

        public DataSet duplicacy_chk_ratecode(string ptbl_name, string pcol1, string pcol1_val, string pcol2, string pcol2_val, string pcol3, string pcol3_val, string pcol4, string pcol4_val, string pcol5, string pcol5_val, string pcol6, string pcol6_val, string pcol7, string pcol7_val, string pcol8, string pcol8_val, string pcol9, string pcol9_val, string pcol10, string pcol10_val, string date, string extra1, string extra2)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                //cmd = GetCommand("fa_check_duplicacy_fa_check_duplicacy_p", ref con);
                cmd = GetCommand("tv_duplicacy", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ptbl_name", SqlDbType.VarChar);
                cmd.Parameters["@ptbl_name"].Value = ptbl_name;

                cmd.Parameters.Add("@pcol1", SqlDbType.VarChar);
                cmd.Parameters["@pcol1"].Value = pcol1;

                cmd.Parameters.Add("@pcol1_val", SqlDbType.VarChar);
                if (pcol1_val == "")
                {
                    cmd.Parameters["@pcol1_val"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pcol1_val"].Value = pcol1_val;
                }

                cmd.Parameters.Add("@pcol2", SqlDbType.VarChar);
                cmd.Parameters["@pcol2"].Value = pcol2;

                cmd.Parameters.Add("@pcol2_val", SqlDbType.VarChar);
                if (pcol2_val == "" || pcol2_val == "0")
                    cmd.Parameters["@pcol2_val"].Value = System.DBNull.Value;
                else
                {

                    cmd.Parameters["@pcol2_val"].Value = pcol2_val;
                }

                cmd.Parameters.Add("@pcol3", SqlDbType.VarChar);
                if (pcol3 == "" || pcol3 == "0")
                    cmd.Parameters["@pcol3"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol3"].Value = pcol3;

                cmd.Parameters.Add("@pcol3_val", SqlDbType.VarChar);
                if (pcol3_val == "" || pcol3_val == "0")
                    cmd.Parameters["@pcol3_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol3_val"].Value = pcol3_val;

                cmd.Parameters.Add("@pcol4", SqlDbType.VarChar);
                if (pcol4 == "" || pcol4 == "0")
                    cmd.Parameters["@pcol4"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol4"].Value = pcol4;

                cmd.Parameters.Add("@pcol4_val", SqlDbType.VarChar);
                if (pcol4_val == "" || pcol4_val == "0")
                    cmd.Parameters["@pcol4_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol4_val"].Value = pcol4_val;

                cmd.Parameters.Add("@pcol5", SqlDbType.VarChar);
                if (pcol5 == "" || pcol5 == "0")
                    cmd.Parameters["@pcol5"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol5"].Value = pcol5;

                cmd.Parameters.Add("@pcol5_val", SqlDbType.VarChar);
                if (pcol5_val == "" || pcol5_val == "0")
                    cmd.Parameters["@pcol5_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol5_val"].Value = pcol5_val;

                cmd.Parameters.Add("@pcol6", SqlDbType.VarChar);
                if (pcol6 == "" || pcol6 == "0")
                    cmd.Parameters["@pcol6"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol6"].Value = pcol6;

                cmd.Parameters.Add("@pcol6_val", SqlDbType.VarChar);
                if (pcol6_val == "" || pcol6_val == "0")
                    cmd.Parameters["@pcol6_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol6_val"].Value = pcol6_val;

                cmd.Parameters.Add("@pcol7", SqlDbType.VarChar);
                if (pcol7 == "" || pcol7 == "0")
                    cmd.Parameters["@pcol7"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol7"].Value = pcol7;

                cmd.Parameters.Add("@pcol7_val", SqlDbType.VarChar);
                if (pcol7_val == "" || pcol7_val == "0")
                    cmd.Parameters["@pcol7_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol7_val"].Value = pcol7_val;

                cmd.Parameters.Add("@pcol8", SqlDbType.VarChar);
                if (pcol8 == "" || pcol8 == "0")
                    cmd.Parameters["@pcol8"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol8"].Value = pcol8;

                cmd.Parameters.Add("@pcol8_val", SqlDbType.VarChar);
                if (pcol8_val == "" || pcol8_val == "0")
                    cmd.Parameters["@pcol8_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol8_val"].Value = pcol8_val;

                cmd.Parameters.Add("@pcol9", SqlDbType.VarChar);
                if (pcol9 == "" || pcol9 == "0")
                    cmd.Parameters["@pcol9"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol9"].Value = pcol9;

                cmd.Parameters.Add("@pcol9_val", SqlDbType.VarChar);
                if (pcol9_val == "" || pcol9_val == "0")
                    cmd.Parameters["@pcol9_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol9_val"].Value = pcol9_val;

                cmd.Parameters.Add("@pcol10", SqlDbType.VarChar);
                if (pcol10 == "" || pcol10 == "0")
                    cmd.Parameters["@pcol10"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol10"].Value = pcol10;

                cmd.Parameters.Add("@pcol10_val", SqlDbType.VarChar);
                if (pcol10_val == "" || pcol10_val == "0")
                    cmd.Parameters["@pcol10_val"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pcol10_val"].Value = pcol10_val;

                cmd.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                cmd.Parameters["@pdateformat"].Value = date;

                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (extra1 == "" || extra1 == "0")
                    cmd.Parameters["@pextra1"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pextra1"].Value = extra1;

                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (extra2 == "" || extra2 == "0")
                    cmd.Parameters["@pextra2"].Value = System.DBNull.Value;
                else
                    cmd.Parameters["@pextra2"].Value = extra2;

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

        public DataSet Agency_getname(string compcode, string codesubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "select dbo.jbl_get_agency('" + compcode + "','" + codesubcode + "') as AGENCY_NAME";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

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
                objSqlConnection.Close();
            }
        }

        public DataSet validate_rate(string compcode, string ratecode, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_RATECODE_CHECK", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = extra1;


                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = extra2;

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

        public DataSet rate_ecode(string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autoratecode", ref objSqlConnection);
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

        public DataSet bindstatus(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();



                objSqlCommand = GetCommand("bindstatus_for_ratemast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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
        public DataSet getagamnt(string compcode, string agncod)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();



                objSqlCommand = GetCommand("getagcrdamnt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_cod"].Value = compcode;

                objSqlCommand.Parameters.Add("@pagsubcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagsubcod"].Value = agncod;



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