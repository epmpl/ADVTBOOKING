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

public partial class CngPrintingCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (!Page.IsPostBack)
        {
           
            Ajax.Utility.RegisterTypeForAjax(typeof(CngPrintingCenter));
            btnsubmit.Attributes.Add("onclick","javascript:return submitnew_company()");
            btnexit.Attributes.Add("onclick", "javascript:return closeme()");
            if (Session["userid"] == null || Session["userid"] == "")
            {
                Response.Redirect("login.aspx");
            }
            hdncompcode.Value = Session["compcode"].ToString();
            hdncompname.Value = Session["comp_name"].ToString();
            hdnuserid.Value = Session["userid"].ToString();
            hdnunitcode.Value = Session["center"].ToString();
            hdncentername.Value = Session["centername"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdnbranch.Value = Session["revenue"].ToString();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                DataSet ds_per = new DataSet();
                //Circulation.Classes.cir_permission ls = new Circulation.Classes.cir_permission();
                //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGPRINTINGCENTER", hiddendateformat.Value, "", "");
                string[] parameterValueArray = new string[] { hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "2", "CNGPRINTINGCENTER", hiddendateformat.Value, "", "" };
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
                DataSet ds_per = new DataSet();
                //Circulation.classesoracle.cir_permission ls = new Circulation.classesoracle.cir_permission();
                //ds_per = ls.fnd_form_permission(hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "1", "CNGPRINTINGCENTER", hiddendateformat.Value, "", "");
                string[] parameterValueArray = new string[] { hdncompcode.Value, hdnunitcode.Value, hdnuserid.Value, "2", "CNGPRINTINGCENTER", hiddendateformat.Value, "", "" };
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
            DataSet ds_table1 = new DataSet();
            DataSet ds_table = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //Circulation.Classes.cngPrintingCenter agmast = new Circulation.Classes.cngPrintingCenter();

                //ds_table = agmast.cng_company(Session["userid"].ToString(), Session["dateformat"].ToString());
                string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["dateformat"].ToString(),"","" };
                string procedureName = "cir_change_printing_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds_table = exe.DynamicBindProcedure(procedureName, parameterValueArray);
                  
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //Circulation.classesoracle.cngPrintingCenter agmast = new Circulation.classesoracle.cngPrintingCenter();

                //ds_table = agmast.cng_printingcenter(Session["userid"].ToString(), Session["dateformat"].ToString());
                string[] parameterValueArray = new string[] { Session["userid"].ToString(), Session["dateformat"].ToString(),"","" };
                string procedureName = "cir_change_printing_p";
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
                        result1 = "<div align='right'  style='overflow-y: scroll; overflow-x: hidden;height:230px;width:700px'><table width=100% id='print_cent'>";
                        result1 += "<tr>";
                        result1 += "<td   bgcolor=#7DAAE3 style='font-size:15px;text-align:center;border:1px solid #7DAAE3;width:10%;'>Select</td>";
                        result1 += "<td   bgcolor=#7DAAE3 style='font-size:15px;;text-align:center;border:1px solid #7DAAE3;width:40%;'>Printing Center Code</td>";
                        result1 += "<td   bgcolor=#7DAAE3 style='font-size:15px;text-align:center;border:1px solid #7DAAE3;width:50%;'>Printing Center Name</td>";
                        //result1 += "<td   bgcolor=#7DAAE3 style='font-size:15px;text-align:center;border:1px solid #7DAAE3;'>Printing Center Alias</td>";
                        result1 += "</tr>";
                        if (Session["compcode"].ToString() == ds_table.Tables[0].Rows[i].ItemArray[0].ToString())
                        {
                            result1 += "<tr><td class=LblText style='text-align:left;'><input id=rdo_" + i + " type=radio name=cngcom checked onclick=chk_branch(this.id)>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                        else
                        {
                            result1 += "<tr><td class=LblText style='text-align:left;'><input id=rdo_" + i + " type=radio name=cngcom onclick=chk_branch(this.id)>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                        result1 += "<td class=LblText id=prin_code_" + i + " value=" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + ">" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>";
                        //result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>";
                        result1 +="</tr>";
                    }
                    else
                    {                        
                        if (Session["compcode"].ToString() == ds_table.Tables[0].Rows[i].ItemArray[0].ToString())
                        {
                            result1 += "<tr><td class=LblText style='text-align:left;'><input id=rdo_" + i + " type=radio name=cngcom checked onclick=chk_branch(this.id)>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                        else
                        {
                            result1 += "<tr><td class=LblText style='text-align:left;'><input id=rdo_" + i + " type=radio name=cngcom onchecked onclick=chk_branch(this.id)>" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        }
                        result1 += "<td class=LblText id=prin_code_" + i + " value=" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + ">" + ds_table.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
                        result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>";
                        //result1 += "<td class=LblText>" + ds_table.Tables[0].Rows[i].ItemArray[2].ToString() + "</td></tr>";
                        result1 += "</tr>";
                    }
                }
                result1 += "</table></div>";
                result.InnerHtml = result1;
            }            
        }         
    }

    [Ajax.AjaxMethod]
    public DataSet Getdata(string userid, string center)
    {

        DataSet ds_table1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //Circulation.Classes.cngPrintingCenter agmast = new Circulation.Classes.cngPrintingCenter();

            //ds_table1 = agmast.bind_branch(userid, center);
            string[] parameterValueArray = new string[] { userid, center };
            string procedureName = "cir_branch_bind_p";
            NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
            ds_table1 = exe.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //Circulation.classesoracle.cngPrintingCenter agmast = new Circulation.classesoracle.cngPrintingCenter();

            //ds_table1 = agmast.bind_branch(userid, center); ;

            string[] parameterValueArray = new string[] { userid, center };
            string procedureName = "cir_branch_bind.cir_branch_bind_p2";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds_table1 = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds_table1;

    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string changeprintingcenter(string newcomapnycode, string newcomapnyname, string bcode, string b_name)
    {
        Session["centername"] = newcomapnyname;
        Session["center"] = newcomapnycode;
        Session["revenuename"] = b_name;
        Session["revenue"] = bcode;
       
        return  "True";
    }

    [Ajax.AjaxMethod]
    public DataSet branch_chk(string pubcenter, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //Circulation.Classes.cngPrintingCenter logindetail = new Circulation.Classes.cngPrintingCenter();
            //ds = logindetail.getQBC(pubcenter);
            string[] parameterValueArray = new string[] { pubcenter };
            string procedureName = "websp_QBC";
            NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                //Circulation.classesoracle.cngPrintingCenter logindetail = new Circulation.classesoracle.cngPrintingCenter();
                //ds = logindetail.getQBC(pubcenter,userid);
                string[] parameterValueArray = new string[] { userid, pubcenter, "", "" };
                string procedureName = "cir_change_printing_branch_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            //else
            //{
            //    Circulation.classmysql.login logindetail = new Circulation.classmysql.login();
            //    ds = logindetail.getQBC(pubcenter);
            //}
        return ds;
    }
}
