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

public partial class chkbranch : System.Web.UI.Page
{
    string compcd, userid, varchk;
        		
       
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
         string branchcode = Request.QueryString["page"].ToString();
        string chkadv = Request.QueryString["chk"].ToString();
        compcd = Session["compcode"].ToString();
        userid = Session["userid"].ToString();

        if (Session["compcode"] == null)
        {
             Response.Write("yes");
             return;
        }

        if (chkadv == "save" )
        {
            DataSet ds = new DataSet();
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")

            {

            NewAdbooking.Classes.BranchMaster fillcity = new NewAdbooking.Classes.BranchMaster();
           
            ds = fillcity.branchchk(compcd, userid, branchcode);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster fillcity = new NewAdbooking.classesoracle.BranchMaster();

                    ds = fillcity.branchchk(compcd, userid, branchcode);

                }
                else
                {
                    NewAdbooking.classmysql.BranchMaster fillcity = new NewAdbooking.classmysql.BranchMaster();

                    ds = fillcity.branchchk(compcd, userid, branchcode);


                }

            if (ds.Tables[0].Rows.Count > 0)
            {
                varchk = "Y";
            }
            else
            {
                varchk = "N";
            }
            Response.Write(varchk);
            Response.End();
        }
        else if (chkadv == "pop" )
        {
            if (Session["branchsave"] == null)
             {

            varchk = "Y";
            }
            else
            {
                varchk="N";
            }


            Response.Write(varchk);
            Response.End();

        }
        else if (chkadv == "query" )
        {

            Session["branchsave"] = null;

        }


    }
}
