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
using System.Data.OracleClient;
using System.Data.SqlClient;

public partial class printpireport : System.Web.UI.Page
{
    int maxlimit = 15;
    string dateto = "", fromdt = "", destination = "", region = "", reg = "";
    string  adtype = "", publname = "", adtypename = "", publication = "";
    string prod = "", product = "", orderby = "";
    int a = 0;
    string day = "", month = "", year = "", date = "", adchk = "", chkorder="",agtype="",agtypetext="";
    int dd2;
    double Area = 0;
    double Amt = 0;
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
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

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
       // maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[27].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        ds = (DataSet)Session["statusad"];

        ds = (DataSet)Session["piproduct"];
        string prm = Session["prm_piproduct_print"].ToString();
        string[] prm_Array = new string[30];
        prm_Array = prm.Split('~');


        dateto = prm_Array[1];// Request.QueryString["dateto"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        destination = prm_Array[5]; //Request.QueryString["destination"].ToString();
        region = prm_Array[7]; //Request.QueryString["region"].ToString();
        reg = prm_Array[9]; //Request.QueryString["regcode"].ToString();
        prod = prm_Array[11]; //Request.QueryString["prodcode"].ToString();
        product = prm_Array[13]; //Request.QueryString["product"].ToString();
        orderby = prm_Array[15]; //Request.QueryString["orderby"].ToString();
        publication = prm_Array[17]; //Request.QueryString["publication"].ToString();
        adtype = prm_Array[19]; //Request.QueryString["adtype"].ToString();

        publname = prm_Array[21]; //Request.QueryString["publname"].ToString();
        adtypename = prm_Array[23]; //Request.QueryString["adtypename"].ToString();
        adchk = prm_Array[25]; //Request.QueryString["adchk"].ToString();
        agtype = prm_Array[27]; //Request.QueryString["agtype1"].ToString();
        agtypetext = prm_Array[29]; //Request.QueryString["agtypetext"].ToString();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
       // heading.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();

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
        lblfrom.Text = fromdt;
        lblto.Text = dateto;
        onscreen(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod);
          
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

    private void onscreen(string fromdt, string dateto, string compcode, string reg, string dateformat, string prod)
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
        //   // ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk);
        //    if (adchk == "1")
        //        ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk, agtypetext);
        //    else
        //        ds = obj.spproductreport(fromdt, dateto, Session["compcode"].ToString(), reg, Session["dateformat"].ToString(), prod, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, adtype, temp4, publication, temp6, temp7, temp8, temp9, temp10, orderby, adchk, agtype);
      
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
       
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        string TBL = "";
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }



        

        if (ds.Tables[0].Rows.Count > 0)
        {
            //TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            if (browser.Browser == "Firefox")
            {
              //  TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                 //   TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;

                if (browser.Browser == "Firefox")
                {
                    if (p != 0)
                    {
                        TBL = TBL + "</table></P>";
                        if (p == pagecount ||p==0)

                            TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    }
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        
                            TBL = TBL + "</table></P>";
                            if (p == pagecount - 1)
                                TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            else
                                TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                        
                    }
                    else if (ver == 6.0)
                    {
                        TBL = TBL + "</table>";
                        if (p == pagecount - 1)
                            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  



               // TBL += "</table>";
               // TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                TBL += "<tr valign='top'>";
                TBL += "<td class='middle111' align='right' colspan='17'>" + "Page  " + s + "  of  " + pagecount;
                TBL += "</td></tr>";

                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";
                //TBL += "<tr></tr>";

                TBL += "<tr>";
                TBL += "<td class='middle31new' valign='top'>" + "S.No." + "</td>";
                if (orderby == "Product")
                {
                    TBL += "<td class='middle31new' align='left' valign='top'>" + "Product" + "</td>";
                }
                if (orderby == "Region")
                {
                    TBL += "<td class='middle31new' align='left' valign='top'>" + "Region" + "</td>";
                }
                if (orderby == "Publication")
                {
                    TBL += "<td class='middle31new' align='left' valign='top'>" + "Publication" + "</td>";
                }
                if (orderby == "Agency Publication")
                {
                    TBL += "<td class='middle31new' align='left' valign='top'>" + "Publication" + "</td>";
                    TBL += "<td class='middle31new' align='left' valign='top'>" + "Agency" + "</td>";
                }
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Booking"+"</br>"+"Id" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Publish"+"</br>"+"Date" + "</td>";
                if (orderby != "Agency Publication")
                {
                    TBL += "<td class='middle31new' align='left' valign='top'>" + "Agency" + "</td>";
                }
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Client" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top' width='3%'>" + "Edition" + "</td>";
                TBL += "<td class='middle31new' valign='top' align='right'>" + "HT" + "</td>";
                TBL += "<td class='middle31new' valign='top' align='right'>" + "WD" + "&nbsp;&nbsp;</td>";
                TBL += "<td class='middle31new' valign='top' align='left'>" + "RO.No" + "</td>";
                TBL += "<td class='middle31new' valign='top' align='left'>" + "RO.Date" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Rate" + "</br>" + "Code" + "</td>";
                TBL += "<td class='middle31new' valign='top' align='left'>" + "Color" + "</td>";
                TBL += "<td class='middle31new'  valign='top' align='right'>" + "Premium" + "&nbsp;&nbsp;</td>";
                TBL += "<td class='middle31new' valign='top' align='left'>" + "Catg" + "</br>" + "Subcat" + "</td>";
                TBL += "<td class='middle31new' align='right' valign='top'>" + "Area" + "</td>";
                TBL += "<td class='middle31new' align='right' valign='top'>" + "Gross</br>Amt" + "</td>";
                TBL += "</tr>";

                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                    if (d > 0)//for adcat total
                    {
                        if ((ds.Tables[0].Rows[d][chkorder].ToString() != ds.Tables[0].Rows[d - 1][chkorder].ToString()))//|| (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString()) || (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))
                        {
                            TBL = TBL + ("<tr style='height:40px'>");
                            TBL = TBL + ("<td class='rep_data2' style='height:50px'>");
                            TBL = TBL + ("<b>" + "Total" + "</b>" + "</td>");


                            for (int abc = 0; abc <= 13; abc++)
                            {
                                TBL = TBL + ("<td class='rep_data2' style='height:50px'>");
                                TBL = TBL + ("</td>");
                            }
                            int i11 = 13;
                            arr1[0] = 0;
                            arr1[1] = 0;
                            for (int j11 = dd2; j11 < a - 1; j11++)
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
                            dd2 = Convert.ToInt32(a - 1);
                            for (int k11 = 0; k11 <= 1; k11++)
                            {
                                TBL = TBL + "<td  align='right' class='rep_data2'>";
                                TBL = TBL + (chk_null(arr1[k11].ToString()));
                                TBL = TBL + "</td>";
                            }
                            TBL = TBL + "</tr>";
                        }
                    }//for adcat total

                    TBL += "<tr>";
                    TBL = TBL + ("<td class='rep_data' valign='top' >");
                    TBL = TBL + (a.ToString() + "</td>");
                    if (orderby == "Product")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Product"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Product"].ToString() != ds.Tables[0].Rows[d - 1]["Product"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Product"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }


                    }
                    if (orderby == "Region")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        // TBL = TBL + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Region"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Region"].ToString() != ds.Tables[0].Rows[d - 1]["Region"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Region"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }
                    }
                    if (orderby == "Publication")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        //TBL = TBL + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Publication"].ToString() != ds.Tables[0].Rows[d- 1]["Publication"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }
                    }
                    if (orderby == "Agency Publication")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        //TBL = TBL + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Publication"].ToString() != ds.Tables[0].Rows[d - 1]["Publication"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }

                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        //string agency11 = "";
                        //string rrr22 = ds.Tables[0].Rows[d]["Agency"].ToString();
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
                        //        agency11 = agency11 + agency1[ch11];
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
                        string chkr = ds.Tables[0].Rows[d]["Agency"].ToString();
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
                        TBL = TBL + (agency1 + "</td>");
                    }

                    TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");

                    //string cid = "";
                    //string rrr1 = ds.Tables[0].Rows[d]["CIOID"].ToString();
                    //char[] cid1 = rrr1.ToCharArray();
                    //int len111 = cid1.Length;
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
                    string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
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
                    TBL = TBL + (cioid1 + "</td>");



                    TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                        if (orderby != "Agency Publication")
                        {

                            TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                            //TBL = TBL + (ds.Tables[0].Rows[d]["Agency"] + "</td>");
                            //string agency1 = "";
                            //string rrr2 = ds.Tables[0].Rows[d]["Agency"].ToString();
                            //char[] agency = rrr2.ToCharArray();
                            //char[] ag = rrr2.ToCharArray();
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
                            string chkr = ds.Tables[0].Rows[d]["Agency"].ToString();
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
                            TBL = TBL + (agency1 + "</td>");
                        }




                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                    //TBL = TBL + (ds.Tables[0].Rows[d]["Client"] + "</td>");
                    //string client1 = "";
                    //string rrr3 = ds.Tables[0].Rows[d]["Client"].ToString();
                    //char[] client = rrr3.ToCharArray();
                    //int len333 = client.Length;
                    //int line33 = 0;
                    //for (int ch1 = 0; ((ch1 < len333) && (line33 < 2)); ch1++)
                    //{

                    //    if (ch1 == 0)
                    //    {
                    //        client1 = client1 + client[ch1];
                    //    }
                    //    else if (ch1 % 15 != 0)
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
                        string der = ds.Tables[0].Rows[d]["Client"].ToString();
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
                    TBL = TBL + (client1 + "</td>");

                    TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Package"] + "</td>");
                    TBL = TBL + ("<td class='rep_data' align='right' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Depth"] + "</td>");
                    TBL = TBL + ("<td class='rep_data' align='right' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Width"] + "&nbsp;&nbsp;</td>");
                    TBL = TBL + ("<td class='rep_data'  valign='top' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["RoNo."] + "</td>");

                    TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Ro.Date"] + "</td>");



                    TBL = TBL + ("<td class='rep_data' valign='top' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Rate"] + "</td>");

                    TBL = TBL + ("<td class='rep_data' valign='top' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Color"] + "</td>");
                    TBL = TBL + ("<td class='rep_data' align='right' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Premium"] + "&nbsp;&nbsp;</td>");

                    TBL = TBL + ("<td class='rep_data' valign='top' align='left' >");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Category"]);// + "</td>");
                    TBL = TBL + "</br>";
                    if (ds.Tables[0].Rows[d]["SubCategory"].ToString() == "0")
                        TBL = TBL + ("</td>");
                    else
                        TBL = TBL + (ds.Tables[0].Rows[d]["SubCategory"] + "</td>");


                    TBL = TBL + ("<td class='rep_data' align='right' valign='top'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Area"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                        Area = Area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());


                    TBL = TBL + ("<td class='rep_data' align='right' valign='top'>");

                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Amt"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["Amt"].ToString() != "")
                        Amt = Amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());
                    
                    TBL += "</tr>";

                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                    //TBL += "<tr></tr>";
                  //  div1.InnerHtml += TBL;
                   // TBL = "";

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }

           
            TBL = TBL + ("<tr><td class='middle1212' align='left' ><b>Total Ads.</b></td>");
            TBL = TBL + ("<td class='middle1212' align='left'>");
            TBL = TBL + (a.ToString() + "</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
           // TBL = TBL + ( "</td>");
            //TBL = TBL + ("<td class='middle1212' >");
           // TBL = TBL + ("</td>");

            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");


            TBL = TBL + ("<td class='middle1212'><b>Total:</b></td>");
            TBL = TBL + ("<td class='middle1212' align='right'>");
            double cal = System.Math.Round(Convert.ToDouble(Area), 2);
            TBL = TBL + (chk_null(cal.ToString()) + "</td>");
            TBL = TBL + ("<td class='middle1212' align='right'  >");
            double cal1 = System.Math.Round(Convert.ToDouble(Amt), 2);
            TBL = TBL + (chk_null(cal1.ToString()) + "</td>");
            TBL = TBL + "</tr>";
            if (browser.Browser == "Firefox")
            {
                TBL = TBL + "</table></P>";

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    TBL = TBL + "</table></P>";

                }
                else if (ver == 6.0)
                {
                    TBL = TBL + "</table>";

                }
            }  
          //  TBL += "</table>";

            div1.Visible = true;
            div1.InnerHtml += TBL;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }

    }
    
}
