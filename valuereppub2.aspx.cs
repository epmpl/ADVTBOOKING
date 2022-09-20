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

public partial class valuereppub2 : System.Web.UI.Page
{

    string dateto, fromdt = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["compcode"] = "HT001";
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();

        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblpub.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pdf.xml"));
        lbladtype.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        lblpayement.Text = ds1.Tables[1].Rows[0].ItemArray[3].ToString();
        lblbillstatus.Text = ds1.Tables[1].Rows[0].ItemArray[0].ToString();
        lbpdfsort.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        lbpdfsortvalue.Text = ds1.Tables[1].Rows[0].ItemArray[21].ToString();
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        lbrange.Text = ds1.Tables[1].Rows[0].ItemArray[22].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

        if (!IsPostBack)
        {
            bindregion();
          //  bindproductnamne();
            //bindcategory();
            bindagency();
            bindpub();
            bindagecli();
            bindadvtype();
            bindstatus();
            bindpayment();
            binddest();
            bindsortvalue();
            bindsort();
            bindrange();
            Txtdest.Attributes.Add("onchange", "opendiv()");
            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");
            Btnreset.Attributes.Add("onclick", "javascript:return resetbarter();");
            txtfrmdate.Text = fromdt;

            txttodate1.Text = dateto;
        }




    }

    public void bindrange()
    {
        DataSet sorting = new DataSet();
        sorting.ReadXml(Server.MapPath("XML/pdf.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        txtrange.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[24].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        txtrange.Items.Add(li1);

        //for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        for (i = 0; i < sorting.Tables[2].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sorting.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sorting.Tables[2].Rows[0].ItemArray[i].ToString();
            txtrange.Items.Add(li);
            arrayval.Value += sorting.Tables[2].Rows[0].ItemArray[i].ToString() + "~";

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
        for (i = 0; i < sortvalue.Tables[5].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sortvalue.Tables[5].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sortvalue.Tables[5].Rows[0].ItemArray[i].ToString();
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

    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = objregion.bindregion(Session["compcode"].ToString());
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
   
    



    public void bindpub()
    {

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
        dppub.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub.Items.Add(li);


        }
    }



    public void bindagency()
    {

        NewAdbooking.Classes.Class1 adagency = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = adagency.agency(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        dpagency.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();

        li1.Value = "0";
        li1.Selected = true;
        dpagency.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagency.Items.Add(li);


        }
    }




    public void bindagecli()
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




    public void bindadvtype()
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




    public void bindstatus()
    {

        NewAdbooking.Classes.bill status = new NewAdbooking.Classes.bill();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));


        ds = status.billstatus();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpbillstatus.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpbillstatus.Items.Add(li);


        }





    }





    public void bindpayment()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.bill paymentobj = new NewAdbooking.Classes.bill();

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        ds = paymentobj.payment(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppayment.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppayment.Items.Add(li);


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
   

}
