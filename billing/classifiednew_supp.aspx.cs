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

public partial class classifiednew_supp : System.Web.UI.Page
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
    System.Web.HttpBrowserCapabilities browser;
    string trade_disc = "";
    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        string url1 = HttpContext.Current.Request.Url.ToString();
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
            trade_disc = Session["trade_disc"].ToString();
        }
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

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
                trade_disc = Session["trade_disc"].ToString();
            }
                    
           // BindPrintFormreprintmonthlyn(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

        }
        if (checkradio == "first")
        {
           // BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        else
            if (checkradio == "7")
            {

                onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, trade_disc);
               

            }   



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
        //int flag=0;
        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice1 = invoice.Split(',');
        string addition_flag = "";
        string[] trade_discn = trade_disc.Split(',');
        for (inew = 0; inew < countbookid2.Length; inew++)
        {


            string bookingid = countbookid2[inew];
            string invoice2 = invoice1[inew];
            trade_disc = trade_discn[inew];



            RCB1_supp obj_RCB1 = new RCB1_supp();
            obj_RCB1 = (RCB1_supp)Page.LoadControl("RCB1_supp.ascx");
            DataSet ds4 = new DataSet();

            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds4 = objvalues1.selectlastnew_billed_supp(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());
                        
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
                RCB1_supp obj_RCB = new RCB1_supp();
                obj_RCB = (RCB1_supp)Page.LoadControl("RCB1_supp.ascx");

                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                if (trade_disc == "0")
                {
                    obj_RCB.lbtrade11 = "0";
                    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                    obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();
                }
                obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();  //Address//
                if (trade_disc == "1")
                {
                    obj_RCB.lbtrade11 = "1";
                    obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();
                    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                }
                obj_RCB.lbcaption1 = ds4.Tables[0].Rows[0]["Caption"].ToString();
                obj_RCB.lblbradd = ds4.Tables[0].Rows[0]["Address1"].ToString();
                obj_RCB.txtinvoice1 = invoice2.ToString();
                obj_RCB.hidedata1 = "";
              
                if (System.IO.File.Exists(Server.MapPath(path)))
                {
                    obj_RCB.divimg1 = "<img src='" + path + "' height='" + finalheight + "'>";
                }



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



                obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["bill_date"].ToString();

           
                obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                obj_RCB.lbronodate1 = ds4.Tables[0].Rows[0]["RO_Date"].ToString();
                obj_RCB.txtronon1 = ds4.Tables[0].Rows[0]["RO_No"].ToString();
                obj_RCB.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                obj_RCB.lbemail1 = " Email: ";
                obj_RCB.lbpune1 = " Pan No: ";
                obj_RCB.EOU1 = " E.&O.E. ";
                obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();

                obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

               
                obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();
                obj_RCB.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();





                obj_RCB.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                string grossamt = ds4.Tables[0].Rows[0]["Gross_Rate"].ToString();
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
                
                addition_flag = ds4.Tables[0].Rows[0]["ADDITIONAL_FLAG"].ToString();

                string disn = ds4.Tables[0].Rows[0]["adtd"].ToString();
                double disn1 = 0;
                Double DISCADTD = 0;
                if (disn != "")
                {
                    disn1 = Convert.ToDouble(disn);
                }
                if (trade_disc == "0")
                {
                    if (addition_flag != "1")
                    {
                        obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";
                    }
                    else
                    {
                        disn1 = 0;
                        obj_RCB.lbadtd1 = "Ad Td" + "(" + disn1 + ")" + "%";
                    }
                }
                else
                {
                    obj_RCB.lbadtd1 = "1";
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

                obj_RCB.txtpackname1 = packagename.ToString();

                dytbl = "";

                /////////////////////////////////////////// dynamic table  ***************

                int count = ds4.Tables[1].Rows.Count;
                int i;
              
                {
                    DataSet dsb = new DataSet();
                   
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<table width='483px' align='left' cellpadding='0' cellspacing='0'>";
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass2' align='center' width='215px' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass2' align='right' width='60px'>" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass2' align='center'  width='35px' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass2'  align='center'  width='5px' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass2'  align='center'  width='32px' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                   
                    dytbl += "</tr>";
                }

                for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
                {
                    dytbl += "<tr align=center>";
                    dytbl += "<td class='insertiontxtclass'align='left' width='215px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center' 'width='60px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";



                    dytbl += "<td  class='insertiontxtclass' align='center' width='35px' >" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";

                   
                    if (ds4.Tables[0].Rows[i]["Color_code"].ToString() != "")
                    {
                        dytbl += "<td  class='insertiontxtclass' align='center' width='5px' >" + ds4.Tables[0].Rows[i]["Color_code"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='middleforbill'align='center' >-</td>";

                    }
                    dytbl += "<td class='insertiontxtclass'align='center' width='5px' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
                    
                    string cardrt = ds4.Tables[0].Rows[i]["Card_Rate"].ToString();
                    double cdr = 0;
                    if (cardrt != "")
                    {
                        cdr = Convert.ToDouble(cardrt);
                    }

                    grossamt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();

                    if (grossamt != "")
                    {
                        abc = Convert.ToDouble(grossamt);
                    }

                    abc1 = abc1 + abc;


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
                   
                    abc2 = abc1;

                    obj_RCB.txtgr1 = abc1.ToString("F2");


                    amtinpr = ((abc1 * pr1) / 100);
                    amtinpr = amtinpr + spec_charge_ins;
                    obj_RCB.lbextrapre1 = amtinpr.ToString("F2");
                    abc1 = abc1 - amtinpr;
                    obj_RCB.amount11 = abc1.ToString("F2");


                    DISCAMT = abc2 * dis1 / 100;

                    if (trade_disc == "0")
                    {
                        obj_RCB.txtdiscal1 = DISCAMT.ToString("F2");

                        obj_RCB.lbtrade11 = "TD" + "(" + dis + ")" + "%";
                        DISCADTD = abc2 * disn1 / 100;
                        if (addition_flag != "1")
                        {
                            obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
                        }
                        else
                        {
                            DISCADTD = 0;
                            obj_RCB.lbadtdtxt1 = DISCADTD.ToString("F2");
                        }
                    }
                    else
                    {
                        obj_RCB.lbtrade11 = "1";

                    }



                    if (addition_flag != "1")
                    {
                        double net = abc2 - ((abc2 * disn1 / 100) + (DISCAMT));
                        net = Math.Round(net);

                        obj_RCB.netpay1 = net.ToString("F2");
                    }
                    else
                    {
                        double net = abc2 - ((DISCAMT));
                        net = Math.Round(net);

                        obj_RCB.netpay1 = net.ToString("F2");
                    }

                    NumberToEngish obj = new NumberToEngish();

                    obj_RCB.lbemail1 = " Email: ";
                    obj_RCB.lbpune1 = " Pan No: ";
                    obj_RCB.EOU1 = " E.&O.E.";
                    obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();

                    string TERMS = "AURANGABAD".ToString();
                    string namme1 = "images/shree.jpg";
                    obj_RCB.insertiontxt1 = ds4.Tables[0].Rows[0]["No_of_insertion"].ToString();
                    obj_RCB.hidedata1 = "<b>Terms & Conditions </b>:1)Payment should be made in favour of <img src='" + namme1 + "'alt=''/> 2)Only official receipt issued by us will be binding on us.3) Objection or complaint regarding the bill if any should be brought to our notice within 15 days from the presentation of the bill,failing which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subject to <font style=font-size:11px;font-weight:bold>" + TERMS + " </font> Jurisdiction only. " + "&nbsp;" + "<b>(NOTE:</b> If you like to deposit the amount of invoice in the bank via <b>RTGS, NEFT & ECS</b>, then after doing so, please inform us immediately on Phone or Email.)";
                    abc1 = 0;


                }
                dytbl += "</table>";           

                obj_RCB.dynamictable1 = dytbl;

                obj_RCB.setReceiptData();



                Page.Controls.Add(obj_RCB);

            }
           

        }
    }

}