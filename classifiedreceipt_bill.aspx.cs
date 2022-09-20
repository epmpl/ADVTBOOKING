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


public partial class classifiedreceipt_bill : System.Web.UI.Page
{

    string cioid = "";
    string cls_matter = "";
    string cent = "";
    double trade_dis = 0;
    double cash_dis = 0;
    double addl_dis = 0;
    double netamount = 0;
    double grossamount = 0;
    double pg_prem = 0;
    string dytbl = "";
    DataSet ds5 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        cioid = Request.QueryString["cioid"].ToString();
        // cls_matter = Request.QueryString["clsmatter"].ToString();
        string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["center"].ToString() };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "GET_PUBCENT_LOGO";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds5 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "GET_PUBCENT_LOGO";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds5 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.classifiedreceipt obj = new NewAdbooking.classmysql.classifiedreceipt();
            ds5 = obj.selectcenterlogo(Session["compcode"].ToString(), Session["center"].ToString());

            /*string procedureName = "GET_PUBCENT_LOGO";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds5 = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
        }
        

        getMatterPreview(cioid);
        onscreen(cioid, Session["dateformat"].ToString(), "ORIGINAL");
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
        string mailmatterbody = "";
        string mailmatterbodym = "";

        DataSet dr = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt objmatter = new NewAdbooking.Classes.classifiedreceipt();
            dr = objmatter.clsreceiptmatter(booking_id);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.classifiedreceipt objmatter = new NewAdbooking.classesoracle.classifiedreceipt();
                dr = objmatter.clsreceiptmatter(booking_id);
            }
            else
            {
                NewAdbooking.classmysql.classifiedreceipt obj = new NewAdbooking.classmysql.classifiedreceipt();
                dr = obj.clsreceiptmatter(Session["compcode"].ToString(), booking_id);

                //string[] parameterValueArray = new string[] { booking_id };
                //string procedureName = "websp_clsmatter_websp_clsmatter_p_multi";
                //NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                //dr = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        if (dr.Tables[0].Rows.Count > 0)
        {
            cls_matter = dr.Tables[0].Rows[0]["RTFformat"].ToString();
            if (cls_matter != "")
            {
                string[] arr = cls_matter.Split("~".ToCharArray());

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].ToString() != " " || arr[i].ToString() != "")
                    {
                        if (mailmatterbodym == "")
                        {
                            mailmatterbodym = arr[i].ToString();
                        }
                        else
                        {
                            mailmatterbodym = mailmatterbodym + "<br/>" + arr[i].ToString();
                        }
                    }
                }
            }
            cls_matter = mailmatterbodym;
        }
        else
        {
            cls_matter = "";
        }
    }
    private void onscreen(string cioid, string dateformat, string labelval)
    {
        RCB obj_RCB2 = new RCB();
        obj_RCB2 = (RCB)Page.LoadControl("RCB.ascx");
        string client_nam = ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.classifiedreceipt obj = new NewAdbooking.classesoracle.classifiedreceipt();
            if (client_nam == "RP")
                ds = obj.selectreceipt_rp(Session["compcode"].ToString(),cioid, dateformat);
            else
                ds = obj.selectreceipt(cioid, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.classifiedreceipt obj = new NewAdbooking.Classes.classifiedreceipt();
            ds = obj.selectreceipt(cioid, dateformat);
        }
        else
        {
            /*string[] parameterValueArray = new string[] { cioid, dateformat };
            string procedureName = "websp_receiptnew2";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
            NewAdbooking.classmysql.classifiedreceipt obj = new NewAdbooking.classmysql.classifiedreceipt();
            ds = obj.selectreceipt(cioid, dateformat);
        }
        int maxlimit = 23;
        int ct = 0;
        int fr = maxlimit;
        float ht=40;
        double disc = 0;
        double sp_disc_per = 0;
        int rcount = ds.Tables[1].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
       
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (Session["center"].ToString() == "CHD" || Session["center"].ToString() == "AMR" || Session["center"].ToString() == "NBN" || Session["center"].ToString() == "NMN" || Session["center"].ToString() == "NRN")
        {
            cent = "NAGPUR";

        }
        else
        {
            cent = "MUMBAI";
        }
        for (int p1 = 0; p1 < pagecount; p1++)
        {
           
            DataSet ds_xml = new DataSet();
            ds_xml.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
            

                if (p1 == 0)
                {
                   // if (ds.Tables[0].Rows[0]["noinsert"].ToString() == ds.Tables[1].Rows[0]["days"].ToString())
            //{
                    client_nam = "SP";
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
                        obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["SUBTCAT"].ToString();
                        obj_RCB.subtfcat = ds.Tables[0].Rows[0]["SUBTfCAT"].ToString();
                        obj_RCB.payname = ds.Tables[0].Rows[0]["Payment_Mode_Name"].ToString();
                        if (ds.Tables[0].Rows[0]["CHK_NO"].ToString() != "")
                        {
                            obj_RCB.chkno = ds.Tables[0].Rows[0]["CHK_NO"].ToString();
                            obj_RCB.chkdt = ds.Tables[0].Rows[0]["CHK_DATE"].ToString();
                            obj_RCB.banknm = ds.Tables[0].Rows[0]["CHK_BANK_NAME"].ToString();
                        }
                        else
                        {
                            obj_RCB.chkno = "";
                            obj_RCB.chkdt = "";
                            obj_RCB.banknm = "";
                        }
                        if (System.IO.File.Exists(Server.MapPath(path)))
                        {
                            obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
                        }

                        //obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));
                        obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()));
                        if (ds5.Tables[0].Rows[0]["logo_file_path"].ToString() == "")
                        {
                            obj_RCB.lblimg1 = "Images/" + ConfigurationManager.AppSettings["logoimg"].ToString();

                        }
                        else
                        {
                            obj_RCB.lblimg1 = "<img  src='Images/" + ds5.Tables[0].Rows[0]["logo_file_path"].ToString() + "'  width='100' height='50'>";
                        }
                        // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
                        obj_RCB.lbbilltype1 = labelval;
                        if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                            obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                        else
                            obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                        obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["date_time"].ToString();
                        obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
                        obj_RCB.adsubcat = ds.Tables[0].Rows[0]["subcat"].ToString();
                        string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                        obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
                        //if (p1 == pagecount - 1)
                        //{

                        if (ds.Tables[0].Rows[0]["special_disc_per"].ToString() != "")
                        {
                            //disc = billamt_latest / (1 - sp_disc_per / 100);
                            if (Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) == 0.0)
                            {
                                disc = 0.0;
                            }
                            else
                            {

                                sp_disc_per = Convert.ToDouble(ds.Tables[0].Rows[0]["special_disc_per"].ToString());
                                disc = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) / (1 - sp_disc_per / 100);
                            }
                        }
                        else
                        {
                            disc = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                        }
                            obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
                            if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                obj_RCB.txtgrossamt1 = string.Format("{0:0.00}",disc);//disc.ToString();
                            else
                                obj_RCB.txtgrossamt1 = string.Format("{0:0.00}", disc); //disc.ToString();

                            //obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); 
                            //All disputes are subject to AURANGABAD Jurisdiction only.
                            obj_RCB.lbemailtxt1 = "All disputes are subject to" + "&nbsp;" + "&nbsp;" + cent/*ds.Tables[0].Rows[0]["pub"].ToString()*/ + "&nbsp;" + "&nbsp;" + "Jurisdiction only.";
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
                                if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                    grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                                else
                                    grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                            }
                            if (obj_RCB.lbextrapre1 == "0.00")
                            {
                                if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                    obj_RCB.txtgrossamt1 = string.Format("{0:0.00}", disc);//Convert.ToString(disc) ;
                                else
                                    obj_RCB.txtgrossamt1 = string.Format("{0:0.00}", disc); //Convert.ToString(disc);
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                    obj_RCB.txtgrossamt1 = string.Format("{0:0.00}", Convert.ToInt32(disc - Convert.ToDouble(obj_RCB.lbextrapre1)));//Convert.ToString(Convert.ToInt32(disc - Convert.ToDouble(obj_RCB.lbextrapre1))) ;
                                else
                                    obj_RCB.txtgrossamt1 = string.Format("{0:0.00}", Convert.ToInt32(disc - Convert.ToDouble(obj_RCB.lbextrapre1))); ;// Convert.ToString(Convert.ToInt32(disc - Convert.ToDouble(obj_RCB.lbextrapre1)));
                            }
                            obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";

                            if (ds.Tables[0].Rows[0]["CHKTRADEDISC"].ToString() == "1")
                            {
                                obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                                obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
                            }
                            else
                            {
                                obj_RCB.lbtrade11 = "0.00";
                                obj_RCB.txtdiscal1 = "0.00";
                            }
                            obj_RCB.lblspldis = "Sp. Discount(" + ds.Tables[0].Rows[0]["special_disc_per"].ToString() + "%" + ")";
                            sp_disc_per = disc * sp_disc_per / 100.0;
                            obj_RCB.lblspldis1 = string.Format("{0:0.00}",sp_disc_per);//.ToString();
                            obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
                            obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
                           // obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
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
                                //netamount = netamount - (netamount * ((cash_dis) / 100));

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

                            //if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
                            //{
                            //    netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
                            //    obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
                            //}
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
                            double eyecatamt = 0;
                            if (ds.Tables[0].Rows[0]["eyecatheramt"].ToString() != "")
                            {
                                if (ds.Tables[0].Rows[0]["Scheme_Code"].ToString() == "3+1")
                                {
                                    for (int j = 0; j < ds.Tables[0].Rows.Count - 1; j++)
                                    {
                                        eyecatamt = eyecatamt + Convert.ToDouble(ds.Tables[0].Rows[j]["eyecatheramt"].ToString());

                                    }
                                }
                                else
                                {

                                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                    {
                                        eyecatamt = eyecatamt + Convert.ToDouble(ds.Tables[0].Rows[j]["eyecatheramt"].ToString());

                                    }
                                }
                            }
                    
                            obj_RCB.eyecatcher = eyecatamt.ToString();

                        //}

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
                            dytbl += "<td class='insertiontxtclass1' >" + "Colour" + "</td>";
                            dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                            //dytbl += "<td class='insertiontxtclasslast1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
                            dytbl += "</tr>";
                        }
                        int countsert = ds.Tables[1].Rows.Count;
                        for (i = ct; i < ds.Tables[1].Rows.Count && i < fr; i++)
                        {
                            if (ds.Tables[0].Rows[0]["noinsert"].ToString() == "ttttt")//ds.Tables[1].Rows[0]["days"].ToString())
                            {

                                if (i == 0)
                                {
                                    dytbl += "<tr>";
                                    dytbl += "<td width=200px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
                                    dytbl += "<td width=160px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "-" + ds.Tables[1].Rows[countsert - 1]["Insert_Date"].ToString() + "</td>";

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


                                    dytbl += "</tr>";
                                                             break;
                                }
                            }
                            else
                            {
                                dytbl += "<tr>";
                                dytbl += "<td width=200px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
                                dytbl += "<td width=160px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

                                if (ds.Tables[1].Rows[i]["Height"].ToString() != "" &&  ds.Tables[1].Rows[i]["Height"].ToString() != "0")
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


                                dytbl += "</tr>";
                            }

                        }  //
                        dytbl += "</table>";
                        obj_RCB.dynamictable1 = dytbl;
                        obj_RCB.setReceiptData();
                        Page.Controls.Add(obj_RCB);

                    }
                //    break;
                //}

                    else
                    {
                        client_nam = "SP";
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
                            obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["SUBTCAT"].ToString();
                            obj_RCB.subtfcat = ds.Tables[0].Rows[0]["SUBTfCAT"].ToString();
                            obj_RCB.payname = ds.Tables[0].Rows[0]["Payment_Mode_Name"].ToString();
                            if (ds.Tables[0].Rows[0]["CHK_NO"].ToString() != "")
                            {
                                obj_RCB.chkno = ds.Tables[0].Rows[0]["CHK_NO"].ToString();
                                obj_RCB.chkdt = ds.Tables[0].Rows[0]["CHK_DATE"].ToString();
                                obj_RCB.banknm = ds.Tables[0].Rows[0]["CHK_BANK_NAME"].ToString();
                            }
                            else
                            {
                                obj_RCB.chkno = "";
                                obj_RCB.chkdt = "";
                                obj_RCB.banknm = "";
                            }
                            if (System.IO.File.Exists(Server.MapPath(path)))
                            {
                                obj_RCB.divimg1 = "<img src='" + path + "' height='" + ht + "'>";
                            }

                            //obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Special_discount"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["Space_discount"].ToString()));
                            obj_RCB.lbpakgrate1 = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["pkgrate"].ToString()));
                            if (ds5.Tables[0].Rows[0]["logo_file_path"].ToString() == "")
                            {
                                obj_RCB.lblimg1 = "Images/" + ConfigurationManager.AppSettings["logoimg"].ToString();

                            }
                            else
                            {
                                obj_RCB.lblimg1 = "<img  src='Images/" + ds5.Tables[0].Rows[0]["logo_file_path"].ToString() + "'  width='100' height='50'>";
                            }
                            // lbrcbtxt.Text = Request.QueryString["cioid"].ToString();       
                            obj_RCB.lbbilltype1 = labelval;
                            if (ds.Tables[0].Rows[0]["recno"].ToString() == "")
                                obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                            else
                                obj_RCB.lbrcbtxt1 = ds.Tables[0].Rows[0]["CIOID"].ToString();
                            obj_RCB.runtxt1 = ds.Tables[0].Rows[0]["date_time"].ToString();
                            obj_RCB.adcat1 = ds.Tables[0].Rows[0]["adtype"].ToString();
                            obj_RCB.adsubcat = ds.Tables[0].Rows[0]["subcat"].ToString();
                            string rodate = ds.Tables[0].Rows[0]["rodate"].ToString();
                            obj_RCB.lbronodate1 = ds.Tables[0].Rows[0]["rono"].ToString() + "/" + rodate;
                            if (p1 == 0)//if (p1 == pagecount - 1)
                            {
                                obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();

                                if (ds.Tables[0].Rows[0]["special_disc_per"].ToString() != "")
                                {
                                    //disc = billamt_latest / (1 - sp_disc_per / 100);
                                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) == 0.0)
                                    {
                                        disc = 0.0;
                                    }
                                    else
                                    {
                                        sp_disc_per = Convert.ToDouble(ds.Tables[0].Rows[0]["special_disc_per"].ToString());
                                        disc = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) / (1 - sp_disc_per / 100);
                                    }
                                }
                                else
                                {
                                    disc = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                                }
                                obj_RCB.insertiontxt1 = ds.Tables[0].Rows[0]["noinsert"].ToString();
                                if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                    obj_RCB.txtgrossamt1 = disc.ToString();
                                else
                                    obj_RCB.txtgrossamt1 = disc.ToString();

                                //obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); 
                                //All disputes are subject to AURANGABAD Jurisdiction only.
                                obj_RCB.lbemailtxt1 = "All disputes are subject to" + "&nbsp;" + "&nbsp;" + "NAGPUR"/*ds.Tables[0].Rows[0]["pub"].ToString()*/ + "&nbsp;" + "&nbsp;" + "Jurisdiction only.";
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
                                    if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                        grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                                    else
                                        grossamount = Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                                }
                                if (obj_RCB.lbextrapre1 == "0.00")
                                {
                                    if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                        obj_RCB.txtgrossamt1 = Convert.ToString(disc);
                                    else
                                        obj_RCB.txtgrossamt1 = Convert.ToString(disc);
                                }
                                else
                                {
                                    if (ds.Tables[0].Rows[0]["gamt1"].ToString() == null || ds.Tables[0].Rows[0]["gamt1"].ToString() == "null" || ds.Tables[0].Rows[0]["gamt1"].ToString() == "")
                                        obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(disc - Convert.ToDouble(obj_RCB.lbextrapre1))) ;
                                    else
                                        obj_RCB.txtgrossamt1 = Convert.ToString(Convert.ToInt32(disc - Convert.ToDouble(obj_RCB.lbextrapre1))) ;
                                }
                                obj_RCB.txtagr1 = Convert.ToString(Convert.ToInt32(Convert.ToDouble(obj_RCB.txtgrossamt1) + Convert.ToDouble(obj_RCB.lbextrapre1))) + ".00";
                                if (ds.Tables[0].Rows[0]["CHKTRADEDISC"].ToString() == "1")
                                {
                                    obj_RCB.lbtrade11 = obj_RCB.lbtrade11 + "(" + ds.Tables[0].Rows[0]["trade_disc"].ToString() + "%" + ")";
                                    obj_RCB.txtdiscal1 = ds.Tables[0].Rows[0]["trade_disc"].ToString();
                                }
                                else
                                {
                                    obj_RCB.lbtrade11 = "0.00";
                                    obj_RCB.txtdiscal1 = "0.00";
                                }
                                obj_RCB.lblspldis = "Sp. Discount(" + ds.Tables[0].Rows[0]["special_disc_per"].ToString() + "%" + ")";
                                sp_disc_per=disc*sp_disc_per/100.0;
                                obj_RCB.lblspldis1 = string.Format("{0:0.00}", sp_disc_per); //sp_disc_per.ToString();
                                obj_RCB.lbadtd1 = obj_RCB.lbadtd1 + "(" + ds.Tables[0].Rows[0]["adl_agency_comm"].ToString() + "%" + ")";
                                obj_RCB.lbadtdtxt1 = ds.Tables[0].Rows[0]["adl_agency_comm"].ToString();
                                
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
                                    //netamount = netamount - (netamount * ((cash_dis) / 100));

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

                                //if (ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "" && ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString() != "null")
                                //{
                                //    netamount = netamount - Convert.ToDouble(ds.Tables[0].Rows[0]["PREVBILLAMT"]);
                                //    obj_RCB.lblprevbill1 = ds.Tables[0].Rows[0]["PREVBILLAMT"].ToString();
                                //}
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
                                double eyecatamt = 0;
                                if (ds.Tables[0].Rows[0]["eyecatheramt"].ToString() != "")
                                {
                                    if (ds.Tables[0].Rows[0]["Scheme_Code"].ToString() == "3+1")
                                    {
                                        for (int j = 0; j < ds.Tables[0].Rows.Count - 1; j++)
                                        {
                                            eyecatamt = eyecatamt + Convert.ToDouble(ds.Tables[0].Rows[j]["eyecatheramt"].ToString());

                                        }
                                    }
                                    else
                                    {

                                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                        {
                                            eyecatamt = eyecatamt + Convert.ToDouble(ds.Tables[0].Rows[j]["eyecatheramt"].ToString());

                                        }
                                    }
                                }
                                obj_RCB.eyecatcher = eyecatamt.ToString(); //ds.Tables[0].Rows[0]["eyecatheramt"].ToString();
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
                                dytbl += "<td class='insertiontxtclass1' >" + "Colour" + "</td>";
                                dytbl += "<td class='insertiontxtclass1' >" + dsb.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>";
                                //dytbl += "<td class='insertiontxtclasslast1' >" + dsb.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>";
                                dytbl += "</tr>";
                            }
                            int countsert = ds.Tables[1].Rows.Count;
                            for (i = ct; i < ds.Tables[1].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[0]["noinsert"].ToString() == ds.Tables[1].Rows[0]["days"].ToString())
                                {

                                    if (i == 0)
                                    {
                                        dytbl += "<tr>";
                                        dytbl += "<td width=200px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
                                        dytbl += "<td width=160px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "-" + ds.Tables[1].Rows[countsert - 1]["Insert_Date"].ToString() + "</td>";

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


                                        dytbl += "</tr>";
                                        break;
                                    }
                                }
                                else
                                {
                                    dytbl += "<tr>";
                                    dytbl += "<td width=200px class='insertiontxtclass2'  align=left >" + ds.Tables[1].Rows[i]["Edition"].ToString() + "</td>";
                                    dytbl += "<td width=160px class='insertiontxtclass2' align=left >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

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


                                    dytbl += "</tr>";
                                }

                            }  //
                            dytbl += "</table>";
                            obj_RCB.dynamictable1 = dytbl;
                            obj_RCB.setReceiptData();
                            Page.Controls.Add(obj_RCB);
                        }
                    }
                
    }
            else if (client_nam == "RP")
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
                obj_RCB.lblcatdata1 = ds.Tables[0].Rows[0]["SUBTCAT"].ToString();// +"/" + ds.Tables[0].Rows[0]["SUBCAT_NAME"].ToString();
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
                        obj_RCB.txtgrossamt1 =  "0.00";
                    }
                    else
                    {
                        grossamount=Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString());
                        obj_RCB.txtgrossamt1 = ds.Tables[0].Rows[0]["gamt1"].ToString() + ".00";
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
                        netamount = Convert.ToDouble(ds.Tables[0].Rows[0]["bilamt"].ToString());
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
                                extraword =Convert.ToDouble(ds.Tables[0].Rows[0]["MIN_WORD"].ToString());
                            extraword = Convert.ToDouble(ds.Tables[1].Rows[0]["Size_Book"].ToString()) - extraword;
                            if(extraword > 0)
                            extramt = tpac* extraword * Convert.ToDouble(ds.Tables[0].Rows[0]["EXTRA_RATE"].ToString());

                            obj_RCB.txtextramt1 = extramt.ToString("F2");
                            obj_RCB.extrarate1 = ds.Tables[0].Rows[0]["EXTRA_RATE"].ToString() + "/Word";
                            obj_RCB.txtgrossamt1 = (Convert.ToDouble(ds.Tables[0].Rows[0]["gamt1"].ToString()) - extramt).ToString("F2");

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
                    if(ds.Tables[0].Rows[0]["Ad_type_code"].ToString()=="DI0" || ds.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
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
                   
                    if(ds.Tables[0].Rows[0]["Ad_type_code"].ToString()=="DI0" || ds.Tables[0].Rows[0]["Uom_code"].ToString() == "CL0")
                    {
                        dytbl += "<td class='insertiontxtclass2'  align=right >" + ds.Tables[1].Rows[i]["Gross_Rate"].ToString() + "</td>";
                        dytbl += "<td width=80px class='insertiontxtclass2' align=center >" + ds.Tables[1].Rows[i]["Insert_Date"].ToString() + "</td>";

                        if (ds.Tables[1].Rows[i]["Height"].ToString() != "")
                            dytbl += "<td width=55px class='insertiontxtclass2'  align=center >" + ds.Tables[1].Rows[i]["Height"].ToString() + "x" + ds.Tables[1].Rows[i]["Width"].ToString() + "</td>";
                        else
                            dytbl += "<td width=55px  class='insertiontxtclass2'align=center>---</td>";

                    }
                    else{
                        dytbl += "<td class='insertiontxtclass2'  align=right >" + ds.Tables[1].Rows[i]["Gross_Rate"].ToString() + "&nbsp;Upto" + ds.Tables[0].Rows[0]["MIN_WORD"].ToString() + "Words</td>";
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
                    //All disputes are subject to AURANGABAD Jurisdiction only.
                    obj_RCB.lbemailtxt1 = "All disputes are subject to" + "&nbsp;" + ds.Tables[0].Rows[0]["pub"].ToString() + "&nbsp;" + "Jurisdiction only.";
                    //obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
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
              double netamtexcelusivevat=0;
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
                obj_RCB.client = ds.Tables[0].Rows[0]["cust_code"].ToString();
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
                    if (ds.Tables[1].Rows[i]["Edition_code"].ToString() != "")
                    {
                        dytbl += "<td width=90px  class='lable_textbox' align=left >" + ds.Tables[1].Rows[i]["Edition_code"].ToString() + "</td>";
                    }
                    else
                        dytbl += "<td width=90px  class=display align=center>-</td>";

                    if (ds.Tables[1].Rows[i]["package_name"].ToString() != "")
                    {
                        dytbl += "<td width='70px'  class='lable_textbox' align=center >" + ds.Tables[1].Rows[i]["package_name"].ToString() + "</td>";

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

                    if (ds.Tables[0].Rows[0]["uom_name"].ToString() != "")
                    {
                        dytbl += "<td width='70px'  class=lable_textbox align=left >" + ds.Tables[0].Rows[0]["uom_name"].ToString() + "</td>";

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
                if (ds.Tables[1].Rows[0]["vat_rate"].ToString() != "" && ds.Tables[1].Rows[0]["vat_rate"].ToString() != null)
                {
                    vat_per = Convert.ToDouble(ds.Tables[1].Rows[0]["vat_rate"].ToString());
                }

                netamtexcelusivevat=(grossamount * 100) / (100 + vat_per);
                vatamt = grossamount - netamtexcelusivevat;
                string vatamt1 = vatamt.ToString("F2");
                dytbl += "<tr align=center >";
                dytbl += "<td colspan='5'   align=center></td>";
                dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + ds.Tables[1].Rows[0]["vat_rate"].ToString() + dsb.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>";
                dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + vatamt1 + "</td>";
                dytbl += "</tr>";

                string vatexcesive_amt = netamtexcelusivevat.ToString("F2");
                dytbl += "<tr align=center >";
                dytbl += "<td colspan='5'   align=center ></td>";
                dytbl += "<td colspan='3' align='left'  class='lable_textbox' >" + dsb.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>";
                dytbl += "<td colspan='2'  class=lable_textbox align='right'>" + vatexcesive_amt + "</td>";
                dytbl += "</tr>";

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
           

           
            //RCB_con.Controls.Add(obj_RCB);
        }
//============For Duplicate Bill================//
        if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "SP")
        {
            // FOR DUPLICATE RECEIPT
            for (int p1 = 0; p1 < pagecount; p1++)
            {
                RCB obj_RCB = new RCB();
                obj_RCB = (RCB)Page.LoadControl("RCB.ascx");
                DataSet ds_xml = new DataSet();
                ds_xml.ReadXml(Server.MapPath("XML/classifiedreceipt_bill.xml"));
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
                obj_RCB.lbbilltype1 = "DUPLICATE";
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

                    //obj_RCB.lbemailtxt1 = ds_xml.Tables[0].Rows[0].ItemArray[53].ToString(); ;
                   // All disputes are subject to AURANGABAD Jurisdiction only.
                    obj_RCB.lbemailtxt1 = "All disputes are subject to" + "&nbsp;" + ds.Tables[0].Rows[0]["pub"].ToString() + "&nbsp;" + "Jurisdiction only.";
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
                        obj_RCB.lbadtdtxt1 = Convert.ToString(grossamount * ((addl_dis) / 100));
                        obj_RCB.lbadtdtxt1 = String.Format("{0:0.00}", Convert.ToDouble(obj_RCB.lbadtdtxt1));
                    }
                    ////else
                    ////{
                    ////    netamount = Convert.ToInt32(grossamount);
                    ////    obj_RCB.lbadtdtxt1 = "0.00";
                    ////}
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
                        dytbl += "<td width=35px  class='insertiontxtclass2'align=center>---</td>";
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
                //RCB_con.Controls.Add(obj_RCB);
            }
        }
        //obj_RCB1.setReceiptData();
        //Page.Controls.Add(obj_RCB1);
        //Page.FindControl("RCB_con").Controls.Add(obj_RCB1);
    }
}