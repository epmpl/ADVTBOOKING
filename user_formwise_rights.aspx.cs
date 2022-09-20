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

public partial class user_formwise_rights : System.Web.UI.Page
{
    string extra1 = "";
    string extra2 = "";
    string unitcode = "";
    string views = "";
    string language = "";
    string rdate = "";
    string usercode = "";
    string modulecode = "";
    string moduleid = "";
    string userid = "";
    string companycode = "";
    string companyname = "";
    string modulename = "";
    string unitname = "";
    string username = "";

    string col1 = "";
    string col2 = "";
    string col3 = "";
    string col4 = "";
    string col5 = "";
    string reportname = "";
    string date = "";
    string rtame = "";
    string modname = "";

    //======================================for paging=============================================================

    int p;
    //int m;
    int jj = 1;
    int kk;
    int ll;
    int j;
    static int current;
    int pagec;
    int pagecount;
    int pagewidth = 45;
    static int ab = 0;
    static int b = 9;
    static int k;
    static int l;
    protected void Page_Load(object sender, EventArgs e)
    {
        //hdnuserid.Value = Session["userid"].ToString();
        if (Session["userid"] == null || Session["userid"] == "" || Session["userid"] == "Nothing") 
        {
            Response.Redirect("login.aspx");
        }
        lblname.Text = Session["comp_name"].ToString();
        companyname = Session["comp_name"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/userformwiserights.xml"));
        dateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hdnunitcode.Value = Session["center"].ToString();
        
        language = Request.QueryString["lang"].ToString();
        views = Request.QueryString["view"].ToString();
        usercode = Request.QueryString["usercode"].ToString();
        modulecode = Request.QueryString["modulecode"].ToString();
        modulename = Request.QueryString["modulename"].ToString();
        companycode = Request.QueryString["companycode"].ToString();
        unitcode = Request.QueryString["unitcode"].ToString();

        string rundate;


        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        lbldate.Text = tim[0];
        rdate = tim[0];
        views = Request.QueryString["view"].ToString();

        if (!Page.IsPostBack)
        {
            //===========================================for paging============================================================
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
            //================================================================================================================    
            if (views == "ons")
            {
                Showreport();
            }
            else if (views == "exc")
            {
                showreportexcel();
            }
            else if (views == "pdf")
            {
                showreportpdf();
            }
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
        lblreportname.Text = reportname;
        lblrundate.Text = date;
        lblmodulename.Text = modname;
        if (Request.QueryString["modulename"].ToString() == "")
        {
            lblmodule_name.Text = "";
        }
        else
        {
            lblmodule_name.Text = modulename;
        }

        //===============================================for paging=======================================================================
        int rcount = ds.Tables[0].Rows.Count;
        pagec = rcount % pagewidth;
        pagecount = rcount / pagewidth;

        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }
        //================================================for next and previous===========================================================

        if (ll == 1)
        {
            kk = ll;
            jj = ll + 1;
        }
        else if (ll == pagecount)
        {
            kk = ll - 1;
            jj = ll;
        }
        else
        {
            kk = ll - 1;
            jj = ll + 1;
        }
        int r1 = p + pagewidth;
        //=================================with r1===============================================================================
        ab = r1 / pagewidth;
        b = ab + 9;
        if (b > pagecount)
        {
            b = pagecount;
        }
        if (rcount == 0)
        {
            ab = 0;
            b = 0;
        }

        //========================================================================================================================
        string TBL = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>";
            //===================================for column name===================================================================
            TBL += "<tr class='imageclass' ><td class='pagingcenter' style='height:30px'><b>" + col1 + "</b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col2 + "<b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col3 + "<b></td>";
            TBL += "<td class ='pagingcenter' style='height:30px'>" + col4 + "<b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col5 + "<b></td>";

            TBL += "</tr>";
            //=======================================for values========================================================
            //int sno = 0;
            for (p = p; p < r1 && p < rcount; p++)
            {
                string usrcode = ds.Tables[0].Rows[p]["USER_CODE"].ToString();
                if (usrcode == ds.Tables[0].Rows[p]["USER_CODE"].ToString())
                {
                    //TBL += "<tr ><td font-size='10' font-family='Arial'class='newfont8'><b>User Name </b></td><td font-size='10' font-family='Arial'class='newfont8'>" + username + "</td><td></td><td></td><td font-size='10' font-family='Arial'class='newfont8'><b>Branch Name </b>&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + unitname +"</td></tr>";
                    // TBL += "<tr font-size='10' font-family='Arial'><td  class='newfont8'>Company Name</td><td  class='newfont8'>" + companyname + "</td></tr>";
                    if (TBL.IndexOf("User Name &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString()) >= 0)
                    {
                        //sno = sno + 1;

                    }
                    else
                    {
                        TBL += "<tr style='padding-top:5px;'><td class='upperhead2' colspan='2' >User Name &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString() + "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_NAME"].ToString() + "&nbsp;:&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["ROLE_NAME"].ToString() + "" + "</td><td></td><td class='upperhead2'colspan='2'align='right'>Branch Name &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["UNIT_NAME"].ToString() + "</td></tr><tr><td class='upperhead2' colspan='2'>Company Name &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["COMP_NAME"].ToString() + "</td></tr>";
                        //sno = 0;
                        //sno = sno + 1;
                    }
                    //sno = p + 1;
                    TBL += "<tr font-size='10' font-family='Arial'>";
                    //TBL += "<td class='newfont'>" + sno + "</td>";
                    TBL += "<td class='newfont'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_ID"].ToString() + "</td>";
                    TBL += "<td class='newfont1'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont1'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_MENUNAME"].ToString() + "</td>";

                    TBL += "<td class='newfont1'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_TY_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont5'>";
                    TBL += ds.Tables[0].Rows[p]["USER_RIGHT"].ToString() + "</td>";
                    TBL += "</tr>";
                }
            }
            //==============================================for paging===============================================================================

            if (pagecount > 1)
            {
                TBL = TBL + "<tr><td colspan='50'><table border='0' class='pagingcenter' style='height:30px;'>";
                TBL = TBL + "</tr>";

                if (ab <= 1)
                {
                    TBL = TBL + "<td class='pagingleft' style='width:200px'>Current Page :" + current + "</td><td class='pagingcenter' colspan='70'><td id='first' class='pagingcenter' ><img id='start' alt='first' src='Images/first_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td id='dec' class='pagingcenter' ><img id='prev' alt='previous' src='Images/previous_btn.jpg' style='border-color:#5195dd;margin-bottom:-5px'/></td>";
                }
                else
                {
                    TBL = TBL + "<td class='pagingleft' style='width:200px'>Current Page :" + current + "</td><td class='pagingcenter' colspan='70'></td><td id='first' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=1" + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='start' alt='first' src='Images/first_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='dec' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + kk + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='prev' alt='previous' src='Images/previous_btn.jpg' style='border-color:#5195dd;margin-bottom:-5px'/></a></td>";
                }
                if (ab < 10 || jj < 10)
                {
                    for (int j = 1; j <= 10 && j <= pagecount; j++)
                    {
                        if (this.j < 10)
                        {
                            k = j + 1;
                            l = j;
                            TBL = TBL + "<td id=" + j + " class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + j + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><font face='verdana' color='white' size='2.5px'>" + j + "</a>|<font color='white'></td>";
                        }
                    }
                    if (ab == 1 && ab <= pagecount)
                    {
                        TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + 2 + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='inc' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + pagecount + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                    }
                    else
                    {
                        if (ab == pagecount)
                        {
                            TBL = TBL + "<td id='last' class='pagingcenter' ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td id='inc' class='pagingcenter' ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                        }
                        else
                        {
                            TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + jj + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='inc' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + pagecount + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                        }
                    }
                }
            }
            else if (ab >= 10 || jj >= 10)
            {
                for (int j = ab - 8; j <= ab + 1 && j <= pagecount; j++)
                {
                    k = j + 1;
                    l = j;
                    TBL = TBL + "<td id=" + j + " class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + j + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><font face='verdana' color='white' size='2.5px'>" + j + "</a>| <font color:'white'></td>";
                }
                if (ab == 1 && ab <= pagecount)
                {
                    TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + 2 + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='inc' class='pagingcenter' ><a href=\"user_formwise_rights?page=" + pagecount + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                }
                else
                {
                    if (ab == pagecount)
                    {
                        TBL = TBL + "<td id='last' class='pagingcenter' ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td id='inc' class='pagingcenter' ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                    }
                    else
                    {
                        TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + jj + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                    }
                }
            }



            report.InnerHtml = TBL;
            btnprint.Attributes.Add("onclick", "javascript:return window.open('printuserformwiserights.aspx?usercode=" + usercode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&companycode=" + companycode + "&view=" + views + "')");

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
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
        lblreportname.Text = reportname;
        lblrundate.Text = date;
        lblmodulename.Text = modname;
        //lblmodule_name.Text = modulename;
        if (Request.QueryString["modulename"].ToString() == "")
        {
            lblmodule_name.Text = "";
        }
        else
        {
            lblmodule_name.Text = modulename;
        }
        //===============================================for paging=======================================================================
        int rcount = ds.Tables[0].Rows.Count;
        pagec = rcount % pagewidth;
        pagecount = rcount / pagewidth;

        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }
        //================================================for next and previous===========================================================

        if (ll == 1)
        {
            kk = ll;
            jj = ll + 1;
        }
        else if (ll == pagecount)
        {
            kk = ll - 1;
            jj = ll;
        }
        else
        {
            kk = ll - 1;
            jj = ll + 1;
        }
        int r1 = p + pagewidth;
        //=================================with r1===============================================================================
        ab = r1 / pagewidth;
        b = ab + 9;
        if (b > pagecount)
        {
            b = pagecount;
        }
        if (rcount == 0)
        {
            ab = 0;
            b = 0;
        }

        //========================================================================================================================
        string TBL = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>";
            //===================================for column name===================================================================
            TBL += "<tr class='imageclass'><td class='pagingcenter' style='height:30px'><b>" + col1 + "</b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col2 + "<b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col3 + "<b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col4 + "<b></td>";
            TBL += "<td class='pagingcenter' style='height:30px'>" + col5 + "<b></td>";

            TBL += "</tr>";
            //=======================================for values========================================================
            //int sno = 0;
            for (p = p; p < r1 && p < rcount; p++)
            {
                string usrcode = ds.Tables[0].Rows[p]["USER_CODE"].ToString();
                if (usrcode == ds.Tables[0].Rows[p]["USER_CODE"].ToString())
                {
                    //TBL += "<tr ><td font-size='10' font-family='Arial' class='newfont8'><b>उपयोगकर्ता का नाम </b></td><td font-size='10' font-family='Arial'class='newfont8'>" + username + "</td><td></td><td></td><td font-size='10' font-family='Arial' class='newfont8'><b>शाखा का नाम </b>&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + unitname + "</td></tr>";
                    //TBL += "<tr font-size='10' font-family='Arial'><td  class='newfont8'>कंपनी नाम</td><td  class='newfont8'>" + companyname + "</td></tr>";
                    if (TBL.IndexOf("उपयोगकर्ता का नाम &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString()) >= 0)
                    {
                        //sno = sno + 1;

                    }
                    else
                    {
                        TBL += "<tr style='padding-top:5px;'><td class='upperhead2' colspan='2' >उपयोगकर्ता का नाम &nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_CODE"].ToString() + "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_NAME"].ToString() + "&nbsp;:&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["ROLE_NAME"].ToString() + "" + "</td><td></td><td class='upperhead2'colspan='2' align='right'>शाखा का नाम &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["UNIT_NAME"].ToString() + "</td></tr><tr><td class='upperhead2' colspan='2'>कंपनी नाम &nbsp;&nbsp;" + ds.Tables[0].Rows[p]["COMP_NAME"].ToString() + "</td></tr>";
                        //sno = 0;
                        //sno = sno + 1;
                    }
                    //sno = p + 1;
                    TBL += "<tr font-size='10' font-family='Arial'>";
                    //TBL += "<td class='newfont'>" + sno + "</td>";
                    TBL += "<td class='newfont'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_ID"].ToString() + "</td>";
                    TBL += "<td class='newfont1'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont1'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_MENUNAME"].ToString() + "</td>";

                    TBL += "<td class='newfont1'>";
                    TBL += ds.Tables[0].Rows[p]["FORM_TY_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont5'>";
                    TBL += ds.Tables[0].Rows[p]["USER_RIGHT"].ToString() + "</td>";
                    TBL += "</tr>";
                }
            }
            //==============================================for paging===============================================================================

            if (pagecount > 1)
            {
                TBL = TBL + "<tr><td colspan='50'><table border='0' class='pagingcenter' style='height:30px;'>";
                TBL = TBL + "</tr>";

                if (ab <= 1)
                {
                    TBL = TBL + "<td class='pagingleft' style='width:200px'>Current Page :" + current + "</td><td class='pagingcenter' colspan='70'><td id='first' class='pagingcenter' ><img id='start' alt='first' src='Images/first_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td id='dec' class='pagingcenter' ><img id='prev' alt='previous' src='Images/previous_btn.jpg' style='border-color:#5195dd;margin-bottom:-5px'/></td>";
                }
                else
                {
                    TBL = TBL + "<td class='pagingleft' style='width:200px'>Current Page :" + current + "</td><td class='pagingcenter' colspan='70'></td><td id='first' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=1" + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='start' alt='first' src='Images/first_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='dec' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + kk + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='prev' alt='previous' src='Images/previous_btn.jpg' style='border-color:#5195dd;margin-bottom:-5px'/></a></td>";
                }
                if (ab < 10 || jj < 10)
                {
                    for (int j = 1; j <= 10 && j <= pagecount; j++)
                    {
                        if (this.j < 10)
                        {
                            k = j + 1;
                            l = j;
                            TBL = TBL + "<td id=" + j + " class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + j + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><font face='verdana' color='white' size='2.5px'>" + j + "</a>|<font color='white'></td>";
                        }
                    }
                    if (ab == 1 && ab <= pagecount)
                    {
                        TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + 2 + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='inc' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + pagecount + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                    }
                    else
                    {
                        if (ab == pagecount)
                        {
                            TBL = TBL + "<td id='last' class='pagingcenter' ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td id='inc' class='pagingcenter' ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                        }
                        else
                        {
                            TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + jj + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='inc' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + pagecount + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                        }
                    }
                }
            }
            else if (ab >= 10 || jj >= 10)
            {
                for (int j = ab - 8; j <= ab + 1 && j <= pagecount; j++)
                {
                    k = j + 1;
                    l = j;
                    TBL = TBL + "<td id=" + j + " class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + j + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><font face='verdana' color='white' size='2.5px'>" + j + "</a>| <font color:'white'></td>";
                }
                if (ab == 1 && ab <= pagecount)
                {
                    TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + 2 + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td id='inc' class='pagingcenter' ><a href=\"user_formwise_rights?page=" + pagecount + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                }
                else
                {
                    if (ab == pagecount)
                    {
                        TBL = TBL + "<td id='last' class='pagingcenter' ><img id='next' alt='next' src='Images/next_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td id='inc' class='pagingcenter' ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                    }
                    else
                    {
                        TBL = TBL + "<td id='last' class='pagingcenter' ><a href=\"user_formwise_rights.aspx?page=" + jj + "&usercode=" + usercode + "&companycode=" + companycode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&view=" + views + "\" ><img id='last' alt='last' src='Images/last_btn.jpg'style='border-color:#5195dd;margin-bottom:-5px'/></a></td><td class='pagingright' style='width:700px' align='right'>Total Page :" + pagecount + "</td></table></td></tr>";
                    }
                }
            }



            report.InnerHtml = TBL;
            btnprint.Attributes.Add("onclick", "javascript:return window.open('printuserformwiserights.aspx?usercode=" + usercode + "&lang=" + language + "&unitcode=" + unitcode + "&modulecode=" + modulecode + "&modulename=" + modulename + "&companycode=" + companycode + "&view=" + views + "')");

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
    public void showreportexcel()
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
            modname = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            //pageno = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            showreportexcel_hindi();
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
            modname = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            //pageno = ds.Tables[1].Rows[0].ItemArray[5].ToString();
            showreportexcel_english();
        }
    }
    public void showreportexcel_english()
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
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");


        //int sno = 0;
        string TBL = "";
        if (ds.Tables[0].Rows.Count >= 0)
        {
            TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='1'>";
            TBL += "<tr><td width='100%' colspan='6' align='center'style='font-size:20px; font-family:Arial:'><b>" + companyname + "</td></tr>";
            TBL += "<tr><td width ='100%' colspan='6' align='center' style='font-weight:bold;'>" + reportname + "</td></tr>";
            TBL += "<tr><td style='font-size:12px; font-family:Arial:' align='left'><b>" + date + ": &nbsp;&nbsp;&nbsp;" + rdate + "</b></td></tr>";
            TBL += "<tr><td><b>" + modname + "</b></td><td><b>" + modulename + "</b></td></tr>";
            //==============================================for column name================================================================================


            TBL += "<tr class='imageclass'><td class='tdforcolname4' style='font-size:10px; font-family:Arial:'><b>" + col1 + "</b></td>";
            TBL += "<td class='tdforcolname3' style='font-size:10px; font-family:Arial:'><b>" + col2 + "</b></td>";
            TBL += "<td class='tdforcolname3' style='font-size:10px; font-family:Arial:'><b>" + col3 + "</b></td>";
            TBL += "<td class ='tdforcolname3' style='font-size:10px; font-family:Arial:'><b>" + col4 + "</b></td>";
            TBL += "<td class='tdforcolname5' style='font-size:10px; font-family:Arial:'><b>" + col5 + "</b></td>";
            TBL += "</tr>";
            //==============================================for values============================================================================================
            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {
                string usrcode = ds.Tables[0].Rows[p]["USER_CODE"].ToString();
                if (usrcode == ds.Tables[0].Rows[p]["USER_CODE"].ToString())
                {
                    //sno = m + 1;
                    //TBL += "<td class='newfont'>" + sno + "</td>";
                    if (TBL.IndexOf("<b>User Name &nbsp;&nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["USER_CODE"].ToString()) >= 0)
                    {
                        //sno = sno + 1;

                    }
                    else
                    {
                        TBL += "<tr style='padding-top:5px;'><td class='upperhead2' colspan='2' ><b>User Name &nbsp;&nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["USER_CODE"].ToString() + "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_NAME"].ToString() + "&nbsp;:&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["ROLE_NAME"].ToString() + "" + "</td><td></td><td class='upperhead2'colspan='2' align='right'><b>Branch Name &nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["UNIT_NAME"].ToString() + "</td></tr><tr><td class='upperhead2' colspan='2'><b>Company Name &nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["COMP_NAME"].ToString() + "</td></tr>";
                        //sno = 0;
                        //sno = sno + 1;
                    }
                    TBL += "<td class='newfont' align='left' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_ID"].ToString() + "</td>";
                    TBL += "<td class='newfont1' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont1' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_MENUNAME"].ToString() + "</td>";

                    TBL += "<td class='newfont1' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_TY_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont5' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["USER_RIGHT"].ToString() + "</td>";
                    TBL += "</tr>";
                    report.InnerHtml = TBL;

                }
                report.InnerHtml = TBL;
            }
        }
        else
        {
            Response.Write("<script>alert('searching criteria does not produce any result');window.close();</script>");

        }
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteBreak();
        report.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    public void showreportexcel_hindi()
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
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        //int sno = 0;
        string TBL = "";
        if (ds.Tables[0].Rows.Count >= 0)
        {
            TBL += "<table width='100%' cellspacing='0' cellpadding='0' border='1'>";
            TBL += "<tr><td width='100%' colspan='6' align='center'style='font-size:20px; font-family:Arial:'><b>" + companyname + "</td></tr>";
            TBL += "<tr><td width ='100%' colspan='6' align='center' style='font-weight:bold;'>" + reportname + "</td></tr>";
            TBL += "<tr><td style='font-size:12px; font-family:Arial:' align='left'><b>" + date + ": &nbsp;&nbsp;&nbsp;" + rdate + "</b></td></tr>";
            TBL += "<tr><td><b>" + modname + "</b></td><td><b>" + modulename + "</b></td></tr>";
            //==============================================for column name================================================================================


            TBL += "<tr class='imageclass'><td class='tdforcolname4' style='font-size:10px; font-family:Arial:'><b>" + col1 + "</b></td>";
            TBL += "<td class='tdforcolname3' style='font-size:10px; font-family:Arial:'><b>" + col2 + "</b></td>";
            TBL += "<td class='tdforcolname3' style='font-size:10px; font-family:Arial:'><b>" + col3 + "</b></td>";
            TBL += "<td class ='tdforcolname3' style='font-size:10px; font-family:Arial:'><b>" + col4 + "</b></td>";
            TBL += "<td class='tdforcolname5' style='font-size:10px; font-family:Arial:'><b>" + col5 + "</b></td>";
            TBL += "</tr>";
            //==============================================for values============================================================================================
            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {
                string usrcode = ds.Tables[0].Rows[p]["USER_CODE"].ToString();
                if (usrcode == ds.Tables[0].Rows[p]["USER_CODE"].ToString())
                {
                    //sno = m + 1;
                    //TBL += "<td class='newfont'>" + sno + "</td>";
                    if (TBL.IndexOf("<b>उपयोगकर्ता का नाम &nbsp;&nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["USER_CODE"].ToString()) >= 0)
                    {
                        //sno = sno + 1;

                    }
                    else
                    {
                        TBL += "<tr style='padding-top:5px;'><td class='upperhead2' colspan='2' ><b>उपयोगकर्ता का नाम &nbsp;&nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["USER_CODE"].ToString() + "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["USER_NAME"].ToString() + "&nbsp;:&nbsp&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["ROLE_NAME"].ToString() + "" + "</td><td></td><td class='upperhead2'colspan='2' align='right'><b>शाखा का नाम &nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["UNIT_NAME"].ToString() + "</td></tr><tr><td class='upperhead2' colspan='2'><b>कंपनी नाम &nbsp;&nbsp;</b>" + ds.Tables[0].Rows[p]["COMP_NAME"].ToString() + "</td></tr>";
                        //sno = 0;
                        //sno = sno + 1;
                    }
                    TBL += "<td class='newfont' align='left' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_ID"].ToString() + "</td>";
                    TBL += "<td class='newfont1' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont1' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_MENUNAME"].ToString() + "</td>";

                    TBL += "<td class='newfont1' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["FORM_TY_NAME"].ToString() + "</td>";
                    TBL += "<td class='newfont5' style='font-size:10px; font-family:Arial:'>";
                    TBL += ds.Tables[0].Rows[m]["USER_RIGHT"].ToString() + "</td>";
                    TBL += "</tr>";
                    report.InnerHtml = TBL;

                }
                report.InnerHtml = TBL;
            }
        }
        else
        {
            Response.Write("<script>alert('searching criteria does not produce any result');window.close();</script>");

        }
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteBreak();
        report.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }


    //================================================for pdf================================================================================
    public void showreportpdf()
    {
        string pdfname = "";
        pdfname = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "\\" + pdfname;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();

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

         float[] arr = {0.3f,0.3f,0.3f,1.3f,0.4f,.3f};
         float[] arr1 = { 0.4f, 0.3f, 0.3f, 1.3f, 0.4f, .3f };
        
        int rowcount = ds.Tables[0].Rows.Count;
        int columncount = ds.Tables[0].Columns.Count;
        int NumColumns = ds.Tables[0].Columns.Count;

        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 12, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 10);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 20, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font12 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 10, iTextSharp.text.Font.BOLD);

        PdfPTable tbl6 = new PdfPTable(1);
        tbl6.DefaultCell.BorderWidth = 0;
        tbl6.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        tbl6.addCell(new iTextSharp.text.Phrase(Session["comp_name"].ToString(), font8));
        tbl6.WidthPercentage = 100;
        document.Add(tbl6);


        PdfPTable tbl = new PdfPTable(1);
        float[] xy = { 100 };
        tbl.DefaultCell.BorderWidth = 0;
        tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //tbl.setWidths(xy);
        tbl.addCell(new iTextSharp.text.Phrase("USER FORM WISE RIGHTS", font9));
        //string rundate = DateTime.Now.ToString();
        //string rdate = rundate.Substring(0, 10);
        //tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //tbl.addCell(new iTextSharp.text.Phrase("Run Date",font11));
        //tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        //tbl.addCell(new iTextSharp.text.Phrase(rdate, font11));
        tbl.WidthPercentage = 100;
        document.Add(tbl);


        PdfPTable tbl1 = new PdfPTable(13);
        tbl1.DefaultCell.BorderWidth = 0;
        tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl1.WidthPercentage = 100;


        string rundate = DateTime.Now.ToString();
        string rdate = rundate.Substring(0, 10);
        tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl1.addCell(new iTextSharp.text.Phrase("Run Date:", font12));
        tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl1.addCell(new iTextSharp.text.Phrase(rdate, font11));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        tbl1.addCell(new iTextSharp.text.Phrase("", font10));
        document.Add(tbl1);


        PdfPTable tbl2 = new PdfPTable(5);
        tbl2.DefaultCell.BorderWidth = 0;
        tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl2.WidthPercentage = 100;
        tbl2.addCell(new iTextSharp.text.Phrase("Module Name", font12));
        tbl2.addCell(new iTextSharp.text.Phrase(modulename, font11));
        tbl2.addCell(new iTextSharp.text.Phrase("", font10));
        tbl2.addCell(new iTextSharp.text.Phrase("", font10));
        tbl2.addCell(new iTextSharp.text.Phrase("", font10));
        document.Add(tbl2);
        //tbl1.WidthPercentage =20;


        PdfPTable tbl3 = new PdfPTable(5);

        tbl3.DefaultCell.BorderWidth = 0;

        tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl3.WidthPercentage = 100;


        tbl3.addCell(new iTextSharp.text.Phrase("S.NO.", font12));
        tbl3.addCell(new iTextSharp.text.Phrase("FORM NAME", font12));
        tbl3.addCell(new iTextSharp.text.Phrase("FORM MENU NAME", font12));

        tbl3.addCell(new iTextSharp.text.Phrase("FORM TYPE NAME", font12));

        tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        tbl3.addCell(new iTextSharp.text.Phrase("PERMISSION", font12));

        document.Add(tbl3);

        PdfPTable tbl7 = new PdfPTable(arr);
        tbl7.DefaultCell.BorderWidth = 0;
        tbl7.WidthPercentage = 100;
        tbl7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl7.addCell(new iTextSharp.text.Phrase("User Name:", font12));
        tbl7.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["USER_CODE"].ToString(), font12));
        tbl7.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["USER_NAME"].ToString(), font12));
        tbl7.addCell(new iTextSharp.text.Phrase("", font12));
        
       
        tbl7.addCell(new iTextSharp.text.Phrase("Branch Name:", font12));
        tbl7.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["UNIT_NAME"].ToString(), font12));
        document.Add(tbl7);

        PdfPTable tbl8 = new PdfPTable(arr1);
        tbl8.DefaultCell.BorderWidth = 0;
        tbl8.WidthPercentage = 100;
        tbl8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl8.addCell(new iTextSharp.text.Phrase("Company Name:", font12));
        tbl8.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["COMP_NAME"].ToString(), font12));
        tbl8.addCell(new iTextSharp.text.Phrase("", font12));
       
        tbl8.addCell(new iTextSharp.text.Phrase("", font12));



        tbl8.addCell(new iTextSharp.text.Phrase("", font12));
        tbl8.addCell(new iTextSharp.text.Phrase("", font12));
        document.Add(tbl8);


        PdfPTable tbl4 = new PdfPTable(5);

        tbl4.DefaultCell.BorderWidth = 0;
        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl4.WidthPercentage = 100;
        //int x = 1;

        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        {
            
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;


                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["FORM_ID"].ToString(), font11));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["FORM_NAME"].ToString(), font11));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["FORM_MENUNAME"].ToString(), font11));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["FORM_TYPE"].ToString(), font11));

                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["USER_RIGHT"].ToString(), font11));
            }
        
            document.Add(tbl4);
            document.Close();
            Response.Redirect(pdfname, false);
        }


    }
