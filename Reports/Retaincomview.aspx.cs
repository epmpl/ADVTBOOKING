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
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;


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
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[41].ToString();

        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

        lblfrom.Text = fromdt;
        lblto.Text = dateto;

            ds = (DataSet)Session["retaincom"];
            string prm = Session["prm_retaincom"].ToString();
            string[] prm_Array = new string[31];
            prm_Array = prm.Split('~');


            destination = prm_Array[1];//Request.QueryString["destination"].ToString();
            fromdt = prm_Array[3];//Request.QueryString["fromdate"].ToString();
            dateto = prm_Array[5];//Request.QueryString["dateto"].ToString();
            region = prm_Array[7];//Request.QueryString["regioncode"].ToString();
            regionname = prm_Array[9];//Request.QueryString["regionname"].ToString();
            product = prm_Array[11];//Request.QueryString["productcode"].ToString();
            productname = prm_Array[13];//Request.QueryString["productname"].ToString();
            editioncode = prm_Array[15];//Request.QueryString["editioncode"].ToString();
            editionname = prm_Array[17];//Request.QueryString["editionname"].ToString();
            branchcode = prm_Array[19];//Request.QueryString["branchcode"].ToString();
            branchname = prm_Array[21];//Request.QueryString["branchname"].ToString();
            Adtypecode = prm_Array[23];//Request.QueryString["Adtypecode"].ToString();
            Adtypename = prm_Array[25];//Request.QueryString["Adtypename"].ToString();
            Retainercode = prm_Array[27];//Request.QueryString["Retainercode"].ToString();
            Retainername = prm_Array[29];//Request.QueryString["Retainername"].ToString();
            chk_excel = prm_Array[31];


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

            if (Retainercode == "0" || Retainercode=="")
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
                        datefrom1 = RETURN_LENGTH(day) + "/" +RETURN_LENGTH (month) + "/" + year;


                    }
                    else if (hiddendateformat.Value == "mm/dd/yyyy")
                    {
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 =RETURN_LENGTH (month) + "/" + RETURN_LENGTH(day) + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd")
                    {

                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        datefrom1 = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);
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
                            dateto1 = RETURN_LENGTH(day) + "/" +RETURN_LENGTH (month) + "/" + year;


                        }
                        else if (hiddendateformat.Value == "mm/dd/yyyy")
                        {
                            day = dt.Day.ToString();
                            month = dt.Month.ToString();
                            year = dt.Year.ToString();
                            dateto1 = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

                        }
                        else if (hiddendateformat.Value == "yyyy/mm/dd")
                        {

                            day = dt.Day.ToString();
                            month = dt.Month.ToString();
                            year = dt.Year.ToString();
                            dateto1 = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);
                        }
                    }
         
              
            }

            if (!Page.IsPostBack)
            {


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



    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x =
            "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }






    private void onscreen(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {
       
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
       
        //    NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();
        //  ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchcode, editionname, Retainercode, Adtypecode);



            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='3' cellspacing='0' border='0'>";

        //tbl = tbl + "<tr height='1px'><td class='middle4'>&nbsp;</td><td class='middle4'>&nbsp;</td><td class='middle4'>&nbsp;</td><td class='middle4'>&nbsp;</td><td class='middle4'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        tbl = tbl + ("<tr><td class='middle31new' align='left' >S.</br>No</td><td id='tdret~7' class='middle31new' align='left'  >Retainer</br>Name</td><td id='tdro~28' class='middle31new' align='left' > CIOID</td><td id='tdag~2' class='middle31new' align='left'  >Agency</td><td id='tdcli~3' class='middle31new' align='left' >Client</td><td id='tdpub~4' class='middle31new' align='left'  >Publication</td><td id='tdpub~4' class='middle31new' align='left' >Edition</td>  <td id='tdro~25' class='middle31new' align='right' >Area</td><td id='tdbill~11' class='middle31new' align='left'>Bill</br>Status</td><td id='td~291' class='middle31new' align='right' >Gross</br>Amt</td><td id='td~291' class='middle31new' align='right' >Agency</br>TD(%)</td><td id='td~291' class='middle31new' align='right' >Agency</br>TD(Amt)</td><td id='td~291' class='middle31new' align='right' >Agency</br>Addl TD(%)</td> <td id='td~291' class='middle31new' align='right' >Agency</br>Addl TD(Amt)</td>  <td id='td~291' class='middle31new' align='right' >Bill</br>Amount</td> <td id='td~291' class='middle31new' align='right' >Retcomm(%)</td><td id='td~291' class='middle31new' align='right' >RetComm(Amt)</td><td id='td~291' class='middle31new' align='right' >Actual</br>Business</td><td id='trevec~13' class='middle31new' align='left' >Revenue</br>Center</td></tr>");


        int i1 = 1;
        float area=0;
        double BillAmt = 0.00;
        double subBillAmt = 0.00;
        double totalretainercomm = 0.00;
        double subretainercomm = 0.00;

        double totalretainercommamt = 0.00;
        double subretainercommamt = 0.00;
        for (int i = 0; i <= cont - 1; i++)
        {

            if (ds.Tables[0].Rows[i]["RetainName"].ToString() != "")
            {


              
                if (i > 0)
                {
                    if ((ds.Tables[0].Rows[i]["RetainName"].ToString()) == (ds.Tables[0].Rows[(i - 1)]["RetainName"].ToString()))
                    {





                        tbl = tbl + ("<tr >");


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (i1++.ToString() + "</td>");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";
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
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (cioid1 + "</td>");



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
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (agency1 + "</td>");

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

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (client1 + "</td>");



                      
                        string Package1 = "";
                        string rrr111111 = ds.Tables[0].Rows[i]["Publication"].ToString();
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
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (Package1 + "</td>");






                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
                      
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                        if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                            area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    

                     
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["grossamt"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyTD(%)"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyTDAmt"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTD(%)"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTDAmt"] + "</td>");




                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                        tbl = tbl + bill11.ToString("F2") + "</td>";
                        if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                        {
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                            subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                        }



                        tbl = tbl + ("<td class='rep_data' align='right' >");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");

                        Double ret_comm_amt;
                        if (ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString() != "")
                        {
                            ret_comm_amt = Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"]);
                        }
                        else
                        {
                            ret_comm_amt = 0;
                        }
                        tbl = tbl + ret_comm_amt.ToString("F2") + "</td>";

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["ActualBusiness"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");
                        tbl = tbl + "</tr>";


                        if (ds.Tables[0].Rows[i]["RetainerCommision"].ToString() != "")
                        {
                            subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                            totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                        }

                        if (ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString() != "")
                        {
                            subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString());
                            totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString());
                        }

                        


                    }
                    else
                    {
                       
                        tbl = tbl + ("<tr valign='top' height='25'>");


                        tbl = tbl + ("<td class='rep_data2' colspan='2' valign='top'>");
                        tbl = tbl  +"Sub Total:"  +"</td>";
                       
                        tbl = tbl + ("<td class='rep_data' colspan='12'>") ;
                        tbl = tbl + "</td>";

                        //tbl = tbl + ("<td class='rep_data' >");
                        //tbl = tbl + "</td>";

                        //tbl = tbl + ("<td class='rep_data' >");
                        //tbl = tbl + "</td>";

                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";

                      
                        //tbl = tbl + ("<td class='rep_data' >");
                        //tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subBillAmt.ToString("F2") + "</b>";
                        tbl = tbl + "</td>";

                       
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";

                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercomm + "</b>";
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercommamt.ToString("F2") + "</b>";
                        tbl = tbl + "</td>";

                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + "</td>";

                        tbl = tbl + "</tr>";


                        subretainercomm = 0.00;
                        subBillAmt = 0.00;
                        subretainercommamt = 0.00;

                        tbl = tbl + ("<tr class='pagebreaknot'>");


                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (i1++.ToString() + "</td>");

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
                      

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl +"<b>" +(retname + "</b></td>");
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

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (cioid1 + "</td>");


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
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (agency1 + "</td>");

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
                      

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (client1 + "</td>");


                        string Package1 = "";
                        string rrr111111 = ds.Tables[0].Rows[i]["Publication"].ToString();
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
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (Package1 + "</td>");


                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
                       
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                        if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                            area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                       
                      
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["grossamt"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyTD(%)"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyTDAmt"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTD(%)"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTDAmt"] + "</td>");




                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                        tbl = tbl + bill11.ToString("F2") + "</td>";
                        if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                        {
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                            subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                        }



                        tbl = tbl + ("<td class='rep_data' align='right' >");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");

                        Double ret_comm_amt;
                        if (ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString() != "")
                        {
                            ret_comm_amt = Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"]);
                        }
                        else
                        {
                            ret_comm_amt = 0;
                        }
                        tbl = tbl + ret_comm_amt.ToString("F2") + "</td>";

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["ActualBusiness"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");
                        tbl = tbl + "</tr>";

                       
                        if (ds.Tables[0].Rows[i]["RetainerCommision"].ToString() != "")
                        {
                            subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                            totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                        }

                        if (ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString() != "")
                        {
                            subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString());
                            totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString());
                        }

                    }

                }
                else
                {

                    tbl = tbl + ("<tr >");


                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (i1++.ToString() + "</td>");

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
                  

                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl +"<b>"+ (retname + "</b></td>");
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
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (cioid1 + "</td>");


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
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (agency1 + "</td>");

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

                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (client1 + "</td>");

                    string Package1 = "";
                    string rrr111111 = ds.Tables[0].Rows[i]["Publication"].ToString();
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
                    tbl = tbl + ("<td class='rep_data'  align='left'>");
                    tbl = tbl + (Package1 + "</td>");


                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
                   
                   
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
                    if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                        area = area + float.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["grossamt"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AgencyTD(%)"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AgencyTDAmt"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTD(%)"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTDAmt"] + "</td>");




                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                    tbl = tbl + bill11.ToString("F2") + "</td>";
                    if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                    {
                        BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                        subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                    }
                       
                  

                    tbl = tbl + ("<td class='rep_data' align='right' >");
                    tbl = tbl + (ds.Tables[0].Rows[i]["RetainerCommision"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");

                    Double ret_comm_amt;
                    if (ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString() != "")
                    {
                        ret_comm_amt = Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"]);
                    }
                    else
                    {
                        ret_comm_amt = 0;
                    }
                    tbl = tbl + ret_comm_amt.ToString("F2") + "</td>";

                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["ActualBusiness"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

                    tbl = tbl + "</tr>";
                 
                    if (ds.Tables[0].Rows[i]["RetainerCommision"].ToString() != "")
                    {
                        subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                        totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[i]["RetainerCommision"].ToString());
                    }

                    if (ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString() != "")
                    {
                        subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString());
                        totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[i]["retainer_comm_amount"].ToString());
                    }

                }


            }

            tblgrid.InnerHtml += tbl;
            tbl = "";
        }

        tbl = tbl + ("<tr valign='top' height='25'>");


        tbl = tbl + ("<td class='rep_data2' colspan='2' valign='top'>");
        tbl = tbl + "<b>" + "Sub Total:" + "</b>" + "</td>";
       

        tbl = tbl + ("<td class='rep_data' colspan='12'>");
        tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data' >");
        //tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data' >");
        //tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

       
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data2' align='right' valign='top' >") + "<b>" + subBillAmt.ToString("F2") + "</b>";
        tbl = tbl + "</td>";

      
        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        //tbl = tbl + ("<td class='rep_data'>");
        //tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercomm + "</b>";
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercommamt.ToString("F2") + "</b>";
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='rep_data'>");
        tbl = tbl + "</td>";


        tbl = tbl + "</tr>";


        tbl = tbl + ("<tr >");
      //  tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
       
        tbl = tbl + ("<tr >");


        tbl = tbl + ("<td class='middle31new' colspan='7' valign='top'>");
        tbl = tbl + "<b>" + "Total" + "</b>" + "</td>";


        tbl = tbl + ("<td class='middle31new' colspan='6'>&nbsp;");
        tbl = tbl + "</td>";

       
      
        tbl = tbl + ("<td class='middle31new'  align='right' colspan='2' valign='top'>");
        tbl = tbl +  "Bill Amount: "  + BillAmt.ToString("F2")  + "</td>";
       tbl = tbl + "</td>";


       tbl = tbl + ("<td class='middle31new'  align='right' colspan='2' valign='top'>");
       tbl = tbl + "Retainer Commision Amount: " + totalretainercommamt.ToString("F2") + "</td>";



       tbl = tbl + ("<td class='middle31new'>&nbsp;");
        tbl = tbl + "</td>";

        tbl = tbl + ("<td class='middle31new'  align='right'>&nbsp;");
        tbl = tbl + "</td>";
       

        tbl = tbl + ("<td colspan='5' class='middle31new'>&nbsp;");
        tbl = tbl + "</td>";

        tbl = tbl + "</tr>";


       // tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";


        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;
    

    }

    private void excel(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {
        
        
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        //NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();
        //ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchcode, editionname, Retainercode, Adtypecode);
    

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
        nameColumn.HeaderText = "RetainName";
        nameColumn.DataField = "RetainName";
        name1 = name1 + "," + "RetainName";
        name2 = name2 + "," + "RetainName";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn);

        BoundColumn nameColumn1 = new BoundColumn();
        nameColumn1.HeaderText = "Booking Id";
        nameColumn1.DataField = "CIOID";

        name1 = name1 + "," + "Booking Id";
        name2 = name2 + "," + "CIOID";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

       

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
        nameColumn7.HeaderText = "Publication";
        nameColumn7.DataField = "Publication";

        name1 = name1 + "," + "Publication";
        name2 = name2 + "," + "Publication";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "Edition";
        nameColumn9.DataField = "Edition";

        name1 = name1 + "," + "Edition";
        name2 = name2 + "," + "Edition";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "Area";
        nameColumn10.DataField = "Area";

        name1 = name1 + "," + "Area";
        name2 = name2 + "," + "Area";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "BillStatus";
        nameColumn11.DataField = "BillStatus";

        name1 = name1 + "," + "BillStatus";
        name2 = name2 + "," + "BillStatus";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);

        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "Gross Amt";
        nameColumn12.DataField = "grossamt";

        name1 = name1 + "," + "Gross Amt";
        name2 = name2 + "," + "grossamt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);


        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "AgencyTD(%)";
        nameColumn13.DataField = "AgencyTD(%)";

        name1 = name1 + "," + "AgencyTD(%)";
        name2 = name2 + "," + "AgencyTD(%)";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);


        BoundColumn nameColumn14 = new BoundColumn();
        nameColumn14.HeaderText = "AgencyTDAmt";
        nameColumn14.DataField = "AgencyTDAmt";

        name1 = name1 + "," + "AgencyTDAmt";
        name2 = name2 + "," + "AgencyTDAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn14);

        BoundColumn nameColumn15 = new BoundColumn();
        nameColumn15.HeaderText = "AgencyAddlTD(%)";
        nameColumn15.DataField = "AgencyAddlTD(%)";

        name1 = name1 + "," + "AgencyAddlTD(%)";
        name2 = name2 + "," + "AgencyAddlTD(%)";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn15);


        BoundColumn nameColumn16 = new BoundColumn();
        nameColumn16.HeaderText = "AgencyAddlTDAmt";
        nameColumn16.DataField = "AgencyAddlTDAmt";

        name1 = name1 + "," + "AgencyAddlTDAmt";
        name2 = name2 + "," + "AgencyAddlTDAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn16);

        BoundColumn nameColumn17 = new BoundColumn();
        nameColumn17.HeaderText = "BillAmt";
        nameColumn17.DataField = "BillAmt";

        name1 = name1 + "," + "BillAmt";
        name2 = name2 + "," + "BillAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn17);

        BoundColumn nameColumn18 = new BoundColumn();
        nameColumn18.HeaderText = "Retainer Comm(%)";
        nameColumn18.DataField = "RetainerCommision";

        name1 = name1 + "," + "Retainer Comm(%)";
        name2 = name2 + "," + "RetainerCommision";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn18);

        BoundColumn nameColumn19 = new BoundColumn();
        nameColumn19.HeaderText = "Retainer Comm(Amt)";
        nameColumn19.DataField = "retainer_comm_amount";

        name1 = name1 + "," + "Retainer Comm(Amt)";
        name2 = name2 + "," + "retainer_comm_amount";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn19);

        BoundColumn nameColumn20 = new BoundColumn();
        nameColumn20.HeaderText = "ActualBusiness";
        nameColumn20.DataField = "ActualBusiness";

        name1 = name1 + "," + "ActualBusiness";
        name2 = name2 + "," + "ActualBusiness";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn20);

        BoundColumn nameColumn21 = new BoundColumn();
        nameColumn21.HeaderText = "RevenueCenter";
        nameColumn21.DataField = "RevenueCenter";

        name1 = name1 + "," + "RevenueCenter";
        name2 = name2 + "," + "RevenueCenter";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn21);

        
        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        DataGrid1.ShowHeader = true;
        DataGrid1.ShowFooter = true;
        DataGrid1.DataBind();
       // hw.Write("<p align=\"center\">Retainer Commision Report");
       //hw.Write("<p align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
        hw.Write("<p <table border =\"1\"> <tr> <td align=\"center\" colspan=\"19\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
        hw.Write("<p <tr> <td align=\"center\" colspan=\"19\"><b>Retainer Commision Report</b></td></tr>");
        hw.Write("<p <tr> <td align=\"left\" colspan=\"5\"><b>Publication:</b>" + lblproduct.Text + "</td><td colspan=\"5\"> <b>Edition:</b>" + lbledition.Text + "</td><td colspan=\"5\"> <b>Run Date:</b>" + lbldate.Text + "</td></tr>");
        hw.Write("<p <tr> <td align=\"left\" colspan=\"5\"><b>Region:</b>" + lblregion.Text + "</td><td colspan=\"5\"> <b>Branch:</b>" + lblbranch.Text + "</td><td colspan=\"5\"> <b>Retainer:</b>" + lblretainer.Text + "</td></tr>");
        hw.Write("<p <tr> <td align=\"left\" colspan=\"5\"><b>Date From:</b>" + lblfrom.Text + "</td><td colspan=\"5\"> <b>AdType:</b>" + lbladtype11.Text + "</td><td colspan=\"5\"> <b>Date To:</b>" + lblto.Text + "</td></tr>");

        //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Retainer Commision Report<b>");



        DataGrid1.RenderControl(hw);

        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td>" + "" + "</td><td align=\"center\" colspan=\"3\">TOTAL</td><td align=\"right\" colspan=\"8\"></td><td></td><td></td><td>" + amtnew + "<td align=\"center\" >" + "" + "</td><td align='right'>" + totalcommission + "</td><td></td></tr></table>"));
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
    

    private void pdf(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {


       DataSet pdfxml = new DataSet();
       pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));

       //DataSet ds = new DataSet();

       //NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();
       //ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchcode, editionname, Retainercode, Adtypecode);
    

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



     
        int NumColumns = 19;

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
            tbl.addCell(new iTextSharp.text.Phrase("Retainer Commision Report", font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;

            document.Add(tbl);


            //PdfPTable datatable = new PdfPTable(NumColumns);
            //datatable.DefaultCell.Padding = 1;


            //datatable.WidthPercentage = 100; // percentage
            //datatable.DefaultCell.BorderWidth = 0;
            //datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


            //PdfPTable datatablecenter = new PdfPTable(NumColumns);
            //datatablecenter.DefaultCell.Padding = 1;


            //datatablecenter.WidthPercentage = 100; // percentage
            //datatablecenter.DefaultCell.BorderWidth = 0;
            //datatablecenter.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            float[] headerwidths9 = { 10, 15, 12, 14, 12, 19 };

            PdfPTable datatablecenter = new PdfPTable(headerwidths9);
            datatablecenter.DefaultCell.Padding = 1;


            datatablecenter.WidthPercentage = 100; // percentage
            datatablecenter.DefaultCell.BorderWidth = 0;
            datatablecenter.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;

           
           
            //PdfPTable tbl11 = new PdfPTable(1);
            //tbl11.DefaultCell.BorderWidth = 0;
            //tbl11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //tbl11.addCell("");
            //tbl11.WidthPercentage = 100;


            //int i11;
            //for (i11 = 0; i11 < 3; i11++)
            //{
            //    document.Add(tbl11);
            //}


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


            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("EDITION:", font10));
            if (editioncode == "0" || editioncode == "")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(editionname.ToString(), font10));
            }

            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("RUN DATE:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(date.ToString(), font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));


            datatablecenter.addCell(new iTextSharp.text.Phrase("REGION:", font10));
            if (region == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(regionname.ToString(), font10));
            }

            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("BRANCH:", font10));
            if (branchcode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(branchname.ToString(), font10));
            }


            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("RETAINER:", font10));
            if (Retainercode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(Retainername.ToString(), font10));
            }

            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));


            datatablecenter.addCell(new iTextSharp.text.Phrase("DATE FROM:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(fromdt.ToString(), font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("AD TYPE:", font10));
            if (Adtypecode == "0")
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase("ALL", font10));
            }
            else
            {
                datatablecenter.addCell(new iTextSharp.text.Phrase(Adtypename.ToString(), font10));
            }

            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase("DATE TO:", font10));
            datatablecenter.addCell(new iTextSharp.text.Phrase(dateto.ToString(), font10));
            //datatablecenter.addCell(new iTextSharp.text.Phrase("", font10));

            document.Add(datatablecenter);






            /*********************      for spacing after heading     ***********************/

            iTextSharp.text.Phrase p111 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p111);


            /*********************    for subheadings   ********************/
           float[] headerwidths = { 10, 15, 12, 14, 12, 19, 18, 10, 17, 18, 15, 15, 15, 15, 14, 19, 19, 14, 15 };

           PdfPTable datatable = new PdfPTable(headerwidths);
            datatable.DefaultCell.Padding = 1;


            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;

           
           
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[51].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));

            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[83].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[91].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[92].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[93].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[94].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[95].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[96].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[97].ToString(), font10));
            datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));

            //datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[52].ToString(), font10));
            //datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[70].ToString(), font10));
            //datatable.addCell(new iTextSharp.text.Phrase(pdfxml.Tables[0].Rows[0].ItemArray[71].ToString(), font10));


                document.Add(datatable);

            /*********************    for subheadings   ********************/

                iTextSharp.text.Phrase p11 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
                document.Add(p11);

            /*********************      for spacing after subheading     ***********************/

            PdfPTable tbl1 = new PdfPTable(NumColumns);
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


            float[] headerwidths122 = { 10, 15, 12, 14, 12, 19, 18, 10, 17, 18, 15, 15, 15, 15, 14, 19, 19, 14, 15 };
            PdfPTable datatable1 = new PdfPTable(headerwidths122);
            datatable1.DefaultCell.Padding = 1;
            datatable1.WidthPercentage = 100; // percentage
            datatable1.DefaultCell.BorderWidth = 0;
            datatable1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            //datatable1.addCell(new iTextSharp.text.Phrase("Sr.No", font10));
           
            float area = 0;
            double BillAmt = 0.00;
            double subBillAmt = 0.00;
            double totalretainercomm = 0.00;
            double subretainercomm = 0.00;
            double totalBillAmt = 0.00;
            double totalretainercommamt = 0.00;
            double subretainercommamt = 0.00;

           

            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {

                if (k > 0)
                {
                    if ((ds.Tables[0].Rows[k]["RetainName"].ToString()) == (ds.Tables[0].Rows[(k - 1)]["RetainName"].ToString()))
                    {

                        
                        datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Edition"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["grossamt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyTD(%)"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyTDAmt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyAddlTD(%)"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyAddlTDAmt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["ActualBusiness"].ToString(), font10));                   
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));

                        if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                        {
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                            subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                        }
                        if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
                        {
                            subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                            totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                        }

                        if (ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString() != "")
                        {
                            subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString());
                            totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString());
                        }


                        //if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                        //{
                        //    subBillAmt = subBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                        //    totalBillAmt = totalBillAmt + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                        //}

                        //if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                        //{
                        //    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                        //    subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                        //}
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
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
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
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));
                        datatable1.addCell(new iTextSharp.text.Phrase("", font10));

                        /***************************************************************/

                        

                        datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainName"].ToString(), font10));
                       

                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Edition"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["grossamt"].ToString(), font10));
                       
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyTD(%)"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyTDAmt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyAddlTD(%)"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyAddlTDAmt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["ActualBusiness"].ToString(), font10));
                        datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));


                        if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                        {
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                            subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                        }
                        if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
                        {
                            subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                            totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                        }

                        if (ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString() != "")
                        {
                            subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString());
                            totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString());
                        }


                        //if (ds.Tables[0].Rows[k]["BillAmt"].ToString() != "")
                        //{
                        //    subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                        //    totalBillAmt = totalBillAmt + double.Parse(ds.Tables[0].Rows[k]["BillAmt"].ToString());
                        //}

                        //if (ds.Tables[0].Rows[k]["RetainerCommision"].ToString() != "")
                        //{
                        //    subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                        //    totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[k]["RetainerCommision"].ToString());
                        //}
                    }
                }
                else
                {
                    datatable1.addCell(new iTextSharp.text.Phrase((k + 1).ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainName"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString(), font10));
                    //datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Card_Rate"].ToString(), font10));

                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainName"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["CIOID"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Agency"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Client"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Publication"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Edition"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["Area"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillStatus"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["grossamt"].ToString(), font10));
                  
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyTD(%)"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyTDAmt"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyAddlTD(%)"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["AgencyAddlTDAmt"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["BillAmt"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RetainerCommision"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["retainer_comm_amount"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["ActualBusiness"].ToString(), font10));
                    datatable1.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[k]["RevenueCenter"].ToString(), font10));
                       

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

            PdfPTable datatable11 = new PdfPTable(NumColumns);
            datatable11.DefaultCell.Padding = 1;
            datatable11.WidthPercentage = 100; // percentage
            datatable11.DefaultCell.BorderWidth = 0;
            datatable11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            datatable11.addCell(new iTextSharp.text.Phrase("Total", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            //datatabletotal.addCell(new iTextSharp.text.Phrase("Bill Amount:", font10));
            datatable11.addCell(new iTextSharp.text.Phrase(totalBillAmt.ToString(), font10));
            //datatabletotal.addCell(new iTextSharp.text.Phrase("Retainer Commision:", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase(totalretainercomm.ToString(), font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));
            datatable11.addCell(new iTextSharp.text.Phrase("", font10));


            document.Add(datatable11);

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


  

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string retainernamechk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (retainernamechk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }
     

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
        string check2 = e.Item.Cells[16].Text;
        string billarea = e.Item.Cells[16].Text;

        if (check2 != "Retainer Comm(Amt)")
        {
            if (check2 != "&nbsp;")
            {


                string billarea1 = e.Item.Cells[16].Text;
                billarea2 = Convert.ToDouble(billarea1);
                totalcommission = totalcommission + billarea2;


            }
        }
   
    }
    protected void btnprint_Click1(object sender, EventArgs e)
    {

        Session["prm_retaincom_print"] = "fromdate~" + fromdt + "~dateto~" + dateto + "~regioncode~" + region + "~regionname~" + regionname + "~productcode~" + product + "~productname~" + productname + "~editioncode~" + editioncode + "~editionname~" + editionname + "~branchcode~" + branchcode + "~branchname~" + branchname + "~Adtypecode~" + Adtypecode + "~Adtypename~" + Adtypename + "~Retainercode~" + Retainercode + "~Retainername~" + Retainername;
        Response.Redirect("retaincomviewprint.aspx");
//    Response.Redirect("retaincomviewprint.aspx?&fromdate=" + fromdt + "&dateto=" + dateto + "&regioncode=" + region + "&regionname=" + regionname + "&productcode=" + product + "&productname=" + productname + "&editioncode=" + editioncode + "&editionname=" + editionname + "&branchcode=" + branchcode + "&branchname=" + branchname + "&Adtypecode=" + Adtypecode + "&Adtypename=" + Adtypename + "&Retainercode=" + Retainercode + "&Retainername=" + Retainername);
    }
}