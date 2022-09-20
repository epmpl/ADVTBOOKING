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

public partial class testnewsambad : System.Web.UI.Page
{

    static string ciobookid = "";
    static string checkradio = "";
    static string insertion = "";
    static string editionbill = "";
    static string spl_dis = "";
    static string trad_dis = "";
    static string rborg = "";
    static int a = 0;
    static int b = 1;
    static int i1 = 0;
    string branch;

    static string invoice_no = "";
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
            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            editionbill = Session["billing_edition"].ToString();
            invoice_no = Session["invoice"].ToString();
            editionbill = editionbill.Replace("^", "+");
            spl_dis = Session["spl_dis"].ToString();
            trad_dis = Session["trade_dis"].ToString();
            rborg = Session["bill_org"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

        }

        string[] countbookid1 = ciobookid.Split(',');
        int c4 = countbookid1.Length;
        BindPrintFormreprint(ciobookid, c4, insertion, editionbill, invoice_no);
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


NewAdbooking.BillingClass.Classes.invoice objpkg = new NewAdbooking.BillingClass.Classes.invoice();
ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString());
}
else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
{

    NewAdbooking.BillingClass.classesoracle.invoice objpkg = new NewAdbooking.BillingClass.classesoracle.invoice();
    ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString(), Session["dateformat"].ToString());

}

else
{
    string[] parameterValueArray = new string[] { countbookid2[i3], Session["compcode"].ToString(), Session["dateformat"].ToString() };
    string procedureName = "websp_packagecode";
    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
    ds1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
    
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

if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
{

testcontrolsambad objcard = new testcontrolsambad();
objcard = (testcontrolsambad)(Page.LoadControl("testcontrolsambad.ascx"));
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
objcard.bookingdate = bookingd;// Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
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

        if (rborg == "0")
        {
            printcount += 1;
            udayvani_bill objcard = new udayvani_bill();
            objcard = (udayvani_bill)(Page.LoadControl("udayvani_bill.ascx"));



            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);

            objcard.invoiceno = invoice_no1[i3];
            objcard.packagelength = c1.ToString();
            // objcard.insertion = i11.ToString();insertion2
            objcard.insertion = insertion2[i3];
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            objcard.qbc = branch;
            objcard.editionnameplus = editionname.ToString();
            //objcard.setcard(printcount);


        }
        else
        {

            for (int abcd = 0; abcd < 2; abcd++)
            {
                printcount += 1;
                udayvani_bill objcard = new udayvani_bill();
                objcard = (udayvani_bill)(Page.LoadControl("udayvani_bill.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);

                objcard.invoiceno = invoice_no1[i3];
                objcard.packagelength = c1.ToString();
                // objcard.insertion = i11.ToString();insertion2
                objcard.insertion = insertion2[i3];
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.qbc = branch;
                objcard.editionnameplus = editionname.ToString();
                //objcard.setcard(printcount);



            }
        }

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
                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                        dk1 = objedition.edition(packagecode1[k1], Session["compcode"].ToString());

                    }
                    else
                    {
                        string[] parameterValueArray = new string[] { packagecode1[k1], Session["compcode"].ToString() };
                        string procedureName = "websp_selectedition";
                        NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                        dk1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);

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
                    NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                    ds4 = objvalues.values_bill_p(invoc12[i3].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    //NewAdbooking.BillingClass.classesoracle.invoice objvalues = new NewAdbooking.BillingClass.classesoracle.invoice();
                    //ds4 = objvalues.values_bill(ciobookingid, tedition_count[p1].Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                }
                else
                {
                    string[] parameterValueArray = new string[] { invoc12[i3].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString() };
                    string procedureName = "websp_selectvalues_pra";
                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                    ds4 = sms.DynamicBindProcedure(procedureName, parameterValueArray);

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

                    pratidinbill_f obj_RCB = new pratidinbill_f();
                    obj_RCB = (pratidinbill_f)Page.LoadControl("pratidinbill_f.ascx");
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

                    pratidinbill objcard = new pratidinbill();
                    objcard = (pratidinbill)(Page.LoadControl("pratidinbill.ascx"));

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
                        objcard.insertion = insertion2[i3].ToString();//i11.ToString();
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
                    else
                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vigilant")
                        {

                            vigilant_media objcard = new vigilant_media();
                            objcard = (vigilant_media)(Page.LoadControl("vigilant_media.ascx"));


                            objcard.valueofradio = checkradio.ToString();
                            placeholder1.Controls.Add(objcard);

                            objcard.invoiceno = invoice_no1[i3];
                            objcard.packagelength = c1.ToString();
                            objcard.insertion = insertion2[i3].ToString();//i11.ToString();
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
                            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision")
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
                                string vat = "";
                                double vat_new = 0;
                                int pk1 = packagecode3.Length;
                                for (int k1 = 0; k1 < pk1; k1++)
                                {
                                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                    {
                                        NewAdbooking.BillingClass.Classes.invoice objedition = new NewAdbooking.BillingClass.Classes.invoice();
                                        dk1 = objedition.edition(packagecode1[k1], Session["compcode"].ToString());
                                    }
                                    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                                    {
                                        NewAdbooking.BillingClass.classesoracle.invoice objedition = new NewAdbooking.BillingClass.classesoracle.invoice();
                                        dk1 = objedition.edition(packagecode1[k1], Session["compcode"].ToString());

                                    }
                                    else
                                    {
                                        string[] parameterValueArray = new string[] { packagecode1[k1], Session["compcode"].ToString() };
                                        string procedureName = "websp_selectedition";
                                        NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                                        dk1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                                        
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
                                int rownum = 0;
                                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                {
                                    NewAdbooking.BillingClass.Classes.invoice objvalues = new NewAdbooking.BillingClass.Classes.invoice();
                                    ds4 = objvalues.values_bill_p(invoc12[i3].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                    rownum = ds4.Tables[0].Rows.Count;
                                }//?????????????????????????????????
                                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mmysql")
                                {
                                    string[] parameterValueArray = new string[] { invoc12[i3].Trim(), Session["bill_cycle1"].ToString(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString() };
                                    string procedureName = "websp_selectvalues_pra";
                                    NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                                    ds4 = sms.DynamicBindProcedure(procedureName, parameterValueArray);
                                    rownum = ds4.Tables[0].Rows.Count;
                                }
                                //int rownum = ds4.Tables[0].Rows.Count;
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



                                    vision_group obj_RCB = new vision_group();
                                    obj_RCB = (vision_group)Page.LoadControl("vision_group.ascx");

                                    if (i3 == count - 1)
                                    {
                                        obj_RCB.chkvalue_length = "no";
                                    }
                                    else
                                    {
                                        obj_RCB.chkvalue_length = "yes";
                                    }
                                    obj_RCB.salesperson = ds4.Tables[0].Rows[0]["EXECUTIVE_CODE"].ToString();
                                    //obj_RCB.branch = ds4.Tables[0].Rows[0]["city_name"].ToString();
                                    obj_RCB.invoice_no = invoc12[i3];
                                    obj_RCB.rono = ds4.Tables[0].Rows[0]["Rono."].ToString();
                                    obj_RCB.duedate = ds4.Tables[0].Rows[0]["paydate"].ToString();
                                    obj_RCB.bookingid = ds4.Tables[0].Rows[0]["CIOID"].ToString();
                                    obj_RCB.bill_date = ds4.Tables[0].Rows[0]["BILL_DATE"].ToString();
                                    obj_RCB.client = ds4.Tables[0].Rows[0]["Client"].ToString();

                                    //    if (korg == 1)
                                    //    {
                                    //        obj_RCB.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[9].ToString();
                                    //    }
                                    //    else if (korg == 2)
                                    //    {
                                    //        obj_RCB.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[10].ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        obj_RCB.lblorg1 = dsb.Tables[0].Rows[0].ItemArray[11].ToString();
                                    //    }
                                    //    obj_RCB.agddxt1 = ds4.Tables[0].Rows[0].ItemArray[1].ToString();
                                    //    street = ds4.Tables[0].Rows[0]["street"].ToString();
                                    //    obj_RCB.lbaddress1 = ds4.Tables[0].Rows[0]["add1"].ToString();
                                    //    obj_RCB.lbaddress2 = obj_RCB.lbaddress1 + "," + street;
                                    //    obj_RCB.lbcityname1 = ds4.Tables[0].Rows[0]["city_name"].ToString();
                                    //    obj_RCB.txtpinno1 = ds4.Tables[0].Rows[0]["pin_code"].ToString();
                                    //    obj_RCB.lblcode1 = ds4.Tables[0].Rows[0]["agency_cod"].ToString();
                                    //    if (ds4.Tables[0].Rows[0]["Box_Charge"].ToString() != "" && ds4.Tables[0].Rows[0]["Box_Charge"].ToString() != null)
                                    //    {
                                    //        obj_RCB.lblboxchrg1 = ds4.Tables[0].Rows[0]["Box_Charge"].ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        obj_RCB.lblboxchrg1 = "-";
                                    //    }
                                    //    if (ds4.Tables[0].Rows[0]["Extra"].ToString() != "")
                                    //    {
                                    //        obj_RCB.lblexamt_col1 = ds4.Tables[0].Rows[0]["Extra"].ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        obj_RCB.lblexamt_col1 = "-";
                                    //    }
                                    //    if (ds4.Tables[0].Rows[0]["pag_prem"].ToString() != "" && ds4.Tables[0].Rows[0]["pag_prem"].ToString() != null)
                                    //    {
                                    //        PagePrem = Convert.ToDouble(ds4.Tables[0].Rows[0]["pag_prem"].ToString());
                                    //    }
                                    //    if (ds4.Tables[0].Rows[0]["Pag_amt"].ToString() != "" && ds4.Tables[0].Rows[0]["Pag_amt"].ToString() != null)
                                    //    {
                                    //        positionpremium = Convert.ToDouble(ds4.Tables[0].Rows[0]["Pag_amt"].ToString());
                                    //    }
                                    //    if (ds4.Tables[0].Rows[0]["Amt"].ToString() != "" && ds4.Tables[0].Rows[0]["Amt"].ToString() != null)
                                    //    {
                                    //        cardamount = Convert.ToDouble(ds4.Tables[0].Rows[0]["Amt"].ToString());
                                    //    }
                                    //    //location
                                    //    obj_RCB.lbllocval1 = ds4.Tables[0].Rows[0]["Print_cent_name"].ToString();
                                    //    grossamt = Convert.ToDouble(ds4.Tables[0].Rows[0]["Gross_Rate"].ToString());
                                    traddis = Convert.ToDouble(ds4.Tables[0].Rows[0]["trade_disc"].ToString());

                                    //    obj_RCB.lblexamt_day1 = "-";
                                    //    if (ds4.Tables[0].Rows[0]["scheme"].ToString() != "" && ds4.Tables[0].Rows[0]["scheme"].ToString() != null)
                                    //    {
                                    //        obj_RCB.txtscode1 = ds4.Tables[0].Rows[0]["scheme"].ToString();
                                    //    }
                                    //    if (ds4.Tables[0].Rows[0]["rate_code"].ToString() != "")
                                    //    {
                                    //        obj_RCB.txtratecode1 = ds4.Tables[0].Rows[0]["rate_code"].ToString();
                                    //    }

                                    //    obj_RCB.lbbillno1 = invoice_no1[i3];
                                    //    obj_RCB.lblclientname1 = ds4.Tables[0].Rows[0]["advertiser"].ToString();

                                    DataSet dsb = new DataSet();
                                    dsb.ReadXml(Server.MapPath("XML/vision_group.xml"));

                                    dytbl = "";
                                    dytbl += "<table width='660px' border='0' align='left' cellpadding='0' cellspacing='0' >";
                                    {

                                        // dytbl += "<tr align=center >";
                                        //  string tb1 = "";
                                        // dytbl += "<table width='650px' cellpadding='0' cellspacing='0' >";

                                        dytbl += "<tr align=center >";
                                        dytbl += "<td colspan='2' class='lable_textbox_bold_left' ></td>";
                                        dytbl += "<td colspan='4' class='lable_textbox_bold_left' >" + dsb.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
                                        dytbl += "<td  colspan='3'class='lable_textbox_bold_left' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";

                                        dytbl += "</tr>";
                                        dytbl += "<tr align=center >";

                                        dytbl += "<td width='90px' class='lable_textbox_bold' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>";
                                        dytbl += "<td width='70px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
                                        dytbl += "<td width='70px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                                        dytbl += "<td width='80px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                                        dytbl += "<td width='100px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                                        dytbl += "<td width='100px' class='lable_textbox_bold' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                                        dytbl += "<td width='100px' class='lable_textbox_bold' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                                        dytbl += "<td width='100px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                                        dytbl += "<td width='100px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                                        dytbl += "<td width='100px' class='lable_textbox_bold' align='center' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                                        dytbl += "</tr>";

                                    }

                                    for (i = ct; i < rownum && i < fr; i++)
                                    {

                                        //if (ds4.Tables[0].Rows[i].ItemArray[29].ToString() != "")
                                        //{
                                        //    obj_RCB.lblpageval1 = ds4.Tables[0].Rows[i].ItemArray[29].ToString() + "PAGE";
                                        //}
                                        //obj_RCB.lblisname1 = ds4.Tables[0].Rows[i]["ad_type"].ToString();
                                        //obj_RCB.lbldate1 = ds4.Tables[0].Rows[i].ItemArray[28].ToString();

                                        string amt = ds4.Tables[0].Rows[i]["Gross_Rate"].ToString();
                                        string boxcharges = ds4.Tables[0].Rows[i].ItemArray[21].ToString();
                                        double amt1 = 0;
                                        if (amt != "")
                                        {
                                            amt1 = Convert.ToDouble(amt);
                                        }
                                        amt5 = amt5 + amt1;
                                        //string package_rate = ds4.Tables[0].Rows[i].ItemArray[14].ToString();
                                        //string premiumper2 = ds4.Tables[0].Rows[i].ItemArray[34].ToString();
                                        //if (package_rate != "")
                                        //{
                                        //    packrate = Convert.ToDouble(package_rate);
                                        //    packrate1 = packrate1 + packrate;
                                        //}
                                        //if (premiumper2 != "")
                                        //{
                                        //    premiumper = Convert.ToDouble(premiumper2);
                                        //    premiumper1 = premiumper1 + premiumper;

                                        //}

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

                                        }
                                        else
                                        {
                                            bill_amt = 0;


                                        }

                                        bill_amt1 = bill_amt1 + bill_amt;

                                        ////Dynamic Table data
                                        //dytbl += "<tr>";
                                        dytbl += "<tr >";

                                        if (ds4.Tables[0].Rows[i]["edition"].ToString() != "")
                                        {
                                            dytbl += "<td width=90px  class='lable_textbox' align=left >" + ds4.Tables[0].Rows[i]["edition"].ToString() + "</td>";
                                        }
                                        else
                                            dytbl += "<td width=90px  class=display align=center>-</td>";

                                        if (ds4.Tables[0].Rows[i]["package_name"].ToString() != "")
                                        {
                                            dytbl += "<td width='70px'  class='lable_textbox' align=center >" + ds4.Tables[0].Rows[i]["package_name"].ToString() + "</td>";

                                        }
                                        else
                                            dytbl += "<td width='70px' class=display align=center>-</td>";


                                        if (ds4.Tables[0].Rows[i]["rundate"].ToString() != "")
                                        {
                                            dytbl += "<td width='70px'   class='lable_textbox' align=right >" + ds4.Tables[0].Rows[i]["rundate"].ToString() + "</td>";

                                        }


                                        dytbl += "<td width='70px' class='lable_textbox' align=center>---</td>";
                                        dytbl += "<td width='70px' class='lable_textbox' align=center>---</td>";
                                        if (ds4.Tables[0].Rows[i]["Ins.No."].ToString() != "")
                                        {
                                            dytbl += "<td width='70px'  class=lable_textbox align=center >" + ds4.Tables[0].Rows[i]["Ins.No."].ToString() + "</td>";

                                        }
                                        else
                                            dytbl += "<td width='70px' class=lable_textbox align=center>---</td>";
                                        if (ds4.Tables[0].Rows[i]["uom_name"].ToString() != "")
                                        {
                                            dytbl += "<td width='70px'  class=lable_textbox align=left >" + ds4.Tables[0].Rows[i]["uom_name"].ToString() + "</td>";

                                        }
                                        else
                                            dytbl += "<td width='70px' class=lable_textbox align=center>---</td>";

                                        if (ds4.Tables[0].Rows[i]["card_rate"].ToString() != "")
                                        {
                                            dytbl += "<td width='100px'  class=lable_textbox align=center >" + ds4.Tables[0].Rows[i]["card_rate"].ToString() + "</td>";

                                        }
                                        else
                                            dytbl += "<td width='100px' class=lable_textbox align=center>---</td>";


                                        dytbl += "<td width='70px'   class='lable_textbox' align=center >" + ds4.Tables[0].Rows[i]["trade_disc"].ToString() + "</td>";
                                        dytbl += "<td width='70px'   class='lable_textbox' align=right >" + ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() + "</td>";


                                        vat = ds4.Tables[0].Rows[0]["Vat"].ToString();

                                        if (vat != "0" && vat != "")
                                        {
                                            vat_new = Convert.ToDouble(vat);
                                        }



                                        dytbl += "</tr>";



                                    }


                                    dytbl += "<tr align=center ><td height='100px;'></td></tr>";
                                    string tr = traddis.ToString();

                                    traddis = amt5 * traddis / 100;
                                    // obj_RCB.lbltradedis1 = traddis.ToString();
                                    double vat_new1 = vat_new + 100;
                                    double netamtexcelusivevat = (((bill_amt1 * 100)) / (vat_new1));
                                    double vatamt = (netamtexcelusivevat * vat_new) / 100;

                                    //    obj_RCB.netpay1 = bill_amt1.ToString("F2");
                                    bill_amt1 = bill_amt1 + 0.01;

                                    double amountinckudingbox1 = Math.Round(bill_amt1);

                                    dytbl += "<tr align=center >";
                                    dytbl += "<td colspan='6'   align=center></td>";
                                    dytbl += "<td colspan='3' align='left'  class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                                    dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + amt5 + "</td>";
                                    dytbl += "</tr>";

                                    dytbl += "<tr align=center >";
                                    dytbl += "<td colspan='6'   align=center></td>";
                                    dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + dsb.Tables[0].Rows[0].ItemArray[15].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + tr + "</td>";

                                    dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + traddis + "</td>";
                                    dytbl += "</tr>";
                                    string vatexcesive_amt = netamtexcelusivevat.ToString("F2");
                                    dytbl += "<tr align=center >";
                                    dytbl += "<td colspan='6'   align=center ></td>";
                                    dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                                    dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + vatexcesive_amt + "</td>";
                                    dytbl += "</tr>";

                                    string vatamt1 = vatamt.ToString("F2");
                                    dytbl += "<tr align=center >";
                                    dytbl += "<td colspan='6'   align=center></td>";
                                    dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                                    dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + vatamt1 + "</td>";
                                    dytbl += "</tr>";

                                    //dytbl += "<tr align=center >";
                                    //dytbl += "<td colspan='6'   align=center></td>";
                                    //dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                                    //dytbl += "<td colspan='2'  class=lable_textbox align='right'>-</td>";
                                    //dytbl += "</tr>";

                                    dytbl += "<tr align=center >";
                                    dytbl += "<td colspan='6'   align=center></td>";
                                    dytbl += "<td colspan='3' align='left'  class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>";
                                    dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + amountinckudingbox1 + "</td>";
                                    dytbl += "</tr>";

                                    dytbl += "</table>";

                                    obj_RCB.dynamictable1 = dytbl;

                                    //    double amountprem = amt4 * (premiumper1 / 100);
                                    //    //lb_totalamt.Text = amt4.ToString();
                                    //    amountprem = amt4 + amountprem - (spcharges + spdes);
                                    //    double disper1 = amountprem * (dispr / 100);

                                    //    obj_RCB.lblgross1 = amt5.ToString();
                                    //    traddis = amt5 * traddis / 100;
                                    //    obj_RCB.lbltradedis1 = traddis.ToString();
                                    //    obj_RCB.lbladddis1 = adddis.ToString();
                                    //    obj_RCB.lbltrade1 = ds4.Tables[0].Rows[0]["trade_disc"].ToString();
                                    //    // lblboxchrg.Text = addchr.ToString();
                                    //    obj_RCB.netpay1 = bill_amt1.ToString("F2");
                                    //    bill_amt1 = bill_amt1 + 0.01;
                                    //    double amountinckudingbox1 = Math.Round(bill_amt1);
                                    //    if (cardamount != 0 && PagePrem != 0)
                                    //    {
                                    //        pageprem_amt = cardamount * PagePrem / 100;
                                    //    }
                                    //    if (pageprem_amt != 0 && positionpremium != 0)
                                    //    {
                                    //        extraposamt = (pageprem_amt + cardamount) * positionpremium / 100;
                                    //        obj_RCB.lblexamt_pos1 = extraposamt.ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        obj_RCB.lblexamt_pos1 = "-";
                                    //    }
                                    //    if (extraposamt != 0)
                                    //    {
                                    //        obj_RCB.lblamt1 = (amt5 - extraposamt).ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        obj_RCB.lblamt1 = amt5.ToString();
                                    //    }
                                    //    //lblround.Text = amountinckudingbox1.ToString();

                                    //    ///////////////////////////////////////////////////////////////////////////////////////////////
                                    //    if (p1 < (pagecount - 1))
                                    //    {
                                    //        obj_RCB.trate1 = "none";
                                    //        //obj_RCB.netamttab1="none";
                                    //    }
                                    //    NumberToEngish obj = new NumberToEngish();
                                    //    obj_RCB.lbwordinrupees1 = obj.changeNumericToWords(obj_RCB.netpay1.ToString()) + "Only";
                                    obj_RCB.setReceiptData();
                                    Page.Controls.Add(obj_RCB);

                                }
                            }
                            else
                                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "arapmedia")
                                {
                                    arapmedia_bill objcard = new arapmedia_bill();
                                    objcard = (arapmedia_bill)(Page.LoadControl("arapmedia_bill.ascx"));


                                    // Abp_bill objcard = new Abp_bill();
                                    //objcard = (Abp_bill)(Page.LoadControl("Abp_bill.ascx"));


                                    objcard.valueofradio = checkradio.ToString();
                                    placeholder1.Controls.Add(objcard);

                                    objcard.invoiceno = invoice_no1[i3];
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


                                else
                                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "haribhoomi")
                                    {
                                        
                                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                        {
                                            string[] parameterValueArray = new string[] { ciobookingid1, invoice_no1[i3] };
                                            string procedureName = "get_billdate";
                                            NewAdbooking.Classes.CommonClass objvalues = new NewAdbooking.Classes.CommonClass();
                                            ds4 = objvalues.DynamicBindProcedure(procedureName, parameterValueArray);
                                        }
                                        else
                                        {
                                            string[] parameterValueArray = new string[] { ciobookingid1, invoice_no1[i3] };
                                            string procedureName = "get_billdate";
                                            NewAdbooking.classesoracle.CommonClass objvalues = new NewAdbooking.classesoracle.CommonClass();
                                            ds4 = objvalues.DynamicBindProcedure(procedureName, parameterValueArray);
                                        }
                                        string billdt = ds4.Tables[0].Rows[0]["bill_date"].ToString();
                                       
                                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                        {
                                            string[] parameterValueArray = new string[] {  billdt.ToString(),Session["compcode"].ToString() };
                                            string procedureName = "attdate_validation_gst";
                                            NewAdbooking.Classes.CommonClass objvalues = new NewAdbooking.Classes.CommonClass();
                                            ds4 = objvalues.DynamicBindProcedure(procedureName, parameterValueArray);
                                        }
                                        else
                                        {
                                            string[] parameterValueArray = new string[] { billdt.ToString(), Session["compcode"].ToString() };
                                            string procedureName = "attdate_validation_gst";
                                            NewAdbooking.classesoracle.CommonClass objvalues = new NewAdbooking.classesoracle.CommonClass();
                                            ds4 = objvalues.DynamicBindProcedure(procedureName, parameterValueArray);
                                        }
                                        string FLAG = ds4.Tables[0].Rows[0]["MESSAGE"].ToString();
                                        if (FLAG == "TRUE ...")
                                        {
                                            haribhoomi_display_gst objcard = new haribhoomi_display_gst();
                                            objcard = (haribhoomi_display_gst)(Page.LoadControl("haribhoomi_display_gst.ascx"));

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
                                            objcard.trade_disc = trade_dis1[i3].ToString();
                                            objcard.editionnameplus = editionname.ToString();
                                            objcard.setcard();
                                        }
                                        else
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
                                            objcard.trade_disc = trade_dis1[i3].ToString();
                                            objcard.editionnameplus = editionname.ToString();
                                            objcard.setcard();
                                        }


                                    }
                                    else
                                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "SA")
                                        {
                                            daniksaweral objcard = new daniksaweral();
                                            objcard = (daniksaweral)(Page.LoadControl("daniksaweral.ascx"));


                                            // Abp_bill objcard = new Abp_bill();
                                            //objcard = (Abp_bill)(Page.LoadControl("Abp_bill.ascx"));

                                            if (i3 == count - 1)
                                            {
                                                objcard.chkvalue_length = "no";
                                            }
                                            else
                                            {
                                                objcard.chkvalue_length = "yes";
                                            }



                                            objcard.valueofradio = checkradio.ToString();
                                            placeholder1.Controls.Add(objcard);

                                            objcard.invoiceno = invoice_no1[i3];
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
                                        else
                                            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "RP" && Session["bill_cycle1"].ToString() == "6")
                                            {


                                                DataSet dsselv = new DataSet();
                                                string street = "";
                                                String dytbl = "";

                                                double traddis = 0;
                                                double adddis = 0;
                                                double addchr = 0;
                                                double bill_amt = 0;
                                                double bill_amt1 = 0;

                                                double Gross_Rate = 0;
                                                double add_ag_dis = 0;
                                                int minword = 0;
                                                int maxword = 0;
                                                int extraword = 0;
                                                double extrarate = 0;
                                                string insert = "";
                                                string pack = "";
                                                double packagegrossamt = 0;
                                                double translation_per = 0;
                                                int kk = 0;

                                                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                                                {

                                                    NewAdbooking.BillingClass.Classes.invoice objedition1 = new NewAdbooking.BillingClass.Classes.invoice();
                                                    //dsselv = objedition1.values_bill(ciobookingid, editionname.Trim(), i12, Session["compcode"].ToString(), Session["dateformat"].ToString());
                                                }
                                                else
                                                {
                                                    NewAdbooking.BillingClass.classesoracle.invoice objvalues1 = new NewAdbooking.BillingClass.classesoracle.invoice();
                                                    //dsselv = objvalues1.values_bill_rpcombined(ciobookingid1, Session["compcode"].ToString(), Session["dateformat"].ToString(), Session["userid"].ToString());


                                                }
                                                int rownum = dsselv.Tables[0].Rows.Count;
                                                int tab2row = dsselv.Tables[1].Rows.Count;
                                                int maxlimit = 15;
                                                int ct = 0;
                                                int fr = maxlimit;

                                                int pagec = (rownum) % maxlimit;//+ tab2row
                                                int pagecount = (rownum) / maxlimit;// + tab2row
                                                if (pagec > 0)
                                                {
                                                    pagecount = pagecount + 1;
                                                }
                                                if (dsselv.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || dsselv.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                                                {
                                                    for (int p1 = 0; p1 < pagecount; p1++)
                                                    {
                                                        ct = maxlimit * p1;
                                                        fr = maxlimit * (p1 + 1);

                                                        RP_bill_combined objcard = new RP_bill_combined();
                                                        objcard = (RP_bill_combined)(Page.LoadControl("RP_bill_combined.ascx"));

                                                        if (i3 == count - 1)
                                                        {
                                                            objcard.chkvalue_length = "no";
                                                        }
                                                        else
                                                        {
                                                            objcard.chkvalue_length = "yes";
                                                        }

                                                        //To fill data in Dynamic Table Header
                                                        dytbl = "";
                                                        dytbl += "<table width='900px' border=0 align='left' cellpadding='0' cellspacing='0' >";
                                                        DataSet dsb = new DataSet();
                                                        dsb.ReadXml(Server.MapPath("XML/RP_bill.xml"));
                                                        if (Session["bill_org"].ToString() == "0")
                                                        {
                                                            objcard.orgdup1 = dsb.Tables[0].Rows[0].ItemArray[15].ToString();
                                                        }
                                                        else
                                                        {
                                                            objcard.orgdup1 = dsb.Tables[0].Rows[0].ItemArray[16].ToString();
                                                        }

                                                        objcard.txtinvoice1 = invoice_no1[i3];
                                                        dytbl += "<tr align=center >";
                                                        dytbl += "<td class='insertiontxtclass1' width='85px'  >" + dsb.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
                                                        dytbl += "<td class='insertiontxtclass1' width='125x'  >" + dsb.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                                                        dytbl += "<td   class='insertiontxtclass1'width='75px' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";

                                                        if (dsselv.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || dsselv.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                                                        {
                                                            dytbl += "<td   class='insertiontxtclass1' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td colspan='2'>" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + " </td></tr><tr><td  style='border-right:solid 1px black;border-top:solid 1px black' >Height</td><td style='border-top:solid 1px black'>Width</td></tr></table></td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                                                            dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                                                            dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='100px' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                                                            dytbl += "<td    class='insertiontxtclass14' width='100px' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                                                            objcard.adcat1 = dsselv.Tables[0].Rows[0]["Cap"].ToString();


                                                        }
                                                        else
                                                        {
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                                                            dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                                                            dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>";
                                                            dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                                                            dytbl += "<td    class='insertiontxtclass14'>" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                                                            objcard.adcat1 = dsselv.Tables[0].Rows[0]["Adv_Cat_Name"].ToString() + "/" + dsselv.Tables[0].Rows[0]["Adv_Subcat_Name"].ToString();
                                                        }

                                                        dytbl += "</tr>";

                                                        //============***********************======================//
                                                        objcard.agencytxt1 = dsselv.Tables[0].Rows[0]["Agency"].ToString();
                                                        objcard.lblkeyno1 = dsselv.Tables[0].Rows[0]["Key No"].ToString();

                                                        street = dsselv.Tables[0].Rows[0]["street"].ToString();
                                                        string agadd = dsselv.Tables[0].Rows[0]["add1"].ToString();
                                                        objcard.agencyaddtxt1 = agadd + "," + street + dsselv.Tables[0].Rows[0]["add2"].ToString() + dsselv.Tables[0].Rows[0]["add3"].ToString();

                                                        objcard.lb_booking_id1 = dsselv.Tables[0].Rows[0]["CIOID"].ToString();
                                                        objcard.runtxt1 = dsselv.Tables[0].Rows[0]["BILL_DATE"].ToString();


                                                        objcard.txtcliname1 = dsselv.Tables[0].Rows[0]["advertiser"].ToString();
                                                        objcard.lbronodate1 = dsselv.Tables[0].Rows[0]["RoNo."].ToString() + "-" + dsselv.Tables[0].Rows[0]["RO_Date"].ToString();

                                                        if (dsselv.Tables[0].Rows[0]["Bill_remarks"].ToString() != "" && dsselv.Tables[0].Rows[0]["Bill_remarks"].ToString() != null)
                                                        {
                                                            objcard.lblremark1 = dsselv.Tables[0].Rows[0]["Bill_remarks"].ToString();
                                                        }
                                                        if (dsselv.Tables[0].Rows[0]["Scheme"].ToString() != "" && dsselv.Tables[0].Rows[0]["Scheme"].ToString() != null)
                                                        {
                                                            objcard.lblschemetype1 = dsselv.Tables[0].Rows[0]["Scheme"].ToString();
                                                        }


                                                        //=============================************========================================//
                                                        if (dsselv.Tables[0].Rows[0]["trade_disc"].ToString() != "")
                                                        {
                                                            traddis = Convert.ToDouble(dsselv.Tables[0].Rows[0]["trade_disc"].ToString());
                                                        }
                                                        else
                                                        {
                                                            traddis = 0;
                                                        }
                                                        if (dsselv.Tables[0].Rows[0]["addcom"].ToString() != "" && dsselv.Tables[0].Rows[0]["addcom"].ToString() != null)
                                                        {
                                                            add_ag_dis = Convert.ToDouble(dsselv.Tables[0].Rows[0]["addcom"].ToString());
                                                        }
                                                        else
                                                        {
                                                            traddis = 0;
                                                        }

                                                        if (dsselv.Tables[0].Rows[0]["special_discount"].ToString() != "")
                                                        {
                                                            adddis = Convert.ToDouble(dsselv.Tables[0].Rows[0]["special_discount"].ToString());
                                                        }

                                                        if (dsselv.Tables[0].Rows[0]["special_charges"].ToString() != "")
                                                        {
                                                            addchr = Convert.ToDouble(dsselv.Tables[0].Rows[0]["special_charges"].ToString());

                                                        }
                                                        if (dsselv.Tables[0].Rows[0]["TRANSLATION_PREMIUM"].ToString() != "")
                                                        {
                                                            translation_per = Convert.ToDouble(dsselv.Tables[0].Rows[0]["TRANSLATION_PREMIUM"].ToString());

                                                        }


                                                        for (i = ct; i < rownum && i < fr; i++)
                                                        {

                                                            if (insert != dsselv.Tables[0].Rows[i]["Ins.No."].ToString())//When Insertion change
                                                            {
                                                                if (i != 0)
                                                                    kk = kk + 1;
                                                                insert = dsselv.Tables[0].Rows[i]["Ins.No."].ToString();
                                                                pack = dsselv.Tables[0].Rows[i]["PACKAGE_CODE"].ToString();

                                                                dytbl += "<tr>";
                                                                dytbl += "<td    align='left' class='display'>" + dsselv.Tables[0].Rows[i]["Ins.No."].ToString() + "." + dsselv.Tables[0].Rows[i]["Package"].ToString() + "</td>";
                                                                dytbl += "<td   class=display align='center'></td>";
                                                                dytbl += "<td   class=display align='center'></td>";

                                                                if (dsselv.Tables[0].Rows[i]["Ad_type_code"].ToString() == "DI0" || dsselv.Tables[0].Rows[i]["Uom_code"].ToString() == "CL0")
                                                                {
                                                                    dytbl += "<td    class=display align='center' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td style='' width='55px' >" + dsselv.Tables[0].Rows[i]["Depth"].ToString() + "</td><td>" + dsselv.Tables[0].Rows[i]["Width"].ToString() + "</td></tr></table></td>";
                                                                    dytbl += "<td   align='center' class=display>" + dsselv.Tables[0].Rows[i]["Volume"].ToString() + "</td>";
                                                                    if (dsselv.Tables[0].Rows[i]["premiumname"].ToString() != "" && dsselv.Tables[0].Rows[i]["premiumname"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'>---</td>";

                                                                    if (dsselv.Tables[0].Rows[0]["premiumch"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumch"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'></td>";




                                                                    string col = dsselv.Tables[0].Rows[0]["Hue"].ToString();
                                                                    col = col.Substring(0, 3);
                                                                    string col1 = col;
                                                                    col1 = col1.Substring(0, 1);
                                                                    if (col1 == "B")
                                                                    {
                                                                        col = "B / W";
                                                                    }
                                                                    dytbl += "<td   align='center' class=display>" + col + "</td>";


                                                                    if (dsselv.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                                                                    {
                                                                        //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                                                        dytbl += "<td   class=display align='center' >" + dsselv.Tables[1].Rows[kk]["package rate"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='center'></td>";
                                                                    //for extra rate
                                                                    dytbl += "<td    align='right' class='display1'></td>";

                                                                }
                                                                else
                                                                {
                                                                    dytbl += "<td   align='center' class=display>" + dsselv.Tables[0].Rows[0]["Volume"].ToString() + "</td>";
                                                                    maxword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["Volume"].ToString());
                                                                    if (dsselv.Tables[0].Rows[0]["premiumname"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumname"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'>---</td>";

                                                                    if (dsselv.Tables[0].Rows[0]["premiumch"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumch"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'></td>";




                                                                    string col = dsselv.Tables[0].Rows[0]["Hue"].ToString();
                                                                    col = col.Substring(0, 3);
                                                                    string col1 = col;
                                                                    col1 = col1.Substring(0, 1);
                                                                    if (col1 == "B")
                                                                    {
                                                                        col = "B / W";
                                                                    }
                                                                    dytbl += "<td   align='center' class=display>" + col + "</td>";

                                                                    //for min word
                                                                    if (dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td   class=display align='center' >" + dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() + "</td>";
                                                                        minword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString());

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='center'></td>";

                                                                    if (dsselv.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                                                                    {
                                                                        //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                                                        dytbl += "<td   class=display align='center' >" + dsselv.Tables[1].Rows[kk]["package rate"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='center'></td>";
                                                                    //for extra word
                                                                    if (maxword > minword)
                                                                    {
                                                                        extraword = maxword - minword;
                                                                        if (dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != null && dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "")
                                                                            extrarate = Convert.ToDouble(dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString());
                                                                        dytbl += "<td   class=display align='center' >" + (extraword).ToString() + "</td>";
                                                                        //for extra rate
                                                                        dytbl += "<td    align='right' class='display1'>" + extrarate.ToString() + "</td>";
                                                                        dytbl += "<td   class=display align='center' >" + (extraword * extrarate).ToString() + "</td>";

                                                                    }
                                                                    else
                                                                    {
                                                                        dytbl += "<td  class=display align='center'>0</td>";
                                                                        //for extra rate
                                                                        dytbl += "<td    align='right' class='display1'></td>";
                                                                        dytbl += "<td  class=display align='center'>0</td>";
                                                                    }
                                                                }


                                                                if (dsselv.Tables[0].Rows[0]["Disc"].ToString() != "" && dsselv.Tables[0].Rows[0]["Disc"].ToString() != null)
                                                                {
                                                                    dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["Disc"].ToString() + "</td>";

                                                                }
                                                                else
                                                                    dytbl += "<td  class=display align='right'></td>";

                                                                dytbl += "<td    align='right' class='display1'>" + dsselv.Tables[1].Rows[kk]["package_rate"].ToString() + "</td>";

                                                                dytbl += "</tr>";

                                                                // To show edition and date when Insertion Change
                                                                dytbl += "<tr>";
                                                                dytbl += "<td    align='left' class='display'></td>";

                                                                if (dsselv.Tables[0].Rows[i]["Edition"].ToString() != "" && dsselv.Tables[0].Rows[i]["Edition"].ToString() != "")
                                                                {
                                                                    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                                                                }


                                                                if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                {
                                                                    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                }
                                                                else
                                                                    dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                dytbl += "<td    align='left' colspan='10' class='display'></td>";

                                                                dytbl += "</tr>";

                                                            }
                                                            else
                                                            {
                                                                if (pack != dsselv.Tables[0].Rows[i]["PACKAGE_CODE"].ToString())//When package Change
                                                                {
                                                                    pack = dsselv.Tables[0].Rows[i]["PACKAGE_CODE"].ToString();
                                                                    kk = kk + 1;
                                                                    dytbl += "<tr>";
                                                                    dytbl += "<td    align='left' class='display'>" + dsselv.Tables[0].Rows[i]["Ins.No."].ToString() + "." + dsselv.Tables[0].Rows[i]["Package"].ToString() + "</td>";
                                                                    dytbl += "<td   class=display align='center'></td>";
                                                                    dytbl += "<td   class=display align='center'></td>";

                                                                    if (dsselv.Tables[0].Rows[i]["Ad_type_code"].ToString() == "DI0" || dsselv.Tables[0].Rows[i]["Uom_code"].ToString() == "CL0")
                                                                    {

                                                                        dytbl += "<td    class=display align='center' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td style='' width='55px' >" + dsselv.Tables[0].Rows[i]["Depth"].ToString() + "</td><td>" + dsselv.Tables[0].Rows[i]["Width"].ToString() + "</td></tr></table></td>";
                                                                        dytbl += "<td   align='center' class=display>" + dsselv.Tables[0].Rows[i]["Volume"].ToString() + "</td>";
                                                                        if (dsselv.Tables[0].Rows[i]["premiumname"].ToString() != "" && dsselv.Tables[0].Rows[i]["premiumname"].ToString() != null)
                                                                        {
                                                                            dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='right'>---</td>";

                                                                        if (dsselv.Tables[0].Rows[0]["premiumch"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumch"].ToString() != null)
                                                                        {
                                                                            dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='right'></td>";




                                                                        string col = dsselv.Tables[0].Rows[0]["Hue"].ToString();
                                                                        col = col.Substring(0, 3);
                                                                        string col1 = col;
                                                                        col1 = col1.Substring(0, 1);
                                                                        if (col1 == "B")
                                                                        {
                                                                            col = "B / W";
                                                                        }
                                                                        dytbl += "<td   align='center' class=display>" + col + "</td>";


                                                                        if (dsselv.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                                                                        {
                                                                            //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                                                            dytbl += "<td   class=display align='center' >" + dsselv.Tables[1].Rows[kk]["package rate"].ToString() + "</td>";

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='center'></td>";
                                                                        //for extra rate
                                                                        dytbl += "<td    align='right' class='display1'></td>";

                                                                    }
                                                                    else
                                                                    {
                                                                        dytbl += "<td   align='center' class=display>" + dsselv.Tables[0].Rows[0]["Volume"].ToString() + "</td>";
                                                                        maxword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["Volume"].ToString());
                                                                        if (dsselv.Tables[0].Rows[0]["premiumname"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumname"].ToString() != null)
                                                                        {
                                                                            dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='right'>---</td>";

                                                                        if (dsselv.Tables[0].Rows[0]["premiumch"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumch"].ToString() != null)
                                                                        {
                                                                            dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='right'></td>";




                                                                        string col = dsselv.Tables[0].Rows[0]["Hue"].ToString();
                                                                        col = col.Substring(0, 3);
                                                                        string col1 = col;
                                                                        col1 = col1.Substring(0, 1);
                                                                        if (col1 == "B")
                                                                        {
                                                                            col = "B / W";
                                                                        }
                                                                        dytbl += "<td   align='center' class=display>" + col + "</td>";

                                                                        //for min word
                                                                        if (dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() != "")
                                                                        {
                                                                            dytbl += "<td   class=display align='center' >" + dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() + "</td>";
                                                                            minword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString());

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='center'></td>";

                                                                        if (dsselv.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                                                                        {
                                                                            //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                                                            dytbl += "<td   class=display align='center' >" + dsselv.Tables[1].Rows[kk]["package rate"].ToString() + "</td>";

                                                                        }
                                                                        else
                                                                            dytbl += "<td  class=display align='center'></td>";
                                                                        //for extra word
                                                                        if (maxword > minword)
                                                                        {
                                                                            extraword = maxword - minword;
                                                                            if (dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != null && dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "")
                                                                                extrarate = Convert.ToDouble(dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString());
                                                                            dytbl += "<td   class=display align='center' >" + (extraword).ToString() + "</td>";
                                                                            //for extra rate
                                                                            dytbl += "<td    align='right' class='display1'>" + extrarate.ToString() + "</td>";
                                                                            dytbl += "<td   class=display align='center' >" + (extraword * extrarate).ToString() + "</td>";

                                                                        }
                                                                        else
                                                                        {
                                                                            dytbl += "<td  class=display align='center'>0</td>";
                                                                            //for extra rate
                                                                            dytbl += "<td    align='right' class='display1'></td>";
                                                                            dytbl += "<td  class=display align='center'>0</td>";
                                                                        }
                                                                    }





                                                                    if (dsselv.Tables[0].Rows[0]["Disc"].ToString() != "" && dsselv.Tables[0].Rows[0]["Disc"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["Disc"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'></td>";

                                                                    dytbl += "<td    align='right' class='display1'>" + dsselv.Tables[1].Rows[kk]["package_rate"].ToString() + "</td>";

                                                                    dytbl += "</tr>";

                                                                    // To show edition and date when Insertion Change
                                                                    dytbl += "<tr>";
                                                                    dytbl += "<td    align='left' class='display'></td>";

                                                                    if (dsselv.Tables[0].Rows[i]["Edition"].ToString() != "" && dsselv.Tables[0].Rows[i]["Edition"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                                                                    }


                                                                    if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                    }
                                                                    else
                                                                        dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                    dytbl += "<td    align='left' colspan='10' class='display'></td>";

                                                                    dytbl += "</tr>";
                                                                }
                                                                else
                                                                {
                                                                    // To show edition and date of that Package
                                                                    dytbl += "<tr>";
                                                                    dytbl += "<td    align='left' class='display'></td>";

                                                                    if (dsselv.Tables[0].Rows[i]["Edition"].ToString() != "" && dsselv.Tables[0].Rows[i]["Edition"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                                                                    }


                                                                    if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                    }
                                                                    else
                                                                        dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                    dytbl += "<td    align='left' colspan='10' class='display'></td>";

                                                                    dytbl += "</tr>";
                                                                }
                                                            }


                                                        }
                                                        dytbl += "</table>";
                                                        objcard.hideamt = "none";
                                                        if (p1 == (pagecount - 1))
                                                        {
                                                            objcard.hideamt = "";
                                                            //objcard.netamttab1 = "none";
                                                            double bulletcrg = 0;
                                                            double grosamt = Convert.ToDouble(dsselv.Tables[0].Rows[0]["Gross_amount"].ToString());
                                                            double insertgross = 0;
                                                            if (dsselv.Tables[1].Rows[0]["insert_gross"].ToString() != "")
                                                                insertgross = Convert.ToDouble(dsselv.Tables[1].Rows[0]["insert_gross"].ToString());
                                                            //add_ag_dis = grosamt * add_ag_dis / 100;
                                                            //grosamt = grosamt - add_ag_dis;
                                                            //objcard.traddis1 = traddis.ToString("F2");
                                                            //traddis = grosamt * traddis / 100;
                                                            objcard.traddis1 = traddis.ToString("F2");
                                                            traddis = grosamt * traddis / 100;
                                                            grosamt = grosamt - traddis;
                                                            add_ag_dis = grosamt * add_ag_dis / 100;

                                                            objcard.traddisamt = traddis.ToString("F2");
                                                            objcard.grossamt = dsselv.Tables[0].Rows[0]["Gross_amount"].ToString();
                                                            objcard.add_ag_dis1 = add_ag_dis.ToString("F2");
                                                            objcard.adddis1 = (adddis + addchr).ToString("F2");
                                                            //objcard.addchr1 = addchr;
                                                            objcard.boxcrg1 = dsselv.Tables[0].Rows[0]["boxchares"].ToString();
                                                            if (dsselv.Tables[0].Rows[0]["Bullet_Charges"].ToString() != "")
                                                            {
                                                                bulletcrg = Convert.ToDouble(dsselv.Tables[0].Rows[0]["Bullet_Charges"].ToString());
                                                                bulletcrg = bulletcrg * Convert.ToDouble(insert);

                                                            }
                                                            objcard.bullet1 = bulletcrg.ToString("F2");
                                                            objcard.transcrg1 = (insertgross * translation_per / 100).ToString("F2");

                                                        }
                                                        objcard.netbillamt1 = dsselv.Tables[0].Rows[0]["Bill_amount"].ToString();
                                                        objcard.dynamictable1 = dytbl;
                                                        objcard.setReceiptData();
                                                        Page.Controls.Add(objcard);
                                                    }
                                                }
                                                else
                                                {
                                                    insert = "";
                                                    pack = "";
                                                    //for (int p1 = 0; p1 < pagecount; p1++)
                                                    //{
                                                        //ct = maxlimit * p1;
                                                        //fr = maxlimit * (p1 + 1);

                                                        RP_bill_combined objcard = new RP_bill_combined();
                                                        objcard = (RP_bill_combined)(Page.LoadControl("RP_bill_combined.ascx"));

                                                        //if (i3 == count - 1)
                                                        //{
                                                        //    objcard.chkvalue_length = "no";
                                                        //}
                                                        //else
                                                        //{
                                                        //    objcard.chkvalue_length = "yes";
                                                        //}

                                                        //To fill data in Dynamic Table Header
                                                        dytbl = "";
                                                        dytbl += "<table width='900px' border=0 align='left' cellpadding='0' cellspacing='0' >";
                                                        DataSet dsb = new DataSet();
                                                        dsb.ReadXml(Server.MapPath("XML/RP_bill.xml"));
                                                        if (Session["bill_org"].ToString() == "0")
                                                        {
                                                            objcard.orgdup1 = dsb.Tables[0].Rows[0].ItemArray[15].ToString();
                                                        }
                                                        else
                                                        {
                                                            objcard.orgdup1 = dsb.Tables[0].Rows[0].ItemArray[16].ToString();
                                                        }

                                                        objcard.txtinvoice1 = invoice_no1[i3];
                                                        dytbl += "<tr align=center >";
                                                        dytbl += "<td class='insertiontxtclass1' width='85px'  >" + dsb.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>";
                                                        dytbl += "<td class='insertiontxtclass1' width='125x'  >" + dsb.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                                                        dytbl += "<td   class='insertiontxtclass1'width='75px' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";

                                                        //if (dsselv.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || dsselv.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                                                        //{
                                                        //    dytbl += "<td   class='insertiontxtclass1' width='100px' >" + "<table cellpadding='0' cellspacing='0' width='100px' ><tr><td colspan='2'>" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + " </td></tr><tr><td  style='border-right:solid 1px black;border-top:solid 1px black' >Height</td><td style='border-top:solid 1px black'>Width</td></tr></table></td>";
                                                        //    dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                                                        //    dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                                                        //    dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                                                        //    dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                                                        //    dytbl += "<td  class='insertiontxtclass1' width='100px' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                                                        //    dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                                                        //    dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                                                        //    dytbl += "<td    class='insertiontxtclass14' width='100px' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                                                        //    objcard.adcat1 = dsselv.Tables[0].Rows[0]["Cap"].ToString();


                                                        //}
                                                        //else
                                                        //{
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                                                        dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                                                        dytbl += "<td class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>";
                                                        dytbl += "<td  class='insertiontxtclass1' width='50px' >" + dsb.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                                                        dytbl += "<td    class='insertiontxtclass14'>" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                                                        objcard.adcat1 = dsselv.Tables[0].Rows[0]["Adv_Cat_Name"].ToString() + "/" + dsselv.Tables[0].Rows[0]["Adv_Subcat_Name"].ToString();
                                                        //}

                                                        dytbl += "</tr>";

                                                        //============***********************======================//
                                                        objcard.agencytxt1 = dsselv.Tables[0].Rows[0]["Agency"].ToString();
                                                        objcard.lblkeyno1 = dsselv.Tables[0].Rows[0]["Key No"].ToString();

                                                        street = dsselv.Tables[0].Rows[0]["street"].ToString();
                                                        string agadd = dsselv.Tables[0].Rows[0]["add1"].ToString();
                                                        objcard.agencyaddtxt1 = agadd + "," + street + dsselv.Tables[0].Rows[0]["add2"].ToString() + dsselv.Tables[0].Rows[0]["add3"].ToString();

                                                        objcard.lb_booking_id1 = dsselv.Tables[0].Rows[0]["CIOID"].ToString();
                                                        objcard.runtxt1 = dsselv.Tables[0].Rows[0]["BILL_DATE"].ToString();


                                                        objcard.txtcliname1 = dsselv.Tables[0].Rows[0]["advertiser"].ToString();
                                                        objcard.lbronodate1 = dsselv.Tables[0].Rows[0]["RoNo."].ToString() + "-" + dsselv.Tables[0].Rows[0]["RO_Date"].ToString();

                                                        if (dsselv.Tables[0].Rows[0]["Bill_remarks"].ToString() != "" && dsselv.Tables[0].Rows[0]["Bill_remarks"].ToString() != null)
                                                        {
                                                            objcard.lblremark1 = dsselv.Tables[0].Rows[0]["Bill_remarks"].ToString();
                                                        }
                                                        if (dsselv.Tables[0].Rows[0]["Scheme"].ToString() != "" && dsselv.Tables[0].Rows[0]["Scheme"].ToString() != null)
                                                        {
                                                            objcard.lblschemetype1 = dsselv.Tables[0].Rows[0]["Scheme"].ToString();
                                                        }


                                                        //=============================************========================================//
                                                        if (dsselv.Tables[0].Rows[0]["trade_disc"].ToString() != "")
                                                        {
                                                            traddis = Convert.ToDouble(dsselv.Tables[0].Rows[0]["trade_disc"].ToString());
                                                        }
                                                        else
                                                        {
                                                            traddis = 0;
                                                        }
                                                        if (dsselv.Tables[0].Rows[0]["addcom"].ToString() != "" && dsselv.Tables[0].Rows[0]["addcom"].ToString() != null)
                                                        {
                                                            add_ag_dis = Convert.ToDouble(dsselv.Tables[0].Rows[0]["addcom"].ToString());
                                                        }
                                                        else
                                                        {
                                                            traddis = 0;
                                                        }

                                                        if (dsselv.Tables[0].Rows[0]["special_discount"].ToString() != "")
                                                        {
                                                            adddis = Convert.ToDouble(dsselv.Tables[0].Rows[0]["special_discount"].ToString());
                                                        }

                                                        if (dsselv.Tables[0].Rows[0]["special_charges"].ToString() != "")
                                                        {
                                                            addchr = Convert.ToDouble(dsselv.Tables[0].Rows[0]["special_charges"].ToString());

                                                        }
                                                        if (dsselv.Tables[0].Rows[0]["TRANSLATION_PREMIUM"].ToString() != "")
                                                        {
                                                            translation_per = Convert.ToDouble(dsselv.Tables[0].Rows[0]["TRANSLATION_PREMIUM"].ToString());

                                                        }


                                                        for (i = 0; i < rownum; i++)
                                                        {

                                                            if (insert != dsselv.Tables[0].Rows[i]["Ins.No."].ToString())//When Insertion change
                                                            {
                                                                if (i != 0)
                                                                    kk = kk + 1;
                                                                insert = dsselv.Tables[0].Rows[i]["Ins.No."].ToString();
                                                                pack = dsselv.Tables[0].Rows[i]["PACKAGE_CODE"].ToString();

                                                                dytbl += "<tr>";
                                                                dytbl += "<td    align='left' class='display'>" + dsselv.Tables[0].Rows[i]["Ins.No."].ToString() + "." + dsselv.Tables[0].Rows[i]["Package"].ToString() + "</td>";
                                                                dytbl += "<td   class=display align='center'></td>";
                                                               // dytbl += "<td   class=display align='center'></td>";
                                                                if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                {
                                                                    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                }
                                                                else
                                                                    dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                //{
                                                                dytbl += "<td   align='center' class=display>" + dsselv.Tables[0].Rows[0]["Volume"].ToString() + "</td>";
                                                                maxword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["Volume"].ToString());
                                                                if (dsselv.Tables[0].Rows[0]["premiumname"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumname"].ToString() != null)
                                                                {
                                                                    dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                                                                }
                                                                else
                                                                    dytbl += "<td  class=display align='right'>---</td>";

                                                                if (dsselv.Tables[0].Rows[0]["premiumch"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumch"].ToString() != null)
                                                                {
                                                                    dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                                                                }
                                                                else
                                                                    dytbl += "<td  class=display align='right'></td>";




                                                                string col = dsselv.Tables[0].Rows[0]["Hue"].ToString();
                                                                col = col.Substring(0, 3);
                                                                string col1 = col;
                                                                col1 = col1.Substring(0, 1);
                                                                if (col1 == "B")
                                                                {
                                                                    col = "B / W";
                                                                }
                                                                dytbl += "<td   align='center' class=display>" + col + "</td>";

                                                                //for min word
                                                                if (dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() != "")
                                                                {
                                                                    dytbl += "<td   class=display align='center' >" + dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() + "</td>";
                                                                    minword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString());

                                                                }
                                                                else
                                                                    dytbl += "<td  class=display align='center'></td>";

                                                                if (dsselv.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                                                                {
                                                                    //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                                                    dytbl += "<td   class=display align='center' >" + dsselv.Tables[1].Rows[kk]["package rate"].ToString() + "</td>";

                                                                }
                                                                else
                                                                    dytbl += "<td  class=display align='center'></td>";
                                                                //for extra word
                                                                if (maxword > minword)
                                                                {
                                                                    extraword = maxword - minword;
                                                                    if (dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != null && dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "")
                                                                        extrarate = Convert.ToDouble(dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString());
                                                                    dytbl += "<td   class=display align='center' >" + (extraword).ToString() + "</td>";
                                                                    //for extra rate
                                                                    dytbl += "<td    align='right' class='display1'>" + extrarate.ToString() + "</td>";
                                                                    dytbl += "<td   class=display align='center' >" + (extraword * extrarate).ToString() + "</td>";

                                                                }
                                                                else
                                                                {
                                                                    dytbl += "<td  class=display align='center'>0</td>";
                                                                    //for extra rate
                                                                    dytbl += "<td    align='right' class='display1'></td>";
                                                                    dytbl += "<td  class=display align='center'>0</td>";
                                                                }
                                                                //}


                                                                if (dsselv.Tables[0].Rows[0]["Disc"].ToString() != "" && dsselv.Tables[0].Rows[0]["Disc"].ToString() != null)
                                                                {
                                                                    dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["Disc"].ToString() + "</td>";

                                                                }
                                                                else
                                                                    dytbl += "<td  class=display align='right'></td>";

                                                                //dytbl += "<td    align='right' class='display1'>" + dsselv.Tables[1].Rows[kk]["package_rate"].ToString() + "</td>";
                                                                if (dsselv.Tables[1].Rows[kk]["package_rate"].ToString() != "")
                                                                {
                                                                    double packrat1 = Convert.ToDouble(dsselv.Tables[1].Rows[kk]["package_rate"].ToString());
                                                                    dytbl += "<td    align='right' class='display1'>" + packrat1.ToString("F2") + "</td>";
                                                                }
                                                                else
                                                                {
                                                                    dytbl += "<td    align='right' class='display1'>0.00</td>";
                                                                }
                                                                dytbl += "</tr>";

                                                                // To show edition and date when Insertion Change
                                                                //dytbl += "<tr>";
                                                                //dytbl += "<td    align='left' class='display'></td>";

                                                                //if (dsselv.Tables[0].Rows[i]["Edition"].ToString() != "" && dsselv.Tables[0].Rows[i]["Edition"].ToString() != "")
                                                                //{
                                                                //    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                                                                //}


                                                                //if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                //{
                                                                //    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                //}
                                                                //else
                                                                //    dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                //dytbl += "<td    align='left' colspan='10' class='display'></td>";

                                                                //dytbl += "</tr>";

                                                            }
                                                            else
                                                            {
                                                                if (pack != dsselv.Tables[0].Rows[i]["PACKAGE_CODE"].ToString())//When package Change
                                                                {
                                                                    pack = dsselv.Tables[0].Rows[i]["PACKAGE_CODE"].ToString();
                                                                    kk = kk + 1;
                                                                    dytbl += "<tr>";
                                                                    dytbl += "<td    align='left' class='display'>" + dsselv.Tables[0].Rows[i]["Ins.No."].ToString() + "." + dsselv.Tables[0].Rows[i]["Package"].ToString() + "</td>";
                                                                    dytbl += "<td   class=display align='center'></td>";
                                                             //       dytbl += "<td   class=display align='center'></td>";
                                                                    if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                    }
                                                                    else
                                                                        dytbl += "<td   class=display align='center'>**/**/****</td>";
                                                                    //{
                                                                    dytbl += "<td   align='center' class=display>" + dsselv.Tables[0].Rows[0]["Volume"].ToString() + "</td>";
                                                                    maxword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["Volume"].ToString());
                                                                    if (dsselv.Tables[0].Rows[0]["premiumname"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumname"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumname"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'>---</td>";

                                                                    if (dsselv.Tables[0].Rows[0]["premiumch"].ToString() != "" && dsselv.Tables[0].Rows[0]["premiumch"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["premiumch"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'></td>";




                                                                    string col = dsselv.Tables[0].Rows[0]["Hue"].ToString();
                                                                    col = col.Substring(0, 3);
                                                                    string col1 = col;
                                                                    col1 = col1.Substring(0, 1);
                                                                    if (col1 == "B")
                                                                    {
                                                                        col = "B / W";
                                                                    }
                                                                    dytbl += "<td   align='center' class=display>" + col + "</td>";

                                                                    //for min word
                                                                    if (dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() != "")
                                                                    {
                                                                        dytbl += "<td   class=display align='center' >" + dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString() + "</td>";
                                                                        minword = Convert.ToInt32(dsselv.Tables[0].Rows[0]["MIN_WORD"].ToString());

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='center'></td>";

                                                                    if (dsselv.Tables[0].Rows[0]["Card_Rate"].ToString() != "")
                                                                    {
                                                                        //dytbl += "<td   class=display align='center' >" + ds4.Tables[0].Rows[0]["Card_Rate"].ToString() + "</td>";
                                                                        dytbl += "<td   class=display align='center' >" + dsselv.Tables[1].Rows[kk]["package rate"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='center'></td>";
                                                                    //for extra word
                                                                    if (maxword > minword)
                                                                    {
                                                                        extraword = maxword - minword;
                                                                        if (dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != null && dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "")
                                                                            extrarate = Convert.ToDouble(dsselv.Tables[0].Rows[0]["EXTRA_RATE"].ToString());
                                                                        dytbl += "<td   class=display align='center' >" + (extraword).ToString() + "</td>";
                                                                        //for extra rate
                                                                        dytbl += "<td    align='right' class='display1'>" + extrarate.ToString() + "</td>";
                                                                        dytbl += "<td   class=display align='center' >" + (extraword * extrarate).ToString() + "</td>";

                                                                    }
                                                                    else
                                                                    {
                                                                        dytbl += "<td  class=display align='center'>0</td>";
                                                                        //for extra rate
                                                                        dytbl += "<td    align='right' class='display1'></td>";
                                                                        dytbl += "<td  class=display align='center'>0</td>";
                                                                    }
                                                                    //}

                                                                    if (dsselv.Tables[0].Rows[0]["Disc"].ToString() != "" && dsselv.Tables[0].Rows[0]["Disc"].ToString() != null)
                                                                    {
                                                                        dytbl += "<td   class=display align='right' >" + dsselv.Tables[0].Rows[0]["Disc"].ToString() + "</td>";

                                                                    }
                                                                    else
                                                                        dytbl += "<td  class=display align='right'></td>";
                                                                    if (dsselv.Tables[1].Rows[kk]["package_rate"].ToString() != "")
                                                                    {
                                                                        double packrat1 = Convert.ToDouble(dsselv.Tables[1].Rows[kk]["package_rate"].ToString());
                                                                        dytbl += "<td    align='right' class='display1'>" + packrat1.ToString("F2") + "</td>";
                                                                    }
                                                                    else
                                                                    {
                                                                        dytbl += "<td    align='right' class='display1'>0.00</td>";
                                                                    }
                                                                    dytbl += "</tr>";

                                                                    // To show edition and date when Insertion Change
                                                                    //dytbl += "<tr>";
                                                                    //dytbl += "<td    align='left' class='display'></td>";

                                                                    //if (dsselv.Tables[0].Rows[i]["Edition"].ToString() != "" && dsselv.Tables[0].Rows[i]["Edition"].ToString() != "")
                                                                    //{
                                                                    //    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                                                                    //}


                                                                    //if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                    //{
                                                                    //    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                    //}
                                                                    //else
                                                                    //    dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                    //dytbl += "<td    align='left' colspan='10' class='display'></td>";

                                                                    //dytbl += "</tr>";
                                                                }
                                                                else
                                                                {
                                                                    // To show edition and date of that Package
                                                                    //dytbl += "<tr>";
                                                                    //dytbl += "<td    align='left' class='display'></td>";

                                                                    //if (dsselv.Tables[0].Rows[i]["Edition"].ToString() != "" && dsselv.Tables[0].Rows[i]["Edition"].ToString() != "")
                                                                    //{
                                                                    //    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Edition"].ToString() + "</td>";

                                                                    //}


                                                                    //if (dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() != "")
                                                                    //{
                                                                    //    dytbl += "<td  class=display  align='center' >" + dsselv.Tables[0].Rows[i]["Ins.Date"].ToString() + "</td>";
                                                                    //}
                                                                    //else
                                                                    //    dytbl += "<td   class=display align='center'>**/**/****</td>";

                                                                    //dytbl += "<td    align='left' colspan='10' class='display'></td>";

                                                                    //dytbl += "</tr>";
                                                                }
                                                            }


                                                        }
                                                        dytbl += "</table>";
                                                        objcard.hideamt = "none";
                                                        //if (p1 == (pagecount - 1))
                                                        {
                                                            objcard.hideamt = "";
                                                            //objcard.netamttab1 = "none";
                                                            double bulletcrg = 0;
                                                            double grosamt = Convert.ToDouble(dsselv.Tables[0].Rows[0]["Gross_amount"].ToString());
                                                            double insertgross = 0;
                                                            if (dsselv.Tables[1].Rows[0]["insert_gross"].ToString() != "")
                                                                insertgross = Convert.ToDouble(dsselv.Tables[1].Rows[0]["insert_gross"].ToString());
                                                            //add_ag_dis = grosamt * add_ag_dis / 100;
                                                            //grosamt = grosamt - add_ag_dis;
                                                            //objcard.traddis1 = traddis.ToString("F2");
                                                            //traddis = grosamt * traddis / 100;
                                                            objcard.traddis1 = traddis.ToString("F2");
                                                            traddis = grosamt * traddis / 100;
                                                            grosamt = grosamt - traddis;
                                                            add_ag_dis = grosamt * add_ag_dis / 100;

                                                            objcard.traddisamt = traddis.ToString("F2");
                                                            objcard.grossamt = dsselv.Tables[0].Rows[0]["Gross_amount"].ToString();
                                                            objcard.add_ag_dis1 = add_ag_dis.ToString("F2");
                                                            objcard.adddis1 = (adddis + addchr).ToString("F2");
                                                            //objcard.addchr1 = addchr;
                                                            objcard.boxcrg1 = dsselv.Tables[0].Rows[0]["boxchares"].ToString();
                                                            if (dsselv.Tables[0].Rows[0]["Bullet_Charges"].ToString() != "")
                                                            {
                                                                bulletcrg = Convert.ToDouble(dsselv.Tables[0].Rows[0]["Bullet_Charges"].ToString());
                                                                bulletcrg = bulletcrg * Convert.ToDouble(insert);

                                                            }
                                                            objcard.bullet1 = bulletcrg.ToString("F2");
                                                            objcard.transcrg1 = (insertgross * translation_per / 100).ToString("F2");

                                                        }
                                                        objcard.netbillamt1 = dsselv.Tables[0].Rows[0]["Bill_amount"].ToString();
                                                        objcard.dynamictable1 = dytbl;
                                                        objcard.setReceiptData();
                                                        Page.Controls.Add(objcard);
                                                    //}//
                                                }


                                            }
                                            else
                                                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "RP")
                                                {

                                                    RP_bill objcard = new RP_bill();
                                                    objcard = (RP_bill)(Page.LoadControl("RP_bill.ascx"));


                                                    objcard.valueofradio = checkradio.ToString();
                                                    placeholder1.Controls.Add(objcard);

                                                    objcard.invoiceno = invoice_no1[i3];
                                                    objcard.packagelength = c1.ToString();
                                                    objcard.insertion = insertion2[i3].ToString();//i11.ToString();
                                                    objcard.packagecode = editionbill2[i3].ToString(); //packagecode2.ToString();
                                                    objcard.id = ciobookingid1.ToString();
                                                    objcard.totalinsertion = no_of_insertion.ToString();
                                                    objcard.bookingdate = bookingd;// Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                                    objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                                    objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                                    objcard.qbc = branch;
                                                    objcard.editionnameplus = editionname.ToString();
                                                    objcard.setcard();

                                                }

        }
    }
}
