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

public partial class EncryptPassword : System.Web.UI.Page
{
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(EncryptPassword));


        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/EncryptPassword.xml"));
        EncryptPass.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        DecryptPass.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
    }

    private string EncryptData(string Message)
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

   

    protected void EncryptPassword_click(object sender, System.EventArgs e)
        {
            int i;
        DataSet dz = new DataSet();
        DataSet du = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EncryptPassword checkform = new NewAdbooking.classesoracle.EncryptPassword();

            dz = checkform.encrypt();

        }
        else
        {

            NewAdbooking.Classes.EncryptPassword checkform = new NewAdbooking.Classes.EncryptPassword();
            dz = checkform.encrypt();
        }
        for (i = 0; i < dz.Tables[0].Rows.Count; i++)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.EncryptPassword checkform = new NewAdbooking.classesoracle.EncryptPassword();

                string pwd = EncryptData(dz.Tables[0].Rows[i]["password"].ToString());
                du = checkform.update(dz.Tables[0].Rows[i]["COM_CODE"].ToString(), dz.Tables[0].Rows[i]["userid"].ToString(), pwd);

            }
            else
            {
                NewAdbooking.Classes.EncryptPassword checkform = new NewAdbooking.Classes.EncryptPassword();

                string pwd = EncryptData(dz.Tables[0].Rows[i]["password"].ToString());
                if (dz.Tables[0].Rows[i]["password"].ToString() == "123")
                    du = checkform.update(dz.Tables[0].Rows[i]["COM_CODE"].ToString(), dz.Tables[0].Rows[i]["userid"].ToString(), pwd);

            }





        }






        

    }

    protected void DecryptPassword_click(object sender, System.EventArgs e)
    {
        int i;
        DataSet dz = new DataSet();
        DataSet du = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EncryptPassword checkform = new NewAdbooking.classesoracle.EncryptPassword();

            dz = checkform.encrypt();

        }
        else
        {

            NewAdbooking.Classes.EncryptPassword checkform = new NewAdbooking.Classes.EncryptPassword();
            dz = checkform.encrypt();
        }
        for (i = 0; i < dz.Tables[0].Rows.Count; i++)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.EncryptPassword checkform = new NewAdbooking.classesoracle.EncryptPassword();

                string pwd = DecryptString(dz.Tables[0].Rows[i]["password"].ToString());
                du = checkform.update(dz.Tables[0].Rows[i]["COM_CODE"].ToString(), dz.Tables[0].Rows[i]["userid"].ToString(), pwd);

            }
            else
            {
                NewAdbooking.Classes.EncryptPassword checkform = new NewAdbooking.Classes.EncryptPassword();

                string pwd = DecryptString(dz.Tables[0].Rows[i]["password"].ToString());
                //if (dz.Tables[0].Rows[i]["password"].ToString()=="123")
                du = checkform.update(dz.Tables[0].Rows[i]["COM_CODE"].ToString(), dz.Tables[0].Rows[i]["userid"].ToString(), pwd);

            }





        }


    }



  




}
