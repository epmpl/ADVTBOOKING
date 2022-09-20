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


public partial class Reports_dailymis : System.Web.UI.Page
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
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_dailymis));
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencenter.Value = Session["revenue"].ToString();
        hiddencentername.Value = Session["centername"].ToString();
        hiddencentercode.Value = Session["center"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/dailymis.xml"));
        
        lbfromdate.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lbtodate.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        lbarea.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        lbladtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lbluom.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lbdesctination.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lbPublicationCenter.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublication.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        suppliment.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
        lbEdition.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
        if (!Page.IsPostBack)
        {
           
           
            txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            // drpadtype.Attributes.Add("OnChange", "javascript:return BindUom();");
           
            btnCancel.Attributes.Add("onclick", "javascript:return cleardata();");
            btnExit.Attributes.Add("onclick", "javascript:return exit();");
            bntsub.Attributes.Add("onclick", "javascript:return sub();");

            //////////////////////////////////
            dppub1.Attributes.Add("onchange", "javascript:return bind_edition4();");
            dpedition.Attributes.Add("onchange", "javascript:return suppforstatus();");

            ////////////////////////////
            bindadvtype();

            edition();
            bindpub();
            publicationbind();
            txtfromdate.Focus();

          
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
       
            drpuom.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
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
    protected void bntsub_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.rateauditlog binddataforrepo = new NewAdbooking.Classes.rateauditlog();
            ds = binddataforrepo.binddaily(txtfromdate.Text, txttodate.Text, Session["compcode"].ToString(), dppubcent.SelectedValue, Session["dateformat"].ToString(), drpadtype.SelectedValue, drpuom.SelectedValue, Session["userid"].ToString(), txtarea.Text, dppub1.SelectedValue, hiddenedition.Value, hiddensupp.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.rateauditlog binddataforrepo = new NewAdbooking.classesoracle.rateauditlog();
            ds = binddataforrepo.binddaily(txtfromdate.Text, txttodate.Text, Session["compcode"].ToString(), dppubcent.SelectedValue, Session["dateformat"].ToString(), drpadtype.SelectedValue, drpuom.SelectedValue, Session["userid"].ToString(), txtarea.Text, dppub1.SelectedValue, hiddenedition.Value, hiddensupp.Value);
        }
        //      return;
        string chk_excel = "Y";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/dailymis.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        if (drpdestination.SelectedValue == "0" || drpdestination.SelectedValue == "1")
        {
            chk_excel = "0";
        }
        else
        {
            chk_excel = "2";
        }


        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["dailymis"] = ds;
            Session["prm_dailymis"] = "~fromdate~" + txtfromdate.Text + "~dateto~" + txttodate.Text + "~chk_excel~" + chk_excel + "~Adtype~" + drpadtype.SelectedItem + "~UOM~" + drpuom.SelectedItem + "~pubcenter~" + dppubcent.SelectedItem + "~Area~" + txtarea.Text + "~plication~" + dppub1.SelectedValue + "~edition~" + hiddenedition.Value + "~supliment~" + hiddensupp.Value;
            Response.Redirect("dailymisreportviwe.aspx");

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');</script>");
        }

        return;
    }



    protected void drpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        binduom();
    }

    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        return ds;
    }
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
   


    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string userid, string editioncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.misupdation clsbooking = new NewAdbooking.Classes.misupdation();
            ds = clsbooking.secpubcodes(compcode, userid, editioncode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.misupdation clsbooking = new NewAdbooking.classesoracle.misupdation();
            ds = clsbooking.secpubcodes(compcode, userid, editioncode);  //, centercode);
        }
        return ds;
    }
    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        // li1.Text = "--Select Publication--";
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
}
