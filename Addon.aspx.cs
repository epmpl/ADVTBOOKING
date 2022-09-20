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

public partial class Addon : System.Web.UI.Page
{
    public static int numberDiv;
    int j = 0;
    string compcode, userid, message;
    string ratecode, pkgcode, pkgdesc;
     static DataSet dk = new DataSet();
     static DataSet dk1 = new DataSet();
    string type_ = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;


        if (Session["compcode"] != null)
        {

            userid = Session["userid"].ToString();
            hiddenuserid.Value = userid;
            compcode = Session["compcode"].ToString();
            hiddencomcode.Value = compcode;
            hiddendateformat.Value = Session["dateformat"].ToString();
            /*new change ankur for agency*/
            type_ = Request.QueryString["type_age"].ToString();
            hiddentype_agency.Value = type_;

            hiddenratecode.Value=ratecode = Request.QueryString["ratecode"].ToString();
            hiddenrateuniqueid.Value = Request.QueryString["ratesaveid"].ToString();
            pkgcode = Request.QueryString["pkgcode"].ToString();
            pkgdesc = Request.QueryString["pkgdesc"].ToString();
            hideshow.Value = Request.QueryString["show"].ToString();
            hiidensanod.Value = Request.QueryString["savemodify"].ToString();
            pkgdesc = pkgdesc.Replace('$','+');
            hiddenpkgcode.Value = pkgcode;
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.adons bind = new NewAdbooking.Classes.adons();
                /*new change ankur for agency*/
                da = bind.getpkgname(compcode, pkgcode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.adons bind = new NewAdbooking.classesoracle.adons();         
                da = bind.getpkgname(compcode, pkgcode);
            }
            else
            {
                NewAdbooking.classmysql.adons bind = new NewAdbooking.classmysql.adons();
                da = bind.getpkgname(compcode, pkgcode);
            }
            txtdesc.Text = pkgdesc;
            if(da.Tables[0].Rows.Count>0)
                txtpkg.Text = da.Tables[0].Rows[0].ItemArray[0].ToString();


            //Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
        }
        else
        {
            Response.Write("<script>alert(\"Your Session has been expired\");window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Addon));

        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/adons.xml"));

        lblpkg.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblpkgdecs.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbledition.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lblrate.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        btnclear.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lblpublication.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lblsup.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();

        if (!Page.IsPostBack)
        {
            if (dk.Tables.Count > 0 && Session["rateinsert"] == null )
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();
            }
            if (Session["rateinsert"] == null )
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();

                DataGrid1.Visible = true;
                //firgri.Visible = true;
               //secgri.Visible = false;
                DataGrid2.Visible = false;
                bindadons("Edition_Name");
            }
            else
            {
                //firgri.Visible = false;
                
                //secgri.Visible = true;
                DataGrid1.Visible = false;
                DataGrid2.Visible = true;
                bindadons1();
            }
           // bindadons();
            bindpublication();
            btnclose.Attributes.Add("OnClick","javascript:return winclose();");
            drppub.Attributes.Add("onkeypress", "return keySort(this);");
            drpedition.Attributes.Add("onkeypress", "return keySort(this);");
            //drppub.Attributes.Add("onkeypress", "return keySort(this);");
            btnsubmit.Attributes.Add("OnClick", "javascript:return saveclickrate();");
            //btnsubmit.Attributes.Add("OnClick", "javascript:return hiheelo();");
            txtrate.Attributes.Add("onchange", "javascript:return chkrate('txtrate');");
            
            if (hideshow.Value == "0" || hideshow.Value == "1")
            {
                drppub.Enabled = true;
                drpsup.Enabled = true;
                txtnoofinsert.Enabled = true;
                drpedition.Enabled = true;
                txtrate.Enabled = true;
                txtextrarate.Enabled = true;
                btnsubmit.Enabled = true;
                btnclear.Enabled = true;
                btndelete.Enabled = true;

            }
            else
            {
                drppub.Enabled = false;
                txtnoofinsert.Enabled = false;
                drpsup.Enabled = false;
                drpedition.Enabled = false;
                txtrate.Enabled = false;
                txtextrarate.Enabled = false;
                btnsubmit.Enabled = false;
                btnclear.Enabled = false;
                btndelete.Enabled = false;
            }
        }
    }

    public void bindadons(string sortfield)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons bind = new NewAdbooking.Classes.adons();
            /*new change ankur for agency*/
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode,type_);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle .adons bind = new NewAdbooking.classesoracle.adons();
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode, type_);
        }
        else
        {
            NewAdbooking.classmysql.adons bind = new NewAdbooking.classmysql.adons();
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode);
        }


        ViewState["SortExpression"] = sortfield;
        ViewState["order"] = "ASC";
        DataView dv = new DataView();
        dv = da.Tables[0].DefaultView;
        dv.Sort = sortfield;


        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();
    }
    public void bindadons1()
    {
        //firgri.Visible = false;

        //secgri.Visible = true;
        DataGrid1.Visible = false;
        DataGrid2.Visible = true;
        DataSet ds_tbl = new DataSet();


        /////////////////////////////////////
        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Edition_Name";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Supp_Name";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Rate";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Adon_code";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "extrarate";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "noofinsert";
        mydatatable1.Columns.Add(mycolumn1);

        if (Session["rateinsert"] == null)
        {
            ds_tbl.Tables.Add(mydatatable1);
            DataGrid2.DataSource = ds_tbl.Tables[0];
            DataGrid2.DataBind();
        }
        else
        {
            int d;
            int g;
            if (dk1.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

             //dk1 = (DataSet)Session["rateinsertshow"];

            for (d = 0; d <= dk1.Tables.Count - 1; d++)
            {
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
               myrow1 = dk1.Tables[d].Rows[0];

                //}
                //else
                //{
                //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                //}



                mydatatable1.ImportRow(myrow1);



            }

            ds_tbl.Tables.Add(mydatatable1);
            //ViewState["SortExpression"] = "Advcategory";
            //ViewState["order"] = "ASC";
            DataView dv = new DataView();
            //if (g == 0)
            //{
           
                dv = ds_tbl.Tables[0].DefaultView;
            
            
                
            //}
            //else
            //{
            //    dv = ds_tbl.Tables[--d].DefaultView;
            //}
            //dv = bind_grid.Defau;
            //dv.Sort = "Advcategory";


            DataGrid2.DataSource = dv;
            DataGrid2.DataBind();
            d = 0;
            //dk1.Clear();
        }
       
    }
    public void bindpublication()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindpublication = new NewAdbooking.Classes.Contract();
            ds = bindpublication.publication(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindpublication = new NewAdbooking.classesoracle.Contract();
            ds = bindpublication.publication(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.Contract bindpublication = new NewAdbooking.classmysql.Contract();
            ds = bindpublication.publication(Session["compcode"].ToString());
        }
        drppub.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Publication-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppub.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppub.Items.Add(li);
            }

        }


    }



    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons bind = new NewAdbooking.Classes.adons();
            /*new change ankur for agency*/
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode,type_);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons bind = new NewAdbooking.classesoracle.adons();
            /*new change ankur for agency*/
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode, type_);
        }
        else
        {
            NewAdbooking.classmysql.adons bind = new NewAdbooking.classmysql.adons();
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode);
        }
        ////////////////////////////////////////////////////////



        DataView dv = new DataView();


        dv = (DataView)DataGrid1.DataSource;
        DataColumnCollection dc = dv.Table.Columns;
      

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string strid = "Box1" + j;
            e.Item.Cells[0].Text = "<input type='checkbox' id=" + strid + "  OnClick=\"javascript:return selectcomm('" + strid + "');\" value=" + e.Item.Cells[4].Text + "  />";
            j++;

        }
          if (e.Item.ItemType == ListItemType.Header)
        {
            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "Edition_Name":
                        str = "Edition";
                        break;
                    case "Supp_Name":
                        str = "Supplement";
                        break;

                    case "Rate":
                        str = "Rate";
                        break;



                };

                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //$ctl01$ctl00
                    //GridView1$ctl01$ctl00
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                }


            }

        }
    }
    protected void drppub_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pubcode = drppub.SelectedItem.Value;

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindeditionfor = new NewAdbooking.Classes.Contract();

            ds = bindeditionfor.editionbind(Session["compcode"].ToString(), pubcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Contract bindeditionfor = new NewAdbooking.classesoracle.Contract();

            ds = bindeditionfor.editionbind(Session["compcode"].ToString(), pubcode);
        }
        else
        {
            NewAdbooking.classmysql.Contract bindeditionfor = new NewAdbooking.classmysql.Contract();
            ds = bindeditionfor.editionbind(Session["compcode"].ToString(), pubcode);
        }
        if (ds.Tables[0].Rows.Count >= 0)
        {
            drpedition.Items.Clear();
            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Edition-";
            li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Selected = true;
            drpedition.Items.Add(li1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    drpedition.Items.Add(li);
                }

            }
        }
        else
        {
            message = "There is no data for the selected publication";
            AspNetMessageBox(message);
            return;
        }
        ScriptManager1.SetFocus(drppub);
    }

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Addon), "ShowAlert", strAlert, true);
    }

    protected void drpedition_SelectedIndexChanged(object sender, EventArgs e)
    {
        string editioncode = drpedition.SelectedItem.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindsuppl = new NewAdbooking.Classes.Contract();

            ds = bindsuppl.supplimentbind(Session["compcode"].ToString(), editioncode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle .Contract bindsuppl = new NewAdbooking.classesoracle.Contract();

            ds = bindsuppl.supplimentbind(Session["compcode"].ToString(), editioncode);
        }
        else
        {
            NewAdbooking.classmysql.Contract bindsuppl = new NewAdbooking.classmysql.Contract();
            ds = bindsuppl.supplimentbind(Session["compcode"].ToString(), editioncode);
        }
       
        if (ds.Tables[0].Rows.Count - 1 >= 0)
        {
            drpsup.Items.Clear();
            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Supplement-";
            li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Selected = true;
            drpsup.Items.Add(li1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    drpsup.Items.Add(li);
                }

            }
        }
        //else
        //{
        //    message = "There is no data for selected Edition";
        //    AspNetMessageBox(message);
        //    return;
        //}

        ScriptManager1.SetFocus(drpedition);
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        
         drppub.SelectedValue="0";
         drpedition.SelectedValue="0";
         drpedition.Items.Clear();
         drpsup.SelectedValue="0";
         txtrate.Text="";
         txtextrarate.Text = "";
         hiddencode.Value = "";
         txtnoofinsert.Text = "";

         drpsup.Items.Clear();
         int i;
         ListItem li1;
         li1 = new ListItem();
         li1.Text = "-Select Supplement-";
         li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
         li1.Selected = true;
         drpsup.Items.Add(li1);


         ListItem li2;
         li2 = new ListItem();
         li2.Text = "-Select Edition-";
         li2.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
         li2.Selected = true;
         drpedition.Items.Add(li2);
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string rate = txtrate.Text;
        string code = hiddencode.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons save = new NewAdbooking.Classes.adons();
            /*new change ankur for agency*/
            ds = save.deladon(compcode, code,type_);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons save = new NewAdbooking.classesoracle.adons();
            /*new change ankur for agency*/
            ds = save.deladon(compcode, code, type_);

        }
        else
        {
            NewAdbooking.classmysql.adons save = new NewAdbooking.classmysql.adons();
            ds = save.deladon(compcode, code);
        }
        if (code != "")
        {
            hiddencode.Value = "";
            message = "Data Deleted Successfully.";
            AspNetMessageBox(message);
        }
        //txtpkg.Text = "";
        //txtdesc.Text = "";
        drppub.SelectedValue = "0";
        drpedition.SelectedValue = "0";
        drpsup.SelectedValue = "0";
        txtrate.Text = "";
        txtextrarate.Text = "";


        bindadons("Edition_Name");


    }
    [Ajax.AjaxMethod]
    /*new change ankur for agency*/
    public void insert(string publication, string edition, string supp, string rate, string compcode, string userid, string pkgcode, string pkgdesc, string pkgname, string ratecode,string rateid,string type,string extrarate,string noofinsert)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons data = new NewAdbooking.Classes.adons();
            /*new change ankur for agency*/
            ds = data.insertadon(publication, edition, supp, rate, compcode, userid, pkgcode, pkgdesc, pkgname, ratecode, rateid, type, extrarate,noofinsert);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons data = new NewAdbooking.classesoracle.adons();
            /*new change ankur for agency*/
            ds = data.insertadon(publication, edition, supp, rate, compcode, userid, pkgcode, pkgdesc, pkgname, ratecode, rateid, type,extrarate,noofinsert);
        }
        else
        {
            NewAdbooking.classmysql.adons data = new NewAdbooking.classmysql.adons();
            ds = data.insertadon(publication, edition, supp, rate, compcode, userid, pkgcode, pkgdesc, pkgname, ratecode, rateid);
        }
        //drpedition_SelectedIndexChanged( sender,  e);

        //return ds;
    
    }


    [Ajax.AjaxMethod]
    /*new change ankur for agency*/
    public void update(string publication,string edition,string  supp,string rate,string compcode,string code,string ratecode,string rateid,string type,string extrarate,string noofinsert)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons save = new NewAdbooking.Classes.adons();
            /*new change ankur for agency*/
            ds = save.updateadon(publication, edition, supp, rate, compcode, code, ratecode, rateid, type, extrarate,noofinsert);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons save = new NewAdbooking.classesoracle.adons();
            /*new change ankur for agency*/
            ds = save.updateadon(publication, edition, supp, rate, compcode, code, ratecode, rateid, type,extrarate,noofinsert);
        }
        else
        {
            NewAdbooking.classmysql.adons save = new NewAdbooking.classmysql.adons();
            ds = save.updateadon(publication, edition, supp, rate, compcode, code, ratecode, rateid);
        }

    }


    [Ajax.AjaxMethod]
    /*new change ankur for agency*/
    public DataSet getdata(string compcode, string ratecode, string code11,string type)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons data = new NewAdbooking.Classes.adons();

            ds = data.getdataup(compcode, ratecode, code11,type);
            //drpedition_SelectedIndexChanged( sender,  e);
       
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons data = new NewAdbooking.classesoracle.adons();

            ds = data.getdataup(compcode, ratecode, code11, type);
        }
        else
        {
            NewAdbooking.classmysql.adons data = new NewAdbooking.classmysql.adons();
            ds = data.getdataup(compcode, ratecode, code11);
        }
        return ds;
    }

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        //string abc = "hello";

        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();
        DataRow myrow;
        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Publication";
        mydatatable.Columns.Add(mycolumn);
        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Edition";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Supplement";
        mydatatable.Columns.Add(mycolumn);
        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Rate";
        mydatatable.Columns.Add(mycolumn);
        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Packagecode";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Packagedesc";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Packagename";
        mydatatable.Columns.Add(mycolumn);
        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Ratecode";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "extrarate";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "noofinsert";
        mydatatable.Columns.Add(mycolumn);

        myrow = mydatatable.NewRow();



        myrow["Publication"] = drppub.SelectedValue;
        myrow["Edition"] = drpedition.SelectedValue;
        myrow["Supplement"] = drpsup.SelectedValue;
        myrow["Rate"] = txtrate.Text;
        myrow["Packagecode"] = hiddenpkgcode.Value;
        myrow["Packagedesc"] = txtdesc.Text;
        myrow["Packagename"] = txtpkg.Text;
        myrow["Ratecode"] = hiddenratecode.Value;
        myrow["extrarate"] = txtextrarate.Text;

        myrow["noofinsert"] = txtnoofinsert.Text;

        mydatatable.Rows.Add(myrow);
     
       dk.Tables.Add(mydatatable);
       // ds_tbl.Tables[].Rows.Add(dk.Tables[dk.Tables.Count - 1].Rows[0]);
        //ds_tbl.Tables.Add(mydatatable);
        //dk.Tables[0].Rows.Add(mydatatable);
       


        Session["rateinsert"] = dk;



        /////////////////this is used for grid

        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Edition_Name";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Supp_Name";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Rate";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Adon_code";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "extrarate";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "noofinsert";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();


            myrow1["Adon_code"] = "1";
            myrow1["Edition_Name"] = drpedition.SelectedItem.Text;

            //
            if (drpsup.SelectedItem.Text == "-Select Supplement-")
            {
                myrow1["Supp_Name"] = "";
            }
            else
            {
                myrow1["Supp_Name"] = drpsup.SelectedItem.Text;
            }
            myrow1["Rate"] = txtrate.Text;
            myrow1["extrarate"] = txtextrarate.Text;

            myrow1["noofinsert"] = txtnoofinsert.Text;
        mydatatable1.Rows.Add(myrow1);

        dk1.Tables.Add(mydatatable1);
        Session["rateinsertshow"] = dk1;

        bindadons1();

        drppub.SelectedValue = "0";
        drpsup.SelectedValue = "0";
        drpedition.SelectedValue = "0";
        txtrate.Text = "";
        txtextrarate.Text = "";
        //////////////////////////////////////////////////////////////////////


         
      
    }
    protected void abc(object source, DataGridSortCommandEventArgs e)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adons bind = new NewAdbooking.Classes.adons();
            /*new change ankur for agency*/
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode,type_);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adons bind = new NewAdbooking.classesoracle.adons();
            /*new change ankur for agency*/
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode, type_);
        }
        else
        {
            NewAdbooking.classmysql.adons bind = new NewAdbooking.classmysql.adons();
            da = bind.bindadon(compcode, hiddenrateuniqueid.Value, pkgcode);
        }
        DataView dv = new DataView();
        dv = da.Tables[0].DefaultView;
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
}
