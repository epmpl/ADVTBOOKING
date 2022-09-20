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
using System.Data.OracleClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
////using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;


public partial class Retaincomview : System.Web.UI.Page
{

    int sno = 1;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;
    double totalcommission = 0;




    string dytbl = "";
    string destination = "";
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
    string productname="";
    float area = 0;
    double BillAmt = 0;
    double billarea = 0;
    string temp_retain = "", temp_pubname = "", temp_pubcent, temp_prod, temp_category;
    string sortorder = "";
    string sortvalue = "";
    string myrange = "";
    string maxrange = "";
    string todate, fromdate, client, publication, adtype, billstatus, payment,  agency = "";
    string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[41].ToString();

        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

        lblfrom.Text = fromdt;
        lblto.Text = dateto;

        if (Request.QueryString["drilout"] == "yes")
        {
          
            region = Request.QueryString["region"].Trim().ToString();
            //product = Request.QueryString["product"].Trim().ToString();
            //category = Request.QueryString["category"].Trim().ToString();
            agency = Request.QueryString["agency"].Trim().ToString();
            client = Request.QueryString["client"].Trim().ToString();
            publication = Request.QueryString["publication"].Trim().ToString();
            adtype = Request.QueryString["adtype"].Trim().ToString();
            payment = Request.QueryString["payment"].Trim().ToString();
            billstatus = Request.QueryString["billstatus"].Trim().ToString();

            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
            myrange = Request.QueryString["myrange"].Trim().ToString();
            maxrange = Request.QueryString["userrange"].Trim().ToString();



            //drillonscreen(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype);

            destination = Request.QueryString["destination"].Trim().ToString();

            if (destination == "3")
            {
                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;




                pdf_drillout(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel_drillout(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype);
            }
            else if (destination == "1" || destination == "0")
            {
                drillonscreen(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype);

            }
        }
        else
        {

            // Response.Redirect("Retaincomview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&regioncode=" + dpregion.SelectedValue + "&productcode=" + dpprodcat.SelectedValue + "&editionname=" + drpedition.SelectedValue + "&branchcode=" + drpbranch.SelectedValue + "&Adtype=" + dpaddtype.SelectedValue + "&Retainer=" + drpretainer.SelectedValue);

            //DataSet ds1 = new DataSet();
            //ds1.ReadXml(Server.MapPath("XML/report1.xml"));

          //  "&regioncode=" + dpregion.SelectedValue + "&regionname=" + dpregion.SelectedItem + "&productcode=" + dpprodcat.SelectedValue + "&productname=" + dpprodcat.SelectedItem + "&editioncode=" + drpedition.SelectedValue + "&editionname=" + drpedition.SelectedItem + "&branchcode=" + drpbranch.SelectedValue + "&branchname=" + drpbranch.SelectedItem + "&Adtypecode=" + dpaddtype.SelectedValue + "&Adtypename=" + dpaddtype.SelectedItem + "&Retainercode=" + drpretainer.SelectedValue + "&Retainername=" + drpretainer.SelectedItem);

            dateto = Request.QueryString["dateto"].ToString();
            fromdt = Request.QueryString["fromdate"].ToString();
            destination = Request.QueryString["destination"].ToString();
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

            //  Ajax.Utility.RegisterTypeForAjax(typeof(NewRegisterbillingview));
            hiddendatefrom.Value = fromdt.ToString();
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
            else
                if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = month + "/" + day + "/" + year;

                }
                else
                    if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
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


                //DateTime dt = Convert.ToDateTime(fromdt.ToString());
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    datefrom1 = day + "/" + month + "/" + year;


                //}
                //else if (hiddendateformat.Value == "mm/dd/yyyy")
                //{
                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    datefrom1 = month + "/" + day + "/" + year;

                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{

                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    datefrom1 = year + "/" + month + "/" + day;
                //}
            }
          
            //dateto1 = "";
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
             //   }




                //DateTime dt = Convert.ToDateTime(dateto.ToString());
                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    dateto1 = day + "/" + month + "/" + year;

                //}
                //else if (hiddendateformat.Value == "mm/dd/yyyy")
                //{

                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    dateto1 = month + "/" + day + "/" + year;

                //}
                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{

                //    day = dt.Day.ToString();
                //    month = dt.Month.ToString();
                //    year = dt.Year.ToString();
                //    dateto1 = year + "/" + month + "/" + day;
                //}
            }
            
           // lbladtype11.Text = adtype;


            if (destination == "1" || destination == "0")
            {
              
                onscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());

            }
            else
                if (destination == "3")
                {
                    pdf(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }

        }

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

        tbl = tbl + "<tr><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        tbl = tbl + ("<tr><td class='middle31' align='left' width='15px' >S.No.</td><td id='tdret~7' class='middle3' align='left' >Retainer</br>Name</td><td id='tdro~28' class='middle3' align='left' > CIOID</td><td id='tdag~2' class='middle3' align='left' >Agency</td><td id='tdcli~3' class='middle3' align='left' >Client</td><td id='tdpub~4' class='middle3' align='left' >Publication</td> <td id='tdreatain~28' class='middle3' align='right' >Retainer&nbsp;&nbsp;&nbsp;</br>Commision</td><td id='tdro~25' class='middle3' align='right' >Area</td><td id='td~291' class='middle3' align='right' >Bill&nbsp;&nbsp;&nbsp;</br>Amount</td><td id='tdbill~11' class='middle3' align='left' >&nbsp;&nbsp;Bill</br>Status</td>    <td id='trevec~13' class='middle3' align='left' >Revenue</br>Center</td></tr>");
        



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
        float area=0;
        double BillAmt = 0.00;
        double subBillAmt = 0.00;
        double totalretainercomm = 0.00;
      //  int chktotal = 0;
        double subretainercomm = 0.00;
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


                //if (i == 0)
                //{
                //    tbl = tbl + "<tr><td colspan='11'><table class='pagebreak11' width='100%'align='left' cellpadding='3' cellspacing='0'>";
                //    tbl = tbl + "<tr><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                //    tbl = tbl + ("<tr><td class='middle31' align='left' width='15px' >S.No.</td><td id='tdret~7' class='middle3' align='left' width='65px' >Retainer</br>Name</td><td id='tdro~28' class='middle3' align='left'  width='65px' > CIOID</td><td id='tdag~2' class='middle3' align='left' width='120px' >Agency</td><td id='tdcli~3' class='middle3' align='left'  width='120px' >Client</td><td id='tdpub~4' class='middle3' align='left'  width='85px' >Publication</td> <td id='tdreatain~28' class='middle3'  width='55px' >Retainer</br>Commision</td><td id='tdro~25' class='middle3'  width='30px' >Area</td><td id='td~291' class='middle3'  width='45px'>Bill</br>Amount</td><td id='tdbill~11' class='middle3' align='left'  width='55px'>Bill</br>Status</td>    <td id='trevec~13' class='middle3' align='left'  width='85px'>Revenue</br>Center</td></tr>");
                //}
                //else if ((i - 17) % 23 == 0)
                //{
                //    tbl = tbl + "<tr><td colspan='11'><table class='pagebreak11' width='100%'align='left' cellpadding='3' cellspacing='0'>";
                //    tbl = tbl + "<tr><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='2px'>&nbsp;</td></tr>";
                //    tbl = tbl + ("<tr><td class='middle31' align='left' width='15px' >S.No.</td><td id='tdret~7' class='middle3' align='left' width='65px' >Retainer</br>Name</td><td id='tdro~28' class='middle3'align='left'  width='65px'  > CIOID</td><td id='tdag~2' class='middle3' align='left'  width='120px' >Agency</td><td id='tdcli~3' class='middle3' align='left'  width='120px' >Client</td><td id='tdpub~4' class='middle3' align='left'  width='85px'>Publication</td> <td id='tdreatain~28' class='middle3'  width='55px' >Retainer</br>Commision</td><td id='tdro~25' class='middle3' width='30px' >Area</td><td id='td~291' class='middle3'  width='45px'>Bill</br>Amount</td><td id='tdbill~11' class='middle3' align='left'  width='55px'>Bill</br>Status</td>    <td id='trevec~13' class='middle3' align='left'  width='85px'>Revenue</br>Center</td></tr>");
                //}



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

                        tbl = tbl + ("<tr >");


                        tbl = tbl + ("<td class='rep_data' colspan='2'>");
                        tbl = tbl +"<b>" +"Sub Total:" +"</b>" +"</td>";
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data'>") ;
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data' >");
                        tbl = tbl + "</td>";


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data' align='right'>") +"<b>"+ subretainercomm+ "</b>";
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




                        /****************************************************************************************/

                        subretainercomm = 0.00;
                        subBillAmt = 0.00;

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
                        tbl = tbl +"<b>" +(retname + "</b></td>");
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
                        //tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"].ToString("F2") + "</td>");
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
                    tbl = tbl +"<b>"+ (retname + "</b></td>");
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
                    //tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"].ToString("F2") + "</td>");
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




        /****************************************************************************************/



        tbl = tbl + ("<tr >");
        // tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        // tbl = tbl + ("<tr >");

        /****************************            for total            ************************/

        tbl = tbl + ("<tr >");


        tbl = tbl + ("<td class='middle13' colspan='2'>");
        tbl = tbl + "<b>" + "Total" + "</b>" + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data'>") ;
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data' style='font-size: 13px;' align='right' colspan='2' >");
        tbl = tbl + "<b>" + "Retainer Commision: " + "<b>" + totalretainercomm.ToString() + "</b>" + "</b>" + "</td>";
       // tbl = tbl + "</td>";


        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='middle13' style='font-size: 13px;' align='right' colspan='3'>");
       // tbl = tbl + "<b>" + totalretainercomm.ToString() + "</b>" + "</td>";
        tbl = tbl + "<b>" + "Bill Amount: " + "<b>" + BillAmt.ToString() + "</b>" + "</b>" + "</td>";
       tbl = tbl + "</td>";
        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='middle13' style='font-size: 11px;' align='right'>");
        tbl = tbl + "</td>";
        //tbl = tbl  + "<b>" + BillAmt.ToString() +"</b>"+ "</td>";

        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data'>");
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

    private void excel(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {
        
        
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
        ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchname, editioncode, Retainercode, Adtypecode);
    

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";

        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        DataGrid1.DataSource = ds;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        DataGrid1.ShowHeader = true;
        DataGrid1.ShowFooter = true;
        DataGrid1.DataBind();
        hw.Write("<p align=\"center\">Retainer Commision Report");

        hw.WriteBreak();

        //oSheet.Cells[3, 8] = "RUN DATE:";
        ////        oSheet.Cells[6, 8] = "RETAINER:";
        ////        oSheet.Cells[7, 8] = "DATE TO:";
        
        ////        oSheet.Cells[7, 3] = fromdt;

       // hw.Write("<table><tr><td>" + "FROM DATE:" + fromdt + "</td><td>" + "DATE TO:" + dateto + "</td><td>" + "RUN DATE:" + date.ToString() + "</td></tr></table>");
       // hw.Write("FROM DATE:" + fromdt + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "DATE TO:" + dateto + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "RUN DATE:" + date.ToString());

        string str11 = "FROM DATE:" + fromdt;

        for (int j11 = 0; j11 < 80; j11++)
        {
            str11 = str11 + "&nbsp;";
        }
        str11 = str11 + "DATE TO:" + dateto;

        for (int j11 = 0; j11 < 80; j11++)
        {
            str11 = str11 + "&nbsp;";
        }

        str11 = str11 + "RUN DATE:" + date.ToString();

        hw.Write(str11);

            hw.WriteBreak();

        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>" + "" + "</td><td align=\"center\" colspan=\"3\">TOTAL</td><td align=\"center\" colspan=\"2\"></td><td>" + totalcommission + "</td><td></td><td>" + amtnew + "<td align=\"center\" >" + "" + "</td><td></td></tr></table>"));
        Response.Flush();
        Response.End(); 
        
    //}



        string strCurrentDir = Server.MapPath(".") + "\\";
       // RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
       //  Excel.Range oRng1;

         try
         {


             //        GC.Collect();// clean up any other excel guys hangin' around...
             oXL = new Excel.Application();
             oXL.Visible = true;

             //        //Get a new workbook.
             oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
             oSheet = (Excel._Worksheet)oWB.ActiveSheet;
             oRng = oSheet.get_Range("A3", "Y3");
             //        SqlDataReader myReader1 = null;
             
             DataSet pdfxml = new DataSet();
             pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
    //////        //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
    //////        //myReader = obj.retainexcel(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());
    //////        //DataSet dst=clsbook.spfun();

    //////        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //////        //{
    //////        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
    //////        //    myReader1 = obj.retainexcel(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());

    //////        //    int iRow = 4;  //2
    //////        //    oSheet.PageSetup.CenterFooter = "&P";

    //////        //    DataSet ds1 = new DataSet();
    //////        //    ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
    //////        //    // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
    //////        //    oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[41].ToString();

    //////        //    for (int j = 0; j < myReader1.FieldCount; j++)
    //////        //    {


    //////        //        //oSheet.Cells[3, j + 1] = myReader1.GetName(j).ToString();
    //////        //        oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
    //////        //        oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
    //////        //        oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
    //////        //        oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
    //////        //        oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
    //////        //        oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
    //////        //        oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[50].ToString();
    //////        //        oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[51].ToString();
    //////        //        oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[52].ToString();
    //////        //        oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[19].ToString();
    //////        //        oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
    //////        //        oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
    //////        //        oSheet.Cells[3, 13] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
    //////        //        oSheet.Cells[3, 14] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

    //////        //        //oSheet.Cells[3, 14] = myReader1.GetName(16).ToString();
    //////        //        //oSheet.Cells[3, 15] = myReader1.GetName(27).ToString();
    //////        //        //oSheet.Cells[3, 16] = myReader1.GetName(18).ToString();
    //////        //        //oSheet.Cells[3, 17] = myReader1.GetName(25).ToString();
    //////        //        //oSheet.Cells[3, 18] = myReader1.GetName(23).ToString();
    //////        //        //oSheet.Cells[3, 19] = myReader1.GetName(24).ToString();
    //////        //        //oSheet.DisplayPageBreaks=

    //////        //    }
    //////        //    //   }
    //////        //    oSheet.Cells.Font.Name = "verdana";
    //////        //    oSheet.Cells.Font.Size = 7;

    //////        //    oRng = oSheet.get_Range("A3", "Y3");
    //////        //    oRng.EntireColumn.AutoFit();
    //////        //    int i1 = 1;
    //////        //    while (myReader1.Read())
    //////        //    {
    //////        //        oSheet.Cells[iRow, 1] = i1++.ToString();
    //////        //        for (int k = 0; k < myReader1.FieldCount; k++)
    //////        //        {

    //////        //            oSheet.Cells[iRow, 2] = myReader1["CIOID"].ToString();
    //////        //            oSheet.Cells[iRow, 3] = myReader1["Agency"].ToString();
    //////        //            oSheet.Cells[iRow, 4] = myReader1["Client"].ToString();
    //////        //            oSheet.Cells[iRow, 5] = myReader1["Publication"].ToString();
    //////        //            oSheet.Cells[iRow, 6] = myReader1["AdType"].ToString();
    //////        //            oSheet.Cells[iRow, 7] = myReader1["PaymentType"].ToString();
    //////        //            oSheet.Cells[iRow, 8] = myReader1["RetainName"].ToString();
    //////        //            oSheet.Cells[iRow, 9] = myReader1["RetainerCommision"].ToString();
    //////        //            oSheet.Cells[iRow, 10] = myReader1["Area"].ToString();
    //////        //            oSheet.Cells[iRow, 11] = myReader1["BillAmt"].ToString();
    //////        //            oSheet.Cells[iRow, 12] = myReader1["BillStatus"].ToString();
    //////        //            oSheet.Cells[iRow, 13] = myReader1["BillableArea"].ToString();
    //////        //            oSheet.Cells[iRow, 14] = myReader1["RevenueCenter"].ToString();

    //////        //            //oSheet.Cells[iRow, 14] = myReader1.GetValue(16).ToString();
    //////        //            //oSheet.Cells[iRow, 15] = myReader1.GetValue(27).ToString();
    //////        //            //oSheet.Cells[iRow, 16] = myReader1.GetValue(18).ToString();
    //////        //            //oSheet.Cells[iRow, 17] = myReader1.GetValue(25).ToString();
    //////        //            //oSheet.Cells[iRow, 18] = myReader1.GetValue(23).ToString();
    //////        //            //oSheet.Cells[iRow, 19] = myReader1.GetValue(24).ToString();


    //////        //        }

    //////        //        if (myReader1["Area"].ToString() != "")
    //////        //            area = area + int.Parse(myReader1["Area"].ToString());
    //////        //        if (myReader1["BillAmt"].ToString() != "")
    //////        //            BillAmt = BillAmt + double.Parse(myReader1["BillAmt"].ToString());

    //////        //        if (myReader1["BillableArea"].ToString() != "")
    //////        //            billarea = billarea + float.Parse(myReader1["BillableArea"].ToString());



    //////        //        iRow++;



    //////        //    }
    //////        //    oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
    //////        //    oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
    //////        //    oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
    //////        //    oSheet.Cells[iRow + 1, 10] = area.ToString();
    //////        //    oSheet.Cells[iRow + 1, 11] = BillAmt.ToString();
    //////        //    oSheet.Cells[iRow + 1, 13] = billarea.ToString();


    //////        //    string row;
    //////        //    string row1;
    //////        //    iRow = iRow + 1;
    //////        //    row = "A" + Convert.ToString(iRow);
    //////        //    row1 = "AA" + Convert.ToString(iRow);

    //////        //    oSheet.get_Range(row, row1).Font.Bold = true;


    //////        //    myReader1.Close();
    //////        //    myReader1 = null;
    //////        //}
    //////        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //////        //{
    //////            NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
    //////            myReader = obj.retainexcel(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8);

             //oSheet.Cells[3, 2] = "PUBLICATION:";
    ////        oSheet.Cells[6, 2] = "REGION:";
    ////        oSheet.Cells[7, 2] = "DATE FROM:";

             //if (product == "0")
             //{
             //    oSheet.Cells[3, 3] = "ALL".ToString();
             //}
             //else
             //{
             //    oSheet.Cells[3, 3] = productname.ToString();
             //}


    ////        if (region == "0")
    ////        {
    ////            oSheet.Cells[6, 3] = "ALL".ToString();
    ////        }
    ////        else
    ////        {
    ////            oSheet.Cells[6, 3] = regionname.ToString();
    ////        }

             //if (editioncode == "0" || editioncode == "")
             //{
             //    oSheet.Cells[3, 6] = "ALL".ToString();
             //}
             //else
             //{
             //    oSheet.Cells[3, 6] = editionname.ToString();
             //}

    ////        if (branchcode == "0")
    ////        {
    ////            oSheet.Cells[6, 6] = "ALL".ToString();
    ////        }
    ////        else
    ////        {
    ////            oSheet.Cells[6, 6] = branchname.ToString();
    ////        }

    ////        if (Adtypecode == "0")
    ////        {
    ////            oSheet.Cells[7, 6] = "ALL".ToString();
    ////        }
    ////        else
    ////        {
    ////            oSheet.Cells[7, 6] = Adtypename.ToString();
    ////        }

    ////        if (Retainercode == "0")
    ////        {
    ////            oSheet.Cells[6, 9] = "ALL".ToString();
    ////        }
    ////        else
    ////        {
    ////            oSheet.Cells[6, 9] = Retainername.ToString();
    ////        }

    ////        oSheet.Cells[7, 9] = dateto;
    ////        oSheet.Cells[7, 3] = fromdt;






             //oSheet.Cells[3, 5] = "EDITION:";
    ////        oSheet.Cells[6, 5] = "BRANCH:";
    ////        oSheet.Cells[7, 5] = "AD TYPE:";

             //oSheet.Cells[3, 8] = "RUN DATE:";
    ////        oSheet.Cells[6, 8] = "RETAINER:";
    ////        oSheet.Cells[7, 8] = "DATE TO:";

             //oSheet.Cells[3, 9] = date.ToString();

           
            
            
    ////        double totalretainercomm = 0.0;
    ////        double totalBillAmt = 0.0;
    ////            int iRow = 11;  //2
    ////            //oSheet.PageSetup.CenterFooter = "&P";

    ////            DataSet ds1 = new DataSet();
    ////            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
    ////             heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
    ////            oSheet.Cells[1,7] = ds1.Tables[0].Rows[0].ItemArray[41].ToString();

    ////            //for (int j = 0; j < ds.FieldCount; j++)
    ////            //{


    ////            //    oSheet.Cells[3, j + 1] = ds.GetName(j).ToString();
    ////                oSheet.Cells[9, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
    ////                oSheet.Cells[9, 2] = pdfxml.Tables[0].Rows[0].ItemArray[51].ToString();
    ////                oSheet.Cells[9, 3] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
    ////                oSheet.Cells[9, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
    ////                oSheet.Cells[9, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
    ////                oSheet.Cells[9, 6] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
    ////                oSheet.Cells[9, 7] = pdfxml.Tables[0].Rows[0].ItemArray[52].ToString();
    ////                oSheet.Cells[9, 8] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
    ////                oSheet.Cells[9, 9] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
    ////                oSheet.Cells[9, 10] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
    ////             //   oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
    ////                oSheet.Cells[9, 11] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();
    ////                //oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
    ////                //oSheet.Cells[3, 13] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
    ////                //oSheet.Cells[3, 14] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

    ////            //    oSheet.Cells[3, 14] = ds.GetName(16).ToString();
    ////            //    oSheet.Cells[3, 15] = ds.GetName(27).ToString();
    ////            //    oSheet.Cells[3, 16] = ds.GetName(18).ToString();
    ////            //    oSheet.Cells[3, 17] = ds.GetName(25).ToString();
    ////            //    oSheet.Cells[3, 18] = ds.GetName(23).ToString();
    ////            //    oSheet.Cells[3, 19] = ds.GetName(24).ToString();
    ////            //    //oSheet.DisplayPageBreaks=

    ////            //}
    ////               //}
    ////            oSheet.Cells.Font.Name = "verdana";
    ////            oSheet.Cells.Font.Size = 7;

    ////            oRng = oSheet.get_Range("A3", "Y3");
    ////            oRng.EntireColumn.AutoFit();
    ////            //int i1 = 1;
    ////            //while (myReader.Read())
    ////            //{
    ////            //    oSheet.Cells[iRow, 1] = i1++.ToString();
    ////            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
    ////            {
    ////                if (ds.Tables[0].Rows[k]["RetainName"].ToString() != "")
    ////                {
    ////                    oSheet.Cells[iRow, 1] = (k + 1).ToString();
    ////                    oSheet.Cells[iRow, 2] = ds.Tables[0].Rows[k]["RetainName"].ToString();
    ////                    oSheet.Cells[iRow, 3] = ds.Tables[0].Rows[k]["CIOID"].ToString();

    ////                    oSheet.Cells[iRow, 4] = ds.Tables[0].Rows[k]["Agency"].ToString();
    ////                    oSheet.Cells[iRow, 5] = ds.Tables[0].Rows[k]["Client"].ToString();
    ////                    oSheet.Cells[iRow, 6] = ds.Tables[0].Rows[k]["Publication"].ToString();
    ////                    //oSheet.Cells[iRow, 6] = ds.Tables[0].Rows[k]["AdType"].ToString();
    ////                    //oSheet.Cells[iRow, 7] = ds.Tables[0].Rows[k]["PaymentType"].ToString();
    ////                    //oSheet.Cells[iRow, 8] = ds.Tables[0].Rows[k]["RetainName"].ToString();
    ////                    oSheet.Cells[iRow, 7] = ds.Tables[0].Rows[k]["RetainerCommision"].ToString();
    ////                    oSheet.Cells[iRow, 8] = ds.Tables[0].Rows[k]["Area"].ToString();
    ////                    oSheet.Cells[iRow, 10] = ds.Tables[0].Rows[k]["BillAmt"].ToString();
    ////                    oSheet.Cells[iRow, 9] = ds.Tables[0].Rows[k]["BillStatus"].ToString();
    ////                    //oSheet.Cells[iRow, 13] = ds.Tables[0].Rows[k]["BillableArea"].ToString();
    ////                    oSheet.Cells[iRow, 11] = ds.Tables[0].Rows[k]["RevenueCenter"].ToString();


    ////                    //oSheet.Cells[iRow, 14] = myReader.GetValue(16).ToString();
    ////                    //oSheet.Cells[iRow, 15] = myReader.GetValue(27).ToString();
    ////                    //oSheet.Cells[iRow, 16] = myReader.GetValue(18).ToString();
    ////                    //oSheet.Cells[iRow, 17] = myReader.GetValue(25).ToString();
    ////                    //oSheet.Cells[iRow, 18] = myReader.GetValue(23).ToString();
    ////                    //oSheet.Cells[iRow, 19] = myReader.GetValue(24).ToString();

    ////                    if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
    ////                    {
    ////                       // subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
    ////                        totalBillAmt = totalBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
    ////                    }

    ////                    if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
    ////                    {
    ////                        // subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
    ////                        totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
    ////                    }

    ////                    iRow++;
    ////                }


    ////            }

    ////            //    if (myReader["Area"].ToString() != "")
    ////            //        area = area + int.Parse(myReader["Area"].ToString());
    ////            //    if (myReader["BillAmt"].ToString() != "")
    ////            //        BillAmt = BillAmt + double.Parse(myReader["BillAmt"].ToString());

    ////            //    if (myReader["BillableArea"].ToString() != "")
    ////            //        billarea = billarea + float.Parse(myReader["BillableArea"].ToString());



    ////            //    iRow++;



    ////            //}
    ////            oSheet.Cells[iRow + 1, 2] = "Total :".ToString();
    ////            oSheet.Cells[iRow + 1, 7] = totalretainercomm.ToString();
    ////            oSheet.Cells[iRow + 1, 10] = totalBillAmt.ToString();
    ////            //oSheet.Cells[iRow + 1, 10] = area.ToString();
    ////            //oSheet.Cells[iRow + 1, 11] = BillAmt.ToString();
    ////            //oSheet.Cells[iRow + 1, 13] = billarea.ToString();


    ////            string row;
    ////            string row1;
    ////            iRow = iRow + 1;
    ////            row = "A" + Convert.ToString(iRow);
    ////            row1 = "AA" + Convert.ToString(iRow);

    ////            oSheet.get_Range(row, row1).Font.Bold = true;
    ////         //   oSheet.get_Range(5, 9).Font.Bold = true;


    ////            //myReader.Close();
    ////            //myReader = null;
    ////        //}
    ////        //else
    ////        //{
    ////        //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
    ////        //    //ds = pub.product(region, Session["compcode"].ToString());
    ////        //}
            
            
    ////        oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
    ////        oSheet.get_Range("A1", "N1").MergeCells = true;
    ////        oSheet.get_Range("A1", "N1").Font.Bold = true;
    ////        oSheet.get_Range("A1", "N1").Font.Size = 10;
    ////        oSheet.get_Range("A3", "Y3").Font.Bold = true;
    ////        oSheet.get_Range("A3", "Y3").Font.Size = 8;
    ////        oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

    ////        oRng.EntireColumn.AutoFit();

    ////        oXL.Visible = true;
    ////        oXL.UserControl = false;
    ////        string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

    ////        oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);
    ////        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRng);
    ////        System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
    ////        System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
    ////        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

    ////        GC.Collect();  // force final cleanup!
    ////        string strMachineName = Request.ServerVariables["SERVER_NAME"];
    ////        //string strMachineName = Request.ServerVariables["umesh"];
    ////       // errLabel.Text = "<A href=http://" + strMachineName + "/ExcelGen/" + strFile + ">Download Report</a>";




             /*************************             new by grid              ***********************/

             OracleDataReader myReader = null;
             NewAdbooking.classesoracle.billreport obj1 = new NewAdbooking.classesoracle.billreport();
             myReader = obj1.retainonexcel(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchname, editioncode, Retainercode, Adtypecode);


                int iRow = 6;  //2

                oSheet.PageSetup.CenterFooter = "&P";

               
                //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[5].ToString();


                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[50].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[51].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[52].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[19].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();
                }

                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;


                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();

                int i1 = 1;
                while (myReader.Read())
                {
                    if (myReader["RetainName"].ToString() != "")
                    {
                        oSheet.Cells[iRow, 1] = i1++.ToString();
                        for (int k = 0; k < myReader.FieldCount; k++)
                        {


                                    oSheet.Cells[iRow, 1] = (k + 1).ToString();
                                    oSheet.Cells[iRow, 2] = myReader["RetainName"].ToString();
                                    oSheet.Cells[iRow, 3] = myReader["CIOID"].ToString();

                                    oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                                    oSheet.Cells[iRow, 5] = myReader["Client"].ToString();
                                    oSheet.Cells[iRow, 6] = myReader["Publication"].ToString();
                                    //oSheet.Cells[iRow, 6] = ds.Tables[0].Rows[k]["AdType"].ToString();
                                    //oSheet.Cells[iRow, 7] = ds.Tables[0].Rows[k]["PaymentType"].ToString();
                                    //oSheet.Cells[iRow, 8] = ds.Tables[0].Rows[k]["RetainName"].ToString();
                                    oSheet.Cells[iRow, 7] = myReader["RetainerCommision"].ToString();
                                    oSheet.Cells[iRow, 8] = myReader["Area"].ToString();
                                    oSheet.Cells[iRow, 10] = myReader["BillAmt"].ToString();
                                    oSheet.Cells[iRow, 9] = myReader["BillStatus"].ToString();
                                    //oSheet.Cells[iRow, 13] = ds.Tables[0].Rows[k]["BillableArea"].ToString();
                                    oSheet.Cells[iRow, 11] = myReader["RevenueCenter"].ToString();



                                }

                                //if (myReader["Area"].ToString() != "")
                                //    area = area + int.Parse(myReader["Area"].ToString());





                                iRow++;
                    }



                }

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;



                myReader.Close();
                myReader = null;
                oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "P1").MergeCells = true;
                oSheet.get_Range("A1", "P1").Font.Bold = true;
                oSheet.get_Range("A1", "P1").Font.Size = 10;
                oSheet.get_Range("A3", "Y3").Font.Bold = true;
                oSheet.get_Range("A3", "Y3").Font.Size = 8;

                oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                oRng.EntireColumn.AutoFit();


                oXL.Visible = true;
                oXL.UserControl = false;
                string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

                oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

                GC.Collect();  // force final cleanup!
                string strMachineName = Request.ServerVariables["umesh"];


             /**************************************************************************************/


        }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
          //  errLabel.Text = errorMessage;
        }
        finally
        {
            Response.Redirect("Retaincom.aspx");
        }
    }

    //private void pdf(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    //{

    //  ///***********************             new changes by shachi                       ******************/   

    //  ////  DataSet pdfxml = new DataSet();
    //  ////  pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
    //  ////  string pdfName1 = "";
    //  ////  pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
    //  ////  string name = Server.MapPath("") + "//" + pdfName1;



    //  //////  btnprint.Attributes.Add("onclick", "javascript:window.print();");

    //  ////  Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

    //  ////  PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
    //  ////  int i2 = 0;
    //  ////  //int count = 0;
    //  ////  //=======================================WATERMARK=========================================

    //  ////  //try
    //  ////  //{
    //  ////  //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
    //  ////  //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
    //  ////  //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
    //  ////  //    document.Add(watermark);
    //  ////  //}
    //  ////  //catch (Exception)
    //  ////  //{
    //  ////  //    Console.WriteLine("Are you sure you have the file 'DSC_473011.jpg' in the right path?");
    //  ////  //}

    //  ////  //--------------------for page numbering---------------------------------------------

    //  ////  //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
    //  ////  HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
    //  ////  //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
    //  ////  footer.Border = Rectangle.NO_BORDER;
    //  ////  footer.Alignment = Element.ALIGN_CENTER;
    //  ////  document.Footer = footer;

    //  ////  document.Open();

    //  //  //---------------------------end-------------------------------------------------------


    //  //  /*********************************                shachi                      *****************************/

    //  //  DataSet pdfxml = new DataSet();
    //  //  pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));


    //  //  string pdfName1 = "";
    //  //  pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
    //  //  string name = Server.MapPath("") + "//" + pdfName1;
    //  //  iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

    //  //  PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
    //  //  int i2 = 0;
    //  //  iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
    //  //  footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
    //  //  document.Footer = footer;
    //  //  document.Open();




    //  //  /***********************************************************************************************************/



    //  //  int NumColumns = 14;
    //  //  Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
    //  //  Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
    //  //  Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

    //  //  //// ---------------table for heading-------------------------
    //  //  //try
    //  //  //{

    //  //  //    //Table tbl  = new Table(1);
    //  //  //    PdfPTable tbl = new PdfPTable(1);
    //  //  //    float[] xy = { 100 };
    //  //  //    tbl.DefaultCell.BorderWidth = 0;
    //  //  //    tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //  //  //    tbl.setWidths(xy);
    //  //  //    tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
    //  //  //    DataSet ds1 = new DataSet();
    //  //  //    ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
    //  //  //    //heading.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();

    //  //  //    // oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
    //  //  //    tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[41].ToString(), font9));
    //  //  //    //tbl.addCell("List of ADS -Hold/Cancelled");
    //  //  //    float[] headerwidths1 = { 50 };
    //  //  //    tbl.setWidths(headerwidths1);
    //  //  //    tbl.WidthPercentage = 100;
    //  //  //    //tbl.DefaultCell.Padding = -5;
    //  //  //    document.Add(tbl);
    //  //  //    //-----------------table for spacing------------------------------
    //  //  //    PdfPTable tbl1 = new PdfPTable(1);
    //  //  //    tbl1.DefaultCell.BorderWidth = 0;
    //  //  //    tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //  //  //    tbl1.addCell("");
    //  //  //    tbl1.WidthPercentage = 100;
    //  //  //    //tbl1.DefaultCell.Padding = -5;
    //  //  //    int i;
    //  //  //    for (i = 0; i < 2; i++)
    //  //  //    {
    //  //  //        document.Add(tbl1);
    //  //  //    }

    //  //  //    PdfPTable tbl2 = new PdfPTable(6);
    //  //  //    tbl2.DefaultCell.BorderWidth = 0;
    //  //  //    tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //  //  //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
    //  //  //    tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
    //  //  //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
    //  //  //    tbl2.addCell(new Phrase(dateto1.ToString(), font11));
    //  //  //    tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
    //  //  //    tbl2.addCell(new Phrase(date.ToString(), font11));
    //  //  //    tbl2.WidthPercentage = 100;
    //  //  //    document.Add(tbl2);


    //  //  //    //-------------------------------table for header-------------------------------------------------------
    //  //  //    PdfPTable datatable = new PdfPTable(NumColumns);
    //  //  //    datatable.DefaultCell.Padding = 3;
    //  //  //    //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
    //  //  //    //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
    //  //  //    //float[] headerwidths = { 11, 13, 17, 17, 16, 17, 17, 14, 16, 18, 12,16,17}; // percentage
    //  //  //    ////float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
    //  //  //    //datatable.setWidths(headerwidths);
    //  //  //    datatable.WidthPercentage = 100; // percentage
    //  //  //    datatable.DefaultCell.BorderWidth = 0;
    //  //  //    datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //  //  //    //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
    //  //  //    //datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
    //  //  //    //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
    //  //  //    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[51].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[52].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));

    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

    //  //  //    datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
    //  //  //    //datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));
    //  //  //    datatable.HeaderRows = 1;

    //  //  //    Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


    //  //  //    document.Add(p2);

    //  //  //    //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
    //  //  //    SqlDataAdapter da = new SqlDataAdapter();
    //  //  //    DataSet ds = new DataSet();
    //  //  //    //ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

    //  //  //    //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //  //  //    //{
    //  //  //    //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
    //  //  //    //    ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
    //  //  //    //}
    //  //  //    //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //  //  //    //{
    //  //  //        NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
    //  //  //        ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6);
    //  //  //    //}
    //  //  //    //else
    //  //  //    //{
    //  //  //    //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
    //  //  //    //    //ds = pub.product(region, Session["compcode"].ToString());
    //  //  //    //}

    //  //  //    int row = 0;
    //  //  //    //int count = 0;
    //  //  //    int i1 = 1;
    //  //  //    while (row < ds.Tables[0].Rows.Count)
    //  //  //    {

    //  //  //        datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
    //  //  //        datatable.addCell(new Phrase(i1++.ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetainName"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetainerCommision"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
    //  //  //        if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
    //  //  //            area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
    //  //  //        if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
    //  //  //            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
    //  //  //        if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
    //  //  //            billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
    //  //  //        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));


    //  //  //        //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[27].ToString(), font11));
    //  //  //        //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));
    //  //  //        //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[25].ToString(), font11));
    //  //  //        //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[23].ToString(), font11));
    //  //  //        //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[24].ToString(), font11));


    //  //  //        row++;

    //  //  //    }


    //  //  //    document.Add(datatable);
    //  //  //    Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
    //  //  //    document.Add(p3);


    //  //  //    PdfPTable tbltotal = new PdfPTable(14);
    //  //  //    float[] headerwidths = { 11, 13, 14, 14,12, 10, 12, 24, 12, 8, 14, 8, 14, 10 }; // percentage
    //  //  //    tbltotal.setWidths(headerwidths);
    //  //  //    tbltotal.DefaultCell.BorderWidth = 0;
    //  //  //    tbltotal.WidthPercentage = 100;
    //  //  //    tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //  //  //    tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
    //  //  //    tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
    //  //  //    tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
           
    //  //  //    tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
    //  //  //    tbltotal.addCell(new Phrase(area.ToString(), font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
    //  //  //      tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));
    //  //  //    tbltotal.addCell(new Phrase(billarea.ToString(), font11));
    //  //  //    tbltotal.addCell(new Phrase(" ", font11));

    //  //  /**********************                 new    change            **********************/


    //  //  try
    //  //  {
    //  //      PdfPTable tbl = new PdfPTable(1);
    //  //      float[] xy = { 100 };
    //  //      tbl.DefaultCell.BorderWidth = 0;
    //  //      tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //  //      tbl.setWidths(xy);
    //  //      tbl.addCell(new iTextSharp.text.Phrase("Query Analysis", font9));
    //  //      //tbl.addCell("List of ADS -Hold/Cancelled");
    //  //      float[] headerwidths1 = { 50 };
    //  //      tbl.setWidths(headerwidths1);
    //  //      tbl.WidthPercentage = 100;

    //  //      document.Add(tbl);


    //  //      //PdfPTable datatable = new PdfPTable(NumColumns);
    //  //      //datatable.DefaultCell.Padding = 1;


    //  //      //datatable.WidthPercentage = 100; // percentage
    //  //      //datatable.DefaultCell.BorderWidth = 0;
    //  //      //datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //  //      //datatable.addCell(new iTextSharp.text.Phrase("Sr.No", font10));


    //  //      ///*********************      for spacing after heading     ***********************/

    //  //      //PdfPTable tbl11 = new PdfPTable(1);
    //  //      //tbl11.DefaultCell.BorderWidth = 0;
    //  //      //tbl11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //  //      //tbl11.addCell("");
    //  //      //tbl11.WidthPercentage = 100;


    //  //      //int i11;
    //  //      //for (i11 = 0; i11 < 5; i11++)
    //  //      //{
    //  //      //    document.Add(tbl11);
    //  //      //}


    //  //  /********************************************************************************/



    //  //    //  document.Add(tbl11);
            
            
    //  //      ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //  //      //Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
    //  //      //document.Add(p4);

    //  //      //PdfPTable tbltotal1 = new PdfPTable(4);
    //  //      //float[] headerwidths11 = { 5, 3, 20, 70 }; // percentage
    //  //      //tbltotal1.setWidths(headerwidths11);
    //  //      //tbltotal1.DefaultCell.BorderWidth = 0;
    //  //      //tbltotal1.WidthPercentage = 100;
    //  //      //tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //  //      //tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
    //  //      //double arr = BillAmt / billarea;
    //  //      //tbltotal1.addCell(new Phrase("ARR", font10));
    //  //      //tbltotal1.addCell(new Phrase(" : ", font10));
    //  //      //tbltotal1.addCell(new Phrase(arr.ToString(), font10));
    //  //      //tbltotal1.addCell(new Phrase(" ", font10));
    //  //      //document.Add(tbltotal1);
            

    //  //      //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            
            
            

    //  //      document.Close();

    //  //      Response.Redirect(pdfName1);


    //  //  }
    //  //  catch (Exception e)
    //  //  {
    //  //      Console.Error.WriteLine(e.StackTrace);
    //  //  }




    //    string pdfName = "";
    //    pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
    //    string name = Server.MapPath("") + "//" + pdfName;
    //    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

    //    PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
    //    int i2 = 0;
    //    iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
    //    footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
    //    document.Footer = footer;
    //    document.Open();



    //    //NewAdbooking.sam.Classes.queryreport objteam = new NewAdbooking.sam.Classes.queryreport();
    //    //DataSet ds = new DataSet();
    //    //ds = objteam.executequery(condition1, condition2, childtab1, childtab2, childtab3);
    //    //DataSet ds1 = new DataSet();
    //    //ds1.ReadXml(Server.MapPath("Xml/queryformfield.xml"));

    //    //string[] displayfields = selectedfields11.Split(',');
    //    //int length1 = displayfields.Length - 1;
    //    //if (ds.Tables[0].Rows.Count == 0)
    //    //{
    //    //    Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
    //    //}


    //    //int NumColumns = length1 + 1;


    //    iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
    //    iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
    //    iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
    //    iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);


    //    //--------------------for page numbering---------------------------------------------
    //    //---------------table for heading-------------------------
    //    try
    //    {
    //        PdfPTable tbl = new PdfPTable(1);
    //        float[] xy = { 100 };
    //        tbl.DefaultCell.BorderWidth = 0;
    //        tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //        tbl.setWidths(xy);
    //        tbl.addCell(new iTextSharp.text.Phrase("Query Analysis", font9));
    //        //tbl.addCell("List of ADS -Hold/Cancelled");
    //        float[] headerwidths1 = { 50 };
    //        tbl.setWidths(headerwidths1);
    //        tbl.WidthPercentage = 100;

    //        document.Add(tbl);
    //        int NumColumns = 4;

    //        PdfPTable datatable = new PdfPTable(NumColumns);
    //        datatable.DefaultCell.Padding = 1;


    //        datatable.WidthPercentage = 100; // percentage
    //        datatable.DefaultCell.BorderWidth = 0;
    //        datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //        datatable.addCell(new iTextSharp.text.Phrase("Sr.No", font10));


    //        /*********************      for spacing after heading     ***********************/

    //        PdfPTable tbl11 = new PdfPTable(1);
    //        tbl11.DefaultCell.BorderWidth = 0;
    //        tbl11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //        tbl11.addCell("");
    //        tbl11.WidthPercentage = 100;


    //        int i11;
    //        for (i11 = 0; i11 < 5; i11++)
    //        {
    //            document.Add(tbl11);
    //        }



    //        /*********************      for spacing after heading     ***********************/



    //        /*********************    for subheadings   ********************/


    //        //for (int j = 0; j < length1; j++)
    //        //{
    //        //    datatable.addCell(new iTextSharp.text.Phrase(displayfields[j].ToString(), font10));
    //        //}

    //        document.Add(datatable);

    //        /*********************    for subheadings   ********************/



    //        /*********************      for spacing after subheading     ***********************/

    //        //PdfPTable tbl1 = new PdfPTable(1);
    //        //tbl1.DefaultCell.BorderWidth = 0;
    //        //tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //        //tbl1.addCell("");
    //        //tbl1.WidthPercentage = 100;


    //        //int i1;
    //        //for (i1 = 0; i1 < 3; i1++)
    //        //{
    //        //    document.Add(tbl1);
    //        //}



    //        /*********************      for spacing after subheading     ***********************/




    //        /***************************   for data in pdf file *************************/



    //        //PdfPTable datatable1 = new PdfPTable(NumColumns);
    //        //datatable1.DefaultCell.Padding = 1;
    //        //datatable1.WidthPercentage = 100; // percentage
    //        //datatable1.DefaultCell.BorderWidth = 0;
    //        //datatable1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
    //        //datatable1.addCell(new iTextSharp.text.Phrase("Sr.No", font10));


    //        //for (int k11 = 0; k11 < ds.Tables[0].Rows.Count; k11++)
    //        //{
    //        //    int k1111 = k11 + 1;
    //        //    datatable1.addCell(new iTextSharp.text.Phrase((k1111).ToString(), font10));

    //        //    for (int i = 0; i < length1; i++)
    //        //    {

    //        //        for (int j = 2, k = 0; j < ds1.Tables[0].Columns.Count; j = j + 2, k++)
    //        //        {

    //        //            if (displayfields[i].ToString() == ds1.Tables[0].Rows[0].ItemArray[j].ToString())
    //        //            {


    //        //                if (displayfields[i].ToString() == "Lead source")
    //        //                {
    //        //                    DataSet ds3 = new DataSet();
    //        //                    ds3.ReadXml(Server.MapPath("Xml/leadsource.xml"));
    //        //                    for (int j11 = 2; j11 < ds3.Tables[0].Columns.Count; j11 = j11 + 2)
    //        //                    {
    //        //                        if (ds3.Tables[0].Rows[0].ItemArray[j11].ToString() == ds.Tables[0].Rows[k11].ItemArray[k].ToString())
    //        //                        {
    //        //                            j11++;

    //        //                            // Osheet.Cells[4 + k11, 2 + k] = ds3.Tables[0].Rows[0].ItemArray[j11].ToString();
    //        //                            datatable1.addCell(new iTextSharp.text.Phrase(ds3.Tables[0].Rows[0].ItemArray[j11].ToString(), font10));

    //        //                        }
    //        //                    }
    //        //                }
    //        //                else if (displayfields[i].ToString() == "Lead Status")
    //        //                {
    //        //                    DataSet ds4 = new DataSet();
    //        //                    ds4.ReadXml(Server.MapPath("Xml/Leadstatus.xml"));
    //        //                    for (int j11 = 2; j11 < ds4.Tables[0].Columns.Count; j11 = j11 + 2)
    //        //                    {
    //        //                        if (ds4.Tables[0].Rows[0].ItemArray[j11].ToString() == ds.Tables[0].Rows[k11].ItemArray[k].ToString())
    //        //                        {
    //        //                            j11++;

    //        //                            // Osheet.Cells[4 + k11, 2 + k] = ds4.Tables[0].Rows[0].ItemArray[j11].ToString();
    //        //                            datatable1.addCell(new iTextSharp.text.Phrase(ds4.Tables[0].Rows[0].ItemArray[j11].ToString(), font10));

    //        //                        }
    //        //                    }
    //        //                }
    //        //                else if (displayfields[i].ToString() == "Priority")
    //        //                {
    //        //                    DataSet ds5 = new DataSet();
    //        //                    ds5.ReadXml(Server.MapPath("Xml/leadpriority.xml"));
    //        //                    for (int j11 = 2; j11 < ds5.Tables[0].Columns.Count; j11 = j11 + 2)
    //        //                    {
    //        //                        if (ds5.Tables[0].Rows[0].ItemArray[j11].ToString() == ds.Tables[0].Rows[0].ItemArray[k].ToString())
    //        //                        {
    //        //                            j11++;

    //        //                            //Osheet.Cells[4 + k11, 2 + k] = ds5.Tables[0].Rows[0].ItemArray[j11].ToString();
    //        //                            datatable1.addCell(new iTextSharp.text.Phrase(ds5.Tables[0].Rows[0].ItemArray[j11].ToString(), font10));

    //        //                        }
    //        //                    }
    //        //                }
    //        //                else
    //        //                {




    //        //                    // Osheet.Cells[4 + k11, 2 + k] = ds.Tables[0].Rows[k11].ItemArray[k].ToString();
    //        //                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k11].ItemArray[k].ToString(), font10));

    //        //                }

    //        //            }

    //        //        }


    //            //}


    //        //}


    //       // document.Add(datatable1);

    //        /************************   for data in pdf file   **************************/




    //        iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
    //        document.Add(p1);


    //        document.Close();
    //        Response.Redirect(pdfName);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.WriteLine(e.StackTrace);
    //    }
        



    //}




    private void pdf(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {


        //string pdfName = "";
        //pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        //string name = Server.MapPath("") + "//" + pdfName;
        //iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

        //PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        //int i2 = 0;
        //iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        //footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        //document.Footer = footer;
        //document.Open();


        ////if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        ////{

        ////    if (dateformate == "dd/mm/yyyy")
        ////    {
        ////        startdate = DMYToMDY(startdate);
        ////        endingdate = DMYToMDY(endingdate);
        ////    }


        ////    if (dateformate == "yyyy/mm/dd")
        ////    {
        ////        startdate = YMDToMDY(startdate);
        ////        endingdate = YMDToMDY(endingdate);
        ////    }
        ////    NewAdbooking.pam.Classes.Vol_Revenue catrpt = new NewAdbooking.pam.Classes.Vol_Revenue();
        ////    DataSet ds = new DataSet();

        ////    ds = catrpt.Newdemo(edition, editionname, branch, branchname, Session["compcode"].ToString(), reportvalue, selref, startdate, endingdate, city, dateformate, strsqcm1);
        ////    if (ds.Tables[0].Rows.Count == 0)
        ////    {
        ////        Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        ////    }

        ////    int controw = ds.Tables[0].Rows.Count;
        ////    int contcol = ds.Tables[0].Columns.Count;
        ////    int table1 = ds.Tables[0].Rows.Count;
        ////    int table2 = ds.Tables[1].Rows.Count;
           


        ////    //this is for last coloumn
        ////    q = ds.Tables[0].Columns.Count;
        ////    z = q - 1;
        ////    //this is for last third coloumn
        ////    lastc = ds.Tables[0].Columns.Count;
        ////    lastthirdc = lastc - 3;
        ////    int NumColumns = ds.Tables[0].Columns.Count+1;
          
        //    iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        //    iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        //    iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
        //    iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);


        //    //--------------------for page numbering---------------------------------------------
        //    //---------------table for heading-------------------------
        //    try
        //    {
        //        PdfPTable tbl = new PdfPTable(1);
        //        float[] xy = { 100 };
        //        tbl.DefaultCell.BorderWidth = 0;
        //        tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tbl.setWidths(xy);
        //        tbl.addCell(new iTextSharp.text.Phrase("Market Share Report", font9));
        //        //tbl.addCell("List of ADS -Hold/Cancelled");
        //        //float[] headerwidths1 = {50};
        //        //tbl.setWidths(headerwidths1);
        //        tbl.WidthPercentage = 100;
        //        document.Add(tbl);
        //        //-----------------table for spacing------------------------------
        //        PdfPTable tbl1 = new PdfPTable(1);
        //        tbl1.DefaultCell.BorderWidth = 0;
        //        tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        tbl1.addCell("");
        //        tbl1.WidthPercentage = 100;

        //        int i;
        //        for (i = 0; i < 5; i++)
        //        {
        //            document.Add(tbl1);
        //        }
        //        int NumColumns = 4;
        //        PdfPTable datatable = new PdfPTable(NumColumns);
        //        datatable.DefaultCell.Padding = 1;

        //        //datatable.setWidths(headerwidths);
        //        datatable.WidthPercentage = 100; // percentage
        //        datatable.DefaultCell.BorderWidth = 0;
        //        datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        datatable.addCell(new iTextSharp.text.Phrase("S.No", font10));
        //        //if (ds.Tables[2].Columns.Count.ToString() == "2")
        //        //{
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[2].Rows[0].ItemArray[0].ToString(), font10));
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[2].Rows[0].ItemArray[1].ToString(), font10));
        //        //    //datatable.addCell(new iTextSharp.text.Phrase("AdCat", font10));
        //        //}
        //        //else if (ds.Tables[2].Columns.Count.ToString() == "3")
        //        //{
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[2].Rows[0].ItemArray[0].ToString(), font10));
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[2].Rows[0].ItemArray[1].ToString(), font10));
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[2].Rows[0].ItemArray[2].ToString(), font10));
                    
        //        //    //datatable.addCell(new iTextSharp.text.Phrase("AdCat", font10));
        //        //}
        //        //else
        //        //{
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[2].Rows[0].ItemArray[0].ToString(), font10));
        //        //}

        //        //for (int x = 0; x <= table2 - 1; x++)
        //        //{
        //        //    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[x].ItemArray[0].ToString(), font10));
        //        //}

        //        ////for (int p = 1; p <= table1 - 1; p++)
        //        ////{
        //        ////    datatable.addCell(new Phrase(ds.Tables[0].Rows[p].ItemArray[0].ToString(), font10));
        //        ////}
        //        datatable.addCell(new iTextSharp.text.Phrase("Total", font9));
        //        datatable.addCell(new iTextSharp.text.Phrase("MktShare%", font9));
        //        datatable.HeaderRows = 1;
        //        datatable.DefaultCell.BorderWidth = 0;

        //        datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        //        datatable.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED;

        //        iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
        //        document.Add(p1);

        //        //---------------------for pagination--------------------------------------------
        //        //int a = 1;

        //        //for (int r = 0; r <= controw - 1; r++)
        //        //{
        //        //    for (int j = 0; j <= contcol - 1; j++)
        //        //    {
        //        //        datatable.addCell(new iTextSharp.text.Phrase(a++.ToString(), font8));
        //        //            for (y = 0; y <= contcol - 1; y++)
        //        //            {
        //        //                if (ds.Tables[0].Rows[r].ItemArray[y].ToString() != "")
        //        //                {
        //        //                    datatable.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[r].ItemArray[y].ToString(), font8));
        //        //                }
        //        //                else
        //        //                {
        //        //                    datatable.addCell(new iTextSharp.text.Phrase("0", font8));
        //        //                }
        //        //            }
                       

        //        //        break;

        //        //    }
        //        //}

        //        document.Add(datatable);
        //        document.Close();
        //        Response.Redirect(pdfName);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Error.WriteLine(e.StackTrace);
        //    }

        DataSet pdfxml = new DataSet();
       pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

       DataSet ds = new DataSet();

       NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
       ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchname, editioncode, Retainercode, Adtypecode);
    

        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();



        //SAM.Classes.queryreport objteam = new SAM.Classes.queryreport();
        //DataSet ds = new DataSet();
        //ds = objteam.executequery(condition1, condition2, childtab1, childtab2, childtab3);
        //DataSet ds1 = new DataSet();
        //ds1.ReadXml(Server.MapPath("Xml/queryformfield.xml"));

        //string[] displayfields = selectedfields11.Split(',');
        //int length1 = displayfields.Length - 1;
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        //}


        //int NumColumns = length1 + 1;
        int NumColumns = 11;

        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);


        //--------------------for page numbering---------------------------------------------
        //---------------table for heading-------------------------
        try
        {
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.addCell(new iTextSharp.text.Phrase("Retainer Commision Report", font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);


            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 1;


            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


            PdfPTable datatablecenter = new PdfPTable(NumColumns);
            datatablecenter.DefaultCell.Padding = 1;


            datatablecenter.WidthPercentage = 100; // percentage
            datatablecenter.DefaultCell.BorderWidth = 0;
            datatablecenter.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


            PdfPTable datatabletotal = new PdfPTable(NumColumns);
            datatabletotal.DefaultCell.Padding = 1;


            datatabletotal.WidthPercentage = 100; // percentage
            datatabletotal.DefaultCell.BorderWidth = 0;
            datatabletotal.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            //datatable.addCell(new iTextSharp.text.Phrase("Sr.No", font10));


            /*********************      for spacing after heading     ***********************/

            //PdfPTable tbl11 = new PdfPTable(1);
            //tbl11.DefaultCell.BorderWidth = 0;
            //tbl11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //tbl11.addCell("");
            //tbl11.WidthPercentage = 100;


            //int i11;
            //for (i11 = 0; i11 < 5; i11++)
            //{
            //    document.Add(tbl11);
            //}

            PdfPTable tbl11 = new PdfPTable(1);
            tbl11.DefaultCell.BorderWidth = 0;
            tbl11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl11.addCell("");
            tbl11.WidthPercentage = 100;


            int i11;
            for (i11 = 0; i11 < 3; i11++)
            {
                document.Add(tbl11);
            }


            /******************************         for filters                ******************/

         

          


            datatablecenter.addCell(new iTextSharp.text.Phrase("PUBLICATION:", font10));
            if (product == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(productname.ToString(), font10));
            }

            
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("EDITION:", font10));
            if (editioncode == "0" || editioncode == "")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(editionname.ToString(), font10)) ;
            }
           
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("RUN DATE:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(date.ToString(), font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));


            datatablecenter.addCell(new iTextSharp.text.Phrase("REGION:", font10));
            if (region == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(regionname.ToString(), font10));
            }
            
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("BRANCH:", font10));
            if (branchcode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(branchname.ToString(), font10)); 
            }

            
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("RETAINER:", font10));
            if (Retainercode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(Retainername.ToString(), font10));
            }
            
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));


            datatablecenter.addCell(new iTextSharp.text.Phrase("DATE FROM:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(fromdt.ToString(), font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("AD TYPE:", font10));
            if (Adtypecode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(Adtypename.ToString(), font10));
            }
            
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("DATE TO:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(dateto.ToString(), font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));

            document.Add(datatablecenter);






            /*********************      for spacing after heading     ***********************/

            iTextSharp.text.Phrase p111 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p111);


            /*********************    for subheadings   ********************/


            //for (int j = 0; j < length1; j++)
            //{
                 //oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                 //   oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[51].ToString();
                 //   oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                 //   oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                 //   oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                 //   oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                 //   oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[52].ToString();
                 //   oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                 //   oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                 //   oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                 ////   oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                 //   oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

            //datatable.addCell(new iTextSharp.text.Phrase("S.No.", font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[51].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[52].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));


                document.Add(datatable);

            /*********************    for subheadings   ********************/

                iTextSharp.text.Phrase p11 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
                document.Add(p11);

            /*********************      for spacing after subheading     ***********************/

            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl1.addCell("");
            tbl1.WidthPercentage = 100;


            int i1;
            for (i1 = 0; i1 < 3; i1++)
            {
                document.Add(tbl1);
            }



            /*********************      for spacing after subheading     ***********************/





            /***************************   for data in pdf file *************************/



            PdfPTable datatable1 = new PdfPTable(NumColumns);
            datatable1.DefaultCell.Padding = 1;
            datatable1.WidthPercentage = 100; // percentage
            datatable1.DefaultCell.BorderWidth = 0;
            datatable1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //datatable1.addCell(new iTextSharp.text.Phrase("Sr.No", font10));


            double totalBillAmt = 0.0;
            double totalretainercomm = 0.0;
            double subBillAmt = 0.0;
            double subretainercomm = 0.0;

            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {

                          if (k > 0)
                          {
                                          if ((ds.Tables[0].Rows[k]["RetainName"].ToString()) == (ds.Tables[0].Rows[(k - 1)]["RetainName"].ToString()))
                                          {

                                              //if (ds.Tables[0].Rows[k]["RetainName"].ToString() != "")
                                              //{
                                                      datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));

                                                      //oSheet.Cells[iRow, 14] = myReader.GetValue(16).ToString();
                                                      //oSheet.Cells[iRow, 15] = myReader.GetValue(27).ToString();
                                                      //oSheet.Cells[iRow, 16] = myReader.GetValue(18).ToString();
                                                      //oSheet.Cells[iRow, 17] = myReader.GetValue(25).ToString();
                                                      //oSheet.Cells[iRow, 18] = myReader.GetValue(23).ToString();
                                                      //oSheet.Cells[iRow, 19] = myReader.GetValue(24).ToString();

                                                      if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                                                      {
                                                          subBillAmt = subBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                                                          totalBillAmt = totalBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                                                      }

                                                      if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
                                                      {
                                                          subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                                                          totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                                                      }
                                          }
                                          else
                                          {
                                                      /************************         for sub total    ***********/

                                                      datatable1.addCell(new iTextSharp.text.Phrase("SubTotal:", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(subretainercomm.ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(subBillAmt.ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));





                                                      /**************************************************************/

                                                      /***************** FOR SPACE AFTER SUB TOTAL *******************/

                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase("", font10));

                                                      /***************************************************************/

                                                      subBillAmt = 0.0;
                                                      subretainercomm = 0.0;

                                                      datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainName"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                                                      datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));

                                                      //oSheet.Cells[iRow, 14] = myReader.GetValue(16).ToString();
                                                      //oSheet.Cells[iRow, 15] = myReader.GetValue(27).ToString();
                                                      //oSheet.Cells[iRow, 16] = myReader.GetValue(18).ToString();
                                                      //oSheet.Cells[iRow, 17] = myReader.GetValue(25).ToString();
                                                      //oSheet.Cells[iRow, 18] = myReader.GetValue(23).ToString();
                                                      //oSheet.Cells[iRow, 19] = myReader.GetValue(24).ToString();

                                                      if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                                                      {
                                                          subBillAmt = subBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                                                          totalBillAmt = totalBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                                                      }

                                                      if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
                                                      {
                                                          subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                                                          totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                                                      }
                                          }
                          }
                          else
                          {
                                          datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainName"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                                          datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));

                                          //oSheet.Cells[iRow, 14] = myReader.GetValue(16).ToString();
                                          //oSheet.Cells[iRow, 15] = myReader.GetValue(27).ToString();
                                          //oSheet.Cells[iRow, 16] = myReader.GetValue(18).ToString();
                                          //oSheet.Cells[iRow, 17] = myReader.GetValue(25).ToString();
                                          //oSheet.Cells[iRow, 18] = myReader.GetValue(23).ToString();
                                          //oSheet.Cells[iRow, 19] = myReader.GetValue(24).ToString();

                                          if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                                          {
                                              subBillAmt = subBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                                              totalBillAmt = totalBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                                          }

                                          if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
                                          {
                                              subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                                              totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                                          }           
                          }

                    
                }


           // }



         
            document.Add(datatable1);

            /************************   for data in pdf file   **************************/




            iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p1);


            datatabletotal.addCell(new iTextSharp.text.Phrase("Total", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("Bill Amount:", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase(totalBillAmt.ToString(), font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("Retainer Commision:", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase(totalretainercomm.ToString(), font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));

            document.Add(datatabletotal);

            iTextSharp.text.Phrase p1111 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p1111);

            

            document.Close();
            Response.Redirect(pdfName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
        
              








    }




    private iTextSharp.text.Image TextWriter(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        pdf1(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());

    }

    //=========================================================================================

    private void pdf1(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



      //  btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'DSC_473011.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 14;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();

            // oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[41].ToString(), font9));
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

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 11, 13, 17, 17, 16, 17, 17, 14, 16, 18, 12,16,17}; // percentage
            ////float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            //datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[51].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[52].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));
            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //    ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
                NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
                ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchname, editioncode, Retainercode, Adtypecode);
            //}
            //else
            //{
            //    //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //    //ds = pub.product(region, Session["compcode"].ToString());
            //}

            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetainName"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetainerCommision"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));


                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[27].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[25].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[23].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[24].ToString(), font11));


                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);

            
            PdfPTable tbltotal = new PdfPTable(14);
            float[] headerwidths = { 11, 13, 14, 14, 12, 10, 12, 24, 12, 8, 14, 12, 14, 6 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            
            document.Add(tbltotal);
            ////////////////////////////////////////////////////////////////////////////////////////

            //Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            //document.Add(p4);


            //PdfPTable tbltotal1 = new PdfPTable(4);
            //float[] headerwidths11 = { 5, 3, 20, 70 }; // percentage
            //tbltotal1.setWidths(headerwidths11);
            //tbltotal1.DefaultCell.BorderWidth = 0;
            //tbltotal1.WidthPercentage = 100;
            //tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            //double arr = BillAmt / billarea;
            //tbltotal1.addCell(new Phrase("ARR", font10));
            //tbltotal1.addCell(new Phrase(" : ", font10));
            //tbltotal1.addCell(new Phrase(arr.ToString(), font10));
            //tbltotal1.addCell(new Phrase(" ", font10));
            //document.Add(tbltotal1);

            //////////////////////////////////////////////////////////////////////////////////////

            document.Close();

            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
              proc.StartInfo.Arguments = @"/p /h" + Server.MapPath(pdfName1);

            
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            if (!proc.HasExited)
            {
                proc.Refresh();
                //Thread.Sleep(2000);
                proc.CloseMainWindow();
            }
            else
            {
                //break;

            }




        }

        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
        //=============================================================================================
    }




    private void drillonscreen(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype)
    {

        //ds = obj.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype);

        //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
            ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }
        
        
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";

        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Publication</td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>RetainerName</td><td class='middle3'>RetainerCom</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>Revenuecenter</td>");


        if (hiddenascdesc.Value == "")
        {

            // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Publication</td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>RetainerName</td><td class='middle3'>RetainerCom</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>Revenuecenter</td>");
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>RetainerName<img id='imgretdown' src='Images\\down.gif' style='display:block;'><img id='imgretup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RetainerCom</td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillableArea</td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");


        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>RetainerName<img id='imgretdown' src='Images\\down.gif' style='display:block;'><img id='imgretup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RetainerCom</td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillableArea</td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~7' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>BillAmt</td><td class='middle3'>BillableArea</td><td class='middle3'>SpecialDisc</td><td class='middle3'>SpaceDisc</td><td class='middle3'>SpecialDisc%</td><td class='middle3'>SpaceDisc%</td><td class='middle3'>AdType</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Disc</td><td id='trevec~18' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");



        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td id='tdret~7' class='middle3' onclick=sorting('RetainerName',this.id)>RetainerName<img id='imgretdown' src='Images\\down.gif' style='display:none;'><img id='imgretup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>RetainerCom</td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td></td><td id='tdbill~11' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>BillableArea</td><td id='trevec~13' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~7' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>BillAmt</td><td class='middle3'>BillableArea</td><td class='middle3'>SpecialDisc</td><td class='middle3'>SpaceDisc</td><td class='middle3'>SpecialDisc%</td><td class='middle3'>SpaceDisc%</td><td class='middle3'>AdType</td><td class='middle3'>CardRate</td><td class='middle3'>AggRate</td><td class='middle3'>Disc</td><td id='trevec~18' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");



        }


        int i1 = 1;
        float area = 0;
        double BillAmt = 0;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");

            tbl = tbl + (ds.Tables[0].Rows[i]["RetainName"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")

                //            BillAmt = BillAmt + float.Parse(ds.Tables[0].Rows[i].ItemArray[6].ToString());
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

            tbl = tbl + "</tr>";

        }
        // tbl = tbl + ("<tr >");
        //// tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        // tbl = tbl + ("<tr >");
        // tbl = tbl + ("<td class='middle13'>");
        // tbl = tbl + ("<tr><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td><td class='middle13'></td>");
        // tbl = tbl + ("<td class='middle13'>");
        // tbl = tbl + (area.ToString() + "<td class='middle13'>TotalAmt</td><td class='middle13'></td></td>");
        // tbl = tbl + ("<td class='middle13'>");
        // tbl = tbl + (BillAmt.ToString() + "<td class='middle13'></td><td class='middle13'></td></td>");
        // tbl = tbl + "</tr>";
        tbl = tbl + ("<td class='middle13'>TotalAds</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");

        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td></td><td class='middle13'>Total</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "</td>");

        tbl = tbl + ("<td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (BillAmt.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;


        




    }



    private void excel_drillout(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
          //  ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
            ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
        
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";

        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        DataGrid1.DataSource = ds;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        DataGrid1.ShowHeader = true;
        DataGrid1.ShowFooter = true;
        DataGrid1.DataBind();
        hw.Write("<p align=\"center\">Retainer Commision Report");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"8\">TOTAL</td><td>" + areanew + "</td><td align=\"center\" >" + amtnew + "</td><td></td><td align=\"center\" >" + billablearea + "</td></tr></table>"));
        Response.Flush();
        Response.End(); 
    }
    
    /* //myReader = obj.drillout_excelbarter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype);



        string strCurrentDir = Server.MapPath(".") + "\\";
        //RemoveFiles(strCurrentDir); // utility method to clean up old files			
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        // Excel.Range oRng1;

        try
        {


            GC.Collect();// clean up any other excel guys hangin' around...
            oXL = new Excel.Application();
            oXL.Visible = true;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            oRng = oSheet.get_Range("A3", "Y3");
            SqlDataReader myReader1 = null;
            OracleDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
            //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //myReader = obj.drillout_excelbarter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, myrange, maxrange);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                myReader1 = obj.drillout_excelbarter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, myrange, maxrange);

                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[41].ToString();

                for (int j = 0; j < myReader1.FieldCount; j++)
                {


                    //oSheet.Cells[3, j + 1] = myReader1.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[50].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[51].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[52].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[19].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

                    //oSheet.Cells[3, 14] = myReader1.GetName(16).ToString();
                    //oSheet.Cells[3, 15] = myReader1.GetName(27).ToString();
                    //oSheet.Cells[3, 16] = myReader1.GetName(18).ToString();
                    //oSheet.Cells[3, 17] = myReader1.GetName(25).ToString();
                    //oSheet.Cells[3, 18] = myReader1.GetName(23).ToString();
                    //oSheet.Cells[3, 19] = myReader1.GetName(24).ToString();
                    //oSheet.DisplayPageBreaks=

                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();
                int i1 = 1;
                while (myReader1.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader1.FieldCount; k++)
                    {

                        oSheet.Cells[iRow, 2] = myReader1["CIOID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader1["Agency"].ToString();
                        oSheet.Cells[iRow, 4] = myReader1["Client"].ToString();
                        oSheet.Cells[iRow, 5] = myReader1["Publication"].ToString();
                        oSheet.Cells[iRow, 6] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 7] = myReader1["PaymentType"].ToString();
                        oSheet.Cells[iRow, 8] = myReader1["RetainName"].ToString();
                        oSheet.Cells[iRow, 9] = myReader1["RetainerCommision"].ToString();
                        oSheet.Cells[iRow, 10] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 11] = myReader1["BillAmt"].ToString();
                        oSheet.Cells[iRow, 12] = myReader1["BillStatus"].ToString();
                        oSheet.Cells[iRow, 13] = myReader1["BillableArea"].ToString();
                        oSheet.Cells[iRow, 14] = myReader1["RevenueCenter"].ToString();

                        //oSheet.Cells[iRow, 14] = myReader1.GetValue(16).ToString();
                        //oSheet.Cells[iRow, 15] = myReader1.GetValue(27).ToString();
                        //oSheet.Cells[iRow, 16] = myReader1.GetValue(18).ToString();
                        //oSheet.Cells[iRow, 17] = myReader1.GetValue(25).ToString();
                        //oSheet.Cells[iRow, 18] = myReader1.GetValue(23).ToString();
                        //oSheet.Cells[iRow, 19] = myReader1.GetValue(24).ToString();


                    }

                    if (myReader1["Area"].ToString() != "")
                        area = area + int.Parse(myReader1["Area"].ToString());
                    if (myReader1["BillAmt"].ToString() != "")
                        BillAmt = BillAmt + double.Parse(myReader1["BillAmt"].ToString());

                    if (myReader1["BillableArea"].ToString() != "")
                        billarea = billarea + float.Parse(myReader1["BillableArea"].ToString());



                    iRow++;



                }
                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 10] = area.ToString();
                oSheet.Cells[iRow + 1, 11] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 13] = billarea.ToString();


                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;


                myReader1.Close();
                myReader1 = null;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
                myReader = obj.drillout_excelbarter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, myrange, maxrange, temp1, temp2, temp3, temp4, temp5, temp6);

                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[41].ToString();

                for (int j = 0; j < myReader.FieldCount; j++)
                {


                    //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[50].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[51].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[52].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[19].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

                    //oSheet.Cells[3, 14] = myReader.GetName(16).ToString();
                    //oSheet.Cells[3, 15] = myReader.GetName(27).ToString();
                    //oSheet.Cells[3, 16] = myReader.GetName(18).ToString();
                    //oSheet.Cells[3, 17] = myReader.GetName(25).ToString();
                    //oSheet.Cells[3, 18] = myReader.GetName(23).ToString();
                    //oSheet.Cells[3, 19] = myReader.GetName(24).ToString();
                    //oSheet.DisplayPageBreaks=

                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();
                int i1 = 1;
                while (myReader.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader.FieldCount; k++)
                    {

                        oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader["Agency"].ToString();
                        oSheet.Cells[iRow, 4] = myReader["Client"].ToString();
                        oSheet.Cells[iRow, 5] = myReader["Publication"].ToString();
                        oSheet.Cells[iRow, 6] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["PaymentType"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["RetainName"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["RetainerCommision"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["BillAmt"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["BillStatus"].ToString();
                        oSheet.Cells[iRow, 13] = myReader["BillableArea"].ToString();
                        oSheet.Cells[iRow, 14] = myReader["RevenueCenter"].ToString();

                        //oSheet.Cells[iRow, 14] = myReader.GetValue(16).ToString();
                        //oSheet.Cells[iRow, 15] = myReader.GetValue(27).ToString();
                        //oSheet.Cells[iRow, 16] = myReader.GetValue(18).ToString();
                        //oSheet.Cells[iRow, 17] = myReader.GetValue(25).ToString();
                        //oSheet.Cells[iRow, 18] = myReader.GetValue(23).ToString();
                        //oSheet.Cells[iRow, 19] = myReader.GetValue(24).ToString();


                    }

                    if (myReader["Area"].ToString() != "")
                        area = area + int.Parse(myReader["Area"].ToString());
                    if (myReader["BillAmt"].ToString() != "")
                        BillAmt = BillAmt + double.Parse(myReader["BillAmt"].ToString());

                    if (myReader["BillableArea"].ToString() != "")
                        billarea = billarea + float.Parse(myReader["BillableArea"].ToString());



                    iRow++;



                }
                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 9] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 10] = area.ToString();
                oSheet.Cells[iRow + 1, 11] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 13] = billarea.ToString();


                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;


                myReader.Close();
                myReader = null;
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }
            
            //DataSet dst=clsbook.spfun();
            
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "N1").MergeCells = true;
            oSheet.get_Range("A1", "N1").Font.Bold = true;
            oSheet.get_Range("A1", "N1").Font.Size = 10;
            oSheet.get_Range("A3", "Y3").Font.Bold = true;
            oSheet.get_Range("A3", "Y3").Font.Size = 8;
            oSheet.get_Range("A1", "AA1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            oRng.EntireColumn.AutoFit();

            oXL.Visible = true;
            oXL.UserControl = false;
            string strFile = "report" + System.DateTime.Now.Ticks.ToString() + ".xls";

            oWB.SaveAs(strCurrentDir + strFile, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRng);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);

            GC.Collect();  // force final cleanup!
            //string strMachineName = Request.ServerVariables["SERVER_NAME"];
            string strMachineName = Request.ServerVariables["umesh"];
            //errLabel.Text = "<A href=http://" + strMachineName + "/ExcelGen/" + strFile + ">Download Report</a>";



        }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
            //errLabel.Text = errorMessage;
        }
        finally
        {
            Response.Redirect("Retaincom.aspx");
        }


    }


    */



    private void pdf_drillout(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string descid, string ascdesc)
    {
        // ds = obj1.drillout_barter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype);
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



      //  btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'DSC_473011.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 14;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
         
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[41].ToString(), font9));
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

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 11, 13, 17, 17, 16, 17, 17, 14, 16, 18, 12,16,17}; // percentage
            ////float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            //datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[51].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[52].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));
            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

           // NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
           // ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
                ds = obj.drillout_barter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }

            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetainName"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetainerCommision"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));


                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[27].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[25].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[23].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[24].ToString(), font11));


                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);


            PdfPTable tbltotal = new PdfPTable(14);
            float[] headerwidths = { 11, 13, 14, 14, 12, 10, 12, 24, 12, 8, 14, 12, 14, 6 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));



            document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName1);







        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }



     
    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string retainernamechk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (retainernamechk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }
       // totalcommission

        //string check1 = e.Item.Cells[9].Text;
        //string area = e.Item.Cells[9].Text;

        //if (check1 != "Area")
        //{
        //    if (check1 != "&nbsp;")
        //    {


        //        string totalarea = e.Item.Cells[9].Text;
        //        areasum = Convert.ToDouble(totalarea);
        //        areanew = areanew + areasum;


        //    }
        //}

        string check = e.Item.Cells[8].Text;
        string amt = e.Item.Cells[8].Text;

        if (check != "BillAmt")
        {
            if (check != "&nbsp;")
            {


                string totalarea = e.Item.Cells[8].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }
        string check2 = e.Item.Cells[6].Text;
        string billarea = e.Item.Cells[6].Text;

        if (check2 != "RetainerCommision")
        {
            if (check2 != "&nbsp;")
            {


                string billarea1 = e.Item.Cells[6].Text;
                billarea2 = Convert.ToDouble(billarea1);
                totalcommission = totalcommission + billarea2;


            }
        }
   
    }
    protected void btnprint_Click1(object sender, EventArgs e)
    {


                                Response.Redirect("retaincomviewprint.aspx?&fromdate=" + fromdt + "&dateto=" + dateto + "&regioncode=" + region + "&regionname=" + regionname + "&productcode=" + product + "&productname=" + productname + "&editioncode=" + editioncode + "&editionname=" + editionname + "&branchcode=" + branchcode + "&branchname=" + branchname + "&Adtypecode=" + Adtypecode + "&Adtypename=" + Adtypename + "&Retainercode=" + Retainercode + "&Retainername=" + Retainername);
    }
}