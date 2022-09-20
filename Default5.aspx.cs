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

public partial class Default5 : System.Web.UI.Page
{
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {

       
        
    }
    protected void drppackage_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            //e.Item.Cells[0].Visible = true;
            string str = "checkbox" + i;
            string abc = e.Item.Cells[2].Text;
            string finstring = abc.Replace("+", "^");
            e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " style=\"top:0px\" width='1px' onclick=\"javascript:return insertLinedrop();\"   value='" + e.Item.Cells[2].Text + "'   />";
            i++;


            //string str = "checkbox" + i;
            //string abc = e.Item.Cells[19].Text;
            //e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " style=\"top:0px\" width='5px' OnClick=\"javascript:return selectforcontract('" + str + "','"+e.Item.Cells[25].Text+"');\"  value=" + e.Item.Cells[25].Text + "   />";
            //i++;
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();
        DataSet ds = new DataSet();
        ds = bindopackage.packagebind("HT001", "A01");

        //DataView Dv = newDataView();
        DataView dv = new DataView();
        dv.Table = ds.Tables["Package_Name"];
        dv.RowFilter = "panel_key like '" + TextBox1.Text + "%'";

        //Dv.Table = m_Ds.Tables["results"];
        //Dv.RowFilter = "panel_key like '"extBox1.Text <strong class="highlight">+</strong> "%'";
        //      Dv.row
        //dataGridView1.DataSource = Dv;

        drppackage.DataSource = dv;
        drppackage.DataBind();
    }
}
