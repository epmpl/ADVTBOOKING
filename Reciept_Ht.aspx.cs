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

public partial class Reciept_Ht : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        DataSet ds = new DataSet();
        Double amt = 0;
        ds.ReadXml(Server.MapPath("XML/Reciept_Ht.xml"));
        lblheading.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbldetypevdown.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lblRDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblRDatedown.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lbldetype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lbldetypedown.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblcat.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcatdown.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcatname.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblcatnamedown.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        //lblsub.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lblsecondheading.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        //lblcomm.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        lblboxchrg.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        lblamtpaid.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        lblmatter.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("receiptAddress/"+Session["center"].ToString()+".xml"));
        //lblheadingmain.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
        //if (Session["centerAdd"] != null)
        //{
        //    string[] arr;
        //    arr = Session["centerAdd"].ToString().Split("^".ToCharArray());
            lblheadingadd.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();//arr[0].ToString();
            lblheadingph.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();//arr[1].ToString();
        //    if (arr[2].ToString()!= "")
        //        lblheadingph.Text = lblheadingph.Text + "," + arr[2].ToString();
        //}

        //if (ConfigurationManager.AppSettings["secondAddressForthtReceipt"].ToString() != "")
        //{
            lblheadingmain.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
       // }
       // if (ConfigurationManager.AppSettings["secondAddressForthtReceipt"].ToString() != "")
       // {
            labelhtheadingph.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
       // }
        lblreceiptno.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
        lableclientname.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
        lableclientadd.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
        lblrostatus.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
        lblsapid.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();

        string compcode = Session["compcode"].ToString();
        string booking_id = Request.QueryString["cioid"].ToString();//"DEL2009A0100005432";
        string str = "";
        string commrate = "";

        string box_chrg_type = "";

        DataSet dsdata = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Reciept_Ht binddata = new NewAdbooking.Classes.Reciept_Ht();
            dsdata = binddata.bindreceiptdata(compcode, booking_id);//
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.Reciept_Ht binddata = new NewAdbooking.classesoracle.Reciept_Ht();
            dsdata = binddata.bindreceiptdata(compcode, booking_id);//
        }

        string[] arrclient = Request.QueryString["clientname"].ToString().Split('(');


        lblclientname.Text = dsdata.Tables[0].Rows[0]["Client_code"].ToString();//arrclient[0];
        lblclientnamedown.Text = dsdata.Tables[0].Rows[0]["Client_code"].ToString();
        lblclientadd.Text = dsdata.Tables[0].Rows[0]["Client_address"].ToString(); //Request.QueryString["clientadd"].ToString();
        lblclientadddown.Text = dsdata.Tables[0].Rows[0]["Client_address"].ToString();
        lblRDatev.Text = dsdata.Tables[5].Rows[0]["Receipt_date"].ToString();
        lblRDatevdown.Text = dsdata.Tables[5].Rows[0]["Receipt_date"].ToString();
        lbldetypev.Text = dsdata.Tables[0].Rows[0]["Uom_Name"].ToString();
        lbldetypevdown.Text = dsdata.Tables[0].Rows[0]["Uom_Name"].ToString();
        lblcatv.Text = dsdata.Tables[0].Rows[0]["Adv_Cat_Name"].ToString();
        lblcatvdown.Text = dsdata.Tables[0].Rows[0]["Adv_Cat_Name"].ToString();
        lblcatnamev.Text = dsdata.Tables[0].Rows[0]["Adv_Cat_Name"].ToString();
        if (Session["agency_name"].ToString() != "0" && Session["agency_name"].ToString()!="")
        {
            lblqbcname.Text = dsdata.Tables[0].Rows[0]["Agency"].ToString();
            lblqbcaddress.Text = dsdata.Tables[0].Rows[0]["Address"].ToString();
        }
        if (dsdata.Tables[0].Rows[0]["ro_status"].ToString() == "1")
        {
            lblrostatusv.Text = "Confirm";
        }
        else
        {
            lblrostatusv.Text = "UnConfirm";
        }
        lblboxchrgv.Text = dsdata.Tables[3].Rows[0].ItemArray[0].ToString();
        box_chrg_type = dsdata.Tables[3].Rows[0].ItemArray[1].ToString();
        if (dsdata.Tables[4].Rows.Count > 0)
        {
            commrate = dsdata.Tables[4].Rows[0].ItemArray[0].ToString();
            commrate =Convert.ToString(Convert.ToDouble(commrate) + Convert.ToDouble(dsdata.Tables[4].Rows[0].ItemArray[1].ToString()));
        }

        lblsapidv.Text = dsdata.Tables[0].Rows[0]["SAPID"].ToString();

        str = "<table cellpadding='0' cellspacing='0' width=100% border='1' >";
        str += "<tr>";
        str += "<td style='width: 100px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";
        str += "<td style='width: 110px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
        str += "<td style='width: 120px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
      //  str += "<td style='width: 100px' class='labelhtdatagrid'>sub cat</td>";
        str += "<td style='width:115px' class='labelhtdatagrid'>Lines/Words</td>";
      //  str += "<td style='width:12px' class='labelhtdatagrid'>O</td>";
      //  str += "<td style='width:25px' class='labelhtdatagrid'>L</td>";
       
        //str += "<td style='width: 12px'></td>";
        //str += "<td style='width: 25px'></td>";
        str += "<td style='width: 70px' class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>";
        str += "<td style='width: 90px'  class='labelhtdatagrid'>" + ds.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
        str += "</tr>";
        for (int i = 0; i < dsdata.Tables[1].Rows.Count; i++)
        {
            str += "<tr>";
            str += "<td style='width: 100px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[0].ToString() + "</td>";
            str += "<td style='width: 110px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[1].ToString() + "</td>";
            str += "<td style='width: 150px'  class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[2].ToString() + "</td>";
          //  str += "<td style='width: 100px' class='labelht'>&nbsp;</td>";/* + dsdata.Tables[1].Rows[i].ItemArray[3].ToString() +*/
            str += "<td style='width:75px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[6].ToString() + " X 1 " + "</td>";
            //str += "<td style='width:12px' class='labelht'>X</td>";
            //str += "<td style='width:25px' class='labelht'>1</td>";
            //str += "</tr></table></td>";
            //str += "<td style='width: 25px'>" + dsdata.Tables[1].Rows[i].ItemArray[6].ToString() + "</td>";
            //str += "<td style='width: 25px'>X</td>";
            //str += "<td style='width: 25px'>1</td>";
            int ins_count = dsdata.Tables[1].Rows.Count;
            if (commrate == "")
                commrate = "0";
            double comm_rate_f = Convert.ToDouble(dsdata.Tables[1].Rows[i]["Card_Rate"]) * Convert.ToDouble(commrate) / 100;
            str += "<td style='width: 25px' class='labelht'>" + dsdata.Tables[1].Rows[i].ItemArray[4].ToString() + "</td>";
           // for qbc double amt_ins = Convert.ToDouble(dsdata.Tables[1].Rows[i].ItemArray[5].ToString()) + comm_rate_f;
            double amt_ins = Convert.ToDouble(dsdata.Tables[1].Rows[i].ItemArray[5].ToString());// IN HOUSE
            str += "<td style='width: 90px' align='right' class='labelht'>" + amt_ins.ToString() + "</td>";
            amt = amt + Convert.ToDouble(dsdata.Tables[1].Rows[i].ItemArray[5].ToString());
            str += "</tr>";
        }
        str += "</table>";
        tblinserts.InnerHtml = str;
        str = "";
        str = "<table width='100%' border='1'>";
        for (int j = 0; j < dsdata.Tables[2].Rows.Count; j++)
        {
            if (dsdata.Tables[2].Rows.Count > dsdata.Tables[1].Rows.Count)
            {
                if (dsdata.Tables[2].Rows[j].ItemArray[2].ToString().IndexOf("All.xtg") < 0)
                {
                    str += "<tr>";
                    str += "<td style='width:50px'>" + (j + 1) + "</td>";
                    str += "<td>" + dsdata.Tables[2].Rows[j].ItemArray[1].ToString().Replace("<br>", "") + "</td>";
                    str += "</tr>";
                }

            }
            else
            {
                str += "<tr>";
                str += "<td style='width:50px'>" + (j + 1) + "</td>";
                str += "<td>" + dsdata.Tables[2].Rows[j].ItemArray[1].ToString().Replace("<br>", "") + "</td>";
                str += "</tr>";
            }
            //str += "<tr><td></td><td>---------------------------------------------</td></tr>";
        }
        str += "</table>";
        divmatter.InnerHtml = str;
        //lblcomm.Text += commrate + "%";
        //lblcommv.Text = Convert.ToString(amt * Convert.ToDouble(commrate) / 100);
       // double famt = amt + (amt * Convert.ToDouble(commrate) / 100);
        if (dsdata.Tables[0].Rows[0]["Gross_amount"] != null)
        {
          // for qbc  amt = Convert.ToDouble(dsdata.Tables[0].Rows[0]["Gross_amount"].ToString());
            amt = Convert.ToDouble(dsdata.Tables[0].Rows[0]["Bill_amount"].ToString());// for ihouse
            
        }
        double famt = amt;
        if (box_chrg_type == "1")
        {
           // famt = famt + Convert.ToDouble(lblboxchrgv.Text);new change 19dec09
        }
        else if (box_chrg_type == "1")
        {
            double chrgper = 0;
            chrgper = famt * Convert.ToDouble(lblboxchrgv.Text) / 100;
           // famt = famt + chrgper;new change 19dec 09
            lblboxchrgv.Text = chrgper.ToString();
        }
        //if (dsdata.Tables[4].Rows.Count > 0)
        //{
        //    if (dsdata.Tables[4].Rows[0].ItemArray[0] != null)
        //    {
        //        string agencyComm = dsdata.Tables[4].Rows[0].ItemArray[0].ToString();
        //        famt = famt - (famt * Convert.ToDouble(agencyComm) / 100);
        //    }
        //}
        lblamt.Text = "<b>" + Convert.ToString(famt) + "</b>";

        lblreceiptnov.Text = "<b>" + Request.QueryString["receiptno"].ToString() + "</b>";
    }
}
