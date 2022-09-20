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

public partial class BillRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["compcode"] = "HT001";
       // Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();

        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[61].ToString();
        //agencyname.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbaaddress.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();


        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[59].ToString();
        lbagcat.Text = ds.Tables[0].Rows[0].ItemArray[60].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[62].ToString();
        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));


        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
        if (!IsPostBack)
        {

            BtnRun.Attributes.Add("onclick", "javascript:return runclickbillregister();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

            bindpublication();
            binddest();
            bindregion();
            bindedition();
            bindadtype();
            bindagencytype();
            bindagencycat();
          //////// // bindproductnamne();
           
           // bindcategory();
            txtfrmdate.Focus();

            //BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
            //BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            ////dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
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
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        //for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        for (i = 0; i < destination.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }
    public void bindpublication()
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
        dppublication.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppublication.Items.Add(li);


        }
    }
    public void bindcategory()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        dpcategory.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        dpcategory.Items.Add(li1);

        for (i = 0; i < ds.Tables[3].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            // i = i + 1;
            li.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            dpcategory.Items.Add(li);

        }


    }
    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
 
        }

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billregister objregion = new NewAdbooking.classesoracle.billregister();
            ds = objregion.bindregionname(Session["compcode"].ToString());
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

    public void bindagencycat()
    {
       
        DataSet ds = new DataSet();
       
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
            ds = obj.bindagcat(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        ListItem li;
        li = new ListItem();
        dpagcat.Items.Clear();
        
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[26].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpagcat.Items.Add(li);
        


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagcat.Items.Add(li2);


        }
    }
    public void bindagencytype()
    {
       
        DataSet ds = new DataSet();
       
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(),Session["compcode"].ToString());
        }
        ListItem li;
        li = new ListItem();
        dpagtype.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[25].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpagtype.Items.Add(li);
        


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagtype.Items.Add(li2);


        }
    }
    public void bindedition()
    {

        DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
        //    ds = obj.bindedition();
        //}
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


        //int i;
        //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li2;
        //    li2 = new ListItem();
        //    li2.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    li2.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    dpedition.Items.Add(li2);


        //}
    }
    public void bindadtype()
    {

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
       
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 advname = new NewAdbooking.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpcategory.Items.Add(li1);
        

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpcategory.Items.Add(li);


        }
    }
    
    //public void bindproductnamne()
    //{
    //    ListItem li;
    //    li = new ListItem();
    //    dpprodcat.Items.Clear();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
    //    //li.Text = "-Select Edition Name-";
    //    li.Value = "0";
    //    li.Selected = true;

    //    dpprodcat.Items.Add(li);

    //}

   
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "",temp_product="";

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString()=="sql")
        //{
        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        //    ds = obj.billingonscreen(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dpprodcat.SelectedValue, dpcategory.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
            //ds = obj.billreg(txtfrmdate.Text, txttodate1.Text, dpregion.SelectedValue, dpprodcat.SelectedValue, dpcategory.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            if (dpagtype.SelectedValue != "0")
            {
                ds = obj.billreg(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, temp_pubcent, dpagtype.SelectedItem.Text, dpedition.SelectedValue, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue);
            }
            else
            {
                ds = obj.billreg(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, temp_pubcent, dpagtype.SelectedValue, dpedition.SelectedValue, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue);
            }

        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(BillRegister), "sa", "alert(\"searching criteria is not valid\");", true);
            return;

        }
        else
        {

            Response.Redirect("BillRegisterview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&edition=" + dpedition.SelectedValue + "&editionname=" + dpedition.SelectedItem.Text + "&region=" + dpregion.SelectedValue + "&regionname=" + dpregion.SelectedItem.Text + "&adtype=" + dpcategory.SelectedValue + "&agtype=" + dpagtype.SelectedValue + "&agtypetext=" + dpagtype.SelectedItem.Text + "&agcat=" + dpagcat.SelectedValue + "&agcattext=" + dpagcat.SelectedItem.Text + "&publicationcd=" + dppublication.SelectedValue + "&publication1=" + dppublication.SelectedItem.Text + "&adtypetext=" + dpcategory.SelectedItem.Text);
           // Response.Redirect("BillRegisterview.aspx?&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&edition=" + dpedition.SelectedValue + "&editionname=" + dpedition.SelectedItem.Text + "&region=" + dpregion.SelectedValue + "&regionname=" + dpregion.SelectedItem.Text + "&adtype=" + dpcategory.SelectedValue + "&agtype=" + dpagtype.SelectedValue + "&agcat=" + dpagcat.SelectedValue);
        }
       

       
    }

    //protected void dpregion_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string region = dpregion.SelectedValue;
    //    dpprodcat.Items.Clear();
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();

    //        ds = pub.product(region, Session["compcode"].ToString());
    //    }
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.billregister pub = new NewAdbooking.classesoracle.billregister();
    //        ds = pub.product(region, Session["compcode"].ToString());
    //    }
    //    ListItem li1;
    //    li1 = new ListItem();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpprodcat.Items.Add(li1);

    //    //dpadcatgory.Items.Clear();
    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpprodcat.Items.Add(li);



    //    }

    //}



    protected void dppublication_SelectedIndexChanged(object sender, EventArgs e)
    {
        string publication = dppublication.SelectedValue;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billregister obj = new NewAdbooking.classesoracle.billregister();
            ds = obj.bindpubedition(publication);
        }
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


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li2;
            li2 = new ListItem();
            li2.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li2.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpedition.Items.Add(li2);
        }
    }
    protected void dpedition_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


