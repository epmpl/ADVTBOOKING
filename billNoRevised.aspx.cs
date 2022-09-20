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

public partial class billNoRevised : System.Web.UI.Page
{
    string dateformat, id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(billNoRevised));
        //   txtcioid.Attributes.Add("OnBlur", "javascript:return fillBillNo();");
        btngo.Attributes.Add("OnClick", "javascript:return checkBillExist();");
        hiddencomcode1.Value = Session["compcode"].ToString();
        hiddenusername.Value = Session["Username"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddenpermission.Value = "";
        string formname = "billNoRevised";
        DataSet dz = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Master checkform = new NewAdbooking.Classes.Master();

            dz = checkform.formpermission(hiddencomcode1.Value, hiddenuserid.Value, formname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master checkform = new NewAdbooking.classesoracle.Master();

                dz = checkform.formpermission(hiddencomcode1.Value, hiddenuserid.Value, formname);
            }
            else
            {
                NewAdbooking.classmysql.Master checkform = new NewAdbooking.classmysql.Master();

                dz = checkform.formpermission(hiddencomcode1.Value, hiddenuserid.Value, formname);
            }

        if (dz.Tables[0].Rows.Count > 0)
        {
            id = dz.Tables[0].Rows[0].ItemArray[0].ToString();
            if (id == "0" || id == "8")
            {
                hiddenpermission.Value = "zero";
                Response.Write("<script>alert('You Are Not Authorised To See This Form');</script>");
                Response.Write("<script>window.close();</script>");
                return;
            }
            if (id == "1" || id == "9")
            {
                one();

            }
            if (id == "2" || id == "10")
            {
                two();
            }
            if (id == "3" || id == "11")
            {
                three();
            }
            if (id == "4" || id == "12")
            {
                four();
            }
            if (id == "5" || id == "13")
            {
                five();
            }
            if (id == "6" || id == "14")
            {
                six();
            }
            if (id == "7" || id == "15")
            {
                seven();
            }
        }
    }
    public void one()
    {
        hiddenpermission.Value = "1";

    }

    public void two()
    {
        hiddenpermission.Value = "2";

    }
    public void three()
    {

        hiddenpermission.Value = "3";

    }

    public void four()
    {
        hiddenpermission.Value = "4";

    }

    public void five()
    {
        hiddenpermission.Value = "5";

    }

    public void six()
    {
        hiddenpermission.Value = "6";

    }
    public void seven()
    {
    }

    private void hiddenpermission_ServerChange(object sender, System.EventArgs e)
    {

    }



    [Ajax.AjaxMethod]
    public void insertintoTempBooking(string billno, string cioid)
    {
        // DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billnorevised clsbill = new NewAdbooking.classesoracle.billnorevised();
            clsbill.insertCioDetail(billno, cioid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.billnorevised clsbill = new NewAdbooking.Classes.billnorevised();
            clsbill.insertCioDetail(billno, cioid);
        }
        //return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet checkBillExist(string billNo,string COMPCODE)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.billnorevised clsbill = new NewAdbooking.classesoracle.billnorevised();
            ds = clsbill.getBill(billNo, COMPCODE);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.billnorevised clsbill = new NewAdbooking.Classes.billnorevised();
            ds = clsbill.getBill(billNo, COMPCODE);
        }
        return ds;
    }
    //[Ajax.AjaxMethod]
    //public DataSet getBillList(string cioid)
    //{
    //    DataSet ds = new DataSet();
    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //    {
    //        NewAdbooking.classesoracle.billnorevised clsbill = new NewAdbooking.classesoracle.billnorevised();
    //        ds = clsbill.getBill(cioid);
    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //    }
    //    return ds;
    //}
}
