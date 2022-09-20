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

public partial class invoice : System.Web.UI.Page
{

    string publication = "";
    string publicationcenter = "";
    string edition = "";
    string fromdt = "";
    string dateto = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        publication = Request.QueryString["publication"].Trim().ToString();
        publicationcenter = Request.QueryString["pubcenter"].Trim().ToString();
        edition = Request.QueryString["edition"].Trim().ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();

        BindPrintForm(publication, publicationcenter, edition, fromdt, dateto,Session ["compcode"].ToString ());
        
    }




    private void BindPrintForm(string publication, string publicationcenter, string edition, string fromdt, string dateto,string compcode)
    {
        //string cardlist = Request.QueryString["Cardno"];
        string[] Arrcardlist = null;

      //  Arrcardlist = cardlist.Split(",".ToCharArray());
        //Process_Card [] objUCcard=new Process_Card[1000];
        //Process_Card obj=new Process_Card();
        //billing objUCcard = new billing();
        //Final_Card objUCcard=new Final_Card();

        string code = "";

        billing objcard = new billing();
       
      

            //ds = objcard.GetCardinfo(Arrcardlist[i], 1);
            //code = objcard.getgroup_code(Arrcardlist[i].ToString());
            //ds=objcard.

            objcard = (billing)(Page.LoadControl("billing.ascx"));
            //placeholder1.Controls.Add(objcard);


            DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

            NewAdbooking.Classes.Class1 abc = new NewAdbooking.Classes.Class1();
            ds = abc.bindgrid(publication, publicationcenter, edition, fromdt, dateto, Session["compcode"].ToString());
        }
        else
        {
           // NewAdbooking.classesoracle.Class1 abc = new NewAdbooking.classesoracle.Class1();
            //ds = abc.bindgrid(publication, publicationcenter, edition, fromdt, dateto, Session["compcode"].ToString());


        }
            int count = ds.Tables[0].Rows.Count;
            //int ciobookingid = ds.Tables[0].Rows[0].ItemArray.ToString();
            int i;
           for (i = 0; i < count; i++)
            {
                string  ciobookingid = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                NewAdbooking .Classes .Class1 abc1=new NewAdbooking.Classes.Class1 ();
                DataSet ds1 = new DataSet();

               
                ds1 = abc1.billing(ciobookingid,Session ["compcode"].ToString ());
                int count1 = ds1.Tables[0].Rows.Count;
                placeholder1.Controls.Add(objcard);
            
                objcard.height = ds1.Tables[0].Rows[i].ItemArray[4].ToString();
                objcard.width = ds1.Tables[0].Rows[i].ItemArray[5].ToString();
                objcard.package = ds1.Tables[0].Rows[i].ItemArray[3].ToString();
                objcard.adcat1 = ds1.Tables[0].Rows[i].ItemArray[12].ToString();
                objcard.pageposition = ds1.Tables[0].Rows[i].ItemArray[11].ToString();
                objcard.rono_date = ds1.Tables[0].Rows[i].ItemArray[8].ToString();
                objcard.insertion = ds1.Tables[0].Rows[i].ItemArray[7].ToString();
                objcard.color = ds1.Tables[0].Rows[i].ItemArray[6].ToString();
                objcard.agency  = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                objcard.publication = ds1.Tables[0].Rows[i].ItemArray[2].ToString();

                objcard.orderno1 = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                objcard.setcard();


           }




           
          
           
                //placeholder1.Controls.Add(objUCcard);
                //objUCcard.Insurancecompany = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                //objUCcard.name = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                //objUCcard.Age = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                //objUCcard.sex = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                //objUCcard.Branchoff = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                //objUCcard.Policyno = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                //objUCcard.Corporate = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                //objUCcard.cardno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                //objUCcard.validity = ds.Tables[0].Rows[0].ItemArray[9].ToString();

                //objUCcard.photo = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                //objUCcard.setcard();
           
            


        //}

       
    }
}
