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
using System.Data.SqlClient;

public partial class BarterBill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["compcode"] = "HT001";
       // Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        /////////////////////////////////////////////////////////////////////

        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[43].ToString();
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();


        /////////////////////////////////////////////////////////////////////
        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));
        if (!IsPostBack)
        {
            bindadtype();
            bindagecli();
            binddest();
            bindregion();
          bindproductnamne();
            
          BtnRun.Attributes.Add("onclick", "javascript:return runclickbillregister();");
          BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
          txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
          dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
          txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
          txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
          txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
          txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
          txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

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


    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        //ds = objregion.bindregion(Session["compcode"].ToString());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass objregion = new NewAdbooking.classesoracle.reportclass();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else
        {
            //NewAdbooking.classmysql.Class1 pub = new NewAdbooking.classmysql.Class1();
            //ds = objregion.product(region, Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
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

    


    public void bindproductnamne()
    {
        ListItem li;
        li = new ListItem();
        dpproduct .Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
       
        dpproduct.Items.Add(li);

    }

    
    protected void BtnRun_Click(object sender, EventArgs e)
    {
      //  NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        // ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
       // ds = obj.barter_report(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, dpproduct.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            ds = obj.barter_report(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, dpproduct.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.barter_report(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedItem.Text, dpproduct.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), dpadtype.SelectedValue, dpadcatgory.SelectedValue, dpagencycli.SelectedValue);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(BarterBill), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {
            //Response.Redirect("BarterBillview.aspx?regcode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&product=" + dpproduct.SelectedValue + "&productname=" + dpproduct.SelectedItem.Text);

            Response.Redirect("BarterBillview.aspx?regcode=" + dpregion.SelectedItem.Text + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&product=" + dpproduct.SelectedValue + "&productname=" + dpproduct.SelectedItem.Text + "&newadtype=" + dpadtype.SelectedValue + "&newcategory=" + dpadcatgory.SelectedValue + "&client=" + dpagencycli.SelectedValue);

        }

    }
    protected void dpregion_SelectedIndexChanged(object sender, EventArgs e)
    {       

        string region = dpregion.SelectedValue;
        dpproduct.Items.Clear();
        //NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();
        DataSet ds = new DataSet();
        //ds = pub.product(region, Session["compcode"].ToString());

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();
            ds = pub.product(region, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass pub = new NewAdbooking.classesoracle.reportclass();
            ds = pub.product(region, Session["compcode"].ToString());
        }
        else
        {
            //NewAdbooking.classmysql.bill pub = new NewAdbooking.classmysql.bill();
            //ds = pub.product(region, Session["compcode"].ToString());
        }
        
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
         li1.Selected = true;
      dpproduct .Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpproduct.Items.Add(li);



        }
        
    }
/////////////////////////////////////////////////////////////////////////////////////////////
    public void bindadtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adtype = new NewAdbooking.Classes.Class1();
            ds = adtype.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adtype = new NewAdbooking.classesoracle.reportclass();
            ds = adtype.adname(Session["compcode"].ToString());
        }
        else
        {
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //li1.Text="--Select Ad Type--";
        li1.Value = "0";
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




   
         
   
    protected void dpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpadtype.SelectedValue;

        dpadcatgory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adcat = new NewAdbooking.classesoracle.reportclass();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Value = "0";
        li1.Selected = true;
        dpadcatgory.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadcatgory.Items.Add(li);
        }

        //ScriptManager.RegisterClientScriptBlock(this, typeof(report), "sa", "document.getElementById('dpdadtype').focus();", true);
    
    }
    public void bindagecli()
    {
        // regionhidden = hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adagencycli = new NewAdbooking.Classes.Class1();
            ds = adagencycli.adagencycli(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adagencycli = new NewAdbooking.classesoracle.reportclass();
            ds = adagencycli.adagencycli(Session["compcode"].ToString());
        }
        else
        {
        }

        ListItem li1;
        li1 = new ListItem();
        dpagencycli.Items.Clear();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
        // li1.Text = "--Select Client Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpagencycli.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpagencycli.Items.Add(li);


        }
    }
}








