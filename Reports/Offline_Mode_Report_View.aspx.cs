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
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;
//using System.Linq;
//using System.Xml.Linq;
using System.Text;

public partial class Offline_Mode_Report_View : System.Web.UI.Page
{
    string from_date = "", to_date = "";
    string  dateformat = "", Run_Date = "", day = "", month = "", year = "", destination = "";
    string heading = "", lbl_from = "", lbl_to = "", lbl_run = "", comp_name="";
    double tot_adamt = 0, tot_depamt=0;
    string name1 = "", name2 = "", name3 = "";
 
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;

    int maxlimit = 15;
    int a = 0;
    int sno = 1;
    string chk_excel = "", agency_code = "", agency_name = "", status="";
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            dateformat = hiddendateformat.Value;

            //DataSet brk = new DataSet();
           // brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
           // maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[51].ToString());
            browser = Request.Browser;

            ver = (float)(browser.MajorVersion + browser.MinorVersion);
            Ajax.Utility.RegisterTypeForAjax(typeof(Offline_Mode_Report_View));

            ds = (DataSet)Session["offline_report"];

            comp_name = ds.Tables[0].Rows[0]["companyname"].ToString();

            string prm = Session["offline_parameter"].ToString();
            string[] prm_Array = new string[15];
            prm_Array = prm.Split('~');


            from_date = prm_Array[1];
            to_date = prm_Array[3];
            destination = prm_Array[5];
            agency_code = prm_Array[7];
            agency_name = prm_Array[9];
            chk_excel = prm_Array[11];
            status = prm_Array[13];
           
            DataSet ds_head = new DataSet();
            ds_head.ReadXml(Server.MapPath("XML/RO_Agency_Wise.xml"));
            
           lblHeading.Text = "Offline Mode Report";//agency wise detail
                
          
            heading = lblHeading.Text;
            lblFromDate.Text = ds_head.Tables[2].Rows[0].ItemArray[4].ToString();
            lblToDate.Text = ds_head.Tables[2].Rows[0].ItemArray[5].ToString();
            lblRunningDate.Text = ds_head.Tables[2].Rows[0].ItemArray[6].ToString();
            lbl_from = lblFromDate.Text;
            lbl_to = lblToDate.Text;
            lbl_run = lblRunningDate.Text;




            Run_Date = DateTime.Now.ToString();
            DateTime dt = Convert.ToDateTime(Run_Date.ToString());

            if (dateformat == "dd/mm/yyyy")
            {
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = day + "/" + month + "/" + year ;

            }
            else if (dateformat == "mm/dd/yyyy")
            {

                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = month + "/" + day + "/" + year;

            }
            else if (dateformat == "yyyy/mm/dd")
            {

                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                Run_Date = year + "/" + month + "/" + day ;
            }
            lblDate.Text = from_date;
            lblTDate.Text = to_date;
            lblRdate.Text = Run_Date;
            Compname.Text = comp_name;
            if (!Page.IsPostBack)
            {
                btnprint.Attributes.Add("onclick", "javascript:window.print();");

                if (destination == "0" || destination == "1" || destination == "destination")
                {
                    onscreen();
                }
                else if (destination == "4")
                {
                    excel();
                }
                else if (destination == "3")
                {
                    pdf();
                }

            }
        }

    }
    public string decimal_fun(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal.IndexOf(".") > -1)
        {
            final_decimal = str_decimal;
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = str_decimal;
        }
        return final_decimal;


    }
    [Ajax.AjaxMethod]
    public void open_file(string file_name)
    {
        string SetupLink = "";
        string strFileType = "";
        SetupLink = Server.MapPath("../paymentattachment/");

        if (file_name != "" && file_name != "qbc.aspx")
        {
            string FilePath = SetupLink + file_name;
           // Response.AppendHeader("Content-Disposition", "attachment; filename=SailBig.jpg");
            Context.Response.ContentType = "*/*";
            //Response.ContentType = "*/*";
            Context.Response.Clear();
            Context.Response.ClearContent();

            int s = file_name.LastIndexOf(".");
            int t = file_name.Length - s;
            strFileType = file_name.Substring(s, t);
            if (strFileType.ToUpper() == ".TXT")
                Context.Response.ContentType = "text/html";
            else
                Context.Response.ContentType = "application/octet-stream";


            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file_name);
            // Response.TransmitFile(FilePath);
            Context.Response.AppendHeader("Content-Length", file_name.Length.ToString());
            Context.Response.WriteFile(file_name);
            Context.Response.Write(file_name);
            Context.Response.End();

        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        btnprint.Visible = false;
        onscreen_print();
    }

    public void onscreen_print()
    {
        rptDiv.InnerHtml = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            
            
                int cont = ds.Tables[0].Rows.Count;

                int ct = 0;
                int fr = maxlimit;
                int rcount = ds.Tables[0].Rows.Count;
                int pagec = rcount % maxlimit;
                int pagecount = rcount / maxlimit;
                if (pagec > 0)
                    pagecount = pagecount + 1;

                // string tbl = "";
                StringBuilder tbl = new StringBuilder();
             //   tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' >");

                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    if (browser.Browser == "Firefox")
                    {


                        tbl.Append( "</table></P>");
                        if (p == pagecount || p == 0)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-after:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                    }

                    else if (browser.Browser == "IE")
                    {


                        tbl.Append("</table></P>");
                        if (p == pagecount - 1)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");


                    }

                  //  tbl.Append("</table>");
                   // tbl.Append("<table cellspacing='0px' cellpadding='0px' border='0' width='100%' class='break'>");
                    tbl.Append("<tr valign='top'>");
                    tbl.Append("<td class='middle111' align='right' colspan='10'>" + "Page  " + s + "  of  " + pagecount);
                    tbl.Append("</td></tr>");
                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'>SNo.</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Receipt</br>No.</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Date</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Publish</br>Date</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Client</td>");
                    tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>Ad</br>Amt</td>");
                    tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>Deposit</br>Amt</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Status</td>");
                    tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Attachment</td>");
                    tbl.Append("</tr>");


                    for (int i = ct; i < ds.Tables[0].Rows.Count && i < fr; i++)
                    {

                        a = i;
                        a = a + 1;

                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data'>" + a.ToString() + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Receipt_No"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Booking_Date"].ToString() + "</td>");
                        tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agency"].ToString() + "</td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Client"].ToString() + "</td>");
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[0].Rows[i]["Ad_Amt"].ToString()) + "</td>");
                        if (ds.Tables[0].Rows[i]["Ad_Amt"].ToString() != "")
                            tot_adamt = tot_adamt + Convert.ToDouble(ds.Tables[0].Rows[i]["Ad_Amt"].ToString());
                        tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[0].Rows[i]["dep_amt"].ToString()) + "</td>");
                        if (ds.Tables[0].Rows[i]["dep_amt"].ToString() != "")
                            tot_depamt = tot_depamt + Convert.ToDouble(ds.Tables[0].Rows[i]["dep_amt"].ToString());
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Status"].ToString() + "</td>");
                        //tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'><a href=\"matterpreview.aspx?file_name=" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "\" >" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "</a></td>");
                        //tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'><a ><span onclick=open_file('" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "');>" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "</span></a></td>");
                        tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'><u><span style='cursor:hand' onclick=open_file('" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "');>" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "</span></u></td>");




                        tbl.Append("</tr>");
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;
                }
                tbl.Append("<tr>");
                tbl.Append("<td colspan='6'  class='middle31new' align='left'>Total</td>");
                tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_adamt.ToString()) + "</td>");
                tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_depamt.ToString()) + "</td>");
                tbl.Append("<td colspan='2'  class='middle31new'>&nbsp;</td>");
                tbl.Append("</tr>");

              //  tbl.Append("</table>");


                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");

                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl.Append("</table></P>");

                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table>");

                    }
                }  
                rptDiv.Visible = true;
                rptDiv.InnerHtml = tbl.ToString();
            
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
    private void onscreen()
    {
       
            StringBuilder tbl = new StringBuilder();

            tbl.Append("<table cellspacing='0px' cellpadding='0px' border='0' width='100%'>");
            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new'>SNo.</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Receipt</br>No.</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Booking</br>Date</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Publish</br>Date</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Agency</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Client</td>");
            tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>Ad</br>Amt</td>");
            tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>Deposit</br>Amt</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Status</td>");
            tbl.Append("<td align='left' style=\"padding-left:4px\"  class='middle31new'>Attachment</td>");
            tbl.Append("</tr>");

            int sno = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sno = sno + 1;

                tbl.Append("<tr>");
                tbl.Append("<td  class='rep_data'>" + sno + "</td>");
                tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Receipt_No"].ToString() + "</td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Booking_Date"].ToString() + "</td>");
                tbl.Append("<td align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Agency"].ToString() + "</td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Client"].ToString() + "</td>");
                tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[0].Rows[i]["Ad_Amt"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["Ad_Amt"].ToString() != "")
                    tot_adamt = tot_adamt + Convert.ToDouble(ds.Tables[0].Rows[i]["Ad_Amt"].ToString());
                tbl.Append("<td  align='right' style=\"padding-left:4px\"  class = 'rep_data'>" + decimal_fun(ds.Tables[0].Rows[i]["dep_amt"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["dep_amt"].ToString() != "")
                    tot_depamt = tot_depamt + Convert.ToDouble(ds.Tables[0].Rows[i]["dep_amt"].ToString());
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'>" + ds.Tables[0].Rows[i]["Status"].ToString() + "</td>");
                //tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'><a href=\"matterpreview.aspx?file_name=" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "\" >" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "</a></td>");
                tbl.Append("<td  align='left' style=\"padding-left:4px\"  class = 'rep_data'><u><span style='cursor:hand' onclick=open_file('" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "');>" + ds.Tables[0].Rows[i]["Attachment"].ToString() + "</span></u></td>");
                tbl.Append("</tr>");               
            }
            tbl.Append("<tr>");
            tbl.Append("<td colspan='6'  class='middle31new' align='left'>Total</td>");
            tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_adamt.ToString()) + "</td>");
            tbl.Append("<td align='right' style=\"padding-left:4px\"  class='middle31new'>" + decimal_fun(tot_depamt.ToString()) + "</td>");
            tbl.Append("<td colspan='2'  class='middle31new'>&nbsp;</td>");
            tbl.Append("</tr>");
            tbl.Append("</table>");
            rptDiv.Visible = true;
            rptDiv.InnerHtml = tbl.ToString();
    }
    private void pdf()
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();
        int NumColumns = 0;
       
            NumColumns = 10;
       
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);


        try
        {


            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(comp_name, font9));
            tbl.addCell(new Phrase(heading, font9));
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);

            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            tbl1.WidthPercentage = 100;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(lbl_from, font10));
            tbl2.addCell(new Phrase(from_date.ToString(), font11));
            tbl2.addCell(new Phrase(lbl_to, font10));
            tbl2.addCell(new Phrase(to_date.ToString(), font11));
            tbl2.addCell(new Phrase(lbl_run, font10));
            tbl2.addCell(new Phrase(Run_Date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase("SNo.", font10));
            datatable.addCell(new Phrase("Receipt No.", font10));
            datatable.addCell(new Phrase("Booking Date", font10));
            datatable.addCell(new Phrase("Publish Date", font10));
            datatable.addCell(new Phrase("Agency", font10));
            datatable.addCell(new Phrase("Client", font10));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable.addCell(new Phrase("Ad Amt", font10));
            datatable.addCell(new Phrase("Deposit Amt", font10));
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase("Status", font10));
            datatable.addCell(new Phrase("Attachment", font10));
                
               
            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());
            document.Add(p2);


            int row = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {



                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Receipt_No"].ToString(), font11));
                   
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Booking_Date"].ToString(), font11));
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                   
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    
                 datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                   
                    datatable.addCell(new Phrase(decimal_fun(ds.Tables[0].Rows[row]["Ad_Amt"].ToString()), font11));
                datatable.addCell(new Phrase(decimal_fun(ds.Tables[0].Rows[row]["dep_amt"].ToString()), font11));

               datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                      datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Attachment"].ToString(), font11));
               
                    if (ds.Tables[0].Rows[row]["Ad_Amt"].ToString() != "")
                    tot_adamt = tot_adamt + Convert.ToDouble(ds.Tables[0].Rows[row]["Ad_Amt"].ToString());

                
                if (ds.Tables[0].Rows[row]["dep_amt"].ToString() != "")
                    tot_depamt = tot_depamt + Convert.ToDouble(ds.Tables[0].Rows[row]["dep_amt"].ToString());


                

                row++;

            }
            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("Total", font10));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font11));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(decimal_fun(tot_adamt.ToString()), font10));
                datatable.addCell(new Phrase(decimal_fun(tot_depamt.ToString()), font10));
                datatable.addCell(new Phrase("", font11));
                datatable.addCell(new Phrase("", font10));
                datatable.DefaultCell.Colspan = NumColumns;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________", font10));
                
          
                document.Add(datatable);
            


            document.Close();

            Response.Redirect(pdfName);



        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    private void excel()
    {

        int m11 = 0;
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        if (chk_excel == "1")
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        }
        else
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        }

        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = "SNo.";
        DataGrid1.Columns.Add(nameColumn0);

        

            BoundColumn nameColumn = new BoundColumn();
            nameColumn.HeaderText = "Receipt No.";
            nameColumn.DataField = "Receipt_No";
            name1 = name1 + "," + "Receipt No.";
            name2 = name2 + "," + "Receipt_No";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn);

            
                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Booking Date";
                nameColumn1.DataField = "Booking_Date";

                name1 = name1 + "," + "Booking Date";
                name2 = name2 + "," + "Booking_Date";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Publish Date";
                nameColumn2.DataField = "Ins.date";

                name1 = name1 + "," + "Publish Date";
                name2 = name2 + "," + "Ins.date";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);
           
            

            BoundColumn nameColumn4 = new BoundColumn();
            nameColumn4.HeaderText = "Agency";
            nameColumn4.DataField = "Agency";

            name1 = name1 + "," + "Agency";
            name2 = name2 + "," + "Agency";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn4);



            BoundColumn nameColumn6 = new BoundColumn();
            nameColumn6.HeaderText = "Client";
            nameColumn6.DataField = "Client";

            name1 = name1 + "," + "Client";
            name2 = name2 + "," + "Client";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn6);

            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "Ad Amt";
            nameColumn7.DataField = "Ad_Amt";

            name1 = name1 + "," + "Ad Amt";
            name2 = name2 + "," + "Ad_Amt";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);

            BoundColumn nameColumn9 = new BoundColumn();
            nameColumn9.HeaderText = "Deposit Amt";
            nameColumn9.DataField = "dep_amt";

            name1 = name1 + "," + "Deposit Amt";
            name2 = name2 + "," + "dep_amt";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn9);

            BoundColumn nameColumn10 = new BoundColumn();
            nameColumn10.HeaderText = "Status";
            nameColumn10.DataField = "Status";

            name1 = name1 + "," + "Status";
            name2 = name2 + "," + "Status";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn10);

            BoundColumn nameColumn11 = new BoundColumn();
            nameColumn11.HeaderText = "Attachment";
            nameColumn11.DataField = "Attachment";

            name1 = name1 + "," + "Attachment";
            name2 = name2 + "," + "Attachment";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn11);

         

            DataGrid1.DataSource = ds;
            if (chk_excel == "1")
            {

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                DataGrid1.ShowHeader = true;
                DataGrid1.ShowFooter = true;
                DataGrid1.DataBind();

                hw.Write("<p <table border=\"1\"><tr><td colspan=\"10\"align=\"center\"><b>" + comp_name + "</b></td></tr>");
                hw.Write("<p <tr><td colspan=\"10\"align=\"center\"><b>" + heading + "</b></td></tr>");

                hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "From Date:" + from_date + "</b></td><td colspan=\"3\"align=\"center\"><b>" + "To Date:" + to_date + "</b></td><td colspan=\"4\"align=\"right\"><b>" + "Run Date:" + Run_Date + "</b></td></tr>");
                //hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>" + "From Date:" + txtfromdate.Text + "</b></td><td colspan=\"4\"align=\"center\"><b>" + "To Date:" + txttodate.Text + "</b></td></tr>");
                //hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>" + "Data in Row:" + drpdrp1.SelectedItem.Text + "</b></td><td colspan=\"4\"align=\"center\"><b>" + "Data in Column:" + drpdrp2.SelectedItem.Text + "</b></td></tr>");
                   
                /*hw.Write("<p align=\"left\"><b>" + comp_name + "</b>");
                hw.Write("<p align=\"left\"><b>From Date:</b>" + from_date + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>To Date:</b>" + to_date);
                hw.Write("<p align=\"left\"><b>Run Date:</b>" + Run_Date + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>" + heading + "<b>");*/
                hw.WriteBreak();
                DataGrid1.RenderControl(hw);

                Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='6' align=\"left\">Total</td><td align=\"right\" >" + tot_adamt + "</td><td align=\"right\" >" + tot_depamt + "</td></tr></table>"));
            }
            else
            {

                string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                string[][] colProperties ={ names, captions, formats };

                QueryToCSV(ds, colProperties);
            }





            StringBuilder TBL = new StringBuilder();
            int cont = ds.Tables[0].Rows.Count;
        
            if (ds.Tables[0].Rows.Count > 0)
            {
                TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='1' width='100%'>");
                // TBL = TBL + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                //=====================================For column Name ===============================================//

                TBL.Append("<tr><td class='middle31' align='left' width='5%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='9%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='10%'></b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='10%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='13%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='13%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[5].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='10%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='10%'><b> ");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[7].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='10%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></td>");
                TBL.Append("<td class='middle31' align='left' width='10%'><b>");
                TBL.Append(ds.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></td>");
                
                TBL.Append("</tr>");
                // ======================================= For values ===================================================


                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {



                    TBL.Append("<tr font-size='10' font-family='Arial'>");

                    
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Receipt_No"].ToString() + "</td>");

                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Booking_Date"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Ins.Date"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Agency"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Client"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Ad_amt"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='center'>");
                    TBL.Append(ds.Tables[0].Rows[m]["dep_Amt"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Status"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Attachment"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    TBL.Append(ds.Tables[0].Rows[m]["Companyname"].ToString() + "</td>");
                   // TBL.Append("<td class='newfont1'align='left'>");
                    
                    
                    TBL.Append("</tr>");

                    rptDiv.InnerHtml = TBL.ToString();

                    m11++;
                }
            }
        


        
        
        
        
        Response.Flush();
        Response.End();


    }
    private void QueryToCSV(DataSet dr, string[][] colProperties)
    {
        if (colProperties.Length > 0)
        {
            int counter;
            Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
            for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
            {
                counter = 0;
                Response.Write("\"");
                foreach (String column in colProperties[0])
                {
                    //dr.Tables[0].Rows[i].
                    Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                    if (counter < colProperties[0].Length - 1)
                    {
                        Response.Write("\",\"");
                    }
                    counter += 1;
                }
                Response.Write("\"\n");
            }
            //dr.Close();
            //tw.Close();
        }
    }
    private int getcolindex(DataSet ds, string col)
    {
        int i;
        for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
        {
            if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
            {
                goto td5;

            }
        }
    td5:
        return i;

    }


    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "SNo.") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }



            string check2 = e.Item.Cells[6].Text;
            string check3 = e.Item.Cells[7].Text;

            if (check2 != "Ad Amt")
            {
                if (check2 != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[6].Text;
                    tot_adamt = tot_adamt + Convert.ToDouble(grossamt);
                   
                }
            }
            if (check3 != "Deposit Amt")
            {
                if (check3 != "&nbsp;")
                {


                    string grossamt = e.Item.Cells[7].Text;
                    tot_depamt = tot_depamt + Convert.ToInt64(grossamt);
                   
                }
            }
           



    }
}
