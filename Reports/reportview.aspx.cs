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
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
public partial class Reportview : System.Web.UI.Page
{
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
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string adtypename = "";
    string editionname = "";
    string pdfName1 = "";
    string datefrom1 = "";
    string dateto1 = "";
    string package = "";
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    string docketbooking = "";
    string searcre = "";
    string extra1 = "";
    int i1 = 1;
    double amt = 0;
    string client = "";
    string agency = "";

    string sortorder = "";
    string sortvalue = "";
    string dytbl = "";

    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;

    string adsubcat = "", agtype = "", agtypetext = "";
    string adsubcatname = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "", branch_name = "", print_cent="";
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
        ds = (DataSet)Session["allads"];
        string prm = Session["parameter"].ToString();
        string[] prm_Array = new string[41];
        prm_Array = prm.Split('~');

       
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        fromdt = Session["fromdate"].ToString();
        dateto = Session["dateto"].ToString();


        adtyp = prm_Array[1];// Request.QueryString["adtype"].ToString();
        adcat = prm_Array[3]; //Request.QueryString["adcategory"].ToString();
        adsubcat = prm_Array[5]; //Request.QueryString["adsubcat"].ToString();
        fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        edition = prm_Array[15]; //Request.QueryString["edition"].ToString();
        pubcname = prm_Array[17]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[19]; //Request.QueryString["publiccent"].ToString();
        destination = prm_Array[21]; //Request.QueryString["destination"].ToString();
        adcatname = prm_Array[23]; //Request.QueryString["adcatname"].ToString();
        adtypename = prm_Array[25]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[27]; //Request.QueryString["editionname"].ToString();
        adsubcatname = prm_Array[29]; //Request.QueryString["adsubcatname"].ToString();
        agtype = prm_Array[31]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[33]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[35];
        branch_name = prm_Array[37];
        print_cent = prm_Array[39];
        docketbooking = prm_Array[41];
        searcre = prm_Array[43];
        extra1 = prm_Array[44];
      
            Ajax.Utility.RegisterTypeForAjax(typeof(Reportview));
            hiddendatefrom.Value = fromdt.ToString();

            adcatname = adcatname.Replace("'", "");
            adsubcatname = adsubcatname.Replace("'", "");


            if (agtype == "0")
                lblagtype.Text = "ALL".ToString();
            else
                lblagtype.Text = agtypetext.ToString();

            if (adtyp == "0")
                lbladtype.Text = "ALL".ToString();
            else
                lbladtype.Text = adtypename.ToString();

            if ((adcat == "0") || (adcat == ""))
                lbladcatg.Text = "ALL".ToString();
            else
                lbladcatg.Text = adcatname.ToString();

            if ((adsubcatname == "0") || (adsubcatname == ""))
                lbladsubcat.Text = "ALL".ToString();
            else
                lbladsubcat.Text = adsubcatname.ToString();
       

            if (publ == "0")
                lblpub.Text = "ALL".ToString();
            else
                lblpub.Text = pubcname.ToString();
            if (pubcen == "0")
                pcenter.Text = "ALL".ToString();
            else
                pcenter.Text = pub2.ToString();

            if (edition == "0" || edition=="")
                lbedition.Text = "ALL".ToString();
            else
                lbedition.Text = editionname.ToString();


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

    


            //datefrom1 = "";
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
            if (!Page.IsPostBack)
            {
                if (destination == "1" || destination == "0")
                {
                    onscreen(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), docketbooking, searcre, extra1);
                }
                else if (destination == "4")
                {

                    if (chk_excel == "1")
                    {
                        excel(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), docketbooking, searcre, extra1);
                    }
                    else
                    {
                        excel_csv(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
                    }

                }
                else if (destination == "3")
                {
                    pdf(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), docketbooking, searcre, extra1);
                }
            }
       
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





    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }




    private void onscreen(string adtyp, string adcat, string adsubcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string docketbooking, string searcre, string extra1)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext, Session["userid"].ToString());

        //}
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
       // string tbl = "";
        StringBuilder tbl = new StringBuilder();
        //StringBuilder tbl = new StringBuilder();
        tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>");

        //tbl.Append("<tr><td  class='middle31new' width='1%' >S.</br>No</td><td class='middle31new' width='3%' align='left'>Booking</br>&nbsp;&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>Edition</td><td class='middle31new' width='3%' align='left'>Publish</br>Date</td><td class='middle31new' width='9%' align='left'>Agency</td><td class='middle31new' width='9%' align='left'>Client</td><td class='middle31new' width='7%' align='left'>Package</td><td class='middle31new' width='2%' align='right'>HT</td><td class='middle31new' width='2%' align='right'>WD</td><td class='middle31new' width='3%' align='right'>Area</td><td class='middle31new' width='1%' align='left'>Color</td><td class='middle31new' width='4%' align='left'>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='7%' align='left'>Ro No.</br>Status</td><td class='middle31new' width='4%' align='left'>Executive </td><td class='middle31new' width='4%' align='left'>Ro </br>Status</td> <td class='middle31new' width='3%' align='left'>AdCat</td><td class='middle31new' width='4%' align='right'>Card</br>Rate</td><td class='middle31new' width='4%' align='right'>Agg</br>Rate</td><td class='middle31new' width='4%' align='right'>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</td><td class='middle31new' width='2%' colspan='2' align='left'>Caption</br>Key No.</td></tr>");
        tbl.Append("<tr><td  class='middle31new' width='1%' >S.</br>No</td><td class='middle31new' width='3%' align='left'>Booking</br>&nbsp;&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>Edition</td><td class='middle31new' width='3%' align='left'>Publish</br>Date</td><td class='middle31new' width='9%' align='left'>Agency</td><td class='middle31new' width='9%' align='left'>Client</td><td class='middle31new' width='7%' align='left'>Package</td><td class='middle31new' width='2%' align='center'>WD</td><td class='middle31new' width='2%' align='right'>HT</td><td class='middle31new' width='3%' align='right'>Area</td><td class='middle31new' width='1%' align='left'>Color</td><td class='middle31new' width='4%' align='left'>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>No&nbsp;&nbsp;</td><td class='middle31new' width='7%' align='left'>Ro No.</br>Status</td><td class='middle31new' width='4%' align='left'>Executive </td><td class='middle31new' width='4%' align='left'>Ro </br>Status</td> <td class='middle31new' width='3%' align='left'>AdCat</td><td class='middle31new' width='4%' align='right'>Card</br>Rate</td><td class='middle31new' width='4%' align='right'>Agg</br>Rate</td><td class='middle31new' width='4%' align='right'>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</td><td class='middle31new' width='2%' colspan='2' align='left'>Caption</br>Key No.</td></tr>");

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr>");


            tbl.Append("<td class='rep_data'>" + i1++.ToString() + "</td>");
           
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            if (rrr.Length >= 10)
            {
                cioid1 = rrr.Substring(0, 10);
                if (rrr.Length - 10 < 10)
                    cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                else
                    cioid1 += "</br>" + rrr.Substring(10, 10);
            }
            else
                cioid1 = rrr;



            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + cioid1 + "</td>");
           
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["edition"] + "</td>");
          

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");
           

            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            if (rrr1.Length >= 16)
            {
                agency1 = rrr1.Substring(0, 16);
                if (rrr1.Length - 16 < 16)
                    agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                else
                    agency1 += "</br>" + rrr1.Substring(16, 16);
            }
            else
                agency1 = rrr1;




            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + agency1 + "</td>");
            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
            if (rrr2.Length >= 16)
            {
                client1 = rrr2.Substring(0, 16);
                if (rrr2.Length - 16 < 16)
                    client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                else
                    client1 += "</br>" + rrr2.Substring(16, 16);
            }
            else
                client1 = rrr2;




            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + client1 + "</td>");
          

            string Package1 = "";
            string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
            if (rrr3.Length >= 9)
            {
                Package1 = rrr3.Substring(0, 9);
                if (rrr3.Length - 9 < 9)
                    Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                else
                    Package1 += "</br>" + rrr3.Substring(9, 9);
            }
            else
                Package1 = rrr3;

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + Package1 + "</td>");

            if ((ds.Tables[0].Rows[i]["Width"]).ToString() == "")
            {

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='center'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='center'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Width"]).ToString() + "</td>");


            }
      
            if ((ds.Tables[0].Rows[i]["Depth"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='center' align='right'>&nbsp;</td>");
              
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='center' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Depth"]).ToString() + "</td>");

               

            }
         

         

            if ((ds.Tables[0].Rows[i]["Area"]).ToString() == "")
            {
               
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
            }
            else
            {              
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>"+Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2")+"</td>");
                if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());



            }

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["Color_code"] + "</td>");
            

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Page"] + "</td>");
          

            if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
            {
              tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >" + ds.Tables[0].Rows[i]["PagePremium"] + "</td>");

               
            }




            
            if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
            {
              
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
            }
            else
            {
              
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>"+ds.Tables[0].Rows[i]["PositionPremium"]+"</td>");
            }
                        
            if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
            {
             
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                
            }


           // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["RoNo."] + "</br>" + ds.Tables[0].Rows[i]["ADSTATUS"] + "</td>");
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["RoNo."] + "</td>");
          

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["DOCKIT_NO"] + "</td>");
           

            string RoStatus1 = "";
            string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
            if (rrr4.Length >= 9)
            {
                RoStatus1 = rrr4.Substring(0, 9);
                if (rrr4.Length - 9 < 9)
                    RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                else
                    RoStatus1 += "</br>" + rrr4.Substring(9, 9);
            }
            else
                RoStatus1 = rrr4;



            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + RoStatus1 + "</td>");
           


            string AdCat1 = "";
            string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
            if (rrr5.Length >= 9)
            {
                AdCat1 = rrr5.Substring(0, 9);
                if (rrr5.Length - 9 < 9)
                    AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                else
                    AdCat1 += "</br>" + rrr5.Substring(9, 9);
            }
            else
                AdCat1 = rrr5;



            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + AdCat1 + "</td>");
                     

            if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
            {
             
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>"+Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2")+"</td>");
              
            }
           
            if ((ds.Tables[0].Rows[i]["AgreedRate"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>"+Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2")+"</td>");
               

            }
            ///////cash disc
          

            if ((ds.Tables[0].Rows[i]["Cash_Disc"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
              
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Cash_Disc"]).ToString("F2") + "</td>");
                
            }

            ////////cash disc
            

            if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
            {
              
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                
            }

            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

            
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Cap"] + "</br>" + ds.Tables[0].Rows[i]["Key"] + "</td>");

            tbl.Append("</tr>");

            tblgrid.InnerHtml = tbl.ToString();   
            

        }
        
       
        tbl.Append("<tr >");

        tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle13new' colspan='3'>&nbsp;</td>");

        ////////////////////////////////////////

        
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl.Append("<td class='middle1212' colspan='4' align='right'><b>Total Area: " + chk_null(cal.ToString()) + "</b></td>");
        
        if (totrol > 0)
        {
            
             double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
             tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Lines: "+calf.ToString()+"</b></td>");
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }
        if (totcd > 0)
        {
           
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Chars:</b> " + calfd.ToString() + "</td>");
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }
        if (totcc > 0)
        {
          
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
          
            tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>" + calft.ToString() + "</td>");

        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }


        ///////////////////////////////////

        tbl.Append("<td class='middle1212' colspan='5'>&nbsp;</td>");
        tbl.Append("<td  class='middle13new'  align='right' style='font-size: 13px;'><b>BillAmt:</b></td>");
        tbl.Append("<td class='middle13new' colspan='2' style='font-size: 13px;'>"+ chk_null(amt.ToString())+"</td>");
     


        tbl.Append("</tr>");
      
        tbl.Append("</table>");
       
        tblgrid.InnerHtml = tbl.ToString();
        
    }

    private void pdf(string adtyp, string adcat, string adsubcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string docketbooking, string searcre, string extra1)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



      

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        //PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        //int i2=0;
      
        //--------------------for page numbering---------------------------------------------

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i4 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i4++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();

        ////HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        ////HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
        //footer.Border = Rectangle.NO_BORDER;
        //footer.Alignment = Element.ALIGN_CENTER;
        //document.Footer = footer;
        
        //document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 24;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {

            SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext);
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext, Session["userid"].ToString());

            //}
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
           
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
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

            PdfPTable tbl2 = new PdfPTable(8);
            tbl2.DefaultCell.BorderWidth = 0;
          // tbltotal.DefaultCell.Colspan = 1;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));


            tbl2.addCell(new Phrase("Publication:", font10));
            tbl2.addCell(new Phrase(lblpub.Text, font10));
            tbl2.addCell(new Phrase("Pub Center:", font10));
            tbl2.addCell(new Phrase(pcenter.Text, font10));
            tbl2.addCell(new Phrase("Edition:", font10));
             tbl2.addCell(new Phrase(lbedition.Text,font10));
            tbl2.addCell(new Phrase("Agency Type:", font10));
            tbl2.addCell(new Phrase(lblagtype.Text, font10));

           


            tbl2.addCell(new Phrase("AD Type:", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font10));
            tbl2.addCell(new Phrase("AD Category:", font10));
            tbl2.addCell(new Phrase(lbladcatg.Text, font10));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("", font11));
            tbl2.addCell(new Phrase("AD Subcat:", font10));
            tbl2.addCell(new Phrase(lbladsubcat.Text, font10));
            

            tbl2.WidthPercentage = 100;
            document.Add(tbl2);
            

            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            float[] headerwidthse = { 10,8,8,8,8,8,5,5,5,8,5,5,5,5,5,5,8,8,5,5,5,8,5,5 }; // percentage
            datatable.setWidths(headerwidthse);
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.Colspan = 24;
            datatable.addCell(new iTextSharp.text.Phrase("___________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
                      
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[7].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[8].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[87].ToString(), font10));
            datatable.addCell(new Phrase("Page Prem", font10));
            datatable.addCell(new Phrase("Post Prem", font10));
            datatable.addCell(new Phrase("Eye Catcher", font10));
            datatable.addCell(new Phrase("Ro No.", font10));
            datatable.addCell(new Phrase("Ro Status", font10));



            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase("Cash Disc", font10));
           
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable.addCell(new Phrase("BillAmt", font10));  
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));
            datatable.HeaderRows = 1;

            //Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            //document.Add(p2);

            datatable.DefaultCell.Colspan = 24;
            datatable.addCell(new iTextSharp.text.Phrase("__________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.HeaderRows = 1;
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                    datatable.addCell(new Phrase(i1++.ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                    
                  
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Depth"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));

                   // area = area + Convert.ToInt32(ds.Tables[0].Rows[row]["Area"].ToString());


                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color_code"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremium"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PositionPremium"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BulletPremium"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));

                    if ((ds.Tables[0].Rows[row]["Area"]).ToString() != "")
                    {

                        if (ds.Tables[0].Rows[row]["uom"].ToString() == "CD" || ds.Tables[0].Rows[row]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                        else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());

                       
                    }
     


                 //   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.No."].ToString(), font11));
                  
               //     datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                    

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cash_Disc"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Amt"].ToString(), font11));
                    if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                    

                row++;

            }



            document.Add(datatable);
            //Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));


            //document.Add(p3);



            PdfPTable tbltotal = new PdfPTable(NumColumns);
           
            //float[] headerwidths = { 3,20, 8, 10, 10, 10, 10, 1, 7, 8, 8, 10, 10, 8, 4, 4, 4, 8, 10 }; // percentage
            //tbltotal.setWidths(headerwidths);
          //  float[] headerwidthse = { 10, 8, 8, 8, 8, 8, 5, 5, 5, 8, 5, 5, 5, 5, 5, 5, 8, 8, 5, 5, 5, 8, 5, 5 }; // percentage
            tbltotal.setWidths(headerwidthse);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.Colspan = NumColumns;
            tbltotal.addCell(new iTextSharp.text.Phrase("_________________________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;

            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase("Total:", font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            //tbltotal.addCell(new Phrase((i1-1).ToString(), font11));
           // tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            
            tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));
           // tbltotal.addCell(new Phrase(" ", font11));
           
            tbltotal.addCell(new Phrase("Area:", font10));
            tbltotal.addCell(new Phrase(" ", font11));
           
            tbltotal.addCell(new Phrase(area.ToString(), font11));


            if (totrol > 0)
            {
                tbltotal.addCell(new Phrase("Lines:", font11));
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.addCell(new Phrase(calf.ToString(), font11));


            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcd > 0)
            {
                tbltotal.addCell(new Phrase("Chars:", font11));
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.addCell(new Phrase(calfd.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcc > 0)
            {

                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbltotal.addCell(new Phrase("Words:", font11));
                tbltotal.addCell(new Phrase(calft.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase("BillAmt:", font11));

            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase(amt.ToString(), font11));

            
            tbltotal.addCell(new Phrase(" ", font11));
            

            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.Colspan = NumColumns;
            tbltotal.addCell(new iTextSharp.text.Phrase("__________________________________________________________________________________________________________________________________________________________", font10));
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

    private iTextSharp.text.Image TextWriter(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["parameter_print"] = "adtype~" + adtyp + "~adcategory~" + adcat + "~adsubcat~" + adsubcat + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + publ + "~pubcenter~" + pubcen + "~edition~" + edition + "~publicname~" + pubcname + "~publiccent~" + pub2 + "~adcatname~" + adcatname + "~adtypename~" + adtypename + "~editionname~" + editionname + "~adsubcatname~" + adsubcatname + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
            Response.Redirect("reportnewprint.aspx"); 
        //Response.Redirect("reportnewprint.aspx?adtype=" + adtyp + "&adcategory=" + adcat + "&adsubcat=" + adsubcat + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + publ + "&pubcenter=" + pubcen + "&edition=" + edition + "&publicname=" + pubcname + "&publiccent=" + pub2 + "&adcatname=" + adcatname + "&adtypename=" + adtypename + "&editionname=" + editionname + "&adsubcatname=" + adsubcatname+"&agtype1=" + agtype + "&agtypetext=" + agtypetext ); 
   
    
    }

    private void excel(string adtyp, string adcat, string adsubcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string docketbooking, string searcre, string extra1)
    {
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

       // DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), "", "", "", "", "", "", agtypetext, Session["userid"].ToString(), Session["access"].ToString(), branch_name, print_cent, docketbooking, searcre, extra1);
        //}

        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{


        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {
        //        fromdt = DMYToMDY(fromdt);
        //        dateto = DMYToMDY(dateto);
        //    }


        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {
        //        fromdt = YMDToMDY(fromdt);
        //        dateto = YMDToMDY(dateto);
        //    }
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), "", "", "", "", "", "", agtypetext, Session["userid"].ToString(), Session["access"].ToString(), branch_name, print_cent, docketbooking, searcre, extra1);

        //}


        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
       // string tbl = "";
        StringBuilder tbl = new StringBuilder();
        tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='1'>");

        //tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='3%' align='left'><b>Edition</b></td><td class='middle31new' width='3%' align='left'><b>Publish</br>Date</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td></b></tr>");
        tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='3%' align='left'><b>Edition</b></td><td class='middle31new' width='3%' align='left'><b>Publish</br>Date</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>No&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='3%' align='left'><b>Sub AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td></b></tr>");

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr>");


            tbl.Append("<td class='rep_data'>" + i1++.ToString() + "</td>");
            

            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            if (rrr.Length >= 10)
            {
                cioid1 = rrr.Substring(0, 10);
                if (rrr.Length - 10 < 10)
                    cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                else
                    cioid1 += "</br>" + rrr.Substring(10, 10);
            }
            else
                cioid1 = rrr;



            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + cioid1 + "</td>");
            //tbl = tbl + (cioid1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["edition"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");


            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;
                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();

                date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

            }
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");


            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            if (rrr1.Length >= 16)
            {
                agency1 = rrr1.Substring(0, 16);
                if (rrr1.Length - 16 < 16)
                    agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                else
                    agency1 += "</br>" + rrr1.Substring(16, 16);
            }
            else
                agency1 = rrr1;

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + agency1 + "</td>");
            //tbl = tbl + (agency1 + "</td>");

            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
            if (rrr2.Length >= 16)
            {
                client1 = rrr2.Substring(0, 16);
                if (rrr2.Length - 16 < 16)
                    client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                else
                    client1 += "</br>" + rrr2.Substring(16, 16);
            }
            else
                client1 = rrr2;

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + client1 + "</td>");
            //tbl = tbl + (client1 + "</td>");

            string Package1 = "";
            string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
            if (rrr3.Length >= 9)
            {
                Package1 = rrr3.Substring(0, 9);
                if (rrr3.Length - 9 < 9)
                    Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                else
                    Package1 += "</br>" + rrr3.Substring(9, 9);
            }
            else
                Package1 = rrr3;

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + Package1 + "</td>");
            //tbl = tbl + (Package1 + "</td>");

            if ((ds.Tables[0].Rows[i]["Width"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");

            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Width"]).ToString("F2") + "</td>");
            }
            
            if ((ds.Tables[0].Rows[i]["Depth"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>&nbsp;</td>");
               
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>"+Convert.ToDouble(ds.Tables[0].Rows[i]["Depth"]).ToString("F2")+"</td>");
            }
            
            if ((ds.Tables[0].Rows[i]["Area"]).ToString() == "")
            {
               
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2") + "</td>");
               
                if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
            }

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["Color_code"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Page"] + "</td>");
                      
            
            if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >" + ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
            }
            
            
            if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
            }

            
            if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
            }

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["RoNo."] + "</td>");
            
            string RoStatus1 = "";
            string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
            if (rrr4.Length >= 9)
            {
                RoStatus1 = rrr4.Substring(0, 9);
                if (rrr4.Length - 9 < 9)
                    RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                else
                    RoStatus1 += "</br>" + rrr4.Substring(9, 9);
            }
            else
                RoStatus1 = rrr4;

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + RoStatus1 + "</td>");

            string AdCat1 = "";
            string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
            if (rrr5.Length >= 9)
            {
                AdCat1 = rrr5.Substring(0, 9);
                if (rrr5.Length - 9 < 9)
                    AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                else
                    AdCat1 += "</br>" + rrr5.Substring(9, 9);
            }
            else
                AdCat1 = rrr5;

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + AdCat1 + "</td>");

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["AdsubCat"].ToString() + "</td>");

            if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
            }
            
            if ((ds.Tables[0].Rows[i]["AgreedRate"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
              }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
            }
            ///////cash disc
            
            if ((ds.Tables[0].Rows[i]["Cash_Disc"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Cash_Disc"]).ToString("F2") + "</td>");
            }
            ////////cash disc

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["AGREED_AMOUNT"] + "</td>");
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["SPL_AMOUNT"] + "</td>");

            if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'></td>");
               
            }
            else
            {
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                
            }

            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Cap"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Key"] + "</td>");
            //if (ds.Tables[0].Rows[i]["DOCKIT_NO"] != "" || ds.Tables[0].Rows[i]["DOCKIT_NO"] != null)
            //{
            //    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["DOCKIT_NO"] + "</td>");
            //}
           
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["EXEC_NAME"] + "</td>");

            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_STATUS"] + "</td>");

             tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

             //tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["GS"] + "</td>");
            
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_CENTER"] + "</td>");
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["REVENUE_CENTER"] + "</td>");
            
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["PRINT_REMARK"] + "</td>");

           // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["ADSTATUS"] + "</td>");
            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" +  "</td>");

           // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

           // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["GS"] + "</td>");
            
            tbl.Append("</tr>");


            tblgrid.InnerHtml = tbl.ToString();
            

        }


        tbl.Append("<tr >");

        tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle13new' colspan='3'>&nbsp;</td>");

        ////////////////////////////////////////

        
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl.Append("<td class='middle1212' colspan='4' align='right'><b>Total Area: " + cal.ToString() + "</b>");
        if (totrol > 0)
        {
            
            double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>" + calf.ToString() + "</td>");
            
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcd > 0)
        {
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>" + calfd + "</td>");
           
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcc > 0)
        {
              double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
              tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:" + calft.ToString() + "</b>");
           
        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }


        ///////////////////////////////////

        tbl.Append("<td  class='middle13new'  colspan='4' align='right' style='font-size: 13px;'><b>BillAmt:"+ amt.ToString()+ "</b></td>");
     
       // tbl = tbl + (amt.ToString() + "</td>");
        tbl.Append("<td class='middle1212' >&nbsp;</td>");

        tbl.Append("</tr>");

        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.Write("<p <table width='100%' align=\"center\"><tr><td  colspan=\"23\" align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
        hw.Write("<p <tr><td align=\"center\" colspan=\"23\"><b>" + "ALL ADS OF DAY" + "</b></td></tr></table>");
        hw.Write("<p <table> <tr><td colspan=\"4\"><b>PUBLICATION:" + lblpub.Text + "</b></td> <td colspan=\"4\"><b> PUBLICATION CENTER:" + pcenter.Text + "</b></td><td colspan=\"4\"><b>  EDITION:" + lbedition.Text + " </b></td> <td colspan=\"4\"><b> AGENCY TYPE:" + lblagtype.Text + "</b></td></tr>");
        hw.Write("<p <tr><td colspan=\"4\"><b>DATE FROM:" + lblfrom.Text + "</b></td> <td colspan=\"4\"><b> DATE TO:" + lblto.Text + "</b></td><td colspan=\"4\"><b> RUN DATE:" + lbldate.Text + "</b></td></tr>");
        hw.Write("<p <tr><td  colspan=\"4\" ><b>AD TYPE:" + lbladtype.Text + "</b></td><td colspan=\"4\"><b>AD CATEGORY:" + lbladcatg.Text + "</b></td><td colspan=\"4\"><b>AD SUBCAT:" + lbladsubcat.Text + " </b></td></tr></table>");
         
        hw.WriteBreak();
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }
    private void excel_csv(string adtyp, string adcat, string adsubcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        string language = ds1.Tables[1].Rows[0].ItemArray[0].ToString();

        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext);
        //}

        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext, Session["userid"].ToString());

        //}
        int cont = ds.Tables[0].Rows.Count;

        for (int u = 0; u < cont; u++)
        {

            if (ds.Tables[0].Rows[u]["Area"].ToString() != "")
            {
                if (ds.Tables[0].Rows[u]["uom"].ToString() == "CD" || ds.Tables[0].Rows[u]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());



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

        BoundColumn nameColumn0 = new BoundColumn();
        nameColumn0.HeaderText = "S.No";
        DataGrid1.Columns.Add(nameColumn0);



        BoundColumn nameColumn = new BoundColumn();
        nameColumn.HeaderText = "Booking ID";
        nameColumn.DataField = "CIOID";
        name1 = name1 + "," + "Booking ID";
        name2 = name2 + "," + "CIOID";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Edition";
        nameColumn1.DataField = "edition";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "edition";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Publish Date";
        nameColumn2.DataField = "Ins.Date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins.Date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Agency";
        nameColumn4.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);



        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Client";
        nameColumn6.DataField = "Client";

        name1 = name1 + "," + "Client";
        name2 = name2 + "," + "Client";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "Package";
        nameColumn7.DataField = "Package";

        name1 = name1 + "," + "Package";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "Depth";
        nameColumn9.DataField = "Depth";

        name1 = name1 + "," + "Depth";
        name2 = name2 + "," + "Depth";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "Width";
        nameColumn10.DataField = "Width";

        name1 = name1 + "," + "Width";
        name2 = name2 + "," + "Width";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Area";
        nameColumn11.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);

        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Color";
        nameColumn12.DataField = "Color_code";

        name1 = name1 + "," + "Color";
        name2 = name2 + "," + "Color_code";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);


        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "Page Position";
        nameColumn13.DataField = "Page";

        name1 = name1 + "," + "Page Position";
        name2 = name2 + "," + "Page";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);


        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "Page Prem";
        nameColumn14.DataField = "PagePremium";

        name1 = name1 + "," + "Page Prem";
        name2 = name2 + "," + "PagePremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "Position Prem";
        nameColumn15.DataField = "PositionPremium";

        name1 = name1 + "," + "Position Prem";
        name2 = name2 + "," + "PositionPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);


        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "Eye Catcher";
        nameColumn16.DataField = "BulletPremium";

        name1 = name1 + "," + "Eye Catcher";
        name2 = name2 + "," + "BulletPremium";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "Ro No.";
        nameColumn17.DataField = "RoNo.";

        name1 = name1 + "," + "Ro No.";
        name2 = name2 + "," + "RoNo.";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "Ro Status";
        nameColumn18.DataField = "RoStatus";

        name1 = name1 + "," + "Ro Status";
        name2 = name2 + "," + "RoStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "AdCat";
        nameColumn19.DataField = "AdCat";

        name1 = name1 + "," + "AdCat";
        name2 = name2 + "," + "AdCat";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "CardRate";
        nameColumn20.DataField = "CardRate";

        name1 = name1 + "," + "CardRate";
        name2 = name2 + "," + "CardRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = "AgreedRate";
        nameColumn21.DataField = "AgreedRate";

        name1 = name1 + "," + "AgreedRate";
        name2 = name2 + "," + "AgreedRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn21);


        BoundColumn nameColumn211 = new BoundColumn();
        nameColumn211.HeaderText = "Cash Disc";
        nameColumn211.DataField = "Cash_Disc";

        name1 = name1 + "," + "Cash Disc";
        name2 = name2 + "," + "Cash_Disc";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn211);

        BoundColumn nameColumn22 = new BoundColumn();
        nameColumn22.HeaderText = "BillAmt";
        nameColumn22.DataField = "Amt";

        name1 = name1 + "," + "BillAmt";
        name2 = name2 + "," + "Amt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn22);


        BoundColumn nameColumn23 = new BoundColumn();
        nameColumn23.HeaderText = "Caption";
        nameColumn23.DataField = "Cap";

        name1 = name1 + "," + "Caption";
        name2 = name2 + "," + "Cap";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn23);

        BoundColumn nameColumn24 = new BoundColumn();
        nameColumn24.HeaderText = "Key No.";
        nameColumn24.DataField = "Key";

        name1 = name1 + "," + "Key No.";
        name2 = name2 + "," + "Key";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn24);

        BoundColumn nameColumn25 = new BoundColumn();
        nameColumn25.HeaderText = "Audit Comment";
        //for (int u = 0; u < cont; u++)
        //{
        //    if (ds.Tables[0].Rows[u]["COMMENT"].ToString().IndexOf("~") != -1)
        //    {
        //        nameColumn25.ItemStyle.Font.Name = "4CAadita";
        //        //nameColumn25.ItemStyle.Font.Name = "Arial";
        //    }
        //    else
        //    {
        //        nameColumn25.ItemStyle.Font.Name = "Arial";
        //        //nameColumn25.ItemStyle.Font.Name = "4CAadita";
        //    }
        //}
        nameColumn25.DataField = "COMMENT";

        name1 = name1 + "," + "Audit Comment";
        name2 = name2 + "," + "COMMENT";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn25);

        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            hw.Write("<p align=\"center\"><b>" + "ALL ADS OF DAY" + "</b>");
            hw.Write("<p align=\"right\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            double arr = comm2 / areanew;
            int sno11 = sno - 1;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2'>TotalAds:" + sno11 + "</td><td align=\"right\" colspan=\"6\">Area:</td><td>" + area + "</td><td colspan='2'>Lines:" + totrol + "</td><td colspan='2'>Chars:" + totcd + "</td><td colspan='2'>Words:" + totcc + "</td><td colspan=\"6\">&nbsp;</td><td>" + comm2 + "</td><td></td><td></td><tr><td colspan=\"2\">Average Rate Realisation (ARR)</td><td colspan=\"3\"  align='left'>" + arr + "</td></tr></table>"));

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

    //protected void RadGrid_ItemDataBound(object sender, Telerik.WebControls.GridItemEventArgs e)
    //{
    //    if (e.Item is GridDataItem)
    //    {
    //        e.Item.CssClass += " test";
    //    }
    //}

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        double sumamt = 0;


        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        //if (e.Item is GridDataItem)
        //{
        //    //e.Item.CssClass += " 4CAadita";
        //    e.Item.Style["font-family"] = "4CAadita";
        //}

        string comt = e.Item.Cells[24].Text;
        if ((comt != "Audit Comment") && (comt != "") && (comt != "&nbsp;"))
        {

            if (e.Item.Cells[24].Text.ToString().IndexOf("~") != -1)
            {
                e.Item.Cells[24].Font.Name = "4CAadita";
                string amt_split = e.Item.Cells[24].Text;
                string[] amt_split1 = amt_split.Split('~');
                e.Item.Cells[24].Text = amt_split1[0];
            }
            else
            {
                e.Item.Cells[24].Font.Name = "Arial";
               
              
            }
        }
        //nameColumn25.HeaderText = "Audit Comment";
        //for (int u = 0; u < cont; u++)
        //{
        //    if (ds.Tables[0].Rows[u]["COMMENT"].ToString().IndexOf("~") != -1)
        //    {
        //        nameColumn25.ItemStyle.Font.Name = "4CAadita";
        //        //nameColumn25.ItemStyle.Font.Name = "Arial";
        //    }
        //    else
        //    {
        //        nameColumn25.ItemStyle.Font.Name = "Arial";
        //        //nameColumn25.ItemStyle.Font.Name = "4CAadita";
        //    }
        //}
        //nameColumn25.DataField = "COMMENT";

        string check = e.Item.Cells[21].Text;
        string amt = e.Item.Cells[21].Text;


        string check1 = e.Item.Cells[9].Text;
        string amt1 = e.Item.Cells[9].Text;


        if (check != "BillAmt")
        {
            if (check != "&nbsp;")
            {


                string grossamt = e.Item.Cells[21].Text;
                comm1 = Convert.ToDouble(grossamt);
                comm2 = comm2 + comm1;

                //string arean = e.Item.Cells[8].Text;
                //areanew=areanew + Convert.ToDouble(arean);


            }
        }


        //area


        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {




                string arean = e.Item.Cells[9].Text;
                areanew = areanew + Convert.ToDouble(arean);


            }
        }


    }
    


}


