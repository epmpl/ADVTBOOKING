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

public partial class savenoissuedate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string compcode, userid;

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        compcode = Session["compcode"].ToString();

        if ((Session["issuesave"] == "") || (Session["issuesave"] == null))
        {
            Response.Write("NO");
            Response.End();
        }
        else
        {
            //saurabh code------------------------------------------------
            string noissuecode = Request.QueryString["issuecode"].ToString();
            string edition11=Request.QueryString["editioncd"].ToString();
            //---------------------------end--------------------------------


            DataSet db = (DataSet)Session["issuesave"];
            int er = db.Tables[0].Rows.Count;
            int gf = db.Tables.Count;
            for (int b = 0; b <= gf - 1; b++)
            {
                string issuecode = db.Tables[b].Rows[0].ItemArray[0].ToString();
                string noissueday = db.Tables[b].Rows[0].ItemArray[1].ToString();
                string date= db.Tables[b].Rows[0].ItemArray[2].ToString();

              
                //string desi = db.Tables[b].Rows[0].ItemArray[2].ToString();
                //string txtphoneno = db.Tables[b].Rows[0].ItemArray[3].ToString();

                DataSet ds1 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.NoIssueMaster noissuedateinsert = new NewAdbooking.Classes.NoIssueMaster();
                    ds1 = noissuedateinsert.insertdate(date, noissueday, noissuecode, compcode, userid, Session["dateformat"].ToString());
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.NoIssueMaster noissuedateinsert = new NewAdbooking.classesoracle.NoIssueMaster();
                    ds1 = noissuedateinsert.insertdate(date, noissueday, noissuecode, compcode, userid, Session["dateformat"].ToString(), edition11);
                }
                else
                {
                    NewAdbooking.classmysql.NoIssueMaster noissuedateinsert = new NewAdbooking.classmysql.NoIssueMaster();
                    ds1 = noissuedateinsert.insertdate(date, noissueday, noissuecode, compcode, userid, Session["dateformat"].ToString());
                }
                
                //ds1 = noissuedateinsert.insertcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, userid, centcode, compcode);
                


            }
            //Session["issuesave"] = null;
            Response.Write("Yes");
            Response.End();
        }







    }
}
