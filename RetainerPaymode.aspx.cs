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

public partial class RetainerPaymode : System.Web.UI.Page
{
    string show, compcode, userid, RetPayCode, sel, n_m;
    protected void Page_Load(object sender, System.EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");

        }

        show = Request.QueryString["show"].ToString();
        hiddenshow.Value = show;

        //saurabh***************************************

        n_m = Request.QueryString["n_m"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(RetainerPaymode));

       DataSet ds = new DataSet();

        hiddencompcode.Value = Session["compcode"].ToString();
        compcode = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        userid = Session["userid"].ToString();
        hiddenretcode.Value = Request.QueryString["RetPayCode"].ToString();
        RetPayCode = hiddenretcode.Value;
      if (hiddenretcode.Value == "")
       
        {
            Response.Write("<script>alert('You Should Enter The Retainer Code First');window.close();</script>");
            return;
        }

        

        btnSubmit.Attributes.Add("OnClick", "javascript:return PayModeSubmit();");
        btnUpdate.Attributes.Add("OnClick", "javascript:return PayModeUpdate();");



        if (hiddencompcode.Value == "" || hiddenuserid.Value == null)
        {
            Response.Write("<script>'alert('your Session has been expired Please Relogin')';window.close(); </script>");
            return;
        }

        //------------------------ saurabh -------------------------------------

        //NewAdbooking.Classes.RetainerMaster RetCode = new NewAdbooking.Classes.RetainerMaster();
        //DataSet ds = new DataSet();
        //ds = RetCode.getData(hiddenretcode.Value, hiddenuserid.Value, hiddencompcode.Value);

        if (!Page.IsPostBack)
        {
            if (Session["retainer_pay"] == null)
            {
                if (n_m == "1")
                {
                    radio_bind();
                    btnSubmit.Enabled = true;
                }
                else
                {
                    radio_bind1();
                    if (n_m == "0")
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = true;
                    }
                    else if (n_m == "2")
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = false;
                    }
                }
            }
            else
            {
                hiddenval.Value = Session["retainer_pay"].ToString();
                radio_bind();

                btnSubmit.Enabled = false;
            }
        }
    }

    //        if (Session["client_pay"] == null)
    //        {
    //            string str = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //            string str1 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
    //            string str2 = ds.Tables[0].Rows[0].ItemArray[2].ToString();

    //            if (str == "Cash")
    //            {
    //                chklstUpdate.Items[0].Selected = true;
    //            }
    //            if (str1 == "Credit")
    //            {
    //                chklstUpdate.Items[1].Selected = true;
    //            }
    //            if (str2 == "Bank")
    //            {
    //                chklstUpdate.Items[2].Selected = true;
    //            }

    //            chklstSubmit.Attributes.Add("disabled", "disabled");
    //            btnUpdate.Enabled = true;
    //            btnSubmit.Enabled = false;
    //        //}
    //        //else
    //        //{

    //        //    chklstUpdate.Attributes.Add("disabled", "disabled");
    //        //    btnUpdate.Enabled = false;
    //        //    btnSubmit.Enabled = true;
    //        //}

    //        if (show == "1")
    //        {

    //            btnSubmit.Enabled = true;
    //            btnUpdate.Enabled = false;

    //        }
    //        if (show == "2")
    //        {
    //            btnSubmit.Enabled = false;
    //            btnUpdate.Enabled = true;
    //        }
    //        if (show == "0")
    //        {
    //            btnSubmit.Enabled = false;
    //            btnUpdate.Enabled = false;


    //        }
    //    }

    //}



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

    //******************************SAURABH CODE FOR RADIO BUTTON****************************

    public void radio_bind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.RetainerMaster radiobind = new NewAdbooking.Classes.RetainerMaster();
            
            ds = radiobind.filldatapay(compcode, userid);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster radiobind = new NewAdbooking.classesoracle.RetainerMaster();

                ds = radiobind.filldatapay(compcode, userid);
            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster radiobind = new NewAdbooking.classmysql.RetainerMaster();

            ds = radiobind.filldatapay(compcode, userid);

        }
        
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem ls = new ListItem();
            ls.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            ls.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            rdolistsubmit.Items.Add(ls);


            string[] myvalue;
            if (Session["retainer_pay"] != null)
            {
                myvalue = Session["retainer_pay"].ToString().Split(',');
                for (int k = 0; k <= myvalue.Length - 1; k++)
                {
                    if (ls.Value == myvalue[k])
                    {
                        rdolistsubmit.Items[i].Selected = true;
                    }

                }

            }
        }
    }
    public void radio_bind1()
    {
        DataSet ds2 = new DataSet();
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    {

        NewAdbooking.Classes.RetainerMaster fill = new NewAdbooking.Classes.RetainerMaster();
      
        ds2 = fill.filldatapay(compcode, userid);
    }

        else
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.RetainerMaster fill = new NewAdbooking.classesoracle.RetainerMaster();

                ds2 = fill.filldatapay(compcode, userid);
            }
    else
    {
        NewAdbooking.classmysql .RetainerMaster fill = new NewAdbooking.classmysql.RetainerMaster();
       
        ds2 = fill.filldatapay(compcode, userid);
    }
        rdolistupdate.DataSource = ds2.Tables[0];
        rdolistupdate.DataTextField = "Payment_Mode_Name";
        rdolistupdate.DataValueField = "Pay_Mode_Code";
        rdolistupdate.DataBind();
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.RetainerMaster chk1 = new NewAdbooking.Classes.RetainerMaster();
         
            ds1 = chk1.showchk(compcode, userid, hiddenretcode.Value);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster chk1 = new NewAdbooking.classesoracle.RetainerMaster();

                ds1 = chk1.showchk(compcode, userid, hiddenretcode.Value);
            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster chk1 = new NewAdbooking.classmysql.RetainerMaster();
            
            ds1 = chk1.showchk(compcode, userid, hiddenretcode.Value);

        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            sel = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            hiddenval.Value = sel;
        }
        else
        {
            sel = "";
            hiddenval.Value = sel;
        }
        for (int i = 0; i < rdolistupdate.Items.Count; i++)
        {
            if (sel == rdolistupdate.Items[i].Value)
            {
                rdolistupdate.SelectedValue = rdolistupdate.Items[i].ToString();
                rdolistupdate.Items[i].Selected = true;
                break;
            }
        }
        // ScriptManager.RegisterClientScriptBlock(this, typeof(RetainerPaymode), "aa", "to_check('" + rdolistupdate + "')", true);
        // Response.Write("<script>'to_check();'</script>");
      // string[] myvalue;
        //NewAdbooking.Classes.RetainerMaster radiobind = new NewAdbooking.Classes.RetainerMaster();
        //DataSet ds = new DataSet();
        //ds = radiobind.filldatapay(compcode, userid);
        //for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
        //{
        //    ListItem ls = new ListItem();

        //    ls.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    ls.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    rdolistsubmit.Items.Add(ls);


        //Checking 4 user has selected any value  or not
        //if (sel != "")
        //{
        //    myvalue = sel.ToString().Split(',');
        //    for (int k = 0; k <= myvalue.Length - 1; k++)
        //    {
        //        if (hiddenval.Value == myvalue[k])
        //        {
        //            rdolistsubmit.Items[i].Selected = true;
        //        }

        //    }

        //}

       //}
    }

    //***************************************************************************************



    [Ajax.AjaxMethod]
    //public DataSet RetainerPayModeInsert(string compcode, string retcode, string userid, params string[] str)
    public void RetainerPayModeInsert(string compcode, string retcode, string userid, string MyString)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.RetainerMaster RetPayCode = new NewAdbooking.Classes.RetainerMaster();
            
            ds = RetPayCode.getData(retcode, userid, compcode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                RetPayCode.insertRetData(compcode, retcode, userid, 1, MyString);
            }
            else
            {
                RetPayCode.insertRetData(compcode, retcode, userid, 0, MyString);
            }
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster RetPayCode = new NewAdbooking.classesoracle.RetainerMaster();

                ds = RetPayCode.getData(retcode, userid, compcode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    RetPayCode.insertRetData(compcode, retcode, userid, 1, MyString);
                }
                else
                {
                    RetPayCode.insertRetData(compcode, retcode, userid, 0, MyString);
                }
            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster RetPayCode = new NewAdbooking.classmysql.RetainerMaster();

            ds = RetPayCode.getData(retcode, userid, compcode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                RetPayCode.insertRetData(compcode, retcode, userid, 1, MyString);
            }
            else
            {
                RetPayCode.insertRetData(compcode, retcode, userid, 0, MyString);
            }

        }
       
        //return ds;

        //string[] MyString = str;
        //for (int i = 0; i <= MyString.Length - 1; i++)
        //{
        //    if (MyString[i] == "ul")
        //    {
        //        MyString[i] = "";
        //    }
        //}
        //NewAdbooking.Classes.RetainerMaster RetPayCode = new NewAdbooking.Classes.RetainerMaster();
        ////DataSet ds = new DataSet();
        ////DataSet ds1 = new DataSet();
        ////ds = RetPayCode.getData(retcode, userid, compcode);
        ////if (ds.Tables[0].Rows.Count > 0)
        ////{
        ////    ds1 = RetPayCode.insertRetData(compcode, retcode, userid, 1, MyString);
        ////}
        ////else
        ////{
        ////    ds1 = RetPayCode.insertRetData(compcode, retcode, userid, 0, MyString);
        ////}
        ////return ds1;
    }

    [Ajax.AjaxMethod]
    public DataSet chk(string compcode, string userid, string retcode)

    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.RetainerMaster chk = new NewAdbooking.Classes.RetainerMaster();
            
            ds = chk.showchk(compcode, userid, retcode);
            return ds;
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RetainerMaster chk = new NewAdbooking.classesoracle.RetainerMaster();

                ds = chk.showchk(compcode, userid, retcode);
                return ds;
            }
        else
        {
            NewAdbooking.classmysql.RetainerMaster chk = new NewAdbooking.classmysql.RetainerMaster();

            ds = chk.showchk(compcode, userid, retcode);
            return ds;
        }
    }

    protected void hiddenshow_ServerChange(object sender, System.EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["retainer_pay"] = rdolistsubmit.SelectedValue.ToString();
        hiddenval.Value = Session["retainer_pay"].ToString();
        btnSubmit.Enabled = false;
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }
}