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

public partial class cover_letter : System.Web.UI.Page
{

    static string ciobookid = "";
    static string checkradio = "";
    static string insertion = "";
    static string frmdt = "";
    static string agencycode = "";
    static string client = "";
    static string dateto1 = "";
    string invoice = "";

    protected void Page_Load(object sender, EventArgs e)
    {


        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            //Response.Redirect("login.aspx");
            //Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
            return;
        }
            if (Session["compcode"] != null)
            {
                hiddendateformat.Value = Session["dateformat"].ToString();
                //hiddenunit.Value = Session["unit"].ToString();

                if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    HDN_server_date.Value = DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + DateTime.Today.Year;
                }
                else if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    HDN_server_date.Value = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
                }
                else
                {
                    HDN_server_date.Value = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
                }
            }
        


        checkradio = Session["billing_checkradio"].ToString();

        if (checkradio == "7")
        {


            ciobookid = Session["billing_cioid"].ToString();

            insertion = Session["billing_insertion"].ToString();
            agencycode = Session["agencycode"].ToString();
            dateto1 = Session["dateto"].ToString();
            frmdt = Session["frmdt"].ToString();
            invoice = Session["invoice"].ToString();
            client = Session["client"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();

            string[] countbookid1 = ciobookid.Split(',');
            int c4 = countbookid1.Length;
            onscreen(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);
        }


        if (checkradio == "42")
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

            BindPrintFormreprintmonthlyn(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);
            //BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);

        }

        if (checkradio == "insertionwise")
        {
            ciobookid = Session["billing_cioid"].ToString();
            invoice = Session["invoice"].ToString();
           
            string[] countbookid1 = ciobookid.Split(',');
            int c4 = countbookid1.Length;
            BindPrintFormreprint(ciobookid, c4, insertion, agencycode, frmdt, dateto1, client, invoice);

        }

    }


    private void BindPrintFormreprintmonthlyn(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    {



        int inew;



        string dytbl = "";
        string[] bookingid5ag = ciobookid.Split('^');




        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] invoice1 = invoice.Split(',');
        string agcode = "";
        string Client = "";
        string invoicenn = "";

        int u = 0;

        DataSet ds4 = new DataSet();
        for (inew = 0; inew < c4; inew++)
        {




            invoicenn = invoice1[inew];

            agcode = agencycode1[inew];

            string bookingidn = bookingid5ag[inew];
            string[] bookingid4ag = bookingidn.Split(',');

            string bookingidn11 = bookingidn.Replace(",", "','");


            int countlen = bookingid4ag.Length;



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectmonthlynew_coverletter(agcode, fromdate, dateto, invoicenn, Client, Session["dateformat"].ToString(), bookingidn);
            }
            else
            {
                NewAdbooking.BillingClass.Classes.session_billing objvalues1 = new NewAdbooking.BillingClass.Classes.session_billing();
                ds4 = objvalues1.selectmonthlynew_coverletter(agcode, fromdate, dateto, bookingidn, Client, Session["dateformat"].ToString(), bookingidn);

            }



            printcoverletter obj_RCB1 = new printcoverletter();
            obj_RCB1 = (printcoverletter)Page.LoadControl("printcoverletter.ascx");

            //objcard.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
            //  objcard.lbcompanyname1 = ds4.Tables[0].Rows[0]["companyname"].ToString();
            //  objcard.lbagencyaddtxt1 = ds4.Tables[0].Rows[0]["Agency_address"].ToString() + "," + ds4.Tables[0].Rows[0]["Dist_Code"].ToString();


            //  objcard.txtinvoice1 = invoicenn.ToString();


















            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {





                int chnew = 0;

                string addbook = "";



















                obj_RCB1.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
                obj_RCB1.lbaddress = ds4.Tables[0].Rows[0]["Agency_address"].ToString();

                obj_RCB1.centername = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString();


                //obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();




                obj_RCB1.telephonenumber = ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();


                obj_RCB1.lbrundate1 = ds4.Tables[0].Rows[0]["SYSDATE1"].ToString();



                obj_RCB1.billno = invoicenn.ToString();
                obj_RCB1.billdate = ds4.Tables[0].Rows[0]["BILL_DATE"].ToString();
                double abc1 = 0;
                string ABC = ds4.Tables[0].Rows[0]["Bill_Amt"].ToString();
                if (ABC != "")
                {
                    abc1 = Convert.ToDouble(ABC);
                }
                obj_RCB1.billamount = abc1.ToString("F2");
                obj_RCB1.billrefrence = ds4.Tables[0].Rows[0]["Caption"].ToString();


                obj_RCB1._billrono = ds4.Tables[0].Rows[0]["RO_No"].ToString();
                obj_RCB1._billedition = ds4.Tables[0].Rows[0]["Edition"].ToString();










            }
















            obj_RCB1.setReceiptData();



            Page.Controls.Add(obj_RCB1);









        }

    }

    private void onscreen(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    {



        int inew = 0;



        string[] countbookid2 = ciobookid.Split(',');
        string[] invoice1 = invoice.Split(',');



        for (inew = 0; inew < countbookid2.Length; inew++)
        {

            // NEWGROSSAMT = 0.0;

            string bookingid = countbookid2[inew];
            string invoice2 = invoice1[inew];



            DataSet ds4 = new DataSet();



            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                ds4 = objvalues1.selectlastnew_letter(bookingid, Session["dateformat"].ToString(), fromdate, dateto, invoice2, Session["compcode"].ToString());
            }
            else
            {


            }






            printcoverletter obj_RCB1 = new printcoverletter();
            obj_RCB1 = (printcoverletter)Page.LoadControl("printcoverletter.ascx");

            obj_RCB1.agddxt1 = ds4.Tables[0].Rows[0]["Agency_Name"].ToString();
            obj_RCB1.lbaddress = ds4.Tables[0].Rows[0]["Agency_address"].ToString();

            obj_RCB1.centername = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString();


            //obj_RCB.lbcompaddress1 = ds4.Tables[0].Rows[0]["Add1"].ToString() + "," + ds4.Tables[0].Rows[0]["street_new"].ToString() + ",Telefax:" + ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();




            obj_RCB1.telephonenumber = ds4.Tables[0].Rows[0]["Fax2"].ToString() + "-" + ds4.Tables[0].Rows[0]["Fax3"].ToString();


            obj_RCB1.lbrundate1 = ds4.Tables[0].Rows[0]["SYSDATE1"].ToString();



            obj_RCB1.billno = invoice2.ToString();
            obj_RCB1.billdate = ds4.Tables[0].Rows[0]["BILL_DATE"].ToString();

            double abc1 = 0;
            string ABC = ds4.Tables[0].Rows[0]["Bill_Amt"].ToString();
            if (ABC != "")
            {
                abc1 = Convert.ToDouble(ABC);
            }
            obj_RCB1.billamount = abc1.ToString("F2");
            obj_RCB1.billrefrence = ds4.Tables[0].Rows[0]["Caption"].ToString();


            obj_RCB1._billrono = ds4.Tables[0].Rows[0]["RO_No"].ToString();



            string packagename = "";
            int p;
            for (p = 0; p < ds4.Tables[1].Rows.Count; p++)
            {
                if (packagename == "")
                {
                    packagename = ds4.Tables[1].Rows[p].ItemArray[0].ToString();
                }
                else
                {
                    packagename = packagename + "+" + ds4.Tables[1].Rows[p].ItemArray[0].ToString();
                }
            }

            obj_RCB1.billedition = packagename.ToString();



            obj_RCB1.setReceiptData();

            Page.Controls.Add(obj_RCB1);




































        }





    }



    //------------------------------------------------Vision Coer Letter------------------------------------------------//


    private void BindPrintFormreprint(string ciobookid, int c4, string insertion, string agencycode, string fromdate, string dateto, string client, string invoice)
    {



        int inew;



        string dytbl = "";
        string[] bookingid5ag = ciobookid.Split(',');




        string[] agencycode1 = agencycode.Split(',');
        string[] client1 = client.Split(',');
        string[] invoice1 = invoice.Split(',');
        string agcode = "";
        string Client = "";
        string invoicenn = "";

        int u = 0;

        DataSet ds5 = new DataSet();
        for (inew = 0; inew < c4; inew++)
        {




            invoicenn = invoice1[inew];
            if (agencycode1.Length > 1)
            {
              agcode = agencycode1[inew];
        }

      
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                //NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                //ds4 = objvalues1.selectmonthlynew_coverletter(agcode, fromdate, dateto, invoicenn, Client, Session["dateformat"].ToString(), bookingidn);
            }
            else
            {
                NewAdbooking.BillingClass.Classes.session_billing objvalues1 = new NewAdbooking.BillingClass.Classes.session_billing();
                ds5 = objvalues1.get_agency_name(invoice1[inew], bookingid5ag[inew],Session["dateformat"].ToString());

            }



            new_vision obj_RCB1 = new new_vision();
            obj_RCB1 = (new_vision)Page.LoadControl("new_vision.ascx");
            if (ds5.Tables[0].Rows.Count > 0)
            {
                obj_RCB1.agddxt1 = ds5.Tables[0].Rows[0]["Agency_Name"].ToString();
                obj_RCB1.agddxt11 = invoice1[inew];
                obj_RCB1.agddxt12 = Session["dateformat"].ToString();
                obj_RCB1.agddxt12 = ds5.Tables[0].Rows[0]["BookDate"].ToString();
                obj_RCB1.agddxt13 = ds5.Tables[0].Rows[0]["address"].ToString();

                int i = c4;
                for ( i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    obj_RCB1.agddxt1 = ds5.Tables[0].Rows[0]["Agency_Name"].ToString();
                    obj_RCB1.agddxt11 = invoice1[inew];
                    obj_RCB1.agddxt12 = Session["dateformat"].ToString();
                    obj_RCB1.agddxt12 = ds5.Tables[0].Rows[0]["BookDate"].ToString();
                    obj_RCB1.agddxt13 = ds5.Tables[0].Rows[0]["address"].ToString();

                                 
                }
                obj_RCB1.setReceiptData();
                Page.Controls.Add(obj_RCB1);
            }


        }

    }
}