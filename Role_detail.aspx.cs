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

public partial class Role_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        Ajax.Utility.RegisterTypeForAjax(typeof(Role_detail));

        if (Session["compcode"] == null)
        {
            Response.Write("<script>window.parent.location=\"login.spx\";</script>");
            return;
        }

        hiddencompcode.Value = Session["compcode"].ToString();
        if (!Page.IsPostBack)
        {
            BindRolename();
            btnshow.Attributes.Add("OnClick", "javascript:return openform();");
        }
        drprole.Focus();

        //------------- (show button permission)------------------//

        
        DataSet ds1 = new DataSet();
        string comp_code = Session["compcode"].ToString();
        string userid = Session["userid"].ToString();
        string[] parameterValueArray = new string[] { comp_code };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "Rolebind";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "Rolebind";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Rolebind";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //string[] parameterValueArray = { compcode, tsubgrcode, dateformat, extra1, extra2, maingrcode, psubgrcode, ssubgrcode };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        string id = "";
        if (ds1.Tables[0].Rows.Count > 0)
        {
            id = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        if (id == "0" || id == "8")
            // btnshow.Enabled = true;
            Response.Write("<script>alert(\"You Are Not Authorised To See This Form\");window.location.href = 'EnterPage.aspx';</script>");
        // else
        //  btnsubmit.Enabled = false;

        //--------------------------------------------------------------------//

    }


    public void BindRolename()
    {
        DataSet ds1 = new DataSet();
        string comp_code = Session["compcode"].ToString();
        string[] parameterValueArray = new string[] { comp_code };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "Rolebind";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "Rolebind";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "Rolebind";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //string[] parameterValueArray = { compcode, tsubgrcode, dateformat, extra1, extra2, maingrcode, psubgrcode, ssubgrcode };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
      

        drprole.Items.Clear();
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select";
        li1.Value = "0";
        li1.Selected = true;
        drprole.Items.Add(li1);

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
                drprole.Items.Add(li);

            }
           // drpdivision.DataBind();
        }


    }
}
