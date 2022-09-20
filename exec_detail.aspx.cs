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

public partial class exec_detail : System.Web.UI.Page
{
    string country = "0";
    string chktname;
    string countrycode = "0";
    string total;
    string varchk;
    string Comp_Code, userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;

        string country = Request.QueryString["page"].ToString();
        string chkadv=Request.QueryString["chk"].ToString();
        string chktname = Request.QueryString["tname"].ToString();
        string bname = Request.QueryString["bname"].ToString();
        Comp_Code = Session["compcode"].ToString();
        userid = Session["userid"].ToString();

        if (Session["compcode"] == null)
        {
            Response.Write("00");
            return;
        }
        if (chkadv == "save"  && country!="pop")
        {
            string teamcode = country;
            string teamname = chktname;
            string branchname = bname;
            
            DataSet ds = new DataSet();
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.AdvertisementMaster AdvExec = new NewAdbooking.Classes.AdvertisementMaster();

            ds = AdvExec.chkAdv(Comp_Code, teamcode, userid, teamname, branchname);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster AdvExec = new NewAdbooking.classesoracle.AdvertisementMaster();
                ds = AdvExec.chkAdv(Comp_Code, teamcode, userid, teamname, branchname);
            }
            else
            {
                NewAdbooking.classmysql.AdvertisementMaster AdvExec = new NewAdbooking.classmysql.AdvertisementMaster();

                ds = AdvExec.chkAdv(Comp_Code, teamcode, userid, teamname, branchname);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                varchk="Y";
            }
            else if (ds.Tables[2].Rows.Count > 0)
            {
                varchk = "Y1";
            }
            else
            {
                varchk = "N";
            }
              Response.Write(varchk);
              Response.End();
        }
        else if (country=="pop" && Session["exesave"] == null)
        {
            
                varchk = "Y";
           
            Response.Write(varchk);
            Response.End();

        }
        else if (chkadv == "find")
        {
            DataSet ds = new DataSet();

            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.AdvertisementMaster getcount = new NewAdbooking.Classes.AdvertisementMaster();
          
            ds = getcount.valueofcount(country);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.AdvertisementMaster getcount = new NewAdbooking.classesoracle.AdvertisementMaster();
                ds = getcount.valueofcount(country);
            }
            else
            {
                NewAdbooking.classmysql.AdvertisementMaster getcount = new NewAdbooking.classmysql.AdvertisementMaster();

                ds = getcount.valueofcount(country);

            }

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                countrycode = ds.Tables[0].Rows[i].ItemArray[0].ToString() + "," + countrycode;
                country = ds.Tables[0].Rows[i].ItemArray[1].ToString() + "," + country;


            }
            total = country + "+" + countrycode;
            Response.Write(total);
            Response.End();

        }
        else if (chkadv == "query")
        {
            Session["exesave"] = null;
        }
        

    }
}
