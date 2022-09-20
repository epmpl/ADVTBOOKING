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

    public partial class agentpaymode : System.Web.UI.Page
    {
        string userid, compcode, sel;
        protected void Page_Load(object sender, EventArgs e)
        {
            string show;
            string agencode, agencysubcode, saurabh;
            if (Session["compcode"] != null)
            {
                hiddencomcode.Value = Session["compcode"].ToString();
                compcode = Session["compcode"].ToString();
                hiddenuserid.Value = Session["userid"].ToString();
                userid = Session["userid"].ToString();
                show = Request.QueryString["show"].ToString();
                hiddenshow.Value = show;
            }
            else
            {
                Response.Write("<script>alert('Your session has been expired');window.close();</script>");
                return;
            }

            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

            hiddenagevcode.Value = Request.QueryString["agecode"].ToString();

            saurabh=Request.QueryString["saurabh"].ToString();

            string execute = Request.QueryString["akhil"].ToString();

            if (show == "0")
            {
                saurabh = "2";

            }
            hiddenagensubcode.Value = Request.QueryString["agencysubcode"].ToString();
            Ajax.Utility.RegisterTypeForAjax(typeof(agentpaymode));




            agencode = Request.QueryString["agecode"].ToString();
            agencysubcode = Request.QueryString["agencysubcode"].ToString();

            if (agencode == "")
            {

                Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

                return;
            }

            if (agencysubcode == "")
            {

                Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

                return;
            }

            btnSubmit.Attributes.Add("OnClick", "javascript:return paymodesubmit();");
            btnUpdate.Attributes.Add("OnClick", "javascript:return paymodeupdate();");
            if (!Page.IsPostBack)
            {
                if (Session["paymodeagency"] == null)
                {
                    if (saurabh == "1")
                    {
                        radio_bind();
                        //btnSubmit.Style.Add("display", "block");
                        btnSubmit.Visible = true;
                        btnSubmit.Enabled = true;

                        btnUpdate.Visible = false;
                        btnUpdate.Enabled = false;
                        //btnSubmit.Enabled = true;
                    }
                    else
                    {

                        radio_bind1();
                        if (saurabh == "0")
                        {
                            btnSubmit.Visible = false;
                            btnSubmit.Enabled = false;

                            btnUpdate.Visible = true;
                            btnUpdate.Enabled = true;
                        }
                        else if (saurabh == "2")
                        {
                            btnSubmit.Visible = false;
                            btnSubmit.Enabled = false;
                            btnUpdate.Enabled = false;
                            chklistsubmit.Enabled = false;
                            //ScriptManager.RegisterClientScriptBlock(this, typeof(agentpaymode), "ss", "exec_agency();", true);


                        }
                    }
                }
                else
                {
                    DataSet sap = new DataSet();
                    //sap = (DataSet)Session["paymodeagency"].ToString();
                    hiddenval.Value = Session["paymodeagency"].ToString();
                    radio_bind();
                    btnSubmit.Visible = false;
                    btnSubmit.Enabled = false;
                   
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
            //this.hiddencomcode.ServerChange += new System.EventHandler(this.hiddencomcode_ServerChange);
            //this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion



        [Ajax.AjaxMethod]
        public void insertpaymode(string agencycode, string compcode, string userid, string agencysubcode,  string str)
        {

            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop CustCode = new NewAdbooking.Classes.pop();
                CustCode.insertpay(agencycode, compcode, userid, agencysubcode, str);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop CustCode = new NewAdbooking.classesoracle.pop();
                CustCode.insertpay(agencycode, compcode, userid, agencysubcode, str);
            }
            else
            {
                NewAdbooking.classmysql.pop CustCode = new NewAdbooking.classmysql.pop();
                CustCode.insertpay(agencycode, compcode, userid, agencysubcode, str);
            }
            
        }

        [Ajax.AjaxMethod]

        public DataSet update(string cash, string credit, string bank, string code, string compcode, string userid, string agencode, string agencysubcode)
        {

            NewAdbooking.Classes.pop update = new NewAdbooking.Classes.pop();
            DataSet da = new DataSet();
            //da=update.payinsert(cash,credit,bank,code, compcode,userid,agencode,agencysubcode);
            return da;
        }

        [Ajax.AjaxMethod]
        public DataSet delete1(string cash, string credit, string bank, string code, string compcode, string userid, string agencode, string agencysubcode)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop delete = new NewAdbooking.Classes.pop();

                da = delete.paydelete(cash, credit, bank, code, compcode, userid, agencode, agencysubcode);
                return da;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop delete = new NewAdbooking.classesoracle.pop();
                da = delete.paydelete(cash, credit, bank, code, compcode, userid, agencode, agencysubcode);
                return da;
            }
            else
            {
                NewAdbooking.classmysql.pop delete = new NewAdbooking.classmysql.pop();
                da = delete.paydelete(cash, credit, bank, code, compcode, userid, agencode, agencysubcode);
                return da;
            }

        }



        [Ajax.AjaxMethod]
        public void updatepaymode(string agencycode, string compcode, string userid, string agencysubcode, string str)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop update = new NewAdbooking.Classes.pop();

                da = update.payinsert(agencycode, compcode, userid, agencysubcode, str);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop update = new NewAdbooking.classesoracle.pop();
                da = update.payinsert(agencycode, compcode, userid, agencysubcode, str);
            }
            else
            {
                NewAdbooking.classmysql.pop update = new NewAdbooking.classmysql.pop();
                da = update.payinsert(agencycode, compcode, userid, agencysubcode, str);
            }
        }


        [Ajax.AjaxMethod]
        public DataSet chk(string hiddencomcode, string hiddenuserid, string hiddenagevcode, string hiddenagensubcode)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Master chk = new NewAdbooking.Classes.Master();

                ds = chk.chkshow(hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode);
                
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master chk = new NewAdbooking.classesoracle.Master();
                ds = chk.chkshow(hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode);
            }
            else
            {
                NewAdbooking.classmysql.Master chk = new NewAdbooking.classmysql.Master();
                ds = chk.chkshow(hiddencomcode, hiddenuserid, hiddenagevcode, hiddenagensubcode);
                return ds;
            }
            return ds;
        }


        [Ajax.AjaxMethod]
        public DataSet filldata(string hiddencomcode, string hiddenuserid)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Master chk = new NewAdbooking.Classes.Master();

                ds = chk.filldatapay(hiddencomcode, hiddenuserid);
                
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master chk = new NewAdbooking.classesoracle.Master();
                ds = chk.filldatapay(hiddencomcode, hiddenuserid);
            }
            else
            {
                //NewAdbooking.classmysql.Master chk = new NewAdbooking.classmysql.Master();
                //ds = chk.filldatapay(hiddencomcode, hiddenuserid);
                //return ds;
            }
            return ds;

        }

        [Ajax.AjaxMethod]
        public void AgencyPayModeInsert(string compcode, string agecode, string agencysubcode, string userid, string MyString)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Master chk = new NewAdbooking.Classes.Master();

                //ds = CustCode.getData(custcode, userid, compcode);
                ds = chk.chkshow(compcode, userid, agecode, agencysubcode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chk.agentpayinsert(compcode, agecode, agencysubcode, userid, 1, MyString);
                }
                else
                {
                    chk.agentpayinsert(compcode, agecode, agencysubcode, userid, 0, MyString);
                }
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master chk = new NewAdbooking.classesoracle.Master();
                ds = chk.chkshow(compcode, userid, agecode, agencysubcode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chk.agentpayinsert(compcode, agecode, agencysubcode, userid, 1, MyString);
                }
                else
                {
                    chk.agentpayinsert(compcode, agecode, agencysubcode, userid, 0, MyString);
                }
            }
            else
            {
                //NewAdbooking.classmysql.Master chk = new NewAdbooking.classmysql.Master();
                //ds = chk.chkshow(compcode, userid, agecode, agencysubcode);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    chk.agentpayinsert(compcode, agecode, agencysubcode, userid, 1, MyString);
                //}
                //else
                //{
                //    chk.agentpayinsert(compcode, agecode, agencysubcode, userid, 0, MyString);
                //}
            }


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }

        public void radio_bind()
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop radiobind = new NewAdbooking.Classes.pop();

                ds = radiobind.filldatapay(compcode, userid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop radiobind = new NewAdbooking.classesoracle.pop();
                ds = radiobind.filldatapay(compcode, userid);
            }
            else
            {
                NewAdbooking.classmysql.pop radiobind = new NewAdbooking.classmysql.pop();
                ds = radiobind.filldatapay(compcode, userid);
            }
          
           
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
            {
                ListItem ls = new ListItem();
                ls.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                ls.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                chklistsubmit.Items.Add(ls);


                //Checking 4 user has selected any value  or not
                string[] myvalue;
                if (Session["MySelectedValue"] != null)
                {
                    myvalue = Session["MySelectedValue"].ToString().Split(',');
                    for (int k = 0; k < myvalue.Length - 1; k++)
                    {
                        if (ls.Value == myvalue[k])
                        {
                            chklistsubmit.Items[i].Selected = true;
                        }

                    }

                }

            }
            
            // chklistsubmit.DataSource = ds.Tables[0];
            //chklistsubmit.DataTextField = "Payment_Mode_Name";
            //chklistsubmit.DataValueField = "Pay_Mode_Code";
            //chklistsubmit.DataBind();

        }
        public void radio_bind1()
        {
            //chklistupdate.Enabled = false;
            DataSet ds1 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop chk1 = new NewAdbooking.Classes.pop();

                ds1 = chk1.showchk(compcode, userid, hiddenagevcode.Value, hiddenagensubcode.Value);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop chk1 = new NewAdbooking.classesoracle.pop();
                ds1 = chk1.showchk(compcode, userid, hiddenagevcode.Value, hiddenagensubcode.Value);
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "showagencypay_showagencypay_p";
                string[] parameterValueArray = { compcode, userid, hiddenagevcode.Value, hiddenagensubcode.Value };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            //else
            //{
            //    NewAdbooking.classmysql.pop chk1 = new NewAdbooking.classmysql.pop();
            //    ds1 = chk1.showchk(compcode, userid, hiddenagevcode.Value, hiddenagensubcode.Value);
            //}
         
            if (ds1.Tables[0].Rows.Count > 0)
            {
                //                sel = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                sel = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
                hiddenval.Value = sel;
            }
            else
            {
                sel = "";
                hiddenval.Value = sel;
            }

            string[] myvalue;
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop radiobind = new NewAdbooking.Classes.pop();

                ds = radiobind.filldatapay(compcode, userid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop radiobind = new NewAdbooking.classesoracle.pop();
                ds = radiobind.filldatapay(compcode, userid);
            }
            else
            {
                NewAdbooking.classmysql.pop radiobind = new NewAdbooking.classmysql.pop();
                ds = radiobind.filldatapay(compcode, userid);
            }
          
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem ls = new ListItem();
                
                ls.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                ls.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                chklistsubmit.Items.Add(ls);


                //Checking 4 user has selected any value  or not
                if (sel != "")
                {
                    myvalue = sel.ToString().Split(',');
                    for (int k = 0; k < myvalue.Length - 1; k++)
                    {
                        if (ls.Value == myvalue[k])
                        {
                            chklistsubmit.Items[i].Selected = true;
                        }

                    }

                }
               
                
            }


            //chklistupdate.DataSource = ds.Tables[0];
            //chklistupdate.DataTextField = "Payment_Mode_Name";
            //chklistupdate.DataValueField = "Pay_Mode_Code";
            //chklistupdate.DataBind();


            

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Session["MySelectedValue"] = null;
            string mynewvalue = "";
            for (int k = 0; k < chklistsubmit.Items.Count; k++)
            {
                if (chklistsubmit.Items[k].Selected == true)
                {
                    mynewvalue = mynewvalue+chklistsubmit.Items[k].Value.ToString() + ",";

                }
            }


            Session["MySelectedValue"] = mynewvalue;
            Session["paymodeagency"] = chklistsubmit.SelectedValue.ToString();
            hiddenval.Value = Session["paymodeagency"].ToString();
            
            btnSubmit.Enabled = false;

        }


        protected void AspNetMessageBox(string strMessage)
        {
            //strMessage = adminResource.GetStringFromResource(strMessage);
            string strAlert = "";
            strAlert = "alert('" + strMessage + "')";
            ScriptManager.RegisterClientScriptBlock(this, typeof(agentpaymode), "ShowAlert", strAlert, true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {


            Session["MySelectedValue"] = null;
            string mynewvalue = "";
            for (int k = 0; k < chklistsubmit.Items.Count; k++)
            {
                if (chklistsubmit.Items[k].Selected == true)
                {
                    mynewvalue = mynewvalue + chklistsubmit.Items[k].Value.ToString() + ",";

                }
            }



            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Master chk = new NewAdbooking.Classes.Master();
                ds = chk.chkshow(hiddencomcode.Value.Trim(), hiddenuserid.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chk.agentpayinsert(hiddencomcode.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim(), hiddenuserid.Value.Trim(), 1, mynewvalue);
                }
                else
                {
                    chk.agentpayinsert(hiddencomcode.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim(), hiddenuserid.Value.Trim(), 0, mynewvalue);
                }
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master chk = new NewAdbooking.classesoracle.Master();
                ds = chk.chkshow(hiddencomcode.Value.Trim(), hiddenuserid.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chk.agentpayinsert(hiddencomcode.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim(), hiddenuserid.Value.Trim(), 1, mynewvalue);
                }
                else
                {
                    chk.agentpayinsert(hiddencomcode.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim(), hiddenuserid.Value.Trim(), 0, mynewvalue);
                }
            }
            else
            {
                NewAdbooking.classmysql.Master chk = new NewAdbooking.classmysql.Master();
                ds = chk.chkshow(hiddencomcode.Value.Trim(), hiddenuserid.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chk.agentpayinsert(hiddencomcode.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim(), hiddenuserid.Value.Trim(), 1, mynewvalue);
                }
                else
                {
                    chk.agentpayinsert(hiddencomcode.Value.Trim(), hiddenagecode.Value.Trim(), hiddenagencycode.Value.Trim(), hiddenuserid.Value.Trim(), 0, mynewvalue);
                }
            }
          
        
            //ds = CustCode.getData(custcode, userid, compcode);
           
          



            Session["MySelectedValue"] = mynewvalue;
            Session["paymodeagency"] = chklistsubmit.SelectedValue.ToString();
            hiddenval.Value = Session["paymodeagency"].ToString();
            btnUpdate.Enabled = false;
        }
}
