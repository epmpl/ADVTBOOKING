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

public partial class bindimagecheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string name = "";
        string name1 = "";
        DataSet ds = new DataSet();

        string packagedesc = Request.QueryString["page"].ToString();
        //try
        //{
        //    NewAdbooking.Classes.CombinationMaster getpackagecode = new NewAdbooking.Classes.CombinationMaster();
            
           //ds = getpackagecode.packcode(packagedesc, Session["compcode"].ToString());
        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}

        //if (ds.Tables[0].Rows.Count > 0)
       //{
            //string packagecode = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        DataSet dl = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
            NewAdbooking.Classes.RateMaster binddescrip = new NewAdbooking.Classes.RateMaster();
        
            dl = binddescrip.getdescription(packagedesc, Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.RateMaster binddescrip = new NewAdbooking.classesoracle.RateMaster();

                dl = binddescrip.getdescription(packagedesc, Session["compcode"].ToString());

            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "binddescription12_binddescription12_p";
                string[] parameterValueArray = { packagedesc, Session["compcode"].ToString() };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                dl = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            
            }
        else
        {
  //          NewAdbooking.classmysql.RateMaster binddescrip = new NewAdbooking.classmysql.RateMaster();
            
//            dl = binddescrip.getdescription(packagedesc, Session["compcode"].ToString());
        }

            if (dl.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j <= dl.Tables[0].Rows.Count - 1; j++)
                {
                    if (name == "")
                    {
                        name = dl.Tables[0].Rows[j].ItemArray[0].ToString() ;
                    }
                    else
                    {
                        name = dl.Tables[0].Rows[j].ItemArray[0].ToString() + "," + name;
                    }
                }
                Response.Write(name);
                Response.End();

            }
            else
            {
                name = "";
                Response.Write(name);
                Response.End();
            }

        //}
        //else
        //{
        //    name = "";
        //    Response.Write(name);
        //    Response.End();
        //}

    }
}
