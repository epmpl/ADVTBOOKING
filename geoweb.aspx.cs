using System;
using System.Collections.Generic;
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

public partial class geoweb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(geoweb));

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }

        hdnciobookid.Value = Request.QueryString["ciobookid"].ToString();
        hdneditiongeo.Value = Request.QueryString["editiongeo"].ToString();
        hdnnoinsert.Value = Request.QueryString["noofinsert"].ToString();
        hdnadcategory.Value = Request.QueryString["adcategory"].ToString();
        hdnuom.Value = Request.QueryString["uom1"].ToString();
        hdndummydate.Value = Request.QueryString["txtdummydate1"].ToString();
        hdnpageprem.Value = Request.QueryString["drppageprem"].ToString();
        excutegeographytemp(hdnciobookid.Value, Session["compcode"].ToString(), hdnnoinsert.Value);
        dynamiccheckbox();
        hiddencompcode.Value=Session["compcode"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        bindtreeview(hiddencompcode.Value);
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
        if (!Page.IsPostBack)
        {
       Button1.Attributes.Add("onclick", "javascript:return openrotation();");
       someTree.Attributes.Add("onclick","OnTreeClick(event)");
       cancel.Attributes.Add("onclick", "javascript:return exit();");
       save.Attributes.Add("onclick", "javascript:return savegeo();");
       tfs.Attributes.Add("onChange", "javascript:return comparesundayfrom();");
       tts.Attributes.Add("onChange", "javascript:return comparesundayto();");
       tfm.Attributes.Add("onChange", "javascript:return comparemondayfrom();");
       ttm.Attributes.Add("onChange", "javascript:return comparemondayto();");
       tft.Attributes.Add("onChange", "javascript:return comparetuesdayfrom();");
       ttt.Attributes.Add("onChange", "javascript:return comparetuesdayto();");
       tfw.Attributes.Add("onChange", "javascript:return comparewednesdayfrom();");
       ttw.Attributes.Add("onChange", "javascript:return comparewednesdayto();");
       tft1.Attributes.Add("onChange", "javascript:return comparethursdayfrom();");
       ttt1.Attributes.Add("onChange", "javascript:return comparethursdayto();");
       tff.Attributes.Add("onChange", "javascript:return comparefridayfrom();");
       ttf.Attributes.Add("onChange", "javascript:return comparefridayto();");
       tfsat.Attributes.Add("onChange", "javascript:return comparedsaturdayfrom();");
       ttsat.Attributes.Add("onChange", "javascript:return comparesaturdayto();");
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
            childNode.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString() + "(" + ds.Tables[0].Rows[i].ItemArray[0].ToString()+")"; ;
            childNode.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
         //   someTree.SelectedNode.Expand();
            bindsub(childNode.Value,childNode);
            node.ChildNodes.Add(childNode);
            node.CollapseAll();
        }
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
        for (i = 0; i < ds.Tables[0].Rows.Count-1; i++)
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


    public void  bindsub(string statecode ,TreeNode chilchildnode)
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


    public void dynamiccheckbox()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/webbooking.xml"));
        int i;
        string str = "";
        str += "<table><tr>";
        for (i = 0; i < ds.Tables[9].Columns.Count; i++)
        {
            str += "<td style='font-family:Verdana;font-size:14px;' ><input  type='checkbox' id='" + "te" + i + "'Text='" + ds.Tables[9].Rows[0].ItemArray[i].ToString() + "'Value='" + ds.Tables[9].Rows[0].ItemArray[i].ToString() + "' >" + ds.Tables[9].Rows[0].ItemArray[i].ToString() + "</td>";
        }
        str+="</table></tr>";
        dynamiccheck.InnerHtml += str;
    }



    [Ajax.AjaxMethod]
    public DataSet savegeography(string country, string state, string city, string edition, string ciobookid,string noinsert,string compcode)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.savegeo(country, state, city, edition, ciobookid, noinsert,compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking execute = new NewAdbooking.classesoracle.webbooking();
            executequery = execute.savegeo(country, state, city, edition, ciobookid, noinsert, compcode);

        }
        return executequery;
    }



    [Ajax.AjaxMethod]
    public DataSet sayedays123(string Rotation, string Priority, string Sunday, string Sunday_From, string Sunday_To, string Monday, string Monday_From, string Monday_To, string Tuesday, string Tuesday_From, string Tuesday_To, string Wedneday, string Wedneday_From, string Wednesday_To, string Thursday, string Thursday_From, string Thursday_To, string Friday, string Friday_From, string Friday_To, string Saturday, string Saturday_From, string Saturday_To, string Demog_sex, string Demog_agegroup, string Demog_Occup, string Demog_inter,string ciobookingid,string noofinsert,string compcode,string edition,string uom,string premium,string adcatcode,string date_time,string interest)
    {
        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.savedays( Rotation,  Priority,  Sunday,  Sunday_From,  Sunday_To,  Monday,  Monday_From,  Monday_To,  Tuesday,  Tuesday_From,  Tuesday_To,  Wedneday,  Wedneday_From,  Wednesday_To,  Thursday,  Thursday_From,  Thursday_To,  Friday,  Friday_From,  Friday_To,  Saturday,  Saturday_From,  Saturday_To,  Demog_sex, Demog_agegroup, Demog_Occup, Demog_inter, ciobookingid, noofinsert, compcode,edition, uom, premium, adcatcode,date_time,interest);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking execute = new NewAdbooking.classesoracle.webbooking();
            executequery = execute.savedays(Rotation, Priority, Sunday, Sunday_From, Sunday_To, Monday, Monday_From, Monday_To, Tuesday, Tuesday_From, Tuesday_To, Wedneday, Wedneday_From, Wednesday_To, Thursday, Thursday_From, Thursday_To, Friday, Friday_From, Friday_To, Saturday, Saturday_From, Saturday_To, Demog_sex, Demog_agegroup, Demog_Occup, Demog_inter, ciobookingid, noofinsert, compcode, edition, interest);

        }
        return executequery;
    }


    [Ajax.AjaxMethod]
    public DataSet tempexcutedays12345(string cio, string compcode, string noofinsert)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bindrate = new NewAdbooking.Classes.webbooking();
            dx = bindrate.tempexecutedays(cio, compcode, noofinsert);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking bindrate = new NewAdbooking.classesoracle.webbooking();
            dx = bindrate.tempexecutedays(cio, compcode, noofinsert);
        }
        return dx;
    }


    [Ajax.AjaxMethod]
    public DataSet tempdeltegeo(string compcode, string edition, string noofinsert, string ciobokid, string country, string statecode, string City)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bindrate = new NewAdbooking.Classes.webbooking();
            dx = bindrate.tempdeletegeography(compcode, edition, noofinsert, ciobokid,  country,  statecode,  City);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking bindrate = new NewAdbooking.classesoracle.webbooking();
            dx = bindrate.tempdeletegeography(compcode, edition, noofinsert, ciobokid, country, statecode, City);
        }

        return dx;

    }


    public void excutegeographytemp(string cio, string compcode, string noofinsert)
    {
        DataSet dx = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking bindrate = new NewAdbooking.Classes.webbooking();
            dx = bindrate.executegeotemp(cio, compcode, noofinsert);
        }
        else
        {
            NewAdbooking.classesoracle.webbooking bindrate = new NewAdbooking.classesoracle.webbooking();
            dx = bindrate.executegeotemp(cio, compcode, noofinsert);
        }
        string str = "";
        if (dx.Tables[0].Rows.Count > 0)
        {
            string country, city, state;
            for (int i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                if (dx.Tables[0].Rows[i]["Country"].ToString() == "" || dx.Tables[0].Rows[i]["Country"].ToString()=="")
                {
                    country = "";
                }
                else
                {
                  

                    country = "---" + dx.Tables[0].Rows[i]["Country"].ToString() + "(" + dx.Tables[0].Rows[i]["Country1"].ToString() + ")";
                }
                if (dx.Tables[0].Rows[i]["Statecode"].ToString() == "" || dx.Tables[0].Rows[i]["Statecode"].ToString() == "")
                {
                    state = "";
                }
                else
                {
                    state = "---" + dx.Tables[0].Rows[i]["Statecode"].ToString() + "(" + dx.Tables[0].Rows[i]["Statecode1"].ToString() + ")";

                }
                if (dx.Tables[0].Rows[i]["city"].ToString() == "" || dx.Tables[0].Rows[i]["city"].ToString()=="")
                {
                    city = "";

                }
                else
                {
                    city = "---" + dx.Tables[0].Rows[i]["city"].ToString() + "(" + dx.Tables[0].Rows[i]["city1"].ToString() + ")";
                }


                if (dx.Tables[0].Rows[i]["Country"].ToString() != "" && dx.Tables[0].Rows[i]["Statecode"].ToString() != "" && dx.Tables[0].Rows[i]["city"].ToString() != "")
                {


                    str += "<div id=" + country + state + city + " ><table width='200px'><tr><td style='font-size:10px;font-family:arial'>" + "<i>Country</i>" + country + "</br>" + "<i>State</i>" + state + "</br>" + "<i>City</i>" + city + "</td><td style='display:none;'>" + "**" + dx.Tables[0].Rows[i]["Edition"] + "+" + dx.Tables[0].Rows[i]["cio_booking_id"] + "+" + dx.Tables[0].Rows[i]["NO_INSERT"] + "+" + dx.Tables[0].Rows[i]["Comp_Code"] + "</td><td style='align:right;float:right;'   ><a href='#'  id=" + country + state + city + " onclick='abc_close123(this.id)'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>";
                }


                if (dx.Tables[0].Rows[i]["Country"].ToString() != "" && dx.Tables[0].Rows[i]["Statecode"].ToString() != "" && dx.Tables[0].Rows[i]["city"].ToString() == "")
                {


                    str += "<div id=" + country + state + city + " ><table width='200px'><tr><td style='font-size:10px;font-family:arial'>" + "<i>Country</i>" + country + "</br>" + "<i>State</i>" + state + "</br>" + city + "</td><td style='display:none;'>" + "**" + dx.Tables[0].Rows[i]["Edition"] + "+" + dx.Tables[0].Rows[i]["cio_booking_id"] + "+" + dx.Tables[0].Rows[i]["NO_INSERT"] + "+" + dx.Tables[0].Rows[i]["Comp_Code"] + "</td><td style='align:right;float:right;'   ><a href='#'  id=" + country + state + city + " onclick='abc_close123(this.id)'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>";
                }


                if (dx.Tables[0].Rows[i]["Country"].ToString() != "" && dx.Tables[0].Rows[i]["Statecode"].ToString() == "" && dx.Tables[0].Rows[i]["city"].ToString() == "")
                {


                    str += "<div id=" + country + state + city + " ><table width='200px'><tr><td style='font-size:10px;font-family:arial'>" + "<i>Country</i>" + country + "</br>" + state + "</br>" + city + "</td><td style='display:none;'>" + "**" + dx.Tables[0].Rows[i]["Edition"] + "+" + dx.Tables[0].Rows[i]["cio_booking_id"] + "+" + dx.Tables[0].Rows[i]["NO_INSERT"] + "+" + dx.Tables[0].Rows[i]["Comp_Code"] + "</td><td style='align:right;float:right;'   ><a href='#'  id=" + country + state + city + " onclick='abc_close123(this.id)'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>";
                }

                dynamicvalue.InnerHtml = str;
            }




        }





    }










}
