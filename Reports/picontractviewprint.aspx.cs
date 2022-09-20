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
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text;
using System.IO;

public partial class picontractviewprint : System.Web.UI.Page
{
    int sno = 1;
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    double areasum = 0;

    string agencycode = "";
    string clientcode = "";
    string adcatcode = "";
    string regioncode = "";

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
    string reporttype;
    DataSet ds;
    int maxlimit = 17;
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
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[29].ToString());

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[40].ToString();

         ds = (DataSet)Session["picontract"];
        string prm = Session["prm_picontract_print"].ToString();
        string[] prm_Array = new string[30];
        prm_Array = prm.Split('~');

        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        prod = prm_Array[5]; //Request.QueryString["prodcode"].ToString();
        product = prm_Array[7]; //Request.QueryString["product"].ToString();
        agency = prm_Array[9]; //Request.QueryString["agency"].ToString();
        agencycode = prm_Array[11]; //Request.QueryString["agencycode"].ToString();
        client = prm_Array[13]; //Request.QueryString["client"].ToString();
        clientcode = prm_Array[15]; //Request.QueryString["clientcode"].ToString();
        region = prm_Array[17]; //Request.QueryString["region"].ToString();
        regioncode = prm_Array[19]; //Request.QueryString["regioncode"].ToString();
        adcat = prm_Array[21]; //Request.QueryString["adcat"].ToString();
        adcatcode = prm_Array[23]; //Request.QueryString["adcatcode"].ToString();
        reporttype = prm_Array[25]; //Request.QueryString["reporttype"].ToString();

        if (agencycode == "0" || agencycode=="")
        {
            lblagency.Text = "ALL".ToString();
        }
        else
        {
            lblagency.Text = agency.ToString();
        }


        if (clientcode == "0" || clientcode=="")
        {
            lblclient.Text = "ALL".ToString();
        }
        else
        {
            lblclient.Text = client.ToString();
        }

        if (regioncode == "0" || regioncode == "")
        {
            lblregion.Text = "ALL".ToString();
        }
        else
        {
            lblregion.Text = region.ToString();
        }

        if (adcatcode == "0")
        {
            lbladcat.Text = "ALL".ToString();
        }
        else
        {
            lbladcat.Text = adcat.ToString();
        }




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

        lblfrom.Text = fromdt;

        lblto.Text = dateto;

        //if (destination == "1" || destination == "0")
        //{
            onscreen(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);
        //}
    }

    private void onscreen(string fromdt, string dateto, string compcode, string dateformat, string prod)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
       

        //if (reporttype == "scheduled")
        //{


        //    NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();
        //    ds = obj.spcontractreportnew(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, agencycode, clientcode, regioncode, adcatcode);
        //}

        //else if (reporttype == "billed")
        //{
        //    NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();
        //    ds = obj.spcontractreportnewbilled(fromdt, dateto, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod, agencycode, clientcode, regioncode, adcatcode);

        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
       
        int cont = ds.Tables[0].Rows.Count;
       
   

        string tbl = "";
        tbl = "<table width='89%'align='left' cellpadding='2' cellspacing='0' border='0'>";

       // tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td id='tdro~28' class='middle31new' width='4%'> CIOID</td><td class='middle31new' width='4%'>Ins.date</td><td id='tdag~3' class='middle31new' width='9%'>Agency</td><td id='tdcli~4' class='middle31new' width='9%'>Client</td><td id='tdpac~5' class='middle31new' width='5%'>Package</td><td id='tdro~25' class='middle31new' width='3%'>&nbsp;&nbsp;Area</td><td id='tdro~25' class='middle31new' width='4%'>Ad Type</td><td id='tds~41' class='middle31new' align='middel' width='5%'> Contract</br>&nbsp;&nbsp;&nbsp;Name</td><td id='tds~2' class='middle31new' width='3%'> Contract</br>&nbsp;&nbsp;&nbsp;Type</td><td id='tds~2' class='middle31new' align='right' width='4%'> Contract</br>Rate&nbsp;&nbsp;&nbsp;</td> <td id='tdro~19' class='middle31new' align='right'  width='3%'> Amount</td> <td id='tdreg~13' class='middle31new' width='5%'>Region</td></tr>");
        tbl = tbl + ("<tr><td class='middle31new' >S.No.</td><td id='tdro~28' class='middle31new' align='left'> Booking</br>Id</td><td class='middle31new' align='left'>Publish</br>Date</td><td id='tdag~3' class='middle31new' align='left'>Agency</td><td id='tdcli~4' class='middle31new' align='left'>Client</td><td id='tdpac~5' class='middle31new' align='left' width='3%'>Edition</td><td id='tdro~25' class='middle31new'  align='right'>Area&nbsp;&nbsp;</td><td id='tdro~25' class='middle31new' align='left'>Ad Type</td><td id='tds~41' class='middle31new' align='left'> Contract</br>Name</td><td id='tds~2' class='middle31new' align='left'> Contract</br>Type</td><td id='tds~2' class='middle31new' align='right' > Contract</br>Rate</td> <td id='tdro~19' class='middle31new' align='right'  > Amount&nbsp;&nbsp;</td> <td id='tdreg~13' class='middle31new' align='left'>Region</td></tr>");



        int i1 = 1;
        double area = 0.0;
        double contractrate = 0.0;
        double amt = 0.0;



        for (int i = 0; i <= cont - 1; i++)
        {


            //if (i == 0)
            //{
            //    tbl = tbl + "<tr><td colspan='13'><table class='pagebreak11' width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>";
            //    tbl = tbl + ("<tr><td class='middle31new' width='1%'>&nbsp;&nbsp;&nbsp;S.</br>&nbsp;&nbsp;&nbsp;No.</td><td id='tdro~28' class='middle31new' width='6%'> CIOID</td><td class='middle31new' width='6%'>Ins.date</td><td id='tdag~3' class='middle31new' width='13%'>Agency</td><td id='tdcli~4' class='middle31new' width='14%'>Client</td><td id='tdpac~5' class='middle31new' width='8%'>Package</td><td id='tdro~25' class='middle31new' width='4%'>&nbsp;&nbsp;Area</td><td id='tdro~25' class='middle31new' width='6%'>Ad Type</td><td id='tds~41' class='middle31new' align='middel' width='7%'> Contract</br>&nbsp;&nbsp;&nbsp;Name</td><td id='tds~2' class='middle31new' width='5%'> Contract</br>&nbsp;&nbsp;&nbsp;Type</td><td id='tds~2' class='middle31new' align='right' width='5%'> Contract</br>Rate&nbsp;&nbsp;&nbsp;</td> <td id='tdro~19' class='middle31new' align='right'  width='5%'> Amount</td> <td id='tdreg~13' class='middle31new' width='6%'>Region</td></tr>");
            //}





            tbl = tbl + ("<tr >");






            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");


            tbl = tbl + ("<td class='rep_data' align='left'>");

            //-------------------------------------------//
            //string cioid1 = "";
            //string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            //char[] cioid = rrr.ToCharArray();
            //int len11 = cioid.Length;

            //for (int ch = 0; ch < len11; ch++)
            //{

            //    if (ch == 0)
            //    {
            //        cioid1 = cioid1 + cioid[ch];
            //    }
            //    else if (ch % 10 != 0)
            //    {
            //        cioid1 = cioid1 + cioid[ch];
            //    }
            //    else
            //    {
            //        cioid1 = cioid1 + "</br>" + cioid[ch];
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
            //----------------------------------------------------------------///

            tbl = tbl + (cioid1 + "</td>");

            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
            // tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='left'>");
            //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");


            //-------------------------------------------//
            //string agency1 = "";
            //string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            //char[] agency = rrr1.ToCharArray();
            //int len111 = agency.Length;
            //int line11 = 0;
            //for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            //{

            //    if (ch1 == 0)
            //    {
            //        agency1 = agency1 + agency[ch1];
            //    }
            //    else if (ch1 % 20 != 0)
            //    {
            //        agency1 = agency1 + agency[ch1];
            //    }
            //    else
            //    {
            //        line11 = line11 + 1;
            //        if (line11 != 2)
            //        {
            //            agency1 = agency1 + "</br>" + agency[ch1];
            //        }
            //    }
            //}
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
            //----------------------------------------------------------------///
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (agency1 + "</td>");

            //-------------------------------------------//
            //string client1 = "";
            //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            //char[] client = rrr11.ToCharArray();
            //int len1111 = client.Length;
            //int line = 0;

            //for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            //{

            //    if (ch11 == 0)
            //    {
            //        client1 = client1 + client[ch11];
            //    }
            //    else if (ch11 % 20 != 0)
            //    {
            //        client1 = client1 + client[ch11];
            //    }
            //    else
            //    {

            //        line = line + 1;
            //        if (line != 2)
            //        {
            //            client1 = client1 + "</br>" + client[ch11];

            //        }



            //    }


            //}
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
            //----------------------------------------------------------------///


            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (client1 + "</td>");


            tbl = tbl + ("<td class='rep_data' align='left'>");

            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='right'>");

            Double Area11 = Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]);
            tbl = tbl + Area11.ToString("F2") + "&nbsp;&nbsp;</td>";




            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]);

            tbl = tbl + ("<td class='rep_data' align='left'>");

            tbl = tbl + (ds.Tables[0].Rows[i]["AdType1"] + "</td>");




            //-------------------------------------------//
            //string Contract_name1 = "";
            //string rrr1111 = ds.Tables[0].Rows[i]["Contract_name"].ToString();
            //char[] Contract_name = rrr1111.ToCharArray();
            //int len111111 = Contract_name.Length;
            //int line11111 = 0;
            //for (int ch1111 = 0; ((ch1111 < len111111) && (line11111 < 2)); ch1111++)
            //{

            //    if (ch1111 == 0)
            //    {
            //        Contract_name1 = Contract_name1 + Contract_name[ch1111];
            //    }
            //    else if (ch1111 % 12 != 0)
            //    {
            //        Contract_name1 = Contract_name1 + Contract_name[ch1111];
            //    }
            //    else
            //    {
            //        line11111 = line11111 + 1;
            //        if (line11111 != 2)
            //        {
            //            Contract_name1 = Contract_name1 + "</br>" + Contract_name[ch1111];
            //        }
            //    }
            //}
            string Package1 = "";
            string rrr111111 = ds.Tables[0].Rows[i]["Contract_name"].ToString();
            char[] Package = rrr111111.ToCharArray();
            int len11111111 = Package.Length;
            int line1111111 = 0;
            int ch_end111 = 0;
            int ch_str111 = 0;
            for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
            {
                /**/
                ch_end111 = ch_end111 + 9;
                ch_str111 = ch_end111;
                if (ch_end111 > len11111111)
                    ch_str111 = len11111111 - ch111111;
                else
                    ch_str111 = ch_end111 - ch111111;

                Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
                Package1 = Package1 + "</br>";
                ch111111 = ch111111 + 9;
                if (ch111111 > len11111111)
                    ch111111 = len11111111;
            }
            //----------------------------------------------------------------///
            tbl = tbl + ("<td class='rep_data'  align='left'>");
            tbl = tbl + (Package1 + "</td>");






            tbl = tbl + ("<td class='rep_data' align='left'>");

            tbl = tbl + (ds.Tables[0].Rows[i]["ContractType"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + ds.Tables[0].Rows[i]["ContractRate"] + "&nbsp;</td>";

           // Double contractrate11 = Convert.ToDouble(ds.Tables[0].Rows[i]["ContractRate"]);
           // tbl = tbl + contractrate11.ToString("F2") + "&nbsp;</td>";

            if (ds.Tables[0].Rows[i]["ContractRate"].ToString() != "")
                contractrate = contractrate + Convert.ToDouble(ds.Tables[0].Rows[i]["ContractRate"]);





            tbl = tbl + ("<td class='rep_data' align='right'>");

            Double Amt11 = Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]);
            tbl = tbl + Amt11.ToString("F2") + "&nbsp;&nbsp;</td>";


            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());



            //----------------------------------------------------------------///

            //string Region1 = "";
            //string rrr111111 = ds.Tables[0].Rows[i]["Region"].ToString();
            //char[] Region = rrr111111.ToCharArray();
            //int len11111111 = Region.Length;
            //int line1111 = 0;

            //for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111 < 2)); ch111111++)
            //{

            //    if (ch111111 == 0)
            //    {
            //        Region1 = Region1 + Region[ch111111];
            //    }
            //    else if (ch111111 % 10 != 0)
            //    {
            //        Region1 = Region1 + Region[ch111111];
            //    }
            //    else
            //    {

            //        line1111 = line1111 + 1;
            //        if (line1111 != 2)
            //        {
            //            Region1 = Region1 + "</br>" + Region[ch111111];

            //        }



            //    }


            //}
            string RoStatus1 = "";
            string rrrnew11 = ds.Tables[0].Rows[i]["Region"].ToString();
            char[] RoStatus = rrrnew11.ToCharArray();
            int lennew11 = RoStatus.Length;
            int linenew11 = 0;
            int ch_end11111 = 0;
            int ch_str11111 = 0;
            for (int chnew11 = 0; ((chnew11 < lennew11) && (linenew11 < 2)); chnew11++)
            {

                /**/
                ch_end11111 = ch_end11111 + 9;
                ch_str11111 = ch_end11111;
                if (ch_end11111 > lennew11)
                    ch_str11111 = lennew11 - chnew11;
                else
                    ch_str11111 = ch_end11111 - chnew11;
                RoStatus1 = RoStatus1 + rrrnew11.Substring(chnew11, ch_str11111).Trim();
                RoStatus1 = RoStatus1 + "</br>";
                chnew11 = chnew11 + 9;
                if (chnew11 > lennew11)
                    chnew11 = lennew11;/**/

            }   
            //----------------------------------------------------------------///


            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (RoStatus1 + "</td>");


            tbl = tbl + "</tr>";

            tblgrid.InnerHtml += tbl;
            tbl = "";

        }


        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle13new' style='font-size: 13px;' colspan='2'><b>&nbsp;&nbsp;Total</b></td>");

        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' align='right'><b>Area:&nbsp</b></td>");
        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' align='left'><b>");
        tbl = tbl + (area.ToString() + "</b></td>");


        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' align='right' colspan='2' ><b>Contract Rate:&nbsp</b></td>");
        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='2'><b>");
        tbl = tbl + (contractrate.ToString() + "</b></td>");



        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='2' align='right'><b>Amount:&nbsp</b></td>");

        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='3'><b>");
        tbl = tbl + (amt.ToString() + "</b></td>");
        tbl = tbl + "</tr>";



        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;






     


    }

}
