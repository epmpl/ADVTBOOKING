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
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text;
using System.IO;

public partial class picontractviewreport : System.Web.UI.Page
{

    int sno = 1;
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    double areasum = 0;

    string dytbl = ""; 
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string agency = "";
    string client = "";
    string package = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string adtypename = "";
    string editionname = "";
    string pdfName1 = "";
    //string date = "";
    string datefrom1 = "";
    string dateto1 = "";
    string region = "";
    string product = "";
    string prod = "";
    string reg = "";
    string uom = "";
    string sortorder = "";
    string sortvalue = "";
    double amt = 0;
    int i1 = 1;
    double area = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[40].ToString();

        
        //uom = Request.QueryString["uom"].ToString();

        // lbluom.Text = uom.ToString();

        if (Request.QueryString["drilout"] == "yes")
        {

            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            //product = Request.QueryString["product"].ToString();
            agency = Request.QueryString["agency"].ToString();
            client = Request.QueryString["client"].ToString();
            package = Request.QueryString["package"].ToString();
            adtyp = Request.QueryString["adtype"].ToString();
            adcat = Request.QueryString["adcategory"].ToString();
            region = Request.QueryString["region"].ToString();
            prod = Request.QueryString["prodcode"].ToString();
            destination = Request.QueryString["destination"].ToString();
            sortorder = Request.QueryString["sortorder"].Trim().ToString();
            sortvalue = Request.QueryString["sortvalue"].Trim().ToString();


            if (destination == "0" || destination == "1")
            {
                drillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }
            else if (destination == "3")
            {
                hiddenascdesc.Value = sortorder;
                hiddencioid.Value = sortvalue;
                pdf_drillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel_drillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString());
            }

        }
        else
        {
            fromdt = Request.QueryString["fromdate"].ToString();
            dateto = Request.QueryString["dateto"].ToString();
            destination = Request.QueryString["destination"].ToString();
            prod = Request.QueryString["prodcode"].ToString();
            product = Request.QueryString["product"].ToString();

            //if (reg == "0")
            //{
            //    lblregion.Text = "ALL".ToString();
            //}
            //else
            //{
            //    lblregion.Text = region.ToString();
            //}


            if (prod == "")
            {
                lblproduct.Text = "ALL".ToString();
            }
            else
            {
                lblproduct.Text = product.ToString();
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
                onscreen(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);
            }
            else if (destination == "4")
            {
                excel(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);
            }


            else
                if (destination == "3")
                {
                    pdf(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);

                }
        }

    }

    private void onscreen(string fromdt, string dateto, string compcode, string dateformat, string prod)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spcontractreportnew(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","","","","","","","","","");
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        
        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdro~28' class='middle3'   onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'   onclick=sorting('Area',this.id)> Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td> <td id='tdadtype~7' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='AdCategory~8' class='middle3'   onclick=sorting('AdCategory',this.id)>Adcat<img id='imgadcatdown' src='Images\\down.gif' style='display:block;'><img id='imgadcatup' src='Images\\up.gif' style='display:none;'></td><td id='tds~41' class='middle3'   onclick=sorting('ContractName',this.id)> ContractName<img id='img41stdown' src='Images\\down.gif' style='display:block;'><img id='img41stup' src='Images\\up.gif' style='display:none;'></td><td id='tds~2' class='middle3'   onclick=sorting('ContractType',this.id)> ContractType<img id='img2stdown' src='Images\\down.gif' style='display:block;'><img id='img2stup' src='Images\\up.gif' style='display:none;'></td><td id='tds~2' class='middle3'   onclick=sorting('ContractRate',this.id)> ContractRate<img id='img2stdown' src='Images\\down.gif' style='display:block;'><img id='img2stup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~19' class='middle3'   onclick=sorting('Amt',this.id)> Amount<img id='img19down' src='Images\\down.gif' style='display:block;'><img id='img19up' src='Images\\up.gif' style='display:none;'></td><td id='tdreg~13' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");

        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdro~28' class='middle3'   onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:block;'><img id='img28up' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td id='tdro~25' class='middle3'   onclick=sorting('Area',this.id)> Area<img id='img25down' src='Images\\down.gif' style='display:block;'><img id='img25up' src='Images\\up.gif' style='display:none;'></td>  <td id='tdadtype~7' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='AdCategory~8' class='middle3'   onclick=sorting('AdCategory',this.id)>Adcat<img id='imgadcatdown' src='Images\\down.gif' style='display:block;'><img id='imgadcatup' src='Images\\up.gif' style='display:none;'></td><td id='tds~41' class='middle3'   onclick=sorting('ContractName',this.id)> ContractName<img id='img41stdown' src='Images\\down.gif' style='display:block;'><img id='img41stup' src='Images\\up.gif' style='display:none;'></td><td id='tds~2' class='middle3'   onclick=sorting('ContractType',this.id)> ContractType<img id='img2stdown' src='Images\\down.gif' style='display:block;'><img id='img2stup' src='Images\\up.gif' style='display:none;'></td><td id='tds~2' class='middle3'   onclick=sorting('ContractRate',this.id)> ContractRate<img id='img2stdown' src='Images\\down.gif' style='display:block;'><img id='img2stup' src='Images\\up.gif' style='display:none;'></td>   <td id='tdro~19' class='middle3'   onclick=sorting('Amt',this.id)> Amount<img id='img19down' src='Images\\down.gif' style='display:block;'><img id='img19up' src='Images\\up.gif' style='display:none;'></td><td id='tdreg~13' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");

        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdro~28' class='middle3'  onclick=sorting('CIOID',this.id)> CIOID<img id='img28down' src='Images\\down.gif' style='display:none;'><img id='img28up' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td id='tdro~25' class='middle3'  onclick=sorting('Area',this.id)> Area<img id='img25down' src='Images\\down.gif' style='display:none;'><img id='img25up' src='Images\\up.gif' style='display:block;'></td>    <td id='tdadtype~7' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='AdCategory~8' class='middle3'   onclick=sorting('AdCategory',this.id)>Adcat<img id='imgadcatdown' src='Images\\down.gif' style='display:none;'><img id='imgadcatup' src='Images\\up.gif' style='display:block;'></td><td id='tds~41' class='middle3'  onclick=sorting('ContractName',this.id)> ContractName<img id='img41stdown' src='Images\\down.gif' style='display:none;'><img id='img41stup' src='Images\\up.gif' style='display:block;'></td><td id='tds~2' class='middle3'  onclick=sorting('ContractType',this.id)> ContractType<img id='img2stdown' src='Images\\down.gif' style='display:none;'><img id='img2stup' src='Images\\up.gif' style='display:block;'></td><td id='tds~2' class='middle3'  onclick=sorting('ContractRate',this.id)> ContractRate<img id='img2stdown' src='Images\\down.gif' style='display:none;'><img id='img2stup' src='Images\\up.gif' style='display:block;'></td> <td id='tdro~19' class='middle3'  onclick=sorting('Amt',this.id)> Amount<img id='img19down' src='Images\\down.gif' style='display:none;'><img id='img19up' src='Images\\up.gif' style='display:block;'></td> <td id='tdreg~13' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:none;'><img id='imgregup' src='Images\\up.gif' style='display:block;'></td></tr>");

        }

        int i1 = 1;
        int area = 0;



        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
             //   area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

            tbl = tbl + ("<td class='rep_data'>"); 
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");

            tbl = tbl + (ds.Tables[0].Rows[i]["AdCategory"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractName"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractType"] + "</td>"); 
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractRate"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");

            




            tbl = tbl + "</tr>";

           

        }

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>Total Ads.</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        
        tbl = tbl + ("<td class='middle13'>");
      //  tbl = tbl + ("<td class='middle13'> </td><td class='middle13'>Total Area</td>");
        tbl = tbl + ("<td class='middle13'> </td><td class='middle13'></td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>Total Amt</td></td>");
      //  tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>Total Amt</td></td>");

        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<tr><td class='middle13'> <td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (area.ToString() + "</td>");

        //tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "</td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;
        /////////////////////////////////////////////////////////////////////////////////////////////////

        double arr1 = amt / area;
        dytbl = dytbl + "<table>";
        dytbl = dytbl + "<tr>";
        dytbl = dytbl + ("<td class='middle13'>");
        dytbl = dytbl + ("<td class='middle13'>");
        dytbl = dytbl + ("<td class='middle13'>");
       // dytbl = dytbl + "<td class='middle13'>Average Rate Realisation </td>";
       // dytbl = dytbl + ("<td class='middle13' > (ARR) : </td>");
        dytbl = dytbl + ("<td class='middle13'>");
       // dytbl = dytbl + (Math.Round(arr1).ToString() + "</td>");
        dytbl = dytbl + ("</tr>");
        dytbl += "</table>";
        dynamictable.Text = dytbl;


        ////////////////////////////////////////////////////////////////////////////////////////////////

        


    }




    private void excel(string fromdt, string dateto, string compcode, string dateformat, string prod)
    {
        
      SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
        ds = obj.spcontractreportnew(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "", "", "", "", "", "", "");


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
        hw.Write("<p align=center> PI Contract Report ");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);
        double arr = comm2 / areanew;
        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"5\">TOTAL</td><td>" + areanew + "</td><td colspan=\"5\">&nbsp;</td><td>" + comm2 + "</td><td></td><tr><td>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));
        Response.Flush();
        Response.End();  
        
        
        
    }
   



    private void pdf(string fromdt, string dateto, string compcode, string dateformat, string prod)
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

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 14;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
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
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[40].ToString(), font9));
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
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            //Phrase p2 = new Phrase(("S.No. CIOID Agency Client Pub Package Depth Width Hue page Ins.No Ins.Date BookDate AdType CardRate AggRate Cap Key"),font10);
            //document.Add(p2);
            //HeaderFooter header = new HeaderFooter(new Phrase(" S.No.      CIOID      Agency     Client          Pub               Package          Depth      Width              Hue                page            Ins.No           Ins.Date             BookDate          AdType      CardRate   AggRate   Cap   Key",font10),false);
            ////HeaderFooter header = new HeaderFooter(new Phrase(Great), false);
            //header.Alignment = Element.ALIGN_CENTER;
            //document.Header = header;




            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 10, 11, 14, 21, 18, 15, 13, 19, 18, 20,16,15,15,13 };
            //, 17, 17, 12, 12, 12, 12 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[45].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[46].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[57].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));

            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[42].ToString(), font10));
            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[43].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            document.Add(p2);



            //------------------//-------------------------------------------------------------------       

            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
           // ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
                ds = obj.spcontractreportnew(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "", "", "", "", "", "", "");
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }
            
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                //----------------------------------------------------------------
                //for (int a = 0; a < 10; ++a)
                //{


                //----------------------------------------------------------------------

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                 //   area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCategory"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractName"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractType"].ToString(), font11));


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[13].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[14].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[17].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));



                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            float[] headerwidths5 = { 5, 6,8,3, 4, 6, 7, 6,8,15,10};//, 12, 10 };//, 10 };//,10,10,9,9,9,9 };//, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
         //   tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(area.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            //tbltotal.addCell(new Phrase(amt.ToString(), font11));

            document.Add(tbltotal);
            //document.Add(datatable);
            //Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            //document.Add(p3);

            //PdfPTable tbltotal = new PdfPTable(4);
            //tbltotal.DefaultCell.BorderWidth = 0;
            //tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));
            //tbltotal.addCell(new Phrase(area.ToString(), font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            //tbltotal.addCell(new Phrase(amt.ToString(), font11));
            //document.Add(tbltotal);
            ////////////////////////////////////////////////////////////////////////////////////////

            Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            document.Add(p4);

            PdfPTable tbltotal1 = new PdfPTable(4);
            float[] headerwidths11 = {3, 3, 20, 70 };
            tbltotal1.setWidths(headerwidths11);
            tbltotal1.DefaultCell.BorderWidth = 0;
            tbltotal1.WidthPercentage = 100;
            tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
           // double arr = amt / area;
            //tbltotal1.addCell(new Phrase("ARR", font10));
           // tbltotal1.addCell(new Phrase(" : ", font10));
           // tbltotal1.addCell(new Phrase(Math.Round(arr).ToString(), font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            document.Add(tbltotal1);

            //////////////////////////////////////////////////////////////////////////////////////
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
        pdf1(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);

        //btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Response.Redirect("<script>window.print();</script>");
    }
    private void pdf1(string fromdt, string dateto, string compcode, string dateformat, string prod)
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
        int count = 0;
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
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 14;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
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
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[40].ToString(), font9));
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
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            //Phrase p2 = new Phrase(("S.No. CIOID Agency Client Pub Package Depth Width Hue page Ins.No Ins.Date BookDate AdType CardRate AggRate Cap Key"),font10);
            //document.Add(p2);
            //HeaderFooter header = new HeaderFooter(new Phrase(" S.No.      CIOID      Agency     Client          Pub               Package          Depth      Width              Hue                page            Ins.No           Ins.Date             BookDate          AdType      CardRate   AggRate   Cap   Key",font10),false);
            ////HeaderFooter header = new HeaderFooter(new Phrase(Great), false);
            //header.Alignment = Element.ALIGN_CENTER;
            //document.Header = header;




            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 10, 11, 14, 21, 18, 15, 13, 19, 18, 20, 16, 15, 15, 13 };
            //, 17, 17, 12, 12, 12, 12 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[45].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[46].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[57].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));

            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[42].ToString(), font10));
            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[43].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            document.Add(p2);



            //------------------//-------------------------------------------------------------------       

            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
               // NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
               // ds = obj.spcontractreport(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", "", "", "", "", "", "", "");
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }
            
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                //----------------------------------------------------------------
                //for (int a = 0; a < 10; ++a)
                //{


                //----------------------------------------------------------------------

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractName"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractType"].ToString(), font11));


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[13].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[14].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[17].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));



                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            float[] headerwidths5 = { 5, 6, 8, 3, 4, 6, 7, 6, 8, 15, 10 };//, 12, 10 };//, 10 };//,10,10,9,9,9,9 };//, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));

            tbltotal.addCell(new Phrase(area.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            //tbltotal.addCell(new Phrase(amt.ToString(), font11));

            document.Add(tbltotal);
           ////////////////////////////////////////////////////////////////////////////////

            Phrase p4 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            document.Add(p4);

            PdfPTable tbltotal1 = new PdfPTable(4);
            float[] headerwidths11 = { 8, 3, 20, 70 }; // percentage
            tbltotal1.setWidths(headerwidths11);
            tbltotal1.DefaultCell.BorderWidth = 0;
            tbltotal1.WidthPercentage = 100;
            tbltotal1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            double arr = amt /  area;
            tbltotal1.addCell(new Phrase(" ARR  ", font10));
            tbltotal1.addCell(new Phrase(" : ", font10));
            tbltotal1.addCell(new Phrase(Math.Round(arr).ToString(), font10));
            tbltotal1.addCell(new Phrase(" ", font10));
            document.Add(tbltotal1);

            //////////////////////////////////////////////////////////////////////////////////////
            document.Close();




            //Response.Redirect( pdfName1);
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

    private void drillout(string fromdt, string dateto, string prod, string agency, string client, string package, string adtyp, string adcat, string region, string compcode, string dateformat)//, string prod
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());//  prod

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());//  prod
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
          //  NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
          //  ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");//  prod
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }
        
        
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>Hue</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Coloumn</td><td class='middle3'>CardRate</td><td class='middle3'>Package</td><td class='middle3'>Region</td><td class='middle3'>AdCat</td><td class='middle3'>Amt</td><td class='middle3'>Ins.Date</td><td class='middle3'>Area</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
        // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Package</td><td class='middle3'>ContractName</td><td class='middle3'>ContractValue</td><td class='middle3'>CardRate</td><td class='middle3'>Amt</td><td class='middle3'>Region</td></tr>");
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Package</td><td class='middle3'>Area</td><td class='middle3'>AdType</td><td class='middle3'>AdCat</td><td class='middle3'>ContractName</td><td class='middle3'>ContractType</td><td class='middle3'>ContractRate</td><td class='middle3'>Amount</td><td class='middle3'>Region</td></tr>");

        if (hiddenascdesc.Value == "")
        {

            tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Area</td><td id='tdadtype~7' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdadcat~8' class='middle3'   onclick=sorting('Adcat',this.id)>Adcat<img id='imgadcatdown' src='Images\\down.gif' style='display:block;'><img id='imgadcatup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>ContractName</td><td class='middle3'>ContractType</td><td class='middle3'>ContractRate</td><td class='middle3'>Amount</td><td id='tdreg~13' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");

        }
        else if (hiddenascdesc.Value == "asc")
        {

            tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Area</td><td id='tdadtype~7' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='tdadcat~8' class='middle3'   onclick=sorting('Adcat',this.id)>Adcat<img id='imgadcatdown' src='Images\\down.gif' style='display:block;'><img id='imgadcatup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>ContractName</td><td class='middle3'>ContractType</td><td class='middle3'>ContractRate</td><td class='middle3'>Amount</td><td id='tdreg~13' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");

        }
        else if (hiddenascdesc.Value == "desc")
        {

            tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Area</td><td id='tdadtype~7' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='tdadcat~8' class='middle3'   onclick=sorting('Adcat',this.id)>Adcat<img id='imgadcatdown' src='Images\\down.gif' style='display:none;'><img id='imgadcatup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>ContractName</td><td class='middle3'>ContractType</td><td class='middle3'>ContractRate</td><td class='middle3'>Amount</td><td id='tdreg~13' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:none;'><img id='imgregup' src='Images\\up.gif' style='display:block;'></td></tr>");


        }

        int i1 = 1;
        int area = 0;



        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");






            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + Convert.ToInt32(ds.Tables[0].Rows[i]["Area"]);

            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[22].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");

            tbl = tbl + (ds.Tables[0].Rows[i]["AdCat"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractName"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractType"] + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[24].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractRate"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

            tbl = tbl + ("<td class='rep_data'>");
            // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");


            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[17].ToString() + "</td>");

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[18].ToString() + "</td>");





            tbl = tbl + "</tr>";

            //    break;
            //}
            //  tbl = tbl + "</tr>";


        }

        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13'>TotalAds:-</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<td class='middle13'>TotalAmt.</td><td class='middle13'></td>");
        //tbl = tbl + (amt.ToString() + "</td>"); 
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + ("<td class='middle13'> </td><td class='middle13'>TotalArea</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td></td>");

        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<tr><td class='middle13'> <td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea:-</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (area.ToString() + "</td>");

        //tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt:-</td>");
        tbl = tbl + ("<td class='middle13'>");
        tbl = tbl + (amt.ToString() + "</td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;

    }
    private void pdf_drillout(string fromdt, string dateto, string prod, string agency, string client, string package, string adtyp, string adcat, string region, string compcode, string dateformat, string descid, string ascdesc)//, string prod
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;


// btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        int count = 0;
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
        //    Console.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
        //}

        //--------------------for   numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 14;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
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
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[40].ToString(), font9));
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
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            //Phrase p2 = new Phrase(("S.No. CIOID Agency Client Pub Package Depth Width Hue page Ins.No Ins.Date BookDate AdType CardRate AggRate Cap Key"),font10);
            //document.Add(p2);
            //HeaderFooter header = new HeaderFooter(new Phrase(" S.No.      CIOID      Agency     Client          Pub               Package          Depth      Width              Hue                page            Ins.No           Ins.Date             BookDate          AdType      CardRate   AggRate   Cap   Key",font10),false);
            ////HeaderFooter header = new HeaderFooter(new Phrase(Great), false);
            //header.Alignment = Element.ALIGN_CENTER;
            //document.Header = header;




            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 10, 11, 14, 21, 18, 15, 13, 19, 18, 20, 16, 15, 15, 13 };
            //, 17, 17, 12, 12, 12, 12 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[13].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[45].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[46].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[57].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));

            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[42].ToString(), font10));
            ////datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[43].ToString(), font10));
            datatable.HeaderRows = 1;
            Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            document.Add(p2);



            //------------------//-------------------------------------------------------------------       

            //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), descid,ascdesc);//  prod

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), descid, ascdesc);//  prod
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
               // NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
               // ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), descid, ascdesc,"","","");//  prod
            }
            else
            {
                //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
                //ds = pub.product(region, Session["compcode"].ToString());
            }
            
            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                //----------------------------------------------------------------
                //for (int a = 0; a < 10; ++a)
                //{


                //----------------------------------------------------------------------

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                    area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractName"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractType"].ToString(), font11));


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ContractRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Region"].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[13].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[14].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[17].ToString(), font11));
                ////datatable.addCell(new Phrase(ds.Tables[0].Rows[row].ItemArray[18].ToString(), font11));



                row++;

            }

            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            float[] headerwidths5 = { 5, 6, 8, 3, 4, 6, 7, 6, 8, 15, 10 };//, 12, 10 };//, 10 };//,10,10,9,9,9,9 };//, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));

            tbltotal.addCell(new Phrase(area.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(amt.ToString(), font11));
            //tbltotal.addCell(new Phrase(amt.ToString(), font11));

            document.Add(tbltotal);
            //document.Add(datatable);
            //Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            //document.Add(p3);

            //PdfPTable tbltotal = new PdfPTable(4);
            //tbltotal.DefaultCell.BorderWidth = 0;
            //tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[13].ToString(), font10));
            //tbltotal.addCell(new Phrase(area.ToString(), font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[14].ToString(), font10));
            //tbltotal.addCell(new Phrase(amt.ToString(), font11));
            //document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }

    }
    private void excel_drillout(string fromdt, string dateto, string prod, string agency, string client, string package, string adtyp, string adcat, string region, string compcode, string dateformat)//, string prod
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());//  prod

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());//  prod
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
           // NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
           // ds = obj.contractdrillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");//  prod
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
        hw.Write("<p align=center> PI Contract Report ");

        hw.WriteBreak();

        DataGrid1.RenderControl(hw);
        double arr = comm2 / areanew;
        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds  " + sno11 + "</td><td align=\"center\" colspan=\"5\">TOTAL</td><td>" + areanew + "</td><td colspan=\"5\">&nbsp;</td><td>" + comm2 + "</td><td></td><tr><td>Average Rate Realisation (ARR)</td><td>" + arr + "</td></tr></table>"));
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
            //oSheet.PageSetup.CenterHeader = "GAURAV";
            //oXL.Visible = true;
            //get our Data     
            // sqlc
            // string strConnect = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
            //SPGen sg = new SPGen(strConnect, spName);
            SqlDataReader myReader1 = null;
            OracleDataReader myReader = null;
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));


            
            //DataSet dst=clsbook.spfun();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
                myReader1 = obj.contract_drillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString());//  prod
                int iRow = 4;  //2

                oSheet.PageSetup.CenterFooter = "&P";

                // while(myReader1.Read())
                // {

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                //heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();

                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[40].ToString();
                for (int j = 0; j < myReader1.FieldCount; j++)
                {

                    //oSheet.Cells[3, j + 1] = myReader1.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[45].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[46].ToString();

                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[57].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[40].ToString();
                    ////oSheet.Cells[3, 15] = myReader1.GetName(14).ToString();
                    ////oSheet.Cells[3, 15] = myReader1.GetName(15).ToString();
                    ////oSheet.Cells[3, 15] = myReader1.GetName(16).ToString();
                    //////oSheet.Cells[3, 14] = myReader1.GetName(13).ToString();
                    //oSheet.Cells[3, 15] = myReader1.GetName(16).ToString();
                    //oSheet.Cells[3, 16] = myReader1.GetName(27).ToString();
                    //oSheet.Cells[3, 17] = myReader1.GetName(18).ToString();
                    //oSheet.Cells[3, 18] = myReader1.GetName(25).ToString();
                    //oSheet.Cells[3, 19] = myReader1.GetName(23).ToString();
                    //oSheet.Cells[3, 20] = myReader1.GetName(24).ToString();
                    //oSheet.DisplayPageBreaks=

                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();
                //oRng.Columns.AutoFit(oSheet, 3);
                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //string total = "";
                //int tot = 0;
                //int finaltotal = 0;
                int i1 = 1;
                while (myReader1.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader1.FieldCount; k++)
                    {


                        oSheet.Cells[iRow, 2] = myReader1["CIOID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader1["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader1["Agency"].ToString();
                        oSheet.Cells[iRow, 5] = myReader1["Client"].ToString();
                        oSheet.Cells[iRow, 6] = myReader1["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader1["Area"].ToString();
                        oSheet.Cells[iRow, 8] = myReader1["AdType"].ToString();
                        oSheet.Cells[iRow, 9] = myReader1["AdCat"].ToString();
                        oSheet.Cells[iRow, 10] = myReader1["ContractName"].ToString();
                        oSheet.Cells[iRow, 11] = myReader1["ContractType"].ToString();

                        oSheet.Cells[iRow, 12] = myReader1["ContractRate"].ToString();

                        oSheet.Cells[iRow, 13] = myReader1["Amt"].ToString();
                        oSheet.Cells[iRow, 14] = myReader1["Region"].ToString();


                        //oSheet.PageSetup.CenterHeader = oRng.ToString();
                        //oXL.Visible = true;
                        // mnWidth = 6;

                    }

                    if (myReader1["Area"].ToString() != "")
                        area = area + Convert.ToInt32(myReader1["Area"].ToString());

                    if (myReader1["Amt"].ToString() != "")
                        amt = amt + double.Parse(myReader1["Amt"].ToString());

                    iRow++;



                }

                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 6] = "Totals Area:".ToString();
                oSheet.Cells[iRow + 1, 7] = area.ToString();
                oSheet.Cells[iRow + 1, 12] = "Totals Amt:".ToString();
                oSheet.Cells[iRow + 1, 13] = amt.ToString();

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
                NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
                myReader = obj.contract_drillout(fromdt, dateto, prod, agency, client, package, adtyp, adcat, region, Session["compcode"].ToString(), Session["dateformat"].ToString(),"","","","","");//  prod
                int iRow = 4;  //2

                oSheet.PageSetup.CenterFooter = "&P";

                // while(myReader.Read())
                // {

                DataSet ds1 = new DataSet();
                ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
                //heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();

                oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[40].ToString();
                for (int j = 0; j < myReader.FieldCount; j++)
                {

                    //oSheet.Cells[3, j + 1] = myReader.GetName(j).ToString();
                    oSheet.Cells[3, 1] = pdfxml.Tables[0].Rows[0].ItemArray[0].ToString();
                    oSheet.Cells[3, 2] = pdfxml.Tables[0].Rows[0].ItemArray[1].ToString();
                    oSheet.Cells[3, 3] = pdfxml.Tables[0].Rows[0].ItemArray[13].ToString();
                    oSheet.Cells[3, 4] = pdfxml.Tables[0].Rows[0].ItemArray[2].ToString();
                    oSheet.Cells[3, 5] = pdfxml.Tables[0].Rows[0].ItemArray[3].ToString();
                    oSheet.Cells[3, 6] = pdfxml.Tables[0].Rows[0].ItemArray[6].ToString();
                    oSheet.Cells[3, 7] = pdfxml.Tables[0].Rows[0].ItemArray[9].ToString();
                    oSheet.Cells[3, 8] = pdfxml.Tables[0].Rows[0].ItemArray[17].ToString();
                    oSheet.Cells[3, 9] = pdfxml.Tables[0].Rows[0].ItemArray[18].ToString();
                    oSheet.Cells[3, 10] = pdfxml.Tables[0].Rows[0].ItemArray[45].ToString();
                    oSheet.Cells[3, 11] = pdfxml.Tables[0].Rows[0].ItemArray[46].ToString();

                    oSheet.Cells[3, 12] = pdfxml.Tables[0].Rows[0].ItemArray[57].ToString();
                    oSheet.Cells[3, 13] = pdfxml.Tables[0].Rows[0].ItemArray[33].ToString();
                    oSheet.Cells[3, 14] = pdfxml.Tables[0].Rows[0].ItemArray[40].ToString();
                    ////oSheet.Cells[3, 15] = myReader.GetName(14).ToString();
                    ////oSheet.Cells[3, 15] = myReader.GetName(15).ToString();
                    ////oSheet.Cells[3, 15] = myReader.GetName(16).ToString();
                    //////oSheet.Cells[3, 14] = myReader.GetName(13).ToString();
                    //oSheet.Cells[3, 15] = myReader.GetName(16).ToString();
                    //oSheet.Cells[3, 16] = myReader.GetName(27).ToString();
                    //oSheet.Cells[3, 17] = myReader.GetName(18).ToString();
                    //oSheet.Cells[3, 18] = myReader.GetName(25).ToString();
                    //oSheet.Cells[3, 19] = myReader.GetName(23).ToString();
                    //oSheet.Cells[3, 20] = myReader.GetName(24).ToString();
                    //oSheet.DisplayPageBreaks=

                }
                //   }
                oSheet.Cells.Font.Name = "verdana";
                oSheet.Cells.Font.Size = 7;

                oRng = oSheet.get_Range("A3", "Y3");
                oRng.EntireColumn.AutoFit();
                //oRng.Columns.AutoFit(oSheet, 3);
                //oRng.EntireColumn.Font.Size = 10;

                //				oRng.Column=1;
                //				oRng.EntireColumn.Width=0;
                //string total = "";
                //int tot = 0;
                //int finaltotal = 0;
                int i1 = 1;
                while (myReader.Read())
                {
                    oSheet.Cells[iRow, 1] = i1++.ToString();
                    for (int k = 0; k < myReader.FieldCount; k++)
                    {


                        oSheet.Cells[iRow, 2] = myReader["CIOID"].ToString();
                        oSheet.Cells[iRow, 3] = myReader["Ins.date"].ToString();
                        oSheet.Cells[iRow, 4] = myReader["Agency"].ToString();
                        oSheet.Cells[iRow, 5] = myReader["Client"].ToString();
                        oSheet.Cells[iRow, 6] = myReader["Package"].ToString();
                        oSheet.Cells[iRow, 7] = myReader["Area"].ToString();
                        oSheet.Cells[iRow, 8] = myReader["AdType"].ToString();
                        oSheet.Cells[iRow, 9] = myReader["AdCat"].ToString();
                        oSheet.Cells[iRow, 10] = myReader["ContractName"].ToString();
                        oSheet.Cells[iRow, 11] = myReader["ContractType"].ToString();

                        oSheet.Cells[iRow, 12] = myReader["ContractRate"].ToString();

                        oSheet.Cells[iRow, 13] = myReader["Amt"].ToString();
                        oSheet.Cells[iRow, 14] = myReader["Region"].ToString();


                        //oSheet.PageSetup.CenterHeader = oRng.ToString();
                        //oXL.Visible = true;
                        // mnWidth = 6;

                    }

                    if (myReader["Area"].ToString() != "")
                        area = area + Convert.ToInt32(myReader["Area"].ToString());

                    if (myReader["Amt"].ToString() != "")
                        amt = amt + double.Parse(myReader["Amt"].ToString());

                    iRow++;



                }

                oSheet.Cells[iRow + 1, 3] = "TotalAds :".ToString();
                oSheet.Cells[iRow + 1, 4] = (i1 - 1).ToString();
                oSheet.Cells[iRow + 1, 6] = "Totals Area:".ToString();
                oSheet.Cells[iRow + 1, 7] = area.ToString();
                oSheet.Cells[iRow + 1, 12] = "Totals Amt:".ToString();
                oSheet.Cells[iRow + 1, 13] = amt.ToString();

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
            
            
            
            oSheet.get_Range("A1", "AA1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A1", "R1").MergeCells = true;
            oSheet.get_Range("A1", "R1").Font.Bold = true;
            oSheet.get_Range("A1", "R1").Font.Size = 10;
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
            string strMachineName = Request.ServerVariables["SERVER_NAME"];


        }
        catch (Exception theException)
        {
            String errorMessage;
            errorMessage = "Error: ";
            errorMessage = String.Concat(errorMessage, theException.Message);
            errorMessage = String.Concat(errorMessage, " Line: ");
            errorMessage = String.Concat(errorMessage, theException.Source);
        }
        finally
        {
            Response.Redirect("picontractreport.aspx");
        }
    }*/

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check1 = e.Item.Cells[6].Text;
        string area = e.Item.Cells[6].Text;

        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {


                string totalarea = e.Item.Cells[6].Text;
                areasum = Convert.ToDouble(totalarea);
                areanew = areanew + areasum;


            }
        }

        string check = e.Item.Cells[12].Text;
        string amt = e.Item.Cells[12].Text;

        if (check != "Amt")
        {
            if (check != "&nbsp;")
            {


                string grossamt = e.Item.Cells[12].Text;
                comm1 = Convert.ToDouble(grossamt);
                comm2 = comm2 + comm1;

            }
        }
    }
}





