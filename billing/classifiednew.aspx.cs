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
//using iTextSharp.text;
using System.IO;
//using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
//using iTextSharp.text.pdf.wmf;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mail;




public partial class classifiednew : System.Web.UI.Page
{




    /// <summary>
    /// /
    /// </summary>
    /// 
    string trade_disc = "";
    string publication = "";
    string No_Insert = "";
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
    string billamtn = "";
    double billamt1 = 0.00;
    double billamt12 = 0.00;
    static string refno = "";
    static string dateto1 = "";
    string clientnew = "";
    string invoice = "";
    string hiddensession = "";
    string hiddenuserid = "";
 
    double volume_total = 0;
    double adddis = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {



            Response.Expires = -1;
            if (Session["compcode"] == null)
            {
                //Response.Redirect("login.aspx");
                //Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
                Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
                return;
            }

            hiddenuserid = Session["userid"].ToString();
            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            invoice = Session["invoice"].ToString();
            if (invoice == "&nbsp;")
                invoice = "";
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();


            //ciobookid = Request.QueryString["ciobookid"].ToString();
            //checkradio = Request.QueryString["checkradio"].ToString();
            //insertion = Request.QueryString["insertion"].ToString();       
            //hiddendateformat.Value = Session["dateformat"].ToString();
            //frmdt = Request.QueryString["frmdt"].ToString();
            //dateto1 = Request.QueryString["dateto"].ToString();
            //agencycode = Request.QueryString["agencycode"].ToString();
            //client = Request.QueryString["client"].ToString();
            //invoice = Request.QueryString["invoice_no"].ToString();




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


                //ciobookid = Request.QueryString["ciobookid"].ToString();
                //checkradio = Request.QueryString["checkradio"].ToString();
                //insertion = Request.QueryString["insertion"].ToString();           
                //hiddendateformat.Value = Session["dateformat"].ToString();
                //frmdt = Request.QueryString["frmdt"].ToString();
                //dateto1 = Request.QueryString["dateto"].ToString();
                //agencycode = Request.QueryString["agencycode"].ToString();
                //client = Request.QueryString["client"].ToString();
                //invoice = Request.QueryString["invoice_no"].ToString();
                //hiddensession = Request.QueryString["hiddensession"].ToString();




            }

            // BindPrintFormreprintmonthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "udayvani")
            {
               // BindPrintFormreprintmonthlyn_uday(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

            }
            else
            {
                BindPrintFormreprintmonthlyn(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);
            }

        }
        if (checkradio == "first")
        {
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
            {
                onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, trade_disc);

            }
            //BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        else
            if (checkradio == "7")
            {
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {
                    onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, trade_disc);

                }
                else
                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "upkar")
                {

                  //  onscreen_upkar(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);
                }

                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "haribhoomi")
                {
                    onscreen_haribhoomi(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);


                }
                else
                {
                    onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, trade_disc);
                    //   onscreen_haribhoomi(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);


                }
                // pdf_drillout(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);
                // BindPrintreprintlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

            }




        string myscript1 = "<script language='Javascript'>";
        myscript1 += "custom_print();";


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

    private void onscreen_haribhoomi(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    {
        //double NEWGROSSAMT = 0.0;
        //  string grossamt = "";
        string day = "";
        string month = "";
        string year = "";
        string date = "";
        double amt1 = 0;
        double amt2 = 0;
        bool flag = true;
        int inew2 = 0;
        int inew = 0;
        int fix = 2;
        int maxlimit12 = 2;
        int cnt = 1;
        double abc = 0;
        double comm2 = 0;
        double boxamt2 = 0;
        double abc1 = 0;
        double amtinpr = 0;
        double abc2 = 0;
        string maxinsert = "";
        string dytbl = "";
        double volume = 0;
        double height1 = 0;
        double width1 = 0;
        double ext = 0;
        double grs = 0;
        double totalam = 0;
        //int flag=0;
        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice1 = invoice.Split(',');
        //    double abc_bill = 0;
        //   double abc1_bill = 0;
        //   string bill_amt = "";
        //   string BOOKING_TYPE = "";

        for (inew = 0; inew < countbookid2.Length; inew++)
        {
            // NEWGROSSAMT = 0.0;
            string bookingid = countbookid2[inew];
            string invoice2 = invoice1[inew];
            haribhoomi_billnew1 obj_RCB1 = new haribhoomi_billnew1();
            //
            obj_RCB1 = (haribhoomi_billnew1)Page.LoadControl("haribhoomi_billnew1.ascx");
            DataSet ds4 = new DataSet();

            if (inew == countbookid2.Length - 1)
            {
                obj_RCB1.chkvalue_length = "no";
            }
            else
            {
                obj_RCB1.chkvalue_length = "yes";
            }
            if (invoice2 == "&nbsp;")
            {
                invoice2 = "";
            }


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
                ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());

            }

            //   DataSet dt = new DataSet();
            // NewAdbooking.BillingClass.classesoracle.billing_save ins = new NewAdbooking.BillingClass.classesoracle.billing_save();
            // dt = ins.update_printcount(invoice2, Session["compcode"].ToString());
            int maxlimit = 35;
            int ct = 0;
            int srl = 1;
            //  int i = 1;
            int fr = maxlimit;
            int rcount = ds4.Tables[0].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;
            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }

            double billamt = 0;

            double grossbillamt = 0;
            for (int p1 = 0; p1 < pagecount; p1++)
            {
                haribhoomi_billnew1 obj_RCB = new haribhoomi_billnew1();
                obj_RCB = (haribhoomi_billnew1)Page.LoadControl("haribhoomi_billnew1.ascx");
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                //if (pagecount == 1)
                //{
                //    if (inew == countbookid2.Length - 1)
                //    {
                //        obj_RCB.chkvalue_length = "no";
                //    }
                //    else
                //    {
                //        obj_RCB.chkvalue_length = "yes";
                //    }
                //}
                //else
                //{
                //    if (p1 == pagecount - 1)
                //    {
                //        obj_RCB.chkvalue_length = "no";
                //    }
                //    else
                //    {
                //        obj_RCB.chkvalue_length = "yes";
                //    }

                //}
                if (cnt == maxlimit12)
                {
                    if (inew == 1)
                    {
                        obj_RCB.chkvalue_length2 = "2";
                        obj_RCB.chkvalue_length = "yes";
                        cnt = 1;
                    }
                    else
                    {
                        obj_RCB.chkvalue_length2 = "2";
                        obj_RCB.chkvalue_length = "yes";
                        cnt = 1;
                    }
                }
                else
                {
                    if (inew == 0)
                    {
                        obj_RCB.chkvalue_length2 = "1"; 
                        obj_RCB.chkvalue_length = "yes";
                    }
                    else
                    {
                        obj_RCB.chkvalue_length2 = "3";
                    }

                   // obj_RCB.chkvalue_length = "no";
                    cnt++;
                }
                if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
                {

                    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                    obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
                    obj_RCB.lblagencyname1 = "Agency";
                }
                else
                {
                    if (!string.IsNullOrEmpty(ds4.Tables[0].Rows[0]["agenadd"].ToString()))
                    {
                        string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                        obj_RCB.lbaddress1 = addname[0];
                        obj_RCB.agddxt1 = addname[2];
                    }
                    else
                    {
                        string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                        obj_RCB.lbaddress1 = "";
                        obj_RCB.agddxt1 = "";
                    }
                    obj_RCB.lblagencyname1 = "Client";
                }

                if (obj_RCB.agddxt1 == ds4.Tables[0].Rows[0]["Agency_Name"].ToString())
                {
                    obj_RCB.lbladrelpar1 = "Client";
                    obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();
                }
                else if (obj_RCB.agddxt1 == ds4.Tables[0].Rows[0]["client"].ToString())
                {
                    obj_RCB.lbladrelpar1 = "Agency";
                    obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                }
                else
                {
                    obj_RCB.lbladrelpar1 = "Client";
                    obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();

                }



                //if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
                //{
                //    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                //    obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();

                //}
                //else
                //{
                //    string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                //    obj_RCB.lbaddress1 = addname[0];
                //    obj_RCB.agddxt1 = addname[2];

                //}
                //obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();




                obj_RCB.bill_dt = ds4.Tables[0].Rows[0]["maxdate1"].ToString();

                if (ds4.Tables[0].Rows[0]["Remark"].ToString() != "")
                {

                    obj_RCB.remark = ds4.Tables[0].Rows[0]["Remark"].ToString();
                }
                else
                {
                    obj_RCB.remark = "--";
                }
                obj_RCB.lbcaption1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

                if (invoice2 == "")
                {
                    obj_RCB.txtinvoice1 = "XXXX";
                }
                else
                {

                    obj_RCB.txtinvoice1 = invoice2.ToString();
                }
                obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();


                obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();

                obj_RCB.txtkey1 = ds4.Tables[0].Rows[0]["Key No"].ToString();
                if (ds4.Tables[0].Rows[0]["volume"].ToString() != "")
                {
                    volume_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["volume"].ToString());
                }
                else
                {
                    volume_total = 0.00;
                }

                if (ds4.Tables[0].Rows[0]["special_discount"].ToString() != "")
                {
                    adddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["special_discount"].ToString());

                }
                else
                {
                    adddis = 0.00;
                }

                double spclcharg = volume_total * adddis;
                obj_RCB.lblspchrg = string.Format("{0:0.00}", spclcharg).ToString();

                if (ds4.Tables[0].Rows[0]["pag_prem"].ToString() != "")
                {
                    obj_RCB.lblpageprem = ds4.Tables[0].Rows[0]["pag_prem"].ToString();
                }
                else
                {
                    obj_RCB.lblpageprem = "0.00";
                }

                obj_RCB.hidedata1 = "";
                if ((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "0") && (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != ""))
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

                obj_RCB.unit1 = ds4.Tables[2].Rows[0]["Unit"].ToString();
                string[] addname1 = ds4.Tables[0].Rows[0]["street_login"].ToString().Split("~".ToCharArray());
                obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["address"].ToString();
                obj_RCB.txtmailid1 = addname1[1];

                //obj_RCB.lbemailtxt1 = "Ph:-" + addname1[2] + "-" + addname1[3] + "," + "Fax:-" + addname1[4] + "," + addname1[5];

                //DataSet ds_new = new DataSet();
                //NewAdbooking.BillingClass.classesoracle.billing_save objvalues11 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                //ds_new = objvalues11.FETACH_BILLDATE(invoice2, Session["dateformat"].ToString());
                //obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();
                //obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                obj_RCB.txtrefno1 = ds4.Tables[0].Rows[0]["RO_No"].ToString();
                obj_RCB.txtrodate1 = ds4.Tables[0].Rows[0]["RO_Date"].ToString();
                if (ds4.Tables[0].Rows[0]["Caption"].ToString() != "" || ds4.Tables[0].Rows[0]["Product"].ToString() != "" ||ds4.Tables[0].Rows[0]["Product"].ToString()!="--")
                {
                    obj_RCB.publication_value1 = ds4.Tables[0].Rows[0]["Caption"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["Product"].ToString();
                }
                else if (ds4.Tables[0].Rows[0]["Caption"].ToString() != "")
                {
                    obj_RCB.publication_value1 = ds4.Tables[0].Rows[0]["Caption"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
                }
                else if (ds4.Tables[0].Rows[0]["Product"].ToString() != "" || ds4.Tables[0].Rows[0]["Product"].ToString() != "--")
                {
                    obj_RCB.publication_value1 = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["Product"].ToString();
                }
                else
                {
                    obj_RCB.publication_value1 = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
                }

                obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();
                //obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString();
                //  obj_RCB.lbemailtxt1 = "Ph:" + ds4.Tables[0].Rows[0]["phone"].ToString() + "-" + ds4.Tables[0].Rows[0]["phone0"].ToString() + "," + "Fax:" + ds4.Tables[0].Rows[0]["fax"].ToString() + "," + ds4.Tables[0].Rows[0]["Fax1"].ToString();
                obj_RCB.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                obj_RCB.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                obj_RCB.txtpanno1 = ds4.Tables[0].Rows[0]["pan"].ToString();

                // obj_RCB.txtmailid1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
                obj_RCB.txtagcode1 = ds4.Tables[0].Rows[0]["Agency_code"].ToString();
                //string grossamt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
                //if (grossamt != "")
                //{
                //    abc = Convert.ToDouble(grossamt);
                //}

                //abc1 = abc1 + abc;

                // obj_RCB.amount11 = abc.ToString("F2");
                string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
                double pr1 = 0;
                if (pr != "")
                {
                    pr1 = Convert.ToDouble(pr);
                }
                string spl_chg = ds4.Tables[0].Rows[0]["Special_charges"].ToString();
                double spl_chg1 = 0;
                if (spl_chg != "")
                {
                    spl_chg1 = Convert.ToDouble(spl_chg);
                }
                //  obj_RCB.lbextpre1 = "Ex.Premium" + "(" + pr1 + ")" + "%";
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
                /////////////////////////////////////////// dynamic table vishwajeet  ***************
                int count = ds4.Tables[1].Rows.Count;
                int i;

                dytbl += "<table width='660px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[64].ToString() + "</td>";

                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='160px' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='120px' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[65].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[76].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                    // dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[74].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[69].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[67].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";
                    dytbl += "</tr>";
                }


                int maxlimit1 = 27;

                if (p1 == 0)
                {

                    for (i = ct; i < ds4.Tables[0].Rows.Count; i++)
                    {
                        billamt = billamt + Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                        grossbillamt = grossbillamt + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());

                    }
                }
                for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
                {
                    //if (ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() != "")
                    //NEWGROSSAMT = NEWGROSSAMT + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());
                    dytbl += "<tr align=center hight='67px'>";
                    dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black;'>" + srl.ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center' width='160px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    //if (ds4.Tables[0].Rows[i]["Caption"].ToString() != "")
                    //{
                    //    dytbl += "<td class='insertiontxtclass' align='center' width='80px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Caption"].ToString() + "</td>";
                    //}
                    //else
                    //{
                    //    dytbl += "<td class='insertiontxtclass' align='center' width='80px'style='border-right:solid 1px black;' >" + "--" + "</td>";
                    //}
                    //dytbl += "<td class='insertiontxtclass' align='center' width='50px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["RO_No"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center'width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";
                    //if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
                    //{

                    //    {
                    //        dytbl += "<td  class='insertiontxtclass' align='center' width='50px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Col_Code"].ToString() + "</td>";
                    //    }
                    //}
                    //else
                    //{
                    //    dytbl += "<td  class='middleforbill'align='center' style='border-right:solid 1px black;'>--</td>";

                    //}


                    if (ds4.Tables[0].Rows[i]["Height"].ToString() != "")
                    {
                        {
                            dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";
                        }
                    }
                    else
                    {
                        dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
                    }
                    if (ds4.Tables[0].Rows[i]["width"].ToString() != "" && ds4.Tables[0].Rows[i]["Height"].ToString() != "")
                    {
                        height1 = Convert.ToDouble(ds4.Tables[0].Rows[i]["Height"].ToString());
                        width1 = Convert.ToDouble(ds4.Tables[0].Rows[i]["width"].ToString());
                        volume = (height1 * width1);
                    }
                    dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + volume + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[0]["Color_code"].ToString() + "</td>";
                    if (i == 0)
                    {
                        dytbl += "<td class='insertiontxtclass'align='center' width='90px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Page_no"].ToString() + "</td>";
                        //if (ds4.Tables[0].Rows[i]["Card_Rate"].ToString() != "")
                        //{
                        //    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + "</td>";
                        //}
                        //else
                        //{
                        //    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>--</td>";
                        //}

                        if (ds4.Tables[0].Rows[i]["Agrred_Rate"].ToString() != "" && ds4.Tables[0].Rows[i]["Agrred_Rate"].ToString() != null)
                        {
                            dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Agreed_Rate"].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + "</td>";
                        }



                        //grossbillamt=Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_amount"].ToString());
                        if (Convert.ToDouble(pr1.ToString()) == 0.0)
                        {

                            dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";
                        }
                        else
                        {
                            dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";
                        }
                        if (ds4.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
                            abc1 = abc1 + Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + pr1 + "</td>";


                        //grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

                        //if (grossamt != "")
                        //{
                        //    abc = Convert.ToDouble(grossamt);
                        //}

                        //abc1 = abc1 + abc;

                        ////////



                        //bill_amt = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();



                        //if (bill_amt != "")
                        //{
                        //    abc_bill = Convert.ToDouble(bill_amt);
                        //}

                        //abc1_bill = abc1_bill + abc_bill;

                        //BOOKING_TYPE = ds4.Tables[0].Rows[i]["Booking_type"].ToString();

                        grs = Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                        ext = pr1;
                        totalam = grs + ext;

                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";

                    }
                    else
                    {
                        dytbl += "<td class='insertiontxtclass'align='center' width='50px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";

                        dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'> " + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + " </td>";



                        dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>  " + "." + " </td>";


                        //  dytbl += "<td class='insertiontxtclass' align='center'  width='50px' style='border-right:solid 1px black;'> " + "." + " </td>";

                        if (ds4.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
                            abc1 = abc1 + Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                        dytbl += "<td class='insertiontxtclass' align='center'  width='50px'>" + "." + "</td>";


                        grs = Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                        ext = pr1;
                        totalam = grs + ext;
                        dytbl += "<td class='insertiontxtclass' align='center'  width='50px' style='border-left:solid 1px black;'>" + "." + " </td>";

                    }
                    dytbl += "</tr>";
                    maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
                    srl++;
                }

                for (int a1 = ds4.Tables[0].Rows.Count; a1 < maxlimit1; a1++)
                {
                    dytbl += "<tr align=center hight='67px'>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='150px' >" + "&nbsp;" + "</td>";
                    dytbl += "<td  class='insertiontxtclass' align='right' width='160px'  style='border-left:solid 1px black'>" + "&nbsp;" + "</td>";
                    //dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-left:solid 1px black;'>" + "&nbsp;" + "</td>";
                    dytbl += "</tr>";
                }

                //
                if (p1 == pagecount - 1)
                {
                    // flag =1;

                    abc2 = abc1;
                    obj_RCB.txtgr1 = abc1.ToString("F2");
                    amtinpr = ((abc1 * pr1) / 100);
                    amtinpr = amtinpr + spl_chg1;
                    obj_RCB.lbextrapre1 = amtinpr.ToString("F2");
                    abc1 = abc1 - amtinpr;
                    obj_RCB.amount11 = grossbillamt.ToString("F2");
                    pr1 = (amtinpr * 100) / abc1;
                    pr1 = pr1;
                    string new1 = pr1.ToString("F2");
                    obj_RCB.lbextpre1 = "Ex.Prem." + "(" + new1 + ")" + "%";
                    DISCAMT = grossbillamt * dis1 / 100;
                    obj_RCB.txtdiscal1 = DISCAMT.ToString("F2");
                    obj_RCB.lbtrade11 = "TD" + "(" + dis + ")" + "%";
                    DISCADTD = grossbillamt * disn1 / 100;
                    obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
                    double net = grossbillamt - ((grossbillamt * disn1 / 100) + (DISCAMT));
                    net = Math.Round(net);
                    obj_RCB.netpay1 = billamt.ToString("F2");
                    obj_RCB.round_text1 = Math.Round(net + 0.01).ToString();
                    NumberToEngish obj = new NumberToEngish();
                    obj_RCB.lbwordinrupees1 = obj.changeNumericToWords(net.ToString()) + "Only";
                    // obj_RCB.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
                    obj_RCB.lbemail1 = "Email";
                    obj_RCB.lbpune1 = "PAN NO.";
                    obj_RCB.EOU1 = "E.&O.E.";
                    obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();
                    obj_RCB.trddisc_per1 = "( " + ds4.Tables[0].Rows[0]["trade_disc"].ToString() + "% )";
                    string TERMS = "AURANGABAD".ToString();
                    string namme1 = "images/shree.jpg";
                    obj_RCB.insertiontxt1 = ds4.Tables[0].Rows[0]["pubname"].ToString();

                    obj_RCB._centername = ds4.Tables[0].Rows[0]["pubname"].ToString();

                    abc1 = 0;
                }

                

                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();
                Page.Controls.Add(obj_RCB);
                //RenderControl(
                // placeholder1.Controls.Add(obj_RCB);
                

            }



            /* MailMessage msgMail = new MailMessage();
                      msgMail.To = "garima.gupta90@gmail.com";
                      msgMail.From = "billwillieorders@gmail.com";
                      msgMail.BodyFormat = MailFormat.Html;
                    //  msgMail.Cc = "pgadodia@apparelwinds.com,support@amsmumbai.com,billwillieorders@gmail.com";
                      //	msgMail.Cc="lata@4cplus.com,billwillieorders@gmail.com";
                      msgMail.Subject = "Order Confirmation Details From BillWillie";
                      msgMail.Body = "Check out the attachment!";
                      SmtpMail.SmtpServer = "";
                      //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["EmailServer"];
                      msgMail .Attachments.Add( new MailAttachment("c:\\temp\\annual-report.pdf"));

                      SmtpMail.Send(msgMail);

                      //"helpdeskqmags@gmail.com ";//
            

          */

        }
        //  Response.Redirect("pdf.aspx");
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
        string[] invoice2 = invoice.Split(',');

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


            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad" )
            {
                classifiedcontrol objcard = new classifiedcontrol();
                objcard = (classifiedcontrol)(Page.LoadControl("classifiedcontrol.ascx"));


                objcard.invoiceno = invoice2[inew].ToString();

                placeholder1.Controls.Add(objcard);



                objcard.agcode = agencycode1[inew].ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.Client = clientnew.ToString();
                objcard.bookingid = countbookid2[inew].ToString();


                objcard.setcard();
            }
            else
                if(ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "seaexpress")
            {

                ////sea_controlclassified objcard = new sea_controlclassified();
                //objcard = (sea_controlclassified)(Page.LoadControl("sea_controlclassified.ascx"));


                //objcard.invoiceno = invoice2[inew].ToString();

                //placeholder1.Controls.Add(objcard);



                //objcard.agcode = agencycode1[inew].ToString();
                //objcard.fromdate = frmdt.ToString();
                //objcard.dateto = dateto1.ToString();
                //objcard.Client = clientnew.ToString();
                //objcard.bookingid = countbookid2[inew].ToString();
                //objcard.setcard();
            
            
            }
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
        int chkfr = 0;
        int chkglob = 0;
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
        int newvar = 0;
        int u = 0;

        DataSet ds4 = new DataSet();
        for (inew = 0; inew < c4; inew++)
        {
            u = 0;

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

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectmonthlynew_b(agcode, fromdate, dateto, bookingidn, Client, Session["dateformat"].ToString(), bookingidn);
            }
            else
            {
                NewAdbooking.BillingClass.Classes.session_billing objvalues1 = new NewAdbooking.BillingClass.Classes.session_billing();
                ds4 = objvalues1.selectmonthlynew_b(agcode, fromdate, dateto, bookingidn, Client, Session["dateformat"].ToString(), bookingidn);

            }


            //  DataSet dt = new DataSet();
            //  NewAdbooking.BillingClass.classesoracle.billing_save ins = new NewAdbooking.BillingClass.classesoracle.billing_save();
            // dt = ins.update_printcount(invoicenn, Session["compcode"].ToString());




            int fr1 = 0;
            int maxlimit = 50;
            int rowcounter = 0;
            int ct = 0;
            int fr = maxlimit;

            int rcount = ds4.Tables[0].Rows.Count + ds4.Tables[3].Rows.Count;

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

                objcard.lbcreditdatetxt1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                objcard.lbwalujadd1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString() + "-" + ds4.Tables[0].Rows[0]["fax2"].ToString();
                objcard.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();

                objcard.lbbranchtxt1 = ds4.Tables[0].Rows[0]["branch"].ToString();
                objcard.lbagencyaddtxt1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString() + "," + ds4.Tables[0].Rows[0]["Dist_Code"].ToString();
                objcard.lbadcattxt1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                objcard.runtxt1 = dateto1.ToString();

                objcard.txtinvoice1 = invoicenn.ToString();











                dytbl += "<table width='650px' align='left' cellpadding='1' cellspacing='0'>";
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


                chkglob = 0;





                // for (i = ct; i < ds4.Tables[0].Rows.Count && (i + chkglob) < fr; i++)
                for (i = ct; i < ds4.Tables[0].Rows.Count; i++)
                {
                    // chkglob = 0;


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






                    //for (ch = 0; ch < len11N; ch++)
                    //{

                    //    if (ch == 0)
                    //    {
                    //        adsub_cat1 = adsub_cat1 + adsub_cat[ch];
                    //    }
                    //    else if (ch % 6 != 0)
                    //    {
                    //        adsub_cat1 = adsub_cat1 + adsub_cat[ch];
                    //    }
                    //    else
                    //    {
                    //        adsub_cat1 = adsub_cat1 + "</br>" + adsub_cat[ch];
                    //    }





                    //}


                    string chk_old = bookingidn1;





                    if (i > 0)
                    {

                        if (chk_old != ds4.Tables[0].Rows[i - 1]["Cio_Booking_Id"].ToString())
                        {
                            if (ds4.Tables[0].Rows[i - 1]["Cio_Booking_Id"].ToString() == ds4.Tables[3].Rows[u]["Cio_Booking_Id"].ToString())
                            {
                                if (rowcounter == maxlimit)
                                {
                                    rowcounter = 0;
                                    int p2 = p1 + 1;
                                    dytbl += "<tr ><td colspan='10'  width='600px' align=right><b>Continue</td></b><td>" + (p2) + "-" + pagecount + "</td></tr>";

                                    ct = i;
                                    break;
                                }
                                dytbl += "<tr><td colspan='11' >";
                                dytbl += "<table>";

                                dytbl += "<tr align=center>";
                                dytbl += "<td     align=right>BOOKINGID</td><td    WIDTH='300PX'>" + ds4.Tables[3].Rows[u]["Cio_Booking_Id"].ToString() + "</td><td  WIDTH='100PX' align=right   >Total</td><td WIDTH='50PX' >" + ds4.Tables[3].Rows[u]["Gross_Rate"].ToString() + "</td><td WIDTH='50PX'  >" + ds4.Tables[3].Rows[u]["TRADE DISC AMT"].ToString() + "</td><td WIDTH='50PX' >" + ds4.Tables[3].Rows[u]["AD AGENCY COMM AMT"].ToString() + "</td><td ALIGN='RIGHT'>" + ds4.Tables[3].Rows[u]["Bill_Amt"].ToString() + "</td>";

                                gros_amt = 0; trade_dis = 0; adtd = 0; amt3 = 0;
                                amt3 = 0;
                                dytbl += "</tr >";


                                dytbl += "</table>";
                                dytbl += "</td></tr >";
                                chkglob++;
                                u++;
                                rowcounter++;
                            }





                        }
                    }




                    if (rowcounter == maxlimit)
                    {
                        rowcounter = 0;
                        int p2 = p1 + 1;
                        dytbl += "<tr ><td colspan='10'  width='600px' align=right><b>Continue</td></b><td>" + (p2) + "-" + pagecount + "</td></tr>";

                        ct = i;
                        break;
                    }

                    dytbl += "<tr align=center>";
                    //  dytbl += "<td class='insertiontxtclassCLA' width='200px' >" + addbook + "</td>";
                    // dytbl += "<td class='insertiontxtclass' >" + ds4.Tables[0].Rows[i]["No_Insert"].ToString() + "</td>";

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        string DATENEW = ds4.Tables[0].Rows[i]["month"].ToString();
                        string[] DATENEW1 = DATENEW.Split('-');
                        objcard.lbformonthtxt1 = DATENEW1[1].ToString() + DATENEW1[2].ToString();
                    }
                    else
                    {
                        string DATENEW = ds4.Tables[0].Rows[i]["month"].ToString();
                        string[] DATENEW1 = DATENEW.Split(' ');
                        objcard.lbformonthtxt1 = DATENEW1[1].ToString() + DATENEW1[2].ToString();


                    }

                    dytbl += "<td class='insertiontxtclassCLA' width='40px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassCLA' width='150px'  >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
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
                        dytbl += "<td  class='insertiontxtclassCLA' width='50px' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='middleforbill' >-</td>";
                    }
                    if (ds4.Tables[0].Rows[i]["Col_Name"].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclassCLA' width='55px' >" + ds4.Tables[0].Rows[i]["Col_Name"].ToString() + "</td>";
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
                        dytbl += "<td class='insertiontxtclassCLA' width='35px'  ALIGN='RIGHT'>" + Convert.ToDouble(ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString()) + "</td>";

                        adtd = adtd + Convert.ToDouble(ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString());
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill' >-</td>";
                    }

                    dytbl += "<td class='insertiontxtclassCLA' width='65px' ALIGN='RIGHT' >" + ds4.Tables[0].Rows[i]["netamt"].ToString() + "</td>";

                    dytbl += "</tr>";

                    rowcounter++;


                    string amt = ds4.Tables[0].Rows[i]["netamt"].ToString();

                    //if (amt != "")
                    //{
                    //    amt1 = Convert.ToDouble(amt);
                    //}

                    //amt2 = amt2 + amt1;
                    //amt3 = amt3 + amt1;

                    //amt2 = amt2 + 0.01;
                    //amt2 = Math.Round(amt2);



                    if (i + 1 == ds4.Tables[0].Rows.Count)
                    {


                        dytbl += "<td colspan='11'>";
                        dytbl += "<table>";
                        dytbl += "<tr align=center>";
                        dytbl += "<tr ><td   align=right>BOOKINGID</td><td WIDTH='300PX' >" + ds4.Tables[3].Rows[u]["Cio_Booking_Id"].ToString() + "<td><td  width='100px' align=right   >Total</td><td width='50px' >" + ds4.Tables[3].Rows[u]["Gross_Rate"].ToString() + "</td><td  width='50px' >" + ds4.Tables[3].Rows[u]["TRADE DISC AMT"].ToString() + "</td><td>" + ds4.Tables[3].Rows[u]["AD AGENCY COMM AMT"].ToString() + "</td><td ALIGN='RIGHT'  >" + ds4.Tables[3].Rows[u]["Bill_Amt"].ToString() + "</td></tr>";
                        gros_amt = 0; trade_dis = 0; adtd = 0; amt3 = 0;
                        amt3 = 0;
                        dytbl += "</tr >";
                        dytbl += "</td>";
                        dytbl += "</table>";
                        rowcounter++;
                    }



                    //if ((i + chkglob) == fr-1)
                    //{
                    //    int p2 = p1 + 1;
                    //    dytbl += "<tr ><td colspan='10'  width='600px' align=right><b>Continue</td></b><td>" + (p2) + "-" + pagecount + "</td></tr>";

                    //}

                    //if (chkglob > 0)
                    //{
                    //    
                    //}

                    newvar = i;
                    //========= new code========

                    //if(rowcounter ==maxlimit )
                    //{
                    //    rowcounter = 0;
                    //    int p2 = p1 + 1;
                    //        dytbl += "<tr ><td colspan='10'  width='600px' align=right><b>Continue</td></b><td>" + (p2) + "-" + pagecount + "</td></tr>";

                    //    ct = i;
                    //    break;
                    //}
                }




                // ct = ct + i ;
                //fr = ct + i;


                if (p1 == pagecount - 1)
                {

                    dytbl += "<tr align=center  width='650px'>";
                    // dytbl += "<td class='insertiontxtclass_last' colspan ='10' ALIGN= 'left'  >Total</td> <td class='insertiontxtclass_last'  >" + amt2.ToString("F2") + "</td>";
                    dytbl += "<td class='insertiontxtclass_last' colspan ='10' ALIGN= 'left'  >Total</td> <td  ALIGN= 'left'  class='insertiontxtclass_last' >" + ds4.Tables[4].Rows[0]["Bill_Amt"].ToString() + "</td>";
                    dytbl += "</tr align=center>";

                    dytbl += "<tr align=center>";
                    dytbl += "<td colspan ='11' 'insertiontxtclass_last' VALIGN='BOTTOM'  ALIGN= 'right' HEIGHT ='40PX' >Advt. Manager/Accountant</td>";
                    dytbl += "</tr align=center>";


                    //objcard.lbtotal1 = "Total".ToString();

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
                    dytbl += "<tr width='650px' align=center>";
                    dytbl += "<td colspan ='11' ALIGN ='LEFT' class='insertiontxtclass_last1'><B> Terms & Condition</B> :1)Payment Should be made in favour of <B>" + namme1 + "</B> 2)Only official receipt issued by us will binding on us.3) Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days from the presentation of the bill,falling which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subjected to " + TERMS + " Jurisdiction only." + "</td>";
                    dytbl += "</tr align=center>";
                    //dytbl += "</table>";
                    //dytbl += "</td>";

                    // objcard.hidedata1 = "<b>Terms & Condition :1)</b>Payment Should be made in favour of " + namme1 + " 2)Only official receipt issued by us will binding on us.3) Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days from the presentation of the bill,falling which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subjected to " + TERMS + " Jurisdiction only.";


                    //  objcard.txttotal1 = amt2.ToString("F2");

                }








                dytbl += "</table>";



                objcard.dynamictable1 = dytbl;

                objcard.setReceiptData();



                Page.Controls.Add(objcard);

            }







        }

    }

    private void onscreen(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice, string trade_disc)
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
        string cls_matter = "";
        //int flag=0;
        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice1 = invoice.Split(',');
        string addition_flag = "";
        string[] trade_discn = trade_disc.Split(',');

        string bookingidd = "";



        string totalcashdisc = "";
        double tot_cas_dics = 0;
        for (inew = 0; inew < countbookid2.Length; inew++)
        {
            billamt12 = 0;
            tot_cas_dics = 0;
            totalcashdisc = "";

            bookingidd = countbookid2[inew];
       // private void getMatterPreview(string booking_id)
      //  {
        DataSet dr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt objmatter = new NewAdbooking.Classes.classifiedreceipt();
            dr = objmatter.clsreceiptmatter(bookingidd);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classifiedreceipt objmatter = new NewAdbooking.classesoracle.classifiedreceipt();
                dr = objmatter.clsreceiptmatter(bookingidd);

            }
            else
            {
            }
        if (dr.Tables[0].Rows.Count > 0)
        {

            
            cls_matter = dr.Tables[0].Rows[0]["RTFformat"].ToString();
            cls_matter = cls_matter.Replace("<!--[if gte mso 9]><xml><br>", " ");
        }
        else
        {
            cls_matter = "";
        }






            string bookingid = countbookid2[inew];
            string invoice2 = invoice1[inew];
           // trade_disc = trade_discn[inew];



            RCB1 obj_RCB1 = new RCB1();
            obj_RCB1 = (RCB1)Page.LoadControl("RCB1.ascx");
            DataSet ds4 = new DataSet();

            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            //ds4 = objvalues1.selectlastnew(bookingid, Session["dateformat"].ToString(), fromdate, dateto);
            ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());
            // DataSet dt = new DataSet();
            //  NewAdbooking.BillingClass.classesoracle.billing_save ins = new NewAdbooking.BillingClass.classesoracle.billing_save();
            //   dt = ins.update_printcount(invoice2, Session["compcode"].ToString());
            string fname = ds4.Tables[0].Rows[0]["FILE_PATH"].ToString();
            float finalheight = 80;
            string path = "Images/" + fname;// +".jpg";

            int maxlimit = 23;
            int ct = 0;
            int fr = maxlimit;

            int rcount = ds4.Tables[0].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;

            //===== special charge varible======

            double special_crg_t = 0;
            double spec_charge_ins = 0;
            double special_amt = 0.0;
            double gross_amt_total = 0;

            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }
            for (int p1 = 0; p1 < pagecount; p1++)
            {
                RCB1 obj_RCB = new RCB1();
                obj_RCB = (RCB1)Page.LoadControl("RCB1.ascx");
                obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
                obj_RCB.eyecatcher1 = "";  // dr.Tables[0].Rows[0]["eyecatcher"].ToString();
                   
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
                obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();
                obj_RCB.lbcaption1 = ds4.Tables[0].Rows[0]["Caption"].ToString();
                obj_RCB.lblciono1 = ds4.Tables[0].Rows[0]["Cio_Booking_Id"].ToString();
                obj_RCB.lblpageprem1 = ds4.Tables[0].Rows[0]["pageprem"].ToString();
                
                obj_RCB.txtinvoice1 = invoice2.ToString();
                obj_RCB.hidedata1 = "";

               
                //    Response.Write(Server.MapPath(path));
                if (System.IO.File.Exists(Server.MapPath(path)))
                {
                    obj_RCB.divimg1 = "<img src='" + path + "' height='" + finalheight + "'>";
                }




                // obj_RCB.agencytxt1 = ds4.Tables[0].Rows[0].ItemArray[14].ToString();

                //if ((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "0") || (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "") || (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != " "))
                //{

                if ((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "0") && (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != ""))
                {
                    obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["Agrred_rate"].ToString();

                }
                else
                {
                     string str1 = ds4.Tables[0].Rows[0]["Cio_Booking_Id"].ToString();
                    string result1 = str1.Substring(0, 2);
                    string uomcode1 = ds4.Tables[0].Rows[0]["Uom_code"].ToString();
                   // string Card_amount = ds4.Tables[0].Rows[i]["Card_amount"].ToString();
                    if (result1 == "CL" && (uomcode1 == "RO0" || uomcode1 == "RO1"))
                    {
                        string arm = ds4.Tables[0].Rows[0]["Size_Book"].ToString();
                        string leg = ds4.Tables[0].Rows[0]["Card_amount"].ToString();
                        if (arm != "" && leg != "")
                        {
                            double aapa = Convert.ToDouble(arm);
                            double jijji = Convert.ToDouble(leg);
                            obj_RCB.lbpakgrate1 = (jijji / aapa).ToString();
                        }
                    }
                    else
                    {
                        obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["Card_Rate"].ToString();
                    }
                    //zzobj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["PACKAGERATE"].ToString();
                  

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

                obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["BILL_DATE"].ToString();

                //obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();

                // obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["SYSDATE1"].ToString();
                obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                obj_RCB.lbronodate1 = ds4.Tables[0].Rows[0]["RO_No"].ToString() + "-" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();

                obj_RCB.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                obj_RCB.lbemail1 = " Email: ";
                obj_RCB.lbpune1 = " Pan No: ";
                obj_RCB.EOU1 = " E.&O.E. ";
                obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();

                //obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

                // obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();

                //obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();
              //  obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();
                obj_RCB.lbcompaddress1 = "Kantipur Complex, Subidga nagar kathmandu, Nepal";
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







                obj_RCB.lbextpre1 = "Ex.Premium";// +"(" + pr1 + ")" + "%";




                string dis = ds4.Tables[0].Rows[0]["td"].ToString();
                double dis1 = 0;
                Double DISCAMT = 0;
                if (dis != "")
                {
                    dis1 = Convert.ToDouble(dis);
                }

                string vat_cal = ds4.Tables[0].Rows[0]["VATAMT"].ToString();
                double vat_dis1 = 0;
                Double vat_DISCAMT = 0;
                if (vat_cal != "")
                {
                    vat_DISCAMT = Convert.ToDouble(vat_cal);
                }

                string client_cal4 = ds4.Tables[0].Rows[0]["FLAT_FEQ_D_AMT"].ToString();
                double client_cal14 = 0;
                 Double FLATAMT = 0;
                 if (client_cal4 != "")
                {
                    FLATAMT = Convert.ToDouble(client_cal4);
                }

                string client_cal2 = ds4.Tables[0].Rows[0]["CLIENT_CAT_D_AMT"].ToString();
                double client_cal13 = 0;
                Double CLIENTAMT = 0;
                if (client_cal2 != "")
                {
                    CLIENTAMT = Convert.ToDouble(client_cal2);
                }

                string client_cal1 = ds4.Tables[0].Rows[0]["CAT_D_AMT"].ToString();
                double client_cal12 = 0;
                Double CATAMT = 0;
                if (client_cal1 != "")
                {
                    CATAMT = Convert.ToDouble(client_cal1);
                }

                string client_cal5 = ds4.Tables[0].Rows[0]["SCHEMEDICPER"].ToString();
                string pranjalpapa = ds4.Tables[0].Rows[0]["Agency_pay"].ToString();
                double client_cal15 = 0;
                Double CASHAMOUNT = 0;
                if (client_cal5 != "")
                {
                    CASHAMOUNT = Convert.ToDouble(client_cal5);
                }


                
                //string client_cal1 = ds4.Tables[0].Rows[0]["CAT_D_AMT"].ToString();
                //double client_cal12 = 0;
                //Double CATAMT = 0;
                //if (client_cal1 != "")
                //{
                //    CATAMT = Convert.ToDouble(client_cal1);
                //}

                //string client_cal = ds4.Tables[0].Rows[0]["VATAMT"].ToString();
                //double client_cal1 = 0;
                ///// Double vat_DISCAMT = 0;
                //if (vat_cal != "")
                //{
                //    vat_DISCAMT = Convert.ToDouble(vat_cal);
                //}

                
                //addition_flag = ds4.Tables[0].Rows[0]["ADDITIONAL_FLAG"].ToString();
                addition_flag = "1";
                trade_disc = "0";
                string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
                double disn1 = 0;
                Double DISCADTD = 0;
                if (disn != "")
                {
                    disn1 = Convert.ToDouble(disn);
                }

                if (disn1 != 0)
                {
                    //if (addition_flag != "1")
                    //{
                    obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";
                    //}
                    //else
                    //{
                    //    disn1 = 0;
                    //    obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";
                    //}
                }
                else
                {
                    obj_RCB.lbadtd1 = "1";
                }
                string disn3 = ds4.Tables[0].Rows[0]["VATAMT"].ToString();
                if (vat_DISCAMT != 0)
                {
                    obj_RCB.lblvatamt1 = "Vat Amount" + "(" + disn3 + ")" + "%";
                }
                else
                {
                    obj_RCB.lblvatamt1 = "1";
                }

                string disn4 = ds4.Tables[0].Rows[0]["FLAT_FEQ_D_TYP"].ToString();
                string BHAGWAN = ds4.Tables[0].Rows[0]["FLAT_FEQ_DISC"].ToString();
                
                if(FLATAMT!=0)
                {
                    if (disn4 == "P")
                    {
                        obj_RCB.lblfreq1 = "Flat_feq_disc." + "(" + BHAGWAN + ")" + "%";
                    }
                    else
                    {
                        obj_RCB.lblfreq1 = "Flat_feq_disc.";// +"(" + disn4 + ")";
                    }
                }
                else
                {
                    obj_RCB.lblfreq1 = "1";
                }
                string allah = ds4.Tables[0].Rows[0]["CLIENT_CAT_DISC"].ToString();
                string disn5 = ds4.Tables[0].Rows[0]["CLIENT_CAT_D_TYP"].ToString();
                if (CLIENTAMT != 0)
                {
                    if (disn5 == "P")
                    {
                        obj_RCB.lblclientc1 = "Client_cat_disc." + "(" + allah + ")" + "%";
                    }
                    else
                    {
                        obj_RCB.lblclientc1 = "Client_cat_disc.";// +"(" + disn5 + ")";
                    }
                }
                else
                {
                    obj_RCB.lblclientc1 = "1";
                }

                string KHWAJA = ds4.Tables[0].Rows[0]["CAT_DISC"].ToString();
                string disn6 = ds4.Tables[0].Rows[0]["CAT_D_TYP"].ToString();

                if (CATAMT != 0)
                {
                    if (disn6 == "P")
                    {
                        obj_RCB.lblcatedis1 = "Cat_disc." + "(" + KHWAJA + ")" + "%";
                    }
                    else
                    {
                        obj_RCB.lblcatedis1 = "Cat_disc.";// +"(" + disn6 + ")";
                    }
                }
                else
                {
                    obj_RCB.lblcatedis1 = "1";
                }
                string disn7 = ds4.Tables[0].Rows[0]["CASHDISCTYPE"].ToString();
              //  string disn7 = ds4.Tables[0].Rows[0]["CASHDISCTYPE"].ToString();
              
                
                if (CASHAMOUNT != 0)
                {
                    
                   //     obj_RCB.lblcashdisc1 = "Feq Disc." +"(" +CASHAMOUNT+ ")"+ "%";
                        obj_RCB.lblcashdisc1 = "";
                    
                }
                else
                {
                    obj_RCB.lblcashdisc1 = "";
                }
              
              
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
                obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["AD_VAT_NO"].ToString();
                dytbl = "";
                /////////////////////////////////////////// dynamic table  ***************


                int count = ds4.Tables[1].Rows.Count;
                int i;
               /* if (browser.Browser == "Firefox")
                {
                    dytbl += "<P><table width='483px' align='left' cellpadding='0' cellspacing='0'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 7.0) || (ver == 8.0))
                    {
                        dytbl += "<P><table width='483px' align='left' cellpadding='0' cellspacing='0'>";
                    }
                    else if (ver == 6.0)
                    {*/
                        dytbl += "<table width='483px' align='left' cellpadding='0' cellspacing='0'>";
                  /*  }
                }*/
                //dytbl += "<table width='483px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";


                    dytbl += "<td class='agecnycodeclasspune' align='center' width='80px' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                    dytbl += "<td class='agecnycodeclasspune' align='right' width='80px'>" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";

                    dytbl += "<td class='agecnycodeclasspune'  align='center'  width='54px' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";

                    dytbl += "<td class='agecnycodeclasspune'  align='center'  width='46px' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                    dytbl += "<td class='agecnycodeclasspune' align='center'  width='46px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";

                   //imp //dytbl += "<td class='agecnycodeclasspune' align='center'  width='40px' >" + dsb.Tables[0].Rows[0].ItemArray[68].ToString() + "</td>";


                    //dytbl += "<td class='agecnycodeclasspune'  align='center'  width='46px' >" + dsb.Tables[0].Rows[0].ItemArray[67].ToString() + "</td>";


                    //dytbl += "<td class='agecnycodeclasspune'  align='center'  width='46px' >" + dsb.Tables[0].Rows[0].ItemArray[65].ToString() + "</td>";
                    //dytbl += "<td class='agecnycodeclasspune'  align='center'  width='46px' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";
                 
                    // += "<td class='insertiontxtclass1'  align='center'  width='20px' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";

                    dytbl += "</tr>";
                }

                for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
                {
                    dytbl += "<tr align=center>";
                    dytbl += "<td class='dateclasspune'align='left' width='100px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td class='dateclasspune' align='center' 'width='100px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";

                    if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
                    {
                        dytbl += "<td  class='dateclasspune' align='center' width='46px' >" + ds4.Tables[0].Rows[i]["Color_code"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill'align='center' >-</td>";

                    }
                    
                    dytbl += "<td class='dateclasspune'align='center' width='46px' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";



                    string str = ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString();
                    string result = str.Substring(0, 2);
                    string uomcode = ds4.Tables[0].Rows[i]["Uom_code"].ToString();
                    string cardamount = "";
                   // string Card_amount = ds4.Tables[0].Rows[i]["Card_amount"].ToString();
                    if (result == "CL" && (uomcode == "RO0" || uomcode == "RO1"))
                    {
                        dytbl += "<td  class='insertiontxtclass' align='right' width='46px' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
                        dytbl += "<td class='dateclasspune' align='center'  width='40px' >" + ds4.Tables[0].Rows[i]["Card_amount"].ToString() + "</td>";
                        cardamount = ds4.Tables[0].Rows[i]["Card_amount"].ToString();
                    }
                    else
                    {
                        dytbl += "<td  class='dateclasspune' align='center' width='46px' >" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";
                         dytbl += "<td class='dateclasspune' align='center'  width='40px' >" + ds4.Tables[0].Rows[i]["amtnew"].ToString() + "</td>";
                         cardamount = ds4.Tables[0].Rows[i]["amtnew"].ToString();
                    }
                   
                    
                    // dytbl += "<td class='insertiontxtclass' align='center 'width='50px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";

                   

                    //dytbl += "<td  class='insertiontxtclass' align='right' width='5px' >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";

                  
                     
                    double crdamt = 0;
                    if (cardamount != "")
                    {
                        crdamt = Convert.ToDouble(cardamount);

                    }





                    double schemeamount = 0;
                    if (CASHAMOUNT != 0)
                    {
                        schemeamount = crdamt * CASHAMOUNT / 100;
                        //  obj_RCB.txtcashdisc1 = CASHAMOUNT.ToString();
                        //  obj_RCB.txtcashdisc1 = schemeamount.ToString();
                    }

                    dytbl += "<td class='dateclasspune'align='center' width='46px' >" + schemeamount + "</td>";

                    dytbl += "<td class='dateclasspune'align='center' width='46px' >" + ds4.Tables[0].Rows[i]["CASHDISAMT"].ToString() + "</td>";

                    dytbl += "<td class='dateclasspune'align='center' width='46px' >" + ds4.Tables[0].Rows[i]["SPLDISAMT"].ToString() + "</td>";
                    //dytbl += "<td class='insertiontxtclass' align='left' >" + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + "</td>";



                   
                    string cardrt = ds4.Tables[0].Rows[i]["Card_Rate"].ToString();
                    double cdr = 0;
                    if (cardrt != "")
                    {
                        cdr = Convert.ToDouble(cardrt);
                    }


                    // dytbl += "<td class='insertiontxtclass' align='right' width='20px'  >" + cdr.ToString("F2") + "</td>";

                    
                    totalcashdisc = ds4.Tables[0].Rows[i]["CASHDISAMT"].ToString();

                    if (totalcashdisc != "")
                    {

                        tot_cas_dics = tot_cas_dics + Convert.ToDouble(totalcashdisc);
                    
                    }
                    grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

                    if (grossamt != "")
                    {
                        abc = Convert.ToDouble(grossamt);
                    }

                    abc1 = abc1 + abc;


                    billamtn = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();

                    if (billamtn != "")
                    {
                        billamt1 = Convert.ToDouble(billamtn);
                    }

                    billamt12 = billamt12 + billamt1;

                    dytbl += "</tr>";

                    maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();





                    dytbl += "</tr>";
                    //*************For special charge*************************//
                    gross_amt_total = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_amount"].ToString());
                    if (ds4.Tables[0].Rows[0]["Special_charges"].ToString() == "")
                    {
                        special_crg_t = 0;
                    }
                    else
                    {
                        special_crg_t = Convert.ToDouble(ds4.Tables[0].Rows[0]["Special_charges"].ToString());
                    }
                    special_amt = (Convert.ToDouble(grossamt) * special_crg_t) / gross_amt_total;
                    spec_charge_ins = spec_charge_ins + special_amt;

                    //**************************************************************//

                }  //



                if (p1 == pagecount - 1)
                {
                    // flag =1;

                    abc2 = abc1;

                    obj_RCB.txtgr1 = abc1.ToString("F2");

//double value = abc1 - 
              //      tot_cas_dics




                    amtinpr = ((abc1 * pr1) / 100);
                    amtinpr = amtinpr + spec_charge_ins;
                    if (amtinpr.ToString("F2") != "0.00")
                    {
                        obj_RCB.lbextrapre1 = amtinpr.ToString("F2");
                    }
                    else
                    {
                        obj_RCB.lbextrapre1 = "";
                    }
                    abc1 = abc1 - amtinpr;
                    obj_RCB.amount11 = abc1.ToString("F2");


                    DISCAMT = abc2 * dis1 / 100;
                    double VAT_DISC_AMT = abc2 * vat_DISCAMT / 100;
                    if (VAT_DISC_AMT != 0)
                    {
                        obj_RCB.txtvatamt1 = VAT_DISC_AMT.ToString();
                    }
                    else
                    {
                        obj_RCB.txtvatamt1 = "";
                    }


                    // not possible

                    if (CASHAMOUNT != 0)
                    {
                       // double schemeamount = abc1 * CASHAMOUNT / 100;
                    //    obj_RCB.txtcashdisc1 = CASHAMOUNT.ToString();
                        obj_RCB.txtcashdisc1 = "";
                       // obj_RCB.txtcashdisc1 = schemeamount.ToString();
                    }
                    else
                    {
                        obj_RCB.txtcashdisc1 = "";
                    }
                    if (CATAMT != 0)
                    {
                        obj_RCB.txtcatedisc1 = CATAMT.ToString();
                    }
                    else
                    {
                        obj_RCB.txtcatedisc1 = "";
                    }
                    if (CLIENTAMT != 0)
                    {
                    obj_RCB.txtclientc1 = CLIENTAMT.ToString();
                    }
                    else
                    {
                        obj_RCB.txtclientc1 = "";
                    }
                    if (FLATAMT != 0)
                    {
                        obj_RCB.txtfrequence1 = FLATAMT.ToString();
                    }
                    else
                    {
                        obj_RCB.txtfrequence1 = "";
                    }
                    //if (trade_disc != "0")
                    //{
                    if (DISCAMT.ToString("F2") != "0.00")
                    {
                        obj_RCB.txtdiscal1 = DISCAMT.ToString("F2");
                    }
                    else
                    {
                        obj_RCB.txtdiscal1 = "";
                    }
                        if (dis != "" || dis != "")
                        {
                            obj_RCB.lbtrade11 = "Agency Dis" + "(" + dis + ")" + "%";
                        }
                        else
                        {
                            obj_RCB.lbtrade11 = "1";
                        }
                        DISCADTD = abc2 * disn1 / 100;
                        //if (addition_flag == "1")
                        //{
                        if (DISCADTD.ToString("F2") != "0.00")
                        {
                            obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
                        }
                        else
                        {
                            obj_RCB.lbadtdtxt1 = "";
                        }
                        //}
                        //else
                        //{
                        //    DISCADTD = 0;
                        //    obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
                        //}
                    //}
                    //else
                    //{
                    //    obj_RCB.lbtrade11 = "1";

                    //}



                    if (addition_flag != "1")
                    {
                        double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT) + VAT_DISC_AMT);
                        net = Math.Round(net);

                        obj_RCB.netpay1 = billamt12.ToString("F2");
                    }
                    else
                    {
                        double net = (abc2 - DISCAMT) + VAT_DISC_AMT;
                        net = Math.Round(net);

                        obj_RCB.netpay1 = billamt12.ToString("F2");
                    }

                    //===================================

                   



                    double myvalue = (abc2 - DISCAMT) - tot_cas_dics;
                    double vatamtfinal = myvalue * 13 / 100;
                    //double value = abc1 - 
                    //      tot_cas_dics

                    obj_RCB.txtvatamt1 = vatamtfinal.ToString("F2");



                    double salesamt = billamt12 - vatamtfinal;
                    obj_RCB.Lblsalesamt1 = salesamt.ToString("F2");

                    obj_RCB.lblbilltyp1 = agencycode;
                    obj_RCB.userid1 = hiddenuserid;
                    //=====================================
                    NumberToEngish obj = new NumberToEngish();
                    obj_RCB.lbwordinrupees1 = obj.changeNumericToWords(billamt12.ToString("F2")) + "Only";


                    obj_RCB.lbemail1 = " Email: ";
                    obj_RCB.lbpune1 = " Pan No: ";
                    obj_RCB.EOU1 = " E.&O.E.";
                    obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();
                    
                    string TERMS = "KATMANDU".ToString();
                    string namme1 = "Kantipur Publication Pvt. Ltd.";
                    obj_RCB.insertiontxt1 = ds4.Tables[0].Rows[0]["No_of_insertion"].ToString();
                    //obj_RCB.hidedata1 = "Terms & Conditions :1)Payment should be made in favour of <font style=font-size:11px;font-weight:bold>" + namme1 + " </font> 2)Only official receipt issued by us will be binding on us.3) Objection or complaint regarding the bill if any should be brought to our notice within 15 days from the presentation of the bill,failing which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subject to <font style=font-size:11px;font-weight:bold>" + TERMS + " </font> Jurisdiction only.";
                    obj_RCB.hidedata1 = "This invoice shall be treated as correct unless and until claimed,otherwise within seven days of the invoice submission date.";

                    abc1 = 0;


                }
              /*  if (browser.Browser == "Firefox")
                {
                    dytbl += "</table></P>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 7.0) || (ver == 8.0))
                    {
                        dytbl += "</table></P>";
                    }
                    else if (ver == 6.0)
                    {*/
                        dytbl += "</table>";
                  /*  }
                }*/
                //dytbl += "</table>";

                obj_RCB.dynamictable1 = dytbl;

                obj_RCB.setReceiptData();



                Page.Controls.Add(obj_RCB);
                // placeholder1.Controls.Add(obj_RCB);






            }
            //obj_RCB2.setReceiptData();
            // Page.Controls.Add(obj_RCB2);












        }
    }




    //private void onscreen_haribhoomi(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    //{
    //    //double NEWGROSSAMT = 0.0;
    //    //  string grossamt = "";
    //    string day = "";
    //    string month = "";
    //    string year = "";
    //    string date = "";
    //    double amt1 = 0;
    //    double amt2 = 0;
    //    bool flag = true;
    //    int inew2 = 0;
    //    int inew = 0;
    //    int fix = 2;
        
    //    double abc = 0;
    //    double comm2 = 0;
    //    double boxamt2 = 0;
    //    double abc1 = 0;
    //    double amtinpr = 0;
    //    double abc2 = 0;
    //    string maxinsert = "";
    //    string dytbl = "";
    //    double volume = 0;
    //    double height1 = 0;
    //    double width1= 0;
    //    double ext = 0;
    //    double grs = 0;
    //    double totalam = 0;
    //    //int flag=0;
    //    string[] countbookid2 = ciobookid.Split(',');
    //    string[] invoice1 = invoice.Split(',');
    //    //    double abc_bill = 0;
    //    //   double abc1_bill = 0;
    //    //   string bill_amt = "";
    //    //   string BOOKING_TYPE = "";

    //    for (inew = 0; inew < countbookid2.Length; inew++)
    //    {
    //        // NEWGROSSAMT = 0.0;
    //        string bookingid = countbookid2[inew];
    //        string invoice2 = invoice1[inew];
    //        //haribhoomi_billnew1 obj_RCB1 = new haribhoomi_billnew1();
    //        //obj_RCB1 = (haribhoomi_billnew1)Page.LoadControl("haribhoomi_billnew1.ascx");
    //        DataSet ds4 = new DataSet();


    //        if (invoice2 == "&nbsp;")
    //        {
    //            invoice2 = "";
    //        }


    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //            ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());
    //        }
    //        else
    //        {
    //            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
    //            ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());

    //        }

    //        //   DataSet dt = new DataSet();
    //        // NewAdbooking.BillingClass.classesoracle.billing_save ins = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //        // dt = ins.update_printcount(invoice2, Session["compcode"].ToString());
    //        int maxlimit = 18;
    //        int ct = 0;
    //        int srl = 1;
    //      //  int i = 1;
    //        int fr = maxlimit;
    //        int rcount = ds4.Tables[0].Rows.Count;
    //        int pagec = rcount % maxlimit;
    //        int pagecount = rcount / maxlimit;
    //        if (pagec > 0)
    //        {
    //            pagecount = pagecount + 1;
    //        }

    //        double billamt = 0;

    //        double grossbillamt = 0;
    //        for (int p1 = 0; p1 < pagecount; p1++)
    //        {
    //            haribhoomi_billnew1 obj_RCB = new haribhoomi_billnew1();
    //            obj_RCB = (haribhoomi_billnew1)Page.LoadControl("haribhoomi_billnew1.ascx");
    //            ct = maxlimit * p1;
    //            fr = maxlimit * (p1 + 1);
    //            if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
    //            {

    //                obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
    //                obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
    //                obj_RCB.lblagencyname1 = "Agency";
    //            }
    //            else
    //            {
    //                string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
    //                obj_RCB.lbaddress1 = addname[0];
    //                obj_RCB.agddxt1 = addname[2];
    //                obj_RCB.lblagencyname1 = "Client";
    //            }

    //            if (obj_RCB.agddxt1 == ds4.Tables[0].Rows[0]["Agency_Name"].ToString())
    //            {
    //                obj_RCB.lbladrelpar1 = "Client";
    //                obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();
    //            }
    //            else if (obj_RCB.agddxt1 == ds4.Tables[0].Rows[0]["client"].ToString())
    //            {
    //                obj_RCB.lbladrelpar1 = "Agency";
    //                obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB.lbladrelpar1 = "Client";
    //                obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();

    //            }



    //            //if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
    //            //{
    //            //    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
    //            //    obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();

    //            //}
    //            //else
    //            //{
    //            //    string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
    //            //    obj_RCB.lbaddress1 = addname[0];
    //            //    obj_RCB.agddxt1 = addname[2];

    //            //}
    //            //obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();




    //            obj_RCB.bill_dt = ds4.Tables[0].Rows[0]["maxdate1"].ToString();

    //            if (ds4.Tables[0].Rows[0]["Remark"].ToString() != "")
    //            {

    //                obj_RCB.remark = ds4.Tables[0].Rows[0]["Remark"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB.remark = "--";
    //            }
    //            obj_RCB.lbcaption1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

    //            if (invoice2 == "")
    //            {
    //                obj_RCB.txtinvoice1 = "XXXX";
    //            }
    //            else
    //            {

    //                obj_RCB.txtinvoice1 = invoice2.ToString();
    //            }
    //            obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();


    //            obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();

    //            obj_RCB.txtkey1 = ds4.Tables[0].Rows[0]["Key No"].ToString();

    //            obj_RCB.hidedata1 = "";
    //            if ((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "0") && (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != ""))
    //            {
    //                obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["Agrred_rate"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["PACKAGERATE"].ToString();
    //            }
    //            string comm1 = ds4.Tables[0].Rows[0].ItemArray[23].ToString();
    //            if (comm1 != "")
    //            {
    //                comm2 = Convert.ToDouble(comm1);
    //            }
    //            string boxamt1 = ds4.Tables[0].Rows[0].ItemArray[22].ToString();
    //            if (boxamt1 != "")
    //            {
    //                boxamt2 = Convert.ToDouble(boxamt1);
    //            }

    //           // obj_RCB.unit1 = ds4.Tables[2].Rows[0]["Unit"].ToString();
    //            string[] addname1 = ds4.Tables[0].Rows[0]["street_login"].ToString().Split("~".ToCharArray());
    //            obj_RCB.lbcompaddress1 = addname1[0];
    //            obj_RCB.txtmailid1 = addname1[1];

    //            obj_RCB.lbemailtxt1 = "Ph:-" + addname1[2] + "-" + addname1[3] + "," + "Fax:-" + addname1[4] + "," + addname1[5];

    //            //DataSet ds_new = new DataSet();
    //            //NewAdbooking.BillingClass.classesoracle.billing_save objvalues11 = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //            //ds_new = objvalues11.FETACH_BILLDATE(invoice2, Session["dateformat"].ToString());
    //            //obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();
    //            //obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
    //            obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
    //            obj_RCB.txtrefno1 = ds4.Tables[0].Rows[0]["RO_No"].ToString();
    //            obj_RCB.txtrodate1 = ds4.Tables[0].Rows[0]["RO_Date"].ToString();
    //            if (ds4.Tables[0].Rows[0]["Caption"].ToString() != "" || ds4.Tables[0].Rows[0]["Product"].ToString() != "")
    //            {
    //                obj_RCB.publication_value1 = ds4.Tables[0].Rows[0]["Caption"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["Product"].ToString();
    //            }
    //            else if (ds4.Tables[0].Rows[0]["Caption"].ToString() != "")
    //            {
    //                obj_RCB.publication_value1 = ds4.Tables[0].Rows[0]["Caption"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
    //            }
    //            else if (ds4.Tables[0].Rows[0]["Product"].ToString() != "")
    //            {
    //                obj_RCB.publication_value1 = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["Product"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB.publication_value1 = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
    //            }

    //            obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();
    //            //obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString();
    //            //  obj_RCB.lbemailtxt1 = "Ph:" + ds4.Tables[0].Rows[0]["phone"].ToString() + "-" + ds4.Tables[0].Rows[0]["phone0"].ToString() + "," + "Fax:" + ds4.Tables[0].Rows[0]["fax"].ToString() + "," + ds4.Tables[0].Rows[0]["Fax1"].ToString();
    //            obj_RCB.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
    //            obj_RCB.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
    //            obj_RCB.txtpanno1 = ds4.Tables[0].Rows[0]["pan"].ToString();

    //            // obj_RCB.txtmailid1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
    //            obj_RCB.txtagcode1 = ds4.Tables[0].Rows[0]["Agency_code"].ToString();
    //            //string grossamt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
    //            //if (grossamt != "")
    //            //{
    //            //    abc = Convert.ToDouble(grossamt);
    //            //}

    //            //abc1 = abc1 + abc;

    //            // obj_RCB.amount11 = abc.ToString("F2");
    //            string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
    //            double pr1 = 0;
    //            if (pr != "")
    //            {
    //                pr1 = Convert.ToDouble(pr);
    //            }
    //            string spl_chg = ds4.Tables[0].Rows[0]["Special_charges"].ToString();
    //            double spl_chg1 = 0;
    //            if (spl_chg != "")
    //            {
    //                spl_chg1 = Convert.ToDouble(spl_chg);
    //            }
    //            //  obj_RCB.lbextpre1 = "Ex.Premium" + "(" + pr1 + ")" + "%";
    //            string dis = ds4.Tables[0].Rows[0]["td"].ToString();
    //            double dis1 = 0;
    //            Double DISCAMT = 0;
    //            if (dis != "")
    //            {
    //                dis1 = Convert.ToDouble(dis);
    //            }
    //            string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
    //            double disn1 = 0;
    //            Double DISCADTD = 0;
    //            if (disn != "")
    //            {
    //                disn1 = Convert.ToDouble(disn);
    //            }
    //            obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";

    //            string packagename = "";
    //            int p;
    //            for (p = 0; p < ds4.Tables[1].Rows.Count; p++)
    //            {
    //                if (packagename == "")
    //                {
    //                    packagename = ds4.Tables[1].Rows[p].ItemArray[0].ToString();
    //                }
    //                else
    //                {
    //                    packagename = packagename + "+" + ds4.Tables[1].Rows[p].ItemArray[0].ToString();
    //                }
    //            }
    //            obj_RCB.txtpackname1 = packagename.ToString();
    //            dytbl = "";
    //            /////////////////////////////////////////// dynamic table vishwajeet  ***************
    //            int count = ds4.Tables[1].Rows.Count;
    //            int i;

    //            dytbl += "<table width='660px' align='left' cellpadding='0' cellspacing='0'>";
    //            {
    //                DataSet dsb = new DataSet();
    //                dsb.ReadXml(Server.MapPath("XML/hari_classified_last.xml"));
    //                dytbl += "<tr align=center >";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[64].ToString() + "</td>";

    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='160px' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='120px' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[65].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
    //                // dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[0].Rows[0].ItemArray[74].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[69].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[67].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";
    //                dytbl += "</tr>";
    //            }


    //            int maxlimit1 = 30;

    //            if (p1 == 0)
    //            {

    //                for (i = ct; i < ds4.Tables[0].Rows.Count; i++)
    //                {
    //                    billamt = billamt + Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
    //                    grossbillamt = grossbillamt + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());

    //                }
    //            }
    //            for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
    //            {
    //                //if (ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() != "")
    //                //NEWGROSSAMT = NEWGROSSAMT + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());
    //                dytbl += "<tr align=center hight='67px'>";
    //                dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black;'>" + srl.ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass' align='center' width='160px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
    //                //if (ds4.Tables[0].Rows[i]["Caption"].ToString() != "")
    //                //{
    //                //    dytbl += "<td class='insertiontxtclass' align='center' width='80px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Caption"].ToString() + "</td>";
    //                //}
    //                //else
    //                //{
    //                //    dytbl += "<td class='insertiontxtclass' align='center' width='80px'style='border-right:solid 1px black;' >" + "--" + "</td>";
    //                //}
    //                //dytbl += "<td class='insertiontxtclass' align='center' width='50px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["RO_No"].ToString() + "</td>";
    //                dytbl += "<td class='insertiontxtclass' align='center'width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";
    //                //if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
    //                //{

    //                //    {
    //                //        dytbl += "<td  class='insertiontxtclass' align='center' width='50px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Col_Code"].ToString() + "</td>";
    //                //    }
    //                //}
    //                //else
    //                //{
    //                //    dytbl += "<td  class='middleforbill'align='center' style='border-right:solid 1px black;'>--</td>";

    //                //}


    //                if (ds4.Tables[0].Rows[i]["Height"].ToString() != "")
    //                {
    //                    {
    //                        dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";
    //                    }
    //                }
    //                else
    //                {
    //                    dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
    //                }
    //                if (ds4.Tables[0].Rows[i]["width"].ToString() != "" && ds4.Tables[0].Rows[i]["Height"].ToString() != "")
    //                {
    //                    height1 = Convert.ToDouble(ds4.Tables[0].Rows[i]["Height"].ToString());
    //                    width1 = Convert.ToDouble(ds4.Tables[0].Rows[i]["width"].ToString());
    //                    volume = (height1 * width1);
    //                }
    //                dytbl += "<td  class='insertiontxtclass' align='center' width='90px' style='border-right:solid 1px black;'>" + volume + "</td>";
    //                if (i == 0)
    //                {
    //                    dytbl += "<td class='insertiontxtclass'align='center' width='90px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
    //                    //if (ds4.Tables[0].Rows[i]["Card_Rate"].ToString() != "")
    //                    //{
    //                    //    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Card_Rate"].ToString() + "</td>";
    //                    //}
    //                    //else
    //                    //{
    //                    //    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>--</td>";
    //                    //}

    //                    if (ds4.Tables[0].Rows[i]["Agrred_Rate"].ToString() != "")
    //                    {
    //                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Agreed_Rate"].ToString() + "</td>";
    //                    }
    //                    else
    //                    {
    //                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>0</td>";
    //                    }



    //                    //grossbillamt=Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_amount"].ToString());
    //                    if (Convert.ToDouble(pr1.ToString()) == 0.0)
    //                    {

    //                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";
    //                    }
    //                    else
    //                    {
    //                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-right:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";
    //                    }
    //                    if (ds4.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
    //                        abc1 = abc1 + Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
    //                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px'>" + pr1 + "</td>";


    //                    //grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

    //                    //if (grossamt != "")
    //                    //{
    //                    //    abc = Convert.ToDouble(grossamt);
    //                    //}

    //                    //abc1 = abc1 + abc;

    //                    ////////



    //                    //bill_amt = ds4.Tables[0].Rows[i]["Bill_Amt"].ToString();



    //                    //if (bill_amt != "")
    //                    //{
    //                    //    abc_bill = Convert.ToDouble(bill_amt);
    //                    //}

    //                    //abc1_bill = abc1_bill + abc_bill;

    //                    //BOOKING_TYPE = ds4.Tables[0].Rows[i]["Booking_type"].ToString();

    //                    grs = Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
    //                    ext = pr1;
    //                    totalam = grs + ext;

    //                    dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";

    //                }
    //                else
    //                {
    //                    dytbl += "<td class='insertiontxtclass'align='center' width='50px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";

    //                    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'> " + "." + " </td>";



    //                    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'>  " + "." + " </td>";


    //                    //  dytbl += "<td class='insertiontxtclass' align='center'  width='50px' style='border-right:solid 1px black;'> " + "." + " </td>";

    //                    if (ds4.Tables[0].Rows[i]["Bill_Amt"].ToString() != "")
    //                        abc1 = abc1 + Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
    //                    dytbl += "<td class='insertiontxtclass' align='center'  width='50px'>" + "." + "</td>";


    //                    grs = Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
    //                    ext = pr1;
    //                    totalam = grs + ext;
    //                    dytbl += "<td class='insertiontxtclass' align='center'  width='50px' style='border-left:solid 1px black;'>" + "." + " </td>";

    //                }
    //                dytbl += "</tr>";
    //                maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
    //                srl++;
    //            }
    //            /*
    //            for (int a1 = ds4.Tables[0].Rows.Count; a1 < maxlimit1 - ds4.Tables[0].Rows.Count; a1++)
    //            {
    //                dytbl += "<tr align=center hight='67px'>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-right:solid 1px black'>" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='150px' >" + "&nbsp;" + "</td>";
    //                dytbl += "<td  class='insertiontxtclass' align='right' width='160px'  style='border-left:solid 1px black'>" + "&nbsp;" + "</td>";
    //                //dytbl += "<td  class='insertiontxtclass' align='right' width='150px'  style='border-left:solid 1px black;'>" + "&nbsp;" + "</td>";
    //                dytbl += "</tr>";
    //            }*/
                
    //            //
    //            if (p1 == pagecount - 1)
    //            {
    //                // flag =1;

    //                abc2 = abc1;
    //                obj_RCB.txtgr1 = abc1.ToString("F2");
    //                amtinpr = ((abc1 * pr1) / 100);
    //                amtinpr = amtinpr + spl_chg1;
    //                obj_RCB.lbextrapre1 = amtinpr.ToString("F2");
    //                abc1 = abc1 - amtinpr;
    //                obj_RCB.amount11 = grossbillamt.ToString("F2");
    //                pr1 = (amtinpr * 100) / abc1;
    //                pr1 = pr1;
    //                string new1 = pr1.ToString("F2");
    //                obj_RCB.lbextpre1 = "Ex.Prem." + "(" + new1 + ")" + "%";
    //                DISCAMT = grossbillamt * dis1 / 100;
    //                obj_RCB.txtdiscal1 = DISCAMT.ToString("F2");
    //                obj_RCB.lbtrade11 = "TD" + "(" + dis + ")" + "%";
    //                DISCADTD = grossbillamt * disn1 / 100;
    //                obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
    //                double net = grossbillamt - ((grossbillamt * disn1 / 100) + (DISCAMT));
    //                net = Math.Round(net);
    //                obj_RCB.netpay1 = billamt.ToString("F2");
    //                obj_RCB.round_text1 = Math.Round(net + 0.01).ToString();
    //                NumberToEngish obj = new NumberToEngish();
    //                obj_RCB.lbwordinrupees1 = obj.changeNumericToWords(net.ToString()) + "Only";
    //                // obj_RCB.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
    //                obj_RCB.lbemail1 = "Email";
    //                obj_RCB.lbpune1 = "PAN NO.";
    //                obj_RCB.EOU1 = "E.&O.E.";
    //                obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();
    //                obj_RCB.trddisc_per1 = "( " + ds4.Tables[0].Rows[0]["trade_disc"].ToString() + "% )";
    //                string TERMS = "AURANGABAD".ToString();
    //                string namme1 = "images/shree.jpg";
    //                obj_RCB.insertiontxt1 = ds4.Tables[0].Rows[0]["pubname"].ToString();

    //                obj_RCB._centername = ds4.Tables[0].Rows[0]["pubname"].ToString();

    //                abc1 = 0;
    //            }
    //            dytbl += "</table>";
    //            obj_RCB.dynamictable1 = dytbl;
    //            obj_RCB.setReceiptData();
    //            Page.Controls.Add(obj_RCB);
    //            //RenderControl(
    //            // placeholder1.Controls.Add(obj_RCB);

    //        }



    //        /* MailMessage msgMail = new MailMessage();
    //                  msgMail.To = "garima.gupta90@gmail.com";
    //                  msgMail.From = "billwillieorders@gmail.com";
    //                  msgMail.BodyFormat = MailFormat.Html;
    //                //  msgMail.Cc = "pgadodia@apparelwinds.com,support@amsmumbai.com,billwillieorders@gmail.com";
    //                  //	msgMail.Cc="lata@4cplus.com,billwillieorders@gmail.com";
    //                  msgMail.Subject = "Order Confirmation Details From BillWillie";
    //                  msgMail.Body = "Check out the attachment!";
    //                  SmtpMail.SmtpServer = "";
    //                  //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["EmailServer"];
    //                  msgMail .Attachments.Add( new MailAttachment("c:\\temp\\annual-report.pdf"));

    //                  SmtpMail.Send(msgMail);

    //                  //"helpdeskqmags@gmail.com ";//
            

    //      */

    //    }
    //    //  Response.Redirect("pdf.aspx");
    //}





    //private void onscreen_upkar(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    //{
    //    //double NEWGROSSAMT = 0.0;
    //    //  string grossamt = "";
    //    string day = "";
    //    string month = "";
    //    string year = "";
    //    string date = "";
    //    double amt1 = 0;
    //    double amt2 = 0;
    //    bool flag = true;
    //    int inew2 = 0;
    //    int inew = 0;
    //    int fix = 2;
    //    double abc = 0;
    //    double comm2 = 0;
    //    double boxamt2 = 0;
    //    double abc1 = 0;
    //    double amtinpr = 0;
    //    double abc2 = 0;
    //    string maxinsert = "";
    //    string dytbl = "";
    //    string ciobooking = "";
    //    string editionname = "";
    //    // string insertion="";
    //    string dateformat = "";
    //    string editoncode = "";
    //    //int flag=0;
    //    string[] countbookid2 = ciobookid.Split(',');
    //    string[] invoice1 = invoice.Split(',');
    //    //    double abc_bill = 0;
    //    //   double abc1_bill = 0;
    //    //   string bill_amt = "";
    //    //   string BOOKING_TYPE = "";
    //    // compcode = Session["compcode"].ToString();
    //    // hiddendateformat.Value = Session["dateformat"].ToString();

    //    //string packagecode2 = ds111.Tables[0].Rows[0].ItemArray[2].ToString();  
    //    // string[] packagecode1 = packagecode2.Split(',');

    //    for (inew = 0; inew < countbookid2.Length; inew++)
    //    {
    //        // NEWGROSSAMT = 0.0;
    //        string bookingid = countbookid2[inew];
    //        string invoice2 = invoice1[inew];



    //        bill_format obj_RCB1 = new bill_format();
    //        obj_RCB1 = (bill_format)Page.LoadControl("bill_format.ascx");


    //        DataSet ds4 = new DataSet();

    //        DataSet ds111 = new DataSet();

    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //            ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());
    //        }
    //        else
    //        {
    //            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
    //            ds4 = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());

    //        }

    //        //obj_RCB.refno = ds4.Tables[0].Rows[0]["RO_No"].ToString();

    //        //string[] arr11 = ds4.Tables[0].Rows[0]["Ins.date"].ToString().Split('/');
    //        //    string dd = arr11[1];
    //        //    string mm = arr11[0];
    //        //    string yy = arr11[2];
    //        //    dateto =dd  + "/" + mm + "/" + yy;
            
    //        //string.Format("{0:MMMM,yyyy}", dateto);
    //        //string.Format("{0:MMMM,yyyy}", DateTime.Parse(dateto));

            



    //        //string packagecode2 = ds111.Tables[0].Rows[0].ItemArray[2].ToString();
    //        //string[] packagecode1 = packagecode2.Split(',');


           

           

    //        DataSet dt = new DataSet();
    //        NewAdbooking.BillingClass.classesoracle.billing_save ins = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //        dt = ins.update_printcount(invoice2, Session["compcode"].ToString());
    //        int maxlimit = 31;
    //        int ct = 0;
    //        int fr = maxlimit;
    //        int rcount = ds4.Tables[0].Rows.Count;
    //        int pagec = rcount % maxlimit;
    //        int pagecount = rcount / maxlimit;
    //        if (pagec > 0)
    //        {
    //            pagecount = pagecount + 1;
    //        }
    //        for (int p1 = 0; p1 < pagecount; p1++)
    //        {
    //            bill_format obj_RCB = new bill_format();
    //            obj_RCB = (bill_format)Page.LoadControl("bill_format.ascx");
    //            ct = maxlimit * p1;
    //            obj_RCB.refno = ds4.Tables[0].Rows[0]["RO_No"].ToString();
    //            obj_RCB.refno = ds4.Tables[0].Rows[0]["Remark"].ToString();
    //            fr = maxlimit * (p1 + 1);
    //            if (ds4.Tables[0].Rows[0]["agenadd"].ToString() == "" || ds4.Tables[0].Rows[0]["agenadd"].ToString() == null || ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
    //            {
    //                obj_RCB._agencyname = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
    //                obj_RCB._agencyadd1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
    //                obj_RCB._city = ds4.Tables[0].Rows[0]["City_Name"].ToString();
    //            }
    //            else
    //            {
    //                string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
    //                obj_RCB._agencyadd1 = addname[0];
    //                obj_RCB._agencyname = addname[2];
    //                obj_RCB._lno = addname[6];
    //                obj_RCB._city = ds4.Tables[0].Rows[0]["City_Name"].ToString();
    //                //if (addname[4] != "")
    //                //{
    //                //    lbcityname.Text = addname[4];
    //                //}
    //            }

    //            if (ds4.Tables[0].Rows[0]["agenadd"].ToString() == "" || ds4.Tables[0].Rows[0]["agenadd"].ToString() == null || ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
    //            {
    //                obj_RCB._headoffice = ds4.Tables[0].Rows[0]["client"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB._headoffice = ds4.Tables[0].Rows[0]["client"].ToString();
    //            }
    //            if (invoice2 == "")
    //            {
    //               // obj_RCB.txtinvoice1 = "XXXX";
    //            }
    //            else
    //            {

    //                //obj_RCB.txtinvoice1 = invoice2.ToString();
    //            } obj_RCB._invoiceno = invoice2.ToString();
    //            obj_RCB._invoicedate = ds4.Tables[0].Rows[0]["maxdate1"].ToString();
    //            string pr = ds4.Tables[0].Rows[0]["expr"].ToString();
    //            double pr1 = 0;
    //            if (pr != "")
    //            {
    //                pr1 = Convert.ToDouble(pr);
    //            }
    //            string spl_chg = ds4.Tables[0].Rows[0]["Special_charges"].ToString();
    //            double spl_chg1 = 0;
    //            if (spl_chg != "")
    //            {
    //                spl_chg1 = Convert.ToDouble(spl_chg);
    //            }
    //            //  obj_RCB.lbextpre1 = "Ex.Premium" + "(" + pr1 + ")" + "%";
    //            string dis = ds4.Tables[0].Rows[0]["td"].ToString();
    //            double dis1 = 0;
    //            Double DISCAMT = 0;
    //            if (dis != "")
    //            {
    //                dis1 = Convert.ToDouble(dis);
    //            }
    //            string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
    //            double disn1 = 0;
    //            Double DISCADTD = 0;
    //            if (disn != "")
    //            {
    //                disn1 = Convert.ToDouble(disn);
    //            }
    //           // obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";


    //            if (ds4.Tables[0].Rows[0]["Retainer"].ToString() == "" || ds4.Tables[0].Rows[0]["Retainer"].ToString() == null )
    //            {
    //               // obj_RCB._headoffice = ds4.Tables[0].Rows[0]["Retainer"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB._repname = ds4.Tables[0].Rows[0]["Retainer"].ToString();
    //            }

    //            if (ds4.Tables[0].Rows[0]["Executive"].ToString() == "" || ds4.Tables[0].Rows[0]["Executive"].ToString() == null)
    //            {
    //               // obj_RCB._headoffice = ds4.Tables[0].Rows[0]["client"].ToString();
    //            }
    //            else
    //            {
    //                obj_RCB._repname = ds4.Tables[0].Rows[0]["Executive"].ToString();
    //            }

    //            //    obj_RCB.txtpackname1 = packagename.ToString();
    //            dytbl = "";
    //            /////////////////////////////////////////// dynamic table vishwajeet  ***************
    //            int count = ds4.Tables[1].Rows.Count;
    //            int i;

    //            dytbl += "<table width='662px' align='left' cellpadding='0' cellspacing='0'>";
    //            {
    //                DataSet dsb = new DataSet();
    //                dsb.ReadXml(Server.MapPath("XML/bill_format.xml"));
    //                dytbl += "<tr align=center >";
    //               // dytbl += "<td class='insertiontxtclass1'  align='center'  width='10px' >" + dsb.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
    //              //  dytbl += "<td class='insertiontxtclass1'  align='center'  width='150px'>" + dsb.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
    //                dytbl += "</tr>";
    //            }
    //            for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
    //            {
                   
    //                dytbl += "<tr align=center height='67px'>";
    //               // dytbl += "<td class='upkardnamicclass1' align='center' >" + ds4.Tables[0].Rows[i]["No_Insert"].ToString() + "</td>";

    //                if (ds4.Tables[0].Rows[i]["Publication"].ToString() != "")
    //                {
    //                    dytbl += "<tr><td  class='upkardnamicclass1' align='left'  width='150px' > " + ds4.Tables[0].Rows[i]["No_Insert"].ToString() + "</td>";
    //                   // dytbl += "<td  class='upkardnamicclass2' align='right' width='150px' >" + ds4.Tables[0].Rows[i]["Publication"].ToString() + "</td></tr>";

    //                    dytbl += "<td class='upkardnamicclass1' align='left'  width='150px' >" + ds4.Tables[0].Rows[i]["Publication"].ToString() + "<td>";
    //                    dytbl += "<td  class='upkardnamicclass2' align='right' width='150px' >" + ds4.Tables[0].Rows[i]["Gross_amount"].ToString() + "</td></tr>";

    //                }
                   
    //  //  dytbl += "<td class='insertiontxtclass'align='left' width='150px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                    
    //                else
    //                {
    //                    dytbl += "<tr><td   class='upkardnamicclass2' align='left' width='150px' >" + "--" + "</td></tr>";
    //                }


    //                if (ds4.Tables[0].Rows[i]["language"].ToString() != "")
    //                {
    //                    dytbl += "<tr><td  class='upkardnamicclass2' align='left'  width='150px' >" + ds4.Tables[0].Rows[i]["language"].ToString() + "</td></tr>";
                     
    //                }

     


    //                else
    //                {
    //                    dytbl += "<tr><td   class='upkardnamicclass2' align='left' width='150px' >" + "--" + "</td></tr>";
    //                }
                    



                 
    //                if (ds4.Tables[0].Rows[i]["Edition"].ToString() != "")
    //                {

    //                    {
    //                        dytbl += "<tr><td   class='upkardnamicclass2' align='left' width='150px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString().Split('-')[0] + "</td></tr>";
    //                    }
    //                }
    //                else
    //                {
    //                    dytbl += "<tr><td  class='upkardnamicclass2' align='left' >--</td></tr>";

    //                }

    //                if (ds4.Tables[0].Rows[i]["Edition_Name"].ToString() == "MAIN")
    //                {

    //                    {
    //                        dytbl += "<tr><td   class='upkardnamicclass2' align='left' width='150px' >All India Distribution</td></tr>";
    //                    }
    //                }
    //                else if(ds4.Tables[0].Rows[i]["Edition_Name"].ToString() !="MAIN")
    //                {
    //                    dytbl += "<tr><td  class='upkardnamicclass2' align='left' >" + ds4.Tables[0].Rows[i]["Edition_Name"].ToString() + "&nbsp;Distribution</td></tr>";

    //                }










    //                if (ds4.Tables[0].Rows[i]["premium_name"].ToString() != "")
    //                {

    //                    {
    //                        dytbl += "<tr><td   class='upkardnamicclass2' align='left' width='150px' >" + ds4.Tables[0].Rows[i]["premium_name"].ToString() + "</td></tr>";
    //                    }
    //                }
    //                else
    //                {
    //                    dytbl += "<tr><td  class='upkardnamicclass2' align='left' >--</td></tr>";

    //                }



    //                if (ds4.Tables[0].Rows[i]["col_name"].ToString() != "")
    //                {

    //                    {
    //                        dytbl += "<tr><td   class='upkardnamicclass2' align='left' width='150px' >" + ds4.Tables[0].Rows[i]["col_name"].ToString() + "</td></tr>";
    //                    }
    //                }
    //                else
    //                {
    //                    dytbl += "<tr><td  class='upkardnamicclass2' align='left' >--</td></tr>";

    //                } 
                    
    //                //dytbl += "<tr><td   class='upkardnamicclass1' align='left' width='150px' >" + ds4.Tables[0].Rows[i].ItemArray[7].ToString() + "</td></tr>";

                    
                   
                    
                    
                    
                    
    //                if (ds4.Tables[0].Rows[i]["Caption"].ToString() != "")
    //                {

    //                    {

                           
                            
    //                        dytbl += "<td class='upkardnamicclass3' align='left' width='150px' > CAPTION:" + ds4.Tables[0].Rows[i]["Caption"].ToString() + "</td></tr>";
    //                    }
    //                }
    //                else
    //                {
                       
                        
    //                    dytbl += "<tr><td  class='upkardnamicclass3' align='left' >--</td></tr>";

    //                }

    //                if (ds4.Tables[0].Rows[i]["Remark"].ToString() != "")
    //                {

    //                    {



    //                        dytbl += "<td class='upkardnamicclass3' align='left' width='150px' > REMARK:" + ds4.Tables[0].Rows[i]["Remark"].ToString() + "</td></tr>";
    //                    }
    //                }
    //                else
    //                {


    //                    dytbl += "<tr><td  class='upkardnamicclass3' align='left' >--</td></tr>";

    //                }
                    
                    
    //                if (ds4.Tables[0].Rows[i]["Ins.date"].ToString() != "")
    //                 {

    //                     {

    //                         string[] arr = ds4.Tables[0].Rows[0]["Ins.date"].ToString().Split('/');
    //                         string dd = arr[1];
    //                         string mm = arr[0];
    //                         string yy = arr[2];
    //                         dateto = dd + "/" + mm + "/" + yy;

    //                         string.Format("{0:MMMM,yyyy}", dateto);
    //                         string dateofissue = (string.Format("{0:MMMM,yyyy}", (DateTime.Parse(dateto)).AddMonths(1)));

    //                        dytbl += "<tr><td  class='upkardnamicclass3' align='left' >ISSUE- " + dateofissue + "</td></tr>";

                         
    //                     }
    //                 }
    //                 else
    //                 {
    //                     dytbl += "<tr><td   class='upkardnamicclass3' align='left >--</td></tr>";

    //                 }
                    
    //                 if (ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() != "")
    //                 {
    //                     abc1 = abc1 + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());
    //                 }
    //                    dytbl += "</tr>";
    //            }






               



    //            dytbl += "</tr>";
    //            //maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
    //            // }  //
    //            if (p1 == pagecount - 1)
    //            {
    //               // flag = 1;
    //                abc2 = abc1;
    //                obj_RCB.txtgr1 = abc1.ToString("F2");
    //                amtinpr = ((abc1 * pr1) / 100);
    //                amtinpr = amtinpr + spl_chg1;
    //                obj_RCB.lbextrapre1 = amtinpr.ToString("F2");
    //                abc1 = abc1 - amtinpr;
    //                obj_RCB.amount11 = abc1.ToString("F2");
    //                pr1 = (amtinpr * 100) / abc1;
    //                pr1 = pr1;
    //                string new1 = pr1.ToString("F2");
    //                //obj_RCB.lbextpre1 = "Ex.Prem." + "(" + new1 + ")" + "%";
    //                DISCAMT = abc2 * dis1 / 100;

    //                obj_RCB.txtdiscal1 = DISCAMT.ToString("F2");
    //               // obj_RCB.tradedis1 = dis1.ToString("F2");
    //                obj_RCB.tradedis1 = "" + "(" + dis + ")" + "%";
    //                DISCADTD = abc2 * disn1 / 100;
    //                obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
    //                double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT));
    //                net = Math.Round(net);
    //                obj_RCB.netpay1 = net.ToString("F2");
    //               // obj_RCB.round_text1 = Math.Round(net + 0.01).ToString();
    //                NumberToEngish obj = new NumberToEngish();
    //                obj_RCB._rupessin = obj.changeNumericToWords(net.ToString()) + "Only";
                   

    //                abc1 = 0;
    //            }
              


    //            dytbl += "</table>";
    //            obj_RCB.dynamictable1 = dytbl;
    //            obj_RCB.setReceiptData();
    //            Page.Controls.Add(obj_RCB);
            
            
    //        }



    //    ///////////////////////
           
    //        ////////////////////////////////////  }
    //        //  Response.Redirect("pdf.aspx");
    //    }
    //}





    //private void BindPrintFormreprintmonthlyn_uday(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice, string hiddensession)
    //{
    //    int chkfr = 0;
    //    int chkglob = 0;
    //    string day = "";
    //    string month = "";
    //    string year = "";
    //    string date = "";
    //    double amt1 = 0;
    //    double amt2 = 0;
    //    double amt3 = 0;
    //    double comm2 = 0;
    //    double boxamt2 = 0;
    //    int agnew;
    //    double gm = 0;

    //    string maxdate = "";
    //    int inew;
    //    double gros_amt = 0;
    //    double trade_dis = 0;
    //    double adtd = 0;
    //    double trate = 0;
    //    double textrarate = 0;
    //    double tgross = 0;
    //    double tcash_dis = 0;
    //    double tadd_comm = 0;
    //    double tbox_charge = 0;
    //    double tvts = 0;
    //    int p = 0;
    //    string edit_name = "";
    //    string insertion_date = "";
    //    string test_bookingId = "";

    //    string dytbl = "";
    //    string[] bookingid5ag = ciobookid.Split('^');


    //    string maxinsert = "";

    //    string[] agencycode1 = agencycode.Split(',');
    //    string[] client1 = client.Split(',');
    //    string[] invoice1 = invoice.Split(',');
    //    string agcode = "";
    //    string Client = "";
    //    string invoicenn = "";
    //    int newvar = 0;
    //    int u = 0;
    //    float ht = 50;

    //    DataSet ds4 = new DataSet();
    //    for (inew = 0; inew < c4; inew++)
    //    {
    //        u = 0;

    //        //billformat_classified objcard = new billformat_classified();
    //        //objcard = (billformat_classified)Page.LoadControl("billformat_classified.ascx");


    //        amt1 = 0;
    //        amt2 = 0;
    //        gros_amt = 0;
    //        trade_dis = 0;

    //        invoicenn = invoice1[inew];

    //        agcode = agencycode1[inew];
    //        // Client = client1[inew];
    //        string bookingidn = bookingid5ag[inew];
    //        string[] bookingid4ag = bookingidn.Split(',');

    //        string bookingidn11 = bookingidn.Replace(",", "','");


    //        int countlen = bookingid4ag.Length;


    //        // for (agnew = 0; agnew < countlen; agnew++)
    //        // {

    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //            ds4 = objvalues1.selectmonthlynew_b(agcode, fromdate, dateto, bookingidn, Client, Session["dateformat"].ToString(), bookingidn);
    //        }
    //        else
    //        {
    //            NewAdbooking.BillingClass.Classes.session_billing objvalues1 = new NewAdbooking.BillingClass.Classes.session_billing();
    //            ds4 = objvalues1.selectmonthlynew_b(agcode, fromdate, dateto, bookingidn, Client, Session["dateformat"].ToString(), bookingidn);

    //        }

    //        int fr1 = 0;
    //        int maxlimit = 22;
    //        int rowcounter = 0;
    //        int ct = 0;
    //        int fr = maxlimit;
    //        int srl = 1;
    //        // int rcount = ds4.Tables[0].Rows.Count + ds4.Tables[3].Rows.Count;
    //        int rcount = ds4.Tables[0].Rows.Count;
    //        int pagec = rcount % maxlimit;
    //        int pagecount = rcount / maxlimit;
    //        if (pagec > 0)
    //        {
    //            pagecount = pagecount + 1;
    //        }
    //        dytbl = "";
    //        int i = 0;
    //        for (int p1 = 0; p1 < pagecount; p1++)
    //        {

    //            dytbl = "";
    //            udayvani_bill_classi objcard = new udayvani_bill_classi();
    //            objcard = (udayvani_bill_classi)Page.LoadControl("udayvani_bill_classi.ascx");
    //            ct = maxlimit * p1;
    //            fr = maxlimit * (p1 + 1);

    //            objcard.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
    //            objcard.lbcityname1 = ds4.Tables[0].Rows[0]["Dist_code"].ToString();


    //            string telefax = "";
    //            if (ds4.Tables[0].Rows[0]["fax"].ToString() != "")
    //            {
    //                telefax = ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();

    //            }
    //            else
    //            {
    //                telefax = "";
    //            }


    //            objcard.lbagencyaddtxt1 = ds4.Tables[0].Rows[0]["add1"].ToString() + "," + ds4.Tables[0].Rows[0]["add2"].ToString() + "," + ds4.Tables[0].Rows[0]["add3"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + telefax + "-" + ds4.Tables[0].Rows[0]["fax2"].ToString();

    //            objcard.lblpubname1 = ds4.Tables[0].Rows[0]["pub"].ToString();
    //            objcard.lbadcattxt1 = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();
    //            objcard.runtxt1 = ds4.Tables[0].Rows[0]["BILL_DATE"].ToString();
    //            objcard.ldduedate1 = ds4.Tables[0].Rows[0]["DUE_DATE"].ToString();
    //            string date_update = "";
    //            string[] due;
    //            string mm = "";
    //            string lastdate = "";
    //            if (ds4.Tables[0].Rows[0]["DUE_DATE"].ToString() != "")
    //            {
    //                date_update = ds4.Tables[0].Rows[0]["DUE_DATE"].ToString();
    //                due = date_update.Split('/');
    //                mm = due[1].ToString();
    //                int yeaarr = Convert.ToInt16(due[2]);
    //                int mm2 = Convert.ToInt16(mm);
    //                int date111 = System.DateTime.DaysInMonth(yeaarr, mm2);
    //                //lastdate = new DateTime(10, 2011, 1).AddDays(-1);
    //                objcard.ldduedate1 = date111 + "/" + mm + "/" + due[2];
    //            }

    //            objcard.txtinvoice1 = invoicenn.ToString();











    //            dytbl += "<table width='660px' align='left' cellpadding='0' cellspacing='0';>";
    //            {
    //                DataSet dsb = new DataSet();
    //                dsb.ReadXml(Server.MapPath("XML/udyavani.xml"));

    //                //Sign Image

    //                DataSet sigimg = new DataSet();
    //                sigimg.ReadXml(Server.MapPath("XML/bill.xml"));

    //                string path = "Images/" + sigimg.Tables[1].Rows[0].ItemArray[1].ToString();// ds4.Tables[0].Rows[0]["FILE_PATH"].ToString();
    //                if (System.IO.File.Exists(Server.MapPath(path)))
    //                {
    //                    objcard.imgpath = "<img src='" + path + "' height='" + ht + "'>";
    //                }

    //                dytbl += "<tr align=center >";
    //                dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[62].ToString() + "</td>";
    //                dytbl += "<td width='120px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
    //                dytbl += "<td width='65px' class='insertiontxtclass1'' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
    //                dytbl += "<td width='35px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[39].ToString() + "</td>";
    //                dytbl += "<td width='75px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";

    //                // dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[49].ToString() + "</td>";
    //                dytbl += "<td width='40px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
    //                dytbl += "<td  width='25px'class='insertiontxtclass1'' >" + dsb.Tables[0].Rows[0].ItemArray[40].ToString() + "</td>";
    //                dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";

    //                //dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";

    //                // dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";

    //                dytbl += "<td width='50px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
    //                dytbl += "<td width='30px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
    //                //  dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[49].ToString() + "</td>";
    //                dytbl += "<td width='25px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[60].ToString() + "</td>";
    //                dytbl += "<td width='45px' class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[61].ToString() + "</td>";

    //                dytbl += "</tr>";
    //            }


    //            chkglob = 0;

    //            for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
    //            {
    //                // chkglob = 0;

    //                dytbl += "<tr align=center >";
    //                string adsub_catnew = ds4.Tables[0].Rows[i]["adsub_cat"].ToString();
    //                char[] adsub_cat = adsub_catnew.ToCharArray();
    //                int ch = 0;
    //                string adsub_cat1 = "";
    //                int len11N = adsub_catnew.Length;
    //                string bookingidn1 = ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString();


    //                char[] book = bookingidn1.ToCharArray();
    //                int len11 = bookingidn1.Length;

    //                int chnew = 0;
    //                string addbook = "";
    //                string chk_old = bookingidn1;
    //                // calculation for packagewise
    //                if (p == 0)
    //                {
    //                    trate = trate + Convert.ToDouble(ds4.Tables[0].Rows[i]["Card_rate"].ToString());
    //                    tgross = tgross + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());
    //                    edit_name = ds4.Tables[0].Rows[i]["RO_No"].ToString();
    //                    insertion_date = ds4.Tables[0].Rows[i]["Ins.date"].ToString();
    //                    test_bookingId = ds4.Tables[0].Rows[i]["Cio_Booking_Id"].ToString();

    //                    for (int k = i; k < (ds4.Tables[0].Rows.Count - 2); k++)
    //                    {
    //                        string[] pac = ds4.Tables[0].Rows[k]["Edition"].ToString().Split('+');
    //                        int packlength = pac.Length;
    //                        // if (ds4.Tables[0].Rows[k]["RO_No"].ToString() == ds4.Tables[0].Rows[k + 1]["RO_No"].ToString() && packlength > 1)
    //                        if ((ds4.Tables[0].Rows[k]["RO_No"].ToString() == ds4.Tables[0].Rows[k + 1]["RO_No"].ToString()) && (ds4.Tables[0].Rows[k]["Ins.date"].ToString() == ds4.Tables[0].Rows[k + 1]["Ins.date"].ToString()) && (ds4.Tables[0].Rows[k]["Cio_Booking_Id"].ToString() == ds4.Tables[0].Rows[k + 1]["Cio_Booking_Id"].ToString()))
    //                        {
    //                            if (ds4.Tables[0].Rows[k]["Card_rate"].ToString() != "")
    //                            {
    //                                trate = trate + Convert.ToDouble(ds4.Tables[0].Rows[k + 1]["Card_rate"].ToString());
    //                            }
    //                            else
    //                            {
    //                                trate = trate + Convert.ToDouble(ds4.Tables[0].Rows[k + 1]["agreed_rate"].ToString());

    //                            }

    //                            //textrarate = textrarate;
    //                            tgross = tgross + Convert.ToDouble(ds4.Tables[0].Rows[k + 1]["Gross_Rate"].ToString());

    //                        }
    //                        else
    //                        {
    //                            //edit_name = ds4.Tables[0].Rows[k]["Edition"].ToString();
    //                            k = ds4.Tables[0].Rows.Count - 2;
    //                            // p=1;
    //                            // break;
    //                        }
    //                    }
    //                }

    //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //                {
    //                    string DATENEW = ds4.Tables[0].Rows[i]["month"].ToString();
    //                    string[] DATENEW1 = DATENEW.Split('-');
    //                    //objcard.lbformonthtxt1 = DATENEW1[1].ToString() + DATENEW1[2].ToString();
    //                }
    //                else
    //                {
    //                    string DATENEW = ds4.Tables[0].Rows[i]["month"].ToString();
    //                    string[] DATENEW1 = DATENEW.Split(' ');
    //                    //objcard.lbformonthtxt1 = DATENEW1[1].ToString() + DATENEW1[2].ToString();


    //                }

    //                if (p == 0)
    //                {
    //                    dytbl += "<td width='25px'  class=display align='CENTER' >" + srl.ToString() + "</td>";
    //                    srl++;
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='25px'  class=display align='CENTER' >--</td>";
    //                }

    //                dytbl += "<td  width='120px' class=display height='30px' align='LEFT'>" + ds4.Tables[0].Rows[i]["client"].ToString() + "</td>";
    //                if (ds4.Tables[0].Rows[i]["CAPTION"].ToString() != "")
    //                {
    //                    dytbl += "<td width='120px' class=display align='LEFT' >" + ds4.Tables[0].Rows[i]["CAPTION"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='65px' class=display align=left>---</td>";
    //                }


    //                if (ds4.Tables[0].Rows[i]["RO_No"].ToString() != "")
    //                {
    //                    dytbl += "<td width='35px'  class=display  align=left >" + ds4.Tables[0].Rows[i]["RO_No"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='35px' class=display align=left>---</td>";
    //                }

    //                if (ds4.Tables[0].Rows[i]["EDITIONNAME"].ToString() != "")
    //                {
    //                    dytbl += "<td  class=display width='75px'  align=LEFT>" + ds4.Tables[0].Rows[i]["EDITIONNAME"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='75px' class=middleforbill >-</td>";
    //                }

    //                dytbl += "<td class=display width='40px'  >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";


    //                if (ds4.Tables[0].Rows[i]["Col_Name"].ToString() != "")
    //                {

    //                    string col = ds4.Tables[0].Rows[i]["Col_Name"].ToString();
    //                    col = col.Substring(0, 3);
    //                    string col1 = col;
    //                    col1 = col1.Substring(0, 1);
    //                    if (col1 == "B")
    //                    {
    //                        col = "B/W";
    //                    }
    //                    dytbl += "<td width='25px' ALIGN='center' class=display   align=center class=display >" + col + "</td>";
    //                    //dytbl += "<td  class='schemeclass' width='55px' >" + ds4.Tables[0].Rows[i]["Col_Name"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='25px' class='middleforbill' >-</td>";

    //                }


    //                if (ds4.Tables[0].Rows[i]["PAGE_NO"].ToString() != "")
    //                {
    //                    dytbl += "<td width='25px' class=display ALIGN='center'  >" + ds4.Tables[0].Rows[i]["PAGE_NO"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='25px' class='middleforbill' ALIGN='center' >-</td>";

    //                }


    //                if (ds4.Tables[0].Rows[0]["Width"].ToString() != "")
    //                {
    //                    if (ds4.Tables[0].Rows[0]["uom_code"].ToString() == "CO0")
    //                    {
    //                        dytbl += "<td width='50px'  align=center class=display >" + ds4.Tables[0].Rows[i]["width1"].ToString() + "*" + ds4.Tables[0].Rows[0]["Depth"].ToString() + "</td>";
    //                    }
    //                    else
    //                    {
    //                        dytbl += "<td width='50px'  align=center class=display >" + ds4.Tables[0].Rows[i]["Width"].ToString() + "*" + ds4.Tables[0].Rows[0]["Depth"].ToString() + "</td>";
    //                    }
    //                }
    //                else if (ds4.Tables[0].Rows[0]["Size_Book"].ToString() != "")
    //                {
    //                    dytbl += "<td width='50px'  align=center class=display >" + ds4.Tables[0].Rows[i]["Size_Book"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td width='50px' class=display  align=center>---</td>";
    //                }

    //                if (p == 0)
    //                {
    //                    dytbl += "<td class=display width='30px'   ALIGN='center'>" + trate + "</td>";
    //                    trate = 0;

    //                }
    //                else
    //                {
    //                    dytbl += "<td class=display width='30px'   ALIGN='center'>--</td>";
    //                }


    //                if (ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString() != "")
    //                {
    //                    //dytbl += "<td class='schemeclass' width='35px'  ALIGN='RIGHT'>" + Convert.ToDouble(ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString()) + "</td>";

    //                    adtd = adtd + Convert.ToDouble(ds4.Tables[0].Rows[i]["AD AGENCY COMM AMT"].ToString());
    //                }
    //                else
    //                {
    //                    //dytbl += "<td  class='middleforbill' >-</td>";
    //                }
    //                //dytbl += "<td ALIGN='RIGHT' width='25px' class=display   ALIGN='center' class=display>---</td>";
    //                if (ds4.Tables[0].Rows[i]["Extra"].ToString() != "" && ds4.Tables[0].Rows[i]["Extra"].ToString() != null && p == 0)
    //                {
    //                    dytbl += "<td ALIGN='RIGHT' width='25px' class=display   ALIGN='center' class=display>" + ds4.Tables[0].Rows[i]["Extra"].ToString() + "</td>";
    //                }
    //                else
    //                {
    //                    dytbl += "<td ALIGN='RIGHT' width='25px' class=display   ALIGN='center' class=display>---</td>";
    //                }

    //                if (p == 0)
    //                {
    //                    dytbl += "<td ALIGN='center' width='45px' class=display  >" + tgross + "</td>";
    //                    tgross = 0;
    //                }
    //                else
    //                {
    //                    dytbl += "<td ALIGN='center' width='45px' class=display  >--</td>";
    //                }



    //                if (ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString() != "")
    //                {
    //                    // dytbl += "<td class='insertiontxtclassCLA' width='35px' >" + ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString() + "</td>";
    //                    trade_dis = trade_dis + Convert.ToDouble(ds4.Tables[0].Rows[i]["TRADE DISC AMT"].ToString());
    //                }

    //                dytbl += "</tr>";

    //                rowcounter++;

    //                gros_amt = gros_amt + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());
    //                string amt = ds4.Tables[0].Rows[i]["netamt"].ToString();
    //                //for additional amount and extra
    //                if (ds4.Tables[0].Rows[i]["vts"].ToString() != "" && ds4.Tables[0].Rows[i]["vts"].ToString() != null)
    //                {
    //                    tvts = tvts + Convert.ToDouble(ds4.Tables[0].Rows[i]["vts"].ToString());
    //                }
    //                if (ds4.Tables[0].Rows[i]["comm_dis"].ToString() != "")
    //                {
    //                    tadd_comm = tadd_comm + Convert.ToDouble(ds4.Tables[0].Rows[i]["comm_dis"].ToString());
    //                }
    //                if (ds4.Tables[0].Rows[i]["cash_dis"].ToString() != "" && ds4.Tables[0].Rows[i]["cash_dis"].ToString() != null)
    //                {
    //                    tcash_dis = tcash_dis + Convert.ToDouble(ds4.Tables[0].Rows[i]["cash_dis"].ToString());
    //                }
    //                // srl++;

    //                // ct = ct + i ;
    //                //fr = ct + i;
    //                objcard.hidetab1 = "hide";

    //                if (i < ds4.Tables[0].Rows.Count - 1)
    //                {
    //                    string[] pac = ds4.Tables[0].Rows[i]["Edition"].ToString().Split('+');
    //                    int packlength = pac.Length;
    //                    //if (edit_name == ds4.Tables[0].Rows[i + 1]["RO_No"].ToString() && packlength > 1)
    //                    if ((edit_name == ds4.Tables[0].Rows[i + 1]["RO_No"].ToString()) && (insertion_date == ds4.Tables[0].Rows[i + 1]["Ins.date"].ToString()) && (test_bookingId == ds4.Tables[0].Rows[i + 1]["Cio_Booking_Id"].ToString()))
    //                        p = 1;
    //                    else
    //                        p = 0;

    //                }
    //            }
    //            if (p1 == pagecount - 1)
    //            {

    //                objcard.hidetab1 = "show";
    //                objcard.lbtotal1 = gros_amt.ToString("F2");

    //                string TERMS = "";
    //                if (ds4.Tables[0].Rows[0]["branch"].ToString() == "MUMBAI")
    //                {
    //                    TERMS = "MUMBAI".ToString();
    //                }
    //                else
    //                {
    //                    TERMS = "AURANGABAD".ToString();

    //                }
    //                string billamtamt1 = ds4.Tables[4].Rows[0]["Bill_Amt"].ToString();
    //                double bill_amt_new = Convert.ToDouble(billamtamt1);
    //                bill_amt_new = Math.Round(bill_amt_new);

    //                objcard.lbltradedis1 = trade_dis.ToString();
    //                objcard.lbladddis1 = (tcash_dis + tadd_comm).ToString("F2");
    //                objcard.lblextra1 = tvts.ToString("F2");
    //                objcard.lblnetamt1 = ds4.Tables[4].Rows[0]["Bill_Amt"].ToString();
    //                objcard.lblround1 = bill_amt_new.ToString();
    //                NumberToEngish obj = new NumberToEngish();
    //                objcard.rupeetxt1 = obj.changeNumericToWords(bill_amt_new.ToString());

    //            }
    //            dytbl += "</table>";
    //            objcard.dynamictable1 = dytbl;
    //            objcard.setReceiptData();
    //            Page.Controls.Add(objcard);


    //        }

    //    }




    //}






  //  private void pdf_drillout(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
  //  {


  //      //IPdfManager objPdf = new PdfManager();
  //      //IPdfDocument objDoc = objPdf.CreateDocument(Missing.Value);
  //      //objDoc.ImportFromUrl("http://www.persits.com", Missing.Value, Missing.Value, Missing.Value);

  //      //String strFilename = objDoc.Save(Server.MapPath("importfromurl.pdf"), false); 

  //      /* bool flag = true;
  //       int inew2 = 0;
  //       int inew = 0;
  //       int fix = 2;
  //       double abc = 0;
  //       double comm2 = 0;
  //       double boxamt2 = 0;

  //       double abc1 = 0;
  //       double amtinpr = 0;
  //       double abc2 = 0;
  //       string maxinsert = "";
  //       string dytbl = "";
  //       //int flag=0;

  //       DataSet pdfxml = new DataSet();
  //       pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
  //       string pdfName = "";
  //       pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
  //       string name = Server.MapPath("") + "//" + pdfName;

  //       string[] countbookid2 = ciobookid.Split(',');
  //       string[] invoice1 = invoice.Split(',');

  //      for (inew = 0; inew < countbookid2.Length; inew++)
  //       {

  //           string bookingid = countbookid2[inew];
  //           string invoice2 = invoice1[inew];
            
  //           RCB1 obj_RCB1 = new RCB1();
  //           obj_RCB1 = (RCB1)Page.LoadControl("RCB1.ascx");
  //           DataSet ds4 = new DataSet();

  //       Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

  //       PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
  //       int i2 = 0;
      

    
  //       HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
  //       footer.Border = Rectangle.NO_BORDER;
  //       footer.Alignment = Element.ALIGN_CENTER;
  //       document.Footer = footer;

  //       document.Open();

  //       int NumColumns = 12;
  //       Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
  //       Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
  //       Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8);

  //       try
  //       {
  //           DataSet ds1 = new DataSet();
  //           ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
   
  //           PdfPTable tbl = new PdfPTable(1);
  //           float[] xy = { 100 };
  //           tbl.DefaultCell.BorderWidth = 0;
  //           tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
  //           tbl.setWidths(xy);
  //           tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;

  //           tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[30].ToString(), font9));
      
  //           float[] headerwidths1 = { 50 };
  //           tbl.setWidths(headerwidths1);
  //           tbl.WidthPercentage = 100;
  //           document.Add(tbl);

  //           PdfPTable tbl1 = new PdfPTable(1);
  //           tbl1.DefaultCell.BorderWidth = 0;
  //           tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
  //           tbl1.addCell("");
  //           tbl1.WidthPercentage = 100;
           
  //           int i;
  //           for (i = 0; i < 2; i++)
  //           {
  //               document.Add(tbl1);
  //           }

  //           PdfPTable tbl2 = new PdfPTable(6);
  //           tbl2.DefaultCell.BorderWidth = 0;
  //           tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
  //           tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
  //           tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
  //           tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
  //           tbl2.addCell(new Phrase(dateto1.ToString(), font11));
  //           tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
  //           tbl2.addCell(new Phrase(date.ToString(), font11));
  //           tbl2.WidthPercentage = 100;
  //           document.Add(tbl2);


   
  //           PdfPTable datatable = new PdfPTable(NumColumns);
  //           datatable.DefaultCell.Padding = 3;
  //           datatable.WidthPercentage = 100;
  //           datatable.DefaultCell.BorderWidth = 0;
  //           datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
         
  //           datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
  //           datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[1].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[50].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
         
  //           datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString(), font10));
  //           datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));

  //           datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
  //           datatable.HeaderRows = 1;


  //           Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


  //           document.Add(p2);

  //         //  NewAdbooking.Classes.bill obj1 = new NewAdbooking.Classes.bill();
  //         //  SqlDataAdapter da = new SqlDataAdapter();
  //           DataSet ds = new DataSet();
  ////           ds = obj1.drillout(fromdate, todate, region, product, category, compcode, Session["dateformat"].ToString(), agency, client, publication, adtype, payment, billstatus, myrange, maxrange, descid, ascdesc);

  //           for (inew = 0; inew < countbookid2.Length; inew++)
  //           {

  //               // NEWGROSSAMT = 0.0;

  //               string bookingid = countbookid2[inew];
  //               string invoice2 = invoice1[inew];



  //               RCB1 obj_RCB1 = new RCB1();
  //               obj_RCB1 = (RCB1)Page.LoadControl("RCB1.ascx");
  //               DataSet ds4 = new DataSet();

  //               NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
  //               ds = objvalues1.selectlastnew_billed(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());


  //               int row = 0;

  //               int i1 = 1;
  //               while (row < ds.Tables[0].Rows.Count)
  //               {



  //                   datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
  //                   datatable.addCell(new Phrase(i1++.ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Edition"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Height"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color_code"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page_No"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Card_Rate"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Gross_Rate"].ToString(), font11));
  //                   if (ds.Tables[0].Rows[row].ItemArray[3].ToString() != "")
  //                       area = area + float.Parse(ds.Tables[0].Rows[row]["Gross_Rate"].ToString());
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Gross_Rate"].ToString(), font11));
  //                   if (ds.Tables[0].Rows[row].ItemArray[6].ToString() != "")
  //                       BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["Gross_Rate"].ToString());
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Gross_Rate"].ToString(), font11));
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Gross_Rate"].ToString(), font11));
  //                   if (ds.Tables[0].Rows[row]["Gross_Rate"].ToString() != "")
  //                       billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["Gross_Rate"].ToString());
  //                   datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Gross_Rate"].ToString(), font11));
  //                   row++;

  //               }

  //               document.Add(datatable);

  //               Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));
  //               document.Add(p3);

  //               PdfPTable tbltotal = new PdfPTable(13);
  //               float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16 }; // percentage
  //               tbltotal.setWidths(headerwidths);
  //               tbltotal.DefaultCell.BorderWidth = 0;
  //               tbltotal.WidthPercentage = 100;
  //               tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
  //               tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
  //               tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
  //               tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
  //               tbltotal.addCell(new Phrase(" ", font11));
  //               tbltotal.addCell(new Phrase(" ", font11));
  //               tbltotal.addCell(new Phrase(" ", font11));
  //               tbltotal.addCell(new Phrase(" ", font11));
  //               tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
  //               tbltotal.addCell(new Phrase(area.ToString(), font11));
  //               tbltotal.addCell(new Phrase(" ", font11));

  //               tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
  //               tbltotal.addCell(new Phrase(" ", font11));
  //               tbltotal.addCell(new Phrase(billarea.ToString(), font11));
  //               tbltotal.addCell(new Phrase(" ", font11));


  //               document.Add(tbltotal);





  //               document.Close();


  //               Response.Redirect(pdfName);
  //           }

  //       }

  //       }
  //       catch (Exception e)
  //        {
  //           Console.Error.WriteLine(e.StackTrace);
  //       }*/
  //  }


}
