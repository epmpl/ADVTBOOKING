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
using System.Web.Mail;
using System.Net;

public partial class pdf : System.Web.UI.Page
{
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
    int inew = 0;
    string  invoice_no="";


    protected void Page_Load(object sender, EventArgs e)
    {
        checkradio = Session["billing_checkradio"].ToString();


        if (checkradio == "42")
        {
            ciobookid = Session["billing_cioid"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();
            hiddensession = Session["hiddensession"].ToString();

            string[] bookingid5ag = ciobookid.Split('^');
            string maxinsert = "";

            string[] agencycode1 = agencycode.Split(',');
            int c4 = agencycode1.Length;
            string[] client1 = client.Split(',');
            string[] invoice1 = invoice.Split(',');



            for (inew = 0; inew < c4; inew++)
            {

                string bookingidn = bookingid5ag[inew];
                string invoicenn = invoice1[inew];
                string agcode = agencycode1[inew];
                PDFGeneratorcls pGen = new PDFGeneratorcls(Server.MapPath("~"));

                string sFile = pGen.Run("pdfprintclassifed.aspx?bookingid=" + bookingidn + "&invoice2=" + invoicenn + "&fromdate=" + frmdt + "&dateto=" + dateto1 + "&agcode=" + agcode);



                DataSet ds4 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.BillingClass.classesoracle.session_billing objvalues1 = new NewAdbooking.BillingClass.classesoracle.session_billing();
                    ds4 = objvalues1.fetch_agency(agcode, Session["compcode"].ToString(), "Monthly");
                }


                string mail_id = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                if (mail_id == "")
                {
                    mail_id = "garima.gupta90@gmail.com";
                }

                System.Net.Mail.MailMessage msgMail = new System.Net.Mail.MailMessage("garima.gupta90@gmail.com", mail_id);


                msgMail.Subject = "Bill from pune nagri";

                string strBody = "Hello Agency";
                msgMail.Body = strBody;
                System.Threading.Thread.Sleep(2000);

                msgMail.CC.Add("garima.gupta90@gmail.com");

                string PATH = Server.MapPath(".") + "\\PRINTPDF\\" + sFile;

                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(PATH);

                msgMail.Attachments.Add(myAttachment);
                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                sc.Host = "192.168.5.128";
                sc.Send(msgMail);
                Response.Write("Email was queued to disk");
            }

        }


        if (checkradio == "7")
        {

            ciobookid = Session["billing_cioid"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();


            string[] countbookid2 = ciobookid.Split(',');

            string[] invoice1 = invoice.Split(',');
            for (inew = 0; inew < countbookid2.Length; inew++)
            {



                string bookingid = countbookid2[inew];
                string invoice2 = invoice1[inew];
                PDFGenerator pGen = new PDFGenerator(Server.MapPath("~"));

                string sFile = pGen.Run("pdf_printdisplay.aspx?bookingid=" + bookingid + "&invoice2=" + invoice2 + "&fromdate=" + frmdt + "&dateto=" + dateto1);

                // string sFile = pGen.Run("classifiednew.aspx");


                //USE PACKAGE HERE 

                DataSet ds4 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.BillingClass.classesoracle.session_billing objvalues1 = new NewAdbooking.BillingClass.classesoracle.session_billing();
                    ds4 = objvalues1.fetch_agency(bookingid, Session["compcode"].ToString(), "orderwiselast");
                }


                string mail_id = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                if (mail_id == "")
                {
                    mail_id = "garima.gupta90@gmail.com";
                }

                System.Net.Mail.MailMessage msgMail = new System.Net.Mail.MailMessage("garima.gupta90@gmail.com", mail_id);
               // msgMail.Bcc.Add("rajneesh.newmedia@gmail.com");

                msgMail.CC.Add("latachugh@gmail.com");
                msgMail.Subject = "Bill from pune nagri";


               // string strBody = "<HTML><BODY><table><tr><td>FROM</td></tr><tr><td>THANKS</td></tr><tr><td>Shree Ambika Printers & Publications</td></tr></table></BODY></HTML>";
                string strBody = "<table><tr><td>Thanks,</td></tr><tr><td>From :-</td></tr><tr><td style='font-family:Arial;color:Red;background-color :Yellow;font-size :medium;font-weight:bold;'>Shree Ambika Printers & Publications</td></tr><tr><td style='font-size :large;color:Purple;font-family:Times New Roman;'>Nilesh Hadawale</td></tr><tr><TD>Cell No.+91 9922901247</TD></tr></table>";
                msgMail.IsBodyHtml = true;
              //  string strBody = "Thanks,From :-Shree Ambika Printers & Publications Office Phone No. 0240-2566100 Nilesh Hadawale Cell No.+91 9922901247";
                
                msgMail.Body = strBody;
                System.Threading.Thread.Sleep(2000);


                string PATH = Server.MapPath(".") + "\\PRINTPDF\\" + sFile;

                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(PATH);

                msgMail.Attachments.Add(myAttachment);
                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                sc.Host = "192.168.5.128";
                sc.Send(msgMail);
                Response.Write("Email was queued to disk");
            }


        }

        if (checkradio == "3")
        {

            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            editionbill = Session["billing_edition"].ToString();
            invoice_no = Session["invoice"].ToString();
            editionbill = editionbill.Replace("^", "+");

            hiddendateformat.Value = Session["dateformat"].ToString();
            string[] countbookid1 = ciobookid.Split(',');
            int c4 = countbookid1.Length;


            int i3;
            int count = c4;
            string[] countbookid2 = ciobookid.Split(',');
            string[] insertion2 = insertion.Split(',');
            string[] invoice_no1 = invoice_no.Split(',');
            string[] editionbill2 = editionbill.Split(',');
            DataSet ds4 = new DataSet();



            string invoice_new = invoice_no1[i1].ToString();
            string ciobookingid = countbookid2[i1].ToString();
            string insertionnew = insertion2[i1].ToString();
            string editionname = editionbill2[i1].ToString();

            DataSet ds5 = new DataSet();

            for (i3 = 0; i3 < count; i3++)
            {

                PDFGeneratorcls_insertion pGen = new PDFGeneratorcls_insertion(Server.MapPath("~"));

                string sFile = pGen.Run("pdf_insertion.aspx?bookingid=" + ciobookingid + "&invoice2=" + invoice_new + "&insertion=" + insertionnew + "&edition=" + editionname);

                string mail_id = "";
                //DataSet ds4 = new DataSet();
                //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                //{
                //    NewAdbooking.BillingClass.classesoracle.session_billing objvalues1 = new NewAdbooking.BillingClass.classesoracle.session_billing();
                //    ds4 = objvalues1.fetch_agency(bookingid, Session["compcode"].ToString(), "orderwiselast");
                //}


                //string mail_id = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                if (mail_id == "")
                {
                    mail_id = "garima.gupta90@gmail.com";
                }

                System.Net.Mail.MailMessage msgMail = new System.Net.Mail.MailMessage("garima.gupta90@gmail.com", mail_id);


                msgMail.Subject = "Bill from pune nagri";

                string strBody = "Hello Agency";
                msgMail.Body = strBody;
                System.Threading.Thread.Sleep(2000);


                string PATH = Server.MapPath(".") + "\\PRINTPDF\\" + sFile;

                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(PATH);

                msgMail.Attachments.Add(myAttachment);
                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                sc.Host = "192.168.5.128";
                sc.Send(msgMail);
                Response.Write("Email was queued to disk");



            }


        }



        if (checkradio == "first")
        {


            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

            string[] agencycode1 = agencycode.Split(',');
            int c4 = agencycode1.Length;

            int inew;
            int countintsert_no = 1;
            int count = c4;
            string[] countbookid2 = ciobookid.Split(',');
            string[] invoice2 = invoice.Split(',');

        
            string[] client1 = client.Split(',');

            DataSet ds4 = new DataSet();









            int i = 0;



            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            int agcode1;


            for (inew = 0; inew < c4; inew++)
            {

                PDFGeneratorcls_first pGen = new PDFGeneratorcls_first(Server.MapPath("~"));

                string sFile = pGen.Run("pfd_orderfirst.aspx?bookingid=" + countbookid2[inew] + "&client=" + client1[inew] + "&fromdate=" + frmdt + "&dateto=" + dateto1);

                string mail_id = "";
                //DataSet ds4 = new DataSet();
                //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                //{
                //    NewAdbooking.BillingClass.classesoracle.session_billing objvalues1 = new NewAdbooking.BillingClass.classesoracle.session_billing();
                //    ds4 = objvalues1.fetch_agency(bookingid, Session["compcode"].ToString(), "orderwiselast");
                //}


                //string mail_id = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                if (mail_id == "")
                {
                    mail_id = "garima.gupta90@gmail.com";
                }

                System.Net.Mail.MailMessage msgMail = new System.Net.Mail.MailMessage("garima.gupta90@gmail.com", mail_id);


                msgMail.Subject = "Bill from pune nagri";

                string strBody = "Hello Agency";
                msgMail.Body = strBody;
                System.Threading.Thread.Sleep(2000);


                string PATH = Server.MapPath(".") + "\\PRINTPDF\\" + sFile;

                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(PATH);

                msgMail.Attachments.Add(myAttachment);
                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                sc.Host = "192.168.5.128";
                sc.Send(msgMail);
                Response.Write("Email was queued to disk");



            }


        }
        if (checkradio == "93")
        {

            ciobookid = Session["billing_cioid"].ToString();
            checkradio = Session["billing_checkradio"].ToString();
            insertion = Session["billing_insertion"].ToString();
            editionbill = Session["billing_edition"].ToString();
            invoice_no = Session["invoice"].ToString();
            editionbill = editionbill.Replace("^", "+");

            hiddendateformat.Value = Session["dateformat"].ToString();
            string[] countbookid1 = ciobookid.Split(',');
            int c4 = countbookid1.Length;


            int i3;
            int count = c4;
            string[] countbookid2 = ciobookid.Split(',');
            string[] insertion2 = insertion.Split(',');
            string[] invoice_no1 = invoice_no.Split(',');
            string[] editionbill2 = editionbill.Split(',');
            DataSet ds4 = new DataSet();



            string invoice_new = invoice_no1[i1].ToString();
            string ciobookingid = countbookid2[i1].ToString();
            string insertionnew = insertion2[i1].ToString();
            string editionname = editionbill2[i1].ToString();

            DataSet ds5 = new DataSet();

            for (i3 = 0; i3 < count; i3++)
            {

                PDFGeneratorcls_insertion pGen = new PDFGeneratorcls_insertion(Server.MapPath("~"));

                string sFile = pGen.Run("pdf_insertion.aspx?bookingid=" + ciobookingid + "&invoice2=" + invoice_new + "&insertion=" + insertionnew + "&edition=" + editionname);

                string mail_id = "";
                //DataSet ds4 = new DataSet();
                //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                //{
                //    NewAdbooking.BillingClass.classesoracle.session_billing objvalues1 = new NewAdbooking.BillingClass.classesoracle.session_billing();
                //    ds4 = objvalues1.fetch_agency(bookingid, Session["compcode"].ToString(), "orderwiselast");
                //}


                //string mail_id = ds4.Tables[0].Rows[0]["EmailID"].ToString();

                if (mail_id == "")
                {
                    mail_id = "kuldeepbhati93@gmail.com";
                }

                System.Net.Mail.MailMessage msgMail = new System.Net.Mail.MailMessage("kuldeepbhati93@gmail.com", mail_id);


                msgMail.Subject = "Bill from pune nagri";

                string strBody = "Hello Agency";
                msgMail.Body = strBody;
                System.Threading.Thread.Sleep(2000);


                string PATH = Server.MapPath(".") + "\\PRINTPDF\\" + sFile;

                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(PATH);

                msgMail.Attachments.Add(myAttachment);
                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                sc.Host = "192.168.5.5";
                sc.Send(msgMail);
                Response.Write("Email was queued to disk");



            }


        }
    }
}