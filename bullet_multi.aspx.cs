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

public partial class bullet_multi : System.Web.UI.Page
{
    NewAdbooking.Classes.Adsize checkmultilistbox = new NewAdbooking.Classes.Adsize();
    DataSet dl = new DataSet();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here


        if (!Page.IsPostBack)
        {
            btnclose.Attributes.Add("OnClick", "javascript:return closebox();");

            addlistbox();



        }
    }

    public void addlistbox()
    {

        NewAdbooking.Classes.Adsize bindlistbox = new NewAdbooking.Classes.Adsize();
        DataSet ds = new DataSet();
        ds = bindlistbox.listboxbind(Session["compcode"].ToString(), Session["userid"].ToString());

        ListBox1.Items.Clear();
        ListItem li1;
        ListItem li2;
        li1 = new ListItem();
        li1.Text = "--Select --";
        li1.Value = "0";
        li1.Selected = true;

        ListBox1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            ListBox1.Items.Add(li);


        }

    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion
}