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

public partial class MaterialMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] == null)
        //if  ;
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenDateFormat.Value = Session["dateformat"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(MaterialMaster));

        hiddenusername.Value = Session["Username"].ToString();
        

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

        txtmatcode.Enabled = false;
        txtmatname.Enabled = false;
        txtmatalias.Enabled = false;

        if (!Page.IsPostBack)
        {
            //pagedef();

            btnNew.Attributes.Add("OnClick", "javascript:return matnew();");
            btnSave.Attributes.Add("OnClick", "javascript:return matsave();");
            btnModify.Attributes.Add("OnClick", "javascript:return matmodify();");
            btnQuery.Attributes.Add("OnClick", "javascript:return querymat();");
            btnExecute.Attributes.Add("OnClick", "javascript:return matexe();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstmat();");
            btnprevious.Attributes.Add("OnClick", "javascript:return premat();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextmat();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastmat();");
            btnCancel.Attributes.Add("OnClick", "javascript:return matcancle();");
            btnExit.Attributes.Add("OnClick", "javascript:return matexit();");
            btnDelete.Attributes.Add("OnClick", "javascript:return matdelete();");


            txtmatcode.Attributes.Add("OnBlur", "javascript:return UpperCase('txtmatcode');");
            txtmatname.Attributes.Add("OnBlur", "javascript:return UpperCase('txtmatname');");
            txtmatalias.Attributes.Add("OnBlur", "javascript:return UpperCase('txtmatalias');");
        }
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


    /*public void pagedef()
		{
			btnNew.Enabled=true;
			btnSave.Enabled=false;
			btnModify.Enabled=false;
			btnDelete.Enabled=false;
			btnQuery.Enabled=true;
			btnExecute.Enabled=false;
			btnCancel.Enabled=true;
			btnfirst.Enabled=false;
			btnprevious.Enabled=false;
			btnnext.Enabled=false;
			btnlast.Enabled=false;
			btnExit.Enabled=true;
			
			txtmatcode.Enabled=false;
			txtmatname.Enabled=false;
			txtmatalias.Enabled=false;
		}*/

    [Ajax.AjaxMethod]
    //		public DataSet chk(string compcode,string matcode,string matname,string userid)
     public DataSet chk(string compcode, string matcode, string matname, string userid)
    {
        NewAdbooking.Classes.MaterialMaster check = new NewAdbooking.Classes.MaterialMaster();
        DataSet ds = new DataSet();
        ds = check.chksave(compcode, matcode, matname, userid);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet insertmat(string compcode,string matcode,string matname,string userid,string matalias)
     public DataSet insertmat(string compcode, string matcode, string matname, string userid, string matalias)
    {
        NewAdbooking.Classes.MaterialMaster check = new NewAdbooking.Classes.MaterialMaster();
        DataSet ds = new DataSet();
        ds = check.matinsert(compcode, matcode, matname, userid, matalias);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet updatemat(string compcode,string matcode,string matname,string userid,string matalias)
     public DataSet updatemat(string compcode, string matcode, string matname, string userid, string matalias)
    {
        NewAdbooking.Classes.MaterialMaster check = new NewAdbooking.Classes.MaterialMaster();
        DataSet ds = new DataSet();
        ds = check.matupdate(compcode, matcode, matname, userid, matalias);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet exemat(string compcode,string matcode,string matname,string userid,string matalias)
     public DataSet exemat(string compcode, string matcode, string matname, string userid, string matalias)
    {
        NewAdbooking.Classes.MaterialMaster check = new NewAdbooking.Classes.MaterialMaster();
        DataSet ds = new DataSet();
        ds = check.matexe(compcode, matcode, matname, userid, matalias);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet fnplmat(string compcode,string userid)
     public DataSet fnplmat(string compcode, string userid)
    {
        NewAdbooking.Classes.MaterialMaster check = new NewAdbooking.Classes.MaterialMaster();
        DataSet ds = new DataSet();
        ds = check.matfnpl(compcode, userid);
        return ds;
    }

    [Ajax.AjaxMethod]
    //		public DataSet deletemat(string compcode,string matcode,string matname,string matalias,string userid)
     public DataSet deletemat(string compcode, string matcode, string matname, string matalias, string userid)
    {
        NewAdbooking.Classes.MaterialMaster del = new NewAdbooking.Classes.MaterialMaster();
        DataSet ds = new DataSet();
        ds = del.deletemat(compcode, matcode, matname, matalias, userid);
        return ds;
    }

    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }

}