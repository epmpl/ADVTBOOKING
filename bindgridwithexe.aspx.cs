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

public partial class bindgridwithexe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string comcode = Request.QueryString["comcode1"].ToString();
        string alias = Request.QueryString["alias1"].ToString();
        string packagename = Request.QueryString["packagename1"].ToString();
        string compcode = Request.QueryString["compcode1"].ToString();
        string userid = Request.QueryString["userid1"].ToString();
        string editiontype = Request.QueryString["editiontype1"].ToString();
      

        NewAdbooking.Classes.CombinationMaster execute = new NewAdbooking.Classes.CombinationMaster();
        DataSet da = new DataSet();
        //da = execute.executecommmdetail(comcode, alias, packagename, compcode, userid, editiontype);
        //da.Tables[0].Rows[0].ItemArray[5].ToString();
       // return da;

        //string code = ds.Tables[0].Rows[0].ItemArray[0].ToString();

        string Combin_Code = da.Tables[0].Rows[0].ItemArray[1].ToString();
        string Package_Alias = da.Tables[0].Rows[0].ItemArray[5].ToString();
        string Package_Name = da.Tables[0].Rows[0].ItemArray[4].ToString();
        string Combin_Desc = da.Tables[0].Rows[0].ItemArray[3].ToString();
        string Ad_Type_code = da.Tables[0].Rows[0].ItemArray[11].ToString();
        string Ad_Cat_Code = da.Tables[0].Rows[0].ItemArray[8].ToString();
        string Ad_Subcat_code = da.Tables[0].Rows[0].ItemArray[9].ToString();
        string No_Of_Edition = da.Tables[0].Rows[0].ItemArray[12].ToString();


              Response.Write(Combin_Code+"/"+ Package_Alias+"/"+ Package_Name+"/"+Combin_Desc+"/"+ Ad_Type_code+"/"+ Ad_Cat_Code+"/"+ Ad_Subcat_code+"/"+ No_Of_Edition);

//        Response.Write(da);
       Response.End();


    }
}
