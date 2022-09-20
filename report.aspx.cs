using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class report : System.Web.UI.Page
{
 
    int cont;
    string fromdate;
    string dateto;

    string agency = "";
    string agency_name = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        //agency = Session["agency_code"].ToString();
        //hiddenagencycode.Value = agency;
       // agency_name = Session["agency_name"].ToString();
       // hiddenagency.Value = agency_name;

       // Session["compcode"] = "HT001";
        //Session["dateformat"]= "mm/dd/yyyy";
       
        Ajax.Utility.RegisterTypeForAjax(typeof(report));
      hiddendateformat.Value = Session["dateformat"].ToString();


        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/REPORT.xml"));
        lbadtype .Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbDateFrom .Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbPublicationCenter .Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();

        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();


        if (!Page.IsPostBack)
        {
            edition();
            bindadvtype();
            bindpub();
            binddest();
            publicationbind();
            
            //-------------for validation-----------------------------

            ////btnExecute.Attributes.Add("OnClick", "javascript:return exeissue();");
            //BtnRun.Attributes.Add("OnClick", "javascript:return runclick();");
            //BtnRun.Attributes.Add("OnClick", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("Onblur", "javascript:return dateformate();");
            //txttodate1.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            //txttodate1.Attributes.Add("Onchange", "javascript:return RetCheckdate_currtill('txttodate1');");
            //txtfrmdate.Attributes.Add("Onchange", "javascript:return RetCheckdate1_currtill('txtfrmdate');");
            //txtfrmdate.Attributes.Add("OnChange", "javascript:return  checkrundate();");


            BtnRun.Attributes.Add("OnClick", "javascript:return allagency_f28989();");
           // BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
          txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
          //  dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
            //BtnRun.Attributes.Add("OnClick", "javascript:return hello();");
          //---------------------end-----------------------------------------------
        }
    }


    //private void testing(string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    //{
    //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    DataSet ds = new DataSet();
    //   //ds = obj.spfun(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
               
    //int cont = ds.Tables[0].Rows.Count;
    ////}


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

        for (i = 0; i < destination.Tables[0].Columns.Count-1 ; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }


    }

    //protected void AspNetMessageBox(string strMessage)
    //{
    //    //strMessage = adminResource.GetStringFromResource(strMessage);
    //    string strAlert = "";
    //    strAlert = "alert('" + strMessage + "')";
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(report), "ShowAlert", strAlert, true);
    //}

    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string from_date = "";
        string to_date = "";
        string str = "";
        string str1 = "";
        for (int i = 1; i < dpadcatgory.Items.Count; i++)
        {

            if (dpadcatgory.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpadcatgory.Items[i].Value;
                    str1=dpadcatgory.Items[i].Text;
                }
                else
                {
                    str = str + "','" + dpadcatgory.Items[i].Value;
                    str1 = str1 + "','" + dpadcatgory.Items[i].Text;
                }
            }
        }

        //if (dpedition.SelectedValue  == "0")
        //{
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
          //  ds = obj.spfun(dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            ds = obj.spfun(dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"", "", "", "");
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spfun(dpdadtype.SelectedValue, str, txtfrmdate.Text, txttodate1.Text, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), dpedition.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(),"", "", "","");
        }
        else
        {

        }
        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(report), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;


            Response.Redirect("reportview.aspx?adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&edition=" + dpedition.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&destination=" + Txtdest.SelectedItem.Value + "&adcatname=" + str1 + "&adtypename=" + dpdadtype.SelectedItem.Text + "&editionname=" + dpedition.SelectedItem.Text);

        }
      
        //}
        //else if (Txtdest.SelectedItem.Text == "Excel Sheet")
            
        //{
          //  Response.Redirect("Excelsheet.aspx?adtype=" + dpdadtype.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" +  "&edition=" + dpedition.SelectedValue + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text);

           // }
    
 }

    private char alert(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    protected void txttdate_TextChanged(object sender, EventArgs e)
    {

    }


    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();    
       

        ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classesoracle.reportclass advname = new NewAdbooking.classesoracle.reportclass();


            ds = advname.adname(Session["compcode"].ToString());
        }
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
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
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


    protected void dpdadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpdadtype.SelectedValue;

        dpadcatgory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
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
        //ScriptManager.RegisterClientScriptBlock(this,"typeof(re)")
        ScriptManager.RegisterClientScriptBlock(this, typeof(report), "sa", "document.getElementById('dpdadtype').focus();", true);
    }
    protected void txttodate1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void dppubcent_SelectedIndexChanged(object sender, EventArgs e)
    {
         
       
    
    }

    //public void edition()
    //{
    //    ListItem li;
    //    li = new ListItem();
    //    dpedition.Items.Clear();
    //    DataSet ds1 = new DataSet();
    //    ds1.ReadXml(Server.MapPath("XML/frontend.xml"));        
    //    li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
    //    //li.Text = "-Select Edition Name-";
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
    ///////////////////////

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
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
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
       // li.Text = "-Select Publication Center-";
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

    protected void dpadcatgory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dppub1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void dppub1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
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
        ScriptManager.RegisterClientScriptBlock(this, typeof(report), "sa", "document.getElementById('dppub1').focus();", true);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            ds = pub_cent2.edition(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
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
        ScriptManager.RegisterClientScriptBlock(this, typeof(report), "sa", "document.getElementById('dppubcent').focus();", true);
    }
}



