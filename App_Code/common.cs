/*****************************************************************
 Created By     : Shailendra Srivastava 
 Created Date   : 26th Sep 2012
 *****************************************************************/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;

/// <summary>
/// Summary description for common
/// </summary>
public class common
{
	public common()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   

    public static void FillDropDown(ref DropDownList drpList, DataSet lstData, string dataText, string dataValueFiels, string initialText, bool IsIntialValueRequired)
    {
        drpList.Items.Clear();
        drpList.DataSource = lstData;
        drpList.DataTextField = dataText;
        drpList.DataValueField = dataValueFiels;
        drpList.DataBind();
        if (IsIntialValueRequired)
        {
            drpList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }


    public static void FillGrid(ref GridView gvList, DataSet lstData, bool AllowPaging)
    {
        gvList.DataSource = lstData;
        //gvList.PageSize = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["PageSize"]);
        gvList.AllowPaging = AllowPaging;
        gvList.DataBind();
    }

    public static void FillDataGrid(ref DataGrid gvList, DataSet lstData, bool AllowPaging)
    {
        gvList.DataSource = lstData;
        //gvList.PageSize = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["PageSize"]);
        gvList.AllowPaging = AllowPaging;
        gvList.DataBind();
    }

    public static void FillCheckBoxList(ref CheckBoxList chkList, DataSet lstData, string dataText, string dataValueFiels)
    {
        chkList.Items.Clear();
        chkList.DataSource = lstData;
        chkList.DataTextField = dataText;
        chkList.DataValueField = dataValueFiels;
        chkList.DataBind();
    }

    public static void FillRadioList(ref RadioButtonList rdList, DataSet lstData, string dataText, string dataValueFiels)
    {
        rdList.DataSource = lstData;
        rdList.DataTextField = dataText;
        rdList.DataValueField = dataValueFiels;
        rdList.DataBind();
    }  
}
