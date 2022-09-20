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

public partial class Modbukclient : System.Web.UI.Page
{
    string client = "",clientname="";
    int sno = 1;
    int j = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["clientnam"] != null)
            clientname = Request.QueryString["clientnam"].ToString();
            client = Request.QueryString["clientcod"].ToString();
            hdnagncycod.Value = client;
        

        hiddendateformat.Value = Session["dateformat"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(Modbukclient));

        btnupdate.Attributes.Add("onclick", "javascript:return checkboxid()");
        btnclose.Attributes.Add("onclick", "javascript:return formclose()");
        //DataSet ds_id = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.BillingClass.Classes.classlibraryforbutton perm = new NewAdbooking.BillingClass.Classes.classlibraryforbutton();
        //    ds_id = perm.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname, Session["revenue_add"].ToString());
        //}
        //else
        //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //    {
        //        NewAdbooking.BillingClass.classesoracle.classlibraryforbutton perm = new NewAdbooking.BillingClass.classesoracle.classlibraryforbutton();
        //        ds_id = perm.getbuttonpermission(Session["compcode"].ToString(), Session["userid"].ToString(), formname);
        //    }

        //if (ds_id.Tables[0].Rows.Count <= 0 || ds_id.Tables[0].Rows[0].ItemArray[0].ToString() == "0")
        //{
        //    //Response.Write("<script> alert('You are not authorised to view this page');window.parent.location = 'Default.aspx';</script>");        
        //    Response.Write("<script> alert('You are not authorised to view this page');window.close();</script>");
        //    return;
        //}

        DataSet ds = new DataSet();
        
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            //NewAdbooking.Classes.clinetintranstion name = new NewAdbooking.Classes.clinetintranstion();
            //ds = name.clientinsert1(hiddencompcode.Value, hiddenuserid.Value, clientname);
        }
        else
        {
            NewAdbooking.classesoracle.clinetintranstion name = new NewAdbooking.classesoracle.clinetintranstion();
            ds = name.clientinsert1(hiddencompcode.Value, hiddenuserid.Value, clientname);

        }




        hidden1.Value = ds.Tables[0].Rows.Count.ToString();
        if (hidden1.Value == "0")
        {
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();

            Response.Write("<script> alert('Data Not found');window.close();</script>");
            //    return;
            btnupdate.Visible = false;
            btnclose.Visible = false;


            return;



        }
        else
        {

            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }


    }

    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
         //   string insert = "Insert_" + j;
        //    string edition = "edition_" + j;
            string chekbox = "chekbox_" + j;
            string bilhold = "bilhold_" + j;

           

            e.Item.Cells[0].Text = Convert.ToString(sno++);

           
           
                //if (e.Item.Cells[25].Text == "Y")
                //{
                //    e.Item.Cells[22].Text = "<input type='checkbox' disabled  size='1'   id=" + chekbox + "'   />";
                //}
                //else
               
        //    e.Item.Cells[6].Text = "<input type='checkbox'   size='1'   id=" + chekbox + "'    />";

            j++;
        }
       
    }

    [Ajax.AjaxMethod]
    public DataSet updatestatusnew(string bookingid, string client, string comp_code)
    {
        DataSet ds = new DataSet();

        string err = "";
        try
        {

            if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
            {
                //NewAdbooking.Classes.clinetintranstion name = new NewAdbooking.Classes.clinetintranstion();
                //ds = name.updatestatusnew(bookingid, client, comp_code);
            }
            else
            {
                NewAdbooking.classesoracle.clinetintranstion name = new NewAdbooking.classesoracle.clinetintranstion();
                ds = name.updatestatusnew(bookingid, client, comp_code);
            }


        }
        catch (Exception e)
        {
            err = e.Message;

        }

        //string adcatcode2 = "publish Audit " + bookingid;
        //clsconnection dconnect = new clsconnection();
        //string sqldd = "insert into log_new (DATE1 ,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + userid + "','publish Audit','" + err.Replace("'", "''") + "','publish audit','" + adcatcode2;
        //sqldd = sqldd + "',";
        //sqldd = sqldd + "'" + serverip + "')";
        //dconnect.executenonquery1(sqldd);
        return ds;

    }

}
