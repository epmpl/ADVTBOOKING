using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;

public partial class importrateview : System.Web.UI.Page
{
    string chk_excel;
    string name1 = "", name2 = "", name3 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["chk_excel"] != null)
        {
            chk_excel = Request.QueryString["chk_excel"].ToString();
        }
        else
        {
            chk_excel = "1";
        }
        excel();
    }
    private void excel()
    {
        DataSet ds = new DataSet();
        ds = (DataSet)Session["RateCard"];

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        if (chk_excel == "1")
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        }
        else
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        }
        if (chk_excel == "1")
        {
            DataGrid1.AutoGenerateColumns = false;
            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                BoundColumn dc = new BoundColumn();
                dc.DataField = col.ColumnName;
                dc.HeaderText = col.Caption;
                DataGrid1.Columns.Add(dc);
            }
            DataGrid1.DataSource = ds;
            DataGrid1.DataMember = ds.Tables[0].TableName;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.DataBind();
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            Response.Write(sw.ToString().Replace("<br />", "").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
            Response.Flush();
            Response.End();
        }
        else
        {
            DataGrid1.AutoGenerateColumns = false;
            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                BoundColumn dc = new BoundColumn();
                dc.DataField = col.ColumnName;
                dc.HeaderText = col.Caption;
                name1 = name1 + "," + col.ColumnName;
                name2 = name2 + "," + col.ColumnName;
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(dc);
            }
            DataGrid1.DataSource = ds;
            DataGrid1.DataMember = ds.Tables[0].TableName;
            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties = { names, captions, formats };
            QueryToCSV(ds, colProperties);
            Response.Flush();
            Response.End();
        }
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
            //dr.Close();
            //tw.Close();
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
