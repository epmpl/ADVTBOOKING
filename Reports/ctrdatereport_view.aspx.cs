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
using System.Text.RegularExpressions;
using iTextSharp.text.pdf.wmf;
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;

public partial class Reports_ctrdatereport_view : System.Web.UI.Page
{
    string fromdate = "";
    string dateto = "";
    string des_adty1 = "";

    string des_adcat1 = "";
    string teamname = "";
    string teamcode = "";
    string execname = "";
    string execcode = "";
    string pubname = "";
    string ediname = "";
    string pubcode = "";
    string edicode = "";
    string des_adcat2 = "";
    string des_adcat3 = "";
    string Branch_Code = "";
    string des_district = "";
    string unitcode = "";
    string des_printcent = "";
    string pdestination = "";
    string date = "";
    string branch_name = "";
    string printingcentername = "";
    string district_name = "";
    string pextra1 = "";
    string pextra2 = "";
    string pextra3 = "";
    string pextra4 = "";
    string pextra5 = "";
    string pad_subcat4 = "";
    string pad_subcat5 = "";
    string puserid = "";
    double area = 0;
    string day = "";
    string month = "";
    string year = "";
    int i1 = 1;
    double amt = 0;
    string rundate = "";
    string dytbl = "";
    int pgno = 1;
    DataSet ds;

    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";

    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    static string MDYToDMY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
       
        ds = (DataSet)Session["ctreport_view"];
        string[] prm_Array = new string[43];
      
        fromdate = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["Todate"].ToString();
      
        des_adty1 = Request.QueryString["des_adty1"].ToString();
        des_adcat1 = Request.QueryString["des_adcat1"].ToString();
        des_adcat2 = Request.QueryString["des_adcat2"].ToString();
        des_adcat3 = Request.QueryString["des_adcat3"].ToString();
        Branch_Code = Request.QueryString["des_branch"].ToString();
        des_district = Request.QueryString["des_district"].ToString();
        des_printcent = Request.QueryString["des_printcent"].ToString();
        pdestination = Request.QueryString["destination_code"].ToString();
        printingcentername = Request.QueryString["printcenter_name"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();
        puserid = Request.QueryString["puserid"].ToString();
        district_name = Request.QueryString["district_name"].ToString();
        teamname = Request.QueryString["teamname"].ToString();
        teamcode = Request.QueryString["teamcode"].ToString();
        execname = Request.QueryString["execname"].ToString();
        execcode = Request.QueryString["execcode"].ToString();
        if (execcode == "--Select Executive Name--")
            execcode = "";
        ediname = Request.QueryString["ediname"].ToString();
        edicode = Request.QueryString["edicode"].ToString();
        pubname = Request.QueryString["pubname"].ToString();
        pubcode = Request.QueryString["pubcode"].ToString();
      


        if (fromdate != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdate.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    fromdate = year + "/" + month + "/" + day;
                }
            }
        }
     
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto = dd + "/" + mm + "/" + yy;

            }


            else
            {


            }
        }
        

        rundate = Convert.ToString(System.DateTime.Now);
        rundate = changeformat(rundate);
        string[] tim = rundate.Split(' ');
       


        rundate = DateTime.Today.ToString().Split(' ')[0];
        string date11117 = rundate;
        string dd7 = date11117.Split('/')[1];
        string mm7 = date11117.Split('/')[0];
        string yyyy7 = date11117.Split('/')[2];
        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {
            rundate = RETURN_LENGTH(dd7) + "/" + RETURN_LENGTH(mm7) + "/" + yyyy7;
        }
        else
            if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
            {
                rundate = yyyy7 + "/" + mm7 + "/" + dd7;
            }


       
        if (!Page.IsPostBack)
        {
            if (pdestination == "1" || pdestination == "0")
            {
                onscreen();
                btnprint.Attributes.Add("onclick", "javascript:return forclick();");
            }
            else if (pdestination == "2")
            {
                showreportexcel();
            }
            else if (pdestination == "3")
            {
                pdf();
            }


           
        }
    }

    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }


    public string changeformat(string userdate)
    {
        string[] arr = userdate.Split('/');
        string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
        if (arr[1].Length < 2)
        {
            arr[1] = "0" + arr[1];
        }
        if (arr[0].Length < 2)
        {
            arr[0] = "0" + arr[0];
        }
        change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
        return change;
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



    public void onscreen()
    {
        DataSet ds = new DataSet();
        double outotal = 0;
        double qtytotal = 0;
        double sqcmtotal = 0;
        double amttotal = 0;
        double qtotal = 0;
        double stotal = 0;
        double linetotal = 0;
        double linaretotal = 0;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
            ds = obj.ctrdatereport_view(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
            ds = obj.ctreport_date_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);

        }
        else
        {
            string procedureName = "rpt_categorywisedate_summary_rpt_categorywisedate_billing";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";

        int maxlimit = 45;
        int rowcounter = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

            tbl = tbl + "<p ><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

            string topheader = createheader(ds);
            tbl = tbl + topheader;
            if (hiddenascdesc.Value == "")
            {
                tbl = tbl + "<tr ><td width='10%' class='rep_datatotal_vouchdata'><b>Date</b></td>";
                tbl = tbl + "<td width='20%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td>";
                tbl = tbl + "<td class='rep_datatotal_vouchdata'width='15%'><b>Ad Subcategory1<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata'width='10%'><b>Ad Subcategory2<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='8%'><b>No.Of<br>Insertions<b></td>";

                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Display</td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Lineage</td>";


                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (rowcounter >= maxlimit)
                {
                    tbl = tbl + "</table></p>";
                    rowcounter = 0;
                    tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                    pgno++;
                    string header = createheader(ds);
                    tbl = tbl + header;
                    if (hiddenascdesc.Value == "")
                    {
                        tbl = tbl + "<tr ><td width='10%' class='rep_datatotal_vouchdata'><b>Date</b></td>";
                        tbl = tbl + "<td width='20%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td>";
                        tbl = tbl + "<td class='rep_datatotal_vouchdata'width='15%'><b>Ad Subcategory1<b></td>";
                        tbl = tbl + "<td  class='rep_datatotal_vouchdata'width='10%'><b>Ad Subcategory2<b></td>";
                        tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='8%'><b>No.Of <br>Insertion<b></td>";
                        tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Display</td>";
                        tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Lineage</td>";
                        tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                    }
                }
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["INSERT_DATE"].ToString() == ds.Tables[0].Rows[i - 1]["INSERT_DATE"].ToString())
                    {
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()) + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT3"] + "</td>");
                        tbl = tbl + ("<td align='right'class='rep_data'>");

                        tbl = tbl + (ds.Tables[0].Rows[i]["NO_OF_INSERTION"] + "</td>");
                        tbl = tbl + ("<td align='right'class='rep_data'>");
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        {
                            sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                            tbl = tbl + (sqcmtotal.ToString("F2") + "</td>");
                        }
                        tbl = tbl + ("<td align='right'class='rep_data'>");
                        if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                        {
                            linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                            tbl = tbl + (linetotal.ToString("F2") + "</td>");
                        }
                        tbl = tbl + ("<td align='right'class='rep_data'>");
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        {
                            outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                            tbl = tbl + (outotal.ToString("F2") + "</td>");
                        }
                        if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                            qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                            stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                            linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                            amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        tbl = tbl + "</tr>";
                        rowcounter++;
                    }

                    else
                    {
                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td  colspan='4'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                        tbl = tbl + ("</tr>");
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                        rowcounter = rowcounter + 2;
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()) + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT3"] + "</td>");
                        tbl = tbl + ("<td align='right'class='rep_data'>");

                        tbl = tbl + (ds.Tables[0].Rows[i]["NO_OF_INSERTION"] + "</td>");
                        tbl = tbl + ("<td align='right'class='rep_data'>");
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        {
                            sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                            tbl = tbl + (sqcmtotal.ToString("F2") + "</td>");
                        }
                        tbl = tbl + ("<td align='right'class='rep_data'>");
                        if (ds.Tables[0].Rows[0]["LINE_AREA"].ToString() != "")
                        {
                            linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                            tbl = tbl + (linetotal.ToString("F2") + "</td>");
                        }
                        tbl = tbl + ("<td align='right'class='rep_data'>");
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        {
                            outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                            tbl = tbl + (outotal.ToString("F2") + "</td>");
                        }
                        if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                            qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                            stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                            linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                            amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);

                        tbl = tbl + "</tr>";
                        rowcounter++;
                    }

                }
                else
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()) + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT3"] + "</td>");
                    tbl = tbl + ("<td align='right'class='rep_data'>");

                    tbl = tbl + (ds.Tables[0].Rows[i]["NO_OF_INSERTION"] + "</td>");
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                    {
                        sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        tbl = tbl + (sqcmtotal.ToString("F2") + "</td>");
                    }
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                    {
                        linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        tbl = tbl + (linetotal.ToString("F2") + "</td>");
                    }
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                    {
                        outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        tbl = tbl + (outotal.ToString("F2") + "</td>");
                    }

                    if (ds.Tables[0].Rows[0]["NO_OF_INSERTION"].ToString() != "")
                        qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);

                    if (ds.Tables[0].Rows[0]["BOOK_AREA"].ToString() != "")
                        stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                    if (ds.Tables[0].Rows[0]["LINE_AREA"].ToString() != "")
                        linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                    if (ds.Tables[0].Rows[0]["AMOUNT"].ToString() != "")
                        amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                    tbl = tbl + "</tr>";
                    rowcounter++;
                }
                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td  colspan='4'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                    tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                    tbl = tbl + ("</tr>");

                }

            }
            tbl = tbl + ("</table></p>");
            tblgrid.InnerHtml = tbl;
            dynamictable.Text = dytbl;
        }
    }
    public string createheader(DataSet ds)
    {
        string Hearder1 = "";
        string company1 = ds.Tables[0].Rows[0]["CNAME"].ToString();// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
        string reportname1 = "Category Date Wise Report";
        Hearder1 += "<tr><td align='center'colspan='20'><b> ";
        Hearder1 += company1;
        Hearder1 += "</b></td></tr>";
        Hearder1 += "<tr><td align='center'colspan='15'><b> ";
        Hearder1 += reportname1;
        Hearder1 += "</b></td></tr>";
        string pub = "";
        if (pubname == "--Select Publication--" || pubname == "0")
        {
            pub = "All";

        }
        else
        {
            pub = pubname;
        }
        string edi = "";
        if (ediname == "Select Edition" || ediname == "0" || ediname == "--Select Edition Name--")
        {
            edi = "All";

        }
        else
        {
            edi = ediname;
        }
        string team = "";
        if (teamname == "Select Team" || teamname == "0")
        {
            team = "All";

        }
        else
        {
            team = teamname;
        }
        string ece = "";
        if (execname == "--Select Executive Name--" || execname == "0")
        {
            ece = "All";

        }
        else
        {
            ece = execname;
        }
        Hearder1 += "<tr width='100%'><td  align='left'style='font-family:Arial;font-size:12px;'><b>Publication Name:</b>" + pub + "</td>";
        Hearder1 += "<td align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
        Hearder1 += "<td  colspan='2'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
        Hearder1 += "<td colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
        string printingname = "";
        if (printingcentername == "" || printingcentername == "0")
        {
            printingname = "All";

        }
        else
        {
            printingname = printingcentername;
        }
        Hearder1 += "<tr width='100%'><td  align='left'style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + printingname + "</td>";

        //tbl1 = tbl1 + " <tr><td  class='rep_data' align='left'><b>Printing Center:</b>" + "nbsp;" + printingname + "</td>";
        string brname = "";
        if (branch_name == "--Select Branch--" || branch_name == "0")
        {
            brname = "All";

        }
        else
        {
            brname = branch_name;
        }

        Hearder1 += "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

        string Daname = "";
        if (district_name == "" || district_name == "0")
        {
            Daname = "All";

        }
        else
        {
            Daname = district_name;
        }
        Hearder1 += "<td  width='20%'align='left'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td  colspan='10' align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
        Hearder1 += "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
        Hearder1 += "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td><td  colspan='10' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
        int rowcounter = 10;
        return Hearder1;
    }

    ///////////////////////////////////////

    public void showreportexcel()//(string fromdate111, string todate111, string mainagency111, string subagency111, string printing_centercode111, string regioncode111, string branchcode111, string distname111, string com_out111, string rcpt_uptodate111)
    {
        DataSet ds = new DataSet();
        double outotal = 0;
        double qtytotal = 0;
        double sqcmtotal = 0;
        double amttotal = 0;
        double qtotal = 0;
        double stotal = 0;
        int rowcounter = 0;
        double linetotal = 0;
        double linaretotal = 0;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
            ds = obj.ctrdatereport_view(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
            ds = obj.ctreport_date_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);

        }
        else
        {
            string procedureName = "rpt_categorywisedate_summary_rpt_categorywisedate_billing";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        int cont = ds.Tables[0].Rows.Count;
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        string tbl = "";
        Double total = 0;
        string dscount = "";
        string company1;
        tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='1' width='100%' >";
        if (ds.Tables[0].Rows.Count > 0)
            company1 = ds.Tables[0].Rows[0]["CNAME"].ToString();
        else
            company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
        string reportname1 = "Category Wise Report";
        tbl = tbl + "<tr><td align='center'colspan='8' style='padding-right:140px'><b> ";
        tbl = tbl + company1;
        tbl = tbl + "</b></td></tr>";
        tbl = tbl + "<tr><td align='center'colspan='8' style='padding-right:140px'><b> ";
        tbl = tbl + reportname1;
        tbl = tbl + "</b></td></tr>";
        string pub = "";
        if (pubname == "--Select Publication--" || pubname == "0")
        {
            pub = "All";

        }
        else
        {
            pub = pubname;
        }
        string edi = "";
        if (ediname == "Select Edition" || ediname == "0" || ediname == "--Select Edition Name--")
        {
            edi = "All";

        }
        else
        {
            edi = ediname;
        }
        string team = "";
        if (teamname == "Select Team" || teamname == "0")
        {
            team = "All";

        }
        else
        {
            team = teamname;
        }
        string ece = "";
        if (execname == "--Select Executive Name--" || execname == "0")
        {
            ece = "All";

        }
        else
        {
            ece = execname;
        }
        tbl = tbl + "<tr width='100%'><td  align='left'style='font-family:Arial;font-size:12px;'><b>Publication Name:</b>" + pub + "</td>";
        tbl = tbl + "<td  colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
        tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
        tbl = tbl + "<td  colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
        string printingname = "";
        if (printingcentername == "" || printingcentername == null)
        {
            printingname = "All";

        }
        else
        {
            printingname = printingcentername;
        }
        tbl = tbl + "<tr width='100%'><td  align='left'style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + printingname + "</td>";
        string brname = "";
        if (branch_name == "--Select Branch--" || branch_name == null)
        {
            brname = "All";

        }
        else
        {
            brname = branch_name;
        }

        tbl = tbl + "<td   colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

        string Daname = "";
        if (district_name == "" || district_name == null)
        {
            Daname = "All";

        }
        else
        {
            Daname = district_name;
        }
        tbl = tbl + "<td  width='100'colsapn='31'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
        tbl = tbl + "<tr><td  colspan='2' align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
        tbl = tbl + "<td colsapn='31' align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";

        tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' style='vertical-align:top'>";
        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr width='100%'><td width='10%' class='rep_datatotal_vouchdata'><b>Date</b></td><td width='20%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td><td class='rep_datatotal_vouchdata'width='15%'><b>Ad Subcategory1</b></td><td  class='rep_datatotal_vouchdata'width='20%'><b>Ad Subcategory2</b></td><td  class='rep_datatotal_vouchdata'  width='10%'><b>No. Of Insertion</b></td><td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Display</b></td><td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Lineage</b></td><td  class='rep_datatotal_vouchdata'width='250' align='right'><b>Amount(Publication,Audit By Rate,Billed)</b></td></tr>");

        }

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i > 0)
            {
                if (ds.Tables[0].Rows[i]["INSERT_DATE"].ToString() == ds.Tables[0].Rows[i - 1]["INSERT_DATE"].ToString())
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()) + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT3"] + "</td>");
                    tbl = tbl + ("<td align='right'class='rep_data'>");

                    tbl = tbl + (ds.Tables[0].Rows[i]["NO_OF_INSERTION"] + "</td>");
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                    {
                        sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        tbl = tbl + (sqcmtotal.ToString("F2") + "</td>");
                    }
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                    {
                        linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        tbl = tbl + (linetotal.ToString("F2") + "</td>");
                    }
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                    {
                        outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        tbl = tbl + (outotal.ToString("F2") + "</td>");
                    }
                    if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                        qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                    if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                        linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                    tbl = tbl + "</tr>";
                    rowcounter++;
                }
                else
                {
                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td  colspan='4'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                    tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                    tbl = tbl + ("</tr>");
                    qtotal = 0;
                    stotal = 0;
                    linaretotal = 0;
                    amttotal = 0;
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()) + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT3"] + "</td>");
                    tbl = tbl + ("<td align='right'class='rep_data'>");

                    tbl = tbl + (ds.Tables[0].Rows[i]["NO_OF_INSERTION"] + "</td>");
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                    {
                        sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        tbl = tbl + (sqcmtotal.ToString("F2") + "</td>");
                    }
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                    {
                        linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        tbl = tbl + (linetotal.ToString("F2") + "</td>");
                    }
                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                    {
                        outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        tbl = tbl + (outotal.ToString("F2") + "</td>");
                    }
                    if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                        qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                    if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                        linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);

                    tbl = tbl + "</tr>";
                    rowcounter++;
                }
            }
            else
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td align='left'class='rep_data'>");
                tbl = tbl + (changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()) + "</td>");
                tbl = tbl + ("<td align='left'class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                tbl = tbl + ("<td align='left'class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                tbl = tbl + ("<td align='left'; class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT3"] + "</td>");
                tbl = tbl + ("<td align='right'class='rep_data'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["NO_OF_INSERTION"] + "</td>");
                tbl = tbl + ("<td align='right'class='rep_data'>");
                if (ds.Tables[0].Rows[0]["BOOK_AREA"].ToString() != "")
                {
                    sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                    tbl = tbl + (sqcmtotal.ToString("F2") + "</td>");
                }
                tbl = tbl + ("<td align='right'class='rep_data'>");
                if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                {
                    linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                    tbl = tbl + (linetotal.ToString("F2") + "</td>");
                }
                tbl = tbl + ("<td align='right'class='rep_data'>");
                if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                {
                    outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                    tbl = tbl + (outotal.ToString("F2") + "</td>");
                }

                if (ds.Tables[0].Rows[0]["NO_OF_INSERTION"].ToString() != "")
                    qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                if (ds.Tables[0].Rows[0]["BOOK_AREA"].ToString() != "")
                    stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                if (ds.Tables[0].Rows[0]["LINE_AREA"].ToString() != "")
                    linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                if (ds.Tables[0].Rows[0]["AMOUNT"].ToString() != "")
                    amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                tbl = tbl + "</tr>";


            }

            if (i == (ds.Tables[0].Rows.Count - 1))
            {
                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='4'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("</tr>");
            }
        }

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }
    //////////////////////////////////////////
    public void pdf()
    {

        int rowcounter23 = 0;
        int maxl = 21;
        double outotal = 0;
        double qtytotal = 0;
        double sqcmtotal = 0;
        double amttotal = 0;
        double qtotal = 0;
        double stotal = 0;
        double linetotal = 0;
        double linaretotal = 0;
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;

        DataSet ds = new DataSet();
        Double total = 0;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
            ds = obj.ctrdatereport_view(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
            ds = obj.ctreport_date_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);

        }
        else
        {
            string procedureName = "rpt_categorywisedate_summary_rpt_categorywisedate_billing";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
        int cont = ds.Tables[0].Rows.Count;
        //-==============================end here=======================================

        document.Open();

        int NumColumns = 8;
        Font font1 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD);
        Font font2 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL);
        Font font3 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font21 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 14, Font.NORMAL);
        Font font31 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL);
        Font font4 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        try
        {
            // we add some meta information to the document

            ///////////////////////////////////////////////////////////////////////////////

            PdfPTable tbl1 = new PdfPTable(1);
            float[] xy1 = { 50 };
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.WidthPercentage = 100;
            tbl1.setWidths(xy1);
            tbl1.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // tbl1.setWidths(xy1);
            tbl1.addCell(new Phrase(ds.Tables[0].Rows[0]["CNAME"].ToString(), font1));
            tbl1.WidthPercentage = 50;
            document.Add(tbl1);


            //////////////////////////////////////////////////////////////////////////////

            PdfPTable tbl2 = new PdfPTable(1);
            float[] xy2 = { 50 };
            tbl2.setWidths(xy2);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl1.WidthPercentage = 100;
            tbl2.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase("Categort Date Wise Report".ToString(), font3));
            document.Add(tbl2);


            //////////////////////////////////////////////////////////////////////////////
            PdfPTable tbl37 = new PdfPTable(4);
            float[] xy37 = { 20, 20, 15, 20 };
            tbl37.DefaultCell.BorderWidth = 0;
            tbl37.WidthPercentage = 100;
            tbl37.DefaultCell.Padding = 0;
            tbl37.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl37.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl37.setWidths(xy37);
            string pub = "";
            if (pubname == "--Select Publication--" || pubname == "0")
            {
                pub = "All";

            }
            else
            {
                pub = pubname;
            }
            string edi = "";
            if (ediname == "Select Edition" || ediname == "0" || ediname == "--Select Edition Name--")
            {
                edi = "All";

            }
            else
            {
                edi = ediname;
            }
            string team = "";
            if (teamname == "Select Team" || teamname == "0")
            {
                team = "All";

            }
            else
            {
                team = teamname;
            }
            string ece = "";
            if (execname == "--Select Executive Name--" || execname == "0")
            {
                ece = "All";

            }
            else
            {
                ece = execname;
            }
            tbl37.addCell(new Phrase("Publication Name:" + pub, font2));
            tbl37.addCell(new Phrase("Edition Name:" + edi, font2));
            tbl37.addCell(new Phrase("Team Name:" + team, font2));
            tbl37.addCell(new Phrase("Executive Name:" + ece, font2));
            document.Add(tbl37);


            PdfPTable tbl3 = new PdfPTable(3);
            float[] xy3 = { 10, 10, 15 };
            tbl3.DefaultCell.BorderWidth = 0;
            tbl3.WidthPercentage = 100;
            tbl3.DefaultCell.Padding = 0;
            tbl3.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl3.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl3.setWidths(xy3);
            string printingname = "";
            if (printingcentername == "" || printingcentername == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = printingcentername;
            }
            string brname = "";
            if (branch_name == "--Select Branch--" || branch_name == null)
            {
                brname = "All";

            }
            else
            {
                brname = branch_name;
            }
            string Daname = "";
            if (district_name == "" || district_name == null)
            {
                Daname = "All";

            }
            else
            {
                Daname = district_name;
            }
            tbl3.addCell(new Phrase("Printing Center:" + printingname, font2));
            tbl3.addCell(new Phrase("Branch Name:" + brname, font2));
            tbl3.addCell(new Phrase("District Name:" + Daname, font2));
            document.Add(tbl3);

            PdfPTable tbl6 = new PdfPTable(3);
            float[] abc = { 15, 20, 15 };
            tbl6.DefaultCell.BorderWidth = 0;
            tbl6.WidthPercentage = 100;
            tbl6.DefaultCell.Padding = 0;
            tbl6.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.setWidths(abc);
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("From Date:" + fromdate, font2));
            tbl6.addCell(new Phrase("To Date:" + dateto, font2));
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl6.addCell(new Phrase("Run Date:" + rundate, font2));
            document.Add(tbl6);


            PdfPTable tb89 = new PdfPTable(6);
            tb89.DefaultCell.BorderWidth = 0;
            tb89.WidthPercentage = 100;
            tb89.DefaultCell.Colspan = 6;
            tb89.addCell(new Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
            document.Add(tb89);



            PdfPTable datatable111 = new PdfPTable(8);
            float[] headerwidths = { 15,15, 15, 15, 10, 15, 15, 20 };// percentage
            datatable111.setWidths(headerwidths);
            datatable111.WidthPercentage = 100; // percentage
            datatable111.DefaultCell.BorderWidth = 0;
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable111.addCell(new Phrase("Date", font3));
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable111.addCell(new Phrase("Ad Category", font3));
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable111.addCell(new Phrase("Ad Subcategory1", font3));
            datatable111.addCell(new Phrase("Ad Subcategory2", font3));
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable111.addCell(new Phrase("No Of" + "\n" + "Insertion", font3));
            datatable111.addCell(new Phrase("Display", font3));
            datatable111.addCell(new Phrase("Lineage", font3));
            datatable111.addCell(new Phrase("Amount(Publish,Audit By Rate,Billed)", font3));
            document.Add(datatable111);

            PdfPTable tb897 = new PdfPTable(8);
            tb897.DefaultCell.Colspan = 8;
            tb897.DefaultCell.BorderWidth = 0;
            tb897.WidthPercentage = 100;
            tb897.addCell(new Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
            document.Add(tb897);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (rowcounter23 >= maxl)
                {
                    rowcounter23 = 0;
                    document.newPage();
                    document.Add(tbl1);
                    document.Add(tbl2);
                    document.Add(tbl37);
                    document.Add(tbl3);
                    document.Add(tbl6);
                    document.Add(tb89);
                    document.Add(datatable111);
                    document.Add(tb897);

                }

                PdfPTable datatable = new PdfPTable(8);
                datatable.DefaultCell.BorderWidth = 0;
                float[] abhg = { 15,15, 15, 15, 10, 15, 15, 20 };// percentage
                datatable.setWidths(abhg);
                datatable.WidthPercentage = 100;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["INSERT_DATE"].ToString() == ds.Tables[0].Rows[i - 1]["INSERT_DATE"].ToString())
                    {

                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        datatable.addCell(new Phrase(changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()), font31));


                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString(), font31));
                        if (ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString().Length < 14)
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString(), font31));
                        else
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString().Substring(0, 13), font31));

                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT3"].ToString(), font31));
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString(), font31));
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        {
                            sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                            datatable.addCell(new Phrase(sqcmtotal.ToString("F2"), font31));
                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font31));
                        }
                        if (ds.Tables[0].Rows[0]["LINE_AREA"].ToString() != "")
                        {
                            linetotal = Convert.ToDouble(ds.Tables[0].Rows[0]["LINE_AREA"]);
                            datatable.addCell(new Phrase(linetotal.ToString("F2"), font31));
                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font31));
                        }
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        {
                            outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                            datatable.addCell(new Phrase(outotal.ToString("F2"), font31));
                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font31));
                        }
                        if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                            qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                            stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                            linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                            amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        rowcounter23++;
                    }
                    else
                    {
                        datatable.DefaultCell.Colspan = 8;
                        datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                        datatable.DefaultCell.Colspan = 4;
                        datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        datatable.addCell(new iTextSharp.text.Phrase("Total:", font3));
                        datatable.DefaultCell.Colspan = 1;
                        datatable.addCell(new iTextSharp.text.Phrase(qtotal.ToString(), font3));
                        //datatable.DefaultCell.Colspan = 1;                      
                        datatable.addCell(new iTextSharp.text.Phrase(stotal.ToString("F2"), font3));
                        datatable.addCell(new iTextSharp.text.Phrase(linaretotal.ToString("F2"), font3));
                        datatable.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font3));
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                        datatable.DefaultCell.Colspan = 8;
                        datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                        rowcounter23 = rowcounter23 + 4;
                        datatable.DefaultCell.Colspan = 1;
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        datatable.addCell(new Phrase(changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()), font31));

                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString(), font31));
                        if (ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString().Length < 14)
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString(), font31));
                        else
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString().Substring(0, 13), font31));
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT3"].ToString(), font31));
                        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString(), font31));
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        {
                            sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                            datatable.addCell(new Phrase(sqcmtotal.ToString("F2"), font31));
                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font31));
                        }
                        if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                        {
                            linetotal = Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                            datatable.addCell(new Phrase(linetotal.ToString("F2"), font31));
                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font31));
                        }
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        {
                            outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                            datatable.addCell(new Phrase(outotal.ToString("F2"), font31));
                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font31));
                        }

                        if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                            qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                        if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                            stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                            linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                        if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                            amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        rowcounter23++;
                    }
                }
                else
                {
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(changeformat(ds.Tables[0].Rows[i]["INSERT_DATE"].ToString()), font31));

                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString(), font31));
                    if (ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString().Length < 14)
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString(), font31));
                    else
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT"].ToString().Substring(0, 13), font31));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["AD_SUB_CAT3"].ToString(), font31));
                    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString(), font31));
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                    {
                        sqcmtotal = Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                        datatable.addCell(new Phrase(sqcmtotal.ToString("F2"), font31));
                    }
                    else
                    {
                        datatable.addCell(new Phrase("", font31));
                    }
                    if (ds.Tables[0].Rows[0]["LINE_AREA"].ToString() != "")
                    {
                        linetotal = Convert.ToDouble(ds.Tables[0].Rows[0]["LINE_AREA"]);
                        datatable.addCell(new Phrase(linetotal.ToString("F2"), font31));
                    }
                    else
                    {
                        datatable.addCell(new Phrase("", font31));
                    }
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                    {
                        outotal = Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                        datatable.addCell(new Phrase(outotal.ToString("F2"), font31));
                    }
                    else
                    {
                        datatable.addCell(new Phrase("", font31));
                    }

                    if (ds.Tables[0].Rows[i]["NO_OF_INSERTION"].ToString() != "")
                        qtotal = qtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["NO_OF_INSERTION"]);
                    if (ds.Tables[0].Rows[i]["BOOK_AREA"].ToString() != "")
                        stotal = stotal + Convert.ToDouble(ds.Tables[0].Rows[i]["BOOK_AREA"]);
                    if (ds.Tables[0].Rows[i]["LINE_AREA"].ToString() != "")
                        linaretotal = linaretotal + Convert.ToDouble(ds.Tables[0].Rows[i]["LINE_AREA"]);
                    if (ds.Tables[0].Rows[i]["AMOUNT"].ToString() != "")
                        amttotal = amttotal + Convert.ToDouble(ds.Tables[0].Rows[i]["AMOUNT"]);
                    rowcounter23++;


                }
                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    datatable.DefaultCell.Colspan = 8;
                    datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                    datatable.DefaultCell.Colspan = 4;
                    datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    datatable.addCell(new iTextSharp.text.Phrase("Total:", font3));
                    datatable.DefaultCell.Colspan = 1;
                    datatable.addCell(new iTextSharp.text.Phrase(qtotal.ToString(), font3));

                    datatable.addCell(new iTextSharp.text.Phrase(stotal.ToString("F2"), font3));
                    datatable.addCell(new iTextSharp.text.Phrase(linaretotal.ToString("F2"), font3));
                    datatable.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font3));
                    datatable.DefaultCell.Colspan = 7;
                    datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                }


                document.Add(datatable);

            }




            document.Close();
            Response.Redirect(pdfName);
        }

        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }
}
