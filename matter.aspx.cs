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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
public partial class matter : System.Web.UI.Page
{
    /*change for oracle*/
    DataSet dsModify_tem = new DataSet();
    string previd = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string keyboard = "";
        string receiptno = "";
        string HH = "";
        string language = ConfigurationSettings.AppSettings["language"].ToString();
        if (Request.QueryString["all"] != null)
        {
            keyboard = Request.QueryString["all"].ToString();
        }
        if (Request.QueryString["receiptno"] != null)
        {
            receiptno = Request.QueryString["receiptno"].ToString();
        }
        if (Request.QueryString["receiptno"] != null)
        {
            HH = Request.QueryString["HH"].ToString();
        }

       
         if (Request.QueryString["eyecatchtype"] != null)
        {
            hiddeneyecatchval.Value = Request.QueryString["eyecatchtype"].ToString();
            hiddenbPrem.Value = Request.QueryString["bPrem"].ToString();
        }
        if (language != "multi")
        {
            if (keyboard == "no" && HH=="no")
            {
                editordiv.Style.Value = "font-size: 16px;font-family:arial;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                KEYBORD.Visible = false;
                CmbLanguage.Visible = false;
            }
            else if (HH=="no")
            {
                editordiv.Style.Value = "font-size: 16px;font-family:arial;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                KEYBORD.Visible = false;
                CmbLanguage.Visible = false;
            }
            else
            {
                editordiv.Style.Value = "font-size: 16px;font-family:hindbody;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                CmbLanguage.Attributes.Add("onchange", "changelang(this.value)");
            }
        }
        else
        {
            if (keyboard == "no" && HH == "no")
            {
                editordiv.Style.Value = "font-size: 16px;font-family:arial;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                KEYBORD.Visible = false;
                CmbLanguage.Visible = false;
            }
            else if (keyboard == "" && HH == "")
            {
                editordiv.Style.Value = "font-size: 16px;font-family:arial;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                KEYBORD.Visible = false;
                CmbLanguage.Visible = false;
            }
            else if (HH == "no")
            {
                editordiv.Style.Value = "font-size: 16px;font-family:arial;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                KEYBORD.Visible = false;
                CmbLanguage.Visible = false;
            }
            else
            {
                editordiv.Style.Value = "font-size: 16px;font-family:hindbody;  border:4px ; width: 700px; height: 270px;border-style: double;overflow: auto;";
                CmbLanguage.Attributes.Add("onchange", "changelang(this.value)");
            }
        }
        Response.Expires = -1;
        if (Request.QueryString["prevcioid"] != null)
        {
            hiddenpreviousid.Value = Request.QueryString["prevcioid"].ToString();
        }
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.close();</script>");
            return;
        }
        /*new change 15 mar*/
        /*Hindustan*/
        hiddenuom_desc.Value = Request.QueryString["uom_desc_"].ToString();
        if (Session["insertname_logo"] == null && hiddenuom_desc.Value == "ROD" && Request.QueryString["modify"].ToString() == "0" && Request.QueryString["prevcioid"]=="")
        {
            //hiddensessionlogo.Value = "";
            //Response.Redirect("login.aspx");
            Response.Write("<script>alert(\"Please upload the logo\");window.close();</script>");
        }
      
        Ajax.Utility.RegisterTypeForAjax(typeof(matter));
        cioid.Value = Request.QueryString["cioid"].ToString();
        hiddensrno.Value = Request.QueryString["srno"].ToString();
        hiddenedition.Value = Request.QueryString["edition"].ToString();
        hiddeneyecatcher.Value = Request.QueryString["eyecatch"].ToString();
        hiddenbgcolor.Value = Request.QueryString["bgcolor"].ToString();
       // hiddenwidth.Value=Request.QueryString["width"].ToString();
        //////////////*change*////////////////////
        /*new change ankur sharma*/
        hiddenuom_desc.Value = Request.QueryString["uom_desc_"].ToString();
        /*new change ankur 9 feb*/
        hiddencoltype.Value = Request.QueryString["coltype"].ToString();
        /////////////this is to get the bgcolor name 
        /*new change ankur for matter*/
        if(Request.QueryString["name_logo"]!=null)
            hiddenlogoname.Value = Request.QueryString["name_logo"].ToString();
        ////////////////////////////
        /*new change ankur matter*/
             /*new change ankur for matter*//*Hindustan*/
        if (Request.QueryString["name_logo"] != null)
            hiddenlogoname.Value = Request.QueryString["name_logo"].ToString();
        /*change for oracle*/
        if(Request.QueryString["prevcioid"]!=null)
            previd = Request.QueryString["prevcioid"].ToString();
        if (hiddenuom_desc.Value == "ROD")
        {
            hiddenlogohei.Value = Request.QueryString["logohei"].ToString();
            hiddenlogowid.Value = Request.QueryString["logowid"].ToString();
        }
        else
        {
            hiddenlogohei.Value = "nologo";
            hiddenlogowid.Value = "nologo";

        }
        DataSet dsgetbgname = new DataSet();
        if (hiddenbgcolor.Value != "White")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
                dsgetbgname = getpubwidth.getwidth_qbc(hiddenbgcolor.Value, Session["compcode"].ToString());
            }
            else

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                                    NewAdbooking.classesoracle .BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
                dsgetbgname = getpubwidth.getwidth_qbc(hiddenbgcolor.Value, Session["compcode"].ToString());

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();

                dsgetbgname = getpubwidth.getwidth_qbc(hiddenbgcolor.Value, Session["compcode"].ToString());

            }
        if (dsgetbgname.Tables[1].Rows.Count > 0)
        {
            hiddenbgcolor.Value = dsgetbgname.Tables[1].Rows[0].ItemArray[0].ToString();
        }

        }

        //////////////////////////////////////////////////////////////////////////////////
        /*new change ankur 15 feb*/
        if (hiddenbgcolor.Value != "White")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();

                dsgetbgname = getpubwidth.getwidth_qbc(hiddencoltype.Value, Session["compcode"].ToString());
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();

                    dsgetbgname = getpubwidth.getwidth_qbc(hiddencoltype.Value, Session["compcode"].ToString());

                }
            else
            {
                NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();

                dsgetbgname = getpubwidth.getwidth_qbc(hiddencoltype.Value, Session["compcode"].ToString());

            }
        if (dsgetbgname.Tables[2].Rows.Count > 0)
        {
            hiddencoltype.Value = dsgetbgname.Tables[2].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            hiddencoltype.Value = "";
        }

        }



        string edition_ = Request.QueryString["width"].ToString();
        edition_ = edition_.Replace("^", "+");
        /*new change ankur 9 feb*/
        DataSet dsgetwidth = new DataSet();
        /*  this to calculate the width for publication*/
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getpubwidth = new NewAdbooking.Classes.BookingMaster();
            
            dsgetwidth = getpubwidth.getwidth_qbc(edition_, Session["compcode"].ToString());
        }

        else

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                            NewAdbooking.classesoracle .BookingMaster getpubwidth = new NewAdbooking.classesoracle.BookingMaster();
            
            dsgetwidth = getpubwidth.getwidth_qbc(edition_, Session["compcode"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.BookingMaster getpubwidth = new NewAdbooking.classmysql.BookingMaster();

            dsgetwidth = getpubwidth.getwidth_qbc(edition_, Session["compcode"].ToString());

        }
        if(dsgetwidth.Tables[0].Rows.Count>0)
            hiddenwidth.Value = dsgetwidth.Tables[0].Rows[0].ItemArray[0].ToString();

        ////////////////////////////////////////////////////////////



        hiddenuom.Value=Request.QueryString["uom"].ToString();
        if (!Page.IsPostBack)
        {
            bindspecialcharacter();
            btnprev.Attributes.Add("OnClick", "javascript:return buttonprevQBC();");
            lbpickchar.Attributes.Add("onclick", "insertintomatter();");
            

        }
        //editordiv.Attributes.Add("onkeypress", "javascript:return enblPrev();");
       hiddeneyecatchlength.Value = Request.QueryString["eyecatchlength"].ToString();
       hiddeninsert.Value=Request.QueryString["insertid"].ToString();

       hiddenInsertNo.Value = Request.QueryString["insertNo"].ToString();
       string modify = Request.QueryString["modify"].ToString();
       hiddenmodify.Value = Request.QueryString["modify"].ToString();

        //****************By Manish Verma***************************
       //if (Request.QueryString["line"].ToString() != "")
       //{
       //    txtnoofline.Text = Request.QueryString["line"].ToString();
       //}
        /*change for oracle*/
        //this is the case when the user want to copy the contents 

       if (Session["savedata"] == null && previd!="")
       {
           if (hiddensrno.Value == "All")
           {
               //string fname = previd + "-All.xtg";
               string fname = receiptno + "-All.xtg";
               getMatterData_prev(fname);
           }
           else
           {
               string fname = Request.QueryString["filename"].ToString();
               getMatterData(fname);
           }
       }

       if (modify == "0" && (dsModify_tem.Tables.Count<=0 || dsModify_tem.Tables[0].Rows.Count <= 0))
       {
           if (Session["savedata"] != null)
           {

               DataSet ds = (DataSet)Session["savedata"];
               //string fileName = Request.QueryString["filename"].ToString();
               if (Request.QueryString["filename"].ToString() != "")
               {
                   if (hiddensrno.Value == "All")
                   {
                       string data = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                       data = data.Replace("<br>", "");
                       editordiv.InnerHtml = data;
                   }
                   else
                   {
                       for (int i = 0; i < ds.Tables.Count; i++)
                       {
                           if (ds.Tables[i].Rows[0].ItemArray[1].ToString() == Request.QueryString["filename"].ToString())
                           {
                               string data = ds.Tables[i].Rows[0].ItemArray[4].ToString();
                               data = data.Replace("<br>", "");
                               editordiv.InnerHtml = data;
                               break;
                           }
                       }
                   }
               }
           }
       }
       else
       {
           if (Session["savedata"] == null)
           {
               if (hiddensrno.Value == "All")
               {
                   //string fname = cioid.Value + "-All.xtg";
                   string fname = receiptno + "-All.xtg";
                   if (previd == "")
                   {
                       getMatterData(fname);
                   }
                   else
                   {
                       //string fname1 = previd + "-All.xtg";
                       string fname1 = receiptno + "-All.xtg";
                       getMatterData_prev(fname1);
                   }
               }
               else
               {
                   string fname = Request.QueryString["filename"].ToString();
                   getMatterData(fname);
               }
           }
           else
           {
               string flag = "0";
               string fName;
               NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
               DataSet dsModify = new DataSet();
               if (hiddensrno.Value == "All")
               {
                   //fName = cioid.Value + "-All.xtg";
                   fName = receiptno + "-All.xtg";
               }
               else
               {
                   fName = Request.QueryString["filename"].ToString();
               }
               dsModify = (DataSet)Session["savedata"];
               for (int i = 0; i < dsModify.Tables.Count; i++)
               {
                   if (dsModify.Tables[i].Rows[0].ItemArray[1].ToString() == fName)
                   {
                       string data = dsModify.Tables[i].Rows[0].ItemArray[4].ToString();
                       data = data.Replace("<br>", "");
                       editordiv.InnerHtml = data;
                       flag = "1";
                       break;
                   }
               }
               

               if (flag == "0")
               {
                   string fname = Request.QueryString["filename"].ToString();
                   getMatterData(fname);
               }

           }

       }
       btnok.Attributes.Add("onClick", "javascript:return okClick_matter();");
        btnok.Enabled = false;    
        //**************************************************************
       
    }
    /*new change */
    /*new change */
    /*Hindustan*/
    public void bindspecialcharacter()
    {
        DataSet objDataSetxml = new DataSet();
        // Read in the XML file
        objDataSetxml.ReadXml(Server.MapPath("XML/insertspecialcharacter.xml"));
        lbpickchar.Items.Clear();

        for (int z = 0; z < objDataSetxml.Tables[0].Columns.Count; z++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = objDataSetxml.Tables[0].Rows[0].ItemArray[z].ToString();
            li.Text = objDataSetxml.Tables[0].Rows[0].ItemArray[z].ToString();
            lbpickchar.Items.Add(li);

        }


    }



    private void getMatterData(string fName)
    {
        DataSet dsModify = new DataSet();
        
        if(ConfigurationSettings.AppSettings ["COnnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();        
        dsModify = csModify.getMatter(cioid.Value, fName);
        dsModify_tem = csModify.getMatter(cioid.Value, fName);
        }
        else
            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
            if (Session["savedata"] == null && previd != "")
            {
                dsModify = csModify.getMatter(previd, fName);
            }
            else
            {
                dsModify = csModify.getMatter(cioid.Value, fName);
            }
        //dsModify_tem = csModify.getMatter(cioid.Value, fName);


        }
            else
            {
                NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                if (Session["savedata"] == null && previd != "")
                {
                    dsModify = csModify.getMatter(previd, fName);
                }
                else
                {
                    dsModify = csModify.getMatter(cioid.Value, fName);
                }
               // dsModify_tem = csModify.getMatter(cioid.Value, fName);


            }

        if (dsModify.Tables[0].Rows.Count == 0)
        {
            editordiv.InnerHtml = "";
        }
        else
        {
            string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
            data = data.Replace("<br>", "");
            editordiv.InnerHtml = data;
        }
    }

    /*change for oracle*/

    private void getMatterData_prev(string fName)
    {
        DataSet dsModify = new DataSet();

        if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster csModify = new NewAdbooking.Classes.BookingMaster();
            dsModify = csModify.getMatter(previd, fName);
            dsModify_tem = csModify.getMatter(previd, fName);
        }
        else
            if (ConfigurationSettings.AppSettings["COnnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster csModify = new NewAdbooking.classesoracle.BookingMaster();
                if (Session["savedata"] == null && previd != "")
                {
                    dsModify = csModify.getMatter(previd, fName);
                    dsModify_tem = csModify.getMatter(previd, fName);
                }
                else
                {
                    dsModify = csModify.getMatter(cioid.Value, fName);
                    dsModify_tem = csModify.getMatter(cioid.Value, fName);
                }


            }
            else
            {
                NewAdbooking.classmysql.BookingMaster csModify = new NewAdbooking.classmysql.BookingMaster();
                if (Session["savedata"] == null && previd != "")
                {
                    dsModify = csModify.getMatter(previd, fName);
                    dsModify_tem = csModify.getMatter(previd, fName);
                }
                else
                {
                    dsModify = csModify.getMatter(cioid.Value, fName);
                    dsModify_tem = csModify.getMatter(cioid.Value, fName);
                }


            }

        if (dsModify.Tables[0].Rows.Count == 0)
        {
            editordiv.InnerHtml = "";
        }
        else
        {
            string data = dsModify.Tables[0].Rows[0].ItemArray[0].ToString();
            data = data.Replace("<br>", "");
            editordiv.InnerHtml = data;
        }
    }
//////////////////////////


   
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    //[Ajax.AjaxMethod]
    public string savethematterinsession(string str, string matterText)
    {
        string ah = str;
        ah = ah.Trim().Replace("&nbsp;", " ").Replace("&NBSP;", " ");
        ah = Regex.Replace(ah, "<a href[^>]*>", "");
        ah = Regex.Replace(ah, "<A href[^>]*>", "");
        ah = ah.Replace("</A>", "");
        while (ah.IndexOf("  ") >= 0)
        {
            ah = ah.Replace("  ", " ");
        }

        HttpContext.Current.Session["matter_session"] = ah.Trim();

        HttpContext.Current.Session["matterText_session"] = matterText;

        //return str;
        return ah;

    }

}
