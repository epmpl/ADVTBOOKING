using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class categories : System.Web.UI.Page
{
    string compcode = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            //Session["access"] = "0";
            hiddenuserid.Value = Session["userid"].ToString();
              hiddendateformat.Value = Session["dateformat"].ToString();
              hiddencomcode.Value = Session["compcode"].ToString();
              compcode = hiddencomcode.Value;
             }
        Ajax.Utility.RegisterTypeForAjax(typeof(categories));
        Response.Expires = -1;
        if (!Page.IsPostBack)
        {
            bindbranch();
            bindadtype();
            bindpubcent();
            bindcategory(compcode);
                dpadtype.Attributes.Add("onchange", "javascript:return bindadcat_schedule();");
             
            txtagency.Attributes.Add("onkeydown", "javascript:return fillAgency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
            lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");
            txtclient.Attributes.Add("onkeydown", "javascript:return fillclient(event);");
            istclient.Attributes.Add("onkeydown", "javascript:return onclickclient(event);");
            istclient.Attributes.Add("onclick", "javascript:return onclickclient(event);");

            txtexcutive.Attributes.Add("onkeydown", "javascript:return fillexcutive(event);");
            istexcutive.Attributes.Add("onkeydown", "javascript:return onclickexcutive(event);");
            istexcutive.Attributes.Add("onclick", "javascript:return onclickexcutive(event);");

            txtret.Attributes.Add("onkeydown", "javascript:return fillreterner(event);");
            istret.Attributes.Add("onkeydown", "javascript:return onclickreterner(event);");
            istret.Attributes.Add("onclick", "javascript:return onclickreterner(event);");

            btnExit.Attributes.Add("OnClick", "javascript:return formexit();");
            btnRunReport.Attributes.Add("onclick", "javascript:return forreport();");
            dpadcatgory.Attributes.Add("onchange", "javascript:return adsubcat_bind();");
       

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/categories.xml"));
            lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lblprtcent.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            Typelbl.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            lbadcat1.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            lbladcat2.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
             lblagtype.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lblagencyname.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            lblclient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            lblexcutive.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            lblretainer.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            lbluom.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            LblDestinationType.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            lblbasedon_lbl.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
   
        }
    }
    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "--Select Branch--";
        li.Selected = true;
        dpbranch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpbranch.Items.Add(li1);
        }

    }

    public void bindadtype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {


            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());

        }
        ListItem li1;
        li1 = new ListItem();

        li1.Value = "";
        li1.Text = "Select AdType";
        li1.Selected = true;
        dpadtype.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadtype.Items.Add(li);


        }
    }
    public void bindpubcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "";
        li.Text = "Select Printing Center";
        li.Selected = true;
        dpprintcenter.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpprintcenter.Items.Add(li1);


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
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.advtype(adtype, compcode);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet subcatbind(string compcode, string cat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.getSubCategory(compcode, cat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.getSubCategory(compcode, cat);
        }
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet subcat345(string cat, string compcode, string adcat4, string adcat5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adcat = new NewAdbooking.Report.classesoracle.Class1();
            ds = adcat.cat345(cat, compcode, adcat4, adcat5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adcat = new NewAdbooking.Report.Classes.Class1();
            ds = adcat.cat345(cat, compcode, adcat4, adcat5);
        }
        return ds;

    }
    public void bindcategory(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient categry = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = categry.categorybind(compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient categry = new NewAdbooking.Report.classesoracle.unregisteredclient();
                ds = categry.categorybind(compcode);
            }


        int i;
        ListItem li;
        li = new ListItem();
        drpagtype.Items.Clear();
        li.Text = "-Select Agency Type-";
        li.Value = "0";
        li.Selected = true;
        drpagtype.Items.Add(li);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpagtype.Items.Add(li1);
            }
        }
    }
    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtye)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fill_agency(string compcode, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Report.Classes.unregisteredclient admast = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = admast.execute_maingrp_child(compcode, agency);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient admast = new NewAdbooking.Report.classesoracle.unregisteredclient();
                ds = admast.execute_maingrp_child(compcode, agency);
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet fill_maingrp(string compcode, string client)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient obj1 = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = obj1.execute_maingrp(compcode, client);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient admast = new NewAdbooking.Report.classesoracle.unregisteredclient();
                ds = admast.execute_maingrp(compcode, client);
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

           NewAdbooking.Report.Classes.unregisteredclient logindetail = new NewAdbooking.Report.Classes.unregisteredclient();
           ds = logindetail.executivexls(compcol, userid, tname, exectv);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient logindetail = new NewAdbooking.Report.classesoracle.unregisteredclient();
                ds = logindetail.executivexls(compcol, userid, tname, exectv);
            }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditretainer(string compcol, string ret)
    {
        DataSet ds = new DataSet();
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

         NewAdbooking.Report.Classes.unregisteredclient logindetail = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = logindetail.retainerxls(compcol, ret);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.unregisteredclient logindetail = new NewAdbooking.Report.classesoracle.unregisteredclient();

                ds = logindetail.retainerxls(compcol, ret);
            }



        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bind_adsubcat(string newstr, string newstr1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.SHACHIREPORT adsubcat = new NewAdbooking.Report.classesoracle.SHACHIREPORT();
            ds = adsubcat.bindadsubcat(newstr);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adsubcat = new NewAdbooking.Report.Classes.Class1();
            ds = adsubcat.bindadsubcat(newstr);
        }

        return ds;
    }

}
