using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Text.RegularExpressions;

public partial class Reports_MaterialReport : System.Web.UI.Page
{

    string pdate = ""; string user = ""; string pcenter = "",destination="";
    string  username = ""; string pcentername = "";
    DataSet ds = new DataSet();
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
        pdate = Request.QueryString["pubdate"].ToString();
        user = Request.QueryString["user"].ToString();
        pcenter = Request.QueryString["pubcenter"].ToString();
      
        pcentername = Request.QueryString["pubname"].ToString();
        username = Request.QueryString["username"].ToString();
        destination = Request.QueryString["dest"].ToString();
        lblpdate.Text = pdate;
        lblpubcent.Text = pcentername;
        lbluser.Text = username;
        lblrdate.Text = DateTime.Now.ToShortDateString();
        cmpnyname.Text = Session["comp_name"].ToString();
        heading.Text = "Material Log";
      
        ds = (DataSet)Session["datamat"];
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_MaterialReport));
       
        //lblcenter.Text = ds.Tables[1].Rows[0].ItemArray[3].ToString();
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
                onscreen();

            else if (destination == "3")
            {

            //    if (chk_excel == "1")
            //    {
                    excel();
            //    }
            //    else
            //    {
            //        excel_csv(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            //    }

            }

            else if (destination == "2")
                pdf();

        }


    }

    private void onscreen()
    {
       

        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";

        tbl = "<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>";

        tbl = tbl + ("<tr><td  class='middle31new' width='20px' >S.No</td><td class='middle31new'  align='left'>UserName</td><td class='middle31new'  align='left'>OrignalName</td><td class='middle31new'  align='left'>Generate</br>FileName</td><td class='middle31new'  align='left'>Publish </br>date</td><td class='middle31new'  align='left'>Publish </br>Name</td><td class='middle31new'  align='left'>Update</br>date</td></tr>");
        int i1 = 1;
        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");

            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["USERNAME"].ToString();
            if (rrr.Length >= 10)
            {
                cioid1 = rrr.Substring(0, 10);
                if (rrr.Length - 10 < 10)
                    cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                else
                    cioid1 += "</br>" + rrr.Substring(10, 10);
            }
            else
                cioid1 = rrr;



            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (cioid1 + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ORIGINALNAME"] + "</td>");


            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["SAPNAME"] + "</td>");


            string INSDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString(); 
            string rrr1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString();
           




            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (INSDATE + "</td>");

            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["BKFOR_NAME"].ToString();
            if (rrr2.Length >= 16)
            {
                client1 = rrr2.Substring(0, 16);
                if (rrr2.Length - 16 < 16)
                    client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                else
                    client1 += "</br>" + rrr2.Substring(16, 16);
            }
            else
                client1 = rrr2;




            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl = tbl + (client1 + "</td>");

           
            tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
            tbl = tbl + (Convert.ToDateTime(ds.Tables[0].Rows[i]["UPD_DATETIME"].ToString()).ToShortDateString() + "</td>");



            tbl = tbl + "</tr>";


            tblgrid.InnerHtml += tbl;
            tbl = "";

        }


        tbl = tbl + ("<tr >");

       

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
         

       // Session["parameter_print"] = "adtype~" + adtyp + "~adcategory~" + adcat + "~adsubcat~" + adsubcat + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~pubcenter~" + pubcen + "~edition~" + edition + "~publicname~" + pubcname + "~publiccent~" + pub2 + "~adcatname~" + adcatname + "~adtypename~" + adtypename + "~editionname~" + editionname + "~adsubcatname~" + adsubcatname + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
        Response.Redirect("Materialprint.aspx?pubdate=" + pdate + "&pubcenter=" + pcenter + "&user=" + user + "&pubname=" + pcentername + "&username=" + username);
        //Response.Redirect("reportnewprint.aspx?adtype=" + adtyp + "&adcategory=" + adcat + "&adsubcat=" + adsubcat + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&pubcenter=" + pubcen + "&edition=" + edition + "&publicname=" + pubcname + "&publiccent=" + pub2 + "&adcatname=" + adcatname + "&adtypename=" + adtypename + "&editionname=" + editionname + "&adsubcatname=" + adsubcatname+"&agtype1=" + agtype + "&agtypetext=" + agtypetext ); 


    }

    private void excel()
    {
        int cont = ds.Tables[0].Rows.Count;
        StringBuilder tbl = new StringBuilder();

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");


       // tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>");

        tbl.Append("<tr><td  class='middle31new' width='10px' >S.</br>No</td><td class='middle31new' align='left'>UserName</td><td class='middle31new'  align='left'>OrignalName</td><td class='middle31new'  align='left' colspan='2'>Generate</br>FileName</td><td class='middle31new'  align='left'>Publish </br>date</td><td class='middle31new'  align='left'>Publish </br>Name</td><td class='middle31new'  align='left'>Update</br>date</td></tr>");
        int i1 = 1;
        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr>");


            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["USERNAME"].ToString();
            if (rrr.Length >= 10)
            {
                cioid1 = rrr.Substring(0, 10);
                if (rrr.Length - 10 < 10)
                    cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                else
                    cioid1 += "</br>" + rrr.Substring(10, 10);
            }
            else
                cioid1 = rrr;



            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl.Append(cioid1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["ORIGINALNAME"] + "</td>");


            tbl.Append("<td style=\"padding-left:4px\" colspan='2' class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["SAPNAME"] + "</td>");


            string INSDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString();
            string rrr1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString();





            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl.Append(INSDATE + "</td>");

            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["BKFOR_NAME"].ToString();
            if (rrr2.Length >= 16)
            {
                client1 = rrr2.Substring(0, 16);
                if (rrr2.Length - 16 < 16)
                    client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                else
                    client1 += "</br>" + rrr2.Substring(16, 16);
            }
            else
                client1 = rrr2;




            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
            tbl.Append(client1 + "</td>");


            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
            tbl.Append(Convert.ToDateTime(ds.Tables[0].Rows[i]["UPD_DATETIME"].ToString()).ToShortDateString() + "</td>");



           tbl.Append("</tr>");


        //    tblgrid.InnerHtml += tbl;
        //    tbl = "";

        }


       // tbl = tbl + ("<tr >");



        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        hw.Write("<p><table border='1'><tr><td align='center' colspan='8'><b><b>" + cmpnyname.Text + "</b></b></td></tr>");
        hw.Write("<p><tr><td align='center' colspan='8'><b><b>" + heading.Text + "</b><b></td></tr>");
        
       hw.WriteBreak();
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }

    private void pdf()
    {
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        document.Open();

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font12 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font14 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 13, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8, Font.NORMAL);
        Font font13 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);

        PdfPTable tb1 = new PdfPTable(1);
        float[] topcomp = { 100 };
        tb1.DefaultCell.BorderWidth = 0;
        tb1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        tb1.setWidths(topcomp);
        tb1.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
        tb1.addCell(new Phrase(cmpnyname.Text, font14));
        tb1.addCell(new Phrase(heading.Text, font14));
        tb1.addCell(new Phrase("", font14));
        document.Add(tb1);

        PdfPTable tb3 = new PdfPTable(4);
        float[] xy3 = { 100 };
        tb3.DefaultCell.BorderWidth = 0;
        tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //tb3.setWidths(xy1);
        tb3.WidthPercentage = 100;
        tb3.DefaultCell.BorderWidth = 0;

        tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
        tb3.addCell(new Phrase("User: " + lbluser.Text, font12));
    //    tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
      //  tb3.addCell(new Phrase(lbluser.Text, font12));
        tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
        tb3.addCell(new Phrase("PUBCENT: " + lblpubcent.Text, font12));
   //     tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
    //    tb3.addCell(new Phrase(lblpubcent.Text, font12));
        tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
        tb3.addCell(new Phrase("Pub Date: " + lblpdate.Text, font12));
    //    tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
   //     tb3.addCell(new Phrase(lblpdate.Text, font12));
        tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
        tb3.addCell(new Phrase("Run Date: " + lblrdate.Text, font12));
  //      tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
  //      tb3.addCell(new Phrase(lblrdate.Text, font12));
        document.Add(tb3);


        PdfPTable tb4 = new PdfPTable(7);
       
        tb4.DefaultCell.BorderWidth = 0;
       // tb4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        float[] headerwidths = { 5,10,10,10,10,10,10 }; // percentage
        tb4.setWidths(headerwidths);
        tb4.WidthPercentage = 100;
        tb4.DefaultCell.BorderWidth = 0;
        tb4.DefaultCell.Colspan = 7;
        tb4.addCell(new Phrase("__________________________________________________________________________________________________________________________________", font12));
        tb4.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
        tb4.DefaultCell.Colspan = 1;
        tb4.addCell(new Phrase("S.No", font12));
        tb4.addCell(new Phrase("UserName", font12));
        tb4.addCell(new Phrase("OrignalName", font12));
        tb4.addCell(new Phrase("Generate Filename", font12));
        tb4.addCell(new Phrase("Publish Date", font12));
        tb4.addCell(new Phrase("Publish Name", font12));
        tb4.addCell(new Phrase("Update Date", font12));
        tb4.DefaultCell.Colspan = 7;
        tb4.addCell(new Phrase("__________________________________________________________________________________________________________________________________", font12));
        document.Add(tb4);

         int i1 = 1; 
        int cont = ds.Tables[0].Rows.Count;
        
        PdfPTable tb5 = new PdfPTable(7);

        tb5.DefaultCell.BorderWidth = 0;
        // tb4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
       // float[] headerwidths = { 5, 10, 10, 10, 10, 10, 10 }; // percentage
        tb5.setWidths(headerwidths);
        tb5.WidthPercentage = 100;
        tb5.DefaultCell.BorderWidth = 0;
        for (int i = 0; i <= cont - 1; i++)
        {

            tb5.addCell(new Phrase(""+i1++, font12));
            tb5.addCell(new Phrase(ds.Tables[0].Rows[i]["USERNAME"].ToString(), font11));
            tb5.addCell(new Phrase(ds.Tables[0].Rows[i]["ORIGINALNAME"].ToString(), font11));
            tb5.addCell(new Phrase(ds.Tables[0].Rows[i]["SAPNAME"].ToString(), font11));
            string INSDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString();
            tb5.addCell(new Phrase(INSDATE, font11));
            tb5.addCell(new Phrase(ds.Tables[0].Rows[i]["BKFOR_NAME"].ToString(), font11));
            string UPDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["UPD_DATETIME"].ToString()).ToShortDateString();
            tb5.addCell(new Phrase(UPDATE, font11));

        }
        document.Add(tb5);
        document.Close();
        Response.Redirect(pdfName, false);
    }

}
