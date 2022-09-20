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

public partial class paymodeforagency : System.Web.UI.Page
{
    string show;
    string agencode, agencysubcode;
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (Session["compcode"] != null)
        {
            hiddencomcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            show = Request.QueryString["show"].ToString();
            hiddenshow.Value = show;
        }
        else
        {
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
        NewAdbooking.Classes.pop paybind = new NewAdbooking.Classes.pop();
        DataSet dz = new DataSet();

        hiddenagevcode.Value = Request.QueryString["agecode"].ToString();

        string execute = Request.QueryString["akhil"].ToString();



        hiddenagensubcode.Value = Request.QueryString["agencysubcode"].ToString();
        




        agencode = Request.QueryString["agecode"].ToString();
        agencysubcode = Request.QueryString["agencysubcode"].ToString();

        if (agencode == "")
        {

            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }

        if (agencysubcode == "")
        {

            Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Code');window.close();</script>");

            return;
        }

        if (!Page.IsPostBack)
        {
            NewAdbooking.Classes.Master chk = new NewAdbooking.Classes.Master();
            DataSet ds = new DataSet();
            ds = chk.filldatapay(Session["compcode"].ToString(), Session["userid"].ToString());


            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                chkforpay.Items.Add(li);


            }

            //check for pay mode for a particular agency code and sub agency code

           
            dz = paybind.payselect(agencode, Session["userid"].ToString(), Session["compcode"].ToString(), agencysubcode);
            if (dz.Tables[0].Rows.Count > 0)
            {
                bindcheckbox();

            }
            if (show == "1" || show == "2")
            {
                if (dz.Tables[0].Rows.Count > 0)
                {
                    btnselect.Enabled = false;
                    updatepay.Enabled = true;

                }
                else
                {
                    btnselect.Enabled = true;
                    updatepay.Enabled = false;
                }
            }
            else
            {
                btnselect.Enabled = false;
                updatepay.Enabled = false;
            }

            /////////////////
        }

       

    }
    protected void btnselect_Click(object sender, EventArgs e)
    {

        string abc = "";
        foreach (ListItem li in chkforpay.Items)
        {

            if (li.Selected == true)
            {
                if (li.Value != "")
                {

                    abc = abc + li.Value + ",";
                }

            }
        }
        string ab = abc;

        NewAdbooking.Classes.pop CustCode = new NewAdbooking.Classes.pop();
        DataSet ds = new DataSet();

        CustCode.insertpay(agencode, Session["compcode"].ToString(), Session["userid"].ToString(), agencysubcode, ab);

        btnselect.Visible=false;
        updatepay.Visible = true;
    }

    public void bindcheckbox()
    {
        NewAdbooking.Classes.pop paybind = new NewAdbooking.Classes.pop();
        DataSet dz = new DataSet();
        dz = paybind.payselect(agencode, Session["userid"].ToString(), Session["compcode"].ToString(), agencysubcode);
        //string sizecode = dz.Tables[0].Rows[0].ItemArray[0].ToString();
        string listcode = dz.Tables[0].Rows[0].ItemArray[0].ToString();

        int i;
        char[] splitter = { ',' };



        string[] myarray = listcode.Split(splitter);

        for (i = 0; i <= myarray.Length - 1; i++)
        {
            if (myarray[i] != "")
            {
                if (myarray[i] != "0")
                {

                    chkforpay.Items.FindByValue(myarray[i]).Selected = true;
                    //chkforpay.Items.FindByValue("0").Selected = false;

                }
            }
        }
    }

    protected void updatepay_Click(object sender, EventArgs e)
    {
        string abc = "";
        foreach (ListItem li in chkforpay.Items)
        {

            if (li.Selected == true)
            {
                if (li.Value != "")
                {

                    abc = abc + li.Value + ",";
                }

            }
        }
        string ab = abc;

        NewAdbooking.Classes.pop update = new NewAdbooking.Classes.pop();
        DataSet da = new DataSet();
        da = update.payinsert(agencode, Session["compcode"].ToString(), Session["userid"].ToString(), agencysubcode, ab);

    }

    protected void updatepay_Click1(object sender, EventArgs e)
    {
        string abc = "";
        foreach (ListItem li in chkforpay.Items)
        {

            if (li.Selected == true)
            {
                if (li.Value != "")
                {

                    abc = abc + li.Value + ",";
                }

            }
        }
        string ab = abc;

        NewAdbooking.Classes.pop update = new NewAdbooking.Classes.pop();
        DataSet da = new DataSet();
        da = update.payinsert(agencode, Session["compcode"].ToString(), Session["userid"].ToString(), agencysubcode, ab);

    }
   
}
