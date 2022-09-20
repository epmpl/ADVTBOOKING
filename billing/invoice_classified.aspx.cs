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

public partial class invoice_classified : System.Web.UI.Page
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

            //for kathmandu
            bill_date_r = Session["bill_date"].ToString();

            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
           // invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            publicationcenter = Session["center"].ToString();
            publicationcentername = Session["centername"].ToString();



            //ciobookid = Request.QueryString["ciobookid"].ToString();
            //checkradio = Request.QueryString["checkradio"].ToString();
            //insertion = Request.QueryString["insertion"].ToString();
            // hiddendateformat.Value = Session["dateformat"].ToString();
            //frmdt = Request.QueryString["frmdt"].ToString();
            //dateto1 = Request.QueryString["dateto"].ToString();
            //agencycode = Request.QueryString["agencycode"].ToString();
            //client = Request.QueryString["client"].ToString();
            


        }


        string[] agencycode1 = agencycode.Split(',');
        int c4 = agencycode1.Length;





        
        if (checkradio == "first")
        {
            BindPrintFormfir(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }




        if (checkradio == "firstsave")
            {
                string page = Session["bill"].ToString();
                if (page == "Bill")
                {
                    //for kathmandu
                    Bindinsertfirst(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, bill_date_r);
                }
                Response.Write("<script>alert('Bill has been generated successfully');</script>");
                Response.Write("<script>window.close();</script>");
              //  Bindsavefirst(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
            }



        if (checkradio == "1")
        {
            BindPrintForm1(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        else
            if (checkradio == "2")
            {
                string page = Request.QueryString["bill"].ToString();
                if (page == "Bill")
                {
                    BindPrintForminsert(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                }
                BindPrintFormsave(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
            }
            else
                if (checkradio == "3")
                {
                    BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

                }

                else
                    if (checkradio == "4")
                    {
                        BindPrintForm1monthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);

                    }
                    else
                        if (checkradio == "42")
                        {

                            string page = Session["bill"].ToString();
                            if (page == "Bill")
                            {
                                BindPrintForminsertmonthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                            }                           
                             Response.Write("<script>alert('Bill has been generated successfully');</script>");
                           //  Response.Write("<script>window.close();</script>");
                           // BindPrintFormsavemonthly(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
                        }



        if (checkradio == "5")
        {

            BindPrintlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
        }
        
            if (checkradio == "6")
            {

                string page = Session["bill"].ToString();
                if (page == "Bill")
                {
                    Bindinsertlast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, bill_date_r, publicationcenter, publicationcentername);
                }

                Response.Write("<script>alert('Bill has been generated successfully');</script>");
                Response.Write("<script>window.close();</script>");
                //BindPrintFormsavelast(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client);
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

            billing_classi objcard = new billing_classi();
            objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));

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
            punebill objcard = new punebill();
            objcard = (punebill)(Page.LoadControl("punebill.ascx"));


            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.agcode = agencycodeval.ToString();
            objcard.invoiceno = "XXXX".ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();

            objcard.setcardfirst();
            
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
   

    private void BindPrintForm1(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
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

        if (ConfigurationSettings .AppSettings["BILLING_FORMAT"].ToString() == "sambad")
        {

            billing_classi objcard = new billing_classi();
            objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));

            objcard.valueofradio = checkradio.ToString();

            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = "XXXX".ToString();


            objcard.bookingid = ciobookingnew.ToString();

            //objcard.setcardlast();




            
        }
        else
        {
            punebill objcard = new punebill();
            objcard = (punebill)(Page.LoadControl("punebill.ascx"));


            objcard.valueofradio = checkradio.ToString();

            placeholder1.Controls.Add(objcard);           
            objcard.invoiceno = "XXXX".ToString(); 
          
          
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

    private void BindPrintForm1monthly(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split('^');

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



        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
        {
            prahhar_classified objcard = new prahhar_classified();
            objcard = (prahhar_classified)(Page.LoadControl("prahhar_classified.ascx"));


            objcard.valueofradio = checkradio.ToString();

            placeholder1.Controls.Add(objcard);


            objcard.agcode = agencycodeval.ToString();
            objcard.invoiceno = "XXXX".ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();

            objcard.setcardmonthly();
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
        else
        {

            punebillclassi objcard = new punebillclassi();
            objcard = (punebillclassi)(Page.LoadControl("punebillclassi.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.agcode = agencycodeval.ToString();
            objcard.invoiceno = "XXXX".ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();
            objcard.setcardmonthly();
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

    //private void BindPrintFormsave(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    //{


    //    int countintsert_no = 1;
    //    int count = c4;
    //    string[] countbookid2 = ciobookid.Split(',');

    //    string[] agencycode1 = agencycode.Split(',');
    //    string[] client1 = client.Split(',');

    //    DataSet ds4 = new DataSet();

    //    int countmiddlestory;

    //    countmiddlestory = count;
    //    pagecount = countmiddlestory / pagewidth;
    //    pagec = countmiddlestory % 1;
    //    if (pagec > 0)
    //    {
    //        pagecount = pagecount + 1;
    //    }

    //    int rl = j + pagewidth;

    //    if (Request.QueryString["page"] != null)
    //    {
    //        i1 = Convert.ToInt32(Request.QueryString["page"].ToString()) - 1;
    //    }
    //    else
    //    {
    //        i1 = 0;
    //    }




    //    string agencycodeval = agencycode1[i1].ToString();
    //    string ciobookingnew = countbookid2[i1].ToString();
    //    if (client == "")
    //    {
    //        clientnew = "";

    //    }
    //    else
    //    {
    //        clientnew = client1[i1].ToString();
    //    }









    //    int i = 0;



    //    DataSet ds1 = new DataSet();
    //    DataSet ds2 = new DataSet();




    //    int agcode1;



    //    billing_classi objcard = new billing_classi();
    //    objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));
    //    autogenerated("0");
    //    objcard.valueofradio = checkradio.ToString();
    //    placeholder1.Controls.Add(objcard);
    //    objcard.invoiceno = auto.ToString();


    //    objcard.agcode = agencycodeval.ToString();
    //    objcard.fromdate = frmdt.ToString();
    //    objcard.dateto = dateto1.ToString();
    //    objcard.Client = clientnew.ToString();
    //    objcard.bookingid = ciobookingnew.ToString();


    //    objcard.setcard();
    //    if (countmiddlestory > 1)
    //    {
    //        pagging.InnerHtml = "<table cellpadding=0 cellspacing=0 border=0>";
    //        int counter = 0;
    //        for (int j1 = 1; j1 <= pagecount; j1++)
    //        {
    //            if (counter == 0)
    //            {
    //                pagging.InnerHtml += "<tr>";
    //            }
    //            if (j1 == 1 & current1 == 0)
    //            {
    //                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
    //            }
    //            else if (j1 == current1)
    //            {
    //                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
    //            }
    //            else
    //            {
    //                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
    //            }
    //            if (counter == 11)
    //            {
    //                pagging.InnerHtml += "</tr>";
    //                counter = -1;
    //            }
    //            counter++;
    //        }
    //        pagging.InnerHtml += "</tr></table>";




    //    }
        


    //}






    private void Bindsavefirst(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');

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
            billing_classi objcard = new billing_classi();
            objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));      // autogenerated("0");
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);


            objcard.agcode = agencycodeval.ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();
            objcard.setcard();
        }
        else
        {
            punebill objcard = new punebill();
            objcard = (punebill)(Page.LoadControl("punebill.ascx"));


            objcard.valueofradio = checkradio.ToString();

            placeholder1.Controls.Add(objcard);
            // objcard.invoiceno = "XXXX".ToString(); 


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
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else if (j1 == current1)
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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

    private void BindPrintFormsave(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');

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

        if (Session["BILLING_FORMAT"].ToString() == "sambad")
        {
        billing_classi objcard = new billing_classi();
        objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));      // autogenerated("0");
        objcard.valueofradio = checkradio.ToString();
        placeholder1.Controls.Add(objcard);    


        objcard.agcode = agencycodeval.ToString();
        objcard.fromdate = frmdt.ToString();
        objcard.dateto = dateto1.ToString();
        objcard.Client = clientnew.ToString();
        objcard.bookingid = ciobookingnew.ToString();
        objcard.setcard();
        }
          else
        {
            punebill objcard = new punebill();
            objcard = (punebill)(Page.LoadControl("punebill.ascx"));


            objcard.valueofradio = checkradio.ToString();

            placeholder1.Controls.Add(objcard);           
           // objcard.invoiceno = "XXXX".ToString(); 
          
          
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
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else if (j1 == current1)
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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

    //private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client, string invoice_new)
    //{

    //    int countintsert_no = 1;
    //    int count = c4;
    //    string[] countbookid2 = ciobookid.Split(',');

    //    string[] agencycode1 = agencycode.Split(',');
    //    string[] client1 = client.Split(',');
    //    string[] invoicenew1 = invoice_new.Split(',');


    //    DataSet ds4 = new DataSet();

    //    int countmiddlestory;

    //    countmiddlestory = count;
    //    pagecount = countmiddlestory / pagewidth;
    //    pagec = countmiddlestory % 1;
    //    if (pagec > 0)
    //    {
    //        pagecount = pagecount + 1;
    //    }

    //    int rl = j + pagewidth;

    //    if (Request.QueryString["page"] != null)
    //    {
    //        i1 = Convert.ToInt32(Request.QueryString["page"].ToString()) - 1;
    //    }
    //    else
    //    {
    //        i1 = 0;
    //    }




    //    string agencycodeval = agencycode1[i1].ToString();
    //    string ciobookingnew = countbookid2[i1].ToString();
    //    string invoicenew2 = invoicenew1[i1].ToString();
    //    if (client == "")
    //    {
    //        clientnew = "";

    //    }
    //    else
    //    {
    //        clientnew = client1[i1].ToString();
    //    }









    //    int i = 0;



    //    DataSet ds1 = new DataSet();
    //    DataSet ds2 = new DataSet();




    //    int agcode1;



    //    billing_classi objcard = new billing_classi();
    //    objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));


    //    //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    //{
    //    //   // NewAdbooking.Classes.invoice objpkg = new NewAdbooking.Classes.invoice();
    //    //    //ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString());
    //    //}
    //    //else
    //    //{
    //    //    NewAdbooking.classesoracle.Booking_Audit1 objpkg = new NewAdbooking.classesoracle.Booking_Audit1();
    //    //    ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString());
    //    //}
       
    //    objcard.valueofradio = checkradio.ToString();
    //    placeholder1.Controls.Add(objcard);
    //    objcard.invoiceno = invoicenew2.ToString();



    //    objcard.agcode = agencycodeval.ToString();
    //    objcard.fromdate = frmdt.ToString();
    //    objcard.dateto = dateto1.ToString();
    //    objcard.Client = clientnew.ToString();
    //    objcard.bookingid = ciobookingnew.ToString();


    //    objcard.setcard();
    //    if (countmiddlestory > 1)
    //    {
    //        pagging.InnerHtml = "<table cellpadding=0 cellspacing=0 border=0>";
    //        int counter = 0;
    //        for (int j1 = 1; j1 <= pagecount; j1++)
    //        {
    //            if (counter == 0)
    //            {
    //                pagging.InnerHtml += "<tr>";
    //            }
    //            if (j1 == 1 & current1 == 0)
    //            {
    //                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
    //            }
    //            else if (j1 == current1)
    //            {
    //                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
    //            }
    //            else
    //            {
    //                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
    //            }
    //            if (counter == 11)
    //            {
    //                pagging.InnerHtml += "</tr>";
    //                counter = -1;
    //            }
    //            counter++;
    //        }
    //        pagging.InnerHtml += "</tr></table>";




    //    }
        



    //}



    private void Bindinsertfirst(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client, string bill_date_re)
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

                billing_classi objcard = new billing_classi();
                objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));


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
                punebill objcard = new punebill();
                objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                objcard.valueofradio = checkradio.ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                //for kathmandu
                objcard.billdater = bill_date_re.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.setcardlastnew();
            }



        }



    }


    private void BindPrintForminsert(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
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

            if (Session["BILLING_FORMAT"].ToString() == "sambad")
            {

                billing_classi objcard = new billing_classi();
                objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));


                autogenerated("0");
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = auto.ToString();

                objcard.agcode = agencycode1[inew].ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.Client = clientnew.ToString();
                objcard.bookingid = countbookid2[inew].ToString();
                // objcard.setcardnew();
            }

            else
            {
                punebill objcard = new punebill();
                objcard = (punebill)(Page.LoadControl("punebill.ascx"));


                objcard.valueofradio = checkradio.ToString();

                placeholder1.Controls.Add(objcard);
          


                objcard.bookingid = countbookid2[inew].ToString();

                objcard.setcardlastnew();
            }
            
            
           
        }



    }



    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');

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



        billing_classi objcard = new billing_classi();
        objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));

        objcard.valueofradio = checkradio.ToString();
        placeholder1.Controls.Add(objcard);


        objcard.agcode = agencycodeval.ToString();
        objcard.fromdate = frmdt.ToString();
        objcard.dateto = dateto1.ToString();
        objcard.Client = clientnew.ToString();
        objcard.bookingid = ciobookingnew.ToString();


        objcard.setcard();
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


    private void BindPrintFormsavemonthly(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {



        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split('^');

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

        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
        {
            prahhar_classified objcard = new prahhar_classified();
            objcard = (prahhar_classified)(Page.LoadControl("prahhar_classified.ascx"));      // autogenerated("0");
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.agcode = agencycodeval.ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();
            objcard.setcardmonthly();
        }

        else
        {

            punebillclassi objcard = new punebillclassi();
            objcard = (punebillclassi)(Page.LoadControl("punebillclassi.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.agcode = agencycodeval.ToString();
            objcard.invoiceno = "XXXX".ToString();
            objcard.fromdate = frmdt.ToString();
            objcard.dateto = dateto1.ToString();
            objcard.Client = clientnew.ToString();
            objcard.bookingid = ciobookingnew.ToString();
            objcard.setcardmonthly();
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
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else if (j1 == current1)
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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




    private void BindPrintForminsertmonthly(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split('^');

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

        string agencycodeval = agencycode1[i1].ToString();
        string ciobookingnew = countbookid2[i1].ToString();






        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int agcode1;


        for (inew = 0; inew < c4; inew++)
        {

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
            {
                prahhar_classified objcard = new prahhar_classified();
                objcard = (prahhar_classified)(Page.LoadControl("prahhar_classified.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = auto.ToString();
                objcard.agcode = agencycode1[inew].ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.Client = clientnew.ToString();
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.setcardmonthlynew();
            }

            else
            {

                punebillclassi objcard = new punebillclassi();
                objcard = (punebillclassi)(Page.LoadControl("punebillclassi.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.agcode = agencycode1[inew].ToString();
                //objcard.invoiceno = "XXXX".ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.Client = clientnew.ToString();
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.setcardmonthlynew();
            }
                

           
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

        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahhar")
        {


            prahhar_classified objcard = new prahhar_classified();
            objcard = (prahhar_classified)(Page.LoadControl("prahhar_classified.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = "XXXX".ToString();
            objcard.bookingid = ciobookingnew.ToString();
        
            objcard.setcardlast();
        }
        else
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
            {

                punebill objcard = new punebill();
                objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = "XXXX".ToString();
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();
                objcard.bookingid = ciobookingnew.ToString();
                objcard.setcardlast();
            }
            else
            {

                billing_classi objcard = new billing_classi();
                objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));


                objcard.valueofradio = checkradio.ToString();

                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = "XXXX".ToString();


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


    private void Bindinsertlast(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client, string bill_date_re, string publicationcenter, string publicationcentername)
    {

        int inew;
        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');


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

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahhar")
            {


                prahhar_classified objcard = new prahhar_classified();
                objcard = (prahhar_classified)(Page.LoadControl("prahhar_classified.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.bookingid = countbookid2[inew].ToString();
                objcard.setcardlastnew();
            }
            else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {
                    punebill objcard = new punebill();
                    objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                    objcard.valueofradio = checkradio.ToString();
                    placeholder1.Controls.Add(objcard);
                    objcard.bookingid = countbookid2[inew].ToString();
                    objcard.fromdate = frmdt.ToString();
                    objcard.billdater = bill_date_re.ToString();
                    objcard.dateto = dateto1.ToString();
                    objcard.publicationcenter = publicationcenter.ToString();
                    objcard.publicationcentername = publicationcentername.ToString();
                    objcard.setcardlastnew();

                }
                else
                {

                    punebill objcard = new punebill();
                    objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                    objcard.valueofradio = checkradio.ToString();
                    placeholder1.Controls.Add(objcard);
                    objcard.bookingid = countbookid2[inew].ToString();
                    objcard.fromdate = frmdt.ToString();
                    objcard.dateto = dateto1.ToString();
                    objcard.publicationcenter = publicationcenter.ToString();
                    objcard.publicationcentername = publicationcentername.ToString();
                    objcard.setcardlastnew();

                }


        }



    }


    private void BindPrintFormsavelast(string ciobookid, int c4, string insertion, string agencycode, string frmdt, string dateto1, string client)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split('^');

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


        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahhar")
        {


            prahhar_classified objcard = new prahhar_classified();
            objcard = (prahhar_classified)(Page.LoadControl("prahhar_classified.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
            objcard.bookingid = ciobookingnew.ToString();
            objcard.setcardlast();
        }

        else
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
            {
                punebill objcard = new punebill();
                objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                objcard.fromdate = frmdt.ToString();
                objcard.dateto = dateto1.ToString();


                objcard.bookingid = ciobookingnew.ToString();
                objcard.setcardlast();
            }
        else
        {
            billing_classi objcard = new billing_classi();
            objcard = (billing_classi)(Page.LoadControl("billing_classi.ascx"));      // autogenerated("0");
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);
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
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else if (j1 == current1)
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                }
                else
                {
                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/invoice_classified.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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



   // public void autogenerated(string no)
   // {
   //     DataSet dsinvoice = new DataSet();
   //     /*change ankur*/
   //     DateTime dt = DateTime.Now;

   //     string cen = "Delhi".ToString();
   //     cen = cen.Substring(0, 2);
   //     string year = (dt.Year).ToString();
   //     year = year.Substring(2, 2);

   //     string month = (dt.Month).ToString();
   //     //  year = year.Substring(2, 2);
   //     if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
   //     {

   ////     NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
   //         NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
   //     dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
   //     }
   //     else
   //     {
   //    //     NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
   //         NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

   //         dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());

   //     }
   //     string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
   //     double autono1 = Convert.ToDouble(autono);

   //     if (no == "0")
   //     {

   //         string zeros = "";
   //         ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
   //         ////and if it is 2 than center + yrar + uid + 8 digit no.
   //         if (Session["invoice_no"].ToString() == "1")
   //         {
   //             auto = cen + year + autono1;
   //         }
   //         else if (Session["invoice_no"].ToString() == "2")
   //         {
   //             auto = cen + year + month + (autono1);

   //         }
   //     }
   // }






    public void autogenerated(string no)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;
        //string cen = Session["qbc"].ToString();
        string cen = "BHUBANESWAR";
        cen = cen.Substring(0, 2);
        string year = (dt.Year).ToString();
        year = year.Substring(2, 2);

        string month = (dt.Month).ToString();
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            //     NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        else
        {
            //     NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());

        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = Convert.ToDouble(autono);

        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {
                auto = cen + "-" + year + "-" + autono1;
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                auto = cen + "-" + year + "-" + month + "-" + (autono1);

            }
        }
    }





















    }


  



