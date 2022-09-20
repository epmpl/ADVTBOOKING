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

public partial class AdvPositionTypMst : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();
            
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(AdvPositionTypMst));
        hiddenusername.Value = Session["Username"].ToString();

       // pagenobind();

        //////////////////////
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

        hiddenprem.Value = Session["premtype"].ToString();

        DataSet ds = new DataSet();
        // Read in the XML file
        ds.ReadXml(Server.MapPath("XML/AdvPositionType.xml"));

        PositionTypeCode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        PositonType.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        Alias.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        //lblamount.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        premium.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
       // Pageno.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        ValidFrom.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        ValidTill.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        AdvType.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        
        

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
        btnNew.Focus();
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
        
        // Put user code to initialize the page here
        if (!Page.IsPostBack)
        {

            addadvtype();
            txtPosTypCode.Enabled = false;
            txtPosType.Enabled = false;
            txtAlias.Enabled = false;
            //drpo.Enabled = false;
            txtamount.Enabled = false;
            drpremium.Enabled = false;
            txtvalid.Enabled = false;
            txtvalidtill.Enabled = false;
            dradvtyp.Enabled = false;

            txtvalid.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            txtvalidtill.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            btnNew.Attributes.Add("OnClick", "javascript:return NewClick2();");
            btnSave.Attributes.Add("OnClick", "javascript:return SaveClick2();");
            btnModify.Attributes.Add("OnClick", "javascript:return ModifyClick2();");
            btnDelete.Attributes.Add("OnClick", "javascript:return DeleteClick2();");
            btnQuery.Attributes.Add("OnClick", "javascript:return QueryClick2();");
            btnExecute.Attributes.Add("OnClick", "javascript:return ExecuteClick2();");
            btnCancel.Attributes.Add("OnClick", "javascript:return CancelClick2('AdvPositionTypMst');");
            btnfirst.Attributes.Add("OnClick", "javascript:return FirstClick2();");
            btnprevious.Attributes.Add("OnClick", "javascript:return PreviousClick2();");
            btnnext.Attributes.Add("OnClick", "javascript:return NextClick2();");
            btnlast.Attributes.Add("OnClick", "javascript:return LastClick2();");
            btnExit.Attributes.Add("OnClick", "javascript:return ExitClick2();");
            btnDelete.Attributes.Add("OnClick", "javascript:return DeleteClick2();");

            txtAlias.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtAlias');");
            txtPosTypCode.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtPosTypCode');");
            txtPosType.Attributes.Add("OnBlur", "javascript:return ClientUpperCase('txtPosType');");
            txtPosType.Attributes.Add("OnBlur", "javascript:return autoornot();");
            txtamount.Attributes.Add("OnChange", "javascript:return checkamount();");
            drpremium.Attributes.Add("OnChange", "javascript:return Cleartext();");
            
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
        btnNew.Focus();
    }



    //public void pagenobind()
    //{
    //    NewAdbooking.Classes.AdvPositionTypMst bindtype = new NewAdbooking.Classes.AdvPositionTypMst();
    //    DataSet ds = new DataSet();
    //    ds = bindtype.pagenobind1(Session["compcode"].ToString(), Session["userid"].ToString());

    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "-----Select-----";
    //    li1.Value = "0";
    //    li1.Selected = true;
    //    drppageno.Items.Add(li1);
    //    int i;
    //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li;
    //        li = new ListItem();

    //        li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            
    //        drppageno.Items.Add(li);
    //    }
    //}




    public void addadvtype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdvPagePositionMaster name = new NewAdbooking.Classes.AdvPagePositionMaster();

            ds = name.addadvtype();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPagePositionMaster name = new NewAdbooking.classesoracle.AdvPagePositionMaster();
            ds = name.addadvtype();
        }
        else
        {
            NewAdbooking.classmysql.AdvPagePositionMaster name = new NewAdbooking.classmysql.AdvPagePositionMaster();
            ds = name.addadvtype();
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select Ad Type---";
        li1.Value = "0";
        li1.Selected = true;
        dradvtyp.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dradvtyp.Items.Add(li);
        }
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet modify(string PosTypCode,string PosType,string Alias,string compcode,string userid)
    public DataSet modify(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string adtype)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.AdvPositionTypMst modify = new NewAdbooking.Classes.AdvPositionTypMst();

        ds = modify.ModifyValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid, fdate, tdate, Session["dateformat"].ToString(),adtype);
        return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst modify = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = modify.ModifyValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid, fdate, tdate, Session["dateformat"].ToString(), adtype);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst modify = new NewAdbooking.classmysql.AdvPositionTypMst();

            ds = modify.ModifyValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet chksave(string PosTypCode,string compcode,string userid)
     public DataSet chksave(string PosTypCode, string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst modify = new NewAdbooking.Classes.AdvPositionTypMst();
         
            ds = modify.chksave(PosTypCode, compcode, userid);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst modify = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = modify.chksave(PosTypCode, compcode, userid);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst modify = new NewAdbooking.classmysql.AdvPositionTypMst();

            ds = modify.chksave(PosTypCode, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public void delete1(string PosTypCode,string compcode,string userid)
     public void delete1(string PosTypCode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst delete1 = new NewAdbooking.Classes.AdvPositionTypMst();
           
            ds = delete1.delete1(PosTypCode, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst delete1 = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = delete1.delete1(PosTypCode, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst delete1 = new NewAdbooking.classmysql.AdvPositionTypMst();

            ds = delete1.delete1(PosTypCode, compcode, userid);
        }
        //return ds;
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet insert(string PosTypCode,string PosType,string Alias,string compcode,string userid)
    public DataSet insert(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst insert = new NewAdbooking.Classes.AdvPositionTypMst();

            ds = insert.InsertValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid, fdate, tdate, Session["dateformat"].ToString(),adtype);
            return ds;
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst insert = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = insert.InsertValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid, fdate, tdate, Session["dateformat"].ToString(), adtype);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst insert = new NewAdbooking.classmysql.AdvPositionTypMst();

            ds = insert.InsertValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet Select(string PosTypCode,string PosType,string Alias,string compcode,string userid)
    // public DataSet Select(string PosTypCode, string PosType, string Alias,int amount,string compcode, string userid)
    public DataSet Selectpage(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst select = new NewAdbooking.Classes.AdvPositionTypMst();

      
            ds = select.SelectValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid, Session["dateformat"].ToString());
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst select = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = select.SelectValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid, Session["dateformat"].ToString());
            return ds;
        }

        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst select = new NewAdbooking.classmysql.AdvPositionTypMst();

            ds = select.SelectValue(PosTypCode, PosType, Alias, amount, premium, compcode, userid);
            return ds;
        }

    }

    [Ajax.AjaxMethod]
    //		public DataSet Selectfnpl(string PosTypCode,string PosType,string Alias,string compcode,string userid)
    public DataSet Selectfnpl(string PosTypCode, string PosType, string Alias, string amount, string premium,string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst select = new NewAdbooking.Classes.AdvPositionTypMst();
            
            ds = select.Selectfnpl(PosTypCode, PosType, Alias, amount, premium, compcode, userid);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst select = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = select.Selectfnpl(PosTypCode, PosType, Alias, amount, premium, compcode, userid);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst select = new NewAdbooking.classmysql.AdvPositionTypMst();

            ds = select.Selectfnpl(PosTypCode, PosType, Alias, amount, premium, compcode, userid);
            return ds;

        }
    }



    [Ajax.AjaxMethod]
    public DataSet chkadvposition(string str)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst chk = new NewAdbooking.Classes.AdvPositionTypMst();
            ds = chk.chkadvposition1(str);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst chk = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = chk.chkadvposition1(str);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.AdvPositionTypMst chk = new NewAdbooking.classmysql.AdvPositionTypMst();
            ds = chk.chkadvposition1(str);
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
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet chkpastypename(string PosTypCode,string PosTypName, string compcode, string userid,string fdate,string tdate,string flag)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.AdvPositionTypMst modify = new NewAdbooking.Classes.AdvPositionTypMst();

            ds = modify.chkpastypename1(PosTypCode, PosTypName, compcode, userid, fdate, tdate, flag, Session["dateformat"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdvPositionTypMst modify = new NewAdbooking.classesoracle.AdvPositionTypMst();
            ds = modify.chkpastypename1(PosTypCode, PosTypName, compcode, userid, fdate, tdate, flag, Session["dateformat"].ToString());
        }
        return ds;
    }
}