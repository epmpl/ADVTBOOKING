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
namespace NewAdbooking.Report.classesoracle
{
    /// <summary>
    /// Summary description for RO_Agency_Wise
    /// </summary>
    public class RO_Agency_Wise:orclconnection
    {
        public RO_Agency_Wise()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindpaymode(string compcode)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("an_payment.an_payment_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);





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

        public DataSet ro_report(string compcode, string dateformat, string userid, string chk_access, string from_date, string to_date, string print_cent, string agency, string branch, string district, string taluka, string ro_doc, string pay_mode, string executive, string retainer, string det_sum, string age_exeret, string type, string ad_type, string adcat, string dtbased, string adsubcat, string rpttype, string extra1, string extra2)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Ro_Report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("chk_access", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = chk_access;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (from_date == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = from_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        from_date = mm + "/" + dd + "/" + yy;


                    }


                    prm5.Value = Convert.ToDateTime(from_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateto", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (to_date == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = to_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        to_date = mm + "/" + dd + "/" + yy;


                    }


                    prm6.Value = Convert.ToDateTime(to_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pprint_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (print_cent=="0")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = print_cent;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pagency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (agency == "0" || agency=="")
                    prm8.Value = System.DBNull.Value;
                else
                    prm8.Value = agency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbranch", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "Select Branch")
                    prm9.Value = System.DBNull.Value;
                else
                    prm9.Value = branch;
               
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pdistrict", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (district == "0" || district == "Select District")
                    prm10.Value = System.DBNull.Value;
                else
                prm10.Value = district;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ptaluka", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (taluka == "0" ||taluka=="")
                prm11.Value = System.DBNull.Value;
                else
                prm11.Value = taluka;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pro_doc_status", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (ro_doc == "0")
                prm12.Value = System.DBNull.Value;
                else
                prm12.Value = ro_doc;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("ppay_mode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (pay_mode == "0")
                    prm13.Value = System.DBNull.Value;
                else
                prm13.Value = pay_mode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pexecutive", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (executive == "0" || executive=="")
                    prm14.Value = System.DBNull.Value;
                else
                prm14.Value = executive;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pretainer", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (retainer == "0" || retainer=="")
                    prm15.Value = System.DBNull.Value;
                else
                prm15.Value = retainer;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("det_summry", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = det_sum;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("age_exeret", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = age_exeret;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pad_type", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (ad_type=="0")
                    prm18.Value = System.DBNull.Value;
                else
                prm18.Value = ad_type;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pad_cat", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (adcat=="0")
                prm19.Value = System.DBNull.Value;
                else
                prm19.Value = adcat;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("ptype", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (type == "0")
                    prm20.Value = System.DBNull.Value;
                else
                prm20.Value = type;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("P_datebased", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dtbased;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm201 = new OracleParameter("padsubcat", OracleType.VarChar);
                prm201.Direction = ParameterDirection.Input;
                    if (adsubcat == "0")
                        prm201.Value = System.DBNull.Value;
                    else
                        prm201.Value = adsubcat;
                objOraclecommand.Parameters.Add(prm201);

                OracleParameter prm202 = new OracleParameter("prpttype", OracleType.VarChar);
                prm202.Direction = ParameterDirection.Input;
                    if (rpttype == "0")
                        prm202.Value = System.DBNull.Value;
                    else
                        prm202.Value = rpttype;
                objOraclecommand.Parameters.Add(prm202);

                OracleParameter prm203 = new OracleParameter("pextra1", OracleType.VarChar);
                prm203.Direction = ParameterDirection.Input;
                    if (extra1 == "0")
                        prm203.Value = System.DBNull.Value;
                    else
                        prm203.Value = extra1;
                objOraclecommand.Parameters.Add(prm203);

                OracleParameter prm204 = new OracleParameter("pextra2", OracleType.VarChar);
                prm204.Direction =
                    ParameterDirection.Input;
                    if (extra2 == "0")
                        prm204.Value = System.DBNull.Value;
                    else
                        prm204.Value = extra2;
                objOraclecommand.Parameters.Add(prm204);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;



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

        public DataSet ro_reportfirstins(string compcode, string dateformat, string userid, string chk_access, string from_date, string to_date, string print_cent, string agency, string branch, string district, string taluka, string ro_doc, string pay_mode, string executive, string retainer, string det_sum, string age_exeret, string type, string ad_type, string adcat, string dtbased, string adsubcat, string rpttype, string extra1, string extra2)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("ro_report_firstinsertionamt_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("puserid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("chk_access", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = chk_access;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (from_date == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = from_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        from_date = mm + "/" + dd + "/" + yy;


                    }


                    prm5.Value = Convert.ToDateTime(from_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateto", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (to_date == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = to_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        to_date = mm + "/" + dd + "/" + yy;


                    }


                    prm6.Value = Convert.ToDateTime(to_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pprint_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (print_cent == "0")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = print_cent;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pagency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (agency == "0" || agency == "")
                    prm8.Value = System.DBNull.Value;
                else
                    prm8.Value = agency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbranch", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "Select Branch")
                    prm9.Value = System.DBNull.Value;
                else
                    prm9.Value = branch;

                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pdistrict", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (district == "0" || district == "Select District")
                    prm10.Value = System.DBNull.Value;
                else
                    prm10.Value = district;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ptaluka", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (taluka == "0" || taluka == "")
                    prm11.Value = System.DBNull.Value;
                else
                    prm11.Value = taluka;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pro_doc_status", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (ro_doc == "0")
                    prm12.Value = System.DBNull.Value;
                else
                    prm12.Value = ro_doc;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("ppay_mode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (pay_mode == "0")
                    prm13.Value = System.DBNull.Value;
                else
                    prm13.Value = pay_mode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pexecutive", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (executive == "0" || executive == "")
                    prm14.Value = System.DBNull.Value;
                else
                    prm14.Value = executive;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pretainer", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (retainer == "0" || retainer == "")
                    prm15.Value = System.DBNull.Value;
                else
                    prm15.Value = retainer;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("det_summry", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = det_sum;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("age_exeret", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = age_exeret;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pad_type", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (ad_type == "0")
                    prm18.Value = System.DBNull.Value;
                else
                    prm18.Value = ad_type;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pad_cat", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (adcat == "0")
                    prm19.Value = System.DBNull.Value;
                else
                    prm19.Value = adcat;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("ptype", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (type == "0")
                    prm20.Value = System.DBNull.Value;
                else
                    prm20.Value = type;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("P_datebased", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dtbased;
                objOraclecommand.Parameters.Add(prm21);


                OracleParameter prm202 = new OracleParameter("prpttype", OracleType.VarChar);
                prm202.Direction = ParameterDirection.Input;
                if (rpttype == "0")
                    prm202.Value = System.DBNull.Value;
                else
                    prm202.Value = rpttype;
                objOraclecommand.Parameters.Add(prm202);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;



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

        public DataSet issuereport_ro(string compcode, string fromdate, string todate, string pubcent, string edition, string dateformat, string userid, string chk_acc, string ratio_typ, string extra1, string extra2, string agencytyp)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_issue_pcentre_wise.rpt_issue_pcentre_wise_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppubcent", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fromdate;

                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = todate;

                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm27 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = userid;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("pratio_type", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = ratio_typ;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = extra1;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = extra2;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pagtype", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;

                if (agencytyp == "--Select Agency Name--" || agencytyp == "--Select AgencyType--")
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                {
                    prm31.Value = agencytyp;
                }

                objOraclecommand.Parameters.Add(prm31);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                // objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                //  objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }

        }
        public DataSet getQBC(string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_QBC.websp_QBC_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }

    }
}
