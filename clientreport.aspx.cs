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
using System.IO;
using System.Data.SqlClient;

public partial class clientreport : System.Web.UI.Page
{
    string agency = "";
    string client="";
    string prod = "";
    string prod1 = "";
    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(clientreport), "ShowAlert", strAlert, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["compcode"] = "HT001";
        hiddencompcode.Value = Session["compcode"].ToString();
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;
        //string u=Session["userid"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lbsubcat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbsubsubcat.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lbbrand.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        lbvarient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        //lblprod.Text=ds.Tables[0].Rows[0].ItemArray[4].ToString();
       // lbaaddress.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();


         Ajax.Utility.RegisterTypeForAjax(typeof(clientreport));
         //txtfrmdate.Focus();
         
         
        if (!Page.IsPostBack)
        {
              bindpublication();
        bindregion();
        //Adcategory();
        //bindProduct();
        binddest();
            lstagency.Attributes.Add("onkeypress", "return keySort(this);");
            lstagency.Attributes.Add("onclick", "javascript:return insertagency();");
            lstclient.Attributes.Add("onclick", "javascript:return insertclient();");
            lstclient.Attributes.Add("onkeypress", "return keySort(this);");
            lstproduct.Attributes.Add("onclick", "javascript:return insertproduct();");
            lstproduct.Attributes.Add("onkeypress", "return keySort(this);");
            dpsubcat.Attributes.Add("onchange", "javascript:return selectsubcat();");
            drpbrand.Attributes.Add("onchange", "javascript:return selectvarient();");
            dpsubsubcat.Attributes.Add("onchange", "javascript:return selectbrand();");
            dpvarient.Attributes.Add("Onchange", "javascript:return selectvalue();");
            //  New Functions for date
            BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");


            ScriptManager2.SetFocus(txtfrmdate);            
        }
    }
    

     public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("xml/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
       //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        Txtdest.Items.Add(li1);

        for (i = 0; i < destination.Tables[0].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = destination.Tables[0].Rows[0].ItemArray[i].ToString();
            Txtdest.Items.Add(li);

        }

}
    



        //bindagencyname(Session["compcode"].ToString(), txtagency.Text);
        //bindagencyname();
        //bindclientname();
        //getbrand();
      
        //string agencyaddress = txtagencyaddress.Text;
        //string clientaddresses = txtclientadd.Text;


       // txtagency.Text = "";
        //txtclient.Text = "";
        //txtagencyaddress.Text = "";
        //txtclientadd.Text = "";
        //txtfrmdate.Focus();





    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string agencycod = txtagency.Text;
        string clientcode = txtclient.Text;
        string prodcode = txtproduct.Text;
        //////////////this is to split the  and get the code
        if (agencycod != "")
        {
            char[] splitter = { '(' };
            string[] myarray = agencycod.Split(splitter);
            agency = myarray[1];
            agency = agency.Replace(")", "");
        }
        if (clientcode != "")
        {
            char[] splitter = { '(' };
            string[] myarray1 = clientcode.Split(splitter);
            client = myarray1[1];
            client = client.Replace(")", "");
        }
        if (prodcode != "")
        {
            char[] splitter = { '(' };
            string[] myarray1 = prodcode.Split(splitter);
            prod1 = myarray1[0];
            prod1 = prod1.Replace(")", "");
            prod = myarray1[1];
            prod = prod.Replace(")", "");
        }

        string subcat = dpsubcat1.Value;
        string subsubcat = dpsubsubcat1.Value;
        string brand = dpbrand1.Value;
        string var = dpvarient1.Value;

        NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ds = obj.onscreenreportforclient(txtfrmdate.Text, txttodate1.Text, txtagency.Text, txtclient.Text, dppub1.SelectedValue, txtproduct.Text, dpsubcat.SelectedValue, dpsubsubcat.SelectedValue, drpbrand.SelectedValue, dpvarient.SelectedValue, dpregion.SelectedValue, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(clientreport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;

            Response.Redirect("clientview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&publiccode=" + dppub1.SelectedValue + "&publication=" + dppub1.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&Product=" + prod1 + "&regioncode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&agency=" + agency + "&client=" + client + "&subcat=" + subcat + "&subsubcat=" + subsubcat + "&brand=" + brand + "&varient=" + var);//+"&Agencycode="+txtagency.Text.Length);

           // &destination=" + Txtdest.SelectedItem.Value
        }
    }

    public void bindpublication()
    {
        //regionhidden=hiddenregion.Value;
        
        NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        ds = misrep.publication(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        //li1.Text = "--Select Publication--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dppub1.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dppub1.Items.Add(li);
           

        }
        ScriptManager2.SetFocus(txtproduct);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(clientreport), "sa", "document.getElementById('dppub1').focus();", true);
    }

    public void bindregion()
    {
        string comcod=Session["compcode"].ToString();

        NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("xml/frontend.xml"));
        ds = misrep.region(comcod);
        ListItem li1;
        li1 = new ListItem();
        li1.Text=ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        //li1.Text = "--Select Region--";
        li1.Value = "0";
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpregion.Items.Add(li);
        }
       // Txtdest.Focus();
    }
    // For product

    
    

    //public void Adcategory()
    //{
    //    NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = misrep.adcategory(Session["compcode"].ToString());
    //    ListItem li1;
    //    li1 = new ListItem();
    //    li1.Text = "--Select Ad Category--";
    //    li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //    //li1.Selected = true;
    //    dpcategory.Items.Add(li1);
       
    //        //dpadcatgory.Items.Clear();
    //        int i;
    //        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            ListItem li;
    //            li = new ListItem();
    //            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //            dpcategory.Items.Add(li);
                          
    //        }
    //}

    

    

    [Ajax.AjaxMethod]
    public DataSet bindagencyname(string compcode, string agency)
    {
        NewAdbooking.Classes.Class1 bindagen = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        //ds = bindagenname.bindagency(compcode, agency);
        ds = bindagen.bindagency(compcode, agency);
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindclientname(string compcode, string client)
    {

        NewAdbooking.Classes.Class1 objclient = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objclient.getClientName(compcode, client);
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet bindProductcategory(string compcode, string product)
    {
        NewAdbooking.Classes.Class1 objproduct = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objproduct.bindProductcategory(compcode, product, "0");
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getbrand(string product, string compcode)
    {
        NewAdbooking.Classes.Class1 objbrand = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objbrand.bindBrand(compcode, product);
        return ds;
    }
    //getsubcategory
    [Ajax.AjaxMethod]
    public DataSet getsubcategory(string prosubcode, string compcode)
    {
        NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objsubcat.prosubcat(compcode, prosubcode);
        return ds;
     
    }
   

    [Ajax.AjaxMethod]

    public DataSet getsubsubcategory(string procatcode, string prosubcatcode, string compcode)
    {
        NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objsubcat.prosubsubcat( procatcode, prosubcatcode,compcode);
        return ds;

    }

    [Ajax.AjaxMethod]

    public DataSet getvarient(string compcode, string brand)
    {
        NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = objsubcat.proforvarient(compcode, brand);
        return ds;

    }

    

    protected void txtagencyaddress_TextChanged(object sender, EventArgs e)
    {

    }

   

    

   
   
        


  protected void  txtproduct_SelectedIndexChanged(object sender, EventArgs e)
{
    ////drpbrand.Items.Clear();
    ////string prod = lstproduct.SelectedItem.Value;
    //////string prod = txtproduct.Text;
    ////////drpbrand.Items.Clear();
    ////////NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
    ////////DataSet ds = new DataSet();
    ////////ds = misrep.bindBrand(Session["compcode"].ToString(), prod);
    ////////return ds;
    
    ////int i;
    ////ListItem li1;
    ////li1 = new ListItem();
    ////li1.Text = "Select Brand";
    ////li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //////li1.Selected = true;
    ////drpbrand.Items.Add(li1);
    ////drpbrand.Focus();

    //////if (ds.Tables[0].Rows.Count > 0)
    //////{
    //////for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //////{
    //////    ListItem li;
    //////    li = new ListItem();
    //////    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //////    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //////    state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //////    drpbrand.Items.Add(li);
    //////}

    //////}
    ////    ////ScriptManager1.SetFocus(drpproduct);

    }
    protected void lstproduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void lstproduct_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string prod = lstproduct.SelectedValue;
        drpbrand.Items.Clear();
        NewAdbooking.Classes.Class1 misrep = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();
        ds = misrep.bindBrand(Session["compcode"].ToString(), prod);
        // return ds;
        drpbrand.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Brand";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpbrand.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpbrand.Items.Add(li);
            }

        }
    }


    //[Ajax.AjaxMethod]
    //public DataSet bindProduct(string compcode, string product)
    //{
    //    NewAdbooking.Classes.Class1  clsbooking = new NewAdbooking.Classes.BookingMaster();
    //    DataSet ds = new DataSet();
    //    ds = clsbooking.bindProduct(compcode, product, "0");
    //    return ds;
    //} 

    //[Ajax.AjaxMethod]
    protected void dpcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string prodcat = dpcategory.SelectedValue;
        //dpcategory.Items.Clear();
        //NewAdbooking.Classes.Class1 objproduct = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = objproduct.bindProduct(Session["compcode"].ToString(), prodcat, "0");
        
    }
    protected void dpsubcat_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }



    protected void dpsubcat_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //string compcode = Session["compcode"].ToString();
        //string procatcode = lstproduct.SelectedValue;
        //string prosubcatcode = dpsubsubcat.SelectedValue;
        //NewAdbooking.Classes.Class1 objsubcat = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = objsubcat.prosubsubcat(compcode, procatcode, prosubcatcode);
        ////return ds;

        //dpsubsubcat.Items.Clear();
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select Brand";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //dpsubsubcat.Items.Add(li1);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        dpsubsubcat.Items.Add(li);
        //    }

        //}
    }
    protected void txtagency_TextChanged(object sender, EventArgs e)
    {

    }
}





      
    


