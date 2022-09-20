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

public partial class RegisterBilling : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["compcode"] = "HT001";
        Session["dateformat"] = "mm/dd/yyyy";
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        //lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //lbsubcat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //lbsubsubcat.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbbrand.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        // lbvarient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        agencyname.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbaaddress.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();

        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();
            bindagency();
            //binduom();

            //lstproduct.Attributes.Add("onkeypress", "return keySort(this);");
            //lstproduct.Attributes.Add("onclick", "javascript:return insertproduct();");
        }
    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Destination--";
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


    public void bindregion()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = objregion.bindregion(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Region--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpregion.Items.Add(li);


        }
    }

    //[Ajax.AjaxMethod]
    //public DataSet bindProduct(string compcode, string product)
    //{
    //    NewAdbooking.Classes.Class1 objproduct = new NewAdbooking.Classes.Class1();
    //    DataSet ds = new DataSet();
    //    ds = objproduct.bindProduct(compcode, product, "0");
    //    return ds;
    //}

    public void bindproductnamne()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 objprod = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        //ds = objprod.bindProductcategory(Session["comnpcode"].ToString());  //, product, "0");
        ds = objprod.bindProductcategory(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Product--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpproduct.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpproduct.Items.Add(li);


        }
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {


        string str = "";
        string str1 = "";

        for (int i = 1; i < dpproduct.Items.Count; i++)
        {

            if (dpproduct.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpproduct.Items[i].Value;
                    str1 = dpproduct.Items[i].Text;
                }
                else
                {
                    str = str + "," + dpproduct.Items[i].Value;
                    str1 = str1 + "," + dpproduct.Items[i].Text;
                }
            }
        }

        Response.Redirect("piproductviewpage.aspx?regcode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&prodcode=" + str + "&product=" + str1 + "&uom=" + hiddendateformat2.Value);
    }



    public void bindagency()
    {
        //regionhidden=hiddenregion.Value;
        NewAdbooking.Classes.Class1 adagency = new NewAdbooking.Classes.Class1();
        DataSet ds = new DataSet();

        ds = adagency.agency(Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        dpagencyna.Items.Clear();
        li1.Text = "--Select Agency Name--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpagencyna.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dpagencyna.Items.Add(li);


        }
    }
}

//string uom = "";
//public void binduom()
//{

//     NewAdbooking.Classes.Class1 objprod = new NewAdbooking.Classes.Class1();
//    DataSet ds = new DataSet();

//    ds = objprod.spbinduom(Session["compcode"].ToString());


//    int i;
//    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
//    {


//       hiddendateformat2 .Value  = ds.Tables[0].Rows[i].ItemArray[0].ToString();
//    }


//}


