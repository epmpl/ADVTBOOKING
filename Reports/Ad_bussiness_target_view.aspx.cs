using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;


public partial class Reports_Ad_bussiness_target_view : System.Web.UI.Page
{

    string compcode = "", userid = "", dateformat = "", datefrom = "", todate = "", publication = "", edition = "", adtype = "", uom = "", paymade = "", extra1 = "", extra2 = "", basedon = "";
    string destination = "", chkaccess = "", agencycode="", currentdate = "", username = "";
    int pgn = 1;
    int rowcounter = 0;
    int p;
    static int current = 1;
    int ll;
    int pagewidth = 20;
    int jj = 1;
    int kk;
    int j;
    int pagec;
    int pagecount;
    static int ab = 0;
    static int b = 4;
    static int k;
    static int l;

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
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        compcode = Request.QueryString["compcode"].ToString();
        userid = Request.QueryString["userid"].ToString();
        dateformat = Request.QueryString["dateformat"].ToString();
        datefrom = Request.QueryString["datefrom"].ToString();
        todate = Request.QueryString["todate"].ToString();
        publication = Request.QueryString["publication"].ToString();
        edition = Request.QueryString["edition"].ToString();
        adtype = Request.QueryString["adtype"].ToString();
        uom = Request.QueryString["uom"].ToString();
        paymade = Request.QueryString["paymade"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        extra2 = Request.QueryString["extra2"].ToString();
        basedon = Request.QueryString["basedon"].ToString();
        destination = Request.QueryString["destination"].ToString();
        agencycode = Request.QueryString["agencycode"].ToString();
        chkaccess = Request.QueryString["chkaccess"].ToString();

        username = Session["username"].ToString().ToUpper();
        currentdate = System.DateTime.Now.ToString();

        if (!Page.IsPostBack)
        {

            //=============for paging================

            if (Request.QueryString["page"] != null)
            {
                p = Convert.ToInt16(Request.QueryString["page"].ToString());
                current = p;
                ll = p;
                p = (p * pagewidth) - pagewidth;
            }
            else
            {
                current = 1;
                p = 0;
                jj = 0;
                kk = 0;

            }
            if (destination == "1")
            {
                showreport();
            }
            else if (destination == "0")
            {
                showreport();
            }
            else if (destination == "2")
            {
                showreportexcel();
            }
            else if (destination == "3")
            {
                showreportpdf();
            }


        }

    }
    public string create_header(DataSet ds)
    {
        StringBuilder TBL = new StringBuilder();
        int vrcount = ds.Tables[0].Columns.Count;//  ds.Tables[0].Rows.Count;
        TBL.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
        TBL.Append("<tr>");
        TBL.Append("<td  width='100%' align='center' style='font-size:20px;'colspan='" + vrcount + "' class='quotationnam'><b><u>" + "THE NEW INDIAN EXPRESS" + "</u></b></td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>");
        TBL.Append("<tr height='10px' align='center'><td style='font-size:20px;'colspan='" + vrcount + "' class='quotationnam'  ><b>&nbsp;Bussiness Target Analisis Report </b></td></tr>");
        TBL.Append("<td width='20%' class='quotationnam' align='left'><b>From Date: </b>" + datefrom + "</td> ");
        TBL.Append("<td   class='quotationnam' align='left'><b>To Date: </b>" + todate + "</td></tr>");

        if (publication == "" || publication == null)
        {
            TBL.Append("<td width='20%' class='quotationnam' align='left'><b>Publication:&nbsp;&nbsp;</b> " + "ALL" + "</td>");
        }
        else { TBL.Append("<td width='20%' class='quotationnam' align='left'><b>Publication:&nbsp;&nbsp;</b> " + publication + "</td>"); }

        if (adtype == "" || adtype == null)
        {
            TBL.Append("<td  align='left'><b>Ad Type:&nbsp;&nbsp; </b> " + "ALL" + "</td></tr> ");
        }
        else { TBL.Append("<td   align='left'><b>Ad Type:&nbsp;&nbsp; </b> " + adtype + "</td></tr>"); }

        if (uom == "" || uom == null)
        {
            TBL.Append("<td width='20%' class='quotationnam' align='left'><b>Ad Type:&nbsp;&nbsp; </b> " + "ALL" + "</td></tr>");
        }
        else
        {
            TBL.Append("<td width='20%' class='quotationnam' align='left'><b>Ad Type:&nbsp;&nbsp; </b> " + uom + "</td></tr>");
        }

        TBL.Append("</table>");
        TBL.Append("<table width='100%'  style='border:solid 1px black;' cellspacing='0' cellpadding='0' border='0'>");
        for (int v = 2; v < ds.Tables[0].Columns.Count; v++)
        {
            if (ds.Tables[0].Columns[v].Caption.ToString() == "Comp_Code" || ds.Tables[0].Columns[v].Caption.ToString() == "TOT_SIZE" || ds.Tables[0].Columns[v].Caption.ToString() == "INSERT_DATE" || ds.Tables[0].Columns[v].Caption.ToString() == "INS_DATE" || ds.Tables[0].Columns[v].Caption.ToString() == "TOT_AMT")
            {
                TBL.Append("<td   class='quotationnam' align='center' style='font-size:13px;border-right:solid 1px black;' ><b>" + ds.Tables[0].Columns[v].Caption.ToString() + "</b></td>");
            }
            else
            {
                string value = ds.Tables[0].Columns[v].Caption.ToString();
                int index1 = value.LastIndexOf('_');
                //string bb = value.Substring(index1).Replace("_", "");
                string bb ="";
                if (bb == "999999")
                {
                    TBL.Append("<td width='18%' class='quotationnam' align='center' style='font-size:13px;border-right:solid 1px black;' ><b>" + "INSERTS" + "</b></td>");
                }
                else if (bb == "888888")
                {
                    TBL.Append("<td width='18%' class='quotationnam' align='center' style='font-size:13px;border-right:solid 1px black;' ><b>" + "CLASSIFIED" + "</b></td>");
                }
                else if (bb == "")
                {
                    TBL.Append("<td width='18%' class='quotationnam' align='center' style='font-size:13px;border-right:solid 1px black;' ><b>" + ds.Tables[0].Columns[v].Caption.ToString() + "</b></td>");
                }
                else
                {
                    TBL.Append("<td width='18%' class='quotationnam' align='center' style='font-size:13px;border-right:solid 1px black;' ><b>" + getexcndame(bb) + "</b></td>");
                }
            }
        }
        return TBL.ToString();
    }
    public string getexcndame(string getexccode)
    {
        DataSet ds = new DataSet();
        string excname = "";
        try
        {

            if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.ad_bussiness_targetrpt exe = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
                ds = exe.getexcname(compcode, getexccode);
            }
            else if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt exe = new NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt();
                ds = exe.getexcname(compcode, getexccode);
            }
            else
            {
                string procedureName = "AD_GET_EXECNAME";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { compcode, getexccode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                excname = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return excname;
        }
        catch (Exception ex)
        {
            return Convert.ToString(ex.Message);
        }
    }

    public void showreport()
    {
        DataSet ds = new DataSet();
        double amountdttotal = 0.00;

        if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_bussiness_targetrpt exe = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
            ds = exe.bussinesstargetreport(compcode, publication, adtype, uom, datefrom, todate, dateformat, userid, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt exe = new NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt();
            //string compcode,string pub_center,string branch, string publication,string edition,string agency_code,string client_code,string executive_code, string adtype, string uom,string agency_pay, string datefrom, string todate, string dateformat, string userid,string chk_access, string extra1, string extra2)
            ds = exe.bussinesstargetreport(compcode,"","", publication,edition,agencycode,"","", adtype, uom,paymade, datefrom, todate, dateformat, userid,chkaccess, extra1, extra2);
        }
        else
        {
            if (paymade == "0")
                paymade = "";
            string procedureName = "ad_rep_bussiness_ad_rep_bussiness_amt_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, paymade, datefrom, todate, dateformat, userid, chkaccess, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }
        int rcount = ds.Tables[0].Rows.Count;
        StringBuilder TBL = new StringBuilder();
        string header = create_header(ds);
        TBL.Append(header.ToString());
        for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        {
            TBL.Append("<tr style='height:30px;'>");
            for (int v = 2; v < ds.Tables[0].Columns.Count; v++)
            {
                TBL.Append("<td  width='18%' class='quotationnam' align='center' style='font-size:10px;border-right:solid 1px black;border-top:solid 1px black;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
            }

            //ds.Tables[0].Rows[z].ItemArray[v].ToString()


        }



        TBL.Append("<tr style='height:30px;'>");
        TBL.Append("<td width='18%' class='quotationnam'  align='center'  style='font-size:16px; border-top:solid 2px black;border-bottom:solid 1px black;border-right:solid 1px black;border-left:solid 1px black;'><b>TOTAL :- </b></td>");
        
        for (int vc = 3; vc < ds.Tables[0].Columns.Count; vc++)
        {
            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                amountdttotal = amountdttotal + Convert.ToDouble(ds.Tables[0].Rows[z].ItemArray[vc].ToString());
                
            //TBL.Append("<td width='18%'  align='center'  style='font-size:14px;border :solid 1px black;border-top:solid 1px black;'><b>" + ds.Tables[0].Rows[0].ItemArray[vc].ToString() + "</b></td>");
            }
            TBL.Append("<td width='18%'  align='center'  style='font-size:14px;border :solid 1px black;border-top:solid 2px black;'><b>" + amountdttotal + "</b></td>");
            amountdttotal = 0.00;
        }
        TBL.Append("</table>");
        view.InnerHtml = TBL.ToString();
    }

    public void showreportexcel()
    {
        DataSet ds = new DataSet();
        double amountdttotal = 0.00;
        if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_bussiness_targetrpt exe = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
            ds = exe.bussinesstargetreport(compcode, publication, adtype, uom, datefrom, todate, dateformat, userid, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt exe = new NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt();
            ds = exe.bussinesstargetreport(compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, paymade, datefrom, todate, dateformat, userid, chkaccess, extra1, extra2);
        }
        else
        {
            if (paymade == "0")
                paymade = "";
            if (edition == "--Select Edition Name--")
                edition = "";
            string procedureName = "ad_rep_bussiness_ad_rep_bussiness_amt_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, paymade, datefrom, todate, dateformat, userid, chkaccess, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }


        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        int rcount = ds.Tables[0].Rows.Count;
        StringBuilder TBL = new StringBuilder();
        string header = create_header(ds);
        TBL.Append(header.ToString());
        for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        {
            TBL.Append("<tr style='height:30px;'>");
            for (int v = 2; v < ds.Tables[0].Columns.Count; v++)
            {
                TBL.Append("<td  width='18%' class='quotationnam' align='center' style='font-size:10px;border-right:solid 1px black;border-top:solid 1px black;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
            }

        }
        TBL.Append("<tr style='height:30px;'>");
        TBL.Append("<td width='18%' class='quotationnam'  align='center'  style='font-size:16px; border-top:solid 2px black;border-bottom:solid 1px black;border-right:solid 1px black;border-left:solid 1px black;'><b>TOTAL :- </b></td>");

        for (int vc = 3; vc < ds.Tables[0].Columns.Count; vc++)
        {
            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                amountdttotal = amountdttotal + Convert.ToDouble(ds.Tables[0].Rows[z].ItemArray[vc].ToString());

                //TBL.Append("<td width='18%'  align='center'  style='font-size:14px;border :solid 1px black;border-top:solid 1px black;'><b>" + ds.Tables[0].Rows[0].ItemArray[vc].ToString() + "</b></td>");
            }
            TBL.Append("<td width='18%'  align='center'  style='font-size:14px;border :solid 1px black;border-top:solid 2px black;'><b>" + amountdttotal + "</b></td>");
            amountdttotal = 0.00;
        }
        TBL.Append("</table>");
        /*TBL.Append("<tr style='height:30px;'>");
        TBL.Append("<td width='18%' class='quotationnam'  align='center'  style='font-size:16px; border-top:solid 1px black;'><b>TOTAL:-</b></td>");
        for (int vc = 1; vc < ds.Tables[2].Columns.Count; vc++)
        {
            TBL.Append("<td width='18%'  align='center'  style='font-size:14px;border :solid 1px black;border-top:solid 1px black;'><b>" + ds.Tables[2].Rows[0].ItemArray[vc].ToString() + "</b></td>");
        }
        TBL.Append("</table>");*/
        view.InnerHtml = TBL.ToString();
        hw.WriteBreak();
        view.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public void showreportpdf()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_bussiness_targetrpt exe = new NewAdbooking.Report.Classes.ad_bussiness_targetrpt();
            ds = exe.bussinesstargetreport(compcode, publication, adtype, uom, datefrom, todate, dateformat, userid, extra1, extra2);
        }
        else if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt exe = new NewAdbooking.Report.classesoracle.ad_bussiness_targetrpt();
            ds = exe.bussinesstargetreport(compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, paymade, datefrom, todate, dateformat, userid, chkaccess, extra1, extra2);
        }
        else
        {
            string procedureName = "ad_rep_bussiness_ad_rep_bussiness_amt_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, paymade, datefrom, todate, dateformat, userid, chkaccess, extra1, extra2 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }

        else
        {
            string pdfName = "";
            int rcount = ds.Tables[0].Rows.Count;
            double[] array1 = new double[ds.Tables[0].Columns.Count - 1];
            int arrlenght = ds.Tables[0].Columns.Count - 1;
            int sno = 1;
            int pdfpage = 0;

            pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
            string name = Server.MapPath("") + "//" + pdfName;

            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
            PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD);

            try
            {

                PdfPTable tbl = new PdfPTable(1);
                tbl.DefaultCell.BorderWidth = 0;
                tbl.WidthPercentage = 100;
                tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl.addCell(new iTextSharp.text.Phrase(" Target Analysis Report ", font9));
                document.Add(tbl);

                PdfPTable tbl1 = new PdfPTable(1);
                tbl1.DefaultCell.BorderWidth = 0;
                tbl1.WidthPercentage = 100;
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl1.addCell(new iTextSharp.text.Phrase("FROM DATE :" + datefrom + "TO DATE :" + todate, font9));
                document.Add(tbl1);

                PdfPTable TBL = new PdfPTable(1);
                TBL.DefaultCell.BorderWidth = 0;
                TBL.WidthPercentage = 100;
                TBL.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                TBL.addCell(new iTextSharp.text.Phrase("RUN DATE & TIME  :" + currentdate, font9));
                TBL.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                TBL.addCell(new iTextSharp.text.Phrase("PREPARED BY  :" + username, font9));
                document.Add(TBL);


                pdfpage = ds.Tables[0].Columns.Count;

                PdfPTable tbl4 = new PdfPTable(pdfpage + 1);
                tbl4.DefaultCell.BorderWidth = 0;
                tbl4.WidthPercentage = 100;
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase("S.NO", font8));

                iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
                document.Add(p1);

                for (int c = 1; c < ds.Tables[0].Columns.Count; c++)
                {
                    if (ds.Tables[0].Columns[c].Caption == "Exec_name" || ds.Tables[0].Columns[c].Caption == "Uom_Name" || ds.Tables[0].Columns[c].Caption == "Agency_Name" || ds.Tables[0].Columns[c].Caption == "Supp_Name")
                    {
                        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Columns[c].ToString(), font8));
                    }
                    else
                    {
                        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Columns[c].ToString(), font8));
                    }
                }


                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Columns["Target"].ToString(), font8));





                for (int r = 0; r < rcount; r++)
                {
                    sno = r;
                    sno++;
                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    tbl4.addCell(new iTextSharp.text.Phrase(sno.ToString(), font8));
                    for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].Caption == "Exec_name" || ds.Tables[0].Columns[i].Caption == "Uom_Name" || ds.Tables[0].Columns[i].Caption == "Agency_Name" || ds.Tables[0].Columns[i].Caption == "Supp_Name")
                        {
                            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[r].ItemArray[i].ToString(), font8));
                        }
                        else
                        {

                            double aa = Convert.ToDouble(ds.Tables[0].Rows[r].ItemArray[i].ToString());

                            var bb = Math.Round(aa, 2);

                            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl4.addCell(new iTextSharp.text.Phrase(bb.ToString(), font8));
                        }
                    }

                    ////if (ds.Tables[1].Rows.Count == 1)
                    ////{
                    ////    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    ////    tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                    ////}
                    ////else
                    ////{
                    ////    if (r < ds.Tables[1].Rows.Count)
                    ////    {
                    ////        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    ////        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[r]["Target"].ToString(), font8));
                    ////    }
                    ////    else
                    ////    {
                    ////        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    ////        tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                    ////    }
                    ////}



                    string bh = "";

                    if (chkaccess == "E")
                    {

                        for (int t = 0; t < ds.Tables[1].Rows.Count; t++)
                        {
                            if (ds.Tables[0].Rows[r]["Exec_name"].ToString().Trim() == ds.Tables[1].Rows[t]["Exec_name"].ToString())
                            {
                                if (ds.Tables[1].Rows[t]["Target"].ToString() != "" && ds.Tables[1].Rows[t]["Target"].ToString() != "0")
                                {
                                    bh = ds.Tables[1].Rows[t]["Target"].ToString();
                                    //  TBL.Append("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[t]["Target"].ToString() + "</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t]["Target"].ToString(), font8));

                                    break;
                                }
                                else
                                {
                                    bh = "0";
                                    // TBL.Append("<td class='rep_data'align='right'>0</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase("0", font8));


                                    break;
                                }

                            }
                        }
                    }

                    if (chkaccess == "A")
                    {

                        for (int t = 0; t < ds.Tables[1].Rows.Count; t++)
                        {
                            if (ds.Tables[0].Rows[r]["Agency_Name"].ToString().Trim() == ds.Tables[1].Rows[t]["AGENCYTYPE_CODE"].ToString())
                            {
                                if (ds.Tables[1].Rows[t]["Target"].ToString() != "" && ds.Tables[1].Rows[t]["Target"].ToString() != "0")
                                {
                                    bh = ds.Tables[1].Rows[t]["Target"].ToString();
                                    //  TBL.Append("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[t]["Target"].ToString() + "</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t]["Target"].ToString(), font8));

                                    break;
                                }
                                else
                                {
                                    bh = "0";
                                    // TBL.Append("<td class='rep_data'align='right'>0</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                                    break;
                                }

                            }
                        }
                    }


                    if (chkaccess == "U")
                    {

                        for (int t = 0; t < ds.Tables[1].Rows.Count; t++)
                        {
                            if (ds.Tables[0].Rows[r]["Uom_Name"].ToString().Trim() == ds.Tables[1].Rows[t]["Exec_name"].ToString())
                            {
                                if (ds.Tables[1].Rows[t]["Target"].ToString() != "" && ds.Tables[1].Rows[t]["Target"].ToString() != "0")
                                {
                                    bh = ds.Tables[1].Rows[t]["Target"].ToString();
                                    //  TBL.Append("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[t]["Target"].ToString() + "</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t]["Target"].ToString(), font8));

                                    break;
                                }
                                else
                                {
                                    bh = "0";
                                    // TBL.Append("<td class='rep_data'align='right'>0</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                                    break;
                                }

                            }
                        }
                    }
                    if (chkaccess == "S")
                    {

                        for (int t = 0; t < ds.Tables[1].Rows.Count; t++)
                        {
                            if (ds.Tables[0].Rows[r]["Supp_Name"].ToString().Trim() == ds.Tables[1].Rows[t]["Exec_name"].ToString())
                            {
                                if (ds.Tables[1].Rows[t]["Target"].ToString() != "" && ds.Tables[1].Rows[t]["Target"].ToString() != "0")
                                {
                                    bh = ds.Tables[1].Rows[t]["Target"].ToString();
                                    //  TBL.Append("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[t]["Target"].ToString() + "</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t]["Target"].ToString(), font8));

                                    break;
                                }
                                else
                                {
                                    bh = "0";
                                    // TBL.Append("<td class='rep_data'align='right'>0</td>");
                                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                                    break;
                                }

                            }
                        }
                    }

                    //}
                    //else
                    //{
                    if (bh == "")
                    {
                        //  TBL.Append("<td class='rep_data'align='right'>0</td>");
                        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl4.addCell(new iTextSharp.text.Phrase("0", font8));

                    }
                    //}
                    //}
                    //  TBL.Append("</tr>");
                }
                document.Add(tbl4);
                document.Close();
                Response.Redirect(pdfName, false);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
            }
        }
    }
}
