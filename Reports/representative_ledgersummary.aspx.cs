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


public partial class Reports_representative_ledgersummary : System.Web.UI.Page
{

    string agency = "";
    string client = "";
    string package = "";
    int maxlimit = 11;
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
    string val_chk = "";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    double rowcounter = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    string execut = "";
    DataSet ds;

    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    string team = "";
    string bill="";
    string cl = "";
        string ag="";
    string  retainercode="";
     string   retainername =""; 
     string   rep ="";
      string  pubcentname =""; 
   
      string  districtname = "";
      string  branchname = "";
     
       string branch = "";
        string district = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = (DataSet)Session["repledger"];

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hddateformat.Value = Session["dateformat"].ToString();
        }


        string prm = Session["prm_repledger"].ToString();
        string[] prm_Array = new string[37];
        prm_Array = prm.Split('~');


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/representativsummary.xml"));
        //  heading.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();




        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcen = prm_Array[7]; //Request.QueryString["pubcent"].ToString();
        publ = prm_Array[9]; //Request.QueryString["publication"].ToString();
        pubcname = prm_Array[11]; //Request.QueryString["publicationname"].ToString();
        adtyp = prm_Array[13]; //Request.QueryString["adtyp"].ToString();
        val_chk = prm_Array[15]; //Request.QueryString["value"].ToString();
        execut = prm_Array[17]; //Request.QueryString["execut"].Trim().ToString();
        team = prm_Array[19]; //Request.QueryString["team"].Trim().ToString();
        bill = prm_Array[21]; //Request.QueryString["bill"].Trim().ToString();
        cl = prm_Array[23]; //Request.QueryString["cl"].Trim().ToString();
        ag = prm_Array[25]; //Request.QueryString["ag"].Trim().ToString();
        retainercode = prm_Array[27]; //Request.QueryString["retainercode"].Trim().ToString();
        retainername = prm_Array[29]; //Request.QueryString["retainername"].Trim().ToString();
        rep = prm_Array[31]; //Request.QueryString["rep"].Trim().ToString();
        pubcentname = prm_Array[33]; //Request.QueryString["pubcentname"].Trim().ToString();
        adtypename = prm_Array[35]; //Request.QueryString["adtypename"].Trim().ToString();
        districtname = prm_Array[39];
        branchname = prm_Array[41];
        chk_excel = prm_Array[37];
        branch = prm_Array[39];
        district = prm_Array[43];

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


        int sno1 = 0;
        string tbl = "";
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/representativsummary.xml"));
        tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</td></tr>";
        if (rep == "1")
        {
            if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
            {
                tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[17].ToString() + "</td></tr>";
                tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[0].ToString() + "" + datefrom1 + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + "" + dateto1 + "</td></tr>";
            }
        }
        else
        {
            tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[23].ToString() + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[22].ToString() + "" + datefrom1 + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + "" + dateto1 + "</td></tr>";
        }
        if (rep == "1")
        {
            if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
            {
                if (execut != "")
                {
                    tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["Executive"].ToString()+"," + ds.Tables[0].Rows[0]["ExecutiveCity"].ToString() + "</td></tr>";
                }
            }
        }
        else
        {

            if (retainername != "")
            {
                tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["Retainer"].ToString()+ "," + ds.Tables[0].Rows[0]["Retainercity"].ToString() + /*"  " + ds.Tables[0].Rows[0]["ADD1"].ToString() + ds.Tables[0].Rows[0]["ADD2"].ToString() + ds.Tables[0].Rows[0]["ADD3"].ToString() + */"</td></tr>";
            }
        }
        tbl += "</table>";
        tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr><td  class='middle31new' width='3%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='14%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='9%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='10%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td></tr>";

        tbl += "<tr font-size='10' font-family='Arial'>";
        if (rep == "1")
        {
            if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
            {
                if (execut == "")
                {
                    tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                    tbl += ds.Tables[0].Rows[0]["Executive"].ToString()+"," + ds.Tables[0].Rows[0]["ExecutiveCity"].ToString() + "</b></td></tr>";
                }
            }
        }
        else
        {
            if (retainername == "")
            {
                tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                tbl += ds.Tables[0].Rows[0]["Retainer"].ToString() +"," + ds.Tables[0].Rows[0]["Retainercity"].ToString() + "</b></td></tr>";
            }
        }
        double total = 0;
        double totalarea = 0;
        double totalwords = 0;
        double excutivetotal = 0;
        double retainertotal = 0;
        for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
        {
            if (rowcounter == maxlimit)
            {
                maxlimit = 12;
                rowcounter = 0;
                tbl += "</table><p>";
                tbl += "</br>";
                tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                tbl += "</table><p>";

                tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                tbl += "<tr><td  class='middle31new' width='3%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='14%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='9%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='10%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td></tr>";

            }
            if ((ds.Tables[0].Rows[p]["Height"].ToString() != "" || ds.Tables[0].Rows[p]["Height"].ToString() != null) && (ds.Tables[0].Rows[p]["Width"].ToString() != "" || ds.Tables[0].Rows[p]["Width"].ToString() != null))
            {
                totalarea = totalarea + Convert.ToDouble(ds.Tables[0].Rows[p]["Size_Book"].ToString());
            }
                if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null)&&(ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
            {
                totalwords = totalwords + Convert.ToDouble(ds.Tables[0].Rows[p]["Size_Book"].ToString());
            }
                sno1++;
                if (rep == "1")
                {
                    if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
                    {
                        if (agencyname == "")
                        {
                            agencyname = ds.Tables[0].Rows[p]["Executive"].ToString();
                        }
                        else
                        {

                            agencyname = ds.Tables[0].Rows[p - 1]["Executive"].ToString();

                        }
                    }
                }
                else
                {
                    if (agencyname == "")
                    {
                        agencyname = ds.Tables[0].Rows[p]["Retainer"].ToString();
                    }
                    else
                    {

                        agencyname = ds.Tables[0].Rows[p - 1]["Retainer"].ToString();

                    }
                }
                if (rep == "1")
                {
                    if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
                    {
                        if (ds.Tables[0].Rows[sno1 - 1]["Executive"].ToString() == agencyname)
                        {



                            tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                            tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                            tbl += "<td class='rep_data'  width='9%'>";
                            tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                            tbl += "<td class='rep_data'  width='6%' align='center'>";
                            if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                            {
                                if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                                {
                                    tbl += "--" + "</td>";
                                }
                                else
                                {
                                    tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                                }
                            }
                            else
                            {
                                tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                            }
                            tbl += "<td class='rep_data' width='14%' align='center'>";
                            tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                            tbl += "<td class='rep_data' width='9%' align='center'>";
                            tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                            tbl += "<td class='rep_data' width='9%'align='right'>";
                            if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                                tbl += "" + "</td>";
                            else
                            {
                                double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                                tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                            }
                            tbl += "<td class='rep_data' width='10%'align='right'>";
                            if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                                tbl += "" + "</td>";
                            else
                            {
                                double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                                tbl += string.Format("{0:0.00}", agratet) + "</td>";
                            }

                            tbl += "<td class='rep_data' width='8%' align='center'>";
                            tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                            tbl += "<td class='rep_data' width='8%' align='center'>";
                            if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                                tbl += "--" + "</td>";
                            else
                                tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                            tbl += "<td class='rep_data' width='8%' align='right'>";
                            double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                            tbl += string.Format("{0:0.00}", billamt) + "</td>";
                            excutivetotal = excutivetotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                            total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                            tbl += "<td class='rep_data' width='8%'  align='right'>";
                            tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                            tbl += "<td class='rep_data' width='5%'  align='right'>";
                            string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                            tbl += insret + "</td>";


                            tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                            tbl += "<td class='rep_data'  align='left' colspan='2'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                            tbl += "<td class='rep_data'  align='left' colspan='2'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                            tbl += "<td class='rep_data'  align='left' colspan='2'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                            tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                            tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";
                        }
                        else
                        {
                            tbl += "<tr width='50%'>";
                            tbl += "<td class='middle31new'  colspan='1'  align='right'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>";
                            tbl += "<td class='middle31new'    align='right'>";
                            tbl += "" + "</td>";
                            tbl += "<td class='middle31new'    align='right'>";
                            tbl += "" + "</td>";
                            tbl += "<td class='middle31new'   align='right'>";
                            tbl += "" + "</td>";
                            tbl += "<td class='middle31new'  colspan='4'  align='right'>";
                            tbl += "" + "</td>";
                            tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
                            tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", excutivetotal) + "</td>";
                            tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


                            tbl += "</tr>";
                            excutivetotal = 0;

                            if (execut == "")
                            {
                                tbl += "<tr font-size='10' font-family='Arial'>";
                                tbl += "<td style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'  align='left' colspan='7'><b>";
                                tbl += ds.Tables[0].Rows[p]["Executive"].ToString()+ "," + ds.Tables[0].Rows[p]["ExecutiveCity"].ToString() + "</b></td></tr>";
                            }


                            tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                            tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                            tbl += "<td class='rep_data'  width='9%'>";
                            tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                            tbl += "<td class='rep_data'  width='6%' align='center'>";
                            if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                            {
                                if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                                {
                                    tbl += "--" + "</td>";
                                }
                                else
                                {
                                    tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                                }
                            }
                            else
                            {
                                tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                            }
                            tbl += "<td class='rep_data' width='14%' align='center'>";
                            tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                            tbl += "<td class='rep_data' width='9%' align='center'>";
                            tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                            tbl += "<td class='rep_data' width='9%'align='right'>";
                            if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                                tbl += "" + "</td>";
                            else
                            {
                                double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                                tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                            }
                            tbl += "<td class='rep_data' width='10%'align='right'>";
                            if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                                tbl += "" + "</td>";
                            else
                            {
                                double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                                tbl += string.Format("{0:0.00}", agratet) + "</td>";
                            }

                            tbl += "<td class='rep_data' width='8%' align='center'>";
                            tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                            tbl += "<td class='rep_data' width='8%' align='center'>";
                            if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                                tbl += "--" + "</td>";
                            else
                                tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                            tbl += "<td class='rep_data' width='8%' align='right'>";
                            excutivetotal = excutivetotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                            double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                            tbl += string.Format("{0:0.00}", billamt) + "</td>";
                            total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                            tbl += "<td class='rep_data' width='8%'  align='right'>";
                            tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                            tbl += "<td class='rep_data' width='5%'  align='right'>";
                            string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                            tbl += insret + "</td>";


                            tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                            tbl += "<td class='rep_data'  align='left' colspan='2'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                            tbl += "<td class='rep_data'  align='left' colspan='2'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                            tbl += "<td class='rep_data'  align='left' colspan='2'>";
                            tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                            tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                            tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";

                        }
                    }
                }
                else
                {

                    if (ds.Tables[0].Rows[sno1 - 1]["Retainer"].ToString() == agencyname)
                    {



                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                        tbl += "<td class='rep_data'  width='9%'>";
                        tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                        tbl += "<td class='rep_data'  width='6%' align='center'>";
                        if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                        {
                            if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                            {
                                tbl += "--" + "</td>";
                            }
                            else
                            {
                                tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                            }
                        }
                        else
                        {
                            tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                        }
                        tbl += "<td class='rep_data' width='14%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='9%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='9%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                            tbl += "" + "</td>";
                        else
                        {
                            double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                        }
                        tbl += "<td class='rep_data' width='10%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                            tbl += "" + "</td>";
                        else
                        {
                            double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", agratet) + "</td>";
                        }


                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                            tbl += "--" + "</td>";
                        else
                            tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                        tbl += "<td class='rep_data' width='8%' align='right'>";
                        double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        retainertotal = retainertotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        tbl += string.Format("{0:0.00}", billamt) + "</td>";
                        total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                        tbl += "<td class='rep_data' width='8%'  align='right'>";
                        tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='5%'  align='right'>";
                        string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                        tbl += insret + "</td>";


                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                        tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";
                    }
                    else
                    {
                        tbl += "<tr width='50%'>";
                        tbl += "<td class='middle31new'  colspan='1'  align='right'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>";
                        tbl += "<td class='middle31new'    align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td class='middle31new'    align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td class='middle31new'   align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td class='middle31new'  colspan='4'  align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
                        tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", retainertotal) + "</td>";
                        tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


                        tbl += "</tr>";
                        retainertotal = 0;

                        if (retainername == "")
                        {
                            tbl += "<tr font-size='10' font-family='Arial'>";
                            tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                            tbl += ds.Tables[0].Rows[p]["Retainer"].ToString() + "," + ds.Tables[0].Rows[p]["Retainercity"].ToString() + "</b></td></tr>";

                        }

                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                        tbl += "<td class='rep_data'  width='9%'>";
                        tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                        tbl += "<td class='rep_data'  width='6%' align='center'>";
                        if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                        {
                            if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                            {
                                tbl += "--" + "</td>";
                            }
                            else
                            {
                                tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                            }
                        }
                        else
                        {
                            tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " +/* ds.Tables[0].Rows[p]["UOM"].ToString() +*/ "</td>";
                        }
                        tbl += "<td class='rep_data' width='14%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='9%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='9%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                            tbl += "" + "</td>";
                        else
                        {
                            double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                        }
                        tbl += "<td class='rep_data' width='10%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                            tbl += "" + "</td>";
                        else
                        {
                            double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", agratet) + "</td>";
                        }


                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                            tbl += "--" + "</td>";
                        else
                            tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                        tbl += "<td class='rep_data' width='8%' align='right'>";
                        retainertotal = retainertotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        tbl += string.Format("{0:0.00}", billamt) + "</td>";
                        total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                        tbl += "<td class='rep_data' width='8%'  align='right'>";
                        tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='5%'  align='right'>";
                        string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                        tbl += insret + "</td>";


                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                        tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";

                    }
                }

            rowcounter++;

        

        }

       
            if (excutivetotal != 0)
            {
                tbl += "<tr width='50%'>";
                tbl += "<td class='middle31new'  colspan='1'  align='right'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>";
                tbl += "<td class='middle31new'    align='right'>";
                tbl += "" + "</td>";
                tbl += "<td class='middle31new'    align='right'>";
                tbl += "" + "</td>";
                tbl += "<td class='middle31new'   align='right'>";
                tbl += "" + "</td>";
                tbl += "<td class='middle31new'  colspan='4'  align='right'>";
                tbl += "" + "</td>";
                tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
                tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", excutivetotal) + "</td>";
                tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


                tbl += "</tr>";
            }
            else if (retainertotal != 0)
            {
                tbl += "<tr width='50%'>";
                tbl += "<td class='middle31new'  colspan='1'  align='right'>";
                tbl += ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>";
                tbl += "<td class='middle31new'    align='right'>";
                tbl += "" + "</td>";
                tbl += "<td class='middle31new'    align='right'>";
                tbl += "" + "</td>";
                tbl += "<td class='middle31new'   align='right'>";
                tbl += "" + "</td>";
                tbl += "<td class='middle31new'  colspan='4'  align='right'>";
                tbl += "" + "</td>";
                tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
                tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", retainertotal) + "</td>";
                tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


                tbl += "</tr>";
                retainertotal = 0;
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
        tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
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



        int sno1 = 0;
        string tbl = "";
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/representativsummary.xml"));
        tbl = "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</td></tr>";
        if (rep == "1")
        {
            if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
            {
                tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[17].ToString() + "</td></tr>";
                tbl += "<tr class='middle33'><td colspan='12' align='left'>" + ds1.Tables[0].Rows[0].ItemArray[0].ToString() + "" + datefrom1 + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + "" + dateto1 + "</td></tr>";
            }
        }
        else
        {
            tbl += "<tr class='headingc'><td colspan='12' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[23].ToString() + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='12' align='left'>" + ds1.Tables[0].Rows[0].ItemArray[22].ToString() + "" + datefrom1 + ds1.Tables[0].Rows[0].ItemArray[1].ToString() + "" + dateto1 + "</td></tr>";
        }
        if (rep == "1")
        {
            if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
            {
                if (execut != "")
                {
                    tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["Executive"].ToString() + "," + ds.Tables[0].Rows[0]["ExecutiveCity"].ToString() + "</td></tr>";
                }
            }
        }
        else
        {

            if (retainername != "")
            {
                tbl += "<tr class='middle33'><td colspan='12' align='center'>" + ds.Tables[0].Rows[0]["Retainer"].ToString() + "," + ds.Tables[0].Rows[0]["Retainercity"].ToString() + /*"  " + ds.Tables[0].Rows[0]["ADD1"].ToString() + ds.Tables[0].Rows[0]["ADD2"].ToString() + ds.Tables[0].Rows[0]["ADD3"].ToString() + */"</td></tr>";
            }
        }
        tbl += "</table>";
        tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
        tbl += "<tr><td  class='middle31new' width='3%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='14%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='9%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='10%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td></tr>";

        tbl += "<tr font-size='10' font-family='Arial'>";
        if (rep == "1")
        {
            if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
            {
                if (execut == "")
                {
                    tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                    tbl += ds.Tables[0].Rows[0]["Executive"].ToString() + "," + ds.Tables[0].Rows[0]["ExecutiveCity"].ToString() + "</b></td></tr>";
                }
            }
        }
        else
        {
            if (retainername == "")
            {
                tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                tbl += ds.Tables[0].Rows[0]["Retainer"].ToString() + "," + ds.Tables[0].Rows[0]["Retainercity"].ToString() + "</b></td></tr>";
            }
        }
        double total = 0;
        double totalarea = 0;
        double totalwords = 0;
        double excutivetotal = 0;
        double retainertotal = 0;
        for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
        {
            if (rowcounter == maxlimit)
            {
                maxlimit = 12;
                rowcounter = 0;
                tbl += "</table><p>";
                tbl += "</br>";
                tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                tbl += "</table><p>";

                tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
                tbl += "<tr><td  class='middle31new' width='3%'>" + ds1.Tables[0].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[3].ToString() + "</td><td  class='middle31new' width='6%'>" + ds1.Tables[0].Rows[0].ItemArray[4].ToString() + "</td><td  class='middle31new' width='14%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[5].ToString() + "</td><td  class='middle31new' width='9%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[6].ToString() + "</td><td  class='middle31new' width='9%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[7].ToString() + "</td><td  class='middle31new' width='10%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[21].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[8].ToString() + "</td><td  class='middle31new' width='8%' align='center'>" + ds1.Tables[0].Rows[0].ItemArray[10].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[11].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[12].ToString() + "</td><td  class='middle31new' width='8%' align='right'>" + ds1.Tables[0].Rows[0].ItemArray[24].ToString() + "</td></tr>";

            }
            if ((ds.Tables[0].Rows[p]["Height"].ToString() != "" || ds.Tables[0].Rows[p]["Height"].ToString() != null) && (ds.Tables[0].Rows[p]["Width"].ToString() != "" || ds.Tables[0].Rows[p]["Width"].ToString() != null))
            {
                totalarea = totalarea + Convert.ToDouble(ds.Tables[0].Rows[p]["Size_Book"].ToString());
            }
            if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
            {
                totalwords = totalwords + Convert.ToDouble(ds.Tables[0].Rows[p]["Size_Book"].ToString());
            }
            sno1++;
            if (rep == "1")
            {
                if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
                {
                    if (agencyname == "")
                    {
                        agencyname = ds.Tables[0].Rows[p]["Executive"].ToString();
                    }
                    else
                    {

                        agencyname = ds.Tables[0].Rows[p - 1]["Executive"].ToString();

                    }
                }
            }
            else
            {
                if (agencyname == "")
                {
                    agencyname = ds.Tables[0].Rows[p]["Retainer"].ToString();
                }
                else
                {

                    agencyname = ds.Tables[0].Rows[p - 1]["Retainer"].ToString();

                }
            }
            if (rep == "1")
            {
                if (ds.Tables[0].Rows[0]["Executive"].ToString() != "" && ds.Tables[0].Rows[0]["Executive"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[sno1 - 1]["Executive"].ToString() == agencyname)
                    {



                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                        tbl += "<td class='rep_data'  width='9%'>";
                        tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                        tbl += "<td class='rep_data'  width='6%' align='center'>";
                        if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                        {
                            if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                            {
                                tbl += "--" + "</td>";
                            }
                            else
                            {
                                tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                            }
                        }
                        else
                        {
                            tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                        }
                        tbl += "<td class='rep_data' width='14%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='9%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='9%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                            tbl += "" + "</td>";
                        else
                        {
                            double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                        }
                        tbl += "<td class='rep_data' width='10%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                            tbl += "" + "</td>";
                        else
                        {
                            double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", agratet) + "</td>";
                        }

                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                            tbl += "--" + "</td>";
                        else
                            tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                        tbl += "<td class='rep_data' width='8%' align='right'>";
                        double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        tbl += string.Format("{0:0.00}", billamt) + "</td>";
                        excutivetotal = excutivetotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                        tbl += "<td class='rep_data' width='8%'  align='right'>";
                        tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='5%'  align='right'>";
                        string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                        tbl += insret + "</td>";


                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                        tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";
                    }
                    else
                    {
                        tbl += "<tr width='50%'>";
                        tbl += "<td class='middle31new'  colspan='1'  align='right'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>";
                        tbl += "<td class='middle31new'    align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td class='middle31new'    align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td class='middle31new'   align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td class='middle31new'  colspan='4'  align='right'>";
                        tbl += "" + "</td>";
                        tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
                        tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", excutivetotal) + "</td>";
                        tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


                        tbl += "</tr>";
                        excutivetotal = 0;

                        if (execut == "")
                        {
                            tbl += "<tr font-size='10' font-family='Arial'>";
                            tbl += "<td style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'  align='left' colspan='7'><b>";
                            tbl += ds.Tables[0].Rows[p]["Executive"].ToString() + "," + ds.Tables[0].Rows[p]["ExecutiveCity"].ToString() + "</b></td></tr>";
                        }


                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                        tbl += "<td class='rep_data'  width='9%'>";
                        tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                        tbl += "<td class='rep_data'  width='6%' align='center'>";
                        if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                        {
                            if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                            {
                                tbl += "--" + "</td>";
                            }
                            else
                            {
                                tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                            }
                        }
                        else
                        {
                            tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                        }
                        tbl += "<td class='rep_data' width='14%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='9%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='9%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                            tbl += "" + "</td>";
                        else
                        {
                            double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                        }
                        tbl += "<td class='rep_data' width='10%'align='right'>";
                        if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                            tbl += "" + "</td>";
                        else
                        {
                            double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                            tbl += string.Format("{0:0.00}", agratet) + "</td>";
                        }

                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                        tbl += "<td class='rep_data' width='8%' align='center'>";
                        if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                            tbl += "--" + "</td>";
                        else
                            tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                        tbl += "<td class='rep_data' width='8%' align='right'>";
                        excutivetotal = excutivetotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                        tbl += string.Format("{0:0.00}", billamt) + "</td>";
                        total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                        tbl += "<td class='rep_data' width='8%'  align='right'>";
                        tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                        tbl += "<td class='rep_data' width='5%'  align='right'>";
                        string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                        tbl += insret + "</td>";


                        tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='2'>";
                        tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                        tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                        tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";

                    }
                }
            }
            else
            {

                if (ds.Tables[0].Rows[sno1 - 1]["Retainer"].ToString() == agencyname)
                {



                    tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                    tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                    tbl += "<td class='rep_data'  width='9%'>";
                    tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                    tbl += "<td class='rep_data'  width='6%' align='center'>";
                    if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                    {
                        if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                        {
                            tbl += "--" + "</td>";
                        }
                        else
                        {
                            tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                        }
                    }
                    else
                    {
                        tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                    }
                    tbl += "<td class='rep_data' width='14%' align='center'>";
                    tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='9%' align='center'>";
                    tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                    tbl += "<td class='rep_data' width='9%'align='right'>";
                    if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                        tbl += "" + "</td>";
                    else
                    {
                        double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                        tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                    }
                    tbl += "<td class='rep_data' width='10%'align='right'>";
                    if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                        tbl += "" + "</td>";
                    else
                    {
                        double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                        tbl += string.Format("{0:0.00}", agratet) + "</td>";
                    }


                    tbl += "<td class='rep_data' width='8%' align='center'>";
                    tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%' align='center'>";
                    if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                        tbl += "--" + "</td>";
                    else
                        tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                    tbl += "<td class='rep_data' width='8%' align='right'>";
                    double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                    retainertotal = retainertotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                    tbl += string.Format("{0:0.00}", billamt) + "</td>";
                    total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                    tbl += "<td class='rep_data' width='8%'  align='right'>";
                    tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                    tbl += "<td class='rep_data' width='5%'  align='right'>";
                    string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                    tbl += insret + "</td>";


                    tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                    tbl += "<td class='rep_data'  align='left' colspan='2'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                    tbl += "<td class='rep_data'  align='left' colspan='2'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                    tbl += "<td class='rep_data'  align='left' colspan='2'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                    tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                    tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";
                }
                else
                {
                    tbl += "<tr width='50%'>";
                    tbl += "<td class='middle31new'  colspan='1'  align='right'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>";
                    tbl += "<td class='middle31new'    align='right'>";
                    tbl += "" + "</td>";
                    tbl += "<td class='middle31new'    align='right'>";
                    tbl += "" + "</td>";
                    tbl += "<td class='middle31new'   align='right'>";
                    tbl += "" + "</td>";
                    tbl += "<td class='middle31new'  colspan='4'  align='right'>";
                    tbl += "" + "</td>";
                    tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
                    tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", retainertotal) + "</td>";
                    tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


                    tbl += "</tr>";
                    retainertotal = 0;

                    if (retainername == "")
                    {
                        tbl += "<tr font-size='10' font-family='Arial'>";
                        tbl += "<td   align='left'style='font-size:10px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%' colspan='13'> <b> ";
                        tbl += ds.Tables[0].Rows[p]["Retainer"].ToString() + "," + ds.Tables[0].Rows[p]["Retainercity"].ToString() + "</b></td></tr>";

                    }

                    tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                    tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                    tbl += "<td class='rep_data'  width='9%'>";
                    tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                    tbl += "<td class='rep_data'  width='6%' align='center'>";
                    if ((ds.Tables[0].Rows[p]["Height"].ToString() == "" || ds.Tables[0].Rows[p]["Height"].ToString() == null) && (ds.Tables[0].Rows[p]["Width"].ToString() == "" || ds.Tables[0].Rows[p]["Width"].ToString() == null))
                    {
                        if (ds.Tables[0].Rows[p]["Size_Book"].ToString() == "" || ds.Tables[0].Rows[p]["Size_Book"].ToString() == null)
                        {
                            tbl += "--" + "</td>";
                        }
                        else
                        {
                            tbl += ds.Tables[0].Rows[p]["Size_Book"].ToString() + " " + ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";
                        }
                    }
                    else
                    {
                        tbl += ds.Tables[0].Rows[p]["Height"].ToString() + "X" + ds.Tables[0].Rows[p]["Width"].ToString() + " " +/* ds.Tables[0].Rows[p]["UOM"].ToString() +*/ "</td>";
                    }
                    tbl += "<td class='rep_data' width='14%' align='center'>";
                    tbl += ds.Tables[0].Rows[p]["Client"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='9%' align='center'>";
                    tbl += ds.Tables[0].Rows[p]["Ins.date"].ToString() + "</td>";

                    tbl += "<td class='rep_data' width='9%'align='right'>";
                    if (ds.Tables[0].Rows[p]["Card_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Card_Rate"].ToString() == null)
                        tbl += "" + "</td>";
                    else
                    {
                        double cardrate = Convert.ToDouble(ds.Tables[0].Rows[p]["Card_Rate"].ToString());

                        tbl += string.Format("{0:0.00}", cardrate) + "</td>";
                    }
                    tbl += "<td class='rep_data' width='10%'align='right'>";
                    if (ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "" || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == null || ds.Tables[0].Rows[p]["Agreed_Rate"].ToString() == "0")
                        tbl += "" + "</td>";
                    else
                    {
                        double agratet = Convert.ToDouble(ds.Tables[0].Rows[p]["Agreed_Rate"].ToString());

                        tbl += string.Format("{0:0.00}", agratet) + "</td>";
                    }


                    tbl += "<td class='rep_data' width='8%' align='center'>";
                    tbl += ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%' align='center'>";
                    if (ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == "" || ds.Tables[0].Rows[p]["BILL_DATE"].ToString() == null)
                        tbl += "--" + "</td>";
                    else
                        tbl += changeformat(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()) + "</td>";

                    tbl += "<td class='rep_data' width='8%' align='right'>";
                    retainertotal = retainertotal + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                    double billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());
                    tbl += string.Format("{0:0.00}", billamt) + "</td>";
                    total = total + Convert.ToDouble(ds.Tables[0].Rows[p]["Bill_Amt"].ToString());

                    tbl += "<td class='rep_data' width='8%'  align='right'>";
                    tbl += ds.Tables[0].Rows[p]["Ro.No."].ToString() + "</td>";

                    tbl += "<td class='rep_data' width='5%'  align='right'>";
                    string insret = ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString();
                    tbl += insret + "</td>";


                    tbl += "<tr font-size='10' font-family='Arial' style='height:25px'>";
                    tbl += "<td class='rep_data'  align='left' colspan='2'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[18].ToString() + " " + ds.Tables[0].Rows[p]["Trade_disc"].ToString() + "</td>";

                    tbl += "<td class='rep_data'  align='left' colspan='2'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[19].ToString() + " " + ds.Tables[0].Rows[p]["CAPTION"].ToString() + "</td>";

                    tbl += "<td class='rep_data'  align='left' colspan='2'>";
                    tbl += ds1.Tables[0].Rows[0].ItemArray[20].ToString() + " " + ds.Tables[0].Rows[p]["Key"].ToString() + "</td>";

                    tbl += "<td class='rep_data'  align='left' colspan='7'>Remark:";
                    tbl += ds.Tables[0].Rows[p]["Remarks"].ToString() + "</td></tr>";

                }
            }

            rowcounter++;



        }


        if (excutivetotal != 0)
        {
            tbl += "<tr width='50%'>";
            tbl += "<td class='middle31new'  colspan='1'  align='right'>";
            tbl += ds1.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>";
            tbl += "<td class='middle31new'    align='right'>";
            tbl += "" + "</td>";
            tbl += "<td class='middle31new'    align='right'>";
            tbl += "" + "</td>";
            tbl += "<td class='middle31new'   align='right'>";
            tbl += "" + "</td>";
            tbl += "<td class='middle31new'  colspan='4'  align='right'>";
            tbl += "" + "</td>";
            tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
            tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", excutivetotal) + "</td>";
            tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


            tbl += "</tr>";
        }
        else if (retainertotal != 0)
        {
            tbl += "<tr width='50%'>";
            tbl += "<td class='middle31new'  colspan='1'  align='right'>";
            tbl += ds1.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>";
            tbl += "<td class='middle31new'    align='right'>";
            tbl += "" + "</td>";
            tbl += "<td class='middle31new'    align='right'>";
            tbl += "" + "</td>";
            tbl += "<td class='middle31new'   align='right'>";
            tbl += "" + "</td>";
            tbl += "<td class='middle31new'  colspan='4'  align='right'>";
            tbl += "" + "</td>";
            tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
            tbl += "<td  class='middle31new' align='right' >" + string.Format("{0:0.00}", retainertotal) + "</td>";
            tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";


            tbl += "</tr>";
            retainertotal = 0;
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
        tbl += "<td  class='middle31new' colspan='1'>" + "" + "</td>";
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


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printrow.Attributes.Add("style", "display:none");
        bdy.Attributes.Add("onload", "window.print()");
    }
}
