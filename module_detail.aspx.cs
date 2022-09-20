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

public partial class module_detail : System.Web.UI.Page
{
    string admin = "";
    string userhome = "";
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here


        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        Ajax.Utility.RegisterTypeForAjax(typeof(module_detail));

        if (Session["compcode"] == null)
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
            //Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            //return;
        }


        hiddenusername.Value = Session["Username"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddensessionuser .Value= Session["Admin"].ToString();

        if (!Page.IsPostBack)
        {

            lstuser.Attributes.Add("onclick", "javascript:return insertuser();");
            lstuser.Attributes.Add("onkeydown", "javascript:return insertuserbyenter(event);");
            //drpuserid.Attributes.Add("OnChange", "javascript:return adduser();");
            drpuserid.Attributes.Add("onkeydown", "javascript:return selectuser(event);");
            drpmodulename.Attributes.Add("OnChange", "javascript:return addmodule();");
            drpdivision.Attributes.Add("OnChange", "javascript:return division();");
            btnshow.Attributes.Add("OnClick", "javascript:return openform();");
            //BindMastprevdisplay();
            bindmoduledetail();
            binddivison();

        }
        drpuserid.Focus();

        //-------------Ad by rinki (show button permission)------------------//

        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();
            dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "module_detail");
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();
            dz = checkform.formpermission(Session["compcode"].ToString(), Session["userid"].ToString(), "module_detail");

        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "WEBSP_SHOWPERMISSION_websp_showpermission_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), "module_detail" };
            dz = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        

        string id = "";
        if (dz.Tables[0].Rows.Count > 0)
        {
            id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        if (id == "0" || id=="8")
           // btnshow.Enabled = true;
            Response.Write("<script>alert(\"You Are Not Authorised To See This Form\");window.location.href = 'EnterPage.aspx';</script>");
       // else
            //  btnsubmit.Enabled = false;
            
        //--------------------------------------------------------------------//
        //Label4.Attributes.Add("OnClick","javascript:return akh13();");
    }





    public void bindmoduledetail()
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.Mastdetail(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.Mastdetail(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            //string procedureName = "wesp_Modultdetail_wesp_Modultdetail_p";
            string procedureName = "wesp_Modultdetail";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       

        drpmodulename.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drpmodulename.Items.Add(li1);

        //ds=MastPrev.MastPrevDisp();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //user=li.Value=ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //li1.Selected =true;
                drpmodulename.Items.Add(li);

            }
            drpmodulename.DataBind();
        }


    }


    public void binddivison()
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastDivison(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastDivison(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "wesp_Modultdivision_wesp_Modultdivision_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       
        

        drpdivision.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drpdivision.Items.Add(li1);

        //ds=MastPrev.MastPrevDisp();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //user=li.Value=ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //li1.Selected =true;
                drpdivision.Items.Add(li);

            }
            drpdivision.DataBind();
        }


    }



    /*change*/
    /*public void BindMastprevdisplay()
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(),Session["Revenue"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.pop MastPrev = new NewAdbooking.classmysql.pop();
            ds1 = MastPrev.MastPrevDisp(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString());
        }
        

        drpuserid.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drpuserid.Items.Add(li1);

        //ds=MastPrev.MastPrevDisp();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
               // if (Session["userhome"].ToString() == "Agency" && Session["Admin"].ToString() == "yes")
                if (Session["Admin"].ToString() == "yes")
                {
                    li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                    drpuserid.Items.Add(li);
                }
                else
                {
                    if (ds1.Tables[0].Rows[i].ItemArray[2].ToString() == "" && ds1.Tables[0].Rows[i].ItemArray[3].ToString() == "Agency")
                    { }
                    else
                    {
                        li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                        li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                        drpuserid.Items.Add(li);
                    }
                }
                //user=li.Value=ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //li1.Selected =true;
                

            }
            drpuserid.DataBind();
        }
    }*/
    //band2(user);
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]

    public DataSet Binduser(string username)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp_user(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString(), username);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp_user(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString(), username);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "wesp_Modultuser_wesp_wesp_Modultuser_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString(), username,"","" };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       

       //if (ds1.Tables[0].Rows.Count > 0)
       // {
       //     for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
       //     {
       //         ListItem li;
       //         li = new ListItem();
       //         // if (Session["userhome"].ToString() == "Agency" && Session["Admin"].ToString() == "yes")
       //         if (Session["Admin"].ToString() == "yes")
       //         {
       //             li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
       //             li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
       //             drpuserid.Items.Add(li);
       //         }
       //         else
       //         {
       //             if (ds1.Tables[0].Rows[i].ItemArray[2].ToString() == "" && ds1.Tables[0].Rows[i].ItemArray[3].ToString() == "Agency")
       //             { }
       //             else
       //             {
       //                 li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
       //                 li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
       //                 drpuserid.Items.Add(li);
       //             }
       //         }


       //     }
       //     drpuserid.DataBind();
       // }
       return ds1;
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
        //this.hiddenusername.ServerChange += new System.EventHandler(this.hiddenusername_ServerChange);
        //this.hiddencompcode.ServerChange += new System.EventHandler(this.hiddencompcode_ServerChange);
        //this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    private void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void hiddencompcode_ServerChange(object sender, System.EventArgs e)
    {

    }

    /*change*/
    [Ajax.AjaxMethod]
    public DataSet getuserinfo(string userid)
    {
        DataSet ds1 = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.getuserinfo(userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.getuserinfo(userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Wesp_getuserinfo_Wesp_getuserinfo_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { userid };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       
       

        return ds1;

    }






}