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

public partial class DistrictMaster : System.Web.UI.Page
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
            //	Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
            return;
        }


        Ajax.Utility.RegisterTypeForAjax(typeof(DistrictMaster));
        hiddenusername.Value = Session["Username"].ToString();
        



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
        //***********************************************************************//
        //*****************Code For Read the data from xml File******************//
        //*******************************For The Button**************************//
        //***********************************************************************//
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

        //********************************For Label****************************************/
        //This code reads the label name from the xml file
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/Districtmaster.xml"));
        lblDistCode.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString() + "<font color=red>*</font>";
        lbdistrictname.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString() + "<font color=red>*</font>";
        lbalias.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString() + "<font color=red>*</font>";
        lblcountry.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString() + "<font color=red>*</font>";
        lbstatename.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString() + "<font color=red>*</font>";

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

        // Put user code to initialize the page here

        if (!Page.IsPostBack)
        {
           state();

            Country();

            txtDistrictCode.Enabled = false;
            txtDistrictName.Enabled = false;
            txtAlias.Enabled = false;
            drpStateName.Enabled = false;
            drpCountryName.Enabled = false;

            drpCountryName.Attributes.Add("OnChange", "javascript:return fillcountry();");

//***************************Function Of Button Call from Java Script*************************
          
            btnNew.Attributes.Add("OnClick", "javascript:return NewClickd();");
            btnSave.Attributes.Add("OnClick", "javascript:return SaveClickd();");
            btnModify.Attributes.Add("OnClick", "javascript:return ModifyClickd();");
            btnQuery.Attributes.Add("OnClick", "javascript:return QueryClickd();");
            btnExecute.Attributes.Add("OnClick", "javascript:return ExecuteClickd();");
            btnCancel.Attributes.Add("OnClick", "javascript:return CancelClickd('DistrictMaster');");
            btnfirst.Attributes.Add("OnClick", "javascript:return FirstClickd();");
            btnprevious.Attributes.Add("OnClick", "javascript:return PreviousClickd();");
            btnnext.Attributes.Add("OnClick", "javascript:return NextClickd();");
            btnlast.Attributes.Add("OnClick", "javascript:return LastClickd();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteClick();");
            btnExit.Attributes.Add("OnClick", "javascript:return ExitClickd();");
            txtDistrictName.Attributes.Add("OnChange", "javascript:return autoornot();");
          
            txtAlias.Attributes.Add("OnBlur", "javascript:return uppercase('txtAlias');");
            txtDistrictCode.Attributes.Add("OnBlur", "javascript:return uppercase('txtDistrictCode');");
           // txtdistrictName.Attributes.Add("OnBlur", "javascript:return uppercase('txtDistrictName');");
            //txtdistrictName.Attributes.Add("OnChange", "javascript:return fillvalue();");
           
        }

    }


    [Ajax.AjaxMethod]
    //		public DataSet selstat(string compcode,string userid,string statcode)
     public DataSet selstat(string compcode, string userid, string statcode)
     {
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.DistrictMaster bind = new NewAdbooking.Classes.DistrictMaster();
        
        ds = bind.statesel(compcode, userid, statcode);
        return ds;
        }
        else if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster bind = new NewAdbooking.classesoracle.DistrictMaster();

                ds = bind.statesel(compcode, userid, statcode);
                return ds;
            }
        else  if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="orcl")
        {
            NewAdbooking.classmysql.DistrictMaster bind = new NewAdbooking.classmysql.DistrictMaster();

            ds = bind.statesel(compcode, userid, statcode);
            
        }
        return ds;
    }


    [Ajax.AjaxMethod]
    //		public DataSet bindstate(string code,string compcode,string userid)
     public DataSet bindstate(string code, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster bind = new NewAdbooking.Classes.DistrictMaster();
            
            ds = bind.bindstate(code, compcode, userid);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster bind = new NewAdbooking.classesoracle.DistrictMaster();

                ds = bind.bindstate(code, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster bind = new NewAdbooking.classmysql.DistrictMaster();

            ds = bind.bindstate(code, compcode, userid);
            return ds;
        }
    }

    //*******************************************************************************************//
    //^^^^^^^^Call The This Function From The Javascript For Update the data through the Ajax^^^^^//
    //*******************************************************************************************//
   
    [Ajax.AjaxMethod]
    //		public DataSet modify(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
     public DataSet modify(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
     {
         DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster modify = new NewAdbooking.Classes.DistrictMaster();
            
            ds = modify.ModifyValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster modify = new NewAdbooking.classesoracle.DistrictMaster();

                ds = modify.ModifyValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster modify = new NewAdbooking.classmysql.DistrictMaster();

            ds = modify.ModifyValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }
    }
    //*******************************************************************************************//
    //^^^^^^^^Call The This Function From The Javascript For Save the data through the Ajax^^^^^^//
    //*******************************************************************************************//
   
    [Ajax.AjaxMethod]
    //		public DataSet insert(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
     public DataSet insert(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.DistrictMaster insert = new NewAdbooking.Classes.DistrictMaster();
            
            ds = insert.InsertValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster insert = new NewAdbooking.classesoracle.DistrictMaster();

                ds = insert.InsertValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster insert = new NewAdbooking.classmysql.DistrictMaster();

            ds = insert.InsertValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    //		public DataSet Select(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
     public DataSet Select(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster select = new NewAdbooking.Classes.DistrictMaster();
            
            ds = select.SelectValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster select = new NewAdbooking.classesoracle.DistrictMaster();

                ds = select.SelectValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
                return ds;
            }

        else
        {
            NewAdbooking.classmysql.DistrictMaster select = new NewAdbooking.classmysql.DistrictMaster();

            ds = select.SelectValue(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }
    }

    //*******************************************************************************************//
    //^^^^^^^^Call The This Function From The Javascript For See the data through the Ajax^^^^^^^//
    //**************************After Click The First,Privious,Next,Last*************************//
    //*******************************************************************************************//
   
    [Ajax.AjaxMethod]
    //		public DataSet Selectfnpl(string DistCode,string DistName,string Alias,string StateName,string CountryName,string compcode,string userid)
     public DataSet Selectfnpl(string DistCode, string DistName, string Alias, string StateName, string CountryName, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster select = new NewAdbooking.Classes.DistrictMaster();
            
            ds = select.Selectfnpl(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster select = new NewAdbooking.classesoracle.DistrictMaster();

                ds = select.Selectfnpl(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster select = new NewAdbooking.classmysql.DistrictMaster();

            ds = select.Selectfnpl(DistCode, DistName, Alias, StateName, CountryName, compcode, userid);
            return ds;
        }
    }

    //		public void state()
    public void state()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster stateName = new NewAdbooking.Classes.DistrictMaster();
            
            ds = stateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster stateName = new NewAdbooking.classesoracle.DistrictMaster();

                ds = stateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster stateName = new NewAdbooking.classmysql.DistrictMaster();

            ds = stateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select State-----";
        li1.Value = "0";
        li1.Selected = true;
        drpStateName.Items.Add(li1);
        //drpStateName.Items.Insert(0, li1);


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string s, y;
            s = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            y = "";

            if (s != y)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpStateName.Items.Add(li);
                y = s;
            }
            else
            {


            }
        }
    }

    //		public void Country()
     public void Country()
     {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.DistrictMaster CountryName = new NewAdbooking.Classes.DistrictMaster();
             
             ds = CountryName.country(Session["compcode"].ToString(), Session["userid"].ToString());
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.DistrictMaster CountryName = new NewAdbooking.classesoracle.DistrictMaster();

                 ds = CountryName.country(Session["compcode"].ToString(), Session["userid"].ToString());
             }
         else
         {
             NewAdbooking.classmysql.DistrictMaster CountryName = new NewAdbooking.classmysql.DistrictMaster();

             ds = CountryName.country(Session["compcode"].ToString(), Session["userid"].ToString());

         }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-----Select Country-----";
        li1.Value = "0";
        li1.Selected = true;
        drpCountryName.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpCountryName.Items.Add(li);
        }
    }

    [Ajax.AjaxMethod]
   
     public DataSet chkcode(string DistCode,string DistName, string compcode, string userid,string countrycode)
     {
         DataSet ds = new DataSet(); 
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.DistrictMaster checkcode = new NewAdbooking.Classes.DistrictMaster();

            // ds = checkcode.checkdistrict(DistCode, DistName, compcode, userid, countrycode);
             ds = checkcode.checkdistrict(DistCode, DistName, compcode, userid);
             return ds;
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.DistrictMaster checkcode = new NewAdbooking.classesoracle.DistrictMaster();

                 ds = checkcode.checkdistrict(DistCode,DistName, compcode, userid);
                 return ds;
             }
         else
         {
             NewAdbooking.classmysql.DistrictMaster checkcode = new NewAdbooking.classmysql.DistrictMaster();

             ds = checkcode.checkdistrict(DistCode, DistName, compcode, userid);
             return ds;
         }
    }

    [Ajax.AjaxMethod]
    //		public DataSet deletedist(string DistCode,string compcode,string userid)
     public void deletedist(string DistCode, string compcode, string userid)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.DistrictMaster check = new NewAdbooking.Classes.DistrictMaster();
            
            da = check.DeleteValue(DistCode, compcode, userid);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster check = new NewAdbooking.classesoracle.DistrictMaster();

                da = check.DeleteValue(DistCode, compcode, userid);
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster check = new NewAdbooking.classmysql.DistrictMaster();

            da = check.DeleteValue(DistCode, compcode, userid);
        }
       // return da;
    }
    //*********************************************************************************************//
    //^^^^^^^^Call The This Function From The Javascript For Auto Generate Code through the Ajax^^^^^//
    //*********************************************************************************************//
   
    [Ajax.AjaxMethod]
    public DataSet chkdistrictcode(string str, string countrycode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster chk = new NewAdbooking.Classes.DistrictMaster();
            
            ds = chk.countdistrictcode(str,  countrycode);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster chk = new NewAdbooking.classesoracle.DistrictMaster();

                ds = chk.countdistrictcode(str, countrycode);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster chk = new NewAdbooking.classmysql.DistrictMaster();

            ds = chk.countdistrictcode(str, countrycode);
            return ds;
        }

    }

    [Ajax.AjaxMethod]
    public DataSet chkdistrictcodename(string str, string strname, string compcode, string countrycode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.DistrictMaster chk = new NewAdbooking.Classes.DistrictMaster();

            ds = chk.countdistrictcodename(str, strname, compcode, countrycode);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.DistrictMaster chk = new NewAdbooking.classesoracle.DistrictMaster();

                ds = chk.countdistrictcodename(str, strname, compcode);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.DistrictMaster chk = new NewAdbooking.classmysql.DistrictMaster();

            ds = chk.countdistrictcodename(str, strname, compcode);
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

}