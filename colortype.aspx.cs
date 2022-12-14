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

public partial class colortype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["Username"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }

        hiddencompanycode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(colortype));

        hiddenusername.Value = Session["Username"].ToString();

        //******************************************************************************************************

        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.ImageUrl = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        // Read in the XML file
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/colortype.xml"));

        lbregioncode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbregionname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbalias.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        /*new change ankur 15 feb*/
        lbcat.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lbedit.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        /////////////////////////////////////////////////////////////
        btnNew.Focus();

        //*********************************************************************************************************

        if (!Page.IsPostBack)
        {
            /*new change ankur 15 feb*/
            bindcategoey();
            bindedition();

            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('variable');");
            //btnSave.Attributes.Add("OnClick","javascript:return saveclick();  ");
            btnSave.Attributes.Add("OnClick", "javascript:return save();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");

            btnExit.Attributes.Add("OnClick", "javascript:return regionexit();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick1();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick1();");
            btnprevious.Attributes.Add("OnClick", "javascript:return preclick1();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick1();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            txtregioncode.Attributes.Add("OnChange", "javascript:return uppercase();");
            txtalias.Attributes.Add("OnChange", "javascript:return uppercase2();");
            txtregioncode.Attributes.Add("OnKeyPress", "javascript:return charval();");
            txtregionname.Attributes.Add("OnKeyPress", "javascript:return charval();");
            txtregionname.Attributes.Add("OnChange", "javascript:return autoornot();");
            txtalias.Attributes.Add("OnKeyPress", "javascript:return charval();");

            txtregioncode.Enabled = false;
            txtregionname.Enabled = false;
            txtalias.Enabled = false;
            drpcat.Enabled = false;
            drpedit.Enabled = false;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnModify.Enabled = false;
            btnQuery.Enabled = true;
            btnExecute.Enabled = false;
            btnfirst.Enabled = false;
            btnprevious.Enabled = false;
            btnnext.Enabled = false;
            btnlast.Enabled = false;
            btnCancel.Enabled = true;
            btnExit.Enabled = true;
            btnDelete.Enabled = false;
        }
        if (btnNew.Enabled == false)
            btnNew.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        if (btnSave.Enabled == false)
            btnSave.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        if (btnModify.Enabled == false)
            btnModify.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        if (btnQuery.Enabled == false)
            btnQuery.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        if (btnExecute.Enabled == false)
            btnExecute.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        if (btnCancel.Enabled == false)
            btnCancel.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        if (btnfirst.Enabled == false)
            btnfirst.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
        if (btnprevious.Enabled == false)
            btnprevious.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[7].ToString();
        if (btnnext.Enabled == false)
            btnnext.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        if (btnlast.Enabled == false)
            btnlast.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[9].ToString();
        if (btnDelete.Enabled == false)
            btnDelete.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[10].ToString();
        if (btnExit.Enabled == false)
            btnExit.ImageUrl = objDataSetbu.Tables[1].Rows[0].ItemArray[11].ToString();
        // Put user code to initialize the page here
    }

    #region Web Form Designer generated code
    protected void OnInit(EventArgs e)
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

    }
    #endregion
    /*new change ankur 15 feb*/
    public void bindcategoey()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.adsubcat category = new NewAdbooking.Classes.adsubcat();

            ds = category.addcategoryname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adsubcat category = new NewAdbooking.classesoracle.adsubcat();
            ds = category.addcategoryname(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.adsubcat category = new NewAdbooking.classmysql.adsubcat();
            ds = category.addcategoryname();
        }
        drpcat.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Category-";
        li1.Value = "0";
        li1.Selected = true;
        drpcat.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcat.Items.Add(li);


        }


    }
    public void bindedition()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindedition = new NewAdbooking.Classes.Adsize();
            ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindedition = new NewAdbooking.classesoracle.Adsize();
            ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.Adsize bindedition = new NewAdbooking.classmysql.Adsize();
            ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Edition--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpedit.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpedit.Items.Add(li);


        }

    }
    /*new change ankur 15 feb*/
    [Ajax.AjaxMethod]
    public void colortypesave(string compcode, string colortypecode, string colortypename, string alias, string username,string cat,string edit)
    {
        DataSet objds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype mst = new NewAdbooking.Classes.colortype();
            objds = mst.colortype_save(compcode, colortypecode, colortypename, alias, username, cat, edit);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype mst = new NewAdbooking.classesoracle.colortype();
            objds = mst.colortype_save(compcode, colortypecode, colortypename, alias, username, cat, edit);
        }
        else
        {
            NewAdbooking.classmysql.colortype mst = new NewAdbooking.classmysql.colortype();
            objds = mst.colortype_save(compcode, colortypecode, colortypename, alias, username, cat, edit);
        }



    }
    //*********************************************************************************************************
    /*new change ankur 15 feb*/
    [Ajax.AjaxMethod]
    public void colortypemodify(string compcode, string colortypecode, string colortypename, string alias, string username,string cat,string edit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype modsave = new NewAdbooking.Classes.colortype();
            ds = modsave.colortype_modify(compcode, colortypecode, colortypename, alias, username, cat, edit);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype modsave = new NewAdbooking.classesoracle.colortype();
            ds = modsave.colortype_modify(compcode, colortypecode, colortypename, alias, username, cat, edit);
        }
        else
        {
            NewAdbooking.classmysql.colortype modsave = new NewAdbooking.classmysql.colortype();
            ds = modsave.colortype_modify(compcode, colortypecode, colortypename, alias, username, cat, edit);
        }

    }
    //*********************************************************************************************************
    /*new change ankur 15 feb*/
    [Ajax.AjaxMethod]
    public DataSet colortypesearchexecute(string compcode, string colortypecode, string colortypename, string alias, string username)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype colorearchexecutea = new NewAdbooking.Classes.colortype();
            da = colorearchexecutea.chkcolortypeexecute(compcode, colortypecode, colortypename, alias, username);
            return da;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype colorearchexecutea = new NewAdbooking.classesoracle.colortype();
            da = colorearchexecutea.chkcolortypeexecute(compcode, colortypecode, colortypename, alias, username);
            return da;
        }
        else
        {
            NewAdbooking.classmysql.colortype colorearchexecutea = new NewAdbooking.classmysql.colortype();
            da = colorearchexecutea.chkcolortypeexecute(compcode, colortypecode, colortypename, alias, username);
            return da;
        }


    }

    //*********************************************************************************************************
    [Ajax.AjaxMethod]
    public void delete1(string compcode, string colortypecode, string userid)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype delete = new NewAdbooking.Classes.colortype();
            ds = delete.btndelete(compcode, colortypecode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype delete = new NewAdbooking.classesoracle.colortype();
            ds = delete.btndelete(compcode, colortypecode, userid);
        }
        else
        {
            NewAdbooking.classmysql.colortype delete = new NewAdbooking.classmysql.colortype();
            ds = delete.btndelete(compcode, colortypecode, userid);
        }
        //return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet chkcolortype(string compcode, string colortypename, string colortypecode, string userid,string cat,string edit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype delete = new NewAdbooking.Classes.colortype();
            ds = delete.chkcolortype(compcode, colortypename, colortypecode, userid, cat, edit);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype delete = new NewAdbooking.classesoracle.colortype();
            ds = delete.chkcolortype(compcode, colortypename, colortypecode, userid, cat, edit);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.colortype delete = new NewAdbooking.classmysql.colortype();
            ds = delete.chkcolortype(compcode, colortypename, colortypecode, userid, cat, edit);
            return ds;
        }



    }

    [Ajax.AjaxMethod]
    public DataSet chkcolortypename(string str)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype chk = new NewAdbooking.Classes.colortype();
            ds = chk.countcolortypecode(str);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype chk = new NewAdbooking.classesoracle.colortype();
            ds = chk.countcolortypecode(str);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.colortype chk = new NewAdbooking.classmysql.colortype();
            ds = chk.countcolortypecode(str);
            return ds;
        }



    }
    //**************************************************************************************
    /*new change ankur 15 feb*/
    [Ajax.AjaxMethod]
    public DataSet chkname(string colortypecode, string colortypename, string compcode,string cat,string edit)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.colortype idname = new NewAdbooking.Classes.colortype();
            ds = idname.chknameforduplicate(colortypecode, colortypename, compcode, cat, edit);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.colortype idname = new NewAdbooking.classesoracle.colortype();
            ds = idname.chknameforduplicate(colortypecode, colortypename, compcode, cat, edit);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.colortype idname = new NewAdbooking.classmysql.colortype();
            ds = idname.chknameforduplicate(colortypecode, colortypename, compcode, cat, edit);
            return ds;
        }

    }


}

