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

public partial class picontractreport : System.Web.UI.Page
{
    string uom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["compcode"] = "HT001";
        //Session["dateformat"] = "mm/dd/yyyy";
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
       // lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbproduct.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbcatgory.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //lbsubcat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        //lbsubsubcat.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        // lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        //lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        //lbbrand.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
        // lbvarient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[40].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        // lbaaddress.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();

        //Ajax.Utility.RegisterTypeForAjax(typeof(piproduct));
        if (!IsPostBack)
        {
            binddest();
           // bindregion();
            bindproductnamne();
           // binduom();

            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpproduct.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            //lstproduct.Attributes.Add("onkeypress", "return keySort(this);");
            //lstproduct.Attributes.Add("onclick", "javascript:return insertproduct();");

            //BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
          //  BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");
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
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
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

    public void bindproductnamne()
    {
        //regionhidden=hiddenregion.Value;
          DataSet ds = new DataSet();
          if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
          {
              NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
              ds = advpub.advpub(Session["compcode"].ToString());
          }
          else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
          {
              NewAdbooking.classesoracle.reportclass advpub = new NewAdbooking.classesoracle.reportclass();
              ds = advpub.advpub(Session["compcode"].ToString());
          }
          else
          {
          }
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpproduct.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpproduct.Items.Add(li);


        }
    }

    protected void BtnRun_Click(object sender, EventArgs e)
    {

        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "", temp11 = "", temp12 = "", temp13 = "";
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
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();

            ds = obj.spcontractreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();

            ds = obj.spcontractreportnew(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), Session["dateformat"].ToString(), dpproduct.SelectedValue, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11);
        }
        else
        {
        }

        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
             ScriptManager.RegisterClientScriptBlock(this, typeof(picontractreport), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;
            Response.Redirect("picontractviewreport.aspx?&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value + "&prodcode=" + str + "&product=" + str1);
        }
    }

       
    }
