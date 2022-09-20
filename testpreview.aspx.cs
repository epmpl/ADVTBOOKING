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

public partial class testpreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // string matter = "<FONT face=Helvetica>This is test ad for HT Classified </FONT><FONT face=HINDBODY>東睢Z東 閻孳FSX<FONT face=Helvetica> <FONT face=Helvetica>t</FONT><FONT face=Helvetica>e</FONT><FONT face=Helvetica>s</FONT><FONT face=Helvetica>t</FONT> -<FONT face=Helvetica>9</FONT><FONT face=Helvetica>8</FONT><FONT face=Helvetica>5</FONT><FONT face=Helvetica>8</FONT></FONT> 東睢Z東 IY睢FSX WX東IY 閻F孳 </FONT><FONT face=Helvetica>-9899845435/ 9899878564. </FONT><FONT face=HINDBODY>東睢Z東 東睢Z東 東睢Z東 睢Z東 e蚌肇Z </FONT><FONT face=Helvetica>test kiya tha.</FONT>";
        string matter="<FONT face=HINDBODY>東睢Z東 <FONT face=HINDBODY>東</FONT><FONT face=HINDBODY>睢</FONT><FONT face=HINDBODY>Z</FONT><FONT face=HINDBODY>東</FONT> <FONT face=HINDBODY>東</FONT><FONT face=HINDBODY>睢</FONT><FONT face=HINDBODY>Z</FONT><FONT face=HINDBODY>東<FONT face=Helvetica>-<FONT face=Helvetica>9</FONT><FONT face=Helvetica>8</FONT><FONT face=Helvetica>7</FONT>1<FONT face=Helvetica>7</FONT><FONT face=Helvetica>2</FONT><FONT face=Helvetica>5</FONT><FONT face=Helvetica>4</FONT><FONT face=Helvetica>0</FONT><FONT face=Helvetica>3</FONT></FONT></FONT></FONT><FONT face=Helvetica></FONT>";
        
        string data=enterSpace(matter);
    }
    public string enterSpace(string matter)
    {
        string data = matter;
        string oldfont = "";
        string curfont = "";
        string newdata = "";
        bool htmlstart = false;
        bool gh = false;
        string trufont = "";
        //data = data.Replace("</FONT>", "").Replace("</font>", "");
        int i = 0;

        for (i = 0; i < data.Length; i++)
        {
            string a;
            if (gh == true)
            {
                gh = false;
                if (trufont != curfont && trufont != "")
                {
                    if (newdata.Substring(newdata.Length - 1) != "}")
                        newdata = newdata + "{" + trufont + "}";
                    trufont = curfont;
                }

            }
            a = data.Substring(i, 1);
            if (a == "<")
            {

                a = data.Substring(i, data.IndexOf(">", i + 1) - i + 1);
                i = i + a.Length - 1;
                if (a.IndexOf("FONT face=") > 0)
                {
                    gh = true;
                    if (a.IndexOf("Helvetica") > 0)
                    {
                        if (curfont == "")
                            curfont = "Helvetica";
                        else
                        {
                            if (oldfont == "")
                                oldfont = curfont;
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "Helvetica";
                        }
                    }
                    else
                    {
                        if (curfont == "")
                            curfont = "HINDBODY";
                        else
                        {
                            if (oldfont == "")
                                oldfont = curfont;
                            else
                                oldfont = oldfont + "," + curfont;
                            curfont = "HINDBODY";
                        }
                    }
                }
                else if (a == "</FONT>")
                {
                    gh = true;
                    if (oldfont != "")
                    {
                        if (oldfont.IndexOf(",") > 0)
                        {
                            curfont = oldfont.Substring(oldfont.LastIndexOf(",") + 1);
                            oldfont = oldfont.Substring(0, oldfont.LastIndexOf(","));
                        }
                        else
                            curfont = oldfont;
                    }
                    else
                        curfont = "";
                }
            }
            else if (a == " ")
            {

                trufont = curfont;
                newdata = newdata + a + "{" + curfont + "}";
            }
            else
                newdata = newdata + a;
        }
        if (newdata.Substring(newdata.Length - 1) != "}")
            newdata = newdata + "{" + curfont + "}";
        return newdata;
    }
}
