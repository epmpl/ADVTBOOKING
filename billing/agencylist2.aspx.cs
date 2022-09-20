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

public partial class agencylist2 : System.Web.UI.Page
{
    int j = 0;
    string nameadd;
    string add;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string name = Request.QueryString["page"].ToString();
        string value = Request.QueryString["value"].ToString();

        if (value == "0")
        {
            DataSet dag = new DataSet();
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
             {
                 NewAdbooking.BillingClass.Classes.billing_save getagenameaddress = new NewAdbooking.BillingClass.Classes.billing_save();
                 dag = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);
             }
             else
             {
                 NewAdbooking.BillingClass.classesoracle.billing_save getagenameaddress = new NewAdbooking.BillingClass.classesoracle.billing_save();
                 dag = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);
             }

            if (dag.Tables[0].Rows.Count > 0)
            {
                string clientname = dag.Tables[0].Rows[0].ItemArray[1].ToString();
                string code = dag.Tables[0].Rows[0].ItemArray[0].ToString();
                //string add1 = dag.Tables[0].Rows[0].ItemArray[2].ToString();
                //string add2 = dag.Tables[0].Rows[0].ItemArray[3].ToString();
                //string add3 = dag.Tables[0].Rows[0].ItemArray[4].ToString();

                nameadd = clientname + "(" + code + ")";
                Response.Write(nameadd);
                Response.End();


            }
        }

        else if (value == "1")
        {

            DataSet da = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
                NewAdbooking.BillingClass.Classes.billing_save getagenameaddress = new NewAdbooking.BillingClass.Classes.billing_save();           
            da = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save getagenameaddress = new NewAdbooking.BillingClass.classesoracle.billing_save();
                da = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);

            }

            if (da.Tables[0].Rows.Count > 0)
            {
                string clientname = da.Tables[0].Rows[0].ItemArray[1].ToString();
                string code = da.Tables[0].Rows[0].ItemArray[0].ToString();
                string add1 = da.Tables[0].Rows[0].ItemArray[2].ToString();
                //string add2 = da.Tables[0].Rows[0].ItemArray[3].ToString();
                //string add3 = da.Tables[0].Rows[0].ItemArray[4].ToString();

                nameadd = clientname + "(" + code + ")";// +"+" + add2 + "+" + add3;
                Response.Write(nameadd);
                Response.End();


            }
        }
        else if (value == "2")
        {
            NewAdbooking.Classes.Class1 clsbooking = new NewAdbooking.Classes.Class1();
            DataSet ds = new DataSet();
            ds = clsbooking.bindProduct(Session["compcode"].ToString(), name, value);

            string prod = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            string prodcod = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            nameadd = prod + "(" + prodcod + ")";

            Response.Write(nameadd);
            Response.End();



        }
    }
}
