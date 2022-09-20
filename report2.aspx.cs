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

public partial class report2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //Session["compcode"] = "HT001";
        //Session["dateformat"] = "mm/dd/yyyy";
        Ajax.Utility.RegisterTypeForAjax(typeof(report2));
       hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/reportagency.xml"));
        agencyname.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();      
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
       lbadcatgory .Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
       Session["dateto"] = txttodate1.Text;
       Session["fromdate"] = txtfrmdate.Text;
     
      
        if (!Page.IsPostBack)
        {

            bindpub();
            publicationbind();
            bindagency();
            binddest();
            bindadvtype();
           edition();


            ////BtnRun.Attributes.Add("OnClick", "javascript:return runclick();");
            //BtnRun.Attributes.Add("OnClick", "javascript:return runclick2();");
            //BtnRun.Attributes.Add("OnClick", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onblur", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txttodate1.Attributes.Add("OnBlur", "javascript:return RetCheckdate_currtill(txttodate1);");
            //txtfrmdate.Attributes.Add("OnBlur", "javascript:return RetCheckdate1_currtill(txtfrmdate);");

           BtnRun.Attributes.Add("OnClick", "javascript:return allagency_f2();");
           BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
           txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
           txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

           txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
           dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
           txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
           txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
           txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
           dpdadtype.Attributes.Add("OnChange", "javascript:return bindadcategory();");

        }


    }


    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string chk_excel = "";
        string from_date = "";
        string to_date = "";
        string str2 = "";

        string category = "";
        string str = "";
        string str1 = "";
        string agency = "";
        string agname = "";
        
        str = hiddenadcat.Value;
        str1 = hiddenadcatname.Value;

        agency = hiddenagencyname.Value;
        agname = hiddenagency.Value;
        //if (ChekAgency.Checked == true)
        //{
        //    str2 = "true";

        //}
        //else
        //{
        //    str2 = "false";
        //}

        //if (Txtdest.SelectedValue == "4")
        //{
        //    if (exe.Checked == true)
        //    {
        //        chk_excel = "1";//excel
        //    }
        //    else
        //    {
        //        chk_excel = "2";//csv
        //    }

        //}
        //else
        //{
        //    chk_excel = "0";//other than excel
        //}


       // category = dpadcatgory.Text;
           
      


        //string agencychk = "";//, clientchk="";
        //if (dpagencyna.Text == "")
        //{
        //    hiddenagencyname = "";
        //    hiddenagency.Value = "";
        //    hdnagencytxt.Value = "";
        //}
        //else
        //    agencychk = hiddenagency.Value;
        //string str = "";
        //string str1 = "";
        //string str2 = "";
        //for (int i = 1; i < dpadcatgory.Items.Count; i++)
        //{

        //    if (dpadcatgory.Items[i].Selected == true)
        //    {
        //        if (str == "")
        //        {
        //            str = dpadcatgory.Items[i].Value;
        //            str1 = dpadcatgory.Items[i].Text;
        //        }
        //        else
        //        {
        //            str = str + "," + dpadcatgory.Items[i].Value;
        //            str1 = str1 + "," + dpadcatgory.Items[i].Text;
        //        }
        //    }
        //}
        //if (ChekAgency.Checked ==true)
        //{
        //    str2 = "true";

        //}
        //else
        //{
        //    str2 = "false";
        //}
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
           // ds = obj.spAgency(dpagencyna.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            ds = obj.spAgency(agency, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            //ds = obj.spAgency(dpagencyna.SelectedValue, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"","","");
            ds = obj.spAgency(agency, dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "");//, dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString());
        
        }
        //int cont = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(report2), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
       // Response.Redirect("reportview2.aspx?agname=" + dpagencyna.SelectedValue + "&adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&agencyname=" + dpagencyna.SelectedItem.Text + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + dpedition.SelectedItem.Text + "&agencysubcode=" + str2);
        Response.Redirect("reportview2.aspx?agname=" + agency + "&adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&agencyname=" + dpagencyna.SelectedItem.Text + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + dpedition.SelectedItem.Text + "&agencysubcode=" + str2);
        }
        //else if (Txtdest.SelectedItem.Text == "Excel Sheet")
        //{
         //   Response.Redirect("Excelsheet.aspx?agname=" + dpagencyna.SelectedValue + "&adtype=" + str + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publication1=" + dppub1.SelectedItem.Text + "&pubcname=" + dppubcent.SelectedItem + "&edition=" + dpedition.SelectedItem);
       // }
    }
    //protected void dppub1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
    //    int i;
    //    ListItem li;
    //    li = new ListItem();
    //    dpedition.Items.Clear();
    //    li.Text = "-Select Edition Name-";
    //    li.Value = "0";
    //   // li.Selected = true;
    //    dpedition.Items.Add(li);


    //    if (ds.Tables.Count > 0)
    //    {
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li1;
    //            li1 = new ListItem();
    //            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            dpedition.Items.Add(li1);
    //        }
    //    }
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(report2), "sa", "document.getElementById('dppub1').focus();", true);
    //}


    public void bindpub()
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
            NewAdbooking.classesoracle.reportclass advpub = new NewAdbooking.classesoracle.reportclass();
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
    }


    //public void edition()
    //{
    //    ListItem li;
    //    li = new ListItem();
    //    dpedition.Items.Clear();

    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
    //   // li.Text = "-Select Edition Name-";
    //    li.Value = "0";
    //    li.Selected = true;
    //    dpedition.Items.Add(li);

    //}


    public void edition()
    {

        DataSet ds = new DataSet();

        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }

    /// //////////////////////////////
    [Ajax.AjaxMethod]
    public DataSet edition_bind(string pub, string pub_cent, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass pub_cent2 = new NewAdbooking.classesoracle.reportclass();
            ds = pub_cent2.edition(pub, pub_cent, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(pub, pub_cent, compcode);

        }
        return ds;
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        //li1.Text = "--Select Destination--";
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
    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass pub_cent1 = new NewAdbooking.classesoracle.reportclass();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else
        {
        }
       
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        //li.Text = "-Select Publication Center-";
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


    }
    public void bindagency()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adagency = new NewAdbooking.Classes.Class1();
            ds = adagency.agency(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adagency = new NewAdbooking.classesoracle.reportclass();
            ds = adagency.agency(Session["compcode"].ToString());
        }
        else
        {
        }
      
        ListItem li1;
        li1 = new ListItem();
        dpagencyna.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
      
        li1.Value = "0";
        li1.Selected = true;
        dpagencyna.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagencyna.Items.Add(li);
            if (Session["agency_name"].ToString().IndexOf(ds.Tables[0].Rows[i].ItemArray[2].ToString()) == 0)
            {
                dpagencyna.SelectedValue = li.Value;
                dpagencyna.Enabled = false;
            }

        }
        //if (Session["agency_name"].ToString() != "0" && Session["agency_name"].ToString() != "")
        //{
          
        //    dpagencyna.SelectedValue = Session["agency_name"].ToString();
        //    dpagencyna.Enabled = false;
        //}
       
    }
    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass advname = new NewAdbooking.classesoracle.reportclass();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        //li1.Text = "--Select Ad Type--";
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

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getCategory(string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adcat = new NewAdbooking.classesoracle.reportclass();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        return ds;
    }
    protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpdadtype.SelectedValue;

        dpadcatgory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass adcat = new NewAdbooking.classesoracle.reportclass();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else
        {
        }
   
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        //li1.Text = "--Select Ad Category--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
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
        ScriptManager.RegisterClientScriptBlock(this, typeof(report2), "sa", "document.getElementById('dpdadtype').focus();", true);
    }
    protected void dppubcent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        //int i;
        //ListItem li;
        //li = new ListItem();
        //dpedition.Items.Clear();
        //li.Text = "-Select Edition Name-";
        //li.Value = "0";
        //li.Selected = true;
        //dpedition.Items.Add(li);


        //if (ds.Tables.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li1;
        //        li1 = new ListItem();
        //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        dpedition.Items.Add(li1);
        //    }
        //}
    }
    protected void dppubcent_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void dppubcent_SelectedIndexChanged2(object sender, EventArgs e)
    {
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
                ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.reportclass pub_cent2 = new NewAdbooking.classesoracle.reportclass();
                ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
            }
            else
            {
            }
           
            int i;
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

        }
        ScriptManager.RegisterClientScriptBlock(this, typeof(report2), "sa", "document.getElementById('dppubcent').focus();", true);  
    }
}
