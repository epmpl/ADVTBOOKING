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

public partial class Aduser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet objDataSet = new DataSet();
        objDataSet.ReadXml(Server.MapPath("XML/adduserpages.xml"));

        Agencyname.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        genno.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        modgenno.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        Submit.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
	    Exit.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        txtgenno.Enabled = false;

        
        
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        Ajax.Utility.RegisterTypeForAjax(typeof(Aduser));
        if (!IsPostBack)
        {
            bindagency(Session["compcode"].ToString());
            drpagency.Attributes.Add("OnChange", "javascript:return binddepocode();");
            Submit.Attributes.Add("OnClick", "javascript:return updategenno();");
            Exit.Attributes.Add("OnClick", "javascript:return exitclick();");
        }
        txtgenno.Text = "";
        drpagency.SelectedValue = "0";
        txtmodgenno.Text = "";

    }

    public void bindagency(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.BookingMaster agency = new NewAdbooking.Classes.BookingMaster();
            //ds = agency.agencybind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.aduser agency = new NewAdbooking.classesoracle.aduser();
            ds = agency.agencybind(compcode);
        }
        else
        {
            //NewAdbooking.classmysql.BookingMaster agency = new NewAdbooking.classmysql.BookingMaster();
            //ds = agency.agencybind(compcode);
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Agency-";
        li1.Value = "0";
        li1.Selected = true;
        drpagency.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpagency.Items.Add(li);


        }
    }

    [Ajax.AjaxMethod]
    public DataSet binddepo(string agencycode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.BookingMaster depocode = new NewAdbooking.Classes.BookingMaster();

            //ds = depocode.depobind(agencycode);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.aduser depocode = new NewAdbooking.classesoracle.aduser();

                ds = depocode.depobind(agencycode);

            }
            else
            {
                //NewAdbooking.classmysql.BookingMaster depocode = new NewAdbooking.classmysql.BookingMaster();

                //ds = depocode.depobind(agencycode);

            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet updategno(string agencycode, string depocode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.BookingMaster depocode = new NewAdbooking.Classes.BookingMaster();

            //ds = depocode.depobind(agencycode);

        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.aduser updatedepocode = new NewAdbooking.classesoracle.aduser();

                ds = updatedepocode.updategen(agencycode, depocode);

            }
            else
            {
                //NewAdbooking.classmysql.BookingMaster depocode = new NewAdbooking.classmysql.BookingMaster();

                //ds = depocode.depobind(agencycode);

            }
        return ds;
    }

}
