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


public partial class Reports_allagencysummary : System.Web.UI.Page
{
    string agency = "";
    string client = "";
    string package = "";
    int maxlimit = 13;
    string agname = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string branch = "";
    string adcatname = "";
    string agencyname = "";
    string agencyname1 = "";
    string agencysubcode1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    double area = 0;
    int i1 = 0;
    double amt = 0;
    string sortorder = "";
    string sortvalue = "", agtype = "", agtypetext = "";

    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    double rowcounter = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    DataSet ds;

    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        ds = (DataSet)Session["allagency"];

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hddateformat.Value = Session["dateformat"].ToString();
        }


        string prm = Session["prm_allagency"].ToString();
        string[] prm_Array = new string[37];
        prm_Array = prm.Split('~');


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/allagencysummary.xml"));
        //  heading.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();



        agname = prm_Array[1];//Request.QueryString["agname"].ToString();
        adtyp = prm_Array[3]; //Request.QueryString["adtype"].ToString();
        adcat = prm_Array[5]; //Request.QueryString["adcategory"].ToString();
        fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();

        pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();

        edition = prm_Array[19]; //Request.QueryString["edition"].ToString();
        destination = prm_Array[21]; //Request.QueryString["destination"].ToString();
        adcatname = prm_Array[23]; //Request.QueryString["adcatname"].ToString();
        agencyname1 = prm_Array[25]; //Request.QueryString["agencyname"].ToString();
        adtypename = prm_Array[27]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[29]; //Request.QueryString["editionname"].ToString();
        agencysubcode1 = prm_Array[31]; //Request.QueryString["agencysubcode"].ToString();
        agtype = prm_Array[33]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[35]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[37];
        branch = prm_Array[39];
        // string dateformat = Request.QueryString["dateformat"].ToString();
        //if (agtype == "0")
        //{
        //    lblagtype.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lblagtype.Text = agtypetext.ToString();
        //}
        //if (publ == "0")
        //{
        //    lblpub.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lblpub.Text = pubcname.ToString();
        //}
        //if (pubcen == "0")
        //{
        //    pcenter.Text = "ALL".ToString();
        //}
        //else
        //{
        //    pcenter.Text = pub2.ToString();
        //}

        //if (adtyp == "0")
        //{
        //    lbladtype.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lbladtype.Text = adtypename.ToString();
        //}

        //if ((adcat == "0") || (adcat == ""))
        //{
        //    lbladcat.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lbladcat.Text = adcatname.ToString();
        //}



        //if (edition == "0" || edition == "")
        //{
        //    lbedition.Text = "ALL".ToString();
        //}
        //else
        //{
        //    lbedition.Text = editionname.ToString();


        //}


        if (fromdt != "")
        {

            if (hddateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                datefrom1 = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hddateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = day + "/" + month + "/" + year;


                }
                else if (hddateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = month + "/" + day + "/" + year;

                }
                else if (hddateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = year + "/" + month + "/" + day;
                }
            }
        }
        //lblfrom.Text = datefrom1;
        //dateto1 = "";
        if (dateto != "")
        {





            ///////////


            if (hddateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto1 = dd + "/" + mm + "/" + yy;

            }


        ////////////

            else
            {

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hddateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = day + "/" + month + "/" + year;

                }
                else if (hddateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = month + "/" + day + "/" + year;

                }
                else if (hddateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = year + "/" + month + "/" + day;
                }
            }
        }
        //lblto.Text = dateto1;


        if (hddateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

        }
        else
            if (hddateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (hddateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                }

        //lbldate.Text = date.ToString();

        //if (agencysubcode1 == "true")
        //{
        //    lblAgencyCode.Visible = true;
        //    lblAgencyCode.Text = "All".ToString();
        //    aaa.Visible = true;

        //}
        //else
        //{
        //    lblAgencyCode.Visible = false;
        //    // lblAgencyCode.Text = "All".ToString();
        //    aaa.Visible = false;




        //}
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

            }
            //else
            //    if (destination == "3")
            //    {
            //        pdf(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            //    }
        }

    }

    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        string cmpnyname;

        if (ds.Tables[0].Rows.Count > 0)
        {
            cmpnyname = ds.Tables[0].Rows[0]["companyname"].ToString();

        }
        else
        {

            cmpnyname = "Rajasthan Patrika Pvt Ltd";
        }
        int sno1 = 0;
        string tbl = "";
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/allagencysummary.xml"));
        tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr class='headingc'><td colspan='12' align='center'>" + cmpnyname + "</td></tr>";
        tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[17].ToString() + "</td></tr>";
        tbl += "<tr class='middle33'><td colspan='12' align='left'>" + ds1.Tables[0].Rows[0].ItemArray[0].ToString() + "" + datefrom1 + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + "" + dateto1 + "</td></tr>";
        if (agencyname1 != "")
        {
            tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["AGENCY_NAME"].ToString() + "  " + ds.Tables[0].Rows[0]["ADD1"].ToString() + ds.Tables[0].Rows[0]["ADD2"].ToString() + ds.Tables[0].Rows[0]["ADD3"].ToString() + "</td></tr>";
        }
        tbl += "</table>";
        tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr><td  class='middle31new' width='4%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='12%'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='15%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='6%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='6%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='6%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='12%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td></tr>";

        tbl += "<tr font-size='10' font-family='Arial'>";
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (agencyname1 == "")
            {
                tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                tbl += ds.Tables[0].Rows[0]["AGENCY_NAME"].ToString() + "</b></td></tr>";
            }
        }
        double total = 0;
        double totalarea = 0;
        double totalwords = 0;
        for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
        {
            if (rowcounter == maxlimit)
            {
                maxlimit = 14;
                rowcounter = 0;
                tbl += "</table><p>";
                tbl += "</br>";
                tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                tbl += "</table><p>";

                tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                tbl += "<tr><td  class='middle31new' width='4%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='12%'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='15%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='6%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='6%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='6%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='12%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td></tr>";

            }

            totalarea = totalarea + Convert.ToDouble(ds.Tables[0].Rows[p]["Area"].ToString());
            totalwords = totalwords + Convert.ToDouble(ds.Tables[0].Rows[p]["Words"].ToString());
            sno1++;
            if (agencyname == "")
            {
                agencyname = ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString();
            }
            else
            {

                agencyname = ds.Tables[0].Rows[p - 1]["AGENCY_NAME"].ToString();

            }
            if (ds.Tables[0].Rows[sno1 - 1]["AGENCY_NAME"].ToString() == agencyname)
            {



                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='4%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data'  width='12%'>";
                tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                tbl += "<td class='rep_data'  width='6%' align='center'>";
                if (ds.Tables[0].Rows[p]["Depth"].ToString() == "" || ds.Tables[0].Rows[p]["Depth"].ToString() == null)
                {
                    if (ds.Tables[0].Rows[p]["Words"].ToString() == "" || ds.Tables[0].Rows[p]["Words"].ToString() == null)
                    {
                        tbl += "--" + "</td>";
                    }
                    else
                    {
                        tbl += ds.Tables[0].Rows[p]["Words"].ToString() + " " + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                    }
                }
                else
                {
                    tbl += ds.Tables[0].Rows[p]["Depth"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                }
                tbl += "<td class='rep_data' width='15%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='6%'align='right'>";
                if (ds.Tables[0].Rows[p]["CardRate"].ToString() == "" || ds.Tables[0].Rows[p]["CardRate"].ToString() == null)
                    tbl += "--" + "</td>";
                else
                    tbl += ds.Tables[0].Rows[p]["CardRate"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'align='right'>";
                if (ds.Tables[0].Rows[p]["AgreedRate"].ToString() == "" || ds.Tables[0].Rows[p]["AgreedRate"].ToString() == null || ds.Tables[0].Rows[p]["AgreedRate"].ToString() == "0")
                    tbl += "--" + "</td>";
                else
                    tbl += ds.Tables[0].Rows[p]["AgreedRate"].ToString() + "</td>";


                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                    tbl += "--" + "</td>";
                else
                    tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                tbl += "<td class='rep_data' width='6%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["Amt"].ToString() != "")
                    total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());

                tbl += "<td class='rep_data' width='12%'  align='right'>";
                tbl += ds.Tables[0].Rows[p]["RoNo."].ToString() + "</td>";


                tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Disc"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["Cap"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                tbl += ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td></tr>";
            }
            else
            {
                if (agencyname1 == "")
                {
                    tbl += "<tr font-size='10' font-family='Arial'>";
                    tbl += "<td style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'  align='left' colspan='7'><b>";
                    tbl += ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</b></td></tr>";
                }
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='4%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data'  width='12%'>";
                tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                tbl += "<td class='rep_data'  width='6%' align='center'>";
                if (ds.Tables[0].Rows[p]["Depth"].ToString() == "" || ds.Tables[0].Rows[p]["Depth"].ToString() == null)
                {
                    if (ds.Tables[0].Rows[p]["Words"].ToString() == "" || ds.Tables[0].Rows[p]["Words"].ToString() == null)
                    {
                        tbl += "--" + "</td>";
                    }
                    else
                    {
                        tbl += ds.Tables[0].Rows[p]["Words"].ToString() + " " + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                    }
                }
                else
                {
                    tbl += ds.Tables[0].Rows[p]["Depth"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                }
                tbl += "<td class='rep_data' width='15%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='6%'align='right'>";
                if (ds.Tables[0].Rows[p]["CardRate"].ToString() == "" || ds.Tables[0].Rows[p]["CardRate"].ToString() == null)
                    tbl += "--" + "</td>";
                else
                    tbl += ds.Tables[0].Rows[p]["CardRate"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'align='right'>";
                if (ds.Tables[0].Rows[p]["AgreedRate"].ToString() == "" || ds.Tables[0].Rows[p]["AgreedRate"].ToString() == null || ds.Tables[0].Rows[p]["AgreedRate"].ToString() == "0")
                    tbl += "--" + "</td>";
                else
                    tbl += ds.Tables[0].Rows[p]["AgreedRate"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                    tbl += "--" + "</td>";
                else
                    tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                tbl += "<td class='rep_data' width='6%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["Amt"].ToString() != "")
                    total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());

                tbl += "<td class='rep_data' width='12%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["RoNo."].ToString() + "</td>";



                tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                tbl += "<td class='rep_data'  align='left' colspan='2' width='16%'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Disc"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2' width='21%'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["Cap"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2' width='16%'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='7' width='38%'>Remark:";
                tbl += ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td></tr>";

            }


            rowcounter++;

        }

        tbl += "<tr width='50%'>";
        tbl += "<td class='middle31new'  colspan='1'  align='right'>";
        tbl += ds1.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
        tbl += "<td class='middle31new'    align='right'>";
        tbl += "" + "</td>";
        tbl += "<td class='middle31new'    align='right'>";
        tbl += ds1.Tables[0].Rows[0].ItemArray[15].ToString() + ":" + string.Format("{0:0.00}", totalarea) + "</td>";
        tbl += "<td class='middle31new'   align='right'>";
        tbl += ds1.Tables[0].Rows[0].ItemArray[16].ToString() + ":" + string.Format("{0:0.00}", totalwords) + "</td>";
        tbl += "<td class='middle31new'  colspan='4'  align='right'>";
        tbl += "" + "</td>";
        tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", total) + "</td>";
        tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


        tbl += "</tr>";


        tbl += "</table></p>";

        report.InnerHtml = tbl;
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

    private void excel(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        string cmpnyname;

        if (ds.Tables[0].Rows.Count > 0)
        {
            cmpnyname = ds.Tables[0].Rows[0]["companyname"].ToString();

        }
        else
        {

            cmpnyname = "Rajasthan Patrika Pvt Ltd";
        }

        int sno1 = 0;
        string tbl = "";
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/allagencysummary.xml"));
        tbl = "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr class='headingc'><td colspan='12' align='center'>" + cmpnyname + "</td></tr>";
        tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[17].ToString() + "</td></tr>";
        tbl += "<tr class='middle33'><td colspan='12' align='left'>" + ds1.Tables[0].Rows[0].ItemArray[0].ToString() + "" + datefrom1 + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + "" + dateto1 + "</td></tr>";
        if (agencyname1 != "")
        {
            tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["AGENCY_NAME"].ToString() + "  " + ds.Tables[0].Rows[0]["ADD1"].ToString() + ds.Tables[0].Rows[0]["ADD2"].ToString() + ds.Tables[0].Rows[0]["ADD3"].ToString() + "</td></tr>";
        }
        tbl += "</table>";
        tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr><td  class='middle31new' width='4%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='12%'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='15%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='6%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='10%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='6%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='12%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td></tr>";

        tbl += "<tr font-size='10' font-family='Arial'>";

        tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'><b> ";
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (agencyname1 == "")
            {
                tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                tbl += ds.Tables[0].Rows[0]["AGENCY_NAME"].ToString() + "</b></td></tr>";
            }
        }
        double total = 0;
        double totalarea = 0;
        double totalwords = 0;
        for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
        {


            totalarea = totalarea + Convert.ToDouble(ds.Tables[0].Rows[p]["Area"].ToString());
            totalwords = totalwords + Convert.ToDouble(ds.Tables[0].Rows[p]["Words"].ToString());
            sno1++;
            if (agencyname == "")
            {
                agencyname = ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString();
            }
            else
            {

                agencyname = ds.Tables[0].Rows[p - 1]["AGENCY_NAME"].ToString();

            }
            if (ds.Tables[0].Rows[sno1 - 1]["AGENCY_NAME"].ToString() == agencyname)
            {



                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='4%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data'  width='12%'>";
                tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                tbl += "<td class='rep_data'  width='6%' align='center'>";
                if (ds.Tables[0].Rows[p]["Depth"].ToString() == "" || ds.Tables[0].Rows[p]["Depth"].ToString() == null)
                {
                    if (ds.Tables[0].Rows[p]["Words"].ToString() == "" || ds.Tables[0].Rows[p]["Words"].ToString() == null)
                    {
                        tbl += "--" + "</td>";
                    }
                    else
                    {
                        tbl += ds.Tables[0].Rows[p]["Words"].ToString() + " " + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                    }
                }
                else
                {
                    tbl += ds.Tables[0].Rows[p]["Depth"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                }
                tbl += "<td class='rep_data' width='15%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='6%'align='right'>";
                if (ds.Tables[0].Rows[p]["AgreedRate"].ToString() == "" || ds.Tables[0].Rows[p]["AgreedRate"].ToString() == null)
                    tbl += ds.Tables[0].Rows[p]["CardRate"].ToString() + "</td>";
                else
                    tbl += ds.Tables[0].Rows[p]["AgreedRate"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                    tbl += "--" + "</td>";
                else
                    tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                tbl += "<td class='rep_data' width='6%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>";
                total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());

                tbl += "<td class='rep_data' width='12%'  align='right'>";
                tbl += ds.Tables[0].Rows[p]["RoNo."].ToString() + "</td>";


                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Disc"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["Cap"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                tbl += ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td></tr>";
            }
            else
            {
                if (agencyname1 == "")
                {
                    tbl += "<tr font-size='10' font-family='Arial'>";
                    tbl += "<td style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'  align='left' colspan='7'><b>";
                    tbl += ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</b></td></tr>";
                }
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='4%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data'  width='12%'>";
                tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                tbl += "<td class='rep_data'  width='6%' align='center'>";
                if (ds.Tables[0].Rows[p]["Depth"].ToString() == "" || ds.Tables[0].Rows[p]["Depth"].ToString() == null)
                {
                    if (ds.Tables[0].Rows[p]["Words"].ToString() == "" || ds.Tables[0].Rows[p]["Words"].ToString() == null)
                    {
                        tbl += "--" + "</td>";
                    }
                    else
                    {
                        tbl += ds.Tables[0].Rows[p]["Words"].ToString() + " " + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                    }
                }
                else
                {
                    tbl += ds.Tables[0].Rows[p]["Depth"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + ds.Tables[0].Rows[p]["uom"].ToString() + "</td>";
                }
                tbl += "<td class='rep_data' width='15%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='6%'align='right'>";
                if (ds.Tables[0].Rows[p]["AgreedRate"].ToString() == "" || ds.Tables[0].Rows[p]["AgreedRate"].ToString() == null)
                    tbl += ds.Tables[0].Rows[p]["CardRate"].ToString() + "</td>";
                else
                    tbl += ds.Tables[0].Rows[p]["AgreedRate"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='10%' align='center'>";
                if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                    tbl += "--" + "</td>";
                else
                    tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                tbl += "<td class='rep_data' width='6%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>";
                total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());
                tbl += "<td class='rep_data' width='12%' align='right'>";
                tbl += ds.Tables[0].Rows[p]["RoNo."].ToString() + "</td>";



                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Disc"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["Cap"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='2'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                tbl += ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td></tr>";

            }


            rowcounter++;

        }

        tbl += "<tr width='50%'>";
        tbl += "<td class='middle31new'  colspan='1'  align='right'>";
        tbl += ds1.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
        tbl += "<td class='middle31new'    align='right'>";
        tbl += ds1.Tables[0].Rows[0].ItemArray[15].ToString() + ":" + string.Format("{0:0.00}", totalarea) + "</td>";
        tbl += "<td class='middle31new'    align='right'>";
        tbl += "" + "</td>";
        tbl += "<td class='middle31new'   align='right'>";
        tbl += ds1.Tables[0].Rows[0].ItemArray[16].ToString() + ":" + string.Format("{0:0.00}", totalwords) + "</td>";
        tbl += "<td class='middle31new'  colspan='4'  align='right'>";
        tbl += "" + "</td>";
        tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", total) + "</td>";
        tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


        tbl += "</tr>";


        tbl += "</table></p>";




        report.InnerHtml = tbl;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteBreak();
        report.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }
}
