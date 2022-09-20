using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;


public partial class insertionview : System.Web.UI.Page
{
    string page = "";
    int pgn = 1;
    string destination = "";
    string report_name1 = "";
    string fromdt = "";
    int maxlimit = 60;
    string publ = "";
    string edition = "";
    string date = "";
    string extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "";
    string day = "";
    string month = "";
    string year = "";
    double book_area = 0;
    double amount = 0;
    string useid = "";
    string rundate2 = "";
    string rundate = "";

    string fromdate = "", pubname = "", pubnamecode = "", pubcent = "", branch_c = "";
    string dateto = "";
    string branchcode = "", pubcentcode = "";
    string reportname = "issue edtion report";
    string editioncode = "";
    string distcode = "";
    string distname = "";
    int rowcounter = 0;
    string comp_name = "";
    string fromdate1 = "";
    string todate1 = "";
    string chk_excel = "";
    System.Web.HttpBrowserCapabilities browser;
    string TBL = "";
    double ver;
    DataSet ds = new DataSet();
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    static string MDYToDMY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //string rundate = DateTime.Now.ToString();
        //rundate2 = rundate;
        fromdate = Request.QueryString["from_date1"].ToString();
        dateto = Request.QueryString["todate1"].ToString();
        pubname = Request.QueryString["pub_name1"].ToString();
        pubnamecode = Request.QueryString["pub_code1"].ToString();
        edition = Request.QueryString["edition_name1"].ToString();
        editioncode = Request.QueryString["edition_code1"].ToString();

        pubcent = Request.QueryString["publication_center1"].ToString();
        branch_c = Request.QueryString["branch_name1"].ToString();
        useid = Request.QueryString["userid1"].ToString();
        destination = Request.QueryString["dest1"].ToString();

        pubcentcode = Request.QueryString["pubcent_code1"].ToString();
        branchcode = Request.QueryString["branch_code1"].ToString();
        distname = Request.QueryString["distname"].ToString();
        distcode = Request.QueryString["distcode"].ToString();
        hiddenedition.Value = edition;
        //hdncompcode.Value = Session["comp_code"].ToString();
        string compcode = Request.QueryString["comp_code"].ToString();
        //comp_name = Session["comp_name"].ToString();

        if (branchcode == "0" || branchcode == "")
        {
            lbbranch.Text = "ALL".ToString();
        }
        else
        {
            lbbranch.Text = branch_c.ToString();
        }



        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editioncode.ToString();

        }


        if (pubcentcode == "0" || pubcentcode == "")
        {
            pcenter.Text = "ALL".ToString();
        }
        else
        {
            pcenter.Text = pubcent.ToString();
        }


        if (pubnamecode == "0" || pubnamecode == "")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = pubname.ToString();
        }

        if (distcode == "0" || distcode == "")
        {
            lbdist.Text = "ALL".ToString();
        }
        else
        {
            lbdist.Text = distname.ToString();
        }
        hiddendateformat.Value = Session["dateformat"].ToString();

        if (fromdate != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdate.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = year + "/" + month + "/" + day;
                }
            }
        }
        lblfrom.Text = fromdate;
        //dateto1 = "";
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto = dd + "/" + mm + "/" + yy;

            }


            else
            {

                //DateTime dt = Convert.ToDateTime(dateto.ToString());

                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    dateto = day + "/" + month + "/" + year;

                //}
                //else if (hiddendateformat.Value == "mm/dd/yyyy")
                //{

                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    dateto = month + "/" + day + "/" + year;

                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{

                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    dateto = year + "/" + month + "/" + day;
                //}
            }
        }
        lblto.Text = dateto;

        rundate = Convert.ToString(System.DateTime.Now);
        rundate = changeformat(rundate);
        string[] tim = rundate.Split(' ');
        lbldate.Text = tim[0];
        
        //rundate = DateTime.Today.ToString().Split(' ')[0];


        string date11117 = rundate;
        string dd7 = date11117.Split('/')[1];
        string mm7 = date11117.Split('/')[0];
        string yyyy7 = date11117.Split('/')[2];
        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {


            rundate =RETURN_LENGTH( dd7) + "/" + RETURN_LENGTH(mm7 )+ "/" + yyyy7;

        }

        else
            if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
            {


                rundate = yyyy7 + "/" + RETURN_LENGTH(mm7) + "/" + RETURN_LENGTH(dd7);

            }

        lbldate.Text = changeformat(rundate);
        
        //if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        //{

        //    DateTime dt = System.DateTime.Now;


        //    day = dt.Day.ToString();
        //    month = dt.Month.ToString();
        //    year = dt.Year.ToString();
        //    date = day + "/" + month + "/" + year;

        //}
        //else
        //    if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
        //    {

        //        DateTime dt = System.DateTime.Now;


        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        date = month + "/" + day + "/" + year;

        //    }
        //    else
        //        if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
        //        {

        //            DateTime dt = System.DateTime.Now;


        //            day = dt.Day.ToString();
        //            month = dt.Month.ToString();
        //            year = dt.Year.ToString();
        //            date = year + "/" + month + "/" + day;

        //        }
        //lbldate.Text = rundate2.ToString().Substring(0, 9);


        ds.ReadXml(Server.MapPath("XML/insertion.xml"));
        page = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0" || destination == "")
            {
                onscreen();
            }
            else if (destination == "4")
            {
                excel();

            }
            else if (destination == "3")
            {
                pdf();//edition, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), useid, Session["compcode"].ToString(), chk_acc, agencytype, extra1, extra2);

            }
        }
    }
    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }

    public string changeformat(string userdate)
    {
        string[] arr = userdate.Split('/');
        string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
        return change;
    }

    public string chk_null(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal == "0.00" || str_decimal == "0.0" || str_decimal == "0")
        {
            final_decimal = "0.00";
        }
        else if (str_decimal.IndexOf(".") > -1)
        {

            double dd = System.Math.Round(Convert.ToDouble(str_decimal), 2);
            string[] oo = dd.ToString().Split('.');
            if (oo.Length == 1)
                final_decimal = dd.ToString() + ".00";
            else if (oo[1].Length == 1)
                final_decimal = dd.ToString() + "0";
            else
                final_decimal = dd.ToString();
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = "0.00";
        }
        return final_decimal;
    }

    public void onscreen()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.insertion2 adagencycli = new NewAdbooking.Report.classesoracle.insertion2();
            ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                fromdate = DMYToMDY(fromdate);
                dateto = DMYToMDY(dateto);

            }

            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                dateto = YMDToMDY(dateto);
            }


            NewAdbooking.Report.Classes.insertclass adagencycli = new NewAdbooking.Report.Classes.insertclass();
            ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        }
        else
        {
            string procedureName = "rpt_edtionwise_summary_rpt_edtionwise_billing";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }



        Session["issue_edition"] = ds;


        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(insertionview), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);


            return;

        }

        string TBL = "";
        string find = "";
        string find_rcpdt = "";
        string find_agency = "";
        double amttotal = 0;
        double outotal = 0;
        int i1 = 1;
        Double total = 0;
        int cont = ds.Tables[0].Rows.Count;
        int m11 = 0;
        string position = "";
        int ct = 0;
        int fr = maxlimit;
        double linamttotal = 0;
        double linamtgtotal = 0;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
            pagecount = pagecount + 1;


        comp_name1.Text = ds.Tables[0].Rows[0]["CNAME"].ToString();
        DataSet ds_xml = new DataSet();
        ds_xml.ReadXml(Server.MapPath("XML/insertion.xml"));
        report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[17].ToString();

        if (ds.Tables[0].Rows.Count > 0)
        {
            TBL += "<p><table width='100%' cellspacing='0' cellpadding = '0' border='0' style='verticle-align:top'align='center'>";
            string Header = creatheader(ds, 0);
            TBL += Header;
            //int sno = 0;

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                total += Convert.ToDouble(ds.Tables[0].Rows[p]["amount"].ToString());
                string adcode = ds.Tables[0].Rows[p]["publ_name"].ToString();
                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    TBL += "</table></p>";
                    TBL += "</br>";
                    TBL += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'align='center'>";
                    //string newheader = creatheader(ds, 0);
                    //TBL += newheader;

                    TBL += "</table></p>";
                    TBL += "<p><table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>";
                    //find_agency += ds.Tables[0].Rows[p]["AGCD"].ToString();
                }
                if (find.IndexOf(ds.Tables[0].Rows[p]["publ_name"].ToString()) < 0)
                {
                    if (p != 0)
                    {
                        TBL += ("<tr>");
                        TBL += ("<td colspan='5' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
                        TBL += ("<td  class='middle31new' align='right'>");
                        TBL += (linamttotal.ToString("F2"));
                        TBL += ("</td>");
                        TBL += ("<td  class='middle31new' align='right'>");
                        TBL += (amttotal.ToString("F2"));
                        TBL += ("</td>");
                        TBL += ("</tr>");
                        TBL += "</table></p>";
                        TBL += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'align='center'>";
                        //string newheader = creatheader(ds,1);
                        //TBL += newheader;


                        amttotal = 0;
                        rowcounter = 0;
                        linamttotal = 0;
                    }

                    //TBL += "<tr><td colspan='6'><table width='100%' cellspacing='0px' cellpadding='0px' border='0'>";
                    //TBL += "<tr class='upperhead1'><td colspan='1'  align='left'></td></tr></table>";
                    find += ds.Tables[0].Rows[p]["publ_name"].ToString() + "~";
                }


                TBL += ("<tr>");
                TBL += "<td class='rep_data' width='20%'>";
                TBL += ds.Tables[0].Rows[p]["publ_name"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='15%'style=padding-left:'1px'>";
                TBL += ds.Tables[0].Rows[p]["edtn_name"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='10%'>";
                TBL += ds.Tables[0].Rows[p]["no_of_insertion"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='10%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["book_area"].ToString()) + "</td>";
                TBL += "<td class='rep_data' width='15%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["lineage_book_area"].ToString()) + "</td>";
                TBL += "<td class='rep_data' width='15%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["lineage_amount"].ToString()) + "</td>";
                if (ds.Tables[0].Rows[p]["lineage_amount"].ToString() != "" && ds.Tables[0].Rows[p]["lineage_amount"].ToString() != null)
                {
                    linamttotal=linamttotal+Convert.ToDouble(ds.Tables[0].Rows[p]["lineage_amount"].ToString());
                    linamtgtotal = linamtgtotal + Convert.ToDouble(ds.Tables[0].Rows[p]["lineage_amount"].ToString());
                }
                TBL += "<td class='rep_data' width='15%' align='right'>";
                if (ds.Tables[0].Rows[p]["amount"].ToString() != "")
                {
                    outotal = Convert.ToDouble(ds.Tables[0].Rows[p]["amount"]);
                    TBL += (outotal.ToString("F2"));
                }

                amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[p]["amount"]);
                TBL += ("</tr>");
                rowcounter++;
            }
            TBL += ("<tr>");
            TBL += ("<td colspan='5' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (linamttotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (amttotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("</tr>");
            TBL += ("<tr>");
            TBL += ("<td colspan='5' class='middle31new' align='right' >" + " GRAND TOTAL" + "&nbsp;&nbsp;" + "</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (linamtgtotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (total.ToString("F2"));
            TBL += ("</td>");
            TBL += ("</tr>");
            TBL += "</table>";
            tblgrid.InnerHtml = TBL;
        }


    }



    //    tbl1 = tbl1 + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";

    //    // tbl1 = tbl1 + "<tr><td width='100%'colspan='8' align='right' style='font=family:Arial; font-size:14px;' style='padding-left:800px;' ><b>" + page + " &nbsp;" + pgn + "</b></td></tr>";
    //    //pgn = pgn + 1;


    //    tbl1 = tbl1 + "<tr valign='top'>";
    //    tbl1 = tbl1 + "<td class='middle31new' width='20%'><b>PUBLICATION<b></td>";
    //    tbl1 = tbl1 + "<td class='middle31new' width='15%'><b>EDITION<b></td>";
    //    tbl1 = tbl1 + "<td class ='middle31new'width='10%'><b>NO. OF INSERTION<b></td>";
    //    tbl1 = tbl1 + "<td class='middle31new' width='10%' align='right' ><b>DISPLAY SIZE</b></td>";
    //    tbl1 = tbl1 + "<td class='middle31new' width='15%' align='right' ><b>LINAGE SIZE</b></td>";
    //    tbl1 = tbl1 + "<td class='middle31new' width='15%' align='right' ><b>LINAGE AMOUNT</b></td>";
    //    tbl1 = tbl1 + "<td class='middle31new' width='15%' align='right' ><b>DISPLAY AMOUNT<b></td>";
    //    tbl1 = tbl1 + "</tr>";

    //}
    //    for (int d = 0; d < ds.Tables[0].Rows.Count; d++)
    //    {


    //        //total += Convert.ToDouble(ds.Tables[0].Rows[d]["amount"].ToString());

    //        //int a = d;
    //        //a = a + 1;

    //        if (d > 0)
    //        {

    //            if (ds.Tables[0].Rows[d]["publ_name"].ToString() == ds.Tables[0].Rows[d - 1]["publ_name"].ToString())
    //            {


    //                tbl1 = tbl1 + ("<tr>");
    //                tbl1 = tbl1 + "<td class='rep_data' width='20%'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["publ_name"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%'style=padding-left:'1px'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["edtn_name"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='10%'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["no_of_insertion"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='10%'align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["book_area"].ToString()) + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%'align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["lineage_book_area"].ToString()) + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%'align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["lineage_amount"].ToString()) + "</td>";

    //                //book_area = book_area + Convert.ToDouble(ds.Tables[1].Rows[p]["book_area"].ToString());
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%' align='right'>";
    //                if (ds.Tables[0].Rows[d]["amount"].ToString() != "")
    //                {

    //                    outotal += Convert.ToDouble(ds.Tables[0].Rows[d]["amount"].ToString());
    //                    tbl1 = tbl1 + (outotal.ToString("F2"));
    //                }

    //                amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);

    //                tbl1 = tbl1 + ("</tr>");

    //                //rowcounter++;

    //            }

    //            else
    //            {

    //                tbl1 = tbl1 + ("<tr>");
    //                tbl1 = tbl1 + ("<td colspan='6' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
    //                tbl1 = tbl1 + ("<td  colspan='1'class='middle31new' align='right'>");
    //                tbl1 = tbl1 + (amttotal.ToString("F2"));
    //                tbl1 = tbl1 + ("</td>");
    //                tbl1 = tbl1 + ("</tr>");

    //                tbl1 = tbl1 + ("<tr>");
    //                tbl1 = tbl1 + "<td class='rep_data' width='20%'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["publ_name"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%'style=padding-left:'1px'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["edtn_name"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='10%'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["no_of_insertion"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='10%'align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["book_area"].ToString()) + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%'align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["lineage_book_area"].ToString()) + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%'align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["lineage_amount"].ToString()) + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='15%' align='right'>";
    //                if (ds.Tables[0].Rows[d]["amount"].ToString() != "")
    //                {
    //                    outotal = Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);
    //                    tbl1 = tbl1 + (outotal.ToString("F2"));
    //                }

    //                amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);

    //                tbl1 = tbl1 + ("</tr>");
    //                amttotal = 0;
    //                //rowcounter++;
    //            }
    //        }
    //            if (d == (ds.Tables[0].Rows.Count - 1))
    //            {
    //                tbl1 = tbl1 + ("<tr>");
    //                tbl1 = tbl1 + ("<td colspan='6' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
    //                tbl1 = tbl1 + ("<td  colspan='1'class='middle31new' align='right'>");
    //                tbl1 = tbl1 + (amttotal.ToString("F2"));
    //                tbl1 = tbl1 + ("</td>");
    //                tbl1 = tbl1 + ("</tr>");

    //            }
    //    }

    //            tbl1 = tbl1 + ("</table>");
    //            tblgrid.InnerHtml += tbl1;

    //}


    public void excel()
    {
        DataSet ds = new DataSet();
        string tbl1 = "";
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.insertion2 adagencycli = new NewAdbooking.Report.classesoracle.insertion2();
        //    ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")

        //{
        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {

        //        fromdate = DMYToMDY(fromdate);
        //        dateto = DMYToMDY(dateto);

        //    }

        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {
        //        fromdate = YMDToMDY(fromdate);
        //        dateto = YMDToMDY(dateto);

        //    }
        //    NewAdbooking.Report.Classes.insertclass adagencycli = new NewAdbooking.Report.Classes.insertclass();
        //    ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        //}


        string TBL = "";
        string find = "";
        string find_rcpdt = "";
        string find_agency = "";
        double amttotal = 0;
        double outotal = 0;
        double linamttotal = 0;
        double linamtgtotal = 0;
        int i1 = 1;
        Double total = 0;
        int m11 = 0;
        string position = "";
        int ct = 0;
        int fr = maxlimit;

        //int pagec = rcount % maxlimit;
        //int pagecount = rcount / maxlimit;
        //if (pagec > 0)
        // pagecount = pagecount + 1;

        String date1 = "";
        date1 = changeformat(rundate);
        ds = (DataSet)Session["issue_edition"];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(insertionview), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);


            return;

        }

        string pub = "";
        if (pubnamecode == "0" || pubnamecode == "")
        {
            pub = "ALL".ToString();
        }
        else
        {
            pub = pubname.ToString();
        }




        string pubcent1 = "";
        if (pubcentcode == "0" || pubcentcode == "")
        {
            pubcent1 = "ALL".ToString();
        }
        else
        {
            pubcent1 = pubcent.ToString();
        }



        string bran = "";
        if (branchcode == "0" || branchcode == "")
        {
            bran = "ALL".ToString();
        }
        else
        {
            bran = branch_c.ToString();
        }



        string edi = "";
        if (edition == "0" || edition == "")
        {
            edi = "ALL".ToString();
        }
        else
        {
            edi = editioncode.ToString();

        }

        string dist = "";
        if (distcode == "0" || distcode == "")
        {
            dist = "ALL".ToString();
        }
        else
        {
            dist = distname.ToString();
        }

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");



        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {


            TBL += "<table cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td align=right><b>Publication:</b>" + pub + "</td>";
            TBL += "<td>";
            TBL += "</td>";
            //TBL += "<td>";
            //TBL += "</td>";

            TBL += "<td align=right><b>Printing Center:</b>" + pubcent1 + "</td>";


            TBL += "<td>";
            TBL += "</td>";
            //TBL += "<td>";
            //TBL += "</td>";
            TBL += "<td align=right><b>Branch:</b>" + bran + "</td>";

            TBL += "<td>";
            TBL += "</td>";
            //TBL += "<td>";
            //TBL += "</td>";
            TBL += "<td align=right><b>District:</b>" + dist + "</td>";
            TBL += "</tr>";
            TBL += "<tr>";
            TBL += "<td align=right><b>Edition:</b>" + edi + "</td>";

            TBL += "<td>";
            TBL += "</td>";
            //TBL += "<td>";
            // TBL += "</td>";

            TBL += "<td align=right><b>Date From:</b>" + fromdate + "</td>";

            TBL += "<td>";
            TBL += "</td>";
            //TBL += "<td>";
            //TBL += "</td>";
            TBL += "<td align=right><b>Date To:</b>" + dateto + "</td>";

            TBL += "<td>";
            TBL += "</td>";
            //TBL += "<td>";
            //TBL += "</td>";
            TBL += "<td align=right><b>Run Date:</b>" + date1 +"</td>";
            TBL += "</table>";
            TBL += "<p><table width='100%' cellspacing='0' cellpadding = '0' border='1' style='verticle-align:top'align='center'>";
            string Header = creatheader(ds, 0);
            TBL += Header;


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                total += Convert.ToDouble(ds.Tables[0].Rows[p]["amount"].ToString());
                string adcode = ds.Tables[0].Rows[p]["publ_name"].ToString();
                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    TBL += "</table></p>";
                    TBL += "</br>";
                    TBL += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='1' border='0'align='center'>";

                    TBL += "</table></p>";
                    TBL += "<p><table width='100%' cellspacing='0' cellpadding='0' border='1' align='center'>";
                    //find_agency += ds.Tables[0].Rows[p]["AGCD"].ToString();
                }
                if (find.IndexOf(ds.Tables[0].Rows[p]["publ_name"].ToString()) < 0)
                {
                    if (p != 0)
                    {
                        TBL += ("<tr>");
                        TBL += ("<td colspan='5' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
                        TBL += ("<td  class='middle31new' align='right'>");
                        TBL += (linamttotal.ToString("F2"));
                        TBL += ("<td  colspan='1'class='middle31new' align='right'>");
                        TBL += (amttotal.ToString("F2"));
                        TBL += ("</td>");
                        TBL += ("</tr>");
                        TBL += "</table></p>";
                        //TBL += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='1'align='center'>";
                        //string newheader = creatheader(ds,1);
                        //TBL += newheader;


                        amttotal = 0;
                        rowcounter = 0;
                        linamttotal = 0;
                    }
                    
                    TBL += "<tr><td colspan='6'><table width='100%' cellspacing='0px' cellpadding='0px' border='1'>";
                    TBL += "<tr class='upperhead1'><td colspan='1'  align='left'></td></tr>";
                    find += ds.Tables[0].Rows[p]["publ_name"].ToString() + "~";
                }


                TBL += ("<tr>");
                TBL += "<td class='rep_data'  colspan='1'  width='20%'>";
                TBL += ds.Tables[0].Rows[p]["publ_name"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='15%'style=padding-left:'1px'>";
                TBL += ds.Tables[0].Rows[p]["edtn_name"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='10%'>";
                TBL += ds.Tables[0].Rows[p]["no_of_insertion"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='10%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["book_area"].ToString()) + "</td>";
                TBL += "<td class='rep_data' width='15%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["lineage_book_area"].ToString()) + "</td>";
                TBL += "<td class='rep_data' width='15%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["lineage_amount"].ToString()) + "</td>";
                if (ds.Tables[0].Rows[p]["lineage_amount"].ToString() != "" && ds.Tables[0].Rows[p]["lineage_amount"].ToString() != null)
                {
                    linamttotal = linamttotal + Convert.ToDouble(ds.Tables[0].Rows[p]["lineage_amount"].ToString());
                    linamtgtotal = linamtgtotal + Convert.ToDouble(ds.Tables[0].Rows[p]["lineage_amount"].ToString());
                }
                TBL += "<td class='rep_data' width='15%' align='right'>";
                if (ds.Tables[0].Rows[p]["amount"].ToString() != "")
                {
                    outotal = Convert.ToDouble(ds.Tables[0].Rows[p]["amount"]);
                    TBL += (outotal.ToString("F2"));
                }

                amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[p]["amount"]);
                TBL += ("</tr>");
                rowcounter++;
            }
            TBL += ("<tr>");
            TBL += ("<td colspan='5' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (linamttotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (amttotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("</tr>");
            TBL += ("<tr>");
            TBL += ("<td colspan='5' class='middle31new' align='right' >" + " GRAND TOTAL" + "&nbsp;&nbsp;" + "</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (linamtgtotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (total.ToString("F2"));
            TBL += ("</td>");
            TBL += ("</tr>");
            TBL += "</table>";
            tblgrid.InnerHtml = TBL;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.Write("<p align='center'><b> " + ds.Tables[0].Rows[0]["CNAME"].ToString() + "</b></p>");
            DataSet ds_xml = new DataSet();
            ds_xml.ReadXml(Server.MapPath("XML/insertion.xml"));
            // report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[12].ToString();

            hw.Write("<p align='center'><b> " + report_name1 + ds_xml.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></p>");




            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }





    protected void btnprint_Click(object sender, EventArgs e)
    {
        btnprint.Visible = false;
        DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.insertion2 adagencycli = new NewAdbooking.Report.classesoracle.insertion2();
        //    ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {

        //        fromdate = DMYToMDY(fromdate);
        //        dateto = DMYToMDY(dateto);

        //    }

        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {
        //        fromdate = YMDToMDY(fromdate);
        //        dateto = YMDToMDY(dateto);
        //    }

        //    NewAdbooking.Report.Classes.insertclass adagencycli = new NewAdbooking.Report.Classes.insertclass();
        //    ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        //}

        ds = (DataSet)Session["issue_edition"];

        int pgno=1;
        int maxpag=1;
        string TBL = "";
        string find = "";
        string find_rcpdt = "";
        string find_agency = "";
        double amttotal = 0;
        double outotal = 0;
        int i1 = 1;
        Double total = 0;
        int cont = ds.Tables[0].Rows.Count;
        //string tbl1 = "";
        int m11 = 0;
        string position = "";
        int ct = 0;
        int fr = maxlimit;
        double linamttotal = 0;
        double linamtgtotal = 0;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
            pagecount = pagecount + 1;

        if (ds.Tables[0].Rows.Count > 0)
        {
            maxpag = (ds.Tables[0].Rows.Count) / maxlimit;
            if (maxpag < 1)
                maxpag = 1;
            TBL += "<p><table width='100%' cellspacing='0' cellpadding = '0' border='0' style='verticle-align:top'align='center'>";
            TBL += ("<tr>");
            string Header = creatheader(ds, 0);
            TBL += ("<tr>" + "<td colspan='7' align='right' >" + "Page:" + pgno + " of " + maxpag + "</td>" + "</tr>");
            TBL += Header;
            //int sno = 0;
            


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
               
                total += Convert.ToDouble(ds.Tables[0].Rows[p]["amount"].ToString());
                string adcode = ds.Tables[0].Rows[p]["publ_name"].ToString();
                if (rowcounter == maxlimit)
                {
                    pgno++;
                    //Lblpgno.Text = "Page:" + pgno+" of "+maxpag;
                    rowcounter = 0;
                   // TBL += "</table></p>";
                   // TBL += "</br>";
                   // TBL += "<p style='PAGE-BREAK-BEFORE:always'><table width='100%' cellspacing='0' cellpadding='0' border='0'align='center'>";
                    //string newheader = creatheader(ds, 0);
                    //TBL += newheader;

                    TBL += "</table></p>";
                    TBL += "<p style='PAGE-BREAK-BEFORE:always'><table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>";
                    TBL += ("<tr>"+"<td colspan='7' align='right' >" + "Page:"+pgno+" of "+maxpag+ "</td>"+"</tr>");
                    TBL += ("<tr>" + Header);
                    //find_agency += ds.Tables[0].Rows[p]["AGCD"].ToString();
                }
                if (find.IndexOf(ds.Tables[0].Rows[p]["publ_name"].ToString()) < 0)
                {
                    if (p != 0)
                    {
                        
                        TBL += ("<tr>");
                        TBL += ("<td colspan='5' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
                        TBL += ("<td  class='middle31new' align='right'>");
                        TBL += (linamttotal.ToString("F2"));
                        TBL += ("</td>");
                        TBL += ("<td  colspan='1'class='middle31new' align='right'>");
                        TBL += (amttotal.ToString("F2"));
                        TBL += ("</td>");
                        TBL += ("</tr>");
                        //TBL += "</table></p>";
                        //TBL += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'align='center'>";
                        //string newheader = creatheader(ds,1);
                        //TBL += newheader;


                        amttotal = 0;
                       //rowcounter = 0;
                        linamttotal = 0;
                    }

                    TBL += "<tr><td colspan='6'><table width='100%' cellspacing='0px' cellpadding='0px' border='0'>";
                    TBL += "<tr class='upperhead1'><td colspan='1'  align='left'></td></tr></table>";
                    find += ds.Tables[0].Rows[p]["publ_name"].ToString() + "~";
                }


                TBL += ("<tr>");
                TBL += "<td class='rep_data' width='20%'>";
                TBL += ds.Tables[0].Rows[p]["publ_name"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='15%'style=padding-left:'1px'>";
                TBL += ds.Tables[0].Rows[p]["edtn_name"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='10%'>";
                TBL += ds.Tables[0].Rows[p]["no_of_insertion"].ToString() + "</td>";
                TBL += "<td class='rep_data' width='10%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["book_area"].ToString()) + "</td>";
                TBL += "<td class='rep_data' width='15%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["lineage_book_area"].ToString()) + "</td>";
                TBL += "<td class='rep_data' width='15%'align='right'>";
                TBL += chk_null(ds.Tables[0].Rows[p]["lineage_amount"].ToString()) + "</td>";
                if (ds.Tables[0].Rows[p]["lineage_amount"].ToString() != "" && ds.Tables[0].Rows[p]["lineage_amount"].ToString() != null)
                {
                    linamttotal = linamttotal + Convert.ToDouble(ds.Tables[0].Rows[p]["lineage_amount"].ToString());
                    linamtgtotal = linamtgtotal + Convert.ToDouble(ds.Tables[0].Rows[p]["lineage_amount"].ToString());
                }
                TBL += "<td class='rep_data' width='15%' align='right'>";
                if (ds.Tables[0].Rows[p]["amount"].ToString() != "")
                {
                    outotal = Convert.ToDouble(ds.Tables[0].Rows[p]["amount"]);
                    TBL += (outotal.ToString("F2"));
                }

                amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[p]["amount"]);
                TBL += ("</tr>");
                rowcounter++;
            }
            TBL += ("<tr>");
            TBL += ("<td colspan='5' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (linamttotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (amttotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("</tr>");
            TBL += ("<tr>");
            TBL += ("<td colspan='5' class='middle31new' align='right' >" + "GRAND TOTAL" + "&nbsp;&nbsp;" + "</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (linamtgtotal.ToString("F2"));
            TBL += ("</td>");
            TBL += ("<td  colspan='1'class='middle31new' align='right'>");
            TBL += (total.ToString("F2"));
            TBL += ("</td>");
            TBL += ("</tr>");
            TBL += "</table>";
            tblgrid.InnerHtml = TBL;
        }


    }

    public string creatheader(DataSet ds, int t)
    {
        if (t == 1)
        {
            pgn = 0;
        }

        string Header = "";
        pgn = pgn + 1;
        //Header += "<tr width='100%' style='padding-bottom:3px;'><td width '100%' colspan='7' align='center' class='upperhead7'>" + comp_name + "</td></tr>";
        //Header += "<tr width '100%' style='padding-bottom:3px;'><td  width '100%' align='center' class='upperhead7' colspan='7'>" + reportname + ":" + rundate2 + "</td></tr>";
        //Header += "<tr width='100%' style='padding-bottom:3px;'><td width '100%' colspan='7' align='center' class='upperhead7'>FROM DATE" + fromdate1 + "TO DATE" + todate1 + "</td></tr>";
        //Header += "<td class='tdforcolname1' width='5%'><b>S.No</b></td>";
        //Header += "<tr width='100%''><tr width='100%'class='upperhead'><td align='right' class='upperhead2' colspan='18'>Page No." + pgn + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>";

        Header += "<td class='middle31new' colspan='1' ><b>PUBLICATION<b></td>";
        Header += "<td class='middle31new' width='15%'><b>EDITION<b></td>";
        Header += "<td class ='middle31new'width='10%'><b>NO.OF.INSERTIONS<b></td>";
        Header += "<td class='middle31new'  width='10%' align='right'><b>DISPLAY SIZE<b></td>";
        Header += "<td class='middle31new'  width='15%'align='right'><b>LINAGE SIZE<b></td>";

        Header += "<td class='middle31new' width='15%' align='right'><b>LINAGE AMOUNT</b></td>";
        Header += "<td class='middle31new' width='15%' align='right'><b> DISPLAY AMOUNT<b></td>";
        Header += "</tr>";
        return Header;
    }


    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, typeof(insertionview), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);


    //            return;

    //        }


    //        int i1 = 1;
    //        Double total = 0;
    //        int cont = ds.Tables[0].Rows.Count;
    //        string tbl1 = "";
    //        int m11 = 0;
    //        string position = "";
    //        int ct = 0;
    //        int fr = maxlimit;
    //        int rcount = ds.Tables[0].Rows.Count;
    //        int pagec = rcount % maxlimit;
    //        int pagecount = rcount / maxlimit;
    //        if (pagec > 0)
    //         pagecount = pagecount + 1;




    //           comp_name1.Text = ds.Tables[0].Rows[0]["CNAME"].ToString();
    //            DataSet ds_xml = new DataSet();
    //            ds_xml.ReadXml(Server.MapPath("XML/insertion.xml"));
    //            report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[17].ToString();


    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            tbl1 = tbl1 + "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' valign='top'>";

    //            for (int p = 0; p < pagecount; p++)
    //            {
    //                int s = p + 1;

    //                tbl1 = tbl1 + "</table></P>";
    //            if (p == pagecount - 1)
    //                {
    //                    tbl1 = tbl1 + "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  >";
    //                }
    //                //else if (p == 0)
    //                //{
    //                //    tbl1 = tbl1 + "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>";


    //                //    tbl1 = tbl1 + ("</p>");
    //                //}
    //                else
    //                {
    //                    tbl1 = tbl1 + "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>";


    //                }



    //            tbl1 = tbl1 + "<tr ><td  width='100%'colspan='8' align='right' style='font=family:Arial; height:5px; font-size:14px;'  style='padding-left:200px;' ><b>" + page + " &nbsp;" + pgn + "</b></td></tr>";
    //            pgn = pgn + 1;
    //            //tbl1 = tbl1 + "<tr><td width='100%'colspan='8' align='right' style='font=family:Arial; font-size:14px;' style='padding-left:800px;' ><b>" + page + " &nbsp;" + pgn + "</b></td></tr>";

    //            tbl1 = tbl1 + "<tr valign='top'>";
    //            tbl1 = tbl1 + "<td class='middle31new' width='20%'><b>PUBLICATION<b></td>";
    //            tbl1 = tbl1 + "<td class='middle31new' width='15%'><b>EDITION<b></td>";
    //            tbl1 = tbl1 + "<td class ='middle31new'width='10%'><b>NO. OF INSERTION<b></td>";
    //            tbl1 = tbl1 + "<td class='middle31new' width='10%' align='right' ><b>DISPLAY SIZE</b></td>";
    //            tbl1 = tbl1 + "<td class='middle31new' width='15%' align='right' ><b>LINAGE SIZE</b></td>";
    //            tbl1 = tbl1 + "<td class='middle31new' width='15%' align='right' ><b>LINAGE AMOUNT</b></td>";
    //            tbl1 = tbl1 + "<td class='middle31new' width='15%' align='right' ><b>DISPLAY AMOUNT<b></td>";
    //            tbl1 = tbl1 + "</tr>";


    //           for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
    //            {
    //                total += Convert.ToDouble(ds.Tables[0].Rows[d]["amount"].ToString());

    //                int a = d;
    //                a = a + 1;

    //                tbl1 = tbl1 + ("<tr>");

    //                tbl1 = tbl1 + "<td class='rep_data' width='20%'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["publ_name"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='20%'style=padding-left:'1px'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["edtn_name"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='20%'>";
    //                tbl1 = tbl1 + ds.Tables[0].Rows[d]["no_of_insertion"].ToString() + "</td>";
    //                tbl1 = tbl1 + "<td class='rep_data' width='20%' align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["book_area"].ToString())+ "</td>";

    //                tbl1 = tbl1 + "<td class='rep_data' width='20%' align='right'>";
    //                tbl1 = tbl1 + chk_null(ds.Tables[0].Rows[d]["amount"].ToString()) + "</td>";

    //                tbl1 = tbl1 + "</tr>";

    //            }
    //            ct = ct + maxlimit;
    //            fr = fr + maxlimit;

    //        }

    //        tbl1 = tbl1 + ("<tr>");
    //        tbl1 = tbl1 + ("<td colspan='6' class='middle31new' align='right' >" + "TOTAL" + "&nbsp;&nbsp;" + "</td>");
    //        tbl1 = tbl1 + ("<td  colspan='2'class='middle31new' align='right'>");
    //        tbl1 = tbl1 + (chk_null(total.ToString()));
    //        tbl1 = tbl1 + ("</td>");
    //        tbl1 = tbl1 + ("</tr>");
    //        tbl1 = tbl1 + ("</table></p>");
    //        tblgrid.Visible = true;
    //    }
    //    tblgrid.InnerHtml = tbl1;



    //}

    public void pdf()
    {
        string code_find = "";
        int rowcount56 = 0;
        int maxlim = 12;
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "\\" + pdfName;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase("Page No. " + i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;
        document.Open();

        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        //iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 12, iTextSharp.text.Font.BOLD);
        Double total = 0;
        int NumColumns = 5;
        String date1 = "";
        date1 = changeformat(rundate);
        //DataSet ds= new DataSet();


        ////if (hiddendateformat.Value == "dd/mm/yyyy")
        ////{
        ////    fromdate = DMYToMDY(fromdate);
        ////    dateto = DMYToMDY(dateto);
        ////}


        ////else if (hiddendateformat.Value == "yyyy/mm/dd")
        ////{
        ////    fromdate = YMDToMDY(fromdate);
        ////    dateto = YMDToMDY(dateto);
        ////}
        DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.insertion2 adagencycli = new NewAdbooking.Report.classesoracle.insertion2();
        //    ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{

        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {

        //        fromdate = DMYToMDY(fromdate);
        //        dateto = DMYToMDY(dateto);

        //    }

        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {
        //        fromdate = YMDToMDY(fromdate);
        //        dateto = YMDToMDY(dateto);
        //    }
        //    NewAdbooking.Report.Classes.insertclass adagencycli = new NewAdbooking.Report.Classes.insertclass();
        //    ds = adagencycli.insertionwisebilling(Request.QueryString["comp_code"].ToString(), pubcentcode, branchcode, pubnamecode, edition, distcode, fromdate, dateto, Session["dateformat"].ToString(), useid, extra1, extra2, extra3, extra4, extra5);
        //}

        ds = (DataSet)Session["issue_edition"];
        string find = "";
        string find_rcpdt = "";
        string find_agency = "";
        //double amttotal = 0;
        //double outotal = 0;
        int i1 = 1;
        //Double total = 0;
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(insertionview), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);


            return;

        }

        double amttotal = 0;
        double outotal = 0;
        double linamttotal = 0;
        double linamtgtotal = 0;
        string pub = "";
        if (pubnamecode == "0" || pubnamecode == "")
        {
            pub = "ALL".ToString();
        }
        else
        {
            pub = pubname.ToString();
        }




        string pubcent1 = "";
        if (pubcentcode == "0" || pubcentcode == "")
        {
            pubcent1 = "ALL".ToString();
        }
        else
        {
            pubcent1 = pubcent.ToString();
        }



        string bran = "";
        if (branchcode == "0" || branchcode == "")
        {
            bran = "ALL".ToString();
        }
        else
        {
            bran = branch_c.ToString();
        }



        string edi = "";
        if (edition == "0" || edition == "")
        {
            edi = "ALL".ToString();
        }
        else
        {
            edi = editioncode.ToString();

        }

        string dist = "";
        if (distcode == "0" || distcode == "")
        {
            dist = "ALL".ToString();
        }
        else
        {
            dist = distname.ToString();
        }




        //int table1 = ds.Tables[0].Rows.Count;
        //int controw = ds.Tables[0].Rows.Count;
        //int contcol = ds.Tables[0].Columns.Count;
        ////int table2 = ds1.Tables[1].Rows.Count;

        //int q = ds.Tables[0].Columns.Count;
        //int z = q - 1;
        //int lastc = ds.Tables[0].Columns.Count;
        //int lastthirdc = lastc - 3;
        //int NumColumns = ds.Tables[0].Columns.Count + 1;
        //NumColumns = NumColumns - 5;
        //int xx = ds.Tables[0].Columns.Count - 10;

        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0]["CNAME"].ToString(), font10));
            tbl.WidthPercentage = 100;
            document.Add(tbl);


            PdfPTable tbl4 = new PdfPTable(1);
            tbl4.DefaultCell.BorderWidth = 0;
            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl4.addCell(new iTextSharp.text.Phrase("Issue Edition Wise Report", font10));
            tbl4.WidthPercentage = 100;
            document.Add(tbl4);


            PdfPTable tb3 = new PdfPTable(8);
            float[] xy3 = { 100 };
            tb3.DefaultCell.BorderWidth = 0;
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tb3.setWidths(xy1);
            tb3.WidthPercentage = 100;
            tb3.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));
            tb3.addCell(new Phrase("", font11));


            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("PUBLICATION:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(pub, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("PUBCENT:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(pubcent1, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("BRANCH:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(bran, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("DISTRICT:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(dist, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("EDITION:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(edi, font11));


            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("DATE FROM:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(fromdate, font11));

            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("TO DATE:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(dateto, font11));



            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("RUN DATE:", font11));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(date1, font11));
            document.Add(tb3);




            PdfPTable datatable = new PdfPTable(7);
            datatable.DefaultCell.Padding = 1;
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 0;
            float[] set_width = { 20, 15, 10, 10, 15, 15, 15 };
            datatable.setWidths(set_width);
            datatable.DefaultCell.Colspan = 7;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_BASELINE;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 0;

            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
            datatable.addCell(new iTextSharp.text.Phrase("PUBLICATION", font11));
            datatable.addCell(new iTextSharp.text.Phrase("EDITION", font11));
            datatable.addCell(new iTextSharp.text.Phrase("NO. OF INSERTION", font11));
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.addCell(new iTextSharp.text.Phrase("DISPLAY SIZE", font11));
            datatable.addCell(new iTextSharp.text.Phrase("LINAGE SIZE", font11));
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.addCell(new iTextSharp.text.Phrase("LINAGE AMOUNT", font11));
            datatable.addCell(new iTextSharp.text.Phrase("DISPLAY AMOUNT", font11));
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            datatable.DefaultCell.Colspan = 7;
            datatable.DefaultCell.Padding = 1;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 0;
            document.Add(datatable);




            //for (int d = 0; d < ds.Tables[0].Rows.Count; d++)
            //{
            //    //total += Convert.ToDouble(ds.Tables[0].Rows[d]["amount"].ToString());

            //    //if (rowcount56 == maxlim)
            //    //{
            //    //    rowcount56 = 0;
            //    //    document.newPage();
            //    //    document.Add(tbl);
            //    //    document.Add(tbl4);
            //    //    document.Add(tb3);
            //    //    document.Add(datatable);

            //    //}
            //    //int a = d;
            //    //a = a + 1;





            for (int d = 0; d < ds.Tables[0].Rows.Count; d++)
            {
                total += Convert.ToDouble(ds.Tables[0].Rows[d]["amount"].ToString());
                if (rowcount56 == maxlim)
                {
                    rowcount56 = 0;
                    document.newPage();
                    document.Add(tbl);
                    document.Add(tbl4);
                    document.Add(tb3);
                    document.Add(datatable);

                }
                //int a = d;
                //a = a + 1;



                PdfPTable datatabledata = new PdfPTable(7);
                datatabledata.DefaultCell.BorderWidth = 0;
                datatabledata.WidthPercentage = 100;
                datatabledata.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                float[] set_width1 = { 20, 15, 10, 10, 15, 15, 15 };
                datatabledata.setWidths(set_width1);
                //datatabledata.DefaultCell.Padding = 1;
                //datatabledata.WidthPercentage = 100;
                //datatabledata.DefaultCell.BorderWidth = 0;
                //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //datatabledata.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

                //float[] set_width1 = { 20, 15, 10, 10, 15, 15, 15 };
                //datatabledata.setWidths(set_width1);
                //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //datatabledata.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

                //datatabledata.DefaultCell.PaddingTop = 6;
                //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //datatabledata.DefaultCell.Colspan = 1;



                //if (d > 0)
                //{
                //    if (ds.Tables[0].Rows[d]["publ_name"].ToString() == ds.Tables[0].Rows[d - 1]["publ_name"].ToString())
                //    {



                  if (find.IndexOf(ds.Tables[0].Rows[d]["publ_name"].ToString()) < 0)
                {
                    if (d != 0)
                    {

                        datatabledata.DefaultCell.Colspan = 7;
                        datatabledata.DefaultCell.Padding = 1;
                        datatabledata.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
                        datatabledata.DefaultCell.Colspan = 0;
                        //datatabledata.DefaultCell.Colspan = 5;
                        datatabledata.addCell(new iTextSharp.text.Phrase("", font10));
                        datatabledata.addCell(new iTextSharp.text.Phrase("", font10));
                        datatabledata.addCell(new iTextSharp.text.Phrase("", font10));
                        datatabledata.addCell(new iTextSharp.text.Phrase("", font10));
                       // datatabledata.addCell(new iTextSharp.text.Phrase("", font10));
                       // datatabledata.addCell(new iTextSharp.text.Phrase("", font10));

                        datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        datatabledata.addCell(new iTextSharp.text.Phrase("Total:", font10));
                        datatabledata.addCell(new iTextSharp.text.Phrase(linamttotal.ToString("F2"), font10));
                        datatabledata.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font10));
                    
                        amttotal = 0;
                        rowcounter = 0;
                        linamttotal = 0;

                    }

                    find += ds.Tables[0].Rows[d]["publ_name"].ToString() + "~";
                        
                  }
                        datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        datatabledata.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[d]["publ_name"].ToString(), font11));
                        datatabledata.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[d]["edtn_name"].ToString(), font11));
                        datatabledata.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[d]["no_of_insertion"].ToString(), font11));
                        datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(ds.Tables[0].Rows[d]["book_area"].ToString()), font11));
                        datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(ds.Tables[0].Rows[d]["lineage_book_area"].ToString()), font11));
                        if (ds.Tables[0].Rows[d]["lineage_amount"].ToString() != "" && ds.Tables[0].Rows[d]["lineage_amount"].ToString() != null)
                        {
                            linamttotal = linamttotal + Convert.ToDouble(ds.Tables[0].Rows[d]["lineage_amount"].ToString());
                            linamtgtotal = linamtgtotal + Convert.ToDouble(ds.Tables[0].Rows[d]["lineage_amount"].ToString());
                        }
                        datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(ds.Tables[0].Rows[d]["lineage_amount"].ToString()), font11));
                        if (ds.Tables[0].Rows[d]["amount"].ToString() != "")
                        {
                            outotal = Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);
                            datatabledata.addCell(new Phrase(outotal.ToString("F2"), font11));
                        }
                       amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);
                    
                       
                        document.Add(datatabledata);
                        rowcount56++;
                       
                    }
                    
                    //else
                    //{

                       
                    //    //datatabledata.DefaultCell.Colspan = 4;
                    //    //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    //    //datatabledata.addCell(new iTextSharp.text.Phrase("Total", font10));
                    //    //datatabledata.DefaultCell.Padding = 1;
                    //    //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    //    //datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(total.ToString()), font10));
                    //    datatabledata.DefaultCell.Colspan = 7;
                    //    datatabledata.DefaultCell.Padding = 1;
                    //    datatabledata.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
                    //    datatabledata.DefaultCell.Colspan = 0;
                    //    datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    //    datatabledata.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[d]["publ_name"].ToString(), font11));
                    //    datatabledata.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[d]["edtn_name"].ToString(), font11));
                    //    datatabledata.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[d]["no_of_insertion"].ToString(), font11));
                    //    datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    //    datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(ds.Tables[0].Rows[d]["book_area"].ToString()), font11));
                    //    datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(ds.Tables[0].Rows[d]["lineage_book_area"].ToString()), font11));
                    //    datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(ds.Tables[0].Rows[d]["lineage_amount"].ToString()), font11));
                    //    if (ds.Tables[0].Rows[d]["amount"].ToString() != "")
                    //    {
                    //        outotal = Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);
                    //        datatabledata.addCell(new Phrase(outotal.ToString("F2"), font11));
                    //    }


                    //    amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[d]["amount"]);
                     
                    //    rowcount56++;
                    //    //amttotal = 0;
                    //}





                    //if (d == (ds.Tables[0].Rows.Count - 1))
                    //{


                    PdfPTable datatabledata2= new PdfPTable(7);
                    datatabledata2.DefaultCell.BorderWidth = 0;
                    datatabledata2.WidthPercentage = 100;

                    datatabledata2.DefaultCell.Colspan = 7;
                    datatabledata2.DefaultCell.Padding = 1;
                    datatabledata2.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
                    datatabledata2.DefaultCell.Colspan = 0;

                        //datatabledata.DefaultCell.Colspan = 5;
                        //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        //datatabledata.addCell(new iTextSharp.text.Phrase("Total", font10));
                        //datatabledata.DefaultCell.Padding = 1;
                        //datatabledata.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        //datatabledata.addCell(new iTextSharp.text.Phrase(chk_null(total.ToString()), font10));
                        //datatabledata.DefaultCell.Colspan = 4;
                    datatabledata2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    datatabledata2.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata2.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata2.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata2.addCell(new iTextSharp.text.Phrase("", font10));
                    //datatabledata2.addCell(new iTextSharp.text.Phrase("", font10));
                    //datatabledata2.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata2.addCell(new iTextSharp.text.Phrase("Total:" , font10));
                    datatabledata2.addCell(new iTextSharp.text.Phrase(linamttotal.ToString("F2"), font10));
                    datatabledata2.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font10));
                    datatabledata2.DefaultCell.Colspan = 7;
                    datatabledata2.DefaultCell.Padding = 1;
                    datatabledata2.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
                    datatabledata2.DefaultCell.Colspan = 0;

                    document.Add(datatabledata2);

                    PdfPTable datatabledata3 = new PdfPTable(7);
                    datatabledata3.DefaultCell.BorderWidth = 0;
                    datatabledata3.WidthPercentage = 100;

                    datatabledata3.DefaultCell.Colspan = 7;
                    datatabledata3.DefaultCell.Padding = 1;
                    datatabledata3.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
                    datatabledata3.DefaultCell.Colspan = 0;

                    datatabledata3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    datatabledata3.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata3.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata3.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata3.addCell(new iTextSharp.text.Phrase("", font10));
                    //datatabledata3.addCell(new iTextSharp.text.Phrase("", font10));
                   // datatabledata3.addCell(new iTextSharp.text.Phrase("", font10));
                    datatabledata3.addCell(new iTextSharp.text.Phrase("Grand Total:", font10));
                    datatabledata3.addCell(new iTextSharp.text.Phrase(linamtgtotal.ToString("F2"), font10));
                    datatabledata3.addCell(new iTextSharp.text.Phrase(total.ToString("F2"), font10));
                    datatabledata3.DefaultCell.Colspan = 7;
                    datatabledata3.DefaultCell.Padding = 1;
                    datatabledata3.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________", font10));
                    datatabledata3.DefaultCell.Colspan = 0;

                    document.Add(datatabledata3);


            




            document.Close();
            Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }

    }

}




    

