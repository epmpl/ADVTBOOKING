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
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;

public partial class picontractviewreport : System.Web.UI.Page
{

    int sno = 1;
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    double areasum = 0;
    double contractratenew = 0.0;
    double amtnew11 = 0.0;

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
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";

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
        

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[40].ToString();

       
        ds = (DataSet)Session["picontract"];
        string prm = Session["prm_picontract"].ToString();
        string[] prm_Array = new string[30];
        prm_Array = prm.Split('~');


        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        destination = prm_Array[5]; //Request.QueryString["destination"].ToString();
        prod = prm_Array[7]; //Request.QueryString["prodcode"].ToString();
        product = prm_Array[9]; //Request.QueryString["product"].ToString();
        agency = prm_Array[11]; //Request.QueryString["agency"].ToString();
        agencycode = prm_Array[13]; //Request.QueryString["agencycode"].ToString();
        client = prm_Array[15]; //Request.QueryString["client"].ToString();
        clientcode = prm_Array[17]; //Request.QueryString["clientcode"].ToString();
        region = prm_Array[19]; //Request.QueryString["region"].ToString();
        regioncode = prm_Array[21]; //Request.QueryString["regioncode"].ToString();
        adcat = prm_Array[23]; //Request.QueryString["adcat"].ToString();
        adcatcode = prm_Array[25]; //Request.QueryString["adcatcode"].ToString();
        reporttype = prm_Array[27]; //Request.QueryString["reporttype"].ToString();
        chk_excel = prm_Array[29];


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
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);
            }
            else if (destination == "4")
            {
                excel(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);
            }


            else
                if (destination == "3")
                {
                    pdf(datefrom1, dateto1, Session["compcode"].ToString(), Session["dateformat"].ToString(), prod);

                }
        }
       
    }

    private void onscreen(string fromdt, string dateto, string compcode, string dateformat, string prod)
    {
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
        tbl = "<table width='100%'align='left' cellpadding='2' cellspacing='0' border='0'>";

        tbl = tbl + ("<tr><td class='middle31new' >S.No.</td><td id='tdro~28' class='middle31new' align='left'> Booking</br>Id</td><td class='middle31new' align='left'>Publish</br>Date</td><td id='tdag~3' class='middle31new' align='left'>Agency</td><td id='tdcli~4' class='middle31new' align='left'>Client</td><td id='tdpac~5' class='middle31new' align='left' width='3%'>Edition</td><td id='tdro~25' class='middle31new'  align='right'>Area&nbsp;&nbsp;</td><td id='tdro~25' class='middle31new' align='left'>Ad Type</td><td id='tds~41' class='middle31new' align='left'> Contract</br>Name</td><td id='tds~2' class='middle31new' align='left'> Contract</br>Type</td><td id='tds~2' class='middle31new' align='right' > Contract</br>Rate</td> <td id='tdro~19' class='middle31new' align='right'  > Amount&nbsp;&nbsp;</td> <td id='tdreg~13' class='middle31new' align='left'>Region</td></tr>");

     

        int i1 = 1;
        double area = 0.0;
        double contractrate = 0.0;
        double amt = 0.0;



        for (int i = 0; i <= cont - 1; i++)
        {
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
            tbl = tbl + Area11.ToString("F2") + "</td>";


         

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
            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (Package1 + "</td>");






            tbl = tbl + ("<td class='rep_data' align='left'>");
        
            tbl = tbl + (ds.Tables[0].Rows[i]["ContractType"] + "</td>");
            tbl = tbl + ("<td class='rep_data' align='right'>");
        
            tbl = tbl + ds.Tables[0].Rows[i]["ContractRate"] + "&nbsp;</td>";
            if (ds.Tables[0].Rows[i]["ContractRate"].ToString() != "")
                contractrate = contractrate + Convert.ToDouble(ds.Tables[0].Rows[i]["ContractRate"]);



       

            tbl = tbl + ("<td class='rep_data' align='right'>");

            Double Amt11 = Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]);
            tbl = tbl + Amt11.ToString("F2") + "&nbsp;</td>";

         
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

      
        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' align='right' ><b>Contract Rate:&nbsp</b></td>");
        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='3'><b>");
        tbl = tbl + (contractrate.ToString() + "</b></td>");


    
        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='2' align='right'><b>Amount:&nbsp</b></td>");
   
        tbl = tbl + ("<td class='middle13new' style='font-size: 12px;' colspan='3'><b>");
        tbl = tbl + (amt.ToString() + "</b></td>");
        tbl = tbl + "</tr>";



        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;
       


    }









    private void excel(string fromdt, string dateto, string compcode, string dateformat, string prod)
    {


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
        nameColumn.HeaderText = "Booking Id";
        nameColumn.DataField = "CIOID";

        name1 = name1 + "," + "Booking Id";
        name2 = name2 + "," + "CIOID";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Publish Date";
        nameColumn1.DataField = "Ins.date";

        name1 = name1 + "," + "Publish Date";
        name2 = name2 + "," + "Ins.date";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "Agency";
        nameColumn2.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Client";
        nameColumn4.DataField = "Client";

        name1 = name1 + "," + "Client";
        name2 = name2 + "," + "Client";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);


        BoundColumn nameColumn5 = new BoundColumn();
        nameColumn5.HeaderText = "Edition";
        nameColumn5.DataField = "Package";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "Package";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn5);

        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Area";
        nameColumn6.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "AdType";
        nameColumn7.DataField = "AdType1";

        name1 = name1 + "," + "AdType";
        name2 = name2 + "," + "AdType1";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn8 = new BoundColumn();
        nameColumn8.HeaderText = "ContractName";
        nameColumn8.DataField = "Contract_name";

        name1 = name1 + "," + "ContractName";
        name2 = name2 + "," + "Contract_name";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn8);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "ContractType";
        nameColumn9.DataField = "ContractType";

        name1 = name1 + "," + "ContractType";
        name2 = name2 + "," + "ContractType";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "ContractRate";
        nameColumn10.DataField = "ContractRate";

        name1 = name1 + "," + "ContractRate";
        name2 = name2 + "," + "ContractRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "Amt";
        nameColumn11.DataField = "Amt";

        name1 = name1 + "," + "Amt";
        name2 = name2 + "," + "Amt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);


        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Region";
        nameColumn12.DataField = "Region";

        name1 = name1 + "," + "Region";
        name2 = name2 + "," + "Region";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);



        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p align=\"left\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>PI Contract Report<b>");
            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            int sno11 = sno - 1;
            Response.Write(sw.ToString().Replace("</table>", "<tr><td>" + "" + "</td><td align=\"center\" colspan=\"3\">TOTAL</td><td align=\"center\" colspan=\"2\"></td><td>" + areanew + "</td><td></td><td></td><td></td><td>" + contractratenew + "<td align=\"center\" >" + amtnew11 + "</td><td>" + "</td></tr></table>"));
        }
        else
        {
            DataGrid1.DataSource = ds;

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


    private iTextSharp.text.Image TextWriter(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    private void pdf(string fromdt, string dateto, string compcode, string dateformat, string prod)
    {

        double totalContractRate = 0.0;
        double totalBillAmt = 0.0;

        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

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




        int NumColumns = 13;

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
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new iTextSharp.text.Phrase("PI Contract Report", font9));
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


            PdfPTable datatablecenter = new PdfPTable(8);
            datatablecenter.DefaultCell.Padding = 1;


            datatablecenter.WidthPercentage = 100; // percentage
            datatablecenter.DefaultCell.BorderWidth = 0;
            datatablecenter.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


            PdfPTable datatabletotal = new PdfPTable(NumColumns);
            datatabletotal.DefaultCell.Padding = 1;


            datatabletotal.WidthPercentage = 100; // percentage
            datatabletotal.DefaultCell.BorderWidth = 0;
            datatabletotal.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

           
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






            datatablecenter.addCell(new iTextSharp.text.Phrase("DATE FROM:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(fromdt.ToString(), font10));

           datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("DATE TO:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(dateto.ToString(), font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("RUN DATE:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(date.ToString(), font10));
      
            datatablecenter.addCell(new iTextSharp.text.Phrase("PUBLICATION:", font10));
            if ((prod == "0") || (prod == ""))
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(product.ToString(), font10));
            }

            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("REGION:", font10));
            if (regioncode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(region.ToString(), font10));
            }


          datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("CATEGORY:", font10));
            if (adcatcode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(adcat.ToString(), font10));
            }

       
            datatablecenter.addCell(new iTextSharp.text.Phrase("AGENCY:", font10));

            if (agencycode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(agency.ToString(), font10));
            }

            
          datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
          
                datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));

                datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
           datatablecenter.addCell(new iTextSharp.text.Phrase("CLIENT:", font10));
            if (clientcode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(client.ToString(), font10));
            }
       
            document.Add(datatablecenter);






            /*********************      for spacing after heading     ***********************/

            iTextSharp.text.Phrase p111 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p111);

            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[45].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[46].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[57].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[40].ToString(), font10));


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
            
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {

              


                    datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Ins.date"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Package"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AdType1"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Contract_name"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["ContractType"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["ContractRate"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Amt"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Region"].ToString(), font10));

                   
                    if (ds.Tables[0].Rows[k]["ContractRate"].ToString() != "")
                    {

                        totalContractRate = totalContractRate + Convert.ToDouble(ds.Tables[0].Rows[k]["ContractRate"].ToString());
                    }

                    if (ds.Tables[0].Rows[k]["Amt"].ToString() != "")
                    {

                        totalBillAmt = totalBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["Amt"].ToString());
                    }

               
            }


        
            document.Add(datatable1);

            /************************   for data in pdf file   **************************/




            iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p1);


            datatabletotal.addCell(new iTextSharp.text.Phrase("Total", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase("", font10));
            datatabletotal.addCell(new iTextSharp.text.Phrase(totalContractRate.ToString(), font10));
           
            datatabletotal.addCell(new iTextSharp.text.Phrase(totalBillAmt.ToString(), font10));
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

        string check = e.Item.Cells[11].Text;
        string amt = e.Item.Cells[11].Text;


        if (check != "Amt")
        {
            if (check != "&nbsp;")
            {


                string grossamt = e.Item.Cells[11].Text;
                comm1 = Convert.ToDouble(grossamt);
                amtnew11 = amtnew11 + comm1;

            }
        }

        string check2 = e.Item.Cells[10].Text;
        string comm33 = e.Item.Cells[10].Text;


        if (check2 != "ContractRate")
        {
            if (check2 != "&nbsp;")
            {


                string commamt = e.Item.Cells[10].Text;
                comm2 = Convert.ToDouble(commamt);
                contractratenew = contractratenew + comm2;

            }
        }




    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_picontract_print"] = "fromdate~" + fromdt + "~dateto~" + dateto + "~prodcode~" + prod + "~product~" + product + "~agency~" + agency + "~agencycode~" + agencycode + "~client~" + client + "~clientcode~" + clientcode + "~region~" + region + "~regioncode~" + regioncode + "~adcat~" + adcat + "~adcatcode~" + adcatcode + "~reporttype~" + reporttype;
        Response.Redirect("picontractviewprint.aspx");
        //Response.Redirect("picontractviewprint.aspx?&fromdate=" + fromdt + "&dateto=" + dateto + "&prodcode=" + prod + "&product=" + product + "&agency=" + agency + "&agencycode=" + agencycode + "&client=" + client + "&clientcode=" + clientcode + "&region=" + region + "&regioncode=" + regioncode + "&adcat=" + adcat + "&adcatcode=" + adcatcode + "&reporttype=" + reporttype);
    }
}





