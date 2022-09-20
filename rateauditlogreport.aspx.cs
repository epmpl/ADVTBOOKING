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

public partial class rateauditlogreport : System.Web.UI.Page
{
    string companyname = "";
    int p = 0;
    string rdatefinalhdsmain1 = "";
    string rundate = "";
    int rowcounter = 0;
    string rdatefinalhdsmain = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        Ajax.Utility.RegisterTypeForAjax(typeof(rateauditlogreport));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencenter.Value = Session["revenue"].ToString();
        hiddencentername.Value = Session["centername"].ToString();
        hiddencentercode.Value = Session["center"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/rateauditlog.xml"));
        lbbookingid.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbagency.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbclient.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lbPublicationCenter.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lbfromdate.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lbtodate.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        lblbranch.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        lbladtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lbluom.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        if (!Page.IsPostBack)
        {
            txtagency.Attributes.Add("onkeydown", "javascript:return agencybindf2(event);");
            lstagency.Attributes.Add("onclick", "javascript:return onclickagency(event);");
            lstagency.Attributes.Add("onkeydown", "javascript:return onclickagency(event);");
            txtclient.Attributes.Add("onkeydown", "javascript:return clientf2(event);");
            lstclient.Attributes.Add("onclick", "javascript:return onclickclient(event);");
            lstclient.Attributes.Add("onkeydown", "javascript:return onclickclient(event);");
            txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
           // drpadtype.Attributes.Add("OnChange", "javascript:return BindUom();");
            txtbookingid.Attributes.Add("onkeyup", "javascript:return bookingidF2(event);");
            listbookingid.Attributes.Add("onclick", "javascript:return onclicbooking(event);");
            listbookingid.Attributes.Add("onkeydown", "javascript:return onclicbooking(event);");
            btnCancel.Attributes.Add("onclick", "javascript:return cleardata();");
            btnExit.Attributes.Add("onclick", "javascript:return exit();");
            
            publicationbind();
            bindadvtype();



            txtbookingid.Focus();
          
            BindBranch();
        }
    }

    public void BindBranch()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Createuser branchname = new NewAdbooking.classesoracle.Createuser();
            ds = branchname.getbranch();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Createuser retainername = new NewAdbooking.Classes.Createuser();
            ds = retainername.retainer();
        }
        else
        {
            NewAdbooking.classmysql.Createuser retainername = new NewAdbooking.classmysql.Createuser();
            ds = retainername.retainer();
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Branch Name-";
        li1.Value = "0";
        li1.Selected = true;
        drpbranch.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbranch.Items.Add(li);


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
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), "0");
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


    }

    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster advname = new NewAdbooking.Classes.AdCategoryMaster();

            ds = advname.adname(hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster advname = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = advname.adname(hiddencompcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster advname = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = advname.adname(hiddencompcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Ad Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindagencyname(string compcode, string userid, string agency)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bindagenname = new NewAdbooking.Classes.BookingMaster();
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
        }
        else
        {
            NewAdbooking.classesoracle.BookingMaster bindagenname = new NewAdbooking.classesoracle.BookingMaster();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            //}
            //else
            //{
            ds = bindagenname.bindagency(compcode, userid, agency, "0");
            //}
        }
        return ds;



    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindbookingid(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.rateauditlog bindagenname = new NewAdbooking.Classes.rateauditlog();
            ds = bindagenname.bindbooking(compcode, userid);
        }
        else
        {
            NewAdbooking.classesoracle.rateauditlog bindagenname = new NewAdbooking.classesoracle.rateauditlog();
            //if (Session["FILTER"].ToString() == "D")
            //{
            //    ds = bindagenname.bindagency(compcode, userid, agency, Session["revenue"].ToString());
            //}
            //else
            //{
            ds = bindagenname.bindbooking(compcode, userid);
            //}
        }
        return ds;



    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            if (Session["FILTER"].ToString() == "D")
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, Session["revenue"].ToString());
            }
            else
            {
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, "0");
            }
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
    }


    //[Ajax.AjaxMethod]
    //public DataSet binduom(string compcode, string adtye)
    public void binduom()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(Session["compcode"].ToString(), drpadtype.SelectedValue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(Session["compcode"].ToString(), drpadtype.SelectedValue);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            ds = binduom.uombind(Session["compcode"].ToString(), drpadtype.SelectedValue);
        }

        ListItem li1;
        li1 = new ListItem();
        drpuom.Items.Clear();
        li1.Text = "-Select UOM Name-";
        li1.Value = "0";
        li1.Selected = true;
        drpuom.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpuom.Items.Add(li);


        }

       // return ds;
    }
    protected void bntsub_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.rateauditlog binddataforrepo = new NewAdbooking.Classes.rateauditlog();
            ds = binddataforrepo.bindrep(txtfromdate.Text, txttodate.Text, Session["compcode"].ToString(), dppubcent.SelectedValue, drpbranch.SelectedValue, Session["dateformat"].ToString(), drpadtype.SelectedValue, drpuom.SelectedValue, hdclientcode.Value, hidenagencycode.Value, txtbookingid.Text, Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.rateauditlog binddataforrepo = new NewAdbooking.classesoracle.rateauditlog();
            ds = binddataforrepo.bindrep(txtfromdate.Text, txttodate.Text, Session["compcode"].ToString(), dppubcent.SelectedValue, drpbranch.SelectedValue, Session["dateformat"].ToString(), drpadtype.SelectedValue, drpuom.SelectedValue, hdclientcode.Value, hidenagencycode.Value, txtbookingid.Text, Session["userid"].ToString());
        }
  //      return;
        string chk_excel = "Y";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/rateauditlog.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["rateaudit"] = ds;
            Session["prm_ratauidt"] = "~fromdate~" + txtfromdate.Text + "~dateto~" + txttodate.Text + "~chk_excel~" + chk_excel;
            Response.Redirect("rateauditlogreportviwe.aspx");

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

        return;
    }

  

    protected void drpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        binduom();
    }
}
