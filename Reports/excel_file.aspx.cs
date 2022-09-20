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
using System.Data.OracleClient;

public partial class excel_file : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(excel_file));
  
    
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public DataSet GetData()
    {
        DataSet ds = new DataSet();
    
         OracleCommand objorclcmd = new OracleCommand();

         OracleConnection objorclcon = new OracleConnection("server=4cpvsssrv01;data source=orcl; password=erp11july; user id=erp11july");
        
            OracleDataAdapter objorcldataadap = new OracleDataAdapter();
           
                objorclcon.Open();
                objorclcmd.CommandText = "select * from login";
                objorclcmd.Connection = objorclcon;
                objorclcmd.CommandType = CommandType.Text;
                objorcldataadap.SelectCommand = objorclcmd;
                objorcldataadap.Fill(ds);
      
     
        return ds;
     
    }

}
