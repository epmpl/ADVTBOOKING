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

public partial class Reports_dummy_revenueview : System.Web.UI.Page
{
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string datefrom1 = "";
    string dateto1 = "";
    string pubcode = "";
    string publication = "";
    string edition = "";
    string editioncode = "";
    string destination = "";
    string fromdt = "";
    string dateto = "";
    double Netamt = 0;
    double Totalads = 0;
    double Grossamt = 0;
    double ActualBuss = 0, agencyadddisc = 0, agencydisc = 0;
    string adtypecode = "", adtypename = "", pubcentcode = "", pubcentname = "", currentdate="",comcode="",reporttype="";
    DataSet ds;
    string extra1 = "", extra2 = "", extra3 = "", extra4 = "";
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
        ds1.ReadXml(Server.MapPath("XML/dummyreport.xml"));
       // heading.Text = ds1.Tables[0].Rows[0].ItemArray[83].ToString();
        ds = (DataSet)Session["dummyrevsum"];
        string prm = Session["prm_dummyrevsum"].ToString();
        string[] prm_Array = new string[22];
        prm_Array = prm.Split('~');



        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
       // dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        editioncode = prm_Array[5]; //Request.QueryString["edition"].Trim().ToString();
        edition = prm_Array[7]; //Request.QueryString["editionname"].Trim().ToString();
        pubcode = prm_Array[9]; //Request.QueryString["publication"].ToString();
        publication = prm_Array[11]; //Request.QueryString["publicationname"].ToString();     
        pubcentcode = prm_Array[13]; //Request.QueryString["pubcentcode"].Trim().ToString();
        pubcentname = prm_Array[15]; //Request.QueryString["pubcentname"].Trim().ToString();
        comcode = prm_Array[17];
        reporttype = prm_Array[19];
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
        else if (hiddendateformat.Value == "mm/dd/yyyy")
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
            currentdate = month + "/" + day + "/" + year;

        }
        else if (hiddendateformat.Value == "yyyy/mm/dd")
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
            currentdate = year + "/" + month + "/" + day;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_dummy_revenueview));
        if (destination == "1" || destination == "0")
        {

            onscreen(comcode, fromdt, pubcode, pubcentcode, editioncode, "", reporttype, extra1, extra2, extra3, extra4);
        }
        else if (destination == "4")
        {
             shoexecl(comcode, fromdt, pubcode, pubcentcode, editioncode, "", reporttype, extra1, extra2, extra3, extra4);
        }
    }


    public string createheader(DataSet ds)
    {
        string Hearder1 = "";
        string reportname1 = "Dummy Revenue Summary Report";
        if (destination == "1" || destination == "0")
        {
            Hearder1 += "<tr><td align='center'colspan='16'><b> ";
            Hearder1 += "DILIGENT MEDIA CORPORATION LTD.";
            Hearder1 += "</b></td></tr>";
            Hearder1 += "<tr><td align='center'colspan='16'><b> ";
            Hearder1 += reportname1;
            Hearder1 += "</b></td></tr>";
            Hearder1 += "<tr><td align='center'colspan='16'><b> ";
            Hearder1 += "Date" + " " + fromdt;
            Hearder1 += "</b></td></tr>";
        }
        else if (destination == "4")
        {
            if (reporttype == "1")
            {
                Hearder1 += "<tr><td align='center'colspan='12'><b> ";
                Hearder1 += "DILIGENT MEDIA CORPORATION LTD.";
                Hearder1 += "</b></td></tr>";
                Hearder1 += "<tr><td align='center'colspan='12'><b> ";
                Hearder1 += reportname1;
                Hearder1 += "</b></td></tr>";
                Hearder1 += "<tr><td align='center'colspan='12'><b> ";
                Hearder1 += "Date" + " " + fromdt;
                Hearder1 += "</b></td></tr>";
            }
            else
            {
                Hearder1 += "<tr><td align='center'colspan='6'><b> ";
                Hearder1 += "DILIGENT MEDIA CORPORATION LTD.";
                Hearder1 += "</b></td></tr>";
                Hearder1 += "<tr><td align='center'colspan='6'><b> ";
                Hearder1 += reportname1;
                Hearder1 += "</b></td></tr>";
                Hearder1 += "<tr><td align='center'colspan='6'><b> ";
                Hearder1 += "Date" + " " + fromdt;
                Hearder1 += "</b></td></tr>";
            }
        }
        if (destination == "1" || destination == "0")
        {
            if (reporttype == "1")
            {
                Hearder1 += "<tr colspan='16'><td  align='right' style='font-family:Arial;font-size:14px;' colspan='16'><b>Run Date:</b>" + currentdate + "</td></tr>";
            }
            else
            {
                Hearder1 += "<tr colspan='6'><td  align='right' style='font-family:Arial;font-size:14px;' colspan='16'><b>Run Date:</b>" + currentdate + "</td></tr>";
            }
        }
        else if (destination == "4")
        {
            if (reporttype == "1")
            {
                Hearder1 += "<tr colspan='12'><td  align='right' style='font-family:Arial;font-size:14px;' colspan='12'><b>Run Date:</b>" + currentdate + "</td></tr>";
            }
            else
            {
                Hearder1 += "<tr colspan='6'><td  align='right' style='font-family:Arial;font-size:14px;' colspan='6'><b>Run Date:</b>" + currentdate + "</td></tr>";
            }
        }
        Hearder1 += "<tr><td  align='left' style='font-family:Arial;font-size:14px;' colspan='4'><b>Revenue Collected For:</b>" + " " + publication + "</td></tr>";
      
        return Hearder1;
    }
    public void onscreen(string comcode, string fromdt, string pubcode,string pubcentcode,string editioncode, string subpub,string reporttype,string extra1,string extra2,string extra3,string extra4)
    {

        double grandtotal = 0;
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }

        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        int rowcounter = 0;
        int srno = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
            string topheader = createheader(ds);
            tbl = tbl + topheader;
            tbl = tbl + "</table>";
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
            if(reporttype=="1"){
            tbl = tbl + "<tr ><td colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Publication</b></td>";
            tbl = tbl + "<td  colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Edition<b></td>";
            tbl = tbl + "<td   colspan='2'  align='right' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Revenue<b></td>";
            tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Pages<b></td>";
            tbl = tbl + "<td  align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ad Col</td>";
           
            tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Edit Col</td>";
            tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ad Col%</td>";
            tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Edit Col%</td></tr>";
        }
        else{
              tbl = tbl + "<tr ><td colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Publication</b></td>";
            tbl = tbl + "<td  colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Supliment Name<b></td>";
            tbl = tbl + "<td   colspan='2'  align='right' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Amount<b></td></tr>";
        }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                tbl = tbl + ("<tr >");
                 if(reporttype=="1"){
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["PUBL_NAME"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["edition_name"] + "</td>");
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                double revenue = Convert.ToDouble(ds.Tables[0].Rows[i]["revenue"].ToString());
                tbl = tbl + (revenue.ToString("F2") + "</td>");
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["edition_page"] + "</td>");
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                double edvl = Convert.ToDouble(ds.Tables[0].Rows[i]["total_ad_vol"].ToString());
                tbl = tbl + (edvl.ToString("F2") + "</td>");
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                double ed = Convert.ToDouble(ds.Tables[0].Rows[i]["EDIT_COL"].ToString());
                tbl = tbl + (ed.ToString("F2")+ "</td>");
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                double adcol = Convert.ToDouble(ds.Tables[0].Rows[i]["ADCOL"].ToString());
                tbl = tbl + (adcol.ToString("F2") + "</td>");
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                double edicol = Convert.ToDouble(ds.Tables[0].Rows[i]["EDICOL"].ToString());
                tbl = tbl + (edicol.ToString("F2") + "</td>");
                double amount = Convert.ToDouble(ds.Tables[0].Rows[i]["revenue"]);

                if (ds.Tables[0].Rows[i]["revenue"].ToString() != "")
                    grandtotal = grandtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["revenue"]);
                
                 }
                 else
                 {
                      tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Pub_Cent_Name"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
                double ed = Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_Amt"].ToString());
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ed.ToString("F2") + "</td>");
                 double amount = Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_Amt"]);
                if (ds.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
                    grandtotal = grandtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_Amt"]);
              
                 }
                rowcounter++;
                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    tbl = tbl + ("<tr>");
                       if(reporttype=="1"){
                    tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Total:</b></td>");
                    tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>" + Math.Round(grandtotal, 0) + "</b></td>");
                    tbl = tbl + ("</tr>");
                       }
                           else{
                               tbl = tbl + ("<td  colspan='5'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Total:</b></td>");
                               tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>" + Math.Round(grandtotal, 0) + "</b></td>");
                               tbl = tbl + ("</tr>");
                           }
                }
                srno++;

            }

        }

        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        view.InnerHtml += tbl;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        view.Visible = true;
        view.RenderControl(hw);
    
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["prm_dummyrevsum_print"] = "destination~" + destination + "~fromdate~" + fromdt + "~edition~" + editioncode + "~editionname~" + edition + "~publication~" + pubcode + "~publicationname~" + publication + "~pubcentcode~" +pubcentcode+ "~pubcentname~" +pubcentname+ "~comcode~" + comcode + "~reporttype~" + reporttype;
        Response.Redirect("dummyrevprint.aspx");

    }
    public void shoexecl(string comcode, string fromdt, string pubcode, string pubcentcode, string editioncode, string subpub, string reporttype, string extra1, string extra2, string extra3, string extra4)
    {

        double grandtotal = 0;
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        int rowcounter = 0;
        int srno = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
            string topheader = createheader(ds);
            tbl = tbl + topheader;
            tbl = tbl + "</table>";
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
            if (reporttype == "1")
            {
                tbl = tbl + "<tr ><td colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Publication</b></td>";
                tbl = tbl + "<td  colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Edition<b></td>";
                tbl = tbl + "<td   colspan='2'  align='right' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Revenue<b></td>";
                tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Pages<b></td>";
                tbl = tbl + "<td  align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ad Col</td>";

                tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Edit Col</td>";
                  tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ad Col%</td>";
            tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Edit Col%</td></tr>";
            }
            else
            {
                tbl = tbl + "<tr ><td colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Publication</b></td>";
                tbl = tbl + "<td  colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Supliment Name<b></td>";
                tbl = tbl + "<td   colspan='2'  align='right' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Amount<b></td></tr>";
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                tbl = tbl + ("<tr >");
                if (reporttype == "1")
                {
                    tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["PUBL_NAME"] + "</td>");
                    tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["edition_name"] + "</td>");
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    double revenue = Convert.ToDouble(ds.Tables[0].Rows[i]["revenue"].ToString());
                    tbl = tbl + (revenue.ToString("F2") + "</td>");
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["edition_page"] + "</td>");
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    double edvl = Convert.ToDouble(ds.Tables[0].Rows[i]["total_ad_vol"].ToString());
                    tbl = tbl + (edvl.ToString("F2") + "</td>");
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    double ed = Convert.ToDouble(ds.Tables[0].Rows[i]["EDIT_COL"].ToString());
                    tbl = tbl + (ed.ToString("F2") + "</td>");
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    double adcol = Convert.ToDouble(ds.Tables[0].Rows[i]["ADCOL"].ToString());
                    tbl = tbl + (adcol.ToString("F2") + "</td>");
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    double edicol = Convert.ToDouble(ds.Tables[0].Rows[i]["EDICOL"].ToString());
                    tbl = tbl + (edicol.ToString("F2") + "</td>");
                    double amount = Convert.ToDouble(ds.Tables[0].Rows[i]["revenue"]);

                    if (ds.Tables[0].Rows[i]["revenue"].ToString() != "")
                        grandtotal = grandtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["revenue"]);

                }
                else
                {
                    tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Pub_Cent_Name"] + "</td>");
                    tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
                    double ed = Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_Amt"].ToString());
                    tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ed.ToString("F2") + "</td>");
                    double amount = Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_Amt"]);
                    if (ds.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
                        grandtotal = grandtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_Amt"]);

                }
                rowcounter++;
                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    tbl = tbl + ("<tr>");
                    if (reporttype == "1")
                    {
                        tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='2'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>" + Math.Round(grandtotal, 0) + "</b></td>");
                        tbl = tbl + ("</tr>");
                    }
                    else
                    {
                        tbl = tbl + ("<td  colspan='5'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>" + Math.Round(grandtotal, 0) + "</b></td>");
                        tbl = tbl + ("</tr>");
                    }
                }
                srno++;

            }

        }


        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        view.InnerHtml += tbl;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        view.Visible = true;
        view.RenderControl(hw);

    }
}