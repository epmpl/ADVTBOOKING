using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class savedesignpopup : System.Web.UI.Page
{

    string compcode, userid, dateformat, logoprem, edition, premimum, amount;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
            dateformat = Session["dateformat"].ToString();

            compcode = Session["compcode"].ToString();

        }
        string desingcode = Request.QueryString["desingcode"].ToString();
        if (Session["DESIGN"] != null)
        {
            DataSet db1 = (DataSet)Session["DESIGN"];

            int er1 = db1.Tables[0].Rows.Count;
            int gf1 = db1.Tables.Count;

            for (int b = 0; b <= gf1 - 1; b++)
            {
                // logoprem=    db1.Tables[b].Rows[0].ItemArray[1].ToString();
                edition = db1.Tables[b].Rows[0].ItemArray[0].ToString();

                if (db1.Tables[b].Rows[0].ItemArray[1].ToString() == "Fixed")
                {
                    premimum = "fix";

                }
                else
                {
                    premimum = "per";
                }


                
              
                string amount = db1.Tables[b].Rows[0].ItemArray[4].ToString();

                string fromdate = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[2].ToString());
                string todate = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[3].ToString());

                DataSet ds = new DataSet();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.AdvDispTypeMst cate = new NewAdbooking.classesoracle.AdvDispTypeMst();
                    ds = cate.save1(compcode, userid, desingcode, edition, premimum, amount,fromdate, todate);


                }

                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {

                         NewAdbooking.Classes.designtype modify = new NewAdbooking.Classes.designtype();

                         ds = modify.save(compcode, userid, desingcode, edition, premimum, amount);

                    }





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

                //dateReturn = mm + "/" + dd + "/" + yyyy;

                dateReturn = dd + "/" + mm + "/" + yyyy;

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
