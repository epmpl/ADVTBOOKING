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


public partial class pendingfordummy : System.Web.UI.Page
{
    int i = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/pending_dummy.xml"));
        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblpubdate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblpubcenter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblpublication.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbledition.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblsuppli.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblreason.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        btnsubmit.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        btnexit.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        btnreport.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbltdate.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
       
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(pendingfordummy));
        if (!Page.IsPostBack)
        {
            //drpadtype.Attributes.Add("OnChange", "javascript:return bindcategory_package();");
            drppublication.Attributes.Add("OnChange", "javascript:return filledition();");
            drpedition.Attributes.Add("onchange", "javascript:return suppbind();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return btnsubmit1();");
            btnexit.Attributes.Add("OnClick", "javascript:return catexitclick();");
            //btnreport.Attributes.Add("OnClick", "javascript:return openreport();");
            fillPubCenter(Session["compcode"].ToString());
            bindreason();
            adtypedata(Session["compcode"].ToString());
            bindpub();
            txtpubfrdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtpubtodate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
          
        }
    }

    public void bindreason()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/pending_dummy.xml"));

        int i;
        ListItem li1;

        li1 = new ListItem();
        drpreason.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpreason.Items.Add(li1);

        for (i = 0; i < ds.Tables[1].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            drpreason.Items.Add(li);


        }

    }


    //[Ajax.AjaxMethod]
    //public DataSet bindpackagenew(string adtype, string compcode)
    //{
    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
    //    {

    //        NewAdbooking.BillingClass.classesoracle.billing_save bindopackage = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //        ds = bindopackage.packagebind_NEW(compcode, adtype);
    //    }
    //    else
    //    {
    //        NewAdbooking.BillingClass.Classes.session_billing bindopackage = new NewAdbooking.BillingClass.Classes.session_billing();
    //        ds = bindopackage.packagebind_NEW(compcode, adtype);
    //    }

    //    return ds;

    //}


    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pending_dummy bind = new NewAdbooking.Classes.pending_dummy();
            ds = bind.adtypbind(compcode);
        }
        else
        {
            NewAdbooking.classesoracle.pending_for_dummy bind = new NewAdbooking.classesoracle.pending_for_dummy();
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





    private void fillPubCenter(string compcode)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.session_billing logindetail = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = logindetail.getPubCenter();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();

            ds = logindetail.getPubCenter_company(compcode);

        }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.getPubCenter();
        }



        drppubcenter.Items.Clear();
        ListItem li1;



        li1 = new ListItem();
        li1.Text = "All";
        li1.Value = "All";
        li1.Selected = true;
        drppubcenter.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drppubcenter.Items.Add(li);
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
        drppublication.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drppublication.Items.Add(li);


        }
    }





    [Ajax.AjaxMethod]
    public DataSet bindsupp(string compcode, string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.publish_audit pub_cent2 = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = pub_cent2.pubsupply(compcode, edition);

        }
        else
        {

            NewAdbooking.classesoracle.pending_for_dummy pub_cent2 = new NewAdbooking.classesoracle.pending_for_dummy();
            ds = pub_cent2.pubsupply(compcode, edition);

        }
        return ds;

    }


    string message;
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

         if (drpadtype.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Adtype');", true);
            drpadtype.Focus();
            return;
        }
         if (txtpubfrdate.Text == "" || txtpubtodate.Text == "")
         {
             ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Date');", true);
             txtpubfrdate.Focus();
             return;
         }
       
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pending_dummy abc = new NewAdbooking.Classes.pending_dummy();
            ds = abc.bindgrid(hiddencompcode.Value, drppubcenter.SelectedValue, drpadtype.SelectedValue, txtpubfrdate.Text, txtpubtodate.Text, drppublication.SelectedValue, drpedition.SelectedValue, drpsuppli.SelectedValue, drpreason.SelectedValue, hiddendateformat.Value, hiddenuserid.Value);
        }
        else
        {
            NewAdbooking.classesoracle.pending_for_dummy abc = new NewAdbooking.classesoracle.pending_for_dummy();
            ds = abc.bindgrid(hiddencompcode.Value, drppubcenter.SelectedValue, drpadtype.SelectedValue, txtpubfrdate.Text, txtpubtodate.Text, drppublication.SelectedValue, drpedition.SelectedValue, drpsuppli.SelectedValue, drpreason.SelectedValue, hiddendateformat.Value, hiddenuserid.Value);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            DataGrid1.DataSource = ds.Tables[0];
            DataGrid1.DataBind();
            //drpadtype.Text = "0";
            //drpedition.Text = "0";
            drppubcenter.Text = "All";
            //drppublication.Text = "0";
            drpreason.Text = "1";
           // drpsuppli.Text = "0";
            //txtpubdate.Text = "";
            message = "Searching Criteria not valid";
            AspNetMessageBox(message);
            return;
        }
        else
        {
            Session["RowLen"] = ds.Tables[0].Rows.Count;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }
        return;
    }







    public void btnreport_Click(object sender, EventArgs e)
    {
       
        if (drpadtype.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Adtype');", true);
            drpadtype.Focus();
            return;
        }
        if (txtpubfrdate.Text == "" || txtpubtodate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('Select Date');", true);
            txtpubfrdate.Focus();
            return;
        }
       
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pending_dummy abc = new NewAdbooking.Classes.pending_dummy();
            ds = abc.bindgrid(hiddencompcode.Value, drppubcenter.SelectedValue, drpadtype.SelectedValue, txtpubfrdate.Text, txtpubtodate.Text, drppublication.SelectedValue, drpedition.SelectedValue, drpsuppli.SelectedValue, drpreason.SelectedValue, hiddendateformat.Value, hiddenuserid.Value);
        }
        else
        {
            NewAdbooking.classesoracle.pending_for_dummy abc = new NewAdbooking.classesoracle.pending_for_dummy();
            ds = abc.bindgrid(hiddencompcode.Value, drppubcenter.SelectedValue, drpadtype.SelectedValue, txtpubfrdate.Text, txtpubtodate.Text, drppublication.SelectedValue, drpedition.SelectedValue, drpsuppli.SelectedValue, drpreason.SelectedValue, hiddendateformat.Value, hiddenuserid.Value);
        }
        Session["pending_ds"] = ds;
        Response.Redirect("pendingdummyreport.aspx?ds=ds");
        return;
    }



    //[Ajax.AjaxMethod]
    //public DataSet getcategory(string compcode, string pkg_code)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {

    //        NewAdbooking.BillingClass.Classes.publish_audit objpkg = new NewAdbooking.BillingClass.Classes.publish_audit();
    //        ds = objpkg.bind_category(compcode, pkg_code);

    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.BillingClass.classesoracle.billing_save objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save();
    //        ds = objpkg.bind_category(compcode, pkg_code);
    //    }
    //    return ds;
    //}


    protected void AspNetMessageBox(string strMessage)
    {

        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(pendingfordummy), "ShowAlert", strAlert, true);
    }






    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        i = i + 1;
        if (e.Item.ItemType != ListItemType.Header)
        {
            if (e.Item.Cells[7].Text == "1")
            {
                e.Item.Cells[7].Text = "UnApproval";
            }
            else if (e.Item.Cells[7].Text == "2")
            {
                e.Item.Cells[7].Text = "UnAudited";

            }
            else
            {
                e.Item.Cells[7].Text = "Material not Upload";

            }
            e.Item.Cells[0].Text = i.ToString();
            
        }
    }
}
