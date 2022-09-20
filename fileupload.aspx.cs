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

public partial class fileupload : System.Web.UI.Page
{
    string selectid;
    
    string temp_id;
    static int newid = 1;   
    protected void Page_Load(object sender, EventArgs e)
    {
        selectmargin.Attributes.Add("onclick", "javascript:toggle()");
        insimage.Value = ConfigurationManager.AppSettings["imagepath"].ToString();
       // fit_t_bx.Attributes.Add("onclick", "var fittobox = 0; if(document.getElementById('fit_t_bx').checked){fittobox=1;} else{fittobox=0;} alert(fittobox);");
        selectid = Request.QueryString["currentid"].ToString();
        hidctrl.Value = selectid;
        temp_id = Request.QueryString["temp_id"].ToString();  
    }
    protected void okupload_ServerClick(object sender, EventArgs e)
    {
            string fittobox = "0";
            char[] c ={ '\\' };
            string val = insertimage.Value.ToString();
            string alttxt = "";
            string imgbdr = imgbrdr.Value;
            string imgtop = top.Value;
            string imgleft = left.Value;
            string imgrght = rght.Value;
            string imgbtm = btm.Value;
            if (fit_t_bx.Checked)
            {
                fittobox = "1";
            }
            string[] abcd = val.Split(c);
            string an = "";
            string len = abcd.Length.ToString();
            for (int r = 0; r <= abcd.Length - 1; r++)
            {
                if (an == "")
                {
                    an = abcd[r];
                }
                else
                {
                    an = an + "+" + abcd[r];
                }
            }
            string path = Server.MapPath("");
            string[] path1 = path.Split(c);
            string sevpath = "";
            for (int s = 0; s <= path1.Length - 1; s++)
            {
                if (sevpath == "")
                {
                    sevpath = path1[s];
                }
                else
                {
                    sevpath = sevpath + "+" + path1[s];
                }
            }
            string[] strsql = val.Split('.');
            string foldername = "images1/";
            string strFilename1 = "Image" + newid + "-" + temp_id + "." + strsql[1];
            string strfilename2 = foldername + strFilename1;
            string strfilename3 = "\\\\192.168.1.207\\" + Server.MapPath("") + ("/") + foldername + "//" + strFilename1;
            string strfilename4 = strfilename3.Replace(":", "$");
            if(System.IO.File.Exists(strfilename3) == true)
            {
                newid++;
                strFilename1 = "Image" + newid + "-" + temp_id + "." + strsql[1];
                strfilename2 = foldername + strFilename1;
                strfilename3 = "\\\\192.168.1.207\\" + Server.MapPath("") + ("/") + foldername + "//" + strFilename1;
                strfilename4 = strfilename3.Replace(":", "$");
            }
            insertimage.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);
            string newimg = Server.MapPath("") + ("/") + foldername + "//" + strFilename1;
            string abc = Server.MapPath("") + ("/") + foldername + "//" + strFilename1;
            string[] abc1 = abc.Split(c);

            string an1 = "";
            string len1 = abc1.Length.ToString();
            for (int r = 0; r <= abc1.Length - 1; r++)
            {
                if (an1 == "")
                {
                    an1 = abc1[r];
                }
                else
                {
                    an1 = an1 + "+" + abc1[r];
                }
            }

            string pathh = Server.MapPath("");
            string[] pathh1 = path.Split(c);
            string sevpath1 = "";
            for(int s = 0; s <= pathh1.Length - 1; s++)
            {
                if (sevpath1 == "")
                {
                    sevpath1 = pathh1[s];
                }
                else
                {
                    sevpath1 = sevpath1 + "+" + pathh1[s];
                }
            }

            newid++;
            ScriptManager.RegisterClientScriptBlock(this, typeof(fileupload), "as", "insertimg('" + selectid + "," + an1 + "," + abcd.Length + "," + abc + "," + alttxt + "," + imgbtm + "," + imgbdr + "," + imgtop + "," + imgleft + "," + imgrght + "," + fittobox + "','" + foldername + "','" + strFilename1 + "','" + insimage.Value + "');", true);
           
        }
   


   
}
