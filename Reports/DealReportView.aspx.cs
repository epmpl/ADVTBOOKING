using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
public partial class DealReportView : System.Web.UI.Page
{
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
    DataSet ds = new DataSet();
   
    string destination = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string fromdt = "";
    string dateto = "";
    string advtype = "All";
    string dealtype = "All";
    int snoex = 1;

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
        Ajax.Utility.RegisterTypeForAjax(typeof(DealReportView));
        ds = (DataSet)Session["delrep"];
        string prm = Session["rep_delrep"].ToString();
        string[] prm_Array = new string[15];
        prm_Array = prm.Split('~');
        destination = prm_Array[1];
        fromdt = prm_Array[3];
        dateto = prm_Array[5];
        if (prm_Array[7] != "--Select Ad Type--")
        advtype = prm_Array[7];
        if (prm_Array[9] != "-Select Deal-")
        dealtype = prm_Array[9];

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = day + "/" + month + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = month + "/" + day + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + month + "/" + day;

                }



        if (!IsPostBack)
        {
            btnprint.Attributes.Add("OnClick", "javascript:return openprintpage();");
            if (destination == "1" || destination == "0")
            {
                onscreen();
            }
            else if (destination == "4")
            {
                excel();

            }
            else
                if (destination == "3")
                {
                    pdf();
                }
        }
    }
    private void onscreen()
    {
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/DealReport.xml"));

        cmpnyname.Text = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
        heading.Text = dsxml.Tables[0].Rows[0].ItemArray[13].ToString();

        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        lblfrom.Text = fromdt;
        lblto.Text = dateto;
        lbladtype.Text = advtype;
        lbldealtype.Text = dealtype;
        lbldate.Text = date;

       int cont = ds.Tables[0].Rows.Count;
            
            StringBuilder tbl = new StringBuilder();
            tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0' class='dealreport'>");
            tbl.Append("<tr><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td><td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[16].ToString() + "</td>");
            tbl.Append("<td class='dealreport' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[17].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[18].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[19].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[20].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[21].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[22].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[23].ToString() + "</td><td class='dealreport'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[24].ToString() + "</td>");
            tbl.Append("</tr>");   
            //hiddenascdesc.Value = "";
            int i1 = 1;
            for (int i = 0; i < cont; i++)
            {
               
                tbl.Append("<tr >");
                tbl.Append("<td class='rep_data' width='3%'>");
                tbl.Append(i1++.ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["DEAL_NO"] + "</td>");


                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["DEAL_NAME"] + "</td>");

                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append("" + "</td>");//DEAL DATE


                tbl.Append("<td class='rep_data' align='right' width='3%'>");
                tbl.Append(ds.Tables[0].Rows[i]["DEAL_TYPE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["FROM_DATE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["TILL_DATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["TOTAL_VALUE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["TOTAL_VOLUM"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left'  >");
                tbl.Append(ds.Tables[0].Rows[i]["AGENCY_NAME"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='3%' >");
                tbl.Append(ds.Tables[0].Rows[i]["CLIENT_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["PACKAGECODE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["CARD_RATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["PREMIUM_CODE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["CONTRACT_RATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["DISCPER"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["DISCTYPE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["INSERTION"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["MIN_SIZE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["MAX_SIZE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["VALUEFROM"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["VALUETO"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["RATE_CODE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["REMARKS"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["APPROVED"].ToString() + "</td>");

                 tbl.Append("</tr>");

            }
            tbl.Append("<tr >");
            tbl.Append("<td colspan='25' style='border-top:solid 1px black' ></tr>");
            tbl.Append("</table>");
           // tbl.Append("<tr><td class='middle31new'colspan='20'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
           
            tblgrid.InnerHtml = tbl.ToString();
    }
    private void excel()
    {
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/DealReport.xml"));

        string cpn = "";
        cpn = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        heading.Text = dsxml.Tables[0].Rows[0].ItemArray[13].ToString();

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        //Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        
        tbl = tbl + "<table width='100%' id='tab2' align='left' cellpadding='5' cellspacing='0'border='1'>";
        tbl = tbl + ("<tr><td class='middle4' colspan='4'></td><td class='middle4' colspan='3' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + cpn + "</b><td class='middle4' ><td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' colspan='4'></td><td class='middle4' colspan='3' ><b>"+heading.Text+"</b><td class='middle4' ><td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr></tr><tr></tr><tr><td class='middle4' >Date From:</td><td class='middle4' align='left' >" + fromdt + "</td><td class='middle4' ></td><td class='middle4' >Date To:</td><td class='middle4' >" + dateto + "</td><td class='middle4' ><td class='middle4' ></td></td><td class='middle4' >Run Date:</td><td class='middle4' >" + date.ToString() + "<td class='middle4' ><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr><td class='middle4' >ADTYPE:</td><td class='middle4' align='left' >" + advtype + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >DEALTYPE:</td><td class='middle4' >" + dealtype + "</td><td class='middle4' ></td><td class='middle4' ></td></tr>");
        tbl = tbl + ("<tr></tr></table>");

        tblgrid.InnerHtml += tbl;
        //if (chk_excel == "1")
        //{
        System.IO.StringWriter sw1 = new System.IO.StringWriter();
        HtmlTextWriter hw1 = new HtmlTextWriter(sw1);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw1);
        Response.Write(sw1.ToString());
        //}

        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
        DataGrid1.Columns.Add(nameColumn0);



        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[1].ToString();
        nameColumn.DataField = "DEAL_NO";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[2].ToString();
        nameColumn1.DataField = "DEAL_NAME";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[3].ToString();
        nameColumn2.DataField = "";
        DataGrid1.Columns.Add(nameColumn2);

        //BoundColumn nameColumn4 = new BoundColumn();
        //nameColumn4.HeaderText = "Package";
        //nameColumn4.DataField = "Package";
        //DataGrid1.Columns.Add(nameColumn4);


        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[4].ToString();
        nameColumn5.DataField = "DEAL_TYPE";
        DataGrid1.Columns.Add(nameColumn5);

        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[5].ToString();
        nameColumn6.DataField = "FROM_DATE";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[6].ToString();
        nameColumn7.DataField = "TILL_DATE";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn8 = new BoundColumn();
        nameColumn8.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[7].ToString();
        nameColumn8.DataField = "TOTAL_VALUE";
        DataGrid1.Columns.Add(nameColumn8);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[8].ToString();
        nameColumn9.DataField = "TOTAL_VOLUM";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[9].ToString();
        nameColumn10.DataField = "AGENCY_NAME";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[10].ToString();
        nameColumn11.DataField = "CLIENT_NAME";
        DataGrid1.Columns.Add(nameColumn11);


        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[11].ToString();
        nameColumn12.DataField = "PACKAGECODE";
        DataGrid1.Columns.Add(nameColumn12);

        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[12].ToString();
        nameColumn13.DataField = "CARD_RATE";
        DataGrid1.Columns.Add(nameColumn13);

        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[13].ToString();
        nameColumn14.DataField = "PREMIUM_CODE";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[14].ToString();
        nameColumn15.DataField = "CONTRACT_RATE";
        DataGrid1.Columns.Add(nameColumn15);

        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[15].ToString();
        nameColumn16.DataField = "DISCPER";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[16].ToString();
        nameColumn17.DataField = "DISCTYPE";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[17].ToString();
        nameColumn18.DataField = "INSERTION";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn28 = new BoundColumn();
        nameColumn28.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[18].ToString();
        nameColumn28.DataField = "MIN_SIZE";
        DataGrid1.Columns.Add(nameColumn28);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[19].ToString();
        nameColumn19.DataField = "MAX_SIZE";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[20].ToString();
        nameColumn20.DataField = "VALUEFROM";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[21].ToString();
        nameColumn21.DataField = "VALUETO";
        DataGrid1.Columns.Add(nameColumn21);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[22].ToString();
        nameColumn22.DataField = "RATE_CODE";
        DataGrid1.Columns.Add(nameColumn22);


        BoundColumn nameColumn23 = new BoundColumn();
        nameColumn23.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[23].ToString();
        nameColumn23.DataField = "REMARKS";
        DataGrid1.Columns.Add(nameColumn23);

        BoundColumn nameColumn24 = new BoundColumn();
        nameColumn24.HeaderText = dsxml.Tables[1].Rows[0].ItemArray[24].ToString();
        nameColumn24.DataField = "APPROVED";
        DataGrid1.Columns.Add(nameColumn24);

        DataGrid1.DataSource = ds;
        //if (chk_excel == "1")
        //{
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        DataGrid1.ShowHeader = true;
        DataGrid1.ShowFooter = true;
        DataGrid1.DataBind();
        hw.WriteBreak();
        DataGrid1.RenderControl(hw);
         Response.Write(sw.ToString());
        Response.Flush();
        Response.End();


    }
    private void pdf()
    {
        //DataSet dsxml = new DataSet();
        //dsxml.ReadXml(Server.MapPath("XML/DealReport.xml"));

        //string pdfName = "";
        //pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        //string name = Server.MapPath("") + "//" + pdfName;


        //Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        //PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        //int i2 = 0;

        ////--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        ////HeaderFooter footer = new HeaderFooter(new Phrase("01",true));
        //footer.Border = Rectangle.NO_BORDER;
        //footer.Alignment = Element.ALIGN_CENTER;
        //document.Footer = footer;

        //document.Open();

        ////---------------------------end-------------------------------------------------------

        //int NumColumns = 24;
        //Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        //Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        //Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        //// ---------------table for heading-------------------------
        //try
        //{
        //    DataSet ds1 = new DataSet();
        //    ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        //    //Table tbl  = new Table(1);
        //    PdfPTable tbl = new PdfPTable(1);
        //    float[] xy = { 100 };
        //    tbl.DefaultCell.BorderWidth = 0;
        //    tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tbl.setWidths(xy);
        //    tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

        //    tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[5].ToString(), font9));
        //    //tbl.addCell("List of ADS -Hold/Cancelled");
        //    float[] headerwidths1 = { 50 };
        //    tbl.setWidths(headerwidths1);
        //    tbl.WidthPercentage = 100;
        //    //tbl.DefaultCell.Padding = -5;
        //    document.Add(tbl);

        //    //-----------------table for spacing------------------------------
        //    PdfPTable tbl1 = new PdfPTable(1);
        //    tbl1.DefaultCell.BorderWidth = 0;
        //    tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tbl1.addCell("");
        //    //tbl.addCell("List of ADS -Hold/Cancelled");
        //    //float[] headerwidths2 = { 15 };
        //    //tbl1.setWidths(headerwidths2);
        //    tbl1.WidthPercentage = 100;
        //    //tbl1.DefaultCell.Padding = -5;
        //    int i;
        //    for (i = 0; i < 3; i++)
        //    {
        //        document.Add(tbl1);
        //    }
        //    PdfPTable tbl2 = new PdfPTable(6);
        //    tbl2.DefaultCell.BorderWidth = 0;
        //    tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
        //    tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
        //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
        //    tbl2.addCell(new Phrase(dateto1.ToString(), font11));
        //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
        //    tbl2.addCell(new Phrase(date.ToString(), font11));

        //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
        //    tbl2.addCell(new Phrase(lblpublication.Text, font11));
        //    tbl2.addCell(new Phrase("", font10));
        //    tbl2.addCell(new Phrase("", font11));
        //    tbl2.addCell(new Phrase("Publication Center", font10));
        //    tbl2.addCell(new Phrase(lblpublicationcenter.Text, font11));

        //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
        //    tbl2.addCell(new Phrase(lbadtype.Text, font11));
        //    tbl2.addCell(new Phrase("AdCategory", font10));
        //    tbl2.addCell(new Phrase(lbadcategory.Text, font11));
        //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
        //    tbl2.addCell(new Phrase(lbedition.Text, font11));
        //    tbl2.WidthPercentage = 100;
        //    document.Add(tbl2);



        //    //-------------------------------table for header-------------------------------------------------------
        //    float[] headerwidths = { 11, 14, 14, 18, 15, 16, 10, 27, 10, 10, 12, 15, 15, 20, 14, 16, 16, 18, 14, 14, 12, 24, 16 }; // percentage
        //    PdfPTable datatable = new PdfPTable(headerwidths);
        //    datatable.DefaultCell.Padding = 3;
        //    //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
        //    //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
        //    //////// float[] headerwidths = { 12, 18, 18, 20, 16, 18, 12, 14, 18, 18, 17, 15, 14, 15, 20 ,20,15,15,12,21,21}; // percentage
        //    //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
        //    ////////   datatable.setWidths(headerwidths);
        //    datatable.WidthPercentage = 100; // percentage
        //    datatable.DefaultCell.BorderWidth = 0;
        //    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));


        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[98].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));

        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[60].ToString(), font10));
        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));

        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

        //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[25].ToString() + "\n" + "File Name" + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[41].ToString(), font10));
        //   datatable.addCell(new Phrase("Audit" + "\n" + "Authorization", font10));
        //    // datatable.addCell(new Phrase("Authorization", font10));

        //    datatable.HeaderRows = 1;
        //    Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


        //    document.Add(p2);


        //    //------------------//-------------------------------------------------------------------       


        //    int row = 0;
        //    //int count = 0;
        //    int i1 = 1;
        //    while (row < ds.Tables[0].Rows.Count)
        //    {
        //        datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
        //        datatable.addCell(new Phrase(i1++.ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
        //        //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[4].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RO_No"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
        //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

               



        //        row++;

        //    }

        //    document.Add(datatable);
        //    Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
        //    document.Add(p3);

        //    PdfPTable tbltotal = new PdfPTable(24);
        //    //  float[] headerwidths5 = { 11, 13, 14, 14, 10, 8, 12 }; // percentage
        //    // tbltotal.setWidths(headerwidths5);
        //    tbltotal.DefaultCell.BorderWidth = 0;
        //    tbltotal.WidthPercentage = 100;
        //    tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
        //    tbltotal.DefaultCell.Colspan = 2;
        //    tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
        //    tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
        //    tbltotal.addCell(new Phrase("Total Area", font10));
        //    tbltotal.addCell(new Phrase(areaset.ToString(), font11));
        //    tbltotal.DefaultCell.Colspan = 1;
        //    tbltotal.addCell(new Phrase("Lines", font10));
        //    tbltotal.addCell(new Phrase(totrol.ToString(), font11));
        //    tbltotal.addCell(new Phrase("Chars", font10));
        //    tbltotal.addCell(new Phrase(totcd.ToString(), font11));
        //    tbltotal.DefaultCell.Colspan = 2;
        //    tbltotal.addCell(new Phrase("Words", font10));
        //    tbltotal.addCell(new Phrase(totcc.ToString(), font11));
        //    tbltotal.addCell(new Phrase("Audit", font10));
        //    tbltotal.addCell(new Phrase(totaudit.ToString(), font11));
        //    tbltotal.addCell(new Phrase("Unaudit", font10));
        //    tbltotal.addCell(new Phrase(totunaudit.ToString(), font11));

        //    document.Add(tbltotal);
        //    document.Close();
        //    Response.Redirect(pdfName);

        //}
        //catch (Exception e)
        //{
        //    Console.Error.WriteLine(e.StackTrace);
        //}


    }
   
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        
            if(e.Item.ItemType != ListItemType.Header)
            {
                e.Item.Cells[0].Text = Convert.ToString(snoex++);
            }

    }
}
