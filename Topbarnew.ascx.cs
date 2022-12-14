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

public partial class Topbarnew : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsenablelink = new DataSet();
        dsenablelink.ReadXml(Server.MapPath("xml/topbarlink.xml"));
        if (Session["comp_name"] != null)
        {
            hidcompname.Value = Session["comp_name"].ToString();
        }
        if (Session["center"] != null)
        {
            hidcenter.Value = Session["center"].ToString();
        }
        if (Session["Username"] != null)
            hidusername.Value = Session["username"].ToString();
        if (Session["userid"] != null)
            hiduserid.Value = Session["userid"].ToString();
        if (Session["compcode"] != null)
            hidcompcode.Value = Session["compcode"].ToString();
        if (Session["dateformat"] != null)
            hidauto.Value = Session["dateformat"].ToString();
        if(Session["autogenerated"]!=null)
            hidautogenerated.Value = Session["autogenerated"].ToString();
        if (Session["center"] != null)
        hiddencenter.Value = Session["center"].ToString();
    if (Session["revenue"] != null)
        hiddenreveneue.Value = Session["revenue"].ToString();

		if (Session["centername"] != null)
            hidunitname.Value = Session["centername"].ToString();
		
        //imglogo.Src = "Images/" + ConfigurationManager.AppSettings["logoimg"].ToString();
        //imglogo.Width = Convert.ToInt32(ConfigurationManager.AppSettings["logoimgwidth"].ToString());

        string center = ConfigurationSettings.AppSettings["center"].ToString();
       // if (center == "depo")
        //{
        if (System.IO.Path.GetFileName(Page.Request.PhysicalPath) != "cngpassword.aspx")
        {
            if (dsenablelink.Tables[0].Rows[0].ItemArray[0].ToString() == "enable")
            {
                lbldisplay.Visible = true;
                
            }
            else
            {
                lbldisplay.Visible = false;
            }
            if (dsenablelink.Tables[0].Rows[0].ItemArray[1].ToString() == "enable")// for classified booking
            {
                Label2.Visible = true;
                                
            }
            else
            {
                Label2.Visible = false;
            }
            if (dsenablelink.Tables[0].Rows[0].ItemArray[2].ToString() == "enable")// for layoutx
            {
                Label3.Visible = true;
            }
            else
            {
                Label3.Visible = false;
            }
            if (dsenablelink.Tables[0].Rows[0].ItemArray[3].ToString() == "enable")
            {
                Label4.Visible = true;
            }
            else
            {
                Label4.Visible = false;
            }
            if (dsenablelink.Tables[0].Rows[0].ItemArray[4].ToString() == "enable")
            {
                Label5.Visible = true;
            }
            else
            {
                Label5.Visible = false;
            }
            if (dsenablelink.Tables[0].Rows[0].ItemArray[5].ToString() == "enable")
            {
                Label9.Visible = true;
            }
            else
            {
                Label9.Visible = false;
            }
            if (dsenablelink.Tables[0].Rows[0].ItemArray[6].ToString() == "enable")
            {
                lblcir.Visible = true;
            }
            else
            {
                lblcir.Visible = false;
            }
        }
        else
        {
            lbldisplay.Visible = false;
            Label9.Visible = false;
            Label5.Visible = false;
            Label4.Visible = false;
            Label3.Visible = false;
            Label2.Visible = false;
            lblcir.Visible = false;
        }

        if (System.IO.Path.GetFileName(Page.Request.PhysicalPath) != "Default.aspx")
        {
            _lbuser.Attributes.Add("style", "display:none");
            _user.Attributes.Add("style", "display:none");
            _lbcom.Attributes.Add("style", "display:none");
            _com.Attributes.Add("style", "display:none");
            _lbadmin.Attributes.Add("style", "display:none");
            _admin.Attributes.Add("style", "display:none");
        }
        //DataSet ds = new DataSet();
        //ds.ReadXml(Server.MapPath("XML/releaseno.xml"));
        //lbrelease.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        ////}

       
    }
}
