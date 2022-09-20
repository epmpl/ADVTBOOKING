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

public partial class chkperiodicity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string value = "";

        string periodicity = Request.QueryString["page"].ToString().Trim();
        string edition = Request.QueryString["edition"].ToString();
        string date = "N";
        string firstdate = Request.QueryString["date1"].ToString();
        string seconddate = Request.QueryString["date2"].ToString();
        string thirdyear = Request.QueryString["date3"].ToString();


        if (edition == "" && periodicity != "")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.EditorMaster chkperiodicty = new NewAdbooking.Classes.EditorMaster();

                //ds = chkperiodicty.chkperiodicty(periodicity);
                ds = chkperiodicty.chkperiodicty(periodicity, "foredition", "", "", "");
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.EditorMaster chkperiodicty = new NewAdbooking.classesoracle.EditorMaster();

                //ds = chkperiodicty.chkperiodicty(periodicity);
                   ds = chkperiodicty.chkperiodicty(periodicity,"foredition","","","");
            }
            else
            {
                NewAdbooking.classmysql.EditorMaster chkperiodicty = new NewAdbooking.classmysql.EditorMaster();
                ds = chkperiodicty.chkperiodicty(periodicity);
            }

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    value = "";
                }
                Response.Write(value);
                Response.End();
         

               
        }
        else  if (edition!="save")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.EditorMaster chkdate = new NewAdbooking.Classes.EditorMaster();

                ds = chkdate.chkdaetedit(Session["compcode"].ToString(), edition);
            }
             else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.EditorMaster chkdate=new NewAdbooking.classesoracle.EditorMaster();
                  ds = chkdate.chkdaetedit(Session["compcode"].ToString(), edition);
            }
            else
            {
                NewAdbooking.classmysql.EditorMaster chkdate = new NewAdbooking.classmysql.EditorMaster();
                ds = chkdate.chkdaetedit(Session["compcode"].ToString(), edition);
            }
                Session["firstdate"] = firstdate;
                Session["seconddate"] = seconddate;
                Session["thirdyear"] = thirdyear;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    date = "Y";
                }
                else
                {
                    date = "N";

                }

                Response.Write(date);
                Response.End();
       }
      
      
      else if (edition == "save")
       {
            Session["firstdate"] = null;
            Session["seconddate"] = null;
            Session["thirdyear"] = null;

       }

        







    }
}
