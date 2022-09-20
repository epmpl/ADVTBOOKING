using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class dealprovision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(dealprovision));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencenter.Value = Session["revenue"].ToString();
        hiddencentername.Value = Session["centername"].ToString();
        hiddencentercode.Value = Session["center"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/dealprovision.xml"));
        lbdeal.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbagency.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbclient.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbexecutive.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lbfromdate.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lbtodate.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        bntsub.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btnCancel.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        btnExit.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lbfilter.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        lbPublicationCenter.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
        lbinvoice.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
        btnsave.Text = objDataSet.Tables[0].Rows[0].ItemArray[12].ToString();
        lbladtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[13].ToString();
        lblum.Text = objDataSet.Tables[0].Rows[0].ItemArray[14].ToString();
        if (!Page.IsPostBack)
        {
            publicationbind();
            txtdeal.Attributes.Add("onkeydown", "javascript:return dealf2(event);");
            lstdeal.Attributes.Add("onclick", "javascript:return dealclick(event);");
            lstdeal.Attributes.Add("onkeydown", "javascript:return dealclick(event);");
            txtagency.Attributes.Add("onkeydown", "javascript:return agencybindf2(event);");
            lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
            txtclient.Attributes.Add("onkeydown", "javascript:return clientf2(event);");
            lstclient.Attributes.Add("onclick", "javascript:return onclickclient(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return onclickclient(event);");
            bntsub.Attributes.Add("onclick", "javascript:return submi();");
            btnCancel.Attributes.Add("onclick", "javascript:return clear1();");
            btnExit.Attributes.Add("onclick", "javascript:return exit();");
            btnsave.Attributes.Add("onclick", "javascript:return saveclick();");
            txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            drpadtype.Attributes.Add("OnChange", "javascript:return binduomname();");
            //txtexecutive.Attributes.Add("onkeydown", "javascript:return executivef2(event);");
            //lstexe.Attributes.Add("onclick", "javascript:return onclickexe(event);");
            //lstexe.Attributes.Add("onkeydown", "javascript:return onclickexe(event);");
            adtypedata(Session["compcode"].ToString());
        }
        DataSet dprv = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster prev = new NewAdbooking.Classes.BookingMaster();

            dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "CL0");


        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster prev = new NewAdbooking.classesoracle.BookingMaster();

                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "CL0");


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();

                dprv = prev.prevbooking(Session["compcode"].ToString(), Session["userid"].ToString(), "CL0");


            }
        if (dprv.Tables[2].Rows.Count > 0)
        {
            hiddencopybooking.Value = dprv.Tables[2].Rows[0].ItemArray[5].ToString();
            hiddencutofftime.Value = dprv.Tables[2].Rows[0].ItemArray[6].ToString();
            hiddensepcashier.Value = dprv.Tables[2].Rows[0].ItemArray[7].ToString();
            if (dprv.Tables[2].Rows[0].ItemArray[8].ToString() != "")
                hiddenmaxdays.Value = dprv.Tables[2].Rows[0].ItemArray[8].ToString();
            else
                hiddenmaxdays.Value = "0";
            hidspldisedit.Value = dprv.Tables[2].Rows[0].ItemArray[9].ToString();
            hidshareman.Value = dprv.Tables[2].Rows[0].ItemArray[10].ToString();
            hidmultisel.Value = dprv.Tables[2].Rows[0].ItemArray[11].ToString();
            hidschememin.Value = dprv.Tables[2].Rows[0].ItemArray[12].ToString();
            hidspltd.Value = dprv.Tables[2].Rows[0].ItemArray[13].ToString();
            hiddenrateauditpreferrence.Value = dprv.Tables[2].Rows[0].ItemArray[14].ToString();
            hiddeneiitagcomm.Value = dprv.Tables[2].Rows[0].ItemArray[17].ToString();
            hiddencancelcharge.Value = dprv.Tables[2].Rows[0].ItemArray[18].ToString();
            allowprem_card_disc_rate.Value = dprv.Tables[2].Rows[0]["ALLOWPREM_CARD_DISC_RATE"].ToString();
            agncomm_seq_com.Value = dprv.Tables[2].Rows[0].ItemArray[1].ToString();
                     
        }
    }





    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 bind = new NewAdbooking.Classes.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = bind.adtypbind(compcode);
        }



        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }

    }



    [Ajax.AjaxMethod]
    public DataSet binddealno(string compcode, string dealno, string mod)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            ds = insert.binddealNo(compcode, dealno, mod);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.dealaudi insert = new NewAdbooking.classesoracle.dealaudi();
            ds = insert.binddealNo(compcode, dealno, mod);
        }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
        }
        else
        {
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            //}
            //else
            //{
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
            //}
        }
        return ds;



    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (Session["FILTER"].ToString() == "D")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, Session["revenue"].ToString());
            }
            else
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, "0");
            }
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string addclientname(string page, string datetime, string value)
    {
        DataSet dag = new DataSet();
        string nameadd = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master getagenameaddress = new NewAdbooking.Classes.Master();

            dag = getagenameaddress.getClientNameadd(page, Session["compcode"].ToString(), value, "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master getagenameaddress = new NewAdbooking.classesoracle.Master();

            dag = getagenameaddress.getClientNameadd(page, Session["compcode"].ToString(), value, "");
        }
        else
        {
            //NewAdbooking.classmysql.BookingMaster getagenameaddress = new NewAdbooking.classmysql.BookingMaster();

            //dag = getagenameaddress.getClientNameadd(name, Session["compcode"].ToString(), value, date, Session["dateformat"].ToString());

        }

        if (dag.Tables[0].Rows.Count > 0)
        {
            string clientname = dag.Tables[0].Rows[0].ItemArray[1].ToString();
            string code = dag.Tables[0].Rows[0].ItemArray[0].ToString();
            string address = dag.Tables[0].Rows[0].ItemArray[2].ToString();
            if (address == "null")
                address = "";
            //string agentypename = dag.Tables[1].Rows[0].ItemArray[0].ToString();
            //string agenstatus = dag.Tables[2].Rows[0].ItemArray[0].ToString();
            //string credit = dag.Tables[3].Rows[0].ItemArray[0].ToString();
            //string rategroup = dag.Tables[4].Rows[0].ItemArray[0].ToString();
            //string comm = dag.Tables[5].Rows[0].ItemArray[0].ToString();
            //string pay = dag.Tables[6].Rows[0].ItemArray[0].ToString();

            nameadd = clientname + "(" + code + ")" + "+" + address;
            //Response.Write(nameadd);
            //Response.End();


        }
        return nameadd;



    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindExec(string compcode, string execname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getExec(compcode, execname, "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            if (Session["FILTER"].ToString() == "D")
            {
                ds = clsbooking.getExec(compcode, execname, "0", Session["revenue"].ToString());
            }
            else
            {
                ds = clsbooking.getExec(compcode, execname, "0", "0");
            }
        }
        return ds;



    }


    [Ajax.AjaxMethod]
    public DataSet Fetch(string compcode, string fdate, string todate, string deal, string agency, string client, string pub, string Filter, string uid, string dateformat,string adtype,string uom)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.dealprovision1 insert = new NewAdbooking.Classes.dealprovision1();
            ds = insert.Fetchdata(compcode, fdate, todate, deal, agency, client, pub, Filter, uid, dateformat, adtype, uom);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.dealprovision1 insert = new NewAdbooking.classesoracle.dealprovision1();
            ds = insert.Fetchdata(compcode, fdate, todate, deal, agency, client, pub, Filter, uid, dateformat, adtype, uom);
        }
        return ds;
    }

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {

            // NewAdbooking.BillingClass.Classes.session_billing logindetail = new NewAdbooking.BillingClass.Classes.session_billing();
            // ds = logindetail.getPubCenter();
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.updatestaus pub_cent1 = new NewAdbooking.BillingClass.classesoracle.updatestaus();
            ds = pub_cent1.publication_center(Session["compcode"].ToString());
        }
        else
        {
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }


    }

    [Ajax.AjaxMethod]
    public DataSet savedealprovision(string compcode, string agencycode, string clientcode, string contractid, string billno, string billdate, string billamt, string billrate, string discrate, string creditnoterate, string totalinsertion, string userid, string insertid, string reamarks, string bookingid, string traddiscount, string ADDITIONALFLAG, string INSERTSTATUS, string DISCRATE, string addcomm, string CHKTRADEDISC, string TRANSLATIONPREMIUM, string TRANSLATIONDISC, string TRANSLATIONTYPE, string SPECIALDISCOUNT, string SPACEDISCOUNT, string SPECIALCHARGES, string PACKAGECODE, string DISCTYPE, string PREMPER, string SPECIALDISCPER, string DISCOUNT, string DISCOUNTPER, string SPACEDISCPER, string PREMIUMCHARGESTYPE, string AGCITY, string ADTYPE, string UOMCODE, string TRANSLATIONCODE, string PAGEPREM, string PAGEPOSITIONCODE, string PAGEAMOUNT, string POSPREMDISC, string BKDATE,string colorcode)
    {
        DataSet ds = new DataSet();
   
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.dealprovision1 C2 = new NewAdbooking.Classes.dealprovision1();
            ds = C2.adddealprovisionsave(compcode, agencycode, clientcode, contractid, billno, billdate, billamt, billrate, discrate, creditnoterate, totalinsertion, userid, insertid, reamarks, bookingid);
        }
        else
        {
            NewAdbooking.classesoracle.dealprovision1 C2 = new NewAdbooking.classesoracle.dealprovision1();
            ds = C2.adddealprovisionsave(compcode, agencycode, clientcode, contractid, billno, billdate, billamt, billrate, discrate, creditnoterate, totalinsertion, userid, insertid, reamarks, bookingid, traddiscount, ADDITIONALFLAG, INSERTSTATUS, DISCRATE, addcomm, CHKTRADEDISC, TRANSLATIONPREMIUM, TRANSLATIONDISC, TRANSLATIONTYPE, SPECIALDISCOUNT, SPACEDISCOUNT, SPECIALCHARGES, PACKAGECODE, DISCTYPE, PREMPER, SPECIALDISCPER, DISCOUNT, DISCOUNTPER, SPACEDISCPER, PREMIUMCHARGESTYPE, AGCITY, ADTYPE, UOMCODE, TRANSLATIONCODE, PAGEPREM, PAGEPOSITIONCODE, PAGEAMOUNT, POSPREMDISC, BKDATE, colorcode);

        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtye)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }

        return ds;
    }
}
