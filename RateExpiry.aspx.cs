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

public partial class RateExpiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hdndtabase.Value = ConfigurationSettings.AppSettings["Connectiontype"].ToString();
           
        }
        else
        {
           
            Response.Redirect("login.aspx");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(RateExpiry));

        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/RateExpiry.xml"));
        lbladtyp.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lblrtcod.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lblcategory.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcolor.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lbluom .Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lblvldfrm.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        lblvldto.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        lblpackage.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lblexpdt.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        //view0.Text = objDataSet.Tables[1].Rows[0].ItemArray[0].ToString();
        //view1.Text = objDataSet.Tables[1].Rows[0].ItemArray[1].ToString();
        //view2.Text = objDataSet.Tables[1].Rows[0].ItemArray[2].ToString();
        //view3.Text = objDataSet.Tables[1].Rows[0].ItemArray[3].ToString();
        //view4.Text = objDataSet.Tables[1].Rows[0].ItemArray[4].ToString();
        //view5.Text = objDataSet.Tables[1].Rows[0].ItemArray[5].ToString();
        //view6.Text = objDataSet.Tables[1].Rows[0].ItemArray[6].ToString();
        //view7.Text = objDataSet.Tables[1].Rows[0].ItemArray[7].ToString();
        //view8.Text = objDataSet.Tables[1].Rows[0].ItemArray[8].ToString();
        //view9.Text = objDataSet.Tables[1].Rows[0].ItemArray[9].ToString();
        //view10.Text = objDataSet.Tables[1].Rows[0].ItemArray[10].ToString();
      //  view11.Text = objDataSet.Tables[1].Rows[0].ItemArray[11].ToString();
        if (!Page.IsPostBack)
        {
            ddladtyp.Attributes.Add("OnChange", "javascript:return bindcategory_package();");
            btnsbmit.Attributes.Add("onclick", "javascript:return datafrGrid();");
            btnsave.Attributes.Add("onclick", "javascript:return savdata();");
            btnExit.Attributes.Add("onclick", "javascript:return exitwin();");
            btnClear.Attributes.Add("onclick", "javascript:return clearwin();");
            txtvldfrm.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtvldto.Attributes.Add("OnChange", "javascript:return checkdate(this);");
            txtexpdt.Attributes.Add("OnChange", "javascript:return checkdate(this);");

            rbsolo.Attributes.Add("OnClick", "javascript:return check2();");
            rbpackage.Attributes.Add("OnClick", "javascript:return check3();");
        }
        adtypedata(Session["compcode"].ToString());
        bindcolortype();
        bindratecod(Session["compcode"].ToString());
    }


    public void adtypedata(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Rateexpiry bind = new NewAdbooking.Classes.Rateexpiry();
            ds = bind.adtypbind(compcode);
        }
        else
        {
            NewAdbooking.classesoracle.Rateexpiry bind = new NewAdbooking.classesoracle.Rateexpiry();
            ds = bind.adtypbind(compcode);
        }



        int i;
        ListItem li1;

        li1 = new ListItem();
        ddladtyp.Items.Clear();
        li1.Text = "-Select Ad Type-";
        li1.Value = "0";
        li1.Selected = true;
        ddladtyp.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            ddladtyp.Items.Add(li);


        }

    }


    public void bindcolortype()
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Rateexpiry colortype = new NewAdbooking.Classes.Rateexpiry();

            dx = colortype.bindcolortyp(Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Rateexpiry bind = new NewAdbooking.classesoracle.Rateexpiry();

                dx = bind.bindcolortyp(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else
            {
                NewAdbooking.classmysql.BookingMaster colortype = new NewAdbooking.classmysql.BookingMaster();

                dx = colortype.bindcolortyp(Session["compcode"].ToString());
            }
        ddlcolor.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select color type-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        ddlcolor.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                ddlcolor.Items.Add(li);
            }

        }

    }

    public void bindratecod(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Rateexpiry bind = new NewAdbooking.Classes.Rateexpiry();
            ds = bind.ratecode(compcode);
        }
        else
        {
            NewAdbooking.classesoracle.Rateexpiry bind = new NewAdbooking.classesoracle.Rateexpiry();
            ds = bind.ratecode(compcode);
        }



        int i;
        ListItem li1;

        li1 = new ListItem();
        ddlrtcod.Items.Clear();
        li1.Text = "-Select Rate Code-";
        li1.Value = "0";
        li1.Selected = true;
        ddlrtcod.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString().ToUpper();
            ddlrtcod.Items.Add(li);


        }

    }


    [Ajax.AjaxMethod]
    public DataSet binduom(string compcode, string adtye)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Rateexpiry binduom = new NewAdbooking.Classes.Rateexpiry();
            ds = binduom.uombind(compcode, adtye);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Rateexpiry binduom = new NewAdbooking.classesoracle.Rateexpiry();
            ds = binduom.uombind(compcode, adtye);
        }
        else
        {
            NewAdbooking.classmysql.Adsize binduom = new NewAdbooking.classmysql.Adsize();
            ds = binduom.uombind(compcode, adtye);
        }

        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getcategory(string compcode, string pkg_code)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Rateexpiry objpkg = new NewAdbooking.Classes.Rateexpiry();
            ds = objpkg.bind_category(compcode, pkg_code);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Rateexpiry objpkg = new NewAdbooking.classesoracle.Rateexpiry();
            ds = objpkg.bind_category(compcode, pkg_code);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindpackagenew(string adtype, string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Rateexpiry bindopackage = new NewAdbooking.classesoracle.Rateexpiry();
            ds = bindopackage.packagebind_NEW(compcode, adtype);
        }
        else
        {
            NewAdbooking.classesoracle.Rateexpiry bindopackage = new NewAdbooking.classesoracle.Rateexpiry();
            ds = bindopackage.packagebind_NEW(compcode, adtype);
        }

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet getdatagrid(string compcod, string adtyp, string rtcod, string categry, string color, string uom, string frdate, string todate, string packge, string extra1, string extra2, string dateformat, string solo123, string edtn_flag)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Rateexpiry bindopackage = new NewAdbooking.classesoracle.Rateexpiry();
            ds = bindopackage.datafrgrid(compcod, adtyp, rtcod, categry, color, uom, frdate, todate, packge, extra1, extra2, dateformat, solo123, edtn_flag);
        }
        else
        {
            NewAdbooking.Classes.Rateexpiry bindopackage = new NewAdbooking.Classes.Rateexpiry();
            ds = bindopackage.datafrgrid(compcod, adtyp, rtcod, categry, color, uom, frdate, todate, packge, extra1, extra2, dateformat, solo123, edtn_flag);
        }

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet saveexpdate(string compcod, string expdate, string ratecod,string dateformat, string extra1)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.Rateexpiry bindopackage = new NewAdbooking.classesoracle.Rateexpiry();
            ds = bindopackage.saveexpdate(compcod, expdate, ratecod,dateformat, extra1);
        }
        else
        {
            NewAdbooking.Classes.Rateexpiry bindopackage = new NewAdbooking.Classes.Rateexpiry();
            ds = bindopackage.saveexpdate(compcod, expdate, ratecod, dateformat, extra1);
        }

        return ds;

    }



}
