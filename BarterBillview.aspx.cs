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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Data.OracleClient;
public partial class BarterBillview : System.Web.UI.Page
{    
    string destination = "";   
    string fromdt = "";
    string dateto = "";
    string frmdt="";
    string  todate="";
    int sno = 1;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;



    string dytbl = "";
  
    string date = "";  
    string day = "";
    string month = "";
    string year = "";  
   
    string pdfName1 = "";
    string region="";
    string regionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    string product = "";
    string productname = "";
    float area = 0;
    double BillAmt = 0;
    double billarea = 0;
    string sortorder = "";
    string sortvalue = "";
    string agency, fromdate, client, publication, adtype, billstatus, payment = "";
    string myrange = "";
    string maxrange = "";
    string temp_agname, temp_adtype, temp_pubcent,  temp_edition,  temp_agency,temp_category;
    string temp_retain = "", temp_pubname = "",  temp_prod;

    string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "";
    string newadtype = "", newcategory = "", newclient = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));

        heading.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

        if (Request.QueryString["drilout"] == "yes")
        {
            region = Request.QueryString["region"].Trim().ToString();
              agency = Request.QueryString["agency"].Trim().ToString();
            client = Request.QueryString["client"].Trim().ToString();
            publication = Request.QueryString["publication"].Trim().ToString();
            adtype = Request.QueryString["adtype"].Trim().ToString();
            payment = Request.QueryString["payment"].Trim().ToString();
            billstatus = Request.QueryString["billstatus"].Trim().ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();
            destination = Request.QueryString["destination"].Trim().ToString();
            myrange = Request.QueryString["myrange"].Trim().ToString();
            maxrange = Request.QueryString["userrange"].Trim().ToString();

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

            newadtype = Request.QueryString["newadtype"].ToString();
            newcategory = Request.QueryString["newcategory"].ToString();
            newclient = Request.QueryString["client"].ToString();
            
            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();

            region = Request.QueryString["regcode"].ToString();
            regionname = Request.QueryString["region"].ToString();
            product = Request.QueryString["product"].ToString();
            productname = Request.QueryString["productname"].ToString();
            destination = Request.QueryString["destination"].ToString();
            

            Ajax.Utility.RegisterTypeForAjax(typeof(BarterBillview));
            hiddendatefrom.Value = fromdt.ToString();

            //  hiddendateto.Value = dateto.ToString();
            // string dateformat = Request.QueryString["dateformat"].ToString();     








            if (product == "0")
            {
                lblpub.Text = "ALL".ToString();
            }
            else
            {
                lblpub.Text = productname.ToString();
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
            lblfrom.Text = datefrom1;
            //dateto1 = "";
            if (dateto != "")
            {





                ///////////


                if (hiddendateformat.Value == "dd/mm/yyyy")
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



            if (destination == "1" || destination == "0")
            {
                onscreen(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(),newadtype,newcategory,newclient);
            }
            else if (destination == "4")
            {
                excel(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), newadtype, newcategory, newclient);

            }
            else
                if (destination == "3")
                {
                    pdf(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), newadtype, newcategory, newclient);
                }

        }

    }

    private void onscreen(string frmdt, string todate, string compcode, string region, string product, string dateformate,string newadtype,string newcategory,string newclient)
    {
        //NewAdbooking.Classes.bill  obj = new NewAdbooking.Classes.bill ();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
           ds = obj.barter_report(fromdt,dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),newadtype,newcategory,newclient);
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }
        
        int cont = ds.Tables[0].Rows.Count;
       
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
      


        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('Publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~36' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:block;'><img id='imgaup' src='Images\\up.gif' style='display:none;'></td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('BillAmt',this.id)>BillableAmt<img id='imgbldown' src='Images\\down.gif' style='display:block;'><img id='imgblup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('BillableArea',this.id)>BillableArea<img id='imgbdown' src='Images\\down.gif' style='display:block;'><img id='imgbup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");           
               }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'   onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('Publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~36' class='middle3'   onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:block;'><img id='imgaup' src='Images\\up.gif' style='display:none;'></td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~37' class='middle3'   onclick=sorting('BillAmt',this.id)>BillableAmt<img id='imgbldown' src='Images\\down.gif' style='display:block;'><img id='imgblup' src='Images\\up.gif' style='display:none;'></td><td id='tdag~35' class='middle3'   onclick=sorting('BillableArea',this.id)>BillableArea<img id='imgbdown' src='Images\\down.gif' style='display:block;'><img id='imgbup' src='Images\\up.gif' style='display:none;'></td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
        }
        else if (hiddenascdesc.Value == "desc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'  onclick=sorting('CIOID',this.id)>CIOID<img id='imgcidown' src='Images\\down.gif' style='display:none;'><img id='imgciup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('Publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~36' class='middle3'  onclick=sorting('Area',this.id)>Area<img id='imgadown' src='Images\\down.gif' style='display:none;'><img id='imgaup' src='Images\\up.gif' style='display:block;'></td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~37' class='middle3'  onclick=sorting('BillAmt',this.id)>BillableAmt<img id='imgbldown' src='Images\\down.gif' style='display:none;'><img id='imgblup' src='Images\\up.gif' style='display:block;'></td><td id='tdag~35' class='middle3'  onclick=sorting('BillableArea',this.id)>BillableArea<img id='imgbdown' src='Images\\down.gif' style='display:none;'><img id='imgbup' src='Images\\up.gif' style='display:block;'></td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");
        }
        
        
        

        int i1 = 1;
        

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
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
            
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());
                
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");            
            tbl = tbl + "</tr>";

        }

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");



        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("</td><td class='middle13'></td><td class='middle13'>Total</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (BillAmt.ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
        tbl = tbl + "</tr>";
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

    private void excel(string frmdt, string todate, string compcode, string region, string product, string dateformate, string newadtype, string newcategory, string newclient)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.drillout_barter(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.barter_report(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), newadtype, newcategory, newclient);
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
        hw.Write("<p align=\"center\">Barter Wise Billing");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"4\">TOTAL</td><td>" + areanew + "</td><td></td><td></td><td align=\"center\" >" + amtnew + "</td><td align=\"center\" >" + billablearea + "</td></tr></table>"));
        Response.Flush();
        Response.End(); 

    }  
        /*string strCurrentDir = Server.MapPath(".") + "\\";
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

            //NewAdbooking.Classes.bill  obj = new NewAdbooking.Classes.bill();
            //myReader = obj.barter_reportexcel(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                myReader1 = obj.barter_reportexcel(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString());
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[29].ToString();

                for (int j = 0; j < myReader1.FieldCount; j++)
                {

                    //oSheet.Cells[3, j + 1] = myReader1.GetName(j).ToString();

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[1].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();

                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

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
                        oSheet.Cells[iRow, 6] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 7] = myReader1["BillStatus"].ToString();
                        oSheet.Cells[iRow, 8] = myReader1["PaymentType"].ToString();
                        oSheet.Cells[iRow, 9] = myReader1["BillAmt"].ToString();
                        oSheet.Cells[iRow, 10] = myReader1["BillableArea"].ToString();

                        oSheet.Cells[iRow, 11] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 12] = myReader1["RevenueCenter"].ToString();
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
                oSheet.Cells[iRow + 1, 5] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 6] = area.ToString();
                oSheet.Cells[iRow + 1, 9] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 10] = billarea.ToString();


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
                myReader = obj.barter_reportexcel(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), newadtype, newcategory, newclient);
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[29].ToString();

                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[1].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();

                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

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
                        oSheet.Cells[iRow, 6] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["BillStatus"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["PaymentType"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["BillAmt"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["BillableArea"].ToString();

                        oSheet.Cells[iRow, 11] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["RevenueCenter"].ToString();
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
                oSheet.Cells[iRow + 1, 5] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 6] = area.ToString();
                oSheet.Cells[iRow + 1, 9] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 10] = billarea.ToString();


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
            Response.Redirect("BarterBill.aspx");
        }
    }
        */
    private void pdf(string frmdt, string todate, string compcode, string region, string product, string dateformate,string newadtype,string newcategory,string newclient)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



     //   btnprint.Attributes.Add("onclick", "javascript:window.print();");

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

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[29].ToString(), font9));
            //ds.Tables[0].Rows[row].ItemArray[0]
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
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11, 10, 16, 18, 15}; // percentage
            ////float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
          
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            
           
            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

           // NewAdbooking.Classes.bill  obj = new NewAdbooking.Classes.bill ();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
                ds = obj.barter_report(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), newadtype, newcategory, newclient);
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));           


                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(12);
            float[] headerwidths = { 15, 13, 14, 14, 12, 10, 12, 18, 12, 8, 16, 18}; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));
          
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));
           
           // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
           // tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            document.Add(tbltotal);


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
           
            //Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
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


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            
            
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

        pdf1(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString());

    }

    //=========================================================================================

    private void pdf1(string frmdt, string todate, string compcode, string region, string product, string dateformate)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName1 = "";
        pdfName1 = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName1;



        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

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

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[29].ToString(), font9));
            //ds.Tables[0].Rows[row].ItemArray[0]
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
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11, 10, 16, 18, 15}; // percentage
            ////float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));


            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

            //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.billreport obj = new NewAdbooking.classesoracle.billreport();
                ds = obj.barter_report(fromdt, dateto, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), newadtype, newcategory, newclient);
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));


                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(12);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));

            // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            document.Add(tbltotal);



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


            document.Close();

 
            //document.PageCount=0;
            //count = i2;
           




            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
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



    private void drillonscreen(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype)
    {

        //ds = obj.drillout(fromdate, todate, region, product, category, compcode, "dd/mm/yyyy", agency, client, publication, adtype, payment, billstatus);


        //NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange,maxrange);

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
            ds = obj.drillout_barter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }
        
        
        int cont = ds.Tables[0].Rows.Count;

        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";



        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillAmt</td><td class='middle31'>BillableArea</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");   
            // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");
        }
        else if (hiddenascdesc.Value == "asc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillAmt</td><td class='middle31'>BillableArea</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
        }
        else if (hiddenascdesc.Value == "desc")
        {
            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:none;'><img id='imgpayup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>BillAmt</td><td class='middle31'>BillableArea</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");
        }
        


        int i1 = 1;


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
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                billarea = billarea + double.Parse(ds.Tables[0].Rows[i]["BillableArea"].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");
            tbl = tbl + "</tr>";

        }

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");



        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("</td><td class='middle13'></td><td class='middle13'>Total</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (BillAmt.ToString() + "</td>");
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
            ds = obj.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.bill obj = new NewAdbooking.classesoracle.bill();
            ds = obj.drillout_barter(fromdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
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
        hw.Write("<p align=\"center\">Barter Wise Billing");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"4\">TOTAL</td><td>" + areanew + "</td><td></td><td></td><td align=\"center\" >" + amtnew + "</td><td align=\"center\" >" + billablearea + "</td></tr></table>"));
        Response.Flush();
        Response.End(); 
    } 
    
    
    /* string strCurrentDir = Server.MapPath(".") + "\\";
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
            //myReader = obj.drillout_excelbarter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, myrange, maxrange);

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                myReader1 = obj.drillout_excelbarter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, myrange, maxrange);
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
                //---------myreader----------------
                for (int j = 0; j < myReader1.FieldCount; j++)
                {

                    //oSheet.Cells[3, j + 1] = myReader1.GetName(j).ToString();

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[1].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();

                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

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
                        oSheet.Cells[iRow, 6] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 7] = myReader1["BillStatus"].ToString();
                        oSheet.Cells[iRow, 8] = myReader1["PaymentType"].ToString();
                        oSheet.Cells[iRow, 9] = myReader1["BillAmt"].ToString();
                        oSheet.Cells[iRow, 10] = myReader1["BillableArea"].ToString();

                        oSheet.Cells[iRow, 11] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 12] = myReader1["RevenueCenter"].ToString();
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
                oSheet.Cells[iRow + 1, 5] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 6] = area.ToString();
                oSheet.Cells[iRow + 1, 9] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 10] = billarea.ToString();


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
                myReader = obj.drillout_excelbarter(fromdate, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, myrange, maxrange, temp1, temp2, temp3, temp4, temp5, temp6);
                int iRow = 4;  //2
                oSheet.PageSetup.CenterFooter = "&P";

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
                //---------myreader----------------
                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();

                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[56].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[1].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[1].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[1].Rows[0].ItemArray[4].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[1].Rows[0].ItemArray[1].ToString();

                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 12] = pdfxml.Tables[1].Rows[0].ItemArray[2].ToString();

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
                        oSheet.Cells[iRow, 6] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["BillStatus"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["PaymentType"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["BillAmt"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["BillableArea"].ToString();

                        oSheet.Cells[iRow, 11] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 12] = myReader["RevenueCenter"].ToString();
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
                oSheet.Cells[iRow + 1, 5] = "Totals :".ToString();
                oSheet.Cells[iRow + 1, 6] = area.ToString();
                oSheet.Cells[iRow + 1, 9] = BillAmt.ToString();
                oSheet.Cells[iRow + 1, 10] = billarea.ToString();


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
            

            //---------myreader----------------

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
            Response.Redirect("BarterBill.aspx");
        }


    
    }



        */


    private void pdf_drillout(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string descid, string ascdesc)
    {



        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



     //   btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
           HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[29].ToString(), font9));
            //ds.Tables[0].Rows[row].ItemArray[0]
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
            //float[] headerwidths = { 11, 13, 14, 17, 16, 11, 11, 10, 16, 18, 15}; // percentage
            ////float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));


            datatable.HeaderRows = 1;

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

           // NewAdbooking.Classes.bill obj1 = new NewAdbooking.Classes.bill();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj1.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj1 = new NewAdbooking.Classes.bill();
                ds = obj1.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.bill obj1 = new NewAdbooking.classesoracle.bill();
                ds = obj1.drillout_barter(frmdt, todate, Session["compcode"].ToString(), region, Session["dateformat"].ToString(), publication, agency, client, billstatus, payment, adtype, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), myrange, maxrange, temp_retain, temp_pubcent, temp_prod, temp_category);
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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));


                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(12);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));

            // tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            // tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(billarea.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            document.Add(tbltotal);
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


    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check1 = e.Item.Cells[5].Text;
        string area = e.Item.Cells[5].Text;

        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {


                string totalarea = e.Item.Cells[5].Text;
                areasum = Convert.ToDouble(totalarea);
                areanew = areanew + areasum;


            }
        }

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
        string check2 = e.Item.Cells[9].Text;
        string billarea = e.Item.Cells[9].Text;

        if (check2 != "BillableArea")
        {
            if (check2 != "&nbsp;")
            {


                string billarea1 = e.Item.Cells[9].Text;
                billarea2 = Convert.ToDouble(billarea1);
                billablearea = billablearea + billarea2;


            }
        }
   
    }
}
