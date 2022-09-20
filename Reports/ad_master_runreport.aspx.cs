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
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;

public partial class Reports_ad_master_runreport : System.Web.UI.Page
{
    string Destination = "", channel = "", seqno = "", tablename = "", tablecol = "", tablefilter = "", order = "";
    string extra2 = "", extra3 = "", extra4 = "", extra5 = "", extra6 = "", extra7 = "", extra8 = "", extra9 = "", extra10 = "";
    string channelname = "", reportname = "";
    string name1 = "", name2 = "", name3 = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script> window.parent.location=\" login.aspx\";</script>)");
            return;
        }

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddencompname.Value = Session["comp_name"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenusername.Value = Session["username"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddenunit.Value = Session["center"].ToString();

        Destination = Request.QueryString["Destination"].ToString();
        channel = Request.QueryString["Channel"].ToString();
        channelname = Request.QueryString["channel_name"].ToString();
        reportname = Request.QueryString["report_name"].ToString();
        seqno = Request.QueryString["seq_no"].ToString();
        tablename = Request.QueryString["table_name"].ToString();
        tablecol = Request.QueryString["table_col"].ToString();
        tablefilter = Request.QueryString["table_filter"].ToString();
        order = Request.QueryString["Order"].ToString();
        extra2 = Request.QueryString["ext2"].ToString();
        extra3 = Request.QueryString["ext3"].ToString();
        extra4 = Request.QueryString["ext4"].ToString();
        extra5 = Request.QueryString["ext5"].ToString();
        extra6 = Request.QueryString["ext6"].ToString();
        extra7 = Request.QueryString["ext7"].ToString();
        extra8 = Request.QueryString["ext8"].ToString();
        extra9 = Request.QueryString["ext9"].ToString();
        extra10 = Request.QueryString["ext10"].ToString();

        DataSet ds1 = new DataSet();

        if (!Page.IsPostBack)
        {
            if (Destination == "1")
            {
                ShowReport();
            }
            else if (Destination == "2")
            {
                showreportexcel();
            }
            else if (Destination == "3")
            {
                CSV();
            }
        }

    }


    private void ShowReport()
    {
        string tbl1 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
            ds = pub.masterreport(hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
            ds = pub11.masterreport(hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_get_table_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_ad_master_runreport), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }

        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            string compname1 = Session["comp_name"].ToString();
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            tbl1 = tbl1 + "<tr><td>";
            tbl1 = tbl1 + "<table style='width:100%' >";
            tbl1 = tbl1 + "<tr><td></td><td align='center' style='height: 20px;padding-right:130px' colspan='2' class='headingc' > ";
            tbl1 = tbl1 + compname1;
            tbl1 = tbl1 + "</td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' colspan='2' class ='headingp1'><b>";
            tbl1 = tbl1 + channelname;
            tbl1 = tbl1 + "</b></td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' colspan='2' class ='headingp1'><b>";
            tbl1 = tbl1 + reportname;
            tbl1 = tbl1 + "</b></td></tr>";

            tbl1 = tbl1 + "<tr><td style='width: 69px'> </td></tr></table>";

            //tbl1 = tbl1 + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
            //tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;' colspan='4'><b>Run Date:</b>" + rundate + "</td></tr>";
            //tbl1 = tbl1 + "</table>";

            ////////////////////for column names//////////////////////////
            tbl1 = tbl1 + "<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
            tbl1 = tbl1 + "<tr>";
            for (int i = 0; i < (ds.Tables[0].Columns.Count); i++)
            {
                tbl1 = tbl1 + "<td width='5%' class='middle31new' align='left'><b>" + ds.Tables[0].Columns[i].ToString() + "</b>&nbsp;&nbsp;&nbsp;";
                tbl1 = tbl1 + "</td>";

            }
            tbl1 = tbl1 + "</tr>";
            //==================================================for values=========================================================================================================================
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tbl1 = tbl1 + "<tr>";
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    tbl1 = tbl1 + "<td width='5%' class='rep_data' align='left'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "&nbsp;&nbsp;&nbsp;</td>";
                }
                tblgrid.InnerHtml += tbl1;
                tbl1 = "";
            }
            tbl1 = tbl1 + "</tr>";
            tbl1 = tbl1 + "</table>";
            tblgrid.InnerHtml += tbl1;
            tbl1 = "";
        }
    }



    private void showreportexcel()
    {
        string tbl1 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
            ds = pub.masterreport(hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
            ds = pub11.masterreport(hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_get_table_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_ad_master_runreport), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            string compname1 = Session["comp_name"].ToString();
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top'>";
            int col1 = ds.Tables[0].Columns.Count / 2;

            tbl1 = tbl1 + "<tr><td>";
            tbl1 = tbl1 + "<table style='width:100%' >";
            tbl1 = tbl1 + "<tr><td></td><td align='center' style='height: 20px;padding-right:130px' colspan=" + col1 + " class='headingc' > ";
            tbl1 = tbl1 + compname1;
            tbl1 = tbl1 + "</td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' colspan=" + col1 + " class ='headingp1'><b>";
            tbl1 = tbl1 + channelname;
            tbl1 = tbl1 + "</b></td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' class ='headingp1' ColSpan=" + col1 + "><b>";
            tbl1 = tbl1 + reportname;
            tbl1 = tbl1 + "</b></td></tr></table>";

            //tbl1 = tbl1 + "<tr><td style='width: 69px'> </td></tr></table>";
            ////////////////////for column names//////////////////////////
            tbl1 = tbl1 + "<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='1'>";
            tbl1 = tbl1 + "<tr>";
            for (int i = 0; i < (ds.Tables[0].Columns.Count); i++)
            {
                tbl1 = tbl1 + "<td class='middle31new' align='left'><b>" + ds.Tables[0].Columns[i].ToString() + "</b>";
                tbl1 = tbl1 + "</td>";

            }
            tbl1 = tbl1 + "</tr>";
            //==================================================for values=========================================================================================================================
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tbl1 = tbl1 + "<tr>";
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    tbl1 = tbl1 + "<td class='rep_data' align='left'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                }

            }
            tbl1 = tbl1 + "</tr>";
            tbl1 = tbl1 + "</table>";
            tblgrid.InnerHtml = tbl1;
        }
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }



    private void CSV()
    {
        string tbl1 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.ad_masterreport pub = new NewAdbooking.Report.Classes.ad_masterreport();
            ds = pub.masterreport(hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.ad_masterreport pub11 = new NewAdbooking.Report.classesoracle.ad_masterreport();
            ds = pub11.masterreport(hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "cir_get_table_report";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hiddencompcode.Value, hiddenunit.Value, channel, seqno, tablename, tablecol, tablefilter, order, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_ad_master_runreport), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                name1 = name1 + "," + ds.Tables[0].Columns[j].Caption.ToString();
                name2 = name2 + "," + ds.Tables[0].Columns[j].Caption.ToString();
                name3 = name3 + "," + "G";
            }
            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties = { names, captions, formats };

            QueryToCSV(ds, colProperties);


        }

        Response.Flush();
        Response.End();

    }


    private void QueryToCSV(DataSet dr, string[][] colProperties)
    {
        if (colProperties.Length > 0)
        {
            int counter;
            Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
            for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
            {
                counter = 0;
                Response.Write("\"");
                foreach (String column in colProperties[0])
                {
                    //dr.Tables[0].Rows[i].
                    Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                    if (counter < colProperties[0].Length - 1)
                    {
                        Response.Write("\",\"");
                    }
                    counter += 1;
                }
                Response.Write("\"\n");
            }

        }
    }


    private int getcolindex(DataSet ds, string col)
    {
        int i;
        for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
        {
            if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
            {
                goto td5;

            }
        }
    td5:
        return i;
    }




}