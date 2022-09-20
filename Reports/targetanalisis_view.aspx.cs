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
using System.Text;
using System.IO;
using iTextSharp.text.pdf;

public partial class Reports_targetanalisis_view : System.Web.UI.Page
{

    string compcode = "", userid = "", dateformat = "", datefrom = "", todate = "", publication = "", edition = "", adtype = "", uom = "", paymade = "", extra1 = "", extra2 = "", basedon = "";
    string destination = "", chkaccess = "", agencycode, currentdate = "", username = "";
    int pgn = 1;
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
            if (destination == "1")
            {
                showreport();
            }
            else if (destination == "0")
            {
                showreport();
            }
            else if (destination == "2")
            {
                showreportexcel();
            }
            else if (destination == "3")
            {
                showreportpdf();
            }


        }

    }

    public void showreport()
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
                if (publication == "0")
                    publication = "";
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
            StringBuilder TBL = new StringBuilder();
            int sno = 1;
            TBL.Append("<table width='100%' cellpadding='0' cellsapcing='0' border='0' stytle='align:top;'>");
            TBL.Append("<tr><td  align='center' colspan='12' style='font-family :verdana;font-size :20px;font-weight :bold;color :#0a4a83; ;' ><b>" + " Target Analysis Report" + "</b></td></tr>");
            TBL.Append("<tr ><td class='headrep111' align='center'colspan='12' ><b>FROM DATE &nbsp;:&nbsp;" + datefrom + "</b><b>&nbsp;&nbsp;TO DATE &nbsp;:&nbsp; " + todate + "</b></td>");
            TBL.Append("</tr>");
            TBL.Append("</tr>");
            TBL.Append("<tr ><td class='headrep111' align='left'colspan='6' ><b>RUN DATE & TIME &nbsp;:&nbsp; " + currentdate + "</b></td>");
            TBL.Append("<td class='headrep111' align='right'colspan='6' ><b>PREPARED BY &nbsp;:&nbsp;" + username + "</b></td>");
            TBL.Append("</tr>");


            TBL.Append("</table>");


            TBL.Append("<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>");
            TBL.Append("<tr style='height:25px;'>");
            TBL.Append("<td class='rep_datatotal_vouchdata'>S.No.</td>");

            for (int c = 1; c < ds.Tables[0].Columns.Count; c++)
            {
                if (ds.Tables[0].Columns[c].Caption == "Exec_name" || ds.Tables[0].Columns[c].Caption == "Uom_Name" || ds.Tables[0].Columns[c].Caption == "Agency_Name" || ds.Tables[0].Columns[c].Caption == "Supp_Name")
                {
                    TBL.Append("<td class='rep_datatotal_vouchdata'  align='left'>" + ds.Tables[0].Columns[c].ToString() + "</td>");
                }
                else
                {
                    TBL.Append("<td class='rep_datatotal_vouchdata'  align='right'>" + ds.Tables[0].Columns[c].ToString() + "</td>");
                }
            }

            TBL.Append("<td class='rep_datatotal_vouchdata' align='right'>" + ds.Tables[1].Columns["Target"].ToString() + "</td>");
           

            TBL.Append("</tr>");
            for (int p=0; p  < rcount; p++)
            {
                sno = p;
                sno++;

                TBL.Append("<tr style='height:30px;'>");
                TBL.Append("<td class='rep_data'align='left'>" + sno.ToString() + "</td>");
                for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[i].Caption == "Exec_name" || ds.Tables[0].Columns[i].Caption == "Uom_Name" || ds.Tables[0].Columns[i].Caption == "Agency_Name" || ds.Tables[0].Columns[i].Caption == "Supp_Name")
                    {
                        TBL.Append("<td class='rep_data'align='left' >" + ds.Tables[0].Rows[p].ItemArray[i].ToString() + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td class='rep_data'align='right' >" + ds.Tables[0].Rows[p].ItemArray[i].ToString() + "</td>");
                    }
                }
                if (ds.Tables[1].Rows.Count == 1)
                {
                    TBL.Append("<td class='rep_data'align='right'>0</td>");
                }
                else
                {

                    if (p < ds.Tables[1].Rows.Count)
                    {
                        TBL.Append("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[p]["Target"].ToString() + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td class='rep_data'align='right'>0</td>");
                    }
                   
                }

                TBL.Append("</tr>");
            }
           
           
            TBL.Append("</table>");
            view.InnerHtml = TBL.ToString();
            btnprint.Attributes.Add("onclick", "javascript:return window.open('targetanalisis_view_print.aspx?page=" + jj + "&compcode=" + compcode + "&userid=" + userid + "&dateformat=" + dateformat + "&datefrom=" + datefrom + "&todate=" + todate + "&publication=" + publication + "&edition=" + edition + "&adtype=" + adtype + "&uom=" + uom + "&paymade=" + paymade + "&extra1=" + extra1 + "&extra2=" + extra2 + "&basedon=" + basedon + "&destination=" + destination + "&agencycode=" + agencycode + "&chkaccess=" + chkaccess + " ')");


        }

    }


    public void showreportexcel()
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
                if (publication == "0")
                    publication = "";
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
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");


            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            int rcount = ds.Tables[0].Rows.Count;
            StringBuilder TBL = new StringBuilder();
            int sno = 1;

            TBL.Append("<table width='100%' cellpadding='0' cellsapcing='0' border='0' stytle='align:top;'>");


            TBL.Append("<tr><td  align='center' colspan='12' style='font-family :verdana;font-size :20px;font-weight :bold;color :#0a4a83; ;' ><b>" + " Target Analysis Report " + "</b></td></tr>");
            TBL.Append("<tr ><td class='headrep111' align='center'colspan='12' ><b>FROM DATE &nbsp;:&nbsp;" + datefrom + "</b><b>&nbsp;&nbsp;TO DATE &nbsp;:&nbsp; " + todate + "</b></td>");
            TBL.Append("</tr>");
            TBL.Append("</tr>");
            TBL.Append("<tr ><td class='headrep111' align='left'colspan='6' ><b>RUN DATE & TIME &nbsp;:&nbsp; " + currentdate + "</b></td>");
            TBL.Append("<td class='headrep111' align='right'colspan='6' ><b>PREPARED BY &nbsp;:&nbsp;" + username + "</b></td>");
            TBL.Append("</tr>");


            TBL.Append("</table>");


            TBL.Append("<table width='100%' cellpadding='0' cellsapcing='0' border='1' style='vertical-align:top;'>");
            TBL.Append("<tr style='height:25px;'>");
            TBL.Append("<td class='rep_datatotal_vouchdata'>S.No.</td>");

            for (int c = 1; c < ds.Tables[0].Columns.Count; c++)
            {
                if (ds.Tables[0].Columns[c].Caption == "Exec_name" || ds.Tables[0].Columns[c].Caption == "Uom_Name" || ds.Tables[0].Columns[c].Caption == "Agency_Name" || ds.Tables[0].Columns[c].Caption == "Supp_Name")
                {
                    TBL.Append("<td class='rep_datatotal_vouchdata'  align='left'>" + ds.Tables[0].Columns[c].ToString() + "</td>");
                }
                else
                {
                    TBL.Append("<td class='rep_datatotal_vouchdata'  align='right'>" + ds.Tables[0].Columns[c].ToString() + "</td>");
                }
            }

         
            TBL.Append("<td class='rep_datatotal_vouchdata' align='right'>" + ds.Tables[1].Columns["Target"].ToString() + "</td>");
            
            TBL.Append("</tr>");
            for (int r = 0; r < rcount; r++)
            {
                sno = r;
                sno++;

                TBL.Append("<tr style='height:30px;'>");
                TBL.Append("<td class='rep_data'align='left'>" + sno.ToString() + "</td>");
                for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[i].Caption == "Exec_name" || ds.Tables[0].Columns[i].Caption == "Uom_Name" || ds.Tables[0].Columns[i].Caption == "Agency_Name" || ds.Tables[0].Columns[i].Caption == "Supp_Name")
                    {
                        TBL.Append("<td class='rep_data'align='left' >" + ds.Tables[0].Rows[r].ItemArray[i].ToString() + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td class='rep_data'align='right' >" + ds.Tables[0].Rows[r].ItemArray[i].ToString() + "</td>");
                    }
                }
                if (ds.Tables[1].Rows.Count == 1)
                {
                    TBL.Append("<td class='rep_data'align='right'>0</td>");
                }
                else
                {
                    if (r < ds.Tables[1].Rows.Count)
                    {
                        TBL.Append("<td class='rep_data'align='right'>" + ds.Tables[1].Rows[p]["Target"].ToString() + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td class='rep_data'align='right'>0</td>");
                    }
                }
                TBL.Append("</tr>");
            }



            TBL.Append("</table>");

            view.InnerHtml = TBL.ToString();
            hw.WriteBreak();
            view.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }

    public void showreportpdf()
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
            string pdfName = "";
            int rcount = ds.Tables[0].Rows.Count;
            double[] array1 = new double[ds.Tables[0].Columns.Count - 1];
            int arrlenght = ds.Tables[0].Columns.Count - 1;
            int sno = 1;
            int pdfpage = 0;

            pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
            string name = Server.MapPath("") + "//" + pdfName;

            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
            PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD);

            try
            {

                PdfPTable tbl = new PdfPTable(1);
                tbl.DefaultCell.BorderWidth = 0;
                tbl.WidthPercentage = 100;
                tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl.addCell(new iTextSharp.text.Phrase(" Target Analysis Report ", font9));
                document.Add(tbl);

                PdfPTable tbl1 = new PdfPTable(1);
                tbl1.DefaultCell.BorderWidth = 0;
                tbl1.WidthPercentage = 100;
                tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl1.addCell(new iTextSharp.text.Phrase("FROM DATE :" + datefrom + "TO DATE :" + todate, font9));
                document.Add(tbl1);

                PdfPTable tbl2 = new PdfPTable(1);
                tbl2.DefaultCell.BorderWidth = 0;
                tbl2.WidthPercentage = 100;
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl2.addCell(new iTextSharp.text.Phrase("RUN DATE & TIME  :" + currentdate, font9));
                tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                tbl2.addCell(new iTextSharp.text.Phrase("PREPARED BY  :" + username, font9));
                document.Add(tbl2);


                pdfpage = ds.Tables[0].Columns.Count ;

                PdfPTable tbl4 = new PdfPTable(pdfpage);
                tbl4.DefaultCell.BorderWidth = 0;
                tbl4.WidthPercentage = 100;
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase("S.NO", font8));

                iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
                document.Add(p1);

                for (int c = 1; c < ds.Tables[0].Columns.Count; c++)
                {
                    if (ds.Tables[0].Columns[c].Caption == "Exec_name" || ds.Tables[0].Columns[c].Caption == "Uom_Name" || ds.Tables[0].Columns[c].Caption == "Agency_Name" || ds.Tables[0].Columns[c].Caption == "Supp_Name")
                    {
                        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Columns[c].ToString(), font8));
                    }
                    else
                    {
                        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Columns[c].ToString(), font8));
                    }
                }

               
                    tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Columns["Target"].ToString(), font8));
               

                


                for (int r = 0; r < rcount; r++)
                {
                    sno = r;
                    sno++;
                    tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    tbl4.addCell(new iTextSharp.text.Phrase(sno.ToString(), font8));
                    for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].Caption == "Exec_name" || ds.Tables[0].Columns[i].Caption == "Uom_Name" || ds.Tables[0].Columns[i].Caption == "Agency_Name" || ds.Tables[0].Columns[i].Caption == "Supp_Name")
                        {
                            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[r].ItemArray[i].ToString(), font8));
                        }
                        else
                        {
                            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[r].ItemArray[i].ToString(), font8));
                        }
                    }

                    if (ds.Tables[1].Rows.Count == 1)
                    {
                        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                    }
                    else
                    {
                        if (r < ds.Tables[1].Rows.Count)
                        {
                            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[r]["Target"].ToString(), font8));
                        }
                        else
                        {
                            tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl4.addCell(new iTextSharp.text.Phrase("0", font8));
                        }
                    }

                   

                }
                document.Add(tbl4);
                document.Close();
                Response.Redirect(pdfName, false);

            }




            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
            }
        }
    }
}
