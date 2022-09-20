using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.OracleClient;

public partial class issue_billwise_rpt : System.Web.UI.Page
{
    string compcode="", supnname="", distname="", edinname="", publicationname="", printcentname="", dateformat="", userid="", printcent = "", chk_acces="", publ_name="", supl_name="", district_name="", edition = "", fromdate = "", todate = "", ratio_type="", statecode="", destination = "", extra1="", extra2="";
    string printingcenter = "";
    string edition_name = "";
    string pub_name = "";
    string suppliment_name = "";
    string dist_name = "";
    double month_collection = 0;
    double rcr = 0;
    double rcp = 0;
    double ca = 0;
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            chk_access.Value = Session["access"].ToString();

            printcent = Request.QueryString["printcent"];
            edition = Request.QueryString["edition"];
            fromdate = Request.QueryString["fromdate"];
            todate = Request.QueryString["todate"];
            ratio_type = Request.QueryString["ratio_type"];
            publ_name = Request.QueryString["publ_name"];
            destination = Request.QueryString["destination"];
            district_name = Request.QueryString["district_name"];
            supl_name = Request.QueryString["supl_name"];
            compcode = Request.QueryString["compcode"];
            dateformat = Request.QueryString["dateformat"];
            userid = Request.QueryString["userid"];
            chk_acces = Request.QueryString["chk_access"];

            supnname = Request.QueryString["supnname"];
            distname = Request.QueryString["distname"];
            edinname = Request.QueryString["edinname"];
            publicationname = Request.QueryString["publicationname"];
            printcentname = Request.QueryString["printcentname"];

            if (printcent == "0" || printcent == "")
            {
                printingcenter = "All";
            }
            else
            {
                printingcenter = printcentname;
            }

            if (edition=="")
            {
                edition_name = "All";
            }
            else
            {
                edition_name = edinname;
            }

            if (publ_name == "0" || publ_name == null)
            {
                pub_name = "All";
            }
            else
            {
                pub_name = publicationname;
            }

            if (district_name == "0" || district_name == null)
            {
                dist_name = "All";
            }
            else
            {
                dist_name = distname;
            }

            if (supl_name == "0" || supl_name == null || supl_name == "")
            {
                suppliment_name = "All";
            }
            else
            {
                suppliment_name = supnname;
            }

            DataSet xml = new DataSet();
            xml.ReadXml(Server.MapPath("XML/issuebillreport.xml"));
            reportname.Value = xml.Tables[0].Rows[0].ItemArray[11].ToString();
            from_date.Value = xml.Tables[0].Rows[0].ItemArray[12].ToString();
            to_date.Value = xml.Tables[0].Rows[0].ItemArray[13].ToString();
            pubcent.Value = xml.Tables[0].Rows[0].ItemArray[14].ToString();
            publication.Value = xml.Tables[0].Rows[0].ItemArray[16].ToString();
            district.Value = xml.Tables[0].Rows[0].ItemArray[19].ToString();
            suppliment.Value = xml.Tables[0].Rows[0].ItemArray[18].ToString();
            branch.Value = xml.Tables[0].Rows[0].ItemArray[15].ToString();
            mainedition.Value = xml.Tables[0].Rows[0].ItemArray[17].ToString();

            if (destination == "1" || destination == "0")
            {
                onscreen();
            }
            else if (destination == "3")
            {
                pdf_report();
            }
            else if (destination == "4")
            {
                excel_report();
            }
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        

    }

    public void onscreen()
    {
        

        try
        {
            string tbl = "";
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.issuebillreport rpt = new NewAdbooking.Report.classesoracle.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }
            else
            {
                NewAdbooking.Report.Classes.issuebillreport rpt = new NewAdbooking.Report.Classes.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }

            int cont = ds.Tables[0].Rows.Count;
            int contc = ds.Tables[0].Columns.Count;
            double[] arr1 = new double[contc];

            if (ds.Tables[0].Rows.Count > 0)
            {
                tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
                tbl = tbl + "<tr><td colspan='12' style='text-align:center;' class='headingc'>" + reportname.Value + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + from_date.Value + "</td><td colspan='1' style='text-align:left;'>" + fromdate + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + to_date.Value + "</td><td colspan='1' style='text-align:right;'>" + todate + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + pubcent.Value + "</td><td colspan='1' style='text-align:left;'>" + printingcenter + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + publication.Value + "</td><td colspan='1' style='text-align:right;'>" + pub_name + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + mainedition.Value + "</td><td colspan='1' style='text-align:left;'>" + edition_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + suppliment.Value + "</td><td colspan='1' style='text-align:right;'>" + suppliment_name + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + district.Value + "</td><td colspan='1' style='text-align:left;'>" + dist_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'></td><td colspan='1' style='text-align:left;'></td></tr>";
                tbl = tbl + "<tr><td class='middle31' align='left' colspan='1'>Publication</td><td colspan='1' class='middle31' align='left'>Main Edition</td><td colspan='1' class='middle31' align='left'>Sub Edition</td><td colspan='1' class='middle31' align='left'>Suppliment</td><td colspan='1' class='middle31' align='left'>Qty</td><td colspan='1' class='middle31' align='left'>CC(Sq cm)</br>(with linage)</td><td colspan='1' class='middle31' align='right'>Business</br>(Billed)</td><td colspan='1' class='middle31' align='right'>Debit</br>Note</td><td colspan='1' class='middle31' align='left'>Busienss</br>AgainstCollection</td><td colspan='1' class='middle31' align='left'>Credit</br>Note</td><td colspan='1' class='middle31' align='left'>Balance</td><td colspan='1' class='middle31' align='left'>This month</br>collection</td></tr>";

                int i1 = 1;
                for (i = 0; i <= cont - 1; i++)
                {
                    tbl = tbl + ("<tr style='height:30px'>");

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    if (i == 0)
                    {
                        tbl = tbl + ds.Tables[0].Rows[i]["PUBLICATION_CODE"] + "</td>";
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[i]["PUBLICATION_CODE"].ToString() != ds.Tables[0].Rows[i - 1]["PUBLICATION_CODE"].ToString())
                        {
                            tbl = tbl + ds.Tables[0].Rows[i]["PUBLICATION_CODE"] + "</td>";
                        }
                        else
                        {
                            tbl = tbl + ("</td>");
                        }
                    }
                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["SUB_EDITION_CODE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["DSIZE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["BUSINESS_BILL"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["DEBIT_NOTE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["RCR"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["CREDIT_NOTE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["BALANCE"] + "</td>";

                    if (ds.Tables[0].Rows[i]["RCR"].ToString() != "")
                    {
                        rcr = double.Parse(ds.Tables[0].Rows[i]["RCR"].ToString());
                    }
                    else
                    {
                        rcr = 0;
                    }

                    if (ds.Tables[0].Rows[i]["RCP"].ToString() != "")
                    {
                        rcp = double.Parse(ds.Tables[0].Rows[i]["RCP"].ToString());
                    }
                    else
                    {
                        rcp = 0;
                    }

                    if (ds.Tables[0].Rows[i]["CA"].ToString() != "")
                    {
                        rcp = double.Parse(ds.Tables[0].Rows[i]["CA"].ToString());
                    }
                    else
                    {
                        rcp = 0;
                    }

                    //if (ds.Tables[0].Rows[i]["RCR"].ToString() != "" || ds.Tables[0].Rows[i]["RCP"].ToString() != "" || ds.Tables[0].Rows[i]["CA"].ToString()!="")
                    //{
                    month_collection = rcr + rcp + ca;
                    //}

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + month_collection + "</td>";

                    tbl = tbl + "</tr>";
                }
                tbl += "</table>";
                div1.Visible = true;
                div1.InnerHtml = tbl;
                btnprint.Attributes.Add("onclick", "javascript:return window.open('issue_billwise_print.aspx?compcode=" + compcode + "&printcent=" + printcent + "&edition=" + edition + "&fromdate=" + fromdate + "&todate=" + todate + "&dateformat=" + dateformat + "&userid=" + userid + "&chk_acces=" + chk_acces + "&ratio_type=" + ratio_type + "&extra1=" + extra1 + "&extra2=" + extra2 + "&publ_name=" + publ_name + "&district_name=" + district_name + "&supl_name=" + supl_name + " ')");
                                                                                  //"issue_billwise_print.aspx?compcode=" + compcode + "&printcent=" + printcent + "&edition=" + edition + "&fromdate=" + fromdate + "&todate=" + todate + "&dateformat=" + dateformat + "&userid=" + userid + "&chk_access=" + chk_access + "&ratio_type=" + ratio_type + "&extra1=" + extra1 + "&extra2=" + extra2 + "&destination=" + destination + "&publ_name=" + publ_name + "&district_name=" + district_name + "&supl_name=" + supl_name);
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }

    public void excel_report()
    {
        try
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            string tbl = "";

            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.issuebillreport rpt = new NewAdbooking.Report.classesoracle.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }
            else
            {
                NewAdbooking.Report.Classes.issuebillreport rpt = new NewAdbooking.Report.Classes.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }

            int cont = ds.Tables[0].Rows.Count;
            int contc = ds.Tables[0].Columns.Count;
            double[] arr1 = new double[contc];
            if (ds.Tables[0].Rows.Count > 0)
            {
                tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
                tbl = tbl + "<tr><td colspan='12' style='text-align:center;' class='headingc'>" + reportname.Value + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + from_date.Value + "</td><td colspan='1' style='text-align:left;'>" + fromdate + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + to_date.Value + "</td><td colspan='1' style='text-align:right;'>" + todate + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + pubcent.Value + "</td><td colspan='1' style='text-align:left;'>" + printingcenter + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + publication.Value + "</td><td colspan='1' style='text-align:right;'>" + pub_name + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + mainedition.Value + "</td><td colspan='1' style='text-align:left;'>" + edition_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + suppliment.Value + "</td><td colspan='1' style='text-align:right;'>" + suppliment_name + "</td></tr>";
                tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + district.Value + "</td><td colspan='1' style='text-align:left;'>" + dist_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'></td><td colspan='1' style='text-align:left;'></td></tr>";
                tbl = tbl + "<tr><td class='middle31' align='left' colspan='1'>Publication</td><td colspan='1' class='middle31' align='left'>Main Edition</td><td colspan='1' class='middle31' align='left'>Sub Edition</td><td colspan='1' class='middle31' align='left'>Suppliment</td><td colspan='1' class='middle31' align='left'>Qty</td><td colspan='1' class='middle31' align='left'>CC(Sq cm)</br>(with linage)</td><td colspan='1' class='middle31' align='right'>Business</br>(Billed)</td><td colspan='1' class='middle31' align='right'>Debit</br>Note</td><td colspan='1' class='middle31' align='left'>Busienss</br>AgainstCollection</td><td colspan='1' class='middle31' align='left'>Credit</br>Note</td><td colspan='1' class='middle31' align='left'>Balance</td><td colspan='1' class='middle31' align='left'>This month</br>collection</td></tr>";

                int i1 = 1;
                for (i = 0; i <= cont - 1; i++)
                {
                    tbl = tbl + ("<tr style='height:30px'>");

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    if (i == 0)
                    {
                        tbl = tbl + ds.Tables[0].Rows[i]["PUBLICATION_CODE"] + "</td>";
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[i]["PUBLICATION_CODE"].ToString() != ds.Tables[0].Rows[i - 1]["PUBLICATION_CODE"].ToString())
                        {
                            tbl = tbl + ds.Tables[0].Rows[i]["PUBLICATION_CODE"] + "</td>";
                        }
                        else
                        {
                            tbl = tbl + ("</td>");
                        }
                    }
                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["SUB_EDITION_CODE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["DSIZE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["BUSINESS_BILL"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["DEBIT_NOTE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["RCR"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["CREDIT_NOTE"] + "</td>";

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + ds.Tables[0].Rows[i]["BALANCE"] + "</td>";

                    if (ds.Tables[0].Rows[i]["RCR"].ToString() != "")
                    {
                        rcr = double.Parse(ds.Tables[0].Rows[i]["RCR"].ToString());
                    }
                    else
                    {
                        rcr = 0;
                    }

                    if (ds.Tables[0].Rows[i]["RCP"].ToString() != "")
                    {
                        rcp = double.Parse(ds.Tables[0].Rows[i]["RCP"].ToString());
                    }
                    else
                    {
                        rcp = 0;
                    }

                    if (ds.Tables[0].Rows[i]["CA"].ToString() != "")
                    {
                        rcp = double.Parse(ds.Tables[0].Rows[i]["CA"].ToString());
                    }
                    else
                    {
                        rcp = 0;
                    }

                    //if (ds.Tables[0].Rows[i]["RCR"].ToString() != "" || ds.Tables[0].Rows[i]["RCP"].ToString() != "" || ds.Tables[0].Rows[i]["CA"].ToString()!="")
                    //{
                    month_collection = rcr + rcp + ca;
                    //}

                    tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                    tbl = tbl + month_collection + "</td>";

                    tbl = tbl + "</tr>";
                }
                tbl += "</table>";

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div1.InnerHtml = tbl;
                div1.Visible = true;
                div1.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }

    public void pdf_report()
    {
        try
        {
            string pdfName = "";
            pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
            string name = Server.MapPath("") + "//" + pdfName;

            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
            PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
            int i2 = 0;
            iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
            footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            document.Footer = footer;
            document.Open();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.issuebillreport rpt = new NewAdbooking.Report.classesoracle.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }
            else
            {
                NewAdbooking.Report.Classes.issuebillreport rpt = new NewAdbooking.Report.Classes.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 19, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 9);
                //iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);

                PdfPTable tbl = new PdfPTable(1);
                float[] xy = { 100 };
                float[] arr = { 10, 10, 10, 4, 10, 10, 10, 6, 10, 7, 6, 7 };
                tbl.DefaultCell.BorderWidth = 0;
                tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl.setWidths(xy);
                tbl.addCell(new iTextSharp.text.Phrase(reportname.Value, font9));
                tbl.WidthPercentage = 100;
                document.Add(tbl);

                PdfPTable tbl1 = new PdfPTable(5);
                float[] xy1 = { 9, 25, 29, 9, 8 };
                tbl1.DefaultCell.BorderWidth = 0;
                tbl1.WidthPercentage = 100;
                tbl1.setWidths(xy1);
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl1.addCell(new iTextSharp.text.Phrase(from_date.Value, font10));
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl1.addCell(new iTextSharp.text.Phrase(fromdate, font10));
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl1.addCell(new iTextSharp.text.Phrase("", font10));
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl1.addCell(new iTextSharp.text.Phrase(to_date.Value, font10));
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl1.addCell(new iTextSharp.text.Phrase(todate, font10));
                tbl1.WidthPercentage = 100;
                document.Add(tbl1);

                PdfPTable tbl2 = new PdfPTable(5);
                //float[] xy1 = { 9, 25, 29, 9, 8 };
                tbl2.DefaultCell.BorderWidth = 0;
                tbl2.WidthPercentage = 100;
                tbl2.setWidths(xy1);
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl2.addCell(new iTextSharp.text.Phrase(pubcent.Value, font10));
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl2.addCell(new iTextSharp.text.Phrase(printingcenter, font10));
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl2.addCell(new iTextSharp.text.Phrase("", font10));
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl2.addCell(new iTextSharp.text.Phrase(publication.Value, font10));
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl2.addCell(new iTextSharp.text.Phrase(pub_name, font10));
                tbl2.WidthPercentage = 100;
                document.Add(tbl2);

                PdfPTable tbl3 = new PdfPTable(5);
                //float[] xy1 = { 9, 25, 29, 9, 8 };
                tbl3.DefaultCell.BorderWidth = 0;
                tbl3.WidthPercentage = 100;
                tbl3.setWidths(xy1);
                tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl3.addCell(new iTextSharp.text.Phrase(mainedition.Value, font10));
                tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl3.addCell(new iTextSharp.text.Phrase(edition_name, font10));
                tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl3.addCell(new iTextSharp.text.Phrase("", font10));
                tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl3.addCell(new iTextSharp.text.Phrase(suppliment.Value, font10));
                tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl3.addCell(new iTextSharp.text.Phrase(suppliment_name, font10));
                tbl3.WidthPercentage = 100;
                document.Add(tbl3);

                PdfPTable tbl4 = new PdfPTable(5);
                //float[] xy1 = { 9, 25, 29, 9, 8 };
                tbl4.DefaultCell.BorderWidth = 0;
                tbl4.WidthPercentage = 100;
                tbl4.setWidths(xy1);
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase(district.Value, font10));
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase(dist_name, font10));
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase("", font10));
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl4.addCell(new iTextSharp.text.Phrase("", font10));
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl4.addCell(new iTextSharp.text.Phrase("", font10));
                tbl4.WidthPercentage = 100;
                document.Add(tbl4);

                PdfPTable tbl5 = new PdfPTable(12);
                float[] xy2 = { 8, 10, 8, 8, 5, 10, 6, 6, 14, 7, 6, 10 };
                tbl5.DefaultCell.BorderWidth = 0;
                tbl5.WidthPercentage = 100;
                tbl5.setWidths(xy2);
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl5.addCell(new iTextSharp.text.Phrase("Publication", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl5.addCell(new iTextSharp.text.Phrase("Main Edition", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl5.addCell(new iTextSharp.text.Phrase("Sub Edition", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl5.addCell(new iTextSharp.text.Phrase("Suppliment", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl5.addCell(new iTextSharp.text.Phrase("QTY", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl5.addCell(new iTextSharp.text.Phrase("CC(Sq cm) (with linage)", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl5.addCell(new iTextSharp.text.Phrase("Business(Billed)", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl5.addCell(new iTextSharp.text.Phrase("Debit Note", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl5.addCell(new iTextSharp.text.Phrase("Busienss AgainstCollection", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl5.addCell(new iTextSharp.text.Phrase("Credit Note", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl5.addCell(new iTextSharp.text.Phrase("Balance", font10));
                tbl5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl5.addCell(new iTextSharp.text.Phrase("This month collection", font10));
                tbl5.WidthPercentage = 100;
                document.Add(tbl5);

                PdfPTable tbl6 = new PdfPTable(12);
                //float[] xy2 = { 8, 10, 8, 8, 5, 10, 6, 6, 14, 7, 6, 10 };
                tbl6.DefaultCell.BorderWidth = 0;
                tbl6.WidthPercentage = 100;
                tbl6.setWidths(xy2);

                for (int k = 0; k < ds.Tables[0].Rows.Count; k++ )
                {
                    if (k == 0)
                    {
                        tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["PUBLICATION_CODE"].ToString(), font10));
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[k]["PUBLICATION_CODE"].ToString() != ds.Tables[0].Rows[k - 1]["PUBLICATION_CODE"].ToString())
                        {
                            tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["PUBLICATION_CODE"].ToString(), font10));
                        }
                        else
                        {
                            tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            tbl6.addCell(new iTextSharp.text.Phrase("", font10));
                        }
                        
                    }
                    
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["EDITION_NAME"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["SUB_EDITION_CODE"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase("", font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase("", font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["DSIZE"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BUSINESS_BILL"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["DEBIT_NOTE"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RCR"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CREDIT_NOTE"].ToString(), font10));
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BALANCE"].ToString(), font10));

                    if (ds.Tables[0].Rows[k]["RCR"].ToString() != "")
                    {
                        rcr = double.Parse(ds.Tables[0].Rows[k]["RCR"].ToString());
                    }
                    else
                    {
                        rcr = 0;
                    }

                    if (ds.Tables[0].Rows[k]["RCP"].ToString() != "")
                    {
                        rcp = double.Parse(ds.Tables[0].Rows[k]["RCP"].ToString());
                    }
                    else
                    {
                        rcp = 0;
                    }

                    if (ds.Tables[0].Rows[k]["CA"].ToString() != "")
                    {
                        rcp = double.Parse(ds.Tables[0].Rows[k]["CA"].ToString());
                    }
                    else
                    {
                        rcp = 0;
                    }

                    month_collection = rcr + rcp + ca;
                    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl6.addCell(new iTextSharp.text.Phrase(month_collection.ToString(), font10));
                }
                document.Add(tbl6);

                document.Close();
                Response.Redirect(pdfName, false);
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
}
