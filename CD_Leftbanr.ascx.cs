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

public partial class CD_Leftbanr : System.Web.UI.MobileControls.MobileUserControl
{
    public string tree = "";
    string userhome = "";
    string admin = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddenusername.Value = Session["username"].ToString();
        userhome = Session["userhome"].ToString();
        admin = Session["Admin"].ToString();
        dynamictreeview();
    }

    public void dynamictreeview()
    {
        DataSet dstreexml = new DataSet();
        dstreexml.ReadXml(Server.MapPath("XML/tree.xml"));


        tree += "<div style=\"OVERFLOW: auto; WIDTH: 230; HEIGHT: 480px\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"230\" id = 'table1' >";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a style='cursor:hand;cursor:pointer' onClick=\"toggle(this)\" class=\"folder\"><img src=\"plus.gif\">Ad Manager</a>";


        tree += "<div  style=\"display:none;\">";
        tree += "<a onClick=\"toggle(this,'group1')\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Master</a>";
        tree += "<div id=\"group1\" style=\"display:none;\">";

        if (dstreexml.Tables[0].Rows[0].ItemArray[55].ToString() == "enable")
        {
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('AdCategoryMaster','Ad Cat. Master');\" >Ad Category Master </a>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[56].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('adsubcat1','Ad Sub Cat Master');\" >Ad Sub Category Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[57].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('Adsubcat3','Ad Sub Cat3');\" >Ad Sub Sub Category Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[67].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('Ratemaster','Rate Master');\" >Rate Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[66].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('Scheme_Master','Scheme_Master');\" >Scheme Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }



        if (dstreexml.Tables[0].Rows[0].ItemArray[44].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('AdvPagePositionMaster','Page Position Master');\" >Ad Page Premium Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[25].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('BoxMaster','Box Master');\" >Box Charges Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[3].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('Agent_master','Agency Master');\" >Agency Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[13].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('ClientMaster','Client Master');\" >Client Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[60].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('AdvExecMaster','Adv Exec. Master');\" >Executive Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[47].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('PublicationMaster','Publication Master');\" >Publication Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[48].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('EditorMaster','Editor Master');\" >Edition Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }



        if (dstreexml.Tables[0].Rows[0].ItemArray[35].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('CountryMaster','Country Master');\" >Country Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[36].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('StateMaster','State Master');\" >State Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[37].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('DistrictMaster','District Master');\" >District Master </a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[33].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('ZoneMaster','Zone Master');\" >Zone Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[15].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('region_master','Region Master');\" >Region Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[6].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('ProductCategory','Product Category');\" >Product Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }
        if (dstreexml.Tables[0].Rows[0].ItemArray[11].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('BrandMaster','BrandMaster');\" >Brand Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[12].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('VarientMaster','VarientMaster');\" >Varient Master</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }


        tree += "</div>";



        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";


        tree += "<a style='cursor:hand;cursor:pointer' onClick=\"toggle(this)\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Transaction</a>";

        tree += "<div style=\"display:none;\">";
        if (dstreexml.Tables[0].Rows[0].ItemArray[76].ToString() == "enable")
        {
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('Booking_master','Booking Master');\" >Display Booking</a>";
        }

        if (dstreexml.Tables[0].Rows[0].ItemArray[77].ToString() == "enable")
        {
            tree += "<table border=\"0\" width=\"100%\">";
            tree += "<tr>";
            tree += "<td valign=\"top\">";
            //        tree += "<a onClick=\"\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\">Classified Booking</a>";
            tree += "<a style='cursor:hand;cursor:pointer' class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"javascript:return giveopenpermission('Classified_Booking','Classified Booking');\" >Classified Booking</a>";
            tree += "</td>";
            tree += "</tr>";
            tree += "</table>";
        }

        tree += "</div>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
       
            if (dstreexml.Tables[0].Rows[0].ItemArray[100].ToString() == "enable")
            {
                tree += "<a style='cursor:hand;cursor:pointer' onClick=\"\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\"></a><a     style=\"text-decoration:none;cursor:hand;cursor:pointer\"    class=\"nodescription\" onClick=\"window.open('reports/reportmenu.aspx');\" >Reports</a>";
            }
       
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "</div>";

        // }

        tree += "</td>";
        tree += "</tr>";
        tree += "</table></div>";


    }
}
