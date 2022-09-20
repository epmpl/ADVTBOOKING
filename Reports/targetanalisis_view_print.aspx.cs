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

public partial class Reports_targetanalisis_view_print : System.Web.UI.Page
{
    string compcode = "", userid = "", dateformat = "", datefrom = "", todate = "", publication = "", edition = "", adtype = "", uom = "", paymade = "", extra1 = "", extra2 = "", basedon = "";
    string destination = "", chkaccess = "", agencycode, currentdate = "", username = "";
    int pgn = 1;
    int rowcounter = 0;
    int maxlimit = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {

            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        compcode = Request.QueryString["compcode"].ToString();
        userid = Request.QueryString["userid"].ToString();
        dateformat = Request.QueryString["dateformat"].ToString();
        datefrom = Request.QueryString["datefrom"].ToString();
        todate = Request.QueryString["todate"].ToString();
        publication = Request.QueryString["publication"].ToString();
        edition = Request.QueryString["edition"].ToString();
        adtype = Request.QueryString["adtype"].ToString();
        uom = Request.QueryString["uom"].ToString();
        paymade = Request.QueryString["paymade"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        extra2 = Request.QueryString["extra2"].ToString();
        basedon = Request.QueryString["basedon"].ToString();
        destination = Request.QueryString["destination"].ToString();
        agencycode = Request.QueryString["agencycode"].ToString();
        chkaccess = Request.QueryString["chkaccess"].ToString();

        username = Session["username"].ToString().ToUpper();
        currentdate = System.DateTime.Now.ToString();
        print_screen();
    }
    public void print_screen()
    {
        DataSet ds = new DataSet();
        if (basedon == "M")
        {

            if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.targetanalisis exe = new NewAdbooking.Report.Classes.targetanalisis();
                ds = exe.getbussinessreport(compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, "", datefrom, todate, dateformat, userid, chkaccess, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
            {

                NewAdbooking.Report.classesoracle.targetanalisis exe = new NewAdbooking.Report.classesoracle.targetanalisis();
                ds = exe.getbussinessreport(compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, "", datefrom, todate, dateformat, userid, chkaccess, extra1, extra2);
            }
            else
            {
                string procedureName = "ad_rep_bussiness_ad_rep_bussiness_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, "", datefrom, todate, dateformat, userid, chkaccess, extra1, extra2 };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        }

        else if (basedon == "V")
        {

            if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.targetanalisis exe = new NewAdbooking.Report.Classes.targetanalisis();
                ds = exe.getbussinessamtreport(compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, "", datefrom, todate, dateformat, userid, chkaccess, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["connectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.targetanalisis exe = new NewAdbooking.Report.classesoracle.targetanalisis();
                ds = exe.getbussinessamtreport(compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, "", datefrom, todate, dateformat, userid, chkaccess, extra1, extra2);
            }
            else
            {
                string procedureName = "ad_rep_bussiness_ad_rep_bussiness_amt_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { compcode, "", "", publication, edition, agencycode, "", "", adtype, uom, "", datefrom, todate, dateformat, userid, chkaccess, extra1, extra2 };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        }


        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }

        else
        {
            int rcount = ds.Tables[0].Rows.Count;
            int sno = 1;

            string TBL = "";
            string header = creatheader(ds);
            TBL += header;
                      


            for (int p = 0; p < rcount; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    TBL += "</table>";
                    TBL += "<p style='PAGE-BREAK-BEFORE: always'>";
                    string newheader = creatheader(ds);
                    TBL += newheader;
                }

               

                TBL += ("<tr style='height:30px;'>");
                TBL += ("<td class='rep_data'align='left'>" + sno.ToString() + "</td>");
                for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[i].Caption == "Exec_name" || ds.Tables[0].Columns[i].Caption == "Uom_Name" || ds.Tables[0].Columns[i].Caption == "Agency_Name" || ds.Tables[0].Columns[i].Caption == "Supp_Name")
                    {
                        TBL += ("<td class='rep_data'align='left' >" + ds.Tables[0].Rows[p].ItemArray[i].ToString() + "</td>");
                    }
                    else
                    {
                        TBL += ("<td class='rep_data'align='right' >" + ds.Tables[0].Rows[p].ItemArray[i].ToString() + "</td>");
                    }
                }
                if (ds.Tables[1].Rows.Count == 1)
                {
                    TBL += ("<td class='rep_data'align='right'>0</td>");
                }
                else
                {

                    if (p < ds.Tables[1].Rows.Count)
                    {
                        TBL += ("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[p]["Target"].ToString() + "</td>");
                    }
                    else
                    {
                        TBL += ("<td class='rep_data'align='right'>0</td>");
                    }
                 
                }
                TBL += ("</tr>");
                sno++;
                rowcounter++;
            }



            TBL += ("</table>");

            tblgrid.InnerHtml = TBL.ToString();
          


        }

    }

    public string creatheader(DataSet ds)
    {
        string Header = "";

        Header += ("<table width='100%' cellpadding='0' cellsapcing='0' border='0' stytle='align:top;'>");


        Header += ("<tr><td  align='center' colspan='12' style='font-family :verdana;font-size :20px;font-weight :bold;color :#0a4a83; ;' ><b>" + " Target Analysis Report" + "</b></td></tr>");
        Header += ("<tr ><td class='headrep111' align='center'colspan='12' ><b>FROM DATE &nbsp;:&nbsp;" + datefrom + "</b><b>&nbsp;&nbsp;TO DATE &nbsp;:&nbsp; " + todate + "</b></td>");
        Header += ("</tr>");

        Header += ("</tr>");
        Header += ("<tr ><td class='headrep111' align='left'colspan='6' ><b>RUN DATE & TIME &nbsp;:&nbsp; " + currentdate + "</b></td>");
        Header += ("<td class='headrep111' align='right'colspan='6' ><b>PREPARED BY &nbsp;:&nbsp;" + username + "</b></td>");
        Header += ("</tr>");


        Header += ("</table>");


        Header += ("<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>");
        Header += ("<tr style='height:25px;'>");
        Header += ("<td class='rep_datatotal_vouchdata'>S.No.</td>");

        for (int c = 1; c < ds.Tables[0].Columns.Count; c++)
        {
            if (ds.Tables[0].Columns[c].Caption == "Exec_name" || ds.Tables[0].Columns[c].Caption == "Uom_Name" || ds.Tables[0].Columns[c].Caption == "Agency_Name" || ds.Tables[0].Columns[c].Caption == "Supp_Name")
            {
                Header += ("<td class='rep_datatotal_vouchdata'  align='left'>" + ds.Tables[0].Columns[c].ToString() + "</td>");
            }
            else
            {
                Header += ("<td class='rep_datatotal_vouchdata'  align='right'>" + ds.Tables[0].Columns[c].ToString() + "</td>");
            }
        }

        Header += ("<td class='rep_datatotal_vouchdata' align='right'>" + ds.Tables[1].Columns["Target"].ToString() + "</td>");
      
       

        Header += ("</tr>");



        pgn = pgn + 1;
        return Header;
    }
}
