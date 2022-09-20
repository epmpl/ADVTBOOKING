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

public partial class editonforcontractaspx : System.Web.UI.Page
{
    
    string edition = "0";
    string editioncode = "0";
    string totaledition;

    string suppl = "0";
    string supplcode = "0";
    string totalsupp;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string page = Request.QueryString["page"].ToString();
        string str = Request.QueryString["str"].ToString();
        string supp = Request.QueryString["supp"].ToString();

        if (str == "0")
        {
           // NewAdbooking.Classes.Contract getedition = new NewAdbooking.Classes.Contract();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Contract bindeditionfor = new NewAdbooking.Classes.Contract();

                ds = bindeditionfor.editionbind(Session["compcode"].ToString(), page);
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.Contract bindeditionfor = new NewAdbooking.classesoracle.Contract();

                    ds = bindeditionfor.editionbind(Session["compcode"].ToString(), page);

                }
                else
                {
                    NewAdbooking.classmysql.Contract bindeditionfor = new NewAdbooking.classmysql.Contract();

                    ds = bindeditionfor.editionbind(Session["compcode"].ToString(), page);
                }
            for (int k = 0; k <= ds.Tables[0].Rows.Count - 1; k++)
            {
                edition = ds.Tables[0].Rows[k].ItemArray[0].ToString() + "," + edition;
                editioncode = ds.Tables[0].Rows[k].ItemArray[1].ToString() + "," + editioncode;

            }
            totaledition = edition + "+" + editioncode;

            Response.Write(totaledition);
            Response.End();
            //break;

        }
        else
        {
            DataSet dz = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.Contract bindsuppl = new NewAdbooking.Classes.Contract();

                dz = bindsuppl.supplimentbind(Session["compcode"].ToString(), supp);
            }

                 else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.Contract bindsuppl = new NewAdbooking.classesoracle.Contract();
                    dz = bindsuppl.supplimentbind(Session["compcode"].ToString(), supp);

                }
                else
                {
                    NewAdbooking.classmysql.Contract bindsuppl = new NewAdbooking.classmysql.Contract();
                    dz = bindsuppl.supplimentbind(Session["compcode"].ToString(), supp);
                }
            for (int z = 0; z <= dz.Tables[0].Rows.Count - 1; z++)
            {
                suppl = dz.Tables[0].Rows[z].ItemArray[1].ToString() + "," + suppl;
                supplcode = dz.Tables[0].Rows[z].ItemArray[0].ToString() +"," + supplcode;


            }
            totalsupp = supplcode + "+" + suppl;

            Response.Write(totalsupp);
            Response.End();

            //break;





        }
        

    }
}
