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

public partial class adBookingType : System.Web.UI.Page
{

    string compcode = "";

    string flag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        compcode = Session["compcode"].ToString();

        DataSet dsdate1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //NewAdbooking.Classes.BookingMaster cls_book = new NewAdbooking.Classes.BookingMaster();
            //dsdate1 = cls_book.datechkprefer(Session["compcode"].ToString);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster cls_book = new NewAdbooking.classesoracle.BookingMaster();
            dsdate1 = cls_book.bindfmgpermission(Session["compcode"].ToString());
        }

        if (dsdate1.Tables.Count > 0 && dsdate1.Tables[0].Rows.Count>0)
        {

            flag = "1";
        }

       




        if (!Page.IsPostBack)
        {






            bindAdType();
         
            btnSubmit.Attributes.Add("OnClick", "javascript:return openQBC();");
        }









    }
 
    public void bindAdType()
    {
        DataSet billtyp = new DataSet();
        billtyp.ReadXml(Server.MapPath("XML/billcycle.xml"));
        drptype.Items.Clear();
        int i;
      
        //li1.Selected = true;
        if (flag == "1")
        {
            for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
                i = i + 1;
                li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();

                drptype.Items.Add(li);

            }
        }

        else
        {
            for (i = 0; i < billtyp.Tables[3].Columns.Count - 1; i++)
            {
                ListItem li;
                li = new ListItem();
                if (billtyp.Tables[3].Rows[0].ItemArray[i].ToString() != "2" && billtyp.Tables[3].Rows[0].ItemArray[i].ToString() != "FMG")
                {
                    li.Text = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();
                    i = i + 1;
                    li.Value = billtyp.Tables[3].Rows[0].ItemArray[i].ToString();

                    drptype.Items.Add(li);
                }
            }


        }


    }
}
