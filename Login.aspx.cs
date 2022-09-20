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
using System.Management;
using System.Text;
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ManagementScope theScope = new ManagementScope("\\\\192.168.5.21\\root\\cimv2");
        //StringBuilder theQueryBuilder = new StringBuilder();
        //theQueryBuilder.Append("SELECT MACAddress FROM Win32_NetworkAdapter");
        //ObjectQuery theQuery = new ObjectQuery(theQueryBuilder.ToString());
        //ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
        //ManagementObjectCollection theCollectionOfResults = theSearcher.Get();

        //foreach (ManagementObject theCurrentObject in theCollectionOfResults)
        //{
        //    if (theCurrentObject["MACAddress"] != null)
        //    {

        //        string macAdd = "MAC Address: " + theCurrentObject["MACAddress"].ToString();
        //        Response.Write(macAdd);
        //    }
        //}
        //Response.End();
        //ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //ManagementObjectCollection objMOC = objMC.GetInstances();

        //foreach (ManagementObject objMO in objMOC)
        //{
        //    if (!(bool)objMO["ipEnabled"])
        //        continue;

        //    Response.Write((string)objMO["MACAddress"]);
        //}

        //ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
        //ManagementObjectCollection queryCollection = query.Get();
        //foreach (ManagementObject mo in queryCollection)
        //{
        //    if (!(bool)mo["ipEnabled"])
        //       continue;

        //  Response.Write((string)mo["MACAddress"]);
        //}
        //Response.End();
        DataSet objDataSet = new DataSet();
        //NewAdbooking.classesoracle.MyDelegate DEL = new NewAdbooking.classesoracle.MyDelegate(NewAdbooking.classesoracle.login.Add);
        // int z = DEL(10, 10);
        // Read in the XML file
        //cnter.Value = "";
        if (ConfigurationSettings.AppSettings["CLIENTNAME"].ToString() == "DJ")
        {
            Response.Redirect("loginDJ.aspx");
        }

        objDataSet.ReadXml(Server.MapPath("XML/login.xml"));
        lblcenter.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblqbc.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lbusername.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lbpassword.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        //btnlogin.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        /*new change ankur 28 feb*/
        lbagency.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        rbcomp.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        rbagency.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(login));

        hiddenmysql.Value = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
        hiddendepo.Value = ConfigurationSettings.AppSettings["center"].ToString();
        hiddenshowrdbtn.Value = ConfigurationSettings.AppSettings["showloginrdbtn"].ToString();
        if (!Page.IsPostBack)
        {


            Ajax.Utility.RegisterTypeForAjax(typeof(login));
            /*new change ankur 28 feb*/

            if (ConfigurationSettings.AppSettings["center"].ToString() == "depo")
            {
                //bindagencyfordepo();
            }
            else
            {
                bindagencydrp();
            }
            if (ConfigurationSettings.AppSettings["center"].ToString() != "depo")
            {
                txtusername.Attributes.Add("OnBlur", "javascript:return filldetail();");
            }
            else
            {
                drpagency.Attributes.Add("onchange", "filluserasagency();");
                drpagency.Attributes.Add("onkeydown", "javascript:return agencyf2(event);");
                lstagency.Attributes.Add("onclick", "javascript:return Fillagency(event);");
                lstagency.Attributes.Add("onkeydown", "javascript:return Fillagency(event);");
            }
            rbagency.Attributes.Add("onclick", "javascript:return chkagencyorcomp('rbagency');");
            rbcomp.Attributes.Add("onclick", "javascript:return chkagencyorcomp('rbcomp');");
            ///////////////////////////////
            drpcenter.Attributes.Add("OnChange", "javascript:return bindQBC();");
            btnlogin.Attributes.Add("Onclick", "javascript:return login1();");
            drpqbc.Attributes.Add("OnChange", "javascript:return bindUser();");

            imglogo.Src = "Images/" + ConfigurationManager.AppSettings["logoimg"].ToString();
            imglogo.Width = Convert.ToInt32(ConfigurationManager.AppSettings["logoimgwidth"].ToString());

        }
        fillPubCenter();
        //UserLabel.Value = Session["Username"].ToString();
    }



    private void fillPubCenter()
    {
        DataSet ds;
        drpcenter.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();

            ds = logindetail.getPubCenter();
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getPubCenter();
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getPubCenter();
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drpcenter.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpcenter.Items.Add(li);
        }

    }
    [Ajax.AjaxMethod]
    public DataSet fillUser(string qbc)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getUser(qbc);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getUser(qbc);

            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getUser(qbc);

            }
        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet chkTempData()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login objtempdetail = new NewAdbooking.Classes.login();
            ds = objtempdetail.clsGetTempData();
            //return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login objtempdetail = new NewAdbooking.classesoracle.login();
                ds = objtempdetail.clsGetTempData();
                // return ds;
            }

            else
            {
               NewAdbooking.classmysql.login objtempdetail = new NewAdbooking.classmysql.login();
               ds = objtempdetail.clsGetTempData();

            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet chkBookingTable(string compcode, string cio_bookingid, string insnum, string edition)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login objBookingTable = new NewAdbooking.Classes.login();
            ds = objBookingTable.clschkBookingTable(compcode, cio_bookingid, insnum, edition);
            //return ds;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
            NewAdbooking.classesoracle.login objBookingTable = new NewAdbooking.classesoracle.login();
            ds = objBookingTable.clschkBookingTable(compcode, cio_bookingid, insnum, edition);
            //return ds;
        }
    return ds;
        //else
        //{
        //    NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
        //    ds = logindetail.getUser(qbc);

        //} 
    }

    [Ajax.AjaxMethod]
    public void InsertintoBookingTable(string compcode, string cio_bookingid, string insnum, string edition)
    {

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login objInsertintoBookingTable = new NewAdbooking.Classes.login();
            objInsertintoBookingTable.clsInsertintoBookingTable(compcode, cio_bookingid, insnum, edition);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login objInsertintoBookingTable = new NewAdbooking.classesoracle.login();
            objInsertintoBookingTable.clsInsertintoBookingTable(compcode, cio_bookingid, insnum, edition);
        }
        //else
        //{
        //    NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
        //    logindetail.getUser(qbc);

        //} 
    }

    [Ajax.AjaxMethod]
    public void deletetempbooking()
    {

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.login objdeletetempbooking = new NewAdbooking.Classes.login();
                objdeletetempbooking.clsdeletetempbooking();
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login objdeletetempbooking = new NewAdbooking.classesoracle.login();
                objdeletetempbooking.clsdeletetempbooking();
            }
        //else
        //{
        //    NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
        //    logindetail.getUser(qbc);

        //} 
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void saveLoginInfo(string ip)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds=logindetail.saveLoginInfo(Session["compcode"].ToString(),Session["userid"].ToString(),ip,"INSERT","");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
               ds = logindetail.saveLoginInfo(Session["compcode"].ToString(), Session["userid"].ToString(), ip, "INSERT","");
            }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Session["SESSIONID"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
           
    }
    [Ajax.AjaxMethod]
    public DataSet fillQBC(string pubcenter)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getQBC(pubcenter);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getQBC(pubcenter);
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getQBC(pubcenter);
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getuser_agency(string code_agency)
    {
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login useragency = new NewAdbooking.Classes.login();
            ds = useragency.getuser_login(code_agency);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login useragency = new NewAdbooking.classesoracle.login();
                ds = useragency.getuser_login(code_agency);
            }
            else
            {
                NewAdbooking.classmysql.login useragency = new NewAdbooking.classmysql.login();
                ds = useragency.getuser_login(code_agency);
            }
        return ds;

    }


    public void bindagencydrp()
    {
        DataSet ds;
       // drpagency.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getPubCenter();
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getPubCenter();
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getPubCenter();
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Agency";
        li1.Value = "0";
        li1.Selected = true;
       // drpagency.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[1].Rows[i].ItemArray[1].ToString();
           // drpagency.Items.Add(li);
        }

    }

    public void bindagencyfordepo()
    {
        DataSet ds;
        //drpagency.Items.Clear();
        DataSet dsagencyxml = new DataSet();
        dsagencyxml.ReadXml(Server.MapPath("XML/agency.xml"));
        int countrows = dsagencyxml.Tables[0].Columns.Count;

        string[] agency1arr = dsagencyxml.Tables[0].Rows[0].ItemArray[0].ToString().Split(',');
        string agency1 = agency1arr[0];
        if (agency1 != "all")
        {
            agency1 = agency1arr[0];
        }
        for (int arrcount = 1; arrcount < agency1arr.Length; arrcount++)
        {
            agency1 += "'" + "," + "'" + agency1arr[arrcount];
        }

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getPubCenterlogin(agency1);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getPubCenterlogin(agency1);
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getPubCenterlogin(agency1);
            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Agency";
        li1.Value = "0";
        li1.Selected = true;
       // drpagency.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
           // drpagency.Items.Add(li);
        }


    }
    [Ajax.AjaxMethod]
    public DataSet getBranch(string username)
    {
        string[] parameterValueArray = new string[] { username };
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "getBranchLogin";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "getBranchLogin";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "getBranchLogin";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet agencyfordepo(string agency)
    {
        DataSet ds;

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getPubCenterlogin(agency);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
                ds = logindetail.getPubCenterlogin(agency);
            }
            else
            {
                NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
                ds = logindetail.getPubCenterlogin(agency);
            }

        return ds;

    }
}
