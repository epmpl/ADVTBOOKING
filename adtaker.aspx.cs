using System;
using System.Data;
using System.Configuration;
using System.Drawing.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    //NewAdbooking.Classes.cls obj5 = new NewAdbooking.Classes.cls();

    string temp_id1 = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(_Default));
        txtpathname.Value = ConfigurationManager.AppSettings["imagepath"].ToString();
        configuom.Value = ConfigurationManager.AppSettings["uom"].ToString();
        //catname.Attributes.Add("onchange", "test(this.value)");
        string testname = Request.QueryString["str"];
        string category = Request.QueryString["category"];


        hdnadsname.Value=Request.QueryString["ciobookid"]+"-";
        hdnadsname.Value += Request.QueryString["ins"] + "-";
        hdnadsname.Value += Request.QueryString["edition"];
        fetchins.Value = Request.QueryString["fileid"];

        hiduom.Value = Request.QueryString["uom"];
         
        string text;
        if (Request.QueryString["id"] != null)
        {
            text = Request.QueryString["id"].ToString();
            hidattach.Value = text;
        }

        hdnadsname.Value += ".pdf";//Request.QueryString["fileid"];
     
        hiddencat.Value = category;

        fetchid.Value = testname;
        
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls obj5 = new NewAdbooking.Classes.cls();
            ds1 = obj5.get_id();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls obj = new NewAdbooking.classesoracle.orclcls();

            ds1 = obj.get_adid();
        }
          int ct = ds1.Tables[0].Rows.Count;
          //int ct1 = ds1.Tables[0].Rows[ct].ItemArray[0];

          if (ds1.Tables[0].Rows.Count > 0)
            {
              temp_id.Value = Convert.ToString(ct + 1);
            }
        else
        {
            temp_id.Value = "1";

        }


    }


    [Ajax.AjaxMethod]
    public DataSet update(string id, string tempxml, string ht1,string xhtml)
    {
        DataSet ds = new DataSet();
        // string xmlval1 = savehtml.Value;
        // string htmlval1 = completehtml.Value;

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls get = new NewAdbooking.Classes.cls();

            ds = get.updatexml(Convert.ToInt32(id), tempxml, ht1, xhtml);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls get = new NewAdbooking.classesoracle.orclcls();

            ds = get.updatexml(Convert.ToInt32(id), tempxml, ht1, xhtml);
        }
        
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getthevalue(string xmlid)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls Fetchquery = new NewAdbooking.Classes.cls();

            ds = Fetchquery.fetchquerydata(xmlid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls Fetchquery = new NewAdbooking.classesoracle.orclcls();

            ds = Fetchquery.fetchquerydata(xmlid);
        }
        
        return ds;

    }
    [Ajax.AjaxMethod]
    public DataSet adupdate(string id, string tempxml, string ht1, string xhtml)
    {
        DataSet ds = new DataSet();
        // string xmlval1 = savehtml.Value;
        // string htmlval1 = completehtml.Value;

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls get1 = new NewAdbooking.Classes.cls();

            ds = get1.updatexml1(Convert.ToInt32(id), tempxml, ht1, xhtml);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls get1 = new NewAdbooking.classesoracle.orclcls();

            ds = get1.updatexml1(Convert.ToInt32(id), tempxml, ht1, xhtml);
        }
       
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet getadvalue(string xmlid)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls Fetchquery1 = new NewAdbooking.Classes.cls();

            ds = Fetchquery1.fetchadquerydata(xmlid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls Fetchquery1 = new NewAdbooking.classesoracle.orclcls();

            ds = Fetchquery1.fetchadquerydata(xmlid);
        }
        
        return ds;

    }


    [Ajax.AjaxMethod]
    public DataSet bindxml()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls Fetchhtml = new NewAdbooking.Classes.cls();

            ds = Fetchhtml.fetchdata();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls Fetchhtml = new NewAdbooking.classesoracle.orclcls();

            ds = Fetchhtml.fetchdata();
        }
        
        //xmllist2.Items.Clear();
        //for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    //string[] temp = li.Value.Split('\\');
        //    //string[] temp2 = temp[2].Split('.');
        //    //string filename = temp2[0];
        //    xmllist2.Items.Add(li);
        //}
        return ds;
    }


    [Ajax.AjaxMethod]
    public DataSet bindadxml()
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls Fetchhtml1 = new NewAdbooking.Classes.cls();

            ds = Fetchhtml1.fetchadhtmdata();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls Fetchhtml1 = new NewAdbooking.classesoracle.orclcls();

            ds = Fetchhtml1.fetchadhtmdata();
        }
        
        //xmllist2.Items.Clear();
        //for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    //string[] temp = li.Value.Split('\\');
        //    //string[] temp2 = temp[2].Split('.');
        //    //string filename = temp2[0];
        //    xmllist2.Items.Add(li);
        //}
        return ds;
    }

    //test1.Value=testname;


    //[Ajax.AjaxMethod]
    //public string chk2badword(string str)
    //{
    //   int i;
    //   DataSet ds = new DataSet();

    //   if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //   {
    //       NewAdbooking.Classes.badwordnew log = new NewAdbooking.Classes.badwordnew();

    //       ds = log.chkbadword1(str);
    //   }
    //   else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //   {
    //       //NewAdbooking.Classes.badwordnew log = new NewAdbooking.Classes.badwordnew();
    //       NewAdbooking.classesoracle.orclcls log = new NewAdbooking.classesoracle.orclcls();

    //       ds = log.chkbadword1(str);
    //   }
       
    // if (ds.Tables[0].Rows.Count > 0)
    //  {
          
    //        return "True~"+str;
    //  }
    //    else
    //    {
    //        return "False";

    //    }

    //}


    [Ajax.AjaxMethod]
    public DataSet bindtemplate(string myid)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls dd = new NewAdbooking.Classes.cls();

            ds = dd.fatchcatemplate(myid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls dd = new NewAdbooking.classesoracle.orclcls();

            ds = dd.fatchcatemplate(myid);
        }
        
        return ds;
    }




/*************************************/

    [Ajax.AjaxMethod]
    public DataSet binduom(string uom)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls aj = new NewAdbooking.Classes.cls();

            ds = aj.fetchaduom(uom);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls aj = new NewAdbooking.classesoracle.orclcls();

            ds = aj.fetchaduom(uom);
        }
        
        return ds;


    }


    /* ajay
     [Ajax.AjaxMethod]
    public string test(string editordivhtml, string editordivfullhtml, string editordivxml, string height, string width, string uom, string adname, string fetchins)

    {
        ankur(editordivhtml, editordivfullhtml, editordivxml, height, width, uom, adname);
        return "Success~" + height + "~" + width +"~" + adname + "~" + temp_id1+"~"+fetchins;
    }

    public void ankur(string editordivhtml, string editordivfullhtml, string editordivxml, string height, string width, string uom,string adname)
    {
        
        //ABPNEW.classes.ABPNEW.classes.cls obj = new ABPNEW.classes.ABPNEW.classes.cls();
       // ABPNEW.classes.cls obj = new ABPNEW.classes.cls();
        DataSet ds1 = new DataSet();

        string filterhtml = editordivhtml;
        string htmlval = editordivfullhtml;
        string xmlval = editordivxml;
        string abc = "";
        string abc1 = "";
        string thisname = adname;

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls dd = new NewAdbooking.Classes.cls();
            ds1 = dd.get_adid();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls dd = new NewAdbooking.classesoracle.orclcls();
            ds1 = dd.get_adid();
        }
        
        //ds1 = obj.get_adid();

        int ct = ds1.Tables[0].Rows.Count;

        if (ds1.Tables[0].Rows.Count > 0)
        {
           temp_id1 = Convert.ToString(ct + 1);
        }
        else
        {
            temp_id1 = "1";
        }
        string[] countdiv = filterhtml.Split(new string[] { "<DIV" }, StringSplitOptions.None);
        int len = countdiv.Length - 1;

        /*********************************************/

       /* ajay
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
                string strFilename1 = "Image" + newid + "_" + temp_id1 + "." + strsql[1];
                string serverpath = "\\\\" + Server.MapPath("") + ("/") + foldernameIMG + strFilename1;
                string serverpath1 = serverpath.Replace(":", "$");
                string bcd = "\\\\" + abc + "\\" + path2[1];
                string hostadd = bcd.Replace(":", "$");

                //string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                //string fn = System.IO.Path.GetFileName(hostadd);
                //string SaveLocation = serverpath1;
                //File1.PostedFile.SaveAs(SaveLocation);

                //System.IO.File.Copy(hostadd, serverpath1);

            }

            newid++;


            /*  string[] image1 = path[1].Split(c);
                path.Value = image1;
                browse.Value = image1;
                string[] strsql = image1.Split('.');
                string foldername = "images/";
                string strfilename2 = foldername + strFilename1;
                newid++;
             //   browse.PostedFile.SaveAs(Server.MapPath("") + ("/") + foldername + "//" + strFilename1);*/


       // }



        //string[] newhtml = filterhtml.Split(new string[] { "\"" }, StringSplitOptions.None);

        //me

        //string ac1 = null; ajay*/
     /* ajay
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

/* ajay

        string idTemp = "Firtst";
        string foldernameTMP = "Templates/";
        string paths = Server.MapPath("") + ("/") + foldernameTMP + "//";
        string location = paths + thisname + ".xml";
        xmlval = xmlval.Replace("<template>undefined", "<template>" );
        xmlval = xmlval.Replace("undefined", " ");
        xmlval = xmlval.Replace("<text />", "<text><text/>");
        xmlval = xmlval.Replace("<bgimage/>", "<bgimage><bgimage/>");
       // System.IO.StreamWriter sw = new System.IO.StreamWriter(location);
       // sw.WriteLine(xmlval);
       // sw.Close();
        //string blogdata = xmlval;
        DataSet ds = new DataSet();
        //string htmlval1 = htmlval.Replace("file:///", "");
        //htmlval1 = htmlval1.Replace("%20", " ");
        //htmlval1 = htmlval1.Replace("//", "\\");
        //string filterhtml1 = filterhtml.Replace("file:///", "");
        //filterhtml1 = filterhtml1.Replace("%20", " ");
        //filterhtml1 = filterhtml1.Replace("//", "\\");
        //ds = obj.insertxml(Convert.ToInt32(idTemp), location, xmlval, thisname, main1new, main1);
        string adh = height;
        string adw = width;
        string uom1 = uom;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cls dd1 = new NewAdbooking.Classes.cls();

            ds = dd1.insertadxml(Convert.ToInt16(temp_id1), xmlval, thisname, htmlval, filterhtml, uom1, adh, adw);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.orclcls dd1 = new NewAdbooking.classesoracle.orclcls();

            ds = dd1.insertadxml(Convert.ToInt16(temp_id1), xmlval, thisname, htmlval, filterhtml, uom1, adh, adw);
        }
        


    }ajay */


    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public string test(string editordivhtml, string editordivfullhtml, string editordivxml, string height, string width, string uom, string adname, string fetchins,string varid)
    {
        //string ad_type
        //ankur(editordivhtml, editordivfullhtml, editordivxml, height, width, uom, adname);
        //createpdf(editordivhtml, editordivfullhtml, adname,"PDF");
        HttpContext.Current.Session["editordivhtml"] = editordivhtml;
        HttpContext.Current.Session["editordivfullhtml"] = editordivfullhtml;
        HttpContext.Current.Session["editordivxml"] = editordivxml;
        HttpContext.Current.Session["adname"] = adname;
        HttpContext.Current.Session["height"] = height;
        HttpContext.Current.Session["width"] = width;
        HttpContext.Current.Session["uom"] = uom;
        HttpContext.Current.Session["selectid"] = fetchins;
        HttpContext.Current.Session["insid"] = varid;


        //HttpContext.Current.Session["img_name"] = img_name;
       //HttpContext.Current.Session["ad_type"] = ad_type;
        return "sucess";
    }



 }







 






