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

public partial class multi_adsize : System.Web.UI.Page
{
    string compcode, userid, adsizecode;
   
    DataSet dl = new DataSet();
    string show;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {

            adsizecode = Request.QueryString["adsize"].ToString();
            chkmulti.Value = Request.QueryString["chk"].ToString();
            show = Request.QueryString["show"].ToString();

        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(multi_adsize));
        //Ajax.Utility.RegisterTypeForAjax(typeof(Adsize_master));
        if (!Page.IsPostBack)
        {
            btnclose.Attributes.Add("OnClick", "javascript:return closebox();");

            addlistbox();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Adsize checkmultilistbox = new NewAdbooking.Classes.Adsize();
                dl = checkmultilistbox.checkmulti(Session["compcode"].ToString(), Session["userid"].ToString(), adsizecode);
            }
            else
            {
                NewAdbooking.classesoracle.Adsize checkmultilistbox = new NewAdbooking.classesoracle.Adsize();
                dl = checkmultilistbox.checkmulti(Session["compcode"].ToString(), Session["userid"].ToString(), adsizecode);
            }
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

       
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindlistbox = new NewAdbooking.Classes.Adsize();
            ds = bindlistbox.listboxbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classesoracle.Adsize bindlistbox = new NewAdbooking.classesoracle.Adsize();
            ds = bindlistbox.listboxbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

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
      
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize bindmultilistbox = new NewAdbooking.Classes.Adsize();
            ds = bindmultilistbox.listboxmultibind(Session["compcode"].ToString(), Session["userid"].ToString(), adsizecode, ab);
        }
        else
        {
            NewAdbooking.classesoracle.Adsize bindmultilistbox = new NewAdbooking.classesoracle.Adsize();
            ds = bindmultilistbox.listboxmultibind(Session["compcode"].ToString(), Session["userid"].ToString(), adsizecode, ab);
        }

        //			btnsubmit.Visible=false;
        //			btnupdate.Visible=true;
        btnsubmit.Enabled = false;
        btnupdate.Enabled = true;

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
        
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Adsize updatemultilistbox = new NewAdbooking.Classes.Adsize();
            ds = updatemultilistbox.listboxmultiupdate(Session["compcode"].ToString(), Session["userid"].ToString(), adsizecode, ab);
        }
        else
        {
            NewAdbooking.classesoracle.Adsize updatemultilistbox = new NewAdbooking.classesoracle.Adsize();
            ds = updatemultilistbox.listboxmultiupdate(Session["compcode"].ToString(), Session["userid"].ToString(), adsizecode, ab);
        }


    }

    protected void chkmulti_ServerChange(object sender, System.EventArgs e)
    {

    }
}
