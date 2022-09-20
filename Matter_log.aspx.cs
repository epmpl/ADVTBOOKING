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
using System.Text.RegularExpressions;
using System.Text;

public partial class Matter_log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddensessionuser.Value = Session["Admin"].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(Matter_log));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Matter_history.xml"));
        lblusrnam.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblfrmdt.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbltodt.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblmainlog.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblbukid.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbl_printcent.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbl_branch.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        if (!IsPostBack)
        {
           // bindprintcent();
            bindbranch();
            lstuser.Attributes.Add("onclick", "javascript:return insertuser(event);");
            lstuser.Attributes.Add("onkeydown", "javascript:return insertuser(event);");
            txtusrid.Attributes.Add("onkeydown", "javascript:return selectuser(event);");
            btnrun.Attributes.Add("onclick", "javascript:return bindreport();");
            btnclr.Attributes.Add("onclick", "javascript:return clearfields();");
            btnexit.Attributes.Add("onclick", "javascript:return closewin();");
            bindlog();

        }
        
    }
    //public void bindprintcent()
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
    //        ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
    //    }

    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
    //        ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
    //    }
    //    ListItem li = new ListItem();
    //    li.Value = "0";
    //    li.Text = "Select Printing Center";
    //    li.Selected = true;
    //    dpd_printcent.Items.Add(li);

    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        ListItem li1 = new ListItem();
    //        li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //        dpd_printcent.Items.Add(li1);


    //    }
    //    dpd_printcent.SelectedValue = Session["center"].ToString();
    //}
    public void bindbranch()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.Report.classesoracle.Class1 pub = new NewAdbooking.Report.classesoracle.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub = new NewAdbooking.Report.Classes.Class1();
            ds = pub.adbranch(Session["compcode"].ToString());
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Branch";
        li.Selected = true;
        dpd_branch.Items.Add(li);



        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_branch.Items.Add(li1);
        }
        dpd_branch.SelectedValue = Session["revenue"].ToString();

    }
    public void bindlog()
    {
        
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/Matter_history.xml"));
        ddlmainlog.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[1].Rows[0].ItemArray[0].ToString();
        li1.Value = "0";
        li1.Selected = true;
        ddlmainlog.Items.Add(li1);

        for (i = 2; i < ds1.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds1.Tables[1].Rows[0].ItemArray[i].ToString();
            ddlmainlog.Items.Add(li);

        }


    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]

    public DataSet Binduser(string username)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp_user(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString(), username);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.matterloghistory MastPrev = new NewAdbooking.classesoracle.matterloghistory();
            ds1 = MastPrev.MastPrevDisp_user(Session["compcode"].ToString(), Session["userid"].ToString(), Session["userhome"].ToString(), Session["Admin"].ToString(), Session["Revenue"].ToString(), username);
        }
        

        
        return ds1;
    }

    [Ajax.AjaxMethod]
    public string call_data(string tblnam, string userid, string frmdt, string todt, string dateformat, string bukid,string branch)
    {
        DataSet ds = new DataSet();
        //if (dateformat == "dd/mm/yyyy")
        //{
        //    frmdt = DMYToMDY(frmdt);
        //    todt = DMYToMDY(todt);

        //}
        //else if (dateformat == "yyyy/mm/dd")
        //{
        //    frmdt = YMDToMDY(frmdt);
        //    todt = YMDToMDY(todt);

        //}

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
       //     ds = obj.call_data(text1, pcomp_code, text2, punit_code, text3, userid, text4, fromdt, todt, tname, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.matterloghistory MastPrev = new NewAdbooking.classesoracle.matterloghistory();
            ds = MastPrev.updatedealstatus(tblnam, userid, frmdt, todt, dateformat, bukid, branch);
        }

        
        StringBuilder buf = new StringBuilder();
        buf.Append("<table border=1px Width='500px' style='border:1px solid #7DAAE3;' cellpadding='0' cellspacing='0' >");
        buf.Append("<tr style='background-color:#7DAAE3'>");
        for (int t = 0; t < ds.Tables[0].Columns.Count; t++)
        {
            
                buf.Append("<td class='gridview' ><b>");
                if (ds.Tables[0].Columns[t].Caption.ToString() != "")
                {
                    string hdname = ds.Tables[0].Columns[t].Caption.ToString();
                  hdname=hdname.Replace("_", " ");
                  if (hdname == "CIOID")
                      hdname = "Booking Id";
                  buf.Append(hdname);
                }
                buf.Append("</b></td>");
            
        }
        buf.Append("</tr>");


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            buf.Append("<tr>");
            for (int t = 0; t < ds.Tables[0].Columns.Count; t++)
            {
                buf.Append("<td class='gridview' style='font-size:12px'>");
                buf.Append( fndnull(ds.Tables[0].Rows[i].ItemArray[t].ToString()) );
                buf.Append("</td>");
                
            }
            buf.Append("</tr>");
        }
        buf.Append("</table>");
        return buf.ToString();

    }
    public string fndnull(string str)
    {
        if (str == "" || str == null)
        {
            str = "&nbsp;";
        }
        return str;
    }
}
