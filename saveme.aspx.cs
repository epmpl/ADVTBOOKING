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
using System.Xml;

public partial class saveme : System.Web.UI.Page
{
    //string blogdata;
    string x, ajay,ankur;
    DataSet ds1 = new DataSet();
       
   // ABPNEW.classes.abpmaster strcountry = new ABPNEW.classes.abpmaster();
    //ABPNEW.classes.cls obj = new ABPNEW.classes.cls();
    protected void Page_Load(object sender, EventArgs e)
    {
       // saveT.Attributes.Add("onFocus", "document.getElementById('savexml').value = opener.document.getElementById('editordivxml').value;document.getElementById('savehtml').value = opener.document.getElementById('editordivhtml').value;document.getElementById('completehtml').value=opener.document.getElementById('editordivfullhtml').value; opener.document.getElementById('fetchid').value='1';document.getElementById('uom').value = opener.document.getElementById('sel_unit').value;document.getElementById('adwidth').value = opener.document.getElementById('adwidth').value;document.getElementById('adheight').value = opener.document.getElementById('adheight').value");
        
        //ankur=Request.QueryString["ankur"].ToString();
        
        
        filename.Focus();
        //DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls obj = new NewAdbooking.Classes.cls();
            ds1 = obj.get_id();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls obj = new NewAdbooking.classesoracle.orclcls();
            ds1 = obj.get_id();
        }
        

        int ct = ds1.Tables[0].Rows.Count;

        if (ds1.Tables[0].Rows.Count > 0)
        {
            temp_id.Value = Convert.ToString(ct + 1);
        }
        else
        {
            temp_id.Value = "1";
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls dd = new NewAdbooking.Classes.cls();
                    //ABPNEW.classes.cls dd = new ABPNEW.classes.cls();
                    
            ds = dd.fatchcategory();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls dd = new NewAdbooking.classesoracle.orclcls();
            //ABPNEW.classes.cls dd = new ABPNEW.classes.cls();

            ds = dd.fatchcategory();
        }
        
        int i = ds.Tables[0].Rows.Count;
        int K = 0;
        for (K = 0; K < i - 1; K++)
        {
            ListItem li = new ListItem();
            li.Text = ds.Tables[0].Rows[K].ItemArray[0].ToString();
            li.Value = ds.Tables[0].Rows[K].ItemArray[1].ToString();
            catname.Items.Add(li);
        }

    }

    //[Ajax.AjaxMethod]
  

    protected void saveT_Click(object sender, EventArgs e)
    {
        string abc = Request.UserHostAddress;
        string abc1 = Request.UserHostName;
        string xmlval = savexml.Value;
        string filterhtml = savehtml.Value;
        string htmlval = completehtml.Value;
        string uom1 = uom.Value;
        string ank="'"+filename.Text+"'";
        string ankue = catname.Text;
        Response.Write("<script>opener.document.getElementById('savehidden').value=" + ank + "</script>");
        if (uom1 == "Pixel")
        {
            uom1 = "1";
          
        }
        else if (uom1 == "Inches")
        {
            uom1 = "2";
        
        }
        else if (uom1 == "CM")
        {
            uom1 = "3";
        }
        else if (uom1 == "MM")
        {
            uom1 = "4";

        }
        else { }


           //////  if(unit==1)document.getElementById('sel_unit_disp').value="Pixel";
          //////  else if(unit==2)document.getElementById('sel_unit_disp').value="Inches";
         //////  else if(unit==3)document.getElementById('sel_unit_disp').value="CM";
        //////  else if(unit==4)document.getElementById('sel_unit_disp').value="MM";
       //////  document.getElementById('measuredialog').style.display='none'; 
        
        if (filename.Text == "")
        {
            Response.Write("<script>opener.document.getElementById('fetchid').value='';alert('Please Specify Template name ?');</script>");
        }
        else
        {
            string thisname = "Template_" + filename.Text;
            int cnt = 0;
            for (int w = 0; w < ds1.Tables[0].Rows.Count; w++)
            {
                // string x = ds1.Tables[0].Rows[w].ItemArray[1];
                x = ds1.Tables[0].Rows[w].ItemArray[1].ToString();
                if (x == thisname)
                {
                    //Response.Write("<script>alert('Template Name Exist !!');</script>");
                    cnt = 1;
                }
            }
            if (cnt == 1)
            {
                Response.Write("<script>opener.document.getElementById('fetchid').value='';alert('Template name Exist');</script>");
                Response.Write("<script>opener.document.getElementById('savehidden').value=''</script>");
            }
            else
            {
                string[] countdiv = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
                int len = countdiv.Length - 1;

                /*********************************************/

                int newid = 1;
                int newid1 = 1;
                int newid2 = 1;


                for (int i = 0; i <= len; i++)
                {
                    //int newid = 1;

                    //    string src = i.innerHTML;
                    //    char[] c ={ '\"' };
                    string s = "src=";
                    if (countdiv[i].IndexOf(s) >= 0)
                    {
                        string[] path1 = countdiv[i].Split(new string[] { "src=" }, StringSplitOptions.None);
                        string[] path2 = path1[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                        // browse.Value = path2[1];
                        string foldernameIMG = "images1/";
                        //string userfolder = "@" + "'" + "\\\\192.168.1.104/" + Server.MapPath("") + ("/") + "f1/" + temp_id.Value + "'";
                        //System.IO.Directory.CreateDirectory(userfolder);
                        string[] strsql = path2[1].Split('.');
                        string strFilename1 = "Image" + newid + "_" + temp_id.Value + "." + strsql[1];
                        string serverpath = "\\\\" + Server.MapPath("") + ("/") + foldernameIMG + strFilename1;
                        string serverpath1 = serverpath.Replace(":", "$");
                        string bcd = "\\\\" + abc + "\\" + path2[1];
                        string hostadd = bcd.Replace(":", "$");

                        /*string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                        string fn = System.IO.Path.GetFileName(hostadd);
                        string SaveLocation = serverpath1;
                        File1.PostedFile.SaveAs(SaveLocation);

                        System.IO.File.Copy(hostadd, serverpath1);*/

                    }

                    newid++;


                    //    string[] image1 = path[1].Split(c);
                    //    //path.Value = image1;
                    //    //browse.Value = image1;
                    //    //string[] strsql = image1.Split('.');
                    //    //string foldername = "images/";
                    //    //
                    //    //string strfilename2 = foldername + strFilename1;
                    //    //newid++;
                    //    //browse.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);


                }



                //string[] newhtml = filterhtml.Split(new string[] { "\"" }, StringSplitOptions.None);

                //me

                //string ac1 = null;
                string ac2 = null;
                string ac5 = null;
                string main = null;
                string[] ac = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
                for (int k = 0; k <= ac.Length - 1; k++)
                {

                    string s1 = "src=";
                    if (ac[k].IndexOf(s1) >= 0)
                    {

                        //ac1 = ac1 + ac[k];
                        string[] ac11 = ac[k].Split(new string[] { "src=" }, StringSplitOptions.None);
                        string[] ac111 = ac11[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                        string pth1 = ac111[1].Replace("%20", " ");
                        pth1 = pth1.Replace("file://", "");
                        pth1 = pth1.Replace(":", "$");
                        string pth11 = "\\\\192.168.1.104\\" + pth1;
                        //string foldernameIMG = "images1/";
                        // string[] strsql1 = ac111[1].Split('.');
                        // string strFilename1 = "Image" + newid1 + "_" + temp_id.Value + "." + strsql1[1];
                        // string serverpath = "\\\\192.168.1.104/" + Server.MapPath("") + ("/") + foldernameIMG + strFilename1;
                        // string serverpath1 = serverpath.Replace(":", "$");
                        //string sevpth = "c:/abc";
                        main = main + "<DIV" + ac11[0] + "src=" + '"' + pth11 + '\"' + ac111[2];


                    }
                    if (ac[k] == "")
                    {
                        ac5 = ac5 + ac[k];
                    }
                    //else
                    if (ac[k].IndexOf(s1) < 0 && ac[k] != "")
                    {

                        ac2 = ac2 + "<DIV" + ac[k];

                    }
                    newid1++;
                }

                string main1 = ac5 + ac2 + main;

                //me

                //me1

                string ac1new = null;
                string ac2new = null;
                string ac5new = null;
                string mainnew = null;
                string[] acnew = htmlval.Split(new string[] { "<DIV" }, StringSplitOptions.None);
                //string abc = Server.MapPath + ("/") + ("abc");
                //System.IO.Directory.CreateDirectory(@abc);
                for (int l = 0; l <= acnew.Length - 1; l++)
                {
                    string s1 = "src=";
                    if (acnew[l].IndexOf(s1) >= 0)
                    {
                        //ac1 = ac1 + ac[k];
                        string[] ac11new = acnew[l].Split(new string[] { "src=" }, StringSplitOptions.None);
                        string[] ac111new = ac11new[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                        string pth1new = ac111new[1].Replace("%20", " ");
                        pth1new = pth1new.Replace("file://", "");
                        pth1new = pth1new.Replace(":", "$");
                        string pth11new = "\\\\" + pth1new;
                        //string foldernameIMG = "images1/";
                        //string[] strsql1 = ac111new[1].Split('.');
                        //string strFilename1 = "Image" + newid2 + "_" + temp_id.Value + "." + strsql1[1];
                        //string serverpath = "\\\\192.168.1.104/" + Server.MapPath("") + ("/") + foldernameIMG + strFilename1;
                        // string serverpath1 = serverpath.Replace(":", "$");
                        //string sevpth = "c:/abc";
                        mainnew = mainnew + "<DIV" + ac11new[0] + "src=" + '"' + pth11new + '\"' + ac111new[2];
                        //string mainneww = mainnew.Replace("'","");

                    }
                    if (acnew[l] == "")
                    {
                        ac5new = ac5new + acnew[l];
                    }
                    //else
                    if (acnew[l].IndexOf(s1) < 0 && acnew[l] != "")
                    {

                        ac2new = ac2new + "<DIV" + acnew[l];

                    }
                    //newid2++;
                }

                string main1new = ac5new + ac2new + mainnew;

                /************************************************************/


                //me1

                // newid++;
                //aaaaaaaaaa
                //string ac2 = null;
                //string ac5 = null;
                //string main = null;
                //string[] ac = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
                //int len = countdiv.Length - 1;
                //for (int i = 0; i <= len; i++)
                //{
                //    string s = "src=";
                //    if (countdiv[i].IndexOf(s) >= 0)
                //    {
                //        string countdiv1 = countdiv[i].Replace("%20"," ");
                //        string countdiv2 = countdiv1.Replace("file:///","");


                //aaaaaaaaaa
                // Response.Write("<script>window.close</script>");
               
                string idTemp = temp_id.Value;
                string foldernameTMP = "Templates/";
                string paths = Server.MapPath("") + ("/") + foldernameTMP + "//";
                string location = paths + thisname + ".xml";
                
                xmlval = xmlval.Replace("<template>undefined","<template>" + ank);
                xmlval = xmlval.Replace("undefined", " ");
                xmlval = xmlval.Replace("<text />", "<text><text/>");
                xmlval = xmlval.Replace("<bgimage/>", "<bgimage><bgimage/>");

                System.IO.StreamWriter sw = new System.IO.StreamWriter(location);
                sw.WriteLine(xmlval);
                sw.Close();
                //string blogdata = xmlval;
                DataSet ds = new DataSet();
                //string htmlval1 = htmlval.Replace("file:///", "");
                //htmlval1 = htmlval1.Replace("%20", " ");
                //htmlval1 = htmlval1.Replace("//", "\\");
                //string filterhtml1 = filterhtml.Replace("file:///", "");
                //filterhtml1 = filterhtml1.Replace("%20", " ");
                //filterhtml1 = filterhtml1.Replace("//", "\\");
                //ds = obj.insertxml(Convert.ToInt32(idTemp), location, xmlval, thisname, main1new, main1);
                string adh = adheight.Value;
                string adw = adwidth.Value;
                string catcode = "";
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.cls obj = new NewAdbooking.Classes.cls();
                    ds = obj.insertxml(Convert.ToInt32(idTemp), location, xmlval, thisname, htmlval, filterhtml, uom1, adh, adw, ankue);

                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.orclcls obj = new NewAdbooking.classesoracle.orclcls();
                    ds = obj.insertxml(Convert.ToInt32(idTemp), location, xmlval, thisname, htmlval, filterhtml, uom1, adh, adw, ankue);
                }
                
                //Response.Write("<script>alert('Template Saved Successfully !!');window.close();currentid=null;current_saved=1</script>");
                tempnamehidden.Value = filename.Text;
                ajay = "'"+tempnamehidden.Value+"'";


                //savehidden.Value = filename.Text;
                //ankur = "'"+savehidden.Value+"'";


                Response.Write("<script>opener.document.getElementById('selected_name').value=" + ajay + ";alert('template Saved Successfully !!!');window.close();currentid=null;current_saved=1</script>"); ;
                //document.getElementById('saveT').focus();
                //Response.Write("<script>alert('Template Saved Successfully !!');</script>");
                //return; <script>alert('Template Saved Successfully !!');
            }
        }//string foldername = "Templates/";
        //string paths = Server.MapPath("") + ("/") + foldername + "//";
        //string location = paths + "Template_" + filename.Text + ".html";
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(location);
        //string blogdata = "<html><head><title>"+filename.Text+"</title></head><body>" + htmlval + "</body></html>";
        //sw.WriteLine(blogdata);
        //sw.Close();
    }
}


/*********************************************/
/*  string xmlval = savexml.Value;
    string filterhtml = savehtml.Value;
    string htmlval = completehtml.Value;
    if (filename.Text == "")
        {
            Response.Write("<script>alert('Please Specify Template name');</script>");
        }
    else
        {
            string thisname = "Template_" + filename.Text;
            string[] countdiv = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
            int len = countdiv.Length - 1;

            int newid = 1;
            int newid1 = 1;
            int newid2 = 1;


            for (int i = 0; i <= len; i++)
                {
                //int newid = 1;

                //    string src = i.innerHTML;
                //    char[] c ={ '\"' };
                string s = "src=";
            if (countdiv[i].IndexOf(s) >= 0)
                {
                    string[] path1 = countdiv[i].Split(new string[] { "src=" }, StringSplitOptions.None);
                    string[] path2 = path1[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                    // browse.Value = path2[1];
                    string foldernameIMG = "images1/";
                    string[] strsql = path2[1].Split('.');
                    string strFilename1 = "Image" + newid + "_" + temp_id.Value + "." + strsql[1];
                    string serverpath = Server.MapPath("") + ("/") + foldernameIMG + strFilename1;
                    string serverpath1 = serverpath.Replace(":", "$");

                    //      \\192.168.1.115\
                    //System.IO.File.Copy(path2[1], Server.MapPath("") + ("/") + foldername + strFilename1);
                    System.IO.File.Copy(path2[1], serverpath);


               }

            newid++;


            //    string[] image1 = path[1].Split(c);
            //    //path.Value = image1;
            //    //browse.Value = image1;
            //    //string[] strsql = image1.Split('.');
            //    //string foldername = "images/";
            //    //
            //    //string strfilename2 = foldername + strFilename1;
            //    //newid++;
            //    //browse.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);


        }



        //string[] newhtml = filterhtml.Split(new string[] { "\"" }, StringSplitOptions.None);

        //me

        string ac1 = null;
        string ac2 = null;
        string ac5 = null;
        string main = null;
        string[] ac = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
        for (int k = 0; k <= ac.Length - 1; k++)
        {

            string s1 = "src=";
            if (ac[k].IndexOf(s1) >= 0)
            {

                //ac1 = ac1 + ac[k];
                string[] ac11 = ac[k].Split(new string[] { "src=" }, StringSplitOptions.None);
                string[] ac111 = ac11[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                string foldernameIMG = "images1/";
                string[] strsql1 = ac111[1].Split('.');
                string strFilename1 = "Image" + newid1 + "_" + temp_id.Value + "." + strsql1[1];
                string serverpath = Server.MapPath("") + ("/") + foldernameIMG + strFilename1;

                //string sevpth = "c:/abc";
                main = main + "<DIV" + ac11[0] + "src=" + '"' + serverpath + '\"' + ac111[2];


            }
            if (ac[k] == "")
            {
                ac5 = ac5 + ac[k];
            }
            //else
            if (ac[k].IndexOf(s1) < 0 && ac[k] != "")
            {

                ac2 = ac2 + "<DIV" + ac[k];

            }
            newid1++;
        }

        string main1 = ac5 + ac2 + main;


        //me



        //me1

        string ac1new = null;
        string ac2new = null;
        string ac5new = null;
        string mainnew = null;
        string[] acnew = htmlval.Split(new string[] { "<DIV" }, StringSplitOptions.None);
        //string abc = Server.MapPath + ("/") + ("abc");
        //System.IO.Directory.CreateDirectory(@abc);
        for (int l = 0; l <= acnew.Length - 1; l++)
        {

            string s1 = "src=";
            if (acnew[l].IndexOf(s1) >= 0)
            {


                //ac1 = ac1 + ac[k];
                string[] ac11new = acnew[l].Split(new string[] { "src=" }, StringSplitOptions.None);
                string[] ac111new = ac11new[1].Split(new string[] { "\"" }, StringSplitOptions.None);
                string foldernameIMG = "images1/";
                string[] strsql1 = ac111new[1].Split('.');
                string strFilename1 = "Image" + newid2 + "_" + temp_id.Value + "." + strsql1[1];
                string serverpath = Server.MapPath("") + ("/") + foldernameIMG + strFilename1;

                //string sevpth = "c:/abc";
                mainnew = mainnew + "<DIV" + ac11new[0] + "src=" + '"' + serverpath + '\"' + ac111new[2];
                //string mainneww = mainnew.Replace("'","");

            }
            if (acnew[l] == "")
            {
                ac5new = ac5new + acnew[l];
            }
            //else
            if (acnew[l].IndexOf(s1) < 0 && acnew[l] != "")
            {

                ac2new = ac2new + "<DIV" + acnew[l];

            }
            newid2++;
        }

        string main1new = ac5new + ac2new + mainnew;




        //me1

        // newid++;

        string idTemp = temp_id.Value;
        string foldernameTMP = "Templates/";
        string paths = Server.MapPath("") + ("/") + foldernameTMP + "//";
        string location = paths + thisname + ".xml";
        System.IO.StreamWriter sw = new System.IO.StreamWriter(location);
        sw.WriteLine(xmlval);
        sw.Close();
        //string blogdata = xmlval;
        DataSet ds = new DataSet();
        // ds = obj.insertxml(Convert.ToInt32(idTemp), location , xmlval,thisname,htmlval,filterhtml);
        ds = obj.insertxml(Convert.ToInt32(idTemp), location, xmlval, thisname, mainnew, main1);

        Response.Write("<script>alert('Template Saved Successfully');window.close();</script>");
    }
}//string foldername = "Templates/";
    //string paths = Server.MapPath("") + ("/") + foldername + "//";
    //string location = paths + "Template_" + filename.Text + ".html";
    //System.IO.StreamWriter sw = new System.IO.StreamWriter(location);
    //string blogdata = "<html><head><title>"+filename.Text+"</title></head><body>" + htmlval + "</body></html>";
    //sw.WriteLine(blogdata);
    //sw.Close();
}*/
