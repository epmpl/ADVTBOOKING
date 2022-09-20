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

public partial class ClientPaymode : System.Web.UI.Page
{
    string show,compcode,userid,sel,n_m;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //Registering the Class file of Ajax Type
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            hiddencomcode.Value = Session["compcode"].ToString();
            compcode = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            userid = Session["userid"].ToString();
            show = Request.QueryString["show"].ToString();
            hiddenshow.Value = show;



        }


        hiddenclientcode.Value = Request.QueryString["ClCode"].ToString();

        if (hiddenclientcode.Value == "")
        {
            Response.Write("<script>alert('You Should Enter The Customer Code First');window.close();</script>");
            return;
        }
        show = Request.QueryString["show"].ToString();
        hiddenshow.Value = show;
        n_m = Request.QueryString["n_m"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(ClientPaymode));

        DataSet ds = new DataSet();

        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        userid = Session["userid"].ToString();


        btnSubmit.Attributes.Add("OnClick", "javascript:return ClientPayModeSubmit();");
        btnUpdate.Attributes.Add("OnClick", "javascript:return ClientPayModeUpdate();");
        btnclose.Attributes.Add("OnClick", "javascript:return closewindow();");
        btnclose1.Attributes.Add("OnClick", "javascript:return closewindow();");


        if (hiddencomcode.Value == "" || hiddenuserid.Value == null)
        {
            Response.Write("<script>'alert('your Session has been expired Please Relogin')';window.close(); </script>");
            return;
        }

        //NewAdbooking.Classes.pop CustCode = new NewAdbooking.Classes.pop();
        //ds = CustCode.getData(hiddenclientcode.Value, hiddenuserid.Value, hiddencomcode.Value);


        if (!Page.IsPostBack)
        {
            if (Session["client_pay"] == null)
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
                hiddenval.Value = Session["client_pay"].ToString();
                radio_bind();
                //for (int i = 0; i < rdolistsubmit.Items.Count; i++)
                //{
                //    if (Session["client_pay"].ToString() == rdolistsubmit.Items[i].Value)
                //    {
                //        rdolistsubmit.SelectedValue = rdolistsubmit.Items[i].ToString();
                //        break;
                //    }
                //}
                btnSubmit.Enabled = false;
            }
           /* if (ds.Tables[0].Rows.Count > 0)
            {
                string str = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                string str1 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                string str2 = ds.Tables[0].Rows[0].ItemArray[2].ToString();

                if ((str == "" && str1 == "" && str2 == "") || (str == null && str1 == null && str2 == null))
                {
                    /*chklstUpdate.Enabled = false;
                    btnUpdate.Enabled= false;
					
                    chklstSubmit.Enabled = true;
                    btnSubmit.Enabled = true;
                }

                else
                {
                    /*if (str == "Cash")
                    {
                        chklstUpdate.Items[0].Selected = true;
                    }
                    if (str1 == "Credit")
                    {
                        chklstUpdate.Items[1].Selected = true;
                    }
                    if (str2 == "Bank")
                    {
                        chklstUpdate.Items[2].Selected = true;
                    }

                    chklstSubmit.Attributes.Add("disabled", "disabled");
                    btnUpdate.Enabled = true;
                    btnSubmit.Enabled = false;
                }
            }
            else
            {

                //chklstUpdate.Attributes.Add("disabled", "disabled");
                btnUpdate.Enabled = false;
                btnSubmit.Enabled = true;
            }
            if (show == "1" || show == "2")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;

                }
                else
                {
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                btnSubmit.Enabled = false;
                btnUpdate.Enabled = false;
            }*/
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

    public void radio_bind()
    {
        DataSet ds= new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMasterpopup radiobind = new NewAdbooking.Classes.ClientMasterpopup();
            ds = radiobind.filldatapay(compcode, userid);
            rdolistsubmit.DataSource = ds.Tables[0];
            rdolistsubmit.DataTextField = "Payment_Mode_Name";
            rdolistsubmit.DataValueField = "Pay_Mode_Code";
            rdolistsubmit.DataBind();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMasterpopup radiobind = new NewAdbooking.classesoracle.ClientMasterpopup();
            ds = radiobind.filldatapay(compcode, userid);
            rdolistsubmit.DataSource = ds.Tables[0];
            rdolistsubmit.DataTextField = "Payment_Mode_Name";
            rdolistsubmit.DataValueField = "Pay_Mode_Code";
            rdolistsubmit.DataBind();
        }
        else
        {
            NewAdbooking.classmysql.ClientMasterpopup radiobind = new NewAdbooking.classmysql.ClientMasterpopup();
            ds = radiobind.filldatapay(compcode, userid);
            rdolistsubmit.DataSource = ds.Tables[0];
            rdolistsubmit.DataTextField = "Payment_Mode_Name";
            rdolistsubmit.DataValueField = "Pay_Mode_Code";
            rdolistsubmit.DataBind();
        }
    }
    public void radio_bind1()
    {
         DataSet ds = new DataSet();
         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
         {
             NewAdbooking.Classes.ClientMasterpopup radiobind = new NewAdbooking.Classes.ClientMasterpopup();
             ds = radiobind.filldatapay(compcode, userid);
             rdolistupdate.DataSource = ds.Tables[0];
             rdolistupdate.DataTextField = "Payment_Mode_Name";
             rdolistupdate.DataValueField = "Pay_Mode_Code";
             //rdolistupdate.DataBind();
         }
         else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
         {
             NewAdbooking.classesoracle.ClientMasterpopup radiobind = new NewAdbooking.classesoracle.ClientMasterpopup();
             ds = radiobind.filldatapay(compcode, userid);
             rdolistupdate.DataSource = ds.Tables[0];
             rdolistupdate.DataTextField = "Payment_Mode_Name";
             rdolistupdate.DataValueField = "Pay_Mode_Code";
             rdolistupdate.DataBind();
         }
         else
         {
             NewAdbooking.classmysql.ClientMasterpopup radiobind = new NewAdbooking.classmysql.ClientMasterpopup();
             ds = radiobind.filldatapay(compcode, userid);
             rdolistupdate.DataSource = ds.Tables[0];
             rdolistupdate.DataTextField = "Payment_Mode_Name";
             rdolistupdate.DataValueField = "Pay_Mode_Code";
             rdolistupdate.DataBind();
         }
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMaster chk1 = new NewAdbooking.Classes.ClientMaster();
            ds1 = chk1.chkshow(compcode, userid, hiddenclientcode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMaster chk1 = new NewAdbooking.classesoracle.ClientMaster();
            ds1 = chk1.chkshow(compcode, userid, hiddenclientcode.Value);
        }
        else
        {
            NewAdbooking.classmysql.ClientMaster chk1 = new NewAdbooking.classmysql.ClientMaster();
            ds1 = chk1.chkshow(compcode, userid, hiddenclientcode.Value);
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            sel = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            hiddenval.Value = sel;
        }
        else
        {
            sel = "";
            hiddenval.Value = sel;
        }

        string[] myvalue;
        DataSet ds2 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop radiobind = new NewAdbooking.Classes.pop();

            ds2 = radiobind.filldatapay(compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop radiobind = new NewAdbooking.classesoracle.pop();
            ds2 = radiobind.filldatapay(compcode, userid);
        }
        else
        {
            NewAdbooking.classmysql.pop radiobind = new NewAdbooking.classmysql.pop();
            ds2 = radiobind.filldatapay(compcode, userid);
        }

        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            ListItem ls = new ListItem();

            ls.Text = ds2.Tables[0].Rows[i].ItemArray[0].ToString();
            ls.Value = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
            rdolistupdate.Items.Add(ls);


            //Checking 4 user has selected any value  or not
            if (sel != "")
            {
                myvalue = sel.ToString().Split(',');
                for (int k = 0; k < myvalue.Length ; k++)
                {
                    if (ls.Value == myvalue[k])
                    {
                        rdolistupdate.Items[i].Selected = true;
                    }

                }

            }


        }  //Response.Write("<script>'to_check();'</script>");

    }

    //[Ajax.AjaxMethod]
    //public void ClientPayModeInsert(string compcode, string custcode, string userid, string MyString)
    //{
    //    //string[] MyString = str;
    //    //for (int i = 0; i <= MyString.Length - 1; i++)
    //    //{
    //    //    if (MyString[i] == "null")
    //    //    {
    //    //        MyString[i] = "";
    //    //    }
    //    //}
    //    //DataSet ds = new DataSet();

    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.ClientMasterpopup CustCode = new NewAdbooking.Classes.ClientMasterpopup();
    //        CustCode.insertData(compcode, custcode, userid, 1, MyString);// CustCode.getData(custcode, userid, compcode);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.ClientMasterpopup CustCode = new NewAdbooking.classesoracle.ClientMasterpopup();
    //        CustCode.insertData(compcode, custcode, userid, 1, MyString); //ds = CustCode.getData(custcode, userid, compcode);
    //    }
    //    else
    //    {
    //        NewAdbooking.classmysql.ClientMasterpopup CustCode = new NewAdbooking.classmysql.ClientMasterpopup();
    //        CustCode.insertData(compcode, custcode, userid, 1, MyString); //ds = CustCode.getData(custcode, userid, compcode);
    //    }


    //   // ===============================7/01/2009===============================//
    //    //if (ds.Tables[0].Rows.Count > 0)
    //    //{
    //    //    CustCode.insertData(compcode, custcode, userid, 1, MyString);
    //    //}
    //    //else
    //    //{
    //    //    CustCode.insertData(compcode, custcode, userid, 0, MyString);
    //    //}
    //    //===========================================================================//
    //}
    [Ajax.AjaxMethod]
    public DataSet chk(string compcode, string userid, string custcode)
    {
          DataSet ds = new DataSet();
          if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          {
              NewAdbooking.Classes.ClientMaster chk = new NewAdbooking.Classes.ClientMaster();
              ds = chk.chkshow(compcode, userid, custcode);
              return ds;
          }
          else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          {
              NewAdbooking.classesoracle.ClientMaster chk = new NewAdbooking.classesoracle.ClientMaster();
              ds = chk.chkshow(compcode, userid, custcode);
              return ds;
          }
          else
          {
              NewAdbooking.classmysql.ClientMaster chk = new NewAdbooking.classmysql.ClientMaster();
              ds = chk.chkshow(compcode, userid, custcode);
              return ds;
          }

    }
        

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["MySelectedValue"] = null;
        string mynewvalue = "";
        for (int k = 0; k < rdolistsubmit.Items.Count; k++)
        {
            if (rdolistsubmit.Items[k].Selected == true)
            {
                mynewvalue = mynewvalue + rdolistsubmit.Items[k].Value.ToString() + ",";

            }
        }
        Session["MySelectedValue"] = mynewvalue;
        Session["client_pay"] = rdolistsubmit.SelectedValue.ToString();
        hiddenval.Value = Session["client_pay"].ToString();
        btnSubmit.Enabled = false;
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        Session["MySelectedValue"] = null;
        string mynewvalue = "";
        for (int k = 0; k < rdolistupdate.Items.Count; k++)
        {
            if (rdolistupdate.Items[k].Selected == true)
            {
                mynewvalue = mynewvalue + rdolistupdate.Items[k].Value.ToString() + ",";

            }
        }



        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ClientMaster chk1 = new NewAdbooking.Classes.ClientMaster();
            ds1 = chk1.chkshow(compcode, userid, hiddenclientcode.Value);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                NewAdbooking.Classes.ClientMasterpopup CustCode = new NewAdbooking.Classes.ClientMasterpopup();
                CustCode.insertData(compcode, hiddenclientcode.Value, userid, 1, mynewvalue);
            }
            else
            {
                NewAdbooking.Classes.ClientMasterpopup CustCode = new NewAdbooking.Classes.ClientMasterpopup();
                CustCode.insertData(compcode, hiddenclientcode.Value, userid, 0, mynewvalue);
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ClientMaster chk1 = new NewAdbooking.classesoracle.ClientMaster();
            ds1 = chk1.chkshow(compcode, userid, hiddenclientcode.Value);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                NewAdbooking.classesoracle.ClientMasterpopup CustCode = new NewAdbooking.classesoracle.ClientMasterpopup();
                CustCode.insertData(compcode, hiddenclientcode.Value, userid, 1, mynewvalue); //ds = CustCode.getData(custcode, userid, compcode);
            }
            else
            {
                NewAdbooking.classesoracle.ClientMasterpopup CustCode = new NewAdbooking.classesoracle.ClientMasterpopup();
                CustCode.insertData(compcode, hiddenclientcode.Value, userid, 0, mynewvalue); //ds = CustCode.getData(custcode, userid, compcode);
            }
        }
       


        //ds = CustCode.getData(custcode, userid, compcode);





        //Session["MySelectedValue"] = mynewvalue;
        //Session["client_pay"] = rdolistupdate.SelectedValue.ToString();
        //hiddenval.Value = Session["client_pay"].ToString();
        btnUpdate.Enabled = false;
    }


}