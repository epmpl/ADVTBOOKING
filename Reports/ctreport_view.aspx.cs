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
//using System.Diagnostics.Design;
using System.Diagnostics;

public partial class Reports_ctreport_view : System.Web.UI.Page
{

    string fromdate = "";
    string dateto = "";
    string des_adty1 = "";
    string reptype = "";
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
    string agency_name = "";
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
        //DataSet ds1 = new DataSet();
        //ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        //heading.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        //hdnunitcode.Value = Session["unitcode"].ToString();
        ds = (DataSet)Session["ctreport_view"];
        string[] prm_Array = new string[43];
        //Request=value
        fromdate = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["Todate"].ToString();
        //unitcode = Request.QueryString["unitcode"].ToString();
        //unitcode = Session["center"].ToString();
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
        reptype = Request.QueryString["reptype"].ToString();
        ///end
        ///lbl=value
        //if (des_printcent == "0")
        //pcenter.Text = "ALL".ToString();
        //else
        //pcenter.Text = des_printcent.ToString();


        //lbdistrict.Text = des_district.ToString();

        //if (des_adty1 == "CL0")
        //lbladtype.Text = "CLASSIFIED".ToString();
        //else
        //lbladtype.Text = des_adty1.ToString();

        //if (des_adty1 == "DI0")
        //lbladtype.Text = "DISPLAY".ToString();
        //else
        //lbladtype.Text = des_adty1.ToString();

        //lblcat.Text = des_adcat1.ToString();
        //lblcat2.Text = des_adcat2.ToString();
        //// lblcat3.Text = des_adcat3.ToString();
        //lblbranch.Text = Branch_Code.ToString();
        ///end
        /// 


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
        // lblfrom.Text = fromdate;
        //dateto1 = "";
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
        // lblto.Text = dateto;

        rundate = Convert.ToString(System.DateTime.Now);
        rundate = changeformat(rundate);
        string[] tim = rundate.Split(' ');
        // lbldate.Text = tim[0];

        //rundate = DateTime.Today.ToString().Split(' ')[0];


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
        if (des_adcat1 == "Select AdCat")
        {
            des_adcat1 = "";
        }
        if (des_adcat2 == "Select AdSubCat")
        {
            des_adcat2 = "";
        }
        if (edicode == "--Select Edition Name--")
        {
            edicode = "";
        }

        //lbldate.Text = date.ToString();
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


            //if (destination == "onscreen" || destination == "Select Destination")
            //{
            //    //onscreen(fromdate, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), des_adty1, des_adcat1, des_adcat2, des_adcat3, Branch_Code, des_district, des_printcent, destination);
            //    onscreen();
            //}
            //if (destination == "0" || destination == "Select Destination")
            //{
            //    onscreen();
            //}
            //else if (destination == "Excel")
            //{
            //    showreportexcel();
            //}
            //        else if (pdestination == "3")
            //        {
            //            showreportpdf();
            //        }
            //       
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
        double gqtotal = 0;
        double gstotal = 0;
        double glinaretotal = 0;
        double gamttotal = 0;
        double gqstotal = 0;
        double gsstotal = 0;
        double gslinaretotal = 0;
        double gsamttotal = 0;

        if (reptype == "S")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_categorywise_summary_rpt_categorywise_billing";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
                    tbl = tbl + "<tr ><td width='20%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='20%'><b>Ad Subcategory1<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata'width='10%'><b>Ad Subcategory2<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='13%'><b>No.Of<br>Insertions<b></td>";

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
                            tbl = tbl + "<tr ><td width='20%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='20%'><b>Ad Subcategory1<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata'width='10%'><b>Ad Subcategory2<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='13%'><b>No.Of <br>Insertion<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Display</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Lineage</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                        }
                    }
                    if (i > 0)
                    {
                        if (ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString() == ds.Tables[0].Rows[i - 1]["AD_MAIN_CAT"].ToString())
                        {
                            tbl = tbl + ("<tr >");
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
                            tbl = tbl + ("<td  colspan='3'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                            tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                            gqtotal = gqtotal + qtotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                            gstotal = gstotal + stotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                            glinaretotal = glinaretotal + linaretotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                            gamttotal = gamttotal + amttotal;
                            tbl = tbl + ("</tr>");
                            qtotal = 0;
                            stotal = 0;
                            linaretotal = 0;
                            amttotal = 0;
                            rowcounter = rowcounter + 2;
                            tbl = tbl + ("<tr >");
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
                        tbl = tbl + ("<td  colspan='3'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                        gqtotal = gqtotal + qtotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                        gstotal = gstotal + stotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                        glinaretotal = glinaretotal + linaretotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                        gamttotal = gamttotal + amttotal;
                        tbl = tbl + ("</tr>");
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                    }

                }

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='3'align='right'class='rep_datatotal_vouchdata'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("</tr>");
                tbl = tbl + ("</table></p>");
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }
        else if (reptype == "D")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_det(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_categorywise_det_rpt_categorywise_billing_det";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            int cont = ds.Tables[0].Rows.Count;
            string tbl = "";

            int maxlimit = 36;
            int rowcounter = 0;
            int sno = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                tbl = tbl + "<p ><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string topheader = createheader1(ds);
                tbl = tbl + topheader;
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdCat</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdSubCat</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>Booking Id</b></td>";
                    tbl = tbl + "<td width='5%' class='rep_datatotal_vouchdata'><b>Booking Date</b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='11%'><b>Agency Name<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Code<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Name<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Package<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>No.Of<br>Insertions<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Display</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='6%'><b>Lineage</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                    rowcounter = rowcounter + 1;
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        pgno++;
                        string header = createheader1(ds);
                        tbl = tbl + header;
                        if (hiddenascdesc.Value == "")
                        {
                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdCat</b></td>";
                            tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdSubCat</b></td>";
                            tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>Booking Id</b></td>";
                            tbl = tbl + "<td width='5%' class='rep_datatotal_vouchdata'><b>Booking Date</b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='11%'><b>Agency Name<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Code<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Name<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Package<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Rate Code<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>No.Of<br>Insertions<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Display</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='6%'><b>Lineage</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                            rowcounter = rowcounter + 1;
                        }
                    }
                    if (i > 0)
                    {
                        if (ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString() == ds.Tables[0].Rows[i - 1]["AD_MAIN_CAT"].ToString())
                        {
                            tbl = tbl + ("<tr >");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (sno + "</td>");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + ("" + "</td>");
                            //tbl = tbl + (ds.Tables[0].Rows[i]["BOOKING_DATE"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");

                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            //tbl = tbl + (ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>");
                            tbl = tbl + ("" + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");

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
                            rowcounter = rowcounter + 3;
                        }

                        else
                        {
                            tbl = tbl + ("<tr>");
                            tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                            tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                            gqtotal = gqtotal + qtotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                            gstotal = gstotal + stotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                            glinaretotal = glinaretotal + linaretotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                            gamttotal = gamttotal + amttotal;
                            tbl = tbl + ("</tr>");
                            qtotal = 0;
                            stotal = 0;
                            linaretotal = 0;
                            amttotal = 0;
                            rowcounter = rowcounter + 1;
                            tbl = tbl + ("<tr >");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (sno + "</td>");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["BOOKING_DATE"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");

                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");
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
                            rowcounter = rowcounter + 3;
                        }

                    }
                    else
                    {
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (sno + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + ("" + "</td>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["BOOKING_DATE"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");

                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + ("" + "</td>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");
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
                        rowcounter = rowcounter + 3;
                    }
                    if (i == (ds.Tables[0].Rows.Count - 1))
                    {

                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                        gqtotal = gqtotal + qtotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                        gstotal = gstotal + stotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                        glinaretotal = glinaretotal + linaretotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                        gamttotal = gamttotal + amttotal;
                        tbl = tbl + ("</tr>");
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                    }
                    sno++;
                }

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("</tr>");
                tbl = tbl + ("</table></p>");

                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }

        }

        else if (reptype == "RD")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_det_region(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_categorywise_det_region_rpt_categorywise_det_region";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            int cont = ds.Tables[0].Rows.Count;
            string tbl = "";

            int maxlimit = 30;
            int rowcounter = 0;
            int sno = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                tbl = tbl + "<p ><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string topheader = createheader1(ds);
                tbl = tbl + topheader;
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdSubCat</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>Booking Id</b></td>";
                    tbl = tbl + "<td width='5%' class='rep_datatotal_vouchdata'><b>Booking Date</b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='11%'><b>Agency Name<b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>City</b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Code<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Name<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Package<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>No.Of<br>Insertions<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Display</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='6%'><b>Lineage</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                    rowcounter = rowcounter + 1;
                }
                string find_region = "";
                string find_adcat = "";
                 find_region = ds.Tables[0].Rows[0]["region"].ToString();
                 find_adcat = ds.Tables[0].Rows[0]["AD_MAIN_CAT"].ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        pgno++;
                        string header = createheader1(ds);
                        tbl = tbl + header;
                        if (hiddenascdesc.Value == "")
                        {

                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdSubCat</b></td>";
                            tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>Booking Id</b></td>";
                            tbl = tbl + "<td width='5%' class='rep_datatotal_vouchdata'><b>Booking Date</b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='11%'><b>Agency Name<b></td>";
                            tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>City</b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Code<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Name<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Package<b></td>";
                            tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Rate Code<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>No.Of<br>Insertions<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Display</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='6%'><b>Lineage</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                            rowcounter = rowcounter + 1;
                           
                        }
                    }

                        if (i == 0)
                        {
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='2' class='rep_data' align='left' width='10%'><b>" + ds.Tables[0].Rows[i]["region"] + "<b></td>";
                            tbl = tbl + "</tr>";
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='1' class='rep_data' align='left' width='3%'><b>" + "&nbsp;" + "<b></td>";
                            tbl = tbl + "<td colspan='13' class='rep_data' align='left' width='97%'><b>" + ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "<b></td>";
                            tbl = tbl + "</tr>";
                            rowcounter = rowcounter + 1;
                        }
                        else
                        {
                            if (find_adcat.IndexOf(ds.Tables[0].Rows[i]["region"].ToString() + ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString()) < 0)
                            {

                                tbl = tbl + ("<tr>");
                                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Category Total:</b></td>");
                                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                                gqtotal = gqtotal + qtotal;
                                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                                gstotal = gstotal + stotal;
                                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                                glinaretotal = glinaretotal + linaretotal;
                                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                                gamttotal = gamttotal + amttotal;
                                tbl = tbl + ("</tr>");
                                qtotal = 0;
                                stotal = 0;
                                linaretotal = 0;
                                amttotal = 0;
                                find_adcat += ds.Tables[0].Rows[i]["region"].ToString() + ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString();
                                if (ds.Tables[0].Rows[i]["region"].ToString() == ds.Tables[0].Rows[i - 1]["region"].ToString())
                                {

                                    tbl = tbl + "<tr>";
                                    tbl = tbl + "<td colspan='1' class='rep_data' align='left' width='3%'><b>" + "&nbsp;" + "<b></td>";
                                    tbl = tbl + "<td colspan='13' class='rep_data' align='left' width='97%'><b>" + ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "<b></td>";
                                    tbl = tbl + "</tr>";
                                    rowcounter = rowcounter + 1;
                                }

                                rowcounter = rowcounter + 1;
                               
                            }

                            if (find_region.IndexOf(ds.Tables[0].Rows[i]["region"].ToString()) < 0)
                            {

                                tbl = tbl + ("<tr>");
                                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Region Total:</b></td>");
                                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
                                gqstotal = gqstotal + gqtotal;
                                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
                                gsstotal = gsstotal + gstotal;
                                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
                                gslinaretotal = gslinaretotal + glinaretotal;
                                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
                                gsamttotal = gsamttotal + gamttotal;
                                tbl = tbl + ("</tr>");
                                gqtotal = 0;
                                gstotal = 0;
                                glinaretotal = 0;
                                gamttotal = 0;
                                find_region += ds.Tables[0].Rows[i]["region"].ToString();

                                tbl = tbl + "<tr>";
                                tbl = tbl + "<td colspan='2' class='rep_data' align='left' width='10%'><b>" + ds.Tables[0].Rows[i]["region"] + "<b></td>";
                                tbl = tbl + "</tr>";
                                tbl = tbl + "<tr>";
                                tbl = tbl + "<td colspan='1' class='rep_data' align='left' width='3%'><b>" + "&nbsp;" + "<b></td>";
                                tbl = tbl + "<td colspan='13' class='rep_data' align='left' width='97%'><b>" + ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "<b></td>";
                                tbl = tbl + "</tr>"; 
                               

                                rowcounter = rowcounter + 3;
                               
                            }
                        }
                    
                  
                            tbl = tbl + ("<tr >");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (sno + "</td>");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["BOOKING_DATE"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                            tbl = tbl + ("<td align='left'class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CITY"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");

                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>");
                            tbl = tbl + ("<td align='left'; class='rep_data'>");
                            tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");

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
                            rowcounter = rowcounter + 2;

                            find_adcat += ds.Tables[0].Rows[i]["region"].ToString() + ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString();
                            find_region += ds.Tables[0].Rows[i]["region"].ToString();
                            sno++;

                        }
                ////last category total
                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Category Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                gqtotal = gqtotal + qtotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                gstotal = gstotal + stotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                glinaretotal = glinaretotal + linaretotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                gamttotal = gamttotal + amttotal;
                tbl = tbl + ("</tr>");
                  
                /////last region total////

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Region Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
                gqstotal = gqstotal + gqtotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
                gsstotal = gsstotal + gstotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
                gslinaretotal = gslinaretotal + glinaretotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
                gsamttotal = gsamttotal + gamttotal;
                tbl = tbl + ("</tr>");

                ///grand total///
                   

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqstotal.ToString()) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gsstotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gslinaretotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gsamttotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("</tr>");
                tbl = tbl + ("</table></p>");

                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }

        }
        else if (reptype == "R")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_rate(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_rate_code_summ";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            string tbl = "";
            double gamt = 0;
            double amt1 = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;

            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Rate Code Wise Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Publish From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Publish To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>No. of Insertion</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='47%'><b>Bill Amount</td></tr>";

                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Rate_code"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["tot_ins"].ToString() != "")
                    {
                        ins = Convert.ToInt16(ds.Tables[0].Rows[i]["tot_ins"]);
                        tbl = tbl + (ins.ToString() + "</td>");
                        totins = totins + ins;
                    }


                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        amt1 = Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);
                        tbl = tbl + (amt1.ToString("F2") + "</td>");
                        gamt = gamt + amt1;
                    }
                    tbl = tbl + "</tr>";
                    sno++;
                }
                tbl = tbl + "<tr>";
                tbl = tbl + ("<td colspan='2' align='left'class='rep_datatotal_vouchdata' width='33%'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  align='left'class='rep_datatotal_vouchdata' width='20%'><b>" + (totins.ToString()) + "</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata' width='47%'><b>" + (gamt.ToString()) + "</b></td>");
                tbl = tbl + "</tr>";
                tbl = tbl + "</table>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }
        else if (reptype == "B")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_bookrate(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_rate_code_book";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            string tbl = "";
            double gamt = 0;
            double amt1 = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 40;
            int rowcounter = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Rate Code Wise Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Booking From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Booking To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>No. of Insertion</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='47%'><b>Bill Amount</td></tr>";

                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Rate_code"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["tot_ins"].ToString() != "")
                    {
                        ins = Convert.ToInt16(ds.Tables[0].Rows[i]["tot_ins"]);
                        tbl = tbl + (ins.ToString() + "</td>");
                        totins = totins + ins;
                    }


                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        amt1 = Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);
                        tbl = tbl + (amt1.ToString("F2") + "</td>");
                        gamt = gamt + amt1;
                    }
                    tbl = tbl + "</tr>";
                    sno++;
                }
                tbl = tbl + "<tr>";
                tbl = tbl + ("<td colspan='2' align='left'class='rep_datatotal_vouchdata' width='33%'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  align='left'class='rep_datatotal_vouchdata' width='20%'><b>" + (totins.ToString()) + "</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata' width='47%'><b>" + (gamt.ToString()) + "</b></td>");
                tbl = tbl + "</tr>";
                tbl = tbl + "</table>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }
        else if (reptype == "A")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_agen(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {

                string procedureName = "rpt_agen_client";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);


            }
            string tbl = "";
            double totbillamt = 0;
            double gbillamt = 0;
            double billamt = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 40;
            int rowcounter = 0;
            pgno = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Ad Recevied From Collection Center Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td colspan='5' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Booking From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Booking To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Name<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Id</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Date</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>Bill Amount</td></tr>";

                }
                pgno++;
                string agcode = "";
                agcode = ds.Tables[0].Rows[0]["Agency_sub_code"].ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        tbl = tbl + "<tr><td colspan='35' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                        pgno++;
                        tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        if (hiddenascdesc.Value == "")
                        {
                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Code<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Name<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Id</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Date</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='17%'><b>Bill Amount</td></tr>";
                        }
                    }
                    if (i == 0)
                    {
                        tbl = tbl + "<tr>";
                        tbl = tbl + "<td  class='rep_data' align='left' width='20%'><b>" + "Agency Name:-" + ds.Tables[0].Rows[i]["agnm"] + "<b></td></tr>";
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (agcode.IndexOf(ds.Tables[0].Rows[i]["Agency_sub_code"].ToString()) < 0)
                        {
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Agency Total" + "<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";
                            gbillamt = gbillamt + totbillamt;
                            agcode += ds.Tables[0].Rows[i]["Agency_sub_code"].ToString();

                            totbillamt = 0;
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td  class='rep_data' align='left' width='20%'><b>" + "Agency Name:-" + ds.Tables[0].Rows[i]["agnm"] + "<b></td></tr>";
                            rowcounter = rowcounter + 2;
                            sno = 1;
                        }
                    }
                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Client_code"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["clientnm"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["booking_dt"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["cio_booking_id"] + "</td>");

                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["Bill_amount"].ToString() != "")
                    {
                        billamt = Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_amount"]);
                        tbl = tbl + (billamt.ToString("F2") + "</td>");
                        totbillamt = totbillamt + billamt;
                    }
                    tbl = tbl + "</tr>";
                    agcode += ds.Tables[0].Rows[i]["Agency_sub_code"].ToString();
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                tbl = tbl + "<tr>";
                tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Agency Total" + "<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";
                gbillamt = gbillamt + totbillamt;


                tbl = tbl + "<tr>";
                tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Grand Total" + "<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", gbillamt) + "<b></td></tr>";

                tbl = tbl + "</table>";
                tbl = tbl + "</table></p>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }


            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }
        else if (reptype == "AS")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_agen(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double totbillamt = 0;
            double gbillamt = 0;
            double billamt = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 40;
            int rowcounter = 0;
            pgno = 1;
            if (ds.Tables[1].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[1].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Ad Recevied From Collection Center Summary Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td colspan='5' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Booking From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Booking To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Agency Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='40%'><b>Agency Name<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Bill Amount</td></tr>";

                }
                pgno++;
                string agcode = "";
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        tbl = tbl + "<tr><td colspan='35' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                        pgno++;
                        tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        if (hiddenascdesc.Value == "")
                        {
                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Agency Code<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='40%'><b>Agency Name<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Bill Amount</td></tr>";
                        }
                    }

                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Agency_sub_code"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["agnm"] + "</td>");



                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[1].Rows[i]["BILL_AMT"].ToString() != "")
                    {
                        billamt = Convert.ToDouble(ds.Tables[1].Rows[i]["BILL_AMT"]);
                        tbl = tbl + (billamt.ToString("F2") + "</td>");
                        totbillamt = totbillamt + billamt;
                    }
                    tbl = tbl + "</tr>";
                    sno++;
                    rowcounter = rowcounter + 1;
                }

                tbl = tbl + "<tr>";
                tbl = tbl + "<td colspan='3' class='rep_datatotal_vouchdata' align='right' width='73%'><b>" + "Grand Total" + "<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";

                tbl = tbl + "</table>";
                tbl = tbl + "</table></p>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }


            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }


        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_last_ins(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double totbillamt = 0;
            double gbillamt = 0;
            double billamt = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 32;
            int rowcounter = 0;
            pgno = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Last Date of Insertion";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td colspan='5' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Last Ins From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Last Ins To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Ad SubCat</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Booking ID<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='6%'><b>Booking Date<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='6%'><b>Last Insertion Date</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Agency Code</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Agency Name</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='10%'><b>Client Code</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Client Name</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Package</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='5%'><b>Rate Code</td></tr>";

                }
                pgno++;
                string adcat = "";
                adcat = ds.Tables[0].Rows[0]["Ad_Cat"].ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        tbl = tbl + "<tr><td colspan='35' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                        pgno++;
                        tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        if (hiddenascdesc.Value == "")
                        {
                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Ad SubCat</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Booking ID<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='6%'><b>Booking Date<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='6%'><b>Last Insertion Date</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Agency Code</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Agency Name</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='10%'><b>Client Code</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Client Name</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Package</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='5%'><b>Rate Code</td></tr>";
                        }
                    }
                    if (i == 0)
                    {
                        tbl = tbl + "<tr>";
                        tbl = tbl + "<td colspan='2' class='rep_data' align='left' width='18%'><b>" + ds.Tables[0].Rows[i]["ad_catnm"] + "<b></td></tr>";
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (adcat.IndexOf(ds.Tables[0].Rows[i]["Ad_Cat"].ToString()) < 0)
                        {

                            adcat += ds.Tables[0].Rows[i]["Ad_Cat"].ToString();


                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='2' class='rep_data' align='left' width='18%'><b>" + ds.Tables[0].Rows[i]["ad_catnm"] + "<b></td></tr>";
                            rowcounter = rowcounter + 1;
                            sno = 1;
                        }
                    }

                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["ad_subcat"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Cio_Booking_Id"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["booking_dt"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["insdate"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Agency_sub_code"] + "</td>");


                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["agnm"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Client_code"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["clientnm"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["package_nm"] + "</td>");


                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Rate_code"] + "</td>");

                    tbl = tbl + "</tr>";
                    sno++;
                    rowcounter = rowcounter + 1;
                    adcat += ds.Tables[0].Rows[i]["Ad_Cat"].ToString();
                }
                //tbl = tbl + "<tr>";
                //tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Agency Total" + "<b></td>";
                //tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";
                //gbillamt = gbillamt + totbillamt;


                //tbl = tbl + "<tr>";
                //tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Grand Total" + "<b></td>";
                //tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", gbillamt) + "<b></td></tr>";

                tbl = tbl + "</table>";
                tbl = tbl + "</table></p>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }


            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }

    }
    public string createheader(DataSet ds)
    {
        string Hearder1 = "";
        string company1 = ds.Tables[0].Rows[0].ItemArray[4].ToString();// Session["centername"].ToString();// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
        string reportname1 = "Category Wise Report";
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
    /////////////////////////////////////
    public string createheader1(DataSet ds)
    {
        string Hearder1 = "";
        //string company1 = Session["centername"].ToString();// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
        string company1 = ds.Tables[0].Rows[0].ItemArray[4].ToString();// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
        string reportname1 = "Category Wise Report";
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
        Hearder1 += "<tr width='100%'><td colspan='3' align='left'style='font-family:Arial;font-size:12px;'><b>Publication Name:</b>" + pub + "</td>";
        Hearder1 += "<td colspan='3' align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
        Hearder1 += "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
        Hearder1 += "<td colspan='4' align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
        string printingname = "";
        if (printingcentername == "" || printingcentername == "0")
        {
            printingname = "All";

        }
        else
        {
            printingname = printingcentername;
        }
        Hearder1 += "<tr width='100%'><td colspan='3' align='left'style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + printingname + "</td>";

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

        Hearder1 += "<td colspan='3' align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

        string Daname = "";
        if (district_name == "" || district_name == "0")
        {
            Daname = "All";

        }
        else
        {
            Daname = district_name;
        }
        Hearder1 += "<td colspan='3'  width='20%'align='left'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td  colspan='2' align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
        Hearder1 += "<tr><td colspan='3' align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
        Hearder1 += "<td colsapn='3' align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td><td  colspan='8' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
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
        double gqtotal = 0;
        double gstotal = 0;
        double glinaretotal = 0;
        double gamttotal = 0;
        double gqstotal = 0;
        double gsstotal = 0;
        double gslinaretotal = 0;
        double gsamttotal = 0;
        if (reptype == "S")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_categorywise_summary_rpt_categorywise_billing";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
                company1 = ds.Tables[0].Rows[0].ItemArray[4].ToString();//Session["centername"].ToString();
            else
                company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
            string reportname1 = "Category Wise Report";
            tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
            tbl = tbl + company1;
            tbl = tbl + "</b></td></tr>";
            tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
            tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
            tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
            tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

            tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

            string Daname = "";
            if (district_name == "" || district_name == null)
            {
                Daname = "All";

            }
            else
            {
                Daname = district_name;
            }
            tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
            tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
            tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";

            tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' style='vertical-align:top'>";
            if (hiddenascdesc.Value == "")
            {
                tbl = tbl + ("<tr width='100%'><td width='20%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td><td class='rep_datatotal_vouchdata'width='20%'><b>Ad Subcategory1</b></td><td  class='rep_datatotal_vouchdata'width='20%'><b>Ad Subcategory2</b></td><td  class='rep_datatotal_vouchdata'  width='10%'><b>No. Of Insertion</b></td><td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Display</b></td><td  class='rep_datatotal_vouchdata' align='right' width='10%'><b>Lineage</b></td><td  class='rep_datatotal_vouchdata'width='250' align='right'><b>Amount(Publication,Audit By Rate,Billed)</b></td></tr>");

            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString() == ds.Tables[0].Rows[i - 1]["AD_MAIN_CAT"].ToString())
                    {
                        tbl = tbl + ("<tr >");
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
                        tbl = tbl + ("<td  colspan='3'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                        gqtotal = gqtotal + qtotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                        gstotal = gstotal + stotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                        glinaretotal = glinaretotal + linaretotal;
                        tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                        gamttotal = gamttotal + amttotal;
                        tbl = tbl + ("</tr>");
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                        tbl = tbl + ("<tr >");
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
                    tbl = tbl + ("<td  colspan='3'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                    gqtotal = gqtotal + qtotal;
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                    gstotal = gstotal + stotal;
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                    glinaretotal = glinaretotal + linaretotal;
                    tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                    gamttotal = gamttotal + amttotal;
                    tbl = tbl + ("</tr>");
                    qtotal = 0;
                    stotal = 0;
                    linaretotal = 0;
                    amttotal = 0;
                }
            }

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td  colspan='3'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
            tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
            tbl = tbl + ("</tr>");

            tbl = tbl + ("</table>");

            tblgrid.InnerHtml += tbl;
        }

        else if (reptype == "D")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_det(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
                string procedureName = "rpt_categorywise_det_rpt_categorywise_billing_det";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
                company1 = ds.Tables[0].Rows[0].ItemArray[4].ToString();// Session["centername"].ToString();
            else
                company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
            string reportname1 = "Category Wise Report";
            tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
            tbl = tbl + company1;
            tbl = tbl + "</b></td></tr>";
            tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
            tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
            tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
            tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

            tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

            string Daname = "";
            if (district_name == "" || district_name == null)
            {
                Daname = "All";

            }
            else
            {
                Daname = district_name;
            }
            tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
            tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>From Date:</b>" + fromdate + "</td>";
            tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";

            tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' style='vertical-align:top'>";
            if (hiddenascdesc.Value == "")
            {
                tbl = tbl + ("<tr width='100%'><td width='8%' class='rep_datatotal_vouchdata'><b>Ad Category</b></td><td class='rep_datatotal_vouchdata'width='8%'><b>Ad Subcategory</b></td><td  class='rep_datatotal_vouchdata'width='8%'><b>Booking Id</b></td><td  class='rep_datatotal_vouchdata'width='15%'><b>Agency Name</b></td><td  class='rep_datatotal_vouchdata'width='12%'><b>Client Code</b></td><td  class='rep_datatotal_vouchdata'width='12%'><b>Client Name</b></td><td  class='rep_datatotal_vouchdata'  width='8%'><b>Rate Code</b></td><td  class='rep_datatotal_vouchdata'  width='8%'><b>No. Of Insertion</b></td><td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Display</b></td><td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Lineage</b></td><td  class='rep_datatotal_vouchdata'width='250' align='right'><b>Amount(Publication,Audit By Rate,Billed)</b></td></tr>");

            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString() == ds.Tables[0].Rows[i - 1]["AD_MAIN_CAT"].ToString())
                    {
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");
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
                        tbl = tbl + ("<td  colspan='7'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                        gqtotal = gqtotal + qtotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                        gstotal = gstotal + stotal;
                        tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                        glinaretotal = glinaretotal + linaretotal;
                        tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                        gamttotal = gamttotal + amttotal;
                        tbl = tbl + ("</tr>");
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");
                        tbl = tbl + ("<td align='left'; class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");
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
                else if (reptype == "D")
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");
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
                    tbl = tbl + ("<td  colspan='7'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                    gqtotal = gqtotal + qtotal;
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                    gstotal = gstotal + stotal;
                    tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                    glinaretotal = glinaretotal + linaretotal;
                    tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                    gamttotal = gamttotal + amttotal;
                    tbl = tbl + ("</tr>");
                    qtotal = 0;
                    stotal = 0;
                    linaretotal = 0;
                    amttotal = 0;
                }
            }

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td  colspan='7'align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
            tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
            tbl = tbl + ("</tr>");

            tbl = tbl + ("</table>");

            tblgrid.InnerHtml += tbl;
        }
        else if (reptype == "R")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_rate(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double gamt = 0;
            double amt1 = 0;
            int sno = 1;
            int ins = 0;
            int totins = 0;
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Rate Code Wise Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Publish From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Publish To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>No. of Insertion</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='47%'><b>Bill Amount</td></tr>";

                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Rate_code"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["tot_ins"].ToString() != "")
                    {
                        ins = Convert.ToInt16(ds.Tables[0].Rows[i]["tot_ins"]);
                        tbl = tbl + (ins.ToString() + "</td>");
                        totins = totins + ins;
                    }


                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        amt1 = Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);
                        tbl = tbl + (amt1.ToString("F2") + "</td>");
                        gamt = gamt + amt1;
                    }
                    tbl = tbl + "</tr>";
                    sno++;
                }
                tbl = tbl + "<tr>";
                tbl = tbl + ("<td colspan='2' align='left'class='rep_datatotal_vouchdata' width='33%'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  align='left'class='rep_datatotal_vouchdata' width='20%'><b>" + (totins.ToString()) + "</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata' width='47%'><b>" + (gamt.ToString()) + "</b></td>");
                tbl = tbl + "</tr>";
                tbl = tbl + "</table>";


            }
            tblgrid.InnerHtml += tbl;
        }
        else if (reptype == "RD")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_det_region(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            else
            {
            }
            int cont = ds.Tables[0].Rows.Count;
            string tbl = "";

            int maxlimit = 30;
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        
            int sno = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                tbl = tbl + "<p ><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string topheader = createheader1(ds);
                tbl = tbl + topheader;
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>AdSubCat</b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>Booking Id</b></td>";
                    tbl = tbl + "<td width='5%' class='rep_datatotal_vouchdata'><b>Booking Date</b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='11%'><b>Agency Name<b></td>";
                    tbl = tbl + "<td width='7%' class='rep_datatotal_vouchdata'><b>City</b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Code<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='10%'><b>Client Name<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Package<b></td>";
                    tbl = tbl + "<td class='rep_datatotal_vouchdata'width='7%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>No.Of<br>Insertions<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Display</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='6%'><b>Lineage</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='7%'><b>Amount(Publication,Audit By Rate,Billed)<b></td></tr>";
                    rowcounter = rowcounter + 1;
                }
                string find_region = "";
                string find_adcat = "";
                find_region = ds.Tables[0].Rows[0]["region"].ToString();
                find_adcat = ds.Tables[0].Rows[0]["AD_MAIN_CAT"].ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                  

                    if (i == 0)
                    {
                        tbl = tbl + "<tr>";
                        tbl = tbl + "<td colspan='2' class='rep_data' align='left' width='10%'><b>" + ds.Tables[0].Rows[i]["region"] + "<b></td>";
                        tbl = tbl + "</tr>";
                        tbl = tbl + "<tr>";
                        tbl = tbl + "<td colspan='1' class='rep_data' align='left' width='3%'><b>" + "&nbsp;" + "<b></td>";
                        tbl = tbl + "<td colspan='13' class='rep_data' align='left' width='97%'><b>" + ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "<b></td>";
                        tbl = tbl + "</tr>";
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (find_adcat.IndexOf(ds.Tables[0].Rows[i]["region"].ToString() + ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString()) < 0)
                        {

                            tbl = tbl + ("<tr>");
                            tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Category Total:</b></td>");
                            tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                            gqtotal = gqtotal + qtotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                            gstotal = gstotal + stotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                            glinaretotal = glinaretotal + linaretotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                            gamttotal = gamttotal + amttotal;
                            tbl = tbl + ("</tr>");
                            qtotal = 0;
                            stotal = 0;
                            linaretotal = 0;
                            amttotal = 0;
                            find_adcat += ds.Tables[0].Rows[i]["region"].ToString() + ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString();
                            if (ds.Tables[0].Rows[i]["region"].ToString() == ds.Tables[0].Rows[i - 1]["region"].ToString())
                            {

                                tbl = tbl + "<tr>";
                                tbl = tbl + "<td colspan='1' class='rep_data' align='left' width='3%'><b>" + "&nbsp;" + "<b></td>";
                                tbl = tbl + "<td colspan='13' class='rep_data' align='left' width='97%'><b>" + ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "<b></td>";
                                tbl = tbl + "</tr>";
                                rowcounter = rowcounter + 1;
                            }

                            rowcounter = rowcounter + 1;

                        }

                        if (find_region.IndexOf(ds.Tables[0].Rows[i]["region"].ToString()) < 0)
                        {

                            tbl = tbl + ("<tr>");
                            tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Region Total:</b></td>");
                            tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
                            gqstotal = gqstotal + gqtotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
                            gsstotal = gsstotal + gstotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
                            gslinaretotal = gslinaretotal + glinaretotal;
                            tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
                            gsamttotal = gsamttotal + gamttotal;
                            tbl = tbl + ("</tr>");
                            gqtotal = 0;
                            gstotal = 0;
                            glinaretotal = 0;
                            gamttotal = 0;
                            find_region += ds.Tables[0].Rows[i]["region"].ToString();

                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='2' class='rep_data' align='left' width='10%'><b>" + ds.Tables[0].Rows[i]["region"] + "<b></td>";
                            tbl = tbl + "</tr>";
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='1' class='rep_data' align='left' width='3%'><b>" + "&nbsp;" + "<b></td>";
                            tbl = tbl + "<td colspan='13' class='rep_data' align='left' width='97%'><b>" + ds.Tables[0].Rows[i]["AD_MAIN_CAT"] + "<b></td>";
                            tbl = tbl + "</tr>";


                            rowcounter = rowcounter + 3;

                        }
                    }


                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AD_SUB_CAT"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["BOOKING_DATE"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AGNAME"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CITY"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT_CODE"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CLIENT"] + "</td>");

                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["EDITION_NAME"] + "</td>");
                    tbl = tbl + ("<td align='left'; class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["rate_code"] + "</td>");

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
                    rowcounter = rowcounter + 2;

                    find_adcat += ds.Tables[0].Rows[i]["region"].ToString() + ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString();
                    find_region += ds.Tables[0].Rows[i]["region"].ToString();
                    sno++;

                }
                ////last category total
                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Category Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (qtotal.ToString()) + "</b></td>");
                gqtotal = gqtotal + qtotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (stotal.ToString("F2")) + "</b></td>");
                gstotal = gstotal + stotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (linaretotal.ToString("F2")) + "</b></td>");
                glinaretotal = glinaretotal + linaretotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (amttotal.ToString("F2")) + "</b></td>");
                gamttotal = gamttotal + amttotal;
                tbl = tbl + ("</tr>");

                /////last region total////

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b>Region Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqtotal.ToString()) + "</b></td>");
                gqstotal = gqstotal + gqtotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gstotal.ToString("F2")) + "</b></td>");
                gsstotal = gsstotal + gstotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (glinaretotal.ToString("F2")) + "</b></td>");
                gslinaretotal = gslinaretotal + glinaretotal;
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gamttotal.ToString("F2")) + "</b></td>");
                gsamttotal = gsamttotal + gamttotal;
                tbl = tbl + ("</tr>");

                ///grand total///


                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td  colspan='10'align='right'class='rep_datatotal_vouchdata'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata'><b>" + (gqstotal.ToString()) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gsstotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gslinaretotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (gsamttotal.ToString("F2")) + "</b></td>");
                tbl = tbl + ("</tr>");
                tbl = tbl + ("</table></p>");

                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }

        }
        else if (reptype == "B")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_rate(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double gamt = 0;
            double amt1 = 0;
            int sno = 1;
            int ins = 0;
            int totins = 0;
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Rate Code Wise Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Booking From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Booking To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Rate Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>No. of Insertion</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='47%'><b>Bill Amount</td></tr>";

                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Rate_code"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["tot_ins"].ToString() != "")
                    {
                        ins = Convert.ToInt16(ds.Tables[0].Rows[i]["tot_ins"]);
                        tbl = tbl + (ins.ToString() + "</td>");
                        totins = totins + ins;
                    }


                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        amt1 = Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);
                        tbl = tbl + (amt1.ToString("F2") + "</td>");
                        gamt = gamt + amt1;
                    }
                    tbl = tbl + "</tr>";
                    sno++;
                }
                tbl = tbl + "<tr>";
                tbl = tbl + ("<td colspan='2' align='left'class='rep_datatotal_vouchdata' width='33%'><b> Grand Total:</b></td>");
                tbl = tbl + ("<td  align='left'class='rep_datatotal_vouchdata' width='20%'><b>" + (totins.ToString()) + "</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata' width='47%'><b>" + (gamt.ToString()) + "</b></td>");
                tbl = tbl + "</tr>";
                tbl = tbl + "</table>";


            }
            tblgrid.InnerHtml += tbl;
        }

        else if (reptype == "A")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_agen(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double totbillamt = 0;
            double gbillamt = 0;
            double billamt = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 40;

            pgno = 1;
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Ad Recevied From Collection Center Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td colspan='5' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Booking From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Booking To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Name<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Id</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Date</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>Bill Amount</td></tr>";

                }
                pgno++;
                string agcode = "";
                agcode = ds.Tables[0].Rows[0]["Agency_sub_code"].ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        tbl = tbl + "<tr><td colspan='35' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                        pgno++;
                        tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        if (hiddenascdesc.Value == "")
                        {
                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Code<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Client Name<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Id</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='20%'><b>Booking Date</td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='17%'><b>Bill Amount</td></tr>";
                        }
                    }
                    if (i == 0)
                    {
                        tbl = tbl + "<tr>";
                        tbl = tbl + "<td  class='rep_data' align='left' width='20%'><b>" + "Agency Name:-" + ds.Tables[0].Rows[i]["agnm"] + "<b></td></tr>";
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (agcode.IndexOf(ds.Tables[0].Rows[i]["Agency_sub_code"].ToString()) < 0)
                        {
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Agency Total" + "<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";
                            gbillamt = gbillamt + totbillamt;
                            agcode += ds.Tables[0].Rows[i]["Agency_sub_code"].ToString();

                            totbillamt = 0;
                            tbl = tbl + "<tr>";
                            tbl = tbl + "<td  class='rep_data' align='left' width='20%'><b>" + "Agency Name:-" + ds.Tables[0].Rows[i]["agnm"] + "<b></td></tr>";
                            rowcounter = rowcounter + 2;
                            sno = 1;
                        }
                    }
                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Client_code"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["clientnm"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["booking_dt"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["cio_booking_id"] + "</td>");

                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[0].Rows[i]["Bill_amount"].ToString() != "")
                    {
                        billamt = Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_amount"]);
                        tbl = tbl + (billamt.ToString("F2") + "</td>");
                        totbillamt = totbillamt + billamt;
                    }
                    tbl = tbl + "</tr>";
                    agcode += ds.Tables[0].Rows[i]["Agency_sub_code"].ToString();
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                tbl = tbl + "<tr>";
                tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Agency Total" + "<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";
                gbillamt = gbillamt + totbillamt;


                tbl = tbl + "<tr>";
                tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Grand Total" + "<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", gbillamt) + "<b></td></tr>";

                tbl = tbl + "</table>";
                tbl = tbl + "</table></p>";
                tblgrid.InnerHtml = tbl;

            }


            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }
        else if (reptype == "AS")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_main_agen(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double totbillamt = 0;
            double gbillamt = 0;
            double billamt = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 40;

            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            pgno = 1;
            if (ds.Tables[1].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[1].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Ad Recevied From Collection Center Summary Report";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td colspan='5' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Booking From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><b>Booking To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Agency Code<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='40%'><b>Agency Name<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Bill Amount</td></tr>";

                }
                pgno++;
                string agcode = "";
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        tbl = tbl + "</table></p>";
                        rowcounter = 0;
                        tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        tbl = tbl + "<tr><td colspan='35' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                        pgno++;
                        tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                        if (hiddenascdesc.Value == "")
                        {
                            tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='30%'><b>Agency Code<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='40%'><b>Agency Name<b></td>";
                            tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>Bill Amount</td></tr>";
                        }
                    }

                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Agency_sub_code"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["agnm"] + "</td>");



                    tbl = tbl + ("<td align='right'class='rep_data'>");
                    if (ds.Tables[1].Rows[i]["BILL_AMT"].ToString() != "")
                    {
                        billamt = Convert.ToDouble(ds.Tables[1].Rows[i]["BILL_AMT"]);
                        tbl = tbl + (billamt.ToString("F2") + "</td>");
                        totbillamt = totbillamt + billamt;
                    }
                    tbl = tbl + "</tr>";
                    sno++;
                    rowcounter = rowcounter + 1;
                }

                tbl = tbl + "<tr>";
                tbl = tbl + "<td colspan='3' class='rep_datatotal_vouchdata' align='right' width='73%'><b>" + "Grand Total" + "<b></td>";
                tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='27%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";

                tbl = tbl + "</table>";
                tbl = tbl + "</table></p>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }


            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }


        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
                ds = obj.ctreport_last_ins(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    fromdate = DMYToMDY(fromdate);
                //    dateto = DMYToMDY(dateto);
                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    fromdate = YMDToMDY(fromdate);
                //    dateto = YMDToMDY(dateto);
                //}

                NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
                ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

            }
            string tbl = "";
            double totbillamt = 0;
            double gbillamt = 0;
            double billamt = 0;
            int ins = 0;
            int totins = 0;
            int sno = 1;
            int maxlimit = 32;


            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            pgno = 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

                string company1 = "";
                tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                if (ds.Tables[0].Rows.Count > 0)
                    company1 = Session["centername"].ToString();
                else
                    company1 = "Hindustan Times";// "SHREE AMBIKA PRINTERS & PUBLICATIONS";
                string reportname1 = "Last Date of Insertion";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
                tbl = tbl + company1;
                tbl = tbl + "</b></td></tr>";
                tbl = tbl + "<tr><td align='center'colspan='7' style='padding-right:140px'><b> ";
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
                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Edition Name:</b>" + edi + "</td>";
                tbl = tbl + "<td  colspan='3'align='left'style='font-family:Arial;font-size:12px;'><b>Team Name:</b>" + team + "</td>";
                tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Executive Name:</b>" + ece + "</td></tr>";
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

                tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td>";

                string Daname = "";
                if (district_name == "" || district_name == null)
                {
                    Daname = "All";

                }
                else
                {
                    Daname = district_name;
                }
                tbl = tbl + "<td  width='100'colsapn='30'align='center'style='font-family:Arial;font-size:12px;'><b>District Name:</b>" + Daname + "</td><td colspan='5' width='100'align='right'style='font-family:Arial;font-size:12px;'><b>Page No:</b>" + pgno + "</td></tr>";
                tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;'><b>Last Ins From Date:</b>" + fromdate + "</td>";
                tbl = tbl + "<td colsapn='30' align='left'style='font-family:Arial;font-size:12px;'><bLast Ins To Date:</b>" + dateto + "</td><td  colspan='5' align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
                //string topheader = createheader1(ds);
                //tbl = tbl + topheader;
                tbl = tbl + "</table>";
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                if (hiddenascdesc.Value == "")
                {

                    tbl = tbl + "<tr ><td width='3%' class='rep_datatotal_vouchdata'><b>S.No.</b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Ad SubCat</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Booking ID<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='6%'><b>Booking Date<b></td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='6%'><b>Last Insertion Date</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Agency Code</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Agency Name</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='10%'><b>Client Code</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='15%'><b>Client Name</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='8%'><b>Package</td>";
                    tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='left' width='5%'><b>Rate Code</td></tr>";

                }
                pgno++;
                string agcode = "";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    tbl = tbl + "<tr>";
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (sno + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Cio_Booking_Id"] + "</td>");
                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["booking_dt"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["insdate"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Agency_sub_code"] + "</td>");


                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["agnm"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Client_code"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["clientnm"] + "</td>");

                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["ad_cat"] + "</td>");


                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["ad_subcat"] + "</td>");


                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["package_nm"] + "</td>");



                    tbl = tbl + ("<td align='left'class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Rate_code"] + "</td>");

                    tbl = tbl + "</tr>";
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                //tbl = tbl + "<tr>";
                //tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Agency Total" + "<b></td>";
                //tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", totbillamt) + "<b></td></tr>";
                //gbillamt = gbillamt + totbillamt;


                //tbl = tbl + "<tr>";
                //tbl = tbl + "<td colspan='5' class='rep_datatotal_vouchdata' align='right' width='80%'><b>" + "Grand Total" + "<b></td>";
                //tbl = tbl + "<td  class='rep_datatotal_vouchdata' align='right' width='20%'><b>" + string.Format("{0:0.00}", gbillamt) + "<b></td></tr>";

                tbl = tbl + "</table>";
                tbl = tbl + "</table></p>";
                tblgrid.InnerHtml = tbl;
                dynamictable.Text = dytbl;
            }


            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
        }

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

        double gqtotal = 0;
        double gstotal = 0;
        double gamttotal = 0;
        double glinaretotal = 0;
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
            ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{
            //    fromdate = DMYToMDY(fromdate);
            //    dateto = DMYToMDY(dateto);
            //}
            //else if (hiddendateformat.Value == "yyyy/mm/dd")
            //{
            //    fromdate = YMDToMDY(fromdate);
            //    dateto = YMDToMDY(dateto);
            //}

            NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
            ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode, agency_name);

        }
        else
        {
            string procedureName = "rpt_categorywise_summary_rpt_categorywise_billing";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
            tbl1.addCell(new Phrase(Session["centername"].ToString(), font1));
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
            tbl2.addCell(new Phrase("Categort Wise Report".ToString(), font3));
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



            PdfPTable datatable111 = new PdfPTable(7);
            float[] headerwidths = { 15, 15, 15, 10, 15, 15, 20 };// percentage
            datatable111.setWidths(headerwidths);
            datatable111.WidthPercentage = 100; // percentage
            datatable111.DefaultCell.BorderWidth = 0;
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

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

            PdfPTable tb897 = new PdfPTable(7);
            tb897.DefaultCell.Colspan = 7;
            tb897.DefaultCell.BorderWidth = 0;
            tb897.WidthPercentage = 100;
            tb897.addCell(new Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
            document.Add(tb897);
            PdfPTable datatable = new PdfPTable(7);
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


                datatable.DefaultCell.BorderWidth = 0;
                float[] abhg = { 15, 15, 15, 10, 15, 15, 20 };// percentage
                datatable.setWidths(abhg);
                datatable.WidthPercentage = 100;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["AD_MAIN_CAT"].ToString() == ds.Tables[0].Rows[i - 1]["AD_MAIN_CAT"].ToString())
                    {

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
                        datatable.DefaultCell.Colspan = 7;
                        datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                        datatable.DefaultCell.Colspan = 3;
                        datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        datatable.addCell(new iTextSharp.text.Phrase("Total:", font3));
                        datatable.DefaultCell.Colspan = 1;
                        datatable.addCell(new iTextSharp.text.Phrase(qtotal.ToString(), font3));
                        gqtotal = gqtotal + qtotal;
                        //datatable.DefaultCell.Colspan = 1;                      
                        datatable.addCell(new iTextSharp.text.Phrase(stotal.ToString("F2"), font3));
                        gstotal = gstotal + stotal;
                        datatable.addCell(new iTextSharp.text.Phrase(linaretotal.ToString("F2"), font3));
                        glinaretotal = glinaretotal + linaretotal;
                        datatable.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font3));
                        gamttotal = gamttotal + amttotal;
                        datatable.DefaultCell.Colspan = 7;
                        qtotal = 0;
                        stotal = 0;
                        linaretotal = 0;
                        amttotal = 0;
                        datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                        rowcounter23 = rowcounter23 + 4;
                        datatable.DefaultCell.Colspan = 1;
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

                    datatable.DefaultCell.Colspan = 7;
                    datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
                    datatable.DefaultCell.Colspan = 3;
                    datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    datatable.addCell(new iTextSharp.text.Phrase("Total:", font3));
                    datatable.DefaultCell.Colspan = 1;
                    datatable.addCell(new iTextSharp.text.Phrase(qtotal.ToString(), font3));
                    gqtotal = gqtotal + qtotal;
                    //datatable.DefaultCell.Colspan = 1;                      
                    datatable.addCell(new iTextSharp.text.Phrase(stotal.ToString("F2"), font3));
                    gstotal = gstotal + stotal;
                    datatable.addCell(new iTextSharp.text.Phrase(linaretotal.ToString("F2"), font3));
                    glinaretotal = glinaretotal + linaretotal;
                    datatable.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font3));
                    gamttotal = gamttotal + amttotal;
                    datatable.DefaultCell.Colspan = 7;
                    qtotal = 0;
                    stotal = 0;
                    linaretotal = 0;
                    amttotal = 0;
                    datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));

                }



                document.Add(datatable);

            }

            datatable.DefaultCell.Colspan = 7;
            datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));
            datatable.DefaultCell.Colspan = 3;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.addCell(new iTextSharp.text.Phrase("Total:", font3));
            datatable.DefaultCell.Colspan = 1;
            datatable.addCell(new iTextSharp.text.Phrase(qtotal.ToString(), font3));

            datatable.addCell(new iTextSharp.text.Phrase(stotal.ToString("F2"), font3));
            datatable.addCell(new iTextSharp.text.Phrase(linaretotal.ToString("F2"), font3));
            datatable.addCell(new iTextSharp.text.Phrase(amttotal.ToString("F2"), font3));
            datatable.DefaultCell.Colspan = 7;
            datatable.addCell(new iTextSharp.text.Phrase("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font3));


            document.Close();
            Response.Redirect(pdfName);
        }

        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }

}
