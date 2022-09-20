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

public partial class issuewiseprint : System.Web.UI.Page
{
    double[] value;
    double[] value1;
    double[] value2;
    double[] value_main;
    double temp_tot = 0;
    double var1 = 0;
    double vared1 = 0;
    double temp_tot35 = 0;
    double temp_tot34 = 0;
    double temp_tot36 = 0;
    double varmained1 = 0;
    double varpub1 = 0;
    int s = 0;
    int mn = 0;
    int n = 0;
    double totcount = 0;
    string ratio_name = "";
    int maxlimit = 20;
    string extra2 = "";
    int a = 0;
    string fromdate = "", dateto = "", destination = "", pubcentcode = "", edition = "", editionname = "", pubcentname = "";
    string day = "", month = "", year = "", Run_Date = "",ratio_type="";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("../login.aspx");
        }

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[33].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        ScriptManager.RegisterClientScriptBlock(this, typeof(issuewiseprint), "sa", "window.print();", true);

        ds = (DataSet)Session["issueprintcent"];
        string prm = Session["prm_issueprintcent_print"].ToString();
        string[] prm_Array = new string[17];
        prm_Array = prm.Split('~');

        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdate = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcentcode = prm_Array[7]; //Request.QueryString["pubcentcode"].ToString();
        edition = prm_Array[9]; //Request.QueryString["edition"].ToString();
        editionname = prm_Array[11]; //Request.QueryString["editionname"].ToString();
        pubcentname = prm_Array[13]; //Request.QueryString["pubcentname"].ToString();
        ratio_type = prm_Array[15];
        extra2 = prm_Array[19];
        ratio_name = prm_Array[21];
                hiddendateformat.Value = Session["dateformat"].ToString();
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();

        lblFDate.Text = fromdate;
        lblTDate.Text = dateto;

        DataSet dsx = new DataSet();
        dsx.ReadXml(Server.MapPath("XML/RPt_Daily_listing.xml"));

        lblHeading.Text = dsx.Tables[3].Rows[0].ItemArray[2].ToString();
        lblFromDate.Text = dsx.Tables[1].Rows[0].ItemArray[1].ToString();
        lblToDate.Text = dsx.Tables[1].Rows[0].ItemArray[2].ToString();
        lblpubcent.Text = dsx.Tables[3].Rows[0].ItemArray[3].ToString();
        lbledition.Text = dsx.Tables[3].Rows[0].ItemArray[4].ToString();
        lblRunningDate.Text = dsx.Tables[1].Rows[0].ItemArray[6].ToString();
        //if (pubcentcode == "0")
        //    lbpubcent.Text = "All";
        //else
        //    lbpubcent.Text = "" + pubcentname.ToString();

        //if (edition == "0")
        //    lbedition.Text = "All";
        //else
        //    lbedition.Text = editionname.ToString();

        //if (ratio_type == "C")
        //    lbratiotyp.Text = "Circulation Copy";
        //else
        //    lbratiotyp.Text = "Edition Ratio";
          

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {
            DateTime dt = System.DateTime.Now;
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            Run_Date = day + "/" + month + "/" + year;

        }
        else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
        {
            DateTime dt = System.DateTime.Now;
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            Run_Date = month + "/" + day + "/" + year;

        }
        else if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
        {
            DateTime dt = System.DateTime.Now;
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            Run_Date = year + "/" + month + "/" + day;

        }
        lblRundate.Text = Run_Date;

        onscreen(hiddencomcode.Value, fromdate, dateto, pubcentcode, edition, hiddendateformat.Value, hiddenuserid.Value);
      

    }
    public string chk_null(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal == "0.00" || str_decimal == "0.0" || str_decimal == "0")
        {
            final_decimal = "0.00";
        }
        else if (str_decimal.IndexOf(".") > -1)
        {

            double dd = System.Math.Round(Convert.ToDouble(str_decimal), 2);
            string[] oo = dd.ToString().Split('.');
            if (oo.Length == 1)
                final_decimal = dd.ToString() + ".00";
            else if (oo[1].Length == 1)
                final_decimal = dd.ToString() + "0";
            else
                final_decimal = dd.ToString();
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = "0.00";
        }
        return final_decimal;
    }
    private void onscreen(string compcode, string fromdate, string dateto, string pubcentcode, string edition, string dateformat, string useid)
    {
        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Record Not Found")
        {
            return;
        }
        string code_find = ds.Tables[0].Rows[0]["MAIN_EDTN_NAME"].ToString();
        //DataSet ds = new DataSet();

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.issuereport(Session["compcode"].ToString(), fromdate, dateto, pubcentcode, edition, dateformat, Session["userid"].ToString());
        //}
        cmpnyname.Text = ds.Tables[1].Rows[0]["companyname"].ToString();
        int controw = ds.Tables[0].Rows.Count;
        int contcol = ds.Tables[0].Columns.Count;

        int cont = ds.Tables[0].Rows.Count;

        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        string tbl = "";
        ///////////////////////////////////////////////////
         if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
                tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
         //   tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table></P>";
                    if (p == pagecount - 1)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl = tbl + "</table></P>";
                        if (p == pagecount - 1)
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1)
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }

                //tbl += "</table>";
                //  tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                tbl += "<tr valign='top'>";
                tbl += "<td class='middle111' align='right' colspan='22'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                int j = 4;
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + Run_Date + "</td></tr>";
                string rt = "";
                if (ratio_name == "" || ratio_name == "0")
                {
                    rt = "All";

                }
                else
                {
                    rt = ratio_name;
                }
                string pub = "";
                if (pubcentname == "Select Printing Center" || pubcentname == "0")
                {
                    pub = "All";

                }
                else
                {
                    pub = pubcentname;
                }
                string ed = "";
                if (edition == "-Select Edition-" || edition == "0")
                {
                    ed = "All";

                }
                else
                {
                    ed = edition;
                }
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Ratio Type:</b>" + rt + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + pub + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + ed + "</td></tr>";
                tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>";
                tbl = tbl + ("<td class='middle31new'  align='left'>");
                tbl = tbl + ("<tr><td class='middle31new'>S.No.</td>");
                //tbl = tbl + ("<td class='middle31new'  align='left'>");
                tbl = tbl + ("<td class='middle31new'>Edition</td>");
                //tbl = tbl + ("<td class='middle31new'  align='left'>");
                tbl = tbl + ("<td class='middle31new'>Printing Center</td>");
                if (extra2 == "W")
                {
                    for (int i = 4; i < ds.Tables[0].Columns.Count - 2; i++)
                    {
                        if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                        {

                            tbl = tbl + ("<td class='middle31new' align='center' >");

                            string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                            //tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                            //if (i % 3 == 0)

                            if (i == j + 1)
                            {

                                tbl = tbl + (str[1].ToString());
                                j = j + 3;
                            }
                            else
                            {
                            }
                            //tbl = tbl + (str[1].ToString());


                            tbl = tbl + "</br>";
                            if (str[0].ToString() == "D")
                            {
                                tbl = tbl + "Display" + "&nbsp;&nbsp;";
                            }
                            if (str[0].ToString() == "L")
                            {
                                tbl = tbl + "Lineage" + "&nbsp;&nbsp;";
                            }
                            if (str[0].ToString() == "A")
                            {
                                tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                            }
                            tbl = tbl + "</td>";

                        }
                        else
                        {
                            tbl = tbl + ("<td class='middle31new' align='right'>");
                            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                        }


                    }


                    tbl = tbl + ("</tr>");
                }
                else if (extra2 == "O")
                {
                    for (int i = 4; i < ds.Tables[0].Columns.Count - 2; i++)
                    {
                        if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                        {

                            tbl = tbl + ("<td class='middle31new' align='right' >");

                            string[] str = ds.Tables[0].Columns[i].ToString().Split('#');


                            tbl = tbl + (str[1].ToString());
                            tbl = tbl + "</br>";
                            if (str[0].ToString() == "A")
                            {
                                tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                                tbl = tbl + "</td>";

                            }
                        }
                        else
                        {
                            tbl = tbl + ("<td class='middle31new' align='right'>");
                            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                        }

                    }

                    tbl = tbl + ("</tr>");
                }
                //int j = 4;
                //tbl = tbl + ("<tr><td class='middle31new'>S.No.</td>");
                //if (extra2 == "W")
                //{
                //    for (int i = 2; i < ds.Tables[0].Columns.Count - 2; i++)
                //    {

                //        //if (i < 4)
                //        //    tbl = tbl + ("<td class='middle31new'  align='left'>");
                //        //else
                //        //    tbl = tbl + ("<td class='middle31new' align='right'>");
                //        //tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                //        if (i < 4)
                //        {

                //            tbl = tbl + ("<td class='middle31new' align='left'>");
                //            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                //        }
                //        else
                //        {
                //            if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                //            {

                //                tbl = tbl + ("<td class='middle31new' align='center' >");

                //                string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                //                //tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                //                //if (i % 3 == 0)

                //                if (i == j + 1)
                //                {

                //                    tbl = tbl + (str[1].ToString());
                //                    j = j + 3;
                //                }
                //                else
                //                {
                //                }
                //                //tbl = tbl + (str[1].ToString());


                //                tbl = tbl + "</br>";
                //                if (str[0].ToString() == "D")
                //                {
                //                    tbl = tbl + "Display" + "&nbsp;&nbsp;";
                //                }
                //                if (str[0].ToString() == "L")
                //                {
                //                    tbl = tbl + "Lineage" + "&nbsp;&nbsp;";
                //                }
                //                if (str[0].ToString() == "A")
                //                {
                //                    tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                //                }
                //                tbl = tbl + "</td>";

                //            }
                //        }


                //    }
                //    for (int i = 22; i < ds.Tables[0].Columns.Count - 2; i++)
                //    {
                //        if (i > 9)
                //        {
                //            tbl = tbl + ("<td class='middle31new' align='right'>");
                //            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                //        }
                //    }
                //    tbl = tbl + ("</tr>");
                //}
                //else if (extra2 == "O")
                //{
                //    for (int i = 2; i < ds.Tables[0].Columns.Count - 2; i++)
                //    {


                //        if (i < 4)
                //        {

                //            tbl = tbl + ("<td class='middle31new' align='left'>");
                //            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                //        }
                //        else
                //        {
                //            if (ds.Tables[0].Columns[i].ToString().IndexOf("#") > -1)
                //            {

                //                tbl = tbl + ("<td class='middle31new' align='right' >");

                //                string[] str = ds.Tables[0].Columns[i].ToString().Split('#');
                //                //tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");

                //                //if (i % 3 == 0)

                //                tbl = tbl + (str[1].ToString());
                //                tbl = tbl + "</br>";
                //                if (str[0].ToString() == "A")
                //                {
                //                    tbl = tbl + "Amount" + "&nbsp;&nbsp;";
                //                    tbl = tbl + "</td>";

                //                }
                //            }
                //        }

                //    }
                //    for (int i = 9; i < ds.Tables[0].Columns.Count - 2; i++)
                //    {
                //        if (i > 9)
                //        {
                //            tbl = tbl + ("<td class='middle31new' align='right'>");
                //            tbl = tbl + (ds.Tables[0].Columns[i].ToString() + "</td>");
                //        }
                //    }
                //    tbl = tbl + ("</tr>");
                //}
                value = new double[ds.Tables[0].Columns.Count];
                value1 = new double[ds.Tables[0].Columns.Count];
                value2 = new double[ds.Tables[0].Columns.Count];
                value_main = new double[ds.Tables[0].Columns.Count];
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    string route_code = ds.Tables[0].Rows[d]["MAIN_EDTN_NAME"].ToString();


                    //////////////MAIN EDIITION TOTAL


                    if (code_find.IndexOf(route_code) < 0)
                    {
                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td colspan='3' align='left' class='middle31new'>Total Edition");
                        tbl = tbl + ("</td>");
                        for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                        {

                            varmained1 = 0;

                            for (int v = mn; v <= (d - 1); v++)
                            {
                                double vared2 = 0;

                                if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                                {
                                    vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                    varmained1 = varmained1 + vared2;
                                }

                            }

                            value_main[m] = varmained1;
                        }
                        mn = (d - 1) + 1;


                        for (int x = 4; x < value_main.Length - 2; x++)
                        {
                            tbl = tbl + "<td  align='right' class='middle31new'>" + chk_null(value_main[x].ToString()) + "</td>";
                        }
                        for (int x = 4; x < value_main.Length - 2; x++)
                        {
                            value_main[x] = 0;
                        }

                        tbl = tbl + ("</tr>");

                        code_find += ds.Tables[0].Rows[d]["MAIN_EDTN_NAME"].ToString() + "~";
                    }

                    a = d;
                    a = a + 1;


                    if (d > 0)
                    {
                        if (ds.Tables[0].Rows[d - 1]["Publication"].ToString() != ds.Tables[0].Rows[d]["Publication"].ToString())
                        {
                            tbl = tbl + ("<tr>");
                            tbl = tbl + ("<td colspan='3' class='middle31new12' align='left'>Total Publication");
                            tbl = tbl + ("</td>");
                            for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                            {

                                varpub1 = 0;

                                for (int v = n; v < d; v++)
                                {
                                    double varpub2 = 0;

                                    if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                                    {
                                        varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                        varpub1 = varpub1 + varpub2;
                                    }

                                }

                                value2[m] = varpub1;
                            }
                            n = d;


                            for (int x = 4; x < value2.Length - 2; x++)
                            {
                                tbl = tbl + "<td  class='middle31new12'  align='right'>" + chk_null(value2[x].ToString()) + "</td>";
                            }
                            for (int x = 4; x < value2.Length - 2; x++)
                            {
                                value2[x] = 0;
                            }
                            tbl = tbl + ("</tr>");
                        }
                    }

                    for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                    {
                        var1 = 0;
                        vared1 = 0;
                        varmained1 = 0;
                        varpub1 = 0;
                        for (int v = 0; v < ds.Tables[0].Rows.Count; v++)
                        {
                            double var2 = 0;

                            if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                            {
                                var2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                var1 = var1 + var2;


                            }

                        }
                        value[m] = var1;
                        value2[m] = varpub1;
                    }



                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td class='rep_data'>" + a.ToString() + "</td>");
                    for (int y = 2; y < contcol - 2; y++)
                    {
                        if (y < 4)
                        {
                            tbl = tbl + ("<td class='rep_data'  align='left'>");
                            tbl = tbl + (ds.Tables[0].Rows[d].ItemArray[y].ToString() + "</td>");
                        }
                        else
                        {
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (chk_null(ds.Tables[0].Rows[d].ItemArray[y].ToString()) + "</td>");
                        }



                    }
                    tbl = tbl + ("</tr>");






                    //////////////MAIN EDIITION TOTAL
                    if (d == controw - 1)
                    {


                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td colspan='3' align='left' class='middle31new'>Total Edition");
                        tbl = tbl + ("</td>");
                        for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                        {

                            varmained1 = 0;

                            for (int v = mn; v <= d; v++)
                            {
                                double vared2 = 0;

                                if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                                {
                                    vared2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                    varmained1 = varmained1 + vared2;
                                }

                            }

                            value_main[m] = varmained1;
                        }
                        mn = d + 1;


                        for (int x = 4; x < value_main.Length - 2; x++)
                        {
                            tbl = tbl + "<td  align='right' class='middle31new'>" + chk_null(value_main[x].ToString()) + "</td>";
                        }
                        for (int x = 4; x < value_main.Length - 2; x++)
                        {
                            value_main[x] = 0;
                        }

                        tbl = tbl + ("</tr>");

                        code_find += ds.Tables[0].Rows[d]["MAIN_EDTN_NAME"].ToString() + "~";

                        ///////////////////////////////////////publication

                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td colspan='3' class='middle31new12' align='left'>Total Publication");
                        tbl = tbl + ("</td>");
                        for (int m = 4; m < ds.Tables[0].Columns.Count - 2; m++)
                        {

                            varpub1 = 0;

                            for (int v = n; v <= d; v++)
                            {
                                double varpub2 = 0;

                                if (ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString() != "")
                                {
                                    varpub2 = Convert.ToDouble(ds.Tables[0].Rows[v][ds.Tables[0].Columns[m].ToString()].ToString());
                                    varpub1 = varpub1 + varpub2;
                                }

                            }

                            value2[m] = varpub1;
                        }
                        n = d + 1;


                        for (int x = 4; x < value2.Length - 2; x++)
                        {
                            tbl = tbl + "<td  class='middle31new12'  align='right'>" + chk_null(value2[x].ToString()) + "</td>";
                        }
                        for (int x = 4; x < value2.Length - 2; x++)
                        {
                            value2[x] = 0;
                        }
                        tbl = tbl + ("</tr>");

                        /////////////publication

                    }
                    ////MAIN EDITION TOTAL



                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    rptDiv.InnerHtml += tbl;
                    tbl = "";

                }
            }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
            }

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td colspan='3' class='middle31new' align='left'>Total Business");
            for (int x = 4; x < value.Length - 2; x++)
            {
                tbl = tbl + "<td class='middle31new' align='right'>" + chk_null(value[x].ToString()) + "</td>";
            }
            tbl = tbl + ("</tr>");
            tbl = tbl + ("<tr rowspan='3'></tr>");

            for (int g = 0; g < ds.Tables[1].Rows.Count; g++)
            {

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td class='rep_data'>" + (g + 1) + "</td>");
                for (int h = 1; h < ds.Tables[1].Columns.Count; h++)
                {

                    if (h == 1)
                    {
                        tbl = tbl + ("<td class='rep_data'  align='left'>");
                        tbl = tbl + (ds.Tables[1].Rows[g].ItemArray[h].ToString() + "</td>");

                        tbl = tbl + ("<td class='rep_data'  align='left'>");
                        tbl = tbl + (ds.Tables[1].Rows[g].ItemArray[h].ToString() + "</td>");
                    }
                    else
                    {
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (chk_null(ds.Tables[1].Rows[g].ItemArray[h].ToString()) + "</td>");
                        if (extra2 == "O")
                        {

                            temp_tot = temp_tot + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                        }
                        if (extra2 == "W")
                        {
                           
                            if (ds.Tables[1].Columns[h].ToString().IndexOf("#") > -1)
                            {
                                string[] abc = ds.Tables[1].Columns[h].ToString().Split('#');

                                if (abc[0].ToString() == "D")
                                {
                                   
                                    temp_tot34 = temp_tot34 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                                    
                                }
                                if (abc[0].ToString() == "L")
                                {
                                    temp_tot35 = temp_tot35 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                                   
                                }
                                if (abc[0].ToString() == "A")
                                {
                                    temp_tot36 = temp_tot36 + Convert.ToDouble(ds.Tables[1].Rows[g].ItemArray[h].ToString());
                                   

                                }

                            }
                           
                        }
                    }
                }
                if (extra2 == "O")
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(temp_tot.ToString()) + "</td>");
                }
                if (extra2 == "W")
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(temp_tot34.ToString()) + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(temp_tot35.ToString()) + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(temp_tot36.ToString()) + "</td>");
                }
                temp_tot34 = 0;
                temp_tot35 = 0;
                temp_tot36 = 0;
                temp_tot = 0;
                tbl = tbl + ("</tr>");
            }

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td colspan='3' class='middle31new' align='left'>Total Business");
            for (int x = 4; x < value.Length - 2; x++)
            {
                tbl = tbl + "<td class='middle31new' align='right'>" +chk_null(value[x].ToString()) + "</td>";
            }
            tbl = tbl + ("</tr>");
            tbl = tbl + ("<tr rowspan='3'></tr>");
            if (browser.Browser == "Firefox")
            {
                tbl = tbl + "</table></P>";

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl = tbl + "</table></P>";

                }
                else if (ver == 6.0)
                {
                    tbl = tbl + "</table>";

                }
            }  

           // tbl = tbl + ("</table>");
            rptDiv.InnerHtml += tbl;
       
       
    }
    //else
    //{
    //    Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
    //}

}

