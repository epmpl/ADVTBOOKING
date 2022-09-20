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

public partial class RepMast : System.Web.UI.Page
{
    string compcode, userid;

    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {


            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(RepMast));



        hiddenusername.Value = Session["Username"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();

        compcode = Session["compcode"].ToString();
        hiddencompcode.Value = compcode;

        userid = Session["userid"].ToString();
        hiddenuserid.Value = userid;

        pageloadbtn();
        //****work done by shweta***********************************************************
        //******************************XML FOR BUTTON**************************************
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

        //******************************XML for labels****************************************
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/RepMast.xml"));
        RepresentativeCode.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        RepresentativeName.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        dist.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        taluka.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        city.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        state.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        repstatus.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
        country.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();

        if (!Page.IsPostBack)
        {
            btnSave.Attributes.Add("OnClick", "javascript:return docsave();");
            btnNew.Attributes.Add("OnClick", "javascript:return docnew();");
            btnModify.Attributes.Add("OnClick", "javascript:return docmodify();");
            btnQuery.Attributes.Add("OnClick", "javascript:return docquery();");
            btnExecute.Attributes.Add("OnClick", "javascript:return docexe();");
            btnfirst.Attributes.Add("OnClick", "javascript:return docfirst();");
            btnprevious.Attributes.Add("OnClick", "javascript:return docpre();");
            btnnext.Attributes.Add("OnClick", "javascript:return docnext();");
            btnlast.Attributes.Add("OnClick", "javascript:return doclast();");
            btnCancel.Attributes.Add("OnClick", "javascript:return canceldoc('RepMast')");
            btnDelete.Attributes.Add("OnClick", "javascript:return deletedoc()");
            btnExit.Attributes.Add("OnClick", "javascript:return docexit()");
            txtrepcode.Attributes.Add("OnBlur", "javascript:return UpperCase('txtrepcode')");
            //txtrepname.Attributes.Add("OnBlur", "javascript:return UpperCase('txtrepname')");


            txtcountry.Attributes.Add("OnChange", "javascript:return addcount(this);");
            txtcity.Attributes.Add("OnChange", "javascript:return adddiststate(this);");



             txtrepname.Attributes.Add("OnChange", "javascript:return autoornot();");
            txtrepname.Attributes.Add("onkeydown", "javascript:return  pressf2(event);");

            lstsubcatname.Attributes.Add("onclick", "javascript:return insertsubcatname(event);");
            lstsubcatname.Attributes.Add("onkeydown", "javascript:return insertsubcatname(event);");







            countryname();
        }
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
        // Put user code to initialize the page here
    }



    //		public void pageloadbtn()
    public void pageloadbtn()
    {
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

        txtrepcode.Enabled = false;
        txtrepname.Enabled = false;
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


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet catdauto(string str, string subcatname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adsubcat3 chk = new NewAdbooking.Classes.adsubcat3();

            ds = chk.catdauto(str, subcatname, Session["compcode"].ToString());
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adsubcat3 chk = new NewAdbooking.classesoracle.adsubcat3();
            ds = chk.catdauto(str, subcatname, Session["compcode"].ToString(),"");
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.adsubcat3 chk = new NewAdbooking.classmysql.adsubcat3();
            ds = chk.catdauto(str, subcatname);
            return ds;
        }
    }


    [Ajax.AjaxMethod]
    public DataSet fill_subcat(string compcode, string ASD)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            
            NewAdbooking.Classes.RepMast clsbooking = new NewAdbooking.Classes.RepMast();
            ds = clsbooking.fill_subcat(compcode, ASD);
            return ds;
            
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RepMast clsbooking = new NewAdbooking.classesoracle.RepMast();
            ds = clsbooking.fill_subcat(compcode, ASD);
            return ds;
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "getrepnamesp";
            string[] parameterValueArray = { compcode, ASD };
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);
            
        }
        return ds;
    }



    public void countryname()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast name = new NewAdbooking.Classes.RepMast();
            ds = name.adcountryname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RepMast name = new NewAdbooking.classesoracle.RepMast();
            ds = name.adcountryname(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.RepMast name = new NewAdbooking.classmysql.RepMast();
            ds = name.adcountryname(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Country-----";
        li1.Value = "0";
        li1.Selected = true;
        txtcountry.Items.Add(li1);

        int i;
        for (i = 0; i < (ds.Tables[0].Rows.Count); i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            txtcountry.Items.Add(li);
        }
    }


    //city on select country...

    [Ajax.AjaxMethod]
    public DataSet getfromc(string txtcountry)
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
            NewAdbooking.classesoracle.RepMast firstAgency = new NewAdbooking.classesoracle.RepMast();
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


    [Ajax.AjaxMethod]

    public DataSet addcitydist(string values, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RetainerMaster add = new NewAdbooking.Classes.RetainerMaster();
            ds = add.addcitydist(values, compcode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RepMast add = new NewAdbooking.classesoracle.RepMast();
            ds = add.addcitydist(values);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.RetainerMaster add = new NewAdbooking.classmysql.RetainerMaster();
            ds = add.addcitydist(values);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet docchk(string compcode,string userid,string repcode)
    public DataSet docchk(string compcode, string userid, string repcode, string repname, string dist, string taluka1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.chkdoc(compcode, userid, repcode, repname, dist, taluka1);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.chkdoc(compcode, userid, repcode, repname, dist, taluka1);
                return ds;
            }

            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.chkdoc(compcode, userid, repcode, repname, dist, taluka1);
                return ds;
            }
    }
    [Ajax.AjaxMethod]
    //		public void modify(string compcode,string userid,string repcode,string repname)
    public void modify(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.docmodify(compcode, userid, repcode, repname, country, city, state, dist, taluka1, repstatus);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.docmodify(compcode, userid, repcode, repname, country, city, state, dist, taluka1, repstatus);

            }
            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.docmodify(compcode, userid, repcode, repname, country, city, state, dist, taluka1, repstatus);

            }
    }
    [Ajax.AjaxMethod]
    //		public void save(string compcode,string userid,string repcode,string repname)
    public void save(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.docinsert(compcode, userid, repcode, repname, country, city, state, dist, taluka1, repstatus);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.docinsert(compcode, userid, repcode, repname, country, city, state, dist, taluka1, repstatus);

            }
            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.docinsert(compcode, userid, repcode, repname, country, city, state, dist, taluka1, repstatus);

            }
    }

    [Ajax.AjaxMethod]
    //		public DataSet exe(string compcode,string userid,string repcode,string repname)
    public DataSet exe(string compcode, string userid, string repcode, string repname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.docexe(compcode, userid, repcode, repname);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.docexe(compcode, userid, repcode, repname);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.docexe(compcode, userid, repcode, repname);
                return ds;
            }
    }

    [Ajax.AjaxMethod]
    //		public DataSet fnpl(string compcode,string userid)
    public DataSet fnpl(string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.docfnpl(compcode, userid);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.docfnpl(compcode, userid);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.docfnpl(compcode, userid);
                return ds;
            }
    }

    [Ajax.AjaxMethod]
    //		public DataSet del(string compcode,string userid,string repcode)
    public DataSet del(string compcode, string userid, string repcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.docdel(compcode, userid, repcode);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.docdel(compcode, userid, repcode);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.docdel(compcode, userid, repcode);
                return ds;
            }
    }






    [Ajax.AjaxMethod]
    public DataSet chkrpcode(string str)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RepMast chk = new NewAdbooking.Classes.RepMast();

            ds = chk.chkrpcode1(str);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RepMast chk = new NewAdbooking.classesoracle.RepMast();

                ds = chk.chkrpcode1(str);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.RepMast chk = new NewAdbooking.classmysql.RepMast();

                ds = chk.chkrpcode1(str);
                return ds;
            }

    }

}