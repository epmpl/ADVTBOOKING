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


public partial class scheduleregister_new_edition : System.Web.UI.Page
{
    int notot = 0;
    int cnt1 = 0, cnt2 = 0, cnt4 = 0, cnt5 = 0, rowcounter = 0;
    decimal cnt3 = 0;
    int dd2;
    string client = "";
    string pdfName1 = "";
    string agency = "";
    int count1 = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count31 = 0;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    int pgn = 1;
    string day = "";
    string month = "";
    string year = "";
    string date = "";

    string datefrom1 = "", adcatname = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    decimal paidins = 0;
    string package = "";
    string dateformate = "";
    string fmg = "";
    string sortorder = "";
    string sortvalue = "";
    string publicationcenter = "";
    string adtype = "";
    string adtypecode = "";
    string adcategory = "";
    string edition = "";
    string supplement = "";
    string pubcentcode = "";
    string dytbl = "";
    string editiondetail = "";
    string status = "";
    int cont1;
    int pagn = 1;
    //string fromdt = "";
    //string dateto="";
    int totunaudit = 0, totaudit = 0, temptotunaudit = 0, temptotaudit = 0;
    string branch_code = "", branch_name = "", ro_statuscod = "", ro_statusnam = "";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    string sortfield = "";
    string sorting = "", supplementcode = "", package11name = "", ciod = "";
    double sqcm = 0, colcm = 0, other = 0, totrol = 0, totcd = 0, totcc = 0, areaset = 0;
    int maxlimit = 60;
    double tempsqcm = 0, tempcolcm = 0, tempother = 0, temptotrol = 0, temptotcd = 0, temptotcc = 0, tempareaset = 0;

    string package11 = "", pkgdetail = "";
    DataSet ds;
    string editionname = "";
    string name1 = "", name2 = "", name3 = "", hdnasc = "";
    string chk_excel = "";

    string edipre, edichange;
    string section;
    string codesubcode = "", extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "";

    double totgamt = 0, totsur = 0, totcom = 0, tototh = 0, totnet = 0, totspace = 0, totbox = 0, totdisc = 0;
    double Atotnet = 0, Atotspace = 0, Atotrate = 0;
    double totgamt1 = 0, totsur1 = 0, totcom1 = 0, tototh1 = 0, totnet1 = 0, totspace1 = 0, totrate1 = 0;
    double Gtotgamt = 0, Gtotsur = 0, Gtotbox = 0, Gtototh = 0, Gtotnet = 0, Gtotcom = 0, Gtotrate = 0, Gtotdisc = 0;
    double Gtotnet1 = 0, Gtotspace1 = 0, Gtotrate1 = 0;


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


        string[] prm_Array = new string[44];


        DataSet ds1 = new DataSet();


        fromdt = Session["fromdate"].ToString();
        dateto = Session["todate"].ToString();
        extra1 = Session["pub"].ToString();
        edition = Session["edtn"].ToString();
        adtype = Session["adtype"].ToString();
        branch_code = Session["branch"].ToString();
        codesubcode = Session["codesubcode"].ToString();
        extra2 = Session["adtype"].ToString();
        extra3 = Session["extra3"].ToString();
        extra4 = Session["extra4"].ToString();
        extra5 = Session["extra5"].ToString();
        editionname = Session["edtnnm"].ToString();
        destination = Session["dest"].ToString();





        if (edition == "0")
            edition = "";
        if (extra1 == "0")
        {
            extra1 = "";
        }

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{
            //    fromdt = DMYToMDY(fromdt);
            //    dateto = DMYToMDY(dateto);
            //}


            //else if (hiddendateformat.Value == "yyyy/mm/dd")
            //{
            //    fromdt = YMDToMDY(fromdt);
            //    dateto = YMDToMDY(dateto);
            //}
            //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), ciod, hdnasc, supplementcode, package11, pkgdetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod, section);

        }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), branch_code, edition, "", fromdt, dateto, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "ad_edition_wise_p";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(scheduleregister_new_edition));


        if (ds.Tables[0].Rows.Count == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(scheduleregister_new_edition), "sa", "alert(\"searching criteria is not valid\");window.close();", true);

            return;
        }
        if (edition == "")
            edition = "0";


        cmpnyname.Text = Session["centername"].ToString();
       

        //if (pkgdetail == "0")
        //{
        //    pubnamelb.Text = "PUBLICATION:";
        //    if (publ == "0")
        //    {
        //        lblpublication.Text = "";
        //    }
        //    else
        //    {
        //        lblpublication.Text = publication.ToString();

        //    }
        //}
        //else
        //{
        //    pubnamelb.Text = "PACKAGE:";
        //    if (package11name == "--Select Package--")
        //    {
        //        lblpublication.Text = "All";
        //    }
        //    else
        //    {
        //        lblpublication.Text = package11name.ToString();
        //    }
        //}

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
        lbldate.Text = date.ToString();

        lblfrom.Text = fromdt;
        datefrom1 = fromdt;
        lblto.Text = dateto;
        dateto1 = dateto;




        //lbadtype.Text = adtype;
        //if (adcategory != "")
        //{
        //    lbadcategory.Text = adcatname;
        //}
        //else
        //{
        //    lbadcategory.Text = "ALL";
        //}
        //if (edition != "" && edition != "0")
        //    lbedition.Text = editionname;
        //else
        //    lbedition.Text = "ALL";

        //lblrostatus.Text = ro_statusnam;

        //if (pubcentcode != "0")
        //{
        //    lblpublicationcenter.Text = publicationcenter;
        //}
        //else
        //{
        //    lblpublicationcenter.Text = "ALL";
        //}
        hiddendatefrom.Value = fromdt.ToString();
        btnprint.Attributes.Add("onclick", "javascript:return forclick();");
        if (!IsPostBack)
        {
            if (destination == "1" || destination == "0" || destination == "4")
            {


                onscreen();
            }

        }
    }
    private void onscreen()
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno = 1;
            StringBuilder TBL = new StringBuilder();
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' colspan='14'  align='right' style='font-size:15px; '><b>" + " Page no :" + "&nbsp;&nbsp;&nbsp;&nbsp;" + pagn + "</b></td>");
            TBL.Append("</tr>");
            TBL.Append("<tr>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='2%'><b>" + "S.No" + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='20%'><b>" + ds.Tables[0].Columns[3].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='12%'><b>" + ds.Tables[0].Columns[5].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='10%'><b>" + ds.Tables[0].Columns[6].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[7].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[8].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[9].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[10].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[11].Caption + "</b></td>");
            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[14].Caption + "</b></td>");

                for (int v = 16; v < ds.Tables[0].Columns.Count; v++)
                {

                    TBL.Append("<td style='text-align:center;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' ><b>" + "&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Columns[v].Caption + "</b></td>");

            }

            TBL.Append("</tr>");
            pagn++;

            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                  
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr>");
                            TBL.Append("<td class='mis_hdr1' colspan='14'  align='right' style='font-size:15px; '><b>" + " Page no :" + "&nbsp;&nbsp;&nbsp;&nbsp;" + pagn + "</b></td>");
                            TBL.Append("</tr>");
                            TBL.Append("<tr>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='2%'><b>" + "S.No" + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='20%'><b>" + ds.Tables[0].Columns[3].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='12%'><b>" + ds.Tables[0].Columns[5].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='10%'><b>" + ds.Tables[0].Columns[6].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[7].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[8].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[9].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[10].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[11].Caption + "</b></td>");
                            TBL.Append("<td style='text-align:left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' width='8%'><b>" + ds.Tables[0].Columns[14].Caption + "</b></td>");

                            for (int v = 16; v < ds.Tables[0].Columns.Count; v++)
                            {

                                TBL.Append("<td style='text-align:center;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;padding-left:6px;' ><b>" + "&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Columns[v].Caption + "</b></td>");

                            }

                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                            pagn++;
                        }
                    }
                TBL.Append("<tr>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='2%' >" + sno + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='20%' >" + ds.Tables[0].Rows[z].ItemArray[3].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='12%'>" + ds.Tables[0].Rows[z].ItemArray[5].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='10%'>" + ds.Tables[0].Rows[z].ItemArray[6].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='8%'>" + ds.Tables[0].Rows[z].ItemArray[7].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='8%'>" + ds.Tables[0].Rows[z].ItemArray[8].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='8%'>" + ds.Tables[0].Rows[z].ItemArray[9].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='8%'>" + ds.Tables[0].Rows[z].ItemArray[10].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='8%'>" + ds.Tables[0].Rows[z].ItemArray[11].ToString() + "</td>");
                TBL.Append("<td align='left' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;' width='8%'>" + ds.Tables[0].Rows[z].ItemArray[14].ToString() + "</td>");

                        
                for (int v = 16; v < ds.Tables[0].Columns.Count; v++)
                {



                    TBL.Append("<td align='center' style='font-size:11px;border-bottom:solid 1px black;padding-left:6px;'>" + "&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                }
                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
                sno++;
            }
            //TBL.Append("<tr>");
            //TBL.Append("<td colspan='12' align='left' style='font-size:12px;border-bottom:solid 1px black;' width='76%' ><b>" + "Total" + "</b></td>");
            //TBL.Append("<td colspan='0' align='right' style='font-size:12px;border-bottom:solid 1px black;' width='8%' ><b>" + ds.Tables[1].Rows[0]["Gross Amount"].ToString() + "</b></td>");
            //TBL.Append("<td colspan='0' align='right' style='font-size:12px;border-bottom:solid 1px black;' width='8%' >&nbsp;</td>");
            //TBL.Append("<td colspan='0' align='right' style='font-size:12px;border-bottom:solid 1px black;;' width='8%' ><b>" + ds.Tables[1].Rows[0]["Bill Amount"].ToString() + "</b></td>");
            //TBL.Append("</tr>");

            TBL.Append("</table>");
            TBL.Append("</table></p>");
            tblgrid.InnerHtml = TBL.ToString();
            if (destination == "4")
            {
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment; filename=Edition_wise_schedule_reg.xls");

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                tblgrid.InnerHtml = TBL.ToString();
                tblgrid.Visible = true;
                tblgrid.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
       
    }
}

