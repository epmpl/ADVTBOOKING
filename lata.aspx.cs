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

public partial class lata : System.Web.UI.Page
{
    public void bindpackage()
    {

        NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
        DataSet ds = new DataSet();
        ds = bindopackage.packagebind("HT001", "A01");
        //drppackage.Items.Clear();
        int i;
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                chk1.Items.Add(li);
            }

        }
        


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        bindpackage();
        if (!Page.IsPostBack)
        {
            chk1.Attributes.Add("onclick ","javascript:return getvalue();");
        }
    }
}
