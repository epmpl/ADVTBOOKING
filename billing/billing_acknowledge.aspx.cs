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

public partial class billing_acknowledge : System.Web.UI.Page
{

    //string fromdate = "";
    //string tilldate = "";
    //string branch = "";
    //string pubcent = "";
    //string user = "";
    //string agency = "";
    //string edition = "";
    //string adtype = "";
    //string acknowledege = "";
    int j = 1;
    int K = 0;
    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
      


        Ajax.Utility.RegisterTypeForAjax(typeof(billing_acknowledge));


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/billing_acknowledge.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lb_branch.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbpackage.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblselect.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lblconfirm.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        Label2.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();//user
        hiddenadtype.Value = dpdadtype.SelectedValue;
        heading.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        if (Session["compcode"] != null)
        {
            hiddencode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenusername.Value = Session["Username"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        if (!IsPostBack)
        {
            user_bind();
            bindpackage();
            adtypedata(Session["compcode"].ToString());
            //publicationbind();
            bindpublication();
            bindbranch();
            bindselect();
            //bindpackagenew();
            //drp_publication.Attributes.Add("onchange", "javascript:return bind_edition11();");
            btnsubmit.Attributes.Add("onclick", "javascript:return checkboxid()");
            btn_click.Attributes.Add("onclick", "javascript:return checkvalidations()");
            ListBox1.Attributes.Add("onclick", "javascript:return insertagency(this.value);");
            //dpedition.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            //dpedition.Attributes.Add("onchange", "javascript:return suppbind();");
            drppackage.Attributes.Add("onchange", "javascript:return fetch_PACKAGE();");
            dpdadtype.Attributes.Add("onchange", "javascript:return bindpackage();");
            txtfrmdate.Attributes.Add("onchange", "javascript:return run_report();");
            txttodate1.Attributes.Add("onchange", "javascript:return run_report();");
            txttodate1.Attributes.Add("onchange", "javascript:return run_report();");

            //txtagency.Attributes.Add("OnPaste", "return false");
            //txtagency.Attributes.Add("Ondrop", "return false");
            //txtagency.Attributes.Add("Ondrag", "return false");
            //txtagency.Attributes.Add("Oncut", "return false");
            //txtagency.Attributes.Add("OnCopy", "return false");

        }

    }






    [Ajax.AjaxMethod]
    public DataSet updatestatusnew(string bill_number, string delivery_man_name, string delivery_date, string acknowledge_date, string remarks,string date_format)
    {
        DataSet ds = new DataSet();

        string err = "";
        try
        {

            if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.biling_acknowledge executebullet = new NewAdbooking.BillingClass.Classes.biling_acknowledge();
                ds = executebullet.updatestatusnew(bill_number, delivery_man_name, delivery_date, acknowledge_date, remarks, date_format);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.biling_acknowledge executebullet = new NewAdbooking.BillingClass.classesoracle.biling_acknowledge();
                ds = executebullet.updatestatusnew(bill_number, delivery_man_name, delivery_date, acknowledge_date, remarks, date_format);
            }
           

        }
        catch (Exception e)
        {
            err = e.Message;

        }
        return ds;


    }


    protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    public void bindpackage()
    {

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Edition";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppackage.Items.Add(li1);


    }

    [Ajax.AjaxMethod]
    public DataSet bindpackagenew(string adtype, string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

            NewAdbooking.BillingClass.classesoracle.billing_save bindopackage = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = bindopackage.packagebind_NEW(compcode, adtype);
        }
        else
        {
            NewAdbooking.BillingClass.Classes.session_billing bindopackage = new NewAdbooking.BillingClass.Classes.session_billing();
            ds = bindopackage.packagebind_NEW(compcode, adtype);
        }

        return ds;

    }

    public void bindselect()
    {
        DataSet ds2 = new DataSet();
        ds2.ReadXml(Server.MapPath("XML/billing_acknowledge.xml"));
        dpselect.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Ac/NonAc--";
        li1.Value = "0";
        li1.Selected = true;
        dpselect.Items.Add(li1);

        for (i =8; i < 12; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds2.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds2.Tables[0].Rows[0].ItemArray[i].ToString();
            dpselect.Items.Add(li);

        }
    }


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
        dpdadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "";
        li1.Selected = true;
        dpdadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


        }

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




    //public void publicationbind()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
    //        //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
    //        NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
    //          ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
    //    }

    //    int i;
    //    ListItem li;
    //    li = new ListItem();
    //    dppubcent.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
    //    li.Value = "";
    //    li.Selected = true;
    //    dppubcent.Items.Add(li);


    //    if (ds.Tables.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li1;
    //            li1 = new ListItem();
    //            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            dppubcent.Items.Add(li1);
    //        }
    //    }


    //}
    public void bindpublication()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.updatestaus pub_cent1 = new NewAdbooking.BillingClass.classesoracle.updatestaus();
            ds = pub_cent1.publication_center(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select Publication---";
        li1.Value = "";
        li1.Selected = true;
        drp_publication.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drp_publication.Items.Add(li);
        }
    }


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

            NewAdbooking.BillingClass.classesoracle.billing_save bind = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = bind.bindbranch();

        }

        int i;
        ListItem li1;

        li1 = new ListItem();
        drpbranch.Items.Clear();
        li1.Text = "-Select Branch-";
        li1.Value = "";
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


    public void user_bind()
    {
        DataSet ds = new DataSet();

        if (Session["Admin"].ToString() == "yes")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();

                ds = obj.bind_user(Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();

                ds = obj.bind_user(Session["compcode"].ToString(),"");
            }


            drpuserid.Items.Clear();
            ListItem li11;
            li11 = new ListItem();
            li11.Text = "--Select User--";
            li11.Value = "0";
            li11.Selected = true;
            drpuserid.Items.Add(li11);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpuserid.Items.Add(li1);
            }
        }
        else
        {
            drpuserid.Items.Clear();
            ListItem li11;
            li11 = new ListItem();
            li11.Text = "--Select User--";
            li11.Value = "0";
            li11.Selected = true;
            drpuserid.Items.Add(li11);

            li11 = new ListItem();
            li11.Text = Session["Username"].ToString();
            li11.Value = Session["userid"].ToString();
            drpuserid.Items.Add(li11);






        }

    }




    protected void btn_click_Click(object sender, EventArgs e)
    {
        
        string branchnew = "";

        if (drpbranch.SelectedValue != "0")
        {
            branchnew = drpbranch.SelectedValue;
        }
        else
        {
            branchnew = "0";
        }


        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.biling_acknowledge abc = new NewAdbooking.BillingClass.Classes.biling_acknowledge();
            //ds = abc.fetchdata_acknow(txtfrmdate.Text, txttodate1.Text, branchnew, drp_publication.SelectedValue,adtype, acknowledege);
            ds1 = abc.fetchdata_acknow(txtfrmdate.Text, txttodate1.Text, branchnew, drp_publication.SelectedValue, drpuserid.SelectedValue, hidden_agency.Value, drppackage.SelectedValue, dpdadtype.SelectedValue, dpselect.SelectedValue, Session["dateformat"].ToString());
        }
      
           
        else
        {

            NewAdbooking.BillingClass.classesoracle.biling_acknowledge abc = new NewAdbooking.BillingClass.classesoracle.biling_acknowledge();
            ds1 = abc.fetchdata_acknow(txtfrmdate.Text, txttodate1.Text, branchnew, drp_publication.SelectedValue, drpuserid.SelectedValue, hidden_agency.Value, drppackage.SelectedValue, dpdadtype.SelectedValue, dpselect.SelectedValue, Session["dateformat"].ToString());
        }



        Session["RowLen"] = ds1.Tables[0].Rows.Count;
        hidden1.Value = Session["RowLen"].ToString();
        if (hidden1.Value == "0")
        {
            DataGrid1.DataSource = ds1;
            DataGrid1.DataBind();
            //div1.Disabled = true;
         //   ScriptManager.RegisterClientScriptBlock(this, typeof(billing_acknowledge), "cc", "checklenthbill()", true);
            return;



        }


        else
        {
            DataGrid1.DataSource = ds1;
            DataGrid1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, typeof(billing_acknowledge), "cc", "checkvisible()", true);
            return;
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        string sno1 = e.Item.Cells[1].Text;
        e.Item.Cells[1].Text = j.ToString();

        if (dpselect.SelectedValue == "Acknow")
        {
            if ((sno1 != "S.No") && (sno1 != "&nbsp;"))
            {
                e.Item.Cells[1].Text = j.ToString();

                //  if(e.Row.RowType!=(System.Web.UI.WebControls.DataControlRowTyp)Header)
                // e.Row.Cells[7].Text = "<input size=5 maxlength=3 id=\"d1\" value=\"" + e.Row.Cells[7].Text + "\">";
                e.Item.Cells[6].Text = "<input size=5 maxlength=20 id=\"d" + j + "\" value=" + ds1.Tables[0].Rows[K]["DELIVERY_MANNAME"].ToString() + "  disabled=true >";
                e.Item.Cells[7].Text = "<input size=5 maxlength=20 id=\"d" + j + "\"  value=" + ds1.Tables[0].Rows[K]["DELIVERY_DATE"].ToString() + " disabled=true >";
                e.Item.Cells[7].Text = "<input size=5 maxlength=20 id=\"d" + j + "\"  value=" + ds1.Tables[0].Rows[K]["DELIVERY_DATE"].ToString() + " disabled=true >";
                e.Item.Cells[8].Text = "<input size=5 maxlength=20 id=\"d" + j + "\" value=" + ds1.Tables[0].Rows[K]["ACKNOWLEDGE_DATE"].ToString() + " disabled=true >";
                e.Item.Cells[9].Text = "<input size=5 maxlength=20 id=\"d" + j + "\" value=" + ds1.Tables[0].Rows[K]["ACKNOW_REMARK"].ToString() + " disabled=true >";
                K++;

            }
        }
        else
        {
            if ((sno1 != "S.No") && (sno1 != "&nbsp;"))
            {

               
                //  if(e.Row.RowType!=(System.Web.UI.WebControls.DataControlRowTyp)Header)
                // e.Row.Cells[7].Text = "<input size=5 maxlength=3 id=\"d1\" value=\"" + e.Row.Cells[7].Text + "\">";
                e.Item.Cells[6].Text = "<input size=5 maxlength=20 id=\"d" + j + "\" >";
                e.Item.Cells[7].Text = "<input size=5 maxlength=20 id=\"d" + j + "\" >";
                e.Item.Cells[8].Text = "<input size=5 maxlength=20 id=\"d" + j + "\" value="+txt_confirm.Text+" disabled=true   >";
                e.Item.Cells[9].Text = "<input size=5 maxlength=20 id=\"d" + j + "\"   >";

            }
        }

        j++;
    }
}
