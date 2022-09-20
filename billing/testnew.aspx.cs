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

public partial class testnew : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        string url1 = HttpContext.Current.Request.Url.ToString();
        if (!url1.Contains("page"))
        {
            ciobookid = Request.QueryString["ciobookid"].ToString();
            checkradio = Request.QueryString["checkradio"].ToString();
            insertion = Request.QueryString["insertion"].ToString();
            editionbill = Request.QueryString["edition"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
           

        }

        string[] countbookid1 = ciobookid.Split(',');
        int c4 = countbookid1.Length;
        BindPrintFormreprint(ciobookid, c4, insertion, editionbill);



        string myscript1 = "<script language='Javascript'>";
        myscript1 += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.print();";
        myscript1 += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript1);
        }




        //string myscript1 = "<script language='Javascript'>";
        //myscript1 += "Object = window.self; windowObject.opener = window.self; windowObject.print();";
        //myscript1 += "printIt();";
        //myscript1 += "</script>";
        //if (!Page.IsStartupScriptRegistered("clientScript"))
        //{
        //    Page.RegisterStartupScript("clientScript", myscript1);
        //}

        

        string myscript = "<script language='Javascript'>";
        myscript += "JavaScript: var windowObject = window.self; windowObject.opener = window.self; windowObject.close();";
        myscript += "</script>";
        if (!Page.IsStartupScriptRegistered("clientScript"))
        {
            Page.RegisterStartupScript("clientScript", myscript);
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

        for (i3 = 0; i3 < count; i3++)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
          //      NewAdbooking.Classes.billing_save objvalues1 = new NewAdbooking.Classes.billing_save();
                NewAdbooking.BillingClass.Classes.billing_save objvalues1 = new NewAdbooking.BillingClass.Classes.billing_save();
                ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);
            }
            else
            {
           //     NewAdbooking.classesoracle.billing_save objvalues1 = new NewAdbooking.classesoracle.billing_save();
                NewAdbooking.BillingClass.classesoracle.billing_save objvalues1 = new NewAdbooking.BillingClass.classesoracle.billing_save();
                    ds5 = objvalues1.selectinvoicefmadbills_ins(countbookid2[i3], insertion2[i3]);

            }

           int countbill = ds5.Tables[0].Rows.Count;
          





            int i = 0;



            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();


            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

        //        NewAdbooking.Classes.invoice objpkg = new NewAdbooking.Classes.invoice();
                NewAdbooking.BillingClass.Classes.invoice objpkg = new NewAdbooking.BillingClass.Classes.invoice();
                ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString());
            }
            else
            {
            //    NewAdbooking.classesoracle.invoice objpkg = new NewAdbooking.classesoracle.invoice();
                NewAdbooking.BillingClass.classesoracle.invoice objpkg = new NewAdbooking.BillingClass.classesoracle.invoice();
                 ds1 = objpkg.packagecode(countbookid2[i3], Session["compcode"].ToString(),Session ["dateformat"].ToString ());

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

                testcontrol objcard = new testcontrol();
                objcard = (testcontrol)(Page.LoadControl("testcontrol.ascx"));



                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);

                objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
                objcard.packagelength = c1.ToString();
                objcard.insertion = i11.ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.qbc = branch;
                objcard.editionnameplus = editionname.ToString();
                objcard.setcard();
            }



                else
                if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "pune")
           {

               punebillre objcard = new punebillre();
               objcard = (punebillre)(Page.LoadControl("punebillre.ascx"));



               objcard.valueofradio = checkradio.ToString();
               placeholder1.Controls.Add(objcard);

               objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
               objcard.packagelength = c1.ToString();
               objcard.insertion = i11.ToString();
               objcard.packagecode = packagecode2.ToString();
               objcard.id = ciobookingid1.ToString();
               objcard.totalinsertion = no_of_insertion.ToString();
               objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
               objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
               objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
               objcard.qbc = branch;
               objcard.editionnameplus = editionname.ToString();
               objcard.setcard();
           }


            else 
           if (ConfigurationSettings.AppSettings["BILLING_FORMAT"].ToString() == "prahaar")
            {
                prhaarre objcard = new prhaarre();
                objcard = (prhaarre)(Page.LoadControl("prhaarre.ascx"));



                objcard.valueofradio = checkradio.ToString();
                placeholder1.Controls.Add(objcard);

                objcard.invoiceno = ds5.Tables[0].Rows[0].ItemArray[0].ToString();
                objcard.packagelength = c1.ToString();
                objcard.insertion = i11.ToString();
                objcard.packagecode = packagecode2.ToString();
                objcard.id = ciobookingid1.ToString();
                objcard.totalinsertion = no_of_insertion.ToString();
                objcard.bookingdate = Convert.ToDateTime(bookingd).ToString("dd/MM/yyy");
                objcard.orderno1 = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                objcard.orderdate = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                objcard.qbc = branch;
                objcard.editionnameplus = editionname.ToString();
                objcard.setcard();
            }
          
            


           
       

            


        }

    }
    protected void lblprint_Click(object sender, EventArgs e)
    {
        
    }
}
