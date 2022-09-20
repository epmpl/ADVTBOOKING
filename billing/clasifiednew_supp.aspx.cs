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

public partial class clasifiednew_supp : System.Web.UI.Page
{
    string publication = "";
    string publicationcenter = "";
    string edition = "";
    string fromdt = "";
    string dateto = "";
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string auto = "";
    string rate_audit = "";
    static string ciobookid = "";
    static string checkradio = "";
    static string insertion = "";
    static string editionbill = "";
    int i3 = 0;
    int pagewidth = 1;
    int ii;
    int jj = 1;
    int kk;
    int ll;
    int pagec;
    int pagecount;
    int j;
    int current1;
    string flag;
    static int current;
    static int a = 0;
    static int b = 1;
    static int i1 = 0;
    string branch;
    string qbc;
    static string frmdt = "";
    static string agencycode = "";
    static string client = "";


    static string dateto1 = "";
    string clientnew = "";
    string invoice = "";
    string hiddensession = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {
            ciobookid = Request.QueryString["ciobookid"].ToString();
            checkradio = Request.QueryString["checkradio"].ToString();
            insertion = Request.QueryString["insertion"].ToString();
            //editionbill = Request.QueryString["edition"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            frmdt = Request.QueryString["frmdt"].ToString();
            dateto1 = Request.QueryString["dateto"].ToString();
            agencycode = Request.QueryString["agencycode"].ToString();
            client = Request.QueryString["client"].ToString();
            invoice = Request.QueryString["invoice_no"].ToString();




        }

        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;

        if (checkradio == "42")
        {



            if (!url1.Contains("page"))
            {
                ciobookid = Request.QueryString["ciobookid"].ToString();
                checkradio = Request.QueryString["checkradio"].ToString();
                insertion = Request.QueryString["insertion"].ToString();
                //editionbill = Request.QueryString["edition"].ToString();
                hiddendateformat.Value = Session["dateformat"].ToString();
                frmdt = Request.QueryString["frmdt"].ToString();
                dateto1 = Request.QueryString["dateto"].ToString();
                agencycode = Request.QueryString["agencycode"].ToString();
                client = Request.QueryString["client"].ToString();
                invoice = Request.QueryString["invoice_no"].ToString();
                hiddensession = Request.QueryString["hiddensession"].ToString();




            }

            // BindPrintFormreprintmonthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

          //  BindPrintFormreprintmonthlyn(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice, hiddensession);

        }
        if (checkradio == "first")
        {
            BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        else
            if (checkradio == "7")
            {

              //  onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                // BindPrintreprintlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

            }




        string myscript1 = "<script language='Javascript'>";
       // myscript1 += "custom_print();";
        //myscript1 += "Object = printIt();";

        myscript1 += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript1);
        }




        string myscript = "<script language='Javascript'>";
        myscript += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.close();";
        myscript += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript);
        }

    }
    private void BindPrintFormreprintmonthly(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client, string invoice, string hiddensession)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split('^');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] invoice1 = invoice.Split(',');

        DataSet ds4 = new DataSet();






        //string agencycodeval = agencycode1[i1].ToString();
        //string ciobookingnew = countbookid2[i1].ToString();
        if (client == "")
        {
            clientnew = "";

        }
        else
        {
            clientnew = client1[i1].ToString();
        }









        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int agcode1;





        for (inew = 0; inew < c4; inew++)
        {


            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahhar")
            {

                //prahhar_classified_re objcard = new prahhar_classified_re();
                //objcard = (prahhar_classified_re)(Page.LoadControl("prahhar_classified_re.ascx"));
                //placeholder1.Controls.Add(objcard);
                //objcard.invoiceno = invoice1[inew].ToString();
                //objcard.agcode = agencycode1[inew].ToString();
                //objcard.fromdate = frmdt.ToString();
                //objcard.dateto = dateto1.ToString();
                //objcard.Client = clientnew.ToString();
                //objcard.bookingid = countbookid2[inew].ToString();
                //objcard.hiddensessionnew = hiddensession.ToString();
               // objcard.setcardmonthly();
            }

            else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {
                    //punebillclassi_re objcard = new punebillclassi_re();
                    //objcard = (punebillclassi_re)(Page.LoadControl("punebillclassi_re.ascx"));
                    //placeholder1.Controls.Add(objcard);
                    //objcard.invoiceno = invoice1[inew].ToString();
                    //objcard.agcode = agencycode1[inew].ToString();
                    //objcard.fromdate = frmdt.ToString();
                    //objcard.dateto = dateto1.ToString();
                    //objcard.Client = clientnew.ToString();
                    //objcard.bookingid = countbookid2[inew].ToString();
                    ////objcard.hiddensessionnew = hiddensession.ToString();
                    //objcard.setcardmonthly();
                }
                else
                {
                    classifed_control_supp objcard = new classifed_control_supp();
                    objcard = (classifed_control_supp)(Page.LoadControl("classifed_control_supp.ascx"));


                    placeholder1.Controls.Add(objcard);
                    objcard.invoiceno = invoice1[inew].ToString();
                    objcard.agcode = agencycode1[inew].ToString();
                    objcard.fromdate = frmdt.ToString();
                    objcard.dateto = dateto1.ToString();
                    objcard.Client = clientnew.ToString();
                    objcard.bookingid = countbookid2[inew].ToString();
                    // objcard.hiddensessionnew = hiddensession.ToString();


                    //objcard.setcardmonthly();
                }
        }



    }
    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] invoice1 = invoice.Split(',');

        DataSet ds4 = new DataSet();






        //string agencycodeval = agencycode1[i1].ToString();
        //string ciobookingnew = countbookid2[i1].ToString();
        if (client == "")
        {
            clientnew = "";

        }
        else
        {
            clientnew = client1[i1].ToString();
        }









        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int agcode1;


        for (inew = 0; inew < c4; inew++)
        {

            classifed_control_supp objcard = new classifed_control_supp();
            objcard = (classifed_control_supp)(Page.LoadControl("classifed_control_supp.ascx"));



            placeholder1.Controls.Add(objcard);



            objcard.agcode = agencycode1[inew].ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = countbookid2[inew].ToString();
            objcard.invoiceno = invoice1[inew].ToString();


            objcard.setcard();
        }



    }


    


 

   
}

