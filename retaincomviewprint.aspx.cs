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
using System.Data.OracleClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;

public partial class retaincomviewprint : System.Web.UI.Page
{

    string fromdt = "";
    string dateto = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string pdfName1 = "";
    string datefrom1 = "";
    string dateto1 = "";
    string region = "";

    string regionname = "";
    string editioncode = "";
    string editionname = "";
    string branchcode = "";
    string branchname = "";
    string Adtypecode = "";
    string Adtypename = "";
    string Retainercode = "";
    string Retainername = "";
    string product = "";
    string productname = "";

    string todate, fromdate, client, publication, adtype, billstatus, payment, agency = "";
    string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "";


    protected void Page_Load(object sender, EventArgs e)
    {

        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[41].ToString();


        dateto = Request.QueryString["dateto"].ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
       // destination = Request.QueryString["destination"].ToString();
        region = Request.QueryString["regioncode"].ToString();
        regionname = Request.QueryString["regionname"].ToString();
        editioncode = Request.QueryString["editioncode"].ToString();
        editionname = Request.QueryString["editionname"].ToString();
        branchcode = Request.QueryString["branchcode"].ToString();
        branchname = Request.QueryString["branchname"].ToString();
        Adtypecode = Request.QueryString["Adtypecode"].ToString();
        Adtypename = Request.QueryString["Adtypename"].ToString();
        Retainercode = Request.QueryString["Retainercode"].ToString();
        Retainername = Request.QueryString["Retainername"].ToString();

        product = Request.QueryString["productcode"].ToString();
        productname = Request.QueryString["productname"].ToString();

        lblfrom.Text = fromdt;
        lblto.Text = dateto;


        if (product == "0")
            {
                lblproduct.Text = "ALL".ToString();
            }
            else
            {
                lblproduct.Text = productname.ToString();
            }


            if (region == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = regionname.ToString();
            }

            if (editioncode == "0" || editioncode == "")
            {
                lbledition.Text = "ALL".ToString();
            }
            else
            {
                lbledition.Text = editionname.ToString();
            }

            if (branchcode == "0")
            {
                lblbranch.Text = "ALL".ToString();
            }
            else
            {
                lblbranch.Text = branchname.ToString();
            }

            if (Adtypecode == "0")
            {
                lbladtype11.Text = "ALL".ToString();
            }
            else
            {
                lbladtype11.Text = Adtypename.ToString();
            }

            if (Retainercode == "0")
            {
                lblretainer.Text = "ALL".ToString();
            }
            else
            {
                lblretainer.Text = Retainername.ToString();
            }

           
            //  hiddendateto.Value = dateto.ToString();
            // string dateformat = Request.QueryString["dateformat"].ToString();

            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = day + "/" + month + "/" + year;

            }
            else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = month + "/" + day + "/" + year;

             }
             else if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
             {

                        DateTime dt = System.DateTime.Now;


                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        date = year + "/" + month + "/" + day;

             }
            lbldate.Text = date.ToString();
            //datefrom1 = "";
            if (fromdt != "")
            {

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                            string[] arr = fromdt.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            datefrom1 = mm + "/" + dd + "/" + yy;

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


            if (dateto != "")
            {


                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = mm + "/" + dd + "/" + yy;

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

            
        onscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());
        //Response.Redirect("window.print();");


    }

    private void onscreen(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {


        //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        //    ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();

        //   fromdate,  dateto,  region,  product, compcode, dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string branch ,string edition ,string retainer ,string addtype) 
        ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchname, editioncode, Retainercode, Adtypecode);




        //}
        //else
        //{
        //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
        //    //ds = pub.product(region, Session["compcode"].ToString());
        //}

        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='3' cellspacing='0'>";


        //tbl = tbl + "<tr><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='2px'>&nbsp;</td></tr>";

        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Publication</td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>RetainerName</td><td class='middle3'>RetainerCom</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>Revenuecenter</td>");


        //if (hiddenascdesc.Value == "")
        //{
        //    //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>Retainer</br>Name<img id='imgretdown' src='Images\\down.gif' style='display:block;'><img id='imgretup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~28' class='middle3'  onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~2' class='middle3' onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td id='tdreatain~28' class='middle3'   onclick=sorting('RetainerCommision',this.id)>RetainCom<img id='imgretaindown' src='Images\\down.gif' style='display:block;'><img id='imgretainup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='td~291' class='middle3' onclick=sorting('BillAmt',this.id)>BillAmount<img id='img291down' src='Images\\down.gif' style='display:block;'><img id='img291up' src='Images\\up.gif' style='display:none;'></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td>        <td id='tdbbarea' class='middle3'   onclick=sorting('BillableArea',this.id)>BillableArea<img id='imgbareadown' src='Images\\down.gif' style='display:block;'><img id='imgbareaup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdret~7' class='middle3' >Retainer</br>Name</td><td id='tdro~28' class='middle3'  > CIOID</td><td id='tdag~2' class='middle3' >Agency</td><td id='tdcli~3' class='middle3' >Client</td><td id='tdpub~4' class='middle3' >Publication</td> <td id='tdreatain~28' class='middle3'  >Retainer</br>Commision</td><td id='tdro~25' class='middle3' >Area</td><td id='td~291' class='middle3' >Bill</br>Amount</td><td id='tdbill~11' class='middle3' >Bill</br>Status</td>    <td id='trevec~13' class='middle3' >Revenue</br>Center</td></tr>");

        //}
        //else if (hiddenascdesc.Value == "asc")
        //{

        //    //tbl = tbl + ("<tr><td class='middle31' >S.No.</td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>Retainer</br>Name<img id='imgretdown' src='Images\\down.gif' style='display:block;'><img id='imgretup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~28' class='middle3'  onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td id='tdreatain~28' class='middle3'   onclick=sorting('RetainerCommision',this.id)> RetainCom<img id='imgretaindown' src='Images\\down.gif' style='display:block;'><img id='imgretainup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'  onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='td~291' class='middle3' onclick=sorting('BillAmt',this.id)>BillAmount<img id='img291down' src='Images\\down.gif' style='display:block;'><img id='img291up' src='Images\\up.gif' style='display:none;'></td></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td>  <td id='tdbbarea' class='middle3'    onclick=sorting('BillableArea',this.id)>BillableArea<img id='imgbareadown' src='Images\\down.gif' style='display:block;'><img id='imgbareaup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
        //    tbl = tbl + ("<tr><td class='middle31' >S.No.</td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>Retainer</br>Name<img id='imgretdown' src='Images\\down.gif' style='display:block;'><img id='imgretup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~28' class='middle3'  onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tdreatain~28' class='middle3'   onclick=sorting('RetainerCommision',this.id)> Retainer</br>Commision<img id='imgretaindown' src='Images\\down.gif' style='display:block;'><img id='imgretainup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'  onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td><td id='td~291' class='middle3' onclick=sorting('BillAmt',this.id)>Bill</br>Amount<img id='img291down' src='Images\\down.gif' style='display:block;'><img id='img291up' src='Images\\up.gif' style='display:none;'></td></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>Bill</br>Status<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td>  <td id='tdbbarea' class='middle3'    onclick=sorting('BillableArea',this.id)>Billable</br>Area<img id='imgbareadown' src='Images\\down.gif' style='display:block;'><img id='imgbareaup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>Revenue</br>Center<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");


        //}
        //else if (hiddenascdesc.Value == "desc")
        //{

        //    //tbl = tbl + ("<tr><td class='middle31' >S.No.</td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>Retainer</br>Name<img id='imgretdown' src='Images\\down.gif' style='display:none;'><img id='imgretup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~28' class='middle3'  onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:none;'><img id='img28up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td id='tdreatain~28' class='middle3'  onclick=sorting('RetainerCommision',this.id)> RetainCom<img id='imgretaindown' src='Images\\down.gif' style='display:none;'><img id='imgretainup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle3'    onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td id='td~291' class='middle3' onclick=sorting('BillAmt',this.id)>BillAmount<img id='img291down' src='Images\\down.gif' style='display:none;'> <img id='img291up' src='Images\\up.gif' style='display:block;'></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td>     <td id='tdbbarea' class='middle3'    onclick=sorting('BillableArea',this.id)>BillableArea<img id='imgbareadown' src='Images\\down.gif' style='display:none;'><img id='imgbareaup' src='Images\\up.gif' style='display:block;'></td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");

        //    tbl = tbl + ("<tr><td class='middle31' >S.No.</td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>Retainer</br>Name<img id='imgretdown' src='Images\\down.gif' style='display:none;'><img id='imgretup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~28' class='middle3'  onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:none;'><img id='img28up' src='Images\\up.gif' style='display:block;'></td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tdreatain~28' class='middle3'  onclick=sorting('RetainerCommision',this.id)> Retainer</br>Commision<img id='imgretaindown' src='Images\\down.gif' style='display:none;'><img id='imgretainup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle3'    onclick=sorting('Area',this.id)>Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td><td id='td~291' class='middle3' onclick=sorting('BillAmt',this.id)>Bill</br>Amount<img id='img291down' src='Images\\down.gif' style='display:none;'> <img id='img291up' src='Images\\up.gif' style='display:block;'></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>Bill</br>Status<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td>     <td id='tdbbarea' class='middle3'    onclick=sorting('BillableArea',this.id)>Billable</br>Area<img id='imgbareadown' src='Images\\down.gif' style='display:none;'><img id='imgbareaup' src='Images\\up.gif' style='display:block;'></td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>Revenue</br>Center<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");

        //}


        int i1 = 1;
        float area = 0;
        double BillAmt = 0;
        double subBillAmt = 0.0;
        double totalretainercomm = 0.0;
        //  int chktotal = 0;
        double subretainercomm = 0.0;
        //  double retainercomm = 0.0;
        for (int i = 0; i <= cont - 1; i++)
        {

            if (ds.Tables[0].Rows[i]["RetainName"].ToString() != "")
            {


                /***************************            FOR page break by shachi       *******************************/
                //if ((i % 16 == 0) && (i != 0))
                //{
                //    tbl = tbl + "<tr class='pagebreak11' ></tr>";
                //}
                //if (i == 16)
                //{
                //    tbl = tbl + "<tr class='pagebreak11'></tr>";
                //}
                //else if ((i - 16) % 24 == 0)
                //{
                //    tbl = tbl + "<tr class='pagebreak11' ></tr>";
                //}


                if (i == 0)
                {
                    tbl = tbl + "<tr><td colspan='11'><table class='pagebreak11' width='100%'align='left' cellpadding='3' cellspacing='0'>";
                    tbl = tbl + "<tr><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                    tbl = tbl + ("<tr><td class='middle31' align='left' width='15px' >S.No.</td><td id='tdret~7' class='middle3' align='left' width='65px' >Retainer</br>&nbsp;&nbsp;Name</td><td id='tdro~28' class='middle3' align='left'  width='65px' > CIOID</td><td id='tdag~2' class='middle3' align='left' width='120px' >Agency</td><td id='tdcli~3' class='middle3' align='left'  width='120px' >Client</td><td id='tdpub~4' class='middle3' align='left'  width='85px' >Publication</td> <td id='tdreatain~28' class='middle3'  width='55px' >&nbsp;&nbsp;Retainer</br>Commision</td><td id='tdro~25' class='middle3'  width='30px' >Area</td><td id='td~291' class='middle3'  width='45px'>&nbsp;&nbsp;Bill</br>Amount</td><td id='tdbill~11' class='middle3' align='left'  width='55px'>&nbsp;&nbsp;Bill</br>Status</td>    <td id='trevec~13' class='middle3' align='left'  width='85px'>Revenue</br>Center</td></tr>");
                }
                else if ((i - 14) % 20 == 0)
                {

                    /****************************            for subtotal            ************************/
                    if ((ds.Tables[0].Rows[i]["RetainName"].ToString()) != (ds.Tables[0].Rows[(i - 1)]["RetainName"].ToString()))
                    {

                        tbl = tbl + ("<tr >");


                        tbl = tbl + ("<td class='rep_data' colspan='2'>");
                        tbl = tbl + "<b>" + "Sub Total:" + "</b>" + "</td>";
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data' >");
                        tbl = tbl + "</td>";


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data' align='right'>") + "<b>" + subretainercomm + "</b>";
                        tbl = tbl + "</td>";
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data' align='right'>") + "<b>" + subBillAmt + "</b>";
                        tbl = tbl + "</td>";

                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + "</tr>";

                    }   
                   

                    /****************************************************************************************/


                    tbl = tbl + "</table ></td></tr>";

                    tbl = tbl + "<tr><td colspan='11'><table class='pagebreak11' width='100%'align='left' cellpadding='3' cellspacing='0'>";
                    tbl = tbl + "<tr><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                    tbl = tbl + ("<tr><td class='middle31' align='left' width='15px' >S.No.</td><td id='tdret~7' class='middle3' align='left' width='65px' >Retainer</br>&nbsp;&nbsp;Name</td><td id='tdro~28' class='middle3'align='left'  width='65px'  > CIOID</td><td id='tdag~2' class='middle3' align='left'  width='120px' >Agency</td><td id='tdcli~3' class='middle3' align='left'  width='120px' >Client</td><td id='tdpub~4' class='middle3' align='left'  width='85px'>Publication</td> <td id='tdreatain~28' class='middle3'  width='55px' >&nbsp;&nbsp;Retainer</br>Commision</td><td id='tdro~25' class='middle3' width='30px' >Area</td><td id='td~291' class='middle3'  width='45px'>&nbsp;&nbsp;Bill</br>Amount</td><td id='tdbill~11' class='middle3' align='left'  width='55px'>&nbsp;&nbsp;Bill</br>Status</td>    <td id='trevec~13' class='middle3' align='left'  width='85px'>Revenue</br>Center</td></tr>");
                }



                /******************************                new  for diff retainer name             ****************/

                if (i > 0)
                {
                    if ((ds.Tables[0].Rows[i]["RetainName"].ToString()) == (ds.Tables[0].Rows[(i - 1)]["RetainName"].ToString()))
                    {





                        tbl = tbl + ("<tr >");


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (i1++.ToString() + "</td>");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";
                        // tbl = tbl + (ds.Tables[0].Rows[i]["RetainName"] + "</td>");
                        //-------------------------------------------//
                        string cioid1 = "";
                        string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
                        char[] cioid = rrr.ToCharArray();
                        int len11 = cioid.Length;

                        for (int ch = 0; ch < len11; ch++)
                        {

                            if (ch == 0)
                            {
                                cioid1 = cioid1 + cioid[ch];
                            }
                            else if (ch % 9 != 0)
                            {
                                cioid1 = cioid1 + cioid[ch];
                            }
                            else
                            {
                                cioid1 = cioid1 + "</br>" + cioid[ch];
                            }
                        }
                        //----------------------------------------------------------------///


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (cioid1 + "</td>");


                        //-------------------------------------------//
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                        char[] agency = rrr1.ToCharArray();
                        int len111 = agency.Length;
                        int line11 = 0;
                        for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                        {

                            if (ch1 == 0)
                            {
                                agency1 = agency1 + agency[ch1];
                            }
                            else if (ch1 % 20 != 0)
                            {
                                agency1 = agency1 + agency[ch1];
                            }
                            else
                            {
                                line11 = line11 + 1;
                                if (line11 != 2)
                                {
                                    agency1 = agency1 + "</br>" + agency[ch1];
                                }
                            }
                        }
                        //----------------------------------------------------------------///
                        tbl = tbl + ("<td class='rep_data' >");
                        tbl = tbl + (agency1 + "</td>");

                        //-------------------------------------------//
                        string client1 = "";
                        string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
                        char[] client = rrr11.ToCharArray();
                        int len1111 = client.Length;
                        int line = 0;

                        for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                        {

                            if (ch11 == 0)
                            {
                                client1 = client1 + client[ch11];
                            }
                            else if (ch11 % 20 != 0)
                            {
                                client1 = client1 + client[ch11];
                            }
                            else
                            {

                                line = line + 1;
                                if (line != 2)
                                {
                                    client1 = client1 + "</br>" + client[ch11];

                                }



                            }


                        }
                        //----------------------------------------------------------------///


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (client1 + "</td>");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");


                        // tbl = tbl + (ds.Tables[0].Rows[i]["RetainName"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                        if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                            area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                        tbl = tbl + bill11.ToString("F2") + "</td>";
                        //tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
                        if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                        {
                            //            BillAmt = BillAmt + float.Parse(ds.Tables[0].Rows[i].ItemArray[6].ToString());
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                            subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                        }
                        
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
                        //if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                        //    billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

                        tbl = tbl + "</tr>";

                        if (ds.Tables[0].Rows[i]["RetainerCommision"].ToString() != "")
                        {
                            subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                            totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                        }


                    }
                    else
                    {
                        /****************************            for subtotal            ************************/

                        if ((i - 14) % 20 != 0)
                        {


                            tbl = tbl + ("<tr >");


                            tbl = tbl + ("<td class='rep_data' colspan='2'>");
                            tbl = tbl + "<b>" + "Sub Total:" + "</b>" + "</td>";
                            //tbl = tbl + ("<td class='rep_data'>");
                            //tbl = tbl + "</td>";

                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + "</td>";

                            tbl = tbl + ("<td class='rep_data' >");
                            tbl = tbl + "</td>";


                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + "</td>";
                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + "</td>";

                            tbl = tbl + ("<td class='rep_data' align='right'>") + "<b>" + subretainercomm + "</b>";
                            tbl = tbl + "</td>";
                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + "</td>";

                            tbl = tbl + ("<td class='rep_data' align='right'>") + "<b>" + subBillAmt.ToString("F2") + "</b>";
                            tbl = tbl + "</td>";

                            //tbl = tbl + ("<td class='rep_data'>");
                            //tbl = tbl + "</td>";
                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + "</td>";

                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + "</td>";

                            tbl = tbl + "</tr>";


                        }

                      
                        
                        /****************************************************************************************/




                        /***************************************************************************************/

                        subretainercomm = 0.0;
                        subBillAmt = 0.0;


                        tbl = tbl + ("<tr class='pagebreaknot'>");


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (i1++.ToString() + "</td>");

                        //-------------------------------------------//
                        string retname = "";
                        string retname11 = ds.Tables[0].Rows[i]["RetainName"].ToString();
                        char[] retname111 = retname11.ToCharArray();
                        int length11 = retname111.Length;

                        for (int chnew = 0; chnew < length11; chnew++)
                        {

                            if (chnew == 0)
                            {
                                retname = retname + retname111[chnew];
                            }
                            else if (chnew % 15 != 0)
                            {
                                retname = retname + retname111[chnew];
                            }
                            else
                            {
                                retname = retname + "</br>" + retname111[chnew];
                            }
                        }
                        //----------------------------------------------------------------///


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl +"<b>"+ retname +"</b>" +"</td>";
                        //-------------------------------------------//
                        string cioid1 = "";
                        string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
                        char[] cioid = rrr.ToCharArray();
                        int len11 = cioid.Length;

                        for (int ch = 0; ch < len11; ch++)
                        {

                            if (ch == 0)
                            {
                                cioid1 = cioid1 + cioid[ch];
                            }
                            else if (ch % 9 != 0)
                            {
                                cioid1 = cioid1 + cioid[ch];
                            }
                            else
                            {
                                cioid1 = cioid1 + "</br>" + cioid[ch];
                            }
                        }
                        //----------------------------------------------------------------///


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (cioid1 + "</td>");


                        //-------------------------------------------//
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                        char[] agency = rrr1.ToCharArray();
                        int len111 = agency.Length;
                        int line11 = 0;
                        for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                        {

                            if (ch1 == 0)
                            {
                                agency1 = agency1 + agency[ch1];
                            }
                            else if (ch1 % 20 != 0)
                            {
                                agency1 = agency1 + agency[ch1];
                            }
                            else
                            {
                                line11 = line11 + 1;
                                if (line11 != 2)
                                {
                                    agency1 = agency1 + "</br>" + agency[ch1];
                                }
                            }
                        }
                        //----------------------------------------------------------------///
                        tbl = tbl + ("<td class='rep_data' >");
                        tbl = tbl + (agency1 + "</td>");

                        //-------------------------------------------//
                        string client1 = "";
                        string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
                        char[] client = rrr11.ToCharArray();
                        int len1111 = client.Length;
                        int line = 0;

                        for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                        {

                            if (ch11 == 0)
                            {
                                client1 = client1 + client[ch11];
                            }
                            else if (ch11 % 20 != 0)
                            {
                                client1 = client1 + client[ch11];
                            }
                            else
                            {

                                line = line + 1;
                                if (line != 2)
                                {
                                    client1 = client1 + "</br>" + client[ch11];

                                }



                            }


                        }
                        //----------------------------------------------------------------///


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (client1 + "</td>");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");


                        // tbl = tbl + (ds.Tables[0].Rows[i]["RetainName"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                        if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                            area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                        tbl = tbl + bill11.ToString("F2") + "</td>";
                        //tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
                        if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                        {

                            //            BillAmt = BillAmt + float.Parse(ds.Tables[0].Rows[i].ItemArray[6].ToString());
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                            subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                        }
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
                        //if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                        //    billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

                        tbl = tbl + "</tr>";


                        if (ds.Tables[0].Rows[i]["RetainerCommision"].ToString() != "")
                        {
                            subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                            totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                        }

                    }

                }
                else
                {

                    tbl = tbl + ("<tr >");


                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (i1++.ToString() + "</td>");

                    //-------------------------------------------//
                    string retname = "";
                    string retname11 = ds.Tables[0].Rows[i]["RetainName"].ToString();
                    char[] retname111 = retname11.ToCharArray();
                    int length11 = retname111.Length;

                    for (int chnew = 0; chnew < length11; chnew++)
                    {

                        if (chnew == 0)
                        {
                            retname = retname + retname111[chnew];
                        }
                        else if (chnew % 15 != 0)
                        {
                            retname = retname + retname111[chnew];
                        }
                        else
                        {
                            retname = retname + "</br>" + retname111[chnew];
                        }
                    }
                    //----------------------------------------------------------------///


                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl +"<b>" +retname +"</b>"+ "</td>";
                    //-------------------------------------------//
                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
                    char[] cioid = rrr.ToCharArray();
                    int len11 = cioid.Length;

                    for (int ch = 0; ch < len11; ch++)
                    {

                        if (ch == 0)
                        {
                            cioid1 = cioid1 + cioid[ch];
                        }
                        else if (ch % 9 != 0)
                        {
                            cioid1 = cioid1 + cioid[ch];
                        }
                        else
                        {
                            cioid1 = cioid1 + "</br>" + cioid[ch];
                        }
                    }
                    //----------------------------------------------------------------///


                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (cioid1 + "</td>");


                    //-------------------------------------------//
                    string agency1 = "";
                    string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                    char[] agency = rrr1.ToCharArray();
                    int len111 = agency.Length;
                    int line11 = 0;
                    for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                    {

                        if (ch1 == 0)
                        {
                            agency1 = agency1 + agency[ch1];
                        }
                        else if (ch1 % 20 != 0)
                        {
                            agency1 = agency1 + agency[ch1];
                        }
                        else
                        {
                            line11 = line11 + 1;
                            if (line11 != 2)
                            {
                                agency1 = agency1 + "</br>" + agency[ch1];
                            }
                        }
                    }
                    //----------------------------------------------------------------///
                    tbl = tbl + ("<td class='rep_data' >");
                    tbl = tbl + (agency1 + "</td>");

                    //-------------------------------------------//
                    string client1 = "";
                    string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
                    char[] client = rrr11.ToCharArray();
                    int len1111 = client.Length;
                    int line = 0;

                    for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                    {

                        if (ch11 == 0)
                        {
                            client1 = client1 + client[ch11];
                        }
                        else if (ch11 % 20 != 0)
                        {
                            client1 = client1 + client[ch11];
                        }
                        else
                        {

                            line = line + 1;
                            if (line != 2)
                            {
                                client1 = client1 + "</br>" + client[ch11];

                            }



                        }


                    }
                    //----------------------------------------------------------------///


                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (client1 + "</td>");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                    //tbl = tbl + ("<td class='rep_data'>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
                    //tbl = tbl + ("<td class='rep_data'>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");


                    // tbl = tbl + (ds.Tables[0].Rows[i]["RetainName"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                    if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                        area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
                    Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                    tbl = tbl + bill11.ToString("F2") + "</td>";
                    if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                    {
                        //            BillAmt = BillAmt + float.Parse(ds.Tables[0].Rows[i].ItemArray[6].ToString());
                        BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                        subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                    }
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
                    //tbl = tbl + ("<td class='rep_data'>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
                    //if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                    //    billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

                    tbl = tbl + "</tr>";

                    if (ds.Tables[0].Rows[i]["RetainerCommision"].ToString() != "")
                    {
                        subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                        totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                    }

                }


                //if (i == 16)
                //{
                //    tbl = tbl + "</table ></td></tr>";
                //}
                //else if ((i - 17) % 23 == 22)
                //{
                //    tbl = tbl + "</table ></td></tr>";
                //}

            }


        }


        /****************************            for subtotal            ************************/

        tbl = tbl + ("<tr >");


        tbl = tbl + ("<td class='rep_data' colspan='2'>");
        tbl = tbl + "<b>" + "Sub Total:" + "</b>" + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data' >");
        tbl = tbl + "</td>";


        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data' align='right'>") + "<b>" + subretainercomm + "</b>";
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data' align='right'>") + "<b>" + subBillAmt.ToString("F2") + "</b>";
        tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + "</tr>";


        tbl = tbl + "</table ></td></tr>";

        /****************************************************************************************/




        tbl = tbl + ("<tr >");
        // tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        // tbl = tbl + ("<tr >");

        /****************************            for total            ************************/

        //tbl = tbl + ("<tr >");


        //tbl = tbl + ("<td class='middle13' colspan='2'>");
        //tbl = tbl + "<b>" + "Total:" + "</b>" + "</td>";
        ////tbl = tbl + ("<td class='rep_data'>");
        ////tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data' >");
        //tbl = tbl + "</td>";


        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='middle13' style='font-size: 11px;' align='right'>");
        //tbl = tbl + "<b>" + totalretainercomm.ToString() + "</b>" + "</td>";

        ////  tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data' colspan='2' align='right' style='font-size: 11px;'>");
        //tbl = tbl + "<b>" + BillAmt.ToString() + "</b>" + "</td>";

        ////tbl = tbl + ("<td class='middle13' style='font-size: 11px;' align='right'>");
        ////tbl = tbl + "</td>";
        

        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        //tbl = tbl + "</tr>";


        //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

        tbl = tbl + ("<tr >");

        tbl = tbl + ("<td class='rep_data' colspan='1' style='font-size: 11px;'>");
        tbl = tbl + "<b>" + "Total " + "</b>" + "</td>";
       // tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' colspan='2' style='font-size: 11px;'>");
        tbl = tbl + "<b>" + "Retainer Commision: " + "<b>" + totalretainercomm.ToString() + "</b>" + "</b>" + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data' >");
        //tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' colspan='2' style='font-size: 11px;'>");
        tbl = tbl + "<b>" + "Bill Amount: " + "<b>" + BillAmt.ToString("F2") + "</b>" + "</b>" + "</td>";
       // tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data' >");
        //tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        
        tbl = tbl + "</td>";
       
        
        tbl = tbl + ("<td class='rep_data' >");
       // tbl = tbl + "<b>" + BillAmt.ToString() + "</b>";
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
       // tbl = tbl + "<b>" + totalretainercomm.ToString() + "</b>";
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        //tbl = tbl + "<b>" + totalretainercomm.ToString() + "</b>";
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        
        tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data' >");
        tbl = tbl + "</td>";
        

        tbl = tbl + "</tr>";

        tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        
        /****************************************************************************************/



        //tbl = tbl + ("<tr >");
        //// tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        //tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        //// tbl = tbl + ("<tr >");
        //// tbl = tbl + ("<td class='middle13'>");
        //// tbl = tbl + ("<tr><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
        //// tbl = tbl + ("<td class='middle13'>");
        //// tbl = tbl + (area.ToString() + "<td class='middle13'>TotalAmt</td><td class='middle13'></td></td>");
        //// tbl = tbl + ("<td class='middle13'>");
        //// tbl = tbl + (BillAmt.ToString() + "<td class='middle13'></td><td class='middle13'></td></td>");
        //// tbl = tbl + "</tr>";
        //tbl = tbl + ("<td class='middle13'>TotalAds</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ((i1 - 1).ToString() + "</td>");

        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td></td><td class='middle13'>Total</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (area.ToString() + "</td>");

        //tbl = tbl + ("<td class='middle13'></td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (BillAmt.ToString() + "<td class='middle13'> </td></td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
        //tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
        ///////////////////////////////////////////////////////////

        //tblgrid.InnerHtml = tbl;
        //double arr1 = BillAmt / billarea;
        //dytbl = dytbl + "<table>";
        //dytbl = dytbl + "<tr>";
        //dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
        //dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
        //dytbl = dytbl + ("<td class='middle13'>");
        //dytbl = dytbl + (arr1.ToString() + "</td>");
        //dytbl = dytbl + ("</tr>");
        //dytbl += "</table>";
        //dynamictable.Text = dytbl;
        ///////////////////////////////////////////////////////////       

    }

}
