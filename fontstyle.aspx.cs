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

public partial class fontstyle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btn1.Attributes.Add("OnClick", "javascript:return prev1();");
        td1.InnerHtml = "<FONT face=Arial><FONT face=Verdana>Passport</FONT> Facilities of <FONT face=Verdana>Name/Address</FONT>change tatkal sewa Renewal <FONT face=Verdana>ECNR</FONT> PCC at your door step. Rajeev #9871735403<FONT face=Bhaskar> ß’Œ’ß</FONT>test</FONT>";
        string data = td1.InnerHtml;
        string finaldata = "";
        string fontname = "";
        string fontDefault = "";
       // int index = td1.InnerHtml.IndexOf("<font ");
       
           
            while (data.IndexOf("<FONT ") >= 0 || data.Length>0)
            {
                int index = data.IndexOf("<FONT ");
                int index1;
                int index2;
                
                
                if (index == 0)
                {
                    index1 = data.IndexOf("<FONT face=");
                    index2 = data.IndexOf(">");
                     fontname = data.Substring(index1, index2 - index1);
                    fontname = fontname.Replace("<FONT face=", "");
                    data = data.Substring(index2 + 1, data.Length - (index2+1));
                    if (fontDefault == "")
                    {
                        fontDefault = fontname;
                    }
                }
                else
                {
                   // index1 = data.IndexOf("<FONT face=");
                   // index2 = data.IndexOf(">");
                   // string fontname = data.Substring(index1, index2 - index1);
                  //  fontname = fontname.Replace("<FONT face=", "");
                   
                   // data = data.Substring(index2 + 1, data.Length - (index2+1));
                    int index3 = data.IndexOf("</FONT>");
                    int index4 = data.IndexOf("<FONT face=");
                    string tempdata ="";
                   
                    if (index3 < index4)
                    {
                        tempdata = data.Substring(0, index3);
                       // fontname = "";
                        
                    }
                    else {
                        if (index4 == -1)
                        {
                            index4 = index3;
                        }
                        tempdata = data.Substring(0, index4);
                    }
                    if (fontname == "")
                    {
                        fontname = fontDefault;
                    }
                    string[] arr;
                    
                   // arr = tempdata.ToString().Split(" ");
                    arr=tempdata.Split(" ".ToCharArray());
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] != "")
                        {
                            if (finaldata != "")
                            {
                                finaldata = finaldata + " " + arr[i].ToString() + "{" + fontname + "}";
                            }
                            else
                            {
                                finaldata = finaldata  + arr[i].ToString() + "{" + fontname + "}";
                            }
                        }
                    }
                    //finaldata = finaldata + data.Substring(0, data.IndexOf("<FONT face="));
                    
                    index = data.IndexOf("</FONT>");
                    int len = 0;
                    if (index == 0)
                    {
                        len = 7;
                        fontname = "";
                    }
                    data = data.Substring(tempdata.Length + len, data.Length - (tempdata.Length+len));
                }
            }
    }
    protected void btn1_Click(object sender, EventArgs e)
    {

        //string data = "<FONT face=Verdana>Passport</FONT> Facilities of <FONT face=Verdana>Name/     </FONT>change tatkal sewa Renewal <FONT face=Verdana>ECNR</FONT> PCC at your door step. Rajeev #9871735403<FONT face=Bhaskar> ß’Œ’ß</FONT>";
        //string[] arr;
        //arr = data.Split("<font");

    }
}
