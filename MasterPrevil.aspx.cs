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

public partial class MasterPrevil : System.Web.UI.Page
{
    int k = 0;
    int j = 0;
    string moduleuserid, modulename;
    string admin = "";
    string userhome = "";
    int abc;
    DataSet dspublic = new DataSet();
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Response.Expires = -1;
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();

            hiddenuser.Value = Request.QueryString["userid"].ToString();

            hiddenusername.Value = Session["Username"].ToString();

            hiddenmodulename.Value = Request.QueryString["modulename"].ToString();

            hiddenmoduleno.Value = Request.QueryString["moduleno"].ToString();
            hiddendivision.Value = Request.QueryString["division"].ToString();
            admin = Session["Admin"].ToString();
            userhome = Session["userhome"].ToString();
        }
        else
        {
            //Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        ip1.Value = Request.ServerVariables["REMOTE_ADDR"];

        Ajax.Utility.RegisterTypeForAjax(typeof(MasterPrevil));



        moduleuserid = Request.QueryString["userid"].ToString();
        modulename = Request.QueryString["modulename"].ToString();
        
        DateTime da = DateTime.Now;
        string id = ""; ;
        string formname = "MasterPrevil";
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();

            dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();

                dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname);
            }
            else
            {
                NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();

                dz = checkform.formpermission(hiddencompcode.Value, hiddenuserid.Value, formname);
            }

        if (dz.Tables[0].Rows.Count > 0)
        {
            id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            if (id == "0" || id == "8")
            {
                //hiddenpermission.Value = "zero";
                Response.Write("<script>alert('You Are Not Authorised To See This Form');</script>");
                Response.Write("<script>window.close();</script>");
                return;
            }
        }

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
            btninsert.Enabled = false;
            btnshow.Enabled = false;
            buttonenable(moduleuserid);
            btnshow.Attributes.Add("OnClick", "javascript:return formnamechk();");
            btninsert.Attributes.Add("OnClick", "javascript:return insertformname();");
            btnclose.Attributes.Add("OnClick", "javascript:return masterpermexit();");



            //drpuserid.Attributes.Add("OnChange","javascript:return adduser();");
            //BindMastprevdisplay();
            //Checkbox4.Attributes.Add("OnClick","javascript:return checkboxes(this);");
            //chekbox1();
            //chekbox();

        }
        //Label4.Attributes.Add("OnClick","javascript:return akh13();");

    }

    public void buttonenable(string moduleuserid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop enablechk = new NewAdbooking.Classes.pop();
            ds = enablechk.buttonenablechk(moduleuserid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop enablechk = new NewAdbooking.classesoracle.pop();
            ds = enablechk.buttonenablechk(moduleuserid);
        }
        else
        {
            NewAdbooking.classmysql.pop enablechk = new NewAdbooking.classmysql.pop();
            ds = enablechk.buttonenablechk(moduleuserid);
        }
        

        //if (ds.Tables[0].Rows.Count != 0)
        //{
            btninsert.Enabled = false;
            btninsert.Visible = false;
           
           
            btnshow.Enabled = true;
            btnshow.Visible = true;
        //}


        //else
        //{
        //    btninsert.Enabled = true;
        //    btninsert.Visible = true;
          
        //    btnshow.Enabled = false;
        //    btnshow.Visible = false;

        //}

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
        this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
        this.hiddenuser.ServerChange += new System.EventHandler(this.hiddenuser_ServerChange);
        this.hiddenmodulename.ServerChange += new System.EventHandler(this.hiddenmodulename_ServerChange);
        this.hiddenusername.ServerChange += new System.EventHandler(this.hiddenusername_ServerChange);
     //   this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion
    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
       
        if (e.Item.ItemType == ListItemType.Header)
        {
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop checkbox = new NewAdbooking.Classes.pop();

                //CheckBox CheckBox7 = (CheckBox)DataGrid1.Items[0].FindControl("CheckBox7");

                ds1 = checkbox.checkForm();
                //  ds1 = checkbox.checkForm(moduleuserid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop checkbox = new NewAdbooking.classesoracle.pop();

                //CheckBox CheckBox7 = (CheckBox)DataGrid1.Items[0].FindControl("CheckBox7");

                ds1 = checkbox.checkForm();
                //  ds1 = checkbox.checkForm(moduleuserid);
            }
            else
            {
                NewAdbooking.classmysql.pop checkbox = new NewAdbooking.classmysql.pop();

                //CheckBox CheckBox7 = (CheckBox)DataGrid1.Items[0].FindControl("CheckBox7");

                ds1 = checkbox.checkForm();
                //  ds1 = checkbox.checkForm(moduleuserid);
            }
            abc = 0;
            abc = ds1.Tables[0].Rows.Count;
        }
        //if (e.Item.Cells[8].Text != "No. of Back Days" && e.Item.Cells[8].Text != "&nbsp")
        //{
        //    e.Item.Cells[8].Text = "<input type='text' value=" + e.Item.Cells[8].Text + " >";
        //}
       
        if ((e.Item.ItemType != ListItemType.Header) && (e.Item.ItemType != ListItemType.Footer))
        {
           
            DataSet dl = new DataSet();
           

            string form = dspublic.Tables[0].Rows[j].ItemArray[0].ToString();
            
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop checkbox1 = new NewAdbooking.Classes.pop();
               // dl = checkbox1.checkPrevuser(Session["userid"].ToString());
                dl = checkbox1.checkPrevuser(moduleuserid, form);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop checkbox1 = new NewAdbooking.classesoracle.pop();
                //dl = checkbox1.checkPrevuser(Session["userid"].ToString());
                dl = checkbox1.checkPrevuser(moduleuserid, form);
            }
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            //{
            //    string procedureName = "Wesp_Modulechekboxuser_Wesp_Modulechekboxuser_p";
            //    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //    string[] parameterValueArray = { moduleuserid, form };
            //    dl = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            //}
            else
            {
                NewAdbooking.classmysql.pop checkbox1 = new NewAdbooking.classmysql.pop();
                //dl = checkbox1.checkPrevuser(Session["userid"].ToString());
                dl = checkbox1.checkPrevuser(moduleuserid, form);
            }
            
           //if (ds.Tables[0].Rows.Count - 1 <= j)
           // //if ( j<=10)
           // {
                
                //e.Item.Cells[0].Text = "<input type=\"checkbox\" name=\"id\" value=\""+ e.Item.Cells[2].Text +"\">";	
                string str = "CheckBox7" + j;
                
                string str1 = "CheckBox1" + j;
                string str2 = "CheckBox2" + j;
                string str3 = "CheckBox3" + j;
                string str4 = "CheckBox4" + j;
                if (admin == "yes" && userhome == "Agency" && dl.Tables[0].Rows.Count > 0)
                {
                   
                    if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "0")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' disabled onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' width='5px' disabled id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox' width='5px' disabled id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' width='5px' disabled id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' width='5px' disabled id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";
                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "1")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "2")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "3")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }

                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "4")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "5")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "6")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "7")
                    {
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "8")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'disabled  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "9")
                    {
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'disabled  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "10")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "11")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "12")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "13")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "14")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "15")
                    {
                        e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                        e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                        e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";

                    }
                    

                }
                else
                {
                    e.Item.Cells[0].Text = "<input type='checkbox' onclick='chechedcolumn(\"" + str + "\",\"" + j + "\");' width='5px' id=" + str + "  value=" + form + "  />";
                    e.Item.Cells[2].Text = "<input type='checkbox' width='5px' id=" + str1 + "    value=" + e.Item.Cells[1].Text + "  />";
                    e.Item.Cells[3].Text = "<input type='checkbox' width='5px' id=" + str2 + "   value=" + e.Item.Cells[1].Text + "  />";
                    e.Item.Cells[4].Text = "<input type='checkbox' width='5px' id=" + str3 + "  value=" + e.Item.Cells[1].Text + "  />";
                    e.Item.Cells[5].Text = "<input type='checkbox' width='5px' id=" + str4 + "  value=" + e.Item.Cells[1].Text + "  />";
                    
                }


               

                //				DataSet ds=new DataSet();
                //				ds=checkbox.checkPrev();

                int l;
              

                        if (dl.Tables[0].Rows.Count != 0)
                        {
                            //if (j < abc && dl.Tables[0].Rows.Count>j)
                            //{

                                if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "1")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "2")
                                {
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "3")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "4")
                                {
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "5")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "6")
                                {
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "7")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";

                                }

                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "8")
                                {
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "9")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "10")
                                {
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "11")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "12")
                                {
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "13")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "14")
                                {
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }
                                else if (dl.Tables[0].Rows[0].ItemArray[0].ToString() == "15")
                                {
                                    e.Item.Cells[2].Text = "<input type='checkbox' checked='true' width='5px' id=" + str1 + "    />";
                                    e.Item.Cells[3].Text = "<input type='checkbox' checked='true' width='5px' id=" + str2 + "    />";
                                    e.Item.Cells[4].Text = "<input type='checkbox' checked='true' width='5px' id=" + str3 + "    />";
                                    e.Item.Cells[5].Text = "<input type='checkbox' checked='true' width='5px' id=" + str4 + "    />";

                                }

                            //}
                        }
                        else
                        {
                            e.Item.Cells[2].Text = "<input type='checkbox'  width='5px' id=" + str1 + "    />";
                            e.Item.Cells[3].Text = "<input type='checkbox'  width='5px' id=" + str2 + "    />";
                            e.Item.Cells[4].Text = "<input type='checkbox'  width='5px' id=" + str3 + "    />";
                            e.Item.Cells[5].Text = "<input type='checkbox'  width='5px' id=" + str4 + "    />";



                        }
                        if (dl.Tables[0].Rows.Count != 0)
                            e.Item.Cells[8].Text = "<input type='text' style='WIDTH: 15px' id='txtid" + k + "' value=" + dl.Tables[0].Rows[0].ItemArray[10].ToString() + " >";
                        else
                            e.Item.Cells[8].Text = "<input type='text' style='WIDTH: 15px' id='txtid" + k + "' value='' >";    
                        k++;
                        //}
                    //}
               // }
                j++;


            //}



        }


    }


    private void btnshow_Click(object sender, System.EventArgs e)
    {
        //			//band();
        //			string prev;
        //			string formname;
        //			int priv1;
        //			int priv2;
        //			int priv3;
        //			int priv;
        //			int  k;
        //
        //						for(k = 0; k<= DataGrid1.Items.Count-1 ;k++)
        //						{ 
        //							NewAdbooking.Classes.pop databindbank=new NewAdbooking.Classes.pop();
        //							DataSet ds=new DataSet();
        //
        //							ds=databindbank.MasterPrevSel();
        //							//formname=ds.Tables[0].Rows[k].ItemArray[0].ToString();
        //							string str="CheckBox7" + j;
        //							CheckBox check1 = (CheckBox)DataGrid1.Items[k].FindControl("CheckBox1");
        //							CheckBox check2 = (CheckBox)DataGrid1.Items[k].FindControl("CheckBox2");
        //							CheckBox check3 = (CheckBox)DataGrid1.Items[k].FindControl("CheckBox3");
        //							CheckBox check4=(CheckBox)DataGrid1.Items[0].FindControl("CheckBox7");
        //						
        //							
        //							
        //							formname=ds.Tables[0].Rows[k].ItemArray[0].ToString();
        //							NewAdbooking.Classes.pop insertpriv=new NewAdbooking.Classes.pop();
        //							DataSet da=new DataSet();
        //							if (check4.Checked == true) 
        //							{
        //								prev="1";
        //								
        //								da=insertpriv.MasterPrev(prev,formname);
        //							}
        //							else
        //							{
        //								prev="0";
        //							da=insertpriv.MasterPrev(prev,formname);
        //							}
        //			
        //							
        //											
        //							if (check1.Checked == true) 
        //							priv1 = 1;
        //							else
        //							priv1 = 0;
        //							if (check2.Checked == true) 
        //							priv2 = 2;
        //							else
        //							priv2 = 0;
        //							if (check3.Checked == true) 
        //							priv3 = 4;
        //							else
        //							priv3 = 0;
        //							priv=0;
        //							priv = priv1 + priv2 + priv3;
        //							
        //
        //							formname=ds.Tables[0].Rows[k].ItemArray[0].ToString();
        //							NewAdbooking.Classes.pop updatebut=new NewAdbooking.Classes.pop();
        //							da=updatebut.MasterPrevbut(priv.ToString(),formname);
        //
        //						}
    }


     

    [Ajax.AjaxMethod]
    public void insertgrid(string name, string prev, string formname, string modulename, string userid, string compcode, string division, string moduleno, string formid, string rostatusval, string modelcode)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop insertpriv = new NewAdbooking.Classes.pop();
            da = insertpriv.insMasterPrev(name, prev, formname, modulename, userid, compcode, division, moduleno, formid, rostatusval);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop insertpriv = new NewAdbooking.classesoracle.pop();
            da = insertpriv.insMasterPrev(name, prev, formname, modulename, userid, compcode, division, moduleno, formid, rostatusval, modelcode);
        }
        //else 
        //{
        //    string procedureName = "Wesp_insertModuleDetailchk";
        //    string[] parameterValueArray = { prev, userid, formname, compcode, division, modulename, moduleno, rostatusval, modelcode };
        //    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
        //    da = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        //}
        else
        {
            NewAdbooking.classmysql.pop insertpriv = new NewAdbooking.classmysql.pop();
            da = insertpriv.insMasterPrev(name, prev, formname, modulename, userid, compcode, division, moduleno, formid, rostatusval, modelcode);
        }

     /*   NewAdbooking.Classes.pop databindbank = new NewAdbooking.Classes.pop();
        DataSet ds = new DataSet();

        ds = databindbank.MasterPrevSel(userid, compcode);
        return ds;*/


    }

    [Ajax.AjaxMethod]
    public DataSet insertgridchk(string name, string formname, string compcode, string userid)
    {

      /*  NewAdbooking.Classes.pop insertpriv = new NewAdbooking.Classes.pop();
        DataSet da = new DataSet();

        da = insertpriv.MasterPrev(name, formname, compcode, userid);*/
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindbank = new NewAdbooking.Classes.pop();
            ds = databindbank.MasterPrevSelchk(userid, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindbank = new NewAdbooking.classesoracle.pop();
            ds = databindbank.MasterPrevSelchk(userid, compcode);
        }
        else
        {
            NewAdbooking.classmysql.pop databindbank = new NewAdbooking.classmysql.pop();
            ds = databindbank.MasterPrevSelchk(userid, compcode);
        }

        return ds;


    }

    [Ajax.AjaxMethod]
    public void updateform(string name1, string formname1, string compcode, string userid)
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop insertpriv1 = new NewAdbooking.Classes.pop();
            da = insertpriv1.MasterPrevbut(name1, formname1, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop insertpriv1 = new NewAdbooking.classesoracle.pop();
            da = insertpriv1.MasterPrevbut(name1, formname1, compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.pop insertpriv1 = new NewAdbooking.classmysql.pop();
            da = insertpriv1.MasterPrevbut(name1, formname1, compcode, userid);
        }

    }

    [Ajax.AjaxMethod]
    public DataSet form1(string userid, string moduleno)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop databindbank = new NewAdbooking.Classes.pop();
            ds = databindbank.MasterPrevSelect(userid, moduleno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop databindbank = new NewAdbooking.classesoracle.pop();
            ds = databindbank.MasterPrevSelect(userid, moduleno);
        }
        else
        {
            NewAdbooking.classmysql.pop databindbank = new NewAdbooking.classmysql.pop();
            ds = databindbank.MasterPrevSelect(userid, moduleno);
        }

        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet insform(string moduleno)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop formins = new NewAdbooking.Classes.pop();
            ds = formins.inscheckForm(moduleno);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop formins = new NewAdbooking.classesoracle.pop();
            ds = formins.inscheckForm(moduleno);
        }
        else
        {
            NewAdbooking.classmysql.pop formins = new NewAdbooking.classmysql.pop();
            ds = formins.inscheckForm(moduleno);
        }

        return ds;

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public void loginsert(string userid, string ip)
    {
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','Priveledge Master','','Priveledge Master Change','" + userid + ' ' + dconnect.getusername(userid);
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip + "')";
        dconnect.executenonquery1(sqldd);
    }



    //		public void BindMastprevdisplay()
    //		{
    //
    //			NewAdbooking.Classes.pop MastPrev=new NewAdbooking.Classes.pop();
    //			DataSet ds1=new DataSet();
    //			ds1=MastPrev.MastPrevDisp();
    //
    //			drpuserid.Items.Clear();
    //			ListItem li1;
    //			li1=new ListItem();
    //			li1.Text="Select";
    //			li1.Value="0";
    //			li1.Selected =true;
    //			drpuserid.Items.Add(li1);
    //
    //			//ds=MastPrev.MastPrevDisp();
    //			if(ds1.Tables[0].Rows.Count>0)
    //			{
    //				for(int i=0;i<ds1.Tables[0].Rows.Count;i++)
    //				{
    //					ListItem li;
    //					li=new ListItem();
    //					li.Text=ds1.Tables[0].Rows[i].ItemArray[0].ToString();
    //					li.Value=ds1.Tables[0].Rows[i].ItemArray[1].ToString();
    //					//user=li.Value=ds1.Tables[0].Rows[i].ItemArray[1].ToString();
    //					//li1.Selected =true;
    //					drpuserid.Items.Add(li);
    //
    //				}
    //				drpuserid.DataBind();
    //			}
    //			
    //			//band2(user);
    //            
    //
    //		}

    private void drpuserid_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }

    private void hiddenmodulename_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void hiddenuser_ServerChange(object sender, System.EventArgs e)
    {

    }

    private void hiddenusername_ServerChange(object sender, System.EventArgs e)
    {

    }









}