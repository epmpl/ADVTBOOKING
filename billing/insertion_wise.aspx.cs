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

public partial class insertion_wise : System.Web.UI.Page
{
    string revenue1 = "";
    string agency = "";
    string client = "";
    string rate_audit = "";
    int i;
    string boooking = "";
    string no_insertion = "";
    string todatenew = "";


    string dtformat = "";
    string todate = "";
    string fromdt = "";
    string pub = "";
    string bkcen = "";
    string rev = "";
    string agtype = "";
    string pckg = "";
    string adtyp = "";
    string ag = "";
    
     string billstate = "";
    string rtaudit = "";
    string blmod = "";
    string blcycle = "";
    string retainer_name = "";
    string executive_name = "";
    string branch_name = "";
    string ad_category = "";
    string district = "";
    string taluka = "";
    string bill_no = "";

    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        //Response.CacheControl = "no-cache";
        Ajax.Utility.RegisterTypeForAjax(typeof(insertion_wise));




        retainer_name = Request.QueryString["retainer_name"].ToString();
        executive_name = Request.QueryString["executive_name"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();

        ad_category = Request.QueryString["ad_category"].ToString();
        district = Request.QueryString["district_code"].ToString();
        taluka = Request.QueryString["taluka_code"].ToString();



        dtformat = Request.QueryString["dtformat"].ToString();
        hiddentdate.Value = Request.QueryString["todate"].ToString();
        todate = Request.QueryString["todate"].ToString();
        hiddenfdate.Value = Request.QueryString["fromdt"].ToString();
        fromdt = Request.QueryString["fromdt"].ToString();
        pub = Request.QueryString["pub"].ToString();
        bkcen = Request.QueryString["bkcen"].ToString();
        rev = Request.QueryString["rev"].ToString();
        agtype = Request.QueryString["agtype"].ToString();
        pckg = Request.QueryString["pckg"].ToString();
        adtyp = Request.QueryString["adtyp"].ToString();
        ag = Request.QueryString["ag"].ToString();
        client = Request.QueryString["client"].ToString();
        billstate = Request.QueryString["billstate"].ToString();
        rtaudit = Request.QueryString["rtaudit"].ToString();
        blmod = Request.QueryString["blmod"].ToString();
        hiddenbillcycle.Value = Request.QueryString["blcycle"].ToString();
        blcycle = Request.QueryString["blcycle"].ToString();
        hiddenadtype.Value = adtyp.ToString();
        Session["bill_cycle1"] = blcycle;
        bill_no = Request.QueryString["bill_no"].ToString();
        Session["pcentername"] = Request.QueryString["bookingcentername"].ToString();
        //***********************for kathmandu*****************************
        Session["pcenter"] = Request.QueryString["bkcen"].ToString();
        if (!IsPostBack)
        {
            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
            btnprintforgov.Attributes.Add("onclick", "javascript:return checkboxidbillreprintforgov();");
           // btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");
            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");

            btn_mail.Attributes.Add("onclick", "javascript:return printpdf();");
            btn_printletter.Attributes.Add("onclick", "javascript:return printletter();");

        }
         






        string agencycod = ag.ToString();
        string clientcode = client.ToString();


        //if (agencycod != "")
        //{
        //    char[] splitter = { '(' };
        //    string[] myarray = agencycod.Split(splitter);
        //    agency = myarray[1];
        //    agency = agency.Replace(")", "");
        //}
        //if (clientcode != "")
        //{
        //    char[] splitter = { '(' };
        //    string[] myarray1 = clientcode.Split(splitter);
        //    client = myarray1[1];
        //    client = client.Replace(")", "");
        //}

        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision")
        {
            btn_printletter.Visible = true;
        }
        else
        {
            btn_printletter.Visible = false;
        }
       

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        if (adtyp == "DI0")
         {
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {

                 NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                 ds = abc.websp_bindciobookingid(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_SCHEME"].ToString(), Session["userid"].ToString());
             }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                 ds = abc.websp_bindciobookingid(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_SCHEME"].ToString());

             }

             else
             {
                 string[] parameterValueArray = new string[] { fromdt, todate, dtformat, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), bill_no, Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_SCHEME"].ToString(),null,null,null };
                 string procedureName = "Websp_Bindcioidnew1";
                 NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                 ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

             }

         Session["RowLen"] = ds.Tables[0].Rows.Count;
         hidden1.Value = Session["RowLen"].ToString();
         hiddenfromdate.Value = fromdt;
         hiddendateto.Value = todate;
         hiddenclient.Value = client.ToString();
         hiddencheck.Value = adtyp;
         if (hidden1.Value == "0")
         {
             DataGrid1.DataSource = ds;
             DataGrid1.DataBind();
            
             ScriptManager.RegisterClientScriptBlock(this, typeof(insertion_wise), "cc", "checklenthbill()", true);
             btnprv.Visible = false;
             btngenrate.Visible = false;
             btnprint.Visible = false;
             btnprintforgov.Visible = false;
             btn_mail.Visible = false;

             return;



         }


         else
         {

             if ((billstate == "3") || (billstate == "5"))
             {
                 btnprv.Visible = true;
                 btngenrate.Visible = true;
                 btnprint.Visible = false;
                 btnprintforgov.Visible = false;
                 btn_mail.Visible = false;

             }
             else
             if (billstate == "6")
             {
                 btnprv.Visible = false;
                 btngenrate.Visible = false;
                 btnprint.Visible = false;
                 btnprintforgov.Visible = false;
                 btn_mail.Visible = false;

             }
             else
                 if (billstate == "2")
             {

                 btnprv.Visible = false;
                 btngenrate.Visible = false;
                 btnprint.Visible = true;
                 btnprintforgov.Visible = true;
                 if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision")
                 {
                     btn_mail.Visible = false;
                 }
                 else
                 {
                     btn_mail.Visible = true;
                 }
             }



             DataGrid1.DataSource = ds;
             DataGrid1.DataBind();
            // ScriptManager.RegisterClientScriptBlock(this, typeof(insertion_wise), "cc", "checkvisible()", true);
            // return;
         }
    }

    else 
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

            ds = abc.websp_bindciobookingid(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_SCHEME"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

            ds = abc.websp_bindciobookingid(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_SCHEME"].ToString());

        }
        else
        {
            string[] parameterValueArray = new string[] { dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_SCHEME"].ToString() };
            string procedureName = "Websp_Bindcioidnew1";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }


        Session["RowLen"] = ds.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();
        if (hidden1.Value == "0")
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();

            ScriptManager.RegisterClientScriptBlock(this, typeof(insertion_wise), "cc", "checklenthbill()", true);
            btnprv.Visible = false;
            btngenrate.Visible = false;
            btnprint.Visible = false;
            btnprintforgov.Visible = false;
            btn_mail.Visible = false;

            return;



        }


        else
        {


            if ((billstate == "3") || (billstate == "5"))
            {
                btnprv.Visible = true;
                btngenrate.Visible = true;
                btnprint.Visible = false;
                btnprintforgov.Visible = false;
                btn_mail.Visible = false;

            }
            else
                if (billstate == "6")
                {
                    btnprv.Visible = false;
                    btngenrate.Visible = false;
                    btnprint.Visible = false;
                    btnprintforgov.Visible = false;
                    btn_mail.Visible = false;

                }
                else
                    if (billstate == "2")
                    {

                        btnprv.Visible = false;
                        btngenrate.Visible = true;
                        btnprint.Visible = true;
                        btnprintforgov.Visible = true;
                        btn_mail.Visible = true;
                    }



            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
           // ScriptManager.RegisterClientScriptBlock(this, typeof(insertion_wise), "cc", "checkvisible()", true);
            //return;
        }
    }

    }

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    

    protected void DataGrid3_ItemDataBound(object sender, DataGridItemEventArgs e)
    {


        if (billstate == "3")
        {
            if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
            {

                string bill_status = e.Item.Cells[7].Text;
                string[] bill_statusq = bill_status.Split('-');
                if (bill_statusq[0] == "N")
                {
                    e.Item.Cells[7].Text = "N";
                    e.Item.Enabled = false;
                    e.Item.Cells[8].Text = bill_statusq[1].ToString();
                }
                else
                {
                    e.Item.Cells[7].Text = "y";
                    e.Item.Cells[8].Text = bill_statusq[1].ToString();
                }
            }

        }
        else
            if (billstate == "2")
            {
                e.Item.Cells[8].Visible = false;
                if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
                {
                    e.Item.Cells[7].Text = "Billed";



                }
            }

            else
                if (billstate == "5")
                {
                    e.Item.Cells[8].Visible = false;
                    if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
                    {
                        e.Item.Cells[7].Text = "Publish";



                    }
                }

                else
                    if (billstate == "6")
                    {
                        e.Item.Cells[8].Visible = false;
                        if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
                        {
                            e.Item.Cells[7].Text = "Booked";



                        }
                    }



    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // ds1 = abc.maxdate(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

        Response.Redirect("billing_summary_insertion.aspx?dtformat=" + dtformat + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + pub + "&bkcen=" + bkcen + "&rev=" + rev + "&agtype=" + agtype + "&pckg=" + pckg + "&adtyp=" + adtyp + "&ag=" + ag + "&client=" + client + "&billstate=" + billstate + "&rtaudit=" + rtaudit + "&blmod=" + blmod + "&blcycle=" + blcycle);


    }





    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSession_preview(string cioid, string checkradio, string insertion, string edition, string spl_dis, string trade_dis, string rborg)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        Session["spl_dis"] = spl_dis;
        Session["trade_dis"] = trade_dis;
        Session["bill_org"] = rborg;
        

    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSession(string cioid, string checkradio, string insertion, string edition, string bill, string spl_dis, string trade_dis, string todate_v, string rborg)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        Session["billing_bill"] = bill;
          Session["spl_dis"] = spl_dis;
        Session["trade_dis"] = trade_dis;
        Session["billing_todate_v"] = todate_v;
        Session["bill_org"] = rborg;

    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionIns_gen(string ciobookid,string checkradio,string insertion,string  dateto,string frmdt,string client,string adtype,string bill,string hiddenbillstatus,string todate_v,string edition,string spl_dis,string trade_dis,string aa,string rborg)
    {
        Session["billing_cioid"] = ciobookid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        Session["billing_bill"] = bill;
        Session["spl_dis"] = spl_dis;
        Session["trade_dis"] = trade_dis;
        Session["billing_todate_v"] = todate_v;
        Session["bill_org"] = rborg;           
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
        Session["adtype"] = adtype;
        Session["bill"] = bill;
        Session["bill_date"] = aa;
        Session["hiddensession"] = hiddenbillstatus;
       

    }




    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionre(string cioid, string checkradio, string insertion, string edition, string invoice_no, string spl_dis, string trade_dis,string rborg)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        Session["invoice"] = invoice_no;
        Session["spl_dis"] = spl_dis;
        Session["trade_dis"] = trade_dis;
        Session["bill_org"] = rborg;

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void settempdata(string cioid, string publish, string insertion, string bill_cycle,string datefrom,string dateto)
    {
        string[] countbookid1 = cioid.Split(',');
        string bill_process_id = "1";
        string[] insert1=insertion.Split(',');
        string[] pubdate=publish.Split(',');
        int c1 = countbookid1.Length;
        for (int i = 0; i < c1; i++)
        {
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                ds1 = abc.settemprec(Session["compcode"].ToString(), countbookid1[i], insert1[i], bill_cycle, datefrom, dateto, pubdate[i], bill_process_id, Session["userid"].ToString(), Session["dateformat"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                //ds1 = abc.settemprec(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString());

            }
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void billpross(string bill_cycle, string datefrom, string dateto,string adtype)
    {
        //string[] countbookid1 = cioid.Split(',');
        string bill_process_id = "1";
        //string[] insert1 = insertion.Split(',');
        //string[] pubdate = publish.Split(',');
        //int c1 = countbookid1.Length;
        //for (int i = 0; i < c1; i++)
        //{
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                ds1 = abc.billproces(Session["compcode"].ToString(), bill_cycle, datefrom, dateto, bill_process_id, Session["userid"].ToString(), Session["dateformat"].ToString(), adtype);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                //ds1 = abc.settemprec(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString());

            }
        else
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), bill_cycle, datefrom, dateto, bill_process_id, Session["userid"].ToString(), Session["dateformat"].ToString(), adtype };
            string procedureName = "adbill_monthly_insert_process";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds1 = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        //}
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast_cover(string ciobookid, string agencycode, string invoice_no,string chkradio)
    {
        Session["billing_cioid"] = ciobookid;
        //Session["billing_checkradio"] = checkradio;
        //Session["billing_insertion"] = insertion;
        //Session["billing_edition"] = edition;
        //

        Session["agencycode"] = agencycode;
        //Session["dateto"] = dateto;
        //Session["frmdt"] = frmdt;
        //Session["client"] = client;
        //Session["adtype"] = adtype;

        Session["invoice"] = invoice_no;
        Session["billing_checkradio"] = chkradio;
        //Session["hiddensession"] = hiddenbillstatus;



    }

}
