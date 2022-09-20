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

public partial class testnewsambad_supp : System.Web.UI.Page
{

    static string ciobookid = "";
    static string checkradio = "";
    static string insertion = "";
    static string editionbill = "";
    static string spl_dis = "";
    static string trad_dis = "";

    static int a = 0;
    static int b = 1;
    static int i1 = 0;
    string branch;

    static string invoice_no = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {
            //ciobookid = Request.QueryString["ciobookid"].ToString();
            //checkradio = Request.QueryString["checkradio"].ToString();
            //insertion = Request.QueryString["insertion"].ToString();
            //editionbill = Request.QueryString["edition"].ToString();

            //invoice_no = Request.QueryString["invoice"].ToString();




            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            editionbill = Session["billing_edition"].ToString();
            invoice_no = Session["invoice"].ToString();
            editionbill = editionbill.Replace("^", "+");
            spl_dis = Session["spl_dis"].ToString();
            trad_dis = Session["trade_dis"].ToString();



            hiddendateformat.Value = Session["dateformat"].ToString();
            //  Session["insertionformat"] = "pune";  

        }

        string[] countbookid1 = ciobookid.Split(',');
        int c4 = countbookid1.Length;
        BindPrintFormreprint(ciobookid, c4, insertion, editionbill, invoice_no);


        /*  string myscript1 = "<script language='Javascript'>";
          myscript1 += "custom_print();";

          myscript1 += "</script>";
          if (!Page.IsStartupScriptRegistered("clientScript"))
          {
              Page.RegisterStartupScript("clientScript", myscript1);       }




          string myscript = "<script language='Javascript'>";
          myscript += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.close();";
          myscript += "</script>";
          if (!Page.IsStartupScriptRegistered("clientScript"))
          {
              Page.RegisterStartupScript("clientScript", myscript);
          }
                   */
    }
    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string editionbill, string invoice_no)
    {


        int i3;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] invoice_no1 = invoice_no.Split(',');
        string[] editionbill2 = editionbill.Split(',');
        string[] spl_dis1 = spl_dis.Split(',');
        string[] trade_dis1 = trad_dis.Split(',');
        DataSet ds4 = new DataSet();



        string invoice_new = invoice_no1[i1].ToString();
        string ciobookingid = countbookid2[i1].ToString();
        string insertionnew = insertion2[i1].ToString();
        string editionname = editionbill2[i1].ToString();

        DataSet ds5 = new DataSet();

        for (i3 = 0; i3 < count; i3++)
        {
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
            //    ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);
            //}
            //else
            //{

            //    NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            //    ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);

            //}

            //int countbill = ds5.Tables[0].Rows.Count;






            int i = 0;



            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {


                NewAdbooking.BillingClass.Classes.billing_save_supp objpkg = new NewAdbooking.BillingClass.Classes.billing_save_supp();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString());
            }
            else
            {

                NewAdbooking.BillingClass.classesoracle.billing_save_supp objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save_supp();
                ds1 = objpkg.packagecode_bill(countbookid2[i3], Session["compcode"].ToString(), Session["dateformat"].ToString());

            }


            int count1 = ds1.Tables[0].Rows.Count;
            branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            string no_of_insertion = insertionnew.ToString();
            string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

            int count11 = Convert.ToInt16(no_of_insertion);


            string[] packagecode1 = packagecode2.Split(',');
            int c1 = packagecode1.Length;

            DataSet ds3 = new DataSet();

            int i11 = 1;
            int packlength = 1;

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
            {

                sambad_supp objcard = new sambad_supp();
                objcard = (sambad_supp)(Page.LoadControl("sambad_supp.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);

                objcard.invoiceno = invoice_no1[i3];
                objcard.packagelength = c1.ToString();
                //  objcard.insertion = i11.ToString();
                objcard.insertion = insertion2[i3].ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = bookingd;
                // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.qbc = branch;
                objcard.editionnameplus = editionname.ToString();
                objcard.setcard();



            }
            else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {


                    punebillre objcard = new punebillre();
                    objcard = (punebillre)(Page.LoadControl("punebillre.ascx"));
                    objcard.valueofradio = checkradio.ToString();
                    placeholder1.Controls.Add(objcard);

                    objcard.invoiceno = invoice_no1[i3];
                    objcard.packagelength = c1.ToString();
                    objcard.insertion = i11.ToString();
                    objcard.packagecode = packagecode2.ToString();
                    objcard.id = ciobookingid1.ToString();
                    objcard.totalinsertion = no_of_insertion.ToString();
                    objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                    objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                    objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                    objcard.qbc = branch;
                    objcard.editionnameplus = editionname.ToString();
                    objcard.setcard();
                }

                else
                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
                    {
                        prhaarre objcard = new prhaarre();
                        objcard = (prhaarre)(Page.LoadControl("prhaarre.ascx"));



                        objcard.valueofradio = checkradio.ToString();
                        placeholder1.Controls.Add(objcard);

                        objcard.invoiceno = invoice_no1[i3];
                        objcard.packagelength = c1.ToString();
                        objcard.insertion = i11.ToString();
                        objcard.packagecode = packagecode2.ToString();
                        objcard.id = ciobookingid1.ToString();
                        objcard.totalinsertion = no_of_insertion.ToString();
                        objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                        objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                        objcard.qbc = branch;
                        objcard.editionnameplus = editionname.ToString();
                        objcard.setcard();
                    }


                    else
                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "udayvani")
                        {
                            udayvani_bill objcard = new udayvani_bill();
                            objcard = (udayvani_bill)(Page.LoadControl("udayvani_bill.ascx"));


                            // Abp_bill objcard = new Abp_bill();
                            //objcard = (Abp_bill)(Page.LoadControl("Abp_bill.ascx"));


                            objcard.valueofradio = checkradio.ToString();
                            placeholder1.Controls.Add(objcard);

                            objcard.invoiceno = invoice_no1[i3];
                            objcard.packagelength = c1.ToString();
                            objcard.insertion = i11.ToString();
                            objcard.packagecode = packagecode2.ToString();
                            objcard.id = ciobookingid1.ToString();
                            objcard.totalinsertion = no_of_insertion.ToString();
                            objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                            objcard.qbc = branch;
                            objcard.editionnameplus = editionname.ToString();
                            objcard.setcard();

                        }

                        else
                            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pratidin" && (Session["bill_cycle1"].ToString() == "2" || Session["bill_cycle1"].ToString() == "3" || Session["bill_cycle1"].ToString() == "4" || Session["bill_cycle1"].ToString() == "5"))
                            {
                                for (int korg = 1; korg <= 3; korg++)
                                {
                                    string street = "";
                                    double finalamount = 0;
                                    double discountint = 0;
                                    double grossamt = 0;
                                    double traddis = 0;
                                    double adddis = 0;
                                    double addchr = 0;
                                    int totinsertnewint = 0;
                                    double finalamount1 = 0;
                                    double amt5 = 0;
                                    double pageprem_amt = 0;
                                    double PagePrem = 0;
                                    double cardamount = 0;
                                    double positionpremium = 0;
                                    double extraposamt = 0;
                                    //
                                    double bill_amt = 0;
                                    double bill_amt1 = 0;
                                    double amt2 = 0;
                                    double amt3 = 0;
                                    double amt4 = 0;
                                    double amountinckudingbox = 0;
                                    double packrate = 0;
                                    double packrate1 = 0;
                                    double premiumper = 0;
                                    double premiumper1 = 0;
                                    double spcharges = 0;
                                    double spdes = 0;
                                    double dispr = 0;
                                    double boxchg1 = 0;
                                    double boxchg2 = 0;
                                    string dytbl = "";
                                    string i12 = i11.ToString();
                                    DataSet dk1 = new DataSet();
                                    string packagecode11 = packagecode2.ToString();
                                    string[] packagecode3 = packagecode11.Split(',');
                                    string invoice1 = invoice_no.ToString();
                                    string[] invoc12 = invoice1.Split(',');
                                    string tedition = "";
                                    int pk1 = packagecode3.Length;
                                    for (int k1 = 0; k1 < pk1; k1++)
                                    {
                                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                        {
                                            NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                                            dk1 = objedition.edition(packagecode1[k1], Session["compcode"].ToString());
                                        }
                                        else
                                        {
                                            NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                                            dk1 = objedition.edition(packagecode1[k1], Session["compcode"].ToString());

                                        }
                                        if (tedition == "")
                                        {
                                            tedition = dk1.Tables[0].Rows[0].ItemArray[0].ToString();
                                        }
                                        else
                                        {
                                            tedition = tedition + "+" + dk1.Tables[0].Rows[0].ItemArray[0].ToString();
                                        }

                                    }
                                    string[] tedition_count = tedition.Split('+');
                                    int tedit = tedition_count.Length;

                                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                    {
                                        NewAdbooking.BillingClass.Classes.billing_save_supp objvalues = new NewAdbooking.BillingClass.Classes.billing_save_supp();
                                        ds4 = objvalues.values_bill_p(invoc12[i3].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                    }
                                    else
                                    {
                                        //NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                                        //ds4 = objvalues.values_bill(ciobookingid, tedition_count[p1].Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                    }
                                    int rownum = ds4.Tables[0].Rows.Count;
                                    int maxlimit = 13;
                                    int ct = 0;
                                    int fr = maxlimit;

                                    int pagec = rownum % maxlimit;
                                    int pagecount = rownum / maxlimit;
                                    if (pagec > 0)
                                    {
                                        pagecount = pagecount + 1;
                                    }

                                    for (int p1 = 0; p1 < pagecount; p1++)
                                    {
                                        ct = maxlimit * p1;
                                        fr = maxlimit * (p1 + 1);

                                        pratidinbill_f_supp obj_RCB = new pratidinbill_f_supp();
                                        obj_RCB = (pratidinbill_f_supp)Page.LoadControl("pratidinbill_f_supp.ascx");
                                        //DataSet ds_xml = new DataSet();

                                        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                        //{
                                        //    NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                                        //    ds4 = objvalues.values_bill_p(invoc12[p1].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                        //}
                                        //else
                                        //{
                                        //    //NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                                        //    //ds4 = objvalues.values_bill(ciobookingid, tedition_count[p1].Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                        //}

                                        //ds_xml.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
                                        DataSet dsb = new DataSet();
                                        dsb.ReadXml(Server.MapPath("XML/pratidin.xml"));

                                        if (korg == 1)
                                        {
                                            obj_RCB.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (korg == 2)
                                        {
                                            obj_RCB.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[10].ToString();
                                        }
                                        else
                                        {
                                            obj_RCB.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[11].ToString();
                                        }
                                        obj_RCB.agddxt1 = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
                                        street = ds4.Tables[0].Rows[0]["street"].ToString();
                                        obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["add1"].ToString();
                                        obj_RCB.lbaddress2 = obj_RCB.lbaddress1 + "," + street;
                                        obj_RCB.lbcityname1 = ds4.Tables[0].Rows[0]["city_name"].ToString();
                                        obj_RCB.txtpinno1 = ds4.Tables[0].Rows[0]["pin_code"].ToString();
                                        obj_RCB.lblcode1 = ds4.Tables[0].Rows[0]["agency_cod"].ToString();
                                        if (ds4.Tables[0].Rows[0]["Box_Charge"].ToString() != "" && ds4.Tables[0].Rows[0]["Box_Charge"].ToString() != null)
                                        {
                                            obj_RCB.lblboxchrg1 = ds4.Tables[0].Rows[0]["Box_Charge"].ToString();
                                        }
                                        else
                                        {
                                            obj_RCB.lblboxchrg1 = "-";
                                        }
                                        if (ds4.Tables[0].Rows[0]["Extra"].ToString() != "")
                                        {
                                            obj_RCB.lblexamt_col1 = ds4.Tables[0].Rows[0]["Extra"].ToString();
                                        }
                                        else
                                        {
                                            obj_RCB.lblexamt_col1 = "-";
                                        }
                                        if (ds4.Tables[0].Rows[0]["pag_prem"].ToString() != "" && ds4.Tables[0].Rows[0]["pag_prem"].ToString() != null)
                                        {
                                            PagePrem = Convert.ToDouble(ds4.Tables[0].Rows[0]["pag_prem"].ToString());
                                        }
                                        if (ds4.Tables[0].Rows[0]["Pag_amt"].ToString() != "" && ds4.Tables[0].Rows[0]["Pag_amt"].ToString() != null)
                                        {
                                            positionpremium = Convert.ToDouble(ds4.Tables[0].Rows[0]["Pag_amt"].ToString());
                                        }
                                        if (ds4.Tables[0].Rows[0]["Amt"].ToString() != "" && ds4.Tables[0].Rows[0]["Amt"].ToString() != null)
                                        {
                                            cardamount = Convert.ToDouble(ds4.Tables[0].Rows[0]["Amt"].ToString());
                                        }
                                        //location
                                        obj_RCB.lbllocval1 = ds4.Tables[0].Rows[0]["Print_cent_name"].ToString();
                                        grossamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
                                        traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());

                                        obj_RCB.lblexamt_day1 = "-";
                                        if (ds4.Tables[0].Rows[0]["scheme"].ToString() != "" && ds4.Tables[0].Rows[0]["scheme"].ToString() != null)
                                        {
                                            obj_RCB.txtscode1 = ds4.Tables[0].Rows[0]["scheme"].ToString();
                                        }
                                        if (ds4.Tables[0].Rows[0]["rate_code"].ToString() != "")
                                        {
                                            obj_RCB.txtratecode1 = ds4.Tables[0].Rows[0]["rate_code"].ToString();
                                        }

                                        obj_RCB.lbbillno1 = invoice_no1[i3];
                                        obj_RCB.lblclientname1 = ds4.Tables[0].Rows[0]["advertiser"].ToString();

                                        dytbl = "";
                                        dytbl += "<table width='660px' align='left' cellpadding='0' cellspacing='0' >";
                                        {
                                            //DataSet dsb = new DataSet();
                                            //dsb.ReadXml(Server.MapPath("XML/pratidin.xml"));
                                            dytbl += "<tr align=center >";
                                            string tb1 = "";
                                            tb1 += "<table width='250px' cellpadding='0' cellspacing='0' >";
                                            tb1 += "<tr align=center >";
                                            tb1 += "<td colspan='3'align='center' style='border-bottom:solid 1px black'>" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + "</td></tr>";
                                            tb1 += "<tr align=center >";
                                            tb1 += "<td  align='center' style='border-right:solid 1px black' width='80px' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
                                            tb1 += "<td  align='center' style='border-right:solid 1px black' width='80px' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                                            tb1 += "<td  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td></tr></table>";


                                            dytbl += "<td width='90px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
                                            dytbl += "<td width='70px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";
                                            dytbl += "<td width='250px' class='insertiontxtclass1' >" + tb1 + "</td>";
                                            dytbl += "<td width='70px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                                            dytbl += "<td width='80px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                                            dytbl += "<td width='100px' class='insertiontxtclass2' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";

                                            dytbl += "</tr>";
                                        }

                                        for (i = ct; i < rownum && i < fr; i++)
                                        {
                                            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                            //    {
                                            //        NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                                            //        ds4 = objedition1.values_bill_p(invoc12[p1].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                            //    }
                                            //    else
                                            //    {
                                            //        //NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                                            //        //ds4 = objvalues1.values_bill(ciobookingid, tedition_count[i].Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                            //    }
                                            if (ds4.Tables[0].Rows[i].ItemArray[29].ToString() != "")
                                            {
                                                obj_RCB.lblpageval1 = ds4.Tables[0].Rows[i].ItemArray[29].ToString() + "PAGE";
                                            }
                                            obj_RCB.lblisname1 = ds4.Tables[0].Rows[i]["ad_type"].ToString();
                                            obj_RCB.lbldate1 = ds4.Tables[0].Rows[i].ItemArray[28].ToString();

                                            string amt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();
                                            string boxcharges = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
                                            double amt1 = 0;
                                            if (amt != "")
                                            {
                                                amt1 = Convert.ToDouble(amt);
                                            }
                                            amt5 = amt5 + amt1;
                                            string package_rate = ds4.Tables[0].Rows[i].ItemArray[14].ToString();
                                            string premiumper2 = ds4.Tables[0].Rows[i].ItemArray[34].ToString();
                                            if (package_rate != "")
                                            {
                                                packrate = Convert.ToDouble(package_rate);
                                                packrate1 = packrate1 + packrate;
                                            }
                                            if (premiumper2 != "")
                                            {
                                                premiumper = Convert.ToDouble(premiumper2);
                                                premiumper1 = premiumper1 + premiumper;

                                            }

                                            if (boxcharges == "")
                                            {

                                            }
                                            else
                                            {
                                                boxchg1 = Convert.ToDouble(boxcharges) / totinsertnewint;


                                            }
                                            boxchg2 = boxchg1 / c1;

                                            amt2 = amt1 - boxchg2;
                                            amt4 = amt4 + amt2;

                                            amt3 = amt3 + amt1;




                                            if (ds4.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
                                            {
                                                bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                                                //bill_amt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"]).ToString("F2");
                                                //finalamount = Convert.ToDouble(ds4.Tables[0].Rows[0]["Bill_Amt"].ToString());
                                            }
                                            else
                                            {
                                                bill_amt = 0;
                                                //lblnetamt.Text = 0.ToString("F2");
                                                // finalamount = 0;

                                            }

                                            bill_amt1 = bill_amt1 + bill_amt;

                                            //Dynamic Table data
                                            dytbl += "<tr>";


                                            if (ds4.Tables[0].Rows[i]["CIOID"].ToString() != "")
                                            {
                                                dytbl += "<td width=90px class=display  align=center >" + ds4.Tables[0].Rows[i]["CIOID"].ToString() + "</td>";
                                            }
                                            else
                                                dytbl += "<td width=90px  class=display align=center>---</td>";

                                            if (ds4.Tables[0].Rows[i].ItemArray[28].ToString() != "")
                                            {
                                                dytbl += "<td width='70px'  class=display align=center >" + ds4.Tables[0].Rows[i]["date_time"].ToString() + "</td>";

                                            }
                                            else
                                                dytbl += "<td width='70px' class=display align=center>---</td>";

                                            string tb1 = "";
                                            tb1 += "<table width='250px' cellpadding='0' cellspacing='0' >";
                                            tb1 += "<tr align=center >";
                                            tb1 += "<td  align='center' class=display3 width='80px' >" + ds4.Tables[0].Rows[i].ItemArray[28].ToString() + "</td>";
                                            if (ds4.Tables[0].Rows[i].ItemArray[5].ToString() != "")
                                            {
                                                tb1 += "<td  align='center' class=display3 width='80px' >" + ds4.Tables[0].Rows[i].ItemArray[5].ToString() + "*" + ds4.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                                            }
                                            else
                                            {
                                                tb1 += "<td  align='center' class=display3 width='80px' >---</td>";
                                            }
                                            tb1 += "<td  align='center'  width='90px'>" + ds4.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>";
                                            tb1 += "</tr></table>";

                                            dytbl += "<td width='250px'  class=display align=center >" + tb1 + "</td>";

                                            if (ds4.Tables[0].Rows[i]["volume"].ToString() != "")
                                            {
                                                dytbl += "<td width='70px'  class=display align=center >" + ds4.Tables[0].Rows[i]["volume"].ToString() + "</td>";

                                            }
                                            else
                                                dytbl += "<td width='70px' class=display align=center>---</td>";


                                            if (ds4.Tables[0].Rows[i]["uom_name"].ToString() != "")
                                            {
                                                dytbl += "<td width='80px'  class=display align=center >" + ds4.Tables[0].Rows[i]["uom_name"].ToString() + "</td>";

                                            }
                                            else
                                                dytbl += "<td width='80px' class=display align=center>---</td>";

                                            if (ds4.Tables[0].Rows[i]["card_rate"].ToString() != "")
                                            {
                                                dytbl += "<td width='100px'  class=display1 align=center >" + ds4.Tables[0].Rows[i]["card_rate"].ToString() + "</td>";

                                            }
                                            else
                                                dytbl += "<td width='100px' class=display1 align=center>---</td>";



                                            dytbl += "</tr>";

                                            //srl++;

                                        }

                                        dytbl += "</table>";

                                        obj_RCB.dynamictable1 = dytbl;

                                        double amountprem = amt4 * (premiumper1 / 100);
                                        //lb_totalamt.Text = amt4.ToString();
                                        amountprem = amt4 + amountprem - (spcharges + spdes);
                                        double disper1 = amountprem * (dispr / 100);

                                        obj_RCB.lblgross1 = amt5.ToString();
                                        traddis = amt5 * traddis / 100;
                                        obj_RCB.lbltradedis1 = traddis.ToString();
                                        obj_RCB.lbladddis1 = adddis.ToString();
                                        obj_RCB.lbltrade1 = ds4.Tables[0].Rows[0]["trade_disc"].ToString();
                                        // lblboxchrg.Text = addchr.ToString();
                                        obj_RCB.netpay1 = bill_amt1.ToString("F2");
                                        bill_amt1 = bill_amt1 + 0.01;
                                        double amountinckudingbox1 = Math.Round(bill_amt1);
                                        if (cardamount != 0 && PagePrem != 0)
                                        {
                                            pageprem_amt = cardamount * PagePrem / 100;
                                        }
                                        if (pageprem_amt != 0 && positionpremium != 0)
                                        {
                                            extraposamt = (pageprem_amt + cardamount) * positionpremium / 100;
                                            obj_RCB.lblexamt_pos1 = extraposamt.ToString();
                                        }
                                        else
                                        {
                                            obj_RCB.lblexamt_pos1 = "-";
                                        }
                                        if (extraposamt != 0)
                                        {
                                            obj_RCB.lblamt1 = (amt5 - extraposamt).ToString();
                                        }
                                        else
                                        {
                                            obj_RCB.lblamt1 = amt5.ToString();
                                        }
                                        //lblround.Text = amountinckudingbox1.ToString();

                                        ///////////////////////////////////////////////////////////////////////////////////////////////
                                        if (p1 < (pagecount - 1))
                                        {
                                            obj_RCB.trate1 = "none";
                                            //obj_RCB.netamttab1="none";
                                        }
                                        NumberToEngish obj = new NumberToEngish();
                                        obj_RCB.lbwordinrupees1 = obj.changeNumericToWords(obj_RCB.netpay1.ToString()) + "Only";
                                        obj_RCB.setReceiptData();
                                        Page.Controls.Add(obj_RCB);

                                    }
                                }
                            }
                            else
                                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pratidin")
                                {
                                    //udayvani_bill objcard = new udayvani_bill();
                                    //objcard = (udayvani_bill)(Page.LoadControl("udayvani_bill.ascx"));
                                    for (int korg = 1; korg <= 3; korg++)
                                    {

                                        pratidinbill_supp objcard = new pratidinbill_supp();
                                        objcard = (pratidinbill_supp)(Page.LoadControl("pratidinbill_supp.ascx"));

                                        DataSet dsb = new DataSet();
                                        dsb.ReadXml(Server.MapPath("XML/pratidin.xml"));

                                        if (korg == 1)
                                        {
                                            objcard.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (korg == 2)
                                        {
                                            objcard.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[10].ToString();
                                        }
                                        else
                                        {
                                            objcard.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[11].ToString();
                                        }

                                        objcard.valueofradio = checkradio.ToString();
                                        placeholder1.Controls.Add(objcard);

                                        objcard.invoiceno = invoice_no1[i3];
                                        objcard.packagelength = c1.ToString();
                                        objcard.insertion = i11.ToString();
                                        objcard.packagecode = packagecode2.ToString();
                                        objcard.id = ciobookingid1.ToString();
                                        objcard.totalinsertion = no_of_insertion.ToString();
                                        objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                        objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                        objcard.qbc = branch;
                                        objcard.editionnameplus = editionname.ToString();
                                        objcard.setcard();

                                    }
                                }
                                else
                                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "abp")
                                    {

                                        Abp_bill objcard = new Abp_bill();
                                        objcard = (Abp_bill)(Page.LoadControl("Abp_bill.ascx"));

                                        //Abp_bill_pre objcard = new Abp_bill_pre();
                                        //objcard = (Abp_bill_pre)(Page.LoadControl("Abp_bill_pre.ascx"));


                                        objcard.valueofradio = checkradio.ToString();
                                        placeholder1.Controls.Add(objcard);

                                        objcard.invoiceno = invoice_no1[i3];
                                        objcard.packagelength = c1.ToString();
                                        objcard.insertion = i11.ToString();
                                        objcard.packagecode = packagecode2.ToString();
                                        objcard.id = ciobookingid1.ToString();
                                        objcard.totalinsertion = no_of_insertion.ToString();
                                        objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                        objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                        objcard.qbc = branch;
                                        objcard.editionnameplus = editionname.ToString();
                                        objcard.setcard();

                                    }
                                    else
                                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "kannad")
                                        {

                                            kannad_prabha objcard = new kannad_prabha();
                                            objcard = (kannad_prabha)(Page.LoadControl("kannad_prabha.ascx"));


                                            objcard.valueofradio = checkradio.ToString();
                                            placeholder1.Controls.Add(objcard);

                                            objcard.invoiceno = invoice_no1[i3];
                                            objcard.packagelength = c1.ToString();
                                            objcard.insertion = i11.ToString();
                                            objcard.packagecode = packagecode2.ToString();
                                            objcard.id = ciobookingid1.ToString();
                                            objcard.totalinsertion = no_of_insertion.ToString();
                                            objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                            objcard.qbc = branch;
                                            objcard.editionnameplus = editionname.ToString();
                                            objcard.trade1 = trade_dis1[i3];
                                            objcard.spldis1 = spl_dis1[i3];
                                            objcard.setcard();

                                        }


        }

    }
}
