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

public partial class Role_Permission : System.Web.UI.Page
{
    string RoleId;
    int j = 0;
    string moduleuserid, modulename;
    int abc;
    DataSet dspublic = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddenuser.Value = Request.QueryString["userid"].ToString();
            hiddenusername.Value = Session["Username"].ToString();
            hiddenmodulename.Value = Request.QueryString["modulename"].ToString();
            hiddendivision.Value = Request.QueryString["division"].ToString();
         
        }
        else
        {
           Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
       
        Ajax.Utility.RegisterTypeForAjax(typeof(Role_Permission));
        
        moduleuserid = Request.QueryString["userid"].ToString();
        modulename = Request.QueryString["modulename"].ToString();
        hiddenRoleId.Value = Request.QueryString["RoleId"].ToString();
        RoleId = Request.QueryString["RoleId"].ToString();

        if (!Page.IsPostBack)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databindbank = new NewAdbooking.Classes.pop();
                dspublic = databindbank.MasterPrevSel(moduleuserid, modulename);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databindbank = new NewAdbooking.classesoracle.pop();
                dspublic = databindbank.MasterPrevSel(moduleuserid, modulename);
            }
            else
            {
                NewAdbooking.classmysql.pop databindbank = new NewAdbooking.classmysql.pop();
                dspublic = databindbank.MasterPrevSel(moduleuserid, modulename);
            }
            band(moduleuserid, modulename);
            btnshow.Attributes.Add("OnClick", "javascript:return formnamechk();");
            btnclose.Attributes.Add("OnClick", "javascript:return masterpermexit();");
        }
    }


    public void band(string userid, string modulename)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindbank = new NewAdbooking.Classes.pop();
            ds = databindbank.MasterPrevSel(userid, modulename);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindbank = new NewAdbooking.classesoracle.pop();
            ds = databindbank.MasterPrevSel(userid, modulename);
        }
        else
        {
            NewAdbooking.classmysql.pop databindbank = new NewAdbooking.classmysql.pop();
            ds = databindbank.MasterPrevSel(userid, modulename);
        }


        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

    }


    [Ajax.AjaxMethod]
    public void insertgrid(string prev, string formname, string roleid, string compcode)
    {
        DataSet da = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RoleMaster insertpriv = new NewAdbooking.classesoracle.RoleMaster();
            da = insertpriv.insMasterPrev(prev, formname, roleid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RoleMaster insertpriv = new NewAdbooking.Classes.RoleMaster();
            da = insertpriv.insMasterPrev(prev, formname, roleid, compcode);
        }
        else
        {
            NewAdbooking.classmysql.RoleMaster insertpriv = new NewAdbooking.classmysql.RoleMaster();
            da = insertpriv.insMasterPrev(prev, formname, roleid, compcode);
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
        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      //  this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
       // this.hiddenuser.ServerChange += new System.EventHandler(this.hiddenuser_ServerChange);
       // this.hiddenmodulename.ServerChange += new System.EventHandler(this.hiddenmodulename_ServerChange);
        //this.hiddenusername.ServerChange += new System.EventHandler(this.hiddenusername_ServerChange);
        //   this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Header)
        {
            DataSet ds1 = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop checkbox = new NewAdbooking.classesoracle.pop();
                ds1 = checkbox.checkForm();

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop checkbox = new NewAdbooking.Classes.pop();
                ds1 = checkbox.checkForm();

            }
            else
            {
                NewAdbooking.classmysql.pop checkbox = new NewAdbooking.classmysql.pop();
                ds1 = checkbox.checkForm();
            }
            abc = 0;
            abc = ds1.Tables[0].Rows.Count;
        }

        if ((e.Item.ItemType != ListItemType.Header) && (e.Item.ItemType != ListItemType.Footer))
        {

            DataSet dl = new DataSet();
             string form = dspublic.Tables[0].Rows[j].ItemArray[0].ToString();

             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.RoleMaster checkbox1 = new NewAdbooking.classesoracle.RoleMaster();
                 dl = checkbox1.checkPrevuser(RoleId.Trim(), form);
             }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
                 NewAdbooking.Classes.RoleMaster checkbox1 = new NewAdbooking.Classes.RoleMaster();
                 dl = checkbox1.checkPrevuser(RoleId.Trim(), form);
             }
             else
             {
                 NewAdbooking.classmysql.RoleMaster checkbox1 = new NewAdbooking.classmysql.RoleMaster();
                 dl = checkbox1.checkPrevuser(RoleId.Trim(), form);
             }

            string str = "CheckBox7" + j;
            string str1 = "CheckBox1" + j;
            string str2 = "CheckBox2" + j;
            string str3 = "CheckBox3" + j;
         //   string str4 = "CheckBox4" + j;
            if (dl.Tables[0].Rows.Count > 0)
            {
                e.Item.Cells[0].Text = "<input type='checkbox'  onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                e.Item.Cells[2].Text = "<input type='checkbox' width='5px'  id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                e.Item.Cells[3].Text = "<input type='checkbox' width='5px'  id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                e.Item.Cells[4].Text = "<input type='checkbox' width='5px'  id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
               
            }
          
            int l;
           if (dl.Tables[0].Rows.Count != 0)
           {
               e.Item.Cells[0].Text = "<input type='checkbox'  onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
               if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "1")
                {
                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                }
                else if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "2")
                {
                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                }
                else if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "3")
                {
                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                }
                else if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "4")
                {
                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                }
                else if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "5")
                {
                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                }
                else if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "6")
                {
                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                }
                else if (dl.Tables[0].Rows[0].ItemArray[1].ToString() == "7")
                {
                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";

                }
            }
            else
            {
                e.Item.Cells[0].Text = "<input type='checkbox'  onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    />";
                e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "    />";
                e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "    />";
            }

            j++;

        }


    }


}
