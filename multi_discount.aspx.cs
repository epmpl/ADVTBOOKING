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

public partial class multi_discount : System.Web.UI.Page
{
    string passvalue, discode, special;
    NewAdbooking.Classes.DiscountMaster checkmultilistbox = new NewAdbooking.Classes.DiscountMaster();
    DataSet dl = new DataSet();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;
        Ajax.Utility.RegisterTypeForAjax(typeof(multi_discount));
        //Ajax.Utility.RegisterTypeForAjax(typeof(DiscountMaster));


        if (Session["compcode"] != null)
        {

            string[] str = new string[2];


            string str1 = Request.QueryString["passvalue"].ToString();
            str = str1.Split(',');
            discode = str[0];
            special = str[1];

            hidndiscode.Value = discode;

        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }




        //			"javascript:return updatedisable();";
        if (!Page.IsPostBack)
        {
            btnclose.Attributes.Add("OnClick", "javascript:return closebox();");

            addlistbox();
            dl = checkmultilistbox.checkmulti(Session["compcode"].ToString(), Session["userid"].ToString(), discode);

            if (dl.Tables[0].Rows.Count > 0)
            {
                btnupdate.Visible = true;
                btnsubmit.Visible = false;
                bindlistbox();
            }
            else
            {
                btnupdate.Visible = false;
                btnsubmit.Visible = true;

            }

            updatedis();


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

    public void addlistbox()
    {

        NewAdbooking.Classes.DiscountMaster bindlistbox = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = bindlistbox.listboxdis(Session["compcode"].ToString(), Session["userid"].ToString());

        ListBox1.Items.Clear();
        ListItem li1;
        //ListItem li2;
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

    public void bindlistbox()
    {

        string sizecode = dl.Tables[0].Rows[0].ItemArray[0].ToString();
        string listcode = dl.Tables[0].Rows[0].ItemArray[1].ToString();

        int i;
        char[] splitter = { ',' };



        string[] myarray = listcode.Split(splitter);

        for (i = 0; i <= myarray.Length - 1; i++)
        {
            if (myarray[i] != "")
            {
                if (myarray[i] != "0")
                {

                    ListBox1.Items.FindByValue(myarray[i]).Selected = true;
                    ListBox1.Items.FindByValue("0").Selected = false;

                }
            }
        }



    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        string abc = "";
        foreach (ListItem li in ListBox1.Items)
        {

            if (li.Selected == true)
            {
                if (li.Value != "")
                {

                    abc = abc + li.Value + ",";
                }

            }
        }
        string ab = abc;
        NewAdbooking.Classes.DiscountMaster bindmultilistbox = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = bindmultilistbox.listboxmultibind(Session["compcode"].ToString(), Session["userid"].ToString(), discode, ab);

        btnsubmit.Visible = false;
        btnupdate.Visible = true;
    }

    protected void btnupdate_Click(object sender, System.EventArgs e)
    {
        string abc = "";
        foreach (ListItem li in ListBox1.Items)
        {

            if (li.Selected == true)
            {

                if (li.Value != "0")
                {
                    abc = abc + li.Value + ",";
                }


            }
        }
        string ab = abc;
        NewAdbooking.Classes.DiscountMaster updatemultilistbox = new NewAdbooking.Classes.DiscountMaster();
        DataSet ds = new DataSet();
        ds = updatemultilistbox.listboxmultiupdate(Session["compcode"].ToString(), Session["userid"].ToString(), discode, ab);

    }

    [Ajax.AjaxMethod]

    public void updatedis()
    {

        if (special == "1")
        {
            btnupdate.Enabled = false;

        }

    }




}