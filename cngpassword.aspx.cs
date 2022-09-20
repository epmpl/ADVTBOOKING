using System.Security.Cryptography;
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
public partial class cngpassword : System.Web.UI.Page
{
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsctlLable = new DataSet();
        dsctlLable.ReadXml(Server.MapPath("XML/cngpassword.xml"));
        lbusername.Text = dsctlLable.Tables[0].Rows[0].ItemArray[0].ToString();
        lboldpwd.Text = dsctlLable.Tables[0].Rows[0].ItemArray[1].ToString();
        lbnewpwd.Text = dsctlLable.Tables[0].Rows[0].ItemArray[2].ToString();
        lbconfpwd.Text = dsctlLable.Tables[0].Rows[0].ItemArray[3].ToString();
        txtoldpwd.Focus();
        if (!IsPostBack)
        {
            binduser();
            txtusername.Text = Session["Username"].ToString();
            btnsubmit.Attributes.Add("onclick", "javascript:return chksubmit()");
            Ajax.Utility.RegisterTypeForAjax(typeof(cngpassword));
        }
       
    }




   

    private void binduser()
    {
        DataSet ds;
        drpusername.Items.Clear();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.getupuser();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
            ds = logindetail.getupuser();
        }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.getupuser();
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Center";
        li1.Value = "0";
        li1.Selected = true;
        drpusername.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpusername.Items.Add(li);
        }
    }
    
    protected string EncryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return Convert.ToBase64String(Results);
    }



    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string DecryptString(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToDecrypt = Convert.FromBase64String(Message);
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return UTF8.GetString(Results);
    }




    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet chkpwd(string pwd, string name)
    {
        string pwd1 = "";
        DataSet ds = new DataSet();
       pwd = EncryptData(pwd);

        //pwd1 = DecryptString(pwd);

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.chkpwd(pwd, Session["Userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
          //  ds = logindetail.chkpwd(name, pwd,Session["compcode"].ToString());
            ds = logindetail.chkpwd(pwd, Session["Userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.chkpwd(name, pwd, Session["compcode"].ToString());
        }
        return ds;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet cngpwd(string name, string user_id)
    {
        DataSet ds = new DataSet();
        string pwd = EncryptData(name);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.login logindetail = new NewAdbooking.Classes.login();
            ds = logindetail.cngpwd(pwd, Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.login logindetail = new NewAdbooking.classesoracle.login();
            //ds = logindetail.cngpwd(name, pwd, Session["compcode"].ToString());
            ds = logindetail.cngpwd(pwd, Session["userid"].ToString(), Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.login logindetail = new NewAdbooking.classmysql.login();
            ds = logindetail.cngpwd(pwd, user_id, Session["compcode"].ToString());
        }
        return ds;
    }


    

}