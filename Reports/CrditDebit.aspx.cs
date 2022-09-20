﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Reports_CrditDebit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_CrditDebit));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/CrditDebit.xml"));

        FromDate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        ToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        PublicCenter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        Branch.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        ReportType.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        Destination.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
       // Btnexit.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        
        if (!Page.IsPostBack)
        {
            
            bindrprttype();
            publicationbind();
            binddestination();
            bindbranch();
            BtnRun.Attributes.Add("onclick", "javascript:return runreport();");
        }

    }

  
    public void bindrprttype()
    {

        dprpttype.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/CrditDebit.xml"));

        for (int i = 0; i < ds1.Tables[2].Columns.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds1.Tables[2].Rows[0].ItemArray[i].ToString();
            dprpttype.Items.Add(li);
        }


    }
  
        public void binddestination()
    {

        dpdestination.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/CrditDebit.xml"));

        for (int i = 0; i < ds1.Tables[1].Columns.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            dpdestination.Items.Add(li);
        }


    }

   

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }

        int i;
        ListItem li;
        li = new ListItem();
        txtpublicentr.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = "--Select Publication Center--" ;
        li.Value = "0";
        li.Selected = true;
        txtpublicentr.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                txtpublicentr.Items.Add(li1);
            }
        }
        //txtpublicentr.SelectedValue = Session["center"].ToString();

    }
    //branch

    public void bindbranch()
    {
        dpbranch.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster name = new NewAdbooking.Classes.AdvertisementMaster();

            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster name = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster name = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());

        }

        int i;
        ListItem li;
        li = new ListItem();
        dpbranch.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = "--Select Branch--";
        li.Value = "0";
        li.Selected = true;
        dpbranch.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dpbranch.Items.Add(li1);
            }
        }
        //dpbranch.SelectedValue = Session["center"].ToString();

    }
    

}