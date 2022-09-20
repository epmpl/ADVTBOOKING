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

using System.IO;

using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Help_Page_view : System.Web.UI.Page
{
    double tot_amt = 0, tot_vol = 0, amount1 = 0, amount2 = 0, amount3 = 0, current_amt = 0, previous_amt = 0, supply = 0, unsold = 0;
    double max1 = 0, max2 = 0, max3 = 0;
    string maximum = "", maximum1 = "", maximum2 = "", maximum3 = "", maximum4 = "", maximum5 = "", year1 = "", bscode1 = "", frmdt1 = "", todate1 = "", frmdt2 = "", todate2 = "", dtfrmat1 = "";
    string max_Len1 = "", max_Len2 = "", max_Len3 = "", max_Len4 = "", max_Len5 = "", max_Len6 = "", pp = "", cc = "", yy = "";
    string axisy_Label = "", chk_zero1 = "", mont = "", tabl = "", parentpage = "";
    Int32 p = 0, q = 0, r = 0, s = 0, w = 0, ii = 0, x = 0, y = 0, z = 0, diff_type1 = 1, act_hgt = 0, act_wid = 0, e = 0, f = 0, g = 0, h = 0, j = 0, k = 0, l = 0, m = 0, a1 = 0, b1 = 0, c1 = 0, d1 = 0, act_int = 0;
    string extra1 = "", extra2 = ""; string differenceofvalue = ""; string helping_value = "";
    DataSet ds_help = new DataSet();
    string prv_img = "", previous = "", current = "", year = "";
    int sno = 0; int function = 1;
    int i = 0; string name1 = "", name2 = "", name3 = "";
    string[] dat = new string[9]; string diff_type = ""; string diff_value = ""; string comp_code = ""; string print_center = "";
    string branch_code = ""; string dateformat = ""; string company_name = ""; string prnt_name = ""; string branch_name = ""; 
    
    protected void Page_Load(object sender, EventArgs e)
    {

        diff_type = Request.QueryString["diff_type"].ToString();
        diff_value = Request.QueryString["diff_value"].ToString();
        comp_code = Request.QueryString["comp_code"].ToString();
        print_center = Request.QueryString["print_center"].ToString();
        branch_code = Request.QueryString["branch_code"].ToString();
        dateformat = Request.QueryString["dateformat"].ToString();
        company_name = Request.QueryString["dateformat"].ToString();
        prnt_name = Request.QueryString["prnt_name"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        extra2 = Request.QueryString["extra2"].ToString();

        showreport();

    }

    private void showreport()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Help_Page obj = new NewAdbooking.Classes.Help_Page();

            ds = obj.mis_health_chk(comp_code, print_center, branch_code, diff_type, dateformat, extra1, extra2, diff_value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Help_page obj = new NewAdbooking.classesoracle.Help_page();

            ds = obj.mis_health_chk(comp_code, print_center, branch_code, diff_type, dateformat, extra1, extra2, diff_value);

        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Help_Page_view), "sa", "alert(\"no record found\"); window.close();", true);
            return;
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";


        //ret_count1 = ret_count1 + "<table id=" + tb1 + " cellpadding=0 cellspacing=0  valign='top' border=1 height='50px;'><tr style='background-color :#ADD8E6;' ><td style='width:10px;'>S.NO.</td><td style='width:50px;'>Difference Type</td><td style='width:25px;'>Company Code</td><td style='width:20px;'>Branch Name
        //    </td><td style='width:50px;'>Receipt Date</td>
        //<td style='width:50px;'>Receipt Number</td>
        //<td style='width:50px;'>Amount</td>
        //<td style='width:50px;'>Agency Name</td><td style='width:20px;'>Cheque No.</td></tr>";

     Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = "S.No";
        
        DataGrid1.Columns.Add(nameColumn0);



        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = "Difference Type";
        nameColumn.DataField = "REMARKS";

        name1 = name1 + "," + "Difference Type";
        name2 = name2 + "," + "REMARKS";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Company Code";
        nameColumn1.DataField = "COMP_CODE";

        name1 = name1 + "," + "Company Code";
        name2 = name2 + "," + "COMP_CODE";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Branch Name";
        nameColumn2.DataField = "BRANCH";

        name1 = name1 + "," + "Branch Name";
        name2 = name2 + "," + "BRANCH";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);


        BoundColumn nameColumn3 = new BoundColumn();
        nameColumn3.HeaderText = "Receipt Date";
        nameColumn3.DataField = "BILL_RECP_DT";

        name1 = name1 + "," + "Receipt Date";
        name2 = name2 + "," + "BILL_RECP_DT";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn3);





        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Receipt Number";
        nameColumn4.DataField = "BILL_RECT_NO";

        name1 = name1 + "," + "Receipt Number";
        name2 = name2 + "," + "BILL_RECT_NO";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);

        BoundColumn name4Column4 = new BoundColumn();
        name4Column4.HeaderText = "Amount";
        name4Column4.DataField = "AMOUNT";

        name1 = name1 + "," + "Amount";
        name2 = name2 + "," + "AMOUNT";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(name4Column4);

        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Agency Name";
        nameColumn6.DataField = "AGNAME";

        name1 = name1 + "," + "Agency Name";
        name2 = name2 + "," + "AGNAME";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        if (diff_type == "9" || diff_type == "11")
        {
            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "Cheque No.";
            nameColumn7.DataField = "CHNO";

            name1 = name1 + "," + "Cheque No.";
            name2 = name2 + "," + "CHNO";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);
        }
        sno++;
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        DataGrid1.RenderControl(hw);
        Response.Write(sw.ToString());
        DataGrid1.ShowHeader = true;
        DataGrid1.ShowFooter = true;
        



        Response.Flush();
        Response.End();


    }
    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        
            double sumamt = 0;


            string sno1 = e.Item.Cells[0].Text;
            string cioidchk = e.Item.Cells[1].Text;

            if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[0].Text = Convert.ToString(sno++);
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
