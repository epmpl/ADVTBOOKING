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

public partial class piregion : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["compcode"] = "HT001";
       // Session["dateformat"] = "mm/dd/yyyy";
        
        Session["fromdate"] = txtfrmdate.Text;
        Session["todate"] = txttodate1.Text;
        
        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/disschreg.xml"));
       
        lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbregion.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblanguage.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
        heading.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
        if(!IsPostBack )
        {
            binddest();
            bindregion();
            bindlanguage();

            BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
            txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
            dpregion.Attributes.Add("onfocus", "javascript:return checkrundate1();");

            //BtnRun.Attributes.Add("Onclick", "javascript:return datevalidation();");
            txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
            txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");
            BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
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


    public void bindregion()
    {
        string region = dpregion.SelectedValue;

        dpregion.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass objregion = new NewAdbooking.classesoracle.reportclass();
            ds = objregion.bindregion(Session["compcode"].ToString());
        }
        else
        {
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();       
        li1.Value = "0";
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
    public void bindlanguage()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
            ds = objregion.bindlanguage(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass objregion = new NewAdbooking.classesoracle.reportclass();
            ds = objregion.bindlanguage(Session["compcode"].ToString());
        }
        else
        {
        }

        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[14].ToString();
      //  li1.Text = "--Select Language--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dplanguage.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dplanguage.Items.Add(li);


        }
    }



    protected void BtnRun_Click(object sender, EventArgs e)
    {


        string str = "";
        string str1 = "";
        for (int i = 1; i < dpregion.Items.Count; i++)
        {
            if (dpregion.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpregion.Items[i].Value;
                    str1 = dpregion.Items[i].Text;
                }
                else
                {
                    str = str + "','" + dpregion.Items[i].Value;
                    str1 = str1 + "','" + dpregion.Items[i].Text;
                }
            }
        }
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "", temp9 = "", temp10 = "", temp11 = "", temp12 = "", temp13 = "";
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.spregionreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dpregion.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value, hiddenascdesc.Value);
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportclass obj = new NewAdbooking.classesoracle.reportclass();
            ds = obj.spregionreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), str1, Session["dateformat"].ToString(), hiddencioid.Value, hiddenascdesc.Value, temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11);
        }
        else
        {
        }

           if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(piregion), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
           
            Response.Redirect("regionwisereport.aspx?region=" + str1 + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value);

        }
      
       






       // Response.Redirect("regionwisereport.aspx?region=" + dpregion.SelectedValue + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&destination=" + Txtdest.SelectedItem.Value);
      
    }
    protected void dpregion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string region = dplanguage.SelectedValue;
        //dplanguage.Items.Clear();
        //NewAdbooking.Classes.Class1 objregion = new NewAdbooking.Classes.Class1();
        //DataSet ds = new DataSet();
        //ds = objregion.bindlanguage(Session["compcode"].ToString(), region);
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "--Select Region--";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //dplanguage.Items.Add(li1);

        ////dpadcatgory.Items.Clear();
        //int i;
        //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ListItem li;
        //    li = new ListItem();
        //    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //    dplanguage.Items.Add(li);



        //}


    }
    
}


