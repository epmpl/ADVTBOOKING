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

public partial class billing_invoice_package_supp : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {



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
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();

                ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);

            }

            int countbill = ds5.Tables[0].Rows.Count;
            if (countbill == 0)
            {
                // ScriptManager.RegisterClientScriptBlock(this, typeof(invoice_package), "cc", "checklenthbill1()", true);
                // return;

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
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString(),Session ["dateformat"].ToString ());

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



            billing_package_supp objcard = new billing_package_supp();
            objcard = (billing_package_supp)(Page.LoadControl("billing_package_supp.ascx"));
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

            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString(),Session ["dateformat"].ToString ());

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
            billing_package_supp objcard = new billing_package_supp();
            objcard = (billing_package_supp)(Page.LoadControl("billing_package_supp.ascx"));
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

            ds1 = objpkg.packagecode(ciobookingid, Session["compcode"].ToString(),Session ["dateformat"].ToString ());

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
            billing_package_supp objcard = new billing_package_supp();
            objcard = (billing_package_supp)(Page.LoadControl("billing_package_supp.ascx"));
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
                NewAdbooking.BillingClass.classesoracle.billing_save_supp objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save_supp();
                ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);

            }

            int countbill = ds5.Tables[0].Rows.Count;
            int i = 0;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.BillingClass.Classes.billing_save_supp objpkg = new NewAdbooking.BillingClass.Classes.billing_save_supp();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString());
            }
            else
            {
                
               NewAdbooking.BillingClass.classesoracle.billing_save_supp objpkg = new NewAdbooking.BillingClass.classesoracle.billing_save_supp();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString(),Session["dateformat"].ToString () );

            }


            int count1 = ds1.Tables[0].Rows.Count;
            branch = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            string ciobookingid1 = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            string packagecode2 = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            string no_of_insertion = insertion2[i3].ToString();
            string bookingd = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            int count11 = Convert.ToInt16(no_of_insertion);
            string[] packagecode1 = packagecode2.Split(',');
            int c1 = packagecode1.Length;
            DataSet ds3 = new DataSet();

            int i11 = 1;
            int packlength = 1;

            if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "sambad")
            {

                billing_package_supp objcard = new billing_package_supp();
                objcard = (billing_package_supp)(Page.LoadControl("billing_package_supp.ascx"));
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
                    objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
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
                    {
                        billing_package_supp objcard = new billing_package_supp();
                        objcard = (billing_package_supp)(Page.LoadControl("billing_package_supp.ascx"));
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




}
