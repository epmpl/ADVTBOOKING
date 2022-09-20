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
//using iTextSharp.text;
using System.IO;
//using iTextSharp.text.pdf;
using System.Drawing.Printing;
//  using System.Diagnostics.Design;
using System.Diagnostics;

public partial class pipublication : System.Web.UI.Page
{
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
       
        lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        lbpubnot.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
        if(!IsPostBack)

        {
            binddest();
            bindpub();
            bindstatus();


            //BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            //txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            //dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");

            //BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
            txttodate1.Attributes.Add("OnBlur", "javascript:return dateformate();");
            txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
            txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");

                
        
        
        }




    }

    public void bindpub()
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
        //li1.Text = "--Select Publication--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
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
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "", temp11 = "", temp12 = "", temp13 = "";

        string str = "";
        string str1 = "";

        for (int i = 1; i < dppub1.Items.Count; i++)
        {

            if (dppub1.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dppub1.Items[i].Value;
                    str1 = dppub1.Items[i].Text;
                }
                else
                {
                    str = str + "','" + dppub1.Items[i].Value;
                    str1 = str1 + "','" + dppub1.Items[i].Text;
                }
            }
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.sppublication(txtfrmdate.Text, txttodate1.Text, str, Session["compcode"].ToString(), Session["dateformat"].ToString(), dppubnot.SelectedItem.Text, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.sppublication(txtfrmdate.Text, txttodate1.Text, str, Session["compcode"].ToString(), Session["dateformat"].ToString(), dppubnot.SelectedValue, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10);
        }

        else
        {
        }

        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(pipublication), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            Session["fromdate"] = txtfrmdate.Text;
            Session["dateto"] = txttodate1.Text;
            Response.Redirect("pipublicationviewpage.aspx?fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + str + "&destination=" + Txtdest.SelectedItem.Value + "&publicname=" + str1 + "&published=" + dppubnot.SelectedItem.Text + "&published1=" + dppubnot.SelectedValue);
            // Response.Redirect("pipublicationviewpage.aspx?agname=""&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publicname=" + dppub1.SelectedItem.Text + "&publiccent=" + dppubcent.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&destination=" + Txtdest.SelectedItem.Value + "&status1=" + dpstatus.SelectedItem.Text + "&adcatname=" + str1 + "&status=" + dpstatus.SelectedItem.Value + "&clientname=" + dpagencycli.SelectedValue + "&client=" + dpagencycli.SelectedItem.Text + "&adtypename=" + dpaddtype.SelectedItem.Text + "&editionname=" + dpedition.SelectedItem.Text + "&agencyname=" + dpagencyna.SelectedItem.Text);        

        }
    }
        //--------------------------------------------------
        //string str = "";

        //if (Txtdest.SelectedItem.Text == "On Screen")
        //{
        //    Response.Redirect("reportview.aspx?adtype=" + dpagencycli.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publication1=" + dppub1.SelectedItem.Text + "&pubcname=" + dppubcent.SelectedItem);
        //}
        //else if (Txtdest.SelectedItem.Text == "Excel Sheet")
        //{
        //    Response.Redirect("Excelsheet.aspx?adtype=" + dpagencycli.SelectedValue + "&adcategory=" + str + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&pubcenter=" + dppubcent.SelectedValue + "&publication1=" + dppub1.SelectedItem.Text + "&pubcname=" + dppubcent.SelectedItem);
        //}
    protected void dppub1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        dppubnot.Items.Clear();
        int i=0;
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
       // li1.Text = "--Select published--";
        li1.Value = "0";
        li1.Selected = true;
        dppubnot.Items.Add(li1);

      //  for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        //{
            
            ListItem li;

            li = new ListItem();
            
            

                li.Text = destination.Tables[1].Rows[0].ItemArray[0].ToString();
                i = i + 1;
                li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();

                dppubnot.Items.Add(li);

                ListItem li2;
                li2 = new ListItem();


                i = 0;
                li2.Text = destination.Tables[1].Rows[0].ItemArray[6].ToString();
                i = i + 7;
                li2.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();

                dppubnot.Items.Add(li2);
            
           
            

        //}




    }
}
   



