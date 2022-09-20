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

public partial class piregionpopup : System.Web.UI.Page
{
    string fromdate = "";
    string todate = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["compcode"] = "HT001";
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        fromdate = Session["fromdate"].ToString();
        todate =   Session["todate"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblanguage.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
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
            bindlanguage();
            bindagency();
            bindclient();
            binddest();
            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");
            txtfrmdate.Text = fromdate;
            txttodate1.Text = todate;

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
        for (i = 0; i < sortvalue.Tables[8].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sortvalue.Tables[8].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sortvalue.Tables[8].Rows[0].ItemArray[i].ToString();
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
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        dpdestination.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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
    public void bindlanguage()
    {
        NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objregion.bindlanguage(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[14].ToString();
        //  li1.Text = "--Select Language--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dplanguage.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dplanguage.Items.Add(li);


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

}
