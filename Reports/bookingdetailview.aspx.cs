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
using System.Text.RegularExpressions;
public partial class Reports_bookingdetailview : System.Web.UI.Page
{
    string currency = "";
    string clientname = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    int maxlimit = 20;
    string publ = "";
    string pubcen = "";
    string pubcenter = "";
    string publication = "";
    string edition = "";
    string date = "";
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string client = "";
    string agname = "";
    string status = "";
    string status1 = "";
    string hold = "";
    string adtypename = "", useid = "", chk_acc = "", extra1 = "", extra2 = "", dpclient="";
  string publi="";
    string agencyname = "";
    string fromdate = "", pubname = "", pubnamecode = "", pubcent = "", branch_c="";
    string dateto = "", agtype = "", branch = "", agnecycode = "", agnecyname = "", clientcode="";
    string cleint = "",branchcode="", pubcentcode="";
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    string ban1 = "";
    string package = "";
    string sortorder = "";
    string sortvalue = "";
    double areanew = 0;
    string editioncode = "";
    string agencytypecode = "";
    string agencytypename = "", agencytype = "", agencytyp="",curr123="";
    int sno = 1;
    string edit = "";
    double comm2 = 0;
    //DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    DataSet ds = new DataSet();
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
    static string MDYToDMY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[57].ToString());
        maxlimit = 10;
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }

        DataSet ds2 = new DataSet();
        ds2.ReadXml(Server.MapPath("XML/Booking_detail.xml"));
        cmpnyname.Text = ds2.Tables[0].Rows[0].ItemArray[12].ToString();
        //Session["AGENCY"] = heading.Text;
        //hiddenedition.Value = 
        //hiddeneditionname.Value = 
        //hdnagency1.Value = 
        //hdnclient1.Value = 
        //hiddendppub1.Value = 
        //hiddenuseid.Value = 
        ds.ReadXml(Server.MapPath("XML/bokinghead.xml"));

        DataSet ds1 = new DataSet();
        //ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        //heading.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();

        //ds = (DataSet)Session["Deviation"];
        //string prm = Session["prm_Deviation"].ToString();
        //string[] prm_Array = new string[43];
        //prm_Array = prm.Split('~');
        currency = Request.QueryString["currency_typename1"].ToString();
        curr123 = Request.QueryString["currency_typename1"].ToString();
        agnecycode = Request.QueryString["agency_code1"].ToString();
        agnecyname = Request.QueryString["agency_name1"].ToString();
        clientcode = Request.QueryString["client_code1"].ToString();
        clientname = Request.QueryString["client_name1"].ToString();
        fromdate = Request.QueryString["from_date1"].ToString();
        dateto = Request.QueryString["todate1"].ToString();
        pubname = Request.QueryString["pub_name1"].ToString();
        pubnamecode = Request.QueryString["pub_code1"].ToString();
        edition = Request.QueryString["edition_name1"].ToString();
        editioncode = Request.QueryString["edition_code1"].ToString();
        pubcent = Request.QueryString["publication_center1"].ToString();
        branch_c = Request.QueryString["branch_name1"].ToString();
        useid = Request.QueryString["userid1"].ToString();
        destination = Request.QueryString["dest1"].ToString();
        pubcentcode = Request.QueryString["pubcent_code1"].ToString();
        branchcode = Request.QueryString["branch_code1"].ToString();
        agencytypecode = Request.QueryString["agency_typecode1"].ToString();
        agencytypename = Request.QueryString["agency_typename1"].ToString();
        hiddenedition.Value = edition;

        btnprint.Attributes.Add("OnClick", "javascript:return window.print();" );


            if (pubcentcode == "0" || pubcentcode == "")
            {
                pubcentcode = "";
            }
            if (branchcode == "0" || branchcode == "")
            {
                branchcode = "";
            }
            if (agencytypecode == "0" || agencytypecode == "")
            {
                agencytypecode = "";
            }
            if (pubnamecode == "0" || pubnamecode == "")
            {
                pubnamecode = "";
            }
            

        hold = "abc";
        hiddendatefrom.Value = fromdt.ToString();
        if (agencytypecode == "0" || agencytypecode == "")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = agencytypename.ToString();

        }
        agtype = branch_c;
        if (agtype != "Select Branch")
        {
            lblagtype.Text =  branch_c.ToString();
        }
       if (agtype=="Select Branch")
        {
            lblagtype.Text = "ALL".ToString();
        }
        publ = pubname;
        if (publ != "--Select Publication--")
        {
            lblpub.Text = pubname.ToString();
        }
        if (publ == "--Select Publication--")
        {
            lblpub.Text = "ALL".ToString();
        }
        pubcen = pubcent;
        if (pubcen != "--Select Publication Center--")
        {
            pcenter.Text = pubcent.ToString();
        }
        if (pubcen == "--Select Publication Center--")
        {
            pcenter.Text = "ALL".ToString();
        }

        //if (clientname == "0" || clientname == "")
        //{

        //    lbclient.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lbclient.Text = clientname.ToString();
        //}

        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editioncode.ToString();

        }
        //if (agnecyname == "0" || agnecyname == "")
        //{
        //    heading.Text = "".ToString();
        //}
        //else
        //{
        //    heading.Text = agnecyname.ToString();
        
        //}

        if (fromdate != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdate.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);
                }
            }
        }
        lblfrom.Text = fromdate;
        //dateto1 = "";
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto = dd + "/" + mm + "/" + yy;

            }


            else
            {

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);
                }
            }
        }
        lblto.Text = dateto;

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
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(edition, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), useid, Session["compcode"].ToString(), chk_acc,agencytype, extra1, extra2,currency);
            }
            else if (destination == "4")
            {
               excel(edition, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), useid, Session["compcode"].ToString(), chk_acc,agencytype, extra1, extra2,currency);

            }
           else if (destination == "3")
            {
                pdf(edition, agnecycode, fromdate, dateto, clientcode, pubnamecode, pubcentcode, branchcode, Session["dateformat"].ToString(), useid, Session["compcode"].ToString(), chk_acc, agencytype, extra1, extra2,currency);

            }
        }

    }



    public string RETURN_LENGTH(string str_decimal)
    {

        string x = "";
        if (str_decimal.Length == 1)
            x =

            "0" + str_decimal;
        else
            x = str_decimal;

        return x;
    }









    private void onscreen(string edition, string agnecycode, string fromdate, string dateto, string clientcode, string pubname, string pubcentcode, string branchcode, string dateformat, string useid, string compcode, string chk_acc,string agencytype, string extra1, string extra2,string currency)
    {
        double tot_billamt = 0;
         int sn = 1;
        int m11 = 0;
        string page = "";
        string position = "";
        int p=1;

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

        //   if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        // {
        


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(fromdate);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                dateto = YMDToMDY(dateto);
            }
            else if (hiddendateformat.Value == "mm/dd/yyyy")
            {
                fromdate = MDYToDMY(fromdate);
                dateto = MDYToDMY(dateto);
            }


            NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
            ds1 = obj.booking(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc,agencytypecode, extra1, extra2,currency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
            ds1 = obj.booking1(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency);
        }
        else
        {
            if (edition == "0")
                edition = "";

            string procedureName = "rpt_booking_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency };
            string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency};
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        StringBuilder TBL = new StringBuilder();
        int cont = ds.Tables[0].Rows.Count;
        if (cont == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        else
        {
            cmpnyname.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            heading.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            //lbpage.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString()+p++;
            if (ds.Tables[0].Rows.Count > 0)
            {

                TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='0'colspan='2' width='100%'>");
                // TBL = TBL + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                //=====================================For column Name ===============================================//
                TBL.Append("<tr><td style='padding-left:4px' class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append("Sr. No." + "</td>");

                TBL.Append("<td style='padding-left:4px' class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[0].ToString().ToUpper() + "</td>");// ds.Tables[0].Columns[t].ToString().ToUpper()
                //TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                //TBL.Append(ds.Tables[0].Rows[0].ItemArray[0].ToString() + "</br>" + ds.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[1].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[2].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[3].ToString() +"</br>"+ds.Tables[0].Columns[4].ToString()+ "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[5].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[6].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[7].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[8].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[9].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[10].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[11].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[12].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[13].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[14].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[15].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[16].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[17].ToString() + "</br>" /*+ ds.Tables[0].Columns[21].ToString()*/ + "</td>");

                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append("Currency" + "</td>");
                TBL.Append("</tr>");
                // ======================================= For values ===================================================


                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {


                    TBL.Append("<tr font-size='10' font-family='Arial' >");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(sn + "</td>");
                    TBL.Append("<td class='newfont1' align='left'>");


                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[m]["BOOKING_ID"].ToString();
                    if (rrr.Length >= 12)
                    {
                        cioid1 = rrr.Substring(0, 12);
                        if (rrr.Length - 12 < 12)
                            cioid1 += "</br>" + rrr.Substring(12, rrr.Length - 12);
                        else
                            cioid1 += "</br>" + rrr.Substring(12, 12);
                    }
                    else
                        cioid1 = rrr;


                    TBL.Append(cioid1 + "</td>");

                    //TBL.Append( "<td class='newfont1'align='left'>");
                    //TBL.Append(ds.Tables[0].Rows[m]["AGENCY"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    string cioid2 = "";
                    string rr = ds.Tables[0].Rows[m]["AGENCY"].ToString();
                    if (rr.Length >= 40)
                    {
                        cioid2 = rr.Substring(0, 40);
                        if (rr.Length - 40 < 40)
                            cioid2 += "</br>" + rr.Substring(40, rr.Length - 40);
                        else
                            cioid2 += "</br>" + rr.Substring(40, 40);
                    }
                    else
                        cioid2 = rr;


                    TBL.Append(cioid2 + "</td>");
                    //TBL.Append( "<td class='newfont1'align='left'>");
                    //TBL.Append(ds.Tables[0].Rows[m]["CLIENT"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    string cioid3 = "";
                    string rr1 = ds.Tables[0].Rows[m]["CLIENT"].ToString();
                    if (rr1.Length >= 50)
                    {
                        cioid3 = rr1.Substring(0, 50);
                        if (rr1.Length - 50 < 50)
                            cioid3 += "</br>" + rr1.Substring(50, rr1.Length - 50);
                        else
                            cioid3 += "</br>" + rr1.Substring(50, 50);
                    }
                    else
                        cioid3 = rr1;


                    TBL.Append(cioid3 + "</td>");
                    //TBL.Append( "<td class='newfont1'align='left'>");
                    // TBL.Append(ds.Tables[0].Rows[m]["CAPTION"].ToString()+"</br>"+  ds.Tables[0].Rows[m]["KEY"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    string cioid4 = "";
                    string rr2 = (ds.Tables[0].Rows[m]["CAPTION"].ToString() + "</br>" + ds.Tables[0].Rows[m]["KEY"].ToString());
                    if (rr2.Length >= 35)
                    {
                        cioid4 = rr2.Substring(0, 35);
                        if (rr2.Length - 35 < 35)
                            cioid4 += "</br>" + rr2.Substring(35, rr2.Length - 35);
                        else
                            cioid4 += "</br>" + rr2.Substring(35, 35);
                    }
                    else
                        cioid4 = rr2;


                    TBL.Append(cioid4 + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["DEPTH"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["WIDTH"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AREA"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["COLOR"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["PAGE_NO"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='center'>");
                    TBL.Append(ds.Tables[0].Rows[m]["EXE_RET"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='center'>");
                    TBL.Append(ds.Tables[0].Rows[m]["CARDRATE"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AGGRATE"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["GROSSAMT"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AGENCYTD(%)"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AgencyAddlTD(%)"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["CASH_DISC"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(chk_null(ds.Tables[0].Rows[m]["BILLAMT"].ToString()) + "</td>");
                    


                    string curr="";
                    if(ds.Tables[0].Rows[m]["currency"].ToString()=="DO0")
                    {
                        curr="USD";

                    }
                    else if (ds.Tables[0].Rows[m]["currency"].ToString() == "KY0")
                    {
                        curr = "KYAT";

                    }
                    else
                    {
                        curr = "Rupees";

                    }

                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(curr + "</td>");


                    if(ds.Tables[0].Rows[m]["BILLAMT"].ToString()!="")
                    {
                        tot_billamt = tot_billamt +Convert.ToDouble(ds.Tables[0].Rows[m]["BILLAMT"].ToString());
                    }

                    

                    TBL.Append("</tr>");
                    //subregrepDiv.InnerHtml = TBL.ToString();                
                    sn++;
                }



            }


            if (currency != "All")
            {
                TBL.Append("<tr><td class='middle31new' colspan='2' align='left'>Total</td>");


                TBL.Append("<td colspan='16' class='middle31new' align='right'>" + chk_null(tot_billamt.ToString()) + "</td><td class='middle31new' align='right'>" + "&nbsp;" + "</td></tr>");
            }
            else
            {

                TBL.Append("<tr><td class='middle31new' colspan='19' align='left'></td>");
            }
            TBL.Append("</table>");

            tblgrid.InnerHtml = TBL.ToString();

            btnprint.Focus();
        }
        
    }



    private void excel(string edition, string agnecycode, string fromdate, string dateto, string clientcode, string pubname, string pubcentcode, string branchcode, string dateformat, string useid, string compcode, string chk_acc, string agencytype, string extra1, string extra2, string currency)
    {
        double tot_billamt = 0;
        int sn = 1;
        int m11 = 0;
        string page = "";
        string position = "";
        int p = 1;

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(fromdate);
                dateto = DMYToMDY(dateto);
            }
            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                dateto = YMDToMDY(dateto);
            }
            else if (hiddendateformat.Value == "mm/dd/yyyy")
            {
                fromdate = MDYToDMY(fromdate);
                dateto = MDYToDMY(dateto);
            }
            NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
            ds1 = obj.booking(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
            ds1 = obj.booking1(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency);
        }
        else
        {
            if (edition == "0")
                edition = "";
            string procedureName = "rpt_booking_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency };
            string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        StringBuilder TBL = new StringBuilder();
        int cont = ds.Tables[0].Rows.Count;
        if (cont == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        else
        {
            cmpnyname.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            heading.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            //lbpage.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString()+p++;
            if (ds.Tables[0].Rows.Count > 0)
            {

                TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='0'colspan='2' width='100%'>");
                // TBL = TBL + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                //=====================================For column Name ===============================================//
                TBL.Append("<tr><td style='padding-left:4px' class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append("Sr. No." + "</td>");

                TBL.Append("<td style='padding-left:4px' class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[0].ToString().ToUpper() + "</td>");// ds.Tables[0].Columns[t].ToString().ToUpper()
                //TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                //TBL.Append(ds.Tables[0].Rows[0].ItemArray[0].ToString() + "</br>" + ds.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[1].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[2].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[3].ToString() + "</br>" + ds.Tables[0].Columns[4].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[5].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[6].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[7].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[8].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[9].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[10].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[11].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[12].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[13].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[14].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='left'>");
                TBL.Append(ds.Tables[0].Columns[15].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[16].ToString() + "</td>");
                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append(ds.Tables[0].Columns[17].ToString() + "</br>" /*+ ds.Tables[0].Columns[21].ToString()*/ + "</td>");

                TBL.Append("<td style='padding-left:4px'class='rep_datatotal_vouchdata' align='center'>");
                TBL.Append("Currency" + "</td>");
                TBL.Append("</tr>");
                // ======================================= For values ===================================================
                for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                {
                    TBL.Append("<tr font-size='10' font-family='Arial' >");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(sn + "</td>");
                    TBL.Append("<td class='newfont1' align='left'>");

                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[m]["BOOKING_ID"].ToString();
                    if (rrr.Length >= 12)
                    {
                        cioid1 = rrr.Substring(0, 12);
                        if (rrr.Length - 12 < 12)
                            cioid1 += "</br>" + rrr.Substring(12, rrr.Length - 12);
                        else
                            cioid1 += "</br>" + rrr.Substring(12, 12);
                    }
                    else
                        cioid1 = rrr;

                    TBL.Append(cioid1 + "</td>");
                 
                    TBL.Append("<td class='newfont1'align='left'>");
                    string cioid2 = "";
                    string rr = ds.Tables[0].Rows[m]["AGENCY"].ToString();
                    if (rr.Length >= 40)
                    {
                        cioid2 = rr.Substring(0, 40);
                        if (rr.Length - 40 < 40)
                            cioid2 += "</br>" + rr.Substring(40, rr.Length - 40);
                        else
                            cioid2 += "</br>" + rr.Substring(40, 40);
                    }
                    else
                        cioid2 = rr;

                    TBL.Append(cioid2 + "</td>");
                    //TBL.Append( "<td class='newfont1'align='left'>");
                    //TBL.Append(ds.Tables[0].Rows[m]["CLIENT"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    string cioid3 = "";
                    string rr1 = ds.Tables[0].Rows[m]["CLIENT"].ToString();
                    if (rr1.Length >= 50)
                    {
                        cioid3 = rr1.Substring(0, 50);
                        if (rr1.Length - 50 < 50)
                            cioid3 += "</br>" + rr1.Substring(50, rr1.Length - 50);
                        else
                            cioid3 += "</br>" + rr1.Substring(50, 50);
                    }
                    else
                        cioid3 = rr1;

                    TBL.Append(cioid3 + "</td>");
                    //TBL.Append( "<td class='newfont1'align='left'>");
                    // TBL.Append(ds.Tables[0].Rows[m]["CAPTION"].ToString()+"</br>"+  ds.Tables[0].Rows[m]["KEY"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='left'>");
                    string cioid4 = "";
                    string rr2 = (ds.Tables[0].Rows[m]["CAPTION"].ToString() + "</br>" + ds.Tables[0].Rows[m]["KEY"].ToString());
                    if (rr2.Length >= 35)
                    {
                        cioid4 = rr2.Substring(0, 35);
                        if (rr2.Length - 35 < 35)
                            cioid4 += "</br>" + rr2.Substring(35, rr2.Length - 35);
                        else
                            cioid4 += "</br>" + rr2.Substring(35, 35);
                    }
                    else
                        cioid4 = rr2;


                    TBL.Append(cioid4 + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["DEPTH"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["WIDTH"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AREA"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["COLOR"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["PAGE_NO"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='center'>");
                    TBL.Append(ds.Tables[0].Rows[m]["EXE_RET"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='center'>");
                    TBL.Append(ds.Tables[0].Rows[m]["CARDRATE"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AGGRATE"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["GROSSAMT"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AGENCYTD(%)"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["AgencyAddlTD(%)"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(ds.Tables[0].Rows[m]["CASH_DISC"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(chk_null(ds.Tables[0].Rows[m]["BILLAMT"].ToString()) + "</td>");

                    string curr = "";
                    if (ds.Tables[0].Rows[m]["currency"].ToString() == "DO0")
                    {
                        curr = "USD";
                    }
                    else if (ds.Tables[0].Rows[m]["currency"].ToString() == "KY0")
                    {
                        curr = "KYAT";
                    }
                    else
                    {
                        curr = "Rupees";
                    }

                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(curr + "</td>");

                    if (ds.Tables[0].Rows[m]["BILLAMT"].ToString() != "")
                    {
                        tot_billamt = tot_billamt + Convert.ToDouble(ds.Tables[0].Rows[m]["BILLAMT"].ToString());
                    }

                    TBL.Append("</tr>");
                    //subregrepDiv.InnerHtml = TBL.ToString();                
                    sn++;
                }

            }

            if (currency != "All")
            {
                TBL.Append("<tr><td class='middle31new' colspan='2' align='left'>Total</td>");
                TBL.Append("<td colspan='16' class='middle31new' align='right'>" + chk_null(tot_billamt.ToString()) + "</td><td class='middle31new' align='right'>" + "&nbsp;" + "</td></tr>");
            }
            else
            {
                TBL.Append("<tr><td class='middle31new' colspan='19' align='left'></td>");
            }
            TBL.Append("</table>");
            // tblgrid.InnerHtml = TBL.ToString();

            if (destination == "4")
            {
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

                //tblgrid.InnerHtml = TBL.ToString();
                 tblgrid.InnerHtml += TBL;

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                hw.WriteBreak();
                tblgrid.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                tblgrid.InnerHtml += TBL;
            }


            btnprint.Focus();
        }
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


   /* private void excel(string edition, string agnecycode, string fromdate, string dateto, string clientcode, string pubname, string pubcentcode, string branchcode, string dateformat, string useid, string compcode, string chk_acc,string agencytype, string extra1, string extra2,string currency)

    {
        double tot_billamt = 0;
        int snoo = 1;

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

        
        //if (agnecyname == "0" || agnecyname == "")
        //{
        //    heading.Text = "".ToString();
        //}
        //else
        //{
        //    heading.Text = agnecyname.ToString();

        //}
        
        //try
        //{
           if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    fromdate = DMYToMDY(fromdate);
                    dateto = DMYToMDY(dateto);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    fromdate = YMDToMDY(fromdate);
                    dateto = YMDToMDY(dateto);
                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    fromdate = MDYToDMY(fromdate);
                    dateto = MDYToDMY(dateto);
                }



                NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
                ds1 = obj.booking(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc,agencytypecode, extra1, extra2,currency);
            }
           else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
                ds1 = obj.booking1(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc,agencytypecode, extra1, extra2,currency);
            }
            else
            {
                string procedureName = "rpt_booking_report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}

        StringBuilder TBL = new StringBuilder();
        int cont = ds1.Tables[0].Rows.Count;
        if (cont == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        else
        {
            cmpnyname.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
            //heading.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            //heading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //cmpnyname.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();


            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            TBL.Append("<table border='1'><tr><td align='left' colspan='3'><b>Publication:</b>" + lblpub.Text + "</td>");
            TBL.Append("<td align='left' colspan='6'><b>Pub cent</b>" + pcenter.Text + "</td>");
            TBL.Append("<td align='left' colspan='6'><b>Branch</b>" + lblagtype.Text + "</td>");
            TBL.Append("<td align='left' colspan='3'><b>Edition</b>" + lbedition.Text + "</td></tr>");

            TBL.Append("<tr><td align='left' colspan='3'><b>Agency:</b>" + lbladtype.Text + "</td>");
            TBL.Append("<td align='left' colspan='6'><b>Date From:</b>" + lblfrom.Text + "</td>");
            // TBL.Append("<td align=left>:" + fromdate + "</td>");

            TBL.Append("<td align='left'  colspan='6'><b>Date To:</b>" + lblto.Text + "</td>");
            //TBL.Append("<td align=left>:" + dateto + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");



            TBL.Append("<td align='left' colspan='3'><b>Run Date:</b>" + date + "</td>");
            //TBL.Append("<td align=left>:" + date + "</td></tr></table>");
            subregrepDiv.InnerHtml = TBL.ToString();


            if (ds1.Tables[0].Rows.Count > 0)
            {

                TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='1'>");


                TBL.Append("<tr><td class='middle31' align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px' class='middle31' align='center'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px' class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></td>");
                TBL.Append("<td  style='padding-left:4px' class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[5].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='center'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[7].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[10].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[11].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='center'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[14].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31'  align='center'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[15].ToString() + "</b></td>");
                TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                TBL.Append("<b>" + ds.Tables[0].Rows[0].ItemArray[16].ToString() + "</b></td>");


                TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                TBL.Append("<b>"+ "Currency" + "</b></td>");
                TBL.Append("</tr>");


                TBL.Append("</tr>");
                // ======================================= For values ===================================================

                
                for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
                {


                    TBL.Append("<tr><td class='newfont1'  align='left'>");
                    TBL.Append(snoo.ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='left'>");


                    string cioid1 = "";
                    string rrr = ds1.Tables[0].Rows[m]["BOOKING_ID"].ToString();
                    if (rrr.Length >= 12)
                    {
                        cioid1 = rrr.Substring(0, 12);
                        if (rrr.Length - 12 < 12)
                            cioid1 += "</br>" + rrr.Substring(12, rrr.Length - 12);
                        else
                            cioid1 += "</br>" + rrr.Substring(12, 12);
                    }
                    else
                        cioid1 = rrr;


                    TBL.Append(cioid1 + "</td>");
                    TBL.Append("<td class='newfont1'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["AGENCY"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["CLIENT"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["CAPTION"].ToString() + "</br>" + ds1.Tables[0].Rows[m]["KEY"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["DEPTH"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["WIDTH"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["AREA"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["COLOR"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["PAGE_NO"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["EXE_RET"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["CARDRATE"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["AGGRATE"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["GROSSAMT"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["AGENCYTD(%)"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["AgencyAddlTD(%)"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1'  align='right'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["CASH_DISC"].ToString() + "</td>");
                    TBL.Append("<td class='newfont1' align='right'>");
                    TBL.Append(chk_null(ds1.Tables[0].Rows[m]["BILLAMT"].ToString()) + "</td>");

                    string curr = "";
                    if (ds1.Tables[0].Rows[m]["currency"].ToString() == "DO0")
                    {
                        curr = "USD";

                    }
                    else if (ds1.Tables[0].Rows[m]["currency"].ToString() == "KY0")
                    {
                        curr = "KYAT";

                    }
                    else
                    {
                        curr = "Rupees";

                    }
                    TBL.Append("<td class='newfont1'align='right'>");
                    TBL.Append(curr + "</td>");


                    if (ds1.Tables[0].Rows[m]["BILLAMT"].ToString() != "")
                    {
                        tot_billamt = tot_billamt + Convert.ToDouble(ds1.Tables[0].Rows[m]["BILLAMT"].ToString());
                    }




                    TBL.Append("</tr>");
                    
                    snoo++;

                }



            }
            if (currency != "All")
            {
                TBL.Append("<tr><td class='middle31new' colspan='2' align='left'>Total</td>");
                TBL.Append("<td class='middle31new' colspan='16' align='right'>" + chk_null(tot_billamt.ToString()) + "</td></tr>");
            }
            subregrepDiv.InnerHtml = TBL.ToString();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            hw.Write("<p><table border='1'><tr><td align='center' colspan='17'><b><b> " + ds1.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></b></td></tr>");
            hw.Write("<p><table border='1'><tr><td align='center'><b><b> " + ds.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></b></td></tr>");
            hw.WriteBreak();
            subregrepDiv.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();

        }


    }*/

   
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
        double tot_billamt = 0;
        int sn = 1;
        int m11 = 0;
        string page = "";
        string position = "";
        int i2 = 0;
        


        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

      

        
        //   if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        // {
        


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(fromdate);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                dateto = YMDToMDY(dateto);
            }
            else if (hiddendateformat.Value == "mm/dd/yyyy")
            {
                fromdate = MDYToDMY(fromdate);
                dateto = MDYToDMY(dateto);
            }



            NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
            ds1 = obj.booking(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc,agencytypecode, extra1, extra2,currency);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
            ds1 = obj.booking1(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency);
        }
        else
        {
            string procedureName = "rpt_booking_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        StringBuilder TBL = new StringBuilder();
        int cont = ds1.Tables[0].Rows.Count;
        if (cont == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        else
        {
            //TBL.Append("<tr><td width='100%' Class='shrey1' align='right'>");1
            //TBL.Append(ds.Tables[0].Rows[0].ItemArray[19].ToString() + ++i2 + "</td></tr>");
            cmpnyname.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
            heading.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            int ct = 0;
            int fr = maxlimit;
            int rcount = ds1.Tables[0].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;
            if (pagec > 0)
                pagecount = pagecount + 1;

            // string tbl = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {

                //if (browser.Browser == "Firefox")
                //{
                //    TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                //}
                //else 
                if (browser.Browser == "IE")
                {
                //    if ((ver == 7.0) || (ver == 8.0))
                //    {
                TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                ////    }
                ////    else if (ver == 6.0)
                ////    {
                ////        TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                 }
                ////}



                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;


                    if (browser.Browser == "Firefox")
                    {
                        TBL.Append("</table></P>");
                        if (p == pagecount||p==0)
                            TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else


                            TBL.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    }
                    //else 
                    if (browser.Browser == "IE")
                    {
                    //    if ((ver == 8.0) || (ver == 7.0))
                    //    {
                    TBL.Append("</table></P>");
                    if (p == pagecount - 1)
                        TBL.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        

                        TBL.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                    //    else if (ver == 6.0)
                    //    {
                    //        TBL.Append("</table>");
                    //        if (p == pagecount - 1)
                    //            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    //        else
                    //            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                    //    }
                    //}



                    TBL.Append("<tr valign='top'>");
                    TBL.Append("<td class='middle111' align='right' colspan='18'>" + "Page  " + s + "  of  " + pagecount);
                    TBL.Append("</td></tr>");





                    TBL.Append("<tr><td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[0].ToString() + "</br>" + ds.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:6px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[2].ToString() + "</br>" + ds.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='left'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                    TBL.Append(ds.Tables[0].Rows[0].ItemArray[16].ToString() + "</br>" + ds.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
                    TBL.Append("<td style='padding-left:4px'class='middle31' align='center'>");
                    TBL.Append("Currency" + "</td>");
                    TBL.Append("</tr>");
                    // ======================================= For values ===================================================


                    //for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
                    //{
                    for (int m = ct; m < ds1.Tables[0].Rows.Count && m < fr; m++)
                    {


                        TBL.Append("<tr font-size='10' font-family='Arial' >");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(sn + "</td>");
                        TBL.Append("<td class='newfont1' align='left'>");


                        string cioid1 = "";
                        string rrr = ds1.Tables[0].Rows[m]["BOOKING_ID"].ToString();
                        if (rrr.Length >= 12)
                        {
                            cioid1 = rrr.Substring(0, 12);
                            if (rrr.Length - 12 < 12)
                                cioid1 += "</br>" + rrr.Substring(12, rrr.Length - 12);
                            else
                                cioid1 += "</br>" + rrr.Substring(12, 12);
                        }
                        else
                            cioid1 = rrr;


                        TBL.Append(cioid1 + "</td>");

                        //TBL.Append( "<td class='newfont1'align='left'>");
                        //TBL.Append(ds1.Tables[0].Rows[m]["AGENCY"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='left'>");
                        string cioid2 = "";
                        string rr = ds1.Tables[0].Rows[m]["AGENCY"].ToString();
                        if (rr.Length >= 40)
                        {
                            cioid2 = rr.Substring(0, 40);
                            if (rr.Length - 40 < 40)
                                cioid2 += "</br>" + rr.Substring(40, rr.Length - 40);
                            else
                                cioid2 += "</br>" + rr.Substring(40, 40);
                        }
                        else
                            cioid2 = rr;


                        TBL.Append(cioid2 + "</td>");
                        //TBL.Append( "<td class='newfont1'align='left'>");
                        //TBL.Append(ds1.Tables[0].Rows[m]["CLIENT"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='left'>");
                        string cioid3 = "";
                        string rr1 = ds1.Tables[0].Rows[m]["CLIENT"].ToString();
                        if (rr1.Length >= 50)
                        {
                            cioid3 = rr1.Substring(0, 50);
                            if (rr1.Length - 50 < 50)
                                cioid3 += "</br>" + rr1.Substring(50, rr1.Length - 50);
                            else
                                cioid3 += "</br>" + rr1.Substring(50, 50);
                        }
                        else
                            cioid3 = rr1;


                        TBL.Append(cioid3 + "</td>");
                        //TBL.Append( "<td class='newfont1'align='left'>");
                        // TBL.Append(ds1.Tables[0].Rows[m]["CAPTION"].ToString()+"</br>"+  ds1.Tables[0].Rows[m]["KEY"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='left'>");
                        string cioid4 = "";
                        string rr2 = (ds1.Tables[0].Rows[m]["CAPTION"].ToString() + "</br>" + ds1.Tables[0].Rows[m]["KEY"].ToString());
                        if (rr2.Length >= 35)
                        {
                            cioid4 = rr2.Substring(0, 35);
                            if (rr2.Length - 35 < 35)
                                cioid4 += "</br>" + rr2.Substring(35, rr2.Length - 35);
                            else
                                cioid4 += "</br>" + rr2.Substring(35, 35);
                        }
                        else
                            cioid4 = rr2;


                        TBL.Append(cioid4 + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["DEPTH"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["WIDTH"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["AREA"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='left'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["COLOR"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["PAGE_NO"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='left'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["EXE_RET"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["CARDRATE"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["AGGRATE"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["GROSSAMT"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["AGENCYTD(%)"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["AgencyAddlTD(%)"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(ds1.Tables[0].Rows[m]["CASH_DISC"].ToString() + "</td>");
                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(chk_null(ds1.Tables[0].Rows[m]["BILLAMT"].ToString()) + "</td>");

                        string curr = "";
                        if (ds1.Tables[0].Rows[m]["currency"].ToString() == "DO0")
                        {
                            curr = "USD";

                        }
                        else if (ds1.Tables[0].Rows[m]["currency"].ToString() == "KY0")
                        {
                            curr = "KYAT";

                        }
                        else
                        {
                            curr = "Rupees";

                        }

                        TBL.Append("<td class='newfont1'align='right'>");
                        TBL.Append(curr + "</td>");

                        if (ds1.Tables[0].Rows[m]["BILLAMT"].ToString() != "")
                        {
                            tot_billamt = tot_billamt + Convert.ToDouble(ds1.Tables[0].Rows[m]["BILLAMT"].ToString());
                        }

                        TBL.Append("</tr>");

                        //subregrepDiv.InnerHtml = TBL.ToString();                
                        sn++;
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;

                }

            }


            //int dttoal = 0;





            if (currency != "All")
            {
                TBL.Append("<tr><td class='middle31new' colspan='2' align='left'>Total</td>");
                TBL.Append("<td class='middle31new'  colspan='16' align='right'>" + chk_null(tot_billamt.ToString()) + "</td><td class='middle31new' align='right'>" + "&nbsp;" + "</td></tr>");
            }
            else
            {

                TBL.Append("<tr><td class='middle31new' colspan='19' ></td>");
            }

            TBL.Append("</table></p>");

            tblgrid.InnerHtml = TBL.ToString();
            btnprint.Visible = false;


        }

}



    private void pdf(string edition, string agnecycode, string fromdate, string dateto, string clientcode, string pubname, string pubcentcode, string branchcode, string dateformat, string useid, string compcode, string chk_acc,string agencytypecode,  string extra1, string extra2,string currency)
    {
        // int reeltotal = 0;
        double tot_billamt = 0;
        int s = 1;
        int m11 = 0;
        int sn = 1;
        int pg = 0;
        int i2 = 0;

        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        // step 2: we create a writer that listens to the document
        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));

        HeaderFooter footer = new HeaderFooter(new Phrase(ds.Tables[0].Rows[0].ItemArray[19].ToString()+i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_RIGHT;
        document.Footer = footer;


        // step 3: we open the document
        document.Open();

        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font12 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font14 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 13, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8, Font.NORMAL);
        Font font13 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);

        try
        {
            DataSet ds1 = new DataSet();


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    fromdate = DMYToMDY(fromdate);
                    dateto = DMYToMDY(dateto);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    fromdate = YMDToMDY(fromdate);
                    dateto = YMDToMDY(dateto);
                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    fromdate = MDYToDMY(fromdate);
                    dateto = MDYToDMY(dateto);
                }


                NewAdbooking.Report.Classes.vtsrpt obj = new NewAdbooking.Report.Classes.vtsrpt();
                ds1 = obj.booking(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc,agencytypecode, extra1, extra2,currency);
            }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.vtsrpt obj = new NewAdbooking.Report.classesoracle.vtsrpt();
                ds1 = obj.booking1(agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency);
            }

            else
            {
                string procedureName = "rpt_booking_report";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { agnecycode, clientcode, fromdate, dateto, pubnamecode, pubcentcode, branchcode, edition, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["compcode"].ToString(), chk_acc, agencytypecode, extra1, extra2, currency };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
                int count = ds1.Tables[0].Rows.Count;
            if (count == 0)
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }
            else
            {

            string pub = "";
            publi = publ;
            if (publi != "--Select Publication--")
            {
                pub = publ.ToString();

            }
            if (publi == "--Select Publication--")
            {
                pub = "ALL".ToString();
            }
            string pubcenter = "";
            pubcen = pubcent;
            if (pubcen != "--Select Publication Center--")
            {
                pubcenter = pubcent.ToString();
            }
            if (pubcen == "--Select Publication Center--")
            {
                pubcenter = "ALL".ToString();
            }
            string bran = "";
            ban1 = branch_c;
            if (ban1 != "Select Branch")
            {
                bran = branch_c.ToString();
            }
            if (ban1 == "Select Branch")
            {
                bran = "ALL".ToString();
            }
            string edi = "";
            edit = editioncode;
            if (edit != "--Select Edition Name--")
            {
                edi = editioncode.ToString();
            }
            if (edit == "--Select Edition Name--")
            {
                edi = "ALL".ToString();
            }

            string shrey = "";

            if (cleint == "0")
            {
                shrey = "ALL".ToString();
            }
            else
            {
                shrey = clientname.ToString();
            }
            string shrey1 = "";
            agencytyp = agencytypename;
            if (agencytyp != "--Select AgencyType--")
            {
                shrey1 = agencytypename.ToString();
            }
            if (agencytyp == "--Select AgencyType--")
            {
                shrey1 = "ALL".ToString();
            }

            PdfPTable tb5 = new PdfPTable(1);
            float[] xy5 = { 100 };
            tb5.DefaultCell.BorderWidth = 0;
            tb5.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb5.setWidths(xy5);
            tb5.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tb5.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[19].ToString(), font14));
            document.Add(tb5);


            PdfPTable tb1 = new PdfPTable(1);
            float[] xy1 = { 100 };
            tb1.DefaultCell.BorderWidth = 0;
            tb1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tb1.setWidths(xy1);
            tb1.WidthPercentage = 105;
            tb1.DefaultCell.Border = Rectangle.LEFT | Rectangle.LEFT;
            tb1.addCell(new Phrase("BOOKING DETAIL REPORT", font12));
            //tb1.addCell(new Phrase("", font12));
            //tb1.addCell(new Phrase("", font12));
            //tb1.addCell(new Phrase("", font12));
            //tb1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tb1.addCell(new Phrase("DATE FROM:", font12));
            //tb1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //tb1.addCell(new Phrase(fromdate, font12));
            //tb1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tb1.addCell(new Phrase("TO DATE:", font12));
            //tb1.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //tb1.addCell(new Phrase(dateto, font12));
            document.Add(tb1);

            PdfPTable tb3 = new PdfPTable(8);
            float[] xy3 = { 100 };
            tb3.DefaultCell.BorderWidth = 0;
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tb3.setWidths(xy1);
            tb3.WidthPercentage = 100;
            tb3.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));
            tb3.addCell(new Phrase("", font12));


            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("PUBLICATION:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(pub, font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("PUBCENT:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(pubcenter, font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("BRANCH:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(bran, font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("EDITION:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(edi, font12));


            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("AGENCY TPYE:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(shrey1, font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("DATE FROM:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(lblfrom.Text, font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("TO DATE:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(lblto.Text, font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tb3.addCell(new Phrase("RUN DATE:", font12));
            tb3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tb3.addCell(new Phrase(date, font12));
            document.Add(tb3);



            PdfPTable datatable = new PdfPTable(19);
            //datatable.addCell(new Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font12));
            datatable.DefaultCell.Padding = 3;
            datatable.WidthPercentage = 105; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;



           


            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.Colspan = 19;

            datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________", font12));
            datatable.DefaultCell.Colspan = 1;
            datatable.addCell(new Phrase("S.No", font12));
            datatable.addCell(new Phrase("Booking Id", font12));
            datatable.addCell(new Phrase("Agency", font12));
            datatable.addCell(new Phrase("Client Name", font12));
            datatable.addCell(new Phrase("Cap/Key.", font12));
            datatable.addCell(new Phrase("HT", font12));
            datatable.addCell(new Phrase("Wd", font12));
            datatable.addCell(new Phrase("Area", font12));
            datatable.addCell(new Phrase("Color", font12));
            datatable.addCell(new Phrase("PageNo.", font12));
            datatable.addCell(new Phrase("Exe/Ret", font12));
            datatable.addCell(new Phrase("Card Rate", font12));
            datatable.addCell(new Phrase("Agreed Rate", font12));
            datatable.addCell(new Phrase("Gross Amt", font12));
            datatable.addCell(new Phrase("Trade Disc", font12));
            datatable.addCell(new Phrase("Adll Comm", font12));
            datatable.addCell(new Phrase("Cash Disc", font12));
            datatable.addCell(new Phrase("Bill Amt", font12));
            datatable.addCell(new Phrase("currency", font12));


            datatable.DefaultCell.Colspan = 19;

            datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________", font12));
            datatable.DefaultCell.Colspan = 1;


          
                cmpnyname.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
                heading.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
                for (int i = 0; i < count; i++)
                {
                    datatable.DefaultCell.Colspan = 1;
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(s.ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["BOOKING_ID"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["AGENCY"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["CLIENT"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["CAPTION"].ToString() + "\n" + ds1.Tables[0].Rows[i]["KEY"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["DEPTH"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["WIDTH"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["AREA"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["COLOR"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["PAGE_NO"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["EXE_RET"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["CARDRATE"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["AGGRATE"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["GROSSAMT"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["AGENCYTD(%)"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["AgencyAddlTD(%)"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["CASH_DISC"].ToString(), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(chk_null(ds1.Tables[0].Rows[i]["BILLAMT"].ToString()), font10));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds1.Tables[0].Rows[i]["currency"].ToString(), font10));

                    string curr = "";
                    if (ds1.Tables[0].Rows[i]["currency"].ToString() == "DO0")
                    {
                        currency = "USD";

                    }
                    else if (ds1.Tables[0].Rows[i]["currency"].ToString() == "KY0")
                    {
                        currency = "KYAT";

                    }
                    else
                    {
                        currency = "Rupees";

                    }
                    if (ds1.Tables[0].Rows[i]["BILLAMT"].ToString() != "")
                    {
                        tot_billamt = tot_billamt + Convert.ToDouble(ds1.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }



                    datatable.DefaultCell.Colspan = 19;
                    s++;
                }
                datatable.DefaultCell.Colspan = 1;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.DefaultCell.Colspan = 19;

                datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________", font12));
                datatable.DefaultCell.Colspan = 1;

                if (curr123 != "All")
                {
                    datatable.addCell(new Phrase("Total", font10));
                    datatable.DefaultCell.Colspan = 19;
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(chk_null(tot_billamt.ToString()), font10));
                    //datatable.addCell(new Phrase("", font10));
                    //datatable.addCell(new Phrase("", font10));
                    //datatable.addCell(new Phrase("", font10));
                
                }
                else
                {
                    datatable.DefaultCell.Colspan = 17;

                }
                //datatable.addCell(new Phrase("", font10));
                //datatable.addCell(new Phrase("", font10));
                //datatable.addCell(new Phrase("", font10));
                
                //datatable.DefaultCell.Colspan = 1;
                //datatable.DefaultCell.Colspan = 19;

                datatable.addCell(new Phrase("____________________________________________________________________________________________________________________________________________________", font12));
                datatable.DefaultCell.Colspan = 19;


                document.Add(datatable);

                



                document.Close();
                Response.Redirect(pdfName, false);
            }
        }

        catch (Exception e)
        {

            Console.Error.WriteLine(e.StackTrace);

        }


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
    
}
