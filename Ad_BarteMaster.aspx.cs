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

public partial class Ad_BarteMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /// Put user code to initialize the page here

        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenauto.Value = Session["autogenerated"].ToString();
        }
       else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;

        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Ad_BarteMaster));
        
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

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Ad_Barter.xml"));
           
        lbunit.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbbranchname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblbartercode.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblbartername.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblbarterstdt.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbbarterendt.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lblprodamt.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblbarteramt.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblbarterarea.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblbarterremark.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lblproddesc.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        lbluom.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        lbbarterkilldt.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lblstrbank.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();

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
       
        if (!Page.IsPostBack)
        {
            adduom();
            fillPubCenter();
            txtbarterendt.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtbarterstdt.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtbarterkilldt.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            lstagency.Attributes.Add("OnClick", "javascript:return fillVal();");
            lstclient.Attributes.Add("OnClick", "javascript:return fillVal();");
            drpunit.Attributes.Add("OnChange", "javascript:return bindBranch(this);");
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnModify.Attributes.Add("onClick", "javascript:return modifyclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return clearclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnExecute.Attributes.Add("onClick", "javascript:return executeclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return prevclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnDelete.Attributes.Add("onClick", "javascript:return deleteclick();");
            txtbartername.Attributes.Add("OnBlur", "javascript:return autoornot();");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");

            txtprodamt.Attributes.Add("onchange", "javascript:return chkamount('txtprodamt');");
            txtbarteramt.Attributes.Add("onchange", "javascript:return chkamount('txtbarteramt');");
            txtbarterarea.Attributes.Add("onchange", "javascript:return chkamount('txtbarterarea');");
          //txtagency.Attributes.Add("onKeydown", "javascript:return bindagencyname();");
            
            
            
            
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

    public void adduom()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Barter binduom = new NewAdbooking.Classes.Ad_Barter();
            ds = binduom.uombind(Session["compcode"].ToString(),"");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Barter binduom = new NewAdbooking.classesoracle.Ad_Barter();
            ds = binduom.uombind(Session["compcode"].ToString(),"");
        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter binduom = new NewAdbooking.classmysql.Ad_Barter();
            ds = binduom.uombind(Session["compcode"].ToString(), "" /*Session["userid"].ToString()*/);
        }

     
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select UOM--";
        li1.Value = "0";
        li1.Selected = true;
        drpuom.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpuom.Items.Add(li);


        }

    }


    private void fillPubCenter()
    {

        DataSet ds = new DataSet();
        drpunit.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Ad_Barter logindetail = new NewAdbooking.Classes.Ad_Barter();
            ds = logindetail.getPubCenter(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Barter logindetail = new NewAdbooking.classesoracle.Ad_Barter();
            ds = logindetail.getPubCenter(Session["compcode"].ToString());

        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter logindetail = new NewAdbooking.classmysql.Ad_Barter();
            ds = logindetail.getPubCenter(Session["compcode"].ToString());
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drpunit.Items.Add(li1);
        string[] drptext;
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().IndexOf("(") > 0)
            {
                drptext = ds.Tables[0].Rows[i].ItemArray[1].ToString().Split('(');
                li.Text = drptext[0];
            }
            else
            {
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            }
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpunit.Items.Add(li);
        }

    }

    [Ajax.AjaxMethod]
    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds=new DataSet();;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Barter logindetail = new NewAdbooking.Classes.Ad_Barter();
            ds = logindetail.getQBC(pubcenter);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Ad_Barter logindetail = new NewAdbooking.classesoracle.Ad_Barter();
                ds = logindetail.getQBC(pubcenter);
            }
            else
            {
                NewAdbooking.classmysql.Ad_Barter logindetail = new NewAdbooking.classmysql.Ad_Barter();
                ds = logindetail.getQBC(pubcenter);
            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindAgency(string compcode,string agency)
    {
        DataSet ds = new DataSet(); 
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Barter logindetail = new NewAdbooking.Classes.Ad_Barter();
            ds = logindetail.bindagency(compcode, agency);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Barter logindetail = new NewAdbooking.classesoracle.Ad_Barter();
            ds = logindetail.bindagency(compcode, agency);
        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter logindetail = new NewAdbooking.classmysql.Ad_Barter();
            ds = logindetail.bindagency(compcode, agency);
        }
        return ds;
    }
     [Ajax.AjaxMethod]
    public DataSet bartersave(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate, string strbook, string client)
     {
         DataSet ds = new DataSet(); 
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.Ad_Barter bs = new NewAdbooking.classesoracle.Ad_Barter();
             ds = bs.savebarter(compcode, userid, unitcode, branchcode, agencycode, subagencycode, bartercode, barterdesc, barterstdt, barterendt, ProdAmt, barterAmt, barterArea, Remarks, dateformat, productdesc, barteruom, barterkilldate, strbook, client);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.Ad_Barter bs = new NewAdbooking.Classes.Ad_Barter();
             ds = bs.savebarter(compcode, userid, unitcode, branchcode, agencycode, subagencycode, bartercode, barterdesc, barterstdt, barterendt, ProdAmt, barterAmt, barterArea, Remarks, dateformat, productdesc, barteruom, barterkilldate, strbook, client);
         }
         else
         {
             NewAdbooking.classmysql.Ad_Barter bs = new NewAdbooking.classmysql.Ad_Barter();
             ds = bs.savebarter(compcode, userid, unitcode, branchcode, agencycode, subagencycode, bartercode, barterdesc, barterstdt, barterendt, ProdAmt, barterAmt, barterArea, Remarks, dateformat, productdesc, barteruom, barterkilldate, strbook, client);
         }
         return ds;
     }

    
     [Ajax.AjaxMethod]
    public DataSet bartermodify(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate, string strbook, string client)
     {
         DataSet ds = new DataSet(); 
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.Ad_Barter bm = new NewAdbooking.classesoracle.Ad_Barter();
             ds = bm.updatebarter(compcode, userid, unitcode, branchcode, agencycode, subagencycode, bartercode, barterdesc, barterstdt, barterendt, ProdAmt, barterAmt, barterArea, Remarks, dateformat, productdesc, barteruom, barterkilldate, strbook, client);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.Ad_Barter bm = new NewAdbooking.Classes.Ad_Barter();
             ds = bm.updatebarter(compcode, userid, unitcode, branchcode, agencycode, subagencycode, bartercode, barterdesc, barterstdt, barterendt, ProdAmt, barterAmt, barterArea, Remarks, dateformat, productdesc, barteruom, barterkilldate, strbook, client);
         }
         else
         {
             NewAdbooking.classmysql.Ad_Barter bm = new NewAdbooking.classmysql.Ad_Barter();
             ds = bm.updatebarter(compcode, userid, unitcode, branchcode, agencycode, subagencycode, bartercode, barterdesc, barterstdt, barterendt, ProdAmt, barterAmt, barterArea, Remarks, dateformat, productdesc, barteruom, barterkilldate, strbook, client);
         }
         return ds;
     }


         
     [Ajax.AjaxMethod]
     public DataSet checkdupbarter(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string agencycode, string subagencycode)
     {
         DataSet ds = new DataSet(); 
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.Ad_Barter chkb = new NewAdbooking.classesoracle.Ad_Barter();
             ds = chkb.checkdupbarter(compcode, unitcode, branchcode, bartercode, barterdesc, agencycode, subagencycode);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.Ad_Barter chkb = new NewAdbooking.Classes.Ad_Barter();
             ds = chkb.checkdupbarter(compcode, unitcode, branchcode, bartercode, barterdesc, agencycode, subagencycode);
         }
         else
         {
             NewAdbooking.classmysql.Ad_Barter chkb = new NewAdbooking.classmysql.Ad_Barter();
             ds = chkb.checkdupbarter(compcode, unitcode, branchcode, bartercode, barterdesc, agencycode, subagencycode);
         }
         return ds;
     }

     [Ajax.AjaxMethod]
    public DataSet executebarter(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string barterstdt, string barterendt, string barterkilldate, string productdesc, string agencycode, string subagencycode, string strbook, string client)
     {
         DataSet ds = new DataSet(); 
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.Ad_Barter exeb = new NewAdbooking.classesoracle.Ad_Barter();
             ds = exeb.barterexecute(compcode, unitcode, branchcode, bartercode, barterdesc, barterstdt, barterendt, barterkilldate, productdesc, agencycode, subagencycode, strbook, client);
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.Ad_Barter exeb = new NewAdbooking.Classes.Ad_Barter();
             ds = exeb.barterexecute(compcode, unitcode, branchcode, bartercode, barterdesc, barterstdt, barterendt, barterkilldate, productdesc, agencycode, subagencycode, strbook, client);
         }
         else
         {
             NewAdbooking.classmysql.Ad_Barter exeb = new NewAdbooking.classmysql.Ad_Barter();
             ds = exeb.barterexecute(compcode, unitcode, branchcode, bartercode, barterdesc, barterstdt, barterendt, barterkilldate, productdesc, agencycode, subagencycode, strbook, client);
         }
         return ds;
     }

    [Ajax.AjaxMethod]
    public void deletebarter(string bartercode, string compcode)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Barter delbarter = new NewAdbooking.classesoracle.Ad_Barter();
            delbarter.barterdelete(bartercode, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Barter delbarter = new NewAdbooking.Classes.Ad_Barter();
            delbarter.barterdelete(bartercode, compcode);
        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter delbarter = new NewAdbooking.classmysql.Ad_Barter();
            delbarter.barterdelete(bartercode, compcode);
        }
    }

    //barterautocode(str,compcode,unitcode,branchcode
    [Ajax.AjaxMethod]
    public DataSet chkbarterdesc(string str, string compcode, string unitcode, string branchcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ad_Barter chk = new NewAdbooking.Classes.Ad_Barter();
            ds = chk.barterautocode(str, compcode, unitcode, branchcode);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Ad_Barter chk = new NewAdbooking.classesoracle.Ad_Barter();
            ds = chk.barterautocode(str, compcode, unitcode, branchcode);
            return ds;
        }
        else
        {
            NewAdbooking.classmysql.Ad_Barter chk = new NewAdbooking.classmysql.Ad_Barter();
            ds = chk.barterautocode(str, compcode, unitcode, branchcode);
            return ds;
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet bindclientname(string compcode, string client)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster clsbooking = new NewAdbooking.Classes.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
           
                NewAdbooking.classesoracle.BookingMaster clsbooking = new NewAdbooking.classesoracle.BookingMaster();
                ds = clsbooking.getClientName(compcode, client, "0");
           
        }

        else
        {
            NewAdbooking.classmysql.BookingMaster clsbooking = new NewAdbooking.classmysql.BookingMaster();
            ds = clsbooking.getClientName(compcode, client);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public Boolean chkCodeMain(string name, string code, string company)
    {
        DataSet ds = new DataSet();
        bool fag = false;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster prev = new NewAdbooking.classesoracle.BookingMaster();

            ds = prev.getmaincode(name, code, company);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fag = true;
            }
            else
            {
                fag = false;
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster prev = new NewAdbooking.Classes.BookingMaster();

            ds = prev.getmaincode(name, code, company);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fag = true;
            }
            else
            {
                fag = false;
            }
        }
        else
        {
            NewAdbooking.classmysql.BookingMaster prev = new NewAdbooking.classmysql.BookingMaster();

            ds = prev.getmaincode(name, code, company);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fag = true;
            }
            else
            {
                fag = false;
            }
        }
        return fag;
    }
    
}