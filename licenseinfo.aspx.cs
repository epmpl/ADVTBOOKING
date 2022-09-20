using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
public partial class licenseinfo : System.Web.UI.Page
{
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        fetchLicenseInfo();
    }
    public static string DecryptString(string Message)
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
    private void fetchLicenseInfo()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.licenseinfo logindetail = new NewAdbooking.Classes.licenseinfo();
            ds = logindetail.fetchLicenseInfo();
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.licenseinfo logindetail = new NewAdbooking.classesoracle.licenseinfo();
                ds = logindetail.fetchLicenseInfo();
            }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string str = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != "")
                {
                    str = str + "<hr style='margin-right:25px;margin-left:20px;margin-top:20px;margin-bottom:20px;height:1px;' color='#7DAAE5' />";
                }
                str = str + "<table bordercolor='#7DAAE5' cellpadding='0' cellspacing='0' border=1 width=100%><tr bgcolor='#a1c0ee'><td class='TextField'>Company Name</td><td  class='TextField'>Valid UpTo</td><td  class='TextField'>Concurrent Users</td><td class='TextField'>Last Key Updated</td><td class='TextField'>Last Key Updated By</td></tr>";
               
                string compname = "";
                string validupto = "";
                string concurrentusers = "";
              //  if (ds.Tables[0].Rows[i].ItemArray[0].ToString() != "" && ds.Tables[0].Rows[i].ItemArray[0].ToString() != "null" && ds.Tables[0].Rows[i].ItemArray[0].ToString() != null)
                if (ds.Tables[0].Rows[i].ItemArray[3].ToString() != "" && ds.Tables[0].Rows[i].ItemArray[3].ToString() != "null" && ds.Tables[0].Rows[i].ItemArray[3].ToString() != null)
                {
                    string[] arr;
                    arr = DecryptString(ds.Tables[0].Rows[i].ItemArray[3].ToString()).Split("~".ToCharArray());
                    if (arr.Length == 3)
                        {
                        concurrentusers = arr[0].ToString();
                        validupto = arr[1].ToString();
                        compname = arr[2].ToString();
                    }
                }
                str = str + "<tr><td class='TextField'>" + compname + "</td><td class='TextField'>" + validupto + "</td><td class='TextField'>" + concurrentusers + "</td><td class='TextField'>" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td><td class='TextField'>" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>";
                str = str + "</table>";
            }
            div1.InnerHtml = str;
        }
    }
}
