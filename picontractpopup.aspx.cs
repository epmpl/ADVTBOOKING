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

public partial class picontractpopup : System.Web.UI.Page
{
    string fromdate;
    string todate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["compcode"] = "HT001";
        Session["dateformat"] = "mm/dd/yyyy";
        fromdate = Session["fromdate"].ToString();
        todate = Session["todate"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lblanguage.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //lblpublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        DataSet ds2 = new DataSet();
        ds2.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbadtype.Text = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds2.Tables[0].Rows[0].ItemArray[1].ToString();



        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pdf.xml"));
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        lbpdfsort.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        lbpdfsortvalue.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");

        //lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        if (!IsPostBack)
        {

            bindregion();
            bindadtype();
            bindagency();
            bindclient();
            bindpackage();
            bindproductnamne();
            binddest();
            txtfrmdate.Text = fromdate;
            txttodate1.Text = todate;
            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");
            Btnreset.Attributes.Add("onclick", "javascript:return picontractppreset()");

            bindsortvalue();
            bindsort();
            dpdestination.Attributes.Add("onchange", "opendiv()");
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
        for (i = 0; i < sortvalue.Tables[10].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sortvalue.Tables[10].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sortvalue.Tables[10].Rows[0].ItemArray[i].ToString();
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
        dpdestination.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
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

    public void bindagency()
    {
        NewAdbooking.Classes.Class1 objagency = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objagency.agency(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
        // li1.Text = "--Select Product--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpagency.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpagency.Items.Add(li);


        }

    }

    public void bindclient()
    {
        // regionhidden = hiddenregion.Value;
        NewAdbooking.Classes.Class1 adagencycli = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = adagencycli.adagencycli(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        dpclient.Items.Clear();


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
        // li1.Text = "--Select Client Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpclient.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpclient.Items.Add(li);


        }
    }
    public void bindregion()
    {
        string region = dpregion.SelectedValue;

        dpregion.Items.Clear();
        NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objregion.bindregion(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
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

    public void bindadtype()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        ds = advname.adname(Session["compcode"].ToString());
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


    protected void dpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpadtype.SelectedValue;

        dpadcatgory.Items.Clear();
        NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = adcat.advtype(adtype, Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        // li1.Selected = true;
        dpadcatgory.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadcatgory.Items.Add(li);
        }
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

    public void bindproductnamne()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 objprod = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        //ds = objprod.bindProductcategory(Session["comnpcode"].ToString());  //, product, "0");
        ds = objprod.bindProductcategory(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        // li1.Text = "--Select Product--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpprodcat.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpprodcat.Items.Add(li);


        }
    }

}
