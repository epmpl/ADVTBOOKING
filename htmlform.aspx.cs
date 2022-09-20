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

public partial class htmlform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        DataSet dslogo = new DataSet();
        DataSet ds = new DataSet();
        string compcode = Session["compcode"].ToString();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.AdCat4 category = new NewAdbooking.Classes.AdCat4();
            //ds = category.addcategoryname(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.receipt vat = new NewAdbooking.classesoracle.receipt();
            ds = vat.getvat(compcode);
        }
        else
        {
            NewAdbooking.classmysql.receipt vat = new NewAdbooking.classmysql.receipt();
            ds = vat.getvat(compcode);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            hiddenvat.Value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        //if (Request.QueryString["cioid"] != null)
        //{
            
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //    {
        //        //NewAdbooking.Classes.AdCat4 category = new NewAdbooking.Classes.AdCat4();
        //        //ds = category.addcategoryname(compcode);
        //    }
        //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        NewAdbooking.classesoracle.receipt logo = new NewAdbooking.classesoracle.receipt();
        //        dslogo = logo.getlogo(Request.QueryString["cioid"].ToString());
        //    }
        //    else
        //    {
        //        NewAdbooking.classmysql.receipt logo = new NewAdbooking.classmysql.receipt();
        //        dslogo = logo.getlogo(Request.QueryString["cioid"].ToString());
        //    }
            

        //    if (Session["imgname_logo"] != null)
        //    {
        //        hiddenlogo.Value = Session["imgname_logo"].ToString();
        //    }
        //    else if (dslogo.Tables[0].Rows.Count > 0)
        //    {
        //        hiddenlogo.Value = dslogo.Tables[0].Rows[0].ItemArray[0].ToString();
        //    }

        //    if (Session["matterText_session"] != null)
        //        hiddenmatter.Value = Session["matterText_session"].ToString();
        //    else
        //        hiddenmatter.Value = dslogo.Tables[1].Rows[0].ItemArray[0].ToString();

        //}

    }
}
