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
using System.Data.SqlClient;
public partial class Vatmaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        hiddencomcode.Value = Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["DateFormat"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        hiddenauto.Value = Session["autogenerated"].ToString();
        //hiddenvatcode.Value = Session["vatcode"].ToString();


        Ajax.Utility.RegisterTypeForAjax(typeof(Vatmaster));




        DataSet objDataSetbu = new DataSet();
        //***********************************************************************//
        //*****************Code For Read the data from xml File******************//
        //*******************************For The Button**************************//
        //***********************************************************************/
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
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/vatmaster.xml"));
       lblfrmdate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
       lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
       lbldescription.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
      // lblcode.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
       lblorder.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
       lblvatrate.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
       lblgross.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
       PublicationName.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
       EditonName.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();




       btnNew.Focus();
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

        txtfromdate.Enabled = false;
        txttodate.Enabled = false;
        drpPubName.Enabled = false;
        drpdescription.Enabled = false;
        txtvatrate.Enabled = false;
        drpgross.Enabled = false;
        txtorder.Enabled = false;
        drEditonName.Enabled = false;
        if (!IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            
           btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
           btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
           btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('Vatmaster');");
           // txtcode.Attributes.Add("OnChange", "javascript:return autoorder();");
            drpdescription.Attributes.Add("OnChange", "javascript:return autoorder();");
            //txtcode.Attributes.Add("OnBlur", "javascript:return limet();");
            txtvatrate.Attributes.Add("OnChange", "javascript:return limet();");
            txtfromdate.Attributes.Add("OnChange", "javascript:return checkdate(this);javascript:return vatdate();");
            txttodate.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            drpPubName.Attributes.Add("OnChange", "javascript:return addedition();");
            //txttodate.Attributes.Add("OnBlur", "javascript:return vatdate();");
           // drpgross.Attributes.Add("OnChange", "javascript:return grosstype();");
            //category(Session["compcode"].ToString());
            addPub();
            grosstype();
            description();

        }
        //if (todate != "" && fromdate != "")
        //{

        //    NewAdbooking.Classes.vatmaster insert = new NewAdbooking.Classes.vatmaster();
        //    DataSet ds = new DataSet();
        //    ds = insert.chkdate(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
        //    //return ds;

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        center = "Y";

        //    }
        //    else
        //    {
        //        center = "N";

        //    }
        //    Response.Write(center);
        //    Response.End();
        //}

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

    }
    //		public void addPub()
    public void addPub()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.SupplimentMaster PubName = new NewAdbooking.Classes.SupplimentMaster();

            ds = PubName.Pub(hiddencompcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster PubName = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = PubName.Pub(hiddencompcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster PubName = new NewAdbooking.classmysql.SupplimentMaster();

            ds = PubName.Pub(hiddencompcode.Value);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Publication--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpPubName.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpPubName.Items.Add(li);


        }
    }
    [Ajax.AjaxMethod]
    public DataSet addedition(string pubname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.SupplimentMaster chkv = new NewAdbooking.Classes.SupplimentMaster();

            ds = chkv.addedition(pubname);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.SupplimentMaster chkv = new NewAdbooking.classesoracle.SupplimentMaster();
            ds = chkv.addedition(pubname);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.SupplimentMaster chkv = new NewAdbooking.classmysql.SupplimentMaster();

            ds = chkv.addedition(pubname);
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet vatsave(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype,string orderno,string publicat,string edit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster save = new NewAdbooking.Classes.vatmaster();
            ds = save.vatsave(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno, publicat, edit);
            return ds;
        }

        else
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                 NewAdbooking.classesoracle .vatmaster save = new NewAdbooking.classesoracle.vatmaster();
                 ds = save.vatsave(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno, publicat, edit);
            return ds;
            }
        else
        {
            NewAdbooking.classmysql.vatmaster save = new NewAdbooking.classmysql.vatmaster();
            ds = save.vatsave(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet vatdauto(string str)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster chk = new NewAdbooking.Classes.vatmaster();
            ds = chk.dauto(str);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                 NewAdbooking.classesoracle .vatmaster chk = new NewAdbooking.classesoracle.vatmaster();
            ds = chk.dauto(str);
            return ds;
            }
        else
        {
            NewAdbooking.classmysql.vatmaster chk = new NewAdbooking.classmysql.vatmaster();
            ds = chk.dauto(str);
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet vatexecute(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster vatexe = new NewAdbooking.Classes.vatmaster();
            ds = vatexe.vatexecute(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.vatmaster vatexe = new NewAdbooking.classesoracle.vatmaster();
            ds = vatexe.vatexecute(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
            return ds;
            }
        else
        {
            NewAdbooking.classmysql.vatmaster vatexe = new NewAdbooking.classmysql.vatmaster();
            ds = vatexe.vatexecute(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet vatchk(string description)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster chk = new NewAdbooking.Classes.vatmaster();
            ds = chk.vatchk(description);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle .vatmaster chk = new NewAdbooking.classesoracle.vatmaster();
            ds = chk.vatchk(description);
            return ds;
            }
        else
        {
            NewAdbooking.classmysql.vatmaster chk = new NewAdbooking.classmysql.vatmaster();
            ds = chk.vatchk(description);
            return ds;
        }
    }

    [Ajax.AjaxMethod]
    public DataSet vatdelete(string compcode, string description,string fromdate,string todate,string publicat,string edit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster delet = new NewAdbooking.Classes.vatmaster();
            ds = delet.vatdelete(compcode, description, fromdate, todate, publicat, edit);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.vatmaster delet = new NewAdbooking.classesoracle.vatmaster();
                ds = delet.vatdelete(compcode, description, fromdate, todate, publicat, edit);
            return ds;
            }
        else
        {
            NewAdbooking.classmysql.vatmaster delet = new NewAdbooking.classmysql.vatmaster();
            ds = delet.vatdelete(compcode, description);
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet vatmodify(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno,string publicat,string edit)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster modify = new NewAdbooking.Classes.vatmaster();
            ds = modify.vatmodify(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno, publicat, edit);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle .vatmaster modify = new NewAdbooking.classesoracle.vatmaster();
                ds = modify.vatmodify(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno, publicat, edit);
            return ds;
            }
        else
        {
            NewAdbooking.classmysql.vatmaster modify = new NewAdbooking.classmysql.vatmaster();
            ds = modify.vatmodify(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
            return ds;
        }
    }

    
    public void grosstype()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.vatmaster type = new NewAdbooking.Classes.vatmaster();
            ds = type.grosstype(Session["compcode"].ToString());
        }
        else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
        {
                NewAdbooking.classesoracle .vatmaster type = new NewAdbooking.classesoracle.vatmaster();
            ds = type.grosstype(Session["compcode"].ToString());
        }
            else
            {
                    NewAdbooking.classmysql  .vatmaster type = new NewAdbooking.classmysql.vatmaster();
            ds = type.grosstype(Session["compcode"].ToString());
            }

            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-----Select Type-----";
            li1.Value = "0";
            li1.Selected = true;
            drpgross.Items.Add(li1);

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();

                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                drpgross.Items.Add(li);
            }
        }
        
      
       
   
    public void description()
    {

        DataSet description = new DataSet();
        description.ReadXml(Server.MapPath("XML/vatmaster.xml"));
        drpdescription.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Description";
        li1.Value = "0";
        li1.Selected = true;
       drpdescription.Items.Add(li1);

        for (i = 0; i < description.Tables[1].Columns.Count ; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = description.Tables[1].Rows[0].ItemArray[i].ToString();
           
            li.Value = description.Tables[1].Rows[0].ItemArray[i].ToString();
             drpdescription.Items.Add(li);

        }
    }
    [Ajax.AjaxMethod]
    public DataSet chkdate(string description, string fromdate, string todate,string publicat,string edit)
    {

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
        NewAdbooking.Classes.vatmaster chk = new NewAdbooking.Classes.vatmaster();
        DataSet ds = new DataSet();
        ds = chk.chkdate(description, fromdate, todate, publicat, edit);
        return ds;
        }
         else
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.vatmaster chk = new NewAdbooking.classesoracle.vatmaster();
                DataSet ds = new DataSet();
                ds = chk.chkdate(description, fromdate, todate, publicat, edit);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.vatmaster chk = new NewAdbooking.classmysql.vatmaster();
                DataSet ds = new DataSet();
                ds = chk.chkdate(description, fromdate, todate);
                return ds;
            }
    }




}
