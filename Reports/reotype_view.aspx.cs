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



public partial class Reports_reotype_view : System.Web.UI.Page
{

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
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string rpt_comp = "";
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

       
        userid = Request.QueryString["userid"].ToString();
        username = Request.QueryString["usename"].ToString();
        firstname = Request.QueryString["firstnm"].ToString();
        lastname = Request.QueryString["lastnm"].ToString();
        agencyname = Request.QueryString["agencycode"].ToString();
        branch = Request.QueryString["branchnm"].ToString();
        employee = Request.QueryString["empcode"].ToString();
        companyname = Request.QueryString["companyname"].ToString();
        emailid = Request.QueryString["email"].ToString();
        discount = Request.QueryString["discount"].ToString();
        brpermission = Request.QueryString["branhper"].ToString();
        rolename = Request.QueryString["role"].ToString();
        editline = Request.QueryString["edit"].ToString();
        status = Request.QueryString["status"].ToString();
        if (status == "0")
            status = "";
        destination = Request.QueryString["desination"].ToString();
        rpt_comp = ds.Tables[0].Rows[0].ItemArray[16].ToString();

       

            cmpnyname.Text = rpt_comp.ToString();
       
        
        if (dateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

        }
        else
            if (dateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (dateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                }
        lbldate.Text = date.ToString();


        if (username == "0" || username == "")
        {
            lbluser1.Text = "ALL".ToString();
        }
        else
        {
            lbluser1.Text = username.ToString();
        }



        if (branch == "0" || branch == "")
        {
            lblbranch.Text = "ALL".ToString();
        }
        else
        {
            lblbranch.Text = branch.ToString();
        }



        if (rolename == "0" || rolename == "")
        {
            lblrole.Text = "ALL".ToString();
        }
        else
        {
            lblrole.Text = rolename.ToString();
        }


        if (status == "0" || status == "")
        {
            lblstatus.Text = "ALL".ToString();
        }
        else
        {
            lblstatus.Text = status.ToString();
        }


        




        if (!Page.IsPostBack)
        {
            if (destination == "0" || destination == "1")
            {
                onscreen();
            }
            else if (destination == "2")
            {
                 excel();
            }
            else if (destination == "3")
            {

                pdf();

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


    private void onscreen()
    {
        int m11 = 0;
        string page = "";
        string position = "";
        var sno = 0;

        StringBuilder TBL = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();


        if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "sql")
        {
              //NewAdbooking.Report.Classes.reotype obj = new NewAdbooking.Report.Classes.reotype();

              //ds1 = obj.reotype bindreportview( compcode,  userid , username, roleid, status, dateformat, extra1, extra2, extra3, extra4, extra5);




             NewAdbooking.Report.Classes.reporttype pub = new NewAdbooking.Report.Classes.reporttype();
            ds1 = pub.bindreportview(hdncompcode.Value, "", username, rolename, status, dateformat.Value, extra1, extra2, extra3, extra4, extra5);
        
       

        }
        else
        {

            NewAdbooking.Report.classesoracle.reotype pub = new NewAdbooking.Report.classesoracle.reotype();
            ds1 = pub.bindreportview(hdncompcode.Value, userid, username, rolename, status, dateformat.Value, extra1, extra2, extra3, extra4, extra5);
        }
        // Session["reotype"] = ds1;




        //subregrepDiv.InnerHtml = TBL.ToString();

        int cont = ds1.Tables[0].Rows.Count;

        if (ds1.Tables[0].Rows.Count > 0)
        {
            //  comp_name.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            DataSet ds_xml = new DataSet();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/reotype.xml"));

            TBL.Append("<table cellspacing='0px' cellpadding = '0px'  width='1010px' border='0' >");



            TBL.Append("<tr><td class='middle31new'align='left' width='50px'>");
            TBL.Append("S.No</td>");

            TBL.Append("<td class='middle31new'align='left' width='50px'>");
            TBL.Append("User Id </td>");

            TBL.Append("<td class='middle31new'align='left'  width='50px'>");
            TBL.Append("User Name</td>");

            TBL.Append("<td class='middle31new'align='left'  width='50px'>");
            TBL.Append("First Name</td>");

            TBL.Append("<td class='middle31new'align='left'  width='50px'>");
            TBL.Append("Last Name</td>");

            TBL.Append("<td class='middle31new'align='left'  width='50px'>");
            TBL.Append("Agency </td>");

            TBL.Append("<td class='middle31new' align='left'  width='50px'>");
            TBL.Append("Branch Name</td>");


            TBL.Append("<td class='middle31new' align='left' width='150px'>");
            TBL.Append("Company Name</td>");

            TBL.Append("<td></td><td class='middle31new' align='center'  width='140px'>");
            TBL.Append("Email</td>");

            TBL.Append("<td class='middle31new' align='left' width='40px'>");
            TBL.Append("Discount Allowed</td>");

            TBL.Append("<td class='middle31new' align='center'  width='80px'>");
            TBL.Append("Branch Permission</td>");

            TBL.Append("<td class='middle31new' align='left'  width='80px'>");
            TBL.Append("Role Name</td>");

            TBL.Append("<td class='middle31new' align='left'  width='80px'>");
            TBL.Append("Edit Lines in Breaking</td>");

            TBL.Append("<td class='middle31new' align='left'  width='50px'>");
            TBL.Append("Status</td>");

            TBL.Append("<td class='middle31new' align='left'  width='80px'>");
            TBL.Append("Emp Code</td>");

            TBL.Append("<td class='middle31new' align='left'  width='80px'>");
            TBL.Append("Login Type</td>");

            TBL.Append("</tr>");

          



            // ======================================= For values ===================================================

            Double dttoal = 0, SUM = 0;

            for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
            {

                sno++;
                dttoal = dttoal + SUM;



                TBL.Append("<td class='rep_data' ' align='left'>");
                TBL.Append(sno + "</td>");
                TBL.Append("<td class='rep_data' ' align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["USERID"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["USERNAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data' align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["FIRSTNAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data' align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["LASTNAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["AGENCY_NAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["BRANCH_NAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["COMP_NAME"].ToString() + "</td>");
                TBL.Append("<td></td><td class='rep_data'  align='center'>");
                TBL.Append(ds1.Tables[0].Rows[m]["EMAIL"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='right'>");
                TBL.Append(ds1.Tables[0].Rows[m]["DISCOUNT"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["BRANCH_PERMISSION"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["ROLENAME"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["BOOKING_EDITLINES"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["STATUS"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["HR_CODE"].ToString() + "</td>");
                TBL.Append("<td class='rep_data'  align='left'>");
                TBL.Append(ds1.Tables[0].Rows[m]["LOGIN_TYPE"].ToString() + "</td>");

                //   string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 9);




                TBL.Append("</tr>");
                
            }






        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_reotype_view), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
            return;
        }

        tblgrid.InnerHtml = TBL.ToString();


    }


    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["prm_moneyrep_print"] = "userid~" + userid + "~usename~" + username + "~firstname~" + firstname + "~lastname~" + lastname + "~agencyname~" + agencyname + "~branch~" + branch + "~employee~" + employee + "~companyname~" + companyname + "~emailid~" + emailid + "~discount~" + discount + "~brpermission~" + brpermission+ "~rolename~" + rolename+ "~editline~" + editline + "~status~" + status + "~destination~" + destination;
        Response.Redirect("reotypeviewprint.aspx");

    //  Session["prm_moneyrep_print"] =userid=" + userid + "username=" + usename + "firstname=" + firstnm + "lastname=" + lastnm + "agencyname=" + agencycode + "branch=" + branchnm + "employee=" + empcode + "companyname=" + companyname + "emailid=" + email + "discount=" + discount + "brpermission=" + branhper + "brpermission=" + role + "rolename=" + edit + "status=" + status + "destination=" + desination;

    




 
 

 



 
  

   
    
    
    
    
    
    
    
    }


   
    
    
    
    private void excel()
    {

        StringBuilder TBL = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds1 = new DataSet();

        var sno = 0;
        


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
        if (ds1.Tables[0].Rows.Count > 0)
        {

            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
           // TBL.Append("<table cellspacing='0px' cellpadding = '0px' width='100%' border='1'colspan='2' >");

            //TBL.Append("<table cellspacing='0px' cellpadding = '0px' width='100%' border='1'colspan='2'><tr><td align=left><b></b>" + cmpnyname.Text + "</td>");
            //TBL.Append("</table>");
            //TBL.Append("<tr><td align='left' colspan='2'><b>User Name:</b>" + lbluser1.Text + "</td>");

            //TBL.Append("<td align='center' colspan='2'><b>Role Id:</b>" + lblrole.Text + "</td>");
            //TBL.Append("<td align=right colspan='2'><b>");
            //TBL.Append("Branch Name</b>" + lblbranch.Text + "</td>");
            //TBL.Append("<td align=left colspan='2'><b>");
            //TBL.Append("Status</b>" + lblstatus.Text + "</td>");
            //TBL.Append("<td align=center colspan='2'><b>");
            //TBL.Append("Rundate</b>" + lbldate.Text + "</td>");

       //     TBL.Append("</table>");


            TBL.Append("<table cellspacing='0px' cellpadding = '0px' width='100%' border='1'><tr><td colspan=\"16\"align=\"center\"><b></b>" + cmpnyname.Text + "</td></tr>");
            TBL.Append("<tr><td colspan=\"5\"align=\"left\"><b>UserName:</b>" + lbluser1.Text + "</td>");

            TBL.Append("<td colspan=\"6\"align=\"center\"><b>RoleId:</b>" + lblrole.Text + "</td>");
            TBL.Append("<td colspan=\"5\"align=\"right\"><b>");
            TBL.Append("BranchName:</b>" + lblbranch.Text + "</td></tr>");
            TBL.Append("<tr><td colspan=\"5\"align=\"left\"><b>");
            TBL.Append("Status:</b>" + lblstatus.Text + "</td>");
            TBL.Append("<td colspan=\"6\"align=\"center\"><b>");
            TBL.Append("Rundate:</b>" + lbldate.Text + "</td></tr>");




            int cont = ds1.Tables[0].Rows.Count;

            if (ds1.Tables[0].Rows.Count > 0)
            {
                //  comp_name.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                DataSet ds_xml = new DataSet();
                ds_xml.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));
                // report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[12].ToString();

                TBL.Append("<table cellspacing='0px' cellpadding = '0px' width='100%' border='1'colspan='2' >");
                // TBL.Append("<table width=100%>");

                TBL.Append("<tr><td class='middle31new'align='left'>");
                TBL.Append("User Id</td>");

                TBL.Append("<td class='middle31new'align='left'>");
                TBL.Append("User Name</td>");

                TBL.Append("<td class='middle31new'align='left'>");
                TBL.Append("First Name</td>");

                TBL.Append("<td class='middle31new'align='left'>");
                TBL.Append("Last Name</td>");

                TBL.Append("<td class='middle31new'align='left'>");
                TBL.Append("Agency </td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Branch Name</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Emp Code</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Company Name</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Email</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Discount Allowed</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Branch Permission</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Role Name</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Edit Lines in Breaking</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Status</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Emp Code</td>");

                TBL.Append("<td class='middle31new' align='left'>");
                TBL.Append("Login Type</td>");
                TBL.Append("</tr>");




                // ======================================= For values ===================================================

                Double dttoal = 0, SUM = 0;

                for (int m = 0; m < ds1.Tables[0].Rows.Count; m++)
                {

                    sno++;
                    dttoal = dttoal + SUM;

                    TBL.Append("<td class='rep_data' ' align='left'>");
                    TBL.Append(sno + "</td>");
                    TBL.Append("<td class='rep_data' ' align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["USERID"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["USERNAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data' align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["FIRSTNAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data' align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["LASTNAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["AGENCY_NAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["BRANCH_NAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["COMP_NAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["EMAIL"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["DISCOUNT"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["BRANCH_PERMISSION"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["ROLENAME"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["BOOKING_EDITLINES"].ToString() + "</td>");
                    TBL.Append("<td class='rep_data'  align='left'>");
                    TBL.Append(ds1.Tables[0].Rows[m]["STATUS"].ToString() + "</td>");
                     TBL.Append("<td class='rep_data'  align='left'>");
                     TBL.Append(ds1.Tables[0].Rows[m]["HR_CODE"].ToString() + "</td>");
                     TBL.Append("<td class='rep_data'  align='left'>");
                     TBL.Append(ds1.Tables[0].Rows[m]["LOGIN_TYPE"].ToString() + "</td>");



                    //   string rrR = ds1.Tables[0].Rows[m]["PUB_DATE"].ToString().Substring(0, 9);




                    TBL.Append("</tr>");

                }

                tblgrid.InnerHtml = TBL.ToString();



                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                // hw.Write("<p align='center'><b> " + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></p>");
                //  DataSet ds_xml = new DataSet();
                //  ds_xml.ReadXml(Server.MapPath("XML/VTS_REPORT.xml"));
                // report_name.Text = ds_xml.Tables[0].Rows[0].ItemArray[12].ToString();

                //  hw.Write("<p align='center'><b> " + report_name1 + ds_xml.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></p>");

                //hw.Write("<p align='center'><b> " + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></p>");
                hw.WriteBreak();
                tblgrid.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_reotype_view), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
                return;
            }



        }

    }







    private void pdf()//(string edition, string agency_code, string from_date, string to_date, string client_code, string publication, string pub_center, string branch, string dateformat, string useid, string compcode, string chk_access, string extra1, string extra2)
    {
        string code_find = "";
        Double dttoal = 0, SUM = 0;
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "\\" + pdfName;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase("Page No. " + i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;
        document.Open();

        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);


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


        DataSet ds11 = new DataSet();
        ds11.ReadXml(Server.MapPath("XML/reotype.xml"));
       
        PdfPTable tbl = new PdfPTable(1);
        float[] xy = { 100 };
        tbl.DefaultCell.BorderWidth = 0;
        tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        tbl.setWidths(xy);
        tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
        tbl.addCell(new Phrase(ds11.Tables[0].Rows[0].ItemArray[16].ToString(), font9));

        
        float[] headerwidths1 = { 50 };
        tbl.setWidths(headerwidths1);
        tbl.WidthPercentage = 100;
       
        document.Add(tbl);




        PdfPTable tbl91111 = new PdfPTable(6);
        tbl91111.DefaultCell.BorderWidth = 0;
        tbl91111.WidthPercentage = 100;
      
       tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        tbl91111.addCell(new Phrase("User Id:", font10));
        tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        tbl91111.addCell(new Phrase(lbluser1.Text, font10));
        tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
     
        tbl91111.addCell(new Phrase("Role Id:", font10));
        tbl91111.addCell(new Phrase(lblrole.Text, font10));
        tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
     
        tbl91111.addCell(new Phrase("Branch Name:", font10));
        tbl91111.addCell(new Phrase(lblbranch.Text, font10));
        tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
     
        tbl91111.addCell(new Phrase("Status:", font10));
        tbl91111.addCell(new Phrase(lblstatus.Text, font10));
        tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    
        tbl91111.addCell(new Phrase("Rundate:", font10));
        tbl91111.addCell(new Phrase(lbldate.Text, font10));


        tbl91111.addCell(new Phrase("", font10));
        tbl91111.addCell(new Phrase("", font10));
        document.Add(tbl91111);


        if (ds1.Tables[0].Rows.Count > 0)
        {

            string pub = "";
            
           
            int table1 = ds1.Tables[0].Rows.Count;
            int controw = ds1.Tables[0].Rows.Count;
            int contcol = ds1.Tables[0].Columns.Count;
            //int table2 = ds1.Tables[1].Rows.Count;

            int q = ds1.Tables[0].Columns.Count;
            int z = q - 1;
            int lastc = ds1.Tables[0].Columns.Count;
            int lastthirdc = lastc - 3;
            int NumColumns = ds1.Tables[0].Columns.Count + 1;
            NumColumns = NumColumns - 5;
            int xx = ds1.Tables[0].Columns.Count - 10;

            try
            {




                int initialization = 1;
              

                

                PdfPTable datatable = new PdfPTable(16);
                datatable.DefaultCell.Padding = 0;
                datatable.WidthPercentage = 100;
                datatable.DefaultCell.BorderWidth = 1;
                float[] set_width = { 10, 20, 20, 20, 30, 20,20,20,20,20,20,10,10,10,10,10 };
                datatable.setWidths(set_width);
                datatable.DefaultCell.Colspan = 16;
                //datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_BASELINE;
                //datatable.addCell(new iTextSharp.text.Phrase("______________________________________________________________________________________________________________________________________________", font10));
                datatable.DefaultCell.Colspan = 1;

              //  datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
               // datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
                datatable.addCell(new iTextSharp.text.Phrase("S.No", font10));
                datatable.addCell(new iTextSharp.text.Phrase("User", font10));
                datatable.addCell(new iTextSharp.text.Phrase("User Name", font10));
                datatable.addCell(new iTextSharp.text.Phrase("First Name", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Last Name", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Agency", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Branch Name", font10));

                datatable.addCell(new iTextSharp.text.Phrase("Company Name", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Email", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Discount Allowed", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Branch Permission", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Role Name", font10));

                datatable.addCell(new iTextSharp.text.Phrase("Edit Lines in Breaking", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Status", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Emp Code", font10));
                datatable.addCell(new iTextSharp.text.Phrase("Login Type", font10));
                datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
             


                datatable.DefaultCell.Colspan = 16;
               // datatable.addCell(new iTextSharp.text.Phrase("______________________________________________________________________________________________________________________________________________", font10));
                //datatable.DefaultCell.Colspan = 1;
               





                for (int x = 0; x < ds1.Tables[0].Rows.Count; x++)
                {
                   
                    datatable.DefaultCell.PaddingTop = 16;
                    datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    datatable.DefaultCell.Colspan = 1;
                    datatable.addCell(new iTextSharp.text.Phrase(initialization.ToString(), font11));

                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["USERID"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["USERNAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["FIRSTNAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["LASTNAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["AGENCY_NAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["BRANCH_NAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["COMP_NAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["EMAIL"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["DISCOUNT"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["BRANCH_PERMISSION"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["ROLENAME"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["BOOKING_EDITLINES"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["STATUS"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["HR_CODE"].ToString(), font11));
                    datatable.addCell(new iTextSharp.text.Phrase(ds1.Tables[0].Rows[x]["LOGIN_TYPE"].ToString(), font11));

                    initialization++;
                
                }

               
                document.Add(datatable);

                document.Close();
                Response.Redirect(pdfName);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_reotype_view), "sa", "alert(\"searching criteria is not valid\");window.close();", true);
            return;
        }

    }








}