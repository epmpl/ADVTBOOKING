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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Default2));
        if (!Page.IsPostBack)
        {
            //Button1.Attributes.Add("OnClick","javascript:return parentclild();");
        }
        
    }


    //[Ajax.AjaxMethod]
    //public DataSet parent()
    //{
    //    NewAdbooking.Classes.Master par = new NewAdbooking.Classes.Master();
    //    DataSet ds = new DataSet();
    //    ds = par.parent();
    //    return ds;
    //}

    //[Ajax.AjaxMethod]
    //public DataSet child(string child)
    //{
    //    NewAdbooking.Classes.Master par = new NewAdbooking.Classes.Master();
    //    DataSet ds = new DataSet();
    //    ds = par.filchild(child);
    //    return ds;
    //}
}
