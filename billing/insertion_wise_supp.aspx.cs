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

public partial class insertion_wise_supp : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(insertion_wise_supp));


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

        if (!IsPostBack)
        {
            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");
            btn_mail.Attributes.Add("onclick", "javascript:return printpdf();");

        }
         






        string agencycod = ag.ToString();
        string clientcode = client.ToString();


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




        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        if (adtyp == "DI0")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save_supp abc = new NewAdbooking.BillingClass.Classes.billing_save_supp();

                ds = abc.websp_bindciobookingid(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds = abc.websp_bindciobookingid_bill(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle);

            }



            Session["RowLen"] = ds.Tables[0].Rows.Count;
            hidden1.Value = Session["RowLen"].ToString();
            if (hidden1.Value == "0")
            {
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                ScriptManager.RegisterClientScriptBlock(this, typeof(insertion_wise_supp), "cc", "checklenthbill()", true);
                btnprv.Visible = false;
                btngenrate.Visible = false;
                btnprint.Visible = false;

                return;



            }


            else
            {

                //if ((billstate == "3") || (billstate == "5"))
                //{
                //    btnprv.Visible = true;
                //    btngenrate.Visible = true;
                //    btnprint.Visible = false;

                //}
                //else
                //{

                    //btnprv.Visible = false;
                if (billstate == "2")
                {
                    btngenrate.Visible = true;
                    btnprv.Visible = false;
                    btnprint.Visible = false;
                    btn_mail.Visible = false;
                }
                else
                {
                    btngenrate.Visible = false;
                    btnprv.Visible = false;
                    btnprint.Visible = true;
                    btn_mail.Visible = false;
                }

                   // btnprint.Visible = true;
                //}



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

                NewAdbooking.BillingClass.Classes.billing_save_supp abc = new NewAdbooking.BillingClass.Classes.billing_save_supp();

                ds = abc.websp_bindciobookingid(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString(), Session["BILL_GENERATION_PRIOR"].ToString(), Session["PUBLICATION_HO"].ToString(), bill_no, Session["center"].ToString(), Session["FMG_BILL_DIS"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds = abc.websp_bindciobookingid_bill(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle);

            }



            Session["RowLen"] = ds.Tables[0].Rows.Count;
            hidden1.Value = Session["RowLen"].ToString();
            if (hidden1.Value == "0")
            {
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                ScriptManager.RegisterClientScriptBlock(this, typeof(insertion_wise_supp), "cc", "checklenthbill()", true);
                btnprv.Visible = false;
                btngenrate.Visible = false;
                btnprint.Visible = false;
                btn_mail.Visible = false;

                return;



            }


            else
            {

                //if (billstate == "3")
                //{
                //    btnprv.Visible = false;
                //    btngenrate.Visible = true;
                //    btnprint.Visible = false;
                //    btn_mail.Visible = false;

                //}
                //else
                //{

                //    btnprv.Visible = false;
                //    btngenrate.Visible = false;
                //    btnprint.Visible = true;
                //    btn_mail.Visible = false;
                //}


                if (billstate == "2")
                {
                    btngenrate.Visible = true;
                }
                else
                {
                    btnprint.Visible = true;
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


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSession_preview(string cioid, string checkradio, string insertion, string edition)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSession(string cioid, string checkradio, string insertion, string edition, string bill, string spl_dis, string trade_dis, string todate_v)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        Session["billing_bill"] = bill;
        Session["spl_dis"] = spl_dis;
        Session["trade_dis"] = trade_dis;
        Session["billing_todate_v"] = todate_v;

    }







    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionre(string cioid, string checkradio, string insertion, string edition, string invoice_no, string spl_dis, string trade_dis)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        Session["billing_edition"] = edition;
        Session["invoice"] = invoice_no;
        Session["spl_dis"] = spl_dis;
        Session["trade_dis"] = trade_dis;
  

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void settempdata(string cioid, string publish, string insertion, string bill_cycle, string datefrom, string dateto)
    {
        string[] countbookid1 = cioid.Split(',');
        string bill_process_id = "1";
        string[] insert1 = insertion.Split(',');
        string[] pubdate = publish.Split(',');
        int c1 = countbookid1.Length;
        for (int i = 0; i < c1; i++)
        {
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save_supp abc = new NewAdbooking.BillingClass.Classes.billing_save_supp();

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
    public void billpross(string bill_cycle, string datefrom, string dateto, string adtype)
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

            NewAdbooking.BillingClass.Classes.billing_save_supp abc = new NewAdbooking.BillingClass.Classes.billing_save_supp();

            ds1 = abc.billproces(Session["compcode"].ToString(), bill_cycle, datefrom, dateto, bill_process_id, Session["userid"].ToString(), Session["dateformat"].ToString(), adtype);
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();

            //ds1 = abc.settemprec(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["compcode"].ToString());

        }
        //}
    }

    protected void btnprv_Click(object sender, EventArgs e)
    {

    }
}
