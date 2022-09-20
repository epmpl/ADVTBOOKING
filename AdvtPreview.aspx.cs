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
using System.IO;

public partial class AdvtPreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string p_path = Server.MapPath("./") + "jpgPreview\\"; //System.Configuration.ConfigurationSettings.AppSettings["Previewpath"].ToString();
        string p_Edition = Request.QueryString["pEdition"].ToString();
        string p_page = Request.QueryString["ppage"].ToString();
        string dDay = Convert.ToString(DateTime.Today.AddDays(1).Day);
        string mMon = Convert.ToString(DateTime.Today.AddDays(1).Month);
       // string page_no = "1";
        if (mMon.Length == 1)
            mMon = "0" + mMon;
        string Yr = Convert.ToString(DateTime.Today.AddDays(1).Year);
        string ddate = dDay + "-" + mMon + "-" + Yr;
        p_path = p_path + p_Edition + ddate + "_" + p_page + ".jpg"; 
        if(File.Exists(p_path))
                // prev.InnerHtml = "<img src='image.aspx?path=" + p_path + "' width='660' height='1020'/>";
            prev.InnerHtml = "<img src='image.aspx?path=" + p_path + "'/>";
        else
        {
            Response.Write("<script>alert(\"Page does not exist.\");window.close();</script>");
            return;
        }
    }
}
