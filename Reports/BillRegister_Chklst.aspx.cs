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
using System.Text.RegularExpressions;

public partial class BillRegister_Chklst : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["access"] = "0";
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(BillRegister_Chklst));


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/BillRegister_Chklst.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbedition.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbagtype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbpublication.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblbranch.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lblratecode.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
        lblfilteron.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
        lbladtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        Btnsummary.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        btndetail.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        btndaily.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblcolor.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        if (!IsPostBack)
        {

            BtnRun.Attributes.Add("OnClick", "javascript:return forreport();");
            Btnsummary.Attributes.Add("OnClick", "javascript:return forsummary();");
            btndetail.Attributes.Add("OnClick", "javascript:return fordetail();");
            btndaily.Attributes.Add("OnClick", "javascript:return dailyreportdata();");
        
            txtfrmdate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txttodate1.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            drpadtype.Attributes.Add("OnChange", "javascript:return BindUom();");

           // dppubcent.Attributes.Add("onchange", "javascript:return bind_edition13();");
            //dppub1.Attributes.Add("onchange", "javascript:return bind_edition13();");

           // bindpublication();
            bindadtype();
            bindagencytype();
            bindadvtype();
            publicationbind();
            txtfrmdate.Focus();
            bindratecode();
            BindBranch();
            //paymodereason();
        }
    }
    public void BindBranch()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Createuser branchname = new NewAdbooking.classesoracle.Createuser();
            ds = branchname.getbranch();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Createuser retainername = new NewAdbooking.Classes.Createuser();
            ds = retainername.retainer();
        }
        else
        {
            NewAdbooking.classmysql.Createuser retainername = new NewAdbooking.classmysql.Createuser();
            ds = retainername.retainer();
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Branch Name-";
        li1.Value = "0";
        li1.Selected = true;
        drpbranch.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpbranch.Items.Add(li);


        }
        drpbranch.SelectedValue = Session["revenue"].ToString();

    }

    //public void paymodereason()
    //{


    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        //Collection.Classes.ReceiptEntry recpt = new Collection.Classes.ReceiptEntry();
    //        //ds = recpt.bindreason(Session["compcode"].ToString(), doctyp);
    //    }
    //    else
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.Report.classesoracle.agencyclientbillingreport recpt = new NewAdbooking.Report.classesoracle.agencyclientbillingreport();
    //            ds = recpt.bindreason(Session["compcode"].ToString(), "");
    //        }

    //    if (ds.Tables[0].Rows.Count >= 0)
    //    {
    //        drppaymode.Items.Clear();

    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = "--Select Paymod/Reason--";
    //        li.Value = "0";
    //        li.Selected = true;
    //        drppaymode.Items.Add(li);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    //            {
    //                ListItem li1;
    //                li1 = new ListItem();

    //                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //                drppaymode.Items.Add(li1);
    //            }
    //        }
    //    }


    //}
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCategoryMaster advname = new NewAdbooking.Classes.AdCategoryMaster();

            ds = advname.adname(hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCategoryMaster advname = new NewAdbooking.classesoracle.AdCategoryMaster();
            ds = advname.adname(hiddencompcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.AdCategoryMaster advname = new NewAdbooking.classmysql.AdCategoryMaster();
            ds = advname.adname(hiddencompcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Ad Type--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }
    }
       
    public void bindratecode()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.DealReport advname = new NewAdbooking.Report.Classes.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.Report.classesoracle.DealReport advname = new NewAdbooking.Report.classesoracle.DealReport();
            ds = advname.bindratecode(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select RateCode--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpratecode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpratecode.Items.Add(li);


        }
    }
    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent1.pub_centbind(Session["compcode"].ToString(), Session["userid"].ToString(), Session["access"].ToString());
        }

        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }
        dppubcent.SelectedValue = Session["center"].ToString();


    }
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        return ds;
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;


        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{

        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);
            if (i == destination.Tables[0].Columns.Count - 1)
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    ListItem lit;
                    lit = new ListItem();
                    lit.Text = "On Screen with Amt";
                    lit.Value = "5";
                    Txtdest.Items.Add(lit);
                }
            }


        }
       

    }
   
    //public void bindpublication()
    //{
    //    //regionhidden=hiddenregion.Value;
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 advpub = new NewAdbooking.Report.Classes.Class1();
    //        ds = advpub.advpub(Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 advpub = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = advpub.advpub(Session["compcode"].ToString());
    //    }
    //    else
    //    {
    //    }

    //    ListItem li1;
    //    li1 = new ListItem();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

    //    li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    li1.Selected = true;
    //    dppub1.Items.Add(li1);

    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dppub1.Items.Add(li);


    //    }
    //}
   
    //public void bindagencycat()
    //{

    //    DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
    //        ds = obj.bindagcat(Session["userid"].ToString(), Session["compcode"].ToString());
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 obj = new NewAdbooking.Report.Classes.Class1();
    //        ds = obj.bindagcat(Session["userid"].ToString(), Session["compcode"].ToString());
    //    }
    //    ListItem li;
    //    li = new ListItem();
    //    dpagcat.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[26].ToString();
    //    //li.Text = "-Select Edition Name-";
    //    li.Value = "0";
    //    li.Selected = true;
    //    dpagcat.Items.Add(li);



    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li2;
    //        li2 = new ListItem();
    //        li2.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li2.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        dpagcat.Items.Add(li2);


    //    }
    //}
    public void bindagencytype()
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.billregister obj = new NewAdbooking.Report.Classes.billregister();
            ds = obj.bindagtype(Session["userid"].ToString(), Session["compcode"].ToString());
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

    public void bindadtype()
    {

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 advname = new NewAdbooking.Report.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 advname = new NewAdbooking.Report.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        //dpcategory.Items.Add(li1);


        //int i;
        //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    dpcategory.Items.Add(li);


        //}
    }



    protected void BtnRun_Click(object sender, EventArgs e)
    {
        

    }

    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtye)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }

        return ds;
    }
}

