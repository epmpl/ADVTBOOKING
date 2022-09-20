using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class Deal_comparisonprint_rpt : System.Web.UI.Page
{
   
    string pdateformat="";
    string all = "";
    string destination = "";
    string comp_code = "";
    string dateformat = "";
    string from_dt = "";
    string to_dt = "";
    string client = "";
    string product = "";
    string city = "";
    string agency = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string extra6 = "";
    int sr = 1;
    string rdate = "";
    string schemename = "";
    int chequecount = 0;
    string client_code = "";
    string product_code = "";
    string agency_code = "";
    Double total = 0;
    DataSet ds1 = new DataSet();
    Double rundate = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        pdateformat = Session["dateformat"].ToString();
        comp_code = Session["compcode"].ToString();
        dateformat = Session["dateformat"].ToString();
        destination = Request.QueryString["destination"].ToString();
        //dateformat = Session["dateformat"].ToString();
        from_dt = Request.QueryString["fromdate"].ToString();
        to_dt = Request.QueryString["todate"].ToString();
        product = Request.QueryString["product"].ToString();
        client = Request.QueryString["client"].ToString();
        //city = Request.QueryString["city"].ToString();
        agency = Request.QueryString["agency"].ToString();
        agency_code = Request.QueryString["agency_code"].ToString();
        product_code = Request.QueryString["product_code"].ToString();
        client_code = Request.QueryString["client_code"].ToString();

        //txtcomp1.Value = Session["compcode"].ToString();    
        rdate = System.DateTime.Now.ToString();
        //schemename = Request.QueryString["schemename"].ToString();
        ds1.ReadXml(Server.MapPath("Xml/Deal_comparison_rpt.xml"));
        if (!Page.IsPostBack)
        {
            if (destination == "0" || destination == "1")
            {
                showreport();
            }

            if (destination == "2")
            {
                showreportexcel();
            }

            if (destination == "3")
            {
                showreportpdf();
            }

        }

    }
   
    
    public string date_chk(string acc_date)
    {
        if (acc_date != "")
        {
            if (acc_date.IndexOf("") > -1)
            {
                string[] chk_str = acc_date.Split(' ');
                acc_date = chk_str[0];
            }
        }
        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            string[] arr = acc_date.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            if (arr[0].Length < 2)
                dd = "0" + arr[0];
            if (arr[1].Length < 2)
                mm = "0" + arr[1];
            acc_date = dd + "/" + mm + "/" + yy;

        }
        else
        {
            string[] arr = acc_date.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            if (arr[0].Length < 2)
                dd = "0" + arr[0];
            if (arr[1].Length < 2)
                mm = "0" + arr[1];
            acc_date = mm + "/" + dd + "/" + yy;
        }


        return acc_date;
    }


    public void showreport()
    {
        string mode = "";
        //rundate = System.DateTime.Now.ToString();
        int totalcopies = 0;
        int grandtotalcopies = 0;
        int m11 = 0;
        //StringBuilder TBL = new StringBuilder();
        DataSet ds = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print subreg = new NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print();
                //ds = subreg.rpt_sub_regprint(compcode, locid, publication, fromdate, todate, town, city, dateformat, extra1, extra2, extra3, extra4, extra5, extra6);
            }
            else
            {

                //NewAdbooking.Classes.dealcomp couprec = new NewAdbooking.Classes.dealcomp();
                //ds = couprec.rpt_imp_summary(comp_code, agency_code, product_code, client_code, from_dt, to_dt,pdateformat);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        StringBuilder TBL = new StringBuilder();
        double total = 0;

       
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");

            return;
        }
        TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='0' width='20%'>");
        TBL.Append("<tr><td  class='newfont1' align='CENTER' style='font-size:16px;' ><b>" + "GUJRAAT" + "</b></td>");
        TBL.Append("</tr>");
        TBL.Append("<tr><td>");
        TBL.Append("<table>");
        TBL.Append("<table>");
        //TBL.Append("<tr><td class='newfont1' width='400px' align='left' > LOCATION: " + Session["centername"].ToString() + "</td>");
        TBL.Append("<td class='middle312' width='200px' align='left' > FROM DATE: " + from_dt + "</td>");
        TBL.Append("<td class='middle312' width='750px' align='right' > TO DATE: " + to_dt + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("<table>");
        TBL.Append("<tr><td class='middle312' width='400px' align='left' > AGENCY :" + Request.QueryString["agency"].ToString() + "</TD>");
         ////TBL.Append("<td class='newfont1' width='200px' align='left' > FROM DATE: " + fromdate + "</td>");
        //TBL.Append("<td class='newfont1' width='600px' align='right' > RUN DATE :  " + date_chk(rundate) + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");

        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("</td></tr>");

        TBL.Append("<tr><td>");
        TBL.Append("<table>");
        //TBL.Append("<tr><td class='newfont1' width='400px' align='left' >PUBLICATION     : " + publicationname + "</td>");
        //TBL.Append("<td class='newfont1' width='200px' align='center' > AGENCY:" + agency + "</td>");
        //TBL.Append("<td class='newfont1' width='400px' align='right' > SUPPLY TYPE NAME  : " + supply_type_code + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("</td></tr>");

        TBL.Append("</table>");
        TBL.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:0px;margin-top:20px;' cellspacing='0px' cellpadding = '0px' border='0' width='100%'>");

        //TBL.Append("<tr ><td class='middle31' align='left' width='25%'>");
        //TBL.Append("S.No." + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("DEAL NUMBER" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("AGENCY NAME" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("CLIENT NAME" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("PRODUCT NAME" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("START DATE" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("END DATE" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("AMOUNT/SIZE" + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        int s_no = 1;
        TBL.Append("<table style ='margin-top:0px;'cellspacing='0px' cellpadding = '0px' border='0' width='100%'>");
        for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
        {

            //TBL.Append("<tr font-size='10' font-family='Verdana'>");
            //TBL.Append("<td class='newfont1'align='left' width='25%'>");
            //TBL.Append(s_no.ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["Deal_code"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["agency_name"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["cust_name"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left'  width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["product_code"].ToString() + "</td>");




            TBL.Append("<td class='newfont1'align='left' width='10%'>");


            if (ds.Tables[0].Rows[r]["from_date"].ToString() == "")
            {
                TBL.Append((ds.Tables[0].Rows[r]["from_date"].ToString()) + "</td>");
            }
            else
            {
                TBL.Append(date_chk(ds.Tables[0].Rows[r]["from_date"].ToString()) + "</td>");
            }
            TBL.Append("<td class='newfont1'align='left' width='10%'>");


            if (ds.Tables[0].Rows[r]["till_date"].ToString() == "")
            {
                TBL.Append((ds.Tables[0].Rows[r]["til_date"].ToString()) + "</td>");
            }
            else
            {
                TBL.Append(date_chk(ds.Tables[0].Rows[r]["till_date"].ToString()) + "</td>");
            }

            TBL.Append("<td class='newfont1'align='left'  width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["contract_amount"].ToString() + "</td>");

           //total += Convert.ToDouble(ds.Tables[0].Rows[r]["COLONY"].ToString());

            TBL.Append("</tr>");
            s_no++;
        }

        //TBL.Append("<tr><td colspan='4'>");
        //TBL.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:1px;margin-top:20px;'  width='100%'>");
        //TBL.Append("<tr font-size='10' font-family='Verdana'>");
        //TBL.Append("<td class='newfont1'align='left' width='30%'>");
        //TBL.Append("<b>Total Copy<b>" + "</td>");
        //TBL.Append("<td class='newfont1'align='right' style='padding-right:190px;' width='70%'>");
        //TBL.Append(total.ToString() + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");
        TBL.Append("</td></tr>");
        TBL.Append("</table>");
        subregrepDiv.InnerHtml = TBL.ToString();
        printbutton.Attributes.Add("onclick", "javascript:window.open('Deal_comparisonprintview_rpt.aspx?destination=" + destination + "&fromdate=" + from_dt + "&todate=" + to_dt + "&product=" + product + "&client=" + client + "&agency=" + agency + "&agency_code=" + agency_code + "&product_code=" + product_code + "&client_code=" + client_code + "')");
        // printbutton.Attributes.Add("onclick", "javascript:window.open('crm_rpt_subscriber_register_walkin_print1.aspx?destination=" + destination + "&fromdate=" + fromdate + "&locid=" + locid + "&publication=" + publication + "&city=" + city + "&town=" + town + "&todate=" + todate + "')");

    }

    public void showreportexcel()
      {
        string mode = "";
        //rundate = System.DateTime.Now.ToString();
        int totalcopies = 0;
        int grandtotalcopies = 0;
        int m11 = 0;
        //StringBuilder TBL = new StringBuilder();
        DataSet ds = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print subreg = new NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print();
                //ds = subreg.rpt_sub_regprint(compcode, locid, publication, fromdate, todate, town, city, dateformat, extra1, extra2, extra3, extra4, extra5, extra6);
            }
            else
            {

                //NewAdbooking.Classes.dealcomp couprec = new NewAdbooking.Classes.dealcomp();
                //ds = couprec.rpt_imp_summary(comp_code, agency_code, product_code, client_code, from_dt, to_dt,pdateformat);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        StringBuilder TBL = new StringBuilder();
        double total = 0;

       
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");

            return;
        }
        TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='0' width='20%'>");
        TBL.Append("<tr><td  class='newfont1' align='CENTER' style='font-size:16px;' ><b>" + "GUJRAAT" + "</b></td>");
        TBL.Append("</tr>");
        TBL.Append("<tr><td>");
        TBL.Append("<table>");
        TBL.Append("<table>");
        //TBL.Append("<tr><td class='newfont1' width='400px' align='left' > LOCATION: " + Session["centername"].ToString() + "</td>");
        TBL.Append("<td class='newfont1' width='200px' align='left' colspan=5 > FROM DATE: " + from_dt + "</td>");
        TBL.Append("<td class='newfont1' width='1000px' align='right' > TO DATE: " + to_dt + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("<table>");
        TBL.Append("<tr><td class='newfont1' width='400px' align='left' > AGENCY :" + Request.QueryString["agency"].ToString()+"</TD>");
         ////TBL.Append("<td class='newfont1' width='200px' align='left' > FROM DATE: " + fromdate + "</td>");
        //TBL.Append("<td class='newfont1' width='600px' align='right' > RUN DATE :  " + date_chk(rundate) + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");

        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("</td></tr>");

        TBL.Append("<tr><td>");
        TBL.Append("<table>");
        //TBL.Append("<tr><td class='newfont1' width='400px' align='left' >PUBLICATION     : " + publicationname + "</td>");
        //TBL.Append("<td class='newfont1' width='200px' align='center' > AGENCY:" + agency + "</td>");
        //TBL.Append("<td class='newfont1' width='400px' align='right' > SUPPLY TYPE NAME  : " + supply_type_code + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        TBL.Append("</td></tr>");

        TBL.Append("</table>");
        TBL.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:0px;margin-top:20px;' cellspacing='0px' cellpadding = '0px' border='0' width='100%'>");

        //TBL.Append("<tr ><td class='middle31' align='left' width='25%'>");
        //TBL.Append("S.No." + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("DEAL NUMBER" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("AGENCY NAME" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("CLIENT NAME" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("PRODUCT NAME" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("START DATE" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("END DATE" + "</td>");
        TBL.Append("<td class='middle31' align='left' width='10%'>");
        TBL.Append("AMOUNT/SIZE" + "</td>");
        TBL.Append("</tr>");
        TBL.Append("</table>");
        int s_no = 1;
        TBL.Append("<table style ='margin-top:0px;'cellspacing='0px' cellpadding = '0px' border='0' width='100%'>");
        for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
        {

            //TBL.Append("<tr font-size='10' font-family='Verdana'>");
            //TBL.Append("<td class='newfont1'align='left' width='25%'>");
            //TBL.Append(s_no.ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["Deal_code"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["agency_name"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["cust_name"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left'  width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["product_code"].ToString() + "</td>");




            TBL.Append("<td class='newfont1'align='left' width='10%'>");


            if (ds.Tables[0].Rows[r]["from_date"].ToString() == "")
            {
                TBL.Append((ds.Tables[0].Rows[r]["from_date"].ToString()) + "</td>");
            }
            else
            {
                TBL.Append(date_chk(ds.Tables[0].Rows[r]["from_date"].ToString()) + "</td>");
            }
            TBL.Append("<td class='newfont1'align='left' width='10%'>");


            if (ds.Tables[0].Rows[r]["till_date"].ToString() == "")
            {
                TBL.Append((ds.Tables[0].Rows[r]["till_date"].ToString()) + "</td>");
            }
            else
            {
                TBL.Append(date_chk(ds.Tables[0].Rows[r]["till_date"].ToString()) + "</td>");
            }

            TBL.Append("<td class='newfont1'align='left'  width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["contract_amount"].ToString() + "</td>");

           //total += Convert.ToDouble(ds.Tables[0].Rows[r]["COLONY"].ToString());

            TBL.Append("</tr>");
            s_no++;
        }

        //TBL.Append("<tr><td colspan='4'>");
        //TBL.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:1px;margin-top:20px;'  width='100%'>");
        //TBL.Append("<tr font-size='10' font-family='Verdana'>");
        //TBL.Append("<td class='newfont1'align='left' width='30%'>");
        //TBL.Append("<b>Total Copy<b>" + "</td>");
        //TBL.Append("<td class='newfont1'align='right' style='padding-right:190px;' width='70%'>");
        //TBL.Append(total.ToString() + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");
        TBL.Append("</td></tr>");
        TBL.Append("</table>");
        subregrepDiv.InnerHtml = TBL.ToString();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        hw.WriteBreak();
        subregrepDiv.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
        printbutton.Attributes.Add("onclick", "javascript:window.open('Deal_comparisonprintview_rpt.aspx?destination=" + destination + "&fromdate=" + from_dt + "&todate=" + to_dt + "&product=" + product + "&client=" + client + "&agency=" + agency + "&agency_code=" + agency_code + "&product_code=" + product_code + "&client_code=" + client_code + "')");
        // printbutton.Attributes.Add("onclick", "javascript:window.open('crm_rpt_subscriber_register_walkin_print1.aspx?destination=" + destination + "&fromdate=" + fromdate + "&locid=" + locid + "&publication=" + publication + "&city=" + city + "&town=" + town + "&todate=" + todate + "')");

    }

    ///here is a coding for pdf
    private void showreportpdf()
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

        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);

        try
        {
            //if (impdue == "yes")
            //{
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print subreg = new NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print();
                //ds = subreg.rpt_sub_regprint(compcode, locid, publication, fromdate, todate, town, city, dateformat, extra1, extra2, extra3, extra4, extra5, extra6);
            }
            else
            {

                //NewAdbooking.Classes.dealcomp couprec = new NewAdbooking.Classes.dealcomp();
                //ds = couprec.rpt_imp_summary(comp_code, agency_code, product_code, client_code, from_dt, to_dt, pdateformat);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                //rundate = System.DateTime.Now.ToString();
                PdfPTable tb1 = new PdfPTable(4);
                float[] xy1 = { 20, 20, 20, 20};
                tb1.DefaultCell.BorderWidth = 0;
                tb1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
               
                tb1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tb1.DefaultCell.Colspan = 4;
                tb1.addCell(new iTextSharp.text.Phrase("", font10));
                tb1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tb1.setWidths(xy1);
                //tb1.DefaultCell.Border = Rectangle.LEFT | Rectangle.LEFT;
                tb1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //tb1.addCell(new iTextSharp.text.Phrase(compname, font10));
                //tb1.addCell(new iTextSharp.text.Phrase(reportname, font10));
                tb1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tb1.DefaultCell.Colspan = 5;
                tb1.addCell(new iTextSharp.text.Phrase("GUJRAAT", font10));

                //tb1.DefaultCell.Colspan = 1;
                //tb1.addCell(new iTextSharp.text.Phrase("Publication:" + pub_name, font10));
                tb1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tb1.DefaultCell.Colspan = 3;
                tb1.addCell(new iTextSharp.text.Phrase("Fromdate:" + date_chk(from_dt), font10));
                tb1.DefaultCell.Colspan = 1;
                tb1.addCell(new iTextSharp.text.Phrase("Todate:" +date_chk( to_dt), font10));
                //tb1.DefaultCell.Colspan = 1;
                //tb1.addCell(new iTextSharp.text.Phrase("Rundate:" + date_chk(rundate), font10));
                tb1.DefaultCell.Colspan = 2;
                tb1.addCell(new iTextSharp.text.Phrase("", font10));

                document.Add(tb1);


                PdfPTable datatable1 = new PdfPTable(7);
                float[] set_width = { 5, 5, 5, 5, 5, 5, 5};
                datatable1.setWidths(set_width);
                //datatable1.DefaultCell.Padding = 3;
                datatable1.WidthPercentage = 100; // percentage
                datatable1.DefaultCell.BorderWidth = 0;
                datatable1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                datatable1.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED;
                //datatable1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //datatable1.DefaultCell.Colspan = 1;
                //datatable1.addCell(new iTextSharp.text.Phrase("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));

                datatable1.DefaultCell.Colspan = 9;
                datatable1.addCell(new iTextSharp.text.Phrase("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));

                datatable1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //datatable1.DefaultCell.Colspan = 3;
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("DEAL NUMBER", font10));
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("AGENCY NAME", font10));
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("CLIENT NAME", font10));
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("PRODUCT NAME", font10));
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("START DATE", font10));
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("END DATE", font10));
                datatable1.DefaultCell.Colspan = 1;
                datatable1.addCell(new iTextSharp.text.Phrase("AMOUNT/SIZE", font10));
             


                datatable1.DefaultCell.Colspan = 9;
                datatable1.addCell(new iTextSharp.text.Phrase("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));

                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {


                    datatable1.DefaultCell.Colspan = 1;
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["Deal_code"].ToString(), font8));
                    datatable1.DefaultCell.Colspan = 1;
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["agency_name"].ToString(), font8));
                    datatable1.DefaultCell.Colspan = 1;
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["cust_name"].ToString(), font8));
                    datatable1.DefaultCell.Colspan = 1;
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["product_code"].ToString(), font8));

                    if (ds.Tables[0].Rows[m]["from_date"].ToString() == "")
                    {
                        datatable1.DefaultCell.Colspan = 1;
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["from_date"].ToString(), font8));
                    }
                    else
                    {
                        datatable1.DefaultCell.Colspan = 1;
                        datatable1.addCell(new iTextSharp.text.Phrase(date_chk(ds.Tables[0].Rows[m]["from_date"].ToString()), font8));
                    }
                    if (ds.Tables[0].Rows[m]["till_date"].ToString() == "")
                    {
                        datatable1.DefaultCell.Colspan = 1;
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["till_date"].ToString(), font8));

                    }
                    else
                    {
                        datatable1.DefaultCell.Colspan = 1;
                        datatable1.addCell(new iTextSharp.text.Phrase(date_chk(ds.Tables[0].Rows[m]["till_date"].ToString()), font8));
                    }
                        datatable1.DefaultCell.Colspan = 1;
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["contract_amount"].ToString(), font8));
                  

                }
                datatable1.DefaultCell.Colspan = 9;
                datatable1.addCell(new iTextSharp.text.Phrase("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font10));
                document.Add(datatable1);

                document.Close();
                Response.Redirect(pdfName, false);
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria Is Not Valid');window.close();</script>");
                return;
            }
        }
        catch (Exception ex)
        {

            Console.Error.WriteLine(ex.StackTrace);

        }
    }
    ///here it ends

    }
