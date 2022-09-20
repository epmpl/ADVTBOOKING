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
using System.Data.SqlClient;
using System.IO;
using System.Text;
public partial class agencyanalysisprint : System.Web.UI.Page
{
    int a = 0;
    int grouptotal_Govt = 0;
    int grouptotal_local = 0;
    int grouptotal_national = 0;
    int netsum = 0;
    double areanew = 0;
    double areasum = 0;
    string client = "";
    string pdfName1 = "";
    string agency = "";
    int sno = 1;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    double amtnew = 0;
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    double amtsum = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    double amt1 = 0;
    string package = "";
    string dateformate = "";
    string pubcent = "";
    string sortorder = "";
    string sortvalue = "";
    string value = "";
    string adtyp = "";
    string bill = "";
    string execut = "";
    string team = "";
    string cl = "";
    string ag = "";
    string place = "";
    string publicationname = "";
    string publicationcode = "";
    string editionname = "";
    string editioncode = "";
    string revenuecentercode = "";
    string revenuecentername = "";
    string executivecode = "";
    string executivename = "";
    string check11 = "";
    string value11 = "";
    string placename = "";
    string adtypname = "";
    string pubcentname = "";
    string noofrows11 = "20";

    // string publication = "";
    // string package = "";
    //  string adtype = "";
    double payment = 0;
    DataSet ds;
    string val_chk = "";
    int maxlimit = 15;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {

            Response.Write("<script>alert('Your Session Has Been Expired');Window.close();</Scrip>");
            return;
        }
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[17].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));

      
       ds = (DataSet)Session["topcliage"];
        string prm = Session["prm_topcliage_print"].ToString();
        string[] prm_Array = new string[43];
        prm_Array = prm.Split('~');


        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        pubcent = prm_Array[5]; //Request.QueryString["pubcent"].Trim().ToString();
        pubcentname = prm_Array[7]; //Request.QueryString["pubcentname"].ToString();
        revenuecentercode = prm_Array[9]; //Request.QueryString["revenuecentercode"].Trim().ToString();
        revenuecentername = prm_Array[11]; //Request.QueryString["revenuecentername"].ToString();
        adtyp = prm_Array[13]; //Request.QueryString["adtyp"].ToString();
        adtypname = prm_Array[15]; //Request.QueryString["adtypname"].ToString();
        val_chk = prm_Array[17]; //Request.QueryString["value"].ToString();
        bill = prm_Array[19]; //Request.QueryString["bill"].Trim().ToString();
        place = prm_Array[21]; //Request.QueryString["place"].Trim().ToString();
        placename = prm_Array[23]; //Request.QueryString["placename"].ToString();
        editioncode = prm_Array[25]; //Request.QueryString["editioncode"].Trim().ToString();
        editionname = prm_Array[27]; //Request.QueryString["editionname"].ToString();
        check11 = prm_Array[29]; //Request.QueryString["check11"].Trim().ToString();
        value11 = prm_Array[31]; //Request.QueryString["value1"].Trim().ToString();
        publicationname = prm_Array[33]; //Request.QueryString["publicationname"].ToString();
        publicationcode = prm_Array[35]; //Request.QueryString["publicationcode"].Trim().ToString();
        executivecode = prm_Array[37]; //Request.QueryString["executivecode"].Trim().ToString();
        executivename = prm_Array[39]; //Request.QueryString["executivename"].ToString();
        noofrows11 = prm_Array[41]; //Request.QueryString["noofrows11"].Trim().ToString();
         
       
        
        


        if (check11 != "1")
            heading.Text = "Top Agency Analysis Report";
        else
            heading.Text = "Top Client Analysis Report";



        Ajax.Utility.RegisterTypeForAjax(typeof(agencyanalysisprint));

        if (pubcent == "0")
        {
            lblpubcent.Text = "All";
        }
        else
        {
            lblpubcent.Text = pubcentname.ToString();

        }

        if (adtyp == "0")
        {
            lbladtype.Text = "All";
        }
        else
        {
            lbladtype.Text = adtypname.ToString();

        }

        if (place == "0")
        {
            lblcity.Text = "All";
        }
        else
        {
            lblcity.Text = placename.ToString();

        }

        if (publicationcode == "0")
        {
            lblpublication.Text = "All";
        }
        else
        {
            lblpublication.Text = publicationname.ToString();

        }

        if ((editioncode == "0") || (editioncode == ""))
        {
            lbledition.Text = "All";
        }
        else
        {
            lbledition.Text = editionname.ToString();

        }

        if ((executivecode == "0") || (executivecode == ""))
        {
            lblexec.Text = "All";
        }
        else
        {
            lblexec.Text = executivename.ToString();

        }



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
        //datefrom1 = "";
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

        lblfrom.Text = datefrom1.ToString();

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

        lblto.Text = dateto1.ToString();



     

        hiddendatefrom.Value = fromdt.ToString();

       
           
            onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());
      

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
    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {
        string agn = "";
        string agnnew = "";
        int agamt = 0;
        int agamtnew = 0;
        string agsamt = "";
        string agsamtnew = "";
        string agnj = "";
        string agnnewj = "";
        int agamtj = 0;
        int agamtnewj = 0;
        int agamtnew1 = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int i1 = 1;

        //string TBL = "";
        StringBuilder TBL = new StringBuilder();
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
             //TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");


            if (browser.Browser == "Firefox")
            {
                TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if (ver == 6.0)
                {
                    TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
            }    
             for (int p = 0; p < pagecount; p++)
             {
                //int s = p + 1;
                 int s = p + 1;
                 if (browser.Browser == "Firefox")
                 {
                     TBL.Append("</table></P>");
                     if (p == pagecount - 1)
                         TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                     else
                         TBL.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                 }
                 else if (browser.Browser == "IE")
                 {
                     if ((ver == 8.0) || (ver == 7.0))
                     {
                         TBL.Append("</table></P>");
                         if (p == pagecount - 1)
                             TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                         else
                             TBL.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                     }
                     else if (ver == 6.0)
                     {
                         TBL.Append("</table>");
                         if (p == pagecount - 1)
                             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                         else
                             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                     }
                 }  

                // TBL.Append("</table>");
                 
               //  TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                 TBL.Append("<tr valign='top'>");
                 TBL.Append("<td class='middle111' align='right' colspan='4'>" + "Page  " + s + "  of  " + pagecount);
                 TBL.Append("</td></tr>");

                 if (check11 != "1")
                 {


                    TBL.Append("<tr><td class='middle31new' width='5%'>S.No.</td><td class='middle31new' width='40%' align='left'>Agency</td><td class='middle31new' width='40%' align='left'>Agency</br>Address</td><td class='middle31new' align='right' width='15%'>Amount</td></tr>");


                 }
                 else
                 {

                     TBL.Append("<tr><td class='middle31new' width='5%'>S.No.</td><td  class='middle31new' width='40%' align='left'>Client</td><td class='middle31new' width='40%' align='left'>Client</br>Address</td><td class='middle31new' align='right' width='15%'>Amount</td></tr>");

                 }


                 for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                 {

                     a = d;
                     a = a + 1;

                     TBL.Append("<tr >");
                     TBL.Append("<td class='rep_data' >");
                     TBL.Append(a.ToString() + "</td>");

                    
                     string agency1 = "";
                     string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
                     char[] agency = rrr1.ToCharArray();
                     int len111 = agency.Length;
                     int line11 = 0;
                     int ch_end1 = 0;
                     int ch_str1 = 0;
                     for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                     {
                         /**/
                         ch_end1 = ch_end1 + 30;
                         ch_str1 = ch_end1;
                         if (ch_end1 > len111)
                             ch_str1 = len111 - ch1;
                         else
                             ch_str1 = ch_end1 - ch1;

                         agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                         agency1 = agency1 + "</br>";
                         ch1 = ch1 + 30;
                         if (ch1 > len111)
                             ch1 = len111;/**/
                     }
                     //----------------------------------------------------------------///
                     TBL.Append("<td class='rep_data' align='left' >");
                     TBL.Append(agency1 + "</td>");

                     string A_Place1 = "";
                     string rrr111 = ds.Tables[0].Rows[d]["A_Place"].ToString();
                     char[] A_Place = rrr111.ToCharArray();
                     int len11111 = A_Place.Length;
                     int line1111 = 0;
                     int ch_endp = 0;
                     int ch_strp = 0;
                     for (int ch1 = 0; ((ch1 < len11111) && (line1111 < 2)); ch1++)
                     {
                         /**/
                         ch_endp = ch_endp + 40;
                         ch_strp = ch_endp;
                         if (ch_endp > len11111)
                             ch_strp = len11111 - ch1;
                         else
                             ch_strp = ch_endp - ch1;

                         A_Place1 = A_Place1 + rrr111.Substring(ch1, ch_strp).Trim();
                         A_Place1 = A_Place1 + "</br>";
                         ch1 = ch1 + 40;
                         if (ch1 > len11111)
                             ch1 = len11111;/**/
                     }
                     //----------------------------------------------------------------///
                     TBL.Append("<td class='rep_data' align='left'>");
                     TBL.Append(A_Place1 + "</td>");

                     TBL.Append("<td class='rep_data' align='right'>");
                     TBL.Append(Convert.ToDouble(ds.Tables[0].Rows[d]["GrossAmt"]).ToString("F2") + "</td>");

                     double amtnet = 0;
                     if (ds.Tables[0].Rows[d]["GrossAmt"].ToString() != "")
                     {
                         amtnet = Convert.ToDouble(ds.Tables[0].Rows[d]["GrossAmt"].ToString());
                         //amtnet = amtnet - disc;

                     }

                     payment = payment + amtnet;


                     TBL.Append("</tr>");
                  

                     
                 }
                 ct = ct + maxlimit;
                 fr = fr + maxlimit;


             }

             TBL.Append("<tr >");
             TBL.Append("<td class='middle13new' width='5%'>&nbsp;</td>");
             TBL.Append("<td class='middle13new' width='40%'>&nbsp;</td>");
             TBL.Append("<td class='middle13new' width='40%' style='font-size:12px'><b>Total Amt:</b></td>");
             TBL.Append("<td class='middle13new' align='right'  width='15%' style='font-size:12px'><b>" + payment.ToString("F2") + "</b></td>");
             TBL.Append("</tr>");

             if (browser.Browser == "Firefox")
             {
                 TBL.Append("</table></P>");

             }
             else if (browser.Browser == "IE")
             {
                 if ((ver == 8.0) || (ver == 7.0))
                 {
                     TBL.Append("</table></P>");

                 }
                 else if (ver == 6.0)
                 {
                     TBL.Append("</table>");

                 }
             }  


           //  TBL.Append("</table>");
             tblgrid.InnerHtml = TBL.ToString();

         }




     




    }
}
