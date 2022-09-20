using System;
//using pdfrecgen;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Globalization;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.Text.RegularExpressions;
public partial class Receipt_Ht_Jab_bill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        DataSet ds = new DataSet();
        Double amt = 0;
        ds.ReadXml(Server.MapPath("XML/Reciept_Ht.xml"));
        lblheading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbldetypevdown.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblRDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblRDatedown.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbldetype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbldetypedown.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcat.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcatdown.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcatname.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblcatnamedown.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //lblsub.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblsecondheading.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lblcomm.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblboxchrg.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblamtpaid.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblmatter.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("receiptAddress/" + Session["center"].ToString() + ".xml"));
        //lblheadingmain.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //if (Session["centerAdd"] != null)
        //{
        //    string[] arr;
        //    arr = Session["centerAdd"].ToString().Split("^".ToCharArray());
        lblheadingadd.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();//arr[0].ToString();
        lblheadingph.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();//arr[1].ToString();
        //    if (arr[2].ToString()!= "")
        //        lblheadingph.Text = lblheadingph.Text + "," + arr[2].ToString();
        //}

        //if (ConfigurationManager.AppSettings["secondAddressForthtReceipt"].ToString() != "")
        //{
        lblheadingmain.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        // }
        // if (ConfigurationManager.AppSettings["secondAddressForthtReceipt"].ToString() != "")
        // {
        labelhtheadingph.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        // }
        lblreceiptno.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lableclientname.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lableclientadd.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblrostatus.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        //  lblsapid.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();

        string compcode = Session["compcode"].ToString();
        hiddenbookid.Value = Request.QueryString["cioid"].ToString();//"DEL2009A0100005432";
        string str = "";
        string commrate = "";

        string box_chrg_type = "";

        DataSet dsdata = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Reciept_Ht binddata = new NewAdbooking.Classes.Reciept_Ht();
            dsdata = binddata.bindreceiptdata(compcode, hiddenbookid.Value);//
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Reciept_Ht binddata = new NewAdbooking.classesoracle.Reciept_Ht();
            dsdata = binddata.bindreceiptdata_bill(compcode, hiddenbookid.Value);//
        }
        else
        {
            NewAdbooking.classmysql.Reciept_Ht binddata = new NewAdbooking.classmysql.Reciept_Ht();
            dsdata = binddata.bindreceiptdata(compcode, hiddenbookid.Value);//
        }

        string[] arrclient = Request.QueryString["clientname"].ToString().Split('(');


        lblclientname.Text = dsdata.Tables[0].Rows[0]["Client_code"].ToString();//arrclient[0];
        lblclientnamedown.Text = dsdata.Tables[0].Rows[0]["Client_code"].ToString();
        lblclientadd.Text = dsdata.Tables[0].Rows[0]["Client_address"].ToString(); //Request.QueryString["clientadd"].ToString();
        lblclientadddown.Text = dsdata.Tables[0].Rows[0]["Client_address"].ToString();
        string date11 = dsdata.Tables[0].Rows[0]["date_time"].ToString();
        date11 = date11.Substring(0, 10);
        lblRDatev.Text = date11;//dsdata.Tables[5].Rows[0]["Receipt_date"].ToString();
        lblRDatevdown.Text = dsdata.Tables[5].Rows[0]["Receipt_date"].ToString();
        lbldetypev.Text = dsdata.Tables[0].Rows[0]["Uom_Name"].ToString();
        lbldetypevdown.Text = dsdata.Tables[0].Rows[0]["Uom_Name"].ToString();
        lblcatv.Text = dsdata.Tables[0].Rows[0]["Adv_Cat_Name"].ToString();
        lblcatvdown.Text = dsdata.Tables[0].Rows[0]["Adv_Cat_Name"].ToString();
        lblcatnamev.Text = dsdata.Tables[0].Rows[0]["Adv_Cat_Name"].ToString();
        if (Session["agency_name"].ToString() != "0" && Session["agency_name"].ToString() != "")
        {
            lblqbcname.Text = dsdata.Tables[0].Rows[0]["Agency"].ToString();
            lblqbcaddress.Text = dsdata.Tables[0].Rows[0]["Address"].ToString();
        }
        if (dsdata.Tables[0].Rows[0]["ro_status"].ToString() == "1")
        {
            lblrostatusv.Text = "Confirm";
        }
        else
        {
            lblrostatusv.Text = "UnConfirm";
        }
        lblboxchrgv.Text = dsdata.Tables[3].Rows[0].ItemArray[0].ToString();
        box_chrg_type = dsdata.Tables[3].Rows[0].ItemArray[1].ToString();
        if (dsdata.Tables[4].Rows.Count > 0)
        {
            commrate = dsdata.Tables[4].Rows[0].ItemArray[0].ToString();
            commrate = Convert.ToString(Convert.ToDouble(commrate) + Convert.ToDouble(dsdata.Tables[4].Rows[0].ItemArray[1].ToString()));
        }

        //  lblsapidv.Text = dsdata.Tables[0].Rows[0]["SAPID"].ToString();

        str = "<table cellpadding='0' cellspacing='0' width=95% border='1' >";// rin
        str += "<tr>";
        str += "<td style='width: 100px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
        str += "<td style='width: 110px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
        str += "<td style='width: 120px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
        //  str += "<td style='width: 100px' class='labelhtdatagrid'>sub cat</td>";
        str += "<td style='width:115px' class='labelhtdatagrid'>Lines/Words</td>";
        //  str += "<td style='width:12px' class='labelhtdatagrid'>O</td>";
        //  str += "<td style='width:25px' class='labelhtdatagrid'>L</td>";

        //str += "<td style='width: 12px'></td>";
        //str += "<td style='width: 25px'></td>";
        str += "<td style='width: 70px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>";
        str += "<td style='width: 70px' class='labelhtdatagrid'>Eyecatcher<br>Amt</td>";
        str += "<td style='width: 90px'  class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
        str += "</tr>";
        for (int i = 0; i < dsdata.Tables[1].Rows.Count; i++)
        {
            str += "<tr>";
            str += "<td style='width: 100px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[0].ToString() + "</td>";
            str += "<td style='width: 110px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[1].ToString() + "</td>";
            str += "<td style='width: 150px'  class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[2].ToString() + "</td>";
            //  str += "<td style='width: 100px' class='labelht'>&nbsp;</td>";/* + dsdata.Tables[1].Rows[i].ItemArray[3].ToString() +*/
            str += "<td style='width:75px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[6].ToString() + " X 1 " + "</td>";
            //str += "<td style='width:12px' class='labelht'>X</td>";
            //str += "<td style='width:25px' class='labelht'>1</td>";
            //str += "</tr></table></td>";
            //str += "<td style='width: 25px'>" + dsdata.Tables[1].Rows[i].ItemArray[6].ToString() + "</td>";
            //str += "<td style='width: 25px'>X</td>";
            //str += "<td style='width: 25px'>1</td>";
            int ins_count = dsdata.Tables[1].Rows.Count;
            if (commrate == "")
                commrate = "0";
            double comm_rate_f = Convert.ToDouble(dsdata.Tables[1].Rows[i]["Card_Rate"]) * Convert.ToDouble(commrate) / 100;
            str += "<td style='width: 25px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[4].ToString() + "</td>";
            //  double amt_ins = Convert.ToDouble(dsdata.Tables[1].Rows[i].ItemArray[5].ToString()) + comm_rate_f;
            str += "<td style='width: 25px' class='labelht'>" + dsdata.Tables[0].Rows[0]["EyeCatcherAmt"].ToString() + "</td>";
            double amt_ins = Convert.ToDouble(dsdata.Tables[1].Rows[i].ItemArray[5].ToString());// IN QBC
            //double amt_ins = Convert.ToDouble(dsdata.Tables[1].Rows[i]["Bill_Amt"]);// IN house
            str += "<td style='width: 90px' align='right' class='labelht'>" + amt_ins.ToString() + "</td>";
            amt = amt + Convert.ToDouble(dsdata.Tables[1].Rows[i].ItemArray[5].ToString());
            str += "</tr>";
        }
        str += "</table>";
        tblinserts.InnerHtml = str;
        str = "";
        str = "<table width='100%' border='1'>";
        for (int j = 0; j < dsdata.Tables[2].Rows.Count; j++)
        {
            if (dsdata.Tables[2].Rows.Count > dsdata.Tables[1].Rows.Count)
            {
                if (dsdata.Tables[2].Rows[j].ItemArray[2].ToString().IndexOf("All.xtg") < 0)
                {
                    str += "<tr>";
                    str += "<td style='width:50px'>" + (j + 1) + "</td>";
                    //                    str += "<td>" + dsdata.Tables[2].Rows[j].ItemArray[1].ToString().Replace("<br>", "") + "</td>";
                    str += "<td>" + dsdata.Tables[2].Rows[j].ItemArray[1].ToString() + "</td>";
                    str += "</tr>";
                }

            }
            else
            {
                str += "<tr>";
                str += "<td style='width:50px'>" + (j + 1) + "</td>";
                //str += "<td>" + dsdata.Tables[2].Rows[j].ItemArray[1].ToString().Replace("<br>", "") + "</td>";
                str += "<td>" + dsdata.Tables[2].Rows[j].ItemArray[1].ToString() + "</td>";
                str += "</tr>";
            }
            //str += "<tr><td></td><td>---------------------------------------------</td></tr>";
        }
        str += "</table>";
        divmatter.InnerHtml = str;
        //lblcomm.Text += commrate + "%";
        //lblcommv.Text = Convert.ToString(amt * Convert.ToDouble(commrate) / 100);
        // double famt = amt + (amt * Convert.ToDouble(commrate) / 100);
        if (dsdata.Tables[0].Rows[0]["Gross_amount"] != null)
        {
            amt = Convert.ToDouble(dsdata.Tables[0].Rows[0]["Gross_amount"].ToString());
            // amt = Convert.ToDouble(dsdata.Tables[0].Rows[0]["Bill_amount"].ToString());// for ihouse

        }
        double famt = amt;
        if (box_chrg_type == "1")
        {
            // famt = famt + Convert.ToDouble(lblboxchrgv.Text);new change 19dec09
        }
        else if (box_chrg_type == "1")
        {
            double chrgper = 0;
            chrgper = famt * Convert.ToDouble(lblboxchrgv.Text) / 100;
            // famt = famt + chrgper;new change 19dec 09
            lblboxchrgv.Text = chrgper.ToString();
        }
        //if (dsdata.Tables[4].Rows.Count > 0)
        //{
        //    if (dsdata.Tables[4].Rows[0].ItemArray[0] != null)
        //    {
        //        string agencyComm = dsdata.Tables[4].Rows[0].ItemArray[0].ToString();
        //        famt = famt - (famt * Convert.ToDouble(agencyComm) / 100);
        //    }
        //}
        lblamt.Text = "<b>" + Convert.ToString(famt) + "</b>";

        lblreceiptnov.Text = "<b>" + Request.QueryString["receiptno"].ToString() + "</b>";
        string myscript1 = "<script language='Javascript'>";
        myscript1 += "JavaScript: var windowObject = window.self;windowObject.opener = window.self; windowObject.print();";
        myscript1 += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript1);
        }

        string myscript = "<script language='Javascript'>";
        myscript += "JavaScript: var windowObject = window.self;windowObject.opener = window.self; windowObject.close();";
        myscript += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript);
        }
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        string commrate = "";
        string box_chrg_type = "";
        DataSet ds1 = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Reciept_Ht binddata = new NewAdbooking.Classes.Reciept_Ht();
            ds1 = binddata.bindreceiptdata(Session["compcode"].ToString(), hiddenbookid.Value);//
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Reciept_Ht binddata = new NewAdbooking.classesoracle.Reciept_Ht();
            ds1 = binddata.bindreceiptdata(Session["compcode"].ToString(), hiddenbookid.Value);//
        }
        else
        {
            NewAdbooking.classmysql.Reciept_Ht binddata = new NewAdbooking.classmysql.Reciept_Ht();
            ds1 = binddata.bindreceiptdata(Session["compcode"].ToString(), hiddenbookid.Value);//
        }
        string rostat;
        if (ds1.Tables[0].Rows[0]["ro_status"].ToString() == "1")
        {
            rostat = "Confirm";
        }
        else
        {
            rostat = "UnConfirm";
        }
        if (ds1.Tables[4].Rows.Count > 0)
        {
            commrate = ds1.Tables[4].Rows[0].ItemArray[0].ToString();
            commrate = Convert.ToString(Convert.ToDouble(commrate) + Convert.ToDouble(ds1.Tables[4].Rows[0].ItemArray[1].ToString()));
        }
        DataSet ds2 = new DataSet();
        ds2.ReadXml(Server.MapPath("receiptAddress/" + Session["center"].ToString() + ".xml"));

        DataSet ds = new DataSet();
        //Double amt = 0;
        ds.ReadXml(Server.MapPath("XML/Reciept_Ht.xml"));

        //&@&&&&&&&&&&&&&&&&&&&@@@@@@@@@@@&&&&&&&&&&&&&&&&&&&&&&&@@@@@&&&&&&&&&&
        string pdfName = "";
        string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".html";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";


        string name3 = Server.MapPath("") + "\\images\\receipt_logo.jpg";
        string name = Server.MapPath("") + "\\temppdf\\" + pdfName;
        string name1 = Server.MapPath("") + "\\temppdf\\" + pdfName1;
        //pdfrecgen.Service serv = new pdfrecgen.Service();
        //serv.GetImageFile(name1, name, name1, ds1, ds, ds2, Request.QueryString["receiptno"].ToString(), name3);
        //iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

        //PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        //int i2 = 0;
        //iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        //footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        //document.Footer = footer;
        //document.Open();

        ////int table1 = ds.Tables[0].Rows.Count;
        ////int controw = ds.Tables[0].Rows.Count;
        ////int contcol = ds.Tables[0].Columns.Count;
        ////int table2 = ds.Tables[1].Rows.Count;

        ////int q = ds.Tables[0].Columns.Count;
        ////int z = q - 1;
        //////this is for last third coloumn
        ////int lastc = ds.Tables[0].Columns.Count;
        ////int lastthirdc = lastc - 3;
        ////int NumColumns = ds.Tables[0].Columns.Count + 1;
        ////NumColumns = NumColumns - 4;
        ////int xx = ds.Tables[0].Columns.Count - 10;
        //iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        //iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        //iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
        //iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);

        ////--------------------for page numbering---------------------------------------------
        ////---------------table for heading-------------------------
        //try
        //{
        //    //PdfPTable tbl = new PdfPTable(1);
        //    float[] xy = { 100 };
        //    //tbl.DefaultCell.BorderWidth = 0;
        //    //tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    //tbl.setWidths(xy);
        //   // tbl.addCell(new iTextSharp.text.Image("Images/receipt_logo.gif"));
        //    //tbl.addCell(new iTextSharp.text.Image("Images/receipt_logo.gif"));
        //    string imageFilePath = Server.MapPath(".") + "\\images\\receipt_logo.jpg";
        //  iTextSharp.text.Image jpg = iTextSharp.text.Image.getInstance(imageFilePath);
        //   // PdfPCell cell2 = new PdfPCell(System.Drawing.Image.FromFile(@"C:\receipt_logo.gif"));
        //    //System.Drawing.Image.FromFile(@"C:\receipt_logo.gif");
        //    //iTextSharp.text.Image logoImage = iTextSharp.text.Image.GetInstance(Server.MapPath("\\images\\receipt_logo.gif"));
        //    //PdfPCell logoCell = new PdfPCell(logoImage);
        //    //var image = Image.GetInstance(Chart());
        //   // var image = Image.GetInstance();
        //    //tbl.addCell(jpg);

        //    //tbl.addCell(jpg);
        //    //objPage.Canvas.DrawImage(objImage, "x=0, y=0");

        //  jpg.Alignment = iTextSharp.text.Image.MIDDLE;
        //    //tbl.WidthPercentage = 100;

        //    document.Add(jpg);

        //    PdfPTable tbl2 = new PdfPTable(2);
        //    //float[] xy1 = { 100 };
        //    tbl2.DefaultCell.BorderWidth = 0;
        //    tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //    //tbl6.setWidths(xy1);
        //    tbl2.addCell(new iTextSharp.text.Phrase("Regd. Office: ", font9));

        //    tbl2.DefaultCell.BorderWidth = 0;
        //    tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tbl2.addCell(new iTextSharp.text.Phrase("Local Office:", font9));
        //    //tbl6.addCell(new iTextSharp.text.Phrase("", font9));
        //    // tbl6.addCell(new iTextSharp.text.Phrase("", font9));
        //    //tbl6.addCell(new iTextSharp.text.Phrase("", font9));
        //    //tbl6.addCell(new iTextSharp.text.Phrase("", font9));
        //    //tbl6.addCell(new iTextSharp.text.Phrase("", font9));
        //    // tbl6.addCell(new iTextSharp.text.Phrase("Print Order Report", font9));
        //    tbl2.WidthPercentage = 100;
        //    document.Add(tbl2);

        //    PdfPTable tbl6 = new PdfPTable(2);
        //    tbl6.DefaultCell.BorderWidth = 0;
        //    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //    tbl6.addCell(new iTextSharp.text.Phrase(ds2.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
        //    tbl6.DefaultCell.BorderWidth = 0;
        //    tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tbl6.addCell(new iTextSharp.text.Phrase(ds2.Tables[0].Rows[0].ItemArray[2].ToString(), font9));
        //    tbl6.WidthPercentage = 100;
        //    document.Add(tbl6);

        //    PdfPTable tb2 = new PdfPTable(2);
        //    tb2.DefaultCell.BorderWidth = 0;
        //    tb2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //    tb2.addCell(new iTextSharp.text.Phrase(ds2.Tables[0].Rows[0].ItemArray[1].ToString(), font9));
        //    tb2.DefaultCell.BorderWidth = 0;
        //    tb2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tb2.addCell(new iTextSharp.text.Phrase(ds2.Tables[0].Rows[0].ItemArray[3].ToString(), font9));
        //    tb2.WidthPercentage = 100;
        //    document.Add(tb2);

        //    PdfPTable tb9 = new PdfPTable(1);
        //    tb9.DefaultCell.BorderWidth = 0;
        //    tb9.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb9.addCell("");
        //    tb9.WidthPercentage = 100;
        //    for (int K = 0; K < 5; K++)
        //    {
        //        document.Add(tb9);
        //    }

        //    PdfPTable tb3 = new PdfPTable(3);
        //    tb3.DefaultCell.BorderWidth = 0;
        //    tb3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tb3.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
        //    tb3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //    PdfPCell DefaultCell = new PdfPCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["Client_code"].ToString(), font9));
        //    DefaultCell.Colspan = 2;
        //    DefaultCell.BorderWidth = 0;
        //    tb3.addCell(DefaultCell);
        //   // tb3.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["Client_code"].ToString(), font9));
        //    document.Add(tb3);

        //    PdfPTable tb4 = new PdfPTable(3);
        //    tb4.DefaultCell.BorderWidth = 0;
        //    tb4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tb4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
        //    tb4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //    PdfPCell Cell1 = new PdfPCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["Client_address"].ToString(), font9));
        //    Cell1.Colspan = 2;
        //    Cell1.BorderWidth = 0;
        //    tb4.addCell(Cell1);
        //    //tb4.addCell(new iTextSharp.text.Phrase( ds1.Tables[0].Rows[0]["Client_address"].ToString(), font9));
        //    document.Add(tb4);

        //    PdfPTable tb14 = new PdfPTable(1);
        //    tb14.DefaultCell.BorderWidth = 0;
        //    tb14.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb14.addCell("");
        //    tb14.WidthPercentage = 100;
        //    for (int K = 0; K < 5; K++)
        //    {
        //        document.Add(tb14);
        //    }

        //    PdfPTable tb5 = new PdfPTable(6);
        //    tb5.DefaultCell.BorderWidth = 1;
        //    tb5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb5.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[18].ToString(), font8));
        //    tb5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb5.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[1].ToString(), font8));
        //    tb5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb5.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[3].ToString(), font8));
        //    tb5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb5.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[2].ToString(), font8));
        //    tb5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb5.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[4].ToString(), font8));
        //    tb5.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb5.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[21].ToString(), font8));
        //    document.Add(tb5);

        //    PdfPTable tb6 = new PdfPTable(6);
        //    tb6.DefaultCell.BorderWidth = 1;
        //    tb6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb6.addCell(new iTextSharp.text.Phrase(Request.QueryString["receiptno"].ToString(), font9));
        //    tb6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb6.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["date_time"].ToString(), font9));
        //    tb6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb6.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["Adv_Cat_Name"].ToString(), font9));
        //    tb6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb6.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["Uom_Name"].ToString(), font9));
        //    tb6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb6.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["Adv_Cat_Name"].ToString(), font9));
        //    tb6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb6.addCell(new iTextSharp.text.Phrase(rostat, font9));
        //    document.Add(tb6);

        //    PdfPTable tb19 = new PdfPTable(1);
        //    tb19.DefaultCell.BorderWidth = 0;
        //    tb19.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb19.addCell("");
        //    tb19.WidthPercentage = 100;
        //    for (int K = 0; K < 5; K++)
        //    {
        //        document.Add(tb19);
        //    }

        //    PdfPTable tb7 = new PdfPTable(1);
        //    tb7.DefaultCell.BorderWidth = 0;
        //    tb7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb7.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[6].ToString(), font9));
        //    tb7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    document.Add(tb7);

        //    PdfPTable tb8 = new PdfPTable(7);
        //    tb8.DefaultCell.BorderWidth = 1;
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[12].ToString(), font9));
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[5].ToString(), font9));
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[13].ToString(), font9));
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase("Lines/Words", font9));
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[22].ToString(), font9));
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase("Eyecatcher Amt", font9));
        //    tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb8.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[14].ToString(), font9));


        //    for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
        //    {
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(ds1.Tables[1].Rows[i].ItemArray[0].ToString(), font8));
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(ds1.Tables[1].Rows[i].ItemArray[1].ToString(), font8));
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(ds1.Tables[1].Rows[i].ItemArray[2].ToString(), font8));
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(ds1.Tables[1].Rows[i].ItemArray[6].ToString() + " X 1 ", font8));
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(ds1.Tables[1].Rows[i].ItemArray[4].ToString(), font8));
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[0]["EyeCatcherAmt"].ToString(), font8));

        //        int ins_count = ds1.Tables[1].Rows.Count;
        //        if (commrate == "")
        //            commrate = "0";
        //        double comm_rate_f = Convert.ToDouble(ds1.Tables[1].Rows[i]["Card_Rate"]) * Convert.ToDouble(commrate) / 100;
        //        double amt_ins = Convert.ToDouble(ds1.Tables[1].Rows[i].ItemArray[5].ToString());
        //        tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tb8.addCell(new iTextSharp.text.Phrase(amt_ins.ToString(), font8));
        //        amt = amt + Convert.ToDouble(ds1.Tables[1].Rows[i].ItemArray[5].ToString());
        //    }
        //    document.Add(tb8);

        //    if (ds1.Tables[0].Rows[0]["Gross_amount"] != null)
        //    {
        //        amt = Convert.ToDouble(ds1.Tables[0].Rows[0]["Gross_amount"].ToString());
        //        // amt = Convert.ToDouble(dsdata.Tables[0].Rows[0]["Bill_amount"].ToString());// for ihouse

        //    }
        //    double famt = amt;
        //    if (box_chrg_type == "1")
        //    {
        //        // famt = famt + Convert.ToDouble(lblboxchrgv.Text);new change 19dec09
        //    }
        //    else if (box_chrg_type == "1")
        //    {
        //        double chrgper = 0;
        //        chrgper = famt * Convert.ToDouble(lblboxchrgv.Text) / 100;
        //        // famt = famt + chrgper;new change 19dec 09
        //        lblboxchrgv.Text = chrgper.ToString();
        //    }

        //    PdfPTable tb12 = new PdfPTable(1);
        //    tb12.DefaultCell.BorderWidth = 0;
        //    tb12.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tb12.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[8].ToString()+lblboxchrgv.Text, font9));
        //    //tb12.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    //tb12.addCell(new iTextSharp.text.Phrase(lblboxchrgv.Text, font9));

        //    tb12.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    tb12.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[9].ToString() + Convert.ToString(famt), font9));
        //    //tb12.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //    //tb12.addCell(new iTextSharp.text.Phrase(Convert.ToString(famt), font9));

        //    document.Add(tb12);

        //    PdfPTable tb13 = new PdfPTable(1);
        //    tb13.DefaultCell.BorderWidth = 0;
        //    tb13.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //    tb13.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[0].ItemArray[11].ToString(), font9));
        //    document.Add(tb13);

        //    PdfPTable tb11 = new PdfPTable(4);
        //    tb11.DefaultCell.BorderWidth = 1;
        //    for (int j = 0; j < ds1.Tables[2].Rows.Count; j++)
        //    {
        //        if (ds1.Tables[2].Rows.Count > ds1.Tables[1].Rows.Count)
        //        {
        //            if (ds1.Tables[2].Rows[j].ItemArray[2].ToString().IndexOf("All.xtg") < 0)
        //            {
        //                tb11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //                tb11.addCell(new iTextSharp.text.Phrase((j + 1).ToString(), font9));
        //                tb11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //                string innerhtml1 = ds1.Tables[2].Rows[j].ItemArray[1].ToString();
        //                string header = "<HTML><HEAD>";
        //                string footer1 = "</BODY></HTML>";
        //                string innerhtml = header + innerhtml1 + footer1;
        //                //StreamWriter myStreamWriter = File.CreateText(Server.MapPath("Temp/" + pdfName1 + ".html"));
        //                //myStreamWriter.Write(innerhtml, System.Text.Encoding.UTF8);
        //                //myStreamWriter.Flush();
        //                //myStreamWriter.Close();
        //                //iTextSharp.text.ht
        //                //ArrayList htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(innerhtml), null);
        //                //for (int t = 0; t < htmlarraylist.Count; t++)
        //                //{
        //                //    document.Add((IElement)htmlarraylist[t]);
        //                //}
        //                //Paragraph mypara = new Paragraph();
        //                //mypara.IndentationLeft = 36;
        //                //mypara.InsertRange(0, htmlarraylist);
        //                //document.Add(mypara);

        //                //tb11.addCell(new iTextSharp.text.Phrase(ds1.Tables[2].Rows[j].ItemArray[1].ToString(), font9));
        //                //PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(ds1.Tables[2].Rows[j].ItemArray[0].ToString(), font8));
        //                //PdfPCell cell = new PdfPCell(iTextSharp.text.Phrase);
        //                //cell.Colspan = 3;
        //                //tb11.addCell(cell);


        //            }

        //        }
        //        else
        //        {
        //            tb11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //           // tb11.DefaultCell.Width=
        //            tb11.addCell(new iTextSharp.text.Phrase((j + 1).ToString(), font9));
        //            tb11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        //            string innerhtml1 = ds1.Tables[2].Rows[j].ItemArray[1].ToString();
        //            string header = "<HTML><HEAD>";
        //            string footer1 = "</BODY></HTML>";
        //            string innerhtml = header + innerhtml1 + footer1;
        //            StreamWriter myStreamWriter = File.CreateText(Server.MapPath("Temp/" + pdfName1 + ".html"));
        //            myStreamWriter.Write(innerhtml, System.Text.Encoding.UTF8);
        //            myStreamWriter.Flush();
        //            myStreamWriter.Close();
        //            PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(ds1.Tables[2].Rows[j].ItemArray[0].ToString(), font8));
        //            cell.Colspan = 3;
        //            tb11.addCell(cell);
        //            //tb11.addCell(new iTextSharp.text.Phrase(ds1.Tables[2].Rows[j].ItemArray[0].ToString(), font9));
        //        }
        //    }
        //    document.Add(tb11);
        //    document.Close();
        pdfName = "temppdf\\" + pdfName;
        Response.Redirect(pdfName, false);
        //}
        //catch (Exception ey)
        //{
        //    Console.Error.WriteLine(ey.StackTrace);
        //}


    }
}
