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

public partial class openlayout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        xmllist.Attributes.Add("onclick", "javascript:gethtm()");
        xmllist.Attributes.Add("onkeydown", "javascript:gethtm()");
        xmllist.Attributes.Add("onkeyup", "javascript:gethtm()");
        
      if (!Page.IsPostBack)
       {
          //  binddrpname("CO0");
          // binddrpname();
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
        
        xmllist.Items.Clear();
        for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        {
            ListItem li = new ListItem();
            li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
            xmllist.Items.Add(li);
        }
    }

/****************ajay code****************************/
    
    //[Ajax.AjaxMethod]
    //public DataSet fatchquerycode(string myid)myid
    ////public void binddrpname()
    //// {
    ////    ABPNEW.classes.cls log = new ABPNEW.classes.cls();
    ////    DataSet ds = new DataSet();
    ////    ds = log.fatchquerycode();
    ////    drpcategory.Items.Clear();
    ////    for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
    ////    {
    ////        ListItem li = new ListItem();
    ////        li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
    ////        li.Value = ds.Tables[0].Rows[a].ItemArray[1].ToString();
    ////        drpcategory.Items.Add(li);

    ////    }
    ////    //return;
       
    ////}


    protected void openL_Click(object sender, EventArgs e)
    {
        try
        {

            if (xmllist.Text == "")
            {
                Response.Write("<script> alert('No Template Selected !');</script>");
            }
            else
            {
                string abc = xmllist.SelectedItem.Text;
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
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error !!!');</script>");
        }

    }
    
    protected void xmllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        string abc = xmllist.SelectedItem.Text;
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

    //ABPNEW.classes.abpmaster strcountry = new ABPNEW.classes.abpmaster();
     //ABPNEW.classes.cls Fetchquery = new ABPNEW.classes.cls();
   // ABPNEW.classes.cls fatchcode = new ABPNEW.classes.cls();
    //public void bindajay()
    //{

    //    ds = aa.fatchquerycode(abc);
    //    string a = ds.Tables[0].
    
    //}
    
}
