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
using System.Drawing;
public partial class bookingauditshowdetailgrid : System.Web.UI.Page
{
    string insert_no = "";
    string packagenam = "";
    int length;
    int fistpacindex;
    DataSet dsglobal = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["packagename"] != null)
        {
            packagenam = Request.QueryString["packagename"].ToString();
        }
        if (Request.QueryString["cioid"] != null)
        {
            string cioid=Request.QueryString["cioid"].ToString();
            //DataSet ds = new DataSet();
            //string err = "";
          //  try
           // {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Booking_Audit1 clsau = new NewAdbooking.classesoracle.Booking_Audit1();
                dsglobal = clsau.bookingdetailgrid(cioid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.Booking_Audit1 clsau = new NewAdbooking.Classes.Booking_Audit1();
                dsglobal = clsau.bookingdetailgrid(cioid);
            }
            else
            {
                string procedureName = "bookingdetailgrid";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { cioid };
                dsglobal = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
           // dsglobal = ds;
            length = dsglobal.Tables[0].Rows.Count;
            DataGrid1.DataSource = dsglobal;
            DataGrid1.DataBind();
          //  }
          //  catch (Exception e1)
           // {
            //    err = e1.Message;

           // }
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
            //To calculate Insertion Amount...
            int a=e.Item.ItemIndex;
            double insertamt=0;
            
            e.Item.Cells[2].Text = packagenam;
            if (e.Item.ItemIndex != 0)
            {
                if (insert_no != e.Item.Cells[0].Text)
                {
                    e.Item.BackColor = System.Drawing.Color.Yellow;
                    for (int k1 = a; k1 < length && a >= 0; k1++)
                    {
                        if (dsglobal.Tables[0].Rows[a]["No_Insert"].ToString() == dsglobal.Tables[0].Rows[k1]["No_Insert"].ToString())
                            insertamt = insertamt + Convert.ToDouble(dsglobal.Tables[0].Rows[k1]["Gross_Rate"].ToString());
                        else
                            break;
                    }
                    e.Item.Cells[18].Text = insertamt.ToString();
                    insert_no = e.Item.Cells[0].Text;
                    fistpacindex = e.Item.ItemIndex;
                }
                else
                {
                    if (e.Item.Cells[8].Text == "&nbsp;")
                        e.Item.Cells[8].Text = "";
                    if (e.Item.Cells[9].Text == "&nbsp;")
                        e.Item.Cells[9].Text = "";
                    if (e.Item.Cells[11].Text == "&nbsp;")
                        e.Item.Cells[11].Text = "";
                    if (e.Item.Cells[12].Text == "&nbsp;")
                        e.Item.Cells[12].Text = "";

                    if (e.Item.Cells[8].Text != dsglobal.Tables[0].Rows[fistpacindex]["Height"].ToString())
                    {
                        e.Item.Cells[8].BackColor = System.Drawing.Color.BlueViolet;
                        e.Item.Cells[8].ForeColor = Color.FromName("White");
                    }
                    if (e.Item.Cells[9].Text != dsglobal.Tables[0].Rows[fistpacindex]["Width"].ToString())
                    {
                        e.Item.Cells[9].BackColor = System.Drawing.Color.BlueViolet;
                        e.Item.Cells[9].ForeColor = Color.FromName("White");
                    }
                    if (e.Item.Cells[11].Text != dsglobal.Tables[0].Rows[fistpacindex]["Remarks"].ToString())
                    {
                        e.Item.Cells[11].BackColor = System.Drawing.Color.BlueViolet;
                        e.Item.Cells[11].ForeColor = Color.FromName("White");
                    }
                    if (e.Item.Cells[12].Text != dsglobal.Tables[0].Rows[fistpacindex]["CAPTION"].ToString())
                    {
                        e.Item.Cells[12].BackColor = System.Drawing.Color.BlueViolet;
                        e.Item.Cells[12].ForeColor = Color.FromName("White");

                    }
                }
            }
            else
            {
                e.Item.BackColor = System.Drawing.Color.Yellow;
                for (int k1 = a; k1 < length && a >= 0; k1++)
                {
                    if (dsglobal.Tables[0].Rows[a]["No_Insert"].ToString() == dsglobal.Tables[0].Rows[k1]["No_Insert"].ToString())
                        insertamt = insertamt + Convert.ToDouble(dsglobal.Tables[0].Rows[k1]["Gross_Rate"].ToString());
                    else
                        break;
                }
                e.Item.Cells[18].Text = insertamt.ToString();
                insert_no = e.Item.Cells[0].Text;
                fistpacindex = 0;
            }
            if (e.Item.Cells[15].Text == "cancel")
                e.Item.BackColor = System.Drawing.Color.OrangeRed;
        }
    }
}
