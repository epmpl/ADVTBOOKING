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
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text;
using System.IO;
using System.Web.UI.WebControls;

public partial class valueReportview : System.Web.UI.Page
{
    int sno = 1;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;
    string destination = "";
    string fromdt = "";
    string rundate = "";
    string dateto = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string adtypename = "";
    string pdfName1 = "";
    string datefrom1 = "";
    string dateto1 = "";
    string region = "";
    string regionname = "";
    string product = "";
    string product1 = "";
    float area = 0;
    int dd2;
    double BillAmt = 0;
    double billarea = 0;
    string sortorder = "";
    string sortvalue = "";
    string agency, fromdate, client, publication="", adtype="", billstatus, payment, todate = "";
    string myrange = "";
    string maxrange = "", orderby = "", pubcode = "", exename = "", execode = "", incname = "", inccode="";
    string temp_category = "", temp_agname = "", temp_pubcent = "", temp_edition = "", temp_state = "", temp_district = "", temp_client = "", temp_newcategory = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }


        ds = (DataSet)Session["rebaterep"];
        string prm = Session["prm_rebaterep"].ToString();
        string[] prm_Array = new string[25];
        prm_Array = prm.Split('~');

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
      
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        region = prm_Array[1];// Request.QueryString["regcode"].ToString();
        regionname = prm_Array[3];//Request.QueryString["region"].ToString();
        fromdt = prm_Array[5];//Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[7];//Request.QueryString["dateto"].ToString();
        destination = prm_Array[9];//Request.QueryString["destination"].ToString();
        orderby = prm_Array[11];//Request.QueryString["orderby"].ToString();
        adtype = prm_Array[13];//Request.QueryString["adtype"].ToString();
        adtypename = prm_Array[15];//Request.QueryString["adtypename"].ToString();
        pubcode = prm_Array[17];//Request.QueryString["publication"].ToString();
        publication = prm_Array[19];//Request.QueryString["publname"].ToString();
        exename = prm_Array[21];//Request.QueryString["exename"].ToString();
        execode = prm_Array[23];//Request.QueryString["execode"].ToString();
        inccode = prm_Array[21];
        incname = prm_Array[23];
        chk_excel = prm_Array[25];
        if (execode == "0" || execode=="")
            {
                lblexecutive.Text = "ALL".ToString();
            }
            else
            {
                lblexecutive.Text = exename.ToString();
            }
            if (inccode == "0" || inccode == "")
            {
                lbldeal.Text = "ALL".ToString();
            }
            else
            {
                lbldeal.Text = incname.ToString();
            }
            if (pubcode == "0")
            {
                lblpublication.Text = "ALL".ToString();
            }
            else
            {
                lblpublication.Text = publication.ToString();
            }
            if (region == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = regionname.ToString();
            }

            if (adtype == "0")
            {
                lbladtype.Text = "ALL".ToString();
            }
            else
            {
                lbladtype.Text = adtypename.ToString();
            }

            if (orderby == "Publication")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[34].ToString();
            }
            else if (orderby == "Region")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[33].ToString();
            }
            else if (orderby == "Agency Region")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[75].ToString();

            }
            else if (orderby == "Extra Rebate")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[35].ToString();
            }

            if (fromdt != "")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
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
                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = day + "/" + month + "/" + year;


                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = year + "/" + month + "/" + day;
                    }
                }
            }
            lblfrom.Text = datefrom1;
            //dateto1 = "";
            if (dateto != "")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = dd + "/" + mm + "/" + yy;

                }


                else
                {

                    DateTime dt = Convert.ToDateTime(dateto.ToString());

                    if (hiddendateformat.Value == "dd/mm/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = day + "/" + month + "/" + year;

                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        dateto1 = year + "/" + month + "/" + day;
                    }
                }
            }
            lblto.Text = dateto1;

            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

                }
                else
                    if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                    {

                        DateTime dt = System.DateTime.Now;


                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                    }
            lbldate.Text = date.ToString();


            lbldate.Text = date.ToString();
            lblfrom.Text = fromdt;
            lblto.Text = dateto;
            rundate = date.ToString();




            if (!Page.IsPostBack)
            {
                if (destination == "1" || destination == "0")
                {
                    onscreen(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString());
                }
                else if (destination == "4")
                {
                    excel(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString());

                }
                else
                    if (destination == "3")
                    {
                        pdf(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString());
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

    private void onscreen(string frmdt, string todate, string compcode, string region, string product, string dateformate)
    {
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    ds = obj.valuereportregion(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //    ds = obj.rebatebilling(frmdt, todate, region, pubcode, temp_category, compcode, dateformate, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtype, temp_pubcent, temp_edition, execode, temp_state, temp_district, temp_client, temp_newcategory, orderby);
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int dealcount = 0;
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        string tbl = "";
        //tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
            //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td>";

            for (int i = 0; i <= cont - 1; i++)
            {
                if (ds.Tables[0].Rows[i]["Dealname"].ToString() == "" || ds.Tables[0].Rows[i]["Dealname"].ToString() == "0")
                {

                }
                else
                {
                    dealcount++;
                }

            }
            if (dealcount > 0)
            {
                tbl = tbl + "<td class='middle4' width='5px'>&nbsp;</td></tr>";
            }
            else
            {
                tbl = tbl + ("</tr>");
            }

        if (hiddenascdesc.Value == "")
        {
            //tbl = tbl + ("<tr><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' valign='top'>Area</td><td class='middle31' valign='top'>BillAmt</td><td id='tdbill~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' valign='top'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
           
            if (orderby == "Publication")
            {
                tbl = tbl + ("<tr><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top' align='left'>Publication</td><td class='middle31' valign='top' align='left' >Booking</br>Id</td><td class='middle31' align='left' valign='top'>Agency</td><td class='middle31' align='left' valign='top'>Client</td><td class='middle31'  align='right' valign='top'>Area</td><td class='middle31' valign='top' align='right' >Bill</br>Amt</td><td class='middle31' valign='top' align='right'>Special</br>Disc</td><td class='middle31' valign='top' align='right'>Space</br>Disc</td><td class='middle31' valign='top' align='right'>Special</br>Disc%</td><td class='middle31' valign='top' align='right'>Space</br>Disc%</td><td class='middle31' valign='top' align='right' >Card</br>Rate</td><td class='middle31' valign='top' align='right' >Agg</br>Rate</td><td class='middle31' valign='top' align='right' >Disc</td><td class='middle31' align='left' valign='top'>Revenue</br>Center</td>");

            }
            else if (orderby == "Region")
            {
                tbl = tbl + ("<tr><td class='middle31' valign='top' valign='top'>S.No.</td><td class='middle31' valign='top' align='left'>Region</td><td class='middle31' valign='top' align='left'>Booking</br>Id</td><td class='middle31' align='left' valign='top'>Agency</td><td class='middle31' valign='top' align='left'>Client</td><td class='middle31'  align='right' valign='top'>Area</td><td class='middle31' valign='top' align='right' >Bill</br>Amt</td><td class='middle31' valign='top' align='right'>Special</br>Disc</td><td class='middle31' valign='top' align='right'>Space</br>Disc</td><td class='middle31' valign='top' align='right'>Special</br>Disc%</td><td class='middle31' valign='top' align='right'>Space</br>Disc%</td><td class='middle31' valign='top' align='right' >Card</br>Rate</td><td class='middle31' valign='top' align='right' >Agg</br>Rate</td><td class='middle31' valign='top' align='right' >Disc</td><td class='middle31' align='left' valign='top'>Revenue</br>Center</td>");

            }
            else if (orderby == "Agency Region")
            {
                tbl = tbl + ("<tr><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top' align='left'>Region</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left'>Booking</br>Id</td><td class='middle31' valign='top' align='left'>Client</td><td class='middle31'  align='right' valign='top'>Area</td><td class='middle31' valign='top' align='right' >Bill</br>Amt</td><td class='middle31' valign='top' align='right'>Special</br>Disc</td><td class='middle31' valign='top' align='right'>Space</br>Disc</td><td class='middle31' valign='top' align='right'>Special</br>Disc%</td><td class='middle31' valign='top' align='right'>Space</br>Disc%</td><td class='middle31' valign='top' align='right' >Card</br>Rate</td><td class='middle31' valign='top' align='right' >Agg</br>Rate</td><td class='middle31' valign='top' align='right' >Disc</td><td class='middle31' align='left' valign='top'>Revenue</br>Center</td>");

            }
            else if (orderby == "Extra Rebate")
            {
                tbl = tbl + ("<tr><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top' align='left' >Booking</br>Id</td><td class='middle31' align='left' valign='top'>Agency</td><td class='middle31' align='left' valign='top'>Client</td><td class='middle31' valign='top' align='left'>Publication</td><td class='middle31'  align='right' valign='top'>Area</td><td class='middle31' valign='top' align='right' >Bill</br>Amt</td><td class='middle31' valign='top' align='right'>Special</br>Disc</td><td class='middle31' valign='top' align='right'>Space</br>Disc</td><td class='middle31' valign='top' align='right'>Special</br>Disc%</td><td class='middle31' valign='top' align='right'>Space</br>Disc%</td><td class='middle31' valign='top' align='right' >Card</br>Rate</td><td class='middle31' valign='top' align='right' >Agg</br>Rate</td><td class='middle31' valign='top' align='right' >Disc</td><td class='middle31' align='left' valign='top'>Revenue</br>Center</td>");

            }
        }
      
       
        if (dealcount > 0)
        {
            lbldeal.Text = "YES";
            tbl = tbl + ("<td class='middle31' valign='top'>Deal Name</td></tr>");
        }
        else
        {
            lbldeal.Text = "NO";
            tbl = tbl + ("</tr>");
        }

        int i1 = 1;
        float area = 0;
        double BillAmt = 0;


        for (int i = 0; i <= cont - 1; i++)
        {
            if (i > 0 && orderby !="Extra Rebate")//for adcat total
            {

                if (orderby != "Agency Region")
                {
                    if ((ds.Tables[0].Rows[i][orderby].ToString() != ds.Tables[0].Rows[i - 1][orderby].ToString()))//|| (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString()) || (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))
                    {
                        tbl = tbl + ("<tr style='height:40px'>");

                        tbl = tbl + ("<td class='rep_data' style='height:50px'>");
                        tbl = tbl + ("<b>" + "Total" + "</b>" + "</td>");


                        for (int abc = 0; abc <= 3; abc++)
                        {
                            tbl = tbl + ("<td class='rep_data' style='height:50px'>");
                            tbl = tbl + ("</td>");
                        }

                        //for (int i11 = 13; i11 <= 14; i11++)
                        //{
                        int i11 = 3;
                        arr1[0] = 0;
                        arr1[1] = 0;
                        for (int j11 = dd2; j11 < i1 - 1; j11++)
                        {

                            if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                            {
                                arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                            }

                            else
                            {
                                arr1[0] = arr1[0] + 0;
                            }

                            if (ds.Tables[0].Rows[j11]["BillAmt"].ToString() != "")
                            {
                                arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["BillAmt"].ToString());
                            }

                            else
                            {
                                arr1[1] = arr1[1] + 0;
                            }
                        }

                        dd2 = Convert.ToInt32(i1 - 1);

                        for (int k11 = 0; k11 <= 1; k11++)
                        {
                            tbl = tbl + "<td  align='right' class='rep_data'>";
                            tbl = tbl + arr1[k11].ToString();

                            tbl = tbl + "</td>";

                        }


                        tbl = tbl + "</tr>";
                    }
                }
                else
                {
                    if ((ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))//|| (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString()) || (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))
                    {
                        tbl = tbl + ("<tr style='height:40px'>");

                        tbl = tbl + ("<td class='rep_data' style='height:50px'>");
                        tbl = tbl + ("<b>" + "Total" + "</b>" + "</td>");


                        for (int abc = 0; abc <= 3; abc++)
                        {
                            tbl = tbl + ("<td class='rep_data' style='height:50px'>");
                            tbl = tbl + ("</td>");
                        }

                        //for (int i11 = 13; i11 <= 14; i11++)
                        //{
                        int i11 = 3;
                        arr1[0] = 0;
                        arr1[1] = 0;
                        for (int j11 = dd2; j11 < i1 - 1; j11++)
                        {

                            if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                            {
                                arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                            }

                            else
                            {
                                arr1[0] = arr1[0] + 0;
                            }

                            if (ds.Tables[0].Rows[j11]["BillAmt"].ToString() != "")
                            {
                                arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["BillAmt"].ToString());
                            }

                            else
                            {
                                arr1[1] = arr1[1] + 0;
                            }
                        }

                        dd2 = Convert.ToInt32(i1 - 1);

                        for (int k11 = 0; k11 <= 1; k11++)
                        {
                            tbl = tbl + "<td  align='right' class='rep_data'>";
                            tbl = tbl + arr1[k11].ToString();

                            tbl = tbl + "</td>";

                        }


                        tbl = tbl + "</tr>";
                    }
                }

            }//for adcat total
            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='rep_data' valign='top' align='center' >");
            tbl = tbl + (i1++.ToString() + "</td>");

            if (orderby == "Publication")
            {
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");

                if (i == 0)
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                }
                else
                {
                    if (ds.Tables[0].Rows[i]["Publication"].ToString() != ds.Tables[0].Rows[i - 1]["Publication"].ToString())
                    {
                        tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                    }
                    else
                    {
                        tbl = tbl + ("</td>");
                    }
                }
            }
            else if (orderby == "Region")
            {
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
               // tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                if (i == 0)
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                }
                else
                {
                    if (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString())
                    {
                        tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                    }
                    else
                    {
                        tbl = tbl + ("</td>");
                    }
                }
            }
            else if (orderby == "Agency Region")
            {
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                if (i == 0)
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                }
                else
                {
                    if (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString())
                    {
                        tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                    }
                    else
                    {
                        tbl = tbl + ("</td>");
                    }
                }
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
               // tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
                string agency1 = "";
                string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                char[] agency = rrr1.ToCharArray();
                int len111 = agency.Length;
                int line11 = 0;
                int ch_end1 = 0;
                int ch_str1 = 0;
                for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                {
                    /**/
                    ch_end1 = ch_end1 + 16;
                    ch_str1 = ch_end1;
                    if (ch_end1 > len111)
                        ch_str1 = len111 - ch1;
                    else
                        ch_str1 = ch_end1 - ch1;

                    agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                    agency1 = agency1 + "</br>";
                    ch1 = ch1 + 16;
                    if (ch1 > len111)
                        ch1 = len111;/**/
                }
                tbl = tbl + (agency1 + "</td>");
                
            }

            tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            char[] cioid = rrr.ToCharArray();
            int len11 = cioid.Length;

            int ch_end = 0;
            int ch_str = 0;
            for (int ch = 0; ch < len11; ch++)
            {
                /**/
                ch_end = ch_end + 9;
                ch_str = ch_end;
                if (ch_end > len11)
                    ch_str = len11 - ch;
                else
                    ch_str = ch_end - ch;

                cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                cioid1 = cioid1 + "</br>";
                ch = ch + 9;
                if (ch > len11)
                    ch = len11;
            }
            tbl = tbl + (cioid1 + "</td>");

            
            if (orderby != "Agency Region")
            {
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
                //tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
                string agency1 = "";
                string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                char[] agency = rrr1.ToCharArray();
                int len111 = agency.Length;
                int line11 = 0;
                int ch_end1 = 0;
                int ch_str1 = 0;
                for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                {
                    /**/
                    ch_end1 = ch_end1 + 16;
                    ch_str1 = ch_end1;
                    if (ch_end1 > len111)
                        ch_str1 = len111 - ch1;
                    else
                        ch_str1 = ch_end1 - ch1;

                    agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                    agency1 = agency1 + "</br>";
                    ch1 = ch1 + 16;
                    if (ch1 > len111)
                        ch1 = len111;/**/
                }
                tbl = tbl + (agency1 + "</td>");
            }
            tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            string client1 = "";
            string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            char[] client = rrr11.ToCharArray();
            int len1111 = client.Length;
            int line = 0;
            int ch_end11 = 0;
            int ch_str11 = 0;
            for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            {
                /* */
                ch_end11 = ch_end11 + 16;
                ch_str11 = ch_end11;
                if (ch_end11 > len1111)
                    ch_str11 = len1111 - ch11;
                else
                    ch_str11 = ch_end11 - ch11;

                client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                client1 = client1 + "</br>";
                ch11 = ch11 + 16;
                if (ch11 > len1111)
                    ch11 = len1111;
            }
            tbl = tbl + (client1 + "</td>");
            if (orderby == "Extra Rebate")
            {
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
            }


            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

           
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["SpecialDisc"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["SpaceDisc"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["SpecialDisc%"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["SpaceDisc%"] + "</td>");
           
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data' valign='top' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Disc"] + "</td>");
            tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

            if (ds.Tables[0].Rows[i]["Dealname"].ToString() == "" || ds.Tables[0].Rows[i]["Dealname"].ToString() == "0")
            {
            }
            else
            {
                tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Dealname"] + "</td>");
            }
           

            tbl = tbl + "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";

        }
      

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle1212'>");
        tbl = tbl + ("<tr><td class='middle1212' colspan='3'><b>Total Ads:</b>");//</td>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'><b>Total</b></td>");
        tbl = tbl + ("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl = tbl + (cal.ToString() + "</td>");
        tbl = tbl + ("<td class='middle1212' align='right'>");
        double cal1 = System.Math.Round(Convert.ToDouble(BillAmt), 2);
        tbl = tbl + (cal1.ToString() + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='8'>&nbsp;</td>");
        if (dealcount > 0)
        {
            tbl = tbl + ("<td class='middle1212' >&nbsp;</td></tr>");
        }
        else
        {
            tbl = tbl + ("</tr>");
        }
       // tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;
    }


    private void excel(string fromdt, string datetoo, string compcode, string region,string product, string dateformat)
    {
        
      
            //DataSet ds = new DataSet();
            //NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            //ds = obj.rebatebilling(fromdt, datetoo, region, pubcode, temp_category, compcode, dateformat, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtype, temp_pubcent, temp_edition, execode, temp_state, temp_district, temp_client, temp_newcategory, orderby);
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

            int dealcount = 0;
            int cont = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                if (ds.Tables[0].Rows[i]["Dealname"].ToString() == "" || ds.Tables[0].Rows[i]["Dealname"].ToString() == "0")
                {

                }
                else
                {
                    dealcount++;
                }

            }
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

            string ffdd = "", ffddag = "";

            BoundColumn nameColumn0 = new BoundColumn();
            nameColumn0.HeaderText = "S.No";
            DataGrid1.Columns.Add(nameColumn0);

            if (orderby == "Publication")
            {
                BoundColumn nameColumn = new BoundColumn();
                nameColumn.HeaderText = "Publication";
                nameColumn.DataField = "Publication";
                name1 = name1 + "," + "Publication";
                name2 = name2 + "," + "Publication";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn);
            }
            else if (orderby == "Region")
            {
                BoundColumn nameColumn = new BoundColumn();
                nameColumn.HeaderText = "Region";
                nameColumn.DataField = "Region";
                name1 = name1 + "," + "Region";
                name2 = name2 + "," + "Region";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn);
            }
            else if (orderby == "Agency Region")
            {
                BoundColumn nameColumn = new BoundColumn();
                nameColumn.HeaderText = "Region";
                nameColumn.DataField = "Region";
                name1 = name1 + "," + "Region";
                name2 = name2 + "," + "Region";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn);

                BoundColumn nameColumnag = new BoundColumn();
                nameColumnag.HeaderText = "Agency";
                nameColumnag.DataField = "Agency";
                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "Agency";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumnag);
            }
           

            BoundColumn nameColumn1 = new BoundColumn();
            nameColumn1.HeaderText = "Booking Id";
            nameColumn1.DataField = "CIOID";
            name1 = name1 + "," + "Booking ID";
            name2 = name2 + "," + "CIOID";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn1);

            if (orderby != "Agency Region")
            {
                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Agency";
                nameColumn2.DataField = "Agency";
                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "Agency";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);
            }

            
                BoundColumn nameColumn3 = new BoundColumn();
                nameColumn3.HeaderText = "Client";
                nameColumn3.DataField = "Client";
                name1 = name1 + "," + "Client";
                name2 = name2 + "," + "Client";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn3);


                if (orderby == "Extra Rebate")
                {
                    BoundColumn nameColumn4 = new BoundColumn();
                    nameColumn4.HeaderText = "Publication";
                    nameColumn4.DataField = "Publication";
                    name1 = name1 + "," + "Publication";
                    name2 = name2 + "," + "Publication";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn4);
                }


            BoundColumn nameColumn5 = new BoundColumn();
            nameColumn5.HeaderText = "Area";
            nameColumn5.DataField = "Area";
            name1 = name1 + "," + "Area";
            name2 = name2 + "," + "Area";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn5);

            BoundColumn nameColumn6 = new BoundColumn();
            nameColumn6.HeaderText = "BillAmt";
            nameColumn6.DataField = "BillAmt";
            name1 = name1 + "," + "BillAmt";
            name2 = name2 + "," + "BillAmt";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn6);

            
            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "SpecialDisc";
            nameColumn7.DataField = "SpecialDisc";
            name1 = name1 + "," + "SpecialDisc";
            name2 = name2 + "," + "SpecialDisc";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);



            BoundColumn nameColumn9 = new BoundColumn();
            nameColumn9.HeaderText = "SpaceDisc";
            nameColumn9.DataField = "SpaceDisc";
            name1 = name1 + "," + "SpaceDisc";
            name2 = name2 + "," + "SpaceDisc";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn9);

            BoundColumn nameColumn10 = new BoundColumn();
            nameColumn10.HeaderText = "SpecialDisc%";
            nameColumn10.DataField = "SpecialDisc%";
            name1 = name1 + "," + "SpecialDisc%";
            name2 = name2 + "," + "SpecialDisc%";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn10);

            BoundColumn nameColumn11 = new BoundColumn();
            nameColumn11.HeaderText = "SpaceDisc%";
            nameColumn11.DataField = "SpaceDisc%";
            name1 = name1 + "," + "SpaceDisc%";
            name2 = name2 + "," + "SpaceDisc%";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn11);
       
            BoundColumn nameColumn12 = new BoundColumn();
            nameColumn12.HeaderText = "CardRate";
            nameColumn12.DataField = "CardRate";
            name1 = name1 + "," + "CardRate";
            name2 = name2 + "," + "CardRate";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn12);

            BoundColumn nameColumn13 = new BoundColumn();
            nameColumn13.HeaderText = "AgreedRate";
            nameColumn13.DataField = "AgreedRate";
            name1 = name1 + "," + "AgreedRate";
            name2 = name2 + "," + "AgreedRate";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn13);

            BoundColumn nameColumn14 = new BoundColumn();
            nameColumn14.HeaderText = "Disc";
            nameColumn14.DataField = "Disc";
            name1 = name1 + "," + "Disc";
            name2 = name2 + "," + "Disc";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn14);

            BoundColumn nameColumn15 = new BoundColumn();
            nameColumn15.HeaderText = "RevenueCenter";
            nameColumn15.DataField = "RevenueCenter";
            name1 = name1 + "," + "RevenueCenter";
            name2 = name2 + "," + "RevenueCenter";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn15);
            if (dealcount > 0)
            {
                BoundColumn nameColumn16 = new BoundColumn();
                nameColumn16.HeaderText = "Dealname";
                nameColumn16.DataField = "Dealname";
                name1 = name1 + "," + "Dealname";
                name2 = name2 + "," + "Dealname";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn16);
               }
            

            //BoundColumn nameColumn8 = new BoundColumn();
            //nameColumn8.HeaderText = "Area";
            //nameColumn8.DataField = "Area";
            //DataGrid1.Columns.Add(nameColumn8);


            
            DataGrid1.DataSource = ds;
           if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            string headexcel = "";
            DataSet ds11 = new DataSet();
            ds11.ReadXml(Server.MapPath("XML/disschreg.xml"));
            if (orderby == "Publication")
            {
                headexcel = ds11.Tables[0].Rows[0].ItemArray[34].ToString();
            }
            else if (orderby == "Region")
            {
                headexcel = ds11.Tables[0].Rows[0].ItemArray[33].ToString();
            }
            else if (orderby == "Agency Region")
            {
                headexcel = ds11.Tables[0].Rows[0].ItemArray[75].ToString();
            }
            else if (orderby == "Extra Rebate")
            {
                headexcel = ds11.Tables[0].Rows[0].ItemArray[35].ToString();
            }

           // hw.Write("<p align=\"center\">" + headexcel);



            hw.Write("<table border=\"1\"><tr><td colspan=\"15\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
           // hw.Write("<p <tr><td colspan=\"15\"align=\"center\"><b>" Report Wise  "</b></td></tr>");   
              hw.Write("<p <table border=\"1\"><tr><td colspan=\"15\"align=\"center\"><b>Rebate Report Agency Region wise</b></td></tr>");   

            hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + "From Date:" + lblfrom.Text + "</b></td><td colspan=\"5\"align=\"center\"><b>" + "To Date:" + lblto.Text + "</b></td><td colspan=\"5\"align=\"right\"><b>" + "Run Date:" + rundate + "</b></td></tr>");   
            
            hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + "Publication:" + lblpublication.Text + "</b></td><td colspan=\"5\"align=\"center\"><b>" + "Executive:" + lblexecutive.Text + "</b></td><td colspan=\"5\"align=\"right\"><b>" + "Adtype:" + lbladtype.Text  + "</b></td>");
            hw.Write("<p <tr><td colspan=\"5\"align=\"left\"><b>" + "Region:" + lblregion.Text + "</b></td><td colspan=\"5\"align=\"center\"><b>" + "Include Deals:" + lbldeal.Text + "</b></td></tr>"); 
                     
             hw.WriteBreak();

            DataGrid1.RenderControl(hw);

            int sno11 = cont;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td align=\"right\" colspan=\"4\">TOTAL</td><td align=\"right\" >" + amtnew + "</td><td align=\"right\" >" + billablearea + "</td></tr></table>"));
           // Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + "sn" + "</td><td align=\"right\" colspan=\"15\">TOTAL</td><td align=\"right\" >" + "amt" + "</td><td align=\"right\" >" + "area" + "</td></tr></table>"));
        }
        else
        {

            string[] names = name2.Substring(1, name2.Length - 1).Split(',');
            string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
            string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
            string[][] colProperties ={ names, captions, formats };

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
    


    private void pdf(string frmdt, string todate, string compcode, string region, string product, string dateformate)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int count = 0;
        //=======================================WATERMARK=========================================

       

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);

        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------
         int NumColumns=15;
        
            // NumColumns = 15;
        
        
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //    SqlDataAdapter da = new SqlDataAdapter();

            //    ds = obj.valuereportregion(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}


            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            //    ds = obj.rebatebilling(frmdt, todate, region, pubcode, temp_category, compcode, dateformate, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtype, temp_pubcent, temp_edition, execode, temp_state, temp_district, temp_client, temp_newcategory, orderby);
            //}


            
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);

            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            if (orderby == "Publication")
            {
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[34].ToString(), font9));
            }
            else if (orderby == "Region")
            {
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[33].ToString(), font9));
            }
            else if (orderby == "Agency Region")
            {
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[75].ToString(), font9));
            }
            else if (orderby == "Extra Rebate")
            {
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[35].ToString(), font9));
            }
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");

            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }
            int dealcount = 0;
           
            int cont = ds.Tables[0].Rows.Count;
            for (int iq = 0; iq <= cont - 1; iq++)
            {
                if (ds.Tables[0].Rows[iq]["Dealname"].ToString() == "" || ds.Tables[0].Rows[iq]["Dealname"].ToString() == "0")
                {

                }
                else
                {
                    dealcount++;
                }

            }
            if (dealcount > 0)
                NumColumns = 16;

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(fromdt.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


              PdfPTable tbl211 = new PdfPTable(6);
              tbl211.DefaultCell.BorderWidth = 0;
              tbl211.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
              tbl211.addCell(new Phrase("Publication:", font10));
              tbl211.addCell(new Phrase(lblpublication.Text, font11));
              tbl211.addCell(new Phrase("Executive:", font10));
              tbl211.addCell(new Phrase( lblexecutive.Text, font11));
              tbl211.addCell(new Phrase("Adtype", font10));
              tbl211.addCell(new Phrase(lbladtype.Text, font11));
              tbl211.addCell(new Phrase("Region:", font10));
              tbl211.addCell(new Phrase(lblregion.Text, font11));
              tbl211.addCell(new Phrase("Include Deals:", font10));
              tbl211.addCell(new Phrase(lbldeal.Text, font11));
              tbl211.addCell(new Phrase("", font10));
              tbl211.addCell(new Phrase("", font11));
              tbl211.WidthPercentage = 100;
              document.Add(tbl211);



            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;


          /*  datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;*/
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
     
    if (orderby == "Publication")
    {
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));//pub
    }
    else if (orderby == "Region")
    {
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));//region
    }
    else if (orderby == "Agency Region")
    {
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));//region
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));//agency
    }
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));//cio
    if (orderby != "Agency Region")
    {
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));//agency
    }
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));//client
    if (orderby == "Extra Rebate")
    {
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));//pub
    }
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));//area
    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));//billamt
    
    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[9].ToString(), font10));//specialdesc
    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[10].ToString(), font10));//spacedesc
    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[11].ToString(), font10));//specialdesc%
    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[12].ToString(), font10));//spacedesc%
    
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));//cardrate
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));//aggrate
    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[23].ToString(), font10));//disc
    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));//revenuecenter

    if (dealcount > 0)
    {
       // lbldeal.Text = "YES";
        datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[76].ToString(), font10));//revenuecenter
    }
    else
    {
        //lbldeal.Text = "NO";
    }
            datatable.HeaderRows = 1;


            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;

            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));

            document.Add(p2);


            //------------------//-------------------------------------------------------------------       
           
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;

            int i1 = 1;
            int contc = ds.Tables[0].Columns.Count;
            double[] arr1 = new double[contc];
          

            while (row < ds.Tables[0].Rows.Count)
            {
               // int ddd = row + 1;
                if (row > 0 && orderby !="Extra Rebate")//for adcat total
                {

                    if (orderby != "Agency Region")
                    {
                        if ((ds.Tables[0].Rows[row][orderby].ToString() != ds.Tables[0].Rows[row - 1][orderby].ToString()))
                        {
                            datatable.addCell(new iTextSharp.text.Phrase("Total", font10));
                            //datatable.addCell(new iTextSharp.text.Phrase( "Total", font10));

                            for (int abc = 0; abc <= 3; abc++)
                            {
                                datatable.addCell(new iTextSharp.text.Phrase("", font11));
                            }

                            int i11 = 3;
                            arr1[0] = 0;
                            arr1[1] = 0;
                            for (int j11 = dd2; j11 < i1 - 1; j11++)
                            {

                                if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                {
                                    arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                }
                                else
                                {
                                    arr1[0] = arr1[0] + 0;
                                }

                                if (ds.Tables[0].Rows[j11]["BillAmt"].ToString() != "")
                                {
                                    arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["BillAmt"].ToString());
                                }

                                else
                                {
                                    arr1[1] = arr1[1] + 0;
                                }
                            }
                            dd2 = Convert.ToInt32(i1 - 1);
                            for (int k11 = 0; k11 <= 1; k11++)
                            {
                                datatable.addCell(new iTextSharp.text.Phrase(arr1[k11].ToString(), font11));
                                //datatable.addCell(new iTextSharp.text.Phrase(arr1[k11].ToString(), font11));
                            }

                            for (int abc = 0; abc < 8; abc++)
                            {
                                datatable.addCell(new iTextSharp.text.Phrase("", font11));
                            }
                        }
                    }
                    else
                    {
                        if ((ds.Tables[0].Rows[row]["Region"].ToString() != ds.Tables[0].Rows[row - 1]["Region"].ToString()))
                        {
                            datatable.addCell(new iTextSharp.text.Phrase("Total", font10));
                            //datatable.addCell(new iTextSharp.text.Phrase( "Total", font10));

                            for (int abc = 0; abc <= 3; abc++)
                            {
                                datatable.addCell(new iTextSharp.text.Phrase("", font11));
                            }

                            int i11 = 3;
                            arr1[0] = 0;
                            arr1[1] = 0;
                            for (int j11 = dd2; j11 < i1 - 1; j11++)
                            {

                                if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                {
                                    arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                }
                                else
                                {
                                    arr1[0] = arr1[0] + 0;
                                }

                                if (ds.Tables[0].Rows[j11]["BillAmt"].ToString() != "")
                                {
                                    arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["BillAmt"].ToString());
                                }

                                else
                                {
                                    arr1[1] = arr1[1] + 0;
                                }
                            }
                            dd2 = Convert.ToInt32(i1 - 1);
                            for (int k11 = 0; k11 <= 1; k11++)
                            {
                                datatable.addCell(new iTextSharp.text.Phrase(arr1[k11].ToString(), font11));
                                //datatable.addCell(new iTextSharp.text.Phrase(arr1[k11].ToString(), font11));
                            }

                            for (int abc = 0; abc < 8; abc++)
                            {
                                datatable.addCell(new iTextSharp.text.Phrase("", font11));
                            }
                        }
                    }

                }//for adcat total
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));

                if (orderby == "Publication")
                {
                   // datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                    if (row == 0)
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));

                    }
                    else
                    {
                        if (ds.Tables[0].Rows[row]["Publication"].ToString() != ds.Tables[0].Rows[row - 1]["Publication"].ToString())
                        {
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));

                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font11));

                        }
                    }
                }
                else if (orderby == "Region")
                {
                    //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                    if (row == 0)
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));

                    }
                    else
                    {
                        if (ds.Tables[0].Rows[row]["Region"].ToString() != ds.Tables[0].Rows[row - 1]["Region"].ToString())
                        {
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));

                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font11));

                        }
                    }
                }
                else if (orderby == "Agency Region")
                {
                   // datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                    if (row == 0)
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));

                    }
                    else
                    {
                        if (ds.Tables[0].Rows[row]["Region"].ToString() != ds.Tables[0].Rows[row - 1]["Region"].ToString())
                        {
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));

                        }
                        else
                        {
                            datatable.addCell(new Phrase("", font11));

                        }
                    }
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));

                if (orderby != "Agency Region")
                {
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                if (orderby == "Extra Rebate")
                {
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());

               
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SpecialDisc"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SpaceDisc"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SpecialDisc%"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SpaceDisc%"].ToString(), font11));
                
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["DISC"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));

                if (ds.Tables[0].Rows[row]["Dealname"].ToString() == "" || ds.Tables[0].Rows[row]["Dealname"].ToString() == "0")
                {
                    if (dealcount > 0)
                    {
                        datatable.addCell(new Phrase("", font11));
                    }
                }
                else
                {
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Dealname"].ToString(), font11));

                }
           
                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(15);
            float[] headerwidths5 = { 10,6,6,6,5,5,5,5,5,6,5,5,10,10,10 };//,10,10,9,9,9,9 };//, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            
            
            
            
           
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("Total: ", font11));          
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
           // tbltotal.addCell(new Phrase("Area: " + area.ToString(), font10));
            //tbltotal.addCell(new Phrase("Amt: " + BillAmt.ToString(), font10));
           // tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase("   " + area.ToString(), font10));
            tbltotal.addCell(new Phrase("   " + BillAmt.ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("" + amtnew.ToString(), font11));
            //document.Add(tbltotal);
            tbltotal.DefaultCell.Colspan = 15;
            tbltotal.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;

            document.Add(tbltotal);

             document.Close();



          Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_rebaterep_print"] = "fromdate~" + fromdt + "~dateto~" + dateto + "~destination~" + destination + "~region~" + regionname + "~regcode~" + region + "~orderby~" + orderby + "~adtype~" + adtype + "~publication~" + pubcode + "~publname~" + publication + "~adtypename~" + adtypename + "~incname~" + incname + "~inccode~" + inccode + "~exename~" + exename + "~execode~" + execode;
           Response.Redirect("printrebatereport.aspx");
//        Response.Redirect("printrebatereport.aspx?fromdate=" + fromdt + "&dateto=" + dateto + "&destination=" + destination + "&region=" + regionname + "&regcode=" + region + "&orderby=" + orderby + "&adtype=" + adtype + "&publication=" + pubcode + "&publname=" + publication + "&adtypename=" + adtypename + "&exename=" + exename + "&execode=" + execode);
       
    }

    //=========================================================================================

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = "";
        if (orderby == "Extra Rebate")
            cioidchk = e.Item.Cells[1].Text;
        else if (orderby != "Agency Region")
            cioidchk = e.Item.Cells[2].Text;
        else
            cioidchk = e.Item.Cells[3].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check = e.Item.Cells[5].Text;
        string amt = e.Item.Cells[5].Text;

        if (check != "Area")
        {
            if (check != "&nbsp;")
            {
                string totalarea = e.Item.Cells[5].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;
            }
        }
        string check2 = e.Item.Cells[6].Text;
        string billarean = e.Item.Cells[6].Text;

        if (check2 != "BillAmt")
        {
            if (check2 != "&nbsp;")
            {
                string billarea1 = e.Item.Cells[6].Text;
                billarea2 = Convert.ToDouble(billarea1);
                billablearea = billablearea + billarea2;
            }
        }
    }
}




