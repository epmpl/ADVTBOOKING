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


public partial class dayspopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CheckBox8.Attributes.Add("OnClick", "javascript:return checkedunchecked('CheckBox8');");
            CheckBox1.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox1');");
            CheckBox2.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox2');");
            CheckBox3.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox3');");
            CheckBox4.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox4');");
            CheckBox5.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox5');");
            CheckBox6.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox6');");
            CheckBox7.Attributes.Add("OnClick", "javascript:return checkedunchecked1('CheckBox7');");

            CheckBox1.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            CheckBox2.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            CheckBox3.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            CheckBox4.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            CheckBox5.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            CheckBox6.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            CheckBox7.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
            //CheckBox8.Attributes.Add("OnClick", "javascript:return fillchk_chkbox();");
        }
    }
}