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

public partial class orderwise_last_supp : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {

        Ajax.Utility.RegisterTypeForAjax(typeof(orderwise_last_supp));

        dtformat = Request.QueryString["dtformat"].ToString();
        todate = Request.QueryString["todate"].ToString();
        gautodate.Value = todate = Request.QueryString["todate"].ToString();
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
        gaubillstate.Value = billstate = Request.QueryString["billstate"].ToString();
        gaurtaudit.Value = rtaudit = Request.QueryString["rtaudit"].ToString();
        blmod = Request.QueryString["blmod"].ToString();
        blcycle = Request.QueryString["blcycle"].ToString();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        hiddenadtype.Value = adtyp.ToString();

        if (!IsPostBack)
        {
            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");

        }
        if (adtyp == "DI0")
        {


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                // ds1 = abc.websp_bookclassified1(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds1 = abc.websp_bookclassifiedlast_bill(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod);

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
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last_supp), "cc", "checklenthbillcla()", true);
                return;



            }


            else
            {
                if ((billstate == "2") || (billstate == "5"))
                {
                    btnprv.Visible = true;
                    btngenrate.Visible = true;
                    btnprint.Visible = false;

                }
                else
                {
                    btnprv.Visible = false;
                    btngenrate.Visible = false;
                    btnprint.Visible = true;
                }
                DataGrid2.DataSource = ds1;
                DataGrid2.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last_supp), "cc", "checkvisiblecla()", true);
                return;
            }





        }

        else
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                //  ds1 = abc.websp_bookclassified1(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds1 = abc.websp_bookclassifiedlast_bill(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod);

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
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last_supp), "cc", "checklenthbillcla()", true);
                return;



            }


            else
            {
                if ((billstate == "2") || (billstate == "5"))
                {
                    btnprv.Visible = true;
                    btngenrate.Visible = true;
                    btnprint.Visible = false;


                }
                else
                {
                    btngenrate.Visible = false;
                    btnprv.Visible = false;
                    btnprint.Visible = true;

                }
                DataGrid2.DataSource = ds1;
                DataGrid2.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last_supp), "cc", "checkvisiblecla()", true);
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

                if (e.Item.Cells[9].Text == "billed")
                {
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.BillingClass.Classes.billing_save fetchinvoice = new NewAdbooking.BillingClass.Classes.billing_save();
                        ds1 = fetchinvoice.selectinvoicefmclassi(e.Item.Cells[0].Text, e.Item.Cells[5].Text);
                        e.Item.Cells[1].Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        NewAdbooking.BillingClass.classesoracle.billing_save fetchinvoice = new NewAdbooking.BillingClass.classesoracle.billing_save();
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

            }








        }


    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast(string cioid, string checkradio, string insertion, string edition, string agencycode, string dateto, string frmdt, string client, string adtype, string invoice_no, string hiddenbillstatus, string trade_dis)
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

        Session["trade_disc"] = trade_dis;




    }




    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast_pr(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string adtype, string bill, string hiddenbillstatus)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        //

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
        Session["adtype"] = adtype;

        Session["bill"] = bill;
        Session["hiddensession"] = hiddenbillstatus;



    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast_priev(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string adtype, string hiddenbillstatus)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        //

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;
        Session["adtype"] = adtype;

        Session["hiddensession"] = hiddenbillstatus;



    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast_cover(string cioid, string checkradio, string insertion, string edition, string agencycode, string dateto, string frmdt, string client, string adtype, string invoice_no, string hiddenbillstatus)
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
}