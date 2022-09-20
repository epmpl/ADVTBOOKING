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

public partial class measurement : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btncancel.Attributes.Add("onclick", "document.getElementById('measuredialog').style.display='none';");
        //if_column.Attributes.Add("onclick", "javascript:checkvalue();");
        //if_width.Attributes.Add("onclick","javascript:checkvalue();");
       
    }


    //protected void units_SelectedIndexChanged(object sender, EventArgs e)
    //{
    ////    string choice = units.SelectedItem.Value.ToString();
    //    switch(choice)
    //    {
    //        case "px":
    //            {

    //                break;
    //            }
    //        case "CM":
    //            {
    //                break;
    //            }
    //        case "MM":
    //            {
    //                break;
    //            }
    //        default:
    //            {
    //                break;
    //            }
    //    }

    //}
}
