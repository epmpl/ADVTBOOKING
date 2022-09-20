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

public partial class pdf_printdisplay : System.Web.UI.Page
{
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




        ciobookid = Request.QueryString["bookingid"].Trim().ToString();
        invoice = Request.QueryString["invoice2"].Trim().ToString();
        frmdt = Request.QueryString["fromdate"].Trim().ToString();
        dateto1 = Request.QueryString["dateto"].Trim().ToString();
    

        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;
       

            onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);
       
    }
    private void onscreen(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    {
        //double NEWGROSSAMT = 0.0;
        //  string grossamt = "";



        int inew = 0;
        double comm2 = 0;
        double boxamt2 = 0;

        double abc1 = 0;
        double amtinpr = 0;
        double abc2 = 0;
        string maxinsert = "";
        string dytbl = "";
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




            RCB1PDF obj_RCB1 = new RCB1PDF();
            obj_RCB1 = (RCB1PDF)Page.LoadControl("RCB1PDF.ascx");
            DataSet ds4 = new DataSet();

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
                RCB1PDF obj_RCB = new RCB1PDF();
                obj_RCB = (RCB1PDF)Page.LoadControl("RCB1PDF.ascx");

                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                obj_RCB.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString();
                obj_RCB.txtcliname1 = ds4.Tables[0].Rows[0]["client"].ToString();

                obj_RCB.lbcaption1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

                obj_RCB.txtinvoice1 = invoice2.ToString();


                obj_RCB.hidedata1 = "";





                // obj_RCB.agencytxt1 = ds4.Tables[0].Rows[0].ItemArray[14].ToString();




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

                obj_RCB.runtxt1 = ds4.Tables[0].Rows[0]["maxdate1"].ToString();


                obj_RCB.ldduedate1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                obj_RCB.adcat1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                obj_RCB.lbronodate1 = ds4.Tables[0].Rows[0]["RO_No"].ToString() + "-" + ds4.Tables[0].Rows[0]["RO_Date"].ToString();



                obj_RCB.txtpackname1 = ds4.Tables[0].Rows[0]["Caption"].ToString();

                // obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString();

                obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();

                obj_RCB.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();





                obj_RCB.lbterms1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
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







                obj_RCB.lbextpre1 = "Ex.Premium" + "(" + pr1 + ")" + "%";




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

                dytbl += "<table width='502px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1' align='center' width='150px' ><b>" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclass1' align='center' width='70px'><b>" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclass1' align='center'  width='5px' ><b>" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='5px' ><b>" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='32px' ><b>" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclass1'  align='center'  width='20px' ><b>" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</b></td>";

                    dytbl += "</tr>";
                }

                for (i = ct; i < ds4.Tables[0].Rows.Count && i < fr; i++)
                {
                    //if (ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() != "")
                    //NEWGROSSAMT = NEWGROSSAMT + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());


                    dytbl += "<tr align=center>";
                    dytbl += "<td class='insertiontxtclass'align='left' width='150px' >" + ds4.Tables[0].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass' align='center 'width='50px' >" + ds4.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>";

                    dytbl += "<td  class='insertiontxtclass' align='right' width='25px' >" + ds4.Tables[0].Rows[i]["Height"].ToString() + "*" + ds4.Tables[0].Rows[i]["Width"].ToString() + "</td>";

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




                    if (ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() != "")
                        abc1 = abc1 + Convert.ToDouble(ds4.Tables[0].Rows[i]["Gross_Rate"].ToString());


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




                    ///////


                    dytbl += "</tr>";

                    maxinsert = ds4.Tables[0].Rows[i].ItemArray[21].ToString();







                }  //



                if (p1 == pagecount - 1)
                {
                    // flag =1;


                    if ((ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != "0") && (ds4.Tables[0].Rows[0]["Agrred_rate"].ToString() != ""))
                    {
                        obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["Agrred_rate"].ToString();

                    }
                    else
                    {
                        obj_RCB.lbpakgrate1 = ds4.Tables[0].Rows[0]["PACKAGERATE"].ToString();

                    }

                    abc2 = abc1;
                    //abc2 = NEWGROSSAMT;

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



                    obj_RCB.netpay1 = net.ToString("F2");


                    //  obj_RCB.netpay1 = abc1_bill.ToString("F2");



                    NumberToEngish obj = new NumberToEngish();



                    obj_RCB.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                    obj_RCB.lbemail1 = "Email";
                    obj_RCB.lbpune1 = "PAN NO.";
                    obj_RCB.EOU1 = "E.&&AMP;O.E.";
                    obj_RCB.lbpunetxt1 = ds4.Tables[0].Rows[0]["pan"].ToString();
                    string TERMS = "";
                    if (ds4.Tables[0].Rows[0]["branch"].ToString() == "MUMBAI")
                    {
                        TERMS = " MUMBAI".ToString();
                    }
                    else
                    {

                        TERMS = " AURANGABAD".ToString();
                    }
                    //string namme1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
                  //  string namme1 = "images/shree.jpg";
                  //  string namme1 = "aa";
                    obj_RCB.insertiontxt1 = ds4.Tables[0].Rows[0]["No_of_insertion"].ToString();

                    obj_RCB.hidedata1 = "<b>Terms & Condition</b> :1)Payment Should be made in favour of  <b>SHREE AMBIKA PRINTERS AND PUBLICATIONS</b> 2)Only official receipt issued by us will binding on us.3) Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days from the presentation of the bill,falling which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subjected to <font style=font-size:11px;font-weight:bold><b>" + TERMS + "</b> </font> Jurisdiction only.";
                    //obj_RCB.hidedata1 = "Terms & Condition :1)Payment Should be made in favour of <img src='" + namme1 + "'alt=''/> 2)Only official receipt issued by us will binding on us.3) Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days from the presentation of the bill,falling which the bill become fully payable. 4) All payment should be made according to the credit limits to avoid interest,which will be levied @24% per annum.5)All disputes are subjected to <font style=font-size:11px;font-weight:bold>" + TERMS + " </font> Jurisdiction only.";

                    abc1 = 0;

                }


                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();

                Page.Controls.Add(obj_RCB);
                //RenderControl(
                // placeholder1.Controls.Add(obj_RCB);






            }







        }


        //  Response.Redirect("pdf.aspx");


    }

}
