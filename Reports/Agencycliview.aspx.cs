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
using System.Data.OracleClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Text;

public partial class Agencycliview : System.Web.UI.Page
{

    string clientname = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string adcatname = "";
    string clientname1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    int ins_no = 0;
    double amt = 0;
    string client = "", agtype = "", agtypetext = "";
    string package = "";
    string drillon = "";
    string sortorder = "";
    string sortvalue = "";
    string branch = "";

    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;

    double area1 = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
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
        ds = (DataSet)Session["allclient"];




        string prm = Session["prm_allclient"].ToString();
        string[] prm_Array = new string[37];
        prm_Array = prm.Split('~');

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();



        clientname = prm_Array[1];// Request.QueryString["clientname"].ToString();
        adtyp = prm_Array[3]; //Request.QueryString["adtype"].ToString();
        adcat = prm_Array[5]; //Request.QueryString["adcategory"].ToString();
        fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();

        edition = prm_Array[19]; //Request.QueryString["edition"].ToString();
        destination = prm_Array[21]; //Request.QueryString["destination"].ToString();
        adcatname = prm_Array[23]; //Request.QueryString["adcatname"].ToString();
        clientname1 = prm_Array[25]; //Request.QueryString["client"].ToString();
        adtypename = prm_Array[27]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[29]; //Request.QueryString["editionname"].ToString();
        agtype = prm_Array[31]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[33]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[35];
        branch = prm_Array[37];
        if (agtype == "0")
        {
            lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = agtypetext.ToString();
        }
        if (publ == "0")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = pubcname.ToString();
        }
        if (pubcen == "0")
        {
            pcenter.Text = "ALL".ToString();
        }
        else
        {
            pcenter.Text = pub2.ToString();
        }



        if (clientname == "0" || clientname == "")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname1.ToString();
        }

        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();


        }


        if (adtyp == "0")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypename.ToString();
        }

        if ((adcat == "0") || (adcat == ""))
        {
            lbladcat.Text = "ALL".ToString();
        }
        else
        {
            lbladcat.Text = adcatname.ToString();
        }



        if (fromdt != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                datefrom1 = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = year + "/" + month + "/" + day;
                }
            }
        }
        lblfrom.Text = datefrom1;


        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                }

        lbldate.Text = date.ToString();
        //dateto1 = "";






        if (dateto != "")
        {





            ///////////


            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto1 = dd + "/" + mm + "/" + yy;

            }


        ////////////

            else
            {

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = day + "/" + month + "/" + year;

                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = year + "/" + month + "/" + day;
                }
            }
        }
        lblto.Text = dateto1;
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), branch);
            }
            else if (destination == "4")
            {
                excel(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), branch);

            }
            else
                if (destination == "3")
                {
                    pdf(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), branch);
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


    private void onscreen(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string branch)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();

        cmpnyname.Text = Session["centername"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        StringBuilder tbl = new StringBuilder();
        tbl.Append("<table width='100%'align='left' cellpadding='3' cellspacing='0' border='0'>");
        tbl.Append("<tr><td class='middle31new' width='1%'>S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new'  width='9%' align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='6%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp;HT</td><td class='middle31new' width='2%' &nbsp;&nbsp;>&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' valign='top' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left' >Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='6%' align='left'>RoNo.</td><td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;AggRate</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</td><td class='middle31new' width='3%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No.</td></tr>");



        int i1 = 1;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr >");

            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
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


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(cioid1 + "</td>");
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["edition"] + "</td>");


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Ins_date"] + "</td>");



            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["Client_Name"].ToString();
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



            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(client1 + "</td>");


            string Package1 = "";
            string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
            if (rrr3.Length >= 9)
            {
                Package1 = rrr3.Substring(0, 9);
                if (rrr3.Length - 9 < 9)
                    Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                else
                    Package1 += "</br>" + rrr3.Substring(9, 9);
            }
            else
                Package1 = rrr3;

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(Package1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Depth"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Width"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
            {

                if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                    area1 = area1 + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());


            }
            //----------------------------------------------------------------///
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
            tbl.Append(ds.Tables[0].Rows[i]["Color_code"] + "</td>");


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Page"] + "</td>");


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='1%'>");

            if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
            {
                tbl.Append("" + "</td>");
            }
            else
            {


                tbl.Append(ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
            }




            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='1%'>");
            if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
            {
                tbl.Append("" + "</td>");
            }
            else
            {
                tbl.Append(ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
            }

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='1%'>");
            if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
            {
                tbl.Append("" + "</td>");
            }
            else
            {
                tbl.Append(ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
            }

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["RoNo."] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["RoStatus"] + "</td>");


            string AdCat1 = "";
            string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
            if (rrr5.Length >= 9)
            {
                AdCat1 = rrr5.Substring(0, 9);
                if (rrr5.Length - 9 < 9)
                    AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                else
                    AdCat1 += "</br>" + rrr5.Substring(9, 9);
            }
            else
                AdCat1 = rrr5;


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
            tbl.Append(AdCat1 + "</td>");


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
            tbl.Append(ds.Tables[0].Rows[i]["RateCode"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");

            if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
            {
                tbl.Append("" + "</td>");
            }
            else
            {

                tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
            }

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            if ((ds.Tables[0].Rows[i]["AgreedRate"]).ToString() == "")
            {
                tbl.Append("" + "</td>");
            }
            else
            {

                tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
            }

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");

            if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
            {
                tbl.Append("" + "</td>");
            }
            else
            {

                tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
            }

            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' colspan='2' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Cap"]);
            tbl.Append("</br>");
            tbl.Append(ds.Tables[0].Rows[i]["Key"] + "</td>");


            tbl.Append("</tr>");


        }


        tbl.Append("<tr >");

        tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle13new' colspan='2'>&nbsp;</td>");

        ////////////////////////////////////////

        tbl.Append("<td class='middle1212' colspan='4' align='right'><b>Total Area:</b>");
        double cal = System.Math.Round(Convert.ToDouble(area1), 2);
        tbl.Append(cal.ToString() + "</td>");

        if (totrol > 0)
        {
            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
            double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            tbl.Append(calf.ToString() + "</td>");
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcd > 0)
        {
            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            tbl.Append(calfd.ToString() + "</td>");
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcc > 0)
        {
            tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            tbl.Append(calft.ToString() + "</td>");
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }


        ///////////////////////////////////

        tbl.Append("<td  class='middle13new'  align='right' style='font-size: 13px;'><b>BillAmt:</b></td>");
        tbl.Append("<td class='middle13new' colspan='8' style='font-size: 13px;'>");
        tbl.Append(amt.ToString() + "</td>");


        tbl.Append("</tr>");
        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();
    }


    private void pdf(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string branch)
    {
        DataSet ds11 = new DataSet();
        ds11.ReadXml(Server.MapPath("XML/agencyclient.xml"));

        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);


        btnprint.Attributes.Add("onclick", "javascript:window.print();");

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //=======================================WATERMARK=========================================


        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();
        //Graphic grx = new Graphic();
        //grx.lineTo(12, 12);
        int NumColumns = 23;

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        //----------------------------------------



        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.Class1 misrep = new NewAdbooking.Report.classesoracle.Class1();
            //    ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Report.Classes.report misrep = new NewAdbooking.Report.Classes.report();
            //    ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);

            //}

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.addCell(new Phrase(Session["centername"].ToString(), font9));

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[10].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 15 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);
            //grx.lineTo(30, 30);
            //---------------------------------------------
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

            PdfPTable tbl2 = new PdfPTable(8);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            tbl2.addCell(new Phrase("Publication", font10));
            tbl2.addCell(new Phrase(lblpub.Text, font11));
            tbl2.addCell(new Phrase("Pub Center", font10));
            tbl2.addCell(new Phrase(pcenter.Text, font11));
            tbl2.addCell(new Phrase("Edition", font10));
            tbl2.addCell(new Phrase(lbedition.Text, font11));
            tbl2.addCell(new Phrase("Client", font10));
            tbl2.addCell(new Phrase(lbclient.Text, font11));


            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.addCell(new Phrase("Agency Type", font10));
            tbl2.addCell(new Phrase(lblagtype.Text, font11));

            tbl2.addCell(new Phrase("Ad Type", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("Ad Category", font10));
            tbl2.addCell(new Phrase(lbladcat.Text, font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));

            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            //-----------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);


            datatable.DefaultCell.Padding = 3;


            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            float[] headerwidths3 = { 5, 10, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8, 5, 5 }; // percentage
            datatable.setWidths(headerwidths3);

            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.Colspan = 23;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase(ds11.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[87].ToString(), font10));

            datatable.addCell(new Phrase("Page Premium", font10));
            datatable.addCell(new Phrase("Position Premium", font10));
            datatable.addCell(new Phrase("Eye Catcher Premium", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase("BillAmt", font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            datatable.DefaultCell.Colspan = 23;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.addCell(new Phrase(ds11.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            //    datatable.HeaderRows = 1;
            //  Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            //   document.Add(p2);


            int i1 = 1;
            int row = 0;

            while (row < ds.Tables[0].Rows.Count)
            {
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins_date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if ((ds.Tables[0].Rows[row]["Area"]).ToString() != "")
                {

                    //if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ0")
                    //    area1 = area1 + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "LI0")
                    //    totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ1")
                    //    totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "CC0")
                    //    totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());



                    if (ds.Tables[0].Rows[row]["uom"].ToString() == "CD" || ds.Tables[0].Rows[row]["uom"].ToString() == "ROD")
                        area1 = area1 + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());

                }

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color_code"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PositionPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BulletPremium"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));

                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")

                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));

                row++;

            }


            document.Add(datatable);


            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(22);
            float[] headerwidths = { 18, 14, 6, 10, 8, 8, 16, 20, 16, 10, 13, 10, 20, 13, 12, 15, 12, 12, 12, 25, 6, 6 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("Area:", font10));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(area1.ToString(), font11));


            if (totrol > 0)
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase("Lines:", font10));
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.addCell(new Phrase(calf.ToString(), font11));


            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcd > 0)
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase("Chars:", font10));
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.addCell(new Phrase(calfd.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcc > 0)
            {
                // tbltotal.addCell(new Phrase(" ", font11));
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbltotal.addCell(new Phrase("Words:", font10));
                tbltotal.addCell(new Phrase(calft.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }


            tbltotal.addCell(new Phrase("Amt", font10));
            //  tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase(string.Format("{0:0.00}", amt), font11));
            tbltotal.DefaultCell.Colspan = 1;
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.Colspan = 22;
            tbltotal.addCell(new iTextSharp.text.Phrase("_______________________________________________________________________________________________________________________________________", font10));
            //tbltotal.addCell(new Phrase(" ", font11));


            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName);


            //document.Add(datatable);
            //document.Close();
            //Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_allclient_print"] = "clientname~" + clientname + "~adtype~" + adtyp + "~adcategory~" + adcat + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~pubcenter~" + pubcen + "~publicname~" + pubcname + "~publiccent~" + pub2 + "~edition~" + edition + "~adcatname~" + adcatname + "~client~" + clientname1 + "~adtypename~" + adtypename + "~editionname~" + editionname + "~agtype1~" + agtype + "~agtypetext~" + agtypetext + "~branch~" + branch;
        Response.Redirect("agencycliviewprint.aspx");
        //Response.Redirect("agencycliviewprint.aspx?clientname=" + clientname + "&adtype=" + adtyp + "&adcategory=" + adcat + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&pubcenter=" + pubcen + "&publicname=" + pubcname + "&publiccent=" + pub2 + "&edition=" + edition + "&adcatname=" + adcatname + "&client=" + clientname1 + "&adtypename=" + adtypename + "&editionname=" + editionname + "&agtype1=" + agtype + "&agtypetext=" + agtypetext);

    }




    private void excel(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string branch)
    {





        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 misrep = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report misrep = new NewAdbooking.Report.Classes.report();
        //    ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);

        //}
        int cont = ds.Tables[0].Rows.Count;
        for (int u = 0; u < cont; u++)
        {

            if (ds.Tables[0].Rows[u]["Area"].ToString() != "")
            {

                if (ds.Tables[0].Rows[u]["uom"].ToString() == "CD" || ds.Tables[0].Rows[u]["uom"].ToString() == "ROD")
                    area1 = area1 + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());

            }
        }
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
        nameColumn0.HeaderText = "S.No";
        DataGrid1.Columns.Add(nameColumn0);



        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = "Booking ID";
        nameColumn.DataField = "CIOID";
        name1 = name1 + "," + "Booking ID";
        name2 = name2 + "," + "CIOID";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Edition";
        nameColumn1.DataField = "edition";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "edition";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Publish Date";
        nameColumn2.DataField = "Ins_date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins_date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);




        BoundColumn nameColumn26 = new BoundColumn();
        nameColumn26.HeaderText = "Bill no";
        nameColumn26.DataField = "BILL_NO";

        name1 = name1 + "," + "Bill no";
        name2 = name2 + "," + "BILL_NO";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn26);



        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Agency_Name";
        nameColumn4.DataField = "Agency_Name";

        name1 = name1 + "," + "Agency_Name";
        name2 = name2 + "," + "Agency_Name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);





        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Client_Name";
        nameColumn6.DataField = "Client_Name";

        name1 = name1 + "," + "Client_Name";
        name2 = name2 + "," + "Client_Name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "Package";
        nameColumn7.DataField = "Package";

        name1 = name1 + "," + "Package";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "Depth";
        nameColumn9.DataField = "Depth";

        name1 = name1 + "," + "Depth";
        name2 = name2 + "," + "Depth";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "Width";
        nameColumn10.DataField = "Width";

        name1 = name1 + "," + "Width";
        name2 = name2 + "," + "Width";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Area";
        nameColumn11.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);

        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Color";
        nameColumn12.DataField = "Color_code";

        name1 = name1 + "," + "Color";
        name2 = name2 + "," + "Color_code";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);


        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "Page Position";
        nameColumn13.DataField = "Page";

        name1 = name1 + "," + "Page Position";
        name2 = name2 + "," + "Page";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);


        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "Page Prem";
        nameColumn14.DataField = "PagePremium";

        name1 = name1 + "," + "Page Prem";
        name2 = name2 + "," + "PagePremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "Position Prem";
        nameColumn15.DataField = "PositionPremium";

        name1 = name1 + "," + "Position Prem";
        name2 = name2 + "," + "PositionPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);


        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "Eye Catcher";
        nameColumn16.DataField = "BulletPremium";

        name1 = name1 + "," + "Eye Catcher";
        name2 = name2 + "," + "BulletPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "Ro No.";
        nameColumn17.DataField = "RoNo.";

        name1 = name1 + "," + "Ro No.";
        name2 = name2 + "," + "RoNo.";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "Ro Status";
        nameColumn18.DataField = "RoStatus";

        name1 = name1 + "," + "Ro Status";
        name2 = name2 + "," + "RoStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "AdCat";
        nameColumn19.DataField = "AdCat";

        name1 = name1 + "," + "AdCat";
        name2 = name2 + "," + "AdCat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "CardRate";
        nameColumn20.DataField = "CardRate";

        name1 = name1 + "," + "CardRate";
        name2 = name2 + "," + "CardRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = "AgreedRate";
        nameColumn21.DataField = "AgreedRate";

        name1 = name1 + "," + "AgreedRate";
        name2 = name2 + "," + "AgreedRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn21);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = "BillAmt";
        nameColumn22.DataField = "Amt";

        name1 = name1 + "," + "BillAmt";
        name2 = name2 + "," + "Amt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn22);


        BoundColumn nameColumn23 = new BoundColumn();
        nameColumn23.HeaderText = "Caption";
        nameColumn23.DataField = "Cap";

        name1 = name1 + "," + "Caption";
        name2 = name2 + "," + "Cap";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn23);

        BoundColumn nameColumn24 = new BoundColumn();
        nameColumn24.HeaderText = "Key No.";
        nameColumn24.DataField = "Key";

        name1 = name1 + "," + "Key No.";
        name2 = name2 + "," + "Key";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn24);

        BoundColumn nameColumn25 = new BoundColumn();
        nameColumn25.HeaderText = "Executive Name";
        nameColumn25.DataField = "EXECUTIVE";

        name1 = name1 + "," + "Executive Name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn25);







        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p <table border=\"1\"><tr><td colspan=\"23\"align=\"center\"><b>" + Session["centername"].ToString() + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"23\"align=\"center\"><b>" + "All Ads Of The Client" + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>" + "Pubublication :" + "</b>" + lblpub.Text + "</td>");
            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Pub Center:" + "</b>" + pcenter.Text + "</td>");
            hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Edition:" + "</b>" + lbedition.Text + "</td></tr>");
            hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>" + "Client:" + "</b>" + lbclient.Text + "</td>");

            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Ad Type:" + "</b>" + lbladtype.Text + "</td>");
            hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Ad Category:" + "</b>" + lbladcat.Text + "</td></tr>");
            hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>" + "From Date:" + "</b>" + lblfrom.Text + "</td>");
            hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "To Date:" + "</b>" + lblto.Text + "</td>");
            hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Run Date:" + "</b>" + lbldate.Text + "</td><tr>");
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td align=\"right\"colspan=\"2\">TotalAds:" + sno11 + "</td><td align=\"right\" colspan=\"6\">Area:</td><td>" + area1 + "</td><td align=\"right\"colspan=\"2\">Lines:" + totrol + "</td><td align=\"right\"colspan=\"2\">Chars:" + totcd + "</td><td align=\"right\"colspan=\"2\">Words:" + totcc + "</td><td colspan=\"5\"align=\"right\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td></tr></table>"));
        }
        else
        {
            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties = { names, captions, formats };

            QueryToCSV(ds, colProperties);
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

        double sumamt = 0;


        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }


        string check = e.Item.Cells[21].Text;
        string amt = e.Item.Cells[20].Text;









        if (check != "BillAmt")
        {
            if (check != "&nbsp;")
            {


                string grossamt = e.Item.Cells[21].Text;
                comm1 = Convert.ToDouble(grossamt);
                comm2 = comm2 + comm1;

                //string arean = e.Item.Cells[8].Text;
                //areanew=areanew + Convert.ToDouble(arean);


            }
        }


        //area





    }





}