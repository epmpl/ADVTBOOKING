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

public partial class onlyforbillprintbycoll : System.Web.UI.Page
{
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
 
    static int current;
    static int a = 0;
    static int b = 1;
    static int i1 = 0;
    string branch;
    string qbc;
    static string frmdt = "";
    static string agencycode = "";
    static string client = "";

    static string refno = "";
    static string dateto1 = "";
    string clientnew = "";
    string invoice = "";
    string hiddensession = "";
    static string ciobookid = "";
    static string checkradio = "";
    static string insertion = "";
    static string editionbill = "";
    static string spl_dis = "";
    static string trad_dis = "";
    static string rborg = "";
    static string compcodenew = "";

    string flag = "";
    static string invoice_no = "";
    static string branchna = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
     
        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {

            ciobookid = Request.QueryString["ciobookid"].ToString(); ;
            checkradio = Request.QueryString["checkradio"].ToString(); 
            insertion = Request.QueryString["insertion"].ToString(); ;
            compcodenew = Request.QueryString["compcode"].ToString(); ;
            invoice_no = Request.QueryString["invoice"].ToString(); 
            branchna=Request.QueryString["branch"].ToString();
            frmdt = Request.QueryString["billdate1"].ToString();
            dateto1 = Request.QueryString["billdate1"].ToString();
                editionbill = "";
                spl_dis = "";
                trad_dis = "";
                rborg = "";


                hiddendateformat.Value = Request.QueryString["dateformate"].ToString();

                Session["compcode"] = compcodenew;
                Session["dateformat"] = hiddendateformat.Value;
                Session["revenue"] = branchna; 
           

        }
        string[] countbookid1 = ciobookid.Split(',');
        int c4 = countbookid1.Length;
        if (checkradio=="3")
        {
             BindPrintFormreprint(ciobookid, c4, insertion, editionbill, invoice_no);

        }
          else
            if (checkradio == "7")
            {
                onscreen_haribhoomi(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice_no);
            }
       
    }
    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string editionbill, string invoice_no)
    {


        int i3;
        int count = c4;
        int printcount = 0;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] invoice_no1 = invoice_no.Split(',');
        string[] editionbill2 = editionbill.Split('$'); //editionbill.Split(',');
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

            int i = 0;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {


                NewAdbooking.BillingClass.Classes.invoice objpkg = new NewAdbooking.BillingClass.Classes.invoice();
                ds1 = objpkg.packagecode(countbookid2[i3], compcodenew);
            }
            else
            {

                NewAdbooking.BillingClass.classesoracle.invoice objpkg = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds1 = objpkg.packagecode(countbookid2[i3], compcodenew, hiddendateformat.Value);

            }


            int count1 = ds1.Tables[0].Rows.Count;
            branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            string no_of_insertion = insertionnew.ToString();
            string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

            //    int count11 = Convert.ToInt16(no_of_insertion);


            string[] packagecode1 = packagecode2.Split(',');
            int c1 = packagecode1.Length;

            DataSet ds3 = new DataSet();

            int i11 = 1;
            int packlength = 1;

    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "haribhoomi")
    {
     
        haribhoomi_display objcard = new haribhoomi_display();
        objcard = (haribhoomi_display)(Page.LoadControl("haribhoomi_display.ascx"));

        objcard.valueofradio = checkradio.ToString();
        placeholder1.Controls.Add(objcard);

        objcard.invoiceno = invoice_no1[i3];
        objcard.invoiceno = invoice_no1[i3];
        if (i3 == count - 1)
        {
            objcard.chkvalue_length = "no";
        }
        else
        {
            objcard.chkvalue_length = "yes";
        }
        objcard.orignaldupli = rborg;
        objcard.packagelength = c1.ToString();
        objcard.insertion = insertion2[i3].ToString(); //i11.ToString();
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
    }
    private void onscreen_haribhoomi(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    {
        
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
     

        for (inew = 0; inew < countbookid2.Length; inew++)
        {
            // NEWGROSSAMT = 0.0;
            string bookingid = countbookid2[inew];
            string invoice2 = invoice1[inew];
            haribhoomi_billnew1 obj_RCB1 = new haribhoomi_billnew1();
            obj_RCB1 = (haribhoomi_billnew1)Page.LoadControl("haribhoomi_billnew1.ascx");
            DataSet ds4 = new DataSet();


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
           
            int maxlimit = 18;
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
               
                if (ds4.Tables[0].Rows[0]["bill2"].ToString() == "" || ds4.Tables[0].Rows[0]["bill2"].ToString() == null)
                {

                    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                    obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
                    obj_RCB.lblagencyname1 = "Agency";
                }
                else
                {
                    string[] addname = ds4.Tables[0].Rows[0]["agenadd"].ToString().Split("$$".ToCharArray());
                    obj_RCB.lbaddress1 = addname[0];
                    obj_RCB.agddxt1 = addname[2];
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
                obj_RCB.lbcompaddress1 = addname1[0];
                obj_RCB.txtmailid1 = addname1[1];

                obj_RCB.lbemailtxt1 = "Ph:-" + addname1[2] + "-" + addname1[3] + "," + "Fax:-" + addname1[4] + "," + addname1[5];

                obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                obj_RCB.txtrefno1 = ds4.Tables[0].Rows[0]["RO_No"].ToString();
                obj_RCB.txtrodate1 = ds4.Tables[0].Rows[0]["RO_Date"].ToString();
                if (ds4.Tables[0].Rows[0]["Caption"].ToString() != "" || ds4.Tables[0].Rows[0]["Product"].ToString() != "")
                {
                    obj_RCB.publication_value1 = ds4.Tables[0].Rows[0]["Caption"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["Product"].ToString();
                }
                else if (ds4.Tables[0].Rows[0]["Caption"].ToString() != "")
                {
                    obj_RCB.publication_value1 = ds4.Tables[0].Rows[0]["Caption"].ToString() + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
                }
                else if (ds4.Tables[0].Rows[0]["Product"].ToString() != "")
                {
                    obj_RCB.publication_value1 = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + ds4.Tables[0].Rows[0]["Product"].ToString();
                }
                else
                {
                    obj_RCB.publication_value1 = "--" + "&nbsp&nbsp" + "/" + "&nbsp&nbsp" + "--";
                }

                obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();
                obj_RCB.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                obj_RCB.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                obj_RCB.txtpanno1 = ds4.Tables[0].Rows[0]["pan"].ToString();

   
                obj_RCB.txtagcode1 = ds4.Tables[0].Rows[0]["Agency_code"].ToString();
          
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
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[69].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[67].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='90px' >" + dsb.Tables[0].Rows[0].ItemArray[66].ToString() + "</td>";
                    dytbl += "</tr>";
                }


                int maxlimit1 = 30;

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
                    
                    dytbl += "<tr align=center hight='67px'>";
                    dytbl += "<td class='insertiontxtclass' align='center' style='border-right:solid 1px black;'>" + srl.ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center' width='160px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center'width='90px' style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";
     


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
                    if (i == 0)
                    {
                        dytbl += "<td class='insertiontxtclass'align='center' width='90px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";
         

                        if (ds4.Tables[0].Rows[i]["Agrred_Rate"].ToString() != "")
                        {
                            dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>" + ds4.Tables[0].Rows[i]["Agreed_Rate"].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td class='insertiontxtclass' align='center'  width='90px'style='border-right:solid 1px black;'>0</td>";
                        }



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



                        grs = Convert.ToDouble(ds4.Tables[0].Rows[i]["Bill_Amt"].ToString());
                        ext = pr1;
                        totalam = grs + ext;

                        dytbl += "<td class='insertiontxtclass' align='center'  width='90px' style='border-left:solid 1px black;'>" + grossbillamt.ToString("F2") + "</td>";

                    }
                    else
                    {
                        dytbl += "<td class='insertiontxtclass'align='center' width='50px'style='border-right:solid 1px black;' >" + ds4.Tables[0].Rows[i]["Page_No"].ToString() + "</td>";

                        dytbl += "<td class='insertiontxtclass' align='center'  width='50px'style='border-right:solid 1px black;'> " + "." + " </td>";



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
              

            }




        }
       
    }


}
