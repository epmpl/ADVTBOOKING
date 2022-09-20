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


public partial class revised_bill : System.Web.UI.Page
{
    string revenue1 = "";
    string agency = "";
    string client = "";
    string rate_audit = "";
    int i;
    string boooking = "";
    string no_insertion = "";
    string todatenew = "";

    string disp_clsbill = "";
    protected void Page_Load(object sender, EventArgs e)
    {



        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            //Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        DataSet ds = new DataSet();
        DataSet ds_SESSION = new DataSet();
        Ajax.Utility.RegisterTypeForAjax(typeof(revised_bill));
        ds.ReadXml(Server.MapPath("XML/billing.xml"));
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        // lblbooking.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblrevenue.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbagencty.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbpackage.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbbillst.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblbooking.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        rate_audit = Session["rate_audit"].ToString();
        hiddenadtype.Value = dpdadtype.SelectedValue;

        disp_clsbill = Session["DISP_CLSBILL"].ToString();


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.BillingClass.classesoracle.session_billing logindetail = new NewAdbooking.BillingClass.classesoracle.session_billing();
            ds_SESSION = logindetail.chklogin_billing(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing logindetail = new NewAdbooking.BillingClass.Classes.session_billing();
            ds_SESSION = logindetail.chklogin_billing(Session["userid"].ToString(), Session["compcode"].ToString());

        }

        Session["FMG_BILL_DIS"] = ds_SESSION.Tables[0].Rows[0]["FMG_BILL_DIS"].ToString();
        Session["BILL_DISP_CASHBILL"] = ds_SESSION.Tables[0].Rows[0]["BILL_DISP_CASHBILL"].ToString();
        Session["BILL_CLA_CASHBILL"] = ds_SESSION.Tables[0].Rows[0]["BILL_CLA_CASHBILL"].ToString();
        Session["CLA_CASHBILL"] = ds_SESSION.Tables[0].Rows[0]["CLA_CASHBILL"].ToString();
        Session["ROWISE_CASHBOOKING"] = ds_SESSION.Tables[0].Rows[0]["ROWISE_CASHBOOKING"].ToString();
        Session["invoice_no"] = ds_SESSION.Tables[0].Rows[0]["invoice_no"].ToString();
        hiddendisp_billcri.Value = ds_SESSION.Tables[0].Rows[0]["DISP_BILLING_CRITERIA"].ToString();
        hiddenclass_billcri.Value = ds_SESSION.Tables[0].Rows[0]["CLSD_BILLING_CRITERIA"].ToString();


        Session["BILL_GENERATION_PRIOR"] = ds_SESSION.Tables[0].Rows[0]["BILL_GENERATION_PRIOR"].ToString();
        Session["PUBLICATION_HO"] = ds_SESSION.Tables[0].Rows[0]["PUBLICATION_HO"].ToString();



        if (Session["center"].ToString() != Session["PUBLICATION_HO"].ToString())
        {

            Response.Write("<script>alert('Billing is not allowed here');window.close();</script>");
            return;

        }



        if (!IsPostBack)
        {


            hiddendisplaybill.Value = Session["displaybilltype"].ToString();
            hiddenclsbill.Value = Session["clsbilltype"].ToString();
            bindmonth();
            bindyear();
            btnprv.Visible = false;
            btngenrate.Visible = false;
            btnprint.Visible = false;
            adtypedata(Session["compcode"].ToString());
            bindload();
            bindpub();
            bindpackage();
            addagent();
            bindcenter();
            //bindbillcycle();
            bindrevenuecenter();
            // bindretainer();
            bindbranch();
            // bindexecutive();
            binddistrict();
            LOADTALUKA();

            lstclient.Attributes.Add("onclick", "javascript:return insertclient();");
            lstclient.Attributes.Add("onkeypress", "javascript:return insertclient();");
            ListBox1.Attributes.Add("onclick", "javascript:return insertagency(this.value);");
            lstretainer.Attributes.Add("onclick", "javascript:return fillmaingrp(this.value)");
            lstexecutive.Attributes.Add("onclick", "javascript:return fillexecutivegrp();");


            form1.Attributes.Add("onkeydown", "javascript:return tabvalue(event);");

            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");

            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");
            btnsubmit.Attributes.Add("onclick", "javascript:return chekvalidaton()");

            billreprint.Attributes.Add("OnClick", "javascript:return blankgrid();");
            billgen.Attributes.Add("OnClick", "javascript:return blankgrid();");

            billprev.Attributes.Add("OnClick", "javascript:return blankgrid();");
            dpdadtype.Attributes.Add("onchange", "javascript:return blankgrid();");

            drpbillstatus.Attributes.Add("onchange", "javascript:return blankgrid();");
            //  dpdadtype.Attributes.Add("onchange", "javascript:return bindadcat1();");
            dpdistrict.Attributes.Add("onchange", "javascript:return bind_taluka();");
            dpadcatgory.Attributes.Add("onchange", "javascript:return fetch_categary();");
            drppackage.Attributes.Add("onchange", "javascript:return fetch_PACKAGE();");
            btnExit.Attributes.Add("OnClick", "javascript:return catexitclick();");
            dpbill.Attributes.Add("onchange", "javascript:return blankgrid1();");


            //dpbill.Attributes.Add("onchange", "javascript:return blankgrid_WEEKLY();");


            dpbill.Attributes.Add("onchange", "javascript:return disablefrdt_todt('dpbill');");

            Text_fromdate.Attributes.Add("onblur", "javascript:return valuecopy('Text_fromdate');");
            text_todate.Attributes.Add("onblur", "javascript:return valuecopy('text_todate');");
            txtfrmdate.Attributes.Add("onblur", "javascript:return valuecopy('txtfrmdate');");


            txtagency.Attributes.Add("OnPaste", "return false");
            txtagency.Attributes.Add("Ondrop", "return false");
            txtagency.Attributes.Add("Ondrag", "return false");
            txtagency.Attributes.Add("Oncut", "return false");
            txtagency.Attributes.Add("OnCopy", "return false");

            txtclient.Attributes.Add("OnPaste", "return false");
            txtclient.Attributes.Add("Ondrop", "return false");
            txtclient.Attributes.Add("Ondrag", "return false");
            txtclient.Attributes.Add("Oncut", "return false");
            txtclient.Attributes.Add("OnCopy", "return false");

            dpretainer.Attributes.Add("OnPaste", "return false");
            dpretainer.Attributes.Add("Ondrop", "return false");
            dpretainer.Attributes.Add("Ondrag", "return false");
            dpretainer.Attributes.Add("Oncut", "return false");
            dpretainer.Attributes.Add("OnCopy", "return false");



            dpexecutive.Attributes.Add("OnPaste", "return false");
            dpexecutive.Attributes.Add("Ondrop", "return false");
            dpexecutive.Attributes.Add("Ondrag", "return false");
            dpexecutive.Attributes.Add("Oncut", "return false");
            dpexecutive.Attributes.Add("OnCopy", "return false");


            //dpexecutive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr();");
            //dpexecutive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr();");

            //lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive();");
            //lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive();");

            // dpretainer.Attributes.Add("onkeydown", "javascript:return F2fillretainercr();");
            // dpretainer.Attributes.Add("onkeypress", "javascript:return F2fillretainercr();");

            //lstretainer.Attributes.Add("onclick", "javascript:return Clickretainer();");
            // lstretainer.Attributes.Add("onkeydown", "javascript:return Clickretainer();");





            if (hiddendisplaybill.Value != "monthly")
            {
                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            }
            if (hiddenclsbill.Value != "monthly")
            {
                txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            }



        }

    }





    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcol, string exectv)
    {
        string tname = "", userid = "";
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save exec = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing exec = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditretainer(string compcol, string ret)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objregion = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = objregion.retainerxls(compcol, ret);
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing objregion = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = objregion.retainerxls(compcol, ret);
        }



        return ds;
    }



    [Ajax.AjaxMethod]
    public DataSet bindtaluka(string compcode, string district)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save taluka = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = taluka.talukabind(compcode, district);
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing taluka = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = taluka.talukabind(compcode, district);
        }


        return ds;

    }


    public void binddistrict()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save pub = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing pub = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }


        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select District";
        li.Selected = true;
        dpdistrict.Items.Add(li);




        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpdistrict.Items.Add(li1);
        }

    }





    public void bindmonth()
    {
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMMM");
            item.Value = i.ToString();
            selecmon.Items.Add(item);
        }
    }


    public void bindload()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select AdCat";
        li1.Value = "0";
        dpadcatgory.Items.Add(li1);
    }



    public void LOADTALUKA()
    {
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Taluka";
        li1.Value = "0";
        dptaluka.Items.Add(li1);
    }

    public void bindyear()
    {

        for (int i = 2000; i <= 2100; i++)
        {
            ListItem item = new ListItem();
            item.Text = i.ToString();
            item.Value = i.ToString();
            selyear.Items.Add(item);
        }
    }





    [Ajax.AjaxMethod]
    public DataSet adcatbnd(string adtype, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing adcat = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = adcat.advtype(adtype, compcode);
        }
        return ds;

    }






    public void bindcenter()
    {
        drpbooking.Items.Clear();
        DataSet ds = new DataSet();



        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            //NewAdbooking.Classes.bill objbkcenter = new NewAdbooking.Classes.billing_save();
            NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();

            ds = objbkcenter.center(Session["compcode"].ToString());
        }
        else
        {

            //NewAdbooking.Classes.billing_save ObjBillingSave = new NewAdbooking.Classes.billing_save();
            NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = objbkcenter.pub_cent_NEW(Session["compcode"].ToString());
        }


        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Booking Center--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbooking.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpbooking.Items.Add(li);
            }

        }


    }


    public void bindrevenuecenter()
    {
        drprevenue.Items.Clear();
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save objbkcenter = new NewAdbooking.BillingClass.Classes.billing_save();
            ds = objbkcenter.revnue_center(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objbkcenter = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = objbkcenter.center(Session["compcode"].ToString());

        }

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Revenue Center--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprevenue.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drprevenue.Items.Add(li);
            }

        }
        // drprevenue.SelectedValue = revenue1;

    }


    public void addagent()
    {
        drpagetyp.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master agent = new NewAdbooking.Classes.Master();


            ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.Master agent = new NewAdbooking.classesoracle.Master();
                ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());

            }
            else
            {
                //NewAdbooking.classmysql.Master agent = new NewAdbooking.classmysql.Master();
                //ds = agent.addagent_typ(Session["userid"].ToString(), Session["compcode"].ToString());

            }
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Agency Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpagetyp.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpagetyp.Items.Add(li);
            }

        }



    }
    public void bindpackage()
    {

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Package";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppackage.Items.Add(li1);


    }
    public void bindpub()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 advpub = new NewAdbooking.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li);


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
        dpdadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        dpdadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


        }

    }

    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.billing_save bindagen = new NewAdbooking.BillingClass.Classes.billing_save();

            ds = bindagen.bindagencycode(compcode, agency);
        }
        else
        {

            NewAdbooking.BillingClass.classesoracle.billing_save bindagen = new NewAdbooking.BillingClass.classesoracle.billing_save();

            ds = bindagen.agencyxls(compcode, agency);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();

            ds = clsbooking.getClientName(compcode, client);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();

            ds = clsbooking.getClientName(compcode, client, "0");
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();

            ds = clsbooking.getClientName(compcode, client);
            return ds;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {



        string billmode = "";
        if (billprev.Checked == true)
        {
            billmode = "1";
        }
        else if (billgen.Checked == true)
        {
            billmode = "2";
        }
        else
        {
            billmode = "3";

        }


        Session["bill_type"] = hiddenbillcycle.Value;



        string agencycod = txtagency.Text;
        string clientcode = txtclient.Text;


        if (agencycod != "")
        {
            char[] splitter = { '(' };
            string[] myarray = agencycod.Split(splitter);
            agency = myarray[1];
            agency = agency.Replace(")", "");
        }
        if (clientcode != "")
        {
            char[] splitter = { '(' };
            string[] myarray1 = clientcode.Split(splitter);
            client = myarray1[1];
            client = client.Replace(")", "");
        }


        string revenue = "";
        if (drprevenue.SelectedValue != "0")
        {
            revenue = drprevenue.SelectedItem.Text;
        }
        string bookingcenter = "";

        if (drpbooking.SelectedValue != "0")
        {
            bookingcenter = drpbooking.SelectedValue;
        }

        string agencytype = "";
        if (drpagetyp.SelectedValue != "0")
        {
            agencytype = drpagetyp.SelectedItem.Text;
        }

        string package11 = "";
        if (drppackage.SelectedValue != "0")
        {
            package11 = drppackage.SelectedItem.Text;
        }
        //=================for seprate pages==========




        if (dpdadtype.SelectedValue == "DI0")
        {
            if (hiddendisplaybill.Value == "orderwisefirstins")
            {
                Response.Redirect("orderwise_first_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue);
            }

            if (hiddendisplaybill.Value == "insertionwise")
            {
                Response.Redirect("insertion_wise_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text);
            }

            if (hiddendisplaybill.Value == "orderwiselastins")
            {



                Response.Redirect("orderwise_last_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + hiddenPACKAGE.Value + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + hidden_agency.Value + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text);


            }










            if (hiddendisplaybill.Value == "orderwiselastins")
            {






                Response.Redirect("orderwise_last_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + hiddenPACKAGE.Value + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + hiddencategory.Value + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text);
            }


            if (hiddendisplaybill.Value == "monthly")
            {
                string mondt;
                string mon = selecmon.SelectedValue;


                string yearnew1 = "";
                yearnew1 = selyear.SelectedValue;
                int yearnew = 0;

                if ((selecmon.SelectedValue == "1") || (selecmon.SelectedValue == "3") || (selecmon.SelectedValue == "5") || (selecmon.SelectedValue == "7") || (selecmon.SelectedValue == "8") || (selecmon.SelectedValue == "10") || (selecmon.SelectedValue == "12"))
                {
                    mondt = "31";
                }
                else
                    if (selecmon.SelectedValue == "2")
                    {



                        yearnew = Convert.ToInt32(yearnew1);

                        if (yearnew % 4 == 0)
                        {
                            mondt = "29";
                        }
                        else
                        {
                            mondt = "28";
                        }
                    }
                    else
                    {
                        mondt = "30";
                    }
                int mont = Convert.ToInt32(mon);
                int mondtt = Convert.ToInt32(mondt);
                string mondt1 = "";
                string mon1 = "";
                if (mondtt <= 9)
                {
                    mondt1 = "0" + mondt;
                }
                else
                {
                    mondt1 = mondt;
                }
                if (mont <= 9)
                {
                    mon1 = "0" + mon;
                }
                else
                {
                    mon1 = mon;
                }


                string todate = yearnew1 + "/" + mon1 + "/" + mondt1;
                string fromdt = yearnew1 + "/" + mon1 + "/" + "01";


                if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                {


                    todate = mondt1 + "/" + mon1 + "/" + yearnew1;


                }
                else
                    if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                    {

                        todate = mon1 + "/" + mondt1 + "/" + yearnew1;

                    }
                    else
                        if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                        {
                            todate = yearnew1 + "/" + mon1 + "/" + mondt1;


                        }
                ////////////////////////////////////////

                if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                {



                    fromdt = "01" + "/" + mon1 + "/" + yearnew1;


                }
                else
                    if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                    {


                        fromdt = mon1 + "/" + "01" + "/" + yearnew1;

                    }
                    else
                        if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                        {
                            fromdt = yearnew1 + "/" + mon1 + "/" + "01";


                        }

                todatenew = todate;

                //todate, fromdt
                Response.Redirect("monthly_wise_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text + "&from_datenew=" + Text_fromdate.Text + "&to_datenew=" + text_todate.Text);
            }

            if (hiddendisplaybill.Value == "daily")
            {
                string todate = "";
                string fromdt = "";
                Response.Redirect("monthly_wise_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text + "&from_datenew=" + txtfrmdate.Text + "&to_datenew=" + txttodate1.Text);
            }

        }

        else
        {

            if (hiddenclsbill.Value == "orderwiselastins")
            {







                Response.Redirect("orderwise_last_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + hiddenPACKAGE.Value + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + hiddencategory.Value + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text);
            }

            if (hiddenclsbill.Value == "orderwisefirstins")
            {
                Response.Redirect("orderwise_first_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue);
            }


            if (hiddenclsbill.Value == "insertionwise")
            {
                Response.Redirect("insertion_wise_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + txttodate1.Text + "&fromdt=" + txtfrmdate.Text + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text);
            }


            if (hiddenclsbill.Value == "monthly")
            {
                string mondt;
                string mon = selecmon.SelectedValue;


                string yearnew1 = "";
                yearnew1 = selyear.SelectedValue;
                int yearnew = 0;

                if ((selecmon.SelectedValue == "1") || (selecmon.SelectedValue == "3") || (selecmon.SelectedValue == "5") || (selecmon.SelectedValue == "7") || (selecmon.SelectedValue == "8") || (selecmon.SelectedValue == "10") || (selecmon.SelectedValue == "12"))
                {
                    mondt = "31";
                }
                else
                    if (selecmon.SelectedValue == "2")
                    {



                        yearnew = Convert.ToInt32(yearnew1);

                        if (yearnew % 4 == 0)
                        {
                            mondt = "29";
                        }
                        else
                        {
                            mondt = "28";
                        }
                    }
                    else
                    {
                        mondt = "30";
                    }
                int mont = Convert.ToInt32(mon);
                int mondtt = Convert.ToInt32(mondt);
                string mondt1 = "";
                string mon1 = "";
                if (mondtt <= 9)
                {
                    mondt1 = "0" + mondt;
                }
                else
                {
                    mondt1 = mondt;
                }
                if (mont <= 9)
                {
                    mon1 = "0" + mon;
                }
                else
                {
                    mon1 = mon;
                }


                string todate = yearnew1 + "/" + mon1 + "/" + mondt1;
                string fromdt = yearnew1 + "/" + mon1 + "/" + "01";


                if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                {


                    todate = mondt1 + "/" + mon1 + "/" + yearnew1;


                }
                else
                    if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                    {

                        todate = mon1 + "/" + mondt1 + "/" + yearnew1;

                    }
                    else
                        if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                        {
                            todate = yearnew1 + "/" + mon1 + "/" + mondt1;


                        }
                ////////////////////////////////////////

                if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                {



                    fromdt = "01" + "/" + mon1 + "/" + yearnew1;


                }
                else
                    if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                    {


                        fromdt = mon1 + "/" + "01" + "/" + yearnew1;

                    }
                    else
                        if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                        {
                            fromdt = yearnew1 + "/" + mon1 + "/" + "01";


                        }

                todatenew = todate;

                //todate, fromdt
                Response.Redirect("monthly_wise_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text + "&from_datenew=" + Text_fromdate.Text + "&to_datenew=" + text_todate.Text);
            }

            if (hiddenclsbill.Value == "daily")
            {
                string todate = "";
                string fromdt = "";
                Response.Redirect("monthly_wise_supp.aspx?dtformat=" + Session["dateformat"].ToString() + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + dppub1.SelectedValue + "&bkcen=" + bookingcenter + "&rev=" + revenue + "&agtype=" + agencytype + "&pckg=" + package11 + "&adtyp=" + dpdadtype.SelectedValue + "&ag=" + agency + "&client=" + client + "&billstate=" + drpbillstatus.SelectedValue + "&rtaudit=" + rate_audit + "&blmod=" + billmode + "&blcycle=" + hiddenbillcycle.Value + "&retainer_name=" + hiddenretainer.Value + "&executive_name=" + hdnexecutivetxt.Value + "&branch_name=" + drpbranch.SelectedItem.Text + "&ad_category=" + dpadcatgory.SelectedValue + "&district_code=" + dpdistrict.SelectedValue + "&taluka_code=" + dptaluka.SelectedValue + "&bill_no=" + txt_billno.Text + "&from_datenew=" + txtfrmdate.Text + "&to_datenew=" + txttodate1.Text);
            }

        }





    }




    [Ajax.AjaxMethod]
    public DataSet bindpackagenew(string adtype, string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

            NewAdbooking.BillingClass.classesoracle.billing_save bindopackage = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = bindopackage.packagebind_NEW(compcode, adtype);
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing bindopackage = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = bindopackage.packagebind_NEW(compcode, adtype);
        }

        return ds;

    }



    protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    {

        //DataSet ds = new DataSet();
        //drppackage.Items.Clear();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.BillingClass.Classes.billing_save bindopackage = new NewAdbooking.BillingClass.Classes.billing_save();
        //    ds = bindopackage.packagebind(Session["compcode"].ToString(), dpdadtype.SelectedValue);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();
        //    ds = bindopackage.packagebind(Session["compcode"].ToString(), dpdadtype.SelectedValue);
        //}
        //else
        //{
        //    NewAdbooking.classmysql.BookingMaster bindopackage = new NewAdbooking.classmysql.BookingMaster();
        //    ds = bindopackage.packagebind(Session["compcode"].ToString(), dpdadtype.SelectedValue);
        //}

        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select Package";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //drppackage.Items.Add(li1);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drppackage.Items.Add(li);
        //    }

        //}


    }


    public void updatetable()
    {


        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save updttbl = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = updttbl.updateinsert_table(Session["compcode"].ToString());
        }
        else
        {

            NewAdbooking.BillingClass.Classes.session_billing updttbl = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = updttbl.updateinsert_table(Session["compcode"].ToString());
        }

    }

    /* public void bindbillcycle()
     {
         DataSet destination = new DataSet();
         destination.ReadXml(Server.MapPath("XML/billcycle.xml"));
         //DataSet ds = new DataSet();
         //ds.ReadXml(Server.MapPath("XML/billcyle.xml"));
         //// lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
         dpbill.Items.Clear();
         int i;
         ListItem li1;
         li1 = new ListItem();
         li1.Text = "--Select Bill Cycle--";
         li1.Value = "0";
         li1.Selected = true;
         dpbill.Items.Add(li1);

         for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
         {
             ListItem li;
             li = new ListItem();
             li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
             i = i + 1;
             li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
             dpbill.Items.Add(li);

         }


     }*/



    [Ajax.AjaxMethod]
    public DataSet bindbillcycl()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = bind.bindbill_frequency();
        }
        else
        {

            NewAdbooking.BillingClass.Classes.session_billing bind = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = bind.bindbill_frequency();

        }


        //DataSet ds = new DataSet();
        //ds.ReadXml(Server.MapPath("XML/billcyle.xml"));
        //// lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //dpbill.Items.Clear();
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "--Select Bill Cycle--";
        //li1.Value = "0";
        //li1.Selected = true;
        //dpbill.Items.Add(li1);

        //for (i = 0; i < ds.Tables[0].Columns.Count; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    dpbill.Items.Add(li);

        //}

        return ds;
    }

    public void bindbranch()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = bind.bindbranch();
        }
        else
        {

            NewAdbooking.BillingClass.Classes.session_billing bind = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = bind.bindbranch(Session["compcode"].ToString());

        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        drpbranch.Items.Clear();
        li1.Text = "-Select Branch-";
        li1.Value = "0";
        li1.Selected = true;
        drpbranch.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbranch.Items.Add(li);


        }

    }











}
