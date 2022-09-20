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

public partial class ProductMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenusername.Value = Session["Username"].ToString();


        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        //*************************************XML***************************

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("xml/productmaster.xml"));
        ProductCode.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString() + "<font color=red>* </font>";
        ProductSubCode.Text  = ds.Tables[0].Rows[0].ItemArray[1].ToString() + "<font color=red>* </font>";
        ProductName.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString() + "<font color=red>* </font>";
        Clientname.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString() + "<font color=red>* </font>";


        //This code reads the label name from the xml file
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


        //********************************************************************


        Ajax.Utility.RegisterTypeForAjax(typeof(ProductMaster));
         
        

        navigation();

        if (!Page.IsPostBack)
        {
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('ProductMaster');");
            btnSave.Attributes.Add("OnClick", "javascript:return saveclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return previousclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            txtproductcode.Attributes.Add("OnChange", "javascript:return uppercase('txtproductcode');");
            txtprodsubcode.Attributes.Add("OnChange", "javascript:return uppercase('txtprodsubcode');");
            txtprodname.Attributes.Add("OnChange", "javascript:return uppercase('txtprodname');");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            bindclientname();

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

    [Ajax.AjaxMethod]


    public DataSet chkcode(string txtproductcode, string txtprodsubcode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.productmaster chkprductcode = new NewAdbooking.Classes.productmaster();
            
            ds = chkprductcode.checkcode(txtproductcode, txtprodsubcode, compcode, userid);

            return ds;
        }
        else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.productmaster chkprductcode = new NewAdbooking.classesoracle.productmaster();

                ds = chkprductcode.checkcode(txtproductcode, txtprodsubcode, compcode, userid);

                return ds;
            }
        else
        {
            NewAdbooking.classmysql.productmaster chkprductcode = new NewAdbooking.classmysql.productmaster();

            ds = chkprductcode.checkcode(txtproductcode, txtprodsubcode, compcode, userid);

            return ds;
        }

    }

    [Ajax.AjaxMethod]


    public DataSet save(string txtproductcode, string txtprodsubcode, string txtprodname,string clientname, string compcode, string userid)
    { DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.productmaster savecode = new NewAdbooking.Classes.productmaster();
       
        ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname,clientname, compcode, userid);

        return ds;

        }
        else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.productmaster savecode = new NewAdbooking.classesoracle.productmaster();

                ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;

            }
        else
        {
            NewAdbooking.classmysql.productmaster savecode = new NewAdbooking.classmysql.productmaster();
       
        ds = savecode.saveproduct(txtproductcode, txtprodsubcode, txtprodname,clientname, compcode, userid);

        return ds;
        }

    }

    [Ajax.AjaxMethod]


    public DataSet execute(string txtproductcode, string txtprodsubcode, string txtprodname, string clientname, string compcode, string userid)
    {
                DataSet ds = new DataSet();

        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.productmaster execute = new NewAdbooking.Classes.productmaster();
        ds = execute.executeproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

        return ds;
        }
        else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.productmaster execute = new NewAdbooking.classesoracle.productmaster();
                ds = execute.executeproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;

            }
        else
        {
            NewAdbooking.classmysql.productmaster execute = new NewAdbooking.classmysql.productmaster();
        ds = execute.executeproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

        return ds;
        }

    }

    [Ajax.AjaxMethod]


    public DataSet first()
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.productmaster firstproduct = new NewAdbooking.Classes.productmaster();
        
        ds = firstproduct.firstprodctcode();

        return ds;
        }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.productmaster firstproduct = new NewAdbooking.classesoracle.productmaster();

                ds = firstproduct.firstprodctcode();

                return ds;
            }
            else
            {
                NewAdbooking.classmysql.productmaster firstproduct = new NewAdbooking.classmysql.productmaster();

                ds = firstproduct.firstprodctcode();

                return ds;
            }

    }

    [Ajax.AjaxMethod]


    public DataSet deletevalue(string txtproductcode, string compcode, string userid)
    {
           DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.productmaster deletecode = new NewAdbooking.Classes.productmaster();
     
        ds = deletecode.deleteproduct(txtproductcode, compcode, userid);

        return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                  NewAdbooking.classesoracle.productmaster deletecode = new NewAdbooking.classesoracle.productmaster();
     
        ds = deletecode.deleteproduct(txtproductcode, compcode, userid);

        return ds;
            }


        else
        {
            NewAdbooking.classmysql.productmaster deletecode = new NewAdbooking.classmysql.productmaster();       
        ds = deletecode.deleteproduct(txtproductcode, compcode, userid);
        return ds;
        }

    }

    [Ajax.AjaxMethod]


    public DataSet update(string txtproductcode, string txtprodsubcode, string txtprodname,string clientname, string compcode, string userid)
    {
          DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.productmaster updatecode = new NewAdbooking.Classes.productmaster();
      
        ds = updatecode.updateproduct(txtproductcode, txtprodsubcode, txtprodname,clientname, compcode, userid);

        return ds;
        }
            else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.productmaster updatecode = new NewAdbooking.classesoracle.productmaster();

                ds = updatecode.updateproduct(txtproductcode, txtprodsubcode, txtprodname, clientname, compcode, userid);

                return ds;

            }


        else
        {
            NewAdbooking.classmysql.productmaster updatecode = new NewAdbooking.classmysql.productmaster();
      
        ds = updatecode.updateproduct(txtproductcode, txtprodsubcode, txtprodname,clientname, compcode, userid);

        return ds;
  
        }

    }

    public void navigation()
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

    }
    public void bindclientname()
    {
         DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.productmaster bindclient = new NewAdbooking.Classes.productmaster();
       
        ds = bindclient.bindclientname(Session["compcode"].ToString(),Session["userid"].ToString());
        }

        else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.productmaster bindclient = new NewAdbooking.classesoracle.productmaster();

                ds = bindclient.bindclientname(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.productmaster bindclient = new NewAdbooking.classmysql.productmaster();
   
        ds = bindclient.bindclientname(Session["compcode"].ToString(),Session["userid"].ToString());


        }
        drpclientname.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Client Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpclientname.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                drpclientname.Items.Add(li);
            }

        }

    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
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