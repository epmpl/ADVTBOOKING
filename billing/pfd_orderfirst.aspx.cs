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

public partial class pfd_orderfirst : System.Web.UI.Page
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

        ciobookid = Request.QueryString["bookingid"].Trim().ToString();
        invoice = Request.QueryString["client"].Trim().ToString();
        frmdt = Request.QueryString["fromdate"].Trim().ToString();
        dateto1 = Request.QueryString["dateto"].Trim().ToString();

        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;
        BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
    }

    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice2 = invoice.Split(',');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');

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

            classifiedcontrol objcard = new classifiedcontrol();
            objcard = (classifiedcontrol)(Page.LoadControl("classifiedcontrol.ascx"));


            objcard.invoiceno = invoice2[inew].ToString();

            placeholder1.Controls.Add(objcard);



            objcard.agcode = agencycode1[inew].ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = countbookid2[inew].ToString();


            objcard.setcard();
        }



    }

}
