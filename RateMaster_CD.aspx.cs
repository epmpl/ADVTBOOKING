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

public partial class RateMaster_CD : System.Web.UI.Page
{
    string dateformat = "";
    string userid = "";
    string compcode = "";
    DataSet dk = new DataSet();
    DataSet ds_tbl = new DataSet();
    //DataRow my_row;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session has been expired\");window.close();</script>");
            return;

        }
      //  pagedef();
        //slabgrid.Visible = true;
        //slabdatagrid.Visible = true;

        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = false;
        btnCancel.Enabled = true;
        btnfirst.Enabled = false;
        btnprevious.Enabled = false;
        btnnext.Enabled = false;
        btnlast.Enabled = false;
        btnExit.Enabled = true;
        if (!Page.IsPostBack)
        {
            DataSet ds = new DataSet();
            // Read in the XML file
            ds.ReadXml(Server.MapPath("XML/button.xml"));
            btnNew.ImageUrl = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            btnSave.ImageUrl = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            btnModify.ImageUrl = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            btnQuery.ImageUrl = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            btnExecute.ImageUrl = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            btnCancel.ImageUrl = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            btnfirst.ImageUrl = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            btnprevious.ImageUrl = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            btnnext.ImageUrl = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            btnlast.ImageUrl = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            btnDelete.ImageUrl = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            btnExit.ImageUrl = ds.Tables[0].Rows[0].ItemArray[11].ToString();


            DataSet objDataset = new DataSet();
            objDataset.ReadXml(Server.MapPath("XML/RateMaster_CD.xml"));
            lbladtype.Text = objDataset.Tables[0].Rows[0].ItemArray[0].ToString();
            lbladcategory.Text = objDataset.Tables[0].Rows[0].ItemArray[1].ToString();
            lblsubcategory.Text = objDataset.Tables[0].Rows[0].ItemArray[2].ToString();
            lblsubsubcategory.Text = objDataset.Tables[0].Rows[0].ItemArray[3].ToString();
            RadioButton1.Text = objDataset.Tables[0].Rows[0].ItemArray[4].ToString();
            RadioButton2.Text = objDataset.Tables[0].Rows[0].ItemArray[5].ToString();
            lblscheme.Text = objDataset.Tables[0].Rows[0].ItemArray[6].ToString();
            lbluom.Text = objDataset.Tables[0].Rows[0].ItemArray[7].ToString();
            lblcolor.Text = objDataset.Tables[0].Rows[0].ItemArray[8].ToString();
            lblline.Text = objDataset.Tables[0].Rows[0].ItemArray[9].ToString();
          //  lbfrminsert.Text = objDataset.Tables[0].Rows[0].ItemArray[10].ToString();
          //  lbtoinsert.Text = objDataset.Tables[0].Rows[0].ItemArray[11].ToString();
            lbrate.Text = objDataset.Tables[0].Rows[0].ItemArray[12].ToString();
            lbextrarate.Text = objDataset.Tables[0].Rows[0].ItemArray[13].ToString();
            Adslabs.Text = objDataset.Tables[0].Rows[0].ItemArray[15].ToString();
          //  lblrate1.Text = objDataset.Tables[0].Rows[0].ItemArray[12].ToString();
         //   lblexrate1.Text = objDataset.Tables[0].Rows[0].ItemArray[13].ToString();
            ediname.Text=objDataset.Tables[0].Rows[0].ItemArray[16].ToString();
            lbltxtfrom.Text = objDataset.Tables[0].Rows[0].ItemArray[17].ToString();

            compcode = Convert.ToString(Session["compcode"].ToString());
            userid = Convert.ToString(Session["userid"]);
            hiddenuserid.Value = userid;
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenusername.Value = Session["username"].ToString();
            hiddencurrency.Value=Session["currency"].ToString();
            hiddendateformat.Value=Session["dateformat"].ToString();
            

            Ajax.Utility.RegisterTypeForAjax(typeof(RateMaster_CD));
            btndeleterow.Attributes.Add("OnClick", "javascript:return deleteRow();");
            btninsertrow.Attributes.Add("OnClick", "javascript:return addClick();");
            btnNew.Attributes.Add("onClick","javascript:return newclick();");
            btnSave.Attributes.Add("onclick", "javascript:return saveclick();");
            btnModify.Attributes.Add("onClick","javascript:return modifyclick();");
            btnExecute.Attributes.Add("onClick", "javascript:return executeclick();");
            btnCancel.Attributes.Add("onClick","javascript:return clearclick();");
            btnQuery.Attributes.Add("onClick", "javascript:return queryclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return prevclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnDelete.Attributes.Add("onClick","javascript:return deleteclick();");
            btnExit.Attributes.Add("onClick","javascript:return exitclick();");
            RadioButton1.Attributes.Add("onClick", "javascript:return onclick_radiobutton();");
            RadioButton2.Attributes.Add("onClick", "javascript:return onclick_radiobutton();");
            drpadtype.Attributes.Add("OnChange", "javascript:return onchage_adtype();");
            listcategory.Attributes.Add("OnChange", "javascript:return onchange_cat();");
            listsubcategory.Attributes.Add("OnChange", "javascript:return onchange_cat4();");
            drpuom.Attributes.Add("onchange", "javascript:return onchange_uom();");
            Adslabs.Attributes.Add("onClick","javascript:return adslabclick();");
          //  btnadd.Attributes.Add("onClick","javascript:return showtablegrid();");

            txtrate.Attributes.Add("onchange", "javascript:return chkamount('txtrate');");
            txtextrarate.Attributes.Add("onchange", "javascript:return chkamount('txtextrarate');");
            txtvalidfrom.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            adtypedata(compcode);
            bindcolor();
            scheme(compcode);
            //slabdatagrid.Visible = true;

            if (btnNew.Enabled == false)
                btnNew.ImageUrl = ds.Tables[1].Rows[0].ItemArray[0].ToString();
            if (btnSave.Enabled == false)
                btnSave.ImageUrl = ds.Tables[1].Rows[0].ItemArray[1].ToString();
            if (btnModify.Enabled == false)
                btnModify.ImageUrl = ds.Tables[1].Rows[0].ItemArray[2].ToString();
            if (btnQuery.Enabled == false)
                btnQuery.ImageUrl = ds.Tables[1].Rows[0].ItemArray[3].ToString();
            if (btnExecute.Enabled == false)
                btnExecute.ImageUrl = ds.Tables[1].Rows[0].ItemArray[4].ToString();
            if (btnCancel.Enabled == false)
                btnCancel.ImageUrl = ds.Tables[1].Rows[0].ItemArray[5].ToString();
            if (btnfirst.Enabled == false)
                btnfirst.ImageUrl = ds.Tables[1].Rows[0].ItemArray[6].ToString();
            if (btnprevious.Enabled == false)
                btnprevious.ImageUrl = ds.Tables[1].Rows[0].ItemArray[7].ToString();
            if (btnnext.Enabled == false)
                btnnext.ImageUrl = ds.Tables[1].Rows[0].ItemArray[8].ToString();
            if (btnlast.Enabled == false)
                btnlast.ImageUrl = ds.Tables[1].Rows[0].ItemArray[9].ToString();
            if (btnDelete.Enabled == false)
                btnDelete.ImageUrl = ds.Tables[1].Rows[0].ItemArray[10].ToString();
            if (btnExit.Enabled == false)
                btnExit.ImageUrl = ds.Tables[1].Rows[0].ItemArray[11].ToString();
        }

    }

   /* public void pagedef()
    {
        drpadtype.Enabled = false;
        listcategory.Enabled = false;
        listsubcategory.Enabled = false;
        listsubsubcatgory.Enabled = false;
        RadioButton1.Enabled = false;
        RadioButton2.Enabled = false;
        drpmainedilist.Enabled = false;
        drpuom.Enabled = false;
        drpcolor.Enabled = false;
        txtline.Enabled = false;
        txtrate.Enabled = false;
        txtextrarate.Enabled = false;
        Adslabs.Enabled = false;
        lblscheme.Enabled = false;
    }*/


    public void scheme(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bind = new NewAdbooking.Classes.RateMaster();
            ds = bind.bindscheme(compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
                ds = bind.bindscheme(compcode);

            }
            else
            {
                NewAdbooking.classmysql.RateMaster bind = new NewAdbooking.classmysql.RateMaster();
                ds = bind.bindscheme(compcode);

            }
        int i;
        ListItem li1;

        li1 = new ListItem();
        drpscheme.Items.Clear();
        li1.Text = "--Select Scheme--";
        li1.Value = "0";
        li1.Selected = true;
        drpscheme.Items.Add(li1);
        string name = "";
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (name != ds.Tables[0].Rows[i].ItemArray[0].ToString())
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpscheme.Items.Add(li);
            }
            name = ds.Tables[0].Rows[i].ItemArray[0].ToString();

        }

    }

    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            ds = bind.adtypbind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
                ds = bind.adtypbind(compcode);

            }
        else
        {
            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
            ds = bind.adtypbind(compcode);
        }
      

        int i;
        ListItem li1;

        li1 = new ListItem();
        drpadtype.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        drpadtype.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpadtype.Items.Add(li);


        }

    }

    private void bindcolor()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();
            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();
                ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();
                ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
            }

        drpcolor.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Color-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcolor.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcolor.Items.Add(li);

            }

        }


    }

    [Ajax.AjaxMethod]
    public DataSet pkg_adcat_uom_bind(string compcode, string adtype, string center)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategoryRate(compcode, adtype, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bind = new NewAdbooking.classesoracle.RateMaster();
            ds = bind.advdatacategory(compcode, adtype, center);

        }
        else
        {
            NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
            ds = bind.advdatacategory(compcode, adtype);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindedition(string flag,string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.RateMaster bind = new NewAdbooking.classmysql.RateMaster();
            ds = bind.EditionBind(flag,adtype);
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet adcatclick(string compcode, string adcat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();
            ds = cls_comb.advdatasubcatcat(compcode, adcat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();
            ds = cls_comb.advdatasubcatcat(compcode, adcat);

        }
        else
        {
            NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();
            ds = cls_comb.advdatasubcatcat(compcode, adcat);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindsubcats(string compcode, string adscat, string value)
    {
        DataSet dcat4 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bingcat4 = new NewAdbooking.Classes.RateMaster();

            dcat4 = bingcat4.bindscategory4(compcode, adscat, value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bingcat4 = new NewAdbooking.classesoracle.RateMaster();

            dcat4 = bingcat4.bindscategory4(compcode, adscat, value);

        }
        else
        {
            NewAdbooking.classmysql.RateMaster bingcat4 = new NewAdbooking.classmysql.RateMaster();
            dcat4 = bingcat4.bindscategory4(compcode, adscat, value);
        }

        return dcat4;
    }
    [Ajax.AjaxMethod]
    public DataSet binddesc(string uom)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binduom = new NewAdbooking.Classes.RateMaster();
            ds = binduom.getuom_desc(compcode, uom);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster binduom = new NewAdbooking.classesoracle.RateMaster();
                ds = binduom.getuom_desc(compcode, uom);

            }
            else
            {
                NewAdbooking.classmysql.RateMaster binduom = new NewAdbooking.classmysql.RateMaster();
                ds = binduom.getuom_desc(compcode, uom);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public void saverate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type_, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            /*new change ankur 17 feb*/
            NewAdbooking.Classes.RateMaster insert = new NewAdbooking.Classes.RateMaster();
            // dii = insert.insertintorate(Session["compcode"].ToString(), Session["userid"].ToString(), ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area);
            insert.insertintorate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area, type_, agencycode, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max,"1","","","","","");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster insert = new NewAdbooking.classesoracle.RateMaster();
            //dii = insert.insertintorate(Session["compcode"].ToString(), Session["userid"].ToString(), ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area);
            insert.insertintorate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area, type_, agencycode, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max,"1","","","","","");

        }
        else
        {
            NewAdbooking.classmysql.RateMaster insert = new NewAdbooking.classmysql.RateMaster();
            insert.insertintorate(compcode, userid, ratecode, adtype, rategroupcode, adcategory, currency, adsubcategory, package, packagedesc, uom, sizefrom, sizeto, consumption, color, colorchrty, weekdrate, weeminrate, extweerate, focusdarate, focminrate, focexrate, validfromdate, validtill, remarks, premium, premiumval, rateuniqueid, weekendrate, weekendmin, weekextra, minadarea, editionfrom, editionto, flramount, flrdiscount, scheme, adscat4, adscat5, adscat6, frominsert, toinsert, agtype, clientcat, max_area, type_, agencycode, dateformat, pubcenter, rate_sun, rate_mon, rate_tue, rate_wed, rate_thu, rate_fri, rate_sat, rate_sun_extra, rate_mon_extra, rate_tue_extra, rate_wed_extra, rate_thu_extra, rate_fri_extra, rate_sat_extra, width_max);
        }
    }

   
    [Ajax.AjaxMethod]
    public DataSet checkrate(string compcode, string userid, string rateuniqueid)
    {
        DataSet chk_query = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.RateMaster chk = new NewAdbooking.classmysql.RateMaster();
            chk_query = chk.RateCheck(compcode, userid,rateuniqueid);
        }
        return chk_query;
    }
    

    [Ajax.AjaxMethod]
    public DataSet executerate(string compcode, string adtype, string adcat, string uomcode, string editioncode, string schemecode, string dateformat)
    {
        DataSet execute_query = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
       {
            NewAdbooking.classmysql.RateMaster execute = new NewAdbooking.classmysql.RateMaster();
            execute_query = execute.executedate(compcode, adtype, adcat, uomcode, editioncode, schemecode, dateformat);
        }
        return execute_query;
    }

    [Ajax.AjaxMethod]
    public void modifyrate(string compcode,string userid ,string rateuniqueid,string rate,string extrarate,string sizeto)
    {
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
       {
            NewAdbooking.classmysql.RateMaster execute = new NewAdbooking.classmysql.RateMaster();
            execute.modifyrate(compcode, rateuniqueid, rate, extrarate, sizeto);
        }
    }

    [Ajax.AjaxMethod]
    public void deleterate(string rateuniqueid, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            NewAdbooking.classmysql.RateMaster execute = new NewAdbooking.classmysql.RateMaster();
            execute.deleteratemast(rateuniqueid, compcode);
        }
    }


   /* protected void btnadd_Click(object sender, EventArgs e)
    {
        slabgrid.Visible = true;
       

        DataColumn mycolumn = new DataColumn();
        DataTable mydatatable = new DataTable();
        DataRow myrow1;

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "FromInsert";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ToInsert";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Rate";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ExtraRate";

        mydatatable.Columns.Add(mycolumn);


         myrow1 = mydatatable.NewRow();
         
         myrow1["FromInsert"] = txtfrminsert.Text;
         myrow1["ToInsert"] = txttoinsert.Text;
         myrow1["Rate"] = txtrate1.Text;
         myrow1["ExtraRate"] = txtexrate1.Text;
         
         mydatatable.Rows.Add(myrow1);
         
       //  dk.Tables.Add(mydatatable);
         ds_tbl.Tables.Add(mydatatable);
        
         DataView dv = new DataView();
         dv = ds_tbl.Tables[0].DefaultView;

         slabgrid.DataSource = dv;
         slabgrid.DataBind();
    }*/
}
