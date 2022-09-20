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

public partial class savestatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string compcode, userid;

        //for PCMContact





        //for PCM Status



        //centercode, status, fromdate, todate, circular)

        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("yes");
            return;
        }

        compcode = Session["compcode"].ToString();

        if ((Session["pubstatus"] == "") || (Session["pubstatus"] == null))
        {
        }
        else
        {

            //saurabh code------------------------------------------------


            string status1 = Request.QueryString["status"].ToString();
            string fromdate1 = Request.QueryString["fromdate"].ToString();
            string todate1 = Request.QueryString["todate"].ToString();
            string circular1 = Request.QueryString["circular"].ToString();
            string centercode = Request.QueryString["centercode"].ToString();

            string dateformat = Session["dateformat"].ToString();
            //---------------------------end--------------------------------

            DataSet db1 = (DataSet)Session["pubstatus"];
            int er1 = db1.Tables[0].Rows.Count;
            int gf1 = db1.Tables.Count;
            for (int b = 0; b <= gf1 - 1; b++)
            {
                string status = db1.Tables[b].Rows[0].ItemArray[5].ToString();
                string fromdate = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[1].ToString());
                string todate = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[2].ToString());
                string circular = db1.Tables[b].Rows[0].ItemArray[4].ToString();
                //string txtext = db.Tables[b].Rows[0].ItemArray[4].ToString();
                //string txtfaxno = db.Tables[b].Rows[0].ItemArray[5].ToString();
                //string mail = db.Tables[b].Rows[0].ItemArray[6].ToString();


                DataSet ds1 = new DataSet();
                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
                NewAdbooking.Classes.PubCatMast insert = new NewAdbooking.Classes.PubCatMast();
              
                ds1 = insert.insertpcmstatus(compcode, userid, centercode, status, fromdate, todate, circular);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.PubCatMast insert = new NewAdbooking.classesoracle.PubCatMast();
                    ds1 = insert.insertpcmstatus(compcode, userid, centercode, status, fromdate, todate, circular, dateformat);
                }
                else
                {
                    NewAdbooking.classmysql.PubCatMast insert = new NewAdbooking.classmysql.PubCatMast();

                    ds1 = insert.insertpcmstatus(compcode, userid, centercode, status, fromdate, todate, circular);

                }
                Session["pubstatus"] = null;
            }


        }





    }
    public string getDate(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        if (dateValue != "")
        {
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];

                dateReturn = mm + "/" + dd + "/" + yyyy;


            }
            //else if (dateformat == "yyyy/mm/dd")
            //{
            //    yyyy = myarrayfrom[0];
            //    mm = myarrayfrom[1];
            //    dd = myarrayfrom[2];

            //    dateReturn = mm + "/" + dd + "/" + yyyy;
            //}
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }
}
