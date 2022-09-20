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
//using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public partial class invoice_classified_supp : System.Web.UI.Page
{
    string compcode = "";
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
    static string retainer = "";
    static string executive = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds_billing = new DataSet();
        string url1 = HttpContext.Current.Request.Url.ToString();

        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script> window.parent.location=\" login.aspx\";</script>)");
            return;
        }

        if (!url1.Contains("page"))
        {



            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            // invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();


            compcode = Session["compcode"].ToString();

        }


        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;






        if (checkradio == "first")
        {
           // BindPrintFormfir(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }




        if (checkradio == "firstsave")
        {
            string page = Session["bill"].ToString();


            if (page == "Bill")
            {
                //Bindinsertfirst(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
            }
           
        }



        if (checkradio == "1")
        {
            //BindPrintForm1(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        else
            if (checkradio == "2")
            {
                string page = Request.QueryString["bill"].ToString();
                if (page == "Bill")
                {
                   // BindPrintForminsert(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                }
               // BindPrintFormsave(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
            }
            else
                if (checkradio == "3")
                {
                   // BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

                }

                else
                    if (checkradio == "4")
                    {
                      //  BindPrintForm1monthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

                    }
                    else
                        if (checkradio == "42")
                        {






                            retainer = Session["retainer"].ToString();
                            executive = Session["executive"].ToString();

                            string[] retainer1 = retainer.Split(',');
                            string[] executive1 = executive.Split(',');
                            string page = Session["bill"].ToString();
                            if (page == "Bill")
                            {
                               // BindPrintForminsertmonthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                            }
                            Response.Write("<script>alert('Bill has been generated successfully');</script>");
                           
                        }



        if (checkradio == "5")
        {

            BindPrintlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }

        

    }

    private void BindPrintlast(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
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

       
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
            {

                punebill_supp objcard = new punebill_supp();
                objcard = (punebill_supp)(Page.LoadControl("punebill_supp.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = "XXXX".ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.bookingid = ciobookingnew.ToString();
                objcard.setcardlast();
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


}