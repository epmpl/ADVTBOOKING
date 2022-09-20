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

public partial class cngcompany : System.Web.UI.Page
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
            Ajax.Utility.RegisterTypeForAjax(typeof(cngcompany));
            btnsubmit.Attributes.Add("onclick","javascript:return submitnew_company()");
            btnexit.Attributes.Add("onclick", "javascript:return closeme()");
            if (Session["userid"] == null || Session["userid"] == "")
            {
                Response.Redirect("login.aspx");
            }
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                DataSet ds_per = new DataSet();
                string[] parameterValueArray = new string[] { hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGCOMPANY", hiddendateformat.Value, "", ""};
                string procedureName = "user_privileges.user_form_rights_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds_per = exe.DynamicBindProcedure(procedureName, parameterValueArray);


                //Circulation.Classes.cir_permission ls = new Circulation.Classes.cir_permission();
                //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGCOMPANY", hiddendateformat.Value, "", "");
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
                //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGCOMPANY", hiddendateformat.Value, "", "");
                DataSet ds_per = new DataSet();
                string[] parameterValueArray = new string[] { hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGCOMPANY", hiddendateformat.Value, "", "" };
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
            DataSet ds_table = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //Circulation.Classes.agency_mast agmast = new Circulation.Classes.agency_mast();
                string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["dateformat"].ToString(),"","" };
                string procedureName = "cir_change_company_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds_table = exe.DynamicBindProcedure(procedureName, parameterValueArray);
                
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //Circulation.classesoracle.agency_mast agmast = new Circulation.classesoracle.agency_mast();
               
                //ds_table = agmast.cng_company(Session["userid"].ToString(), Session["dateformat"].ToString());

                string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["dateformat"].ToString(),"","" };
                string procedureName = "cir_change_company.cir_change_company_P";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds_table = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {
            }
            result.InnerHtml = "";
            string result1="";
            int i=0;
            if (ds_table.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i <= ds_table.Tables[0].Rows.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        result1 = "<table width=100% style=margin-top:60px><tr><td   bgcolor=#7DAAE3 style='font-size:15px;text-align:center;border:1px solid #7DAAE3;'>Select</td><td   bgcolor=#7DAAE3 style='font-size:15px;;text-align:center;border:1px solid #7DAAE3;'>Company Code</td><td   bgcolor=#7DAAE3 style='font-size:15px;;text-align:center;border:1px solid #7DAAE3;'>Company Name</td><td   bgcolor=#7DAAE3 style='font-size:15px;;text-align:center;border:1px solid #7DAAE3;'>Company Alias</td></tr>";
                        if (Session["compcode"].ToString() == ds_table.Tables[0].Rows[i].ItemArray[0].ToString())
                        {
                            result1 += "<tr><td class=LblText><input id=rdo_"+i+" type=radio name=cngcom checked>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                        else
                        {
                            result1 += "<tr><td class=LblText><input id=rdo_"+i+" type=radio name=cngcom>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                            result1 +="<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString()+"</td>";
                        result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>";
                        result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[2].ToString() + "</td></tr>";
                    }
                    else
                    {
                        if (Session["compcode"].ToString() == ds_table.Tables[0].Rows[i].ItemArray[0].ToString())
                        {
                            result1 += "<tr><td class=LblText><input id=rdo_"+i+" type=radio name=cngcom checked>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                        else
                        {
                            result1 += "<tr><td class=LblText><input id=rdo_"+i+" type=radio name=cngcom onchecked>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                            result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>";
                        result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[2].ToString() + "</td></tr>";
                    }
                }
                result1 += "</tr></table>";
                result.InnerHtml = result1;
            }            
        }
        
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string changecompany(string newcomapnycode,string newcomapnyname)
    {
       Session["comp_name"]=newcomapnyname;
       Session["compcode"] =newcomapnycode;
        return  "True";

    }
}
