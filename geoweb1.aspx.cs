using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class geoweb1 : System.Web.UI.Page
{
    string flag = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }


        Ajax.Utility.RegisterTypeForAjax(typeof(geoweb1));

        hdnciobookid123.Value = Request.QueryString["ciobookid"].ToString();
     
        bindtime();

        bindtime1();
        bindtime2();
        bindtime3();
        bindtime4();
        bindtime5();
        bindtime6();
        bindtime7();
        bindtime8();
        bindtime9();
        bindtime10();
        bindtime11();
        bindtime12();
        bindtime13();
        bindagegroup();

        bindoccupation();

          hiddencompcode.Value=Session["compcode"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        hdnnoinsert123.Value = Request.QueryString["noofinsert"].ToString();
        hdneditiongeo123.Value = Request.QueryString["editiongeo"].ToString();

        flag = Request.QueryString["flag"].ToString();

        hdnflag.Value = flag;
        if (hdnflag.Value == "M")
        {


            someTree.Enabled = true;
            txtrotation.Enabled = true;
            txtpriority.Enabled = true;
            chks.Enabled = true;
            tfs.Enabled = true;
            tts.Enabled = true;
            chkm.Enabled = true;
            tfm.Enabled = true;
            ttm.Enabled = true;
            chkt.Enabled = true;
            tft.Enabled = true;
            ttt.Enabled = true;
            chkw.Enabled = true;
            tfw.Enabled = true;
            ttw.Enabled = true;
            chkth.Enabled = true;
            tft1.Enabled = true;
            ttt1.Enabled = true;
            chkf.Enabled = true;
            tff.Enabled = true;
            ttf.Enabled = true;
            chksat.Enabled = true;
            tfsat.Enabled = true;
            ttsat.Enabled = true;
            ml1.Enabled = true;

            fe1.Enabled = true;
            age1.Enabled = true;
            occup.Enabled = true;
            Button1.Enabled = true;



            hdnadcategory.Value = Request.QueryString["adcategory"].ToString();
            hdnuom.Value = Request.QueryString["uom1"].ToString();
            hdndummydate.Value = Request.QueryString["txtdummydate1"].ToString();
            hdnpageprem.Value = Request.QueryString["drppageprem"].ToString();




        }
        if (hdnflag.Value == "E")
        {
            someTree.Enabled = false;
            txtrotation.Enabled = false;
        txtpriority.Enabled = false;
        chks.Enabled = false;
        tfs.Enabled = false;
        tts.Enabled = false;
            chkm.Enabled = false;
        tfm.Enabled = false;
    ttm.Enabled = false;
        chkt.Enabled = false;
        tft.Enabled = false;
ttt.Enabled = false;
chkw.Enabled = false;
tfw.Enabled = false;
ttw.Enabled = false;
chkth.Enabled = false;
tft1.Enabled = false;
ttt1.Enabled = false;
chkf.Enabled = false;
tff.Enabled = false;
ttf.Enabled = false;
chksat.Enabled = false;
tfsat.Enabled = false;
ttsat.Enabled = false;
ml1.Enabled = false;

fe1.Enabled = false;
age1.Enabled = false;
occup.Enabled = false;




        }

        dynamiccheckbox();

        bindtreeview(hiddencompcode.Value);

        excutegeography(hdnciobookid123.Value, hiddencompcode.Value, hdnnoinsert123.Value);

        //excutedays(hdnciobookid123.Value, hiddencompcode.Value, hdnnoinsert123.Value);

        


        if (!Page.IsPostBack)
        {



            Button1.Attributes.Add("onclick", "javascript:return openrotation1();");




            someTree.Attributes.Add("onclick", "OnTreeClick(event)");

            cancel.Attributes.Add("onclick", "javascript:return exit();");

            save.Attributes.Add("onclick", "javascript:return savegeo1();");



        }



     
    }




    public void excutegeography(string cio,string compcode,string noofinsert)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bindrate = new NewAdbooking.Classes.webbooking();
            dx = bindrate.executegeo(cio,compcode,noofinsert);
        }
        else
        {

            NewAdbooking.classesoracle.webbooking bindrate = new NewAdbooking.classesoracle.webbooking();
            dx = bindrate.executegeo(cio, compcode, noofinsert);
        }

        string str = "";



        if (dx.Tables[0].Rows.Count>0)
        {
            string  country,city,state;


            for (int i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                if (dx.Tables[0].Rows[i]["Country"].ToString() == "")
                {
                    country = "";
                }
                else
                {

                    country = "---" + dx.Tables[0].Rows[i]["Country"].ToString() + "(" + dx.Tables[0].Rows[i]["Country1"].ToString()+")";
                }
                if (dx.Tables[0].Rows[i]["Statecode"].ToString() == "")
                {
                    state = "";
                }
                else 
                {
                    state =  "---" + dx.Tables[0].Rows[i]["Statecode"].ToString() + "(" + dx.Tables[0].Rows[i]["Statecode1"].ToString() + ")";

                }
                if (dx.Tables[0].Rows[i]["city"].ToString() == "")
                {
                    city = "";

                }
                else
                {
                    city = "---" + dx.Tables[0].Rows[i]["city"].ToString() + "(" + dx.Tables[0].Rows[i]["city1"].ToString() + ")";
                }


                if (dx.Tables[0].Rows[i]["Country"].ToString() != "" && dx.Tables[0].Rows[i]["Statecode"].ToString() != "" && dx.Tables[0].Rows[i]["city"].ToString() != "")
                {


                    str += "<div id=" + country + state + city + " ><table width='200px'><tr><td style='font-size:10px;font-family:arial'>" +"<i>Country</i>"+ country + "</br>" +"<i>State</i>"+ state + "</br>" +"<i>City</i>"+ city + "</td><td style='display:none;'>" + "**" + dx.Tables[0].Rows[i]["Edition"] + "+" + dx.Tables[0].Rows[i]["cio_booking_id"] + "+" + dx.Tables[0].Rows[i]["NO_INSERT"] + "+" + dx.Tables[0].Rows[i]["Comp_Code"] + "</td><td style='align:right;float:right;'   ><a href='#'  id=" + country + state + city + " onclick='abc_close(this.id)'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>";
                }


                if (dx.Tables[0].Rows[i]["Country"].ToString() != "" && dx.Tables[0].Rows[i]["Statecode"].ToString() !="" && dx.Tables[0].Rows[i]["city"].ToString() == "")
                {


                    str += "<div id=" + country + state + city + " ><table width='200px'><tr><td style='font-size:10px;font-family:arial'>" +"<i>Country</i>"+ country + "</br>" +"<i>State</i>"+ state + "</br>" + city + "</td><td style='display:none;'>" + "**" + dx.Tables[0].Rows[i]["Edition"] + "+" + dx.Tables[0].Rows[i]["cio_booking_id"] + "+" + dx.Tables[0].Rows[i]["NO_INSERT"] + "+" + dx.Tables[0].Rows[i]["Comp_Code"] + "</td><td style='align:right;float:right;'   ><a href='#'  id=" + country + state + city + " onclick='abc_close(this.id)'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>";
                }


                if (dx.Tables[0].Rows[i]["Country"].ToString() != "" && dx.Tables[0].Rows[i]["Statecode"].ToString() == "" && dx.Tables[0].Rows[i]["city"].ToString() == "")
                {


                    str += "<div id=" + country + state + city + " ><table width='200px'><tr><td style='font-size:10px;font-family:arial'>" +"<i>Country</i>"+ country + "</br>" + state + "</br>" + city + "</td><td style='display:none;'>" + "**" + dx.Tables[0].Rows[i]["Edition"] + "+" + dx.Tables[0].Rows[i]["cio_booking_id"] + "+" + dx.Tables[0].Rows[i]["NO_INSERT"] + "+" + dx.Tables[0].Rows[i]["Comp_Code"] + "</td><td style='align:right;float:right;'   ><a href='#'  id=" + country + state + city + " onclick='abc_close(this.id)'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>";
                }






                dynamicvalue.InnerHtml = str;
            }
            



        }
        

      
       

    }





    [Ajax.AjaxMethod]
    public DataSet excutedays12345(string cio, string compcode, string noofinsert)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bindrate = new NewAdbooking.Classes.webbooking();
            dx = bindrate.executedays(cio, compcode, noofinsert);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking bindrate = new NewAdbooking.classesoracle.webbooking();
            dx = bindrate.executedays(cio, compcode, noofinsert);
        }

        return dx;

    }


    [Ajax.AjaxMethod]
    public DataSet savegeography(string country, string state, string city, string edition, string ciobookid, string noinsert, string compcode)
    {


        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.savegeo12(country, state, city, edition, ciobookid, noinsert, compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking execute = new NewAdbooking.classesoracle.webbooking();
            executequery = execute.savegeo12(country, state, city, edition, ciobookid, noinsert, compcode);

        }
        return executequery;


    }


    public void bindtreeview(string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bind = new NewAdbooking.Classes.webbooking();
            ds = bind.bindtree(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking bind = new NewAdbooking.classesoracle.webbooking();
            ds = bind.bindtree(compcode);
        }


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
        {
            TreeNode tn = new TreeNode("Parent Node");
            tn.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString() + "(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ")"; ;
            tn.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            someTree.Nodes.Add(tn);

            string aa = tn.Value;
            string bb = tn.Text;


            BindChilds(tn, aa);



        }
    }

    private void BindChilds(TreeNode node, string parentNodeID)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bind = new NewAdbooking.Classes.webbooking();
            ds = bind.bindchild(parentNodeID, hiddencompcode.Value, hdnuserid.Value);
        }


        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking bind = new NewAdbooking.classesoracle.webbooking();
            ds = bind.bindchild(parentNodeID, hiddencompcode.Value, hdnuserid.Value);
        }

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TreeNode childNode = new TreeNode();
           
            childNode.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString() + "(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ")"; ;
            childNode.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();

            //   someTree.SelectedNode.Expand();

            bindsub(childNode.Value, childNode);

            node.ChildNodes.Add(childNode);

            node.CollapseAll();


        }

    }



    public void bindsub(string statecode, TreeNode chilchildnode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bind = new NewAdbooking.Classes.webbooking();
            ds = bind.bindsubchild(statecode, hiddencompcode.Value, hdnuserid.Value);
        }


        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking bind = new NewAdbooking.classesoracle.webbooking();
            ds = bind.bindsubchild(statecode, hiddencompcode.Value, hdnuserid.Value);
        }


        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TreeNode childNode = new TreeNode();
            childNode.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString() + "(" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ")"; ;
            childNode.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            chilchildnode.ChildNodes.Add(childNode);
        }
    }




    public void bindtime()
    {
        tfs.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tfs.Items.Add(li1);
        }
    }


    public void bindtime1()
    {
        tts.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tts.Items.Add(li1);
        }
    }



    public void bindtime2()
    {
        tfm.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tfm.Items.Add(li1);
        }
    }


    public void bindtime3()
    {
        ttm.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            ttm.Items.Add(li1);
        }
    }


    public void bindtime4()
    {
        tft.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tft.Items.Add(li1);
        }
    }


    public void bindtime5()
    {
        ttt.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            ttt.Items.Add(li1);
        }
    }



    public void bindtime6()
    {
        tfw.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tfw.Items.Add(li1);
        }
    }


    public void bindtime7()
    {
        ttw.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            ttw.Items.Add(li1);
        }
    }



    public void bindtime8()
    {
        tft1.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tft1.Items.Add(li1);
        }
    }


    public void bindtime9()
    {
        ttt1.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            ttt1.Items.Add(li1);
        }
    }




    public void bindtime10()
    {
        tff.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tff.Items.Add(li1);
        }
    }


    public void bindtime11()
    {
        ttf.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            ttf.Items.Add(li1);
        }
    }


    public void bindtime12()
    {
        tfsat.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));




        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            tfsat.Items.Add(li1);
        }
    }


    public void bindtime13()
    {
        ttsat.Items.Clear();
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));


        for (int i = 0; i < ds.Tables[6].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[6].Rows[0].ItemArray[i].ToString();

            li1.Value = ds.Tables[6].Rows[0].ItemArray[i].ToString();
            ttsat.Items.Add(li1);
        }
    }




    public void bindagegroup()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));
        ListItem li = new ListItem();
        int i;
        age1.Items.Clear();

        li.Text = "--Select Age Group--";
        li.Value = "0";
        li.Selected = true;
        age1.Items.Add(li);
        for (i = 0; i < ds.Tables[7].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[7].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[7].Rows[0].ItemArray[i].ToString();
            age1.Items.Add(li1);
        }

    }




    public void dynamiccheckbox()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));
        int i;
        string str = "";
        str += "<table><tr>";
        for (i = 0; i < ds.Tables[9].Columns.Count; i++)
        {

            str += "<td style='font-family:Verdana;font-size:14px;' ><input Enabled='True'  type='checkbox' id='" + "te" + i + "'Text='" + ds.Tables[9].Rows[0].ItemArray[i].ToString() + "'Value='" + ds.Tables[9].Rows[0].ItemArray[i].ToString() + "'  >" + ds.Tables[9].Rows[0].ItemArray[i].ToString() + "</td>";

        }
        str += "</table></tr>";
        dynamiccheck.InnerHtml += str;
    }



    public void bindoccupation()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));
        ListItem li = new ListItem();
        int i;
        occup.Items.Clear();

        li.Text = "--Select Occupation--";
        li.Value = "0";
        li.Selected = true;
        occup.Items.Add(li);
        for (i = 0; i < ds.Tables[8].Columns.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Text = ds.Tables[8].Rows[0].ItemArray[i].ToString();
            i = i + 1;
            li1.Value = ds.Tables[8].Rows[0].ItemArray[i].ToString();
            occup.Items.Add(li1);
        }

    }



    [Ajax.AjaxMethod]
    public DataSet sayedays12345(string Rotation, string Priority, string Sunday, string Sunday_From, string Sunday_To, string Monday, string Monday_From, string Monday_To, string Tuesday, string Tuesday_From, string Tuesday_To, string Wedneday, string Wedneday_From, string Wednesday_To, string Thursday, string Thursday_From, string Thursday_To, string Friday, string Friday_From, string Friday_To, string Saturday, string Saturday_From, string Saturday_To, string Demog_sex, string Demog_agegroup, string Demog_Occup, string Demog_inter, string ciobookingid, string noofinsert, string compcode, string edition)
    {


        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.savedays123(Rotation, Priority, Sunday, Sunday_From, Sunday_To, Monday, Monday_From, Monday_To, Tuesday, Tuesday_From, Tuesday_To, Wedneday, Wedneday_From, Wednesday_To, Thursday, Thursday_From, Thursday_To, Friday, Friday_From, Friday_To, Saturday, Saturday_From, Saturday_To, Demog_sex, Demog_agegroup, Demog_Occup, Demog_inter, ciobookingid, noofinsert, compcode, edition);
        }
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.classesoracle.webbooking execute = new NewAdbooking.classesoracle.webbooking();
        //    executequery = execute.savegeo(country, state, city, edition, ciobookid);

        //}
        return executequery;

    }


    [Ajax.AjaxMethod]
    public DataSet deltegeo(string compcode, string edition, string noofinsert, string ciobokid, string country, string statecode, string City)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bindrate = new NewAdbooking.Classes.webbooking();
            dx = bindrate.deletegeography(compcode, edition, noofinsert, ciobokid, country, statecode, City);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            NewAdbooking.classesoracle.webbooking bindrate = new NewAdbooking.classesoracle.webbooking();
            dx = bindrate.deletegeography(compcode, edition, noofinsert, ciobokid, country, statecode, City);
        }
        else
        {
            //  NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
            //  dx = bindrate.ratebind(adcat, compcode);
        }
        return dx;

    }




}
