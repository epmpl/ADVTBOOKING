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

public partial class Execondetail : System.Web.UI.Page
{
    public static int numberDiv;
    public static int flag=0;
    string userid, compcode;
    int j = 0;
    int exno = 0;
    string show,message,bname;
    DataSet dk1 = new DataSet();
    DataSet dk = new DataSet();
     DataRow my_row;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here

        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddenuserid.Value = Session["userid"].ToString();

            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenteamcode.Value = Request.QueryString["teamcode"];
            show = Request.QueryString["show"].ToString();
            bname = Request.QueryString["branchname"].ToString();
            hiddenshow.Value = Request.QueryString["show"].ToString();
            compcode = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            userid = Session["userid"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your login session has been expired');window.close();</script>");
            return;
        }
        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/executivemaster.xml"));
        executivename.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        designation.Text = objDataSet.Tables[0].Rows[0].ItemArray[14].ToString();
        city.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        state.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        district.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        status.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        address.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        street.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
        country.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
        pincode.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
        phoneno.Text = objDataSet.Tables[0].Rows[0].ItemArray[12].ToString();
        reportto.Text = objDataSet.Tables[0].Rows[0].ItemArray[13].ToString();
        taluka.Text = objDataSet.Tables[0].Rows[0].ItemArray[16].ToString();
        repname.Text = objDataSet.Tables[0].Rows[0].ItemArray[17].ToString();
        adtype.Text = objDataSet.Tables[0].Rows[0].ItemArray[18].ToString();
        adcategory.Text = objDataSet.Tables[0].Rows[0].ItemArray[19].ToString();
        lblbranch1.Text = objDataSet.Tables[0].Rows[0].ItemArray[20].ToString();
        lblemail.Text = objDataSet.Tables[0].Rows[0].ItemArray[21].ToString();
        lblmobile.Text = objDataSet.Tables[0].Rows[0].ItemArray[22].ToString();
        lbemcode.Text = objDataSet.Tables[0].Rows[0].ItemArray[24].ToString();
        lblmail.Text = objDataSet.Tables[0].Rows[0].ItemArray[25].ToString();
        lblattachment.Text = objDataSet.Tables[0].Rows[0].ItemArray[26].ToString();
        lblpaymode.Text = objDataSet.Tables[0].Rows[0].ItemArray[27].ToString();



        Ajax.Utility.RegisterTypeForAjax(typeof(Execondetail));

       if (objDataSet.Tables.Count > 1)
        {
            if (objDataSet.Tables[1].Rows[0].ItemArray[0].ToString() == "hide")
            {
                designation.Attributes.Add("style", "display:none");
                txtdesignation.Attributes.Add("style", "display:none");
            }
            if (objDataSet.Tables[1].Rows[0].ItemArray[1].ToString() == "hide")
            {
                taluka.Attributes.Add("style", "display:none");
                drptaluka.Attributes.Add("style", "display:none");
            }
            if (objDataSet.Tables[1].Rows[0].ItemArray[2].ToString() == "hide")
            {
                repname.Attributes.Add("style", "display:none");
                txtrepname.Attributes.Add("style", "display:none");
            }
            if (objDataSet.Tables[1].Rows[0].ItemArray[3].ToString() == "hide")
            {
                reportto.Attributes.Add("style", "display:none");
                drprepot.Attributes.Add("style", "display:none");
            }
            if (objDataSet.Tables[1].Rows[0].ItemArray[4].ToString() == "hide")
            {
                adtype.Attributes.Add("style", "display:none");
                drpadtype.Attributes.Add("style", "display:none");
            }
            if (objDataSet.Tables[1].Rows[0].ItemArray[5].ToString() == "hide")
            {
                adcategory.Attributes.Add("style", "display:none");
                lbadcategory.Attributes.Add("style", "display:none");
            }
        }

        if (!Page.IsPostBack)
        {
            if (show == "1")
            {
                btnsubmit.Enabled = true;
                btnselect.Enabled = true;
                txtaddress.Enabled = true;
                txtstate.Enabled = true;
                txtstreet.Enabled = true;
                drpstatus.Enabled = true;
                drprepot.Enabled = true;
                txtdesignation.Enabled = true;
                txtcountry.Enabled = true;
                txtexename.Enabled = true;
                drpcity.Enabled = true;
                txtpin.Enabled = true;
                txtphone.Enabled = true;
                txtdistrict.Enabled = true;
                drptaluka.Enabled = true;
                txtrepname.Enabled = true;
                drpadtype.Enabled = true;
                btndelete.Enabled = false;
                drpbranch1.Enabled = true;
                txtcraditlimit.Enabled = true;
                txtemail.Enabled = true; 
                txtmobile.Enabled = true;
                txtemcode.Enabled = true;
                txtemailid.Enabled = true;
                attachment1.Enabled = true;
                txtpaymode.Enabled = true;
            }
            else if (show == "0")
            {
                btnsubmit.Enabled = false;
                btnselect.Enabled = false;
               btndelete.Enabled = false;
               txtaddress.Enabled = false;
               txtstate.Enabled = false;
               txtstreet.Enabled = false;
                drpstatus.Enabled=false;
                drprepot.Enabled=false;
                txtdesignation.Enabled=false;
                txtcountry.Enabled=false;
                txtexename.Enabled=false;
                drpcity.Enabled = false;
                txtdistrict.Enabled = false;
                txtpin.Enabled=false;
                txtphone.Enabled = false;
                drptaluka.Enabled = false;
                txtrepname.Enabled = false;
                drpadtype.Enabled = false;
                drpbranch1.Enabled = false;
                txtcraditlimit.Enabled = false;
                txtemail.Enabled = false;
                txtmobile.Enabled = false;
                txtemcode.Enabled = false;
                txtemailid.Enabled = true;
                attachment1.Enabled = false;
                txtpaymode.Enabled = false;
            }
            else if (show == "2")
            {
                btnsubmit.Enabled = true;
                btnselect.Enabled = false;
                btndelete.Enabled = false;
                txtaddress.Enabled = true;
                txtstate.Enabled = true;
                txtstreet.Enabled = true;
                drpstatus.Enabled = true;
                drprepot.Enabled = true;
                txtdesignation.Enabled = true;
                txtcountry.Enabled = true;
                txtexename.Enabled = true;
                drpcity.Enabled = true;
                txtpin.Enabled = true;
                txtphone.Enabled = true;
                txtdistrict.Enabled = true;
                drptaluka.Enabled = true;
                txtrepname.Enabled = true;
                drpadtype.Enabled = true;
                drpbranch1.Enabled = true;
                txtcraditlimit.Enabled = true;
                txtemail.Enabled = true;
                txtmobile.Enabled = true;
                txtemcode.Enabled = true;
                txtemailid.Enabled = true;
                attachment1.Enabled = true;
                txtpaymode.Enabled = true;
            }
            addregion();

            if (dk.Tables.Count > 0 && Session["exesave"]==null)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();
                dk = new DataSet();
            }
            if (Session["exesave"] == null && show !="1")
            {
                DataGrid2.Visible = false;
                divdg2.Visible = false;
                divdatagd1.Visible = true;
                DataGrid1.Visible = true;
                datagridbind("Exec_name");
            }
            else
            {
                DataGrid2.Visible = true;
                divdg2.Visible = true;
                divdatagd1.Visible = false;
                DataGrid1.Visible = false;
                bindgrid2();
                drpbranch1.SelectedValue = bname;
            }
            txtemail.Attributes.Add("OnBlur", "javascript:return checkEmail();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return exedetail();");
            //btnselect.Attributes.Add("OnClick", "javascript:return selectexe();");
            btnselect.Attributes.Add("OnClick", "javascript:return closeexe();");
            btndelete.Attributes.Add("OnClick", "javascript:return deleteexe();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearexe();");
            txtexename.Attributes.Add("OnChange", "javascript:return uppercase('txtexename');");
            //txtdesignation.Attributes.Add("OnChange", "javascript:return uppercase('txtdesignation');");
            txtaddress.Attributes.Add("OnChange", "javascript:return uppercase('txtaddress');");
            txtstreet.Attributes.Add("OnChange", "javascript:return uppercase('txtstreet');");
            txtcountry.Attributes.Add("OnChange", "javascript:return addcount(this);");
            
            //addcit();
            drpcity.Attributes.Add("OnChange", "javascript:return addreg();");
            //txtcountry.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            //txtcountry.Attributes.Add("OnKeydown","javascript:return enter();");
            //drpcity.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            txtdesignation.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            drprepot.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            drpstatus.Attributes.Add("onkeypress", "javascript:return keySort(this);");
            drpadtype.Attributes.Add("OnChange", "javascript:return category()");
            txtemcode.Attributes.Add("onkeydown", "javascript:return F2fillempcode(event);");
            lstempcode.Attributes.Add("onkeydown", "javascript:return Clickrempcode_ret(event);");
            lstempcode.Attributes.Add("OnClick", "javascript:return Clickrempcode_ret(event);");
            txtemailid.Attributes.Add("OnBlur", "javascript:return ClientEmlChck('txtemailid');");
           
            attachment1.Attributes.Add("OnClick", "javascript:return openattach1();");

         //   datagridbind();
            countryname();
            binddesignation();
            bindreportto();
            addtype();

            paymode();

            BindRepresentative();
            btnclear.Enabled = true;
            btnselect.Enabled = true;
            //txtexename.Focus = true;
        }
    }


    //public void paymode()
    //{
    //}

    public void paymode()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
       {
            NewAdbooking.classesoracle.pop radiobind = new NewAdbooking.classesoracle.pop();
            ds = radiobind.filldatapay(compcode, userid);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop radiobind = new NewAdbooking.Classes.pop();

                ds = radiobind.filldatapay(compcode, userid);
            }



            else
            {
                string[] parameterValueArray = new string[] { compcode, userid };
                string procedureName = "retainer_payfill_retainer_payfill_p";
                NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
                ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
               /* NewAdbooking.classmysql.CityMaster retainername = new NewAdbooking.classmysql.CityMaster();
                ds = retainername.retainer();*/
            }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Paymode-";
        li1.Value = "0";
        li1.Selected = true;
        txtpaymode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            
            
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
           txtpaymode.Items.Add(li);
           
        }




    }








    public void addregion()
    {
        drpbranch1.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster name = new NewAdbooking.Classes.AdvertisementMaster();

            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster name = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster name = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = name.adzone(Session["userid"].ToString(), Session["compcode"].ToString());

        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Branch-----";
        li1.Value = "0";
        li1.Selected = true;
        drpbranch1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpbranch1.Items.Add(li);
        }
    }
    public void BindRepresentative()
    {
        txtrepname.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster ClMst = new NewAdbooking.Classes.AdvertisementMaster();

            ds = ClMst.addrepname(Session["compcode"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster ClMst = new NewAdbooking.classesoracle.AdvertisementMaster();

                ds = ClMst.addrepname(Session["compcode"].ToString());

            }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classmysql.AdvertisementMaster ClMst = new NewAdbooking.classmysql.AdvertisementMaster();

                ds = ClMst.addrepname(Session["compcode"].ToString());

            }


        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Representative Name--";
        li1.Value = "0";
        li1.Selected = true;
        txtrepname.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                txtrepname.Items.Add(li);
            }

        }


    }

    public void addtype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster bindtype = new NewAdbooking.Classes.AdvertisementMaster();
            //DataSet ds = new DataSet();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster bindtype = new NewAdbooking.classesoracle.AdvertisementMaster();
            //DataSet ds = new DataSet();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
         else 
        {
            NewAdbooking.classmysql.AdvertisementMaster bindtype = new NewAdbooking.classmysql.AdvertisementMaster();
            //DataSet ds = new DataSet();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
       

        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select Ad Type --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadtype.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpadtype.Items.Add(li);


        }
    }

    [Ajax.AjaxMethod]
    public DataSet addadvcat(string adtypcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster name = new NewAdbooking.Classes.AdvertisementMaster();

            ds = name.addadvcat(adtypcode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster name = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = name.addadvcat1(adtypcode);

        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster name = new NewAdbooking.classmysql.AdvertisementMaster();
            ds = name.addadvcat(adtypcode);

        }
      
        return ds;
    }

    public void datagridbind(string sortfield)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster binddata = new NewAdbooking.Classes.AdvertisementMaster();
            
            ds = binddata.exebind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenteamcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster binddata = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = binddata.exebind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenteamcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster binddata = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = binddata.exebind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenteamcode.Value);

        }
      
        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        dv.Sort = sortfield;

        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();
    }

    public void bindgrid2()
    {
        DataGrid1.Visible = false;
        DataGrid2.Visible = true;
        divdg2.Visible = true;
        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Exec_name";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "designation";
        mydatatable.Columns.Add(mycolumn);
     
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Add1";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "street";
        mydatatable.Columns.Add(mycolumn);

        

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "dist_code";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "state_code";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "country_code";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "pin_code";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "phone";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "exe_status";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "city_name";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "city_code";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Exe_no";
        mydatatable.Columns.Add(mycolumn);

         mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "report_to";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "TALUKA";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "repname";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Branch_code";
        mydatatable.Columns.Add(mycolumn);


        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ATTACHMENT";
        mydatatable.Columns.Add(mycolumn);
        
        //mycolumn = new DataColumn();
        //mycolumn.DataType = System.Type.GetType("System.String");
        //mycolumn.ColumnName = "RETAINER";
        //mydatatable.Columns.Add(mycolumn);


        if (Session["exesave"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
            int d;
            int g;
            DataSet dsnew = new DataSet();
            if (Session["exesave"] != null)
            {
                dsnew = (DataSet)Session["exesave"];
            }
            if (dsnew.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

            for (d = 0; d <= dsnew.Tables.Count - 1; d++)
            {
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                my_row = dsnew.Tables[d].Rows[0];
                //}
                //else
                //{
                //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                //}



                mydatatable.ImportRow(my_row);



            }


            ds_tbl.Tables.Add(mydatatable);
            //ViewState["SortExpression"] = sortfield;
            //ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds_tbl.Tables[0].DefaultView;
            // dv.Sort = sortfield;


            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;
            txtdistrict.Text = "";
            txtstate.Text = "";
            drpstatus.SelectedValue = "0";
            drprepot.SelectedValue = "0";
            txtcountry.SelectedValue = "0";
            drpadtype.SelectedValue = "0";
            txtdesignation.SelectedValue = "0";
            txtrepname.SelectedValue = "0";

        }
    }
   



    public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster binddata = new NewAdbooking.Classes.AdvertisementMaster();
           
            ds = binddata.exebind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenteamcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster binddata = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = binddata.exebind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenteamcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster binddata = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = binddata.exebind(Session["compcode"].ToString(), Session["userid"].ToString(), hiddenteamcode.Value);
        }
   
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        if ((numberDiv % 2) == 0)
        {
            dv.Sort = e.SortExpression + " " + "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "ASC";
        }
        else
        {
            dv.Sort = e.SortExpression + " " + "DESC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "DESC";
        }
        numberDiv++;

        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();
    }


    public DataSet addcit()
    {
        drpcity.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Master exe = new NewAdbooking.Classes.Master();
           
            ds = exe.addcity();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master exe = new NewAdbooking.classesoracle.Master();
            ds = exe.addcity();
        }
        else
        {
            NewAdbooking.classmysql.Master exe = new NewAdbooking.classmysql.Master();

            ds = exe.addcity();
        }

        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select City--";
        li1.Value = "0";
        li1.Selected = true;
        drpcity.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                //li.Value=ds.Tables[0].Rows[i].ItemArray[5].ToString();
                drpcity.Items.Add(li);
            }
        }
        //			
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet citysel(string city)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster fillcity = new NewAdbooking.Classes.AdvertisementMaster();
           
            ds1 = fillcity.addpickdistname(city);
            return ds1;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster fillcity = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds1 = fillcity.addpickdistname(city);
            return ds1;
        }
        else
        {

            NewAdbooking.classmysql.AdvertisementMaster fillcity = new NewAdbooking.classmysql.AdvertisementMaster();

            ds1 = fillcity.addpickdistname(city);
            return ds1;
        }
    }


    [Ajax.AjaxMethod]
    public DataSet insertintodetail(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string report, string taluka, string repname, string adtype, string branchcode, string craditlimit, string email, string mobile, string empcode, string mailto, string attachment, string PAYMENTMODE, string oldcode)
  {
      DataSet ds = new DataSet();
     if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
     {

         NewAdbooking.Classes.AdvertisementMaster inserted = new NewAdbooking.Classes.AdvertisementMaster();

         ds = inserted.detailinserted(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, report, taluka, repname, adtype, branchcode, craditlimit, email, mobile, empcode, mailto, attachment, PAYMENTMODE);
     }
     else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
     {
         NewAdbooking.classesoracle.AdvertisementMaster inserted = new NewAdbooking.classesoracle.AdvertisementMaster();
         ds = inserted.detailinserted(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, report, taluka, repname, adtype, branchcode, craditlimit, email, mobile, empcode, mailto, attachment);
     }
     else
     {
         /*string[] parameterValueArray = new string[] { exename, teamcode, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, report, taluka, repname, adtype, branchcode, craditlimit, mobile, email, mailto, empcode, attachment, oldcode };
         string procedureName = "execcontactinsert_execcontactinsert_p";
         NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
         ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);*/
       
         NewAdbooking.classmysql.AdvertisementMaster inserted = new NewAdbooking.classmysql.AdvertisementMaster();
         ds = inserted.detailinserted(exename, teamcode, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, report, taluka, repname, adtype, branchcode, craditlimit, mobile, email, mailto, empcode, attachment, oldcode,"","","");
       
     }
     return ds;
 }

    //ad for category
   [Ajax.AjaxMethod]
    public void insertExecAdetail(string compcode, string userid, string teamcode, string badcategory, string flag,string code)
   {
      
       if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
       {
           NewAdbooking.classesoracle.AdvertisementMaster inserted = new NewAdbooking.classesoracle.AdvertisementMaster();
           inserted.insertedExecAdetail(compcode, userid, teamcode, badcategory, flag,code);
       }
       else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
       {
           NewAdbooking.Classes.AdvertisementMaster inserted = new NewAdbooking.Classes.AdvertisementMaster();
           inserted.insertedExecAdetail(compcode, userid, teamcode, badcategory, flag, code);
       }
       else 
       {
           NewAdbooking.classmysql.AdvertisementMaster inserted = new NewAdbooking.classmysql.AdvertisementMaster();
           inserted.insertedExecAdetail(compcode, userid, teamcode, badcategory, flag, code);
       }
     
   }
    [Ajax.AjaxMethod]
    public void deleteExecAdetail(string compcode, string code)
    {

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster inserted = new NewAdbooking.classesoracle.AdvertisementMaster();
            inserted.deleteExecAdetail(compcode,code);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvertisementMaster inserted = new NewAdbooking.Classes.AdvertisementMaster();
            inserted.deleteExecAdetail(compcode, code);
        }
        else 
        {
            NewAdbooking.classmysql.AdvertisementMaster inserted = new NewAdbooking.classmysql.AdvertisementMaster();
            inserted.deleteExecAdetail(compcode, code);
        }
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      //  this.Datagrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Datagrid1_ItemDataBound);

    }
    #endregion

    [Ajax.AjaxMethod]
    public DataSet upperexe(string compcode, string userid, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster inserted = new NewAdbooking.Classes.AdvertisementMaster();
           
            ds = inserted.detailinsertedexec(compcode, userid, code);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster inserted = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = inserted.detailinsertedexec(compcode, userid, code);
            return ds;
        }
        else
        {

            NewAdbooking.classmysql.AdvertisementMaster inserted = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = inserted.detailinsertedexec(compcode, userid, code);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    public void updatedetail(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string codeexe, string report, string taluka, string repname, string adtype, string brancgname1, string craditlimit, string email, string mobile, string empcode, string mailto, string attachment, string PAYMENTMODE, string oldcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster inserted = new NewAdbooking.Classes.AdvertisementMaster();

            ds = inserted.detailupdate(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe, report, taluka, repname, adtype, brancgname1, craditlimit, email, mobile, empcode, mailto, attachment, PAYMENTMODE);
            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster inserted = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = inserted.detailupdate(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe, report, taluka, repname, adtype, brancgname1, craditlimit, email, mobile, empcode, mailto, attachment);
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster inserted = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = inserted.detailupdate(exename, designation, address, street, city, district, state, country, pin, phone, status, compcode, userid, teamcode, codeexe, report, taluka, repname, adtype, brancgname1, craditlimit, email, mobile, empcode, mailto, attachment, oldcode,"");

        }
        datagridbind("Exec_name");
        
    }


    [Ajax.AjaxMethod]
    public DataSet deleteexec121(string compcode, string userid, string code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster delete = new NewAdbooking.Classes.AdvertisementMaster();
           
            ds = delete.deleteexecdetail(compcode, userid, code);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster delete = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = delete.deleteexecdetail(compcode, userid, code);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdvertisementMaster delete = new NewAdbooking.classmysql.AdvertisementMaster();

            ds = delete.deleteexecdetail(compcode, userid, code);
            return ds;
        }
    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {



        DataView dv = new DataView();

        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType != ListItemType.Header)
        {

            e.Item.Cells[19].Text = "<input type='button' value=Comm.Slab  OnClick=\"javascript:return retcomslab('" + e.Item.Cells[12].Text + "');\" />";
            e.Item.Cells[20].Text = "<input type='button' value=Executive  OnClick=\"javascript:return retpopopn('" + e.Item.Cells[12].Text + "');\" />";
           
     


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;



                //e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\"  value=" + e.Item.Cells[12].Text + e.Item.Cells[13].Text + "  />";
                e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\"  value=" + e.Item.Cells[12].Text + "  />";
                j++;


            }
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {


                        case "Exec_name":
                            str = "Executive Name";
                            break;

                        case "designation":
                            str = "Designation";
                            break;

                        case "Add1":
                            str = "Address";
                            break;

                        case "street":
                            str = "Street";
                            break;

                        case "dist_code":
                            str = "District";
                            break;

                        case "state_code":
                            str = "State";
                            break;

                        case "country_code":
                            str = "Country";
                            break;

                        case "pin_code":
                            str = "Pin Code";
                            break;

                        case "phone":
                            str = "Phone No";
                            break;

                        case "exe_status":
                            str = "Status";
                            break;

                        case "city_name":
                            str = "City";
                            break;

                        case "report_to":
                            str = "Reporting To";
                            break;

                        case "TALUKA":
                            str = "Taluka";
                            break;

                        case "Branch_code":
                            str = "Branch";
                            break;

                        case "ATTACHMENT":
                            str = "ATTACHMENT";
                            break;


                        case "Pay_Mode_Code":
                            str = "Pay_Mode_Code";
                            break;



                    };
                    string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                    strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                    if (strd.Length < 2)
                        strd = "0" + strd;
                    if (ViewState["order"].ToString() == "DESC")
                    {

                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                    }
                    else
                    {
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    }
                }
            }




            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    string str = "DataGrid1__ctl_CheckBox1" + j;

            //    e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\"  value=" + e.Item.Cells[12].Text + "  />";
            //    j++;
            //    //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";
            // }
        }
    }

    [Ajax.AjaxMethod]
    public DataSet addcou(string txtcountry)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Master firstAgency = new NewAdbooking.Classes.Master();
          
            ds = firstAgency.countcity(txtcountry);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master firstAgency = new NewAdbooking.classesoracle.Master();

            ds = firstAgency.countcity(txtcountry);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.Master firstAgency = new NewAdbooking.classmysql.Master();

            ds = firstAgency.countcity(txtcountry);
            return ds;
        }
    }

    public void countryname()
    {
        DataSet ds = new DataSet();
        txtcountry.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Master name = new NewAdbooking.Classes.Master();

            ds = name.adcountryname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master name = new NewAdbooking.classesoracle.Master();
            ds = name.adcountryname(Session["compcode"].ToString());
        }

        else
        {

            NewAdbooking.classmysql.Master name = new NewAdbooking.classmysql.Master();

            ds = name.adcountryname(Session["compcode"].ToString());

        }
        
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Country-----";
        li1.Value = "0";
        li1.Selected = true;
        txtcountry.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            txtcountry.Items.Add(li);
        }
    }
    public void binddesignation()
    {
        txtdesignation.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.pop insrolename = new NewAdbooking.Classes.pop();
          
            ds = insrolename.rolename(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop insrolename = new NewAdbooking.classesoracle.pop();
            ds = insrolename.rolename(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        else
        {
            NewAdbooking.classmysql.pop insrolename = new NewAdbooking.classmysql.pop();

            ds = insrolename.rolename(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Designation--";
        li1.Value = "0";
        li1.Selected = true;
        txtdesignation.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                txtdesignation.Items.Add(li);
            }
        }

        

    }

    public void bindreportto()
    {
        DataSet dz = new DataSet();

         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {

             NewAdbooking.Classes.AdvertisementMaster bindreport = new NewAdbooking.Classes.AdvertisementMaster();

             dz = bindreport.report(Session["compcode"].ToString(), Session["userid"].ToString());
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.AdvertisementMaster bindreport = new NewAdbooking.classesoracle.AdvertisementMaster();
             dz = bindreport.report(Session["compcode"].ToString(), Session["userid"].ToString());
         }
         else
         {
             NewAdbooking.classmysql.AdvertisementMaster bindreport = new NewAdbooking.classmysql.AdvertisementMaster();

             dz = bindreport.report(Session["compcode"].ToString(), Session["userid"].ToString());

         }

        drprepot.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Report To--";
        li1.Value = "0";
        li1.Selected = true;
        drprepot.Items.Add(li1);

        if (dz.Tables.Count > 0)
        {
            for (i = 0; i < dz.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dz.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dz.Tables[0].Rows[i].ItemArray[1].ToString();

                drprepot.Items.Add(li);
            }
        }
    }



    [Ajax.AjaxMethod]
    public DataSet chkexecname(string compcode, string exename, string userid, string teamcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster AdvExec = new NewAdbooking.Classes.AdvertisementMaster();

            ds = AdvExec.chkexecname1(compcode, exename, userid, teamcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvertisementMaster AdvExec = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = AdvExec.chkexecname1(compcode, exename, userid, teamcode);
        }
        else
        {
          //  NewAdbooking.classmysql.AdvertisementMaster AdvExec = new NewAdbooking.classmysql.AdvertisementMaster();

          //  ds = AdvExec.chkexecname1(compcode, exename, userid, teamcode);
            string[] parameterValueArray = new string[] { compcode, exename, userid, teamcode };
            string procedureName = "chkexecname_chkexecname_p";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        
        return ds;
    }






    protected void btnsubmit_Click(object sender, EventArgs e){
        string paymentmode = "";
        string city = hidencity.Value;
        string report = txtreport.Text;
          string adtypcode = drpadtype.SelectedValue;
         // string talukaT = hidtaluka.Value;
       string talukaT="";
       string RepName = "";
          DataSet ds2 = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {

              NewAdbooking.Classes.AdvertisementMaster fillcity = new NewAdbooking.Classes.AdvertisementMaster();
              
              ds2 = fillcity.addpickdistname(city);
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.classesoracle.AdvertisementMaster fillcity = new NewAdbooking.classesoracle.AdvertisementMaster();
              ds2 = fillcity.addpickdistname(city);
          }
          else
          {
              NewAdbooking.classmysql.AdvertisementMaster fillcity = new NewAdbooking.classmysql.AdvertisementMaster();

              ds2 = fillcity.addpickdistname(city);

          }

          txtcity.Text = ds2.Tables[3].Rows[0].ItemArray[0].ToString();
          if (ds2.Tables[1].Rows.Count > 0)
          {
              txtdistrict.Text = ds2.Tables[1].Rows[0].ItemArray[0].ToString();

          } if (ds2.Tables[2].Rows.Count > 0)
            txtstate.Text = ds2.Tables[2].Rows[0].ItemArray[0].ToString();
            string dis = txtdistrict.Text;
            string st = txtstate.Text;
            if (ds2.Tables[4].Rows.Count>0)
                talukaT = ds2.Tables[4].Rows[0].ItemArray[1].ToString();
            else
                talukaT = "";


        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        flag = 0;

        if ((dk.Tables.Count != 0))
        {
            int j;
            for (j = 0; j < dk.Tables[0].Rows.Count; j++)
            {
                if (txtexename.Text == dk.Tables[0].Rows[j].ItemArray[0].ToString())
                {
                    message = "Executive Name has been submitted already";
                    AspNetMessageBox(message);
                    flag = 1;

                }
                else
                {
                    flag = 0;
                }

            }
            
        }
        if(flag==0)
        {

          
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Exec_name";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "designation";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Add1";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "street";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "dist_code";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "state_code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "country_code";
            mydatatable1.Columns.Add(mycolumn1);






            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "pin_code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "phone";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "exe_status";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "city_name";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "city_code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Exe_no";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "report_to";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "TALUKA";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "repname";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Branch_code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "adcat";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "adtype";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "CRADITLIMIT";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "EMAILID";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "MOBILENO";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "empcode";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "MailTo";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "ATTACHMENT";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "Pay_Mode_Code";
            mydatatable1.Columns.Add(mycolumn1);




            //===============================//

            int j = 0;
            if (DataGrid2.Items.Count > 0)
            {
                while (j < DataGrid2.Items.Count)
                {
                    string exename = DataGrid2.Items[j].Cells[0].Text;
                    if (exename == txtexename.Text)
                    {
                        message = "Executive Name has been submitted already";
                        AspNetMessageBox(message);
                        txtexename.Text = "";
                        bindgrid2();
                        return;
                    }
                    j++;
                }

            }

            if (Session["exesave"] != null)
            {
                DataSet dsNew = new DataSet();
                dsNew = (DataSet)Session["exesave"];
                while (j < dsNew.Tables.Count)
                {
                    string exename = dsNew.Tables[j].Rows[0].ItemArray[0].ToString();
                    if (exename == txtexename.Text)
                    {
                        message = "Executive Name has been submitted already";
                        AspNetMessageBox(message);
                        txtexename.Text = "";
                        bindgrid2();
                        return;
                    }
                    j++;
                }
            }

            //====================================//

            myrow1 = mydatatable1.NewRow();
            myrow1["Exe_no"] = "0";


            myrow1["Exec_name"] = txtexename.Text;

            myrow1["designation"] = txtdesignation.SelectedValue;

            myrow1["Add1"] = txtaddress.Text;

            myrow1["street"] = txtstreet.Text;


            myrow1["dist_code"] = txtdistrict.Text;

            myrow1["state_code"] = txtstate.Text;


            myrow1["country_code"] = txtcountry.SelectedValue;


            myrow1["pin_code"] = txtpin.Text;

            myrow1["phone"] = txtphone.Text;
            myrow1["exe_status"] = drpstatus.SelectedValue;


            //function getSelectedOptions(oList)
            //{   var sdValues = [];  
            //    for(var i = 1; i < oList.options.length; i++) 
            //{      if(oList.options[i].selected == true)    
            //{      sdValues.push(oList.options[i].value);     
            //}   
            //    }   return sdValues;}

         









            myrow1["city_name"] = txtcity.Text;
            myrow1["city_code"] = city;
            myrow1["Branch_code"] = drpbranch1.SelectedValue;
            if ((report != "0") && (report != "null"))
            {
                myrow1["report_to"] = report;
            }
            else
            {
                myrow1["report_to"] = "0";
            }

            myrow1["TALUKA"] = talukaT;

            myrow1["repname"] = txtrepname.Text;
            //---------------for multiple category selection----------------------//
            //////string str = "";
            //////string str1 = "";
            //////for (int li = 1; li < lbadcategory.Items.Count; li++)
            //////{

            //////    if (lbadcategory.Items[li].Selected == true)
            //////    {
            //////        if (str == "")
            //////        {
            //////            str = lbadcategory.Items[li].Value;
            //////            str1 = lbadcategory.Items[li].Text;
            //////        }
            //////        else
            //////        {
            //////            str = str + "','" + lbadcategory.Items[li].Value;
            //////            str1 = str1 + "','" + lbadcategory.Items[li].Text;
            //////        }
            //////    }
            //////}
           //-----------------------------------------------------------------------//         
            myrow1["adcat"] = hiddencat.Value;

            myrow1["adtype"] = drpadtype.SelectedValue;
            myrow1["CRADITLIMIT"] = txtcraditlimit.Text;
            myrow1["EMAILID"] = txtemail.Text;
            myrow1["MOBILENO"] = txtmobile.Text;
            myrow1["empcode"] = hdempcode.Value;
            myrow1["MailTo"] = txtemailid.Text;
            myrow1["ATTACHMENT"] = hidattachment.Value;

            for (int i = 1; i < txtpaymode.Items.Count; i++)
            { 
                if(txtpaymode.Items[i].Selected==true )
                {
                    // paymentmode =  txtpaymode.Items[i].Text + ',' + txtpaymode.Items[i].Text;
                    paymentmode =paymentmode+ txtpaymode.Items[i].Value + ',';
                }
                
            }
            myrow1["Pay_Mode_Code"] = paymentmode;
           // myrow1["Payment_Mode_NAME"] = hdpaycode;
           // myrow1["ATTACHMENT"] = hidattachment.Value;


            mydatatable1.Rows.Add(myrow1);
            if (Session["exesave"] != null)
            {
                DataSet dsNew = new DataSet();
                dsNew = (DataSet)Session["exesave"];
                dk = dsNew;
            }
            dk.Tables.Add(mydatatable1);




            Session["exesave"] = dk;

            ///this is for grid
            ///


            DataColumn mycolumn;
            DataTable mydatatable = new DataTable();
            DataRow myrow;

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Exec_name";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "designation";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Add1";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "street";
            mydatatable.Columns.Add(mycolumn);



            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "dist_code";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "state_code";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "country_code";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "pin_code";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "phone";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "exe_status";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "city_name";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "city_code";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Exe_no";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "report_to";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "TALUKA";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "repname";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "Branch_code";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "ATTACHMENT";
            mydatatable.Columns.Add(mycolumn);







            myrow = mydatatable.NewRow();
            myrow["city_code"] = "0";
            myrow["Exe_no"] = "0";



            myrow["Exec_name"] = txtexename.Text;

            myrow["designation"] = txtdesignation.SelectedItem.Text;


            myrow["Add1"] = txtaddress.Text;

            myrow["street"] = txtstreet.Text;


            myrow["dist_code"] = txtdistrict.Text;

            myrow["state_code"] = txtstate.Text;


            myrow["country_code"] = txtcountry.SelectedItem.Text;

            


            myrow["pin_code"] = txtpin.Text;

            myrow["phone"] = txtphone.Text;

            myrow["exe_status"] = drpstatus.SelectedItem.Text;

            myrow["city_name"] = txtcity.Text;
            myrow["city_code"] = city;

            myrow["Branch_code"] = drpbranch1.SelectedItem.Text;

            if (report == "0")
            {
                myrow["report_to"] = "";
            }
            else
            {
                myrow["report_to"] = drprepot.SelectedItem.Text;
            }

            myrow["TALUKA"] = talukaT;

            myrow["repname"] = txtrepname.Text;

            myrow["ATTACHMENT"] = hidattachment.Value;





           // myrow["Payment_Mode_Code"] = paymentmode;





          
            txtexename.Text = "";
            txtdesignation.SelectedValue = "0";
            txtaddress.Text = "";
            txtstreet.Text = "";
            txtdistrict.Text = "";
            txtstate.Text = "";
            txtcountry.SelectedValue = "0";
            txtpin.Text = "";
            txtphone.Text = "";
            txtmobile.Text = "";
            txtcraditlimit.Text = "";
            txtemail.Text = "";
            txtemailid.Text = "";
            drpcity.SelectedValue = "0";
            drpbranch1.SelectedValue = bname;
            drpstatus.SelectedValue = "0";
            drprepot.SelectedValue = "0";
            drptaluka.SelectedValue = "0";
            txtrepname.SelectedValue = "0";
            txtemcode.Text = "";
            txtemailid.Text = "";
            hidattachment.Value = "";

            mydatatable.Rows.Add(myrow);

            dk1.Tables.Add(mydatatable);


            bindgrid2();

         //   return;
        }
    }
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Execondetail), "ShowAlert", strAlert, true);
    }


    [Ajax.AjaxMethod]
    public DataSet empcodebind(string compcode,string empname)
    {
        //drpemcode.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvertisementMaster name = new NewAdbooking.Classes.AdvertisementMaster();

            ds = name.bindempcode(compcode, empname);
            return ds;
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "emp_code_bind";
            string[] parameterValueArray = { compcode, empname };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
        else
        {
            NewAdbooking.classesoracle.AdvertisementMaster name = new NewAdbooking.classesoracle.AdvertisementMaster();
            ds = name.bindempcode(compcode, empname);
            return ds;
        }
        
  

    }


    protected void DataGrid1_ItemDataBound2(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        exno++;


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            e.Item.Cells[18].Text = "exe" + exno;




            e.Item.Cells[17].Text = "<input type='button' value='Comm Slab'  OnClick=\"javascript:return retcomslab('" + e.Item.Cells[18].Text + "');\" />";
            //e.Item.Cells[19].Text = "<input type='button' value='Executive'  OnClick=\"javascript:return retpopopn('" + e.Item.Cells[18].Text + "');\" />";
            //e.Item.Cells[20].Text = "<input type='hidden' value='" + hiddenexecutive.Value + "'   />";
           
           
            j++;


        }

    }

   
}