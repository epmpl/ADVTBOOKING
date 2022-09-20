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

public partial class agency_type_save : System.Web.UI.Page
{
    string dateformat = "";
    string agtype_code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string compcode, userid, message;


        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
             dateformat = Session["dateformat"].ToString();

        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        compcode = Session["compcode"].ToString();
        if (Session["agency_type_slab"] == null)
        {

            Response.Write("commnull");
            return;
        }

        agtype_code = Request.QueryString["agencytypecode"].ToString();


        if ((Session["agency_type_slab"] == "") || (Session["agency_type_slab"] == null))
        {

        }
        else
        {
            DataSet db1 = (DataSet)Session["agency_type_slab"];
            int er1 = db1.Tables[0].Rows.Count;
            int gf1 = db1.Tables.Count;
            DataSet ds = new DataSet();
            for (int b = 0; b <= gf1 - 1; b++)
            {

                string agency_type = agtype_code;
                string comm_type = db1.Tables[b].Rows[0].ItemArray[0].ToString();

                string comm_rate = db1.Tables[b].Rows[0].ItemArray[1].ToString();
                string from_days = db1.Tables[b].Rows[0].ItemArray[2].ToString();
                string till_days = db1.Tables[b].Rows[0].ItemArray[3].ToString();
                string valid_from = getDate(dateformat,db1.Tables[b].Rows[0].ItemArray[4].ToString());
                string valid_to = getDate(dateformat,db1.Tables[b].Rows[0].ItemArray[5].ToString());
                string userid1 = Session["userid"].ToString();
                string extra1 = "";
                string extra2 = "";
                string extra3 = "";
                string extra4 = "";
                string extra5 = "";




              //  string txtefffrom = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[0].ToString());
              //  string txtcommrate = db1.Tables[b].Rows[0].ItemArray[2].ToString();

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {

                    NewAdbooking.Classes.agency_type_slab agentmastersave = new NewAdbooking.Classes.agency_type_slab();
                    ds = agentmastersave.saveagencytype(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);

                
                
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.agency_type_slab agentmastersave = new NewAdbooking.classesoracle.agency_type_slab();
                    ds = agentmastersave.saveagencytype(compcode, agency_type, comm_type, comm_rate, from_days, till_days, valid_from, valid_to, userid1, extra1, extra2, extra3, extra4, extra5);

                }
                else
                {
                }
            }
        
        
        }

        Session["agency_type_slab"] = null;


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
