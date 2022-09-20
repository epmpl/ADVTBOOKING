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

public partial class packagewisereport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[92].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
        lbpackage.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;

        if (!IsPostBack)
        {
            binddest();
            bindclient1();
            bindagency1();
            bindpackage();
            bindpub();
            pubcentbind();
            edition();
            bindadtype();
            

            BtnRun.Attributes.Add("onclick", "javascript:return pivalidation();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");

            drpagency.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

        }
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //  ds = obj.barter_report(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, dpproduct.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.packagewise(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), drpclient.SelectedValue, drpagency.SelectedValue, Session["dateformat"].ToString(), drppackage.SelectedValue,dpadtype.SelectedValue,dppub1.SelectedValue,dppubcent.SelectedValue,dpedition.SelectedValue);
                                
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(packagewisereport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            Response.Redirect("packagewiseview.aspx?fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&agency=" + drpagency.SelectedValue + "&agencyname=" + drpagency.SelectedItem.Text + "&client=" + drpclient.SelectedValue + "&clientname=" + drpclient.SelectedItem.Text + "&packagecode=" + drppackage.SelectedValue + "&packagename=" + drppackage.SelectedItem.Text + "&adtypecode=" + dpadtype.SelectedValue + "&adtypename=" + dpadtype.SelectedItem.Text + "&pubcode=" + dppub1.SelectedValue + "&pubname=" + dppub1.SelectedItem.Text + "&pubcentcode=" + dppubcent.SelectedValue + "&pubcentname=" + dppubcent.SelectedItem.Text + "&editioncode=" + dppubcent.SelectedValue + "&editionname=" + dppubcent.SelectedItem.Text);
        }
    }
    public void bindadtype()
    {

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
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

    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        //li1.Text = "--Select Publication--";
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

    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        // li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }
    public void pubcentbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();

            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
        //li.Text = "-Select Publication Center-";
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
    protected void dpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
           // NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            //ds = advpub.package_report(Session["compcode"].ToString(), dpadtype.SelectedValue);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
            ds = advpub.package_report(Session["compcode"].ToString(), dpadtype.SelectedValue);
        }
        int i;
        ListItem li;
        li = new ListItem();
        drppackage.Items.Clear();
        
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = "--Select Package--";
        // li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        drppackage.Items.Add(li);



        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drppackage.Items.Add(li1);
            }
        }
        // ScriptManager.RegisterClientScriptBlock(this, typeof(packagewisereport), "sa", "document.getElementById('dppub1').focus();", true);
    }
    protected void dppub1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        }
        int i;
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        // li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);



        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dpedition.Items.Add(li1);
            }
        }
       // ScriptManager.RegisterClientScriptBlock(this, typeof(packagewisereport), "sa", "document.getElementById('dppub1').focus();", true);
    }
    protected void dppubcent_SelectedIndexChanged(object sender, EventArgs e)
    {
        // NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        // ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());

        }
        int i;
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


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dpedition.Items.Add(li1);
            }
        }
      // ScriptManager.RegisterClientScriptBlock(this, typeof(packagewisereport), "sa", "document.getElementById('dppubcent').focus();", true);
    }

    public void bindpackage()
    {

        //DataSet ds = new DataSet();

        //NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
        //ds = advpub.package_report(Session["compcode"].ToString(),dpadtype.SelectedValue);

        ListItem li1;
        li1 = new ListItem();


        li1.Text = "--Select Package--";
        li1.Value = "0";
        li1.Selected = true;
        drppackage.Items.Add(li1);

        //int i;
        //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    drppackage.Items.Add(li);


        //}
    }
    public void bindagency1()
    {

        DataSet ds = new DataSet();

        NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
        ds = advpub.bindagency(Session["compcode"].ToString());

        ListItem li1;
        li1 = new ListItem();


        li1.Text = "--Select Agency--";
        li1.Value = "0";
        li1.Selected = true;
        drpagency.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpagency.Items.Add(li);


        }
    }
    public void bindclient1()
    {

        DataSet ds = new DataSet();

        NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
        ds = advpub.bindclient(Session["compcode"].ToString());

        ListItem li1;
        li1 = new ListItem();

        li1.Text = "--Select Client--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpclient.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpclient.Items.Add(li);


        }
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }


    
}
