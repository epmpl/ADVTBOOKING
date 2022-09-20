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

public partial class pageprepop : System.Web.UI.Page
{

    string fromdate = "";
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

        lbpage.Text = ds.Tables[0].Rows[0].ItemArray[57].ToString();
        lbposition.Text = ds.Tables[0].Rows[0].ItemArray[58].ToString();
        lblagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblclient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[54].ToString();
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[44].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[45].ToString();
        lblpackage.Text = ds.Tables[0].Rows[0].ItemArray[42].ToString();
        //lbcity.Text = ds.Tables[0].Rows[0].ItemArray[53].ToString();
        lbstatus.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[50].ToString();

        
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/pdf.xml"));

        //lbladtype.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        lbpdfsort.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        lbpdfsortvalue.Text = ds1.Tables[1].Rows[0].ItemArray[20].ToString();
        BtnRun.Text = ds1.Tables[1].Rows[0].ItemArray[17].ToString();
        Btncancel.Text = ds1.Tables[1].Rows[0].ItemArray[18].ToString();
        Btnreset.Text = ds1.Tables[1].Rows[0].ItemArray[19].ToString();
        Btncancel.Attributes.Add("onclick", "javascript:return windowclose();");
       
        if (!Page.IsPostBack)
        {
            //edition();
            bindadvtype();
            // bindregion();
            bindagency();
            bindpackage();
            bindclient();
            publicationbind();
            edition();
            //// bindadvtype();
            binddest();
            bindpub();
            bindpage();
            bindposition();
            //// //binddest();
            bindstatus();
            txtfrmdate.Text = fromdate;
            txttodate1.Text = todate;
           //bindpackage();
            BtnRun.Attributes.Add("onclick", "drill_outpage();");

            bindsortvalue();
            bindsort();
            dpdestination.Attributes.Add("onchange", "opendiv()");


        }
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {

    }


    public void bindsortvalue()
    {
        DataSet sortvalue = new DataSet();
        sortvalue.ReadXml(Server.MapPath("XML/grouping.xml"));
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
        for (i = 0; i < sortvalue.Tables[2].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = sortvalue.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = sortvalue.Tables[2].Rows[0].ItemArray[i].ToString();
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

    public void bindposition()
    {
        NewAdbooking.Classes.Class1 position = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = position.position(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();
        // li1.Text = "--Select Position--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpposition.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpposition.Items.Add(li);


        }


    }


    public void bindpage()
    {
        NewAdbooking.Classes.Class1 page = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = page.page(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[13].ToString();
        //li1.Text = "--Select Page--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppage.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppage.Items.Add(li);


        }


    }
    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dpstatus.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
        // li1.Text = "Select Status";
        li1.Value = "0";
        li1.Selected = true;
        dpstatus.Items.Add(li1);

        for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();
            dpstatus.Items.Add(li);

        }




    }
    public void bindpackage()
    {
        NewAdbooking.Classes.Class1 adagencycli = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = adagencycli.adagencycli1(Session["compcode"].ToString());
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


    //public void bindregion()
    //{
    //    string region = dpregion.SelectedValue;

    //    dpregion.Items.Clear();
    //    NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = objregion.bindregion(Session["compcode"].ToString());
    //    ListItem li1;
    //    li1 = new ListItem();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    dpregion.Items.Add(li1);


    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpregion.Items.Add(li);

    //    }


    //}
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
    public void edition()
    {
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

    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {

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
        dpdadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpdadtype.Items.Add(li);


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
    }


    //protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string adtype = dpdadtype.SelectedValue;

    //    dpadcatgory.Items.Clear();
    //    NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = adcat.advtype(adtype, Session["compcode"].ToString());
    //    ListItem li1;
    //    li1 = new ListItem();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    // li1.Selected = true;
    //    dpadcatgory.Items.Add(li1);

    //    //dpadcatgory.Items.Clear();
    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpadcatgory.Items.Add(li);



    //    }
    //    //ScriptManager.RegisterClientScriptBlock(this,"typeof(re)")
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(pageprepop), "sa", "document.getElementById('dpdadtype').focus();", true);
    //}
    protected void txttodate1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void dppubcent_SelectedIndexChanged(object sender, EventArgs e)
    {



    }

    ////public void edition()
    ////{
    ////    ListItem li;
    ////    li = new ListItem();
    ////    dpedition.Items.Clear();
    ////    DataSet ds1 = new DataSet();
    ////    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    ////    li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
    ////    //li.Text = "-Select Edition Name-";
    ////    li.Value = "0";
    ////    li.Selected = true;
    ////    dpedition.Items.Add(li);

    ////}


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        // string pub_cent_name = DropDownList2.SelectedValue;

        //// dpadcatgory.Items.Clear();
        // NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
        // DataSet ds = new DataSet();
        // ds = adcat.pub_cent(pub_cent_name, compcode);
        // ListItem li1;
        // li1 = new ListItem();
        // li1.Text = "--Select pub Cent--";
        // li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        // li1.Selected = true;
        // dpadcatgory.Items.Add(li1);

        //     //dpadcatgory.Items.Clear();
        //     int i;
        //     for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //     {
        //         ListItem li;
        //         li = new ListItem();
        //         li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //         li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //         dpadcatgory.Items.Add(li);



        // }
    }

    //string compcode
    public void publicationbind()
    {
        NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        int i;
        ListItem li;
        li = new ListItem();
        pubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
        li.Value = "0";
        li.Selected = true;
        pubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                pubcent.Items.Add(li1);
            }
        }

    }


    //protected void dpadcatgory_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    protected void dppub1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void dppub1_SelectedIndexChanged1(object sender, EventArgs e)
    //{

    //}
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = pub_cent2.edition(dppub1.SelectedValue, pubcent.SelectedValue, Session["compcode"].ToString());
        int i;
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dpedition.Items.Add(li1);
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, typeof(pageprepop), "sa", "document.getElementById('pubcent').focus();", true);
    }
    protected void dppub1_SelectedIndexChanged2(object sender, EventArgs e)
    {
        NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = pub_cent2.edition(dppub1.SelectedValue, pubcent.SelectedValue, Session["compcode"].ToString());
        int i;
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        // li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dpedition.Items.Add(li1);
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, typeof(pageprepop), "sa", "document.getElementById('dppub1').focus();", true);
    }
    protected void BtnRun_Click1(object sender, EventArgs e)
    {

    }
}



