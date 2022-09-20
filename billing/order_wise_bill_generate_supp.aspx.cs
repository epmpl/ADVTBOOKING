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

public partial class order_wise_bill_generate_supp : System.Web.UI.Page
{
    string publication = "";
    string publicationcenter = "";
    string publicationcentername = "";
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
    static string invoice_new = "";
    string bill_date_r = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {


            bill_date_r = Session["bill_date"].ToString();

            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            //agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            publicationcenter = Session["center"].ToString();
            publicationcentername = Session["centername"].ToString();

            string[] countbookid1 = ciobookid.Split(',');
            int c4 = countbookid1.Length;



            if (checkradio == "6")
            {

                string page = Session["bill"].ToString();
                if (page == "Bill")
                {
                    BindinsertionWise(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, bill_date_r, publicationcenter, publicationcentername);
                }

                Response.Write("<script>alert('Bill has been generated successfully');</script>");
                Response.Write("<script>window.close();</script>");
                //BindPrintFormsavelast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
            }


        }
    }

    private void BindinsertionWise(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client, string bill_date_re, string publicationcenter, string publicationcentername)
    {
        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] insertionnew = insertion.Split(',');
        DataSet ds4 = new DataSet();
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

        for (inew = 0; inew < c4; inew++)
        {
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision")
            {
                bill_generate_orderwisewise objcard = new bill_generate_orderwisewise();
                objcard = (bill_generate_orderwisewise)(Page.LoadControl("bill_generate_orderwisewise.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.billdater = bill_date_re.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.insertion = insertionnew[inew].ToString();
                objcard.publicationcenter = publicationcenter.ToString();
                objcard.publicationcentername = publicationcentername.ToString();
                objcard.setcardlastnew();

            }
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
            {
                bill_generate_orderwisewise objcard = new bill_generate_orderwisewise();
                objcard = (bill_generate_orderwisewise)(Page.LoadControl("bill_generate_orderwisewise.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.billdater = bill_date_re.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.insertion = insertionnew[inew].ToString();
                objcard.publicationcenter = publicationcenter.ToString();
                objcard.publicationcentername = publicationcentername.ToString();
                objcard.setcardlastnew();

            }
        }
    }
}