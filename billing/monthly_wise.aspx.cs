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

public partial class monthly_wise : System.Web.UI.Page
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
    int i;
    string bill_no = "";
    string fromdate_new = "";
    string todate_new = "";
    string formname = "";
    string add_string = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(monthly_wise));
    

        retainer_name = Request.QueryString["retainer_name"].ToString();
        executive_name = Request.QueryString["executive_name"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();

        ad_category = Request.QueryString["ad_category"].ToString();
        district = Request.QueryString["district_code"].ToString();
        taluka = Request.QueryString["taluka_code"].ToString();
        bill_no = Request.QueryString["bill_no"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();


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
        blmod = Request.QueryString["blmod"].ToString();
        blcycle = Request.QueryString["blcycle"].ToString();
        Session["blcycle"] = blcycle;
        fromdate_new = Request.QueryString["fromdt"].ToString();
        todate_new = Request.QueryString["todate"].ToString();
        gaubillstate.Value = Request.QueryString["billstate"].ToString();
        gaurtaudit.Value = Request.QueryString["rtaudit"].ToString();
        add_string = "bill_genrate";
        gautodate.Value = Request.QueryString["todate"].ToString();
        Session["pcentername"] = Request.QueryString["bookingcentername"].ToString();

        Session["pcenter"] = bkcen;

     
        
        
        DataSet ds1 = new DataSet();

        hiddenadtype.Value = adtyp.ToString();

        if (!IsPostBack)
        {

            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");
            btn_mail.Attributes.Add("onclick", "javascript:return printpdf();");
            btn_printletter.Attributes.Add("onclick", "javascript:return checkboxidbillreprint_cover();");


        }

        Session["BILL_ORDERWSLAST"] = "agencywise";

        
        if (Session["BILL_ORDERWSLAST"].ToString() == "agencywise")
        {

            //, fromdate_new, todate_new
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();
                ds1 = abc.mothly_billing(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), executive_name, retainer_name, ad_category, district, taluka, Session["CLA_CASHBILL"].ToString(), Session["BILL_CLA_CASHBILL"].ToString(), Session["center"].ToString(), bill_no , fromdate_new,todate_new);

            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds1 = abc.mothly_billingnew(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString());

            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();
                ds1 = abc.mothly_billingnew(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), executive_name, retainer_name, ad_category, district, taluka, Session["CLA_CASHBILL"].ToString(), Session["BILL_CLA_CASHBILL"].ToString (), Session["center"].ToString(),   bill_no);

            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds1 = abc.mothly_billingnew_retainer(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), executive_name, retainer_name, ad_category, district, taluka, Session["CLA_CASHBILL"].ToString(), Session["BILL_CLA_CASHBILL"].ToString (), Session["center"].ToString(),   bill_no);

            }
        }


        Session["RowLendisplay"] = ds1.Tables[0].Rows.Count;


        hidden1.Value = Session["RowLendisplay"].ToString();
        if (fromdt == "01/01/2000")
        {
            hiddenfromdate.Value = fromdate_new.ToString ();
            hiddendateto.Value = todate_new.ToString();
        }
        else
        {
            hiddenfromdate.Value = fromdt;
            hiddendateto.Value = todate;
        }
        hiddenclient.Value = client.ToString();
        hiddencheck.Value = adtyp;


        if (hidden1.Value == "0")
        {
            DataGrid2.DataSource = ds1;
            DataGrid2.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, typeof(monthly_wise), "cc", "checklenthbillcla()", true);
            return;



        }


        else
        {
            if ((billstate == "3") || (billstate == "5") || (billstate == "6"))
            {
                btn_mail.Visible = false;
                btnprint.Visible = false;
                btnprv.Visible = true;
                btngenrate.Visible = true;
                Button1.Visible = false;
                btn_printletter.Visible = false;



            }

            if (billstate == "2")
            {

                btn_printletter.Visible = true;
                btn_mail.Visible = true;
                btnprint.Visible = true;
                btnprv.Visible = false;
                btngenrate.Visible = false;
                Button1.Visible = false;

            }

            DataGrid2.DataSource = ds1;
            DataGrid2.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, typeof(monthly_wise), "cc", "checkvisiblecla()", true);
            return;
        }


    }

    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
       
     




    }
    protected void DataGrid2_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        if (billstate == "2")
        {
            e.Item.Cells[2].Visible = false;
            e.Item.Cells[3].Visible = false;
            e.Item.Cells[4].Visible = false;
            e.Item.Cells[5].Visible = false;


        }


        if (billstate == "3" || billstate == "5")
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                string chk = e.Item.Cells[2].Text;

                if (chk == "0")
                {
                    e.Item.Cells[13].Enabled = false;
                }
                string chk_un = e.Item.Cells[3].Text;
                if ((chk != "0") && (chk_un == "0"))
                {
                    e.Item.Cells[13].Enabled = true;
                }
                else
                {
                    e.Item.Cells[13].Enabled = true ;
                }


            }
        }
        else
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                string chk = e.Item.Cells[6].Text;

                if (chk == "0")
                {
                    e.Item.Cells[13].Enabled = true;
                }
            }
        }
        if (billstate == "3" || billstate == "5")
        {
           e.Item.Cells[9].Visible = false;
           e.Item.Cells[6].Visible = false;
           e.Item.Cells[7].Visible = false;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.Cells[3].Text != "&nbsp;")
                {
                    // e.Item.Cells[0].Text = "<img src=\"images/flag.gif\" ></img>";
                }
                string bookingid = e.Item.Cells[7].Text;
                e.Item.Cells[3].Text = "<a  style=\"cursor:hand;color:blue\" onClick=\"openbooking('" + e.Item.Cells[5].Text + "','')\">" + e.Item.Cells[3].Text + "</a>";
                i = i + 1;
            }

            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    if (e.Item.Cells[2].Text != "&nbsp;")
            //    {
            //        // e.Item.Cells[0].Text = "<img src=\"images/flag.gif\" ></img>";
            //    }
            //    string chk = e.Item.Cells[2].Text;
            //    if (chk == "0")
            //    {
            //        e.Item.Cells[2].Enabled = false;
            //    }
                
            //}



        }

       


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // ds1 = abc.maxdate(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

        Response.Redirect("billing_summary_monthly.aspx?dtformat=" + dtformat + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + pub + "&bkcen=" + bkcen + "&rev=" + rev + "&agtype=" + agtype + "&pckg=" + pckg + "&adtyp=" + adtyp + "&ag=" + ag + "&client=" + client + "&billstate=" + billstate + "&rtaudit=" + rtaudit + "&blmod=" + blmod + "&blcycle=" + blcycle);


    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]	
      public void setSessionmonthly_preview (string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string adtype, string hiddenbillstatus)
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

    public void setSessionmonthly(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string bill, string hiddenbillstatus)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        //

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;


        Session["bill"] = bill;
        Session["hiddensession"] = hiddenbillstatus;



    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmonthly_pr(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string bill, string hiddenbillstatus)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        //

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;


        Session["invoice"] = bill;
        Session["hiddensession"] = hiddenbillstatus;



    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmonthly_cover(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string bill, string hiddenbillstatus)
    {
        Session["billing_cioid"] = cioid;
        Session["billing_checkradio"] = checkradio;
        Session["billing_insertion"] = insertion;
        //

        Session["agencycode"] = agencycode;
        Session["dateto"] = dateto;
        Session["frmdt"] = frmdt;
        Session["client"] = client;


        Session["invoice"] = bill;
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
