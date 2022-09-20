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

public partial class scheduleregisterpopup : System.Web.UI.Page
{
   
    //string fromdt = "";
    //string dateto = "";
  
    protected void Page_Load(object sender, EventArgs e)
    {

        txtfrmdate.Text = Session["from"].ToString();
        txttodate1.Text = Session["to"].ToString();



         Session["compcode"] = "HT001";
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pdf.xml"));
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        lbpdfsort.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        lbpdfsortvalue.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");

        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        

        if (!IsPostBack)
        {

            bindpub();
            bindpackage();
            bindagency();
            bindclient();
            binddest();
            bindsort();
            bindsortvalue();
            Txtdest.Attributes.Add("onchange", "opendiv()");
            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");
            Btnreset.Attributes.Add("onclick", "javascript:return schedule();");

           

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
        for (i = 0; i < sortvalue.Tables[9].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sortvalue.Tables[9].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sortvalue.Tables[9].Rows[0].ItemArray[i].ToString();
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
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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

    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = advpub.advpub(Session["compcode"].ToString());
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


    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string fromdate = "";
        string todate = "";

        string package = "";
        //string product = "";
        //string category = "";
        string agency = "";
        string client = "";
        string publication = "";
        string destination = "";
        //fromdate = txtfrmdate.Text.Trim();
        //todate = txttodate1.Text.Trim();
        agency = dpagency.Text.Trim();
        client = dpclient.Text.Trim();
        publication = dppublication.Text.Trim();
        package = dppackage.Text.Trim();
        destination = Txtdest.Text.Trim();
        Response.Redirect("ScheduleRegisterView.aspx?fromdate=" + fromdate.Trim() + "&todate=" + todate.Trim() + "&agency=" + agency.Trim() + "&client=" + client.Trim() + "&publication=" + publication.Trim() + "&package=" + package.Trim() + "&schedule_drillout=" + "yes" + "&destination=" + destination.Trim());


    }
    protected void Txtdest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

