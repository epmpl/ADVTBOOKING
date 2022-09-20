using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class cngbranch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdncompcode.Value = Session["compcode"].ToString();
        hdncompname.Value = Session["comp_name"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        hdnunitcode.Value = Session["center"].ToString();
        hdncentername.Value = Session["centername"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        if (!Page.IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(cngbranch));
            btnsubmit.Attributes.Add("onclick", "javascript:return submitnew_branch123()");
            btnexit.Attributes.Add("onclick", "javascript:return closeme()");
            if (Session["userid"] == null || Session["userid"] == "")
            {
                Response.Redirect("login.aspx");
            }


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //DataSet ds_per = new DataSet();
                //Circulation.Classes.cir_permission ls = new Circulation.Classes.cir_permission();
                //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGBRANCH", hiddendateformat.Value, "", "");
                DataSet ds_per = new DataSet();
                string[] parameterValueArray = new string[] { hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGBRANCH", hiddendateformat.Value, "", "" };
                string procedureName = "user_privileges.user_form_rights_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds_per = exe.DynamicBindProcedure(procedureName, parameterValueArray);

                if (ds_per.Tables[0].Rows.Count > 0)
                {
                    hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
                }
                else
                {
                    hdn_user_right.Value = "0";
                }
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //DataSet ds_per = new DataSet();
                //Circulation.classesoracle.cir_permission ls = new Circulation.classesoracle.cir_permission();
                //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGBRANCH", hiddendateformat.Value, "", "");
                DataSet ds_per = new DataSet();
                string[] parameterValueArray = new string[] { hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGBRANCH", hiddendateformat.Value, "", "" };
                string procedureName = "user_privileges.user_form_rights_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds_per = exe.DynamicBindProcedure(procedureName, parameterValueArray);
                if (ds_per.Tables[0].Rows.Count > 0)
                {
                    hdn_user_right.Value = ds_per.Tables[0].Rows[0].ItemArray[6].ToString();
                }
                else
                {
                    hdn_user_right.Value = "0";
                }
            }
            else
            {
            }

        }
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string changeBRANCH(string newcomapnycode, string newcomapnyname)
    {
        Session["revenuename"] = newcomapnyname;
        Session["revenue"] = newcomapnycode;
        return "True";

    }


    [Ajax.AjaxMethod]
    public DataSet Getdata(string userid, string center)
    {

        DataSet ds_table = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //Circulation.Classes.agency_mast agmast = new Circulation.Classes.agency_mast();
            string[] parameterValueArray = new string[] { userid, center };
            string procedureName = "cir_branch_bind_p";
            NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
            ds_table = exe.DynamicBindProcedure(procedureName, parameterValueArray);

            //ds_table = agmast.bind_branch(userid, center);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //Circulation.classesoracle.agency_mast agmast = new Circulation.classesoracle.agency_mast();

            //ds_table = agmast.bind_branch(userid, center); ;

            string[] parameterValueArray = new string[] { userid, center };
            string procedureName = "cir_branch_bind.cir_branch_bind_p2";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds_table = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds_table;

    }
}
