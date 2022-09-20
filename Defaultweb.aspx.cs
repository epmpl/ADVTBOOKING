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
using System.IO;
using System.Drawing;
using System.Diagnostics;
using forCopy;

public partial class Defaultweb : System.Web.UI.Page
{
    string filename;
    string ciobookid;
    string aa;
    string inserts;
    string edition;
    string ins;

    string final_date, txt_today_date;
    public int dd_sys, yyyy_sys, mm_sys;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>");
            return;
        }

        string system_date = System.DateTime.Now.ToString();
        String[] split_date = system_date.Split('/');
        string mm = split_date[0];
        string dd = split_date[1];
        string yyyy = split_date[2];
        final_date = dd + "/" + mm + "/" + yyyy.Substring(0, 4);
       // txt_today_date.Value = final_date; //sending to javascript
        //txtpubdate.Value = final_date;
        dd_sys = Convert.ToInt32(dd);
        mm_sys = Convert.ToInt32(mm);
        yyyy_sys = Convert.ToInt32(yyyy.Substring(0, 4));
 





        Ajax.Utility.RegisterTypeForAjax(typeof(Defaultweb));
        filename = Request.QueryString["filename"];

        hdnins.Value = Request.QueryString["ins"].ToString();
        hdnedit123.Value = Request.QueryString["edition"].ToString();
        //hdnins123.Value = Request.QueryString["ins"].ToString();
        hdnciobookid.Value = Request.QueryString["ciobookid"];
        hdnfileid.Value = Request.QueryString["fileid"];
        hdntemp.Value = Request.QueryString["temp"].ToString();
        hdncompcode.Value=Session["compcode"].ToString();

        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        ins = hdnins.Value;

              if (!Page.IsPostBack)
        {

          // btnsave1.Attributes.Add("OnClick", "javascript:return savewebmaterial();");
            btncancel1.Attributes.Add("OnClick", "javascript:return exitdefault3();");
            lblfilename.Attributes.Add("OnClick", "javascript:return openfile();");
                  }



    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string str1 = FileUpload1.PostedFile.FileName;
        string str2 = Path.GetFileName(str1);

        string filnam = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string filename1 = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("."));
        string val = hdnciobookid.Value + "-" + hdnins.Value + "-" + hdnedit123.Value;
     
        int ind = str2.LastIndexOf(".");
        string tot1 = filnam.Substring(0, ind);
        string tot11 = filnam.Substring(0, 5);
        string fileid = Request.QueryString["fileid"].ToString();
        string aa1 = tot11 + "_" + val  + filename1;


        string aa = yyyy_sys + "_" + mm_sys + "_" + dd_sys +"_"+ aa1 ;


        string per="";

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking cls_book = new NewAdbooking.Classes.webbooking();


            if (hdntemp.Value == "A")
            {

                per = cls_book.webmaterial(hdnciobookid.Value, filename1, tot1, "", aa, hdncompcode.Value, hdnins.Value, hdnedit123.Value);

            }
            else if (hdntemp.Value == "B")
            {

                per = cls_book.updatewebmaterial(hdnciobookid.Value, filename1, tot1, "", aa, hdncompcode.Value, hdnins.Value, hdnedit123.Value);

            }
            else
            {
            }

            if (per == "True")
            {

                Response.Write("<script>alert(\"Web Material Updated Successfully\");</script>");
            //    ClientScript.RegisterStartupScript(typeof(Defaultweb), "closePage", "window.close();", true);

            }
            else
            {

                Response.Write("<script>alert(\"Some Error.\");</script>");

            }



            if (fileid != "bookdiv")
            {



                tot1 = tot1.Replace(tot1, aa + filename1);




                FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("webmaterial"), aa));
                ScriptManager.RegisterStartupScript(this, typeof(Defaultweb), "ss", "addlabel('" + aa + "');", true);
               
                int valued = Convert.ToInt32(hdnins.Value)-1;                
                string fill = "<script>";
                fill = fill + "var y=window.opener.document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length;";
                fill = fill + "var filename ;";
                fill = fill + "var i;";
                fill = fill + "filename=\"fil"+valued+"\";";
                fill = fill + "window.opener.document.getElementById(filename).value='" + aa + "';";
                fill = fill + "</script>";
                Response.Write(fill);
            }
            else
            {
                string val1 = hdnciobookid.Value  + "-" + hdnedit123.Value;

                if (filename1 == ".jpg")
                {
                    tot1 = tot1.Replace(tot1, val1 + ".jpg");
                }

                FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("webmaterial"), aa));
                ScriptManager.RegisterStartupScript(this, typeof(Defaultweb), "ss", "addlabel('" + aa + "');", true);

                string fill = "<script>";
                fill = fill + "var y=window.opener.document.getElementById('" + fileid + "').getElementsByTagName('table')[0].rows.length;";
                fill = fill + "var filename;";
              
                fill = fill + "var i;";
                fill = fill + "for(i=0;i<y-1;i++)";
                fill = fill + "{";
                fill = fill + "filename=\"fil\"+i;";
             
                fill = fill + "window.opener.document.getElementById(filename).value='" + val1 + "';";

                fill = fill + "}";
                fill = fill + "</script>";
                Response.Write(fill);

            }


        }



        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking cls_book = new NewAdbooking.classesoracle.webbooking();

            per = cls_book.webmaterial(hdnciobookid.Value, filename1, str2, "", aa, hdncompcode.Value, hdnins.Value, hdnedit123.Value);


            if (per == "True")
            {

                Response.Write("<script>alert(\"Web Material Updated Successfully\");</script>");
                //    ClientScript.RegisterStartupScript(typeof(Defaultweb), "closePage", "window.close();", true);

            }
            else
            {

                Response.Write("<script>alert(\"Some Error.\");</script>");

            }



            if (fileid != "bookdiv")
            {



                tot1 = tot1.Replace(tot1, aa + filename1);




                FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("webmaterial"), tot1));
                ScriptManager.RegisterStartupScript(this, typeof(Defaultweb), "ss", "addlabel('" + tot1 + "');", true);

                int valued = Convert.ToInt32(hdnins.Value) - 1;
                string fill = "<script>";


                fill = fill + "var y=window.opener.document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length;";
                fill = fill + "var filename ;";

                fill = fill + "var i;";

                int cou = Convert.ToInt32(fileid.Replace("fil", ""));

                fill = fill + "filename=\"fil" + valued + "\";";



                fill = fill + "window.opener.document.getElementById(filename).value='" + aa + "';";

                fill = fill + "</script>";
                Response.Write(fill);
            }
            else
            {
                string val1 = hdnciobookid.Value + "-" + hdnedit123.Value;


                if (filename1 == ".jpg")
                {
                    tot1 = tot1.Replace(tot1, val1 + ".jpg");
                }

                FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("webmaterial"), tot1));
                ScriptManager.RegisterStartupScript(this, typeof(Defaultweb), "ss", "addlabel('" + tot1 + "');", true);

                string fill = "<script>";
                fill = fill + "var y=window.opener.document.getElementById('" + fileid + "').getElementsByTagName('table')[0].rows.length;";
                fill = fill + "var filename;";

                fill = fill + "var i;";
                fill = fill + "for(i=0;i<y-1;i++)";
                fill = fill + "{";
                fill = fill + "filename=\"fil\"+i;";

                fill = fill + "window.opener.document.getElementById(filename).value='" + val1 + "';";

                fill = fill + "}";
                fill = fill + "</script>";
                Response.Write(fill);

            }


        }





        txturl.Text = str1;
    }

    //[Ajax.AjaxMethod]
    //public string Button2_Click(string cio, string imagefile, string imagename, string d, string filename)
    //{
     
    //    string per = "";
    //    //  string imagefile = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("."));
    //    //if (imagefile == ".jpg" || imagefile == ".tiff" || imagefile == ".eps" || imagefile == ".pdf" || imagefile == ".tif")
    //    //{

    //    string str1 = FileUpload1.PostedFile.FileName;

    //    string str2 = Path.GetFileName(str1);

    //    string nam = Server.MapPath("webmaterial");
    //    FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("webmaterial"), str2));

    //    if (imagefile == "jpg")
    //    {
    //        str1 = str1.Replace(str1, filename + ".jpg");
    //    }






    //    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //    {
    //        NewAdbooking.Classes.BookingMaster cls_book = new NewAdbooking.Classes.BookingMaster();

    //        per = cls_book.webmaterial(cio, imagefile, imagename, d, filename);

    //    }
    //    else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
    //    {
    //        //NewAdbooking.classmysql.BookingMaster cls_book = new NewAdbooking.classmysql.BookingMaster();
    //        //dsdate = cls_book.getCurrdate();
    //    }






    //    // }

    //    return per;
    //    //else
    //    //{
//   Response.Write("<script>alert(\"Upload Jpegs,Tiff,Eps and Pdf only.\");</script>");
    //    //    return;
    //    //}




    //}


    public void filupload(object sender, EventArgs e)
    {
        string str1 = FileUpload1.PostedFile.FileName;

        string str2 = Path.GetFileName(str1);

        txturl.Text = str2;
    }




    [Ajax.AjaxMethod]
    public DataSet execute(string cioid, string Comp_code, string NO_INSERT, string filename)
    {


        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.executewebmaterial(cioid, Comp_code, NO_INSERT, filename);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking execute = new NewAdbooking.classesoracle.webbooking();
            executequery = execute.executewebmaterial(cioid, Comp_code, NO_INSERT, filename);

        }
        return executequery;

    }


    [Ajax.AjaxMethod]
    public DataSet deleteweb(string cioid, string Comp_code, string imagename)
    {

        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();

                executequery = execute.deletewebmaterial(cioid, Comp_code, imagename);
       
        }

        return executequery;
    }


    [Ajax.AjaxMethod]
    public DataSet tempdeleteweb(string cioid, string Comp_code, string imagename)
    {

        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.deletetempwebmaterial(cioid, Comp_code, imagename);

        }

        return executequery;
    }







    [Ajax.AjaxMethod]
    public DataSet tempexecute(string cioid, string Comp_code, string NO_INSERT, string filename)
    {


        DataSet executequery = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.webbooking execute = new NewAdbooking.Classes.webbooking();
            executequery = execute.tempexecutewebmaterial(cioid, Comp_code, NO_INSERT, filename);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.webbooking execute = new NewAdbooking.classesoracle.webbooking();
           executequery = execute.tempexecutewebmaterial(cioid, Comp_code, NO_INSERT, filename);

        }
        return executequery;

    }







}
