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

public partial class Reports_reportprefer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
            Response.Redirect("../login.aspx");
        else
            hiddencompcode.Value = Session["compcode"].ToString();
        if (dpdpubcentpermit.SelectedValue == "0")
        {
            Session["access"] = "0";
        }
        else
        {
            Session["access"] = "1";
        }
       
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_reportprefer));
        if (!Page.IsPostBack)
        {
            bindpermit();
            //dpdpubcentpermit.Attributes.Add("onchange", "javascript:return accesspermission1();");
            btnupdate.Attributes.Add("onclick", "javascript:return updateprefer();");
        }
    }

    public void bindpermit()
    {
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 upd = new NewAdbooking.Report.classesoracle.Class1();
            dz = upd.selectreport(Session["compcode"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 upd = new NewAdbooking.Report.Classes.Class1();
            dz = upd.selectreport(Session["compcode"].ToString());

        }

        
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "No";
        li1.Value = "0";
        if (dz.Tables[0].Rows.Count > 0)
        {
            if (dz.Tables[0].Rows[0].ItemArray[1].ToString() == "0")
            {
                li1.Selected = true;
            }
        }
        else
        {
            li1.Selected = true;
        }
        dpdpubcentpermit.Items.Add(li1);
        
        
        li1 = new ListItem();
        li1.Value = "1";
        li1.Text = "Yes";
        if (dz.Tables[0].Rows.Count > 0)
        {
            if (dz.Tables[0].Rows[0].ItemArray[1].ToString() == "1")
            {
                li1.Selected = true;
            }
        }
        dpdpubcentpermit.Items.Add(li1);

        
        

     


    }

    //[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //public void access_permission(string value)
    //{
    //    Session["access"] = value;
    //}
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet update_prefer(string pub_cent, string compcode, string value)
    {
        Session["access"] = value;
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 upd = new NewAdbooking.Report.classesoracle.Class1();
            dz = upd.updatereport(pub_cent, compcode);           

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 upd = new NewAdbooking.Report.Classes.Class1();
            dz = upd.updatereport(pub_cent, compcode);

        }
        return dz;
    }

    
}
