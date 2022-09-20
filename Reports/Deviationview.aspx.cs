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
using System.Web.UI.WebControls;
using System.Text;

public partial class Deviationview : System.Web.UI.Page
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
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string clientname1 = "";
    string agname = "";
    string status = "";
    string status1 = "";
    string hold = "";
    string adtypename = "";
    string editionname = "";
    string agencyname = "";
    string datefrom1 = "";
    string dateto1 = "", agtype = "", agtypetext = "";

    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    string rundate="";
    string package = "";
    string sortorder = "";
    string sortvalue = "";
    double areanew = 0;
    int sno = 1;
    double comm2 = 0;
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
       

        

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();

        ds = (DataSet)Session["Deviation"];
        string prm = Session["prm_Deviation"].ToString();
        string[] prm_Array = new string[43];
        prm_Array = prm.Split('~');


        agname = prm_Array[1];// Request.QueryString["agname"].ToString();
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
        status1 = prm_Array[23]; //Request.QueryString["status1"].ToString();
        adcatname = prm_Array[25]; //Request.QueryString["adcatname"].ToString();
        status = prm_Array[27]; //Request.QueryString["status"].ToString();
        clientname = prm_Array[29]; //Request.QueryString["clientname"].ToString();
        clientname1 = prm_Array[31]; //Request.QueryString["client"].ToString();
        adtypename = prm_Array[33]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[35]; //Request.QueryString["editionname"].ToString();
        agencyname = prm_Array[37]; //Request.QueryString["agencyname"].ToString();
        agtype = prm_Array[39]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[41]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[43];



            hold = "abc";
            hiddendatefrom.Value = fromdt.ToString();
         
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

            if (clientname == "0" || clientname=="")
            {

                lbclient.Text = "ALL".ToString();
            }
            else
            {
                lbclient.Text = clientname1.ToString();
            }

            if (edition == "0" || edition=="")
            {
                lbedition.Text = "ALL".ToString();
            }
            else
            {
                lbedition.Text = editionname.ToString();



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
            //dateto1 = "";
            if (dateto != "")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = dd + "/" + mm + "/" + yy;

                }


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
            rundate = date.ToString();
            if (!Page.IsPostBack)
            {
                if (destination == "1" || destination == "0")
                {
                    onscreen(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
                }
                else if (destination == "4")
                {
                    excel(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

                }
                else if (destination == "3")
                {
                    pdf(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);

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

    private void onscreen(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
        string page = "";
        string position = "";
        SqlDataAdapter da = new SqlDataAdapter();
       
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        StringBuilder tbl = new StringBuilder();
        //string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>");
        //tbl.Append("<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>");
     
        int i1 = 1;
        //if (hiddenascdesc.Value == "")
        //{
        tbl.Append("<tr><td class='middle1212' width='1%' align='center'>S.No.</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;Id</td><td class='middle1212' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td id='tdag~3' class='middle1212'   onclick=sorting('Agency',this.id) width='10%' align='left'>&nbsp;&nbsp;Agency</td> <td id='tdcl~4' class='middle1212' width='10%'  onclick=sorting('Client',this.id) align='left'>&nbsp;&nbsp;Client</td> <td id='tdcl~6' class='middle1212' width='8%'  onclick=sorting('Package',this.id) align='left'>&nbsp;&nbsp;Package<td class='middle1212' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle1212' width='3%' align='left'>&nbsp;&nbsp;Color</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;BookDate</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;RoNo.</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;RoStatus</td> <td id='tdad~17' class='middle1212' width='5%'  onclick=sorting('AdCat',this.id) align='left'>&nbsp;AdCategory</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;RateCode</td><td class='middle1212' width='5%' align='right'>&nbsp;&nbsp;CardRate</td><td class='middle1212' width='5%' align='right'>&nbsp;&nbsp;AggRate</td><td class='middle1212' width='5%' align='right'>&nbsp;&nbsp;Dev%</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;Status</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;BookedBy</td><td class='middle1212' width='5%' align='left'>&nbsp;&nbsp;AuditBy</td></tr>"); //<td class='middle31' width='3%'>page</td>

        //}
       


        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr >");

            tbl.Append("<td class='rep_data' width='1%' align='center'>");
            tbl.Append( i1++.ToString() + "</td>");
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'  width='5%'>");
           
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

            tbl.Append(cioid1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='3%'>");
            tbl.Append(ds.Tables[0].Rows[i]["edition"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["Ins.date"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='7%'>");
            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            if (rrr1.Length >= 16)
            {
                agency1 = rrr1.Substring(0, 16);
                if (rrr1.Length - 16 < 16)
                    agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                else
                    agency1 += "</br>" + rrr1.Substring(16, 16);
            }
            else
                agency1 = rrr1;


            //string agency1 = "";
            //string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            //char[] agency = rrr1.ToCharArray();
            //int len111 = agency.Length;
            //int line11 = 0;
            //int ch_end1 = 0;
            //int ch_str1 = 0;
            //for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            //{
            //    /**/
            //    ch_end1 = ch_end1 + 16;
            //    ch_str1 = ch_end1;
            //    if (ch_end1 > len111)
            //        ch_str1 = len111 - ch1;
            //    else
            //        ch_str1 = ch_end1 - ch1;

            //    agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
            //    agency1 = agency1 + "</br>";
            //    ch1 = ch1 + 16;
            //    if (ch1 > len111)
            //        ch1 = len111;/**/
            //}
            tbl.Append(agency1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='10%'>");


            //string client1 = "";
            //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            //char[] client = rrr11.ToCharArray();
            //int len1111 = client.Length;
            //int line = 0;
            //int ch_end11 = 0;
            //int ch_str11 = 0;
            //for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            //{
            //    /* */
            //    ch_end11 = ch_end11 + 16;
            //    ch_str11 = ch_end11;
            //    if (ch_end11 > len1111)
            //        ch_str11 = len1111 - ch11;
            //    else
            //        ch_str11 = ch_end11 - ch11;

            //    client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
            //    client1 = client1 + "</br>";
            //    ch11 = ch11 + 16;
            //    if (ch11 > len1111)
            //        ch11 = len1111;
            //}
            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
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

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='7%'>");
            tbl.Append(Package1 + "</td>");


            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
            tbl.Append(chk_null(ds.Tables[0].Rows[i]["Area"].ToString()) + "</td>");

            //area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
            {

                if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());


            }
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='3%'>");
            tbl.Append(ds.Tables[0].Rows[i]["Hue"] + "</td>");


            //tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_dataSN' align='center' width='3%'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["BookDate"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["RoNo"] + "</td>");

            string RoStatus1 = "";
            string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
            if (rrr4.Length >= 9)
            {
                RoStatus1 = rrr4.Substring(0, 9);
                if (rrr4.Length - 9 < 9)
                    RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                else
                    RoStatus1 += "</br>" + rrr4.Substring(9, 9);
            }
            else
                RoStatus1 = rrr4;

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(RoStatus1 + "</td>");
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
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(AdCat1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data'align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["RateCode"] + "</td>");



            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["CardRate"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["Deviation(%)"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["Status"] + "</td>");
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["booked_by"] + "</td>");
            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
            tbl.Append(ds.Tables[0].Rows[i]["audit"] + "</td>");
            tbl.Append("</tr >");
            //tblgrid.InnerHtml += tbl;
           // tbl = "";

        }
        tbl.Append("<tr >");

        tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle13new'  colspan='2'>&nbsp;</td>");

        ////////////////////////////////////////

        tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl.Append(chk_null(cal.ToString()) + "</td>");

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

        tbl.Append("<td  class='middle13new'  colspan='4'>&nbsp;</td>");
       // tbl = tbl + ("<td class='middle13new' colspan='8' style='font-size: 13px;'>");
       // tbl = tbl + (amt.ToString() + "</td>");


        tbl.Append("</tr>");

        tbl.Append("</table>");
        //tblgrid.InnerHtml = tbl;
        tblgrid.InnerHtml = tbl.ToString();
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

        string check1 = e.Item.Cells[7].Text;
        string amt1 = e.Item.Cells[7].Text;

        //area
        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {
                string arean = e.Item.Cells[7].Text;
                areanew = areanew + Convert.ToDouble(arean);
            }
        }
    }
    

    private void excel(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
        string page = "";
        string position = "";
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, agtypetext);
        //}
        int cont = ds.Tables[0].Rows.Count;
        for (int u = 0; u < cont; u++)
        {

            if (ds.Tables[0].Rows[u]["Area"].ToString() != "")
            {


                if (ds.Tables[0].Rows[u]["uom"].ToString() == "CD" || ds.Tables[0].Rows[u]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
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
        nameColumn.HeaderText = "Booking Id";
        nameColumn.DataField = "CIOID";

        name1 = name1 + "," + "Booking Id";
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
        nameColumn2.DataField = "Ins.Date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins.Date";
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
        nameColumn7.HeaderText = "Package";
        nameColumn7.DataField = "Package";

        name1 = name1 + "," + "Package";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);



        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Area";
        nameColumn11.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);

        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Color";
        nameColumn12.DataField = "Hue";

        name1 = name1 + "," + "Color";
        name2 = name2 + "," + "Hue";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);


        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "BookDate";
        nameColumn13.DataField = "BookDate";

        name1 = name1 + "," + "BookDate";
        name2 = name2 + "," + "BookDate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);


        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "RoNo.";
        nameColumn14.DataField = "RoNo";

        name1 = name1 + "," + "RoNo.";
        name2 = name2 + "," + "RoNo";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "RoStatus";
        nameColumn15.DataField = "RoStatus";

        name1 = name1 + "," + "RoStatus";
        name2 = name2 + "," + "RoStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);


        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "Adcat";
        nameColumn16.DataField = "Adcat";

        name1 = name1 + "," + "Adcat";
        name2 = name2 + "," + "Adcat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "RateCode";
        nameColumn17.DataField = "RateCode";

        name1 = name1 + "," + "RateCode";
        name2 = name2 + "," + "RateCode";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "CardRate";
        nameColumn18.DataField = "CardRate";

        name1 = name1 + "," + "CardRate";
        name2 = name2 + "," + "CardRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "AgreedRate";
        nameColumn19.DataField = "AgreedRate";

        name1 = name1 + "," + "AgreedRate";
        name2 = name2 + "," + "AgreedRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "%Dev";
        nameColumn20.DataField = "Deviation(%)";

        name1 = name1 + "," + "%Dev";
        name2 = name2 + "," + "Deviation(%)";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = "Status";
        nameColumn21.DataField = "Status";

        name1 = name1 + "," + "Status";
        name2 = name2 + "," + "Status";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn21);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = "BookedBy";
        nameColumn22.DataField = "booked_by";

        name1 = name1 + "," + "BookedBy";
        name2 = name2 + "," + "booked_by";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn22);


        BoundColumn nameColumn23 = new BoundColumn();
        nameColumn23.HeaderText = "AuditBy";
        nameColumn23.DataField = "audit";

        name1 = name1 + "," + "AuditBy";
        name2 = name2 + "," + "audit";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn23);

        if (chk_excel == "1")
        {
            DataGrid1.DataSource = ds;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();

            hw.Write("<p <table border=\"1\"><tr><td colspan=\"20\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");

            hw.Write("<p <tr><td colspan=\"20\"align=\"center\"><b>" + "Devation Report" + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"7\"align=\"left\"><b>" + "From Date:" + lblfrom.Text + "</b></td><td colspan=\"7\"align=\"center\"><b>" + "To Date:" + lblto.Text + "</b></td><td colspan=\"6\"align=\"right\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
                
            //hw.Write("<p align=\"left\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Devation Report<b>");
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds:" + sno11 + "</td><td align=\"right\" colspan=\"5\">Area:</td><td>" + areanew + "</td><td colspan='2'>Lines:" + totrol + "</td><td colspan='2'>Chars:" + totcd + "</td><td colspan='2'>Words:" + totcc + "</td></tr></table>"));
        }
        else
        {
            DataGrid1.DataSource = ds;

            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties ={ names, captions, formats };

            QueryToCSV(ds, colProperties);
        }
        

     //   string page = "";
     //   string position = "";
     //   Response.Clear();
     //   Response.ClearContent();
     //   Response.Charset = "UTF-8";
     //   Response.ContentType = "text/csv";
     //   if (chk_excel == "1")
     //   {
     //       Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
     //   }
     //   else
     //   {
     //       Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
     //   }

     //   string companyname = "";
     //   companyname = ds.Tables[0].Rows[0]["companyname"].ToString();

     //   int cont = ds.Tables[0].Rows.Count;
     //   int contc = ds.Tables[0].Columns.Count;
     //   StringBuilder tbl = new StringBuilder();
     //   //string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
     //   tbl.Append("<table id='table1' cellpadding='0' cellspacing='0' align='center' border='1' width='100%' >");
     ////   tbl.Append("<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>");
     //   //tbl.Append("<table id='table2' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >");
     //   tbl.Append("<tr><td class='rep_data' width='5px' colspan='20' align='center'><b>" + companyname + "</b></td></tr>");
     //   tbl.Append("<tr><td class='rep_data' width='5px' colspan='20' align='center'><b>Deviation Report</b></td></tr>");
     //   tbl.Append("<tr><td class='middle31' align='left' colspan='5'><b>Publication</b>" + lblpub.Text + "</b></td><td class='middle31' align='left' colspan='5'><b>Pubcenter" + pcenter.Text + "</b></td><td class='middle31' align='left' colspan='5'><b>Agency Type" + lblagtype.Text + "</b></td><td class='middle31' align='left' colspan='5'><b>Edition" + lbedition.Text + "</b></td></tr>");
     //   tbl.Append("<tr><td class='middle31' align='left' colspan='5'><b>Client" + lbclient.Text + "</b></td><td class='middle31' align='left' colspan='5'><b>Date From" + lblfrom.Text + "</b></td><td class='middle31' align='left' colspan='5'><b>Date To" + lblto.Text + "</b></td><td class='middle31' align='left' colspan='5'><b>Run Date" + lbldate.Text + "</b></td></tr>");
     //   tbl.Append("</table>");
     //   tbl.Append("<table id='table3' cellpadding='0' cellspacing='0' align='center' border='1' width='100%' >");
     //   int i1 = 1;
     //   if (hiddenascdesc.Value == "")
     //   {
     //       tbl.Append("<tr><td class='middle31' width='1%' align='center'>S.No.</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;Id</td><td class='middle31' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id) width='10%' align='left'>&nbsp;&nbsp;Agency</td> <td id='tdcl~4' class='middle3' width='10%'  onclick=sorting('Client',this.id) align='left'>&nbsp;&nbsp;Client</td> <td id='tdcl~6' class='middle3' width='8%'  onclick=sorting('Package',this.id) align='left'>&nbsp;&nbsp;Package<td class='middle31' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle31' width='3%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;BookDate</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;RoNo.</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;RoStatus</td> <td id='tdad~17' class='middle3' width='5%'  onclick=sorting('AdCat',this.id) align='left'>&nbsp;&nbsp;AdCategory</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;RateCode</td><td class='middle31' width='5%' align='right'>&nbsp;&nbsp;CardRate</td><td class='middle31' width='5%' align='right'>&nbsp;&nbsp;AggRate</td><td class='middle31' width='5%' align='right'>&nbsp;&nbsp;Dev%</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;Status</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;BookedBy</td><td class='middle31' width='5%' align='left'>&nbsp;&nbsp;AuditBy</td></tr>"); //<td class='middle31' width='3%'>page</td>

     //   }
       


     //   for (int i = 0; i <= cont - 1; i++)
     //   {
     //       tbl.Append("<tr >");

     //       tbl.Append("<td class='rep_data' width='1%' align='center'>");
     //       tbl.Append( i1++.ToString() + "</td>");
     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'  width='5%'>");
           
     //       string cioid1 = "";
     //       string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
     //       if (rrr.Length >= 10)
     //       {
     //           cioid1 = rrr.Substring(0, 10);
     //           if (rrr.Length - 10 < 10)
     //               cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
     //           else
     //               cioid1 += "</br>" + rrr.Substring(10, 10);
     //       }
     //       else
     //           cioid1 = rrr;

     //       tbl.Append(cioid1 + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='3%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["edition"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["Ins.date"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='7%'>");
     //       string agency1 = "";
     //       string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
     //       if (rrr1.Length >= 16)
     //       {
     //           agency1 = rrr1.Substring(0, 16);
     //           if (rrr1.Length - 16 < 16)
     //               agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
     //           else
     //               agency1 += "</br>" + rrr1.Substring(16, 16);
     //       }
     //       else
     //           agency1 = rrr1;


     //       //string agency1 = "";
     //       //string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
     //       //char[] agency = rrr1.ToCharArray();
     //       //int len111 = agency.Length;
     //       //int line11 = 0;
     //       //int ch_end1 = 0;
     //       //int ch_str1 = 0;
     //       //for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
     //       //{
     //       //    /**/
     //       //    ch_end1 = ch_end1 + 16;
     //       //    ch_str1 = ch_end1;
     //       //    if (ch_end1 > len111)
     //       //        ch_str1 = len111 - ch1;
     //       //    else
     //       //        ch_str1 = ch_end1 - ch1;

     //       //    agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
     //       //    agency1 = agency1 + "</br>";
     //       //    ch1 = ch1 + 16;
     //       //    if (ch1 > len111)
     //       //        ch1 = len111;/**/
     //       //}
     //       tbl.Append(agency1 + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='10%'>");


     //       //string client1 = "";
     //       //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
     //       //char[] client = rrr11.ToCharArray();
     //       //int len1111 = client.Length;
     //       //int line = 0;
     //       //int ch_end11 = 0;
     //       //int ch_str11 = 0;
     //       //for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
     //       //{
     //       //    /* */
     //       //    ch_end11 = ch_end11 + 16;
     //       //    ch_str11 = ch_end11;
     //       //    if (ch_end11 > len1111)
     //       //        ch_str11 = len1111 - ch11;
     //       //    else
     //       //        ch_str11 = ch_end11 - ch11;

     //       //    client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
     //       //    client1 = client1 + "</br>";
     //       //    ch11 = ch11 + 16;
     //       //    if (ch11 > len1111)
     //       //        ch11 = len1111;
     //       //}
     //       string client1 = "";
     //       string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
     //       if (rrr2.Length >= 16)
     //       {
     //           client1 = rrr2.Substring(0, 16);
     //           if (rrr2.Length - 16 < 16)
     //               client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
     //           else
     //               client1 += "</br>" + rrr2.Substring(16, 16);
     //       }
     //       else
     //           client1 = rrr2;


     //       tbl.Append(client1 + "</td>");
     //       string Package1 = "";
     //       string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
     //       if (rrr3.Length >= 9)
     //       {
     //           Package1 = rrr3.Substring(0, 9);
     //           if (rrr3.Length - 9 < 9)
     //               Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
     //           else
     //               Package1 += "</br>" + rrr3.Substring(9, 9);
     //       }
     //       else
     //           Package1 = rrr3;

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='7%'>");
     //       tbl.Append(Package1 + "</td>");


     //       tbl.Append("<td  class='rep_data' align='right'>");
            

     //       //area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);
     //       if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
     //       {

     //           if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
     //               area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
     //           else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
     //               totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
     //           else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
     //               totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
     //           else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
     //               totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());


     //       }
     //       float ara1 = Single.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
     //       tbl.Append(string.Format("{0:0.00}",ara1) + "</td>");
     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='3%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["Hue"] + "</td>");


     //       //tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_dataSN' align='center' width='3%'>");
     //       //tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["BookDate"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["RoNo"] + "</td>");

     //       string RoStatus1 = "";
     //       string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
     //       if (rrr4.Length >= 9)
     //       {
     //           RoStatus1 = rrr4.Substring(0, 9);
     //           if (rrr4.Length - 9 < 9)
     //               RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
     //           else
     //               RoStatus1 += "</br>" + rrr4.Substring(9, 9);
     //       }
     //       else
     //           RoStatus1 = rrr4;

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(RoStatus1 + "</td>");
     //       string AdCat1 = "";
     //       string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
     //       if (rrr5.Length >= 9)
     //       {
     //           AdCat1 = rrr5.Substring(0, 9);
     //           if (rrr5.Length - 9 < 9)
     //               AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
     //           else
     //               AdCat1 += "</br>" + rrr5.Substring(9, 9);
     //       }
     //       else
     //           AdCat1 = rrr5;
     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(AdCat1 + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data'align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["RateCode"] + "</td>");



     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["CardRate"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["Deviation(%)"] + "</td>");

     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["Status"] + "</td>");
     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["booked_by"] + "</td>");
     //       tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
     //       tbl.Append(ds.Tables[0].Rows[i]["audit"] + "</td>");
     //       tbl.Append("</tr >");
     //       //tblgrid.InnerHtml += tbl;
     //      // tbl = "";

     //   }
     //   tbl.Append("<tr >");

     //   tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
     //   tbl.Append("<td class='middle13new'  colspan='2'>&nbsp;</td>");

     //   ////////////////////////////////////////

     //   tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
     //   double cal = System.Math.Round(Convert.ToDouble(area), 2);
     //   tbl.Append(chk_null(cal.ToString()) + "</td>");

     //   if (totrol > 0)
     //   {
     //       tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
     //       double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
     //       tbl.Append(calf.ToString() + "</td>");
     //   }
     //   else
     //   {
     //       tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
     //   }
     //   if (totcd > 0)
     //   {
     //       tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
     //       double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
     //       tbl.Append(calfd.ToString() + "</td>");
     //   }
     //   else
     //   {
     //       tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
     //   }
     //   if (totcc > 0)
     //   {
     //       tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
     //       double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
     //       tbl.Append(calft.ToString() + "</td>");
     //   }
     //   else
     //   {
     //       tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
     //   }


     //   ///////////////////////////////////

     //   tbl.Append("<td  class='middle13new'  colspan='4'>&nbsp;</td>");
     //  // tbl = tbl + ("<td class='middle13new' colspan='8' style='font-size: 13px;'>");
     //  // tbl = tbl + (amt.ToString() + "</td>");


     //   tbl.Append("</tr>");

     //   tbl.Append("</table>");
        
        //tblgrid.InnerHtml = tbl.ToString();
        //System.IO.StringWriter sw = new System.IO.StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //tblgrid.Visible = true;
        //tblgrid.RenderControl(hw);
        //Response.Write(sw.ToString());
    
        
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
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_Deviation_print"] = "agname~" + agname + "~adtype~" + adtyp + "~adcategory~" + adcat + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~pubcenter~" + pubcen + "~publicname~" + pubcname + "~publiccent~" + pub2 + "~edition~" + edition + "~destination~" + destination + "~status1~" + status1 + "~adcatname~" + adcatname + "~status~" + status + "~clientname~" + clientname + "~client~" + clientname1 + "~adtypename~" + adtypename + "~editionname~" + editionname + "~agencyname~" + agencyname + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
         Response.Redirect("PrintDeviationReport.aspx" );
       // Response.Redirect("PrintDeviationReport.aspx?agname=" + agname + "&adtype=" + adtyp + "&adcategory=" + adcat + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&pubcenter=" + pubcen + "&publicname=" + pubcname + "&publiccent=" + pub2 + "&edition=" + edition + "&destination=" + destination + "&status1=" + status1 + "&adcatname=" + adcatname + "&status=" + status + "&clientname=" + clientname + "&client=" + clientname1 + "&adtypename=" + adtypename + "&editionname=" + editionname + "&agencyname=" + agencyname + "&agtype1=" + agtype + "&agtypetext=" + agtypetext );

    }

    

    private void pdf(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {

        string page = "";
        string position = "";
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //=======================================WATERMARK=========================================

       

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //footer.Border = Rectangle.NO_BORDER;
        //footer.Alignment = Element.ALIGN_CENTER;
        //document.Footer = footer;

        document.Open();

        int NumColumns = 20;

        //---------------------------------

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 15, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);

        //----------------------------------------



        try
        {
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //    ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, agtypetext);
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
            //    ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, agtypetext);
            //}

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));
            //heading.Text =
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[3].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };

            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);
            //-----------------------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            PdfPTable tbl91 = new PdfPTable(NumColumns);
            tbl91.DefaultCell.BorderWidth = 0;
            tbl91.WidthPercentage = 100;
            tbl91.DefaultCell.Colspan = NumColumns;
            tbl91.addCell(new iTextSharp.text.Phrase("______________________________________________________________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl91);
            //--------------------------------------------===
            PdfPTable datatable = new PdfPTable(NumColumns);

            datatable.DefaultCell.Padding = 3;

            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage


            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 12,14, 18, 17, 24, 24, 18, 13, 11, 15, 19, 18, 26, 26, 22, 27, 17, 16, 19, 19, 19, 18, 16 }; // percentage

            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[4].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
           // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            
           // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[87].ToString(), font10));
           
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[14].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));
           // datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[34].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[24].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[77].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[78].ToString(), font10));
            datatable.HeaderRows = 1;

            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("______________________________________________________________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            //Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            //document.Add(p2);
          
           

            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {

                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                if ((ds.Tables[0].Rows[row]["Area"]).ToString() != "")
                {

                    //if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ0")
                    //    area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "LI0")
                    //    totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ1")
                    //    totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "CC0")
                    //    totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());


                    if (ds.Tables[0].Rows[row]["uom"].ToString() == "CD" || ds.Tables[0].Rows[row]["uom"].ToString() == "ROD")
                        area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());

                }

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
               // datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
               
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BookDate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
               // datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Deviation(%)"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Status"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Booked_by"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["audit"].ToString(), font11));

            }


            document.Add(datatable);
            //Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            //document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 14, 16, 5, 10, 8, 16, 10, 1, 10, 13, 10, 25 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.Colspan = NumColumns;
            tbltotal.addCell(new iTextSharp.text.Phrase("______________________________________________________________________________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;
            //  tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("Area:", font10));
         //   tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(area.ToString(), font11));


            if (totrol > 0)
            {
                tbltotal.addCell(new Phrase("Lines:", font11));
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.addCell(new Phrase(calf.ToString(), font11));


            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcd > 0)
            {
                tbltotal.addCell(new Phrase("Chars:", font11));
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.addCell(new Phrase(calfd.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcc > 0)
            {

                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbltotal.addCell(new Phrase("Words:", font11));
                tbltotal.addCell(new Phrase(calft.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
           tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));        
            document.Add(tbltotal);
            PdfPTable tbl911 = new PdfPTable(NumColumns);
            tbl911.DefaultCell.BorderWidth = 0;
            tbl911.WidthPercentage = 100;
            tbl911.DefaultCell.Colspan = NumColumns;
            tbl911.addCell(new iTextSharp.text.Phrase("______________________________________________________________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl911);
            document.Close();

            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }

    }
}