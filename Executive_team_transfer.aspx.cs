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
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Net;

public partial class Executive_team_transfer : System.Web.UI.Page
{

    string compcode = "";
    string userid = "";
    string dateformat = "";
  
    private void Page_Load(object sender, System.EventArgs e)
    {
       
        Response.Expires = -1;
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();


        Ajax.Utility.RegisterTypeForAjax(typeof(Executive_team_transfer));
        //			-------------------------------------Code Of XML File--------------
        	
        DataSet objDataSet = new DataSet();

        objDataSet.ReadXml(Server.MapPath("XML/Executive_team_transfer.xml"));

        lblexname.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblteamname.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();

        if (!Page.IsPostBack)
        {
            tctexeretname.Attributes.Add("onkeydown", "javascript:return F2fillexecutivecr(event);");
            lstexecutive.Attributes.Add("onclick", "javascript:return Clickexecutive(event);");
            lstexecutive.Attributes.Add("onkeydown", "javascript:return Clickexecutive(event);");
           
            txtteamname.Attributes.Add("onkeydown", "javascript:return F2fillteamname(event);");
            lstteamname.Attributes.Add("onclick", "javascript:return Clickteamname(event);");
            lstteamname.Attributes.Add("onkeydown", "javascript:return Clickteamname(event);");
            btntransfer.Attributes.Add("onclick", "javascript:return Clicktransfer(event);");
        }
    }

    [Ajax.AjaxMethod]
    public DataSet fillF2_Creditexecutive(string compcode, string executive)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, executive };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "EXECUTIVE_TEAM_TRANSFER.EXECUTIVE_TEAM_TRANSFER_EX";
            NewAdbooking.classesoracle.CommonClass executivename = new NewAdbooking.classesoracle.CommonClass();
            ds = executivename.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "EXECUTIVE_TEAM_TRANSFER";
            NewAdbooking.classmysql.CommonClass executivename = new NewAdbooking.classmysql.CommonClass();
            ds = executivename.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.Executive_team_transfer executivename = new NewAdbooking.classmysql.Executive_team_transfer();
            ds = executivename.executivetransferdataexec(compcode, executive);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet fill_Creditteam(string compcode, string team)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, team };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "EXECUTIVE_TEAM_TRANSFER.EXECUTIVE_TEAM_TRANSFER_TM";
            NewAdbooking.classesoracle.CommonClass teamname = new NewAdbooking.classesoracle.CommonClass();
            ds = teamname.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "EXECUTIVE_TEAM_TRANSFER";
            NewAdbooking.classmysql.CommonClass teamname = new NewAdbooking.classmysql.CommonClass();
            ds = teamname.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.Executive_team_transfer teamname = new NewAdbooking.classmysql.Executive_team_transfer();
            ds = teamname.executivetransferdatateam(compcode, team);

        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet TransferForm(string compcode, string teamCode, string executiveCode, string userid,  string extra1, string extra)
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, teamCode, executiveCode, userid, extra1, extra };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "EXECUTIVE_TEAM_TRANSFER.EXECUTIVE_TEAM_TRANSFER_UPDATE";
            NewAdbooking.classesoracle.CommonClass transfer = new NewAdbooking.classesoracle.CommonClass();
            ds = transfer.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "EXECUTIVE_TEAM_TRANSFER";
            NewAdbooking.classmysql.CommonClass transfer = new NewAdbooking.classmysql.CommonClass();
            ds = transfer.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classmysql.Executive_team_transfer transfer = new NewAdbooking.classmysql.Executive_team_transfer();
            ds = transfer.executivetransferdataupdate(compcode, teamCode, executiveCode, userid, extra1, extra);

        }
        return ds;

       }
}
