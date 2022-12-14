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

public partial class rate_audit_orderwise : System.Web.UI.Page
{

    int i = 0;
    int sno = 1;
    protected void Page_Load(object sender, EventArgs e)
    {




        Response.Expires = -1;
        DataGrid1.Visible = true;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
       hiddenDateFormat.Value = Session["DateFormat"].ToString();
    
        hiddenusername.Value = Session["Username"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();

        hiddenrtaudit_audit.Value = Session["rate_audit"].ToString();
        //  hiddenadcategory.Value = drpadtype.SelectedValue;

        hiddenserverip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(rate_audit_orderwise));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Booking_Audit1.xml"));
        lblvfrm.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblvalidtill.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //lblagenysubcode.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblagreedrate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //lbladdress1.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lbladdress2.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblagreedamount.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        //lblstatus.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpaymode.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpublichdate.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lblcredit.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbldiscount.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblrono.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblnoofinsertion.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lblpositionpremium.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lblrostatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //lblkeyno.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblpaid.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lblspecialdiscount.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        //lblexezone.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lblexecutivename.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lblcontractname.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lblspacediscount.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lbloutstanding.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        //lblbrand.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lblheight.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        //lblproduct.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblspecialcharge.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lblretainername.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
        lbllines.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
        lbladdagecomm.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        //lblnocolumns.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lblbookingtype.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        lblpageposition.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lblgrossamt.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        //lblcurrency.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lblcolourtype.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lblpositionpre1.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lblretainercommission.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
        lbladcategory.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lblarea.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lblagtradediscount.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
        lbladsubcat1.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
        lblschemetype.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString();
        lblbillamount.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbladsubcat2.Text = ds.Tables[0].Rows[0].ItemArray[38].ToString();
        lblratecode.Text = ds.Tables[0].Rows[0].ItemArray[39].ToString();
        lbladsubcat3.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lblcardrate1.Text = ds.Tables[0].Rows[0].ItemArray[41].ToString();
        lbladsubcat4.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lblcardamount1.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        lblSumAmt.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        lblPagePrem.Text = ds.Tables[0].Rows[0].ItemArray[46].ToString();
        Label6.Text = ds.Tables[0].Rows[0].ItemArray[47].ToString();
        lblremarks.Text = ds.Tables[0].Rows[0].ItemArray[44].ToString();

        btnmodify.Enabled = false;


        if (!IsPostBack)
        {
            bindpub();
            publicationbind();
            bindbranch(hiddenuserid.Value);
            bindpayment(Session["compcode"].ToString());

            //bindagency();           
            //bindagecli();         
            //bindexecutive();
            //bindretainer();

            adtypedata(Session["compcode"].ToString());
            //  fillPubCenter(Session["compcode"].ToString());
            btnaudit.Attributes.Add("OnClick", "javascript:return checkboxid();");
            btnmodify.Attributes.Add("OnClick", "javascript:return openpage();");
            btnexit.Attributes.Add("OnClick", "javascript:return catexitclick();");

            //dppubcent.Attributes.Add("OnChange", "javascript:return filledition();");
            dppub1.Attributes.Add("OnChange", "javascript:return filledition();");
            dpedition.Attributes.Add("onchange", "javascript:return suppbind();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return checklenth();");
            ///
            //dpagencyna.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            //dpagencycli.Attributes.Add("onkeypress", "javascript:return keySort(this);");
           // dpretainer.Attributes.Add("onkeypress", "javascript:return keySort(this);");
           // dpexecutive.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            txtvalidityfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttilldate.Attributes.Add("OnChange", "javascript:return checkdate(this);");



            txtagency1.Attributes.Add("OnPaste", "return false");
            txtagency1.Attributes.Add("Ondrop", "return false");
            txtagency1.Attributes.Add("Ondrag", "return false");
            txtagency1.Attributes.Add("Oncut", "return false");
            txtagency1.Attributes.Add("OnCopy", "return false");

            txtclient1.Attributes.Add("OnPaste", "return false");
            txtclient1.Attributes.Add("Ondrop", "return false");
            txtclient1.Attributes.Add("Ondrag", "return false");
            txtclient1.Attributes.Add("Oncut", "return false");
            txtclient1.Attributes.Add("OnCopy", "return false");

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



            lstclient.Attributes.Add("onclick", "javascript:return insertclient();");       
            lstagency.Attributes.Add("onclick", "javascript:return insertagency(this.value);");
            lstretainer.Attributes.Add("onclick", "javascript:return fillmaingrp(this.value)");
            lstexecutive.Attributes.Add("onclick", "javascript:return fillexecutivegrp();");


        }

        txtagency.ReadOnly = true;
        txtratecode.ReadOnly = true;
        txtclient.ReadOnly = true;
        txtadsubcat4.ReadOnly = true;

        txtagtradediscount.ReadOnly = true;
        txtagreedamount.ReadOnly = true;
        txtarea.ReadOnly = true;
        txtagreedrate.ReadOnly = true;
        txtgrossamt.ReadOnly = true;
      
        txtcontractname.ReadOnly = true;
        txtaddagecomm.ReadOnly = true;
        txtpackage.ReadOnly = true;
        txtdiscount.ReadOnly = true;
        txtpageposition.ReadOnly = true;
        txtexecutivename.ReadOnly = true;
        txtlines.ReadOnly = true;
        txtbookingtype.ReadOnly = true;
        txtheight.ReadOnly = true;
        txtcolourtype.ReadOnly = true;

        txtwidth.ReadOnly = true;
        txtspecialdiscount.ReadOnly = true;
        txtdiscount.ReadOnly = true;
        txtagreedrate.ReadOnly = true;
        txtschemetype.ReadOnly = true;

        txtpaid.ReadOnly = true;
        txtpublishdate.ReadOnly = true;
        txtpositionpremium.ReadOnly = true;
        txtretainercommission.ReadOnly = true;
        txtadcategory.ReadOnly = true;
        txtadsubcat1.ReadOnly = true;
        txtuom.ReadOnly = true;
        txtoutstanding.ReadOnly = true;
        txtadsubcat2.ReadOnly = true;
        txtspecialcharge.ReadOnly = true;
        txtadsubcat3.ReadOnly = true;
        txtrono.ReadOnly = true;
        txtrostatus.ReadOnly = true;
        txtretainername.ReadOnly = true;
        txtpaymode.ReadOnly = true;
        txtnoofinsertion.ReadOnly = true;
        txtspacediscount.ReadOnly = true;
        txtbillamount.ReadOnly = true;

        txtremarks.ReadOnly = true;

        btnmodify.Enabled = false;


        //txtagencysubcode.Enabled = false;
        //txtagency.Enabled = false;
        //txtheight.Enabled = false;

        txtdiscountamt.ReadOnly = true;
        txtPagePrem.ReadOnly = true;
        txtPagePremamt.ReadOnly = true;
        txtpositionpremiumamt.ReadOnly = true;
        txtspecialdiscount.ReadOnly = true;
        txtspecialdiscountamt.ReadOnly = true;
        txtspacediscount.ReadOnly = true;
        txtspacediscountamt.ReadOnly = true;
        txtSumAmt.ReadOnly = true;
        txtretainercommissionamt.ReadOnly = true; 

        txtaddagecommamt.ReadOnly = true;
        txtcardrate1.ReadOnly = true;
        txtcardamount1.ReadOnly = true;

    }



    public void bindpayment(string compcode)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit bind = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = bind.paymode_bind(compcode);
        }
        else
        {

            NewAdbooking.BillingClass.classesoracle.updatestaus bind = new NewAdbooking.BillingClass.classesoracle.updatestaus();
            //ds = bind.paymode_bind(compcode);

        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        drp_paytype.Items.Clear();
        li1.Text = "-Select pay mode-";
        li1.Value = "0";
        li1.Selected = true;
        drp_paytype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drp_paytype.Items.Add(li);


        }

    }
    [Ajax.AjaxMethod]
    public DataSet fillEdition2(string publication, string pub_cent, string comp_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(publication, "0", comp_code);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 pub_cent2 = new NewAdbooking.classesoracle.Class1();
            ds = pub_cent2.edition(publication, pub_cent, comp_code);
        }
        return ds;



    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string revcenter = "";
        string edition = "";
        string branch = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.publish_audit abc = new NewAdbooking.BillingClass.Classes.publish_audit();
            if (drpbranch.SelectedValue == "0")
            {
                branch = "0";
            }
            else
            {
                branch = drpbranch.SelectedValue;
            }
            ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, hidden_agency.Value, hidden_client.Value, branch, hiddenretainer.Value, hdnexecutivetxt.Value, hiddensupplement.Value, drpstatus.SelectedValue, hiddenuserid.Value,drp_paytype.SelectedValue);

//            ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, dpagencyna.SelectedValue, dpagencycli.SelectedValue, branch, dpretainer.SelectedValue, dpexecutive.SelectedValue, hiddensupplement.Value, drpstatus.SelectedValue);
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.updatestaus abc = new NewAdbooking.BillingClass.classesoracle.updatestaus();

          
        
            if (drpbranch.SelectedValue == "0")
            {
                branch = "0";
            }
            else
            {
                branch = drpbranch.SelectedValue;
            }

            ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, hidden_agency.Value, hidden_client.Value, branch, hiddenretainer.Value, hdnexecutivetxt.Value, hiddensupplement.Value, drpstatus.SelectedValue,"","");

          
           // ds = abc.websp_bindgridorderwise(Session["dateformat"].ToString(), txttilldate.Text, txtvalidityfrom.Text, revcenter, drpadtype.SelectedValue, dppub1.SelectedValue, dppubcent.SelectedValue, hiddenedition.Value, dpagencyna.SelectedValue, dpagencycli.SelectedValue, branch, dpretainer.SelectedValue, dpexecutive.SelectedValue, hiddensupplement.Value, drpstatus.SelectedValue);

        }
        Session["RowLen"] = ds.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();
        if (hidden1.Value == "0")
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, typeof(rate_audit_orderwise), "cc", "checklenthnew()", true);
        }
        else
        {

            //DataRow 
            foreach (DataRow dr in ds.Tables [0].Rows)
            {
               string totalc= dr["TotalCount"].ToString();
               string PublishCount = dr["PublishCount"].ToString();

               if (totalc != PublishCount)
                {
            dr.Delete();
                }
            }
            ds.Tables[0].AcceptChanges();
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

       string sno1 = e.Item.Cells[0].Text;
        //string insert_status = e.Item.Cells[15].Text;
        string chkname=e.Item.Cells[14].Text;
      string cioidchk = e.Item.Cells[2].Text;
      if (drpstatus.SelectedValue == "audit by rate")
      {
          if (chkname == "TotalPublished")
          {
              e.Item.Cells[14].Text = "TotalAudited";
          }
          e.Item.Cells[15].Enabled = false;
      }


      else

      {
          //if (e.Item.Cells[13].Text != "TotalItemsLines")
          //{
          //    if (e.Item.Cells[13].Text != e.Item.Cells[14].Text)
          //    {
          //      // e.Item.Height.Value = 0;
          //       e.Item.Visible = false;
          //        //e.Item.Enabled = false;

          //      //  e.Item.Cells[15].Enabled = false;
          //    }
          //}
      }
      //if (e.Item.Visible != false)
      {
          if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
          {
              e.Item.Cells[0].Text = Convert.ToString(sno++);
          }

      }




     
        //if (insert_status == "audit by rate")
        //{
        //    e.Item.Cells[1].Text = "<img src=\"images/flag.gif\" ></img>";
        //    e.Item.Cells[16].Enabled = false;

        //}

        //if ((insert_status == "audit by rate") && (insert_status != "") && (insert_status != "&nbsp;"))
        //{
        //    e.Item.Cells[0].Enabled = false;
        //}



       //if (e.Item.Visible != false)
       {

           hiddenrowcount.Value = Session["RowLen"].ToString();
           if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
           {
               if (e.Item.Cells[4].Text != "&nbsp;")
               {
                   // e.Item.Cells[0].Text = "<img src=\"images/flag.gif\" ></img>";
               }
               string bookingid = e.Item.Cells[2].Text;
               //e.Item.Cells[1].Text = "<a id='cio" + i + "' style=\"cursor:hand;color:blue\" onClick=\"openbooking('" + e.Item.Cells[1].Text + "','cio" + i + "','" + hiddenrowcount.Value + "','" + e.Item.Cells[4].Text + "','')\">" + e.Item.Cells[1].Text + "</a>";
               e.Item.Cells[2].Text = "<a style=\"cursor:hand;color:blue\" id='cio" + i + "'  onClick=\"openbooking('" + e.Item.Cells[2].Text + "','cio" + i + "','" + hiddenrowcount.Value + "','" + e.Item.Cells[4].Text + "','" + e.Item.Cells[7].Text + "',''  )\">" + e.Item.Cells[2].Text + "</a>";
               i = i + 1;
           }
       }
    }


    [Ajax.AjaxMethod]
    public DataSet execute(string bookingid, string compcode, string adtype, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Booking_Audit1 executebullet = new NewAdbooking.Classes.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
        }
        else
        {
            NewAdbooking.classesoracle.Booking_Audit1 executebullet = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = executebullet.executeauditmast1(bookingid, compcode, adtype, dateformat,"");
            //NewAdbooking.classesoracle.adsubcat executebullet = new NewAdbooking.classesoracle.adsubcat();
            //ds = executebullet.addcategoryname();
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet updatestatus(string bookingid, string insertion, string edition, string from_date, string date_format, string serverip, string userid)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.session_billing executebullet = new NewAdbooking.BillingClass.Classes.session_billing();

                ds = executebullet.updatestatus_order(bookingid, insertion, edition, from_date, date_format);
                return ds;
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.updatestaus executebullet = new NewAdbooking.BillingClass.classesoracle.updatestaus();

                ds = executebullet.updatestatus_order(bookingid, insertion, edition, from_date, date_format);
             
            }
        }
        catch (Exception e)
        {
            err = e.Message;

        }
        string adcatcode2 = "Rate Audit " + bookingid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new  (DATE1 ,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + userid + "','Rate Audit','" + err.Replace("'", "''") + "','Rate audit','" + adcatcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + serverip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;
        
    }
    //public void bindretainer()
    //{
    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.BillingClass.Classes.publish_audit objregion = new NewAdbooking.BillingClass.Classes.publish_audit();
    //        ds = objregion.bindretainer(Session["compcode"].ToString());

    //    }
    //    else
    //    {
    //        NewAdbooking.classesoracle.Booking_Audit1 objregion = new NewAdbooking.classesoracle.Booking_Audit1();
    //        ds = objregion.bindretainer(Session["compcode"].ToString());
    //    }


    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = ("--Select Retainer--");
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpretainer.Items.Add(li1);



    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpretainer.Items.Add(li);


    //    }
    //}

    //public void bindexecutive()
    //{
    //    string tname = "";

    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {

    //        NewAdbooking.BillingClass.Classes.publish_audit exec = new NewAdbooking.BillingClass.Classes.publish_audit();
    //        ds = exec.adexec(Session["compcode"].ToString(), Session["userid"].ToString(), tname);

    //    }
    //    else
    //    {
    //        NewAdbooking.classesoracle.Booking_Audit1 exec = new NewAdbooking.classesoracle.Booking_Audit1();
    //        ds = exec.adexec(Session["compcode"].ToString(), Session["userid"].ToString(), tname);
    //    }


    //    ListItem li1;
    //    li1 = new ListItem();

    //    li1.Text = "--Select Executive--";
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpexecutive.Items.Add(li1);


    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpexecutive.Items.Add(li);


    //    }
    //}

    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {

            NewAdbooking.BillingClass.Classes.publish_audit pub_cent2 = new NewAdbooking.BillingClass.Classes.publish_audit();
        ds = pub_cent2.pubsupply(compcode, edition);
       
        }
        else
        {

        NewAdbooking.classesoracle.Booking_Audit1 pub_cent2 = new NewAdbooking.classesoracle.Booking_Audit1();
        ds = pub_cent2.pubsupply(compcode, edition);
     
        }
        return ds;

    }


    //public void bindagecli()
    //{
    //    // regionhidden = hiddenregion.Value;
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.Class1 adagencycli = new NewAdbooking.Classes.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.Class1 adagencycli = new NewAdbooking.classesoracle.Class1();
    //        ds = adagencycli.adagencycli(Session["compcode"].ToString());
    //    }
    //    else
    //    {
    //    }

    //    ListItem li1;
    //    li1 = new ListItem();
    //    dpagencycli.Items.Clear();


    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
    //    // li1.Text = "--Select Client Name--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpagencycli.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpagencycli.Items.Add(li);


    //    }
    //}

    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }




    public void bindbranch( string  userid)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit bind = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = bind.bindbranch();
        }
        else
        {

            NewAdbooking.BillingClass.classesoracle.session_billing bind = new NewAdbooking.BillingClass.classesoracle.session_billing();
            ds = bind.bindbranch_userwise(userid);

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
            li.Value = ds.Tables[0].Rows[i]["Branch_Code"].ToString();
            li.Text = ds.Tables[0].Rows[i]["Branch_Name"].ToString();
            drpbranch.Items.Add(li);


        }

    }


    /*

    public void bindbranch()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit bind = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = bind.bindbranch();
        }
        else
        {

            NewAdbooking.classesoracle.Booking_Audit1 bind = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = bind.bindbranch();

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
     * */
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

    //public void bindagency()
    //{
    //    DataSet ds = new DataSet();
    //    if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.BillingClass.Classes.publish_audit adagency = new NewAdbooking.BillingClass.Classes.publish_audit();
    //    ds = adagency.agency(Session["compcode"].ToString());

    //    }
    //    else
    //    {
        
    //    NewAdbooking.classesoracle.Class1 adagency = new NewAdbooking.classesoracle.Class1();
    //    ds = adagency.agency(Session["compcode"].ToString());
    //    }
       

    //    ListItem li1;
    //    li1 = new ListItem();
    //    dpagencyna.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();

    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpagencyna.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        dpagencyna.Items.Add(li);


    //    }
    //}
  

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save pub_cent1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString());
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

    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 advpub = new NewAdbooking.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else
        {
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


    [Ajax.AjaxMethod]
    public DataSet getPackageName(string compcode, string pkg_code)
    {
        DataSet ds = new DataSet();
       if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.publish_audit objpkg = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = objpkg.clsPackageName(compcode, pkg_code);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Booking_Audit1 objpkg = new NewAdbooking.classesoracle.Booking_Audit1();
            ds = objpkg.clsPackageName(compcode, pkg_code);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet fetch_date_data(string pcomp_code, string pformname, string puserid, string pentry_date, string pdateformat, string pextra1, string pextra2)
    {
        

         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.BillingClass.Classes.session_billing abcd = new NewAdbooking.BillingClass.Classes.session_billing();
             ds = abcd.ad_get_backdays_validate(pcomp_code, pformname, puserid, pentry_date, pdateformat, pextra1, pextra2);

         }
         else
         {
             NewAdbooking.BillingClass.classesoracle.session_billing abcd = new NewAdbooking.BillingClass.classesoracle.session_billing();
             ds = abcd.ad_get_backdays_validate(pcomp_code, pformname, puserid, pentry_date, pdateformat, pextra1, pextra2);
         }


        return ds;
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




    protected void btnaudit_Click(object sender, EventArgs e)
    {
        btnsubmit_Click(sender,e);
    }
}
