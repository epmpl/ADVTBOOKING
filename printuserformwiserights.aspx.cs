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
using System.Text.RegularExpressions;
//using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;
using iTextSharp.text;
//using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;

using System.Drawing;


public partial class printuserformwiserights : System.Web.UI.Page
{
    string extra1 = "";
    string extra2 = "";
    string unitcode = "";
    string views = "";
    string language = "";
    string rdate = "";
    string usercode = "";
    string modulecode = "";
    string modulename = "";
    //string moduleid = "";
    //string userid = "";
    string pageno = "";
    string companycode = "";
    string companyname = "";
    string compname = "";
    string unitname = "";
    string username = "";
    string usrcode = "";

    string col1 = "";
    string col2 = "";
    string col3 = "";
    string col4 = "";
    string col5 = "";
    string reportname = "";
    string date = "";
    string rtame = "";
    string modname = "";

    int pgn = 0;
    int rowcounter = 0;
    int maxlimit = 45;

    protected void Page_Load(object sender, EventArgs e)
    {
       // hdnuserid.Value = Session["userid"].ToString();
        if (Session["userid"] == null || Session["userid"] == "" || Session["userid"] == "Nothing") 
        {
            Response.Redirect("login.aspx");
        }
        compname = Session["comp_name"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/userformwiserights.xml"));
        //lblreportname.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //lblrundate.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        dateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hdnunitcode.Value = Request.QueryString["unitcode"].ToString();//Session["center"].ToString();
        
        language = Request.QueryString["lang"].ToString();
        views = Request.QueryString["view"].ToString();
        usercode = Request.QueryString["usercode"].ToString();
        //username = Request.QueryString["username"].ToString();
        modulecode = Request.QueryString["modulecode"].ToString();
        companycode = Request.QueryString["companycode"].ToString();
        //companyname = Request.QueryString["companyname"].ToString();
        modulename = Request.QueryString["modulename"].ToString();
        date = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        unitcode = Session["center"].ToString();
        //unitname = Request.QueryString["unitname"].ToString();
        reportname = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        string rundate;


        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        rdate = tim[0];
        views = Request.QueryString["view"].ToString();

        if (!Page.IsPostBack)
        {
            Showreport();
        }
    }

        public void Showreport()
    {
        if (language == "hind")
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/userformwiserights_hindi.xml"));
            col1 = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            col2 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            col3 = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            col4 = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            col5 = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            reportname = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            date = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            pageno = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            modname = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            Showreport_hindi();
        }
        else
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/userformwiserights.xml"));
            col1 = ds.Tables[1].Rows[0].ItemArray[0].ToString();
            col2 = ds.Tables[1].Rows[0].ItemArray[1].ToString();
            col3 = ds.Tables[1].Rows[0].ItemArray[2].ToString();
            col4 = ds.Tables[1].Rows[0].ItemArray[3].ToString();
            col5 = ds.Tables[1].Rows[0].ItemArray[4].ToString();
            reportname = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            date = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            pageno = ds.Tables[1].Rows[0].ItemArray[5].ToString();
            modname = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            Showreport_english();
        }
    }
        public void Showreport_english()
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.userformwiserights obj = new NewAdbooking.classesoracle.userformwiserights();
                ds = obj.reportdata(companycode, unitcode, usercode, modulecode, Session["dateformat"].ToString(), extra1, extra2);
            }
            else
            {
                NewAdbooking.Classes.userformwiserights obj = new NewAdbooking.Classes.userformwiserights();
                ds = obj.reportdata(companycode, unitcode, usercode, modulecode, Session["dateformat"].ToString(), extra1, extra2);
            }
            string TBL = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                TBL += "<table width='100%' cellspacing='0' cellpadding = '0' border='0' style='verticle-align:top'>";

                string Header = creatheader_english(ds);
                TBL += Header;
                //int sno = 0;
                for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                {
                    if (rowcounter == maxlimit)
                    {
                        rowcounter = 0;
                        TBL += "</table>";
                        TBL += "</br>";
                        TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' class='break'>";
                        string newheader = creatheader_english(ds);
                        TBL += newheader;
                        TBL += "</table>";
                        TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                    }
                    usrcode = ds.Tables[0].Rows[p]["USER_CODE"].ToString();
                    if (usrcode == ds.Tables[0].Rows[p]["USER_CODE"].ToString())
                    {
                        //TBL += "<tr ><td font-size='10' font-family='Arial'class='newfont8'><b>User Name </b></td><td font-size='10' font-family='Arial'class='newfont8'>" + username + "</td><td></td><td></td><td font-size='10' font-family='Arial'class='newfont8'><b>Branch Name </b>&nbsp;&nbsp;" + unitname + "</td></tr>";
                        //TBL += "<tr font-size='10' font-family='Arial'><td  class='newfont8'>Company Name</td><td  class='newfont8'>" + companyname + "</td></tr>";
                        if (TBL.IndexOf("User Name &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString()) >= 0)
                        {
                            //sno = sno + 1;

                        }
                        else
                        {
                            TBL += "<tr style='padding-top:5px;'><td class='upperhead2' colspan='2' >User Name &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString() + "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_NAME"].ToString() + "&nbsp;:&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["ROLE_NAME"].ToString() + "</td><td></td><td class='upperhead2'colspan='2' align='right'>Branch Name &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["UNIT_NAME"].ToString() + "</td></tr><tr><td class='upperhead2' colspan='2'>Company Name &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["COMP_NAME"].ToString() + "</td></tr>";
                            //sno = 0;
                            //sno = sno + 1;
                        }
                        if (rowcounter == maxlimit)
                        {
                            rowcounter = 0;
                            TBL += "</table>";
                            TBL += "</br>";
                            TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' class='break'>";
                            string newheader = creatheader_english(ds);
                            TBL += newheader;
                            TBL += "</table>";
                            TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                        }
                        TBL += "<tr font-size='10' font-family='Arial'>";
                        //TBL += "<td class='newfont'>" + sno + "</td>";
                        TBL += "<td class='newfont4'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_ID"].ToString() + "</td>";
                        TBL += "<td class='newfont2'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_NAME"].ToString() + "</td>";
                        TBL += "<td class='newfont2'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_MENUNAME"].ToString() + "</td>";

                        TBL += "<td class='newfont2'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_TY_NAME"].ToString() + "</td>";
                        TBL += "<td class='newfont3'>";
                        TBL += ds.Tables[0].Rows[p]["USER_RIGHT"].ToString() + "</td>";
                        TBL += "</tr>";
                        rowcounter++;
                    }
                    
                }

                TBL += "</table>";
                report.InnerHtml = TBL;
            }
        }

        public void Showreport_hindi()
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.userformwiserights obj = new NewAdbooking.classesoracle.userformwiserights();
                ds = obj.reportdata(companycode, unitcode, usercode, modulecode, Session["dateformat"].ToString(), extra1, extra2);
            }
            else
            {
                NewAdbooking.Classes.userformwiserights obj = new NewAdbooking.Classes.userformwiserights();
                ds = obj.reportdata(companycode, unitcode, usercode, modulecode, Session["dateformat"].ToString(), extra1, extra2);
            }
            string TBL = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                TBL += "<table width='100%' cellspacing='0' cellpadding = '0' border='0' style='verticle-align:top'>";

                string Header = creatheader_hindi(ds);
                TBL += Header;
                //int sno = 0;
                for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                {
                    if (rowcounter == maxlimit)
                    {
                        rowcounter = 0;
                        TBL += "</table>";
                        TBL += "</br>";
                        TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' class='break'>";
                        string newheader = creatheader_hindi(ds);
                        TBL += newheader;
                        TBL += "</table>";
                        TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                    }
                    usrcode = ds.Tables[0].Rows[p]["USER_CODE"].ToString();
                    if (usrcode == ds.Tables[0].Rows[p]["USER_CODE"].ToString())
                    {
                        //TBL += "<tr ><td font-size='10' font-family='Arial'class='newfont8'><b>उपयोगकर्ता का नाम </b></td><td font-size='10' font-family='Arial'class='newfont8'>" + username + "</td><td></td><td></td><td font-size='10' font-family='Arial'class='newfont8'><b>शाखा का नाम </b>&nbsp;&nbsp;" + unitname + "</td></tr>";
                        //TBL += "<tr font-size='10' font-family='Arial'><td  class='newfont8'>कंपनी नाम</td><td  class='newfont8'>" + companyname + "</td></tr>";
                        if (TBL.IndexOf("उपयोगकर्ता का नाम &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString()) >= 0)
                        {
                            //sno = sno + 1;

                        }
                        else
                        {
                            TBL += "<tr style='padding-top:5px;'><td class='upperhead2' colspan='2' >उपयोगकर्ता का नाम &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString() + "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_NAME"].ToString() + "&nbsp;:&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["ROLE_NAME"].ToString() + "</td><td></td><td class='upperhead2' colspan='2' align='right'>शाखा का नाम &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["UNIT_NAME"].ToString() + "</td></tr><tr><td class='upperhead2' colspan='2'>कंपनी नाम &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["COMP_NAME"].ToString() + "</td></tr>";
                            //sno = 0;
                            //sno = sno + 1;
                        }
                        if (rowcounter == maxlimit)
                        {
                            rowcounter = 0;
                            TBL += "</table>";
                            TBL += "</br>";
                            TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' class='break'>";
                            string newheader = creatheader_hindi(ds);
                            TBL += newheader;
                            TBL += "</table>";
                            TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                        }
                        TBL += "<tr font-size='10' font-family='Arial'>";
                        //TBL += "<td class='newfont'>" + sno + "</td>";
                        TBL += "<td class='newfont4'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_ID"].ToString() + "</td>";
                        TBL += "<td class='newfont2'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_NAME"].ToString() + "</td>";
                        TBL += "<td class='newfont2'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_MENUNAME"].ToString() + "</td>";

                        TBL += "<td class='newfont2'>";
                        TBL += ds.Tables[0].Rows[p]["FORM_TY_NAME"].ToString() + "</td>";
                        TBL += "<td class='newfont3'>";
                        TBL += ds.Tables[0].Rows[p]["USER_RIGHT"].ToString() + "</td>";
                        TBL += "</tr>";
                        rowcounter++;
                    }
                    
                }
                TBL += "</table>";
                report.InnerHtml = TBL;
            }

        }
        public string creatheader_english(DataSet ds)
        {
            string Header = "";
            pgn = pgn + 1;

            Header += "<tr width='100%' style='padding-bottom:3px;'><td width '100%' colspan='5' align='center' class='p_head'>" + compname + "</td></tr>";
            Header += "<tr width '100%'><td  width '100%' class='tdforcolname13' colspan='5' align='center'><b>" + reportname + "</b></td></tr>";

            Header += "<tr width='100%'><td colspan='4' align='left' class='tdforcolname14'>" + date + "&nbsp;&nbsp;" + rdate + "<td  class='tdforcolname15' colspan='1'>Page No." + pgn + "</td></tr>";
            Header += "<tr style='padding-bottom:5px;'><td width='100%' colspan='2' class='upperhead1' align='left'>" + modname + ":&nbsp;&nbsp;&nbsp;" + modulename + "</td></tr>";

            Header += "<tr width='100%' style='padding-bottom:3px;'><td class='tdforcolname'><b>" + col1 + "</b></td>";
            Header += "<td class='tdforcolname1'><b>" + col2 + "</b></td>";
            Header += "<td class='tdforcolname1'><b>" + col3 + "</b></td>";
            Header += "<td class ='tdforcolname1'><b>" + col4 + "</b></td>";
            Header += "<td class='tdforcolname7'><b>" + col5 + "</b></td>";
            Header += "</tr>";
            return Header;
        }

        public string creatheader_hindi(DataSet ds)
        {
            string Header = "";
            pgn = pgn + 1;

            Header += "<tr width='100%' style='padding-bottom:3px;'><td width '100%' colspan='5' align='center' class='p_head'>" + compname + "</td></tr>";
            Header += "<tr width '100%'><td  width '100%' class='tdforcolname13' colspan='5' align='center'><b>" + reportname + "</b></td></tr>";

            Header += "<tr width='100%'><td colspan='4' align='left' class='tdforcolname14'>" + date + "&nbsp;&nbsp;" + rdate + "<td  class='tdforcolname15' colspan='1'>Page No." + pgn + "</td></tr>";
            Header += "<tr style='padding-bottom:5px;'><td width='100%' colspan='2' class='upperhead1' align='left'>"+ modname +":&nbsp;&nbsp;&nbsp;" + modulename + "</td></tr>";

            Header += "<tr width='100%' style='padding-bottom:3px;'><td class='tdforcolname'><b>" + col1 + "</b></td>";
            Header += "<td class='tdforcolname1'><b>" + col2 + "</b></td>";
            Header += "<td class='tdforcolname1'><b>" + col3 + "</b></td>";
            Header += "<td class ='tdforcolname1'><b>" + col4 + "</b></td>";
            Header += "<td class='tdforcolname7'><b>" + col5 + "</b></td>";
            Header += "</tr>";
            return Header;
        }
}
