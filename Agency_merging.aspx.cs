using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Agency_merging : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddencompcode.Value = Session["compcode"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet objDataSetbu = new DataSet();
       
        objDataSetbu.ReadXml(Server.MapPath("XML/Ag_marging.xml"));

        lbagency.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        lbagency1.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        lbremark.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnProcess.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnexit.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        agencyn.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        agencyc.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        agencysc.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        agencyssc.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnCancel.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        lblagencytype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        lblparentagency.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();
        lblfagalert.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[12].ToString();
        lblfcommper.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[13].ToString();
        lbltagalert.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[14].ToString();
        lbltcommper.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[15].ToString();
      
        Ajax.Utility.RegisterTypeForAjax(typeof(Agency_merging));

        if (!Page.IsPostBack)
        {
           txtagency.Attributes.Add("onkeydown", "javascript:return agname(event);");
           txtagency1.Attributes.Add("onkeydown", "javascript:return agname(event);");
           txtpagname.Attributes.Add("onkeydown", "javascript:return agname(event);");

           agecy.Attributes.Add("onkeydown", "javascript:return agnamel2st(event);");
           agecy.Attributes.Add("OnClick", "javascript:return agnamel2st(event);");

           drpagencytype.Attributes.Add("OnChange", "javascript:return AgTypeChange();");
           //lstagn.Attributes.Add("onkeydown", "javascript:return agnamelst(event);");
           //lstagn.Attributes.Add("OnClick", "javascript:return agnamelst(event);");
           btnProcess.Attributes.Add("onclick", "javascript:return process();");
           btnCancel.Attributes.Add("onclick", "javascript:return clearall();");
           //btnCancel.Attributes.Add("onkeydown", "javascript:return clearall();");
           btnexit.Attributes.Add("onclick", "javascript:return Exit();");
        }

    }

    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string userid, string agency,string agtype,string ag_main_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Ag_merging obj1 = new NewAdbooking.Classes.Ag_merging();

            ds = obj1.bindagency(compcode, userid, agency, agtype, ag_main_code);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Agenmerging obj1 = new NewAdbooking.classesoracle.Agenmerging();

                ds = obj1.bindagency(compcode, userid, agency, agtype, ag_main_code);
                return ds;
            }
        return ds;
    }


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string call_process(string compcode, string Agency_main_code, string Agency_sub_code, string from_agency_code, string to_agency_main_code, string to_agency_sub_code, string to_agency_code, string on_date, string dateformat, string remarks, string user, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
    {
        DataSet ds = new DataSet();
        string result = "";
        try
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.Ag_merging obj1 = new NewAdbooking.Classes.Ag_merging();
                result = obj1.process_call(compcode, Agency_main_code, Agency_sub_code, from_agency_code, to_agency_main_code, to_agency_sub_code, to_agency_code, on_date, dateformat, remarks, user, pextra1, pextra2, pextra3, pextra4, pextra5);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Agenmerging obj1 = new NewAdbooking.classesoracle.Agenmerging();
                result = obj1.process_call(compcode, Agency_main_code, Agency_sub_code, from_agency_code, to_agency_main_code, to_agency_sub_code, to_agency_code, on_date, dateformat, remarks, user, pextra1, pextra2, pextra3, pextra4, pextra5);
            }

             return result;
        }
      catch (Exception ex)
        {
            return ex.Message.ToString();
       }

   }
}
