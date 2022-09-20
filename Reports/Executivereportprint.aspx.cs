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
using System.IO;
using System.Data.SqlClient;

public partial class Executivereportprint : System.Web.UI.Page
{
    int maxlimit = 15;
    int a = 0;
    int sno = 1;
    double amtsum = 0;
    string adtyp = "";
    string destination = "";

    string fromdt = "";
    string dateto = "";

    string date = "";

    string day = "";
    string month = "";
    string year = "";

    string pdfName1 = "";
    double amtnew = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string package = "";
    //int area = 0;
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    double ARR = 0;
    int i1 = 1;
    double amt = 0;
    string client = "";
    string agency = "";
    string publicationname = "";
    string publicationcode = "";
    string editionname1 = "";
    string editioncode = "";
    string adcatname1 = "";
    string adcatcode = "";
    string adtypename1 = "";
    string adtypecode = "";
    string teamname = "";
    string teamcode = "";
    string execname = "";
    string execcode = "";

    string adtypename = "";
    string editionname = "";
    string adcat = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string adcatname = "";


    string sortorder = "";
    string sortvalue = "";

     string ascdesc1 = "";
    string descid1 = "", pubcentcode = "", pubcentname="";

    string page = "", region = "", rep = "", place = "", grp = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
       
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[19].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        hiddendateformat.Value = Session["dateformat"].ToString();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/categoryreport.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();

       
        ds = (DataSet)Session["exereport"];
        string prm = Session["prm_exereport_print"].ToString();
        string[] prm_Array = new string[35];
        prm_Array = prm.Split('~');

        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        teamcode = prm_Array[5]; //Request.QueryString["teamcode"].ToString();
        teamname = prm_Array[7]; //Request.QueryString["teamname"].ToString();
        execcode = prm_Array[9]; //Request.QueryString["repcode"].ToString();
        execname = prm_Array[11]; //Request.QueryString["repname"].ToString();
        adtypecode = prm_Array[13]; //Request.QueryString["adtypecode"].ToString();
        adtypename1 = prm_Array[15]; //Request.QueryString["adtypename"].ToString();
        editioncode = prm_Array[17]; //Request.QueryString["editioncode"].ToString();
        adcatcode = prm_Array[19]; //Request.QueryString["adcatcode"].ToString();
        publicationcode = prm_Array[21]; //Request.QueryString["publicationcode"].ToString();
        publicationname = prm_Array[23]; //Request.QueryString["publicationname"].ToString();
        editionname1 = prm_Array[25]; //Request.QueryString["editionname"].ToString();        
        adcatname1 = prm_Array[27]; //Request.QueryString["adcatname"].ToString();
        ascdesc1 = prm_Array[29]; //Request.QueryString["ascdesc1"].ToString();
        descid1 = prm_Array[31]; //Request.QueryString["descid1"].ToString();
        pubcentcode = prm_Array[33]; //Request.QueryString["pubcentcode"].ToString();
        pubcentname = prm_Array[35]; //Request.QueryString["pubcentname"].ToString();



        Ajax.Utility.RegisterTypeForAjax(typeof(Executivereportprint));
        hiddendatefrom.Value = fromdt.ToString();

          if ((publicationcode == "0") || (publicationcode == ""))
        {
            lblpublication.Text = "ALL".ToString();
        }
        else
        {
            lblpublication.Text = publicationname.ToString();
        }

        if ((editioncode == "0") || (editioncode == ""))
        {
            lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname1.ToString();
        }

        if ((adcatcode == "0") || (adcatcode == ""))
        {
            lbladcat.Text = "ALL".ToString();
        }
        else
        {
            lbladcat.Text = adcatname1.ToString();
        }


        if ((adtypecode == "0") || (adtypecode == ""))
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypename1.ToString();
        }

        if ((teamcode == "0") || (teamcode == ""))
        {
            lblteam.Text = "ALL".ToString();
        }
        else
        {
            lblteam.Text = teamname.ToString();
        }

        if ((execcode == "0") || (execcode == ""))
        {
            lblexec.Text = "ALL".ToString();
        }
        else
        {
            lblexec.Text = execname.ToString();
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

        lblrundate.Text = date.ToString();

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


    onscreen(adtyp, adcat, fromdt, dateto, publ, Session["compcode"].ToString(), Session["dateformat"].ToString());
     

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

    private void onscreen(string adtyp, string adcat, string fromdt, string dateto, string publ, string compcode, string dateformat)
    {
        
        SqlDataAdapter da = new SqlDataAdapter();
        
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
            pagecount = pagecount + 1;
        string cu = Session["drpcurrency1234"].ToString();
        string tbl = "";
        
        int j = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
           // tbl = "<table width='100%' cellspacing='0px' cellpadding = '5px' border='0' align='left' valign='top'>";
            if (browser.Browser == "Firefox")
            {
                tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table></P>";
                    if (p == pagecount - 1)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl = tbl + "</table></P>";
                        if (p == pagecount - 1)
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1)
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  

                //tbl += "</table>";
                //tbl += "<table width='100%' cellspacing='0px' cellpadding = '5px' border='0'  class='break' valign='top'>";
                tbl += "<tr valign='top'>";
                tbl += "<td class='middle111' align='right' colspan='6'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>";


                tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td  class='middle31new' align='left'>Executive</td><td class='middle31new' align='left'>Ad Category</td><td  class='middle31new' align='right'>GrossAmt</td><td  class='middle31new' align='right'>UOM</td><td  class='middle31new' align='right'>Edition</td><td  class='middle31new' align='right'>Area</td><td  class='middle31new' align='right'>Yield</td></tr>");



                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                 {




                    if (ascdesc1 == "Name")
                    {
                        if (ds.Tables[0].Rows[d]["Name"].ToString() != ds.Tables[1].Rows[j]["Name"].ToString())
                        {
                            tbl = tbl + ("<tr >");

                            tbl = tbl + ("<td class='rep_data' colspan='2' valign='top'><b>");
                            tbl = tbl + "" + "</b></td>";
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";
                            tbl = tbl + ("<td class='rep_data' valign='top' align='right'><b>");
                            
                                tbl = tbl + "Sub Total:" + (Convert.ToDouble(ds.Tables[1].Rows[j]["GrossAmt"]).ToString("F2") + "</b></td>");
                            
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";

                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";



                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";

                            //=======================
                            tbl = tbl + "</tr>";

                            j++;
                        }
                    }
                    else
                    {

                        if (ds.Tables[0].Rows[d]["Category"].ToString() != ds.Tables[1].Rows[j]["Category"].ToString())
                        {
                            tbl = tbl + ("<tr >");



                            tbl = tbl + ("<td class='rep_data' colspan='2' valign='top'><b>");
                            tbl = tbl + "" + "</b></td>";
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";
                            tbl = tbl + ("<td class='rep_data' valign='top' align='right'><b>");
                            if (cu != "All")
                            {
                                tbl = tbl + "Sub Total:" + (Convert.ToDouble(ds.Tables[1].Rows[j]["GrossAmt"]).ToString("F2") + "</b></td>");
                            }
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";
                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";



                            tbl = tbl + ("<td class='rep_data' valign='top'>");
                            tbl = tbl + "" + "</td>";

                            //=======================
                            tbl = tbl + "</tr>";

                            j++;
                        }
                    }

                    /***********************************************************************************************/

                    a = d;
                    a = a + 1;
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (a.ToString() + "</td>");



                    string exe_name = "";
                    string rrr = ds.Tables[0].Rows[d]["Name"].ToString();
                    if (rrr.Length >= 40)
                    {
                        exe_name = rrr.Substring(0, 40);
                        if (rrr.Length - 40 < 40)
                            exe_name += "</br>" + rrr.Substring(40, rrr.Length - 40);
                        else
                            exe_name += "</br>" + rrr.Substring(40, 40);
                    }
                    else
                        exe_name = rrr;
                    //----------------------------------------------------------------///


                    tbl = tbl + ("<td class='rep_data' align='left' width='180px'>");
                    tbl = tbl + (exe_name + "</td>");

                    string category_name = "";
                    string rrr1 = ds.Tables[0].Rows[d]["Category"].ToString();
                    if (rrr1.Length >= 30)
                    {
                        category_name = rrr1.Substring(0, 30);
                        if (rrr1.Length - 30 < 30)
                            category_name += "</br>" + rrr1.Substring(30, rrr1.Length - 30);
                        else
                            category_name += "</br>" + rrr1.Substring(30, 30);
                    }
                    else
                        category_name = rrr1;
                    //----------------------------------------------------------------///
                    tbl = tbl + ("<td class='rep_data' align='left' width='120px'>");
                    tbl = tbl + (category_name + "</td>");



                    tbl = tbl + ("<td class='rep_data' valign='top' align='right' width='120px'>");
                    
                        tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["GrossAmt"]).ToString("F2") + "</td>");
                    
                    if (ds.Tables[0].Rows[d]["GrossAmt"].ToString() != "")
                   
   amt = amt + double.Parse(ds.Tables[0].Rows[d]["GrossAmt"].ToString());
                    string cur = "";
                    if (ds.Tables[0].Rows[d]["Currency"].ToString() == "DO0")
                    {
                        cur = "USD";
                    }
                    else
                    {
                        cur = "KYAT";
                    }


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");



                    tbl = tbl + cur;

                    //=====================
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (string.Format("{0:0.00}", ds.Tables[0].Rows[d]["uom"]) + "</td>");
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (string.Format("{0:0.00}", ds.Tables[0].Rows[d]["edition"]) + "</td>");
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (string.Format("{0:0.00}",ds.Tables[0].Rows[d]["Area"]) + "</td>");
                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                    {


                        if (ds.Tables[0].Rows[d]["uom"].ToString() == "CD" || ds.Tables[0].Rows[d]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());


                    }


                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["ARR"] + "</td>");
                    if (ds.Tables[0].Rows[d]["ARR"].ToString() != "")
                        ARR = ARR + double.Parse(ds.Tables[0].Rows[d]["ARR"].ToString());
                    //=======================
                    tbl = tbl + "</tr>";

                    tbl += "<tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr>";


                    tblgrid.InnerHtml += tbl;
                    tbl = "";

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
            }




            tbl = tbl + ("<tr >");



            tbl = tbl + ("<td class='upper2' colspan='2' valign='top'><b>");
            tbl = tbl +  "</b></td>";
            tbl = tbl + ("<td class='rep_data' valign='top'>");
            tbl = tbl + "" + "</td>";
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'><b>");
            if (cu != "All")
            {
                tbl = tbl + "Sub Total:" + (Convert.ToDouble(ds.Tables[1].Rows[j]["GrossAmt"]).ToString("F2") + "</b></td>");
            }
            tbl = tbl + ("<td class='rep_data' valign='top'>");
            tbl = tbl + "" + "</td>";


            tbl = tbl + ("<td class='rep_data' valign='top'>");
            tbl = tbl + "" + "</td>";

            //=======================
            tbl = tbl + "</tr>";

            /**********************************************************************************************************/

    
            //tbl = tbl + ("<tr >");
            //tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='6'>&nbsp;");
            ////tbl = tbl + ((i1 - 1).ToString());
            //tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            //tbl = tbl + "<b>Total Gross Amount:</b>" + (amt.ToString("F2"));
            //tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            //double cal = System.Math.Round(Convert.ToDouble(area), 2);
            //tbl = tbl + "<b>Total Area:</b>" + (cal.ToString());

            //if (totrol > 0)
            //{
            //    tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            //    double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            //    tbl = tbl + "<b>Total Lines:</b>" + (calf.ToString());
            //}

            //if (totcd > 0)
            //{
            //    tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            //    double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            //    tbl = tbl + "<b>Total Chars:</b>" + (calfd.ToString());
            //}

            //if (totcc > 0)
            //{
            //    tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            //    double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            //    tbl = tbl + "<b>Total Words:</b>" + (calft.ToString() + "</td>");
            //}
            //tbl = tbl + "</tr>";
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle31new' >Total</td>");

            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle31new' align='left' >");
                tbl = tbl + "Lines:&nbsp&nbsp;" + (calf.ToString()) + "</td>";
            }
            else
                tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle31new' align='left'>");
                tbl = tbl + "Chars:&nbsp&nbsp;" + (calfd.ToString()) + "</td>";

            }
            else
                tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");


            if (cu != "All")
            {
                tbl = tbl + ("<td class='middle31new'  align='right'>" + (amt.ToString("F2")) + "</td>");
            }
            tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
            tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
            tbl = tbl + ("<td class='middle31new'  align='right'>Area:&nbsp;&nbsp;" + (cal.ToString("F2")) + "&nbsp;&nbsp;</td>");
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle31new' align='left'>");
                tbl = tbl + "Words:&nbsp&nbsp;" + (calft.ToString()) + "</td>";

            }
            else
                tbl = tbl + ("<td class='middle31new' >&nbsp;</td>");
            tbl = tbl + ("</tr >");

            if (browser.Browser == "Firefox")
            {
                tbl = tbl + "</table></P>";

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl = tbl + "</table></P>";

                }
                else if (ver == 6.0)
                {
                    tbl = tbl + "</table>";

                }
            }
          //  tbl = tbl + ("</table>");
            tblgrid.InnerHtml += tbl;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
}
