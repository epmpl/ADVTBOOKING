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

public partial class saveImageBooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ciobookid = "";
        if(Request.QueryString["cioid"]!=null)
        {
            ciobookid = Request.QueryString["cioid"].ToString();
        }
        if (Session["imgname"] != null)
        {
            string filename = Session["imgname"].ToString();
            char[] splitimg = { '+' };
            string[] array = filename.Split(splitimg);

            /////////////this is to attach the name file
            string insertname = Session["insertname"].ToString();
            char[] splitins ={ '/' };
            string[] array1 = insertname.Split(splitins);
            string savename = "";

            for (int z = 0; z <= array.Length - 1; z++)
            {
                if (array[z] != "")
                {
                    //char[] split ={ '.' };
                    //string[] arraypoint = array[z].Split(split); 
                    string str2 = array[z];
                    int ind = str2.LastIndexOf(".");
                    int len = (str2.Length) - ind;
                    string tot = str2.Substring(ind, len);

                    if (array[z] != null && array[z] != "undefined")
                    {
                        savename = array[z];

                        if (!System.IO.Directory.Exists(Server.MapPath("Orignal/" + ciobookid)))
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("Orignal/" + ciobookid));
                        }

                        if (System.IO.Directory.Exists(Server.MapPath("Temp/")))
                        {
                            System.IO.File.Copy(Server.MapPath("Temp/" + array[z]), Server.MapPath("Orignal/" + ciobookid + "/" + array[z]), true);

                            System.IO.File.Move(Server.MapPath("Orignal/" + ciobookid + "/" + array[z]), Server.MapPath("Orignal/" + ciobookid + "/" + ciobookid + "-" + array1[z] + tot));

                            System.IO.File.Delete(Server.MapPath("Temp/" + array[z]));
                        }

                    }
                }

            }


        }

        Session["imgname"] = null;
        Session["Tempimgname"] = null;
        Session["insertname"] = null;
        Session["Tempinsertname"] = null;
    }
}
