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

public partial class Adsize_master : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here

        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";





        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        navigation();
        Ajax.Utility.RegisterTypeForAjax(typeof(Adsize_master));
        hiddenusername.Value = Session["Username"].ToString();

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
        //chnages done by gaurav 24 april 09
        DataSet ds = new DataSet();
        // Read in the XML file
        ds.ReadXml(Server.MapPath("XML/adsize.xml"));
        Label12.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            //DataSet dz = new DataSet();
            dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, "Adsize_master");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
           // DataSet dz = new DataSet();
            dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, "Adsize_master");
        }
        else
        {
            NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();
            //DataSet dz = new DataSet();
            dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, "Adsize_master");
        }
        //change over

        if (dz.Tables[0].Rows[0].ItemArray[0].ToString() == "0" || dz.Tables[0].Rows[0].ItemArray[0].ToString() == "8")
        {
            Response.Write("<script>alert('You Are Not Authorised To See This Form');</script>");
            Server.Transfer("EnterPage.aspx");
        }
        else
        {
            string id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            if (id == "1" || id == "9")
            {

                //					btnNew.Enabled=true;
                //					btnQuery.Enabled=false;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;	
                //					hiddenpermission.Value="1";
                btnNew.Enabled = true;


                btnQuery.Enabled = false;
                hiddenpermission.Value = "1";


            }
            if (id == "2" || id == "10")
            {

                //					btnNew.Enabled=false;
                //					btnQuery.Enabled=true;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;
                //					hiddenpermission.Value="2";
                btnNew.Enabled = false;
                hiddenpermission.Value = "2";



            }
            if (id == "3" || id == "11")
            {

                //					btnNew.Enabled=true;
                //					btnQuery.Enabled=true;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;
                //					hiddenpermission.Value="3";
                btnNew.Enabled = true;
                hiddenpermission.Value = "3";

            }
            if (id == "4" || id == "12")
            {

                //					btnNew.Enabled=false;
                //					btnQuery.Enabled=true;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;	
                //					hiddenpermission.Value="4";
                btnNew.Enabled = false;
                btnCancel.Enabled = true;
                btnModify.Enabled = false;

                hiddenpermission.Value = "4";


            }
            if (id == "5" || id == "13")
            {
                btnNew.Enabled = true;
                btnQuery.Enabled = false;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;	
                hiddenpermission.Value = "5";

            }
            if (id == "6" || id == "14")
            {
                //					btnNew.Enabled=false;
                //					btnQuery.Enabled=true;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;	
                //					hiddenpermission.Value="6";
                btnNew.Enabled = false;
                hiddenpermission.Value = "6";


            }
            if (id == "7" || id == "15")
            {
                //					btnNew.Enabled=true;
                //					btnQuery.Enabled=true;
                //					btnDelete.Enabled=false;	
                //					btnSave.Enabled=false;	
                //					btnExecute.Enabled=false;
                //					btnCancel.Enabled=true;
                //					btnModify.Enabled=false;		
                //					
                //					btnfirst.Enabled=false;				
                //					btnnext.Enabled=false;					
                //					btnprevious.Enabled=false;			
                //					btnlast.Enabled=false;			
                //					btnExit.Enabled=true;	
                //
                if (btnNew.Enabled == true)
                {
                    btnNew.Focus();
                }
                hiddenpermission.Value = "7";

            }

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
        if (!Page.IsPostBack)
        {

            //adduom();
            addcolor();
            addtype();
           // addedition();
           // addlistbox();
            btnNew.Attributes.Add("OnClick", "javascript:return newclick();");
            btnSave.Attributes.Add("OnClick", "javascript:return submitclick();");
            txtadvsizecode.Attributes.Add("OnChange", "javascript:return uppercase('txtadvsizecode');");
            txtadvdescription.Attributes.Add("OnChange", "javascript:return uppercase('txtadvdescription');");
            btnExecute.Attributes.Add("OnClick", "javascript:return executeclick();");
            btnModify.Attributes.Add("OnClick", "javascript:return modifyclick();");
            btnfirst.Attributes.Add("OnClick", "javascript:return firstclick();");
            btnlast.Attributes.Add("OnClick", "javascript:return lastclick();");
            btnnext.Attributes.Add("OnClick", "javascript:return nextclick();");
            btnprevious.Attributes.Add("OnClick", "javascript:return prevclick();");
            btnDelete.Attributes.Add("OnClick", "javascript:return deleteclick();");
            btnQuery.Attributes.Add("OnClick", "javascript:return queryclick();");
            btnCancel.Attributes.Add("OnClick", "javascript:return cancelclick('Adsize_master');");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            lbadtype.Attributes.Add("OnClick", "javascript:return popupdisplay();");
            btnmulti.Attributes.Add("OnClick", "javascript:return multiple();");
            txtadvtype.Attributes.Add("OnChange", "javascript:return Bindpackage();");
         
            txtheight1.Attributes.Add("OnChange", "javascript:return chkheight();");
            txtwidth1.Attributes.Add("OnChange", "javascript:return chkwidth();");


        }
    }

    [Ajax.AjaxMethod]
    public DataSet uom_bind(string comp_code, string adtype, string uomdesc)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 pub_cent2 = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub_cent2.uombind(comp_code, adtype, uomdesc);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent2 = new NewAdbooking.Report.Classes.Class1();
            ds = pub_cent2.uombind(comp_code, adtype, uomdesc);

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "GETUOM";
            string[] parameterValueArray = { comp_code, adtype, uomdesc };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet adduomAjax(string compcode,string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = binduom.uombind(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = binduom.uombind(compcode, adtype);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            // DataSet ds = new DataSet();
            ds = binduom.uombind(compcode, adtype);
        }
        return ds;
    }
    public void adduom()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = binduom.uombind(Session["compcode"].ToString(), "");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize binduom = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = binduom.uombind(Session["compcode"].ToString(), "");
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
           // DataSet ds = new DataSet();
            ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        //NewAdbooking.Classes.Adsize binduom = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select UOM--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
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

    public void navigation()
    {
        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnModify.Enabled = false;
        btnDelete.Enabled = false;
        btnQuery.Enabled = true;
        btnExecute.Enabled = true;
        btnCancel.Enabled = true;
        btnfirst.Enabled = true;
        btnprevious.Enabled = true;
        btnnext.Enabled = true;
        btnlast.Enabled = true;
        btnExit.Enabled = true;

    }

    public void addtype()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindtype = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindtype = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.Adsize bindtype = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        //NewAdbooking.Classes.Adsize bindtype = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = bindtype.typebind(Session["compcode"].ToString(), Session["userid"].ToString());

        ListItem li1;

        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        txtadvtype.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            txtadvtype.Items.Add(li);


        }
    }
    [Ajax.AjaxMethod]
    public DataSet addlistbox(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindlistbox = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = bindlistbox.listboxbind(compcode, adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindlistbox = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = bindlistbox.listboxbind(compcode, adtype);
        }
        else
        {
            NewAdbooking.classmysql.Adsize bindlistbox = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = bindlistbox.listboxbind(compcode, adtype);
        }
        //NewAdbooking.Classes.Adsize bindlistbox = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = bindlistbox.listboxbind(Session["compcode"].ToString(), Session["userid"].ToString());
/*================================
    
        ListItem li1;
        //ListItem li2;
        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;

        lbadcategory.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            lbadcategory.Items.Add(li);


        }

    */
        return ds;
    }
    public void addcolor()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindcolor = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = bindcolor.colorbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindcolor = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = bindcolor.colorbind(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.Adsize bindcolor = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = bindcolor.colorbind(Session["compcode"].ToString());
        }
        //NewAdbooking.Classes.Adsize bindcolor = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = bindcolor.colorbind();

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Color--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcolor.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcolor.Items.Add(li);


        }

    }

    public void addedition()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindedition = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindedition = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        else
        {
            NewAdbooking.classmysql.Adsize bindedition = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());

        }
        //NewAdbooking.Classes.Adsize bindedition = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Edition--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpedition.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[1].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            drpedition.Items.Add(li);


        }
    }
    [Ajax.AjaxMethod]
    public DataSet packagebind(string compcode, string adtype)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindedition = new NewAdbooking.Classes.Adsize();
            ds = bindedition.editionbind(compcode, adtype);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize bindedition = new NewAdbooking.classesoracle.Adsize();
            ds = bindedition.editionbind(compcode, adtype);

        }
        else
        {
            NewAdbooking.classmysql.Adsize bindedition = new NewAdbooking.classmysql.Adsize();
            ds = bindedition.editionbind(compcode, adtype);
        }
        return ds;
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

    [Ajax.AjaxMethod]
    public DataSet insertadsize(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string uom, string remarks, string width1, string width2, string height1, string height2, string compcode, string userid,string column)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize insertinto = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = insertinto.inserttinadsize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid,column);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize insertinto = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = insertinto.inserttinadsize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid,column);
        }
        else
        {
            NewAdbooking.classmysql.Adsize insertinto = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = insertinto.inserttinadsize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid, column);
        }

        //NewAdbooking.Classes.Adsize insertinto = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = insertinto.inserttinadsize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid);


        return ds;
}


    [Ajax.AjaxMethod]
    public DataSet checksizecode(string description,string advsizecode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize check = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = check.checkcode(description,advsizecode, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize check = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = check.checkcode(description,advsizecode, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.Adsize check = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = check.checkcode(description, advsizecode, compcode, userid);
        }

        //NewAdbooking.Classes.Adsize check = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = check.checkcode(advsizecode, compcode, userid);


        return ds;


    }

    [Ajax.AjaxMethod]
    public DataSet excutesize(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize excute = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = excute.exceutesearch(advtype, badcategory, edition, advsizecode, description, color, compcode,userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize excute = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = excute.exceutesearch(advtype, badcategory, edition, advsizecode, description, color, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.Adsize excute = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = excute.exceutesearch(advtype, badcategory, edition, advsizecode, description, color, compcode);
        }
        //NewAdbooking.Classes.Adsize excute = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = excute.exceutesearch(advtype, badcategory, edition, advsizecode, description, color, compcode, userid);


        return ds;


    }

    [Ajax.AjaxMethod]
    public DataSet update(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string uom, string remarks, string width1, string width2, string height1, string height2, string compcode, string userid, string column)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize updateinto = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = updateinto.updatesize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid, column);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize updateinto = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = updateinto.updatesize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid, column);

        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "updateintosize_updateintosize_p";
            string[] parameterValueArray = { advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, column };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        //else
        //{
        //    NewAdbooking.classmysql.Adsize updateinto = new NewAdbooking.classmysql.Adsize();
        //    //DataSet ds = new DataSet();
        //    ds = updateinto.updatesize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid, column);

        //}
        //NewAdbooking.Classes.Adsize updateinto = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = updateinto.updatesize(advtype, badcategory, edition, advsizecode, description, color, uom, remarks, width1, width2, height1, height2, compcode, userid);


        return ds;


    }

    [Ajax.AjaxMethod]
    public DataSet searchfirst()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize first = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = first.firstnext();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize first = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = first.firstnext();
        }
        else
        {
            NewAdbooking.classmysql.Adsize first = new NewAdbooking.classmysql.Adsize();
            //DataSet ds = new DataSet();
            ds = first.firstnext();
        }
        //NewAdbooking.Classes.Adsize first = new NewAdbooking.Classes.Adsize();
        //DataSet ds = new DataSet();
        //ds = first.firstnext();


        return ds;


    }

    [Ajax.AjaxMethod]
    public DataSet deletesize(string advsizecode, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize deleteit = new NewAdbooking.Classes.Adsize();
            //DataSet ds = new DataSet();
            ds = deleteit.deletesizead(advsizecode, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize deleteit = new NewAdbooking.classesoracle.Adsize();
            //DataSet ds = new DataSet();
            ds = deleteit.deletesizead(advsizecode, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.Adsize deleteit = new NewAdbooking.classmysql.Adsize();
            ////DataSet ds = new DataSet();
            ds = deleteit.deletesizead(advsizecode, compcode, userid);
        }
            ////NewAdbooking.classmysql.Adsize deleteit = new NewAdbooking.classmysql.Adsize();
        ////DataSet ds = new DataSet();
            ////ds = deleteit.deletesizead(advsizecode, compcode, userid);

        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize first = new NewAdbooking.Classes.Adsize();
            //DataSet da = new DataSet();
            da = first.firstnext();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Adsize first = new NewAdbooking.classesoracle.Adsize();
            //DataSet da = new DataSet();
            da = first.firstnext();
        }
        else
        {
            NewAdbooking.classmysql.Adsize first = new NewAdbooking.classmysql.Adsize();
            ////DataSet da = new DataSet();
            da = first.firstnext();
        }
        //NewAdbooking.Classes.Adsize first = new NewAdbooking.Classes.Adsize();
        ////DataSet da = new DataSet();
        //da = first.firstnext();


        return da;


    }

    [Ajax.AjaxMethod]
    public DataSet submitpermission(string hiddencompcode, string hiddenuserid, string formname)
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            //DataSet dz = new DataSet();
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            //DataSet dz = new DataSet();
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
        }
        else
        {
            NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();
            ////DataSet dz = new DataSet();
            dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
        }
        //NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
        ////DataSet dz = new DataSet();
        //dz = checkform.formpermission(hiddencompcode, hiddenuserid, formname);
        return dz;
    }

    protected void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }


}