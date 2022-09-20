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
using System.Text;
public partial class rpt_audit_trail : System.Web.UI.Page
{
    string extra2 = "", extra3 = "", extra4 = "", extra5 = "", extra6 = "", extra7 = "", extra8 = "", extra9 = "", extra10 = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userid"] == null || Session["userid"] == "" || Session["userid"] == "Nothing")
        {
            Response.Redirect("login.aspx");
        }

        Response.Expires = -1;
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";


        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("xml/rpt_audit_trail.xml"));
      
        Reports.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
     



        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenusername.Value = Session["username"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        hiddenunit.Value = Session["center"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(rpt_audit_trail));

        if (!Page.IsPostBack)
        {
            bindLogSection();
            DrpLogSelection.Attributes.Add("onchange", "javascript:return CallBindColumn();");
            
            btnadd.Attributes.Add("onclick", "javascript:return addfilter(this.id);");
            btnadd.Attributes.Add("onkeypress", "javascript:return addfilter(this.id);");
            btnclear.Attributes.Add("onclick", "javascript:return clearfilter(this.id);");
           
            btnaddn.Attributes.Add("onclick", "javascript:return addfieldname();");
            btnadd.Attributes.Add("onclick", "javascript:return bindgrid();");
            btnremove.Attributes.Add("onclick", "javascript:return removefield();");
          //  form1.Attributes.Add("onclick", "javascript:return HideModalDiv();");
            btnclear.Attributes.Add("onclick", "javascript:return HideModalDiv();");
        


        }
    }

    public void bindLogSection()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("xml/rpt_audit_trail.xml"));
        DrpLogSelection.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Log Selection-";
        li1.Value = "0";
        DrpLogSelection.Items.Add(li1);

        for (i = 0; i < ds.Tables[1].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = ds.Tables[1].Rows[0].ItemArray[i].ToString();
            DrpLogSelection.Items.Add(li);

        }


    }

    [Ajax.AjaxMethod]
    public DataSet bindlis(string compcode, string unit, string cha, string repo)
    {
        string extra2 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.rpt_audit_trail rep = new NewAdbooking.Report.Classes.rpt_audit_trail();
            ds = rep.bindr(compcode, unit, cha, repo, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.rpt_audit_trail rep = new NewAdbooking.Report.classesoracle.rpt_audit_trail();
            ds = rep.bindr(compcode, unit, cha, repo, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindreport(string compcode, string unit, string cha, string extra1)
    {
        string extra2 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.rpt_audit_trail rep = new NewAdbooking.Report.Classes.rpt_audit_trail();
            ds = rep.masrep(compcode, unit, cha, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.rpt_audit_trail rep = new NewAdbooking.Report.classesoracle.rpt_audit_trail();
            ds = rep.masrep(compcode, unit, cha, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public string bindgriddata(string compcode, string bookingid, string fromdate, string todate, string extra1, string hdnlist, string hdnlist1)
    {
       string extra2 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.rpt_audit_trail rep = new NewAdbooking.Report.Classes.rpt_audit_trail();
            ds = rep.bindgrid(compcode, bookingid, fromdate, todate, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.rpt_audit_trail rep = new NewAdbooking.Report.classesoracle.rpt_audit_trail();
            ds = rep.bindgrid(compcode, bookingid, fromdate, todate, extra1);
        }
        StringBuilder str = new StringBuilder();
        string allitem11 = hdnlist;
        string[] list11 = allitem11.Split(',');
        string[] listtable = hdnlist1.Split(',');
        str.Append("<table width='100%'  style='border:solid 1px black;' cellspacing='0' cellpadding='0' border='1'>");
        str.Append("<tr style='height:30px;'>");
        for (int i = 0; i < list11.Length; i++)
        {
            for (int v = 0; v < ds.Tables[0].Columns.Count; v++)
            {
                if (ds.Tables[0].Columns[v].Caption.ToString().ToUpper() == list11[i].ToUpper())
                {
                    str.Append("<td   class='quotationnam' align='center' style='font-size:13px;border-right:solid 1px black;background-color:#a0bfeb' id='capt_" + i + "' onclick=abc(this.id,'" + ds.Tables[0].Columns[v].Caption.ToString() + "','"+listtable[i]+"')><b>" + ds.Tables[0].Columns[v].Caption.ToString() + "</b></td>");
                }
            }
        }
        str.Append("</tr>");
        //for (int n = 0; n < list11.Length; n++)
        //{
        //    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        //    {
               
        //        for (int v = 0; v < ds.Tables[0].Columns.Count; v++)
        //        {
        //            if (ds.Tables[0].Columns[v].Caption.ToString() == list11[n])
        //            {
        //                str.Append("<td  width='18%' class='quotationnam' align='center' style='font-size:10px;border-right:solid 1px black;border-top:solid 1px black;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
        //            }
        //        }

        //    }
        //}

       
            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                str.Append("<tr style='height:30px;'>");
                for (int n = 0; n < list11.Length; n++)
                {
                    for (int v = 0; v < ds.Tables[0].Columns.Count; v++)
                    {
                        if (ds.Tables[0].Columns[v].Caption.ToString().ToUpper() == list11[n].ToUpper())
                        {
                            str.Append("<td  width='18%' class='quotationnam' align='center' style='font-size:10px;border-right:solid 1px black;border-top:solid 1px black;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                        }
                    }
                }
                str.Append("</tr>");
            }
       

        str.Append("</table>");
      
        extra2 = str.ToString();
        return extra2;
       
        
    }

    [Ajax.AjaxMethod]
    public string  bindlogndetail(string compcode, string tabcolnm, string bookingid, string fromdate, string todate, string extra1, string extra2)
    {
       string extra3 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.rpt_audit_trail rep = new NewAdbooking.Report.Classes.rpt_audit_trail();
           // ds = rep.bindgrid(compcode, bookingid, fromdate, todate, extra1);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.rpt_audit_trail rep = new NewAdbooking.Report.classesoracle.rpt_audit_trail();
            ds = rep.bindlogndetail(compcode, tabcolnm, bookingid, fromdate, todate, extra1,"");
        }
        StringBuilder str = new StringBuilder();
      
        str.Append("<table   cellspacing='0' cellpadding='0' border='1'>");
        str.Append("<tr style='height:30px;'>");
      
            for (int v = 0; v < ds.Tables[0].Columns.Count; v++)
            {
               
                    str.Append("<td   class='quotationnam' align='center' style='font-size:13px;background-color:#a0bfeb' )><b>" + ds.Tables[0].Columns[v].Caption.ToString() + "</b></td>");
               
            }
      
        str.Append("</tr>");
       


        for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        {
            str.Append("<tr style='height:30px;'>");
           
                for (int v = 0; v < ds.Tables[0].Columns.Count; v++)
                {
                    
                        str.Append("<td   class='quotationnam' align='center' style='font-size:10px;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                    
                }
           
            str.Append("</tr>");
        }


        str.Append("</table>");

        extra3 = str.ToString();
        return extra3;
    }

    protected void btnremove_Click(object sender, EventArgs e)
    {

  //  // Find the right item and it's value and index
  //      string currentItemText = ListBox4.SelectedValue.ToString();
  //      string currentItemIndex = ListBox4.SelectedIndex;
  //  // Add RightListBox item to the ArrayList
  //  string myDataList.Add(currentItemText);
 
  //RightListBox.Items.RemoveAt(RightListBox.Items.IndexOf(RightListBox.SelectedItem));
 
  //  // Refresh data binding
  //  ApplyDataBinding();

    }

    private void ApplyDataBinding()
    {
        //LeftListBox.ItemsSource = null;
        //// Bind ArrayList with the ListBox
        //LeftListBox.ItemsSource = myDataList;
    }
}
