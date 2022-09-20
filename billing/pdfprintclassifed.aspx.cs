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

public partial class pdfprintclassifed : System.Web.UI.Page
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
        agencycode = Request.QueryString["agcode"].Trim().ToString();
        


        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;

        BindPrintFormreprintmonthlyn(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

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


            DataSet dt = new DataSet();
            NewAdbooking.BillingClass.classesoracle.billing_save ins = new NewAdbooking.BillingClass.classesoracle.billing_save();
            dt = ins.update_printcount(invoicenn, Session["compcode"].ToString());




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
                RCB_CLASSIFIED objcard = new RCB_CLASSIFIED();
                objcard = (RCB_CLASSIFIED)Page.LoadControl("RCB_CLASSIFIED.ascx");

                objcard.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();

                objcard.lbadtypetxt1 = ds4.Tables[0].Rows[0]["adv_type_name"].ToString();

                objcard.lbcreditdatetxt1 = ds4.Tables[0].Rows[0]["paydatesys"].ToString();
                objcard.lbwalujadd1 = ds4.Tables[0].Rows[0]["address"].ToString() + "," + ds4.Tables[0].Rows[0]["street"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["fax"].ToString() + "-" + ds4.Tables[0].Rows[0]["fax2"].ToString();
                objcard.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();

                objcard.lbbranchtxt1 = ds4.Tables[0].Rows[0]["branch"].ToString();
                objcard.lbagencyaddtxt1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString() + "," + ds4.Tables[0].Rows[0]["Dist_Code"].ToString();
                objcard.lbadcattxt1 = ds4.Tables[0].Rows[0]["AdCat"].ToString();
                objcard.runtxt1 = ds4.Tables[0].Rows[0]["sysdate_new"].ToString();

                objcard.txtinvoice1 = invoicenn.ToString();











                dytbl += "<table width='650px' align='left' cellpadding='1' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/punebill.xml"));
                    dytbl += "<tr align=center >";
                    // dytbl += "<td class='insertiontxtclassNEW' >" + dsb.Tables[0].Rows[0].ItemArray[49].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[39].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</b></td>";

                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[56].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[57].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[42].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[43].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[44].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclassNEW' ><b>" + dsb.Tables[0].Rows[0].ItemArray[48].ToString() + "</b></td>";
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
                        dytbl += "<tr ><td   align=right>BOOKINGID</td><td  >" + ds4.Tables[3].Rows[u]["Cio_Booking_Id"].ToString() + "<td><td  width='100px' align=right   >Total</td><td width='50px' >" + ds4.Tables[3].Rows[u]["Gross_Rate"].ToString() + "</td><td  width='50px' >" + ds4.Tables[3].Rows[u]["TRADE DISC AMT"].ToString() + "</td><td>" + ds4.Tables[3].Rows[u]["AD AGENCY COMM AMT"].ToString() + "</td><td ALIGN='RIGHT'  >" + ds4.Tables[3].Rows[u]["Bill_Amt"].ToString() + "</td></tr>";
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

                    dytbl += "<tr  width='600px'>";
                    // dytbl += "<td class='insertiontxtclass_last' colspan ='10' ALIGN= 'left'  >Total</td> <td class='insertiontxtclass_last'  >" + amt2.ToString("F2") + "</td>";
                    dytbl += "<td colspan='5'   ><table><tr><td width='200px' align='left' ><b>Total</b><td><td>"+ ds4.Tables[4].Rows[0]["Bill_Amt"].ToString() + "</td></tr></Table></td>";
                    dytbl += "</tr align=center>";

                    dytbl += "<tr align=center>";
                    dytbl += "<td colspan ='11'  VALIGN='BOTTOM'  ALIGN= 'right' HEIGHT ='40PX'>Advt. Manager/Accountant</td>";
                    dytbl += "</tr align=center>";


                    //objcard.lbtotal1 = "Total".ToString();

                    objcard.lbemailtxt1 = ds4.Tables[0].Rows[0]["EmailID"].ToString();
                    objcard.lbemail1 = "Email";
                    objcard.lbpune1 = "PAN NO.";
                    objcard.EOU1 = "E.&&AMP;O.E.";
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




}
