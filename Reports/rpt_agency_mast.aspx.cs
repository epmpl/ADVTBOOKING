using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

public partial class Reports_rpt_agency_mast : System.Web.UI.Page
{

    string compcode = "";

    string branch = "";
    string fromdate = "";
    string todate = "";
    string currentdate = "";
    string unitnm = "";
    string brnchnm = "";
    string taluka = "";
    string extra2 = "";
    string extra3 = "";
    string zonenm = "";
    string extra5 = "";
    string compname = "";
    string pubname = "";
    string dist = "";
    string centermame = "";
    string dest = "";
    string reptype = "";
    string pub = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string DATEFORMAT = "";
    string userid = "";
    string amnt = "";
    string unit = "";
    string agtype = "";
    string agclass = "";
    string state = "";
    string adtype = "";
    string agtypenm = "";
    string edtn = "";
    string region = "";
    string adsubcat5 = "";
    string execode = "";
    string agencycode = "";
    string zone = "";
    string adsubcat4 = "";
    string agencycat = "";
    string agcd = "";
    string dpcd = "";
    string pcent = "";
    string city = "";
    string client = "";
    int maxlimit = 39;
    int area = 0;
    int i1 = 0;
    double amt_u = 0;
    double amt_t = 0;
    double amt_s = 0;
    double amt_0 = 0;
    double camt_1 = 0;
    double camt_2 = 0;
    string last_comm = "";
    string last_edtn = "";
    int pgn = 1;
    int seq = 1;
    int rowcounter = 0;
    int p;
    static int current = 1;
    int ll;
    int pagewidth = 20;
    int jj = 1;
    int kk;
    int j;
    int pagec;
    int pagecount;
    static int ab = 0;
    static int b = 4;
    static int k;
    static int l;
    double totgamt = 0, totsur = 0, totcom = 0, tototh = 0, totnet = 0, totspace = 0, totrate = 0;
    double Atotnet = 0, Atotspace = 0, Atotrate = 0;
    double totgamt1 = 0, totsur1 = 0, totcom1 = 0, tototh1 = 0, totnet1 = 0, totspace1 = 0, totrate1 = 0;
    double Gtotgamt = 0, Gtotsur = 0, Gtotcom = 0, Gtototh = 0, Gtotnet = 0, Gtotspace = 0, Gtotrate = 0;
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
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        hdnuserid.Value = Session["userid"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        compname = Session["comp_name"].ToString();
        compcode = Session["compcode"].ToString();
        branch = Session["branch"].ToString();
        unit = Session["unit"].ToString();
        agencycode = Session["agencycode"].ToString();
        agencycat = Session["agencycat"].ToString();
        region = Session["region"].ToString();
        zone = Session["zone"].ToString();
        agcd = Session["agcd"].ToString();
        dest = Session["dest"].ToString();
        dist = Session["dist"].ToString();
        dpcd = Session["dpcd"].ToString();
        state = Session["state"].ToString();
        city = Session["city"].ToString();
        taluka = Session["taluka"].ToString();
        unitnm = Session["unitnm"].ToString();
        brnchnm = Session["brnchnm"].ToString();
        zonenm = Session["zonenm"].ToString();
        client = Session["client"].ToString();
        execode = Session["exe"].ToString();
        reptype = Session["reptype"].ToString();

        DateTime dt = System.DateTime.Now;
        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            year = dt.Year.ToString();
            currentdate = day + "/" + month + "/" + year;

        }
        if (!Page.IsPostBack)
        {

            //=============for paging================

            if (Request.QueryString["page"] != null)
            {
                p = Convert.ToInt16(Request.QueryString["page"].ToString());
                current = p;
                ll = p;
                p = (p * pagewidth) - pagewidth;
            }
            else
            {
                current = 1;
                p = 0;
                jj = 0;
                kk = 0;
            }
            if (agencycode == "0")
            {
                agencycode = "";
            }
            if (zone == "0")
            {
                zone = "";
            }
            if (region == "0")
            {
                region = "";
            }
            if (dist == "0")
            {
                dist = "";
            }
            if (city == "0")
            {
                city = "";
            }
            if (state == "0")
            {
                state = "";
            }
            btnprint.Attributes.Add("onclick", "javascript:return forclick();");
            if (dest == "1")
            {

                onscreen();
                

            }
            else if (dest == "2")
            {
                excel();
            }
        }
    }
    private void onscreen()
    {
        string find_dist = "";
        string find_agcode = "";
        DataSet ds = new DataSet();
        StringBuilder TBL = new StringBuilder();
        

        if (reptype == "A")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, agencycode, agencycat, zone, region, state, dist, city, taluka, branch, unit, agcd, dpcd };
                string procedureName = "agency_master_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Agency Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Type Code" + "</b></td>");       //2
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Type Name" + "</b></td>");       //3
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Cat Code" + "</b></td>");//4
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Cat Name" + "</b></td>");//5
                //TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Subcat Code" + "</b></td>");//6
                //TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Subcat Name" + "</b></td>");//7
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Code" + "</b></td>");//8
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Name" + "</b></td>");//9
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Alias" + "</b></td>");//10
                //TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency HO" + "</b></td>");//11
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Add1" + "</b></td>");//12
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Street" + "</b></td>");//13
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "CityCode" + "</b></td>");//14
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "CityName" + "</b></td>");//15
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Zip" + "</b></td>");//16
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Dist Code" + "</b></td>");//17
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Dist Name" + "</b></td>");//18
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "State" + "</b></td>");//19
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "State Name" + "</b></td>");//20
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Country Code" + "</b></td>");//21
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Country Name" + "</b></td>");//22
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Phone" + "</b></td>");//23
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Fax" + "</b></td>");//24
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "EmailID" + "</b></td>");//25
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "URL" + "</b></td>");//26
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Buss Start Date" + "</b></td>");//27
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Enroll Date" + "</b></td>");//28
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "MRV Ref No" + "</b></td>");//29
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "No of VTS" + "</b></td>");//30
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Credit Days" + "</b></td>");//31
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "PAN No" + "</b></td>");//32
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "TAN No" + "</b></td>");//33
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "ST Acc no" + "</b></td>");//34
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Pay Mode Code" + "</b></td>");//35
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Agency Status" + "</b></td>");//36
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Status Reason" + "</b></td>");//37
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Remark" + "</b></td>");//38
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Sub Agency HO" + "</b></td>");//39
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Sub Agency Code" + "</b></td>");//40
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Amount" + "</b></td>");//41
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Bank" + "</b></td>");//42
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Validity Date" + "</b></td>");//43
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Bill To" + "</b></td>");//44
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Alert" + "</b></td>");//45
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Credit Limit" + "</b></td>");//46
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Code" + "</b></td>");//47
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Representative Code" + "</b></td>");//48
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Pin Code" + "</b></td>");//49
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Region" + "</b></td>");//50
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Region Name" + "</b></td>");//51
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Status Detail" + "</b></td>");//52
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Status Till Date" + "</b></td>");//53
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Type" + "</b></td>");//54
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Type Name" + "</b></td>");//55
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Code Subcode" + "</b></td>");//56
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Zone Code" + "</b></td>");//57
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Zone Name" + "</b></td>");//58
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Add2" + "</b></td>");//59
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Add3" + "</b></td>");//60
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Credit Type" + "</b></td>");//61
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Ac Agency" + "</b></td>");//62
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Fax" + "</b></td>");//63
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Rate Group" + "</b></td>");//64
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "QBC UserId" + "</b></td>");//65
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Taluka Code" + "</b></td>");//66
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Taluka Name" + "</b></td>");//67
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Branch Code" + "</b></td>");//68
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Branch Name" + "</b></td>");//69
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Ad Type" + "</b></td>");//70
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "District" + "</b></td>");//71
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Bill Frequency" + "</b></td>");//72
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Old Agency Code" + "</b></td>");//73
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "SAP AGCode" + "</b></td>");//74
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Booking Type" + "</b></td>");//75
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Comp_code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_Type_Code"] + "</td>");//2
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["agency_type_name"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_Cat_Code"] + "</td>");//4
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["agency_category_name"] + "</td>");//5
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_SubCat_Code"] + "</td>");//6
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["agency_subcat_name"] + "</td>");//7
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_Code"] + "</td>");//8
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_Name"] + "</td>");//9
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_Alias"] + "</td>");//10
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_HO"] + "</td>");//11
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");//12
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Street"] + "</td>");//13
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["City_Code"] + "</td>");//14
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["City_Name"] + "</td>");//15
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Zip"] + "</td>");//16
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");//17
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["dist_name"] + "</td>");//18
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["STATE"] + "</td>");//19
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["State_Name"] + "</td>");//20
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");//21
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["country_name"] + "</td>");//22
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Phone"] + "</td>");//23
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");//24
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");//25
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["URL"] + "</td>");//26
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Buss_Start_Date"] + "</td>");//27
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Enroll_Date"] + "</td>");//28
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["MRV_Ref_No"] + "</td>");//29
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["No_of_VTS"] + "</td>");//30
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Credit_Days"] + "</td>");//31
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["PAN_No"] + "</td>");//32
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["TAN_No"] + "</td>");//33
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["ST_ACC_No"] + "</td>");//34
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Pay_Mode_Code"] + "</td>");//35
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Agency_Status"] + "</td>");//36
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Status_Reason"] + "</td>");//37
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Remarks"] + "</td>");//38
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["SUB_Agency_HO"] + "</td>");//39
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["SUB_Agency_Code"] + "</td>");//40
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["AMOUNT"] + "</td>");//41
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["BANK"] + "</td>");//42
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["VALIDITY_DATE"] + "</td>");//43
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["BILL_TO"] + "</td>");//44
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["ALERT"] + "</td>");//45
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["CREDIT_LIMIT"] + "</td>");//46
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["CODE"] + "</td>");//47
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Representative_code"] + "</td>");//48
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["pin_code"] + "</td>");//49
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["region"] + "</td>");//50
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["region_name"] + "</td>");//51
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["status_detail"] + "</td>");//52
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["status_till_date"] + "</td>");//53
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["type_name"] + "</td>");//55
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["code_subcode"] + "</td>");//56
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["zone_code"] + "</td>");//57
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["ZONE_NAME"] + "</td>");//58
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Add2"] + "</td>");//59
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Add3"] + "</td>");//60
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["CREDIT_TYPE"] + "</td>");//61
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["acagency"] + "</td>");//62
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["fax1"] + "</td>");//63
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Rate_Group"] + "</td>");//64
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["qbc_userid"] + "</td>");//65
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["TALUKA"] + "</td>");//66
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["TALUKA_NAME"] + "</td>");//67
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Branch_code"] + "</td>");//68
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Branch_Name"] + "</td>");//69
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["ADTYPE"] + "</td>");//70
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["DISTRICT"] + "</td>");//71
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["BILL_FREQUENCY"] + "</td>");//72
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["OLD_AGENCY"] + "</td>");//73
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["SAP_AGCODE"] + "</td>");//74
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["BOOKING_TYPE"] + "</td>");//75
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");
               
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "C")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, branch, client, state, dist, city, region, zone };
                string procedureName = "ADV_GETCLIENTNAME_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Client Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Branch Code" + "</b></td>");       //2
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Client Code" + "</b></td>");       //3
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Client Name" + "</b></td>");//4
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Address" + "</b></td>");//5
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Phone1" + "</b></td>");//6
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Phone2" + "</b></td>");//7
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "EmailID" + "</b></td>");//8
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Zone Code" + "</b></td>");//9
               // TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Region Code" + "</b></td>");//10
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Country Code" + "</b></td>");//11
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Country Name" + "</b></td>");//12
                //TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "State Code" + "</b></td>");//13
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "State Name" + "</b></td>");//14
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "District Name" + "</b></td>");//15
                //TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Dist Code" + "</b></td>");//16
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Taluka" + "</b></td>");//17
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "City" + "</b></td>");//18
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Region Name" + "</b></td>");//19
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "PAN No" + "</b></td>");//20
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;' ><b>" + "Credit Days" + "</b></td>");//21
               
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["BRANCH_CODE"] + "</td>");//2
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Cust_Code"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Cust_Name"] + "</td>");//4
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");//5
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["phone1"] + "</td>");//6
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Phone2"] + "</td>");//7
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");//8
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Zone_code"] + "</td>");//9
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["REGION_NAME"] + "</td>");//10
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");//11
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["COUNTRY_NAME"] + "</td>");//12
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");//13
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["state_name"] + "</td>");//14
                    //TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["dist_name"] + "</td>");//15
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");//16
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["taluka"] + "</td>");//17
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["city"] + "</td>");//18
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["region_name"] + "</td>");//19
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["PAN_No"] + "</td>");//20
                    TBL.Append("<td class='forrecords1'>" + ds.Tables[0].Rows[i]["Credit_Days"] + "</td>");//21
                   
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "E")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, branch,"", execode, state, dist, city, region, zone };
                string procedureName = "ADV_GETEXECTNAME_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Executive Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Branch Code" + "</b></td>");       //2
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Team Name" + "</b></td>");       //3
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Executive No" + "</b></td>");//4
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Executive Name" + "</b></td>");//4
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:15%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Mobile No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Country Name" + "</b></td>");//5
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "State" + "</b></td>");//6
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:6%' ><b>" + "District" + "</b></td>");//7
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "City" + "</b></td>");//8
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:7%' ><b>" + "Taluka" + "</b></td>");//9
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:7%' ><b>" + "Executive Status" + "</b></td>");//11
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["BRANCH_CODE"] + "</td>");//2
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["TEAM_NAME"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Exe_no"] + "</td>");//4
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Exec_name"] + "</td>");//5
                    TBL.Append("<td class='forrecords1'style='width:15%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");//6
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["MOBILENO"] + "</td>");//7
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["COUNTRY_NAME"] + "</td>");//8
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["State_code"] + "</td>");//9
                    TBL.Append("<td class='forrecords1'style='width:6%'>" + ds.Tables[0].Rows[i]["dist_code"] + "</td>");//11
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["CITY"] + "</td>");//12
                    TBL.Append("<td class='forrecords1'style='width:7%'>" + ds.Tables[0].Rows[i]["TALUKA"] + "</td>");//13
                    TBL.Append("<td class='forrecords1'style='width:7%'>" + ds.Tables[0].Rows[i]["exe_status"] + "</td>");//13
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "Z")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "ZONEEMST_ZONE_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Zone Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:30%' ><b>" + "Zone Name" + "</b></td>");       //2
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:25%' ><b>" + "Zone Code" + "</b></td>"); 
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'style='width:30%'>" + ds.Tables[0].Rows[i]["Zone_Name"] + "</td>");//2
                    TBL.Append("<td class='forrecords1'style='width:25%'>" + ds.Tables[0].Rows[i]["Zone_Code"] + "</td>");//3
                   
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "R")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, zone, hdnuserid.Value };
                string procedureName = "BINDREGION_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Region Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Region Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Region Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Zone Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Zone Name" + "</b></td>");
                
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Region_Code"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Region_Name"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Zone_Code"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Zone_Name"] + "</td>");//2
                   

                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AT")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "ADVCATEGORY";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Type Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:30%' ><b>" + "Ad Type Name" + "</b></td>");
              

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:30%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");//3
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AT")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "ADVCATEGORY";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Type Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:30%' ><b>" + "Ad Type Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:30%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");//3
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "PM")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode,"",execode };
                string procedureName = "ADPRODUCTMAINCAT_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Main Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Product Main Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:30%' ><b>" + "Product Main Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["product_cat"] + "</td>");//3
                    TBL.Append("<td class='forrecords1'style='width:30%'>" + ds.Tables[0].Rows[i]["product_name"] + "</td>");//3
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "PS")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "", execode };
                string procedureName = "ADPRODUCTSUBCAT_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Sub Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Industry Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Industry Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Product Sub Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Product Sub Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["industry_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["industryname"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["pro_subcat_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["pro_sub_name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AC")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "AD_CATEGORY_MASTER_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Type Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Type"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Type_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AS")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "GETSUBCATEGORY_MASTER_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Sub Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Category Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Sub Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Ad Sub Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["CATE_NM"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AS3")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "GETCAT3_MASTER_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Sub Category3 Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Type Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Category Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Sub Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Sub Category Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Sub Category3 Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Ad Sub Category3 Name" + "</b></td>");

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Adv_Type"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Adv_Type_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["catcode"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["catname"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "S")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, state };
                string procedureName = "ad_state_name_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>State Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Country Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "State Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "State Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["country"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["st_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["st_nm"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "D")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode,state, dist };
                string procedureName = "ad_dist_name_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>District Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Country Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "State Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "State Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "District Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "District Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["country"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["state"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Dist_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "CT")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, state, dist };
                string procedureName = "ad_city_name_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>District Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Country Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "State Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "State Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Zone Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Zone Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Region Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Region Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "District Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "District Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "STD Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "City Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "City Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["country"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["state"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Zone_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["zone_name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Region_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["region_name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Dist_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["STD_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["City_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["City_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "PS3")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "", "" };
                string procedureName = "ad_product_third_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Sub category3 Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Product Main Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Product Main Category Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Product Sub Category Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Product Sub Category Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Product Sub Category3 Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Product Sub Category3 Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["industry_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["industry_name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["prod_cat_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["prod_desc"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["pro_subcat_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["pro_sub_name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "U")
        {
            if (unit == "0")
            {
                unit = "";
            }
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string[] parameterValueArray = new string[] { compcode, unit };
                string procedureName = "get_pub_cent_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
          else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Unit Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Unit Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:15%' ><b>" + "Unit Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:21%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Street" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "City" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "District" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "State" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Zip" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Phone" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Fax" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:6%' ><b>" + "Email ID" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + ds.Tables[0].Rows[i]["Pub_cent_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:15%'>" + ds.Tables[0].Rows[i]["Pub_Cent_name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:21%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["street"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["zip"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Phone"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:6%'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "CO")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "company_detail_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Company Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:2%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Company Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:15%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Street" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "City" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Zip" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "District" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "State" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Country" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Phone1" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Phone2" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Fax" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Email ID" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "ST Acc No." + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "PAN No." + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "TAN No." + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Reg.No." + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Reg.Date" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Box Address" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "VAT No." + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Company URL" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:2%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["Comp_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:15%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Street"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Zip"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Phone1"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Phone2"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["ST_Acc_No"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["PAN_No"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["TAN_No"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Reg_No"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Reg_Date"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Box_Address"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["VAT_TINNO"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["comp_url"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "B")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                if (unit == "0")
                {
                    unit = "";
                }
                if (branch == "0")
                {
                    branch = "";
                }

                string[] parameterValueArray = new string[] { compcode,unit,branch };
                string procedureName = "get_branch_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Branch Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:2%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Unit Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Unit Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Branch Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Branch Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:15%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Street" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "City" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Zip" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "District" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "State" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Country" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Phone1" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Phone2" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Fax" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Email ID" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Cost Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Zone" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Region" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Branch Control Acc" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Box Address" + "</b></td>");
               
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:2%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + ds.Tables[0].Rows[i]["unit_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:6%'>" + ds.Tables[0].Rows[i]["unit"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:7%'>" + ds.Tables[0].Rows[i]["Branch_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:7%'>" + ds.Tables[0].Rows[i]["Branch_Name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:15%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Street"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Zip"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Phone1"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Phone2"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["cost_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Zone_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Region_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["branch_control_acc"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["box_address"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "ED")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
             

                string[] parameterValueArray = new string[] { compcode};
                string procedureName = "GET_EDITION_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Edition Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:2%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:3%' ><b>" + "Unit Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Unit Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:5%' ><b>" + "Publication Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Publication Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:8%' ><b>" + "Edition Type" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Edition Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Short Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:15%' ><b>" + "Edition Alias" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "No of Columns" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Height" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Width" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Area" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Periodicity Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Gutter Space" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:4%' ><b>" + "Coloumn Space" + "</b></td>");
              

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:2%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:3%'>" + ds.Tables[0].Rows[i]["unit_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["unit"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:5%'>" + ds.Tables[0].Rows[i]["Pub_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["publ_nm"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:8%'>" + ds.Tables[0].Rows[i]["Edition_Type"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Edition_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["short_name"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:15%'>" + ds.Tables[0].Rows[i]["Edition_Alias"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["No_Of_Columns"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Size_Height"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Size_Width"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Edition_Area"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Preodicity_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Gutter_Space"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:4%'>" + ds.Tables[0].Rows[i]["Column_Space"] + "</td>");
               
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "BR")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string[] parameterValueArray = new string[] { compcode,"" };
                string procedureName = "ad_brandvarient_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Brand Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Brand Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Brand Name" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Varient Code" + "</b></td>");
                TBL.Append("<td class='grid2'style='height:20px;font-size:10px;font-weight:bold;text-align:left;border:0px solid #ffffff;width:20%' ><b>" + "Varient Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + seq + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["Brand_Code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["brand"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["varient_code"] + "</td>");
                    TBL.Append("<td class='forrecords1'style='width:20%'>" + ds.Tables[0].Rows[i]["varient_name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        report.InnerHtml = TBL.ToString();
        //if (dest == "2")
        //{
        //    Response.Clear();
        //    Response.ClearContent();
        //    Response.Charset = "UTF-8";
        //    Response.ContentType = "text/csv";
        //    Response.AppendHeader("content-disposition", "attachment; filename=exls.xls");

        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    report.InnerHtml = TBL.ToString();
        //    report.Visible = true;
        //    report.RenderControl(hw);
        //    Response.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
    }

    private void excel()
    {

   
        DataSet ds = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {




            string[] parameterValueArray = new string[] { compcode, agencycode, agencycat, zone, region, state, dist, city, taluka, branch, unit, agcd, dpcd };
            string procedureName = "agency_master_p";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            //string procedureName = "cir_outst_addback_statement";
            //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
            //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
            //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        StringBuilder TBL = new StringBuilder();


        
        ////////////////////////////////////////////////////////

        if (reptype == "A")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, agencycode, agencycat, zone, region, state, dist, city, taluka, branch, unit, agcd, dpcd };
                string procedureName = "agency_master_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Agency Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black; ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Agency Type Code" + "</b></td>");       //2
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Agency Type Name" + "</b></td>");       //3
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black; ><b>" + "Agency Cat Code" + "</b></td>");//4
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black; ><b>" + "Agency Cat Name" + "</b></td>");//5
                //TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;'' ><b>" + "Agency Subcat Code" + "</b></td>");//6
                //TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;'' ><b>" + "Agency Subcat Name" + "</b></td>");//7
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Agency Code" + "</b></td>");//8
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black; ><b>" + "Agency Name" + "</b></td>");//9
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black; ><b>" + "Agency Alias" + "</b></td>");//10
                //TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;'' ><b>" + "Agency HO" + "</b></td>");//11
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black; ><b>" + "Add1" + "</b></td>");//12
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Street" + "</b></td>");//13
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "CityCode" + "</b></td>");//14
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "CityName" + "</b></td>");//15
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Zip" + "</b></td>");//16
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Dist Code" + "</b></td>");//17
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Dist Name" + "</b></td>");//18
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "State" + "</b></td>");//19
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "State Name" + "</b></td>");//20
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Country Code" + "</b></td>");//21
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Country Name" + "</b></td>");//22
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Phone" + "</b></td>");//23
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Fax" + "</b></td>");//24
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "EmailID" + "</b></td>");//25
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "URL" + "</b></td>");//26
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Buss Start Date" + "</b></td>");//27
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Enroll Date" + "</b></td>");//28
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "MRV Ref No" + "</b></td>");//29
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "No of VTS" + "</b></td>");//30
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Credit Days" + "</b></td>");//31
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "PAN No" + "</b></td>");//32
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "TAN No" + "</b></td>");//33
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "ST Acc no" + "</b></td>");//34
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Pay Mode Code" + "</b></td>");//35
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Agency Status" + "</b></td>");//36
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Status Reason" + "</b></td>");//37
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Remark" + "</b></td>");//38
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Sub Agency HO" + "</b></td>");//39
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Sub Agency Code" + "</b></td>");//40
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Amount" + "</b></td>");//41
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Bank" + "</b></td>");//42
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Validity Date" + "</b></td>");//43
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Bill To" + "</b></td>");//44
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Alert" + "</b></td>");//45
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Credit Limit" + "</b></td>");//46
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Code" + "</b></td>");//47
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Representative Code" + "</b></td>");//48
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Pin Code" + "</b></td>");//49
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Region" + "</b></td>");//50
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Region Name" + "</b></td>");//51
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Status Detail" + "</b></td>");//52
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Status Till Date" + "</b></td>");//53
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Type" + "</b></td>");//54
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Type Name" + "</b></td>");//55
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Code Subcode" + "</b></td>");//56
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Zone Code" + "</b></td>");//57
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Zone Name" + "</b></td>");//58
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Add2" + "</b></td>");//59
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Add3" + "</b></td>");//60
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Credit Type" + "</b></td>");//61
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Ac Agency" + "</b></td>");//62
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Fax" + "</b></td>");//63
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Rate Group" + "</b></td>");//64
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "QBC UserId" + "</b></td>");//65
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Taluka Code" + "</b></td>");//66
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Taluka Name" + "</b></td>");//67
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Branch Code" + "</b></td>");//68
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Branch Name" + "</b></td>");//69
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Ad Type" + "</b></td>");//70
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "District" + "</b></td>");//71
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Bill Frequency" + "</b></td>");//72
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Old Agency Code" + "</b></td>");//73
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "SAP AGCode" + "</b></td>");//74
                //TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Booking Type" + "</b></td>");//75
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Comp_code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_Type_Code"] + "</td>");//2
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["agency_type_name"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_Cat_Code"] + "</td>");//4
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["agency_category_name"] + "</td>");//5
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_SubCat_Code"] + "</td>");//6
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["agency_subcat_name"] + "</td>");//7
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_Code"] + "</td>");//8
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_Name"] + "</td>");//9
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_Alias"] + "</td>");//10
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_HO"] + "</td>");//11
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");//12
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Street"] + "</td>");//13
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["City_Code"] + "</td>");//14
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["City_Name"] + "</td>");//15
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Zip"] + "</td>");//16
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");//17
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["dist_name"] + "</td>");//18
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["STATE"] + "</td>");//19
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["State_Name"] + "</td>");//20
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");//21
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["country_name"] + "</td>");//22
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Phone"] + "</td>");//23
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");//24
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");//25
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["URL"] + "</td>");//26
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Buss_Start_Date"] + "</td>");//27
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Enroll_Date"] + "</td>");//28
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["MRV_Ref_No"] + "</td>");//29
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["No_of_VTS"] + "</td>");//30
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Credit_Days"] + "</td>");//31
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["PAN_No"] + "</td>");//32
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["TAN_No"] + "</td>");//33
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["ST_ACC_No"] + "</td>");//34
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Pay_Mode_Code"] + "</td>");//35
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Agency_Status"] + "</td>");//36
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Status_Reason"] + "</td>");//37
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Remarks"] + "</td>");//38
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["SUB_Agency_HO"] + "</td>");//39
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["SUB_Agency_Code"] + "</td>");//40
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["AMOUNT"] + "</td>");//41
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["BANK"] + "</td>");//42
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["VALIDITY_DATE"] + "</td>");//43
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["BILL_TO"] + "</td>");//44
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["ALERT"] + "</td>");//45
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["CREDIT_LIMIT"] + "</td>");//46
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["CODE"] + "</td>");//47
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Representative_code"] + "</td>");//48
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["pin_code"] + "</td>");//49
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["region"] + "</td>");//50
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["region_name"] + "</td>");//51
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["status_detail"] + "</td>");//52
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["status_till_date"] + "</td>");//53
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["type_name"] + "</td>");//55
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["code_subcode"] + "</td>");//56
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["zone_code"] + "</td>");//57
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["ZONE_NAME"] + "</td>");//58
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Add2"] + "</td>");//59
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Add3"] + "</td>");//60
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["CREDIT_TYPE"] + "</td>");//61
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["acagency"] + "</td>");//62
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["fax1"] + "</td>");//63
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Rate_Group"] + "</td>");//64
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["qbc_userid"] + "</td>");//65
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["TALUKA"] + "</td>");//66
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["TALUKA_NAME"] + "</td>");//67
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Branch_code"] + "</td>");//68
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Branch_Name"] + "</td>");//69
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["ADTYPE"] + "</td>");//70
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["DISTRICT"] + "</td>");//71
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["BILL_FREQUENCY"] + "</td>");//72
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["OLD_AGENCY"] + "</td>");//73
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["SAP_AGCODE"] + "</td>");//74
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["BOOKING_TYPE"] + "</td>");//75
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "C")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, branch, client, state, dist, city, region, zone };
                string procedureName = "ADV_GETCLIENTNAME_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Client Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Branch Code" + "</b></td>");       //2
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Client Code" + "</b></td>");       //3
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Client Name" + "</b></td>");//4
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Address" + "</b></td>");//5
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Phone1" + "</b></td>");//6
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Phone2" + "</b></td>");//7
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "EmailID" + "</b></td>");//8
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Zone Code" + "</b></td>");//9
                // TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Region Code" + "</b></td>");//10
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Country Code" + "</b></td>");//11
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Country Name" + "</b></td>");//12
                //TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "State Code" + "</b></td>");//13
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "State Name" + "</b></td>");//14
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "District Name" + "</b></td>");//15
                //TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Dist Code" + "</b></td>");//16
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Taluka" + "</b></td>");//17
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "City" + "</b></td>");//18
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Region Name" + "</b></td>");//19
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "PAN No" + "</b></td>");//20
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' ><b>" + "Credit Days" + "</b></td>");//21

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["BRANCH_CODE"] + "</td>");//2
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Cust_Code"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Cust_Name"] + "</td>");//4
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");//5
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["phone1"] + "</td>");//6
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Phone2"] + "</td>");//7
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");//8
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Zone_code"] + "</td>");//9
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["REGION_NAME"] + "</td>");//10
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");//11
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["COUNTRY_NAME"] + "</td>");//12
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");//13
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["state_name"] + "</td>");//14
                    //TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["dist_name"] + "</td>");//15
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");//16
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["taluka"] + "</td>");//17
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["city"] + "</td>");//18
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["region_name"] + "</td>");//19
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["PAN_No"] + "</td>");//20
                    TBL.Append("<td style='text-align:Left;font-size:11px;'>" + ds.Tables[0].Rows[i]["Credit_Days"] + "</td>");//21

                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "E")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, branch, "", execode, state, dist, city, region, zone };
                string procedureName = "ADV_GETEXECTNAME_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Executive Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Branch Code" + "</b></td>");       //2
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Team Name" + "</b></td>");       //3
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Executive No" + "</b></td>");//4
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Executive Name" + "</b></td>");//4
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:15%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Mobile No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Country Name" + "</b></td>");//5
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "State" + "</b></td>");//6
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:6%' ><b>" + "District" + "</b></td>");//7
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "City" + "</b></td>");//8
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:7%' ><b>" + "Taluka" + "</b></td>");//9
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:7%' ><b>" + "Executive Status" + "</b></td>");//11
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["BRANCH_CODE"] + "</td>");//2
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["TEAM_NAME"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Exe_no"] + "</td>");//4
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Exec_name"] + "</td>");//5
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:15%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");//6
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["MOBILENO"] + "</td>");//7
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["COUNTRY_NAME"] + "</td>");//8
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["State_code"] + "</td>");//9
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:6%'>" + ds.Tables[0].Rows[i]["dist_code"] + "</td>");//11
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["CITY"] + "</td>");//12
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:7%'>" + ds.Tables[0].Rows[i]["TALUKA"] + "</td>");//13
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:7%'>" + ds.Tables[0].Rows[i]["exe_status"] + "</td>");//13
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "Z")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "ZONEEMST_ZONE_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Zone Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Comp Code" + "</b></td>");              //1
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:30%' ><b>" + "Zone Name" + "</b></td>");       //2
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:25%' ><b>" + "Zone Code" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:30%'>" + ds.Tables[0].Rows[i]["Zone_Name"] + "</td>");//2
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:25%'>" + ds.Tables[0].Rows[i]["Zone_Code"] + "</td>");//3

                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "R")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, zone, hdnuserid.Value };
                string procedureName = "BINDREGION_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Region Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Region Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Region Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Zone Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Zone Name" + "</b></td>");

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Region_Code"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Region_Name"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Zone_Code"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Zone_Name"] + "</td>");//2


                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AT")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "ADVCATEGORY";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Type Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:30%' ><b>" + "Ad Type Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:30%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");//3
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AT")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "ADVCATEGORY";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Type Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:30%' ><b>" + "Ad Type Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:30%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");//3
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "PM")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "", execode };
                string procedureName = "ADPRODUCTMAINCAT_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Main Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Product Main Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:30%' ><b>" + "Product Main Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");//1
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["product_cat"] + "</td>");//3
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:30%'>" + ds.Tables[0].Rows[i]["product_name"] + "</td>");//3
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "PS")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "", execode };
                string procedureName = "ADPRODUCTSUBCAT_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Sub Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Industry Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Industry Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Product Sub Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Product Sub Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["industry_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["industryname"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["pro_subcat_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["pro_sub_name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AC")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "AD_CATEGORY_MASTER_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Type Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Type"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Type_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AS")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "GETSUBCATEGORY_MASTER_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Sub Category Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Category Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Sub Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Ad Sub Category Name" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["CATE_NM"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "AS3")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "GETCAT3_MASTER_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Sub Category3 Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Type Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Type Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Category Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Sub Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Sub Category Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Sub Category3 Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Ad Sub Category3 Name" + "</b></td>");

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Adv_Type"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Adv_Type_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Adv_Cat_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Adv_Subcat_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["catcode"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["catname"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "S")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, state };
                string procedureName = "ad_state_name_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>State Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Country Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "State Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "State Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:20%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:20%'>" + ds.Tables[0].Rows[i]["country"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:20%'>" + ds.Tables[0].Rows[i]["st_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;'width:20%'>" + ds.Tables[0].Rows[i]["st_nm"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "D")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, state, dist };
                string procedureName = "ad_dist_name_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>State Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Country Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "State Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "State Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "District Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "District Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["country"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["state"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Dist_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "CT")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, state, dist };
                string procedureName = "ad_city_name_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>District Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Country Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "State Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "State Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Zone Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Zone Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Region Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Region Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "District Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "District Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "STD Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "City Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "City Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["country"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["state"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Zone_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["zone_name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Region_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["region_name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Dist_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["STD_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["City_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["City_Name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "PS3")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {




                string[] parameterValueArray = new string[] { compcode, "", "" };
                string procedureName = "ad_product_third_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Sub category3 Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Product Main Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Product Main Category Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Product Sub Category Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Product Sub Category Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Product Sub Category3 Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Product Sub Category3 Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["industry_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["industry_name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["prod_cat_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["prod_desc"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["pro_subcat_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["pro_sub_name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "U")
        {
            if (unit == "0")
            {
                unit = "";
            }
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string[] parameterValueArray = new string[] { compcode, unit };
                string procedureName = "get_pub_cent_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Unit Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Unit Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:15%' ><b>" + "Unit Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:21%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Street" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "City" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "District" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "State" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Zip" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Phone" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Fax" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:6%' ><b>" + "Email ID" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + ds.Tables[0].Rows[i]["Pub_cent_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:15%'>" + ds.Tables[0].Rows[i]["Pub_Cent_name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:21%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["street"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["zip"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Phone"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:6%'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }

        else if (reptype == "CO")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "company_detail_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Comapany Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:2%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Company Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:15%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Street" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "City" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Zip" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "District" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "State" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Country" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Phone1" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Phone2" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Fax" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Email ID" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "ST Acc No." + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "PAN No." + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "TAN No." + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Reg.No." + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Reg.Date" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Box Address" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "VAT No." + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Company URL" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:2%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["Comp_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:15%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Street"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Zip"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Phone1"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Phone2"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["ST_Acc_No"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["PAN_No"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["TAN_No"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Reg_No"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Reg_Date"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Box_Address"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["VAT_TINNO"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["comp_url"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }

        else if (reptype == "B")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                if (unit == "0")
                {
                    unit = "";
                }
                if (branch == "0")
                {
                    branch = "";
                }

                string[] parameterValueArray = new string[] { compcode, unit, branch };
                string procedureName = "get_branch_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Branch Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:2%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Unit Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Unit Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Branch Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Branch Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:15%' ><b>" + "Address" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Street" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "City" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Zip" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "District" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "State" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Country" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Phone1" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Phone2" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Fax" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Email ID" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Cost Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Zone" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Region" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Branch Control Acc" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Box Address" + "</b></td>");

                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:2%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + ds.Tables[0].Rows[i]["unit_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:6%'>" + ds.Tables[0].Rows[i]["unit"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:7%'>" + ds.Tables[0].Rows[i]["Branch_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:7%'>" + ds.Tables[0].Rows[i]["Branch_Name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:15%'>" + ds.Tables[0].Rows[i]["Add1"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Street"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["city"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Zip"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Dist_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["State_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Phone1"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Phone2"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Fax"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["EmailID"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["cost_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Zone_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Region_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["branch_control_acc"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["box_address"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }

        else if (reptype == "ED")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {


                string[] parameterValueArray = new string[] { compcode };
                string procedureName = "GET_EDITION_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Edition Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:2%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:3%' ><b>" + "Unit Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Unit Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:5%' ><b>" + "Publication Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Publication Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:8%' ><b>" + "Edition Type" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Edition Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Short Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:15%' ><b>" + "Edition Alias" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Country Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "No of Columns" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Height" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Width" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Area" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Periodicity Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Gutter Space" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:4%' ><b>" + "Coloumn Space" + "</b></td>");


                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:2%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:3%'>" + ds.Tables[0].Rows[i]["unit_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["unit"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:5%'>" + ds.Tables[0].Rows[i]["Pub_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["publ_nm"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:8%'>" + ds.Tables[0].Rows[i]["Edition_Type"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Edition_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["short_name"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:15%'>" + ds.Tables[0].Rows[i]["Edition_Alias"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Country_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["No_Of_Columns"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Size_Height"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Size_Width"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Edition_Area"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Preodicity_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Gutter_Space"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:4%'>" + ds.Tables[0].Rows[i]["Column_Space"] + "</td>");

                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        else if (reptype == "BR")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string[] parameterValueArray = new string[] { compcode, "" };
                string procedureName = "ad_brandvarient_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
                //string procedureName = "cir_outst_addback_statement";
                //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
                //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
                //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;

                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + compname + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Brand Master List</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");



                TBL.Append("<tr>");
                if (unit == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Unit :</b>" + " " + unitnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch == "0")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch :</b>" + " " + brnchnm + "</td>");
                }
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table class='imageclass'  style='overflow: auto; border:solid 1px; border-color:#7fa7f7;width:100%' cellspacing='0' cellpadding='0' align='left'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Seq No" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:10%' ><b>" + "Comp Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Brand Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Brand Name" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Varient Code" + "</b></td>");
                TBL.Append("<td style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;width:20%' ><b>" + "Varient Name" + "</b></td>");
                TBL.Append("</tr>");
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + seq + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:10%'>" + ds.Tables[0].Rows[i]["Comp_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["Brand_Code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["brand"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["varient_code"] + "</td>");
                    TBL.Append("<td style='text-align:Left;font-size:11px;width:20%'>" + ds.Tables[0].Rows[i]["varient_name"] + "</td>");
                    TBL.Append("<tr>");

                    seq++;


                }
                TBL.Append("</table>");

            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }

        }
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        report.InnerHtml = TBL.ToString();
        report.Visible = true;
        report.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
}