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

public partial class multi_bullet : System.Web.UI.Page
{
    string bulletcode, chk, show;
    NewAdbooking.Classes.bulletmaster multi = new NewAdbooking.Classes.bulletmaster();
    DataSet dl = new DataSet();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;

        if (Session["compcode"] != null)
        {
            bulletcode = Request.QueryString["adsize"].ToString();
            chk = Request.QueryString["chk"].ToString();
            show = Request.QueryString["show"].ToString();


        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(multi_bullet));
        //Ajax.Utility.RegisterTypeForAjax(typeof(Bullet_master));

        if (!Page.IsPostBack)
        {
            //btnclose.Attributes.Add("OnClick","javascript:return closebox();");
            btnclose.Attributes.Add("OnClick", "javascript:return closebullet();");
            addlistbox();
            dl = multi.checkmultibull(Session["compcode"].ToString(), Session["userid"].ToString(), bulletcode);
            if (dl.Tables[0].Rows.Count > 0)
            {
                //btnupdate.Visible=true;
                btnupdate.Enabled = true;
                //btnsubmit.Visible=false;
                //btnsubmit.Enabled=true;
                bindlistbox();
            }
            /*else
            {
                btnupdate.Enabled=false;
                btnupdate.Visible=false;
                btnsubmit.Visible=true;
                btnsubmit.Enabled=true;
				
            }*/
            if (chkmulti.Value == "e")
            {
                btnupdate.Enabled = true;
                btnsubmit.Enabled = true;
                btnupdate.Visible = true;
                btnsubmit.Visible = false;

            }
            if (chkmulti.Value == "n")
            {
                btnupdate.Enabled = false;
                btnsubmit.Enabled = true;
                btnupdate.Visible = false;
                btnsubmit.Visible = true;

            }
            if (chkmulti.Value == "f")
            {
                btnupdate.Enabled = true;
                btnsubmit.Enabled = true;
                //btnupdate.Visible=true;
                //btnsubmit.Visible=false;

            }
            if (chkmulti.Value == "m")
            {
                btnupdate.Enabled = true;
                btnsubmit.Enabled = true;
                //btnupdate.Visible=true;
                //btnsubmit.Visible=false;

            }
            if (dl.Tables[0].Rows.Count > 0)
            {
                //btnupdate.Visible=true;
                btnupdate.Enabled = true;
                btnsubmit.Visible = false;
            }
            if (dl.Tables[0].Rows.Count <= 0)
            {
                //btnupdate.Visible=true;
                btnupdate.Visible = false;
                btnsubmit.Visible = true;
            }
            if (show == "2" || show == "1")
            {
                btnupdate.Enabled = true;
            }
            else
            {
                btnupdate.Enabled = false;
                btnsubmit.Enabled = false;
            }
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
        NewAdbooking.Classes.bulletmaster submitbull = new NewAdbooking.Classes.bulletmaster();
        DataSet ds = new DataSet();
        ds = submitbull.chkinsbull(Session["compcode"].ToString(), Session["userid"].ToString(), bulletcode, ab);

        //			btnsubmit.Visible=false;
        //			btnupdate.Visible=true;
        btnsubmit.Enabled = false;
        btnupdate.Enabled = true;
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
        NewAdbooking.Classes.bulletmaster updatebull = new NewAdbooking.Classes.bulletmaster();
        DataSet ds = new DataSet();
        ds = updatebull.listboxbullupdate(Session["compcode"].ToString(), Session["userid"].ToString(), bulletcode, ab);
    }


}