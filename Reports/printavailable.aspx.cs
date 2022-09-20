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

public partial class Reports_printavailable : System.Web.UI.Page
{

    int maxlimit = 17;
    string dateto = "", fromdt = "", destination = "";

   
    int a = 0;
    string day = "", month = "", year = "", date = "";

    double area = 0;
    double amt = 0;
    string publ = "", pubcname = "", edition = "", page = "",pagename="", position = "", editionname = "", positioncode = "", pageno = "", adtype = "", adcate = "";
    DataSet ds;
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
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[21].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pagepreviewreport.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();


        ds = (DataSet)Session["availableprem"];
        string prm = Session["prm_availableprem_print"].ToString();
        string[] prm_Array = new string[20];
        prm_Array = prm.Split('~');


        dateto = prm_Array[1];// Request.QueryString["dateto"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        destination = prm_Array[5]; //Request.QueryString["destination"].ToString();
        publ = prm_Array[7]; //Request.QueryString["publication"].ToString();
        pubcname = prm_Array[9]; //Request.QueryString["publicname"].ToString();
        edition = prm_Array[11]; //Request.QueryString["edition"].ToString();
        editionname = prm_Array[13]; //Request.QueryString["editionname"].ToString();
        page = prm_Array[15]; //Request.QueryString["page"].ToString();
        position = prm_Array[17]; //Request.QueryString["position"].ToString();
        positioncode = prm_Array[19]; //Request.QueryString["positioncode"].ToString();
        pageno = prm_Array[21];
        adtype = prm_Array[23];
        adcate = prm_Array[25];
        pagename = prm_Array[27];

         if (page == "0")
        {
            lblpagepr.Text = "ALL".ToString();
        }
        else
        {
            lblpagepr.Text = pagename.ToString();
        }
        if (position == "0")
        {
            lblposition.Text = "ALL".ToString();
        }
        else
        {
            lblposition.Text = positioncode.ToString();
        }
        if (publ == "0")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = pubcname.ToString();
        }

        if (edition == "0" || edition == "--Select Edition Name--" || edition == "")
        {
            lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname.ToString();
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
        lblfrom.Text = fromdt;
        lblto.Text = dateto;

            onscreen(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
       
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

    private void onscreen(string page, string position, string fromdt, string dateto, string publ, string compcode, string edition, string dateformat)
    {
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
        //    ds = obj.availableprem(page, position, fromdt, dateto, publ, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
        //}
        cmpnyname.Text = ds.Tables[1].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        string TBL = "";
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
          //  TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            if (browser.Browser == "Firefox")
            {
                TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    TBL = TBL + "</table></P>";
                    if (p == pagecount - 1)
                        TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        TBL = TBL + "</table></P>";
                        if (p == pagecount - 1)
                            TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                    }
                    else if (ver == 6.0)
                    {
                        TBL = TBL + "</table>";
                        if (p == pagecount - 1)
                            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  


               // TBL += "</table>";
              //  TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                TBL += "<tr valign='top'>";
                for (int GT = 0; GT < ds.Tables[0].Columns.Count+1; GT++)
                {
                    TBL += "<td class='middle111' align='right' >";
                }

               
                TBL += "Page  " + s + "  of  " + pagecount;
                TBL += "</td></tr>";

                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";

                TBL += "<tr>";
                TBL += "<td class='middle31new' valign='top' align='left' width='25%'>" + "S.No." + "</td>";

                for (int fr1 = 0; fr1 < ds.Tables[0].Columns.Count; fr1++)
                {
                    if (fr1 == 0)
                    {
                        TBL = TBL + ("<td class='middle31new' valign='top' align='left' width='25%'>");
                        TBL = TBL + (ds.Tables[0].Columns[fr1].ToString() + "</td>");

                    }
                    else
                    {
                        //TBL = TBL + "<td class='middle31new' width='130px'  colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Columns[fr1].ToString() + "</br>Booked&nbsp;&nbsp;&nbsp;Available</td>";
                        //fr1 = fr1 + 1;
                        TBL = TBL + ("<td class='middle31new' width='25%' align='right'>" + ds.Tables[0].Columns[fr1].ToString() + "(" + "Booked" + ")" + "</td>");
                        TBL = TBL + ("<td class='middle31new' width='25%'  colspan='2' align='right'>" + ds.Tables[0].Columns[fr1].ToString() + "(" + "Available" + ")" + "</td>");
                        fr1 = fr1 + 1;
                    }

                }
               // TBL += "<td class='middle123' align='left' valign='top'>" + "CIOID" + "</td>";
                
                TBL += "</tr>";

                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                    TBL += "<tr>";
                    TBL = TBL + ("<td class='rep_data' valign='top' align='left' >");
                    TBL = TBL + (a.ToString() + "</td>");

                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            TBL = TBL + ("<td class='rep_data' align='left'>");
                            TBL = TBL + (ds.Tables[0].Rows[d].ItemArray[j].ToString()  + "</td>");

                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d].ItemArray[j].ToString() != "")
                            {
                               // TBL = TBL + ("<td class='rep_data' align='right'>");
                               // TBL = TBL + (ds.Tables[0].Rows[d].ItemArray[j].ToString() + "</td>");
                                //TBL = TBL + "<td class='rep_data' width='120px'  colspan='2'>" + ds.Tables[0].Rows[d].ItemArray[j].ToString() + "&nbsp;&nbsp;" + ds.Tables[0].Rows[d].ItemArray[j+1].ToString() + "</td>";
                                TBL = TBL + ("<td class='rep_data' width='25%'  align='right'>" + ds.Tables[0].Rows[d].ItemArray[j].ToString() + "</td>");
                                TBL = TBL + ("<td class='rep_data' width='25%'  colspan='2' align='right'>" + ds.Tables[0].Rows[d].ItemArray[j + 1].ToString() + "</td>");
                       
                            }
                            //else
                            //{
                            //    TBL = TBL + "<td class='rep_data' width='120px'  colspan='2'>0&nbsp;&nbsp;0</td>";
                               
                            //}
                            j++;
                        }
                    }
                    TBL += "</tr>";

                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    div1.InnerHtml += TBL;
                    TBL = "";

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }

            TBL = TBL + "</tr>";
           // TBL += "</table>";
            if (browser.Browser == "Firefox")
            {
                TBL = TBL + "</table></P>";

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    TBL = TBL + "</table></P>";

                }
                else if (ver == 6.0)
                {
                    TBL = TBL + "</table>";

                }
            }  

            div1.Visible = true;
            //div1.InnerHtml = TBL;
            div1.InnerHtml += TBL;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }

    }
}
