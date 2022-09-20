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

public partial class Reports_bookingmaterialdata_rpt : System.Web.UI.Page
{

    StringBuilder TBL = new StringBuilder();
    StringBuilder head = new StringBuilder();
    int TotalColSpan = 0, ColSpan1 = 0, ColSpan2 = 0;
    double col_sp = 0;
    DataSet ds;
    //string destination = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null || Session["compcode"] == "null")
        {
            Response.Redirect("login.aspx");
        }
        if (Session["compcode"] != null)
        {
            HDN_dateformat.Value = Session["dateformat"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
            //HDNunit = Session["center"].ToString();
            dateformat.Value = Session["dateformat"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hdncomname.Value = Session["comp_name"].ToString();
            //  dateformat = hiddendateformat.Value;
        }

        ds = (DataSet)Session["statusad"];
        string prm = Session["prm_statusad"].ToString();
        string[] prm_Array = new string[39];
        prm_Array = prm.Split('~');

        if (!Page.IsPostBack)
        {
            if (prm == "destination~csv")
            {
                CsvReportView();
            }
            else
            {
                showreportexcelall();
            }
        }

    }


    public void showreportexcelall()
    {

        TotalColSpan = (ds.Tables[0].Columns.Count) - 2;
        col_sp = TotalColSpan / 3;

        if (TotalColSpan % 2 == 0)
        {
            ColSpan1 = TotalColSpan / 2;
            ColSpan2 = ColSpan1;
        }
        else
        {
            ColSpan1 = (TotalColSpan - 1) / 2;
            ColSpan2 = ColSpan1 + 1;
        }
        TBL = new StringBuilder();

        TBL.Append("<table width='100%'cellpadding='0'cellsapcing='0' border='1' vertical-align:top;>");
        TBL.Append("<tr>");
        for (int t = 0; t < ds.Tables[0].Columns.Count; t++)
        {
            TBL.Append("<td style='width:15%;text-align:center;font-size:15px;font-family:Arial, Helvetica, sans-serif;border-left:0px solid black; border-bottom:1px solid black;border-top:1px solid black;border-right:1px solid black;vertical-align:middle;'><b>" + ds.Tables[0].Columns[t].ToString().ToUpper() + "</b></td>");
        }
        TBL.Append("</tr>");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TBL.Append("<tr  style='height:20px;'>");
            // TBL.Append("<td style='text-align:left;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black; border-bottom:1px solid black;border-right:1px solid black;padding-left:2px;'><b>" + "Total Days" + "</b></td>");
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                if (ds.Tables[0].Rows[i].ItemArray[j].ToString() != "")
                {
                    TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:1px solid black;padding-right:2px;'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>");
                }
                else
                {
                    TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:1px solid black;padding-right:2px;'>" + "&nbsp;" + "</td>");
                }
            }
            TBL.Append("</tr>");

        }

        TBL.Append("</table>");
        report.InnerHtml = TBL.ToString();
        //view.InnerHtml = TBL.ToString();

        //    destination == views;
        string views = "exc";
        if (views == "exc")
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            report.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.Close();
            Response.End();
        }
    }



    void CsvReportView()
    {
        DataTable dt = ds.Tables[0];
        StringBuilder sb = new StringBuilder();
        string[] columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
        sb.AppendLine(string.Join("~", columnNames));
        foreach (DataRow row in dt.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString().Replace("~", " ")).ToArray();
            sb.AppendLine(string.Join("~", fields));
            //output.WriteLine(sb.ToString());
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        string file = "materialdata" + "_" + DateTime.Now.ToString("yyyy_MM_dd") + ".csv";
        Response.AppendHeader("content-disposition", string.Format("attachment; filename=\"{0}\"", file));
        Response.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }



}
