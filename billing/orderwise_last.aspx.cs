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

public partial class orderwise_last : System.Web.UI.Page
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
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        Ajax.Utility.RegisterTypeForAjax(typeof(orderwise_last));

        hiddendateformat.Value = Session["dateformat"].ToString();
        add_string = "bill_genrate";
        retainer_name=Request.QueryString["retainer_name"].ToString();
        executive_name=Request.QueryString["executive_name"].ToString();
        branch_name=Request.QueryString["branch_name"].ToString();
        
        ad_category=Request.QueryString["ad_category"].ToString();
        district=Request.QueryString["district_code"].ToString();
        taluka=Request.QueryString["taluka_code"].ToString();
        bill_no = Request.QueryString["bill_no"].ToString();



        gaudtformat.Value = dtformat = Request.QueryString["dtformat"].ToString();
        gautodate.Value = todate = Request.QueryString["todate"].ToString();
        gaufromdt.Value = fromdt = Request.QueryString["fromdt"].ToString();
        gaupub.Value = pub = Request.QueryString["pub"].ToString();
        gaubkcen.Value = bkcen = Request.QueryString["bkcen"].ToString();
        gaurev.Value = rev = Request.QueryString["rev"].ToString();
        gauagtype.Value = agtype = Request.QueryString["agtype"].ToString();
        gaupckg.Value = pckg = Request.QueryString["pckg"].ToString();
        gauadtyp.Value =  adtyp = Request.QueryString["adtyp"].ToString();
        gauag.Value = ag = Request.QueryString["ag"].ToString();
        gauclient.Value = client = Request.QueryString["client"].ToString();
        gaubillstate.Value = billstate = Request.QueryString["billstate"].ToString();
        gaurtaudit.Value = rtaudit = Request.QueryString["rtaudit"].ToString();
        gaublmod.Value = blmod = Request.QueryString["blmod"].ToString();
        gaublcycle.Value = blcycle = Request.QueryString["blcycle"].ToString();
        Session["pcentername"] = Request.QueryString["bookingcentername"].ToString();
      //***********************for kathmandu*****************************
        Session["pcenter"] = gaubkcen.Value;
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
          dz = checkform.formpermission(Session["compcode"].ToString (), Session["userid"].ToString (), formname);

      }
      else
      {
          NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
          dz = checkform.formpermission(Session["compcode"].ToString (), Session["userid"].ToString (), formname);


      }
      string id = "";
      if (dz.Tables[0].Rows.Count > 0)
      {
          id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
      }

    //  id = "15";

      chk_idstatus.Value = id;


        DataSet ds1 = new DataSet();
        hiddenadtype.Value = adtyp.ToString();

        if (!IsPostBack)
        {
            btngenrate.Attributes.Add("onclick", "javascript:return checkboxidbillgen();");
            btnprint.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
           // btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillpreview();");

            btnprv.Attributes.Add("onclick", "javascript:return checkboxidbillreprint();");
            Button1.Attributes.Add("onclick", "javascript:return openbilling();");
            btn_mail.Attributes.Add("onclick", "javascript:return printpdf();");
            btn_printletter.Attributes.Add("onclick", "javascript:return printletter();");

        }
        if (adtyp == "DI0")
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();
                ds1 = abc.maxdate(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["DISP_CASHBILL"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_DISP_CASHBILL"].ToString(), Session["center"].ToString(), Session["ROWISE_CASHBOOKING"].ToString(), bill_no);

            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
               // ds1 = abc.MAXDATE1(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

                //ds1 = abc.maxdatenew(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString());
                ds1 = abc.maxdate_latest(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["DISP_CASHBILL"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_DISP_CASHBILL"].ToString(), Session["center"].ToString(), Session["ROWISE_CASHBOOKING"].ToString(), bill_no);
                

            }

            Session["RowLendisplay"] = ds1.Tables[0].Rows.Count;


            hidden1.Value = Session["RowLendisplay"].ToString();
            hiddenfromdate.Value = fromdt;
            hiddendateto.Value = todate;
            hiddenclient.Value = client.ToString();
            hiddencheck.Value = adtyp;


            if (hidden1.Value == "0")
            {


                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last), "sa", "alert(\"searching criteria is not valid\");", true);
                Button1.Visible = false;
                btnprv.Visible = false;
                btngenrate.Visible = false;
                btnprint.Visible = false;
                btn_mail.Visible = false;
                btn_printletter.Visible = false;
                
                return;
               // DataGrid3.DataSource = ds1;
               // DataGrid3.DataBind();
               //// ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last), "cc", "checklenthbillcla()", true);
              //  return;



            }


            else
            {
                if ((billstate == "3")||(billstate == "5"))
                {

                    if ((id == "15") || (id == "7"))
                    {
                        btnprv.Visible = true;
                        btngenrate.Visible = true;

                        btnprint.Visible = false;
                        Button1.Visible = false;
                        btn_mail.Visible = false;
                        btn_printletter.Visible = false;
                    }
                    else
                    {
                        btnprv.Visible = true;

                       // btngenrate.Enabled = false;
                        btnprint.Visible = false;
                       Button1.Visible = false;
                        btn_mail.Visible = false;
                        btn_printletter.Visible = false;
                    }

                }
                else
                {

                    Button1.Visible = false;
                    btnprv.Visible = false;
                    txtdate.Visible = false;
                    btngenrate.Visible =false;
                    btnprint.Visible = true;
                    btn_mail.Visible = true;
                    btn_printletter.Visible = true;
                }
                DataGrid3.DataSource = ds1;
                DataGrid3.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last), "cc", "checkvisiblecla()", true);
                return;
            }
        }
        else
        {
                       
            
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();

                ds1 = abc.maxdate(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["DISP_CASHBILL"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_DISP_CASHBILL"].ToString(), Session["center"].ToString(), Session["ROWISE_CASHBOOKING"].ToString(), bill_no);

            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
                //ds1 = abc.MAXDATE1(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

              //  ds1 = abc.maxdatenew(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

            //  ds1 = abc.maxdatenew(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString());
                ds1 = abc.maxdate_latest(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString(), Session["DISP_CLSBILL"].ToString(), retainer_name, executive_name, branch_name, ad_category, district, taluka, Session["DISP_CASHBILL"].ToString(), Session["FMG_BILL_DIS"].ToString(), Session["BILL_DISP_CASHBILL"].ToString(), Session["center"].ToString(), Session["ROWISE_CASHBOOKING"].ToString(), bill_no);


            }

            Session["RowLendisplay"] = ds1.Tables[0].Rows.Count;


            hidden1.Value = Session["RowLendisplay"].ToString();
            hiddenfromdate.Value = fromdt;
            hiddendateto.Value = todate;
            hiddenclient.Value = client.ToString();
            hiddencheck.Value = adtyp;


            if (hidden1.Value == "0")
            {

                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last), "sa", "alert(\"searching criteria is not valid\");", true);
                Button1.Visible = false;
                btnprv.Visible = false;
                btngenrate.Visible = false;
                btnprint.Visible = false;
                btn_mail.Visible = false;
                btn_printletter.Visible = true;
                return;


            }


            else
            {
                if ((billstate == "3") || (billstate == "5"))
                {
                    btnprv.Visible = true;
                    btngenrate.Visible = true;
                    btn_mail.Visible = false;
                    btnprint.Visible = false;
                   Button1.Visible = false;
                    btn_printletter.Visible = false;

                }
                else
                {
                    Button1.Visible = false;
                    btnprv.Visible = false;
                    btngenrate.Visible = false;
                    btnprint.Visible = true;
                    btn_mail.Visible = false;
                    btn_printletter.Visible = false;

              

                }
                DataGrid3.DataSource = ds1;
                DataGrid3.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(orderwise_last), "cc", "checkvisiblecla()", true);
                return;
            }
        }
        }


    
   
    protected void DataGrid3_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void DataGrid3_ItemDataBound(object sender, DataGridItemEventArgs e)
    {


        if (billstate != "2")
        {

            if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
            {
                if (e.Item.Cells[6].Text != e.Item.Cells[7].Text)
                {
                    e.Item.Cells[9].Enabled = true;

                }


            }
        }


        //if (billstate == "3")
        //{
        //    if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
        //    {

        //        string bill_status = e.Item.Cells[7].Text;
        //        string[] bill_statusq = bill_status.Split('-');
        //        if (bill_statusq[0] == "N")
        //        {
        //            e.Item.Cells[7].Text = "N";
        //            e.Item.Enabled = false;
        //            e.Item.Cells[8].Text = bill_statusq[1].ToString();
        //        }
        //        else
        //        {
        //            e.Item.Cells[7].Text = "y";
        //            e.Item.Cells[8].Text = bill_statusq[1].ToString();
        //        }
        //    }

        //}
        //else
        //    if (billstate == "2")
        //    {
        //        e.Item.Cells[8].Visible = false;
        //        if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
        //        {
        //            e.Item.Cells[7].Text = "Billed";



        //        }
        //    }

        //    else
        //        if (billstate == "5")
        //        {
        //            e.Item.Cells[8].Visible = false;
        //            if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
        //            {
        //                e.Item.Cells[7].Text = "Publish";



        //            }
        //        }

        //        else
        //            if (billstate== "6")
        //            {
        //                e.Item.Cells[8].Visible = false;
        //                if ((e.Item.Cells[0].Text != "Cio_Booking_Id") && (e.Item.Cells[0].Text != "&nbsp;"))
        //                {
        //                    e.Item.Cells[7].Text = "Booked";



        //                }
        //            }



    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast(string cioid, string checkradio, string insertion, string edition,string agencycode,string dateto,string frmdt,string client,string adtype,string invoice_no,string hiddenbillstatus)
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
        Session["bill_date"] = txtdate.Text; 
      


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast_gen(string ciobookid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string adtype, string bill, string hiddenbillstatus, string bill_date)
    {
        Session["billing_cioid"] = ciobookid;
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
        Session["bill_date"] = bill_date;



    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionlast_priev(string cioid, string checkradio, string insertion, string agencycode, string dateto, string frmdt, string client, string adtype,  string hiddenbillstatus)
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
    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //   // ds1 = abc.maxdate(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

    //    Response.Redirect("bill_summary_last.aspx?dtformat=" + dtformat + "&todate=" + todate + "&fromdt=" + fromdt + "&pub=" + pub + "&bkcen=" + bkcen + "&rev=" + rev + "&agtype=" + agtype + "&pckg=" + pckg + "&adtyp=" + adtyp + "&ag=" + ag + "&client=" + client + "&billstate=" + billstate + "&rtaudit=" + rtaudit + "&blmod=" + blmod + "&blcycle=" + blcycle);
       

    //}
}
