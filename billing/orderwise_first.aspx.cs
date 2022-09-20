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

public partial class orderwise_first : System.Web.UI.Page
{
  
    string client = "";
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
    string formname = "";
    string add_string = "";
    string bill_no = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(orderwise_first));


        hiddendateformat.Value = Session["dateformat"].ToString();
        retainer_name = Request.QueryString["retainer_name"].ToString();
        executive_name = Request.QueryString["executive_name"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();
        
        ad_category = Request.QueryString["ad_category"].ToString();
        district = Request.QueryString["district_code"].ToString();
        taluka = Request.QueryString["taluka_code"].ToString();

        dtformat = Request.QueryString["dtformat"].ToString();
        todate = Request.QueryString["todate"].ToString();
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
        gaubillstate.Value =  Request.QueryString["billstate"].ToString();
        gaurtaudit.Value =  Request.QueryString["rtaudit"].ToString();
        blmod = Request.QueryString["blmod"].ToString();
        blcycle = Request.QueryString["blcycle"].ToString();
        bill_no = Request.QueryString["bill_no"].ToString();
        add_string = "bill_genrate";
        gautodate.Value  = Request.QueryString["todate"].ToString();
        Session["pcentername"] = Request.QueryString["bookingcentername"].ToString();
        //***********************for kathmandu*****************************
        Session["pcenter"] = bkcen;
        //***********************for kathmandu*****************************

        if (hiddendateformat.Value == "mm/dd/yyyy")
            {
                string da = Convert.ToString(DateTime.Today.Day);
                if (da.Length == 1)
                {
                    da = "0" + da;
                }
                string mon = Convert.ToString(DateTime.Today.Month);
                if (mon.Length == 1)
                {
                    mon = "0" + mon;
                }
                HDN_server_date.Value = mon + "/" + da + "/" + DateTime.Today.Year;

            }
        else if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                string da = Convert.ToString(DateTime.Today.Day);
                if (da.Length == 1)
                {
                    da = "0" + da;
                }
                string mon = Convert.ToString(DateTime.Today.Month);
                if (mon.Length == 1)
                {
                    mon = "0" + mon;
                }

                HDN_server_date.Value = da + "/" + mon + "/" + DateTime.Today.Year;
            }
            else
            {

                string da = Convert.ToString(DateTime.Today.Day);
                if (da.Length == 1)
                {
                    da = "0" + da;
                }
                string mon = Convert.ToString(DateTime.Today.Month);
                if (mon.Length == 1)
                {
                    mon = "0" + mon;
                }

                HDN_server_date.Value = DateTime.Today.Year + "/" + mon + "/" + da;
            }

            txtdate.Text = HDN_server_date.Value;
       
      
        //*****************************************************
            formname = "billing";
            DataSet dz = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
                dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);

            }
            else
            {
                NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
                dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);


            }
            string id = "";
            if (dz.Tables[0].Rows.Count > 0)
            {
                id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            }

            //  id = "15";

            chk_idstatus.Value = id;


        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        hiddenadtype.Value = adtyp.ToString();

        if (!IsPostBack)
        {
            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");
            btn_mail.Attributes.Add("onclick", "javascript:return printpdf();");
        }
        if (adtyp == "DI0")
        {


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                ds1 = abc.websp_bookclassified1(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds1 = abc.websp_bookclassified(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, retainer_name, executive_name, branch_name, ad_category, district, taluka,"","");

            }


            Session["RowLendisplay"] = ds1.Tables[0].Rows.Count;


            hidden1.Value = Session["RowLendisplay"].ToString();
            hiddenfromdate.Value = fromdt;
            hiddendateto.Value = todate;
            hiddenclient.Value = client.ToString();
            hiddencheck.Value = adtyp;


            if (hidden1.Value == "0")
            {
                DataGrid2.DataSource = ds1;
                DataGrid2.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_first), "cc", "checklenthbillcla()", true);
                Response.Write("<script>window.close();</script>");
                return;



            }


            else
            {
                if ((billstate == "3") || (billstate == "5"))
                {
                    Button1.Visible = false;
                    btn_mail.Visible = false;
                    btnprv.Visible = true;
                    btngenrate.Visible = true;
                    btnprint.Visible = false;

                }
                else
                    if (billstate == "6")
                    {
                        Button1.Visible = false;
                        btn_mail.Visible = false;
                        btnprv.Visible = false;
                        btngenrate.Visible = false;
                        btnprint.Visible = false;

                    }
                    else
                        if (billstate == "2")
                        {
                            txtdate.Visible = false;
                            Button1.Visible = false;
                            btn_mail.Visible = false;
                            btnprv.Visible = false;
                            btngenrate.Visible = false;
                            btnprint.Visible = true;
                        }
                DataGrid2.DataSource = ds1;
                DataGrid2.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_first), "cc", "checkvisiblecla()", true);
              //  Response.Write("<script>window.close();</script>");
                return;
            }





        }

        else
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                ds1 = abc.websp_bookclassified1(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds1 = abc.websp_bookclassified(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, retainer_name, executive_name, branch_name, ad_category, district, taluka,"","");

            }


            Session["RowLendisplay"] = ds1.Tables[0].Rows.Count;


            hidden1.Value = Session["RowLendisplay"].ToString();
            hiddenfromdate.Value = fromdt;
            hiddendateto.Value = todate;
            hiddenclient.Value = client.ToString();
            hiddencheck.Value = adtyp;


            if (hidden1.Value == "0")
            {
                DataGrid2.DataSource = ds1;
                DataGrid2.DataBind();
             //   Response.Write("<script>alert('Seaching criteria does not produce any result');</script>");
               ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_first), "cc", "checklenthbillcla()", true);

              //  Response.Write("<script>window.close();</script>");
                //Response.Redirect("billing.aspx");



            }


            else
            {
                if ((billstate == "3") || (billstate == "5"))
                {


                    Button1.Visible = false;
                    btnprv.Visible = true;
                    btngenrate.Visible = true;
                    btnprint.Visible = false;
                    btn_mail.Visible = false;

                }
                else
                    if (billstate == "6")
                    {
                        Button1.Visible = false;
                        btnprv.Visible = false;
                        btngenrate.Visible = false;
                        btnprint.Visible = false;
                        btn_mail.Visible = false;

                    }
                    else
                        if (billstate == "2")
                        {
                            txtdate.Visible = false;
                            Button1.Visible = false;
                            btnprv.Visible = false;
                            btngenrate.Visible = false;
                            btnprint.Visible = true;
                            btn_mail.Visible = false;
                        }
                DataGrid2.DataSource = ds1;
                DataGrid2.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_first), "cc", "checkvisiblecla()", true);
                return;
            }





        }


    }

    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        e.Item.Cells[4].Visible = false;
        DataSet ds1 = new DataSet();
        hidden1.Value = Session["RowLendisplay"].ToString();

        string check = e.Item.Cells[6].Text;
        string comm = e.Item.Cells[7].Text;
        double comm1 = 0;


        if (comm == "&nbsp;")
        {
            comm1 = 0;
        }




        if (check != "GrossAmount")
        {
            if (check != "&nbsp;")
            {


                string grossamt = e.Item.Cells[6].Text;
                comm = e.Item.Cells[7].Text;
                double gm = Convert.ToDouble(grossamt);
                if (comm == "&nbsp;")
                {
                    comm1 = Convert.ToDouble(comm1);
                }
                else
                {
                    comm1 = Convert.ToDouble(comm);

                }

                double netamt = gm - ((gm * comm1) / 100);
                e.Item.Cells[8].Text = netamt.ToString();



                ////

              /*  if (e.Item.Cells[9].Text == "billed")
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                        ds1 = fetchinvoice.selectinvoicefmclassi(e.Item.Cells[0].Text, e.Item.Cells[5].Text);
                        e.Item.Cells[1].Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                       // NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        //ds1 = fetchinvoice.selectinvoicefmclassi(e.Item.Cells[0].Text, e.Item.Cells[5].Text);
                        //e.Item.Cells[1].Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

                    }

                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                        ds1 = fetchinvoice.selectprintcount(e.Item.Cells[0].Text, e.Item.Cells[5].Text);
                        e.Item.Cells[11].Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
                        // ds1 = fetchinvoice.selectprintcount(e.Item.Cells[0].Text, e.Item.Cells[5].Text);
                        // e.Item.Cells[11].Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

                    }

                }
                */
            }








        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // ds1 = abc.maxdate(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

        Response.Redirect("billing_summary_first.aspx?dtformat=" + dtformat + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + pub + "&bkcen=" + bkcen + "&rev=" + rev + "&agtype=" + agtype + "&pckg=" + pckg + "&adtyp=" + adtyp + "&ag=" + ag + "&client=" + client + "&billstate=" + billstate + "&rtaudit=" + rtaudit + "&blmod=" + blmod + "&blcycle=" + blcycle);


    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionfirst(string cioid, string checkradio, string insertion, string edition, string agencycode, string dateto, string frmdt, string client, string bill, string bill_date)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;     

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
        Session["bill"] = bill;
        //for kathmandu
        Session["bill_date"] = bill_date;
      




    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionfirstpr(string cioid, string checkradio, string insertion,  string agencycode, string dateto, string frmdt, string client, string invoice_no)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
        Session["invoice"] = invoice_no;





    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionfirst_priev(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
      





    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionIns_gen(string ciobookid, string checkradio, string insertion, string dateto, string frmdt, string client, string adtype, string bill, string hiddenbillstatus, string todate_v, string edition, string spl_dis, string trade_dis, string aa, string rborg)
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
    public void setSessionlast(string cioid, string checkradio, string insertion, string edition, string agencycode, string dateto, string frmdt, string client, string adtype, string invoice_no, string hiddenbillstatus)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        //

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
        Session["adtype"] = adtype;

        Session["invoice"] = invoice_no;
        Session["hiddensession"] = hiddenbillstatus;



    }

}