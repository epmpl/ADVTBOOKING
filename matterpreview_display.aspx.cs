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
using System.Drawing;
using System.IO;

    public partial class matterpreview_display : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";

            
            hiddenfilename.Value = Request.QueryString["f_name"].ToString();
            
            hiddenbheight.Value = Request.QueryString["bheight"].ToString();
            hiddenbwidth.Value = Request.QueryString["bwidth"].ToString();
            hiddenpheight.Value = Request.QueryString["pheight"].ToString();
            hiddenpwidth.Value = Request.QueryString["pwidth"].ToString();
            int wd = Convert.ToInt32((Convert.ToDouble(hiddenpwidth.Value) * 72) / 2.54);
            int ht = Convert.ToInt32((Convert.ToDouble(hiddenpheight.Value) * 72) / 2.54);
            if (!Page.IsPostBack)
            {
                // btnRefresh.Attributes.Add("OnClick", "javascript:return drawPageforPrint();");

            }

            Ajax.Utility.RegisterTypeForAjax(typeof(matterpreview_display));

            string p2 = Server.MapPath("/webdir/");
            string p1 = Server.MapPath("/webdir/Temppdf/");
            string StrJPGPath = Server.MapPath("/webdir/jpgPreview/");//ConfigurationSettings.AppSettings["JPGfilepath"].ToString();  //Server.MapPath("/webdir/jpgPreview/");
           
            // string ff = "D:\\finalserver\\addummy\\adpictures\\pictures\\jpg\\" + hiddenfilename.Value + ".jpg";
            string ff = StrJPGPath + hiddenfilename.Value + ".jpg";
            div1.InnerHtml = "<img src='" + ff + "' width=" + Convert.ToString(wd) + " height=" + Convert.ToString(ht) + "/>";
            Label3.Text = hiddenpheight.Value;
            Label4.Text = hiddenpwidth.Value;

        }

        
/*
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            updatepubsize(hiddencompcode.Value, hiddendate.Value, hiddenpub.Value, hiddencenter.Value, hiddenedition.Value, hiddenspub.Value, hiddenidnum.Value, hiddenfilename.Value, Convert.ToDouble(hiddenpheight.Value), Convert.ToDouble(hiddenpwidth.Value));
            Response.Write("<script>window.close();</script>");

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string serverpath = ConfigurationSettings.AppSettings[hiddencenter.Value].ToString();
            string StrJPGPath = serverpath + ConfigurationSettings.AppSettings["JPGfilepath"].ToString();
            string StrAdPicturesPath = serverpath + ConfigurationSettings.AppSettings["AdPicturesfilepath"].ToString();
            string StrJPGPathtemp = serverpath + ConfigurationSettings.AppSettings["JPGfilepathtemp"].ToString();
            string ImgFilename = StrAdPicturesPath + hiddenfilename.Value;
            string ImgFilenametemp = StrJPGPathtemp + hiddenfilename.Value;
            string ImgFilenamejpg = StrJPGPath + hiddenfilename.Value;
            
            if(File.Exists(ImgFilename+".pdf")==true)
                File.Delete(ImgFilename + ".pdf");
            if (File.Exists(ImgFilename + ".eps") == true)
                File.Delete(ImgFilename + ".eps");
            if (File.Exists(ImgFilename + ".tif") == true)
                File.Delete(ImgFilename + ".tif");
            if (File.Exists(ImgFilename + ".tiff") == true)
                File.Delete(ImgFilename + ".tiff");
            if (File.Exists(ImgFilename + ".jpg") == true)
                File.Delete(ImgFilename + ".jpg");

            if (File.Exists(ImgFilenametemp + ".jpg") == true)
                File.Delete(ImgFilenametemp + ".jpg");
            if (File.Exists(ImgFilenamejpg + ".jpg") == true)
                File.Delete(ImgFilenamejpg + ".jpg");
            Response.Write("<script>window.close();</script>");

        }*/
}
