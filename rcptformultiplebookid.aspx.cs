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


public partial class rcptformultiplebookid : System.Web.UI.Page
{
    string dta = "true";
    string cioid = "";
    string cls_matter = "";
    double trade_dis = 0;
    double cash_dis = 0;
    double addl_dis = 0;
    double netamount = 0;
    double grossamount = 0;
    double pg_prem = 0;
    string dytbl = "";
    int aa;
    string idbook = "";
    double last_total_amount = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        cioid = Request.QueryString["cioid"].ToString();

        string[] spl = cioid.Split(',');

        aa = Convert.ToInt32(Request.QueryString["length"].ToString());


        // cls_matter = Request.QueryString["clsmatter"].ToString();
        getMatterPreview(cioid);





        for (int i = 0; i < aa - 1; i++)
        {

            onscreen(cioid.Replace(",", ""), Session["dateformat"].ToString(), "ORIGINAL", aa, spl[i]);
        }

        //  onscreen(cioid, Session["dateformat"].ToString(),"DUPLICATE");
        // onscreen(cioid, "mm/dd/yyyy");
        string myscript1 = "<script language='Javascript'>";
        myscript1 += "JavaScript: var windowObject = window.self;windowObject.opener = window.self; windowObject.print();";
        myscript1 += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript1);
        }

        string myscript = "<script language='Javascript'>";
        myscript += "JavaScript: var windowObject = window.self;windowObject.opener = window.self; windowObject.close();";
        myscript += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript);
        }

    }
    //Function to get metter
    private void getMatterPreview(string booking_id)
    {
        string booking_id12 = "";
        DataSet dr = new DataSet();
        if (booking_id.IndexOf(',') > 0)
        {
            string[] booking_id1 = booking_id.Split(',');
             booking_id12 = booking_id1[0];
        }
        else
        {
             booking_id12 = booking_id;
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt objmatter = new NewAdbooking.Classes.classifiedreceipt();
            dr = objmatter.clsreceiptmatter(booking_id12);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classifiedreceipt objmatter = new NewAdbooking.classesoracle.classifiedreceipt();
                dr = objmatter.clsreceiptmatter(booking_id12);

            }
            else
            {
            }
        if (dr.Tables[0].Rows.Count > 0)
        {
            cls_matter = dr.Tables[0].Rows[0]["RTFformat"].ToString();
        }
        else
        {
            cls_matter = "";
        }
    }
    private void onscreen(string cioid, string dateformat, string labelval, int aa, string bookingid)
    {

        //for (int ii = 0; ii < aa - 1; ii++)
        //{





        RCB obj_RCB2 = new RCB();
        obj_RCB2 = (RCB)Page.LoadControl("RCB.ascx");
        string client_nam = ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classifiedreceipt obj = new NewAdbooking.classesoracle.classifiedreceipt();
            if (client_nam == "kannad")
                ds = obj.selectreceipt_rp(Session["compcode"].ToString(), bookingid, dateformat);
            else
                ds = obj.selectreceipt(cioid, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt obj = new NewAdbooking.Classes.classifiedreceipt();
            ds = obj.selectreceipt(cioid, dateformat);
        }
        int maxlimit = 23;
        int ct = 0;
        int fr = maxlimit;
        float ht = 40;

        int rcount = ds.Tables[1].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;

        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }
        for (int p1 = 0; p1 < pagecount; p1++)
        {

            DataSet ds_xml = new DataSet();
            ds_xml.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));


            if (client_nam == "SP")
            {
                RCB obj_RCB = new RCB();
                obj_RCB = (RCB)Page.LoadControl("RCB.ascx");

                obj_RCB.lbextpre1 = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
                obj_RCB.lbtrade11 = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();
                string path = "Images/" + ds_xml.Tables[0].Rows[0].ItemArray[52].ToString();
                if (ds.Tables[0].Rows[0]["DOCTYPE"].ToString() == "CA")
                    obj_RCB.lblnetpayable1 = "Refund Amount";
                else
                    obj_RCB.lblnetpayable1 = "Net Amount";
                obj_RCB.lbadtd1 = ds_xml.Tables[0].Rows[0].ItemArray[24].ToString();
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                obj_RCB.agddxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
                obj_RCB.lbaddress1 = ds.Tables[0].Rows[0]["address"].ToString();
                obj_RCB.txtcliname1 = ds.Tables[0].Rows[0]["Client2"].ToString();
                obj_RCB.lbcaption1 = ds.Tables[0].Rows[0]["caption"].ToString();
                obj_RCB.txtpackname1 = ds.Tables[0].Rows[0]["Package_Name"].ToString();
                obj_RCB.lblcashdisc1 = ds.Tables[0].Rows[0]["CASHDISCOUNT"].ToString();
                obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["cat2"].ToString();
                if (System.IO.File.Exists(Server.MapPath(path)))
                {
                    obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
                }

                obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));

                // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
                obj_RCB.lbbilltype1 = labelval;
                if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                else
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
                obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["BookDate"].ToString();
                obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
                string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
                if (p1 == pagecount - 1)
                {
                    obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
                    if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                        obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
                    else
                        obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt"].ToString() + ".00";

                    obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
                    obj_RCB.lbpune1 = "PAN NO.";
                    obj_RCB.lbpunetxt1 = ds.Tables[0].Rows[0]["PAN_No"].ToString();

                    obj_RCB.lbextpre1 = obj_RCB.lbextpre1 + "(" + ds.Tables[0].Rows[0]["Page_prem"].ToString() + "%" + ")";
                    double pkg_amount = Convert.ToDouble(ds.Tables[0].Rows[0]["cardamount"].ToString());
                    if (ds.Tables[0].Rows[0]["Page_prem"].ToString() != "" && ds.Tables[0].Rows[0]["Page_prem"].ToString() != "0")
                    {
                        double prem = Convert.ToDouble(ds.Tables[0].Rows[0]["Page_prem"].ToString()) + 100;
                        pg_prem = pkg_amount - (pkg_amount * 100 / prem);
                        obj_RCB.lbextrapre1 = Convert.ToString(Convert.ToInt32(pg_prem)) + ".00";
                    }
                    else
                        obj_RCB.lbextrapre1 = "0.00";

                    if (obj_RCB.txtgrossamt1 != "")
                    {
                        if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                            grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                        else
                            grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString());
                    }
                    if (obj_RCB.lbextrapre1 == "0.00")
                    {
                        if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()))) + ".00";
                        else
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()))) + ".00";
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                        else
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                    }
                    obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";

                    obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                    obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
                    obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
                    obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
                    if (ds.Tables[0].Rows[0]["boxcharge"] != null && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "" && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "0")
                        obj_RCB.lblbox1 = ds.Tables[0].Rows[0]["boxcharge"].ToString();
                    else
                        obj_RCB.lblbox1 = "0.00";
                    if ((obj_RCB.txtdiscal1 != "") && (obj_RCB.txtdiscal1 != "0"))
                    {
                        trade_dis = Convert.ToDouble(obj_RCB.txtdiscal1);
                    }
                    if ((obj_RCB.lblcashdisc1 != "") && (obj_RCB.lblcashdisc1 != "0"))
                    {
                        cash_dis = Convert.ToDouble(obj_RCB.lblcashdisc1);
                    }
                    if (obj_RCB.lbadtdtxt1 != "")
                    {
                        addl_dis = Convert.ToDouble(obj_RCB.lbadtdtxt1);
                    }

                    netamount = Convert.ToInt32(grossamount);
                    obj_RCB.lbadtdtxt1 = "0.00";
                    if (trade_dis != 0)
                    {
                        netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
                    }
                    if (addl_dis != 0)
                    {
                        netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
                        // obj_RCB.lbadtdtxt1 = Convert.ToString(Convert.ToInt32(grossamount * ((addl_dis) / 100))) + ".00";
                        obj_RCB.lbadtdtxt1 = Convert.ToString(grossamount * ((addl_dis) / 100));
                        obj_RCB.lbadtdtxt1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lbadtdtxt1));
                    }
                    if (cash_dis != 0)
                    {
                        obj_RCB.lblcashdisc1 = Convert.ToString(netamount * ((cash_dis) / 100));
                        netamount = netamount - (netamount * ((cash_dis) / 100));

                        obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
                    }
                    else
                    {
                        if (obj_RCB.lblcashdisc1 == "")
                            obj_RCB.lblcashdisc1 = "";
                        else
                            obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
                    }
                    ////else
                    ////{
                    ////    netamount = Convert.ToInt32(grossamount);
                    ////    obj_RCB.lbadtdtxt1 = "0.00";
                    ////}
                    //
                    if (obj_RCB.lblbox1 != "")
                    {
                        if (ds.Tables[0].Rows[0]["boxtype"].ToString() == "1")
                        {
                            netamount = netamount + Convert.ToDouble(obj_RCB.lblbox1);
                        }
                        else
                        {
                            obj_RCB.lblbox1 = Convert.ToString(netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));
                            netamount = netamount + (netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));

                            obj_RCB.lblbox1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblbox1));
                        }
                    }
                    netamount = netamount + .01;
                    netamount = Math.Round(netamount);

                    if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
                    {
                        netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
                        obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
                    }
                    if (netamount < 0)
                        netamount = netamount * -1;
                    obj_RCB.netpay1 = String.Format("{0:0.00}", netamount);

                    if (ds.Tables[0].Rows[0]["Booking_type"].ToString().ToUpper() == "2")   //2 FOR FMG
                        obj_RCB.netpay1 = "0.00";
                    obj_RCB.txtdiscal1 = Math.Round((grossamount * trade_dis / 100), 2).ToString();
                    if (obj_RCB.txtdiscal1.IndexOf(".") < 0)
                        obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + ".00";
                    else
                        if (obj_RCB.txtdiscal1.Split('.')[1].Length == 1)
                            obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + "0";

                    NumberToEngish objwords = new NumberToEngish();
                    obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.netpay1) + "Only";
                    obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
                }

                /////////////////////////////////////////// dynamic table  ***************


                int count = ds.Tables[1].Rows.Count;
                int i;
                dytbl = "";

                dytbl += "<table width='500px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                    // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                    //dytbl += "<td class='insertiontxtclasslast1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
                    dytbl += "</tr>";
                }

                for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
                {
                    //if (p1 == 0)
                    //{
                    //    dytbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'  class='break' valign='top'> ";
                    //}
                    //else
                    //{
                    //    dytbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='2'   valign='top' > ";
                    //}
                    dytbl += "<tr>";
                    dytbl += "<td width=235px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
                    dytbl += "<td width=60px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

                    if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
                    {
                        dytbl += "<td width=38px class='insertiontxtclass2'  align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
                    }
                    else if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
                    {
                        dytbl += "<td width=38px class='insertiontxtclass2' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width=38px class='insertiontxtclass2'  align=center>---</td>";
                    }
                    ////if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
                    ////{
                    ////    dytbl += "<td width=43px class='insertiontxtclass' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
                    ////}
                    ////else
                    ////{
                    ////    dytbl += "<td width=43px  class='insertiontxtclass'align=center>---</td>";
                    ////}
                    if (ds.Tables[1].Rows[i]["Col_Alias"].ToString() != "")
                    {
                        dytbl += "<td width=35px class='insertiontxtclass2' align=left>" + ds.Tables[1].Rows[i]["Col_Alias"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width=35px  class='insertiontxtclass2' align=center>---</td>";
                    }
                    if (ds.Tables[1].Rows[i]["Page_No"].ToString() != "")  //0
                    {
                        dytbl += "<td width=51px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Page_No"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width=51px  class='insertiontxtclass2'align=center>---</td>";
                    }

                    //if (ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != "" && ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != null && ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != "0")  //0
                    //{
                    //    dytbl += "<td width=45px class='insertiontxtclass2' align=right>" + ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() + "</td>";
                    //}
                    //else if (ds.Tables[1].Rows[i]["Solo_Rate"].ToString() != "")
                    //{
                    //    dytbl += "<td width=45px class='insertiontxtclass2' align=right>" + ds.Tables[1].Rows[i]["Solo_Rate"].ToString() + "</td>";
                    //}
                    //else
                    //{
                    //    dytbl += "<td width=45px  class='insertiontxtclass2' align=left>---</td>";

                    //}

                    dytbl += "</tr>";

                }  //
                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();
                Page.Controls.Add(obj_RCB);

            }
            else if (client_nam == "kannad")
            {
                RCB_RP obj_RCB = new RCB_RP();
                obj_RCB = (RCB_RP)Page.LoadControl("RCB_RP.ascx");

                //obj_RCB.lbextpre1 = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
                //obj_RCB.lbtrade11 = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();
                //string path = "Images/" + ds_xml.Tables[0].Rows[0].ItemArray[52].ToString();
                //if (ds.Tables[0].Rows[0]["DOCTYPE"].ToString() == "CA")
                //    obj_RCB.lblnetpayable1 = "Refund Amount";
                //else
                //    obj_RCB.lblnetpayable1 = "Net Amount";
                //obj_RCB.lbadtd1 = ds_xml.Tables[0].Rows[0].ItemArray[24].ToString();
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                if (ds.Tables[0].Rows[0]["Direct_Agency"].ToString() == "" || ds.Tables[0].Rows[0]["Direct_Agency"].ToString() == null)
                    obj_RCB.agddxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
                else
                    obj_RCB.agddxt1 = "";
                obj_RCB.lbaddress1 = ds.Tables[0].Rows[0]["address"].ToString();
                obj_RCB.txtcliname1 = ds.Tables[0].Rows[0]["Client2"].ToString();
                obj_RCB.lbcaption1 = ds.Tables[0].Rows[0]["caption"].ToString();
                obj_RCB.txtpackname1 = ds.Tables[0].Rows[0]["Package_Name"].ToString();
                obj_RCB.lblcashdisc1 = ds.Tables[0].Rows[0]["CASHDISCOUNT"].ToString();
                obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["CAT_NAME"].ToString() + "/" + ds.Tables[0].Rows[0]["SUBCAT_NAME"].ToString();
                obj_RCB.eyecatcher1 = ds.Tables[0].Rows[0]["eyecatcher"].ToString();

                //if (System.IO.File.Exists(Server.MapPath(path)))
                //{
                //    obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
                //}

                //obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));

                // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
                obj_RCB.lbbilltype1 = labelval;
                if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                else
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
                obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["BookDate"].ToString();
                if (ds.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                    obj_RCB.adcat1 = "CD";
                else
                    obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
                string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + " - " + rodate;
                if (p1 == pagecount - 1)
                {
                    obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
                    if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                    {
                        obj_RCB.txtgrossamt1 = "0.00";
                    }
                    else
                    {
                        grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                        obj_RCB.txtgrossamt1 = Convert.ToDouble(ds.Tables[1].Rows[0]["Solo_Rate"].ToString()) + Convert.ToDouble(grossamount) + ".00";
                    }

                    double translation_per = 0;
                    double insertgross = 0;

                    obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                    obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
                    obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
                    obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
                    if (ds.Tables[0].Rows[0]["boxcharge"] != null && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "" && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "0")
                        obj_RCB.lblbox1 = ds.Tables[0].Rows[0]["boxcharge"].ToString();
                    else
                        obj_RCB.lblbox1 = "0.00";

                    //obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
                    //obj_RCB.lbpune1 = "PAN NO.";
                    //obj_RCB.lbpunetxt1 = ds.Tables[0].Rows[0]["PAN_No"].ToString();

                    //obj_RCB.lbextpre1 = obj_RCB.lbextpre1 + "(" + ds.Tables[0].Rows[0]["Page_prem"].ToString() + "%" + ")";
                    //double pkg_amount = Convert.ToDouble(ds.Tables[0].Rows[0]["cardamount"].ToString());
                    //if (ds.Tables[0].Rows[0]["Page_prem"].ToString() != "" && ds.Tables[0].Rows[0]["Page_prem"].ToString() != "0")
                    //{
                    //    double prem = Convert.ToDouble(ds.Tables[0].Rows[0]["Page_prem"].ToString()) + 100;
                    //    pg_prem = pkg_amount - (pkg_amount * 100 / prem);
                    //    obj_RCB.lbextrapre1 = Convert.ToString(Convert.ToInt32(pg_prem)) + ".00";
                    //}
                    //else
                    //    obj_RCB.lbextrapre1 = "0.00";


                    if (ds.Tables[0].Rows[0]["Bullet_Charges"] != null && ds.Tables[0].Rows[0]["Bullet_Charges"].ToString() != "" && ds.Tables[0].Rows[0]["Bullet_Charges"].ToString() != "0")
                    {
                        double bulletcrg = Convert.ToDouble(ds.Tables[0].Rows[0]["Bullet_Charges"].ToString());
                        double tinsert = 0;
                        if (ds.Tables[0].Rows[0]["noinsert"].ToString() != "")
                            tinsert = Convert.ToDouble(ds.Tables[0].Rows[0]["noinsert"].ToString());
                        obj_RCB.bulletchrg1 = (bulletcrg * tinsert).ToString("F2");

                    }
                    else
                        obj_RCB.bulletchrg1 = "0.00";

                    if (ds.Tables[0].Rows[0]["bilamt"].ToString() != null || ds.Tables[0].Rows[0]["bilamt"].ToString() != "null" || ds.Tables[0].Rows[0]["bilamt"].ToString() != "")
                    {

                        double aaa122 = 0.0;
                        if (ds.Tables[0].Rows[0]["Bullet_Charges"].ToString() != "")
                        {
                            aaa122 = Convert.ToDouble(ds.Tables[0].Rows[0]["Bullet_Charges"].ToString());

                        }



                        //  netamount = Convert.ToDouble(ds.Tables[0].Rows[0]["bilamt"].ToString());
                        if (Convert.ToDouble(ds.Tables[1].Rows[0]["Size_Book"].ToString()) < 20)
                        {
                            netamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                        }
                        else
                        {
                            double ss1 = Convert.ToDouble(ds.Tables[0].Rows[0]["Extra_Rate"].ToString()) * (Convert.ToDouble(ds.Tables[1].Rows[0]["Size_Book"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Min_Word"].ToString()));

                            netamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                            // netamount = Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) + ss1 + aaa122;
                        }

                    }
if(ds.Tables[0].Rows[0]["trade_disc"].ToString()!="" && ds.Tables[0].Rows[0]["trade_disc"].ToString()!="0")
{
 netamount = netamount  - (netamount * (Convert.ToDouble(ds.Tables[0].Rows[0]["trade_disc"].ToString()) / 100));
}
                    if (ds.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || ds.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                    {
                        obj_RCB.extrarate1 = "0.00";
                        obj_RCB.txtextramt1 = "0.00";
                    }
                    else
                    {
                        if (ds.Tables[1].Rows[0]["Size_Book"].ToString() != "" && ds.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "" && ds.Tables[0].Rows[0]["EXTRA_RATE"].ToString() != "0")
                        {
                            double extramt = 0;
                            double extraword = 0;
                            double tpac = 0;
                            tpac = ds.Tables[1].Rows.Count;
                            if (ds.Tables[0].Rows[0]["MIN_WORD"].ToString() != "")
                                extraword = Convert.ToDouble(ds.Tables[0].Rows[0]["MIN_WORD"].ToString());
                            extraword = Convert.ToDouble(ds.Tables[1].Rows[0]["Size_Book"].ToString()) - extraword;
                            if (extraword > 0)
                                extramt = tpac * extraword * Convert.ToDouble(ds.Tables[0].Rows[0]["EXTRA_RATE"].ToString());

                            obj_RCB.txtextramt1 = extramt.ToString("F2");
                            obj_RCB.extrarate1 = ds.Tables[0].Rows[0]["EXTRA_RATE"].ToString() + "/Word";
                            obj_RCB.txtgrossamt1 = ds.Tables[1].Rows[0]["Solo_Rate"].ToString() + ".00";

                        }
                        else
                        {
                            obj_RCB.extrarate1 = "0.00";
                            obj_RCB.txtextramt1 = "0.00";
                        }
                    }
                    if (ds.Tables[0].Rows[0]["TRANSLATION_PREMIUM"].ToString() != "")
                    {
                        translation_per = Convert.ToDouble(ds.Tables[0].Rows[0]["TRANSLATION_PREMIUM"].ToString());
                        if (ds.Tables[0].Rows[0]["INSERT_GROSS_AMT"].ToString() != "")
                            insertgross = Convert.ToDouble(ds.Tables[1].Rows[0]["INSERT_GROSS_AMT"].ToString());
                        obj_RCB.tanscrg = (insertgross * translation_per / 100).ToString("F2");

                    }
                    else
                    {
                        obj_RCB.tanscrg = "0.00";
                    }

                    netamount = netamount + .01;
                    netamount = Math.Round(netamount);
                    obj_RCB.netpay1 = netamount.ToString();

                    NumberToEngish objwords = new NumberToEngish();
                    obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.netpay1) + "Only";
                    obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
                }

                /////////////////////////////////////////// dynamic table  ***************


                int count = ds.Tables[1].Rows.Count;
                int i;
                dytbl = "";

                dytbl += "<table width='500px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    DataSet dsb = new DataSet();
                    dsb.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td class='insertiontxtclass1'  align='left' >" + dsb.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' align='right' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[59].ToString() + "</td>";
                    //if display
                    if (ds.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || ds.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                    {
                        dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
                    }
                    else
                        dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[55].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
                    dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                    dytbl += "</tr>";
                }

                for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
                {

                    dytbl += "<tr>";
                    dytbl += "<td width=180px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";

                    if (ds.Tables[0].Rows[0]["Ad_type_code"].ToString() == "DI0" || ds.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                    {
                        dytbl += "<td class='insertiontxtclass2'  align=right >" + ds.Tables[1].Rows[i]["Gross_Rate"].ToString() + "</td>";
                        dytbl += "<td width=80px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

                        if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
                            dytbl += "<td width=55px class='insertiontxtclass2'  align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
                        else
                            dytbl += "<td width=55px  class='insertiontxtclass2'align=center>---</td>";

                    }
                    else
                    {
                        dytbl += "<td class='insertiontxtclass2'  align=right >" + ds.Tables[1].Rows[i]["Solo_Rate"].ToString() + "&nbsp;Upto" + ds.Tables[0].Rows[0]["MIN_WORD"].ToString() + "Words</td>";
                        dytbl += "<td width=70px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

                        if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
                        {
                            dytbl += "<td width=38px class='insertiontxtclass2' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
                        }

                    }


                    if (ds.Tables[1].Rows[i]["Col_Alias"].ToString() != "")
                    {
                        string col = ds.Tables[1].Rows[i]["Col_Alias"].ToString();
                        col = col.Substring(0, 1);
                        if (col == "B")
                            dytbl += "<td width=35px class='insertiontxtclass2' align=left>" + "B / W" + "</td>";
                        else
                            dytbl += "<td width=35px class='insertiontxtclass2' align=left>" + ds.Tables[1].Rows[i]["Col_Alias"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width=35px  class='insertiontxtclass2' align=center>---</td>";
                    }
                    if (ds.Tables[1].Rows[i]["Page_No"].ToString() != "" && ds.Tables[1].Rows[i]["Page_No"].ToString() != "0")  //0
                    {
                        dytbl += "<td width=35px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Page_No"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width=35px  class='insertiontxtclass2'align=center>--</td>";
                    }


                    dytbl += "</tr>";

                }  //
                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();
                Page.Controls.Add(obj_RCB);

            }
            else if (client_nam == "vigilant")
            {
                RCB_V obj_RCB = new RCB_V();
                obj_RCB = (RCB_V)Page.LoadControl("RCB_V.ascx");

                obj_RCB.lbextpre1 = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
                obj_RCB.lbtrade11 = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();
                string path = "Images/" + ds_xml.Tables[0].Rows[0].ItemArray[52].ToString();
                if (ds.Tables[0].Rows[0]["DOCTYPE"].ToString() == "CA")
                    obj_RCB.lblnetpayable1 = "Refund Amount";
                else
                    obj_RCB.lblnetpayable1 = "Net Amount";
                obj_RCB.lbadtd1 = ds_xml.Tables[0].Rows[0].ItemArray[24].ToString();
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                obj_RCB.agddxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
                obj_RCB.lbaddress1 = ds.Tables[0].Rows[0]["address"].ToString();
                obj_RCB.txtcliname1 = ds.Tables[0].Rows[0]["Client2"].ToString();
                obj_RCB.lbcaption1 = ds.Tables[0].Rows[0]["caption"].ToString();
                obj_RCB.txtpackname1 = ds.Tables[0].Rows[0]["Package_Name"].ToString();
                obj_RCB.lblcashdisc1 = ds.Tables[0].Rows[0]["CASHDISCOUNT"].ToString();
                obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["cat2"].ToString();
                if (System.IO.File.Exists(Server.MapPath(path)))
                {
                    obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
                }

                obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));

                // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
                obj_RCB.lbbilltype1 = labelval;
                if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                else
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
                obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["BookDate"].ToString();
                obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
                string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
                if (p1 == pagecount - 1)
                {
                    obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
                    if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                        obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
                    else
                        obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt"].ToString() + ".00";

                    obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
                    obj_RCB.lbpune1 = "PAN NO.";
                    obj_RCB.lbpunetxt1 = ds.Tables[0].Rows[0]["PAN_No"].ToString();

                    obj_RCB.lbextpre1 = obj_RCB.lbextpre1 + "(" + ds.Tables[0].Rows[0]["Page_prem"].ToString() + "%" + ")";
                    double pkg_amount = Convert.ToDouble(ds.Tables[0].Rows[0]["cardamount"].ToString());
                    if (ds.Tables[0].Rows[0]["Page_prem"].ToString() != "" && ds.Tables[0].Rows[0]["Page_prem"].ToString() != "0")
                    {
                        double prem = Convert.ToDouble(ds.Tables[0].Rows[0]["Page_prem"].ToString()) + 100;
                        pg_prem = pkg_amount - (pkg_amount * 100 / prem);
                        obj_RCB.lbextrapre1 = Convert.ToString(Convert.ToInt32(pg_prem)) + ".00";
                    }
                    else
                        obj_RCB.lbextrapre1 = "0.00";

                    if (obj_RCB.txtgrossamt1 != "")
                    {
                        if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                            grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                        else
                            grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString());
                    }
                    if (obj_RCB.lbextrapre1 == "0.00")
                    {
                        if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()))) + ".00";
                        else
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()))) + ".00";
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                        else
                            obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                    }
                    obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";

                    obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                    obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
                    obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
                    obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
                    if (ds.Tables[0].Rows[0]["boxcharge"] != null && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "" && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "0")
                        obj_RCB.lblbox1 = ds.Tables[0].Rows[0]["boxcharge"].ToString();
                    else
                        obj_RCB.lblbox1 = "0.00";
                    if ((obj_RCB.txtdiscal1 != "") && (obj_RCB.txtdiscal1 != "0"))
                    {
                        trade_dis = Convert.ToDouble(obj_RCB.txtdiscal1);
                    }
                    if ((obj_RCB.lblcashdisc1 != "") && (obj_RCB.lblcashdisc1 != "0"))
                    {
                        cash_dis = Convert.ToDouble(obj_RCB.lblcashdisc1);
                    }
                    if (obj_RCB.lbadtdtxt1 != "")
                    {
                        addl_dis = Convert.ToDouble(obj_RCB.lbadtdtxt1);
                    }

                    netamount = Convert.ToInt32(grossamount);
                    obj_RCB.lbadtdtxt1 = "0.00";
                    if (trade_dis != 0)
                    {
                        netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
                    }
                    if (addl_dis != 0)
                    {
                        netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
                        // obj_RCB.lbadtdtxt1 = Convert.ToString(Convert.ToInt32(grossamount * ((addl_dis) / 100))) + ".00";
                        obj_RCB.lbadtdtxt1 = Convert.ToString(grossamount * ((addl_dis) / 100));
                        obj_RCB.lbadtdtxt1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lbadtdtxt1));
                    }
                    if (cash_dis != 0)
                    {
                        obj_RCB.lblcashdisc1 = Convert.ToString(netamount * ((cash_dis) / 100));
                        netamount = netamount - (netamount * ((cash_dis) / 100));

                        obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
                    }
                    else
                    {
                        if (obj_RCB.lblcashdisc1 == "")
                            obj_RCB.lblcashdisc1 = "";
                        else
                            obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
                    }
                    ////else
                    ////{
                    ////    netamount = Convert.ToInt32(grossamount);
                    ////    obj_RCB.lbadtdtxt1 = "0.00";
                    ////}
                    //
                    if (obj_RCB.lblbox1 != "")
                    {
                        if (ds.Tables[0].Rows[0]["boxtype"].ToString() == "1")
                        {
                            netamount = netamount + Convert.ToDouble(obj_RCB.lblbox1);
                        }
                        else
                        {
                            obj_RCB.lblbox1 = Convert.ToString(netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));
                            netamount = netamount + (netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));

                            obj_RCB.lblbox1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblbox1));
                        }
                    }
                    netamount = netamount + .01;
                    netamount = Math.Round(netamount);

                    if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
                    {
                        netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
                        obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
                    }
                    if (netamount < 0)
                        netamount = netamount * -1;
                    obj_RCB.netpay1 = String.Format("{0:0.00}", netamount);

                    if (ds.Tables[0].Rows[0]["Booking_type"].ToString().ToUpper() == "2")   //2 FOR FMG
                        obj_RCB.netpay1 = "0.00";
                    obj_RCB.txtdiscal1 = Math.Round((grossamount * trade_dis / 100), 2).ToString();
                    if (obj_RCB.txtdiscal1.IndexOf(".") < 0)
                        obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + ".00";
                    else
                        if (obj_RCB.txtdiscal1.Split('.')[1].Length == 1)
                            obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + "0";

                    NumberToEngish objwords = new NumberToEngish();
                    obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.netpay1) + "Only";
                    obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
                }

                /////////////////////////////////////////// dynamic table  ***************


                int count = ds.Tables[1].Rows.Count;
                int i;
                dytbl = "";

                dytbl += "<table width='763px' align='left' cellpadding='0' cellspacing='0'>";
                {
                    obj_RCB.cioid11 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                    obj_RCB.boxno1 = ds.Tables[0].Rows[0]["Box_no"].ToString();
                    DataSet dsc = new DataSet();
                    dsc.ReadXml(Server.MapPath("XML/RCB_V.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td width='70px' class='insertiontxtclass1' ><b>" + dsc.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>";
                    dytbl += "<td width='200px' class='insertiontxtclass1' ><b>" + dsc.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></td>";
                    dytbl += "<td width='50px' class='insertiontxtclass1' align='center' ><b>" + dsc.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></td>";
                    dytbl += "<td width='35px' class='insertiontxtclass1' ><b>" + dsc.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>";
                    dytbl += "<td width='50px' class='insertiontxtclass1' ><b>" + dsc.Tables[0].Rows[0].ItemArray[4].ToString() + "</b></td>";
                    dytbl += "<td width='90px' class='insertiontxtclass1' ><b>" + dsc.Tables[0].Rows[0].ItemArray[5].ToString() + "</b></td>";
                    dytbl += "<td width='80px' class='insertiontxtclass1' ><b>" + dsc.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></td>";
                    dytbl += "<td class='insertiontxtclass14' ><b>" + dsc.Tables[0].Rows[0].ItemArray[7].ToString() + "</b></td>";
                    dytbl += "</tr>";
                }

                for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
                {

                    dytbl += "<tr>";
                    dytbl += "<td  class='display' align=center >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";
                    dytbl += "<td  class='display'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";


                    if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
                    {
                        dytbl += "<td  class='display'  align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
                    }
                    else if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
                    {
                        dytbl += "<td class='display' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='display'  align=center>---</td>";
                    }

                    if (ds.Tables[1].Rows[i]["Col_Alias"].ToString() != "")
                    {
                        dytbl += "<td  class='display' align=left>" + ds.Tables[1].Rows[i]["Col_Alias"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='display' align=center>---</td>";
                    }

                    if (ds.Tables[1].Rows[i]["Solo_Rate"].ToString() != "")
                    {
                        dytbl += "<td class='display' align=center>" + ds.Tables[1].Rows[i]["Solo_Rate"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='display' align=center>---</td>";
                    }

                    if (ds.Tables[0].Rows[0]["Prem_per"].ToString() != "")
                    {
                        dytbl += "<td class='display' align=center>" + ds.Tables[0].Rows[0]["Prem_per"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='display' align=center>---</td>";
                    }

                    if (ds.Tables[0].Rows[0]["Special_disc_per"].ToString() != "")
                    {
                        dytbl += "<td class='display' align=center>" + ds.Tables[0].Rows[0]["Special_disc_per"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td class='display' align=center>---</td>";
                    }

                    if (ds.Tables[1].Rows[i]["Gross_Rate"].ToString() != "")
                    {
                        dytbl += "<td class='display1' align=right>" + ds.Tables[1].Rows[i]["Gross_Rate"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td  class='display1' align=right>---</td>";
                    }

                    dytbl += "</tr>";

                }  //

                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();
                Page.Controls.Add(obj_RCB);
            }

            else if (client_nam == "vision")//if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "SP")
            {
                RCB_vision obj_RCB = new RCB_vision();
                obj_RCB = (RCB_vision)Page.LoadControl("RCB_vision.ascx");

                if (p1 == pagecount - 1)
                {
                    obj_RCB.chkvalue_length = "no";
                }
                else
                {
                    obj_RCB.chkvalue_length = "yes";
                }
                double netamtexcelusivevat = 0;
                double vat_per = 0;
                double vatamt = 0;

                //obj_RCB.lbextpre1 = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
                //obj_RCB.lbtrade11 = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();
                //string path = "Images/" + ds_xml.Tables[0].Rows[0].ItemArray[52].ToString();
                //if (ds.Tables[0].Rows[0]["DOCTYPE"].ToString() == "CA")
                //    obj_RCB.lblnetpayable1 = "Refund Amount";
                //else
                //    obj_RCB.lblnetpayable1 = "Net Amount";
                //obj_RCB.lbadtd1 = ds_xml.Tables[0].Rows[0].ItemArray[24].ToString();
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);
                obj_RCB.agency = ds.Tables[0].Rows[0]["Agen"].ToString();
                obj_RCB.bookingid = ds.Tables[0].Rows[0]["CIOID"].ToString();
                obj_RCB.salesperson = ds.Tables[0].Rows[0]["Client2"].ToString();
                obj_RCB.client = ds.Tables[0].Rows[0]["Client"].ToString();
                obj_RCB.rono = ds.Tables[0].Rows[0]["rono"].ToString();
                obj_RCB.package = ds.Tables[0].Rows[0]["Package_Name"].ToString();

                // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
                // obj_RCB.lbbilltype1 = labelval;
                if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                    obj_RCB.invoice_no = ds.Tables[0].Rows[0]["CIOID"].ToString();
                else
                    obj_RCB.invoice_no = ds.Tables[0].Rows[0]["recno"].ToString();

                obj_RCB.bill_date = ds.Tables[0].Rows[0]["BookDate"].ToString();
                //obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
                //string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                //obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
                if (p1 == pagecount - 1)
                {
                    // obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
                    //if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                    //    obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
                    //else
                    //    obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt"].ToString() + ".00";

                    //obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
                    //obj_RCB.lbpune1 = "PAN NO.";
                    //obj_RCB.lbpunetxt1 = ds.Tables[0].Rows[0]["PAN_No"].ToString();

                    //obj_RCB.lbextpre1 = obj_RCB.lbextpre1 + "(" + ds.Tables[0].Rows[0]["Page_prem"].ToString() + "%" + ")";
                    //double pkg_amount = Convert.ToDouble(ds.Tables[0].Rows[0]["cardamount"].ToString());
                    //if (ds.Tables[0].Rows[0]["Page_prem"].ToString() != "" && ds.Tables[0].Rows[0]["Page_prem"].ToString() != "0")
                    //{
                    //    double prem = Convert.ToDouble(ds.Tables[0].Rows[0]["Page_prem"].ToString()) + 100;
                    //    pg_prem = pkg_amount - (pkg_amount * 100 / prem);
                    //    obj_RCB.lbextrapre1 = Convert.ToString(Convert.ToInt32(pg_prem)) + ".00";
                    //}
                    //else
                    //    obj_RCB.lbextrapre1 = "0.00";

                    //if (obj_RCB.txtgrossamt1 != "")
                    //{
                    if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                        grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                    else
                        grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString());
                    //}
                    //if (obj_RCB.lbextrapre1 == "0.00")
                    //{
                    //    if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                    //        obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()))) + ".00";
                    //    else
                    //        obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()))) + ".00";
                    //}
                    //else
                    //{
                    //    if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
                    //        obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                    //    else
                    //        obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                    //}
                    //   obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";

                    //obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                    //obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
                    //obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
                    //obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
                    //if (ds.Tables[0].Rows[0]["boxcharge"] != null && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "" && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "0")
                    //    obj_RCB.lblbox1 = ds.Tables[0].Rows[0]["boxcharge"].ToString();
                    //else
                    //    obj_RCB.lblbox1 = "0.00";
                    //if ((obj_RCB.txtdiscal1 != "") && (obj_RCB.txtdiscal1 != "0"))
                    //{
                    //    trade_dis = Convert.ToDouble(obj_RCB.txtdiscal1);
                    //}
                    //if ((obj_RCB.lblcashdisc1 != "") && (obj_RCB.lblcashdisc1 != "0"))
                    //{
                    //    cash_dis = Convert.ToDouble(obj_RCB.lblcashdisc1);
                    //}
                    //if (obj_RCB.lbadtdtxt1 != "")
                    //{
                    //    addl_dis = Convert.ToDouble(obj_RCB.lbadtdtxt1);
                    //}

                    //netamount = Convert.ToInt32(grossamount);
                    ////obj_RCB.lbadtdtxt1 = "0.00";
                    //if (trade_dis != 0)
                    //{
                    //    netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
                    //}
                    //if (addl_dis != 0)
                    //{
                    //    netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
                    //    // obj_RCB.lbadtdtxt1 = Convert.ToString(Convert.ToInt32(grossamount * ((addl_dis) / 100))) + ".00";
                    //    obj_RCB.lbadtdtxt1 = Convert.ToString(grossamount * ((addl_dis) / 100));
                    //    obj_RCB.lbadtdtxt1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lbadtdtxt1));
                    //}
                    //if (cash_dis != 0)
                    //{
                    //    obj_RCB.lblcashdisc1 = Convert.ToString(netamount * ((cash_dis) / 100));
                    //    netamount = netamount - (netamount * ((cash_dis) / 100));

                    //    obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
                    //}
                    //else
                    //{
                    //    if (obj_RCB.lblcashdisc1 == "")
                    //        obj_RCB.lblcashdisc1 = "";
                    //    else
                    //        obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
                    //}
                    //////else
                    //////{
                    //////    netamount = Convert.ToInt32(grossamount);
                    //////    obj_RCB.lbadtdtxt1 = "0.00";
                    //////}
                    ////
                    //if (obj_RCB.lblbox1 != "")
                    //{
                    //    if (ds.Tables[0].Rows[0]["boxtype"].ToString() == "1")
                    //    {
                    //        netamount = netamount + Convert.ToDouble(obj_RCB.lblbox1);
                    //    }
                    //    else
                    //    {
                    //        obj_RCB.lblbox1 = Convert.ToString(netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));
                    //        netamount = netamount + (netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));

                    //        obj_RCB.lblbox1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblbox1));
                    //    }
                    //}
                    //netamount = netamount + .01;
                    //netamount = Math.Round(netamount);

                    //if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
                    //{
                    //    netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
                    //    obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
                    //}
                    //if (netamount < 0)
                    //    netamount = netamount * -1;
                    //obj_RCB.netpay1 = String.Format("{0:0.00}", netamount);

                    //if (ds.Tables[0].Rows[0]["Booking_type"].ToString().ToUpper() == "2")   //2 FOR FMG
                    //    obj_RCB.netpay1 = "0.00";
                    //obj_RCB.txtdiscal1 = Math.Round((grossamount * trade_dis / 100), 2).ToString();
                    //if (obj_RCB.txtdiscal1.IndexOf(".") < 0)
                    //    obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + ".00";
                    //else
                    //    if (obj_RCB.txtdiscal1.Split('.')[1].Length == 1)
                    //        obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + "0";

                    //NumberToEngish objwords = new NumberToEngish();
                    //obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.netpay1) + "Only";
                    //obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
                }

                /////////////////////////////////////////// dynamic table  ***************


                int count = ds.Tables[1].Rows.Count;
                int i;
                dytbl = "";
                DataSet dsb = new DataSet();
                dsb.ReadXml(Server.MapPath("XML/RCB_vision.xml"));
                dytbl += "<table width='660px' border='0' align='left' cellpadding='0' cellspacing='0' >";
                {
                    //obj_RCB.cioid11 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                    //obj_RCB.boxno1 = ds.Tables[0].Rows[0]["Box_no"].ToString();

                    dytbl += "<tr align=center >";
                    dytbl += "<td colspan='2' class='lable_textbox_bold_left' ></td>";
                    dytbl += "<td colspan='3' class='lable_textbox_bold_left' ></td>";
                    dytbl += "<td  colspan='4' class='lable_textbox_bold_left' >" + dsb.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>";

                    dytbl += "</tr>";
                    dytbl += "<tr align=center >";

                    dytbl += "<td width='90px' class='lable_textbox_bold' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>";
                    dytbl += "<td width='70px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>";
                    //dytbl += "<td width='70px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                    dytbl += "<td width='80px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                    dytbl += "<td width='100px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                    dytbl += "<td width='100px' class='lable_textbox_bold' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                    dytbl += "<td width='100px' class='lable_textbox_bold' align='left' >" + dsb.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                    dytbl += "<td width='100px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                    dytbl += "<td width='100px' class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                    dytbl += "<td width='100px' class='lable_textbox_bold' align='center' >" + dsb.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                    dytbl += "</tr>";
                    dytbl += "</tr><td colspan='10'></td><tr>";
                }

                for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
                {

                    dytbl += "<tr>";
                    if (ds.Tables[1].Rows[i]["Edition"].ToString() != "")
                    {
                        dytbl += "<td width=90px  class='lable_textbox' align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
                    }
                    else
                        dytbl += "<td width=90px  class=display align=center>-</td>";

                    if (ds.Tables[0].Rows[i]["PACKAGE_NAME"].ToString() != "")
                    {
                        dytbl += "<td width='70px'  class='lable_textbox' align=center >" + ds.Tables[0].Rows[i]["package_name"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td width='70px' class=display align=center>-</td>";


                    //if (ds.Tables[1].Rows[i]["Insert_Date"].ToString() != "")
                    //{
                    //    dytbl += "<td width='70px'   class='lable_textbox' align=right >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

                    //}


                    dytbl += "<td width='70px' class='lable_textbox' align=center>---</td>";
                    dytbl += "<td width='70px' class='lable_textbox' align=center>---</td>";
                    //if (ds4.Tables[0].Rows[i]["Ins.No."].ToString() != "")
                    //{
                    //    dytbl += "<td width='70px'  class=lable_textbox align=center >" + ds4.Tables[0].Rows[i]["Ins.No."].ToString() + "</td>";

                    //}
                    //else
                    //    dytbl += "<td width='70px' class=lable_textbox align=center>---</td>";

                    if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
                    {
                        dytbl += "<td  width='70px'  class=lable_textbox align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
                    }
                    else if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
                    {
                        dytbl += "<td width='70px'  class=lable_textbox align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width='70px'  class=lable_textbox align=center >---</td>";
                    }

                    if (ds.Tables[0].Rows[0]["UOM_NAME"].ToString() != "")
                    {
                        dytbl += "<td width='70px'  class=lable_textbox align=left >" + ds.Tables[0].Rows[0]["UOM_NAME"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td width='70px' class=lable_textbox align=center>---</td>";

                    if (ds.Tables[1].Rows[i]["Solo_Rate"].ToString() != "")
                    {
                        dytbl += "<td width='100px'  class=lable_textbox align=center >" + ds.Tables[1].Rows[i]["Solo_Rate"].ToString() + "</td>";

                    }
                    else
                        dytbl += "<td width='100px' class=lable_textbox align=center>---</td>";

                    if (ds.Tables[0].Rows[0]["Special_disc_per"].ToString() != "")
                    {
                        dytbl += "<td width='70px'   class='lable_textbox' align=center>" + ds.Tables[0].Rows[0]["Special_disc_per"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width='70px'   class='lable_textbox' align=center>---</td>";
                    }

                    if (ds.Tables[1].Rows[i]["Gross_Rate"].ToString() != "")
                    {
                        dytbl += "<td width='70px'   class='lable_textbox' align=center>" + ds.Tables[1].Rows[i]["Gross_Rate"].ToString() + "</td>";
                    }
                    else
                    {
                        dytbl += "<td width='70px'   class='lable_textbox' align=center>---</td>";
                    }
                    //dytbl += "<td width='70px'   class='lable_textbox' align=center >" + ds4.Tables[0].Rows[i]["trade_disc"].ToString() + "</td>";
                    // dytbl += "<td width='70px'   class='lable_textbox' align=right >" + ds4.Tables[0].Rows[i]["Gross_Rate"].ToString() + "</td>";


                    dytbl += "</tr>";

                }  //
                dytbl += "<tr align=center ><td height='100px;'></td></tr>";
                //if (ds.Tables[1].Rows[0]["vat_rate"].ToString() != "" && ds.Tables[1].Rows[0]["vat_rate"].ToString() != null)
                //{
                //    vat_per = Convert.ToDouble(ds.Tables[1].Rows[0]["vat_rate"].ToString());
                //}

                //netamtexcelusivevat = (grossamount * 100) / (100 + vat_per);
                //vatamt = grossamount - netamtexcelusivevat;
                //string vatamt1 = vatamt.ToString("F2");
                //dytbl += "<tr align=center >";
                //dytbl += "<td colspan='5'   align=center></td>";
                //dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + ds.Tables[1].Rows[0]["vat_rate"].ToString() + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                //dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + vatamt1 + "</td>";
                //dytbl += "</tr>";

                //string vatexcesive_amt = netamtexcelusivevat.ToString("F2");
                //dytbl += "<tr align=center >";
                //dytbl += "<td colspan='5'   align=center ></td>";
                //dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                //dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + vatexcesive_amt + "</td>";
                //dytbl += "</tr>";

                dytbl += "<tr align=center >";
                dytbl += "<td colspan='5'   align=center></td>";
                dytbl += "<td colspan='3' align='left'  class='lable_textbox_bold' >" + dsb.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>";
                dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + grossamount.ToString() + "</td>";
                dytbl += "</tr>";

                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();
                Page.Controls.Add(obj_RCB);
            }

            else if (client_nam == "lokmat")
            {
                RCB_V obj_RCB = new RCB_V();
                obj_RCB = (RCB_V)Page.LoadControl("RCB_V.ascx");

                if (p1 == pagecount - 1)
                {
                    obj_RCB.chkvalue_length = "no";
                }
                else
                {
                    obj_RCB.chkvalue_length = "yes";
                }
                obj_RCB.companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
               // obj_RCB.companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
                obj_RCB.compnameaddress = ds.Tables[0].Rows[0]["address2"].ToString();
                obj_RCB.agddxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
                obj_RCB.branchdetails = ds.Tables[0].Rows[0]["BOXADDRESS"].ToString();
                obj_RCB.lbemailtxt1 = "Email ID- "+ds.Tables[0].Rows[0]["emailid"].ToString();
                obj_RCB.panno1 = "INCOME TAX PAN No. "+ds.Tables[0].Rows[0]["pan_no"].ToString();
              //  obj_RCB.lbagencyadd1 = ds.Tables[0].Rows[0]["address"].ToString();
                obj_RCB.lblphone1 = "Phone No. " + ds.Tables[0].Rows[0]["Phone1"].ToString() + "(10 Lines)";
                obj_RCB.lblcin1 = "CIIN No.  "+ds.Tables[0].Rows[0]["CIN_NO"].ToString();
                obj_RCB.lblfax1 = "Fax No. -"+ds.Tables[0].Rows[0]["Fax"].ToString();
                obj_RCB.lbclientadd1 = ds.Tables[0].Rows[0]["Client2"].ToString();
                obj_RCB.txtremark1 = ds.Tables[0].Rows[0]["Print_remark"].ToString();
                if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                else
                    obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
               
                obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString();
                string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                obj_RCB.rodate = rodate;
                obj_RCB.runtxt1 = rodatechane(ds.Tables[0].Rows[0]["date_time"].ToString());
                obj_RCB.txtlines1 = ds.Tables[0].Rows[0]["Size_Book"].ToString();///lines
               // obj_RCB.txttype1 = ds.Tables[0].Rows[0]["adtypenew"].ToString();
               // obj_RCB.txtbaseamt1 = ds.Tables[0].Rows[0]["cardamount"].ToString();
                obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["cat2"].ToString();
                obj_RCB.txtsubcat1 = ds.Tables[0].Rows[0]["subcat2"].ToString();
                //obj_RCB.lbl_extra1 = ds.Tables[0].Rows[0]["Special_disc_per"].ToString();
                obj_RCB.txtpaidinsertion1 = ds.Tables[0].Rows[0]["PAIDINSERTION"].ToString();
                obj_RCB.txtunpaidinsertion1 = ds.Tables[0].Rows[0]["FREEINSERTION"].ToString();
                //obj_RCB.txtbulletprem1 = ds.Tables[0].Rows[0]["EYECATHER"].ToString();
                obj_RCB.txtpaymode1 = ds.Tables[0].Rows[0]["Payment_Mode_Name"].ToString();
                ct = maxlimit * p1;
                fr = maxlimit * (p1 + 1);  
                //if (p1 == pagecount - 1)
                //{
                obj_RCB.txttotalinsertion1 = ds.Tables[0].Rows[0]["no_of_insert"].ToString();
                    obj_RCB.lbl_gross1 =  ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
                    //obj_RCB.txtcapprem1 = obj_RCB.txtcapprem1 + "(" + ds.Tables[0].Rows[0]["Prem_Per"].ToString() + "%" + ")";
                    obj_RCB.lbl_trade1 = obj_RCB.lbl_trade1 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                    obj_RCB.lbl_net1 = ds.Tables[0].Rows[0]["bilamt"].ToString()+ ".00";
                   // if (ds.Tables[0].Rows[0]["BOXCHARGE"] != null && ds.Tables[0].Rows[0]["BOXCHARGE"].ToString() != "" && ds.Tables[0].Rows[0]["BOXCHARGE"].ToString() != "0")
                     //   obj_RCB.txtboxcharge1 = ds.Tables[0].Rows[0]["BOXCHARGE"].ToString();
                    //else
                      //  obj_RCB.txtboxcharge1 = "0.00";
                    NumberToEngish objwords = new NumberToEngish();
                    obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.lbl_net1) + "Only";
                    obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
                //}

                /////////////////////////////////////////// dynamic table  ***************


                int count = ds.Tables[1].Rows.Count;
                int i;
                dytbl = "";

                dytbl += "<table width='509px' align='left' cellpadding='0' cellspacing='0' border='1'>";
                {
                    //obj_RCB.cioid11 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                    //obj_RCB.boxno1 = ds.Tables[0].Rows[0]["Box_no"].ToString();
                    DataSet dsc = new DataSet();
                    dsc.ReadXml(Server.MapPath("XML/RCB_V.xml"));
                    dytbl += "<tr align=center >";
                    dytbl += "<td width='200px' class='insertionreciept' ><b>" + dsc.Tables[0].Rows[0].ItemArray[10].ToString() + "</b></td>";
                    dytbl += "<td width='70px' class='insertionreciept' ><b>" + dsc.Tables[0].Rows[0].ItemArray[11].ToString() + "</b></td>";
                    dytbl += "<td width='50px' class='insertionreciept' align='center' ><b>" + dsc.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></td>";
                   
                    dytbl += "</tr>";
                }

                for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
                {
                    if (i == ct)
                    {
                        idbook = ds.Tables[1].Rows[i]["Edition"].ToString();
                        dytbl += "<tr>";
                        //dytbl += "<td  class='display' align=center >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";
                        dytbl += "<td  class='display'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";


                        if (ds.Tables[1].Rows[i]["minInsert_Date"].ToString() != "")
                        {
                            dytbl += "<td  class='display'  align=center >" + ds.Tables[1].Rows[i]["minInsert_Date"].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td  class='display'  align=center ></td>";
                        }
                        if (ds.Tables[1].Rows[i]["maxInsert_Date"].ToString() != "")
                        {
                            dytbl += "<td  class='display'  align=center >" + ds.Tables[1].Rows[i]["maxInsert_Date"].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td  class='display'  align=center ></td>";
                        }

                        dytbl += "</tr>";
                    }
                    else
                    {
                        idbook = ds.Tables[1].Rows[i - 1]["Edition"].ToString();
                    }

                    if (ds.Tables[1].Rows[i]["Edition"].ToString() != idbook)
                    {
                        dytbl += "<tr>";
                        //dytbl += "<td  class='display' align=center >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";
                        dytbl += "<td  class='display'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";


                        if (ds.Tables[1].Rows[i]["minInsert_Date"].ToString() != "")
                        {
                            dytbl += "<td  class='display'  align=center >" + ds.Tables[1].Rows[i]["minInsert_Date"].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td  class='display'  align=center ></td>";
                        }
                        if (ds.Tables[1].Rows[i]["maxInsert_Date"].ToString() != "")
                        {
                            dytbl += "<td  class='display'  align=center >" + ds.Tables[1].Rows[i]["maxInsert_Date"].ToString() + "</td>";
                        }
                        else
                        {
                            dytbl += "<td  class='display'  align=center ></td>";
                        }

                        dytbl += "</tr>";
                    }
                   
                }  //

                dytbl += "</table>";
                obj_RCB.dynamictable1 = dytbl;
                obj_RCB.setReceiptData();
                Page.Controls.Add(obj_RCB);
            }

            //RCB_con.Controls.Add(obj_RCB);
        }

        //============For Duplicate Bill================//
        //if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "HT")
        //{
        //    // FOR DUPLICATE RECEIPT
        //    for (int p1 = 0; p1 < pagecount; p1++)
        //    {
        //        RCB obj_RCB = new RCB();
        //        obj_RCB = (RCB)Page.LoadControl("RCB.ascx");
        //        DataSet ds_xml = new DataSet();
        //        ds_xml.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
        //        obj_RCB.lbextpre1 = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
        //        obj_RCB.lbtrade11 = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();
        //        string path = "Images/" + ds_xml.Tables[0].Rows[0].ItemArray[52].ToString();
        //        if (ds.Tables[0].Rows[0]["DOCTYPE"].ToString() == "CA")
        //            obj_RCB.lblnetpayable1 = "Refund Amount";
        //        else
        //            obj_RCB.lblnetpayable1 = "Net Amount";
        //        obj_RCB.lbadtd1 = ds_xml.Tables[0].Rows[0].ItemArray[24].ToString();
        //        ct = maxlimit * p1;
        //        fr = maxlimit * (p1 + 1);
        //        obj_RCB.agddxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
        //        obj_RCB.lbaddress1 = ds.Tables[0].Rows[0]["address"].ToString();
        //        obj_RCB.txtcliname1 = ds.Tables[0].Rows[0]["Client2"].ToString();
        //        obj_RCB.lbcaption1 = ds.Tables[0].Rows[0]["caption"].ToString();
        //        obj_RCB.txtpackname1 = ds.Tables[0].Rows[0]["Package_Name"].ToString();
        //        obj_RCB.lblcashdisc1 = ds.Tables[0].Rows[0]["CASHDISCOUNT"].ToString();
        //        //obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["cat2"].ToString();
        //        if (System.IO.File.Exists(Server.MapPath(path)))
        //        {
        //            obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
        //        }
        //        obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));

        //        // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
        //        obj_RCB.lbbilltype1 = "DUPLICATE";
        //        if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
        //            obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
        //        else
        //            obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
        //        obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["BookDate"].ToString();
        //        obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
        //        string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
        //        obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
        //        if (p1 == pagecount - 1)
        //        {
        //            obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
        //            if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
        //            else
        //                obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt"].ToString() + ".00";

        //            obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
        //            obj_RCB.lbpune1 = "PAN NO.";
        //            obj_RCB.lbpunetxt1 = ds.Tables[0].Rows[0]["PAN_No"].ToString();

        //            obj_RCB.lbextpre1 = obj_RCB.lbextpre1 + "(" + ds.Tables[0].Rows[0]["Page_prem"].ToString() + "%" + ")";
        //            double pkg_amount = 0.0;
        //            if (ds.Tables[0].Rows[0]["cardamount"].ToString() != "")
        //            {
        //                pkg_amount = Convert.ToDouble(ds.Tables[0].Rows[0]["cardamount"].ToString());
        //            }
        //            if (ds.Tables[0].Rows[0]["Page_prem"].ToString() != "" && ds.Tables[0].Rows[0]["Page_prem"].ToString() != "0")
        //            {
        //                double prem = Convert.ToDouble(ds.Tables[0].Rows[0]["Page_prem"].ToString()) + 100;
        //                pg_prem = pkg_amount - (pkg_amount * 100 / prem);
        //                obj_RCB.lbextrapre1 = Convert.ToString(Convert.ToInt32(pg_prem)) + ".00";
        //            }
        //            else
        //                obj_RCB.lbextrapre1 = "0.00";

        //            if (obj_RCB.txtgrossamt1 != "")
        //            {
        //                if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                    grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
        //                else
        //                    grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString());
        //            }
        //            if (obj_RCB.lbextrapre1 == "0.00")
        //            {
        //                if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()))) + ".00";
        //                else
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()))) + ".00";
        //            }
        //            else
        //            {
        //                if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
        //                else
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
        //            }
        //            obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";

        //            obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
        //            obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
        //            obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
        //            obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
        //            if (ds.Tables[0].Rows[0]["boxcharge"] != null && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "" && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "0")
        //                obj_RCB.lblbox1 = ds.Tables[0].Rows[0]["boxcharge"].ToString();
        //            else
        //                obj_RCB.lblbox1 = "0.00";
        //            if ((obj_RCB.txtdiscal1 != "") && (obj_RCB.txtdiscal1 != "0"))
        //            {
        //                trade_dis = Convert.ToDouble(obj_RCB.txtdiscal1);
        //            }

        //            if (obj_RCB.lbadtdtxt1 != "")
        //            {
        //                addl_dis = Convert.ToDouble(obj_RCB.lbadtdtxt1);
        //            }

        //            netamount = Convert.ToInt32(grossamount);
        //            obj_RCB.lbadtdtxt1 = "0.00";
        //            if (trade_dis != 0)
        //            {
        //                netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
        //            }
        //            if (addl_dis != 0)
        //            {
        //                netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
        //                obj_RCB.lbadtdtxt1 = Convert.ToString(grossamount * ((addl_dis) / 100));
        //                obj_RCB.lbadtdtxt1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lbadtdtxt1));
        //            }
        //            ////else
        //            ////{
        //            ////    netamount = Convert.ToInt32(grossamount);
        //            ////    obj_RCB.lbadtdtxt1 = "0.00";
        //            ////}
        //            if (cash_dis != 0)
        //            {
        //                obj_RCB.lblcashdisc1 = Convert.ToString(netamount * ((cash_dis) / 100));
        //                netamount = netamount - (netamount * ((cash_dis) / 100));

        //                obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
        //            }
        //            else
        //            {
        //                if (obj_RCB.lblcashdisc1 == "")
        //                    obj_RCB.lblcashdisc1 = "";
        //                else
        //                    obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
        //            }
        //            if (obj_RCB.lblbox1 != "")
        //            {
        //                if (ds.Tables[0].Rows[0]["boxtype"].ToString() == "1")
        //                {
        //                    netamount = netamount + Convert.ToDouble(obj_RCB.lblbox1);
        //                }
        //                else
        //                {
        //                    obj_RCB.lblbox1 = Convert.ToString(netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));
        //                    netamount = netamount + (netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));

        //                    obj_RCB.lblbox1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblbox1));
        //                }
        //            }

        //            netamount = netamount + .01;
        //            netamount = Math.Round(netamount);
        //            if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
        //            {
        //                netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
        //                obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
        //            }
        //            if (netamount < 0)
        //                netamount = netamount * -1;
        //            obj_RCB.netpay1 = String.Format("{0:0.00}", netamount);
        //            if (ds.Tables[0].Rows[0]["Booking_type"].ToString().ToUpper() == "2")   //2 FOR FMG
        //                obj_RCB.netpay1 = "0.00";
        //            obj_RCB.txtdiscal1 = Math.Round((grossamount * trade_dis / 100), 2).ToString();
        //            if (obj_RCB.txtdiscal1.IndexOf(".") < 0)
        //                obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + ".00";
        //            else
        //                if (obj_RCB.txtdiscal1.Split('.')[1].Length == 1)
        //                    obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + "0";

        //            NumberToEngish objwords = new NumberToEngish();
        //            obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.netpay1) + "Only";
        //            obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
        //        }
        //        /////////////////////////////////////////// dynamic table  ***************


        //        int count = ds.Tables[1].Rows.Count;
        //        int i;
        //        dytbl = "";
        //        dytbl += "<table width='500px' align='left' cellpadding='0' cellspacing='0'>";
        //        {
        //            DataSet dsb = new DataSet();
        //            dsb.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
        //            dytbl += "<tr align=center >";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
        //            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
        //            //dytbl += "<td class='insertiontxtclasslast1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
        //            dytbl += "</tr>";
        //        }

        //        for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
        //        {
        //            //if (p1 == 0)
        //            //{
        //            //    dytbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'  class='break' valign='top'> ";
        //            //}
        //            //else
        //            //{
        //            //    dytbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='2'   valign='top' > ";
        //            //}
        //            dytbl += "<tr>";
        //            dytbl += "<td width=235px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
        //            dytbl += "<td width=60px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

        //            if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
        //            {
        //                dytbl += "<td width=38px class='insertiontxtclass2'  align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
        //            }
        //            else if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
        //            {
        //                dytbl += "<td width=38px class='insertiontxtclass2' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
        //            }
        //            else
        //            {
        //                dytbl += "<td width=38px class='insertiontxtclass2'  align=center>---</td>";
        //            }
        //            ////if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
        //            ////{
        //            ////    dytbl += "<td width=43px class='insertiontxtclass' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
        //            ////}
        //            ////else
        //            ////{
        //            ////    dytbl += "<td width=43px  class='insertiontxtclass'align=center>---</td>";
        //            ////}
        //            if (ds.Tables[1].Rows[i]["Col_Alias"].ToString() != "")
        //            {
        //                dytbl += "<td width=35px class='insertiontxtclass2' align=left>" + ds.Tables[1].Rows[i]["Col_Alias"].ToString() + "</td>";
        //            }
        //            else
        //            {
        //                dytbl += "<td width=35px  class='insertiontxtclass2'align=center>---</td>";
        //            }
        //            if (ds.Tables[1].Rows[i]["Page_No"].ToString() != "")  //0
        //            {
        //                dytbl += "<td width=51px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Page_No"].ToString() + "</td>";
        //            }
        //            else
        //            {
        //                dytbl += "<td width=51px  class='insertiontxtclass2'align=center>---</td>";
        //            }

        //            //if (ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != "" && ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != null && ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != "0")  //0
        //            //{
        //            //    dytbl += "<td width=45px class='insertiontxtclass2' align=right>" + ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() + "</td>";
        //            //}
        //            //else if (ds.Tables[1].Rows[i]["Solo_Rate"].ToString() != "")
        //            //{
        //            //    dytbl += "<td width=45px class='insertiontxtclass2' align=right>" + ds.Tables[1].Rows[i]["Solo_Rate"].ToString() + "</td>";
        //            //}
        //            //else
        //            //{
        //            //    dytbl += "<td width=45px  class='insertiontxtclass2' align=left>---</td>";

        //            //}

        //            dytbl += "</tr>";

        //        }  //

        //        dytbl += "</table>";
        //        obj_RCB.dynamictable1 = dytbl;
        //        obj_RCB.setReceiptData();
        //        Page.Controls.Add(obj_RCB);
        //        //RCB_con.Controls.Add(obj_RCB);
        //    }
        //}
       // else if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "LOKMATERP")
        //{
        //    for (int p1 = 0; p1 < pagecount; p1++)
        //    {
        //        RCB obj_RCB = new RCB();
        //        obj_RCB = (RCB)Page.LoadControl("RCB.ascx");
        //        DataSet ds_xml = new DataSet();
        //        ds_xml.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
        //        obj_RCB.lbextpre1 = ds_xml.Tables[0].Rows[0].ItemArray[21].ToString();
        //        obj_RCB.lbtrade11 = ds_xml.Tables[0].Rows[0].ItemArray[23].ToString();
        //        string path = "Images/" + ds_xml.Tables[0].Rows[0].ItemArray[52].ToString();
        //        if (ds.Tables[0].Rows[0]["DOCTYPE"].ToString() == "CA")
        //            obj_RCB.lblnetpayable1 = "Refund Amount";
        //        else
        //            obj_RCB.lblnetpayable1 = "Net Amount";
        //        obj_RCB.lbadtd1 = ds_xml.Tables[0].Rows[0].ItemArray[24].ToString();
        //        ct = maxlimit * p1;
        //        fr = maxlimit * (p1 + 1);
        //        obj_RCB.agddxt1 = ds.Tables[0].Rows[0]["Agen"].ToString();
        //        obj_RCB.lbaddress1 = ds.Tables[0].Rows[0]["address"].ToString();
        //        obj_RCB.txtcliname1 = ds.Tables[0].Rows[0]["Client2"].ToString();
        //        obj_RCB.lbcaption1 = ds.Tables[0].Rows[0]["caption"].ToString();
        //        obj_RCB.txtpackname1 = ds.Tables[0].Rows[0]["Package_Name"].ToString();
        //        obj_RCB.lblcashdisc1 = ds.Tables[0].Rows[0]["CASHDISCOUNT"].ToString();
        //        //obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["cat2"].ToString();
        //        if (System.IO.File.Exists(Server.MapPath(path)))
        //        {
        //            obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
        //        }
        //        obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));

        //        // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
        //        obj_RCB.lbbilltype1 = "DUPLICATE";
        //        if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
        //            obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
        //        else
        //            obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["recno"].ToString();
        //        obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["BookDate"].ToString();
        //        obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
        //        string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
        //        obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
        //        if (p1 == pagecount - 1)
        //        {
        //            obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
        //            if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
        //            else
        //                obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt"].ToString() + ".00";

        //            obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
        //            obj_RCB.lbpune1 = "PAN NO.";
        //            obj_RCB.lbpunetxt1 = ds.Tables[0].Rows[0]["PAN_No"].ToString();

        //            obj_RCB.lbextpre1 = obj_RCB.lbextpre1 + "(" + ds.Tables[0].Rows[0]["Page_prem"].ToString() + "%" + ")";
        //            double pkg_amount = 0.0;
        //            if (ds.Tables[0].Rows[0]["cardamount"].ToString() != "")
        //            {
        //                pkg_amount = Convert.ToDouble(ds.Tables[0].Rows[0]["cardamount"].ToString());
        //            }
        //            if (ds.Tables[0].Rows[0]["Page_prem"].ToString() != "" && ds.Tables[0].Rows[0]["Page_prem"].ToString() != "0")
        //            {
        //                double prem = Convert.ToDouble(ds.Tables[0].Rows[0]["Page_prem"].ToString()) + 100;
        //                pg_prem = pkg_amount - (pkg_amount * 100 / prem);
        //                obj_RCB.lbextrapre1 = Convert.ToString(Convert.ToInt32(pg_prem)) + ".00";
        //            }
        //            else
        //                obj_RCB.lbextrapre1 = "0.00";

        //            if (obj_RCB.txtgrossamt1 != "")
        //            {
        //                if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                    grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
        //                else
        //                    grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString());
        //            }
        //            if (obj_RCB.lbextrapre1 == "0.00")
        //            {
        //                if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()))) + ".00";
        //                else
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()))) + ".00";
        //            }
        //            else
        //            {
        //                if (ds.Tables[0].Rows[0]["gamt"].ToString() == null || ds.Tables[0].Rows[0]["gamt"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt"].ToString() == "")
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
        //                else
        //                    obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(ds.Tables[0].Rows[0]["gamt"].ToString()) - Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
        //            }
        //            obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";

        //            obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
        //            obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
        //            obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
        //            obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
        //            if (ds.Tables[0].Rows[0]["boxcharge"] != null && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "" && ds.Tables[0].Rows[0]["boxcharge"].ToString() != "0")
        //                obj_RCB.lblbox1 = ds.Tables[0].Rows[0]["boxcharge"].ToString();
        //            else
        //                obj_RCB.lblbox1 = "0.00";
        //            if ((obj_RCB.txtdiscal1 != "") && (obj_RCB.txtdiscal1 != "0"))
        //            {
        //                trade_dis = Convert.ToDouble(obj_RCB.txtdiscal1);
        //            }

        //            if (obj_RCB.lbadtdtxt1 != "")
        //            {
        //                addl_dis = Convert.ToDouble(obj_RCB.lbadtdtxt1);
        //            }

        //            netamount = Convert.ToInt32(grossamount);
        //            obj_RCB.lbadtdtxt1 = "0.00";
        //            if (trade_dis != 0)
        //            {
        //                netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
        //            }
        //            if (addl_dis != 0)
        //            {
        //                netamount = grossamount - (grossamount * ((trade_dis + addl_dis) / 100));
        //                obj_RCB.lbadtdtxt1 = Convert.ToString(grossamount * ((addl_dis) / 100));
        //                obj_RCB.lbadtdtxt1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lbadtdtxt1));
        //            }
        //            ////else
        //            ////{
        //            ////    netamount = Convert.ToInt32(grossamount);
        //            ////    obj_RCB.lbadtdtxt1 = "0.00";
        //            ////}
        //            if (cash_dis != 0)
        //            {
        //                obj_RCB.lblcashdisc1 = Convert.ToString(netamount * ((cash_dis) / 100));
        //                netamount = netamount - (netamount * ((cash_dis) / 100));

        //                obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
        //            }
        //            else
        //            {
        //                if (obj_RCB.lblcashdisc1 == "")
        //                    obj_RCB.lblcashdisc1 = "";
        //                else
        //                    obj_RCB.lblcashdisc1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblcashdisc1));
        //            }
        //            if (obj_RCB.lblbox1 != "")
        //            {
        //                if (ds.Tables[0].Rows[0]["boxtype"].ToString() == "1")
        //                {
        //                    netamount = netamount + Convert.ToDouble(obj_RCB.lblbox1);
        //                }
        //                else
        //                {
        //                    obj_RCB.lblbox1 = Convert.ToString(netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));
        //                    netamount = netamount + (netamount * ((Convert.ToDouble(obj_RCB.lblbox1)) / 100));

        //                    obj_RCB.lblbox1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lblbox1));
        //                }
        //            }

        //            netamount = netamount + .01;
        //            netamount = Math.Round(netamount);
        //            if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
        //            {
        //                netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
        //                obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
        //            }
        //            if (netamount < 0)
        //                netamount = netamount * -1;
        //            obj_RCB.netpay1 = String.Format("{0:0.00}", netamount);
        //            if (ds.Tables[0].Rows[0]["Booking_type"].ToString().ToUpper() == "2")   //2 FOR FMG
        //                obj_RCB.netpay1 = "0.00";
        //            obj_RCB.txtdiscal1 = Math.Round((grossamount * trade_dis / 100), 2).ToString();
        //            if (obj_RCB.txtdiscal1.IndexOf(".") < 0)
        //                obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + ".00";
        //            else
        //                if (obj_RCB.txtdiscal1.Split('.')[1].Length == 1)
        //                    obj_RCB.txtdiscal1 = obj_RCB.txtdiscal1 + "0";

        //            NumberToEngish objwords = new NumberToEngish();
        //            obj_RCB.lbwordinrupees1 = objwords.changeNumericToWords(obj_RCB.netpay1) + "Only";
        //            obj_RCB.lblmatter1 = cls_matter.Replace("<br>", "");
        //        }
        //        /////////////////////////////////////////// dynamic table  ***************


        //        int count = ds.Tables[1].Rows.Count;
        //        int i;
        //        dytbl = "";
        //        dytbl += "<table width='500px' align='left' cellpadding='0' cellspacing='0'>";
        //        {
        //            DataSet dsb = new DataSet();
        //            dsb.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
        //            dytbl += "<tr align=center >";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[26].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[27].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[28].ToString() + "</td>";
        //            // dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[30].ToString() + "</td>";
        //            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
        //            //dytbl += "<td class='insertiontxtclasslast1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
        //            dytbl += "</tr>";
        //        }

        //        for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
        //        {
        //            //if (p1 == 0)
        //            //{
        //            //    dytbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'  class='break' valign='top'> ";
        //            //}
        //            //else
        //            //{
        //            //    dytbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='2'   valign='top' > ";
        //            //}
        //            dytbl += "<tr>";
        //            dytbl += "<td width=235px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
        //            dytbl += "<td width=60px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

        //            if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
        //            {
        //                dytbl += "<td width=38px class='insertiontxtclass2'  align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
        //            }
        //            else if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
        //            {
        //                dytbl += "<td width=38px class='insertiontxtclass2' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
        //            }
        //            else
        //            {
        //                dytbl += "<td width=38px class='insertiontxtclass2'  align=center>---</td>";
        //            }
        //            ////if (ds.Tables[1].Rows[i]["Size_Book"].ToString() != "")
        //            ////{
        //            ////    dytbl += "<td width=43px class='insertiontxtclass' align=center>" + ds.Tables[1].Rows[i]["Size_Book"].ToString() + "</td>";
        //            ////}
        //            ////else
        //            ////{
        //            ////    dytbl += "<td width=43px  class='insertiontxtclass'align=center>---</td>";
        //            ////}
        //            if (ds.Tables[1].Rows[i]["Col_Alias"].ToString() != "")
        //            {
        //                dytbl += "<td width=35px class='insertiontxtclass2' align=left>" + ds.Tables[1].Rows[i]["Col_Alias"].ToString() + "</td>";
        //            }
        //            else
        //            {
        //                dytbl += "<td width=35px  class='insertiontxtclass2'align=center>---</td>";
        //            }
        //            if (ds.Tables[1].Rows[i]["Page_No"].ToString() != "")  //0
        //            {
        //                dytbl += "<td width=51px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Page_No"].ToString() + "</td>";
        //            }
        //            else
        //            {
        //                dytbl += "<td width=51px  class='insertiontxtclass2'align=center>---</td>";
        //            }

        //            //if (ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != "" && ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != null && ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() != "0")  //0
        //            //{
        //            //    dytbl += "<td width=45px class='insertiontxtclass2' align=right>" + ds.Tables[0].Rows[0]["Agreed_Rate"].ToString() + "</td>";
        //            //}
        //            //else if (ds.Tables[1].Rows[i]["Solo_Rate"].ToString() != "")
        //            //{
        //            //    dytbl += "<td width=45px class='insertiontxtclass2' align=right>" + ds.Tables[1].Rows[i]["Solo_Rate"].ToString() + "</td>";
        //            //}
        //            //else
        //            //{
        //            //    dytbl += "<td width=45px  class='insertiontxtclass2' align=left>---</td>";

        //            //}

        //            dytbl += "</tr>";

        //        }  //

        //        dytbl += "</table>";
        //        obj_RCB.dynamictable1 = dytbl;
        //        obj_RCB.setReceiptData();
        //        Page.Controls.Add(obj_RCB);
        //        //RCB_con.Controls.Add(obj_RCB);
        //    }
        //}
        //obj_RCB1.setReceiptData();
        //Page.Controls.Add(obj_RCB1);
        //Page.FindControl("RCB_con").Controls.Add(obj_RCB1);

    }
    public string rodatechane(string date)
    {
        if (date != "")
        {
            string[] strdate = date.Split('/');

            if (strdate[0].Length < 2)
            {
                strdate[0] = "0" + strdate[0];
            }
            if (strdate[1].Length < 2)
            {
                strdate[1] = "0" + strdate[1];
            }

            date = strdate[1] + "-" + strdate[0] + "-" + strdate[2];
            date = date.Remove(date.Length - 12, 12);
            return date;
        }
        else
        {
            return date;
        }
    }
}
