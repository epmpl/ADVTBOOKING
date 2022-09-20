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


public partial class ScheduleRegister : System.Web.UI.Page
{
    //protected void AspNetMessageBox(string strMessage)
    //{
    //    //strMessage = adminResource.GetStringFromResource(strMessage);
    //    string strAlert = "";
    //    strAlert = "alert('" + strMessage + "')";
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(disschreg), "ShowAlert", strAlert, true);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            
           hiddendateformat.Value = Session["dateformat"].ToString();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("XML/disschreg.xml"));

            lbDateFrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            lbAdtype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            lbadcatgory.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            lbEdition.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            //lbsubcat.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            //lbsubsubcat.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            //lbagency.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            //lbClient.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            lbPublication.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            lbPublicationCenter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            //lbvarient.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            BtnRun.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            heading.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
            lbdestination.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            editiondetail.Text = ds.Tables[0].Rows[0].ItemArray[64].ToString();
            status.Text = ds.Tables[0].Rows[0].ItemArray[56].ToString();
            //lbcaddress.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            //lbpubnot.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
            if (!IsPostBack)
            {
                edition();
                bindadvtype();
                binddest();
                bindpub();
                bindstatus();
                publicationbind();
                bindedidetail();

                BtnRun.Attributes.Add("OnClick", "javascript:return pivalidation();");
                BtnRun.Attributes.Add("onfocus", "javascript:checkrundate();checkrundate1();");
                txttodate1.Attributes.Add("onkeypress", "javascript:return validdate1();");
                txtfrmdate.Attributes.Add("onkeypress", "javascript:return validdate();");

                txttodate1.Attributes.Add("onfocus", "javascript:return checkrundate();");
                dppub1.Attributes.Add("onfocus", "javascript:return checkrundate1();");
                txttodate1.Attributes.Add("onchange", "javascript:return dateformate();");
                txtfrmdate.Attributes.Add("OnChange", "javascript:return incorrectfromdate(txtfrmdate);");
                txttodate1.Attributes.Add("OnChange", "javascript:return incorrectodate(txttodate1);");


            }
        }
    }
    protected void BtnRun_Click(object sender, EventArgs e)
    {
        string str = "";
        string str1 = "";
        for (int i = 1; i < dpadcatgory.Items.Count; i++)
        {

            if (dpadcatgory.Items[i].Selected == true)
            {
                if (str == "")
                {
                    str = dpadcatgory.Items[i].Value;
                    str1 = dpadcatgory.Items[i].Text;
                }
                else
                {
                    str = str + "','" + dpadcatgory.Items[i].Value;
                    str1 = str1 + "','" + dpadcatgory.Items[i].Text;
                }
            }
        }


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue,Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            // SqlDataAdapter da = new SqlDataAdapter();
        }
        else
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
            ds = obj.displayonscreenreport(txtfrmdate.Text, txttodate1.Text, Session["compcode"].ToString(), dppub1.SelectedValue, drpstatus.SelectedValue, dpedition.SelectedValue, dppubcent.SelectedValue, dpaddtype.SelectedValue, dpadcatgory.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }

        
        //int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count == 0)
        {
            //Response.Write("<script>alert(\"searching criteria is not valid\")</script>");
            //return;
            ScriptManager.RegisterClientScriptBlock(this, typeof(ScheduleRegister), "sa", "alert(\"searching criteria is not valid\");", true);
            return;
        }
        else
        {
            // Response.Redirect("disschregview.aspx?&destination=" + Txtdest.SelectedItem.Value + "&agencyname=" + txtagency.Text + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&Product=" + txtproduct.Text + "&client=" + txtclient.Text + "&region=" + dpregion.SelectedValue + "&publication="+dppub1.SelectedValue);

            Session["from"] = txtfrmdate.Text;
            Session["to"] = txttodate1.Text;

            Response.Redirect("ScheduleRegisterView.aspx?&destination=" + Txtdest.SelectedItem.Value + "&fromdate=" + txtfrmdate.Text + "&dateto=" + txttodate1.Text + "&publication=" + dppub1.SelectedValue + "&publicationname=" + dppub1.SelectedItem.Text + "&edition=" + dpedition.SelectedValue + "&editionname=" + dpedition.SelectedItem.Text + "&publicationcenter=" + dppubcent.SelectedItem.Text + "&pubcentcode=" + dppubcent.SelectedValue + "&adtype=" + dpaddtype.SelectedItem.Text + "&adtypecode=" + dpaddtype.SelectedValue + "&adcategory=" + str + "&editiondetail=" + dpedidetail.SelectedValue + "&status=" + drpstatus.SelectedValue);
        }
    }


    public void bindpub()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advpub = new NewAdbooking.Classes.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 advpub = new NewAdbooking.classesoracle.Class1();
            ds = advpub.advpub(Session["compcode"].ToString());
        }
      
        ListItem li1;
        li1 = new ListItem();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        li1.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
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
    }

    public void publicationbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 pub_cent1 = new NewAdbooking.Classes.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 pub_cent1 = new NewAdbooking.classesoracle.Class1();
            ds = pub_cent1.pub_cent(Session["compcode"].ToString());
        }
        else
        {
        }
        int i;
        ListItem li;
        li = new ListItem();
        dppubcent.Items.Clear();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
        // li.Text = "-Select Publication Center-";
        li.Value = "0";
        li.Selected = true;
        dppubcent.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dppubcent.Items.Add(li1);
            }
        }


    }

    public void edition()
    {
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        li.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
        //li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);

    }

    public void bindadvtype()
    {
        //regionhidden=hiddenregion.Value;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();


        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 advname = new NewAdbooking.Classes.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 advname =new NewAdbooking.classesoracle.Class1();
            ds = advname.adname(Session["compcode"].ToString());
        }
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        dpaddtype.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpaddtype.Items.Add(li);


        }
    }

    protected void dpaddtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string adtype = dpaddtype.SelectedValue;

        dpadcatgory.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 adcat = new NewAdbooking.Classes.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Class1 adcat = new NewAdbooking.classesoracle.Class1();
            ds = adcat.advtype(adtype, Session["compcode"].ToString());
        }
        else
        {
        }
        ListItem li1;
        li1 = new ListItem();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/frontend.xml"));

        // li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        // li1.Selected = true;
        dpadcatgory.Items.Add(li1);

        //dpadcatgory.Items.Clear();
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpadcatgory.Items.Add(li);



        }
        //ScriptManager.RegisterClientScriptBlock(this,"typeof(re)")
        ScriptManager.RegisterClientScriptBlock(this, typeof(ScheduleRegister), "sa", "document.getElementById('dpaddtype').focus();", true);
    }
  
    public void binddest()
    {
        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        Txtdest.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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


    public void bindedidetail()
    {
        DataSet edidetail = new DataSet();
        edidetail.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/frontend.xml"));
        // lbadtype.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        dpedidetail.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
        li1.Value = "0";
        li1.Selected = true;
        dpedidetail.Items.Add(li1);

        for (i = 0; i < edidetail.Tables[13].Columns.Count - 1; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = edidetail.Tables[13].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li.Value = edidetail.Tables[13].Rows[0].ItemArray[i].ToString();
            dpedidetail.Items.Add(li);

        }
    }


    protected void dppubcent_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "sql")
        {
            //NewAdbooking.Classes.Class1 pub_cent2 = new NewAdbooking.Classes.Class1();
            //ds = pub_cent2.edition1(dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString());

        }
        else
        {
            NewAdbooking.classesoracle.Class1 pub_cent2 = new NewAdbooking.classesoracle.Class1();
            ds = pub_cent2.edition1(dppub1.SelectedValue, dppubcent.SelectedValue,Session["compcode"].ToString());

        }
        int i;
        ListItem li;
        li = new ListItem();
        dpedition.Items.Clear();
        li.Text = "-Select Edition Name-";
        li.Value = "0";
        li.Selected = true;
        dpedition.Items.Add(li);


        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dpedition.Items.Add(li1);
            }
        }
    }

    public void bindstatus()
    {

        DataSet destination = new DataSet();
        destination.ReadXml(Server.MapPath("XML/Report_destination.xml"));
        //dppubnot.Items.Clear();
        //int i = 0;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "Select published";
        //li1.Value = "0";
        //li1.Selected = true;
        // dppubnot.Items.Add(li1);

        //  for (i = 0; i < destination.Tables[1].Columns.Count - 1; i++)
        //{

        //ListItem li;
        //li = new ListItem();



        //    li.Text = destination.Tables[1].Rows[0].ItemArray[0].ToString();
        //    i = i + 1;
        //    li.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();

        //dppubnot.Items.Add(li);

        //ListItem li2;
        //li2 = new ListItem();



        //li2.Text = destination.Tables[1].Rows[0].ItemArray[6].ToString();
        //i = i + 1;
        //li2.Value = destination.Tables[1].Rows[0].ItemArray[i].ToString();

        //dppubnot.Items.Add(li2);
    }

}
