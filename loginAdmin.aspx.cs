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

public partial class loginAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/login.xml"));
        lbusername.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lbpwd.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        btnlogin.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();

        
        Ajax.Utility.RegisterTypeForAjax(typeof(loginAdmin));

        if (!Page.IsPostBack)
        {
            btnlogin.Attributes.Add("Onclick", "javascript:return login1();");
            fillUserName();
        }

    }

    protected void fillUserName()
    {
        int i;
        DataSet dsUserName = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql" )
        {
            NewAdbooking.Classes.loginAdmin loginAd = new NewAdbooking.Classes.loginAdmin();
            dsUserName = loginAd.getUserName();
        }
        else
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="orcl")
            {


                NewAdbooking.classesoracle.loginAdmin loginAd = new NewAdbooking.classesoracle.loginAdmin();
                dsUserName = loginAd.getUserName();
            }
        else
        {
            NewAdbooking.classmysql.loginAdmin loginAd = new NewAdbooking.classmysql.loginAdmin();
                 dsUserName = loginAd.getUserName();

        }
        
        drpUser.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select User Name--";
        li1.Value = "0";
        li1.Selected = true;
        drpUser.Items.Add(li1);

        for (i = 0; i < dsUserName.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = dsUserName.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = dsUserName.Tables[0].Rows[i].ItemArray[1].ToString();
            drpUser.Items.Add(li);
        }
    }

    [Ajax.AjaxMethod]
    public DataSet chkLoginAd1(string username, string password)
    {
        DataSet dsChkLogin = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.loginAdmin chkLoginAd = new NewAdbooking.Classes.loginAdmin();
       
        dsChkLogin = chkLoginAd.chklogin(username, password);

        return dsChkLogin;
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.loginAdmin chkLoginAd = new NewAdbooking.classesoracle.loginAdmin();
                dsChkLogin = chkLoginAd.chklogin(username, password);
                return dsChkLogin;
            }
        else
        {
            NewAdbooking.classmysql.loginAdmin chkLoginAd = new NewAdbooking.classmysql.loginAdmin();

            dsChkLogin = chkLoginAd.chklogin(username, password);

            return dsChkLogin;

        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {


        string p = txtpwd.Text;
        string un = drpUser.Text;
        DataSet ds = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {

        NewAdbooking.Classes.loginAdmin lg = new NewAdbooking.Classes.loginAdmin();
        
        ds = lg.chklogin(un, p);        
        }
        else
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="orcl")
            {
                NewAdbooking.classesoracle.loginAdmin lg = new NewAdbooking.classesoracle.loginAdmin();
                ds = lg.chklogin(un, p);  
            }
        else
        {

           NewAdbooking.classmysql.loginAdmin lg = new NewAdbooking.classmysql.loginAdmin();
             
        ds = lg.chklogin(un, p); 
       }
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            Response.Redirect("home.aspx");
        }
        else
        {
            Response.Write("<script> alert('Wrong ID & Password!!!')</script>");
            return;
        }
       
    }
}