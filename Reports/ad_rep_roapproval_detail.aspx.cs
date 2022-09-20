﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class ad_rep_roapproval_detail : System.Web.UI.Page
{
    int i = 0;
    int j = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();
         hiddenbk_audit.Value = Session["audit"].ToString();
        hiddenserverip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(ad_rep_roapproval_detail));
          if (!Page.IsPostBack)
          {
              txtagency.Attributes.Add("onkeydown", "javascript:return fillAgency(event);");
              lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
              lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");

              txtclient.Attributes.Add("onkeydown", "javascript:return fillclient(event);");
              lstclient.Attributes.Add("onkeydown", "javascript:return onclickclient(event);");
              lstclient.Attributes.Add("onclick", "javascript:return onclickclient(event);");

              txtexecname.Attributes.Add("onkeydown", "javascript:return fillexcutive(event);");
              istexcutive.Attributes.Add("onkeydown", "javascript:return onclickexcutive(event);");
              istexcutive.Attributes.Add("onclick", "javascript:return onclickexcutive(event);");
              drprevenu.Attributes.Add("OnChange", "javascript:return bindQBC(event);");
                   txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
              txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
              BtnRun.Attributes.Add("onclick", "javascript:return forreport();");

              fillPubCenter(Session["compcode"].ToString());
              binddate();
          }
          DataSet ds = new DataSet();
          ds.ReadXml(Server.MapPath("XML/ad_rep_roapproval_detail.xml"));

          lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
          lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
          lblprint.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
          lblbranch.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
          lbl_agency.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
          lblclient.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
          lblexcutive.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
          lbratecode.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
          lblstatus.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
          lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
          BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
          heading.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();


    }
    private void fillPubCenter(string compcode)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.misupdation logindetail = new NewAdbooking.Classes.misupdation();
            ds = logindetail.getPubCenter();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.misupdation logindetail = new NewAdbooking.classesoracle.misupdation();

            ds = logindetail.getPubCenter_company(compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Bind_PubCentName_Bind_PubCentName_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }



        drprevenu.Items.Clear();
        ListItem li1;



        li1 = new ListItem();
        li1.Text = "-Select Center-";
        li1.Value = "";
        li1.Selected = true;
        drprevenu.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drprevenu.Items.Add(li);
        }

        drprevenu.Focus();
    }
    [Ajax.AjaxMethod]
    public DataSet fillQBC(string userid)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.misupdation logindetail = new NewAdbooking.Classes.misupdation();

            ds = logindetail.bindbranch_userwise(userid);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.misupdation bind = new NewAdbooking.classesoracle.misupdation();
                ds = bind.bindbranch_userwise(userid);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "bind_branch_branchwise_bind_branch_branchwise_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { userid };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fill_agency(string compcode, string maingrcode, string dateformat, string extra1, string extra2)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.misupdation admast = new NewAdbooking.Classes.misupdation();
            ds = admast.execute_maingrp(compcode, maingrcode, dateformat, extra1, extra2);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.misupdation admast = new NewAdbooking.classesoracle.misupdation();
                ds = admast.execute_maingrp(compcode, maingrcode, dateformat, extra1, extra2);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "bindagencyforxls_bindagencyforxls_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, maingrcode, dateformat, extra1, extra2 };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.misupdation adagencycli = new NewAdbooking.classesoracle.misupdation();
            ds = adagencycli.clientxls(compcol, client);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.misupdation adagencycli = new NewAdbooking.Classes.misupdation();
            ds = adagencycli.clientxls(compcol, client);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindclientforxls_bindclientforxls_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcol, client };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcol, string exectv)
    {
        string tname = "", userid = "";

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.misupdation logindetail = new NewAdbooking.Classes.misupdation();
            ds = logindetail.executivexls(compcol, userid, tname, exectv);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.misupdation logindetail = new NewAdbooking.classesoracle.misupdation();
                ds = logindetail.executivexls(compcol, userid, tname, exectv);
            }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "xlsBindexecnew_xlsBindexecnew_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcol, userid, tname, exectv };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        return ds;
    }


    private void binddate()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/ad_rep_roapproval_detail.xml"));

        int i;
        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drpadate.Items.Add(li1);
        }

    }
}