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

public partial class savecontact : System.Web.UI.Page
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

        if ((Session["pubsave"] == "") || (Session["pubsave"] == null))
        {
            //DataSet db = (DataSet)Session["pubsave"];
            //int er = db.Tables[0].Rows.Count;
            //int gf = db.Tables.Count;
            //for (int b = 0; b <= gf - 1; b++)
            //{
            //    string contactperson = db.Tables[b].Rows[0].ItemArray[0].ToString();
            //    string txtdob = db.Tables[b].Rows[0].ItemArray[1].ToString();
            //    string desi = db.Tables[b].Rows[0].ItemArray[2].ToString();
            //    string txtphoneno = db.Tables[b].Rows[0].ItemArray[3].ToString();
            //    string txtext = db.Tables[b].Rows[0].ItemArray[4].ToString();
            //    string txtfaxno = db.Tables[b].Rows[0].ItemArray[5].ToString();
            //    string mail = db.Tables[b].Rows[0].ItemArray[6].ToString();



            //    NewAdbooking.Classes.PubCatMast contactinsert = new NewAdbooking.Classes.PubCatMast();
            //    DataSet ds1 = new DataSet();
            //    ds1 = contactinsert.insertcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, userid, centercode, compcode);

            //}
        }
        else
        {
            //saurabh code------------------------------------------------

            string centcode = Request.QueryString["centcode"].ToString();
            string contactperson1 = Request.QueryString["contactperson"].ToString();
            string dob1 = Request.QueryString["dob"].ToString();
            string desig1 = Request.QueryString["desi"].ToString();
            string phone1 = Request.QueryString["phone"].ToString();
            string ext1 = Request.QueryString["ext"].ToString();
            string fax1 = Request.QueryString["fax"].ToString();
            string email1 = Request.QueryString["email"].ToString();

            string dateformat = Session["dateformat"].ToString();
            //---------------------------end--------------------------------


            DataSet db = (DataSet)Session["pubsave"];
            int er = db.Tables[0].Rows.Count;
            int gf = db.Tables.Count;
            for (int b = 0; b <= gf - 1; b++)
            {
                string contactperson = db.Tables[b].Rows[0].ItemArray[0].ToString();
                string txtdob = getDate(dateformat, db.Tables[b].Rows[0].ItemArray[1].ToString());
                string desi = db.Tables[b].Rows[0].ItemArray[2].ToString();
                string txtphoneno = db.Tables[b].Rows[0].ItemArray[3].ToString();
                string txtext = db.Tables[b].Rows[0].ItemArray[4].ToString();
                string txtfaxno = db.Tables[b].Rows[0].ItemArray[5].ToString();
                string mail = db.Tables[b].Rows[0].ItemArray[6].ToString();

                

                DataSet ds1 = new DataSet();
                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {

                NewAdbooking.Classes.PubCatMast contactinsert = new NewAdbooking.Classes.PubCatMast();
               
                ds1 = contactinsert.insertcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, userid, centcode, compcode);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.PubCatMast contactinsert = new NewAdbooking.classesoracle.PubCatMast();
                    ds1 = contactinsert.insertcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, userid, centcode, compcode, dateformat);
                }
                else
                {
                    NewAdbooking.classmysql.PubCatMast contactinsert = new NewAdbooking.classmysql.PubCatMast();

                    ds1 = contactinsert.insertcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, userid, centcode, compcode);

                }

                Session["pubsave"] = null;   

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
