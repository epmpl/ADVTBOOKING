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

public partial class pipublicationpopup : System.Web.UI.Page
{
    string fromdate="";
    string todate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["compcode"] = "HT001";
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        fromdate = Session["fromdate"].ToString();
        todate = Session["todate"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbpubnot.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pdf.xml"));
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        lbpdfsort.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        lbpdfsortvalue.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");
        if (!IsPostBack)
        {

            bindregion();
            bindpublication();
            bindagency();
            bindclient();
            bindstatus();
            binddest();
            bindsort();
            bindsortvalue();
            txtfrmdate.Text = fromdate;
            txttodate1.Text = todate;
            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");
            Btnreset.Attributes.Add("onclick", "javascript:return pipublicationreset();");
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

    public void bindpublication()
    {
        NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        int i;
        ListItem li;
        li = new ListItem();
        dppublication.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
        li.Value = "0";
        li.Selected = true;
        dppublication.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppublication.Items.Add(li1);
            }
        }


    }

    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dppubnot.Items.Clear();
        int i = 0;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
        // li1.Text = "--Select published--";
        li1.Value = "0";
        li1.Selected = true;
        dppubnot.Items.Add(li1);

        //  for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        //{

        ListItem li;
        li = new ListItem();

        li.Text = destination.Tables[1].Rows[0].ItemArray[0].ToString();
        i = i + 1;
        li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();

        dppubnot.Items.Add(li);

        ListItem li2;
        li2 = new ListItem();

        li2.Text = destination.Tables[1].Rows[0].ItemArray[6].ToString();
        i = i + 1;
        li2.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();

        dppubnot.Items.Add(li2);


   }


}
