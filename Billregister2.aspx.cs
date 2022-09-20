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
public partial class Billregister2 : System.Web.UI.Page
{
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string datefrom1="";
    string dateto1 = "";
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
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();           
        heading.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();  
        
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
        lbrange.Text = ds1.Tables[1].Rows[0].ItemArray[22].ToString();
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        dateto = Session ["dateto"].ToString();
        fromdt = Session ["fromdate"].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");
       // BtnRun.Attributes.Add("OnClick", "javascript:return sortvalidation();");

        if (!IsPostBack)
        {           
            bindregion();
            bindproductnamne();
            bindcategory();
            bindagency(); 
            bindpub();
            bindagecli();
            bindadvtype();
            bindstatus();
            bindpayment();
            bindrange();
            binddest();
//________________for pdf sorting_________________________
            bindsortvalue();
            bindsort();
            Txtdest.Attributes.Add("onchange", "opendiv()");
 //________________End_________________________


            BtnRun.Attributes.Add("onclick", "javascript:return drill_out();");
            Btnreset.Attributes.Add("onclick", "javascript:return resetbill();");

            txtfrmdate.Text = fromdt;

            txttodate1.Text = dateto;
        }
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        //Response.Redirect("BillRegisterview.aspx");
    }
    

    public void bindcategory()
    {
       // DataSet ds = new DataSet();
       // ds.ReadXml(Server.MapPath("XML/Report_destination.xml"));
       // DataSet ds1 = new DataSet();
       // ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
       //// dpcategory.Items.Clear();
       // int i;
       // ListItem li1;
       // li1 = new ListItem();
       // li1.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
       // //li1.Text = "--Select Destination--";
       // li1.Value = "0";
       // li1.Selected = true;
       // //dpcategory.Items.Add(li1);

       // for (i = 0; i < ds.Tables[3].Columns.Count; i++)
       // {
       //     ListItem li;
       //     li = new ListItem();
       //     li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
       //     // i = i + 1;
       //     li.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
       //     dpcategory.Items.Add(li);

       // }
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
            arrayval.Value+= sorting.Tables[2].Rows[0].ItemArray[i].ToString() + "~";

        }


    }

    //________________for pdf sorting_________________________

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
    //_______________End_________________________


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
    public void bindproductnamne()
    {
        //ListItem li;
        //li = new ListItem();
        //dpprodcat.Items.Clear();
        //DataSet ds1 = new DataSet();
        //ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        //li.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        ////li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;

        //dpprodcat.Items.Add(li);

    }

    protected void dpregion_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        string region = dpregion.SelectedValue;
        //dpprodcat.Items.Clear();
        NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();
        DataSet ds = new DataSet();
        ds = pub.product(region, Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        //dpprodcat.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //dpprodcat.Items.Add(li);



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
        dppub .Items.Add(li1);

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
        dpagency .Items.Clear();

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
        dpclient .Items.Clear();


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
        dpadtype .Items.Add(li1);

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

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
       dpbillstatus .Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
        // li1.Text = "Select Status";
        li1.Value = "0";
        li1.Selected = true;
        dpbillstatus.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            dpbillstatus.Items.Add(li);

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





    public void bindpayment()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.bill paymentobj = new NewAdbooking.Classes.bill();
        
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        ds = paymentobj.payment (Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppayment .Items.Add(li1);

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




    protected void BtnRun_Click1(object sender, EventArgs e)
    {
        string fromdate = "";
        string todate = "";
       
        string region = "";
        string product = "";
        string category = "";
        string agency = "";
        string client = "";
        string publication = "";
        string adtype = "";
        string payment = "";
        string billstatus = "";
        fromdate=txtfrmdate.Text.Trim();
        todate= txttodate1.Text.Trim();
        region=dpregion.Text.Trim();
        //product=dpprodcat.Text.Trim();
        //category = dpcategory.Text.Trim();
        agency = dpagency.Text.Trim();
        client = dpclient.Text.Trim();
        publication = dppub.Text.Trim();
        adtype = dpadtype.Text.Trim();
        payment = dppayment.Text.Trim();
        billstatus = dpbillstatus.Text.Trim();
        //Response.Redirect("BillRegisterview.aspx?fromdate=" + fromdate.Trim() + "&todate=" + todate.Trim() + "&region=" + region.Trim() + "&product=" + product.Trim() + "&category=" + category.Trim() + "&agency=" + agency.Trim() + "&client=" + client.Trim() + "&publication=" + publication.Trim() + "&adtype=" + adtype + "&payment=" + payment.Trim() + "&billstatus=" + billstatus.Trim() + "&drilout=" + "yes" + "&destination="+"1");
    }

    
}
