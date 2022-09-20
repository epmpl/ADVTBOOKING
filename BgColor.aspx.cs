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

public partial class BgColor : System.Web.UI.Page
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
             ip1.Value = Request.ServerVariables["REMOTE_ADDR"];
             hiddencomcode.Value = Session["compcode"].ToString();
             hiddencompcode.Value = Session["compcode"].ToString();
             hiddenuserid.Value = Session["userid"].ToString();
             hiddenDateFormat.Value = Session["DateFormat"].ToString();
             hiddenusername.Value = Session["Username"].ToString();
             hiddenauto.Value = Session["autogenerated"].ToString();
             hiddenpubforbg.Value = Session["bg_colorpub"].ToString();
             Ajax.Utility.RegisterTypeForAjax(typeof(BgColor));
        //***********************************************************************//
        //*****************Code For Read the data from xml File******************//
        //*******************************For The Button**************************//
        //***********************************************************************/
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
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/BgColor.xml"));
        lblbgid.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblbgname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblbgalias.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();

        /*new change ankur*/
        if (Session["bg_colorpub"].ToString() == "yes")
        {
            lbedition.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString()+"<font color=red>*</font>";
            lbcat.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString() + "<font color=red>*</font>";
            lbcolortype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString() + "<font color=red>*</font>";
            lbpub.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString() + "<font color=red>*</font>";
            lbcat2.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            lbcat3.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            lbcat4.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lbcat5.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        }
        else
        {
            lbedition.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            lbcat.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            lbcolortype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            lbpub.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            lbcat2.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            lbcat3.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            lbcat4.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lbcat5.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        }
        ///////////////////////////////////////////////

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

        txtbgid.Enabled = false;
        txtbgname.Enabled = false;
        txtbgalias.Enabled = false;


        if (!Page.IsPostBack)
        {
            /*new change ankur*/
            bindpublication();
            
            bindcategory();
            bindcolortype();
            drppub.Attributes.Add("OnChange", "javascript:return filledit();");
            ///////////////////////////////
            btnNew.Attributes.Add("OnClick", "javascript:return bgnewclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return bgsaveclick();");
            txtbgname.Attributes.Add("OnChange", "javascript:return autoornot();");
            btnModify.Attributes.Add("OnClick", "javascript:return bgmodifyclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return bgqueryclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return bgexecuteclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return bgfirstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return bgpreviousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return bgnextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return bglastclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return bgexitclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return bgdeleteclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return bgcancelclick('BgColor');");
            drpcat.Attributes.Add("OnChange", "javascript:return fillAdCat2();");
            drpcat2.Attributes.Add("OnChange", "javascript:return fillAdCat3();");
            drpcat3.Attributes.Add("OnChange", "javascript:return fillAdCat4();");
            drpcat4.Attributes.Add("OnChange", "javascript:return fillAdCat5();"); 
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
    }


    /*new change ankur*/
    public void bindpublication()
    {
              DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            
        {
        NewAdbooking.Classes.EditorMaster PubName = new NewAdbooking.Classes.EditorMaster();
        
        ds = PubName.Pub(hiddencompcode.Value);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.EditorMaster PubName = new NewAdbooking.classesoracle.EditorMaster();

                ds = PubName.Pub(hiddencompcode.Value);

            }
            else
            {
                NewAdbooking.classmysql.EditorMaster PubName = new NewAdbooking.classmysql.EditorMaster();

                ds = PubName.Pub(hiddencompcode.Value);

            }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select Publication---";
        li1.Value = "0";
        li1.Selected = true;
        drppub.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drppub.Items.Add(li);
        }
                
    }

    public void bindcategory()
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
            //NewAdbooking.classmysql.adsubcat category = new NewAdbooking.classmysql.adsubcat();
            //ds = category.addcategoryname();

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
    public void bindcolortype()
    {
            DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.BgColor colortype = new NewAdbooking.Classes.BgColor();
    
        ds = colortype.bindcolortyp(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                        NewAdbooking.classesoracle .BgColor colortype = new NewAdbooking.classesoracle.BgColor();
    
        ds = colortype.bindcolortyp(Session["compcode"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.BgColor colortype = new NewAdbooking.classmysql.BgColor();
    
        ds = colortype.bindcolortyp(Session["compcode"].ToString());

            }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select color type-";
        li1.Value = "0";
        li1.Selected = true;
        drpcolortype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpcolortype.Items.Add(li);
        }

    }


    /////////////////////////////////////////////////////////////////////////////////////////

    //*******************************************************************************************//
    //^^^^^^^^Call The This Function From The Javascript For Save the data through the Ajax^^^^^^//
    //*******************************************************************************************

   


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    /*new change ankur*/
    public DataSet bgSave(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string coltyp, string ip, string comcode,string bgtype,string bgamt)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BgColor bgsave = new NewAdbooking.Classes.BgColor();
                /*new change ankur*/
                ds = bgsave.bgSave(bgid, bgname, bgalias, pub, edit, cat, cat2, cat3, cat4, cat5, coltyp, comcode, bgtype, bgamt);
                //return ds;
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BgColor bgsave = new NewAdbooking.classesoracle.BgColor();

                    ds = bgsave.bgSave(bgid, bgname, bgalias, pub, edit, cat, cat2, cat3, cat4, cat5, coltyp, comcode, bgtype, bgamt);
                    //      return ds;
                }
                else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
                {
                    string procedureName = "bg_save_bg_save_p";
                    string[] parameterValueArray = { bgid, bgname, bgalias, pub, edit, cat, cat2, cat3, cat4, cat5, coltyp, comcode, bgtype, bgamt };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
        }
        catch (Exception e)
        {
            err = e.Message;
        }
        string bgid1 = "Inserted BgColor " + bgid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["UserId"] + "','BgColor','" + err.Replace("'", "''") + "','BgColor Created','" + bgid1;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;
    }
    [Ajax.AjaxMethod]
    /*new change ankur*/
    public DataSet chkbgid(string bgid,string pub,string edit,string cat, string colortype,string bgname)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {
        NewAdbooking.Classes.BgColor Chkbgid = new NewAdbooking.Classes.BgColor();
            /*new change ankur*/
        ds = Chkbgid.chkbgid(bgid,pub,edit,cat,colortype,bgname);
        return ds;
    }

    else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.BgColor Chkbgid = new NewAdbooking.classesoracle.BgColor();
            ds = Chkbgid.chkbgid(bgid, pub, edit, cat,colortype, bgname);
            return ds;
        }
    else
    {
        NewAdbooking.classmysql.BgColor Chkbgid = new NewAdbooking.classmysql.BgColor();
        ds = Chkbgid.chkbgid(bgid, pub, edit, cat, colortype, bgname);
        return ds;

    }
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    /*new change ankur*/
    public DataSet bgmodify(string bgid, string bgname, string bgalias,string pub,string edit,string cat, string cat2, string cat3, string cat4, string cat5,string coltyp,string ip, string compcode,string bgtype,string bgamt)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BgColor bgmod = new NewAdbooking.Classes.BgColor();

                ds = bgmod.bgmodify(bgid, bgname, bgalias, pub, edit, cat, cat2, cat3, cat4, cat5, coltyp, compcode, bgtype, bgamt);
                //return ds;
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BgColor bgmod = new NewAdbooking.classesoracle.BgColor();

                    ds = bgmod.bgmodify(bgid, bgname, bgalias, pub, edit, cat, cat2, cat3, cat4, cat5, coltyp, compcode, bgtype, bgamt);
                    //      return ds;
                }
                else
                {
                    NewAdbooking.classmysql.BgColor bgmod = new NewAdbooking.classmysql.BgColor();
                    ds = bgmod.bgmodify(bgid, bgname, bgalias, pub, edit, cat, cat2, cat3, cat4, cat5, coltyp, compcode);
                    //return ds;


                }
        }
        catch (Exception e)
        {
            err = e.Message;
        }
        string bgid2 = "Modified BgColor " + bgid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["UserId"] + "','BgColor','" + err.Replace("'", "''") + "','BgColor Updated','" + bgid2;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        return ds;

    }
    [Ajax.AjaxMethod]
    //		public DataSet Advexecute1(string companycode,string zonecode,string zonename,string alias,string UserId)
    // public DataSet billexecute1(string companycode, string zonecode, string zonename, string alias, string UserId)
    public DataSet bgexecute1(string bgid, string bgname, string bgalias, string compcode)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.BgColor bllexe1 = new NewAdbooking.Classes.BgColor();

        ds = bllexe1.bgexecute1(bgid, bgname, bgalias, compcode);
        return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BgColor bllexe1 = new NewAdbooking.classesoracle.BgColor();

                ds = bllexe1.bgexecute1(bgid, bgname, bgalias, compcode);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.BgColor bllexe1 = new NewAdbooking.classmysql.BgColor();
            ds = bllexe1.bgexecute1(bgid, bgname, bgalias, compcode);
            return ds;


        }
    }
    [Ajax.AjaxMethod]
    //		public DataSet Zonefpnl()
    public DataSet bgfpnl()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.BgColor first = new NewAdbooking.Classes.BgColor();

            ds = first.bgfpnl();
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BgColor first = new NewAdbooking.classesoracle.BgColor();

                ds = first.bgfpnl();
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.BgColor first = new NewAdbooking.classmysql.BgColor();
            ds = first.bgfpnl();
            return ds;

        }


    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //		public DataSet Advdelete(string companycode,string zonecode,string zonename,string alias,string UserId)
    public void bgdelete(string bgid,string ip)
    {
        DataSet ds = new DataSet();
        string err = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BgColor bgdel = new NewAdbooking.Classes.BgColor();

                ds = bgdel.bgdelete(bgid);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {

                    NewAdbooking.classesoracle.BgColor bgdel = new NewAdbooking.classesoracle.BgColor();

                    ds = bgdel.bgdelete(bgid);
                }
                else
                {
                    NewAdbooking.classmysql.BgColor bgdel = new NewAdbooking.classmysql.BgColor();
                    ds = bgdel.bgdelete(bgid);


                }

        }
        catch (Exception e)
        {
            err = e.Message;
        }
        string bgid3 = "Deleted BgColor " + bgid;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["UserId"] + "','BgColor','" + err.Replace("'", "''") + "','BgColor Deleted','" + bgid3;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
        //return ds;
    }
    [Ajax.AjaxMethod]
    /*new change ankur 9 feb*/
    public DataSet bgdauto(string str,string pub,string edit,string cat,string coltype )
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.BgColor chk = new NewAdbooking.Classes.BgColor();
            /*new change ankur 9 feb */
            ds = chk.bgdauto(str, pub,edit,cat,coltype);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BgColor chk = new NewAdbooking.classesoracle.BgColor();

                ds = chk.bgdauto(str, pub, edit, cat, coltype);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.BgColor chk = new NewAdbooking.classmysql.BgColor();
            ds = chk.bgdauto(str, pub, edit, cat, coltype);
            return ds;
            }

    }
    [Ajax.AjaxMethod]
    //		public DataSet Advexecute1(string companycode,string zonecode,string zonename,string alias,string UserId)
    public DataSet bgexecute2(string bgid, string bgname, string bgalias)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.BgColor bgexe1 = new NewAdbooking.Classes.BgColor();
       
        ds = bgexe1.bgexecute2(bgid, bgname, bgalias);
        return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BgColor bgexe1 = new NewAdbooking.classesoracle.BgColor();

                ds = bgexe1.bgexecute2(bgid, bgname, bgalias);
                return ds;
            }

        else
        {
            NewAdbooking.classmysql.BgColor bgexe1 = new NewAdbooking.classmysql.BgColor();
            ds = bgexe1.bgexecute2(bgid, bgname, bgalias);
            return ds;



        }
    }

    /*new change ankur*/
    [Ajax.AjaxMethod]
    public DataSet addedition(string pubname)
    {
        DataSet ds = new DataSet();

        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        

            NewAdbooking.Classes.SupplimentMaster chkv = new NewAdbooking.Classes.SupplimentMaster();

            ds = chkv.addedition(pubname);
            return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
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


    ////////////  for cat1   ///////////////////////////////////////////////////////
    [Ajax.AjaxMethod]
    public DataSet fillCat2(string cat1, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BgColor category = new NewAdbooking.Classes.BgColor();

            ds = category.addcategoryname2(cat1, compcode);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BgColor category = new NewAdbooking.classesoracle.BgColor();

            ds = category.addcategoryname2(cat1, compcode);
        }
        else
        {
            NewAdbooking.classmysql.BgColor category = new NewAdbooking.classmysql.BgColor();
            ds = category.addcategoryname2(cat1, compcode);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillCat3(string cat1)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BgColor category = new NewAdbooking.Classes.BgColor();

            ds = category.addcategoryname3(cat1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BgColor category = new NewAdbooking.classesoracle.BgColor();

            ds = category.addcategoryname3(cat1);
        }
        else
        {
            NewAdbooking.classmysql.BgColor category = new NewAdbooking.classmysql.BgColor();
            ds = category.addcategoryname3(cat1);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fillCat4(string adscat4, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BgColor category = new NewAdbooking.Classes.BgColor();

            ds = category.bindscategory4(adscat4, "1", compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BgColor category = new NewAdbooking.classesoracle.BgColor();

            ds = category.bindscategory4(adscat4, "1", compcode);
        }
        else
        {
            NewAdbooking.classmysql.BgColor category = new NewAdbooking.classmysql.BgColor();
            ds = category.bindscategory4(adscat4, "1", compcode);
        }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet fillCat5(string adscat5, string value)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BgColor category = new NewAdbooking.Classes.BgColor();

            ds = category.bindscategory5(adscat5, "2", value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BgColor category = new NewAdbooking.classesoracle.BgColor();

            ds = category.bindscategory5(adscat5, "2", value);
        }
        else
        {
            NewAdbooking.classmysql.BgColor category = new NewAdbooking.classmysql.BgColor();
            ds = category.bindscategory5(adscat5, "2", value);
        }
        return ds;
    }
}
