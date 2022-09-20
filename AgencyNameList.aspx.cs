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

public partial class AgencyNameList : System.Web.UI.Page
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
                NewAdbooking.Classes.Master getagenameaddress = new NewAdbooking.Classes.Master();
                dag = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master getagenameaddress = new NewAdbooking.classesoracle.Master();
                dag = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);
            }
            else
            {
                NewAdbooking.classmysql.Master getagenameaddress = new NewAdbooking.classmysql.Master();
                dag = getagenameaddress.GetAgencyNameAdd_agency(name, Session["compcode"].ToString(), value);
            }
           

            if (dag.Tables[0].Rows.Count > 0)
            {
                string clientname = dag.Tables[0].Rows[0].ItemArray[1].ToString();
                string code = dag.Tables[0].Rows[0].ItemArray[0].ToString();
                string add1 = dag.Tables[0].Rows[0].ItemArray[2].ToString();
                string add2 = dag.Tables[0].Rows[0].ItemArray[3].ToString();
                string add3 = dag.Tables[0].Rows[0].ItemArray[4].ToString();
                string subcode = dag.Tables[0].Rows[0].ItemArray[5].ToString();
                nameadd = clientname + "+" + code + "+" + add1 + "+" + add2 + "+" + add3 + "+" + subcode;
                
                Response.Write(nameadd);
                Response.End();


            }
        }
        else if (value == "1")
        {
            DataSet dcl = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.ClientMaster getclientnameaddress = new NewAdbooking.Classes.ClientMaster();
                dcl = getclientnameaddress.getClientNamelist(name, Session["compcode"].ToString(), value);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                NewAdbooking.classmysql.ClientMaster getclientnameaddress = new NewAdbooking.classmysql.ClientMaster();
                dcl = getclientnameaddress.getClientNamelist(name, Session["compcode"].ToString(), value);
            }
            else
            {
                NewAdbooking.classesoracle.ClientMaster getclientnameaddress = new NewAdbooking.classesoracle.ClientMaster();
                dcl = getclientnameaddress.getClientNamelist(name, Session["compcode"].ToString(), value);
            }
           

            if (dcl.Tables[0].Rows.Count > 0)
            {
                string clientname = dcl.Tables[0].Rows[0].ItemArray[1].ToString();
                string code = dcl.Tables[0].Rows[0].ItemArray[0].ToString();
                string address = dcl.Tables[0].Rows[0].ItemArray[2].ToString();
                string  alias = dcl.Tables[0].Rows[0].ItemArray[3].ToString();

                nameadd = clientname + "+" + code + "+" +alias+ "+" + address;
                Response.Write(nameadd);
                Response.End();



            }

        }
    }
}
