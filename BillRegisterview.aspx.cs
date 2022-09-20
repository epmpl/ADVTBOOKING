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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Data.OracleClient;


public partial class BillRegisterview : System.Web.UI.Page


{
    int sno = 1;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;
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
    string product = "";
    string product1 = "";
    string category = "";
    float amt = 0;
    float area = 0;
    double BillAmt = 0;
    double billarea = 0;
    double agencomm = 0;
    int i1 = 1;
    string agcattext = "";
    string publicationcd = "";
    string regionname = "";

    string fromdate = "";
    string todate = "";
    string categorytext = "";
    string publb = "";
    string adtypename = "";
    string agency = "";
    string client = "";
    string publication = "";
    string adtype = "";
    string payment = "";
    string billstatus = "";
    string sortorder = "";
    string sortvalue = "";
    string myrange = "";
    string maxrange = "", adtypenew="",agencycat="",edition="",editionname="";
    int count1 = 0;
    int count2 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
        
        dateto = Session ["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

       
        
        if (Request.QueryString["drilout"] == "yes")
        {
            //fromdate = Request.QueryString["fromdate"].Trim().ToString();
            //todate = Request.QueryString["todate"].Trim().ToString();
            region = Request.QueryString["region"].Trim().ToString();          
            agency = Request.QueryString["agency"].Trim().ToString();
            client = Request.QueryString["client"].Trim().ToString();
            publication = Request.QueryString["publication"].Trim().ToString();
            adtype = Request.QueryString["adtype"].Trim().ToString();
            payment = Request.QueryString["payment"].Trim().ToString();
            billstatus = Request.QueryString["billstatus"].Trim().ToString();
            destination = Request.QueryString["destination"].Trim().ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
            myrange = Request.QueryString["myrange"].Trim().ToString();
            maxrange = Request.QueryString["userrange"].Trim().ToString();
            //________________for pdf sorting_________________________
            if (destination == "3")
            {
                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
            
              


                pdf_drillout(fromdt, dateto, region, product, category, Session["compcode"].ToString(), agency, client, publication, adtype, payment, billstatus, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
            //________________End_________________________


            else if (destination == "4")
            {
               excel_drillout(fromdt, dateto, region, product, category, Session["compcode"].ToString(), agency, client, publication, adtype, payment, billstatus);
            }
            else if (destination == "1" || destination == "0")
            {
                drillonscreen(fromdt, dateto, region, product, category, Session["compcode"].ToString(), agency, client, publication, adtype, payment, billstatus);
                
            }
            
        }

        else
        {
            //DataSet ds1 = new DataSet();
            //ds1.ReadXml(Server.MapPath("XML/report1.xml"));
           // sortorder = Request.QueryString["sortorder"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            fromdt = Request.QueryString["fromdate"].ToString();
            destination = Request.QueryString["destination"].ToString();
            region = Request.QueryString["region"].ToString();
            regionname = Request.QueryString["regionname"].ToString();
            edition = Request.QueryString["edition"].ToString();
            editionname = Request.QueryString["editionname"].ToString();
            category = Request.QueryString["agtype"].ToString();
            categorytext = Request.QueryString["agtypetext"].ToString();
            agencycat = Request.QueryString["agcat"].ToString();
            adtypenew = Request.QueryString["adtype"].ToString();
            publb = Request.QueryString["publication1"].ToString();
            adtypename = Request.QueryString["adtypetext"].ToString();
            agcattext = Request.QueryString["agcattext"].ToString();
            publicationcd = Request.QueryString["publicationcd"].ToString();

            //  Ajax.Utility.RegisterTypeForAjax(typeof(NewRegisterbillingview));
            hiddendatefrom.Value = fromdt.ToString();

            //  hiddendateto.Value = dateto.ToString();
            // string dateformat = Request.QueryString["dateformat"].ToString();

            if (edition == "0")
            {
                lblproduct.Text = "ALL".ToString();
            }
            else
            {
                lblproduct.Text = editionname.ToString();
            }

            if (publicationcd == "0")
            {
                lblcategory.Text = "ALL".ToString();
            }
            else
            {
                lblcategory.Text = publb.ToString();
            }

            //if (category == "AllCategory")
            //{
            //    category = "0".ToString();
            //}

            if (adtypenew == "0")
            {
                lbladtype.Text = "ALL".ToString();
            }
            else
            {
                lbladtype.Text = adtypename.ToString();
            }


            if (region == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = regionname.ToString();
            }

            if (category == "0")
            {
                lblagtype.Text = "ALL".ToString();
            }
            else
            {
                lblagtype.Text = categorytext.ToString();
            }

            if (agencycat == "0")
            {
                lblagcat.Text = "ALL".ToString();
            }
            else
            {
                lblagcat.Text = agcattext.ToString();
            }
            


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

            //if (fromdt != "")
            //{
            //    DateTime dt = Convert.ToDateTime(fromdt.ToString());
            //    if (hiddendateformat.Value == "dd/mm/yyyy")
            //    {
            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        datefrom1 = day + "/" + month + "/" + year;


            //    }
            //    else if (hiddendateformat.Value == "mm/dd/yyyy")
            //    {
            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        datefrom1 = month + "/" + day + "/" + year;

            //    }
            //    else if (hiddendateformat.Value == "yyyy/mm/dd")
            //    {

            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        datefrom1 = year + "/" + month + "/" + day;
            //    }
            //}
            lblfrom.Text = fromdt;
            lblto.Text = dateto;
           
            //if (dateto != "")
            //{
            //    DateTime dt = Convert.ToDateTime(dateto.ToString());
            //    if (hiddendateformat.Value == "dd/mm/yyyy")
            //    {
            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        dateto1 = day + "/" + month + "/" + year;

            //    }
            //    else if (hiddendateformat.Value == "mm/dd/yyyy")
            //    {

            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        dateto1 = month + "/" + day + "/" + year;

            //    }
            //    else if (hiddendateformat.Value == "yyyy/mm/dd")
            //    {

            //        day = dt.Day.ToString();
            //        month = dt.Month.ToString();
            //        year = dt.Year.ToString();
            //        dateto1 = year + "/" + month + "/" + day;
            //    }
            //}
            //lblto.Text = dateto1;



            if (destination == "1" || destination == "0")
            {
                onscreen(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew);
            }
            else if (destination == "4")
            {
                excel(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew);

            }
            else
                if (destination == "3")
                {
                    pdf(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew);
                }
        }
    }




    private void onscreen(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product="";
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.billingonscreen(fromdt, dateto, region, product, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
            //ds = obj.billreg(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dpprodcat.SelectedValue, dpcategory.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            if(category!="0")
            ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat);
            else
            ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);

        }
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' valign='top'>";
        //tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + "<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>";
        if (hiddenascdesc.Value == "")
        {
            //////////tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   

            //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('BillStatus',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");
            tbl = tbl + ("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id) valign='top' align='left'>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id) valign='top' align='left'>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id) valign='top' align='left'>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' valign='top' align='right'>Area</td><td id='trevec~11' class='middle3' onclick=sorting('BillStatus',this.id) valign='top'>Revenue</br>Center<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td><td class='middle31' valign='top'>Rate</td><td class='middle31' valign='top' align='right'>Premium</td><td class='middle31' valign='top'>Bill</br>Remark</td><td class='middle31' valign='top'>Clr</td><td class='middle31' valign='top'>Catg</br>SubCat</td><td class='middle31' valign='top'>Package</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td>");
       
        }
        else if (hiddenascdesc.Value == "asc")
        {
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'  onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");
        }
        else if (hiddenascdesc.Value == "desc")
        {
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td> <td class='middle31' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td> <td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~6' class='middle3'  onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Area</td> <td class='middle31'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td>");
        }
 

        
        

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            string cid = "";
            string rrr1 = ds.Tables[0].Rows[i]["CIOID"].ToString();
            char[] cid1 = rrr1.ToCharArray();
            int len111 = cid1.Length;
            // int line11 = 0;
            for (int ch1 = 0; ch1 < len111; ch1++)
            {

                if (ch1 == 0)
                {
                    cid = cid + cid1[ch1];
                }
                else if (ch1 % 9 != 0)
                {
                    cid = cid + cid1[ch1];
                }
                else
                {

                    cid = cid + "</br>" + cid1[ch1];

                }
            }
            tbl = tbl + (cid + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            //string agency1 = "";
            //string rrr2 = ds.Tables[0].Rows[i]["Agency"].ToString();
            //char[] agency = rrr2.ToCharArray();
            //int len222 = agency.Length;
            //int line22 = 0;
            //for (int ch1 = 0; ((ch1 < len222) && (line22 < 2)); ch1++)
            //{

            //    if (ch1 == 0)
            //    {
            //        agency1 = agency1 + agency[ch1];
            //    }
            //    else if (ch1 % 21 != 0)
            //    {
            //        agency1 = agency1 + agency[ch1];
            //    }
            //    else
            //    {
            //        line22 = line22 + 1;
            //        if (line22 != 2)
            //        {
            //            agency1 = agency1 + "</br>" + agency[ch1];
            //        }
            //    }
            //}
            //tbl = tbl + (agency1 + "</td>");


            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            //string client1 = "";
            //string rrr3 = ds.Tables[0].Rows[i]["Client"].ToString();
            //char[] client = rrr3.ToCharArray();
            //int len333 = client.Length;
            //int line33 = 0;
            //for (int ch1 = 0; ((ch1 < len333) && (line33 < 2)); ch1++)
            //{

            //    if (ch1 == 0)
            //    {
            //        client1 = client1 + client[ch1];
            //    }
            //    else if (ch1 % 21 != 0)
            //    {
            //        client1 = client1 + client[ch1];
            //    }
            //    else
            //    {
            //        line33 = line33 + 1;
            //        if (line33 != 2)
            //        {
            //            client1 = client1 + "</br>" + client[ch1];
            //        }
            //    }
            //}
            //tbl = tbl + (client1 + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i].ItemArray[3].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[i].ItemArray[3].ToString());
           
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            
            
            //tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
            //if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
            //   billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());
           
            
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

            ////////////////////////////////////////////////NEW CHANGE
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Rate"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Premium"] + "</td>");

           

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillRemark"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Color"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Category"]);// + "</td>");
            tbl = tbl + "</br>";
            //tbl = tbl + ("<td class='rep_data'>");
            if (ds.Tables[0].Rows[i]["SubCategory"].ToString()=="0")
            tbl = tbl + ("</td>");
            else
            tbl = tbl + (ds.Tables[0].Rows[i]["SubCategory"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgencyComm"] + "</td>");
            if (ds.Tables[0].Rows[i]["AgencyComm"].ToString() != "")
                agencomm = agencomm + double.Parse(ds.Tables[0].Rows[i]["AgencyComm"].ToString());


            if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["Rate"])
                count1++;
            if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Category"].ToString())
                count2++;

            tbl = tbl + "</tr>";

        }
       
        tbl = tbl + ("<tr >");
        //tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'><b>Total Ads.</b></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'><b>FMG:</b>");
        tbl = tbl + (count1.ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'><b>HouseAd:</b>");
        tbl = tbl + (count2.ToString() + "</td>");


        tbl = tbl + ("<td class='middle13'>");
       

       // tbl = tbl + ("<td class='middle13'> </td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>Total</td>");
        tbl = tbl + ("<td class='middle13'> </td><td class='middle13'> </td><td class='middle13'> </td><td class='middle13'> </td><td class='middle13'> </td><td class='middle13'> </td>");
        
        tbl = tbl + ("<td class='middle13'> </td><td class='middle13'><b>Total</b></td>");

        //tbl = tbl + ("<td class='middle13' align>");
        //tbl = tbl + (area.ToString() + "</td>");
        tbl = tbl + ("<td class='middle13' align='right'>");
        tbl = tbl + (BillAmt.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + ("<td class='middle13' align='right'>");
        tbl = tbl + (agencomm.ToString() + "<td class='middle13'> </td></td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;


    }

    private void excel(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew)
    {
       
        
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
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
                    SqlDataReader myReader = null;
                    OracleDataReader myReader1 = null;

                    DataSet pdfxml = new DataSet();
                    pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                myReader = obj.Billingrepexcel(fromdt, dateto, region, product, category, Session["compcode"].ToString(), Session["dateformat"].ToString());
                //DataSet dst=clsbook.spfun();
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
                oSheet.Cells[1, 5] = ds1.Tables[0].Rows[0].ItemArray[30].ToString();

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
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[19].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();
                    //oSheet.Cells[3, 12] = myReader.GetName(12).ToString();
                    //oSheet.Cells[3, 13] = myReader.GetName(13).ToString();
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
                        oSheet.Cells[iRow, 8] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["BillAmt"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["BillStatus"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["BillableArea"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["RevenueCenter"].ToString();
                        //oSheet.Cells[iRow, 12] = myReader.GetValue(12).ToString();
                        //oSheet.Cells[iRow, 13] = myReader.GetValue(13).ToString();
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
                oSheet.Cells[iRow + 1, 7] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 8] = area.ToString();
                oSheet.Cells[iRow + 1, 9] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 11] = billarea.ToString();

                string row;
                string row1;
                iRow = iRow + 1;
                row = "A" + Convert.ToString(iRow);
                row1 = "AA" + Convert.ToString(iRow);

                oSheet.get_Range(row, row1).Font.Bold = true;


                myReader.Close();
                myReader = null;
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
            Response.Redirect("BillRegister.aspx");
        }

        }



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product="";
       
                //NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
                //myReader1 = obj.billreg_excel(fromdt, dateto, Session["compcode"].ToString(), product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, temp_adtype, temp_pubcent, category, temp_edition, temp_agency, region);
                //SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                //NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
                //ds = obj.billingonscreen(fromdt, dateto, region, product, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, temp_adtype, temp_pubcent, temp_edition, temp_agency, executive, state, district);


                NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
                //ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);
                if (category != "0")
                    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat);
                else
                    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);
                int cont = ds.Tables[0].Rows.Count;
                for (int i = 0; i < cont - 1; i++)
                {

                    if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["Rate"])
                        count1++;
                    if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Category"].ToString())
                        count2++;
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
                hw.Write("<p align=\"center\">Billing Resister");

                hw.WriteBreak();

                DataGrid1.RenderControl(hw);

                int sno11 = sno - 1;

                //Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"6\">TOTAL</td><td>" + areanew + "</td><td align=\"center\" >" + amtnew + "</td><td></td><td align=\"center\" >" + billablearea + "</td></tr></table>"));
                Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td >Fmg:" + count1 + "</td><td >HouseAds:" + count2 + "</td><td align=\"right\" colspan=\"11\">TOTAL</td><td align=\"center\" >" + amtnew + "</td><td align=\"center\" >" + billablearea + "</td></tr></table>"));



               // Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds :" + sno11 + "</td><td colspan=\"2\">TotalArea:" + areanew + "</td><td>Line/Word::" + count3 + "</td><td >Size:" + count31 + "</td><td>Paid:" + paidins + "</td><td colspan=\"5\">Fmg:" + count1 + "</td><td colspan=\"4\">HouseAds:" + count2 + "</td><td colspan=\"4\">Pages:" + 1 + "-" + sno11 + "</td></table>")); //align=\"center\" colspan=\"7\"
               
                Response.Flush();
                Response.End();
            }
          


        
    }

    private void pdf(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product="";

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
        //////////////////////////////////////////////////////////////////////////////////
        //PdfAction action = PdfAction.gotoLocalPage(2, new PdfDestination(PdfDestination.XYZ, -1, 10000, 0), writer);
        //writer.setOpenAction(action);
        //document.Add(new Paragraph("Page 1"));
        //document.newPage();
        //document.Add(new Paragraph("Page 2"));
        
        

        ////String application = "c:/winnt/notepad.exe";
        //Paragraph p = new Paragraph(new Chunk("Click to open " + pdfName).setAction(new PdfAction(pdfName, null, null, null)));
        //PdfPTable table = new PdfPTable(4);
        //table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.addCell(new Phrase(new Chunk("First Page").setAction(new PdfAction(PdfAction.FIRSTPAGE))));
        //table.addCell(new Phrase(new Chunk("Prev Page").setAction(new PdfAction(PdfAction.PREVPAGE))));
        //table.addCell(new Phrase(new Chunk("Next Page").setAction(new PdfAction(PdfAction.NEXTPAGE))));
        //table.addCell(new Phrase(new Chunk("Last Page").setAction(new PdfAction(PdfAction.LASTPAGE))));

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        //---------------------------end-------------------------------------------------------

        int NumColumns = 15;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[30].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);
            //tbl.DefaultCell.Padding = -5;

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
            tbl2.addCell(new Phrase(fromdt.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));

          
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11, 10, 16, 18,12}; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
            ////  datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));


            ////datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
           // datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
           // datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[60].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[63].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString() + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[65].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[65].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[66].ToString(), font10));
            datatable.HeaderRows = 1;
            

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

          
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "SQL")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                ds = obj.billingonscreen(fromdt, dateto, region, product, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
               // ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);

               if (category != "0")
                    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat);
                else
                    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);


            }
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                                
                
                
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
             
                //string agency1 = "";
                //string rrr2 = ds.Tables[0].Rows[row]["Agency"].ToString();
                //char[] agency = rrr2.ToCharArray();
                //int len222 = agency.Length;
                //int line22 = 0;
                //for (int ch1 = 0; ((ch1 < len222) && (line22 < 2)); ch1++)
                //{

                //    if (ch1 == 0)
                //    {
                //        agency1 = agency1 + agency[ch1];
                //    }
                //    else if (ch1 % 21 != 0)
                //    {
                //        agency1 = agency1 + agency[ch1];
                //    }
                //    else
                //    {
                //        line22 = line22 + 1;
                //        if (line22 != 2)
                //        {
                //            agency1 = agency1 + "\n" + agency[ch1];
                //        }
                //    }
                //}
             
                //datatable.addCell(new Phrase(agency1, font11));



                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));

                //string client1 = "";
                //string rrr3 = ds.Tables[0].Rows[row]["Client"].ToString();
                //char[] client = rrr3.ToCharArray();
                //int len333 = client.Length;
                //int line33 = 0;
                //for (int ch1 = 0; ((ch1 < len333) && (line33 < 2)); ch1++)
                //{

                //    if (ch1 == 0)
                //    {
                //        client1 = client1 + client[ch1];
                //    }
                //    else if (ch1 % 21 != 0)
                //    {
                //        client1 = client1 + client[ch1];
                //    }
                //    else
                //    {
                //        line33 = line33 + 1;
                //        if (line33 != 2)
                //        {
                //            client1 = client1 + "</br>" + client[ch1];
                //        }
                //    }
                //}
                //datatable.addCell(new Phrase(client1, font11));




                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row].ItemArray[3].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row].ItemArray[3].ToString());

                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
               // if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                  //  billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Rate"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Premium"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillRemark"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                if (ds.Tables[0].Rows[row]["SubCategory"].ToString() == "0")
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString() +"\n"+ "", font11));
                else
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString() + "\n" + ds.Tables[0].Rows[row]["SubCategory"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row].ItemArray[6].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row].ItemArray[6].ToString());
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgencyComm"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["AgencyComm"].ToString() != "")
                    agencomm = agencomm + double.Parse(ds.Tables[0].Rows[row]["AgencyComm"].ToString());

                if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[row]["Rate"])
                    count1++;
                if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[row]["Category"].ToString())
                    count2++;
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[13].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[16].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[27].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[25].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[23].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[24].ToString(), font11));


                row++;

            }
            
            document.Add(datatable);
             
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));
            document.Add(p3);
           
            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10,10,16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1-1).ToString(), font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[67].ToString() + count1.ToString(), font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[68].ToString() + count2.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
           
            //tbltotal.addCell(new Phrase(area.ToString(), font11));
           // tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));  
            //tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));  
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10)); 
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            tbltotal.addCell(new Phrase(agencomm.ToString(), font11));

           
            //tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            
            
            document.Add(tbltotal);

           
//55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555
            //document.Add(new Paragraph("This is page " + k));
            //document.Add(table);
            //document.Add(p);
            //document.newPage();
            //try
            //{

            //    // step 2: we create a writer that listens to the document
            //   // PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1103.pdf", FileMode.Create));
            //    // step 3: we open the document
            //    document.Open();
            //    // step 4: we add some content
            //    String application = "c:/winnt/notepad.exe";
            //    Paragraph p = new Paragraph(new Chunk("Click to open " + application).setAction(new PdfAction(application, null, null, null)));
            //    PdfPTable table = new PdfPTable(4);
            //    table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    table.addCell(new Phrase(new Chunk("First Page").setAction(new PdfAction(PdfAction.FIRSTPAGE))));
            //    table.addCell(new Phrase(new Chunk("Prev Page").setAction(new PdfAction(PdfAction.PREVPAGE))));
            //    table.addCell(new Phrase(new Chunk("Next Page").setAction(new PdfAction(PdfAction.NEXTPAGE))));
            //    table.addCell(new Phrase(new Chunk("Last Page").setAction(new PdfAction(PdfAction.LASTPAGE))));
            //    for (int k = 1; k <= 10; ++k)
            //    {
            //        document.Add(new Paragraph("This is page " + k));
            //        document.Add(table);
            //        document.Add(p);
            //        document.newPage();
            //    }
            //}
            //catch (Exception de)
            //{
            //    Console.Error.WriteLine(de.StackTrace);
            //    Console.Error.WriteLine(de.Message);
            //}

            //55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555



            document.Close();

            //document.PageCount=0;
            //count = i2;
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
        //pdf1(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew);
        Response.Redirect("printbillregister.aspx?dateto="+dateto+"&fromdate="+fromdt+"&destination="+destination+"&region="+region+"&regionname="+regionname+"&edition="+edition+"&editionname="+editionname+"&agtype="+category+"&agtypetext="+categorytext+"&agcat="+agencycat+"&adtype="+adtypenew+"&publication1="+publb+"&adtypetext="+adtypename+"&agcattext="+agcattext+"&publicationcd="+publicationcd+" ");

         
    }

    //=========================================================================================

    private void pdf1(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "",temp_product="";

        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;



       // btnprint.Attributes.Add("onclick", "javascript:window.print();");

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
        //////////////////////////////////////////////////////////////////////////////////
        //PdfAction action = PdfAction.gotoLocalPage(2, new PdfDestination(PdfDestination.XYZ, -1, 10000, 0), writer);
        //writer.setOpenAction(action);
        //document.Add(new Paragraph("Page 1"));
        //document.newPage();
        //document.Add(new Paragraph("Page 2"));
        
        

        ////String application = "c:/winnt/notepad.exe";
        //Paragraph p = new Paragraph(new Chunk("Click to open " + pdfName).setAction(new PdfAction(pdfName, null, null, null)));
        //PdfPTable table = new PdfPTable(4);
        //table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.addCell(new Phrase(new Chunk("First Page").setAction(new PdfAction(PdfAction.FIRSTPAGE))));
        //table.addCell(new Phrase(new Chunk("Prev Page").setAction(new PdfAction(PdfAction.PREVPAGE))));
        //table.addCell(new Phrase(new Chunk("Next Page").setAction(new PdfAction(PdfAction.NEXTPAGE))));
        //table.addCell(new Phrase(new Chunk("Last Page").setAction(new PdfAction(PdfAction.LASTPAGE))));

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[30].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);
            //tbl.DefaultCell.Padding = -5;

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
            tbl2.addCell(new Phrase(fromdt.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11, 10, 16, 18,12}; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
            //  datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));


            //datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            datatable.HeaderRows = 1;
            

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                ds = obj.billingonscreen(fromdt, dateto, region, product, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
                //ds = obj.billreg(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dpprodcat.SelectedValue, dpcategory.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
                ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);

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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row].ItemArray[3].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row].ItemArray[3].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row].ItemArray[6].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row].ItemArray[6].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));

                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[13].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[16].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[27].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[25].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[23].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[24].ToString(), font11));


                row++;

            }
            
            document.Add(datatable);
             
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));
            document.Add(p3);
           
            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10,10,16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1-1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10)); 
            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));            
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            
            
            document.Add(tbltotal);

           
//55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555
            //document.Add(new Paragraph("This is page " + k));
            //document.Add(table);
            //document.Add(p);
            //document.newPage();
            //try
            //{

            //    // step 2: we create a writer that listens to the document
            //   // PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1103.pdf", FileMode.Create));
            //    // step 3: we open the document
            //    document.Open();
            //    // step 4: we add some content
            //    String application = "c:/winnt/notepad.exe";
            //    Paragraph p = new Paragraph(new Chunk("Click to open " + application).setAction(new PdfAction(application, null, null, null)));
            //    PdfPTable table = new PdfPTable(4);
            //    table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    table.addCell(new Phrase(new Chunk("First Page").setAction(new PdfAction(PdfAction.FIRSTPAGE))));
            //    table.addCell(new Phrase(new Chunk("Prev Page").setAction(new PdfAction(PdfAction.PREVPAGE))));
            //    table.addCell(new Phrase(new Chunk("Next Page").setAction(new PdfAction(PdfAction.NEXTPAGE))));
            //    table.addCell(new Phrase(new Chunk("Last Page").setAction(new PdfAction(PdfAction.LASTPAGE))));
            //    for (int k = 1; k <= 10; ++k)
            //    {
            //        document.Add(new Paragraph("This is page " + k));
            //        document.Add(table);
            //        document.Add(p);
            //        document.newPage();
            //    }
            //}
            //catch (Exception de)
            //{
            //    Console.Error.WriteLine(de.StackTrace);
            //    Console.Error.WriteLine(de.Message);
            //}

            //55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555



            document.Close();

            //document.PageCount=0;
            //count = i2;
           // Response.Redirect(pdfName);

        


            Process proc = new Process();
            //proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 6.0\Acrobat\Acrobat.exe";
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Reader 9.0\Reader\AcroRd32.exe";
            //proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
            proc.StartInfo.Arguments = @"/p /h" + Server.MapPath(pdfName1);
            //proc.StartInfo.Arguments = @"/p /Depth" + Server.MapPath(pdfName1);

            //proc.StartInfo.Arguments = @"/p /Depth C:\Inetpub\wwwroot\NewAdbooking\3719138.pdf";

            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.UseShellExecute = false;
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


    private void drillonscreen(string fromdate, string todate, string region, string product, string category, string compcode, string agency, string client, string publication, string adtype, string payment, string billstatus)
    {
        NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ds = obj.drillout(fromdate, todate, region, product, category, compcode, Session["dateformat"].ToString(), agency, client, publication, adtype, payment, billstatus, myrange,maxrange, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        if (hiddenascdesc.Value == "")
        {
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('BillStatus',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");
        }
        else if (hiddenascdesc.Value == "asc")
        {
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'  onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");
        }
        else if (hiddenascdesc.Value == "desc")
        {
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td> <td class='middle31' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td> <td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tadtype~5' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~6' class='middle3'  onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Area</td> <td class='middle31'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td>");
        }


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
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
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

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");



        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'> </td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>Total</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (BillAmt.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;


    }



    private void excel_drillout(string fromdate, string todate, string region, string product, string category, string compcode, string agency, string client, string publication, string adtype, string payment, string billstatus)
    {


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
            SqlDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            myReader = obj.drillout_excelbill(fromdate, todate, region, product, category, compcode, Session["dateformat"].ToString(), agency, client, publication, adtype, payment, billstatus, myrange, maxrange);
            //DataSet dst=clsbook.spfun();
            int iRow = 4;  //2
            oSheet.PageSetup.CenterFooter = "&P";

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            // heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
            oSheet.Cells[1, 5] = ds1.Tables[0].Rows[0].ItemArray[30].ToString();

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
                oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[19].ToString();
                oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                oSheet.Cells[3, 11] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();
                oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();
                //oSheet.Cells[3, 12] = myReader.GetName(12).ToString();
                //oSheet.Cells[3, 13] = myReader.GetName(13).ToString();
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
                    oSheet.Cells[iRow, 8] = myReader["Area"].ToString();
                    oSheet.Cells[iRow, 9] = myReader["BillAmt"].ToString();
                    oSheet.Cells[iRow, 10] = myReader["BillStatus"].ToString();
                    oSheet.Cells[iRow, 11] = myReader["BillableArea"].ToString();
                    oSheet.Cells[iRow, 12] = myReader["RevenueCenter"].ToString();
                    //oSheet.Cells[iRow, 12] = myReader.GetValue(12).ToString();
                    //oSheet.Cells[iRow, 13] = myReader.GetValue(13).ToString();
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
            oSheet.Cells[iRow + 1, 7] = "Totals :".ToString();
            oSheet.Cells[iRow + 1, 8] = area.ToString();
            oSheet.Cells[iRow + 1, 9] = BillAmt.ToString();
            oSheet.Cells[iRow + 1, 11] = billarea.ToString();

            string row;
            string row1;
            iRow = iRow + 1;
            row = "A" + Convert.ToString(iRow);
            row1 = "AA" + Convert.ToString(iRow);

            oSheet.get_Range(row, row1).Font.Bold = true;


            myReader.Close();
            myReader = null;
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
            Response.Redirect("BillRegister.aspx");
        }
  
       
    }






    private void pdf_drillout(string fromdate, string todate, string region, string product, string category, string compcode, string agency, string client, string publication, string adtype, string payment, string billstatus, string descid, string ascdesc)
    {



        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        btnprint.Attributes.Add("onclick", "javascript:window.print();");

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
        //////////////////////////////////////////////////////////////////////////////////
        //PdfAction action = PdfAction.gotoLocalPage(2, new PdfDestination(PdfDestination.XYZ, -1, 10000, 0), writer);
        //writer.setOpenAction(action);
        //document.Add(new Paragraph("Page 1"));
        //document.newPage();
        //document.Add(new Paragraph("Page 2"));



        ////String application = "c:/winnt/notepad.exe";
        //Paragraph p = new Paragraph(new Chunk("Click to open " + pdfName).setAction(new PdfAction(pdfName, null, null, null)));
        //PdfPTable table = new PdfPTable(4);
        //table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.addCell(new Phrase(new Chunk("First Page").setAction(new PdfAction(PdfAction.FIRSTPAGE))));
        //table.addCell(new Phrase(new Chunk("Prev Page").setAction(new PdfAction(PdfAction.PREVPAGE))));
        //table.addCell(new Phrase(new Chunk("Next Page").setAction(new PdfAction(PdfAction.NEXTPAGE))));
        //table.addCell(new Phrase(new Chunk("Last Page").setAction(new PdfAction(PdfAction.LASTPAGE))));

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8);

        // ---------------table for heading-------------------------
        try
        {
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[30].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);
            //tbl.DefaultCell.Padding = -5;

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
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11, 10, 16, 18,12}; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
            //  datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));


            //datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            datatable.HeaderRows = 1;


            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

            NewAdbooking.Classes.bill obj1 = new NewAdbooking.Classes.bill();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = obj1.drillout(fromdate, todate, region, product, category, compcode, Session["dateformat"].ToString(), agency, client, publication, adtype, payment, billstatus, myrange, maxrange, descid,ascdesc);


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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row].ItemArray[3].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row].ItemArray[3].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row].ItemArray[6].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row].ItemArray[6].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));

                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[13].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[16].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[27].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[25].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[23].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[24].ToString(), font11));


                row++;

            }

            document.Add(datatable);

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16 }; // percentage
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
            tbltotal.addCell(new Phrase(area.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));


            document.Add(tbltotal);


            //55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555
            //document.Add(new Paragraph("This is page " + k));
            //document.Add(table);
            //document.Add(p);
            //document.newPage();
            //try
            //{

            //    // step 2: we create a writer that listens to the document
            //   // PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1103.pdf", FileMode.Create));
            //    // step 3: we open the document
            //    document.Open();
            //    // step 4: we add some content
            //    String application = "c:/winnt/notepad.exe";
            //    Paragraph p = new Paragraph(new Chunk("Click to open " + application).setAction(new PdfAction(application, null, null, null)));
            //    PdfPTable table = new PdfPTable(4);
            //    table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    table.addCell(new Phrase(new Chunk("First Page").setAction(new PdfAction(PdfAction.FIRSTPAGE))));
            //    table.addCell(new Phrase(new Chunk("Prev Page").setAction(new PdfAction(PdfAction.PREVPAGE))));
            //    table.addCell(new Phrase(new Chunk("Next Page").setAction(new PdfAction(PdfAction.NEXTPAGE))));
            //    table.addCell(new Phrase(new Chunk("Last Page").setAction(new PdfAction(PdfAction.LASTPAGE))));
            //    for (int k = 1; k <= 10; ++k)
            //    {
            //        document.Add(new Paragraph("This is page " + k));
            //        document.Add(table);
            //        document.Add(p);
            //        document.newPage();
            //    }
            //}
            //catch (Exception de)
            //{
            //    Console.Error.WriteLine(de.StackTrace);
            //    Console.Error.WriteLine(de.Message);
            //}

            //55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555



            document.Close();

            //document.PageCount=0;
            //count = i2;
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }



    protected void hiddencioid_TextChange(object sender, EventArgs e)
    {

    }
    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        //string check1 = e.Item.Cells[7].Text;
        //string area = e.Item.Cells[7].Text;

        //if (check1 != "Area")
        //{
        //    if (check1 != "&nbsp;")
        //    {


        //        string totalarea = e.Item.Cells[7].Text;
        //        areasum = Convert.ToDouble(totalarea);
        //        areanew = areanew + areasum;


        //    }
        //}

        //string fmg = e.Item.Cells[7].Text;
        //string fmgtot = e.Item.Cells[7].Text;
        //if (fmg != "Area")
        //{
        //    if (fmg != "&nbsp;")
        //    {

        //        if(ConfigurationSettings.AppSettings["FMG"].ToString()==)
        //        string totalarea = e.Item.Cells[7].Text;
        //        areasum = Convert.ToDouble(totalarea);
        //        areanew = areanew + areasum;


        //    }
        //}


        string check = e.Item.Cells[14].Text;
        string amt = e.Item.Cells[14].Text;

        if (check != "BillAmt")
        {
            if (check != "&nbsp;")
            {


                string totalarea = e.Item.Cells[14].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }
        string check2 = e.Item.Cells[15].Text;
        string billarea = e.Item.Cells[15].Text;

        if (check2 != "AgencyComm")
        {
            if (check2 != "&nbsp;")
            {


                string billarea1 = e.Item.Cells[15].Text;
                billarea2 = Convert.ToDouble(billarea1);
                billablearea = billablearea + billarea2;


            }
        }
    }
}