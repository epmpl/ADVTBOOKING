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

public partial class checkword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(checkword));
    }
    [Ajax.AjaxMethod]
    public string chk2badword(string str)
    {
        NewAdbooking.Classes.badwordnew log = new NewAdbooking.Classes.badwordnew();
        DataSet ds = new DataSet();
        ds = log.chkbadword1(str);
        if (ds.Tables[0].Rows.Count > 0)
        {

            return "True~" + str;
        }
        else
        {
            return "False";

        }

    }
}
