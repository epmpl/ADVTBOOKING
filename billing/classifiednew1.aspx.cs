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

public partial class classifiednew : System.Web.UI.Page
{
    string publication = "";
    string publicationcenter = "";
    string edition = "";
    string fromdt = "";
    string dateto = "";
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string auto = "";
    string rate_audit = "";
    static string ciobookid = "";
    static string checkradio = "";
    static string insertion = "";
    static string editionbill = "";
    int i3 = 0;
    int pagewidth = 1;
    int ii;
    int jj = 1;
    int kk;
    int ll;
    int pagec;
    int pagecount;
    int j;
    int current1;
    string flag;
    static int current;
    static int a = 0;
    static int b = 1;
    static int i1 = 0;
    string branch;
    string qbc;
    static string frmdt = "";
    static string agencycode = "";
    static string client = "";


    static string dateto1 = "";
    string clientnew = "";
    string invoice = "";
    string hiddensession = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {
            //ciobookid = Request.QueryString["ciobookid"].ToString();
            //checkradio = Request.QueryString["checkradio"].ToString();
            //insertion = Request.QueryString["insertion"].ToString();
            ////editionbill = Request.QueryString["edition"].ToString();
            //hiddendateformat.Value = Session["dateformat"].ToString();
            //frmdt = Request.QueryString["frmdt"].ToString();
            //dateto1 = Request.QueryString["dateto"].ToString();
            //agencycode = Request.QueryString["agencycode"].ToString();
            //client = Request.QueryString["client"].ToString();
            //invoice = Request.QueryString["invoice_no"].ToString();

            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
          



        }

        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;

        if (checkradio == "42")
        {


           
            if (!url1.Contains("page"))
            {

                ciobookid = Session["billing_cioid"].ToString();
                checkradio = Session["billing_checkradio"].ToString();
                insertion = Session["billing_insertion"].ToString();
                agencycode = Session["agencycode"].ToString();
                dateto1 = Session["dateto"].ToString();
                frmdt = Session["frmdt"].ToString();
                invoice = Session["invoice"].ToString();
                client = Session["client"].ToString();
                hiddendateformat.Value = Session["dateformat"].ToString();
                hiddensession = Session["hiddensession"].ToString();
     

              
             





            }

          // BindPrintFormreprintmonthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

            BindPrintFormreprintmonthlyn(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

        }
        if (checkradio=="first")
        {
        BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        else
            if (checkradio == "7")
        {

            onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                   // BindPrintreprintlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

        }

    //if (checkradio == "4")
    //{
    //    BindPrintreprintlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

    //}

  
        //string myscript1 = "<script language='Javascript'>";
        //myscript1 += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.print();";
        //myscript1 += "</script>";
        //if (!Page.IsStartupScriptRegistered("clientScript"))
        //{
        //    Page.RegisterStartupScript("clientScript", myscript1);
        //}



    string myscript1 = "<script language='Javascript'>";
    myscript1 += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.print();";
    myscript1 += "</script>";
    if (!Page.IsStartupScriptRegistered("clientScript"))
    {
        Page.RegisterStartupScript("clientScript", myscript1);
    }








    string myscript = "<script language='Javascript'>";
    myscript += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.close();";
    myscript += "</script>";
    if (!Page.IsStartupScriptRegistered("clientScript"))
    {
        Page.RegisterStartupScript("clientScript", myscript);
    }


    }


    private void BindPrintFormreprintmonthly(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client, string invoice, string hiddensession)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split('^');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] invoice1 = invoice.Split(',');

        DataSet ds4 = new DataSet();






        //string agencycodeval = agencycode1[i1].ToString();
        //string ciobookingnew = countbookid2[i1].ToString();
        if (client == "")
        {
            clientnew = "";

        }
        else
        {
            clientnew = client1[i1].ToString();
        }









        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int agcode1;





        for (inew = 0; inew < c4; inew++)
        {


            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahhar")
            {

                prahhar_classified_re objcard = new prahhar_classified_re();
                objcard = (prahhar_classified_re)(Page.LoadControl("prahhar_classified_re.ascx"));

           
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = invoice1[inew].ToString();
            objcard.agcode = agencycode1[inew].ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = countbookid2[inew].ToString();
            objcard.hiddensessionnew = hiddensession.ToString();


            objcard.setcardmonthly();
            }

            else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {
                    punebillclassi_re objcard = new punebillclassi_re();
                    objcard = (punebillclassi_re)(Page.LoadControl("punebillclassi_re.ascx"));           
                    placeholder1.Controls.Add(objcard);
                    objcard.invoiceno = invoice1[inew].ToString();
                    objcard.agcode = agencycode1[inew].ToString();
                     objcard.fromdate = frmdt.ToString();
                     objcard.dateto = dateto1.ToString();
                     objcard.Client = clientnew.ToString();
                     objcard.bookingid = countbookid2[inew].ToString();
                     //objcard.hiddensessionnew = hiddensession.ToString();
                   objcard.setcardmonthly();
                }
                else
                {
                    classifiedcontrol objcard = new classifiedcontrol();
                    objcard = (classifiedcontrol)(Page.LoadControl("classifiedcontrol.ascx"));

           
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = invoice1[inew].ToString();


            objcard.agcode = agencycode1[inew].ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = countbookid2[inew].ToString();
           // objcard.hiddensessionnew = hiddensession.ToString();


            //objcard.setcardmonthly();
                }
        }



    }
    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');

        DataSet ds4 = new DataSet();






        //string agencycodeval = agencycode1[i1].ToString();
        //string ciobookingnew = countbookid2[i1].ToString();
        if (client == "")
        {
            clientnew = "";

        }
        else
        {
            clientnew = client1[i1].ToString();
        }









        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int agcode1;


        for (inew = 0; inew < c4; inew++)
        {

            classifiedcontrol objcard = new classifiedcontrol();
            objcard = (classifiedcontrol)(Page.LoadControl("classifiedcontrol.ascx"));   
        


            placeholder1.Controls.Add(objcard);
            


            objcard.agcode = agencycode1[inew].ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = countbookid2[inew].ToString();


            objcard.setcard();
        }



    }


    private void BindPrintreprintlast(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice1 = invoice.Split(',');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');

        DataSet ds4 = new DataSet();

        if (client == "")
        {
            clientnew = "";

        }
        else
        {
            clientnew = client1[i1].ToString();
        }









        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int agcode1;


        for (inew = 0; inew < countbookid2.Length; inew++)
        {

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
            {

                classifiedcontrol objcard = new classifiedcontrol();
                objcard = (classifiedcontrol)(Page.LoadControl("classifiedcontrol.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.setcardlast();
            }

            else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {
                    punebillre objcard = new punebillre();
                    objcard = (punebillre)(Page.LoadControl("punebillre.ascx"));
                    objcard.valueofradio = checkradio.ToString();
                    placeholder1.Controls.Add(objcard);
                    objcard.bookingid = countbookid2[inew].ToString();
                    objcard.fromdate = frmdt.ToString();
                    objcard.dateto = dateto1.ToString();
                    objcard.invoiceno = invoice1[inew].ToString();
                    objcard.setcardlast();
                }

                else
                {
                    prahhar_classified_re objcard = new prahhar_classified_re();
                    objcard = (prahhar_classified_re)(Page.LoadControl("prahhar_classified_re.ascx"));
                   
                    placeholder1.Controls.Add(objcard);
                    objcard.valueofradio = checkradio.ToString();
                    placeholder1.Controls.Add(objcard);
                    objcard.bookingid = countbookid2[inew].ToString();
                    objcard.setcardlast();
                }



        }



    }


    private void BindPrintFormreprintmonthlyn(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice, string hiddensession)
    {
        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double amt3 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        int agnew;
        double gm = 0;

        string maxdate = "";
        int inew;
        double gros_amt = 0;
        double trade_dis = 0;
        double adtd = 0;


        string dytbl = "";
        string[] bookingid5ag = ciobookid.Split('^');


        string maxinsert = "";

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] invoice1 = invoice.Split(',');
        string agcode = "";
        string Client = "";
        string invoicenn = "";


        DataSet ds4 = new DataSet();
        for (inew = 0; inew < c4; inew++)
        {


            //billformat_classified objcard = new billformat_classified();
            //objcard = (billformat_classified)Page.LoadControl("billformat_classified.ascx");


            amt1 = 0;
            amt2 = 0;
            invoicenn = invoice1[inew];

            agcode = agencycode1[inew];
            // Client = client1[inew];
            string bookingidn = bookingid5ag[inew];
            string[] bookingid4ag = bookingidn.Split(',');

            string bookingidn11 = bookingidn.Replace(",", "','");


            int countlen = bookingid4ag.Length;


            // for (agnew = 0; agnew < countlen; agnew++)
            // {
            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            // ds4 = objvalues1.selectmonthlynew(agcode, fromdate, dateto, bookingid4ag[agnew], Client, Session["dateformat"].ToString(), bookingidn);


            ds4 = objvalues1.selectmonthlynew_b(agcode, fromdate, dateto, bookingidn, Client, Session["dateformat"].ToString(), bookingidn);





            int maxlimit = 50;
            int ct = 0;
            int fr = maxlimit;

            int rcount = ds4.Tables[0].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;
            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }
            dytbl = "";
            int i;
            for (int p1 = 0; p1 < pagecount; p1++)
            {

                dytbl = "";
                billformat_classified objcard = new billformat_classified();
                objcard = (billformat_classified)Page.LoadControl("billformat_classified.ascx");

                objcard.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();

                objcard.lbadtypetxt1 = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
                // objcard.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
                // objcard.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();
                objcard.lbcreditdatetxt1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                objcard.lbwalujadd1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString() + "-" + ds4.Tables[0].Rows[0]["fax2"].ToString();
                objcard.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                //  objcard.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                // objcard.lbnaam1 = "AURANGABAD".ToString();
                objcard.lbbranchtxt1 = ds4.Tables[0].Rows[0]["branch"].ToString();
                //objcard.agencytxt1 = ds4.Tables[0].Rows[0].ItemArray[14].ToString();
                //  objcard.lbagencyaddtxt1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString() + ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["Street"].ToString() + "," + ds4.Tables[0].Rows[0]["Dist_Code"].ToString();
                objcard.lbagencyaddtxt1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString() + "," + ds4.Tables[0].Rows[0]["Dist_Code"].ToString();
                objcard.lbadcattxt1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                objcard.runtxt1 = ds4.Tables[0].Rows[0]["sysdate_new"].ToString();

                objcard.txtinvoice1 = invoicenn.ToString();











                dytbl += "<table width='720px' align='left' cellpadding='1' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    // dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[49].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[39].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";

                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[43].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[44].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[48].ToString() + "</td>";
                    dytbl += "</tr>";
                }




                for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
                {
                    string adsub_catnew = ds4.Tables[0].Rows[i]["adsub_cat"].ToString();
                    char[] adsub_cat = adsub_catnew.ToCharArray();
                    int ch = 0;
                    string adsub_cat1 = "";
                    int len11N = adsub_catnew.Length;




                    //int len11 = bookingid4ag[agnew].Length;

                    // char[] book = bookingid4ag[agnew].ToCharArray();



                    string bookingidn1 = ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString();






                    char[] book = bookingidn1.ToCharArray();
                    int len11 = bookingidn1.Length;



                    int chnew = 0;

                    string addbook = "";


                    //for (chnew = 0; chnew < len11; chnew++)
                    //{

                    //    if (chnew == 0)
                    //    {
                    //        addbook = addbook + book[chnew];
                    //    }
                    //    else if (chnew % 10 != 0)
                    //    {
                    //        addbook = addbook + book[chnew];
                    //    }
                    //    else
                    //    {
                    //        addbook = addbook + "</br>" + book[chnew];
                    //    }





                    //}






                    ////for (ch = 0; ch < len11N; ch++)
                    ////{

                    ////    if (ch == 0)
                    ////    {
                    ////        adsub_cat1 = adsub_cat1 + adsub_cat[ch];
                    ////    }
                    ////    else if (ch % 6 != 0)
                    ////    {
                    ////        adsub_cat1 = adsub_cat1 + adsub_cat[ch];
                    ////    }
                    ////    else
                    ////    {
                    ////        adsub_cat1 = adsub_cat1 + "</br>" + adsub_cat[ch];
                    ////    }





                    ////}


                    string chk_old = bookingidn1;
                    if (i > 0)
                    {

                        if (chk_old != ds4.Tables[0].Rows[i - 1]["Cio_Booking_Id"].ToString())
                        {
                            dytbl += "<tr align=center>";
                            // dytbl += "<td  colspan='12' align='right'   class='insertiontxtclassCLA' ><b>" + amt3 + "</td></b>";  gros_amt,trade_dis,adtd
                            dytbl += "<tr ><td  colspan='4' align=right><b>BOOKINGID</td><td>" + bookingidn1 + "<td><td  align=right><b>Total</td></b><td>" + gros_amt + "</td><td>" + trade_dis + "</td><td>" + adtd + "</td><td>" + amt3 + "</td></tr>";
                            gros_amt = 0; trade_dis = 0; adtd = 0;
                            amt3 = 0;
                            dytbl += "</tr >";

                        }
                    }





                    dytbl += "<tr align=center>";
                    //  dytbl += "<td class='insertiontxtclassCLA' width='200px' >" + addbook + "</td>";
                    // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["No_Insert"].ToString() + "</td>";

                    string DATENEW = ds4.Tables[0].Rows[i]["month"].ToString();
                    string[] DATENEW1 = DATENEW.Split('-');
                    objcard.lbformonthtxt1 = DATENEW1[1].ToString() + DATENEW1[2].ToString();

                    dytbl += "<td class='insertiontxtclassCLA' width='40px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassCLA' width='200px'  >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td  class='insertiontxtclassCLA' width='140px' >" + ds4.Tables[0].Rows[i]["client"].ToString() + "</td>";
                    if (ds4.Tables[0].Rows[i]["RO_No"].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclassCLA' width='60px' >" + ds4.Tables[0].Rows[i]["RO_No"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' >-</td>";
                    }

                    dytbl += "<td  class='insertiontxtclassCLA' width='150px' >" + adsub_catnew + "</td>";



                    if (ds4.Tables[0].Rows[i]["Uom_Alias"].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclassCLA' width='40px' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' >-</td>";
                    }
                    if (ds4.Tables[0].Rows[i]["Col_Name"].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclassCLA' width='35px' >" + ds4.Tables[0].Rows[i]["Col_Name"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill' >-</td>";

                    }

                    if (ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclassCLA' width='35px' >" + ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() + "</td>";
                        gros_amt = gros_amt + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());
                    }
                    if (ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclassCLA' width='35px' >" + ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString() + "</td>";
                        trade_dis = trade_dis + Convert.ToDouble(ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString());
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill' >-</td>";
                    }


                    if (ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString() != "")
                    {
                        dytbl += "<td class='insertiontxtclassCLA' width='35px' >" + Convert.ToDouble(ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString()) + "</td>";

                        adtd = adtd + Convert.ToDouble(ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString());
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill' >-</td>";
                    }

                    dytbl += "<td class='insertiontxtclassCLA' width='35px' >" + ds4.Tables[0].Rows[i]["netamt"].ToString() + "</td>";

                    dytbl += "</tr>";



                    string amt = ds4.Tables[0].Rows[i]["netamt"].ToString();
                    if (amt != "")
                    {
                        amt1 = Convert.ToDouble(amt);
                    }

                    amt2 = amt2 + amt1;
                    amt3 = amt3 + amt1;

                    amt2 = amt2 + 0.01;
                    amt2 = Math.Round(amt2);



                    if (i + 1 == ds4.Tables[0].Rows.Count)
                    {
                        dytbl += "<tr align=center>";
                        // dytbl += "<td  colspan='12' align='right'   class='insertiontxtclassCLA' ><b>" + amt3 + "</td></b>";
                        dytbl += "<tr ><td  colspan='4' align=right><b>BOOKINGID</td><td>" + bookingidn1 + "<td><td  align=right><b>Total</td></b><td>" + gros_amt + "</td><td>" + trade_dis + "</td><td>" + adtd + "</td><td>" + amt3 + "</td></tr>";
                        gros_amt = 0; trade_dis = 0; adtd = 0;

                        dytbl += "</tr >";
                    }


                    if (i == fr - 1)
                    {
                        int p2 = p1 + 1;
                        dytbl += "<tr ><td colspan='10'  width='670px' align=right><b>Continue</td></b><td>" + (p2) + "-" + pagecount + "</td></tr>";

                    }




                }




                ct = ct + maxlimit;
                fr = fr + maxlimit;


                if (p1 == pagecount - 1)
                {


                    objcard.lbtotal1 = "Total".ToString();
                    objcard.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
                    objcard.lbemail1 = "Email";
                    objcard.lbpune1 = "PAN NO.";
                    objcard.EOU1 = "E.&O.E.";
                    objcard.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();
                    string TERMS = "";
                    if (ds4.Tables[0].Rows[0]["branch"].ToString() == "MUMBAI")
                    {
                        TERMS = "MUMBAI".ToString();
                    }
                    else
                    {
                        TERMS = "AURANGABAD".ToString();
                    }

                    string namme1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                    objcard.hidedata1 = "<b>Terms & Condition :1)</b>Payment Should be made in favour of " + namme1 + " 2)Only official receipt issued by us will binding on us.3) Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days from the presentation of the bill,falling which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subjected to " + TERMS + " Jurisdiction only.";
                    objcard.txttotal1 = amt2.ToString("F2");

                }








                dytbl += "</table>";



                objcard.dynamictable1 = dytbl;

                objcard.setReceiptData();



                Page.Controls.Add(objcard);

            }

            //dytbl += "</table>";
            //objcard.dynamictable1 = dytbl;

            //objcard.setReceiptData();



            //Page.Controls.Add(objcard);



            //}






        }

    }


    private void onscreen(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client)
    {

        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        bool flag = true;
        int inew2 = 0;
        int inew = 0;
        int fix = 2;
        double abc = 0;
        double abc1 = 0;
        double amtinpr = 0;
        double abc2 = 0;
        string maxinsert = "";
        string dytbl = "";
        //int flag=0;
        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice1 = invoice.Split(',');

        for (inew = 0; inew < countbookid2.Length; inew++)
        {

            
            string bookingid = countbookid2[inew];
            string invoice2 = invoice1[inew];




            RCB1 obj_RCB1 = new RCB1();
            obj_RCB1 = (RCB1)Page.LoadControl("RCB1.ascx");
            DataSet ds4 = new DataSet();

            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            //ds4 = objvalues1.selectlastnew(bookingid, Session["dateformat"].ToString(), fromdate, dateto);
            ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto);



            int maxlimit = 16;
            int ct = 0;
            int fr = maxlimit;

            int rcount = ds4.Tables[0].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;
            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }
            for (int p1 = 0; p1 < pagecount; p1++)
            {
                RCB1 obj_RCB = new RCB1();
                obj_RCB = (RCB1)Page.LoadControl("RCB1.ascx");

                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
                obj_RCB1.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();
                obj_RCB1.lbcaption1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

                obj_RCB.txtinvoice1 = invoice2.ToString();
                obj_RCB.hidedata1 = "";





                // obj_RCB.agencytxt1 = ds4.Tables[0].Rows[0].ItemArray[14].ToString();

                //if ((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "0") || (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "") || (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != " "))
                //{

                if((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString()!="0")&&(ds4.Tables[0].Rows[0]["Agrred_rate"].ToString()!=""))
               {
                    obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["Agrred_rate"].ToString();

                }
                else
                {
                    obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["PACKAGERATE"].ToString();

                }



                string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
                if (comm1 != "")
                {

                    comm2 = Convert.ToDouble(comm1);
                }
                string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
                if (boxamt1 != "")
                {
                    boxamt2 = Convert.ToDouble(boxamt1);
                }



                //DataSet ds_new = new DataSet();
                //NewAdbooking.BillingClass.classesoracle.billing_save objvalues11 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                //ds_new = objvalues11.FETACH_BILLDATE(invoice2, Session["dateformat"].ToString());

                //obj_RCB.runtxt1 = ds_new.Tables[0].Rows[0]["BILL_DATE"].ToString();

                obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();

               // obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["SYSDATE1"].ToString();
                obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                obj_RCB.lbronodate1 = ds4.Tables[0].Rows[0]["RO_No"].ToString() + "-" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();



                obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

               // obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();

                //obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();
                obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[2].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[2].Rows[0]["Fax3"].ToString();
                obj_RCB.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();





                obj_RCB.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                string grossamt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();


                //if (grossamt != "")
                //{
                //    abc = Convert.ToDouble(grossamt);
                //}

                ////garima
                //abc1 = abc1 + abc;

                // obj_RCB.amount11 = abc.ToString("F2");



                string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
                double pr1 = 0;
                if (pr != "")
                {


                    pr1 = Convert.ToDouble(pr);
                }







                obj_RCB1.lbextpre1 = "Ex.Premium" + "(" + pr1 + ")" + "%";




                string dis = ds4.Tables[0].Rows[0]["td"].ToString();
                double dis1 = 0;
                Double DISCAMT = 0;
                if (dis != "")
                {
                    dis1 = Convert.ToDouble(dis);
                }



                string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
                double disn1 = 0;
                Double DISCADTD = 0;
                if (disn != "")
                {
                    disn1 = Convert.ToDouble(disn);
                }

                obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";


                string packagename = "";
                int p;
                for (p = 0; p < ds4.Tables[1].Rows.Count; p++)
                {
                    if (packagename == "")
                    {
                        packagename = ds4.Tables[1].Rows[p].ItemArray[0].ToString();
                    }
                    else
                    {
                        packagename = packagename + "+" + ds4.Tables[1].Rows[p].ItemArray[0].ToString();
                    }
                }

                obj_RCB.txtpackname1 = packagename.ToString();




                dytbl = "";



                /////////////////////////////////////////// dynamic table  ***************


                int count = ds4.Tables[1].Rows.Count;
                int i;

                dytbl += "<table width='483px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1' align='center' width='145px' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' align='center' width='50px'>" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' align='center'  width='5px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='5px' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='32px' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";

                    dytbl += "</tr>";
                }

                for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
                {
                    dytbl += "<tr align=center>";
                    dytbl += "<td class='insertiontxtclass'align='left' width='145px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center 'width='30px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";



                    dytbl += "<td  class='insertiontxtclass' align='right' width='25px' >" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";

                   // dytbl += "<td class='insertiontxtclass' align='center 'width='50px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";



                    //dytbl += "<td  class='insertiontxtclass' align='right' width='5px' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";

                    if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='center' width='5px' >" + ds4.Tables[0].Rows[i]["Color_code"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill'align='center' >-</td>";

                    }
                    dytbl += "<td class='insertiontxtclass'align='right' width='5px' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
                    //dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + "</td>";
                    string cardrt = ds4.Tables[0].Rows[i]["Card_Rate"].ToString();
                    double cdr = 0;
                    if (cardrt != "")
                    {
                        cdr = Convert.ToDouble(cardrt);
                    }


                    dytbl += "<td class='insertiontxtclass' align='right' width='20px'  >" + cdr.ToString("F2") + "</td>";




                    grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

                    if (grossamt != "")
                    {
                        abc = Convert.ToDouble(grossamt);
                    }

                    abc1 = abc1 + abc;


                    dytbl += "</tr>";

                    maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();





                    dytbl += "</tr>";

                }  //



                if (p1 == pagecount - 1)
                {
                    // flag =1;

                    abc2 = abc1;

                    obj_RCB.txtgr1 = abc1.ToString("F2");


                    amtinpr = ((abc1 * pr1) / 100);
                    obj_RCB.lbextrapre1 = amtinpr.ToString("F2");
                    abc1 = abc1 - amtinpr;
                    obj_RCB.amount11 = abc1.ToString("F2");


                    DISCAMT = abc2 * dis1 / 100;

                    obj_RCB.txtdiscal1 = DISCAMT.ToString("F2");

                    obj_RCB.lbtrade11 = "TD" + "(" + dis + ")" + "%";
                    DISCADTD = abc2 * disn1 / 100;
                    obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");

                    double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT));
                    net = Math.Round(net);
                    obj_RCB.netpay1 = net.ToString("F2");

                    NumberToEngish obj = new NumberToEngish();
                    //obj_RCB.lbwordinrupees1 = obj.changeNumericToWords(netpay.Text) + "Only";


                    obj_RCB.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                    obj_RCB.lbemail1 = "Email";
                    obj_RCB.lbpune1 = "PAN NO.";
                    obj_RCB.EOU1 = "E.&O.E.";
                    obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();

                    string TERMS = "AURANGABAD".ToString();
                    string namme1 = "images/shree.jpg";
                    obj_RCB.insertiontxt1 = ds4.Tables[0].Rows[0]["No_of_insertion"].ToString();
                    obj_RCB.hidedata1 = "Terms & Conditions :1)Payment should be made in favour of <img src='" + namme1 + "'alt=''/> 2)Only official receipt issued by us will be binding on us.3) Objection or complaint regarding the bill if any should be brought to our notice within 15 days from the presentation of the bill,failing which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subject to <font style=font-size:11px;font-weight:bold>" + TERMS + " </font> Jurisdiction only.";

                    abc1 = 0;
                   
                
                }

                dytbl += "</table>";

                obj_RCB.dynamictable1 = dytbl;

                obj_RCB.setReceiptData();

               

                Page.Controls.Add(obj_RCB);
                // placeholder1.Controls.Add(obj_RCB);






            }
            //obj_RCB2.setReceiptData();
            // Page.Controls.Add(obj_RCB2);












        }
    }
}
