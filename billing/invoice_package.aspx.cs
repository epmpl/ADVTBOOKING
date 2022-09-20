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

public partial class invoice_package : System.Web.UI.Page
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
    static int cheklenth = 1;
    string billing_todat = "";
    string prefix = "";
    string pub_ma = "";
    string _auto;
    protected void Page_Load(object sender, EventArgs e)
    {

        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {
            //ciobookid = Request.QueryString["ciobookid"].ToString();
            //checkradio = Request.QueryString["checkradio"].ToString();
            //insertion = Request.QueryString["insertion"].ToString();
            //editionbill = Request.QueryString["edition"].ToString();



            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            editionbill = Session["billing_edition"].ToString();
            editionbill = editionbill.Replace("^", "+");


            hiddendateformat.Value = Session["dateformat"].ToString();




        }


        string[] countbookid1 = ciobookid.Split(',');
        int c4 = countbookid1.Length;
        if (checkradio == "1")
        {
            BindPrintForm1(ciobookid, c4, insertion, editionbill);
        }
        else
            if (checkradio == "2")
            {
                string page = Session["billing_bill"].ToString();
                billing_todat = Session["billing_todate_v"].ToString();
                if (page == "Bill")
                {
                    BindPrintForminsert(ciobookid, c4, insertion, editionbill, billing_todat);
                    Response.Write("<script>alert('Bill has been generated successfully');</script>");
                    Response.Write("<script>window.close();</script>");
                }
                //BindPrintFormsave(ciobookid, c4, insertion, editionbill);
            }
            else
                if (checkradio == "3")
                {
                    BindPrintFormreprint(ciobookid, c4, insertion, editionbill);
                }




        if (checkradio == "lastpreview")
        {
            last_datepreview(ciobookid, c4, insertion, editionbill);
        }

    }
















    private void last_datepreview(string ciobookid, int c4, string insertion, string editionbill)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] editionbill2 = editionbill.Split(',');
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


        string ciobookingid = countbookid2[i1].ToString();
        string insertionnew = insertion2[i1].ToString();
        string editionname = editionbill2[i1].ToString();




        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();



        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save objpkg = new NewAdbooking.BillingClass.Classes.billing_save();
            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save();

            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString(), Session["dateformat"].ToString());

        }


        int count1 = ds1.Tables[0].Rows.Count;
        branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        string no_of_insertion = insertionnew.ToString();
        string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        int count11 = Convert.ToInt16(no_of_insertion);
        string[] packagecode1 = packagecode2.Split(',');
        int c1 = packagecode1.Length;

        DataSet ds3 = new DataSet();
        int i11 = 1;
        int packlength = 1;
        if (Session["BILLING_FORMAT"].ToString() == "sambad")
        {
            billing_packageprahar objcard = new billing_packageprahar();
            objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = "XXXXX";
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
            {
                objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

            }
            else
            {
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            }

            objcard.qbc = branch;
            objcard.editionnameplus = editionname.ToString();
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
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else if (j1 == current1)
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
            punebill objcard = new punebill();
            objcard = (punebill)(Page.LoadControl("punebill.ascx"));
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = "XXXXX";
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
            {
                objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

            }
            else
            {
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            }

            objcard.qbc = branch;
            objcard.editionnameplus = editionname.ToString();
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
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else if (j1 == current1)
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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



    private void BindPrintForm1(string ciobookid, int c4, string insertion, string editionbill)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] editionbill2 = editionbill.Split(',');
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


        string ciobookingid = countbookid2[i1].ToString();
        string insertionnew = insertion2[i1].ToString();
        string editionname = editionbill2[i1].ToString();




        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();



        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save objpkg = new NewAdbooking.BillingClass.Classes.billing_save();
            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save();

            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString(), Session["dateformat"].ToString());

        }


        int count1 = ds1.Tables[0].Rows.Count;
        branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        string no_of_insertion = insertionnew.ToString();
        string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        int count11 = Convert.ToInt16(no_of_insertion);
        string[] packagecode1 = packagecode2.Split(',');
        int c1 = packagecode1.Length;

        DataSet ds3 = new DataSet();
        int i11 = 1;
        int packlength = 1;
        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
        {
            billing_packageprahar objcard = new billing_packageprahar();
            objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = "XXXXX";
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = bookingd.ToString();
            //objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
            {
                objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

            }
            else
            {
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            }

            objcard.qbc = branch;
            objcard.editionnameplus = editionname.ToString();
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
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else if (j1 == current1)
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "herald")
        {
            herladpreview objcard = new herladpreview();
            objcard = (herladpreview)(Page.LoadControl("herladpreview.ascx"));
            placeholder1.Controls.Add(objcard);
            objcard.invoiceno = "XXXXX";
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = bookingd.ToString();
            //objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
            {
                objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

            }
            else
            {
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            }

            objcard.qbc = branch;
            objcard.editionnameplus = editionname.ToString();
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
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else if (j1 == current1)
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "haribhoomi")//
            {
                haribhoomi_privew objcard = new haribhoomi_privew();
                objcard = (haribhoomi_privew)(Page.LoadControl("haribhoomi_privew.ascx"));
                placeholder1.Controls.Add(objcard);
                objcard.invoiceno = "XXXXX";
                objcard.packagelength = c1.ToString();
                objcard.insertion = insertion2[i1].ToString();//i11.ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                {
                    objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                }
                else
                {
                    objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                }

                objcard.qbc = branch;
                objcard.editionnameplus = editionname.ToString();
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
                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                        }
                        else if (j1 == current1)
                        {
                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                        }
                        else
                        {
                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "arapmedia")
                {
                    arpmedia_billpriv objcard = new arpmedia_billpriv();
                    objcard = (arpmedia_billpriv)(Page.LoadControl("arpmedia_billpriv.ascx"));
                    placeholder1.Controls.Add(objcard);
                    objcard.invoiceno = "XXXXX";
                    objcard.packagelength = c1.ToString();
                    objcard.insertion = i11.ToString();
                    objcard.packagecode = packagecode2.ToString();
                    objcard.id = ciobookingid1.ToString();
                    objcard.totalinsertion = no_of_insertion.ToString();
                    objcard.bookingdate = bookingd.ToString();
                    //objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                    objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                    if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                    {
                        objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                    }
                    else
                    {
                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                    }

                    objcard.qbc = branch;
                    objcard.editionnameplus = editionname.ToString();
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
                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                            }
                            else if (j1 == current1)
                            {
                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                            }
                            else
                            {
                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                    {
                        punebill objcard = new punebill();
                        objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                        placeholder1.Controls.Add(objcard);
                        objcard.invoiceno = "XXXXX";
                        objcard.packagelength = c1.ToString();
                        objcard.insertion = i11.ToString();
                        objcard.packagecode = packagecode2.ToString();
                        objcard.id = ciobookingid1.ToString();
                        objcard.totalinsertion = no_of_insertion.ToString();
                        objcard.bookingdate = bookingd.ToString();
                        // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                        objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                        if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                        {
                            objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                        }
                        else
                        {
                            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                        }

                        objcard.qbc = branch;
                        objcard.editionnameplus = editionname.ToString();
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
                                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                }
                                else if (j1 == current1)
                                {
                                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                }
                                else
                                {
                                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
                        {
                            prhaar objcard = new prhaar();
                            objcard = (prhaar)(Page.LoadControl("prhaar.ascx"));
                            objcard.valueofradio = checkradio.ToString();
                            placeholder1.Controls.Add(objcard);
                            objcard.invoiceno = "XXXXX".ToString();
                            objcard.packagelength = c1.ToString();
                            objcard.insertion = i11.ToString();
                            objcard.packagecode = packagecode2.ToString();
                            objcard.id = ciobookingid1.ToString();
                            objcard.totalinsertion = no_of_insertion.ToString();
                            objcard.bookingdate = bookingd.ToString();
                            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                            objcard.qbc = branch;
                            objcard.editionnameplus = editionname.ToString();
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
                                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                    }
                                    else if (j1 == current1)
                                    {
                                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                    }
                                    else
                                    {
                                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "udayvani")
                            {
                                udayvani_bill_priw objcard = new udayvani_bill_priw();
                                objcard = (udayvani_bill_priw)(Page.LoadControl("udayvani_bill_priw.ascx"));
                                placeholder1.Controls.Add(objcard);
                                objcard.invoiceno = "XXXXX";
                                objcard.packagelength = c1.ToString();
                                objcard.insertion = i11.ToString();
                                objcard.packagecode = packagecode2.ToString();
                                objcard.id = ciobookingid1.ToString();
                                objcard.totalinsertion = no_of_insertion.ToString();
                                objcard.bookingdate = bookingd.ToString();
                                // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                                {
                                    objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                                }
                                else
                                {
                                    objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                }

                                objcard.qbc = branch;
                                objcard.editionnameplus = editionname.ToString();
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
                                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                        }
                                        else if (j1 == current1)
                                        {
                                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                        }
                                        else
                                        {
                                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pratidin")
                                {
                                    pratidinbill objcard = new pratidinbill();
                                    objcard = (pratidinbill)(Page.LoadControl("pratidinbill.ascx"));
                                    placeholder1.Controls.Add(objcard);
                                    objcard.invoiceno = "XXXXX";
                                    objcard.packagelength = c1.ToString();
                                    objcard.insertion = i11.ToString();
                                    objcard.packagecode = packagecode2.ToString();
                                    objcard.id = ciobookingid1.ToString();
                                    objcard.totalinsertion = no_of_insertion.ToString();
                                    objcard.bookingdate = bookingd.ToString();
                                    // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                    objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                    if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                                    {
                                        objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                                    }
                                    else
                                    {
                                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                    }

                                    objcard.qbc = branch;
                                    objcard.editionnameplus = editionname.ToString();
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
                                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                            }
                                            else if (j1 == current1)
                                            {
                                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                            }
                                            else
                                            {
                                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "kannad")
                                    {
                                        kannad_prabha objcard = new kannad_prabha();
                                        objcard = (kannad_prabha)(Page.LoadControl("kannad_prabha.ascx"));
                                        placeholder1.Controls.Add(objcard);
                                        objcard.invoiceno = "XXXXX";
                                        objcard.packagelength = c1.ToString();
                                        objcard.insertion = i11.ToString();
                                        objcard.packagecode = packagecode2.ToString();
                                        objcard.id = ciobookingid1.ToString();
                                        objcard.totalinsertion = no_of_insertion.ToString();
                                        objcard.bookingdate = bookingd.ToString();
                                        // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                        objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                        if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                                        {
                                            objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                                        }
                                        else
                                        {
                                            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                        }

                                        objcard.qbc = branch;
                                        objcard.editionnameplus = editionname.ToString();
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
                                                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                }
                                                else if (j1 == current1)
                                                {
                                                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                }
                                                else
                                                {
                                                    pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                                        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "abp")
                                        {
                                            Abp_bill objcard = new Abp_bill();
                                            objcard = (Abp_bill)(Page.LoadControl("Abp_bill.ascx"));

                                            placeholder1.Controls.Add(objcard);
                                            objcard.invoiceno = "XXXXX";
                                            objcard.packagelength = c1.ToString();
                                            objcard.insertion = i11.ToString();
                                            objcard.packagecode = packagecode2.ToString();
                                            objcard.id = ciobookingid1.ToString();
                                            objcard.totalinsertion = no_of_insertion.ToString();
                                            objcard.bookingdate = bookingd.ToString();
                                            // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                            if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                                            {
                                                objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                                            }
                                            else
                                            {
                                                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                            }

                                            objcard.qbc = branch;
                                            objcard.editionnameplus = editionname.ToString();
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
                                                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                    }
                                                    else if (j1 == current1)
                                                    {
                                                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                    }
                                                    else
                                                    {
                                                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                                            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vigilant")
                                            {
                                                vigilant_media objcard = new vigilant_media();
                                                objcard = (vigilant_media)(Page.LoadControl("vigilant_media.ascx"));

                                                placeholder1.Controls.Add(objcard);
                                                objcard.invoiceno = "XXXXX";
                                                objcard.packagelength = c1.ToString();
                                                objcard.insertion = i11.ToString();
                                                objcard.packagecode = packagecode2.ToString();
                                                objcard.id = ciobookingid1.ToString();
                                                objcard.totalinsertion = no_of_insertion.ToString();
                                                objcard.bookingdate = bookingd.ToString();
                                                // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                                if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                                                {
                                                    objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                                                }
                                                else
                                                {
                                                    objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                                }

                                                objcard.qbc = branch;
                                                objcard.editionnameplus = editionname.ToString();
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
                                                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                        }
                                                        else if (j1 == current1)
                                                        {
                                                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                        }
                                                        else
                                                        {
                                                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
                                                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision")
                                                {
                                                    vision_group_preview objcard = new vision_group_preview();
                                                    objcard = (vision_group_preview)(Page.LoadControl("vision_group_preview.ascx"));

                                                    placeholder1.Controls.Add(objcard);
                                                    objcard.invoiceno = "XXXXX";
                                                    objcard.packagelength = c1.ToString();
                                                    objcard.insertion = i11.ToString();
                                                    objcard.packagecode = packagecode2.ToString();
                                                    objcard.id = ciobookingid1.ToString();
                                                    objcard.totalinsertion = no_of_insertion.ToString();
                                                    objcard.bookingdate = bookingd.ToString();
                                                    // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                                                    objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                                    if (ds1.Tables[0].Rows[0].ItemArray[6].ToString() != "" && ds1.Tables[0].Rows[0].ItemArray[5].ToString() != "")
                                                    {
                                                        objcard.orderdate = "/" + ds1.Tables[0].Rows[0].ItemArray[6].ToString();

                                                    }
                                                    else
                                                    {
                                                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                                    }

                                                    objcard.qbc = branch;
                                                    objcard.editionnameplus = editionname.ToString();
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
                                                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                            }
                                                            else if (j1 == current1)
                                                            {
                                                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                                                            }
                                                            else
                                                            {
                                                                pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "") + "\" class=forumindex><font color='#00000'>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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

    //private void BindPrintForm(string publication, string publicationcenter, string edition, string fromdt, string dateto, string compcode)

    private void BindPrintFormsave(string ciobookid, int c4, string insertion, string editionbill)
    {


        int countintsert_no = 1;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] editionbill2 = editionbill.Split(',');
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


        string ciobookingid = countbookid2[i1].ToString();
        string insertionnew = insertion2[i1].ToString();
        string editionname = editionbill2[i1].ToString();

        DataSet ds5 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //         NewAdbooking.Classes.billing_save objvalues1 = new NewAdbooking.Classes.billing_save();
            NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();

            ds5 = objvalues1.selectinvoicefmadbills_ins(ciobookingid, insertionnew);
        }
        else
        {
            //      NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();
            NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds5 = objvalues1.selectinvoicefmadbills_ins(ciobookingid, insertionnew);

        }

        int countbill = ds5.Tables[0].Rows.Count;
        if (countbill == 0)
        {

        }





        int i = 0;



        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();



        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //    NewAdbooking.Classes.invoice objpkg = new NewAdbooking.Classes.invoice();
            NewAdbooking.BillingClass.Classes.invoice objpkg = new NewAdbooking.BillingClass.Classes.invoice();
            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.billing_save objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString(), Session["dateformat"].ToString());
        }

        int count1 = ds1.Tables[0].Rows.Count;
        branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
        string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        string no_of_insertion = insertionnew.ToString();
        string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

        int count11 = Convert.ToInt16(no_of_insertion);


        string[] packagecode1 = packagecode2.Split(',');
        int c1 = packagecode1.Length;

        DataSet ds3 = new DataSet();

        int i11 = 1;
        int packlength = 1;



        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
        {

            billing_packageprahar objcard = new billing_packageprahar();
            objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);

            objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = bookingd.ToString();
            //  objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            objcard.editionnameplus = editionname.ToString();
            objcard.qbc = branch;

            objcard.setcard();

            string colour = "red";

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
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=blue>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else if (j1 == current1)
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=blue>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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
            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
            {

                punebill objcard = new punebill();
                objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);

                objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
                objcard.packagelength = c1.ToString();
                objcard.insertion = i11.ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = bookingd.ToString();
                //  objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.editionnameplus = editionname.ToString();
                objcard.qbc = branch;

                objcard.setcard();

                string colour = "red";

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
                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=blue>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                        }
                        else if (j1 == current1)
                        {
                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                        }
                        else
                        {
                            pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=blue>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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

        if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
        {
            prhaar objcard = new prhaar();
            objcard = (prhaar)(Page.LoadControl("prhaar.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);

            //autogenerated("0");

            objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = bookingd.ToString();
            // objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            objcard.editionnameplus = editionname.ToString();
            objcard.qbc = branch;

            objcard.setcard();

            string colour = "red";

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
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=blue>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else if (j1 == current1)
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=red>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
                    }
                    else
                    {
                        pagging.InnerHtml += "<td style='padding-left:5px' align='center'><a style='text-decoration:none' href=\"" + Page.ResolveUrl("~/billing/invoice_package.aspx?page=" + j1 + "&bill=" + j1 + "") + "\" class=forumindex><font color=blue>" + j1 + "</font></a>&nbsp;<font class=forumindex>|</font></td>";
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












    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string editionbill)
    {

        int countintsert_no = 1;
        int i3;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] editionbill2 = editionbill.Split(',');
        DataSet ds4 = new DataSet();




        string ciobookingid = countbookid2[i1].ToString();
        string insertionnew = insertion2[i1].ToString();
        string editionname = editionbill2[i1].ToString();

        DataSet ds5 = new DataSet();

        for (i3 = 0; i3 < 2; i3++)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                //      NewAdbooking.Classes.billing_save objvalues1 = new NewAdbooking.Classes.billing_save();
                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();

                ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);
            }
            else
            {
                //      NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();
                //   NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();

                //  ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);

            }






            int i = 0;



            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                //    NewAdbooking.Classes.invoice objpkg = new NewAdbooking.Classes.invoice();
                NewAdbooking.BillingClass.Classes.invoice objpkg = new NewAdbooking.BillingClass.Classes.invoice();

                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString());
            }
            else
            {
                //  NewAdbooking.classesoracle.invoice objpkg = new NewAdbooking.classesoracle.invoice();
                NewAdbooking.BillingClass.classesoracle.invoice objpkg = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString(), Session["dateformat"].ToString());

            }


            int count1 = ds1.Tables[0].Rows.Count;
            branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            string no_of_insertion = insertionnew.ToString();
            string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

            // string bookingd = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            //  string bookingd = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            int count11 = Convert.ToInt16(no_of_insertion);


            string[] packagecode1 = packagecode2.Split(',');
            int c1 = packagecode1.Length;

            DataSet ds3 = new DataSet();

            int i11 = 1;
            int packlength = 1;



            billing_packageprahar objcard = new billing_packageprahar();
            objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
            objcard.valueofradio = checkradio.ToString();
            placeholder1.Controls.Add(objcard);

            objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
            objcard.packagelength = c1.ToString();
            objcard.insertion = i11.ToString();
            objcard.packagecode = packagecode2.ToString();
            objcard.id = ciobookingid1.ToString();
            objcard.totalinsertion = no_of_insertion.ToString();
            objcard.bookingdate = bookingd.ToString();
            //objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            objcard.qbc = branch;
            objcard.editionnameplus = editionname.ToString();
            objcard.setcard();


        }

    }




    private void BindPrintForminsert(string ciobookid, int c4, string insertion, string editionbill, string billing_todat)
    {

        int countintsert_no = 1;
        int i3;
        int count = c4;
        string[] countbookid2 = ciobookid.Split(',');
        string[] insertion2 = insertion.Split(',');
        string[] editionbill2 = editionbill.Split(',');
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();
        for (i3 = 0; i3 < count; i3++)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
                ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);

            }

            int countbill = ds5.Tables[0].Rows.Count;
            int i = 0;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.BillingClass.Classes.invoice objpkg = new NewAdbooking.BillingClass.Classes.invoice();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString());
            }
            else
            {
                NewAdbooking.BillingClass.classesoracle.invoice objpkg = new NewAdbooking.BillingClass.classesoracle.invoice();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString(), Session["dateformat"].ToString());

            }



            prefix = ds1.Tables[0].Rows[0]["prefix"].ToString();
            pub_ma = ds1.Tables[0].Rows[0]["pub_type"].ToString();


            int count1 = ds1.Tables[0].Rows.Count;
            branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

            string publish_date = ds1.Tables[0].Rows[0]["publish_date"].ToString();
            string no_of_insertion = insertion2[i3].ToString();
            string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

            int count11 = Convert.ToInt16(no_of_insertion);
            string[] packagecode1 = packagecode2.Split(',');
            int c1 = packagecode1.Length;
            DataSet ds3 = new DataSet();
            int i11 = 1;
            int packlength = 1;




            if ((ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "udayvani"))
            {

                billing_packageprahar objcard = new billing_packageprahar();
                objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                autogenerated_UDAYVANI(billing_todat, prefix, pub_ma);
                objcard.invoiceno = auto;
                objcard.packagelength = c1.ToString();
                objcard.insertion = i11.ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = bookingd.ToString();
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.qbc = branch;
                objcard.editionnameplus = editionbill2[i3].ToString();
                objcard.setcardnew();

            }







            if ((ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad") || (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pratidin") || (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "herald") || (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "abp"))
            {

                billing_packageprahar objcard = new billing_packageprahar();
                objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);
                autogenerated("0");
                objcard.invoiceno = auto;
                objcard.packagelength = c1.ToString();
                objcard.insertion = i11.ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = bookingd.ToString();
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.qbc = branch;
                objcard.editionnameplus = editionbill2[i3].ToString();
                objcard.setcardnew();

            }
            else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
                {
                    punebill objcard = new punebill();
                    objcard = (punebill)(Page.LoadControl("punebill.ascx"));
                    objcard.valueofradio = checkradio.ToString();
                    placeholder1.Controls.Add(objcard);
                    autogenerated("0");
                    objcard.invoiceno = auto;
                    objcard.packagelength = c1.ToString();
                    objcard.insertion = i11.ToString();
                    objcard.packagecode = packagecode2.ToString();
                    objcard.id = ciobookingid1.ToString();
                    objcard.totalinsertion = no_of_insertion.ToString();
                    objcard.bookingdate = bookingd;//Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                    objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                    objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                    objcard.qbc = branch;
                    objcard.editionnameplus = editionbill2[i3].ToString();
                    objcard.setcardnew();
                }


                else
                    if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
                    {
                        prhaar objcard = new prhaar();
                        objcard = (prhaar)(Page.LoadControl("prhaar.ascx"));
                        objcard.valueofradio = checkradio.ToString();
                        placeholder1.Controls.Add(objcard);
                        autogenerated("0");
                        objcard.invoiceno = auto;
                        objcard.packagelength = c1.ToString();
                        objcard.insertion = i11.ToString();
                        objcard.packagecode = packagecode2.ToString();
                        objcard.id = ciobookingid1.ToString();
                        objcard.totalinsertion = no_of_insertion.ToString();
                        objcard.bookingdate = bookingd.ToString();
                        objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                        objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                        objcard.qbc = branch;
                        objcard.editionnameplus = editionbill2[i3].ToString();
                        objcard.setcardnew();
                    }

                    else
                        if ((ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "haribhoomi"))
                        {

                            billing_packageprahar objcard = new billing_packageprahar();
                            objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
                            objcard.valueofradio = checkradio.ToString();
                            placeholder1.Controls.Add(objcard);
                            autogenerated_haribhoomi("0", publish_date);
                            objcard.invoiceno = _auto;
                            objcard.packagelength = c1.ToString();
                            objcard.insertion = i11.ToString();
                            objcard.packagecode = packagecode2.ToString();
                            objcard.id = ciobookingid1.ToString();
                            objcard.totalinsertion = no_of_insertion.ToString();
                            objcard.bookingdate = bookingd.ToString();
                            objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                            objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                            objcard.qbc = branch;
                            objcard.editionnameplus = editionbill2[i3].ToString();
                            objcard.setcardnew();

                        }

                        else

                            if ((ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "vision"))
                            {
                            }

                            else
                            {
                                billing_packageprahar objcard = new billing_packageprahar();
                                objcard = (billing_packageprahar)(Page.LoadControl("billing_packageprahar.ascx"));
                                objcard.valueofradio = checkradio.ToString();
                                placeholder1.Controls.Add(objcard);
                                autogenerated("0");
                                objcard.invoiceno = auto;
                                objcard.packagelength = c1.ToString();
                                objcard.insertion = i11.ToString();
                                objcard.packagecode = packagecode2.ToString();
                                objcard.id = ciobookingid1.ToString();
                                objcard.totalinsertion = no_of_insertion.ToString();
                                objcard.bookingdate = bookingd.ToString();
                                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                                objcard.qbc = branch;
                                objcard.editionnameplus = editionbill2[i3].ToString();
                                objcard.setcardnew();

                            }








        }

    }



    // public void  autogenerated(string no)
    // {
    //     DataSet dsinvoice = new DataSet();
    //     /*change ankur*/
    //     DateTime dt = DateTime.Now;

    //     string cen = branch.ToString();
    //     cen = cen.Substring(0, 2);
    //     string year = (dt.Year).ToString();
    //     year = year.Substring(2, 2);

    //     string month = (dt.Month).ToString();
    //     //  year = year.Substring(2, 2);
    //     if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //     {
    ////         NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
    //         NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
    //        dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
    //     }
    //     else
    //     {
    //   //      NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
    //         NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

    //         dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
    //     }
    //     string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
    //     double autono1 = 0;
    //     if (autono!="")
    //     {
    //      autono1 = Convert.ToDouble (autono);
    //     }


    //     if (no == "0")
    //     {

    //         string zeros = "";
    //         ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
    //         ////and if it is 2 than center + yrar + uid + 8 digit no.
    //         if (Session["invoice_no"].ToString() == "1")
    //         {
    //             auto = cen + year + (autono1);
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

        string cen = branch.ToString();
        cen = cen.Substring(0, 2);
        //cen = "EM";
        string year = (dt.Year).ToString();
        year = year.Substring(2, 2);

        string month = (dt.Month).ToString();
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //         NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        else
        {
            //      NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = 0;
        if (autono != "")
        {
            autono1 = Convert.ToDouble(autono);
        }


        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {
                auto = cen + "-" + year + "-" + (autono1);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                auto = cen + "-" + year + "-" + month + "-" + (autono1);

            }
        }
    }


    public void autogenerated_UDAYVANI(string no, string prefix1, string pub_ma1)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;

        string[] date_new = no.Split('/');

        // string cen = branch.ToString();
        string cen = Session["centername"].ToString();
        cen = cen.Substring(0, 2);
        // string cen = "Ma";
        string year = (dt.Year).ToString();
        year = year.Substring(2, 2);

        string month = date_new[1];
        string date1 = dt.Day.ToString();
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //         NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
            dsinvoice = objinvoice.invoice_no_uday(Session["compcode"].ToString(), prefix1);
        }
        else
        {
            //      NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = 0;
        if (autono != "")
        {
            autono1 = Convert.ToDouble(autono);
        }




        string zeros = "";
        ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
        ////and if it is 2 than center + yrar + uid + 8 digit no.

        auto = cen + "-" + year + "-" + month + "-" + (autono1);



    }



    public void autogenerated_vision(string no)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;

        string cen = branch.ToString();
        cen = "AD";
        //cen = "EM";
        string year = (dt.Year).ToString();
        year = year.Substring(2, 2);

        string month = (dt.Month).ToString();
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            //         NewAdbooking.Classes.invoice objinvoice = new NewAdbooking.Classes.invoice();
            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();
            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        else
        {
            //      NewAdbooking.classesoracle.invoice objinvoice = new NewAdbooking.classesoracle.invoice();
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = 0;
        if (autono != "")
        {
            autono1 = Convert.ToDouble(autono);
        }


        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {
                auto = cen + "-" + year + "-" + (autono1);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                auto = cen + "-" + year + "-" + month + "-" + (autono1);

            }
        }
    }


    public void autogenerated_haribhoomi(string no, string fromdate)
    {
        DataSet dsinvoice = new DataSet();
        /*change ankur*/
        DateTime dt = DateTime.Now;
        string cen = branch;
        cen = cen.Substring(0, 2);
        string year;
        //string year = (dt.Year).ToString();
        string mm;
        string[] frmdt;
        if (Session["dateformat"].ToString() == "dd/mm/yyyy")
        {
            frmdt = fromdate.Split('/');
            mm = frmdt[1];
            year = frmdt[2];
        }
        else
            if (Session["dateformat"].ToString() == "mm/dd/yyyy")
            {
                frmdt = fromdate.Split('/');
                mm = frmdt[0];
                year = frmdt[2];
            }
            else
            {
                frmdt = fromdate.Split('/');
                mm = frmdt[2];
                year = frmdt[0];
            }


        int nextyr = Convert.ToInt16(year);
        nextyr = nextyr + 1;

        string nextyr1 = nextyr.ToString();
        nextyr1 = nextyr1.Substring(2, 2);


        year = year.Substring(2, 2);
        string cond_flag = "F";

        string month = (dt.Month).ToString();
        //  year = year.Substring(2, 2);
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.invoice objinvoice = new NewAdbooking.BillingClass.Classes.invoice();

            //dsinvoice = objinvoice.invoice_no(Session["compcode"].ToString());
            dsinvoice = objinvoice.invoice_no_haribhoomi(Session["compcode"].ToString(), cen, fromdate, Session["dateformat"].ToString(), cond_flag, cen, "", "");

        }
        else
        {
            NewAdbooking.BillingClass.classesoracle.invoice objinvoice = new NewAdbooking.BillingClass.classesoracle.invoice();

            dsinvoice = objinvoice.invoice_no_pune(Session["compcode"].ToString(), fromdate, Session["dateformat"].ToString(), cond_flag);

        }
        string autono = dsinvoice.Tables[0].Rows[0].ItemArray[0].ToString();
        double autono1 = 0;

        char[] number = autono.ToCharArray();

        if (number.Length < 4)
        {
            if (number.Length == 1)
            {

                autono = "000" + autono;

            }
            else
                if (number.Length == 2)
                {
                    autono = "00" + autono;
                }
                else
                {
                    autono = "0" + autono;
                }


            //autono1 = Convert.ToDouble(autono);
        }


        if (no == "0")
        {

            string zeros = "";
            ////this to chk from the preferrences if from the preferrences it is  1 than generate id as center + year + 8 digit no.
            ////and if it is 2 than center + yrar + uid + 8 digit no.
            if (Session["invoice_no"].ToString() == "1")
            {


                _auto = cen + "/" + year + "-" + mm + "/" + (autono);
            }
            else if (Session["invoice_no"].ToString() == "2")
            {
                _auto = cen + "/" + year + "-" + mm + "/" + (autono);

            }
        }

    }




}