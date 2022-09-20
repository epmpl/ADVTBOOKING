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

public partial class billing_invoice_cls_supp : System.Web.UI.Page
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
    static string invoice_new = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {
            ciobookid = Request.QueryString["ciobookid"].ToString();
            checkradio = Request.QueryString["checkradio"].ToString();
            insertion = Request.QueryString["insertion"].ToString();
            //invoice_new = Request.QueryString["invoiceno1"].ToString();
            //editionbill = Request.QueryString["edition"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            frmdt = Request.QueryString["frmdt"].ToString();
            dateto1 = Request.QueryString["dateto"].ToString();
            agencycode = Request.QueryString["agencycode"].ToString();
            client = Request.QueryString["client"].ToString();



        }


        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;






        if (checkradio == "first")
        {
            BindPrintFormfir(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }




        if (checkradio == "firstsave")
        {
            string page = Request.QueryString["bill"].ToString();
            if (page == "Bill")
            {
                Bindinsertfirst(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
            }
            //  Bindsavefirst(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }

    }


    private void BindPrintFormfir(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {


        int countintsert_no = 1;

        string[] countbookid2 = ciobookid.Split(',');
        int count = countbookid2.Length;

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');

        DataSet ds4 = new DataSet();

        int countmiddlestory;

        countmiddlestory = count;
        pagecount = countmiddlestory / pagewidth;
        pagec = countmiddlestory % 1;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        int rl = j + pagewidth;

        if (Request.QueryString["page"] != null)
        {
            i1 = Convert.ToInt32(Request.QueryString["page"].ToString()) - 1;
        }
        else
        {
            i1 = 0;
        }




        string agencycodeval = agencycode1[i1].ToString();
        string ciobookingnew = countbookid2[i1].ToString();
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

        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
        {

            samab_cls_supp objcard = new samab_cls_supp();
            objcard = (samab_cls_supp)(Page.LoadControl("samab_cls_supp.ascx"));

            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.agcode = agencycodeval.ToString();
            objcard.invoiceno = "XXXX".ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();

            objcard.setcard();
        }
        else
        {
            //punebill objcard = new punebill();
            //objcard = (punebill)(Page.LoadControl("punebill.ascx"));


            //objcard.valueofradio = checkradio.ToString();
            //placeholder1.Controls.Add(objcard);
            //objcard.agcode = agencycodeval.ToString();
            //objcard.invoiceno = "XXXX".ToString();
            //objcard.fromdate = frmdt.ToString();
            //objcard.dateto = dateto1.ToString();
            //objcard.Client = clientnew.ToString();
            //objcard.bookingid = ciobookingnew.ToString();

            //objcard.setcardfirst();

        }
        if (countmiddlestory > 1)
        {
            pagging.InnerHtml = "<table cellpadding=0 cellspacing=0 border=0>";
            int counter = 0;
            for (int j1 = 1; j1 <= pagecount; j1++)
            {
                if (counter == 0)
                {
                    pagging.InnerHtml += "<tr>";
                }
                if (j1 == 1 & current1 == 0)
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else if (j1 == current1)
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                if (counter == 11)
                {
                    pagging.InnerHtml += "</tr>";
                    counter = -1;
                }
                counter++;
            }
            pagging.InnerHtml += "</tr></table>";

        }








    }


    private void Bindinsertfirst(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');

        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');

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
        int agcode1;


        for (inew = 0; inew < c4; inew++)
        {

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
            {

                samab_cls_supp objcard = new samab_cls_supp();
                objcard = (samab_cls_supp)(Page.LoadControl("samab_cls_supp.ascx"));


                //autogenerated("0");
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = auto.ToString();

                objcard.agcode = agencycode1[inew].ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.Client = clientnew.ToString();
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.setcardnew();
            }

            else
            {
                //punebill objcard = new punebill();
                //objcard = (punebill)(Page.LoadControl("punebill.ascx"));


                //objcard.valueofradio = checkradio.ToString();

                //placeholder1.Controls.Add(objcard);



                //objcard.bookingid = countbookid2[inew].ToString();

                //objcard.setcardlastnew();
            }



        }



    }

}
