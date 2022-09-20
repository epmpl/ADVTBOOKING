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
using System.Data.SqlClient;

public partial class RegionRebate : System.Web.UI.Page
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
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();
        lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //lbsubcat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //lbsubsubcat.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbbrand.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        // lbvarient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        Session["dateto"] = txttodate1.Text;
        Session["fromdate"] = txtfrmdate.Text;
       // agencyname.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbaaddress.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();

        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));
        if (!IsPostBack)
        {
            binddest();
            bindregion();
            bindproductnamne();
            bindcategory();
            //bindagency();
            //binduom();

            //lstproduct.Attributes.Add("onkeypress", "return keySort(this);");
            //lstproduct.Attributes.Add("onclick", "javascript:return insertproduct();");
            BtnRun.Attributes.Add("onclick", "javascript:return runclickbillregister();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

        }
    }
    public void bindcategory()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        dpcategory.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
        //li1.Text = "--Select Destination--";
        li1.Value = "0";
        li1.Selected = true;
        dpcategory.Items.Add(li1);

        for (i = 0; i < ds.Tables[3].Columns.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            // i = i + 1;
            li.Value = ds.Tables[3].Rows[0].ItemArray[i].ToString();
            dpcategory.Items.Add(li);

        }


    }
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
       
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
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
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
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
        ListItem li;
        li = new ListItem();
        dpproduct.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;

        dpproduct.Items.Add(li);

    }


    protected void BtnRun_Click1(object sender, EventArgs e)
    {

        NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ds = obj.regionrebate(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, dpproduct.SelectedValue, dpcategory.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(RegionRebate), "sa", "alert(\"searching criteria is not valid\");", true);

            return;
        }
        else
        {


        Response.Redirect("RegionRebateview.aspx?regcode=" + dpregion.SelectedValue + "&region=" + dpregion.SelectedItem.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + hiddendateformat2.Value + "&agname=" + dpcategory.SelectedValue + "&category=" + dpcategory.SelectedItem.Text + "&product=" + dpproduct.SelectedValue + "&productname=" + dpproduct.SelectedItem.Text + "&category1=" + dpcategory.SelectedValue );
        }
    }
    protected void dpregion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string region = dpregion.SelectedValue;
        dpproduct.Items.Clear();
        NewAdbooking.Classes.bill pub = new NewAdbooking.Classes.bill();
        DataSet ds = new DataSet();
        ds = pub.product(region, Session["compcode"].ToString());
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpproduct.Items.Add(li1);

        //dpadcatgory.Items.Clear();
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

}






