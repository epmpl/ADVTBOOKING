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
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text;
using System.IO;
using System.Web.UI.WebControls;


public partial class piproductviewpage : System.Web.UI.Page
{
    int sno = 1;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;
    string orderby = "", publication = "", adtype = "", adtypename = "", publname="",adchk="";
    string adtyp = "",agtype="",agtypetext="";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";    
    string date = "";    
    string day = "";
    string month = "";
    string year = "";  
    string pdfName1 = "";    
    string datefrom1 = "";
    string rundate = "";
    string dateto1 = "";
    string region = "";
    string product = "";
    string agency = "";
    string client = "";
    string prod = "";
    string reg = "";
    string uom = "";
    string sortorder = "";
    string sortvalue = "";
    double amt = 0;
    string package = "";
    int i1 = 1;
    int dd1;
    int dd2;
    int helll;
    int sw;
    int i = 0;
    string chkorder = "";
    //int area = 0;
    double area = 0;
    double BillAmt = 0;
    float billarea = 0;
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

        fromdt = Session["fromdate"].ToString();
        dateto = Session["todate"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));



        ds = (DataSet)Session["piproduct"];
        string prm = Session["prm_piproduct"].ToString();
        string[] prm_Array = new string[33];
        prm_Array = prm.Split('~');


        reg = prm_Array[1];// Request.QueryString["regcode"].ToString();
        region = prm_Array[3];//Request.QueryString["region"].ToString();
        fromdt = prm_Array[5];//Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[7]; //Request.QueryString["dateto"].ToString();
        destination = prm_Array[9]; //Request.QueryString["destination"].ToString();
        prod = prm_Array[11]; //Request.QueryString["prodcode"].ToString();
        product = prm_Array[13]; //Request.QueryString["product"].ToString();
        uom = prm_Array[15]; //Request.QueryString["uom"].ToString();
        orderby = prm_Array[17]; //Request.QueryString["orderby"].ToString();
        adtype = prm_Array[19]; //Request.QueryString["adtype"].ToString();
        adtypename = prm_Array[21]; //Request.QueryString["adtypename"].ToString();
        publication = prm_Array[23]; //Request.QueryString["publication"].ToString();
        publname = prm_Array[25]; //Request.QueryString["publname"].ToString();
        adchk = prm_Array[27]; //Request.QueryString["adchk"].ToString();
        agtype = prm_Array[29]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[31]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[33];


            if (orderby == "Product")
            {
                chkorder = "Product";
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
            }
            else if (orderby == "Publication")
            {
                chkorder = "Publication";
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
            }
            else if (orderby == "Region")
            {
                chkorder = "Region";
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
            }
            else if (orderby == "Agency Publication")
            {
                chkorder = "Publication";
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[71].ToString();
            }
            //uom = Request.QueryString["uom"].ToString();

            //lbluom.Text = uom.ToString();
            if (agtype == "0")
            {
                lblagtype.Text = "ALL".ToString();
            }
            else
            {
                lblagtype.Text = agtypetext.ToString();
            }

            if (publication == "0")
            {
                lblpublication.Text = "ALL".ToString();
            }
            else
            {
                lblpublication.Text = publname.ToString();
            }

            if (adtype == "0")
            {
                lbladtype.Text = "ALL".ToString();
            }
            else
            {
                lbladtype.Text = adtypename.ToString();
            }

            if (reg == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = region.ToString();
            }


            if (prod == "")
            {
                lblproduct.Text = "ALL".ToString();
            }
            else
            {
                lblproduct.Text = product.ToString();
            }


         /*   if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
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
          */





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
                    onscreen(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod);
                }
                else if (destination == "4")
                {
                    excel(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod);

                }
                else
                    if (destination == "3")
                    {
                        pdf(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod);
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
    
    
    
    
    private void onscreen( string fromdt, string dateto,  string compcode, string reg, string dateformat, string prod)
    {
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "";
       

        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    SqlDataAdapter da = new SqlDataAdapter();
           
        //    ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //    if(adchk=="1")
        //    ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby,adchk,agtypetext);
        //    else
        //    ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk,agtype);
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        string tbl = "";


        //if (helll > 1)
        //{
        //    for (sw = i; sw > 0; sw--)
        //    {
        //        if ((ds.Tables[0].Rows[i].ItemArray[0].ToString() != ds.Tables[0].Rows[sw - 1].ItemArray[0].ToString()))// && this.ii - dd2 > 1)
        //        {
        //            Session["dd1"] = Convert.ToString(this.sw);
        //            dd2 = Convert.ToInt32(Session["dd1"]);
        //            break;
        //        }
        //    }


        //}

        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
        tbl = tbl + "<tr><td class='middle4' width='4%'align='center'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='8%'>&nbsp;</td><td class='middle4' width='7%'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='5%'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='5%'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='7%'>&nbsp;</td><td class='middle4' width='4%'>&nbsp;</td><td class='middle4' width='7%'>&nbsp;</td><td class='middle4' width='5%'>&nbsp;</td><td class='middle4' width='6%'>&nbsp;</td><td class='middle4' width='7%'>&nbsp;</td></tr>";
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>Hue</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Coloumn</td><td class='middle3'>CardRate</td><td class='middle3'>Package</td><td class='middle3'>Region</td><td class='middle3'>AdCat</td><td class='middle3'>Amt</td><td class='middle3'>Ins.Date</td><td class='middle3'>Area</td><td class='middle3'>Cap</td><td class='middle3'>Key</td></tr>");
        //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3'>CIOID</td><td class='middle3'>Ins.date</td><td class='middle3'>Agency</td><td class='middle3'>Client</td><td class='middle3'>Package</td><td class='middle3'>Depth</td><td class='middle3'>Width</td><td class='middle3'>Area</td><td class='middle3'>RO.No</td><td class='middle3'>RO.Date</td><td class='middle3'>CardRate</td><td class='middle3'>AgreedRate</td><td class='middle3'>AdCatagory</td><td class='middle3'>Amt</td><td class='middle3'>Region</td></tr>");

        if (hiddenascdesc.Value == "")
        {
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Client</td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");
            if (orderby == "Product")
            {
//                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>Product</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>Rate</br>Code</td><td class='middle31'>Clr</td><td class='middle31'>Premium</td><td id='tdadcat~13' class='middle3'   onclick=sorting('Category',this.id)>Catg</br>SubCat<img id='imgadcatdown' src='Images\\down.gif' style='display:block;'><img id='imgadcatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td class='middle31'>Amt</td></tr>");
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' align='left'>Product</td><td class='middle31' align='left'>Booking</br>Id</td><td class='middle31' align='left'>Publish</br>Date</td><td class='middle31' align='left'>Agency</td><td class='middle31' align='left'>Client</td><td class='middle31' align='left' width='5%'>Edition</td><td class='middle31' align='right'>HT</td><td class='middle31' align='right'>WH</td><td class='middle31' align='left'>RO.No</td><td class='middle31' align='left'>RO.Date</td><td class='middle31' align='left'>Rate</br>Code</td><td class='middle31' align='left'>Color</td><td class='middle31' align='right'>Premium</td><td class='middle31' align='left'>Catg</br>SubCat</td><td class='middle31' align='right'>Area</td><td class='middle31' align='right'>Gross</br>Amt</td></tr>");
            }
            if (orderby == "Region")
            {
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' align='left'>Region</td><td class='middle31' align='left'>Booking</br>Id</td><td class='middle31' align='left'>Publish</br>Date</td><td class='middle31' align='left'>Agency</td><td class='middle31' align='left'>Client</td><td class='middle31' align='left' width='5%'>Edition</td><td class='middle31' align='right'>HT</td><td class='middle31' align='right'>WH</td><td class='middle31' align='left'>RO.No</td><td class='middle31' align='left'>RO.Date</td><td class='middle31' align='left'>Rate</br>Code</td><td class='middle31' align='left'>Color</td><td class='middle31' align='right'>Premium</td><td class='middle31' align='left'>Catg</br>SubCat</td><td class='middle31' align='right'>Area</td><td class='middle31' align='right'>Gross</br>Amt</td></tr>");
            }
            if (orderby == "Publication")
            {
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' align='left'>Publication</td><td class='middle31' align='left'>Booking</br>Id</td><td class='middle31' align='left'>Publish</br>Date</td><td class='middle31' align='left'>Agency</td><td class='middle31' align='left'>Client</td><td class='middle31' align='left' width='5%'>Edition</td><td class='middle31' align='right'>HT</td><td class='middle31' align='right'>WH</td><td class='middle31' align='left'>RO.No</td><td class='middle31' align='left'>RO.Date</td><td class='middle31' align='left'>Rate</br>Code</td><td class='middle31' align='left'>Color</td><td class='middle31' align='right'>Premium</td><td class='middle31' align='left'>Catg</br>SubCat</td><td class='middle31' align='right'>Area</td><td class='middle31' align='right'>Gross</br>Amt</td></tr>");
            }
            if (orderby == "Agency Publication")
            {
                tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31' align='left'>Publication</td><td class='middle31' align='left'>Agency</td><td class='middle31' align='left'>Booking</br>Id</td><td class='middle31' align='left'>Publish</br>Date</td><td class='middle31' align='left'>Client</td><td class='middle31' align='left' width='5%'>Edition</td><td class='middle31' align='right'>HT</td><td class='middle31' align='right'>WH</td><td class='middle31' align='left'>RO.No</td><td class='middle31' align='left'>RO.Date</td><td class='middle31' align='left'>Rate</br>Code</td><td class='middle31' align='left'>Color</td><td class='middle31' align='right'>Premium</td><td class='middle31' align='left'>Catg</br>SubCat</td><td class='middle31' align='right'>Area</td><td class='middle31' align='right'>Gross</br>Amt</td></tr>");
            }
        }
        //else if (hiddenascdesc.Value == "asc")
        //{
        //    //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Client</td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:block;'><img id='imgpacup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>CardRate</td><td class='middle31'>AgreedRate</td><td id='tdadcat~13' class='middle3'   onclick=sorting('AdCategory',this.id)>AdCategory<img id='imgadcatdown' src='Images\\down.gif' style='display:block;'><img id='imgadcatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Amt</td><td id='tdreg~15' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:block;'><img id='imgregup' src='Images\\up.gif' style='display:none;'></td></tr>");
        //}
        //else if (hiddenascdesc.Value == "desc")
        //{
        //    //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'  onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>Client</td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>");
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpac~5' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpacdown' src='Images\\down.gif' style='display:none;'><img id='imgpacup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Area</td><td class='middle31'>RO.No</td><td class='middle31'>RO.Date</td><td class='middle31'>CardRate</td><td class='middle31'>AgreedRate</td><td id='tdadcat~13' class='middle3'   onclick=sorting('AdCategory',this.id)>AdCategory<img id='imgadcatdown' src='Images\\down.gif' style='display:none;'><img id='imgadcatup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>Amt</td><td id='tdreg~15' class='middle3'   onclick=sorting('Region',this.id)>Region<img id='imgregdown' src='Images\\down.gif' style='display:none;'><img id='imgregup' src='Images\\up.gif' style='display:block;'></td></tr>");

        //}

        //int area = 0;
        int i1 = 1;
        


        for (i = 0; i <= cont - 1; i++)
       // for (int i = 0; i <= 10; i++)
        {

           // i1 = i1 + 1;
            if (i > 0)//for adcat total
            {
               

                if ((ds.Tables[0].Rows[i][chkorder].ToString() != ds.Tables[0].Rows[i - 1][chkorder].ToString()))//|| (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString()) || (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))
                {
                    tbl = tbl + ("<tr style='height:40px'>");

                    tbl = tbl + ("<td class='rep_data2' style='height:50px'>");
                    tbl = tbl + ("<b>" + "Total" + "</b>" + "</td>");


                    for (int abc = 0; abc <= 13; abc++)
                    {
                        tbl = tbl + ("<td class='rep_data2' style='height:50px'>");
                        tbl = tbl + ("</td>");
                    }

                    //for (int i11 = 13; i11 <= 14; i11++)
                    //{
                        int i11 = 13;
                        arr1[0] = 0;
                        arr1[1] = 0;
                        for (int j11 = dd2; j11 < i1 - 1; j11++)
                        {
                            
                              if (ds.Tables[0].Rows[j11]["Area"].ToString() != "" )
                              {
                                  arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                              }
                           
                            else
                            {
                                arr1[0] = arr1[0] + 0;
                            }

                            if (ds.Tables[0].Rows[j11]["Amt"].ToString() != "")
                            {
                                arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Amt"].ToString());
                            }

                            else
                            {
                                arr1[1] = arr1[1] + 0;
                            }
                        }

                       
                    //Session["dd1"] = Convert.ToString(this.i);
                    //dd2 = Convert.ToInt32(Session["dd1"]);
                    dd2 = Convert.ToInt32(i1 - 1);

                    for (int k11 = 0; k11 <= 1; k11++)
                    {
                        tbl = tbl + "<td  align='right' class='rep_data2'>";
                        tbl = tbl + arr1[k11].ToString();

                        tbl = tbl + "</td>";

                    }


                    tbl = tbl + "</tr>";
                }

            }//for adcat total

            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'  valign='top'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            if (orderby == "Product")
            {
                tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
                if (i == 0)
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["Product"] + "</td>");
                }
                else
                {
                    if (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString())
                    {
                        tbl = tbl + (ds.Tables[0].Rows[i]["Product"] + "</td>");
                    }
                    else
                    {
                        tbl = tbl + ("</td>");
                    }
                }
                                      

            }
            if (orderby == "Region")
            {
                tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
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
            if (orderby == "Publication")
            {
                tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
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
            if (orderby == "Agency Publication")
            {
                tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
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
                tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
                //string agency11 = "";
                //string rrr22 = ds.Tables[0].Rows[i]["Agency"].ToString();
                //char[] agency1 = rrr22.ToCharArray();
                //int len2222 = agency1.Length;
                //int line222 = 0;
                //for (int ch11 = 0; ((ch11 < len2222) && (line222 < 2)); ch11++)
                //{

                //    if (ch11 == 0)
                //    {
                //        agency11 = agency11 + agency1[ch11];
                //    }
                //    else if (ch11 % 15 != 0)
                //    {
                //        agency11= agency11 + agency1[ch11];
                //    }
                //    else
                //    {
                //        line222 = line222 + 1;
                //        if (line222 != 2)
                //        {
                //            agency11 = agency11 + "</br>" + agency1[ch11];
                //        }
                //    }
                //}
                string agency1 = "";
                string chkr = ds.Tables[0].Rows[i]["Agency"].ToString();
                char[] agencyj = chkr.ToCharArray();
                int len111 = agencyj.Length;
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

                    agency1 = agency1 + chkr.Substring(ch1, ch_str1).Trim();
                    agency1 = agency1 + "</br>";
                    ch1 = ch1 + 16;
                    if (ch1 > len111)
                        ch1 = len111;/**/
                }
                tbl = tbl + (agency1 + "</td>");
            }
            tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
           // tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            //string cid = "";
            //string rrr1 = ds.Tables[0].Rows[i]["CIOID"].ToString();
            //char[] cid1 = rrr1.ToCharArray();
            //int len111 = cid1.Length;
            //// int line11 = 0;
            //for (int ch1 = 0; ch1 < len111; ch1++)
            //{

            //    if (ch1 == 0)
            //    {
            //        cid = cid + cid1[ch1];
            //    }
            //    else if (ch1 % 10 != 0)
            //    {
            //        cid = cid + cid1[ch1];
            //    }
            //    else
            //    {

            //        cid = cid + "</br>" + cid1[ch1];

            //    }
            //}
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            char[] cioid = rrr.ToCharArray();
            int len11 = cioid.Length;

            int ch_end = 0;
            int ch_str = 0;
            for (int ch = 0; ch < len11; ch++)
            {
                /**/
                ch_end = ch_end + 10;
                ch_str = ch_end;
                if (ch_end > len11)
                    ch_str = len11 - ch;
                else
                    ch_str = ch_end - ch;

                cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                cioid1 = cioid1 + "</br>";
                ch = ch + 10;
                if (ch > len11)
                    ch = len11;
            }
            tbl = tbl + (cioid1 + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");
            if (orderby != "Agency Publication")
            {
                tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
                // tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");
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
                //    else if (ch1 % 15 != 0)
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
                string agency1 = "";
                string chkr = ds.Tables[0].Rows[i]["Agency"].ToString();
                char[] agencyj = chkr.ToCharArray();
                int len111 = agencyj.Length;
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

                    agency1 = agency1 + chkr.Substring(ch1, ch_str1).Trim();
                    agency1 = agency1 + "</br>";
                    ch1 = ch1 + 16;
                    if (ch1 > len111)
                        ch1 = len111;/**/
                }
                tbl = tbl + (agency1 + "</td>");
            }
            tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
          //  tbl = tbl + (ds.Tables[0].Rows[i]["Client"] + "</td>");
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
            string client1 = "";
            string der = ds.Tables[0].Rows[i]["Client"].ToString();
            char[] clientd = der.ToCharArray();
            int len1111 = clientd.Length;
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

                client1 = client1 + der.Substring(ch11, ch_str11).Trim();
                client1 = client1 + "</br>";
                ch11 = ch11 + 16;
                if (ch11 > len1111)
                    ch11 = len1111;
            }
            tbl = tbl + (client1 + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
           //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='right' valign='top'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Depth"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right' valign='top'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  valign='top' align='left'>");
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");


            tbl = tbl + ("<td class='rep_data' align='left'>");
           //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>"); 
            tbl = tbl + (ds.Tables[0].Rows[i]["Ro.Date"] + "</td>");

            tbl = tbl + ("<td class='rep_data' valign='top' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Rate"] + "</td>");
            tbl = tbl + ("<td class='rep_data' valign='top'  align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Color"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right' valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Premium"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left' valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Category"] + "</br>");
            string df="";
            if (ds.Tables[0].Rows[i]["SubCategory"].ToString() == "0")
            {
                df = "";
                tbl = tbl + (df + "</td>");
            }
            else
            {
                tbl = tbl + (ds.Tables[0].Rows[i]["SubCategory"] + "</td>");
            }

            tbl = tbl + ("<td class='rep_data' align='right' valign='top'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]);

            tbl = tbl + ("<td class='rep_data' align='right' valign='top'>");
           // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Amt"] + "</td>");
            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString ());

            ////tbl = tbl + ("<td class='rep_data'>");
            ////    // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[14].ToString() + "</td>");
            ////tbl = tbl + (ds.Tables[0].Rows[i]["Region"] + "</td>");



            tbl = tbl + "</tr>";

            //    break;
            //}
            //  tbl = tbl + "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";

        }
        //tbl = tbl + ("<tr >");
        //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        //tbl = tbl + ("<tr >");

        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<tr><td class='middle13'>TotalAds.</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ((i1 - 1).ToString() + "</td>");

        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + ("<td class='middle13'><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalArea</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (area.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'>TotalAmt</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (amt.ToString() + "<td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td></td>");
        //tbl = tbl + "</tr>";

        //tbl = tbl + ("</table>");
        //tblgrid.InnerHtml = tbl;

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle1212'>");
        tbl = tbl + ("<tr><td class='middle1212' colspan='13'><b>Total Ads:</b>");//</td>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        //tbl = tbl + ("<td class='middle1212'>&nbsp;</td>");
        //tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
        //tbl = tbl + ("<td class='middle1212'>&nbsp;");
        //tbl = tbl + ("<td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td>");
        tbl = tbl + ("<td class='middle1212'>&nbsp;</td><td class='middle1212'><b>Total</b></td>");
        tbl = tbl + ("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl = tbl + (cal.ToString() + "</td>");
        tbl = tbl + ("<td class='middle1212' align='right'>");
        double cal1 = System.Math.Round(Convert.ToDouble(amt), 2);
        tbl = tbl + (cal1.ToString() + "</td>");
        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;



    }
    



    private void excel(string fromdt, string dateto, string compcode, string reg, string dateformat, string prod)
    {
        
    
            
                string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "";
                //DataSet ds = new DataSet();

                //NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
                //if (adchk == "1")
                //    ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk, agtypetext);
                //else
                //    ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk, agtype);
                int cont = ds.Tables[0].Rows.Count;
             
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
              

                    string ffdd = "",ffddag="";

                    BoundColumn nameColumn0 = new BoundColumn();
                    nameColumn0.HeaderText = "S.No";
                    DataGrid1.Columns.Add(nameColumn0);

                    if (orderby == "Product")
                    {
                        BoundColumn nameColumn = new BoundColumn();
                        nameColumn.HeaderText = "Product";
                        nameColumn.DataField = "Product";
                        name1 = name1 + "," + "Product";
                        name2 = name2 + "," + "Product";
                        name3 = name3 + "," + "G";

                        DataGrid1.Columns.Add(nameColumn);
                    }
                    if (orderby == "Region")
                    {
                        //ffdd = ds.Tables[0].Rows[i]["Region"].ToString();
                        BoundColumn nameColumn = new BoundColumn();
                        nameColumn.HeaderText = "Region";
                        nameColumn.DataField = "Region";

                        name1 = name1 + "," + "Region";
                        name2 = name2 + "," + "Region";
                        name3 = name3 + "," + "G";
                        DataGrid1.Columns.Add(nameColumn);

                    }
                    if (orderby == "Publication")
                    {
                        //ffdd = ds.Tables[0].Rows[i]["Publication"].ToString();
                        BoundColumn nameColumn = new BoundColumn();
                        nameColumn.HeaderText = "Publication";
                        nameColumn.DataField = "Publication";

                        name1 = name1 + "," + "Publicati";
                        name2 = name2 + "," + "Publicatis";
                        name3 = name3 + "," + "G";
                        DataGrid1.Columns.Add(nameColumn);

                    }
                    if (orderby == "Agency Publication")
                    {
                        //ffdd = ds.Tables[0].Rows[i]["Publication"].ToString() ;
                        BoundColumn nameColumn = new BoundColumn();
                        nameColumn.HeaderText = "Publication";
                        nameColumn.DataField = "Publication";

                        name1 = name1 + "," + "Publication";
                        name2 = name2 + "," + "Publication";
                        name3 = name3 + "," + "G";
                        DataGrid1.Columns.Add(nameColumn);


                        //ffddag = ds.Tables[0].Rows[i]["Agency"].ToString();
                        BoundColumn nameColumnag = new BoundColumn();
                        nameColumnag.HeaderText = "Agency";
                        nameColumnag.DataField = "Agency";

                        name1 = name1 + "," + "Agency";
                        name2 = name2 + "," + "Agency";
                        name3 = name3 + "," + "G";
                        DataGrid1.Columns.Add(nameColumnag);

                    }

                   
                      

                    BoundColumn nameColumn1= new BoundColumn();
                    nameColumn1.HeaderText = "Booking Id";
                    nameColumn1.DataField = "CIOID";

                    name1 = name1 + "," + "Booking Id";
                    name2 = name2 + "," + "CIOID";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn1);

                    BoundColumn nameColumn2 = new BoundColumn();
                    nameColumn2.HeaderText = "Publish Date";
                    nameColumn2.DataField = "Ins.date";

                    name1 = name1 + "," + "Publish Date";
                    name2 = name2 + "," + "Ins.dats";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn2);

                    if (orderby != "Agency Publication")
                    {

                         BoundColumn nameColumn3 = new BoundColumn();
                         nameColumn3.HeaderText = "Agency";
                         nameColumn3.DataField = "Agency";

                         name1 = name1 + "," + "Agency";
                         name2 = name2 + "," + "Agency";
                         name3 = name3 + "," + "G";
                         DataGrid1.Columns.Add(nameColumn3);
                    }


                    BoundColumn nameColumn4 = new BoundColumn();
                    nameColumn4.HeaderText = "Client";
                    nameColumn4.DataField = "Client";

                    name1 = name1 + "," + "Client";
                    name2 = name2 + "," + "Client";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn4);



                    //string  ffdd5=ds.Tables[0].Rows[i]["Package"].ToString();
                    BoundColumn nameColumn5 = new BoundColumn();
                    nameColumn5.HeaderText = "Edition";
                    nameColumn5.DataField = "Package";

                    name1 = name1 + "," + "Edition";
                    name2 = name2 + "," + "Package";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn5);


                    //string  ffdd6=ds.Tables[0].Rows[i]["Depth"].ToString();
                    BoundColumn nameColumn6 = new BoundColumn();
                    nameColumn6.HeaderText = "Depth";
                    nameColumn6.DataField = "Depth";

                    name1 = name1 + "," + "Depth";
                    name2 = name2 + "," + "Depth";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn6);


                    //string  ffdd7=ds.Tables[0].Rows[i]["Width"].ToString();
                    BoundColumn nameColumn7 = new BoundColumn();
                    nameColumn7.HeaderText = "Width";
                    nameColumn7.DataField = "Width";

                    name1 = name1 + "," + "Width";
                    name2 = name2 + "," + "Width";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn7);




                    //string  ffdd9=ds.Tables[0].Rows[i]["RoNo."].ToString();
                    BoundColumn nameColumn9 = new BoundColumn();
                    nameColumn9.HeaderText = "RoNo.";
                    nameColumn9.DataField = "RoNo.";

                    name1 = name1 + "," + "RoNo.";
                    name2 = name2 + "," + "RoNo.";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn9);

                    //string  ffdd10=ds.Tables[0].Rows[i]["Ro.Date"].ToString();
                    BoundColumn nameColumn10 = new BoundColumn();
                    nameColumn10.HeaderText = "Ro.Date";
                    nameColumn10.DataField = "Ro.Date";

                    name1 = name1 + "," + "Ro.Date";
                    name2 = name2 + "," + "Ro.Date";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn10);

                    //string ffdd11= ds.Tables[0].Rows[i]["Rate"].ToString();
                    BoundColumn nameColumn11 = new BoundColumn();
                    nameColumn11.HeaderText = "RateCode";
                    nameColumn11.DataField = "Rate";

                    name1 = name1 + "," + "RateCode";
                    name2 = name2 + "," + "RateCode";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn11);

                    //string ffdd12= ds.Tables[0].Rows[i]["Color"].ToString();
                    BoundColumn nameColumn12 = new BoundColumn();
                    nameColumn12.HeaderText = "Color";
                    nameColumn12.DataField = "Color";

                    name1 = name1 + "," + "Color";
                    name2 = name2 + "," + "Color";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn12);

                    //string ffdd13= ds.Tables[0].Rows[i]["Premium"].ToString();
                    BoundColumn nameColumn13 = new BoundColumn();
                    nameColumn13.HeaderText = "Premium";
                    nameColumn13.DataField = "Premium";

                    name1 = name1 + "," + "Premium";
                    name2 = name2 + "," + "Premium";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn13);

                    //string  ffdd14= ds.Tables[0].Rows[i]["Category"].ToString();
                    BoundColumn nameColumn14 = new BoundColumn();
                    nameColumn14.HeaderText = "Category";
                    nameColumn14.DataField = "Category";

                    name1 = name1 + "," + "Category";
                    name2 = name2 + "," + "Category";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn14);

                    //string ffdd15=ds.Tables[0].Rows[i]["SubCategory"].ToString();
                    BoundColumn nameColumn15 = new BoundColumn();
                    nameColumn15.HeaderText = "SubCategory";
                    nameColumn15.DataField = "SubCategory";

                    name1 = name1 + "," + "SubCategory";
                    name2 = name2 + "," + "SubCategory";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn15);

                    //string  ffdd8=ds.Tables[0].Rows[i]["Area"].ToString();
                    BoundColumn nameColumn8 = new BoundColumn();
                    nameColumn8.HeaderText = "Area";
                    nameColumn8.DataField = "Area";
                    //area = area + int.Parse(nameColumn8.DataField);

                    name1 = name1 + "," + "Area";
                    name2 = name2 + "," + "Area";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn8);

                    //string ffdd16= ds.Tables[0].Rows[i]["Amt"].ToString();

                    BoundColumn nameColumn16 = new BoundColumn();
                    nameColumn16.HeaderText = "Gross Amt";
                    nameColumn16.DataField = "Amt";
                    // amt = amt + int.Parse(nameColumn16.DataField);

                    name1 = name1 + "," + "Gross Amt";
                    name2 = name2 + "," + "Amt";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn16);


                    ///////////////////////////////////////////////prachi
                    DataGrid1.DataSource = ds;

                    if (chk_excel == "1")
                    {
                        System.IO.StringWriter sw = new System.IO.StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        DataGrid1.ShowHeader = true;
                        DataGrid1.ShowFooter = true;
                        DataGrid1.DataBind();
                        string headexcel = "";
                        headexcel = "Pi Report " + chkorder + " Wise";

                        hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
                        hw.Write("<p align=\"center\"><b>" +heading.Text+ "</b>");
                            // hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>" + headexcel + "<b>");
                      //  hw.Write("<p <tr><td colspan=\"20\"align=\"center\"><b>" + "Pi Report" + "</b></td></tr>");
                        hw.Write("<p <table><tr><td colspan=\"5\"align=\"left\"><b>" + "From Date:" + lblfrom.Text + "</b></td><td colspan=\"9\"align=\"left\"><b>" + "To Date:" + lblto.Text + "</b></td><td colspan=\"5\"align=\"left\"><b>" + "Run Date:" + rundate + "</b></td></tr>");
                        hw.Write("<p <table><tr><td colspan=\"5\"align=\"left\"><b>" + "Product:" + lblproduct.Text + "</b></td><td colspan=\"9\"align=\"left\"><b>" + "Region:" + lblregion.Text + "</b></td><td colspan=\"5\"align=\"left\"><b>" + "Ad Type:" + lbladtype.Text + "</b></td></tr>");
                        hw.Write("<p <table><tr><td colspan=\"5\"align=\"left\"><b>" + "Publication:" + lblpublication.Text + "</b></td><td colspan=\"5\"align=\"left\"><b>" + "Agency Type:" + lblagtype.Text + "</b></td></tr>");

                        hw.WriteBreak();

                        DataGrid1.RenderControl(hw);

                        int sno11 = cont;

                        Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td align=\"right\" colspan=\"13\">TOTAL Area</td><td align=\"right\" colspan=\"1\" ></td><td align=\"right\" ></td><td>"+ amtnew +"</td><td> " + billablearea + "</td></tr></table>"));

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




    private void pdf(string fromdt, string dateto, string compcode, string reg, string dateformat, string prod)
    {
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "";
       
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
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 17;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //    SqlDataAdapter da = new SqlDataAdapter();

            //    ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            //    if (adchk == "1")
            //        ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk, agtypetext);
            //    else
            //        ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk, agtype);

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
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            if (orderby == "Product")
            {
                chkorder = "Product";
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[17].ToString(), font9));
            }
            else if (orderby == "Publication")
            {
                chkorder = "Publication";
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[19].ToString(), font9));
            }
            else if (orderby == "Region")
            {
                chkorder = "Region";
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[18].ToString(), font9));
            }
            else if (orderby == "Agency Publication")
            {
                chkorder = "Publication";
                tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[71].ToString(), font9));
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
          
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }


           

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
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
            tbl211.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl211.addCell(new Phrase("Product:", font10));
            tbl211.addCell(new Phrase(lblproduct.Text, font11));
            tbl211.addCell(new Phrase("Region:", font10));
            tbl211.addCell(new Phrase(lblregion.Text, font11));
            tbl211.addCell(new Phrase("Adtype", font10));
            tbl211.addCell(new Phrase(lbladtype.Text, font11));
            tbl211.addCell(new Phrase("Publication:", font10));
            tbl211.addCell(new Phrase(lblpublication.Text, font11));
            tbl211.addCell(new Phrase("AgencyType:", font10));
            tbl211.addCell(new Phrase(lblagtype.Text, font11));
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

            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            if (orderby == "Product")
            {
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[58].ToString(), font10));
            }
            if (orderby == "Region")
            {
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));
                
            }
            if (orderby == "Publication")
            {
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            }
            if (orderby == "Agency Publication")
            {
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));

            }
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
            if (orderby != "Agency Publication")
            {
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            }
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[39].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString() + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[74].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[65].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[66].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[65].ToString() + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[66].ToString(), font10));
            

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[83].ToString(), font10));

            datatable.HeaderRows = 1;
            //Phrase p2 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));


            //document.Add(p2);

            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;

            //------------------//-------------------------------------------------------------------       
           

            //---------------------for pagination--------------------------------------------

            //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            int row = 0;
            //int count = 0;
            int i1 = 1;
            int contc = ds.Tables[0].Columns.Count;
            double[] arr1 = new double[contc];
           
            while (row < ds.Tables[0].Rows.Count)
            {
                //----------------------------------------------------------------
                if (row > 0)//for adcat total
                {
                    

                    if ((ds.Tables[0].Rows[row][chkorder].ToString() != ds.Tables[0].Rows[row - 1][chkorder].ToString()))
                    {
                        datatable.addCell(new iTextSharp.text.Phrase("\n\n\n" + "Total", font10));
                        //datatable.addCell(new iTextSharp.text.Phrase( "Total", font10));
                     
                        for (int abc = 0; abc < 14; abc++)
                        {
                            datatable.addCell(new iTextSharp.text.Phrase("", font11));
                        }

                        int i11 = 13;
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

                            if (ds.Tables[0].Rows[j11]["Amt"].ToString() != "")
                            {
                                arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Amt"].ToString());
                            }

                            else
                            {
                                arr1[1] = arr1[1] + 0;
                            }
                        }
                        dd2 = Convert.ToInt32(i1 - 1);
                        for (int k11 = 0; k11 <= 1; k11++)
                        {
                            datatable.addCell(new iTextSharp.text.Phrase("\n\n\n" + arr1[k11].ToString() + "\n\n\n", font11));
                            //datatable.addCell(new iTextSharp.text.Phrase(arr1[k11].ToString(), font11));
                        }  
                    }

                }//for adcat total


                    //----------------------------------------------------------------------

                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    if (orderby == "Product")
                    {
                        if (row == 0)
                        {
                            datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Product"].ToString(), font11));
                       
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[row]["Product"].ToString() != ds.Tables[0].Rows[row - 1]["Product"].ToString())
                            {
                                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Product"].ToString(), font11));
                       
                            }
                            else
                            {
                                datatable.addCell(new Phrase("", font11));
                       
                            }
                        }
                    }
                    if (orderby == "Region")
                    {
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
                    if (orderby == "Publication")
                    {
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
                    if (orderby == "Agency Publication")
                    {
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
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    }
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.Date"].ToString(), font11));
                    if (orderby != "Agency Publication")
                    {
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    }
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                  
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                   
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ro.Date"].ToString(), font11));
                  
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Rate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Premium"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                        area = area + Convert.ToDouble(ds.Tables[0].Rows[row]["Area"].ToString());

                    if (ds.Tables[0].Rows[row]["SubCategory"].ToString() == "0")
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString() + "\n" + "", font11));
                    else
                        datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString() + "\n" + ds.Tables[0].Rows[row]["SubCategory"].ToString(), font11));
               
                   
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());
         
                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(17);
            float[] headerwidths5 = {10,5,5,4,4,4,5,5,5,6,5,5,5,5,10,9,7};//,10,10,9,9,9,9 };//, 10, 1, 10, 10, 10, 16 }; // percentage
            tbltotal.setWidths(headerwidths5);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
           
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString() + ":  " + (i1 - 1).ToString(), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("       Total:", font11));

            tbltotal.addCell(new Phrase(" " + area.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
             
           
            //tbltotal.addCell(new Phrase(" " + area.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase("" + amt.ToString(), font11));
            tbltotal.DefaultCell.Colspan = 17;
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

        Session["prm_piproduct_print"] = "dateto~" + dateto + "~fromdate~" + fromdt + "~destination~" + destination + "~region~" + region + "~regcode~" + reg + "~prodcode~" + prod + "~product~" + product + "~orderby~" + orderby +  "~publication~" + publication + "~adtype~" + adtype + "~publname~" + publname + "~adtypename~" + adtypename + "~adchk~" + adchk + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
        Response.Redirect("printpireport.aspx");
//        Response.Redirect("printpireport.aspx?dateto=" + dateto + "&fromdate=" + fromdt + "&destination=" + destination + "&region=" + region + "&regcode=" + reg + "&prodcode=" + prod + "&product=" + product + "&orderby=" + orderby + "&agtype=" + adtype + "&publication=" + publication + "&adtype=" + adtype + "&publname=" + publname + "&adtypename=" + adtypename + "&adchk=" + adchk + "&agtype1=" + agtype + "&agtypetext=" + agtypetext + " ");

    }
    


    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk="";
        if(chkorder!="Agency Publication")
        cioidchk = e.Item.Cells[2].Text;
        else
        cioidchk = e.Item.Cells[3].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check = e.Item.Cells[16].Text;
        string amt = e.Item.Cells[16].Text;

        if (check != "Area")
        {
            if (check != "&nbsp;")
            {
                string totalarea = e.Item.Cells[16].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;
            }
        }
        string check2 = e.Item.Cells[17].Text;
        string billarean = e.Item.Cells[17].Text;

        if (check2 != "Gross Amt")
        {
            if (check2 != "&nbsp;")
            {
                string billarea1 = e.Item.Cells[17].Text;
                billarea2 = Convert.ToDouble(billarea1);
                billablearea = billablearea + billarea2;
            }
        }
    }

   
}

