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
/// Summary description for SummaryReport
/// </summary>
namespace NewAdbooking.Report.classesoracle
{
    public class SummaryReport : orclconnection
    {
        public SummaryReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet IssueBusnonscreen(string frmdt, string todate, string publication, string edition, string dateformate, string adtype, string pubcent, string compcode, string useid, string chk_acc, string GSTstatus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Summaryreport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter p1rm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                p1rm3.Direction = ParameterDirection.Input;
                p1rm3.Value = compcode;                
                objOraclecommand.Parameters.Add(p1rm3);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (publication == "0" || publication=="")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = publication;
                   
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prme3 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prme3.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype=="")
                {
                    prme3.Value = System.DBNull.Value;
                    
                }
                else
                {
                    prme3.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prme3);


                OracleParameter prmt = new OracleParameter("pubcent", OracleType.VarChar, 50);
                prmt.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prmt.Value = System.DBNull.Value;

                }
                else
                {
                    prmt.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prmt);

                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0")
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
                if (todate != "0")
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

                OracleParameter prm8 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "" || edition == "--Select Edition Name--")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("gstflag", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (GSTstatus == "0" || GSTstatus == "")
                {
                    prm9.Value = System.DBNull.Value;

                }
                else
                {
                    prm9.Value = GSTstatus;
                }
                objOraclecommand.Parameters.Add(prm9);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            //catch (OracleException objException)
            //{
            //    throw (objException);
            //}
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet Revenuereport(string frmdt, string todate, string publication, string edition, string dateformate) // string compcode,
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Summaryreport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = compcode;
                //objOraclecommand.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = dateformate;
                //objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
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




                OracleParameter prm6 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (frmdt != "0")
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
                if (todate != "0")
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

                OracleParameter prm8 = new OracleParameter("editioncode", OracleType.VarChar, 50);
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


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            //catch (OracleException objException)
            //{
            //    throw (objException);
            //}
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet spDeviation(string cliname, string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformate, string hold, string descid, string ascdesc, string page, string position, string agentyp, string useid, string chk_acc, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deviationreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm7 = new OracleParameter("clientname", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (cliname == "0" || cliname=="")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = cliname;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("agname", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (agname == "0" || agname=="")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = agname;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("Adtype1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("adcategory", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (adcategory == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("fromdate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    prm11.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("dateto", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm12.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pub_name", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm16 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("edition", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm14 = new OracleParameter("compcode", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = compcode;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("dateformat", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dateformate;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter temp1 = new OracleParameter("status", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                if (status == "0")
                {
                    temp1.Value = System.DBNull.Value;
                }
                else
                {
                    temp1.Value = status;
                }

                objOraclecommand.Parameters.Add(temp1);

                OracleParameter temp2 = new OracleParameter("hold", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = hold;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp6 = new OracleParameter("descid", OracleType.VarChar);
                temp6.Direction = ParameterDirection.Input;
                temp6.Value = descid;
                objOraclecommand.Parameters.Add(temp6);

                OracleParameter temp3 = new OracleParameter("ascdesc", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = ascdesc;
                objOraclecommand.Parameters.Add(temp3);

                OracleParameter temp4 = new OracleParameter("page", OracleType.VarChar);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = page;
                objOraclecommand.Parameters.Add(temp4);

                OracleParameter temp5 = new OracleParameter("position", OracleType.VarChar);
                temp5.Direction = ParameterDirection.Input;
                temp5.Value = position;
                objOraclecommand.Parameters.Add(temp5);

                OracleParameter tmp33 = new OracleParameter("agtype", OracleType.VarChar);
                tmp33.Direction = ParameterDirection.Input;
                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    tmp33.Value = System.DBNull.Value;
                }
                else
                {
                    tmp33.Value = agentyp;
                }
                objOraclecommand.Parameters.Add(tmp33);

                OracleParameter new1 = new OracleParameter("pextra1", OracleType.VarChar);
                new1.Direction = ParameterDirection.Input;
                if (extra1 == "0" || extra1 == "")
                {
                    new1.Value = System.DBNull.Value;
                }
                else
                {
                    new1.Value = extra1;
                }
                objOraclecommand.Parameters.Add(new1);

                OracleParameter new2 = new OracleParameter("pextra2", OracleType.VarChar);
                new2.Direction = ParameterDirection.Input;
                if (extra2 == "0" || extra2 == "")
                {
                    new2.Value = System.DBNull.Value;
                }
                else
                {
                    new2.Value = extra2;
                }
                objOraclecommand.Parameters.Add(new2);

                OracleParameter new3 = new OracleParameter("pextra3", OracleType.VarChar);
                new3.Direction = ParameterDirection.Input;
                if (extra3 == "0" || extra3 == "")
                {
                    new3.Value = System.DBNull.Value;
                }
                else
                {
                    new3.Value = extra3;
                }
                objOraclecommand.Parameters.Add(new3);

                OracleParameter new4 = new OracleParameter("pextra4", OracleType.VarChar);
                new4.Direction = ParameterDirection.Input;
                if (extra4 == "0" || extra4 == "")
                {
                    new4.Value = System.DBNull.Value;
                }
                else
                {
                    new4.Value = extra4;
                }
                objOraclecommand.Parameters.Add(new4);

                OracleParameter new5 = new OracleParameter("pextra5", OracleType.VarChar);
                new5.Direction = ParameterDirection.Input;
                if (extra5 == "0" || extra5 == "")
                {
                    new5.Value = System.DBNull.Value;
                }
                else
                {
                    new5.Value = extra5;
                }
                objOraclecommand.Parameters.Add(new5);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;




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

        //=================================== For Representative ledger==================================

        public DataSet representative(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill, string cl, string ag, string retain, string repchk, string useid, string chk_acc,string branch,string district)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Representative.Representative_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                //if (frmdt == "0" || frmdt == "")
                //{
                //    prm4.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                //}
                if (frmdt == "0" || frmdt == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                //if (todate == "0" || todate == "")
                //{
                //    prm5.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                //}
                if (todate == "0" || todate == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter py = new OracleParameter("rep", OracleType.VarChar);
                py.Direction = ParameterDirection.Input;
                py.Value = repchk;
                objOraclecommand.Parameters.Add(py);

                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm18 = new OracleParameter("dateformat", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;

                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm116 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm116.Value = System.DBNull.Value;
                }
                else
                {
                    prm116.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm116);


                OracleParameter prm161 = new OracleParameter("value", OracleType.VarChar);
                prm161.Direction = ParameterDirection.Input;
                prm161.Value = value;
                objOraclecommand.Parameters.Add(prm161);

                OracleParameter prm1117 = new OracleParameter("team", OracleType.VarChar);
                prm1117.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm1117.Value = System.DBNull.Value;
                }
                else
                {
                    prm1117.Value = team;
                }
                objOraclecommand.Parameters.Add(prm1117);



                OracleParameter prm11115 = new OracleParameter("execut", OracleType.VarChar);
                prm11115.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm11115.Value = System.DBNull.Value;
                }
                else
                {
                    prm11115.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm11115);


                OracleParameter prm111151 = new OracleParameter("bill", OracleType.VarChar);
                prm111151.Direction = ParameterDirection.Input;
                if (bill == "0" || bill == "")
                {
                    prm111151.Value = System.DBNull.Value;
                }
                else
                {
                    prm111151.Value = bill;
                }

                objOraclecommand.Parameters.Add(prm111151);

                OracleParameter prm11111 = new OracleParameter("cl", OracleType.VarChar);
                prm11111.Direction = ParameterDirection.Input;
                if (cl == "0" || cl == "")
                {
                    prm11111.Value = System.DBNull.Value;
                }
                else
                {
                    prm11111.Value = cl;
                }

                objOraclecommand.Parameters.Add(prm11111);

                OracleParameter prm1111511 = new OracleParameter("ag", OracleType.VarChar);
                prm1111511.Direction = ParameterDirection.Input;
                if (ag == "0" || ag == "")
                {
                    prm1111511.Value = System.DBNull.Value;
                }
                else
                {
                    prm1111511.Value = ag;
                }

                objOraclecommand.Parameters.Add(prm1111511);

                OracleParameter pt1 = new OracleParameter("retainer", OracleType.VarChar);
                pt1.Direction = ParameterDirection.Input;
                if (retain == "0" || retain == "")
                {
                    pt1.Value = System.DBNull.Value;
                }
                else
                {
                    pt1.Value = retain;
                }

                objOraclecommand.Parameters.Add(pt1);

                OracleParameter bhr1 = new OracleParameter("pbrancode", OracleType.VarChar);
                bhr1.Direction = ParameterDirection.Input;
                bhr1.Value = branch;
                objOraclecommand.Parameters.Add(bhr1);


                OracleParameter bhr2 = new OracleParameter("pdistcode", OracleType.VarChar);
                bhr2.Direction = ParameterDirection.Input;
                bhr2.Value = district;
                objOraclecommand.Parameters.Add(bhr2);


                OracleParameter ext1 = new OracleParameter("pextra1", OracleType.VarChar);
                ext1.Direction = ParameterDirection.Input;
                ext1.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext1);


                OracleParameter ext2 = new OracleParameter("pextra2", OracleType.VarChar);
                ext2.Direction = ParameterDirection.Input;
                ext2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext2);


                OracleParameter ext3 = new OracleParameter("pextra3", OracleType.VarChar);
                ext3.Direction = ParameterDirection.Input;
                ext3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext3);


                OracleParameter ext4 = new OracleParameter("pextra4", OracleType.VarChar);
                ext4.Direction = ParameterDirection.Input;
                ext4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext4);


                OracleParameter ext5 = new OracleParameter("pextra5", OracleType.VarChar);
                ext5.Direction = ParameterDirection.Input;
                ext5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

               // objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
               // objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        //=================

        //team
        public DataSet team(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_team", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        //=============
        public DataSet bindexecutive(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("get_exec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                objOraclecommand.Parameters.Add("get_executive", OracleType.Cursor);
                objOraclecommand.Parameters["get_executive"].Direction = ParameterDirection.Output;

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

        public DataSet bindrevenuecenter(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindrevenuecenter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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

        //Get_Execexec
        public DataSet bindexecutive(string compcode, string team)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Get_Execexec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("team", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = team;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("get_executive", OracleType.Cursor);
                objOraclecommand.Parameters["get_executive"].Direction = ParameterDirection.Output;

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

        public DataSet displayonscreenreport1(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("billregister.billregister_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (frmdt == "0" || frmdt == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "0" || todate == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (publication == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm18 = new OracleParameter("dateformat", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm116 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm116.Value = System.DBNull.Value;
                }
                else
                {
                    prm116.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm116);


                OracleParameter prm161 = new OracleParameter("value", OracleType.VarChar);
                prm161.Direction = ParameterDirection.Input;
                prm161.Value = value;
                objOraclecommand.Parameters.Add(prm161);

                OracleParameter prm1117 = new OracleParameter("team", OracleType.VarChar);
                prm1117.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm1117.Value = System.DBNull.Value;
                }
                else
                {
                    prm1117.Value = team;
                }
                objOraclecommand.Parameters.Add(prm1117);



                OracleParameter prm11115 = new OracleParameter("execut", OracleType.VarChar);
                prm11115.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm11115.Value = System.DBNull.Value;
                }
                else
                {
                    prm11115.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm11115);

                OracleParameter prm111151 = new OracleParameter("bill", OracleType.VarChar);
                prm111151.Direction = ParameterDirection.Input;
                if (bill == "0" || bill == "")
                {
                    prm111151.Value = System.DBNull.Value;
                }
                else
                {
                    prm111151.Value = bill;
                }

                objOraclecommand.Parameters.Add(prm111151);

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


        public DataSet representativesummary(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill, string cl, string ag, string retain, string repchk, string useid, string chk_acc, string branch, string district)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Representative_summmery", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                //if (frmdt == "0" || frmdt == "")
                //{
                //    prm4.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                //}
                if (frmdt == "0" || frmdt == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                //if (todate == "0" || todate == "")
                //{
                //    prm5.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                //}
                if (todate == "0" || todate == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter py = new OracleParameter("rep", OracleType.VarChar);
                py.Direction = ParameterDirection.Input;
                py.Value = repchk;
                objOraclecommand.Parameters.Add(py);

                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm18 = new OracleParameter("dateformat", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;

                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm116 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm116.Value = System.DBNull.Value;
                }
                else
                {
                    prm116.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm116);


                OracleParameter prm161 = new OracleParameter("value", OracleType.VarChar);
                prm161.Direction = ParameterDirection.Input;
                prm161.Value = value;
                objOraclecommand.Parameters.Add(prm161);

                OracleParameter prm1117 = new OracleParameter("team", OracleType.VarChar);
                prm1117.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm1117.Value = System.DBNull.Value;
                }
                else
                {
                    prm1117.Value = team;
                }
                objOraclecommand.Parameters.Add(prm1117);



                OracleParameter prm11115 = new OracleParameter("execut", OracleType.VarChar);
                prm11115.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm11115.Value = System.DBNull.Value;
                }
                else
                {
                    prm11115.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm11115);


                OracleParameter prm111151 = new OracleParameter("bill", OracleType.VarChar);
                prm111151.Direction = ParameterDirection.Input;
                if (bill == "0" || bill == "")
                {
                    prm111151.Value = System.DBNull.Value;
                }
                else
                {
                    prm111151.Value = bill;
                }

                objOraclecommand.Parameters.Add(prm111151);

                OracleParameter prm11111 = new OracleParameter("cl", OracleType.VarChar);
                prm11111.Direction = ParameterDirection.Input;
                if (cl == "0" || cl == "")
                {
                    prm11111.Value = System.DBNull.Value;
                }
                else
                {
                    prm11111.Value = cl;
                }

                objOraclecommand.Parameters.Add(prm11111);

                OracleParameter prm1111511 = new OracleParameter("ag", OracleType.VarChar);
                prm1111511.Direction = ParameterDirection.Input;
                if (ag == "0" || ag == "")
                {
                    prm1111511.Value = System.DBNull.Value;
                }
                else
                {
                    prm1111511.Value = ag;
                }

                objOraclecommand.Parameters.Add(prm1111511);

                OracleParameter pt1 = new OracleParameter("retainer", OracleType.VarChar);
                pt1.Direction = ParameterDirection.Input;
                if (retain == "0" || retain == "")
                {
                    pt1.Value = System.DBNull.Value;
                }
                else
                {
                    pt1.Value = retain;
                }

                objOraclecommand.Parameters.Add(pt1);

                OracleParameter bhr1 = new OracleParameter("pbrancode", OracleType.VarChar);
                bhr1.Direction = ParameterDirection.Input;
                bhr1.Value = branch;
                objOraclecommand.Parameters.Add(bhr1);


                OracleParameter bhr2 = new OracleParameter("pdistcode", OracleType.VarChar);
                bhr2.Direction = ParameterDirection.Input;
                bhr2.Value = district;
                objOraclecommand.Parameters.Add(bhr2);


                OracleParameter ext1 = new OracleParameter("pextra1", OracleType.VarChar);
                ext1.Direction = ParameterDirection.Input;
                ext1.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext1);


                OracleParameter ext2 = new OracleParameter("pextra2", OracleType.VarChar);
                ext2.Direction = ParameterDirection.Input;
                ext2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext2);


                OracleParameter ext3 = new OracleParameter("pextra3", OracleType.VarChar);
                ext3.Direction = ParameterDirection.Input;
                ext3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext3);


                OracleParameter ext4 = new OracleParameter("pextra4", OracleType.VarChar);
                ext4.Direction = ParameterDirection.Input;
                ext4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext4);


                OracleParameter ext5 = new OracleParameter("pextra5", OracleType.VarChar);
                ext5.Direction = ParameterDirection.Input;
                ext5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(ext5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                // objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                // objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
