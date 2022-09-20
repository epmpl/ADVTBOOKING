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

public partial class PublicationType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        btnNew.Focus();

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();
        }

        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;

        }
        ip1.Value = Request.ServerVariables["REMOTE_ADDR"];
        Ajax.Utility.RegisterTypeForAjax(typeof(PublicationType));
        hiddenusername.Value = Session["Username"].ToString();

        DataSet ds = new DataSet();
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

        DataSet objds = new DataSet();
        objds.ReadXml(Server.MapPath("XML/PublicationType.xml"));

        lblpubtypeCode.Text = objds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbpubtypename.Text = objds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbAlias.Text = objds.Tables[0].Rows[0].ItemArray[2].ToString();

        if (Session["Username"] == null)
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        else
        {
        }
        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = false;
        btnCancel.Enabled = true;
        btnfirst.Enabled = false;
        btnnext.Enabled = false;
        btnprevious.Enabled = false;
        btnlast.Enabled = false;
        btnExit.Enabled = true;

        txtpubtypecode.Enabled = false;
        txtpubtypename.Enabled = false;
        txtAlias.Enabled = false;
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
        btnNew.Focus();

        // Put user code to initialize the page here
        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return NewClick2();");
            btnSave.Attributes.Add("OnClick", "javascript:return SaveClick2();");
            btnModify.Attributes.Add("OnClick", "javascript:return ModifyClick2();");
            btnDelete.Attributes.Add("OnClick", "javascript:return DeleteClick2();");
            btnQuery.Attributes.Add("OnClick", "javascript:return QueryClick2();");
            btnExecute.Attributes.Add("OnClick", "javascript:return ExecuteClick2();");
            btnCancel.Attributes.Add("OnClick", "javascript:return CancelClick2('PublicationType');");
            btnfirst.Attributes.Add("OnClick", "javascript:return FirstClick2();");
            btnprevious.Attributes.Add("OnClick", "javascript:return PreviousClick2();");
            btnnext.Attributes.Add("OnClick", "javascript:return NextClick2();");
            btnlast.Attributes.Add("OnClick", "javascript:return LastClick2();");
            btnExit.Attributes.Add("OnClick", "javascript:return ExitClick2();");
            btnDelete.Attributes.Add("OnClick", "javascript:return DeleteClick2();");

            txtpubtypecode.Attributes.Add("OnBlur", "javascript:return pubtypautocode();");

            txtpubtypename.Attributes.Add("OnChange", "javascript:return pubtypautocode();");

            txtAlias.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtAlias');");
            txtpubtypecode.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtpubtypecode');");
            //txtPosType.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtPosType');");


        }

    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet modify(string pubcode, string pubname, string Alias, string compcode, string userid,string ip)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.PublicationType modify = new NewAdbooking.Classes.PublicationType();

                ds = modify.ModifyValue(pubcode, pubname, Alias, compcode, userid);
                //return ds;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PublicationType modify = new NewAdbooking.classesoracle.PublicationType();
                ds = modify.ModifyValue(pubcode, pubname, Alias, compcode, userid);
                //return ds;
            }
            else
            {
                NewAdbooking.classmysql.PublicationType modify = new NewAdbooking.classmysql.PublicationType();

                ds = modify.ModifyValue(pubcode, pubname, Alias, compcode, userid);
                //return ds;

            }
        }
        catch (Exception e)
        {
            err = e.Message;
        }
        string pubcode2 = "Modified Publication Type " + pubcode;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','Publication Type','" + err.Replace("'", "''") + "','Publication Type Modify','" + pubcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet save(string pubtypename,string pubcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.PublicationType chksave = new NewAdbooking.Classes.PublicationType();

                ds = chksave.save(pubtypename, pubcode, compcode, userid);
                return ds;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PublicationType chksave = new NewAdbooking.classesoracle.PublicationType();
                ds = chksave.save(pubtypename, pubcode, compcode, userid);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.PublicationType chksave = new NewAdbooking.classmysql.PublicationType();

                ds = chksave.save(pubtypename, pubcode, compcode, userid);
                return ds;
            }
        
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void delete1(string pubcode, string compcode, string userid, string ip)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.PublicationType delete1 = new NewAdbooking.Classes.PublicationType();

                ds = delete1.delete1(pubcode, compcode, userid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PublicationType delete1 = new NewAdbooking.classesoracle.PublicationType();
                ds = delete1.delete1(pubcode, compcode, userid);
            }
            else
            {
                NewAdbooking.classmysql.PublicationType delete1 = new NewAdbooking.classmysql.PublicationType();

                ds = delete1.delete1(pubcode, compcode, userid);
            }
        }
        catch (Exception e)
        {
            err = e.Message;
        }
        string pubcode3 = "Deleted Publication Type " + pubcode;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','Publication Type','" + err.Replace("'", "''") + "','Publication Type Deletion','" + pubcode3;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        //return ds;

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //public DataSet insert(string pubcode,string pubname,string Alias,string compcode,string userid)
    public DataSet insert(string pubcode, string pubname, string Alias, string compcode, string userid, string ip)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.PublicationType insert = new NewAdbooking.Classes.PublicationType();

                ds = insert.InsertValue(pubcode, pubname, Alias, compcode, userid);
                //return ds;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.PublicationType insert = new NewAdbooking.classesoracle.PublicationType();
                ds = insert.InsertValue(pubcode, pubname, Alias, compcode, userid);
                //return ds;
            }
            else
            {
                NewAdbooking.classmysql.PublicationType insert = new NewAdbooking.classmysql.PublicationType();

                ds = insert.InsertValue(pubcode, pubname, Alias, compcode, userid);
                //return ds;
            }
        }
        catch (Exception e)
        {
            err = e.Message;
        }
        string pubcode2 = "Inserted Publication Type " + pubcode;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','Publication Type','" + err.Replace("'", "''") + "','Publication Type Creation','" + pubcode2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;

    }

    [Ajax.AjaxMethod]
    //public DataSet Select(string pubcode,string pubname,string Alias,string compcode,string userid)
    public DataSet Execute(string pubcode, string pubname, string Alias, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PublicationType select = new NewAdbooking.Classes.PublicationType();
            
            ds = select.Execute1(pubcode, pubname, Alias, compcode, userid);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PublicationType select = new NewAdbooking.classesoracle.PublicationType();

            ds = select.Execute1(pubcode, pubname, Alias, compcode, userid);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.PublicationType select = new NewAdbooking.classmysql.PublicationType();

            ds = select.Execute1(pubcode, pubname, Alias, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //public DataSet Selectfnpl(string pubcode,string pubname,string Alias,string compcode,string userid)
    public DataSet Selectfnpl(string pubcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PublicationType select = new NewAdbooking.Classes.PublicationType();
            
            ds = select.Selectfnpl(pubcode, compcode, userid);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PublicationType select = new NewAdbooking.classesoracle.PublicationType();
            ds = select.Selectfnpl(pubcode, compcode, userid);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.PublicationType select = new NewAdbooking.classmysql.PublicationType();

            ds = select.Selectfnpl(pubcode, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet autopreodicity(string str)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.PublicationType adcat = new NewAdbooking.Classes.PublicationType();
            
            ds = adcat.prodicityauto(str,Session["compcode"].ToString());
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.PublicationType adcat = new NewAdbooking.classesoracle.PublicationType();
            ds = adcat.prodicityauto(str, Session["compcode"].ToString());
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.PublicationType adcat = new NewAdbooking.classmysql.PublicationType();

            ds = adcat.prodicityauto(str, Session["compcode"].ToString());
            return ds;
        }
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

    protected void btnNew_Click(object sender, System.EventArgs e)
    {
    }

    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }

}
