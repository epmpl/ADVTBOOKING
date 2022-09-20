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

public partial class openlayout1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        xmllist1.Attributes.Add("onclick", "javascript:gethtml1();document.getElementById('fetchid1').value='';");
        xmllist1.Attributes.Add("onkeydown", "javascript:gethtml1()");
        xmllist1.Attributes.Add("onkeyup", "javascript:gethtml1()");
        catname.Attributes.Add("onchange", "javascript:mydata(this.value)");
       
        //openL.Attributes.Add("onclick", "javascript:gethtml()");
        //Ajax.Utility.RegisterTypeForAjax(typeof(openlayout));


        if (!Page.IsPostBack)
        {
            bindxml();
            binddrop();
        }
        //xmllist.Attributes.Add("onclick", "javascript:showp();");

    }
    public void bindxml()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls Fetchhtml = new NewAdbooking.Classes.cls();
            //ABPNEW.classes.cls Fetchhtml = new ABPNEW.classes.cls();

            ds = Fetchhtml.fetchdata();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls Fetchhtml = new NewAdbooking.classesoracle.orclcls();
            //ABPNEW.classes.cls Fetchhtml = new ABPNEW.classes.cls();

            ds = Fetchhtml.fetchdata();
        }
       
        xmllist1.Items.Clear();
        for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        {
            ListItem li = new ListItem();
            li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
            //string[] temp = li.Value.Split('\\');
            //string[] temp2 = temp[2].Split('.');
            //string filename = temp2[0];
            xmllist1.Items.Add(li);
        }
    }

    protected void openL_Click(object sender, EventArgs e)
    {
        if (xmllist1.Text == "")
        {
            Response.Write("<script> alert('No Template Selected !');</script>");
        }
        else
        {
            string abc = xmllist1.SelectedItem.Text;
            //string abc = xmllist.SelectedValue;
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.cls Fetchquery = new NewAdbooking.Classes.cls();
                //ABPNEW.classes.cls Fetchquery = new ABPNEW.classes.cls();

                ds = Fetchquery.fetchquerydata(abc);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.orclcls Fetchquery = new NewAdbooking.classesoracle.orclcls();
                //ABPNEW.classes.cls Fetchquery = new ABPNEW.classes.cls();

                ds = Fetchquery.fetchquerydata(abc);
            }
            
            string myhtml = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            // slctdval.Value = myhtml;
            getslcthtml.Value = myhtml;
            //ScriptManager.RegisterClientScriptBlock(this, typeof(openlayout), "as", "gethtml(()", true);
            //Response.Write("<script>window.close();</script>");
        }
        //openL_Click

    }
    //[Ajax.AjaxMethod]
    //public DataSet getthevalue(string xmlid)
    //{
    //    ABPNEW.classes.cls Fetchquery = new ABPNEW.classes.cls();
    //    DataSet ds = new DataSet();
    //    ds = Fetchquery.fetchquerydata(xmlid);
    //    return ds;

    //}

    protected void xmllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        string abc = xmllist1.SelectedItem.Text;
        //string abc = xmllist.SelectedValue;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls Fetchquery = new NewAdbooking.Classes.cls();
            //ABPNEW.classes.cls Fetchquery = new ABPNEW.classes.cls();

            ds = Fetchquery.fetchquerydata(abc);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls Fetchquery = new NewAdbooking.classesoracle.orclcls();
            //ABPNEW.classes.cls Fetchquery = new ABPNEW.classes.cls();

            ds = Fetchquery.fetchquerydata(abc);
        }
        
        string myhtml = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        string myfilterhtml = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        getslcthtml.Value = myhtml;
        //preview.InnerHtml = myfilterhtml;                  
    }


    //ABPNEW.classes.cls dd = new ABPNEW.classes.cls();
    public void binddrop()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls dd = new NewAdbooking.Classes.cls();
            //ABPNEW.classes.cls dd = new ABPNEW.classes.cls();

            ds = dd.fatchcategory();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls dd = new NewAdbooking.classesoracle.orclcls();
            //ABPNEW.classes.cls dd = new ABPNEW.classes.cls();

            ds = dd.fatchcategory();
        }
        
        int i = ds.Tables[0].Rows.Count;
        int K = 0;
        catname.Items.Add("All");
        for (K = 0; K < i; K++)
        {
            ListItem li = new ListItem();
            li.Text = ds.Tables[0].Rows[K].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[K].ItemArray[1].ToString();
            catname.Items.Add(li);
        }
    }


    
}
