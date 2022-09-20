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

public partial class cyoptopkg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string flag = "";
        string flag1 = "";
        string description = "";
        string code = Request.QueryString["cyop_code"].ToString();
        string desc = Request.QueryString["cyop_desc"].ToString();
        string cyop_adtype = Request.QueryString["cyop_adtype"].ToString();
        desc = desc.Replace("^", " + ");
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            // Response.Write("<script>alert(\"Your Session Has Been Expired\");window.close();</script>");
            Response.Write("<script>alert('Your Session Has Been Expired');document.location.href=login.aspx;</script>");
            return;

        }
        string compcode = Session["compcode"].ToString();
        string[] edit;
        edit = desc.Split('+');

        DataSet dk = new DataSet();
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();
        DataRow myrow;

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Editonname";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "value";
        mydatatable.Columns.Add(mycolumn);

        

        for (int j = 0; j < edit.Length; j++)
        {
            myrow = mydatatable.NewRow();
            myrow["Editonname"] = edit[j].Trim();
            myrow["value"] = "1";
           mydatatable.Rows.Add(myrow);
            
            
        }
        
        DataRow[] foundrow;
        string strExp;
        string strSort;
        strExp = "value='1'";
        strSort = "Editonname DESC";
        foundrow = mydatatable.Select(strExp, strSort);

        for (int z = foundrow.Length-1; z >= 0;)
        {
            if (description != "")
            {
                description = foundrow[z].ItemArray[0].ToString() + " + " + description;
            }
            else
            {
                description = foundrow[z].ItemArray[0].ToString();
            }
            z--;
        }

        

        DataSet ds = new DataSet();
if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
{


        NewAdbooking.Classes.BookingMaster get_cyoppkg = new NewAdbooking.Classes.BookingMaster();
        
        ds = get_cyoppkg.book_getcyoppkg(description, compcode, cyop_adtype);
}


else
    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
{
    NewAdbooking.classesoracle.BookingMaster get_cyoppkg = new NewAdbooking.classesoracle.BookingMaster();
    ds = get_cyoppkg.book_getcyoppkg(description, compcode, cyop_adtype);

}
else{
    NewAdbooking.classmysql .BookingMaster get_cyoppkg = new NewAdbooking.classmysql .BookingMaster();
    ds = get_cyoppkg.book_getcyoppkg(description, compcode, cyop_adtype);
}



        if (ds.Tables[0].Rows.Count > 0)
        {
            flag = ds.Tables[0].Rows[0].ItemArray[0].ToString() + "^" + ds.Tables[0].Rows[0].ItemArray[1].ToString();

        }

        Response.Write(flag);
        Response.End();
        return;


    }
}
