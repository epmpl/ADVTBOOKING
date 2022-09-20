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

public partial class Leftbar_n : System.Web.UI.UserControl
{

    public string tree = "";


    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/releaseno.xml"));
        lbrelease.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //tP1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //Ajax.Utility.RegisterTypeForAjax(typeof(EnterPage));
        //Ajax.Utility.RegisterTypeForAjax(typeof(ClientMaster));

        // Put user code to initialize the page here
        //    dynamictreeview();
    }
    public void dynamictreeview()
    {

        tree += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"200\" id = 'table1' >";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a onClick=\"toggle(this)\" class=\"folder\"><img src=\"plus.gif\">Display Ad</a>";


        tree += "<div style=\"display:none;\">";
        tree += "<a onClick=\"toggle(this)\" class=\"folder\">&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Booking Scheduling</a>";
        tree += "<div style=\"display:none;\">";
        tree += "<a onClick=\"toggle(this)\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Master</a>";

        tree += "<div  style=\"display:none;\">";
        tree += "<a onClick=\"toggle1(this,'group1')\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Agency/Client Master</a>";
        tree += "<div id=\"group1\" style=\"display:none;\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\"  onClick=\"javascript:return FormPermission('AgencyTypeMaster','Agency Type Master');\" >Agency Type </a>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Agent_master','Agency Master');\" >Agency </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('AgencyCategoryMaster','Agency Category Master');\" >Agency Category</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('AgencySubCategoryMaster','Agency Sub Category Master');\" >Agency Sub Category </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";




        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('ClientMaster','Client Master');\" >Client </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('region_master','Region Master');\" >Region </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";



        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('AdvTypeMaster2','Adv Type Master');\" >Adv Type </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Revenue_master','Revenue Master');\" >Revenue </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('RetainerMaster','Retainer Master');\" >Retainer </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('BranchMaster','Branch Master');\" >Branch </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Agency_EXL_Uploader','Agency Uploader');\" >Agency Uploader </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('DocumentMaster','Document Master');\" >Document </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('RepMast','Representative Master');\" >Representative</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "</div>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        //tree +="<a onClick=\"toggle1(this,'group2')\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Enviornment Masters</a>";
        tree += "<a onClick=\"toggle1(this,'group2')\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Enviornment Master</a>";

        tree += "<div id=\"group2\" style=\"display:none;\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Adsize_master','Ad Size Master');\" >AdSize </a>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('BoxMaster','Box Master');\" >Box </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('MaterialMaster','Material Master');\" >Material </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('ColorMaster','Color Master');\" >Color </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('CurrencyMaster','Currency Master');\" >Currency </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('LanguageMaster','Language Master');\" >Language </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('ZoneMaster','Zone Master');\" >Zone </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('CityMaster','City Master');\" >City </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('CountryMaster','Country Master');\" >Country </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('StateMaster','State Master');\" >State </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('DistrictMaster','District Master');\" >District </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('UOM','UOM Master');\" >UOM </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Bullet_master','Bullet Master');\" >Bullet </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";
        //tree +="</div>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a onClick=\"toggle1(this,'group3')\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Publication Masters</a>";

        tree += "<div id=\"group3\" style=\"display:none;\">";
        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('EditorMaster','Editor Master');\" >Editon </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('PubCatMast','Publication Center Master');\" >Publication Center </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Pageparametermaster','Page Parameter Master');\" >Page Parameter </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('AdvPositionTypMst','Adv Postion Master');\" >Adv Position Type </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Adcategorymaster','Ad Cat. Master');\" >Ad Category </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('adsubcat1','Ad Sub Cat Master');\" >Ad Sub Category </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('AdvExecMaster','Adv Exec. Master');\" >Adv Executive </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";



        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('PublicationMaster','Publication Master');\" >Publication </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('NoIssueMaster','No Issue Master');\" >NoIssue </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('NoIssueDayMaster','No Issue Day Master');\" >NoIssueDay </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "</div>";




        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<a onClick=\"toggle1(this,'group4')\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Rate Masters</a>";
        tree += "<div id=\"group4\" style=\"display:none;\">";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('CombinationMaster','Combination Master');\" >Combination </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('DiscountMaster','Discount Master');\" >Discount </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('Premium_typ_master','Premium Type Master');\" >Premium Type </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('SupplimentMaster','Suppliment Master');\" >Suppliment </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('premium_master','Premium Master');\" >Premium </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('SchemeTypeMaster','Scheme Type Master');\" >Scheme Type </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('SchemeMaster','Scheme Master');\" >Scheme</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('ProductMaster','Product Master');\" >Product </a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return FormPermission('RateGroupMaster','Rate Group Master');\" >Rate Group</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" onClick=\"javascript:return calldepo('DepotIncmaster');\" >Depo Inc.</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";






        tree += "</div>";



        tree += "</div>";






        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a onClick=\"\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"plus.gif\">Reports</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";
        tree += "</div>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        tree += "<a onClick=\"\" class=\"folder\">&nbsp;&nbsp;<img src=\"plus.gif\">Billing</a>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";


        tree += "<a onClick=\"toggle(this)\" class=\"folder\">&nbsp;&nbsp;<img src=\"plus.gif\">Services</a>";

        tree += "<div style=\"display:none;\">";
        tree += "<a  class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\"  class=\"nodescription\" onClick=\"javascript:masterprevilege();\">Master Privilege</a>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";
        //tree +="<br>";
        tree += "<a onClick=\"folder\" class=\"folder\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\"  class=\"nodescription\" href=\"javascript:date();\">Preferences</a>";



        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        tree += "</div>";



        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";


        tree += "<table border=\"0\" width=\"100%\">";
        tree += "<tr>";
        tree += "<td valign=\"top\">";


        tree += "<a  class=\"folder\">&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\" class=\"nodescription\" OnClick=\"javascript: home('Enter Page');\">Home Page</a>";

        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";

        //			tree +="<table border=\"0\" width=\"100%\">";
        //			tree +="<tr>";
        //			tree +="<td valign=\"top\">";
        //			//tree +="<br>";
        //			tree +="<a  class=\"folder\">&nbsp;&nbsp;<img src=\"minus.gif\"></a><a style=\"{text-decoration:none}\"  class=\"nodescription\" href=\"javascript: logout();\">Log Out</a>";
        //
        //
        //
        //
        //			tree +="</td>";
        //			tree +="</tr>";
        //			tree +="</table>";



        tree += "</div>";
        tree += "</td>";
        tree += "</tr>";
        tree += "</table>";




    }
}
