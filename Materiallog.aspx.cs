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

public partial class Reports_Materiallog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();

            hiddenuserid.Value = Session["userid"].ToString();
            hiddenuserhome.Value = Session["userhome"].ToString();
            hiddenrevenue.Value = Session["Revenue"].ToString();
            hiddenadmin.Value = Session["Admin"].ToString();
         //   hdnaccess.Value = Session["access"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_Materiallog));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/materiallog.xml"));
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcenter.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblusrnam.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbpubdat.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbldest.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();


        if (!Page.IsPostBack)
        {
            txtusrnam.Attributes.Add("onkeydown", "javascript:return binduser(event);");
            lst_user.Attributes.Add("onclick", "javascript:return filluser(event);");
            lst_user.Attributes.Add("onkeydown", "javascript:return filluser(event);");

            txtcenter.Attributes.Add("onkeydown", "javascript:return bincent(event);");
            lst_cent .Attributes.Add("onclick", "javascript:return fillcent(event);");
            lst_cent.Attributes.Add("onkeydown", "javascript:return fillcent(event);");

            BtnRun.Attributes.Add("onclick", "javascript:return get_report(event);");
            txtpubdat.Attributes.Add("OnChange", "javascript:return checkdate(this);");

        }
        binddest();
      
    }

    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/materiallog.xml"));
        drpdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/materiallog.xml"));
        li1.Text ="Select Destation";
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        drpdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[2].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[2].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[2].Rows[0].ItemArray[i].ToString();
            drpdest.Items.Add(li);

        }


    }


    [Ajax.AjaxMethod]
    public DataSet UserBind(string compcode, string userid, string userhome, string revenue, string admin)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Materiallog MastPrev = new NewAdbooking.Classes.Materiallog();
         //   ds1 = MastPrev.MastPrevDisp(compcode, userid, userhome, admin, revenue);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.materiallog MastPrev = new NewAdbooking.classesoracle.materiallog();
            ds1 = MastPrev.MastPrevDisp(compcode, userid, userhome, admin, revenue);
        }
        else
        {
            //  NewAdbooking.classmysql.pop MastPrev = new NewAdbooking.classmysql.pop();
            //  ds1 = MastPrev.MastPrevDisp(compcode,userid,userhome,revenue,admin);
        }
        return ds1;
    }

    [Ajax.AjaxMethod]
    public DataSet publicationbind(string compcode, string userid, string access)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Materiallog pub_cent1 = new NewAdbooking.Classes.Materiallog();
         //   ds = pub_cent1.pub_centbind(compcode, userid, access);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.classesoracle.materiallog pub_cent1 = new NewAdbooking.classesoracle.materiallog();
            ds = pub_cent1.pub_centbind(compcode, userid, access);

        }

        return ds;

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet getdata(string pubdate, string pubcenter, string user, string extra1, string extra2, string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Materiallog pub_cent1 = new NewAdbooking.Classes.Materiallog();
            ds = pub_cent1.getdata(pubdate, pubcenter, user, extra1, extra2, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
            //ds = pub_cent1.pub_cent(Session["compcode"].ToString());
            NewAdbooking.classesoracle.materiallog pub_cent1 = new NewAdbooking.classesoracle.materiallog();
            ds = pub_cent1.getdata(pubdate, pubcenter, user, extra1, extra2, dateformat);

        }
        Session["datamat"] = ds;
        return ds;

    }


}
