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
using System.Text.RegularExpressions;

public partial class Reports_AGENCY_MAST : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {

            Ajax.Utility.RegisterTypeForAjax(typeof(Reports_AGENCY_MAST));
            //unit_flag.Value = unit_flag1;
            dateformat.Value = Session["dateformat"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdncompcode.Value = Session["compcode"].ToString();
            txtcompname.Text = Session["comp_name"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hdnunit.Value = Session["center"].ToString();
            //hdnunitname.Value = Session["centername"].ToString();
            //txtunitname.Text = Session["centername"].ToString();
            Hiddenbranchcode.Value = Session["revenue"].ToString();
            hdnuserid.Value = Session["userid"].ToString();

            if (!Page.IsPostBack)
            {
                bindzone();
                bindbranch();
                binddistrict();
                bindcity();
               
                bindregion();
                bindstate();
                publicationbind();
                bindagencytype();


                dpstate.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpdistrict.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dptaluka.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpcity.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpregion.Attributes.Add("onkeypress", "javascript:return keySort(this);");
                dpbranch.Attributes.Add("onkeypress", "javascript:return keySort(this);");

                lstagency.Attributes.Add("onkeypress", "javascript:return keySort(this);");

                dpagency.Attributes.Add("onkeydown", "javascript:return F2fillagencycr(event);");
                dpagency.Attributes.Add("onkeypress", "javascript:return F2fillagencycr(event);");

                txtclient.Attributes.Add("onkeydown", "javascript:return F2fillclientcr();");
                txtclient.Attributes.Add("onkeypress", "javascript:return F2fillclientcr();");

                lstclintf2.Attributes.Add("onclick", "javascript:return Clickclient();");
                lstclintf2.Attributes.Add("onkeydown", "javascript:return Clickclient();");

                txt_executive.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr_bill(event);");
                txt_executive.Attributes.Add("onkeypress", "javascript:return F2fillexecutivecr_bill(event);");

                lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive_bill(event);");
                lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive_bill(event);");

                lstagency.Attributes.Add("onclick", "javascript:return ClickAgaency1(event);");
                lstagency.Attributes.Add("onkeydown", "javascript:return ClickAgaency1(event);");
                btnsubmit.Attributes.Add("onclick", "javascript:return forreport();");
                btncancel.Attributes.Add("onclick", "javascript:return forCancel();");
                btnexit.Attributes.Add("onclick", "javascript:return Exit();");
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("XML/agency_mast.xml"));
                
                lblcompname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                lblunitname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                agency.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                district.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                lbtaluka.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                city.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                region.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                zone.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                branch.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                lblrptdestination.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                lbstate.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                agencytype.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                lblclient.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                lbexe.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                lbreptype.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString(); 
            }
            
        }
    }

    public void binddistrict()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.district(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select District";
        li.Selected = true;
        dpdistrict.Items.Add(li);




        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpdistrict.Items.Add(li1);
        }

    }

    public void bindzone()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.addzone(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.addzone(Session["compcode"].ToString());
        }

        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Zone";
        li.Selected = true;
        dpzone.Items.Add(li);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpzone.Items.Add(li1);
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
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        dpbranch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpbranch.Items.Add(li1);
        }
        dpbranch.SelectedValue = Session["revenue"].ToString();
    }
    public void bindcity()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister objregion = new NewAdbooking.Report.classesoracle.billregister();
            ds = objregion.bindplace(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindplace(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select City";
        li1.Value = "0";
        li1.Selected = true;
        dpcity.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcity.Items.Add(li);


        }
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_client(string compcol, string cli)
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
    public DataSet fillF2_Creditexecutive(string compcol, string exectv)
    {
        string tname = "", userid = "";

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister exec = new NewAdbooking.Report.classesoracle.billregister();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 exec = new NewAdbooking.Report.Classes.Class1();
            ds = exec.executivexls(compcol, userid, tname, exectv);
        }
        return ds;
    }
    public void bindregion()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objregion = new NewAdbooking.Report.classesoracle.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objregion = new NewAdbooking.Report.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();

        li1.Text = "Select Region";
        li1.Value = "0";
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpregion.Items.Add(li);


        }
    }

    public void bindstate()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 objprod = new NewAdbooking.Report.classesoracle.Class1();
            ds = objprod.statebind(Session["compcode"].ToString(), Session["center"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 objprod = new NewAdbooking.Report.Classes.Class1();
            ds = objprod.statebind(Session["compcode"].ToString(), Session["center"].ToString());

        }

        ListItem li1;
        li1 = new ListItem();


        li1.Text = "Select State";
        li1.Value = "0";
        dpstate.Items.Add(li1);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpstate.Items.Add(li);
        }

    }

    public void bindagencytype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.billregister obj = new NewAdbooking.Report.Classes.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        ListItem li;
        li = new ListItem();
        dpagencytype.Items.Clear();

        li.Text = "Select Agency Type";

        li.Value = "0";
        li.Selected = true;
        dpagencytype.Items.Add(li);



        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagencytype.Items.Add(li2);



        }
    }

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
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
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
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
        dppubcent.SelectedValue = Session["center"].ToString();

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

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public void setSessionmis_run(string agencycode, string agencycat, string zone,string agcd,string dpcd,string dest,string region,string state,string unit,string branch,string dist,string city,string taluka,string unitnm,string brnchnm,string zonenm,string client,string exe,string reptype)
    {


        Session["agencycode"] = agencycode;
        Session["agencycat"] = agencycat;
        Session["zone"] = zone;
        Session["agcd"] = agcd;
        Session["dpcd"] = dpcd;
        Session["dest"] = dest;
        Session["region"] = region;
        Session["state"] = state;
        Session["unit"] = unit;
        Session["dist"] = dist;
        Session["branch"] = branch;
        Session["city"] = city;
        Session["taluka"] = taluka;
        Session["unitnm"] = unitnm;
        Session["brnchnm"] = brnchnm;
        Session["zonenm"] = zonenm;
        Session["client"] = client;
        Session["exe"] = exe;
        Session["reptype"] = reptype;

    }
}