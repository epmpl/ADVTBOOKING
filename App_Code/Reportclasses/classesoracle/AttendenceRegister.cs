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
    /// Summary description for AttendenceRegister
    /// </summary>
    public class AttendenceRegister : orclconnection
    {
        public AttendenceRegister()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string status, string edition, string pubcenter, string adtype, string adcategory, string dateformate, string descid, string ascdesc, string supplement, string package1, string editiondetail, string useid, string chk_acc, string branch, string pbookfrom, string uomcode, string subcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("schedulereport_checklist", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformate;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm3.Value = publication;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter e4 = new OracleParameter("supplement_name", OracleType.VarChar, 50);
                e4.Direction = ParameterDirection.Input;
                if (supplement != "0" && supplement != "")
                {
                    e4.Value = supplement;
                }
                else
                {
                    e4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(e4);



                OracleParameter prm4 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = descid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0" && frmdt != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (todate != "0" && todate != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("edition_name", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (pubcenter == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = pubcenter;
                }

                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("adcatg", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (adcategory == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("adtyp", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adtype;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm21 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = subcatcode;
                objOraclecommand.Parameters.Add(prm21);


                OracleParameter prm12 = new OracleParameter("drpstatus", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (status == "cancel")
                {
                    prm12.Value = "includecancel";
                }
                else if (status == "hold")
                {
                    prm12.Value = "includehold";
                }
                else
                {
                    prm12.Value = "cancel";
                }
                objOraclecommand.Parameters.Add(prm12);



                OracleParameter prm13 = new OracleParameter("packagecode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (package1 == "0" || package1 == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = package1;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("editiondtl", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = editiondetail;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("p_branch", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (branch == "" || branch == "0")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = branch;
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("poth_branch_flag", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pbookfrom;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("p_uom", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                if (uomcode == "0" || uomcode == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = uomcode;
                }
                objOraclecommand.Parameters.Add(prm17);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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
//===========================  Call Procedure for Bill Register checklist =============================//
        public DataSet getbillregisterrec_chklst(string frmdt, string todate, string compcode, string publication, string branch, string edition, string pubcenter, string adtype, string dateformate, string useid, string chk_acc, string Agencytype, string ratecod, string uom, string Basedon, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                if (type == "run")
                    objOraclecommand = GetCommand("rpt_billregister_checklist", ref objOracleConnection);
              else
                    objOraclecommand = GetCommand("rpt_billregister_summ", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;
                
                   

                OracleParameter top1 = new OracleParameter("PADTYPE", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    top1.Value = System.DBNull.Value;
                }
                else
                {
                    top1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("PUBLICATION", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
                    top2.Value = System.DBNull.Value;
                else
                    top2.Value = publication;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("PCOMPCODE", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("DATEFORMAT", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformate;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PUB_CENT", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (pubcenter != "0" && pubcenter != "")
                {
                    prm3.Value = pubcenter;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter e4 = new OracleParameter("EDITION", OracleType.VarChar, 50);
                e4.Direction = ParameterDirection.Input;
                if (edition != "0" && edition != "")
                {
                    e4.Value = edition;
                }
                else
                {
                    e4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(e4);



                OracleParameter prm4 = new OracleParameter("PBRANCH", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = branch;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("PAGENTYPE", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (Agencytype == "0" || Agencytype == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = Agencytype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("FROMDATE", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0" && frmdt != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("DATETO", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (todate != "0" && todate != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("PRATECODE", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (ratecod == "0" || ratecod == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = ratecod;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("PUOM", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (uom == "0" || uom == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = uom;
                }

                objOraclecommand.Parameters.Add(prm9);
                if (type == "run")
                {
                    OracleParameter prm10 = new OracleParameter("PFILTERON", OracleType.VarChar, 50);
                    prm10.Direction = ParameterDirection.Input;
                    prm10.Value = Basedon;
                    objOraclecommand.Parameters.Add(prm10);
                }

                OracleParameter prm11 = new OracleParameter("PUSERID", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = useid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("CHK_ACCESS", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = chk_acc;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("PEXTRA1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("PEXTRA2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                objOraclecommand.Parameters.Add("P_RECORDSET", OracleType.Cursor);
                objOraclecommand.Parameters["P_RECORDSET"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_RECORDSET1", OracleType.Cursor);
                objOraclecommand.Parameters["P_RECORDSET1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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
        public DataSet getbillregisterrec_chklst_detail(string frmdt, string todate, string compcode, string publication, string branch, string edition, string pubcenter, string adtype, string dateformate, string useid, string chk_acc, string Agencytype, string ratecod, string uom, string Basedon, string type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                if (type == "run")
                    objOraclecommand = GetCommand("rpt_billsummary_checklist", ref objOracleConnection);
                else
                    objOraclecommand = GetCommand("rpt_billsummary_checklist", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter top1 = new OracleParameter("padtype", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    top1.Value = System.DBNull.Value;
                }
                else
                {
                    top1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(top1);

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0" && frmdt != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (todate != "0" && todate != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (pubcenter != "0" && pubcenter != "")
                {
                    prm3.Value = pubcenter;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = branch;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pagentype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (Agencytype == "0" || Agencytype == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = Agencytype;
                objOraclecommand.Parameters.Add(prm5);







                OracleParameter prm8 = new OracleParameter("pratecode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (ratecod == "0" || ratecod == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = ratecod;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("puom", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (uom == "0" || uom == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = uom;
                }

                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = useid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("chk_access", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = chk_acc;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = edition;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                objOraclecommand.Parameters.Add("p_recordset", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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
        public DataSet displaycardratereport(string frmdt, string todate, string compcode, string pcenter, string pratecode, string adtype, string adcategory, string dateformate, string package1, string useid, string uomcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_ratecard", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("pfromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0" && frmdt != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdateto", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (todate != "0" && todate != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm11 = new OracleParameter("padtyp", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adtype;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm10 = new OracleParameter("padcatg", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (adcategory == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm13 = new OracleParameter("ppackagecode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (package1 == "0" || package1 == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = package1;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter top2 = new OracleParameter("pcenter", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = pcenter;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm3 = new OracleParameter("pratecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (pratecode != "0")
                {
                    prm3.Value = pratecode;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm17 = new OracleParameter("p_uom", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                if (uomcode == "0" || uomcode == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = uomcode;
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter prm4 = new OracleParameter("extra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("extra2", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm8 = new OracleParameter("extra3", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("extra4", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm14 = new OracleParameter("extra5", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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
        public DataSet dailyreportdata(string dpaddtype, string frmdt, string todate, string compcode, string pubcenter, string branch, string dateformate, string Agencytype, string ratecod, string uom, string useid, string chk_acc, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();              
               objOraclecommand = GetCommand("daily_billing_data_report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter top1 = new OracleParameter("padtype", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                if (dpaddtype == "0" || dpaddtype == "")
                {
                    top1.Value = System.DBNull.Value;
                }
                else
                {
                    top1.Value = dpaddtype;
                }
                objOraclecommand.Parameters.Add(top1);

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0" && frmdt != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (todate != "0" && todate != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (pubcenter != "0" && pubcenter != "")
                {
                    prm3.Value = pubcenter;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = branch;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pagentype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (Agencytype == "0" || Agencytype == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = Agencytype;
                objOraclecommand.Parameters.Add(prm5);







                OracleParameter prm8 = new OracleParameter("pratecode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (ratecod == "0" || ratecod == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = ratecod;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("puom", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (uom == "0" || uom == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = uom;
                }

                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = useid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("chk_access", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = chk_acc;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = extra1;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = extra2;
                objOraclecommand.Parameters.Add(prm14);

                objOraclecommand.Parameters.Add("p_recordset", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
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
        public DataSet dist(string compcode, string state)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("distMst_state", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                objOraclecommand.Parameters.Clear();



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("statecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = state;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet state(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("stateMst_state", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                objOraclecommand.Parameters.Clear();



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet city(string compcode, string dist)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cityMst_city", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                objOraclecommand.Parameters.Clear();



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("distcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dist;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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
        public DataSet bankbranch(string compcode, string centercode, string branchname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("branch_name_new", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranchname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchname;
                objOraclecommand.Parameters.Add(prm3);

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
       public DataSet spfun1(string agname,string clientname, string adtype, string listadcat, string listadsubcat, string fromdate, string dateto, string compcode, string pubname, string pubcent, string status, string edition, string dateformat, string ascdesc, string hold, string descid,  string agencytype, string useridmain, string chk_access, string branch, string printcenter, string docket, string searching, string uom, string userid, string state, string dist, string city )
            {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;


                objOraclecommand = GetCommand("daily_booking_report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("agname", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = agname;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("clientname", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = clientname;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("adtype1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("Adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (listadcat == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {


                    prm2.Value = listadcat;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm255 = new OracleParameter("Adsubcategory", OracleType.VarChar);
                prm255.Direction = ParameterDirection.Input;
                if (listadsubcat == "")
                {
                    prm255.Value = System.DBNull.Value;
                }
                else
                {


                    prm255.Value = listadsubcat;
                }
                objOraclecommand.Parameters.Add(prm255);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate  == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }


                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pub_name", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm6);

              
                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm327 = new OracleParameter("status", OracleType.VarChar);
                prm327.Direction = ParameterDirection.Input;
                if (status == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm327.Value = status;
                }
                objOraclecommand.Parameters.Add(prm327);


                OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = hold;
                objOraclecommand.Parameters.Add(temp4);


                OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = descid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
                tmp33.Direction = ParameterDirection.Input;
                if (agencytype == "0" || agencytype == "--Select AgencyType--")
                {
                    tmp33.Value = System.DBNull.Value;
                }
                else
                {
                    tmp33.Value = agencytype;
                }
                objOraclecommand.Parameters.Add(tmp33);


                OracleParameter temp1 = new OracleParameter("puserid", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                temp1.Value = useridmain;
                objOraclecommand.Parameters.Add(temp1);

                OracleParameter temp2 = new OracleParameter("chk_access", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = chk_access;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter po1 = new OracleParameter("pbranch", OracleType.VarChar);
                po1.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "Select Branch")
                {
                    po1.Value = System.DBNull.Value;
                }
                else
                {
                    po1.Value = branch;
                }
                objOraclecommand.Parameters.Add(po1);

                OracleParameter po2 = new OracleParameter("pprint_center", OracleType.VarChar);
                po2.Direction = ParameterDirection.Input;
                if (printcenter == "0")
                {
                    po2.Value = System.DBNull.Value;
                }
                else
                {
                    po2.Value = printcenter;
                }
                objOraclecommand.Parameters.Add(po2);


                OracleParameter doc1 = new OracleParameter("pwithout_rono", OracleType.VarChar);
                doc1.Direction = ParameterDirection.Input;
                doc1.Value = docket;
                objOraclecommand.Parameters.Add(doc1);



                OracleParameter ser1 = new OracleParameter("pdate_flag", OracleType.VarChar);
                ser1.Direction = ParameterDirection.Input;
                ser1.Value = searching;
                objOraclecommand.Parameters.Add(ser1);           
              

                OracleParameter ser2 = new OracleParameter("pextra1", OracleType.VarChar);
                ser2.Direction = ParameterDirection.Input;

                if (uom == "0" || uom == "--Select UOM Name--")
                {
                    ser2.Value = System.DBNull.Value;
                }
                else
                {
                    ser2.Value = uom;
                }

                objOraclecommand.Parameters.Add(ser2);

                OracleParameter ser3 = new OracleParameter("pextra2", OracleType.VarChar);
                ser3.Direction = ParameterDirection.Input;
                if (userid == "" || userid == "0")
                {
                    ser3.Value = System.DBNull.Value;
                }
                else
                {
                    ser3.Value = userid;
                }
                objOraclecommand.Parameters.Add(ser3);

                OracleParameter ser4 = new OracleParameter("pextra3", OracleType.VarChar);
                ser4.Direction = ParameterDirection.Input;
                if (state == "" || state == "0")
                {
                    ser4.Value = System.DBNull.Value;
                }
                else
                {
                    ser4.Value = state;
                }

                objOraclecommand.Parameters.Add(ser4);

                OracleParameter ser5 = new OracleParameter("pextra4", OracleType.VarChar);
                ser5.Direction = ParameterDirection.Input;
                if (dist == "" || dist == "0")
                {
                    ser5.Value = System.DBNull.Value; ;
                }
                else
                {
                    ser5.Value = dist;
                }

                objOraclecommand.Parameters.Add(ser5);

                OracleParameter ser6 = new OracleParameter("pextra5", OracleType.VarChar);
                ser6.Direction = ParameterDirection.Input;
                if (city == "" || city == "0")
                {
                    ser6.Value = System.DBNull.Value;
                }
                else
                {
                    ser6.Value = city;
                }

                objOraclecommand.Parameters.Add(ser6);




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
