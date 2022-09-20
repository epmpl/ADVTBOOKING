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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;


public partial class Reports_reotypeviewprint : System.Web.UI.Page
{

    int maxlimit = 10;
    string userid = "";
    string username = "";
    string firstname = "";
    string lastname = "";
    string agencyname = "";
    string branch = "";
    string employee = "";
    string roleid = "";
    string companyname = "";
    string emailid = "";
    string discount = "";
    string brpermission = "";
    string rolename = "";
    string editline = "";
    string status = "";
    string destination = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string TBL = "";
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    //DataSet ds;
    string rpt_comp = "";
    double ver;
    int rowcount5 = 0;
    string rdate = "";
    string username1 = "";
    string branch1 = "";
    string rolename1 = "";
    string status1 = "";
    int rowcount55 = 0;
    int s = 1;
    System.Web.HttpBrowserCapabilities browser;
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reotype.xml"));
        dateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hdncompname.Value = Session["comp_name"].ToString();
        hdnunit.Value = Session["center"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        rpt_comp = ds.Tables[0].Rows[0].ItemArray[16].ToString();



       // cmpnyname.Text = rpt_comp.ToString();


        ds = (DataSet)Session["moneyrep"];
        string prm = Session["prm_moneyrep_print"].ToString();
        string[] prm_Array = new string[22];
        prm_Array = prm.Split('~');

        userid = prm_Array[1];
        username = prm_Array[3];
        firstname = prm_Array[5];
        lastname = prm_Array[7];
        agencyname = prm_Array[9];
        branch = prm_Array[11];
        employee = prm_Array[13];
        companyname = prm_Array[15];
        emailid = prm_Array[17];
        discount = prm_Array[19];
        brpermission = prm_Array[21];
        rolename = prm_Array[23];
        editline = prm_Array[25];
        status = prm_Array[27];
        destination = prm_Array[29];

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[49].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);



        if (username == "0" || username == "")
        {
            username1 = "ALL";
        }
        else
        {
            username1= username.ToString();
        }



        if (branch == "0" || branch == "")
        {
            branch1 = "ALL";
        }
        else
        {
            branch1 = branch.ToString();
        }



        if (rolename == "0" || rolename == "")
        {
            rolename1 = "ALL";
        }
        else
        {
            rolename1 = rolename.ToString();
        }


        if (status == "0" || status == "")
        {
            status1 = "ALL";
        }
        else
        {
            status1 = status.ToString();
        }


        

        string rundate1 = System.DateTime.Now.ToString();
        string[] rundate2 = rundate1.Split(' ');
        rdate = rundate2[0];

        
        onscreen();


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


    public string createheader()
    {
        DataSet ds1 = new DataSet();


        if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
        {
           
            NewAdbooking.Report.Classes.reporttype pub = new NewAdbooking.Report.Classes.reporttype();
            ds1 = pub.bindreportview(hdncompcode.Value, userid, username, rolename, status, dateformat.Value, extra1, extra2, extra3, extra4, extra5);

        }
        else
        {

            NewAdbooking.Report.classesoracle.reotype pub = new NewAdbooking.Report.classesoracle.reotype();
            ds1 = pub.bindreportview(hdncompcode.Value, userid, username, rolename, status, dateformat.Value, extra1, extra2, extra3, extra4, extra5);
        }
       
        string Hearder1 = "";
      int rcount = ds1.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

         Hearder1 +="<tr valign='top'>";
         Hearder1 +="<td class='middle111' align='right' colspan='17'>" + "Page  " + s + "  of  " + pagecount;
         Hearder1 += "</td></tr>";
        
        
       
        Hearder1 += "<tr width='100%'><td  colspan='25' style='font-family:Arial;font-size:20px;' align='center'>" + rpt_comp + "</td></tr>";
        Hearder1 += "<tr width='100%'><td  colspan='25' style='font-family:Arial;font-size:13px;' align='center'>LOGIN USER REPORT</td></tr>";

        Hearder1 += "<tr width='100%'><td  colspan='5' align='left' style='width:33%;font-family:Arial;font-size:12px; padding-right:20px;'><b>USERNAME:&nbsp;</b>" + username1 + "<td  colspan='5' style='font-family:Arial;font-size:12px;' align='center'><b>ROLE ID:&nbsp;</b>" + rolename1 + "<td colspan='4'  style='font-family:Arial;font-size:12px;' align='right'><b>BRANCH NAME:&nbsp;</b>" + branch1 + "</b></td></tr>";//acntfrom
        Hearder1 += "<tr width='100%'><td  colspan='5' align='left' style='width:33%;font-family:Arial;font-size:12px; padding-right:20px;'><b>STATUS:&nbsp;</b>" + status1 + "<td colspan='5'  style='font-family:Arial;font-size:12px;' align='center'><b> RUNDATE:&nbsp;</b>" + rdate + "</b></td></tr>";//acntfrom




        Hearder1 += "<table cellspacing='0px' cellpadding = '0px' width='100%' border='0' >";

        Hearder1+="<tr ><td class='middle31new'align='left' width='5%'>";
        Hearder1+="S.No</td>";

        Hearder1+="<td class='middle31new'align='left' width='5%'>";
        Hearder1 += "User Id </td>";

        Hearder1+="<td class='middle31new'align='left'  width='5%'>";
        Hearder1+= "User Name</td>";

        Hearder1+="<td class='middle31new'align='left'  width='10%'>";
        Hearder1 += "First Name</td>";

        Hearder1+="<td class='middle31new'align='left'  width='10%'>";
        Hearder1+= "Last Name</td>";

        Hearder1+="<td class='middle31new'align='left'  width='10%'>";
        Hearder1 += "Agency </td>";

        Hearder1+="<td class='middle31new' align='left'  width='10%'>";
        Hearder1+="Branch Name</td>";


        Hearder1+="<td class='middle31new' align='left' width='10%'>";
        Hearder1 += "Company Name</td>";

        Hearder1+="<td></td><td class='middle31new' align='center'  width='10%'>";
        Hearder1 += "Email</td>";

        Hearder1+="<td class='middle31new' align='left' width='5%'>";
        Hearder1 += "Discount Allowed</td>";

        Hearder1+="<td class='middle31new' align='center'  width='5%'>";
        Hearder1+="Branch Permission</td>";

        Hearder1+="<td class='middle31new' align='left'  width='5%'>";
        Hearder1+="Role Name</td>";

        Hearder1+="<td class='middle31new' align='left'  width='5%'>";
        Hearder1+="Edit Lines in Breaking</td>";

        Hearder1+="<td class='middle31new' align='left'  width='5%'>";
        Hearder1+="Status</td>";

        Hearder1+="<td class='middle31new' align='left'  width='5%'>";
        Hearder1+="Emp Code</td>";

        Hearder1 += "<td class='middle31new' align='left'  width='5%'>";
        Hearder1 += "Login Type</td>";

         Hearder1+="</tr>";


         s = s + 1;
        rowcount5 ++;
        rowcount55 ++;
       
        return Hearder1;
    }
    
    private void onscreen()
    {
        int m11 = 0;
        string page = "";
        string position = "";
        var sno = 0;
        int rowcount55 = 0;
        StringBuilder TBL = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();


        if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
        {
            

            NewAdbooking.Report.Classes.reporttype pub = new NewAdbooking.Report.Classes.reporttype();
            ds1 = pub.bindreportview(hdncompcode.Value, userid, username, rolename, status, dateformat.Value, extra1, extra2, extra3, extra4, extra5);



        }
        else
        {

            NewAdbooking.Report.classesoracle.reporttype pub = new NewAdbooking.Report.classesoracle.reporttype();
            ds1 = pub.bindreportview(hdncompcode.Value, userid, username, rolename, status, dateformat.Value, extra1, extra2, extra3, extra4, extra5);
        }

       
        int fr = maxlimit;
        int rcount = ds1.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

           

        int cont = ds1.Tables[0].Rows.Count;

        if (ds1.Tables[0].Rows.Count > 0)
        {
           

            string topheader = createheader();
            TBL.Append(topheader);

            
            
            DataSet ds_xml = new DataSet();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/reotype.xml"));
           
            // ======================================= For values ===================================================

            Double dttoal = 0, SUM = 0;

            for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
            {
                //int s = 1;
                // s = m + 1;
                
                
                string narrtinname=ds1.Tables[0].Rows[m]["EMAIL"].ToString();
                sno++;
                dttoal = dttoal + SUM;
                int abc = rowcount5;
                int abcpay = rowcount55;
                if (abc > abcpay)
                {
                    rowcount5 = abc;
                }
                else
                {
                    rowcount5 = abcpay;
                }
                if (rowcount5 >= maxlimit)
                {
                     TBL.Append("</table></p>");
                   
                    TBL.Append("<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0'>");
                     TBL.Append(topheader);
                     string Hearder1 = "";
                      rcount = ds1.Tables[0].Rows.Count;
                      pagec = rcount % maxlimit;
                      pagecount = rcount / maxlimit;
                     if (pagec > 0)
                     {
                         pagecount = pagecount + 1;
                     }

                     Hearder1 += "<tr valign='top'>";
                     Hearder1 += "<td class='middle111' align='right' colspan='17'>" + "Page  " + s + "  of  " + pagecount;
                     Hearder1 += "</td></tr>";
                     s = s + 1;
                    rowcount5 = 0;
                     rowcount55 = 0;

                }
                TBL.Append("<tr><td class='rep_data' ' align='left'>");
                TBL.Append(sno + "</td>");
                TBL.Append("<td class='rep_data'  align='left'width='5%' >");
                TBL.Append(ds1.Tables[0].Rows[m]["USERID"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='5%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["USERNAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data' align='left' width='10%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["FIRSTNAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data' align='left' width='10%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["LASTNAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='10%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["AGENCY_NAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='10%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["BRANCH_NAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='10%'>");
               TBL.Append(ds1.Tables[0].Rows[m]["COMP_NAME"].ToString() + "</td>");
              
                TBL.Append("<td></td><td class='rep_data'  align='center' width='10%'>");
               
                TBL.Append(ds1.Tables[0].Rows[m]["EMAIL"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='right' width='5%'>");
                
                TBL.Append(ds1.Tables[0].Rows[m]["DISCOUNT"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='5%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["BRANCH_PERMISSION"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='5%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["ROLENAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='5%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["BOOKING_EDITLINES"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='5%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["STATUS"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left' width='5%'>");
                TBL.Append(ds1.Tables[0].Rows[m]["HR_CODE"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["LOGIN_TYPE"].ToString() + "</td>");

                //   string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 9);



               
                TBL.Append("</tr>");
                rowcount5++;


            }






        }


        tblgrid.InnerHtml = TBL.ToString();


    }
}
