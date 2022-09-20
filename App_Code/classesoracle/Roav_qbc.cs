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

/// <summary>
/// Summary description for Roav_qbc
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class Roav_qbc : orclconnection
    {
        public Roav_qbc()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindagency(string compcode, string userid, string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = userid;
                //objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agency;
                objOraclecommand.Parameters.Add(prm7);

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




        public string Save_main(string code, string unitcode, string tblname, string action, string datefrm, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_insert_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("pcolname", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcolvalue", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                cmd.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("pdelimiter", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "$~$";
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = datefrm;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra1;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra2;
                cmd.Parameters.Add(prm7);



                cmd.ExecuteNonQuery();
                //  return ds;

                //da.SelectCommand = cmd;
                //da.Fill(ds);
                return "true";

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

        public DataSet Modify_tal(string code, string unitcode, string tblname, string action, string wheresecond, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_update_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcolname", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

                OracleParameter prm9 = new OracleParameter("pcolvalue", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = unitcode;
                cmd.Parameters.Add(prm9);

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wheresecond;
                cmd.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

                //da.SelectCommand = cmd;
                //da.Fill(ds);
                cmd.ExecuteNonQuery();
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


        public DataSet cli_execute(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_execute_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);


                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);


                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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


        public string delete_tal(string tblname, string colname, string colvalue, string delimeter, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_dynamic_dml.variable_delete_stmt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptable_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = tblname;
                cmd.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("pcond_colname", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = colname;
                cmd.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcond_colval", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = colvalue;
                cmd.Parameters.Add(prm2);

                OracleParameter prm8 = new OracleParameter("pdelimiter", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = "$~$";
                cmd.Parameters.Add(prm8);

                OracleParameter prm3 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);


                //da.SelectCommand = cmd;
                //da.Fill(ds);
                cmd.ExecuteNonQuery();
                return "true";

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


        public DataSet Atognrte_Code(string pcode, string isudt, string dtformat)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            string ank = "";
            string day, month, year,date;
            string[] dates =isudt.Split('/');
            if (dtformat == "'dd/mm/yyyy'")
            {
                



                day = dates[0];
                month = dates[1];
                year = dates[2];
                if (day.Length < 2)
                    day = "0" + day;
                if (month.Length < 2)
                    month = "0" + month;

                date = month + "/" + day + "/" + year;

                isudt = "'" + Convert.ToDateTime(date).ToString("dd-MMMM-yyyy") + "'";

            }
            if (dtformat == "'mm/dd/yyyy'")
            {

                day = dates[1];
                month = dates[0];
                year = dates[2];
                if (day.Length < 2)
                    day = "0" + day;
                if (month.Length < 2)
                    month = "0" + month;

                date = month + "/" + day + "/" + year;


                isudt = "'" + Convert.ToDateTime(date).ToString("MMMM/dd/yyyy") + "'";

            }
            if (dtformat == "'yyyy/mm/dd'")
            {



                day = dates[2];
                month = dates[1];
                year = dates[0];
                if (day.Length < 2)
                    day = "0" + day;
                if (month.Length < 2)
                    month = "0" + month;

                date = month + "/" + day + "/" + year;

                isudt ="'"+ Convert.ToDateTime(date).ToString("'yyyy/MMMM/dd'")+"'";

            }


                        try
            {
              //  isudt = "'03-MAY-2012'";
                //ank = "Select ro_book_allotmentno('pcomp_code','" + pcode + "','pissue_dt','" + isudt + "','pdateformat','" + dtformat + "') AS ISSUE_NO from dual";
                ank = "Select ro_book_allotmentno(" + pcode + "," + isudt + "," + dtformat + ") AS ISSUE_NO from dual";
                cmd.CommandText = ank;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

            return ds;
        }

        public DataSet Agency_get(string pcode, string subcode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            string ank = "";
            try
            {
                ank = "Select ad_get_fieldname('Comp_Code','" + pcode + "','code_subcode','" + subcode + "','Agency_Name','agency_mast','','') AS Agency_Name from dual";
                cmd.CommandText = ank;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);

                //ad_get_fieldname ('Comp_Code','HT001','code_subcode',
                //                   'TC0TCP0',
                //                   'Agency_Name',
                //                   'agency_mast',
                //                   '',
                //                   ''
                //                  ) AS agencyname
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

            return ds;
        }

        public DataSet Agency_getname(string pcode, string subcode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            string ank = "";
            try
            {
                ank = "Select jbl_get_agency(" + "'" + pcode + "'" + "," + "'" + subcode + "'" + ") AS Agency_Name from dual";
                //  ank = "Select jbl_get_agency('Comp_Code','" + pcode + "','code_subcode','" + subcode + "','Agency_Name','agency_mast','','') AS Agency_Name from dual";
                cmd.CommandText = ank;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);

                //ad_get_fieldname ('Comp_Code','HT001','code_subcode',
                //                   'TC0TCP0',
                //                   'Agency_Name',
                //                   'agency_mast',
                //                   '',
                //                   ''
                //                  ) AS agencyname
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

            return ds;
        }

        public DataSet duplicacy_chk(string ptbl_name, string pcol1, string pcol1_val, string pcol2, string pcol2_val, string pcol3, string pcol3_val, string pcol4, string pcol4_val, string pcol5, string pcol5_val, string pcol6, string pcol6_val, string pcol7, string pcol7_val, string pcol8, string pcol8_val, string pcol9, string pcol9_val, string pcol10, string pcol10_val, string date, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("tv_duplicacy", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptbl_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = ptbl_name;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcol1", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcol1;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcol1_val", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pcol1_val;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pcol2", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pcol2;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pcol2_val", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
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
                prm5.Value = Convert.ToDateTime(pcol2_val).ToString("dd-MMMM-yyyy");
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pcol3", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pcol3;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pcol3_val", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pcol3_val;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pcol4", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pcol4;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pcol4_val", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pcol4_val;
                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pcol5", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pcol5;
                cmd.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pcol5_val", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pcol5_val;
                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pcol6", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pcol6;
                cmd.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pcol6_val", OracleType.VarChar, 2000);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pcol6_val;
                cmd.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pcol7", OracleType.VarChar, 2000);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pcol7;
                cmd.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pcol7_val", OracleType.VarChar, 2000);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pcol7_val;
                cmd.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pcol8", OracleType.VarChar, 2000);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pcol8;
                cmd.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pcol8_val", OracleType.VarChar, 2000);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pcol8_val;
                cmd.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pcol9", OracleType.VarChar, 2000);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = pcol4_val;
                cmd.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pcol9_val", OracleType.VarChar, 2000);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pcol9_val;
                cmd.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pcol10", OracleType.VarChar, 2000);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = pcol10;
                cmd.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pcol10_val", OracleType.VarChar, 2000);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pcol10_val;
                cmd.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = date;
                cmd.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = extra1;
                cmd.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = extra2;
                cmd.Parameters.Add(prm24);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("tv_duplicacy", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ptbl_name", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = ptbl_name;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcol1", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcol1;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcol1_val", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pcol1_val;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pcol2", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pcol2;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pcol2_val", OracleType.VarChar, 2000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcol2_val;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pcol3", OracleType.VarChar, 2000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pcol3;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pcol3_val", OracleType.VarChar, 2000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pcol3_val;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pcol4", OracleType.VarChar, 2000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pcol4;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pcol4_val", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pcol4_val;
                cmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pcol5", OracleType.VarChar, 2000);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pcol5;
                cmd.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pcol5_val", OracleType.VarChar, 2000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pcol5_val;
                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pcol6", OracleType.VarChar, 2000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pcol6;
                cmd.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pcol6_val", OracleType.VarChar, 2000);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pcol6_val;
                cmd.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pcol7", OracleType.VarChar, 2000);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pcol7;
                cmd.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pcol7_val", OracleType.VarChar, 2000);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pcol7_val;
                cmd.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pcol8", OracleType.VarChar, 2000);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pcol8;
                cmd.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pcol8_val", OracleType.VarChar, 2000);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pcol8_val;
                cmd.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pcol9", OracleType.VarChar, 2000);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = pcol4_val;
                cmd.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pcol9_val", OracleType.VarChar, 2000);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pcol9_val;
                cmd.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pcol10", OracleType.VarChar, 2000);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = pcol10;
                cmd.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pcol10_val", OracleType.VarChar, 2000);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = pcol10_val;
                cmd.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = date;
                cmd.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = extra1;
                cmd.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = extra2;
                cmd.Parameters.Add(prm24);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet rate_ecode(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autoagtypecode.autoratecode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2);
                }
                else
                {
                    prm2.Value = str;
                }
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;






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


        public DataSet bindstatus(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindstatus_for_ratemast", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

               

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


        public DataSet validate_rate(string compcode, string ratecode, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_RATECODE_CHECK", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pratecode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ratecode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra1;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = extra2;
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

        public DataSet getagamnt(string compcode, string agncod)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getagcrdamnt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("pcomp_cod", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pagsubcod", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agncod;
                objOraclecommand.Parameters.Add(prm4);

               

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