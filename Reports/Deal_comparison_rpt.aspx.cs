using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Deal_comparison_rpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Session Expired Please Login Again');window.close();</script>");
            return;
        }
        //hdnuserid.Value = Session["userid"].ToString();
        //hdndateformat.Value = Session["dateformat"].ToString();
        //hdnunit.Value = Session["center"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        //hdnshid.Value = Session["schid"].ToString();
        //hdnloc.Value = Session["center"].ToString();
        //txtcomp.Text = Session["compcode"].ToString();
        //txtcomp.Enabled = false;
        Ajax.Utility.RegisterTypeForAjax(typeof(Deal_comparison_rpt));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("Xml/Deal_comparison_rpt.xml"));
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblproduct.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblDestination.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();


        //lbllocality.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lblsociety.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnExit.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        //lblDestination.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

        //txtloccode.Focus();
        ////txtlocname.Enabled = false;
        //txtcustname.Enabled = true;
        //txtstate.Enabled = true;
        //txttown.Enabled = true;
        //txtcity.Enabled = true;
        //txtdist.Enabled = true;
        //txtloccode.Enabled = false;

        //txtsocietyname.Enabled = false;
        if (!IsPostBack)
        {
            bind_rptdestination();

            lstclient.Attributes.Add("onclick", "javascript:return onclickclient(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return onclickclient(event);");
            lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
            lstproduct.Attributes.Add("onclick", "javascript:return onclickproduct(event);");
            lstproduct.Attributes.Add("onkeydown", "javascript:return onclickproduct(event);");
            //lsttown.Attributes.Add("onclick", "javascript:return filltown(event);");
            //lsttown.Attributes.Add("onkeydown", "javascript:return filltown(event);");
            //lstcity.Attributes.Add("onclick", "javascript:return onclickcity(event);");
            //lstcity.Attributes.Add("onkeydown", "javascript:return onclickcity(event);");
            
            
            //txtagencyname.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            txtagencyname.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
            txtagencyname.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");

            txtclientname.Attributes.Add("onkeypress", "javascript:return keySort1(this);");
            txtclientname.Attributes.Add("onkeydown", "javascript:return F2fillagencycr1(event);");
            txtclientname.Attributes.Add("onkeypress", "javascript:return F2fillagencycr1(event);");

            txtproductname.Attributes.Add("onkeypress", "javascript:return keySort1(this);");
            txtproductname.Attributes.Add("onkeydown", "javascript:return F2fillagencycr2(event);");
            txtproductname.Attributes.Add("onkeypress", "javascript:return F2fillagencycr2(event);");

            btnExit.Attributes.Add("onclick", "javascript:return exit(event);");
            BtnRun.Attributes.Add("onclick", "javascript:return run(event);");

            //txtloccode.Text = hdnloc.Value.ToString();
            // txtschgroup.Text = hdnshid.Value.ToString();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                hiddenconnection.Value = "orcl";
            }
            else
            {
                hiddenconnection.Value = "sql";
            }


        }
        //Ajax.Utility.RegisterTypeForAjax(typeof(Deal_comparison_rpt));




        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    DataSet ds_per = new DataSet();
        //    NewAdbooking.Classes.cir_permission ls = new NewAdbooking.Classes.cir_permission();
        //    ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunit.Value, hdnuserid.Value, "31", "crm_walkin_delivery_addrpt", hdndateformat.Value, "", "");
        //    if (ds_per.Tables[0].Rows.Count > 0)
        //    {
        //        hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
        //    }
        //    else
        //    {
        //        hdn_user_right.Value = "7";
        //    }
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    DataSet ds_per = new DataSet();
        //    NewAdbooking.classesoracle.cir_permission ls = new NewAdbooking.classesoracle.cir_permission();
        //    ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunit.Value, hdnuserid.Value, "31", "crm_walkin_delivery_addrpt", hdndateformat.Value, "", "");
        //    if (ds_per.Tables[0].Rows.Count > 0)
        //    {
        //        hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
        //    }
        //    else
        //    {
        //        hdn_user_right.Value = "7";
        //    }
        //}
        //else
        //{
        //}


    }
    public void bind_rptdestination()
    {
        drpdestination.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("Xml/Deal_comparison_rpt.xml"));
        for (int i = 0; i < ds1.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li3 = new ListItem();
            li3.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i++;
            li3.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            drpdestination.Items.Add(li3);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_CreditAgency(string compcol, string agen)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagency = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagency = new NewAdbooking.Report.Classes.Class1();
            ds = adagency.agencyxls(compcol, agen);
        }

        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditclient(string compcol, string cli)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 adagencycli = new NewAdbooking.Report.classesoracle.Class1();
            ds = adagencycli.clientxls(compcol, cli);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 adagencycli = new NewAdbooking.Report.Classes.Class1();
            ds = adagencycli.clientxls(compcol, cli);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindbrand(string compcode, string pro)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.bindBrand(compcode, pro);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.bindBrand(compcode, pro);
        }
        return ds;

    }
    //[Ajax.AjaxMethod]
    //public DataSet fill_pub(string locid)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.expiry_list remark = new NewAdbooking.classesoracle.expiry_list();
    //            ds = remark.pub_bind(locid);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.EXPIRY_LIST1 remark = new NewAdbooking.Classes.EXPIRY_LIST1();
    //            ds = remark.pub_bind(locid);
    //        }
    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }

    //}
    //[Ajax.AjaxMethod]
    //public DataSet fill_sch(string locid, string schid, string compcode, string extra1, string extra2)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_expiry_list sch = new NewAdbooking.classesoracle.crm_expiry_list();
    //            ds = sch.sch_bind(locid, schid, compcode, extra1, extra2);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.CRM_CustMaster sch = new NewAdbooking.Classes.CRM_CustMaster();
    //            ds = sch.sch_bind(locid, schid, compcode, extra1, extra2);
    //        }

    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }
    //}
    //[Ajax.AjaxMethod]
    //public DataSet fill_city(string compcode, string datformat, string extra1, string extra2)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.crm_potential_cust bpub = new NewAdbooking.classesoracle.crm_potential_cust();
    //        ds = bpub.fillcity123(compcode, datformat, extra1, extra2);
    //    }
    //    else
    //    {
    //        NewAdbooking.Classes.crm_potential_cust bpub = new NewAdbooking.Classes.crm_potential_cust();
    //        ds = bpub.fillcity123(compcode, datformat, extra1, extra2);
    //    }
    //    return ds;
    //}
    //[Ajax.AjaxMethod]
    //public DataSet fill_town(string locid, string pextra1, string pextra2)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.CRM_CustMaster pubname = new NewAdbooking.classesoracle.CRM_CustMaster();
    //        ds = pubname.filltown(locid, pextra1, pextra2);
    //    }

    //    else
    //    {
    //        NewAdbooking.Classes.CRM_CustMaster pubname = new NewAdbooking.Classes.CRM_CustMaster();
    //        ds = pubname.filltown(locid, pextra1, pextra2);
    //    }
    //    return ds;
    //}

    //[Ajax.AjaxMethod]
    //public DataSet fill_dist(string compcode, string dateformate, string extra1, string extra2)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_walkin_delivery_addrpt reg = new NewAdbooking.classesoracle.crm_walkin_delivery_addrpt();
    //            ds = reg.dist_bind(compcode, dateformate, extra1, extra2);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.crm_walkin_delivery_addrpt sch = new NewAdbooking.Classes.crm_walkin_delivery_addrpt();
    //            ds = sch.dist_bind(compcode, dateformate, extra1, extra2);
    //        }

    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }
    //}

    //[Ajax.AjaxMethod]
    //public DataSet fill_cust(string compcode, string custname, string extra1, string extra2)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_walkin_delivery_addrpt reg = new NewAdbooking.classesoracle.crm_walkin_delivery_addrpt();
    //            ds = reg.cust_name(compcode, custname, extra1, extra2);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.crm_walkin_delivery_addrpt sch = new NewAdbooking.Classes.crm_walkin_delivery_addrpt();
    //            ds = sch.cust_name(compcode, custname, extra1, extra2);
    //        }

    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }
    //}
    //[Ajax.AjaxMethod]
    //public DataSet fill_state(string compcode)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_walkin_delivery_addrpt reg = new NewAdbooking.classesoracle.crm_walkin_delivery_addrpt();
    //            ds = reg.state_bind(compcode);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.crm_walkin_delivery_addrpt reg = new NewAdbooking.Classes.crm_walkin_delivery_addrpt();
    //            ds = reg.state_bind(compcode);
    //        }

    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }
    //}

    //[Ajax.AjaxMethod]
    //public DataSet fill_zone(string locid, string region, string extra1, string compcode)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_expiry_list zone = new NewAdbooking.classesoracle.crm_expiry_list();
    //            ds = zone.zone_bind(locid, region, extra1, compcode);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.imp_pend bpub = new NewAdbooking.Classes.imp_pend();
    //            //NewAdbooking.classesoracle.Customermaster bpub = new NewAdbooking.classesoracle.Customermaster();
    //            ds = bpub.bindzone(locid, region, extra1, compcode);
    //        }

    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }

    //}
    //[Ajax.AjaxMethod]
    //public DataSet fill_center(string locid, string extra1, string extra2)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_expiry_list center = new NewAdbooking.classesoracle.crm_expiry_list();
    //            ds = center.center_bind(locid, extra1, extra2);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.imp_pend bpub = new NewAdbooking.Classes.imp_pend();
    //            //NewAdbooking.classesoracle.Customermaster bpub = new NewAdbooking.classesoracle.Customermaster();
    //            ds = bpub.bindcenter(locid, extra1, extra2);
    //        }

    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }

    //}
    //[Ajax.AjaxMethod]
    //public DataSet fill_howker(string locid, string center, string compcode, string extra1, string extra2, string extra3)
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {

    //            NewAdbooking.classesoracle.crm_expiry_list howker = new NewAdbooking.classesoracle.crm_expiry_list();
    //            ds = howker.howker_bind(locid, center, compcode, extra1, extra2, extra3);
    //        }
    //        else
    //        {
    //            NewAdbooking.Classes.CRM_CustMaster bpub = new NewAdbooking.Classes.CRM_CustMaster();
    //            ds = bpub.bindhowker(locid, center, compcode, extra1, extra2, extra3);
    //        }
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        return ds;

    //    }
    //}



}
