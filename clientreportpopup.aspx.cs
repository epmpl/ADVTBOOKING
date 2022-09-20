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

public partial class clientreportpopup : System.Web.UI.Page
{
    string fromdate;
    string todate;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["compcode"] = "HT001";
        hiddencompcode.Value = Session["compcode"].ToString();
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        fromdate = Session["fromdate"].ToString();
        todate = Session["todate"].ToString();
        //hi
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));
         lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbsubcat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbsubsubcat.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbbrand.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbvarient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbpackage.Text =ds.Tables[0].Rows[0].ItemArray[42].ToString();
        //BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();



        //lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //lbbrand.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        //lblagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        //lblclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //lblpackage.Text =ds.Tables[0].Rows[0].ItemArray[42].ToString();

        //BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        //heading.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pdf.xml"));
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        lbpdfsort.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        lbpdfsortvalue.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");
        Ajax.Utility.RegisterTypeForAjax(typeof(clientreportpopup));
         if (!Page.IsPostBack)
        {

            //bindpublication();
            bindregion();
            bindpublication();
            bindpackage();
            binddest();
            txtfrmdate.Text = fromdate;
            txttodate1.Text = todate;
            bindsortvalue();
            bindsort();
            dpdestination.Attributes.Add("onchange", "opendiv()");
             
             lstagency.Attributes.Add("onkeypress", "return keySort(this);");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
            lstclient.Attributes.Add("onclick", "javascript:return insertclient();");
            lstclient.Attributes.Add("onkeypress", "return keySort(this);");
            lstproduct.Attributes.Add("onclick", "javascript:return insertproduct();");
            lstproduct.Attributes.Add("onkeypress", "return keySort(this);");
            dpsubcat.Attributes.Add("onchange", "javascript:return selectsubcat();");
            drpbrand.Attributes.Add("onchange", "javascript:return selectvarient();");
            dpsubsubcat.Attributes.Add("onchange", "javascript:return selectbrand();");
            dpvarient.Attributes.Add("Onchange", "javascript:return selectvalue();");
            //  New Functions for date
            BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");

         }

    }
    public void bindsortvalue()
    {
        DataSet sortvalue = new DataSet();
        sortvalue.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        txtpdfsortvalue.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[23].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        txtpdfsortvalue.Items.Add(li1);

        //for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        for (i = 0; i < sortvalue.Tables[12].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sortvalue.Tables[12].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sortvalue.Tables[12].Rows[0].ItemArray[i].ToString();
            txtpdfsortvalue.Items.Add(li);

        }


    }

    public void bindsort()
    {
        DataSet sorting = new DataSet();
        sorting.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        txtpdfsort.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[22].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        txtpdfsort.Items.Add(li1);

        //for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        for (i = 0; i < sorting.Tables[4].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sorting.Tables[4].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sorting.Tables[4].Rows[0].ItemArray[i].ToString();
            txtpdfsort.Items.Add(li);

        }


    }

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("xml/frontend.xml"));
        dpdestination.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        dpdestination.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            dpdestination.Items.Add(li);

        }

    }

    public void bindpublication()
    {
        //regionhidden=hiddenregion.Value;

        NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        ds = misrep.publication(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
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
      //  ScriptManager2.SetFocus(txtproduct);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(clientreport), "sa", "document.getElementById('dppub1').focus();", true);
    }

    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string agency)
    {
        NewAdbooking.Classes.Class1 bindagen = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        //ds = bindagenname.bindagency(compcode, agency);
        ds = bindagen.bindagency(compcode, agency);
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindclientname(string compcode, string client)
    {

        NewAdbooking.Classes.Class1 objclient = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objclient.getClientName(compcode, client);
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getsubcategory(string prosubcode, string compcode)
    {
        NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objsubcat.prosubcat(compcode, prosubcode);
        return ds;

    }

    [Ajax.AjaxMethod]

    public DataSet getsubsubcategory(string procatcode, string prosubcatcode, string compcode)
    {
        NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objsubcat.prosubsubcat(procatcode, prosubcatcode, compcode);
        return ds;

    }

    [Ajax.AjaxMethod]

    public DataSet getvarient(string compcode, string brand)
    {
        NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objsubcat.proforvarient(compcode, brand);
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet getbrand(string product, string compcode)
    {
        NewAdbooking.Classes.Class1 objbrand = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objbrand.bindBrand(compcode, product);
        return ds;
    }
    public void bindregion()
    {
        string comcod = Session["compcode"].ToString();

        NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("xml/frontend.xml"));
        ds = misrep.region(comcod);
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        //li1.Text = "--Select Region--";
        li1.Value = "0";
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpregion.Items.Add(li);
        }
        // Txtdest.Focus();
    }
    [Ajax.AjaxMethod]
    public DataSet bindProductcategory(string compcode, string product)
    {
        NewAdbooking.Classes.Class1 objproduct = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objproduct.bindProductcategory(compcode, product, "0");
        return ds;
    }

    public void bindpackage()
    {
        // regionhidden = hiddenregion.Value;
        NewAdbooking.Classes.Class1 objpackage = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = objpackage.packagedesc(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        dppackage.Items.Clear();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[19].ToString();
        // li1.Text = "--Select Client Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppackage.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppackage.Items.Add(li);


        }
    }

    //public void bindagency()
    //{
    //    string agency=dpagency.Text;
    //    NewAdbooking.Classes.Class1 objagency = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = objagency.bindagency(Session["compcode"].ToString(), agency);
    //    ListItem li1;
    //    li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
    //    // li1.Text = "--Select Product--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpagency.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpagency.Items.Add(li);


    //    }
    //  }

    //public void bindclientname()
    //{
    //    string client=dpclient.Text;
    //    NewAdbooking.Classes.Class1 objclient = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = objclient.getClientName(Session["compcode"].ToString(), client);
    //    ListItem li1;
    //    li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
    //    // li1.Text = "--Select Product--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpclient.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpclient.Items.Add(li);


    //    }
    //  }
    // public void bindbrandname()
    //{
    //    string =dpclient.Text;
    //    NewAdbooking.Classes.Class1 objbrand = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = objbrand.objbrand.bindBrand(Session["compcode"].ToString(), product);
    //    ListItem li1;
    //    li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
    //    // li1.Text = "--Select Product--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dpclient.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpclient.Items.Add(li);


    //    }
    //  }


    //NewAdbooking.Classes.Class1 objbrand = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = objbrand.bindBrand(compcode, product);
    protected void dpsubcat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtproduct_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dpsubcat_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void dpsubsubcat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
