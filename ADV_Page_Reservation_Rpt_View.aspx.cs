using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ADV_Page_Reservation_Rpt_View : System.Web.UI.Page
{
    string P_FRDT = "", P_TODT = "", pageprem = "", reportname = "", view = "", P_DATEFORMAT = "", P_COMP_CODE = "", companyname = "", rundate = "", rdate = "", rdatefinalhdsmain="";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 40;
    int pgn = 0;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] != null)
        {
            hdncompcode.Value       = Session["compcode"].ToString();
            hdncompname.Value       = Session["comp_name"].ToString();
            hdnbrancd.Value         = Session["revenue"].ToString();
            //hdnbrannm.Value       = Session["revenuename"].ToString();
            hdnusernm.Value         = Session["Username"].ToString();
            hdnuserid.Value         = Session["userid"].ToString();
            hiddendateformat.Value  = Session["dateformat"].ToString();
            P_COMP_CODE             = Session["compcode"].ToString();
            P_DATEFORMAT            = Session["dateformat"].ToString();
            companyname             = Session["comp_name"].ToString();
        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(ADV_Page_Reservation_Rpt_View));
        P_FRDT      = Request.QueryString["P_FRDT"].ToString();
        P_TODT      = Request.QueryString["P_TODT"].ToString();
        pageprem    = Request.QueryString["pageprem"].ToString();
        view        = Request.QueryString["dest"].ToString();

        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        rdate = tim[0];
        string[] rdatehdsmaintds = rdate.Split(' ');
        string hdsmainhjrdate = rdatehdsmaintds[0];
        string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
        string hdsmainhjrdate1 = hdsmainhjrdateS[0];
        string hdsmainhjrdate2 = hdsmainhjrdateS[1];
        string hdsmainhjrdate3 = hdsmainhjrdateS[2];
        rdatefinalhdsmain = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;
        reportname = "Page Reservation Report";

        string[] parameterValueArray = { P_COMP_CODE, pageprem, P_FRDT, P_TODT, P_DATEFORMAT };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "AD_RESERVE_REPT";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "AD_RESERVE_REPT";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "AD_RESERVE_REP";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (!Page.IsPostBack)
        {
            if (view == "O")
            {
                gridbind();
            }
            else
            {
                //gridbind();
                gridbind_excel();
            }
             btnPrint.Attributes.Add("onclick", "javascript:return printreport();");

        }

        
    }
    public void gridbind()
    {
        
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'><b>" + companyname + "</b></td></tr>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'><b>" + reportname + "</b></td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date : " + P_FRDT + "</b></td><td style='text-align:right'><b>ToDate : " + P_TODT + "</b></td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Run Date : " + rdatefinalhdsmain + "</b></td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='10px'>" + "Sr.No." + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='25px'>" + "Page Position" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='25px'>" + "Size(W*H)" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='200px'>" + "Client Name" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='25px'>" + "Edition" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='100px'>" + "Publication" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='100px'>" + "Publishing Center" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='40px'>" + "Booking Center" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Booked By" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Schedule Date" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Booking Date" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Cancellation Date" + "</td></tr>";
            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    tbl += "</table><p>";
                    tbl += "</br>";
                    tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                    tbl += "</table><p>";

                    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr><td  class='middle31new' width='10px'>" + "Sr.No." + "</td><td  class='middle31new'>" + "Page Position" + "</td><td  class='middle31new'>" + "Size(W*H)" + "</td><td  class='middle31new'>" + "Client Name" + "</td><td  class='middle31new'>" + "Edition" + "</td><td  class='middle31new'>" + "Publication" + "</td><td  class='middle31new'>" + "Booking Center" + "</td><td  class='middle31new'>" + "Booked By" + "</td><td  class='middle31new'>" + "Schedule Date" + "</td><td  class='middle31new'>" + "Booking Date" + "</td><td  class='middle31new'>" + "Cancellation Date" + "</td></tr>";
                    //tbl += "</table></p>";
                    //tbl += "<p><table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                }

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data'   style='text-align:center;'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='25px'style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["PAGE_POSITION_NM"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["SIZE"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:left;'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME_VAL"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
               // tbl += "-" + "</td>";
                tbl += ds.Tables[0].Rows[p]["PUBLICATION_NM"].ToString() + "</td>";
                tbl += "<td class='rep_data'   style='text-align:center;'>";
                // tbl += "-" + "</td>";
                string PRINTING_CENTER_NM = ds.Tables[0].Rows[p]["PRINTING_CENTER_NM"].ToString();
                int v_lenght = 0;
                v_lenght = PRINTING_CENTER_NM.Length;
                v_lenght = PRINTING_CENTER_NM.Split(',').Length;
                string abc = "";
                int a1 = 0;
                if (v_lenght > 6)
                {
                    
                    for (int a = 0; a < v_lenght; a++)
                    {
                        if (abc == "")
                        {
                            abc = PRINTING_CENTER_NM.Split(',')[0];
                        }
                        else
                        {
                            if (a1 > 6)
                            {
                                abc = abc +"," + "</br>";
                                a1 = 0;
                            }
                            if (a1 == 0)
                            {
                                abc = abc   + PRINTING_CENTER_NM.Split(',')[a];
                            }
                            abc = abc +","+ PRINTING_CENTER_NM.Split(',')[a];
                        }
                        a1++;
                    }
                }
                else
                {
                    abc = PRINTING_CENTER_NM;
                }
                tbl += abc + "</td>";
                tbl += "<td class='rep_data'   style='text-align:center;'>";
               // tbl += "-" + "</td>";
                 tbl += ds.Tables[0].Rows[p]["UNIT_CODE"].ToString() + "</td>";

                 tbl += "<td class='rep_data'  style='text-align:center;'>";
                 tbl += ds.Tables[0].Rows[p]["USERNAME"].ToString() + "</td>";
                //tbl += "ADMINISTRATOR" + "</td>";

                tbl += "<td class='rep_data' style='text-align:center;' >";
                tbl += ds.Tables[0].Rows[p]["INSERT_DATE"].ToString() + "</td>";
                tbl += "<td class='rep_data'  style='text-align:center;'>";
                if (ds.Tables[0].Rows[p]["CREATION_DATE"].ToString() != "" || ds.Tables[0].Rows[p]["CREATION_DATE"].ToString() != null)
                {
                    tbl += ds.Tables[0].Rows[p]["CREATION_DATE"].ToString() + "</td>";
                }
                else
                {
                    tbl += "-" + "</td>";
                }
                tbl += "<td class='rep_data'  style='text-align:center;'>";
                //tbl += "-" + "</td>";
                if (ds.Tables[0].Rows[p]["CANCEL_DATE"].ToString() != "" || ds.Tables[0].Rows[p]["CANCEL_DATE"].ToString() != null)
                {
                    tbl += ds.Tables[0].Rows[p]["CANCEL_DATE"].ToString() + "</td>";
                }
                else
                {
                    tbl += "-" + "</td>";
                }
                rowcounter++;

            }
            tbl += "<tr><td  class='middle31new' style='text-align:right;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' colspan='12'><b>Total Ads : " + sno1.ToString() + "</b></td></tr>";
            tbl += "</table></p>";

            report.InnerHtml = tbl;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }

    public void gridbind_excel()
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='10' style='text-align:center'><b>" + companyname + "</b></td></tr>";
            tbl += "<tr class='headingc'><td colspan='10' style='text-align:center'><b>" + reportname + "</b></td></tr>";
            tbl += "<tr class='middle33'><td colspan='6' style='text-align:center'><b>From Date : " + P_FRDT + "</b></td><td style='text-align:right'><b>ToDate : " + P_TODT + "</b></td></tr>";
            tbl += "<tr class='middle33'><td colspan='6' style='text-align:center'><b>Run Date : " + rdatefinalhdsmain + "</b></td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='10px'>" + "Sr.No." + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='25px'>" + "Page Position" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='25px'>" + "Size(W*H)" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='200px'>" + "Client Name" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;'width='25px'>" + "Edition" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='100px'>" + "Publication" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='100px'>" + "Publishing Center" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='40px'>" + "Booking Center" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Booked By" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Schedule Date" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Booking Date" + "</td>";
            tbl += "<td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' width='10px'>" + "Cancellation Date" + "</td></tr>";
            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    tbl += "</table><p>";
                    tbl += "</br>";
                    tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";
                    tbl += "</table><p>";

                    tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr><td  class='middle31new' width='10px'>" + "Sr.No." + "</td><td  class='middle31new'>" + "Page Position" + "</td><td  class='middle31new'>" + "Size(W*H)" + "</td><td  class='middle31new'>" + "Client Name" + "</td><td  class='middle31new'>" + "Edition" + "</td><td  class='middle31new'>" + "Publication" + "</td><td  class='middle31new'>" + "Booking Center" + "</td><td  class='middle31new'>" + "Booked By" + "</td><td  class='middle31new'>" + "Schedule Date" + "</td><td  class='middle31new'>" + "Booking Date" + "</td><td  class='middle31new'>" + "Cancellation Date" + "</td></tr>";
                }

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial' style='border-bottom:1px;'>";
                tbl += "<td class='rep_data'   style='text-align:center;border-bottom:1px;'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='25px'style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["PAGE_POSITION_NM"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["SIZE"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:left;'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME_VAL"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["PUBLICATION_NM"].ToString() + "</td>";

                tbl += "<td class='rep_data'   style='text-align:center;'>";
                string PRINTING_CENTER_NM = ds.Tables[0].Rows[p]["PRINTING_CENTER_NM"].ToString();
                int v_lenght = 0;
                v_lenght = PRINTING_CENTER_NM.Length;
                v_lenght = PRINTING_CENTER_NM.Split(',').Length;
                string abc = "";
                int a1 = 0;
                if (v_lenght > 6)
                {

                    for (int a = 0; a < v_lenght; a++)
                    {
                        if (abc == "")
                        {
                            abc = PRINTING_CENTER_NM.Split(',')[0];
                        }
                        else
                        {
                            if (a1 > 6)
                            {
                                abc = abc + "," + "</br>";
                                a1 = 0;
                            }
                            if (a1 == 0)
                            {
                                abc = abc + PRINTING_CENTER_NM.Split(',')[a];
                            }
                            abc = abc + "," + PRINTING_CENTER_NM.Split(',')[a];
                        }
                        a1++;
                    }
                }
                else
                {
                    abc = PRINTING_CENTER_NM;
                }
                tbl += abc + "</td>";
                tbl += "<td class='rep_data'   style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["UNIT_CODE"].ToString() + "</td>";

                tbl += "<td class='rep_data'  style='text-align:center;'>";
                tbl += ds.Tables[0].Rows[p]["USERNAME"].ToString() + "</td>";

                tbl += "<td class='rep_data' style='text-align:center;' >";
                tbl += ds.Tables[0].Rows[p]["INSERT_DATE"].ToString() + "</td>";

                tbl += "<td class='rep_data'  style='text-align:center;'>";
                if (ds.Tables[0].Rows[p]["CREATION_DATE"].ToString() != "" || ds.Tables[0].Rows[p]["CREATION_DATE"].ToString() != null)
                {
                    tbl += ds.Tables[0].Rows[p]["CREATION_DATE"].ToString() + "</td>";
                }
                else
                {
                    tbl += "-" + "</td>";
                }
                tbl += "<td class='rep_data'  style='text-align:center;'>";
                if (ds.Tables[0].Rows[p]["CANCEL_DATE"].ToString() != "" || ds.Tables[0].Rows[p]["CANCEL_DATE"].ToString() != null)
                {
                    tbl += ds.Tables[0].Rows[p]["CANCEL_DATE"].ToString() + "</td>";
                }
                else
                {
                    tbl += "-" + "</td>";
                }
                rowcounter++;

            }
            tbl += "<tr><td  class='middle31new' style='text-align:center;border-top: thick double #3399FF;border-bottom: thick double #3399FF;' colspan='12'><b>Total Ads : " + sno1.ToString() + "</b></td></tr>";
            tbl += "</table></p>";

            report.InnerHtml = tbl;

            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Pagereservation.xls");
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            report.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.Close();
            Response.End();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }
}